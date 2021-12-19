using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace FileAccess2
{
	/// <summary>
	/// Summary description for frmReadFile.
	/// </summary>
	public class frmReadFile : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox TextBox1;
		private System.Windows.Forms.Button cmdReadFile;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components;

		public frmReadFile()
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
			this.TextBox1 = new System.Windows.Forms.TextBox();
			this.cmdReadFile = new System.Windows.Forms.Button();
			this.TextBox1.Location = new System.Drawing.Point(24, 48);
			this.TextBox1.Multiline = true;
			this.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.TextBox1.Size = new System.Drawing.Size(488, 232);
			this.TextBox1.TabIndex = 1;
			this.TextBox1.Text = "";
			this.cmdReadFile.Location = new System.Drawing.Point(24, 12);
			this.cmdReadFile.TabIndex = 0;
			this.cmdReadFile.Text = "Read File";
			this.cmdReadFile.Click += new System.EventHandler(this.cmdReadFile_Click);
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(536, 296);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.TextBox1,
																		  this.cmdReadFile});
			this.Text = "frmReadFile";

		}
		#endregion

		private void cmdReadFile_Click(object sender, System.EventArgs e)
		{
			//Read the contents of the file we just created and output it to the textbox
			try
			{
				System.IO.StreamReader sr = System.IO.File.OpenText("c:" + System.IO.Path.DirectorySeparatorChar + "temp" + System.IO.Path.DirectorySeparatorChar + "MyFile." + "txt");
				do
				{
					TextBox1.Text = TextBox1.Text + sr.ReadLine() + "\r\n";
				}
				while (sr.Peek() != -1);
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message);
			}
		}
	}
}
