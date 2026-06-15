using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Personal_MAnagement_Tracker
{
    public partial class AddInvestmentForm : Form
    {
        public AddInvestmentForm()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Investment name is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!decimal.TryParse(txtPurchasePrice.Text, out decimal purchaseprice) || purchaseprice <= 0)
                {
                    MessageBox.Show("Invalid or non-positive Purchase Price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!decimal.TryParse(txtCurrentValue.Text, out decimal currentvalue) || currentvalue <= 0)
                {
                    MessageBox.Show("Invalid or non-positive current value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Get date from DateTimePicker
                DateTime purchaseDate = dtpPurchaseDate.Value;

                // Add investment to database using the repository instance
                SQLServerRepository repo = new SQLServerRepository();
                repo.AddInvestment(txtName.Text, purchaseprice, currentvalue, purchaseDate);

                // Show success message and close form
                MessageBox.Show("Investment added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to add investment: {ex.Message}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
