using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ExceptionCatch
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnException;
		private System.Windows.Forms.Label Label1;
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
			this.btnException = new System.Windows.Forms.Button();
			this.Label1 = new System.Windows.Forms.Label();
			this.btnException.Location = new System.Drawing.Point(104, 56);
			this.btnException.Size = new System.Drawing.Size(112, 24);
			this.btnException.TabIndex = 0;
			this.btnException.Text = "Cause Exception";
			this.btnException.Click += new System.EventHandler(this.btnException_Click);
			this.Label1.Location = new System.Drawing.Point(8, 16);
			this.Label1.Size = new System.Drawing.Size(336, 32);
			this.Label1.TabIndex = 1;
			this.Label1.Text = "We\'re going to divide 10 by 0 and see what happens...";
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(379, 96);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.btnException,
																		  this.Label1});
			this.Text = "frmExceptionCatch";

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

		private void btnException_Click(object sender, System.EventArgs e)
		{
			//This code shows how to catch an exception
			try
			{
				int i;
				int j;
				int k;

				//cause a divide by zero exception            
				i = 10;
				j = 0;
				k = i / j;
			}
			catch (System.Exception er)
			{
				// Display the exception
				MessageBox.Show(er.ToString());
			}
			finally
			{
				// Display a message box to the user.
				MessageBox.Show(" The error was caught, now we can continue",  "ExceptionCatch");
			}        
		}
	}
}
