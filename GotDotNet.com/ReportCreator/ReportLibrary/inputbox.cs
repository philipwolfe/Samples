using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Windows.Forms.Reports.ReportLibrary
{
	#region inputbox
	public class inputbox : System.Windows.Forms.Form
	{
		#region class variables
		public System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		public System.Windows.Forms.Label label1;
		
		private System.ComponentModel.Container components = null;
		#endregion

		#region constructor
		public inputbox()
		{
			InitializeComponent();
		}
		#endregion

		#region destructor
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
		private void InitializeComponent()
		{
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(8, 32);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(168, 20);
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "";
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Location = new System.Drawing.Point(8, 56);
			this.button1.Name = "button1";
			this.button1.TabIndex = 1;
			this.button1.Text = "&OK";
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Location = new System.Drawing.Point(104, 56);
			this.button2.Name = "button2";
			this.button2.TabIndex = 2;
			this.button2.Text = "&Cancel";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.TabIndex = 3;
			this.label1.Text = "Input file extension";
			// 
			// inputbox
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.button2;
			this.ClientSize = new System.Drawing.Size(192, 94);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.label1,
																		  this.button2,
																		  this.button1,
																		  this.textBox1});
			this.Name = "inputbox";
			this.ShowInTaskbar = false;
			this.Text = "inputbox";
			this.ResumeLayout(false);

		}
		#endregion
	}
	#endregion
}
