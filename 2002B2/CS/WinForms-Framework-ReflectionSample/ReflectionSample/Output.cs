using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ReflectionSample
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Output : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Output()
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
			if (components != null) 
			{
				components.Dispose();
			}
			base.Dispose();
		}

		public System.Windows.Forms.TextBox txtResults;

		#region Windows Form Designer generated code
 
		private System.Windows.Forms.Button btnClose;

		private void InitializeComponent()
		{
			this.btnClose = new System.Windows.Forms.Button();
			this.txtResults = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(408, 464);
			this.btnClose.Name = "btnClose";
			this.btnClose.TabIndex = 0;
			this.btnClose.Text = "Close";
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// txtResults
			// 
			this.txtResults.Location = new System.Drawing.Point(8, 32);
			this.txtResults.Multiline = true;
			this.txtResults.Name = "txtResults";
			this.txtResults.Size = new System.Drawing.Size(472, 424);
			this.txtResults.TabIndex = 1;
			this.txtResults.Text = "";
			// 
			// Output
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(488, 500);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.txtResults,
																		  this.btnClose});
			this.Name = "Output";
			this.Text = "Output";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		/// 
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.Visible = false;
			this.Dispose();

		}
	}
}
