//--------------------------------------------------------------------------------
// This file is a "Sample" as from Windows Workflow Foundation
// Hands on Labs RC
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//
// This source code is intended only as a supplement to Microsoft
// Development Tools and/or on-line documentation.  See these other
// materials for detailed information regarding Microsoft code samples.
// 
// THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//--------------------------------------------------------------------------------

namespace ManagerApplication
{
	partial class Form1
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
            this.lstvwExpenseReports = new System.Windows.Forms.ListView();
            this.ExpenseReportId = new System.Windows.Forms.ColumnHeader();
            this.Amount = new System.Windows.Forms.ColumnHeader();
            this.SubmittedTime = new System.Windows.Forms.ColumnHeader();
            this.SubmittedBy = new System.Windows.Forms.ColumnHeader();
            this.Status = new System.Windows.Forms.ColumnHeader();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstvwExpenseReports
            // 
            this.lstvwExpenseReports.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ExpenseReportId,
            this.Amount,
            this.SubmittedTime,
            this.SubmittedBy,
            this.Status});
            this.lstvwExpenseReports.Dock = System.Windows.Forms.DockStyle.Top;
            this.lstvwExpenseReports.FullRowSelect = true;
            this.lstvwExpenseReports.GridLines = true;
            this.lstvwExpenseReports.Location = new System.Drawing.Point(0, 0);
            this.lstvwExpenseReports.Name = "lstvwExpenseReports";
            this.lstvwExpenseReports.Size = new System.Drawing.Size(569, 132);
            this.lstvwExpenseReports.TabIndex = 3;
            this.lstvwExpenseReports.View = System.Windows.Forms.View.Details;
            // 
            // ExpenseReportId
            // 
            this.ExpenseReportId.Text = "Expense Report Id";
            this.ExpenseReportId.Width = 138;
            // 
            // Amount
            // 
            this.Amount.Text = "Amount";
            this.Amount.Width = 86;
            // 
            // SubmittedTime
            // 
            this.SubmittedTime.Text = "Submitted Time";
            this.SubmittedTime.Width = 119;
            // 
            // SubmittedBy
            // 
            this.SubmittedBy.DisplayIndex = 4;
            this.SubmittedBy.Text = "Submitted By";
            this.SubmittedBy.Width = 115;
            // 
            // Status
            // 
            this.Status.DisplayIndex = 3;
            this.Status.Text = "Status";
            this.Status.Width = 88;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(482, 147);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnApprove
            // 
            this.btnApprove.Location = new System.Drawing.Point(320, 147);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(75, 23);
            this.btnApprove.TabIndex = 5;
            this.btnApprove.Text = "Approve";
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnReject
            // 
            this.btnReject.Location = new System.Drawing.Point(401, 147);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(75, 23);
            this.btnReject.TabIndex = 6;
            this.btnReject.Text = "Reject";
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 176);
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lstvwExpenseReports);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Manager Expense Report Review";
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView lstvwExpenseReports;
		private System.Windows.Forms.ColumnHeader ExpenseReportId;
		private System.Windows.Forms.ColumnHeader Amount;
		private System.Windows.Forms.ColumnHeader SubmittedTime;
		private System.Windows.Forms.ColumnHeader Status;
		private System.Windows.Forms.ColumnHeader SubmittedBy;
		private System.Windows.Forms.Button btnRefresh;
		private System.Windows.Forms.Button btnApprove;
		private System.Windows.Forms.Button btnReject;
	}
}

