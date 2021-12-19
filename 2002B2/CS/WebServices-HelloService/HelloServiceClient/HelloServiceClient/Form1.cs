using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace HelloServiceClient
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox name;
		private System.Windows.Forms.Button Hello;
		private System.Windows.Forms.Label label1;
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
			this.name = new System.Windows.Forms.TextBox();
			this.Hello = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// name
			// 
			this.name.Location = new System.Drawing.Point(120, 40);
			this.name.Name = "name";
			this.name.Size = new System.Drawing.Size(120, 20);
			this.name.TabIndex = 0;
			this.name.Text = "Bob";
			// 
			// Hello
			// 
			this.Hello.Location = new System.Drawing.Point(256, 40);
			this.Hello.Name = "Hello";
			this.Hello.Size = new System.Drawing.Size(88, 24);
			this.Hello.TabIndex = 1;
			this.Hello.Text = "Say Hello";
			this.Hello.Click += new System.EventHandler(this.Hello_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Enter Name:";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(352, 93);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.label1,
																		  this.Hello,
																		  this.name});
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

		private void Hello_Click(object sender, System.EventArgs e)
		{
			localhost.Service1 helloService = new localhost.Service1();
			string greeting;

			//Call WebService
			greeting = helloService.HelloWorld(this.name.Text);

			//Display Results
			MessageBox.Show(greeting,"Hello Service Result");


		}
	}
}
