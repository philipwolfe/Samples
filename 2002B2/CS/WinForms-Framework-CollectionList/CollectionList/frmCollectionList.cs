using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace CollectionList
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnCollection;
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
			this.btnCollection = new System.Windows.Forms.Button();
			this.btnCollection.Location = new System.Drawing.Point(32, 24);
			this.btnCollection.Size = new System.Drawing.Size(144, 24);
			this.btnCollection.TabIndex = 0;
			this.btnCollection.Text = "Display Fruit Collection";
			this.btnCollection.Click += new System.EventHandler(this.btnCollection_Click);
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(219, 96);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.btnCollection});
			this.Text = "frmCollectionList";

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

		private void btnCollection_Click(object sender, System.EventArgs e)
		{
			string strReturn="";
			

			//populate the ArrayList
			
			ArrayList fruit = new ArrayList();
			fruit.Add("Apple");
			fruit.Add("Pear");
			fruit.Add("Orange");
			fruit.Add("Banana");
			foreach (string item in fruit)
			{
				strReturn = strReturn + item + Convert.ToChar(10);
			}

			//display the contents to the user
			MessageBox.Show(strReturn,  "Fruit Collection");
		}
	}
}
