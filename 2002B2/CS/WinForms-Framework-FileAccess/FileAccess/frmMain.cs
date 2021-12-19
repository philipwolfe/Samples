using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace FileAccess2
{
	/// <summary>
	/// Summary description for frmMain.
	/// </summary>
	public class frmMain : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button cmdReadFile;
		private System.Windows.Forms.Button cmdDir;
		private System.Windows.Forms.Button cmdCreateFile;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components;

		public frmMain()
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
			this.cmdDir = new System.Windows.Forms.Button();
			this.cmdCreateFile = new System.Windows.Forms.Button();
			this.cmdReadFile = new System.Windows.Forms.Button();
			this.cmdDir.Location = new System.Drawing.Point(32, 24);
			this.cmdDir.Size = new System.Drawing.Size(96, 23);
			this.cmdDir.TabIndex = 0;
			this.cmdDir.Text = "Dir List";
			this.cmdDir.Click += new System.EventHandler(this.cmdDir_Click);
			this.cmdCreateFile.Location = new System.Drawing.Point(32, 60);
			this.cmdCreateFile.Size = new System.Drawing.Size(96, 23);
			this.cmdCreateFile.TabIndex = 1;
			this.cmdCreateFile.Text = "Create File";
			this.cmdCreateFile.Click += new System.EventHandler(this.cmdCreateFile_Click);
			this.cmdReadFile.Location = new System.Drawing.Point(32, 96);
			this.cmdReadFile.Size = new System.Drawing.Size(96, 23);
			this.cmdReadFile.TabIndex = 2;
			this.cmdReadFile.Text = "Read File";
			this.cmdReadFile.Click += new System.EventHandler(this.cmdReadFile_Click);
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(164, 153);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.cmdCreateFile,
																		  this.cmdReadFile,
																		  this.cmdDir});
			this.Text = "frmMain";

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmMain());
		}

		private void cmdDir_Click(object sender, System.EventArgs e)
		{
			//display the Directory List dialog
			frmDirList frmDir = new frmDirList();
			frmDir.Show();
		}

		private void cmdCreateFile_Click(object sender, System.EventArgs e)
		{
			//display the write file dialog
			WriteFile frmCreateFile = new WriteFile();
			frmCreateFile.Show();
		}

		private void cmdReadFile_Click(object sender, System.EventArgs e)
		{
			//display the read file dialog
			frmReadFile frmReadFile = new frmReadFile();
			frmReadFile.Show();
		}
	}
}
