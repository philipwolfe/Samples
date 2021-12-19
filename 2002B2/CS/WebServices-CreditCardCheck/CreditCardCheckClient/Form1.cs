using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace CreditCardCheckClient
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lblResponse;
		private System.Windows.Forms.Button cmbVerify;
		private System.Windows.Forms.TextBox txtCreditCard;
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
			this.lblResponse = new System.Windows.Forms.Label();
			this.cmbVerify = new System.Windows.Forms.Button();
			this.txtCreditCard = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// lblResponse
			// 
			this.lblResponse.Location = new System.Drawing.Point(128, 96);
			this.lblResponse.Name = "lblResponse";
			this.lblResponse.Size = new System.Drawing.Size(128, 32);
			this.lblResponse.TabIndex = 0;
			// 
			// cmbVerify
			// 
			this.cmbVerify.Location = new System.Drawing.Point(232, 48);
			this.cmbVerify.Name = "cmbVerify";
			this.cmbVerify.Size = new System.Drawing.Size(96, 24);
			this.cmbVerify.TabIndex = 1;
			this.cmbVerify.Text = "Verify";
			this.cmbVerify.Click += new System.EventHandler(this.cmbVerify_Click);
			// 
			// txtCreditCard
			// 
			this.txtCreditCard.Location = new System.Drawing.Point(72, 48);
			this.txtCreditCard.Name = "txtCreditCard";
			this.txtCreditCard.Size = new System.Drawing.Size(128, 20);
			this.txtCreditCard.TabIndex = 2;
			this.txtCreditCard.Text = "";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(376, 149);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.txtCreditCard,
																		  this.cmbVerify,
																		  this.lblResponse});
			this.Name = "Form1";
			this.Text = "Verify Credit Card";
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

		private void cmbVerify_Click(object sender, System.EventArgs e)
		{
			//Instantiate the CreditCheck Web Service
			localhost.Service1 oCreditCheck = new localhost.Service1();
        
			// Display an Hourglass cursor
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			try
			{
				// Call the Web Service
				string strResult;
				strResult = oCreditCheck.VerifyCreditCard(this.txtCreditCard.Text);
				if (strResult == "Approved")
				{
					lblResponse.ForeColor = Color.Green;
					lblResponse.Text = strResult;
				}
				else
				{
					lblResponse.ForeColor = Color.Red;
					lblResponse.Text = strResult;
				}
			}
			catch
			{
				// Display an error message
				MessageBox.Show("An unexpected error was returned fromt he service.", "Service Error");
			}
			finally
			{
				//Release the Web Service object
				oCreditCheck.Dispose();
			}
              
			// Return the cursor to it's normal state
			this.Cursor = System.Windows.Forms.Cursors.Arrow;
              
		}
	}
}
