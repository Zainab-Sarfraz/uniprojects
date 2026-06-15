using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Personal_MAnagement_Tracker
{
    public partial class AddAccountForm : Form
    {
        public AddAccountForm()
        {
            InitializeComponent();
            cmbType.SelectedIndex = 0;
        }

        private void AddAccountForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //Validate Account Name
                if (string.IsNullOrWhiteSpace(txtAcountName.Text))
                {
                    MessageBox.Show("Account Name is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //Validate Balance
                if(!decimal.TryParse(Balance.Text, out decimal balance) || balance < 0)
                {
                    MessageBox.Show("Invalid or negative balance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //Add Account to Database
                SQLServerRepository repository = new SQLServerRepository();
                repository.AddAccount(txtName.Text, cmbType.SelectedItem.ToString(), balance);
                MessageBox.Show("Account added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                // Handle errors (e.g., duplicate name)
                MessageBox.Show($"Failed to add account: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
