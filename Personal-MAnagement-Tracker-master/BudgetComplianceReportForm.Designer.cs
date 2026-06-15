namespace Personal_MAnagement_Tracker
{
    partial class BudgetComplianceReportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BudgetComplianceReportForm));
            this.lblMonth = new System.Windows.Forms.Label();
            this.lblBudgeted = new System.Windows.Forms.Label();
            this.dtpMonth = new System.Windows.Forms.DateTimePicker();
            this.lblSpent = new System.Windows.Forms.Label();
            this.lblCompliance = new System.Windows.Forms.Label();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dataGridViewCompliance = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompliance)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonth.Location = new System.Drawing.Point(63, 69);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(111, 37);
            this.lblMonth.TabIndex = 0;
            this.lblMonth.Text = "Month";
            // 
            // lblBudgeted
            // 
            this.lblBudgeted.AutoSize = true;
            this.lblBudgeted.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBudgeted.Location = new System.Drawing.Point(613, 69);
            this.lblBudgeted.Name = "lblBudgeted";
            this.lblBudgeted.Size = new System.Drawing.Size(124, 37);
            this.lblBudgeted.TabIndex = 1;
            this.lblBudgeted.Text = "Budget";
            // 
            // dtpMonth
            // 
            this.dtpMonth.Location = new System.Drawing.Point(217, 77);
            this.dtpMonth.Name = "dtpMonth";
            this.dtpMonth.Size = new System.Drawing.Size(315, 26);
            this.dtpMonth.TabIndex = 2;
            // 
            // lblSpent
            // 
            this.lblSpent.AutoSize = true;
            this.lblSpent.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpent.Location = new System.Drawing.Point(1008, 69);
            this.lblSpent.Name = "lblSpent";
            this.lblSpent.Size = new System.Drawing.Size(105, 37);
            this.lblSpent.TabIndex = 3;
            this.lblSpent.Text = "Spent";
            // 
            // lblCompliance
            // 
            this.lblCompliance.AutoSize = true;
            this.lblCompliance.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompliance.Location = new System.Drawing.Point(769, 69);
            this.lblCompliance.Name = "lblCompliance";
            this.lblCompliance.Size = new System.Drawing.Size(196, 37);
            this.lblCompliance.TabIndex = 4;
            this.lblCompliance.Text = "Compilance";
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.BackColor = System.Drawing.Color.Lime;
            this.btnGenerateReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateReport.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGenerateReport.Location = new System.Drawing.Point(105, 232);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(184, 58);
            this.btnGenerateReport.TabIndex = 5;
            this.btnGenerateReport.Text = "Generate Report";
            this.btnGenerateReport.UseVisualStyleBackColor = false;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose.Location = new System.Drawing.Point(817, 234);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(184, 58);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // dataGridViewCompliance
            // 
            this.dataGridViewCompliance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCompliance.Location = new System.Drawing.Point(12, 335);
            this.dataGridViewCompliance.Name = "dataGridViewCompliance";
            this.dataGridViewCompliance.RowHeadersWidth = 62;
            this.dataGridViewCompliance.RowTemplate.Height = 28;
            this.dataGridViewCompliance.Size = new System.Drawing.Size(1215, 316);
            this.dataGridViewCompliance.TabIndex = 7;
            // 
            // BudgetComplianceReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1239, 663);
            this.Controls.Add(this.dataGridViewCompliance);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnGenerateReport);
            this.Controls.Add(this.lblCompliance);
            this.Controls.Add(this.lblSpent);
            this.Controls.Add(this.dtpMonth);
            this.Controls.Add(this.lblBudgeted);
            this.Controls.Add(this.lblMonth);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BudgetComplianceReportForm";
            this.Text = "BudgetComplianceReportForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompliance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.Label lblBudgeted;
        private System.Windows.Forms.DateTimePicker dtpMonth;
        private System.Windows.Forms.Label lblSpent;
        private System.Windows.Forms.Label lblCompliance;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dataGridViewCompliance;
    }
}