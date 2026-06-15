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
    public partial class AddTransactionForm : Form
    {
        public AddTransactionForm()
        {
            InitializeComponent();
            LoadComboBoxes();
        }

        private void AddTransactionForm_Load(object sender, EventArgs e)
        {

        }
        //Load ComboBoxes
        private void LoadComboBoxes()
        {
            //bind accounts to ComboBoxes
            SQLServerRepository repo=new SQLServerRepository();
            cmbAccount.DataSource = repo.GetAccounts();
            cmbAccount.DisplayMember = "[Account Name]";
            cmbAccount.ValueMember = "[Account ID]";
            //Bind Category to ComboBoxes
            cmbAccount.DataSource = repo.GetCategories();
            cmbAccount.DisplayMember = "[Category Name]";
            cmbAccount.ValueMember = "[Category ID]";
        }
        private void lblAccount_Click(object sender, EventArgs e)
        {
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //Validate ComboBox Selection
                if (cmbAccount.SelectedItem == null || cmbCategory.SelectedItem == null)
                {
                    MessageBox.Show("Please Select an Account or Category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //Validate Amount
                if(!decimal.TryParse(txtAmount.Text, out decimal amount))
                {
                    MessageBox.Show("Invalid or non-positive Amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //Get Selected Account and category IDs
                int accountid = ((ComboBoxItem)cmbAccount.SelectedItem).ID;
                int categoryid = ((ComboBoxItem)cmbCategory.SelectedItem).ID;
                //Add Transaction to database
                SQLServerRepository repo = new SQLServerRepository();
                repo.AddTransaction(accountid, categoryid, amount, dtpDate.Value, txtDescription.Text);
                MessageBox.Show("Transaction Added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to add transaction: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
