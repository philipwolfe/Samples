//=============================================================================
//	The Remoting Management Console.
//	(C) Copyright 2003, Roman Kiss (rkiss@pathcom.com)
//	All rights reserved.
//	The code and information is provided "as-is" without waranty of any kind,
//	either expresed or implied.
//
//-----------------------------------------------------------------------------
//	History:
//		03/31/2003	Roman Kiss				Initial Revision
//=============================================================================
//
#region references
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
#endregion

namespace RKiss.RemotingManagement
{
	public class HelpForm : System.Windows.Forms.Form
	{
		#region private members
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.ComponentModel.Container components = null;
		#endregion

		#region constructor
		public HelpForm()
		{
			InitializeComponent();
		}
		#endregion

		#region Clean up any resources being used.
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.buttonOK = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// buttonOK
			// 
			this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.buttonOK.Location = new System.Drawing.Point(128, 68);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(46, 23);
			this.buttonOK.TabIndex = 0;
			this.buttonOK.Text = "OK";
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(22, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(264, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "This is a preview version without the help project.";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 38);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(262, 20);
			this.label2.TabIndex = 1;
			this.label2.Text = "Copyright (c) Roman Kiss, rkiss@pathcom.com";
			// 
			// HelpForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(306, 98);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																																	this.label1,
																																	this.buttonOK,
																																	this.label2});
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(314, 128);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(314, 128);
			this.Name = "HelpForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Help";
			this.TopMost = true;
			this.ResumeLayout(false);

		}
		#endregion

		#region events
		private void buttonOK_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		#endregion
	}
}
