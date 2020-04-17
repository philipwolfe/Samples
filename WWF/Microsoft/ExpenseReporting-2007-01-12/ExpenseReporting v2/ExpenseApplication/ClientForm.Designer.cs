//---------------------------------------------------------------------
//  This file is part of the WindowsWorkflow.NET web site samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//  This source code is intended only as a supplement to Microsoft
//  Development Tools and/or on-line documentation.  See these other
//  materials for detailed information regarding Microsoft code samples.
// 
//  THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//  PARTICULAR PURPOSE.
//---------------------------------------------------------------------

namespace ExpenseApplication
{
	partial class ClientForm
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
            this.btnSubmitReport = new System.Windows.Forms.Button();
            this.lstvwExpenseReports = new System.Windows.Forms.ListView();
            this.ExpenseReportId = new System.Windows.Forms.ColumnHeader();
            this.Amount = new System.Windows.Forms.ColumnHeader();
            this.SubmittedTime = new System.Windows.Forms.ColumnHeader();
            this.SubmittedBy = new System.Windows.Forms.ColumnHeader();
            this.Status = new System.Windows.Forms.ColumnHeader();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSubmittedBy = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSubmitReport
            // 
            this.btnSubmitReport.Location = new System.Drawing.Point(298, 27);
            this.btnSubmitReport.Name = "btnSubmitReport";
            this.btnSubmitReport.Size = new System.Drawing.Size(104, 23);
            this.btnSubmitReport.TabIndex = 2;
            this.btnSubmitReport.Text = "Submit Report";
            this.btnSubmitReport.Click += new System.EventHandler(this.btnSubmitReport_Click);
            // 
            // lstvwExpenseReports
            // 
            this.lstvwExpenseReports.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstvwExpenseReports.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ExpenseReportId,
            this.Amount,
            this.SubmittedTime,
            this.SubmittedBy,
            this.Status});
            this.lstvwExpenseReports.FullRowSelect = true;
            this.lstvwExpenseReports.GridLines = true;
            this.lstvwExpenseReports.Location = new System.Drawing.Point(0, 80);
            this.lstvwExpenseReports.Name = "lstvwExpenseReports";
            this.lstvwExpenseReports.Size = new System.Drawing.Size(519, 128);
            this.lstvwExpenseReports.TabIndex = 3;
            this.lstvwExpenseReports.UseCompatibleStateImageBehavior = false;
            this.lstvwExpenseReports.View = System.Windows.Forms.View.Details;
            // 
            // ExpenseReportId
            // 
            this.ExpenseReportId.Text = "Expense Report Id";
            this.ExpenseReportId.Width = 126;
            // 
            // Amount
            // 
            this.Amount.Text = "Amount";
            this.Amount.Width = 86;
            // 
            // SubmittedTime
            // 
            this.SubmittedTime.Text = "SubmittedTime";
            this.SubmittedTime.Width = 119;
            // 
            // SubmittedBy
            // 
            this.SubmittedBy.DisplayIndex = 4;
            this.SubmittedBy.Text = "Submitted By";
            this.SubmittedBy.Width = 92;
            // 
            // Status
            // 
            this.Status.DisplayIndex = 3;
            this.Status.Text = "Status";
            this.Status.Width = 86;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(398, 214);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(109, 23);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh Reports";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Amount:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(144, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Submitted By:";
            // 
            // txtSubmittedBy
            // 
            this.txtSubmittedBy.Location = new System.Drawing.Point(145, 28);
            this.txtSubmittedBy.Name = "txtSubmittedBy";
            this.txtSubmittedBy.Size = new System.Drawing.Size(136, 20);
            this.txtSubmittedBy.TabIndex = 1;
            this.txtSubmittedBy.Text = "AB";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(13, 28);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(100, 20);
            this.txtAmount.TabIndex = 0;
            this.txtAmount.Text = "1500";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 243);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(511, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(41, 17);
            this.toolStripStatusLabel1.Text = "Done.";
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 265);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.txtSubmittedBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lstvwExpenseReports);
            this.Controls.Add(this.btnSubmitReport);
            this.Name = "ClientForm";
            this.Text = "Expense Reporting";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnSubmitReport;
		private System.Windows.Forms.ListView lstvwExpenseReports;
		private System.Windows.Forms.ColumnHeader ExpenseReportId;
		private System.Windows.Forms.ColumnHeader Amount;
		private System.Windows.Forms.ColumnHeader SubmittedTime;
		private System.Windows.Forms.Button btnRefresh;
		private System.Windows.Forms.ColumnHeader Status;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtSubmittedBy;
		private System.Windows.Forms.ColumnHeader SubmittedBy;
		private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
	}
}

