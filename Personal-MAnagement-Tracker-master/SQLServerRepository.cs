using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_MAnagement_Tracker
{
    public class SQLServerRepository
    {
        private string connectionString = "Data Source=. ;Initial Catalog=PersonalMnagementTracker;" + "Integrated Security=True";
        //Add a new Account to the account table
        public void AddAccount(string name, string accountype, decimal balance)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "Insert into Account([Account Name],[Account Type],Balance)  Values (@AccountName,@AccountType,@Balance)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@AccountName", name);
                    cmd.Parameters.AddWithValue("@AccountType", accountype);
                    cmd.Parameters.AddWithValue("@Balance", balance);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        //Add a new transaction and update related tables (Accounts,Saving Goals)
        public void AddTransaction(int accountid, int categoryid, decimal amount, DateTime date, string description)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())//Automatic start transaction
                {
                    try
                    {
                        string query = "Insert into Transactions(AccountId,CategoryId,Amount,TransactionDate,[Description]" +
                            "Values (@AccountId, @CategoryId, @Amount, @TransactionDate, @Description";
                        using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@AccountId", accountid);
                            cmd.Parameters.AddWithValue("@CategoryId", categoryid);
                            cmd.Parameters.AddWithValue("@Amount", amount);
                            cmd.Parameters.AddWithValue("@TransactionDate", date);
                            cmd.Parameters.AddWithValue("@Description", description);
                            cmd.ExecuteNonQuery();
                        }
                        //Update Account Balance based on Category Type
                        string updatebalance = "Update Account set Balance=Balance-@Amount" +
                            "where AccountId=@AccountId";
                        if (GetCategoryName(categoryid) == "Expense")
                        {
                            updatebalance = "Update Account set Balance=Balance-@Amount" +
                            "where AccountId=@AccountId";
                            using (SqlCommand cmd = new SqlCommand(updatebalance, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@AccountId", accountid);
                                cmd.Parameters.AddWithValue("@Amount", amount);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        //Update Savings goal if category is Savings Contribution
                        if (GetCategoryName(categoryid) == "Savings Contribution")
                        {
                            updatebalance = "Update SavingsGoal set[Current Amount]=[Current Amount]+@Amount" +
                            "where [Goal Id]=1";
                            using (SqlCommand cmd = new SqlCommand(updatebalance, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@Amount", amount);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();//Rollback an error
                        throw;//Rethrow exception for UI handling
                    }
                }
            }
        }
        //Add Budget
        public void AddBudget(int categoryId, DateTime period, decimal amount)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open(); // Open database connection
                             // SQL query to insert a new budget, using DateTime for Period
                string query = "INSERT INTO Budgets ([Category Id], [Period], Amount) VALUES (@CategoryId, @Period, @Amount)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Add parameters to prevent SQL injection
                    cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                    cmd.Parameters.AddWithValue("@Period", period);
                    cmd.Parameters.AddWithValue("@Amount", amount);
                    cmd.ExecuteNonQuery(); // Execute the insert command
                }
            }
        }
        //Add savings Goal
        public void AddSavingsGoal(string name, decimal targetAmount, DateTime deadline)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open(); // Open database connection
                             // SQL query to insert a new savings goal
                string query = "INSERT INTO SavingsGoals ([Goal Name], [Target Amount], Deadline) VALUES (@Name, @TargetAmount, @Deadline)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Add parameters to prevent SQL injection
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@TargetAmount", targetAmount);
                    cmd.Parameters.AddWithValue("@Deadline", deadline);
                    cmd.ExecuteNonQuery(); // Execute the insert command
                }
            }
        }
        //Add investment
        public void AddInvestment(string investmentName, decimal purchasePrice, decimal currentValue, DateTime purchaseDate)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open(); // Open database connection
                             // SQL query matches Investments table columns (Investment Id is auto-incremented)
                string query = "INSERT INTO Investments ([Investment Name], [Purchase Price], [Current Value], [Purchase Date]) " +
                               "VALUES (@InvestmentName, @PurchasePrice, @CurrentValue, @PurchaseDate)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Add parameters to prevent SQL injection
                    cmd.Parameters.AddWithValue("@InvestmentName", investmentName);
                    cmd.Parameters.AddWithValue("@PurchasePrice", purchasePrice);
                    cmd.Parameters.AddWithValue("@CurrentValue", currentValue);
                    cmd.Parameters.AddWithValue("@PurchaseDate", purchaseDate);
                    cmd.ExecuteNonQuery(); // Execute the insert command
                }
            }
        }
        //Retrieve list of accounts from combobox binding
        public List<ComboBoxItem> GetAccounts()
        {
            List<ComboBoxItem> accounts = new List<ComboBoxItem>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT [Account ID],[Account Name] From Accounts";
                using (SqlCommand cmd=new SqlCommand(query, conn))
                {
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            accounts.Add(new ComboBoxItem { ID=reader.GetInt32(0),Name=reader.GetString(1) });
                        }
                    }
                }
            }
            return accounts;
        }
        //Retrieve Categories, Optionally Filtered by Type(Income,Expense)
        public List<ComboBoxItem> GetCategories(string type=null)
        {
            List<ComboBoxItem> categories = new List<ComboBoxItem>();
            using ( SqlConnection conn = new SqlConnection(connectionString) )
            {
                conn.Open();
                string query = "Select CategoryID from Categories";
                if (!string.IsNullOrEmpty(type))
                {
                    query += "where Type=@type";
                }
                using(SqlCommand cmd=new SqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(type))
                    {
                        cmd.Parameters.AddWithValue("@type", type);
                    }
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categories.Add(new ComboBoxItem { ID = reader.GetInt32(0), Name = reader.GetString(1) });
                        }
                    }
                }
            }
            return categories;
        }
        // Generate data for Monthly Spending Report
        public DataTable GetMonthlySpendingReport(DateTime month)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // Query to sum expenses by category for a given month
                string query = @"SELECT c.[Category Name] AS Category, SUM(t.Amount) AS TotalSpent
                             FROM Transactions t
                             JOIN Categories c ON t.CategoryId = c.[Category Id]
                             WHERE c.Type = 'Expense'
                             AND YEAR(t.TransactionDate) = @Year
                             AND MONTH(t.TransactionDate) = @Month
                             GROUP BY c.[Category Name]";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Year", month.Year);
                    cmd.Parameters.AddWithValue("@Month", month.Month);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt); // Fill DataTable with results
                    }
                }
            }
            return dt;
        }
        //Generate Data for budget compliance report
        public DataTable GetBudgetComplianceReport(DateTime month)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                //Query to compare budgeted vs. actual spending
                string query = @"Select c.[Category Name] AS Category,b.Amount AS Budgeted
                               COALESCE(SUM(t.Amount),0) AS Spent
                               b.Amount-COALESCE(SUM(t.Amount),0) AS Remain
                               From Budget b
                               Join category c ON b.[Category Id]=c.[Category Id]
                               Left Join Transactions t ON t.CategoryId=b.[Category Id]
                               AND YEAR(t.TransactionDate)=@Year
                               AND Month(t.TransactionDate)=@Month
                               where YEAR(b.Period)=@Year
                               AND Month(b.Period)=@Month
                               Group By c.[Category Name],b.Amount";
                using( SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Year", month.Year);
                    cmd.Parameters.AddWithValue("@Month", month.Month);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);//Fill DataTables with result
                    }
                }
            }
            return dt;
        }
        // Helper method to get category type (Income/Expense)
        private string GetCategoryType(int categoryid)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "Select Type From Categories where [Category Id]=@categoryid";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@categoryid", categoryid);
                    return (string)cmd.ExecuteScalar();
                }
            }
        }
        //Helper Method to get category name
        private string GetCategoryName(int categoryid)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "Select [Category Name] From Categories where [Category Id]=@categoryid ";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@categoryid", categoryid);
                    return (string)cmd.ExecuteScalar();
                }
            }
        }
    }
}

