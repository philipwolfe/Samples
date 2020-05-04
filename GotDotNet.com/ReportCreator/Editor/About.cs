using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Windows.Forms.Reports.Editor
{
	public class About : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
	
		private System.ComponentModel.Container components = null;

		public About()
		{			
			InitializeComponent();
		}

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

		#region Windows Form Designer generated code
		
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(48, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(144, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "serdardirican@hotmail.com";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(64, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(112, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "SERDAR DIRICAN";
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Location = new System.Drawing.Point(80, 80);
			this.button1.Name = "button1";
			this.button1.TabIndex = 2;
			this.button1.Text = "&OK";
			// 
			// About
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(232, 126);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.button1,
																		  this.label2,
																		  this.label1});
			this.Name = "About";
			this.ShowInTaskbar = false;
			this.Text = "About";
			this.ResumeLayout(false);

		}
		#endregion
	}
}
