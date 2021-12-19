using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

namespace FileAccess2
{
	/// <summary>
	/// Summary description for WriteFile.
	/// </summary>
	public class WriteFile : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox TextBox3;
		private System.Windows.Forms.TextBox TextBox1;
		private System.Windows.Forms.Button cmdWriteFile;
		private System.Windows.Forms.TextBox TextBox2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components;

		public WriteFile()
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
			this.TextBox3 = new System.Windows.Forms.TextBox();
			this.TextBox1 = new System.Windows.Forms.TextBox();
			this.cmdWriteFile = new System.Windows.Forms.Button();
			this.TextBox2 = new System.Windows.Forms.TextBox();
			this.TextBox3.Location = new System.Drawing.Point(24, 84);
			this.TextBox3.Size = new System.Drawing.Size(472, 20);
			this.TextBox3.TabIndex = 3;
			this.TextBox3.Text = "This is line three.";
			this.TextBox1.Location = new System.Drawing.Point(24, 20);
			this.TextBox1.Size = new System.Drawing.Size(472, 20);
			this.TextBox1.TabIndex = 1;
			this.TextBox1.Text = "This is line one.";
			this.cmdWriteFile.Location = new System.Drawing.Point(420, 116);
			this.cmdWriteFile.TabIndex = 0;
			this.cmdWriteFile.Text = "Write File";
			this.cmdWriteFile.Click += new System.EventHandler(this.cmdWriteFile_Click);
			this.TextBox2.Location = new System.Drawing.Point(24, 52);
			this.TextBox2.Size = new System.Drawing.Size(472, 20);
			this.TextBox2.TabIndex = 2;
			this.TextBox2.Text = "This is line  two.";
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(520, 161);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.TextBox1,
																		  this.cmdWriteFile,
																		  this.TextBox3,
																		  this.TextBox2});
			this.Text = "WriteFile";

		}
		#endregion

		private void cmdWriteFile_Click(object sender, System.EventArgs e)
		{
        //write the contents of the text boxes to a file
			try
			{
				StreamWriter sw = File.CreateText("c:" + System.IO.Path.DirectorySeparatorChar + "temp" + System.IO.Path.DirectorySeparatorChar + "MyFile." + "txt");
				sw.WriteLine(TextBox1.Text);
				sw.WriteLine(TextBox2.Text);
				sw.WriteLine(TextBox3.Text);
				sw.Close();

				//tell the user we're done
				MessageBox.Show("File successfully written!", "WriteFile", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message);
			}
		}

	}
}
