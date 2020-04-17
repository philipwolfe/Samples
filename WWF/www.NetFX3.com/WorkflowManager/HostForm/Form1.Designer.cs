//---------------------------------------------------------------------
//  This file is part of the NetFx3.com web site samples.
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
namespace HostForm
{
	public partial class DocReviewForm
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
			this.startHost = new System.Windows.Forms.Button();
			this.startInstance1 = new System.Windows.Forms.Button();
			this.startInstance2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// startHost
			// 
			this.startHost.Location = new System.Drawing.Point(12, 12);
			this.startHost.Name = "startHost";
			this.startHost.Size = new System.Drawing.Size(84, 23);
			this.startHost.TabIndex = 0;
			this.startHost.Text = "Start Host";
			this.startHost.Click += new System.EventHandler(this.startHost_Click);
			// 
			// startInstance1
			// 
			this.startInstance1.Enabled = false;
			this.startInstance1.Location = new System.Drawing.Point(102, 12);
			this.startInstance1.Name = "startInstance1";
			this.startInstance1.Size = new System.Drawing.Size(109, 23);
			this.startInstance1.TabIndex = 1;
			this.startInstance1.Text = "Start Instance 1";
			this.startInstance1.Click += new System.EventHandler(this.startInstance1_Click);
			// 
			// startInstance2
			// 
			this.startInstance2.Enabled = false;
			this.startInstance2.Location = new System.Drawing.Point(217, 12);
			this.startInstance2.Name = "startInstance2";
			this.startInstance2.Size = new System.Drawing.Size(100, 23);
			this.startInstance2.TabIndex = 4;
			this.startInstance2.Text = "Start Instance 2";
			this.startInstance2.Click += new System.EventHandler(this.startInstance2_Click);
			// 
			// DocReviewForm
			// 
			this.ClientSize = new System.Drawing.Size(335, 47);
			this.Controls.Add(this.startInstance2);
			this.Controls.Add(this.startInstance1);
			this.Controls.Add(this.startHost);
			this.Name = "DocReviewForm";
			this.Text = "Windows Workflow Runtime Host";
			this.Load += new System.EventHandler(this.DocReviewForm_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button startHost;
		private System.Windows.Forms.Button startInstance1;
		private System.Windows.Forms.Button startInstance2;
	}
}

