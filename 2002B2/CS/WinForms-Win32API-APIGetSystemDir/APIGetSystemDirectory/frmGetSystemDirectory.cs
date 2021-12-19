using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;
using System.Runtime.InteropServices;

namespace WindowsApplication2
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{


		//Win32 API Declaration
		[DllImport("kernel32")]
		public static extern int GetSystemDirectory(StringBuilder Buffer,int Size);

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox txtSystemDirectory; 


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
			this.txtSystemDirectory = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.txtSystemDirectory.Location = new System.Drawing.Point(16, 64);
			this.txtSystemDirectory.Size = new System.Drawing.Size(216, 20);
			this.txtSystemDirectory.TabIndex = 1;
			this.txtSystemDirectory.Text = "";
			this.button1.Location = new System.Drawing.Point(56, 16);
			this.button1.Size = new System.Drawing.Size(128, 24);
			this.button1.TabIndex = 0;
			this.button1.Text = "Get System Directory";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(259, 104);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.txtSystemDirectory,
																		  this.button1});
			this.Text = "frmGetSystemDirectory";

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
			const int MAX_PATH = 256;
			StringBuilder str = new StringBuilder(MAX_PATH);

			// Call the API			
			GetSystemDirectory(str, MAX_PATH);

			// Place the results in the textbox
			this.txtSystemDirectory.Text = str.ToString();
		}

	}
}
