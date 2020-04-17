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

namespace ExpenseApplication
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
            this.button1 = new System.Windows.Forms.Button();
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
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(298, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Submit Report";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lstvwExpenseReports
            // 
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
            this.lstvwExpenseReports.Size = new System.Drawing.Size(521, 132);
            this.lstvwExpenseReports.TabIndex = 3;
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
            this.btnRefresh.Location = new System.Drawing.Point(412, 218);
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
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Amount:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(144, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Submitted By:";
            // 
            // txtSubmittedBy
            // 
            this.txtSubmittedBy.Location = new System.Drawing.Point(145, 28);
            this.txtSubmittedBy.Name = "txtSubmittedBy";
            this.txtSubmittedBy.Size = new System.Drawing.Size(136, 20);
            this.txtSubmittedBy.TabIndex = 1;
            this.txtSubmittedBy.Text = "Ari Bixhorn";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(13, 28);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(100, 20);
            this.txtAmount.TabIndex = 0;
            this.txtAmount.Text = "1500";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 248);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.txtSubmittedBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lstvwExpenseReports);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Expense Reporting";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
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
	}
}

