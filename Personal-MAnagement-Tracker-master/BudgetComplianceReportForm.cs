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
    public partial class BudgetComplianceReportForm : Form
    {
        public BudgetComplianceReportForm()
        {
            InitializeComponent();
            dtpMonth.Value=DateTime.Today;
            dataGridViewCompliance.AutoGenerateColumns = true; // Enable auto-generation of columns
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime Month = dtpMonth.Value;
                SQLServerRepository repository = new SQLServerRepository();
                DataTable dt = repository.GetBudgetComplianceReport(Month);
                dataGridViewCompliance.DataSource = dt;
                MessageBox.Show($"Budget Compilance report for{Month:yyyy-mm} is generated.", "Report Generated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
