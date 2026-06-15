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
    public partial class AddSavingsGoalForm : Form
    {
        public AddSavingsGoalForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //validate goal name
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Goal Name is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //validate Target Amount
                if(!decimal.TryParse(txtTargetAmount.Text,out decimal targetAmount) || targetAmount <= 0)
                {
                    MessageBox.Show("Invalid or non-positive Target Amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //validate deadline
                if (dtpDeadline.Value < DateTime.Today)
                {
                    MessageBox.Show("Deadline cannot be in the Past.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //Add saving goal to the database
                SQLServerRepository repo = new SQLServerRepository();
                repo.AddSavingsGoal(txtName.Text, targetAmount, dtpDeadline.Value);
                MessageBox.Show("Savings Goal added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to add Saving Goal: {ex.Message}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
