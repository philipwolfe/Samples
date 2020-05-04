using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Windows.Forms.Reports.ReportLibrary
{
	#region SelectFSDlg
	public class SelectFSDlg : System.Windows.Forms.Form
	{
		#region class variables
		public System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		
		private System.ComponentModel.Container components = null;
		#endregion

		#region constructor
		public SelectFSDlg()
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
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.Location = new System.Drawing.Point(8, 8);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(224, 173);
			this.listBox1.TabIndex = 0;
			this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Location = new System.Drawing.Point(16, 192);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(96, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "&OK";
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Location = new System.Drawing.Point(128, 192);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(104, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "&Cancel";
			// 
			// SelectFSDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(240, 230);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.button2,
																		  this.button1,
																		  this.listBox1});
			this.Name = "SelectFSDlg";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Select File System";
			this.ResumeLayout(false);

		}
		#endregion

		#region class methods
		private void listBox1_DoubleClick(object sender, System.EventArgs e)
		{
			DialogResult=DialogResult.OK;
		}
		#endregion
	}
	#endregion
}
