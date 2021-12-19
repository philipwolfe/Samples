using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Text;

namespace Encode
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnEncode;
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
			this.btnEncode = new System.Windows.Forms.Button();
			this.btnEncode.Location = new System.Drawing.Point(48, 32);
			this.btnEncode.Size = new System.Drawing.Size(120, 32);
			this.btnEncode.TabIndex = 0;
			this.btnEncode.Text = "Encode";
			this.btnEncode.Click += new System.EventHandler(this.btnEncode_Click);
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(232, 93);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.btnEncode});
			this.Text = "Form1";

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

		private void btnEncode_Click(object sender, System.EventArgs e)
		{
			//Create a text file for this example
			System.Windows.Forms.MessageBox.Show("Creating Encode.txt in the \\bin directory for the Encode project", "Encode");
			FileStream fs;
			fs = new FileStream("Encode.txt", FileMode.OpenOrCreate);

			System.Windows.Forms.MessageBox.Show("Writing UTF8", "Encode");
			StreamWriter t;
			t = new StreamWriter(fs, Encoding.UTF8);
			t.WriteLine("This is in UTF8");
			t.Flush();

			System.Windows.Forms.MessageBox.Show("Writing Unicode", "Encode");
			StreamWriter t2;
			t2 = new StreamWriter(fs, Encoding.Unicode);
			t2.WriteLine("This is in Unicode");
			t2.Flush();

			System.Windows.Forms.MessageBox.Show("Writing Ascii", "Encode");
			StreamWriter t3;
			t3 = new StreamWriter(fs, Encoding.ASCII);
			t3.WriteLine("This is in ASCII");
			t3.Flush();

			fs.Close();
		}
	}
}
