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
    public partial class MonthlySpendingReportForm : Form
    {
        public MonthlySpendingReportForm()
        {
            InitializeComponent();
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime Month = dtpMonth.Value;
                SQLServerRepository repository = new SQLServerRepository();
                DataTable dt = repository.GetMonthlySpendingReport(Month);
                dataGridViewReport.DataSource = dt;
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No spending data found for the selected month.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Error generating report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
