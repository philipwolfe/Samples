using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace WinForms_Random_Numbers
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox txtNumber;
		private System.Windows.Forms.Button btnGenNumbers;
		private System.Windows.Forms.Button btnGenLetter;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.TextBox txtLetter;
		private System.Windows.Forms.TextBox txtZeroOrOne;
		private System.Windows.Forms.Button btnGenZeroOrOne;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components;
		Random generateRandomNumber = new Random();

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
			this.txtNumber = new System.Windows.Forms.TextBox();
			this.btnGenNumbers = new System.Windows.Forms.Button();
			this.btnGenLetter = new System.Windows.Forms.Button();
			this.btnClear = new System.Windows.Forms.Button();
			this.txtLetter = new System.Windows.Forms.TextBox();
			this.txtZeroOrOne = new System.Windows.Forms.TextBox();
			this.btnGenZeroOrOne = new System.Windows.Forms.Button();
			this.txtNumber.Location = new System.Drawing.Point(184, 40);
			this.txtNumber.Size = new System.Drawing.Size(160, 20);
			this.txtNumber.TabIndex = 1;
			this.txtNumber.Text = "";
			this.btnGenNumbers.Location = new System.Drawing.Point(16, 40);
			this.btnGenNumbers.Size = new System.Drawing.Size(152, 23);
			this.btnGenNumbers.TabIndex = 0;
			this.btnGenNumbers.Text = "Random Digits";
			this.btnGenNumbers.Click += new System.EventHandler(this.btnGenNumbers_Click);
			this.btnGenLetter.Location = new System.Drawing.Point(16, 120);
			this.btnGenLetter.Size = new System.Drawing.Size(152, 23);
			this.btnGenLetter.TabIndex = 4;
			this.btnGenLetter.Text = "Random Letter";
			this.btnGenLetter.Click += new System.EventHandler(this.btnGenLetter_Click);
			this.btnClear.Location = new System.Drawing.Point(140, 172);
			this.btnClear.TabIndex = 8;
			this.btnClear.Text = "Clear Fields";
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			this.txtLetter.Location = new System.Drawing.Point(184, 120);
			this.txtLetter.Size = new System.Drawing.Size(160, 20);
			this.txtLetter.TabIndex = 5;
			this.txtLetter.Text = "";
			this.txtZeroOrOne.Location = new System.Drawing.Point(184, 80);
			this.txtZeroOrOne.Size = new System.Drawing.Size(160, 20);
			this.txtZeroOrOne.TabIndex = 3;
			this.txtZeroOrOne.Text = "";
			this.btnGenZeroOrOne.Location = new System.Drawing.Point(16, 80);
			this.btnGenZeroOrOne.Size = new System.Drawing.Size(152, 23);
			this.btnGenZeroOrOne.TabIndex = 2;
			this.btnGenZeroOrOne.Text = "Between 0 and 1";
			this.btnGenZeroOrOne.Click += new System.EventHandler(this.btnGenZeroOrOne_Click);
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(376, 217);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.txtNumber,
																		  this.btnGenZeroOrOne,
																		  this.btnGenLetter,
																		  this.btnClear,
																		  this.txtLetter,
																		  this.btnGenNumbers,
																		  this.txtZeroOrOne});
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

		private void btnGenNumbers_Click(object sender, System.EventArgs e)
		{
			//Generate a random number 
			txtNumber.Text = generateRandomNumber.Next().ToString();
		}

		private void btnGenZeroOrOne_Click(object sender, System.EventArgs e)
		{
			//Generate a random number between zero and one
			txtZeroOrOne.Text = generateRandomNumber.NextDouble().ToString();
		}

		private void btnGenLetter_Click(object sender, System.EventArgs e)
		{   
			//restrict the random number generator to uppercase ASCII character values
			txtLetter.Text = Convert.ToChar(generateRandomNumber.Next(65, 90)).ToString();
			
		}

		private void btnClear_Click(object sender, System.EventArgs e)
		{
			//Clear the results
			txtZeroOrOne.Text = "";
			txtNumber.Text = "";
			txtLetter.Text = "";
		}
	}
}
