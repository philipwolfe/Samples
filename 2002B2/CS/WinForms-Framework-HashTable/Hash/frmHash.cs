using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Hash
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label Label1;
		private System.Windows.Forms.Label Label2;
		private System.Windows.Forms.Button btnHash;
		private System.Windows.Forms.TextBox txtInput;
		private System.Windows.Forms.ListBox lstHashContents;

		private	Hashtable table = new Hashtable();
		
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

			//load the hash table
			table.Add("Jay", "0123");
			table.Add("Brad", "0569");
			table.Add("Brian", "1254");
			table.Add("Seth", "6839");
			table.Add("Rajesh", "3948");
			table.Add("Lakshan", "1930");
			table.Add("Kristian", "9341");

			//load the values of the hash table into the list box to show the user
			foreach (string s in table.Keys)
			{
				lstHashContents.Items.Add(s);
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
			this.Label1 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.btnHash = new System.Windows.Forms.Button();
			this.txtInput = new System.Windows.Forms.TextBox();
			this.lstHashContents = new System.Windows.Forms.ListBox();
			this.Label1.Location = new System.Drawing.Point(8, 32);
			this.Label1.Size = new System.Drawing.Size(96, 16);
			this.Label1.TabIndex = 2;
			this.Label1.Text = "Employee Name";
			this.Label2.Location = new System.Drawing.Point(8, 136);
			this.Label2.Size = new System.Drawing.Size(120, 16);
			this.Label2.TabIndex = 4;
			this.Label2.Text = "Employee Hash Table";
			this.btnHash.Location = new System.Drawing.Point(80, 88);
			this.btnHash.Size = new System.Drawing.Size(168, 24);
			this.btnHash.TabIndex = 0;
			this.btnHash.Text = "Search for Employee";
			this.btnHash.Click += new System.EventHandler(this.btnHash_Click);
			this.txtInput.Location = new System.Drawing.Point(136, 32);
			this.txtInput.Size = new System.Drawing.Size(240, 20);
			this.txtInput.TabIndex = 1;
			this.txtInput.Text = "Brad";
			this.lstHashContents.Location = new System.Drawing.Point(8, 160);
			this.lstHashContents.Size = new System.Drawing.Size(168, 108);
			this.lstHashContents.TabIndex = 3;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(392, 273);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.lstHashContents,
																		  this.txtInput,
																		  this.Label2,
																		  this.Label1,
																		  this.btnHash});
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

		private void btnHash_Click(object sender, System.EventArgs e)
		{
			//search the hash table for there requested user
			string id = (string) table[txtInput.Text];
			if (id != null)
			{
				System.Windows.Forms.MessageBox.Show("Found in the list:\n" + id, "Found");
				
			}
			else
			{
				System.Windows.Forms.MessageBox.Show("Employee not found.", "Not Found");
			}
		}
	}
}
