using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

namespace FileAccess2
{
	/// <summary>
	/// Summary description for frmDirList.
	/// </summary>
	public class frmDirList : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox txtDir;
		private System.Windows.Forms.Button cmdGetDir;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components;

		public frmDirList()
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
			if(components != null)
				components.Dispose();
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtDir = new System.Windows.Forms.TextBox();
			this.cmdGetDir = new System.Windows.Forms.Button();
			this.txtDir.Location = new System.Drawing.Point(12, 44);
			this.txtDir.Multiline = true;
			this.txtDir.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDir.Size = new System.Drawing.Size(520, 168);
			this.txtDir.TabIndex = 1;
			this.txtDir.Text = "";
			this.cmdGetDir.Location = new System.Drawing.Point(12, 12);
			this.cmdGetDir.TabIndex = 0;
			this.cmdGetDir.Text = "Get Dir";
			this.cmdGetDir.Click += new System.EventHandler(this.cmdGetDir_Click);
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(552, 225);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.txtDir,
																		  this.cmdGetDir});
			this.Text = "frmDirList";

		}
		#endregion

		private void cmdGetDir_Click(object sender, System.EventArgs e)
		{
			//get the list of files within the current directory
			DirectoryInfo dir = new DirectoryInfo(".");
			//FileInfo f;
			string name;
			long size;
			DateTime creationTime;

			//display the current directory name
			txtDir.Text = dir.FullName + "\r\n";

			//insert some descriptive text
			txtDir.Text = txtDir.Text + "\r\n";
			txtDir.Text = txtDir.Text + "Contains:" + "\r\n";

			//display the name, size and create date for each file
			foreach(FileInfo f in dir.GetFiles("*.*"))
			{
				name = f.Name;
				size = f.Length;
				creationTime = f.CreationTime;
				txtDir.Text = txtDir.Text + " " + name + " " + size + " " + creationTime + "\r\n";
			}

		}
	}
}
