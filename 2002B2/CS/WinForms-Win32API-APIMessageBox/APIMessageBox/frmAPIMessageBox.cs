using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;




namespace Win32API_MEssageBox
{

	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		//Win32 API Declaration
		[DllImport("user32.dll")]
		public static extern int MessageBox(int Hwnd, string message, string caption, int type);


		private System.Windows.Forms.Button btnExecute;
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
			this.btnExecute = new System.Windows.Forms.Button();
			this.btnExecute.Location = new System.Drawing.Point(96, 40);
			this.btnExecute.Size = new System.Drawing.Size(88, 24);
			this.btnExecute.TabIndex = 0;
			this.btnExecute.Text = "Click Me!";
			this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(283, 120);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.btnExecute});
			this.Text = "frmAPIMessageBox";

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
		
																	         
		private void btnExecute_Click(object sender, System.EventArgs e)
		{
			//Call Messagebox using Win32 API
			MessageBox(0, "Hello World!", "Hi", 0);
		}
	}
	

}
