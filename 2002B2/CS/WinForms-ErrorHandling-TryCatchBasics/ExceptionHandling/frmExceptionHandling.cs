using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ExceptionHandling
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label Label3;
		private System.Windows.Forms.GroupBox grpExample3;
		private System.Windows.Forms.GroupBox grpExample2;
		private System.Windows.Forms.GroupBox grpExample1;
		private System.Windows.Forms.Button btnExample2;
		private System.Windows.Forms.Button btnExample3;
		private System.Windows.Forms.Button btnExample1;
		private System.Windows.Forms.Label Label1;
		private System.Windows.Forms.Label Label2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
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
			this.grpExample3 = new System.Windows.Forms.GroupBox();
			this.grpExample2 = new System.Windows.Forms.GroupBox();
			this.grpExample1 = new System.Windows.Forms.GroupBox();
			this.button2 = new System.Windows.Forms.Button();
			this.btnExample2 = new System.Windows.Forms.Button();
			this.btnExample3 = new System.Windows.Forms.Button();
			this.btnExample1 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.Label1 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label3.Location = new System.Drawing.Point(8, 24);
			this.Label3.Size = new System.Drawing.Size(184, 23);
			this.Label3.TabIndex = 7;
			this.Label3.Text = "Catching specific exception types";
			this.grpExample3.Controls.AddRange(new System.Windows.Forms.Control[] {this.button1,
																					  this.Label3});
			this.grpExample3.Location = new System.Drawing.Point(8, 160);
			this.grpExample3.Size = new System.Drawing.Size(280, 64);
			this.grpExample3.TabIndex = 6;
			this.grpExample3.TabStop = false;
			this.grpExample2.Controls.AddRange(new System.Windows.Forms.Control[] {this.Label2,
																					  this.btnExample2});
			this.grpExample2.Location = new System.Drawing.Point(8, 88);
			this.grpExample2.Size = new System.Drawing.Size(280, 64);
			this.grpExample2.TabIndex = 5;
			this.grpExample2.TabStop = false;
			this.grpExample1.Controls.AddRange(new System.Windows.Forms.Control[] {this.btnExample1,
																					  this.Label1});
			this.grpExample1.Location = new System.Drawing.Point(8, 16);
			this.grpExample1.Size = new System.Drawing.Size(280, 64);
			this.grpExample1.TabIndex = 4;
			this.grpExample1.TabStop = false;
			this.button2.Location = new System.Drawing.Point(208, 184);
			this.button2.TabIndex = 2;
			this.button2.Text = "Example 3";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			this.btnExample2.Location = new System.Drawing.Point(200, 22);
			this.btnExample2.TabIndex = 1;
			this.btnExample2.Text = "Example 2";
			this.btnExample2.Click += new System.EventHandler(this.btnExample2_Click);
			this.btnExample3.Location = new System.Drawing.Point(208, 184);
			this.btnExample3.TabIndex = 2;
			this.btnExample3.Text = "Example 3";
			this.btnExample1.Location = new System.Drawing.Point(200, 24);
			this.btnExample1.Size = new System.Drawing.Size(72, 24);
			this.btnExample1.TabIndex = 5;
			this.btnExample1.Text = "Example 1";
			this.btnExample1.Click += new System.EventHandler(this.btnExample1_Click);
			this.button1.Location = new System.Drawing.Point(208, 184);
			this.button1.TabIndex = 2;
			this.button1.Text = "Example 3";
			this.Label1.Location = new System.Drawing.Point(8, 24);
			this.Label1.Size = new System.Drawing.Size(168, 16);
			this.Label1.TabIndex = 6;
			this.Label1.Text = "Basic Try..Catch block";
			this.Label2.Location = new System.Drawing.Point(8, 24);
			this.Label2.Size = new System.Drawing.Size(184, 23);
			this.Label2.TabIndex = 6;
			this.Label2.Text = "Try..Catch..Finally block";
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(323, 288);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.button2,
																		  this.grpExample1,
																		  this.grpExample3,
																		  this.grpExample2,
																		  this.btnExample3});
			this.Text = "frmExceptionHandling";

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

		private void btnExample1_Click(object sender, System.EventArgs e)
		{
		//This example shows the basic structured exception handling,the try..catch block

        // Code that might throw an exception is wrapped in a Try block
			try
			{
				int x  = 0;
				int y = 10;
				int z; 
				// This will cause an exception to be thrown
				z = Convert.ToInt16(y / x);

				// The following line will never execute because the Exception thrown in the line
				// above transfers execution to the Catch block
				MessageBox.Show("End of Try block");
			}
			catch (System.Exception exc)
			{
				// This Catch block will execute when any exception is thrown from the Try block
				MessageBox.Show("Exception Caught");
			}
		}

		private void btnExample2_Click(object sender, System.EventArgs e)
		{
			// This example expands on basic exception handling by adding the Finally block

			// Code that might throw an exception is wrapped in a Try block
			try
			{
				//Manually throw an exception of type ArgumentException
				throw new System.ArgumentException();

				// The following line will never execute because the Exception thrown in the line
				// above transfers execution to the Catch block
				MessageBox.Show("End of Try block");
			}
			catch (System.Exception exc)
			{

				// This Catch block will execute when any exception is thrown from the Try block
				MessageBox.Show("Exception Caught");
			}        
			finally
			{
				// Code in the Finally block will always execute. It can be used to do cleanup that
				// is necessary even if an exception is thrown. Like closing a file or socket.
				MessageBox.Show("Finally code always executes");
			}
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			// This example adds a Catch block that will only catch a specific type of exception.
			// In this case it catches an OverflowException, but other Catch blocks can be added
			// to catch other types of excpetions.

			// Code that might throw an exception is wrapped in a Try block
			try
			{
				int x = 0;
				int y = 10;
				int z; 

				// This will cause an OverflowException to be thrown
				z = Convert.ToInt16(y / x);

				// The following line will never execute because the Exception thrown in the line
				// above transfers execution to the Catch block
				MessageBox.Show("End of Try block");
			}
			catch (System.OverflowException excOverflow)
			{
				// This Catch block will execute when an OverflowException is thrown from the Try block
				// Any other type of exception will be caught by the Catch block for generic Exception
				//  types below
				MessageBox.Show("Overflow Exception Caught");
			}
			catch (System.Exception exc)
			{
				// This catch block will execute when any exception is thrown and not caught in
				// a previous Catch block
				MessageBox.Show("Generic Exception Caught");
			}
			finally
			{
				// Code in the Finally block will always execute. It can be used to do cleanup that
				// is necessary even if an exception is thrown. Like closing a file or socket.
				MessageBox.Show("Finally code always executes");
			}

		}
	}
}
