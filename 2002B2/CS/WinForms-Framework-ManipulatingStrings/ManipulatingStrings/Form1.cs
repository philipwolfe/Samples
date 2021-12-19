using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;

namespace ManipulatingStrings
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button Button1;
		/// <summary>
		/// Required designer variable.
		/// </summary>

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
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Button1 = new System.Windows.Forms.Button();
			this.Button1.Location = new System.Drawing.Point(16, 24);
			this.Button1.Size = new System.Drawing.Size(120, 40);
			this.Button1.TabIndex = 0;
			this.Button1.Text = "Manipulating strings";
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(240, 85);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.Button1});
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

		private void Button1_Click(object sender, System.EventArgs e)
		{
        //Strings are immutable in C#
        //So to change the contents of a String, you use the 
        //System.Text.StringBuilder class
        string originalString;
        originalString = "C#'s Basics";
        string newString;
        StringBuilder sb = new StringBuilder(originalString);
		sb.Replace("'", "''");
        newString = sb.ToString();			
        MessageBox.Show("String changed from: " + originalString + " to " + newString, "Replacement", MessageBoxButtons.OK);

        //using AppendFormat you can format data then append it to a stringbuilder
        sb.AppendFormat(" Today's date is:  {0,12:dd MMM, yyyy} and the time is {1,10:HH:mm:ss }", System.DateTime.Now, System.DateTime.Now);
        //then use 
        MessageBox.Show(sb.ToString(), "Append", MessageBoxButtons.OK);

        //use StringBuilder.Remove to remove characters from the string
        //** note that the first character is at position 0 not 1

        //The StringBuilder methods return the modified StringBuilder, so you 
        //can call ToString on the return value directly
        MessageBox.Show(sb.Remove(0, 12).ToString(), "Remove", MessageBoxButtons.OK);

        //Similary, StringBuilder.Insert inserts characters
        //this inserts the wornd "now" between "time" and "is"
        MessageBox.Show(sb.Insert(45, "now ").ToString(), "Insert", MessageBoxButtons.OK);
		}
	}
}
