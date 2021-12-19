using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SysTraySample
{
	/// <summary>
	/// Summary description for SettingsForms.
	/// </summary>
	public class SettingsForms : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label Label1;
		private System.Windows.Forms.Button Button1;
		/// <summary>
		/// Required designer variable.
		/// </summary>

		public SettingsForms()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		public override void Dispose()
		{
			base.Dispose();
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Label1 = new System.Windows.Forms.Label();
			this.Button1 = new System.Windows.Forms.Button();
			this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
			this.Label1.Location = new System.Drawing.Point(12, 20);
			this.Label1.Size = new System.Drawing.Size(264, 92);
			this.Label1.TabIndex = 0;
			this.Label1.Text = "This form would contain the settings options.";
			this.Button1.Location = new System.Drawing.Point(196, 128);
			this.Button1.TabIndex = 1;
			this.Button1.Text = "Close";
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 173);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.Button1,
																		  this.Label1});
			this.Text = "SettingsForms";

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}


	}
}
