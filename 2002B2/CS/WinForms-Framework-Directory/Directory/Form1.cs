using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace Directory1
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label Label1;
		private System.Windows.Forms.Button Button1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public static void PrintFiles(DirectoryInfo dir)
		{

			//loop through the contents of the directory and grab information about files
			foreach (object d in dir.GetFiles())
			{
				FileInfo f;
				f = (FileInfo)(d);
				string Name;
				Name = f.FullName;
				long size;
				size = f.Length;
				DateTime creationTime;
				creationTime = f.CreationTime;
				System.Windows.Forms.MessageBox.Show(size + ", " + creationTime + ", " + Name,"Directory Info");
				}

				//make a recursive call to PrintFiles if there are any subdirectories
				foreach (object d in dir.GetDirectories())
				{
					PrintFiles((DirectoryInfo)(d));
				}
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
			this.Button1 = new System.Windows.Forms.Button();
			this.Label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// Button1
			// 
			this.Button1.Location = new System.Drawing.Point(56, 80);
			this.Button1.Name = "Button1";
			this.Button1.TabIndex = 0;
			this.Button1.Text = "Go";
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			// 
			// Label1
			// 
			this.Label1.Location = new System.Drawing.Point(24, 16);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(192, 40);
			this.Label1.TabIndex = 1;
			this.Label1.Text = "View the File details for the contents of the app directory.";
			this.Label1.Click += new System.EventHandler(this.Label1_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(224, 109);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.Label1,
																		  this.Button1});
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			DirectoryInfo dir = new DirectoryInfo(".");
			PrintFiles(dir);
		}

		private void Label1_Click(object sender, System.EventArgs e)
		{

		}
	}
}
