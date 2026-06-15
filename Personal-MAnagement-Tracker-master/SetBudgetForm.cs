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
    public partial class SetBudgetForm : Form
    {
        public SetBudgetForm()
        {
            InitializeComponent();
            LoadComboBox();
        }
        private void LoadComboBox()
        {
            SQLServerRepository repo= new SQLServerRepository();
            cmbCategory.DataSource=repo.GetCategories("Expense");
            cmbCategory.DisplayMember = "[Category Name]";
            cmbCategory.ValueMember = "[Category Id]";
        }

        private void SetBudgetForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbCategory.SelectedItem == null)
                {
                    MessageBox.Show("Please Select a Category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if(!decimal.TryParse(txtAmount.Text, out decimal amount)|| amount <= 0)
                {
                    MessageBox.Show("Invalid or non-Positive amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int categoryid = Convert.ToInt32((ComboBox)cmbCategory.SelectedValue);
                //Set Period to first day of selected month
                DateTime period = new DateTime(dtpPeriod.Value.Year, dtpPeriod.Value.Month, 1);
                SQLServerRepository repo = new SQLServerRepository();
                repo.AddBudget(categoryid, period, amount);
                MessageBox.Show("Budget get Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Failed to set budget.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
