using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Collections.Specialized;

namespace Anagrams
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button loadStrings;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

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
			if (components != null) 
			{
				components.Dispose();
			}
			base.Dispose();
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.loadStrings = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// loadStrings
			// 
			this.loadStrings.Location = new System.Drawing.Point(64, 64);
			this.loadStrings.Name = "loadStrings";
			this.loadStrings.TabIndex = 0;
			this.loadStrings.Text = "Load Strings";
			this.loadStrings.Click += new System.EventHandler(this.loadStrings_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(218, 159);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.loadStrings});
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

		private void loadStrings_Click(object sender, System.EventArgs e)
		{
			string str;

			// open a stream to the text file
			StreamReader din = File.OpenText ("words.txt");
			
			StringCollection st = new StringCollection(); 
        
			MessageBox.Show("Reading data and inserting into a StringTable.");
			// read the contents of the file
			while ((str=din.ReadLine()) != null) 
			{
				st.Add(str);
			}

			MessageBox.Show("Printing out the StringTable.");
			foreach (string s in st)
			{
				MessageBox.Show(s,"String Reader");
			}
		}
	}
}
