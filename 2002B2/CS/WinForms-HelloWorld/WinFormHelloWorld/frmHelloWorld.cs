using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace WinFormHelloWorld
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnInput;
		private System.Windows.Forms.TextBox txtInput;
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
			this.btnInput = new System.Windows.Forms.Button();
			this.txtInput = new System.Windows.Forms.TextBox();
			this.btnInput.Location = new System.Drawing.Point(208, 72);
			this.btnInput.Size = new System.Drawing.Size(80, 24);
			this.btnInput.TabIndex = 0;
			this.btnInput.Text = "Click Me!";
			this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
			this.txtInput.Location = new System.Drawing.Point(8, 24);
			this.txtInput.Size = new System.Drawing.Size(280, 20);
			this.txtInput.TabIndex = 1;
			this.txtInput.Text = "Hello World!";
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(299, 112);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.txtInput,
																		  this.btnInput});
			this.Text = "WinFormHelloWorld";

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

		private void btnInput_Click(object sender, System.EventArgs e)
		{
			// Display a message box with the contents of the TextBox.
			MessageBox.Show(this.txtInput.Text,"Hello World");
		}
	}
}
