using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ExceptionThrow
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnThrow;
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
			this.btnThrow = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnThrow
			// 
			this.btnThrow.Location = new System.Drawing.Point(72, 56);
			this.btnThrow.Name = "btnThrow";
			this.btnThrow.Size = new System.Drawing.Size(104, 23);
			this.btnThrow.TabIndex = 0;
			this.btnThrow.Text = "Throw Exception";
			this.btnThrow.Click += new System.EventHandler(this.btnThrow_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(250, 151);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.btnThrow});
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

		private void btnThrow_Click(object sender, System.EventArgs e)
		{
			try
			{
				MessageBox.Show("We're going to call our mehod with two args, one valid and one invalid","Throw Exception");
				MessageBox.Show("Trying to call the method wih an argument of 1", "Throw Exception");
				seeIfIntIsOne(1);
				MessageBox.Show("Trying to call the method with an argument of 2","Throw Exception");
				seeIfIntIsOne(2);
			}
			catch (System.Exception er)
			{

				MessageBox.Show("The following error occured: " + er.ToString() , "Exception Occured");
			}
			finally
			{
				MessageBox.Show("Now we can Continue" , "Throw Exception");
			}
		}
		private string seeIfIntIsOne(int i) 
		{
			string s;
			s = "You passed in 1";
			if (i == 1) 
			{
				return s;
			}
			else
			{	
				throw new ArgumentException("Your integer was not 1");
				// it should be noted that this exception does not utilize the Runtime's resource
				// system which would make the text of the exception easily localizable.
				// For examples of using resources, see the Resources section of Quickstart.
			}
		}																									

	}
}
