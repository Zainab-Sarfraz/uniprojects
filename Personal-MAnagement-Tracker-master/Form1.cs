using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Personal_MAnagement_Tracker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_Addaccount_Click(object sender, EventArgs e)
        {
            new AddAccountForm().ShowDialog();
        }

        private void btn_AddTransaction_Click(object sender, EventArgs e)
        {
            new AddTransactionForm().ShowDialog();
        }

        private void btn_SetBudget_Click(object sender, EventArgs e)
        {
            new SetBudgetForm().ShowDialog();
        }

        private void btn_AddSavingGoals_Click(object sender, EventArgs e)
        {
            new AddSavingsGoalForm().ShowDialog();
        }

        private void btnAddInvestment_Click(object sender, EventArgs e)
        {
            new AddInvestmentForm().ShowDialog();
        }

        private void btnMonthlySpendingReport_Click(object sender, EventArgs e)
        {
            new MonthlySpendingReportForm().ShowDialog();
        }

        private void btnBudgetComplianceReport_Click(object sender, EventArgs e)
        {
            new BudgetComplianceReportForm().ShowDialog();
        }
    }
}
