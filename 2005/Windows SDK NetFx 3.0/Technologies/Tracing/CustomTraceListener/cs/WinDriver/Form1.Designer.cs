//---------------------------------------------------------------------
//  This file is part of the Microsoft .NET Framework SDK Code Samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//---------------------------------------------------------------------

namespace Microsoft.Samples.CustomTraceListener
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
			this.CriticalBtn = new System.Windows.Forms.Button();
			this.ErrorBtn = new System.Windows.Forms.Button();
			this.WarningBtn = new System.Windows.Forms.Button();
			this.InformationBtn = new System.Windows.Forms.Button();
			this.VerboseBtn = new System.Windows.Forms.Button();
			this.StartBtn = new System.Windows.Forms.Button();
			this.StopBtn = new System.Windows.Forms.Button();
			this.ResumeBtn = new System.Windows.Forms.Button();
			this.SuspendBtn = new System.Windows.Forms.Button();
			this.TransferBtn = new System.Windows.Forms.Button();
			this.RandomBtn = new System.Windows.Forms.Button();
			this.NumEventsTxtBox = new System.Windows.Forms.TextBox();
			this.FailBtn = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
// 
// CriticalBtn
// 
			this.CriticalBtn.Location = new System.Drawing.Point(13, 13);
			this.CriticalBtn.Name = "CriticalBtn";
			this.CriticalBtn.TabIndex = 0;
			this.CriticalBtn.Text = "Critical";
			this.CriticalBtn.Click += new System.EventHandler(this.CriticalBtn_Click);
// 
// ErrorBtn
// 
			this.ErrorBtn.Location = new System.Drawing.Point(13, 43);
			this.ErrorBtn.Name = "ErrorBtn";
			this.ErrorBtn.TabIndex = 1;
			this.ErrorBtn.Text = "Error";
			this.ErrorBtn.Click += new System.EventHandler(this.ErrorBtn_Click);
// 
// WarningBtn
// 
			this.WarningBtn.Location = new System.Drawing.Point(13, 73);
			this.WarningBtn.Name = "WarningBtn";
			this.WarningBtn.TabIndex = 2;
			this.WarningBtn.Text = "Warning";
			this.WarningBtn.Click += new System.EventHandler(this.WarningBtn_Click);
// 
// InformationBtn
// 
			this.InformationBtn.Location = new System.Drawing.Point(13, 103);
			this.InformationBtn.Name = "InformationBtn";
			this.InformationBtn.TabIndex = 3;
			this.InformationBtn.Text = "Information";
			this.InformationBtn.Click += new System.EventHandler(this.InformationBtn_Click);
// 
// VerboseBtn
// 
			this.VerboseBtn.Location = new System.Drawing.Point(13, 133);
			this.VerboseBtn.Name = "VerboseBtn";
			this.VerboseBtn.TabIndex = 4;
			this.VerboseBtn.Text = "Verbose";
			this.VerboseBtn.Click += new System.EventHandler(this.VerboseBtn_Click);
// 
// StartBtn
// 
			this.StartBtn.Location = new System.Drawing.Point(95, 13);
			this.StartBtn.Name = "StartBtn";
			this.StartBtn.TabIndex = 5;
			this.StartBtn.Text = "Start";
			this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
// 
// StopBtn
// 
			this.StopBtn.Location = new System.Drawing.Point(95, 43);
			this.StopBtn.Name = "StopBtn";
			this.StopBtn.TabIndex = 6;
			this.StopBtn.Text = "Stop";
			this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
// 
// ResumeBtn
// 
			this.ResumeBtn.Location = new System.Drawing.Point(95, 73);
			this.ResumeBtn.Name = "ResumeBtn";
			this.ResumeBtn.TabIndex = 7;
			this.ResumeBtn.Text = "Resume";
			this.ResumeBtn.Click += new System.EventHandler(this.ResumeBtn_Click);
// 
// SuspendBtn
// 
			this.SuspendBtn.Location = new System.Drawing.Point(95, 102);
			this.SuspendBtn.Name = "SuspendBtn";
			this.SuspendBtn.TabIndex = 8;
			this.SuspendBtn.Text = "Suspend";
			this.SuspendBtn.Click += new System.EventHandler(this.SuspendBtn_Click);
// 
// TransferBtn
// 
			this.TransferBtn.Location = new System.Drawing.Point(95, 132);
			this.TransferBtn.Name = "TransferBtn";
			this.TransferBtn.TabIndex = 9;
			this.TransferBtn.Text = "Transfer";
			this.TransferBtn.Click += new System.EventHandler(this.TransferBtn_Click);
// 
// RandomBtn
// 
			this.RandomBtn.Location = new System.Drawing.Point(13, 163);
			this.RandomBtn.Name = "RandomBtn";
			this.RandomBtn.TabIndex = 10;
			this.RandomBtn.Text = "Random";
			this.RandomBtn.Click += new System.EventHandler(this.RandomBtn_Click);
// 
// NumEventsTxtBox
// 
			this.NumEventsTxtBox.Location = new System.Drawing.Point(118, 193);
			this.NumEventsTxtBox.Name = "NumEventsTxtBox";
			this.NumEventsTxtBox.Size = new System.Drawing.Size(52, 20);
			this.NumEventsTxtBox.TabIndex = 11;
			this.NumEventsTxtBox.Text = "1";
			this.NumEventsTxtBox.TextChanged += new System.EventHandler(this.NumEventsTxtBox_TextChanged);
// 
// FailBtn
// 
			this.FailBtn.Location = new System.Drawing.Point(95, 163);
			this.FailBtn.Name = "FailBtn";
			this.FailBtn.TabIndex = 12;
			this.FailBtn.Text = "Fail";
			this.FailBtn.Click += new System.EventHandler(this.FailBtn_Click);
// 
// label1
// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 196);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(98, 14);
			this.label1.TabIndex = 13;
			this.label1.Text = "Number of Events:";
// 
// Form1
// 
            		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            		this.ClientSize = new System.Drawing.Size(179, 223);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.FailBtn);
			this.Controls.Add(this.NumEventsTxtBox);
			this.Controls.Add(this.RandomBtn);
			this.Controls.Add(this.TransferBtn);
			this.Controls.Add(this.SuspendBtn);
			this.Controls.Add(this.ResumeBtn);
			this.Controls.Add(this.StopBtn);
			this.Controls.Add(this.StartBtn);
			this.Controls.Add(this.VerboseBtn);
			this.Controls.Add(this.InformationBtn);
			this.Controls.Add(this.WarningBtn);
			this.Controls.Add(this.ErrorBtn);
			this.Controls.Add(this.CriticalBtn);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.Text = "Trace Maker";
			this.TopMost = true;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button CriticalBtn;
		private System.Windows.Forms.Button ErrorBtn;
		private System.Windows.Forms.Button WarningBtn;
		private System.Windows.Forms.Button InformationBtn;
		private System.Windows.Forms.Button VerboseBtn;
		private System.Windows.Forms.Button StartBtn;
		private System.Windows.Forms.Button StopBtn;
		private System.Windows.Forms.Button ResumeBtn;
		private System.Windows.Forms.Button SuspendBtn;
		private System.Windows.Forms.Button TransferBtn;
		private System.Windows.Forms.Button RandomBtn;
		private System.Windows.Forms.TextBox NumEventsTxtBox;
		private System.Windows.Forms.Button FailBtn;
		private System.Windows.Forms.Label label1;
	}
}

