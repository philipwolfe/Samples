using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace CustomExceptions
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label Label3;
		private System.Windows.Forms.GroupBox grpExample1;
		private System.Windows.Forms.Button btnExample2;
		private System.Windows.Forms.GroupBox GroupBox1;
		private System.Windows.Forms.GroupBox GroupBox2;
		private System.Windows.Forms.Button btnExample1;
		private System.Windows.Forms.Button btnExample3;
		private System.Windows.Forms.Label Label1;
		private System.Windows.Forms.Label Label2;
		private System.Windows.Forms.Button button1;
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
			this.Label3 = new System.Windows.Forms.Label();
			this.grpExample1 = new System.Windows.Forms.GroupBox();
			this.button1 = new System.Windows.Forms.Button();
			this.btnExample2 = new System.Windows.Forms.Button();
			this.GroupBox1 = new System.Windows.Forms.GroupBox();
			this.GroupBox2 = new System.Windows.Forms.GroupBox();
			this.btnExample1 = new System.Windows.Forms.Button();
			this.btnExample3 = new System.Windows.Forms.Button();
			this.Label1 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label3.Location = new System.Drawing.Point(8, 24);
			this.Label3.Size = new System.Drawing.Size(184, 23);
			this.Label3.TabIndex = 6;
			this.Label3.Text = "Nest Try blocks";
			this.grpExample1.Controls.AddRange(new System.Windows.Forms.Control[] {this.Label1});
			this.grpExample1.Location = new System.Drawing.Point(8, 8);
			this.grpExample1.Size = new System.Drawing.Size(280, 64);
			this.grpExample1.TabIndex = 3;
			this.grpExample1.TabStop = false;
			this.button1.Location = new System.Drawing.Point(208, 32);
			this.button1.TabIndex = 0;
			this.button1.Text = "Example 1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			this.btnExample2.Location = new System.Drawing.Point(200, 24);
			this.btnExample2.TabIndex = 1;
			this.btnExample2.Text = "Example 2";
			this.btnExample2.Click += new System.EventHandler(this.btnExample2_Click);
			this.GroupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {this.Label2,
																					this.btnExample2});
			this.GroupBox1.Location = new System.Drawing.Point(8, 80);
			this.GroupBox1.Size = new System.Drawing.Size(280, 64);
			this.GroupBox1.TabIndex = 4;
			this.GroupBox1.TabStop = false;
			this.GroupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {this.Label3,
																					this.btnExample3});
			this.GroupBox2.Location = new System.Drawing.Point(8, 152);
			this.GroupBox2.Size = new System.Drawing.Size(280, 64);
			this.GroupBox2.TabIndex = 5;
			this.GroupBox2.TabStop = false;
			this.btnExample1.Location = new System.Drawing.Point(208, 32);
			this.btnExample1.TabIndex = 0;
			this.btnExample1.Text = "Example 1";
			this.btnExample3.Location = new System.Drawing.Point(200, 24);
			this.btnExample3.TabIndex = 2;
			this.btnExample3.Text = "Example 3";
			this.btnExample3.Click += new System.EventHandler(this.btnExample3_Click);
			this.Label1.Location = new System.Drawing.Point(8, 24);
			this.Label1.Size = new System.Drawing.Size(184, 23);
			this.Label1.TabIndex = 4;
			this.Label1.Text = "Throw a custom error";
			this.Label2.Location = new System.Drawing.Point(8, 24);
			this.Label2.Size = new System.Drawing.Size(184, 23);
			this.Label2.TabIndex = 5;
			this.Label2.Text = "Catch an exception thrown from another object";
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(315, 256);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.button1,
																		  this.grpExample1,
																		  this.GroupBox1,
																		  this.btnExample1,
																		  this.GroupBox2});
			this.Text = "frmCustomExceptions";

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

		private void button1_Click(object sender, System.EventArgs e)
		{
			//This example shows how you can throw and catch an exception of your own type.
			//The custom exception is defined as a class called InsufficientFundsException
			//that inherits from Exception
			try
			{
				//Create a new instance of InsufficientFundsException and throw it
				throw new InsufficientFundsException("Account balance is negative");
			}
			catch (InsufficientFundsException exc) 
			{    
				  // This Catch will only execute if an exception of type InsuficientFundsException is thrown
				  // If this catch was missing, then the generic Catch below would catch the
				  //  thrown InsufficientFundsException
				  MessageBox.Show("Insufficient Funds Exception Caught \n" + exc.ToString());
			}
			catch (System.Exception exc)
			{
				// This will catch any excption, not already caught above. In this example this
				// code will not execute
				MessageBox.Show("Exception Caught \n" + exc.ToString());

			}
			}

		private void btnExample2_Click(object sender, System.EventArgs e)
		{
			//This example shows how an exception can be thrown from another object and still
			// be caught locally. 
			try
			{
				//Create a new instance of MyAccount
				MyAccount objMyAccount; 
				objMyAccount = new MyAccount();

				//Try to withdraw more than is available (5 is available). objMyAccount will
				// throw an InsufficientFundsException
				objMyAccount.WithDraw(10);

				//This code will never execute since an exception was thrown above
				MessageBox.Show("Withdraw Successful");
			}
			catch (System.Exception exc)
			{
	            //Catch any exception that was thrown
				MessageBox.Show("Exception Caught in btnExample2_Click: \n" + exc.ToString());
			}

		}

		private void btnExample3_Click(object sender, System.EventArgs e)
		{
			//This example shows how you can nest Try..Catch blocks within the same function.

			int intValue = 0;
	        //Start the outer Try block
			try
			{
				//Do some processing
				intValue += 4;

				//Start the inner Try block
				try
				{
					//Do some processing
					intValue += 30;

					//Throw an exception, it will be caught in the inner Try block
					throw new OverflowException();
				}
				catch (System.Exception exc)
				{
					//Catch exceptions thrown in the inner Try block
					MessageBox.Show("Exception Caught in Inner Block.  intValue = " + intValue);
				}            
				finally
				{
					//The Finally code will execute, even if an exception was thrown
					intValue += 200;
					MessageBox.Show("Inner Block Finally code always executes.  intValue = " + intValue);
				}

				//Do some processing
				intValue += 1000;

				//Thow an exception, this one is caught in the outer Try block
				throw new OverflowException();
			}
			catch (System.Exception exc)
			{
				//Catch exceptions in the Outer Try block
				MessageBox.Show("Exception Caught in Outer Block.  intValue = " + intValue);
			}
			finally
			{
				//Just a reminder, Finally code always executes
				MessageBox.Show("Finally code always executes");
			}
		}
	}
}
