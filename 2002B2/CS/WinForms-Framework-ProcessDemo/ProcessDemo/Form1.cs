using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using System.Threading;


namespace ProcessDemo
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label Label1;
		private System.Windows.Forms.TextBox TextBox1;
		private System.Windows.Forms.Button Button1;
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
			this.components = new System.ComponentModel.Container();
			this.Label1 = new System.Windows.Forms.Label();
			this.TextBox1 = new System.Windows.Forms.TextBox();
			this.Button1 = new System.Windows.Forms.Button();
			this.Label1.Location = new System.Drawing.Point(8, 8);
			this.Label1.Size = new System.Drawing.Size(360, 23);
			this.Label1.TabIndex = 0;
			this.Label1.Text = "Launch and shut down an executable.";
			this.TextBox1.Location = new System.Drawing.Point(8, 56);
			this.TextBox1.Size = new System.Drawing.Size(264, 20);
			this.TextBox1.TabIndex = 2;
			this.TextBox1.Text = "Calc.exe";
			this.Button1.Location = new System.Drawing.Point(336, 56);
			this.Button1.Size = new System.Drawing.Size(104, 23);
			this.Button1.TabIndex = 1;
			this.Button1.Text = "Launch Program";
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(448, 117);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.Button1,
																		  this.TextBox1,
																		  this.Label1});
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
			string executableFilename;
			executableFilename = this.TextBox1.Text;

			//create a new process
			Process process;
			process = new Process();
			process.StartInfo.FileName = executableFilename;
			process.Start();

			process.WaitForInputIdle();

			//sleep for a second then kill the process
			Thread.Sleep(1000);
			if (!process.CloseMainWindow())
			{
				process.Kill();
			}
		}
	}
}
