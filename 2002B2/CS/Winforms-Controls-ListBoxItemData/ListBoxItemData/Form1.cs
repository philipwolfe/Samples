using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ListBoxItemData
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button Button3;
		private System.Windows.Forms.ListBox ListBox1;
		private System.Windows.Forms.Button Button1;
		private System.Windows.Forms.Button Button2;
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
			this.Button3 = new System.Windows.Forms.Button();
			this.ListBox1 = new System.Windows.Forms.ListBox();
			this.Button1 = new System.Windows.Forms.Button();
			this.Button2 = new System.Windows.Forms.Button();
			this.Button3.Location = new System.Drawing.Point(264, 104);
			this.Button3.Size = new System.Drawing.Size(200, 40);
			this.Button3.TabIndex = 3;
			this.Button3.Text = "Populate using DataSource";
			this.Button3.Click += new System.EventHandler(this.Button3_Click);
			this.ListBox1.Location = new System.Drawing.Point(16, 16);
			this.ListBox1.Size = new System.Drawing.Size(224, 212);
			this.ListBox1.TabIndex = 0;
			this.Button1.Location = new System.Drawing.Point(264, 16);
			this.Button1.Size = new System.Drawing.Size(200, 40);
			this.Button1.TabIndex = 1;
			this.Button1.Text = "Populate using Items Collection";
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Button2.Location = new System.Drawing.Point(264, 192);
			this.Button2.Size = new System.Drawing.Size(200, 40);
			this.Button2.TabIndex = 2;
			this.Button2.Text = "Display selected item info";
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(488, 273);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.ListBox1,
																		  this.Button1,
																		  this.Button3,
																		  this.Button2});
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
			//Reset ListBox if Button3 has been clicked
			if (ListBox1.DataSource != null)
			{
				ListBox1.DataSource = null;
				ListBox1.Items.Clear();
				ListBox1.DisplayMember = null;
			}

			ListBox1.Items.Add(Customer.ReadCustomer1());
			ListBox1.Items.Add(Customer.ReadCustomer2());
			ListBox1.Items.Add(Customer.ReadCustomer3());
			ListBox1.SelectedIndex = 0;
		}

		private void Button3_Click(object sender, System.EventArgs e)
		{
			ListBox1.Items.Clear();
			ListBox1.DisplayMember = "FirstName";
			ListBox1.DataSource = Customer.LoadCustomers();
			ListBox1.SelectedIndex = 0;
		}

		private void Button2_Click(object sender, System.EventArgs e)
		{
			if (ListBox1.SelectedItem != null)
			{
				Customer selectedCustomer = (Customer )(ListBox1.SelectedItem);
				MessageBox.Show(selectedCustomer.LastName);
			}
		}
	}
}
