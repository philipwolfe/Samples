using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using eYesoft.Tools.WebServices;

namespace SimpleDynWSClient
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button bnCalc;
		private System.Windows.Forms.TextBox tbA;
		private System.Windows.Forms.TextBox tbB;
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
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.bnCalc = new System.Windows.Forms.Button();
			this.tbA = new System.Windows.Forms.TextBox();
			this.tbB = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// bnCalc
			// 
			this.bnCalc.Location = new System.Drawing.Point(72, 64);
			this.bnCalc.Name = "bnCalc";
			this.bnCalc.Size = new System.Drawing.Size(64, 24);
			this.bnCalc.TabIndex = 0;
			this.bnCalc.Text = "Add";
			this.bnCalc.Click += new System.EventHandler(this.bnCalc_Click);
			// 
			// tbA
			// 
			this.tbA.Location = new System.Drawing.Point(8, 8);
			this.tbA.Name = "tbA";
			this.tbA.Size = new System.Drawing.Size(80, 20);
			this.tbA.TabIndex = 1;
			this.tbA.Text = "";
			// 
			// tbB
			// 
			this.tbB.Location = new System.Drawing.Point(120, 8);
			this.tbB.Name = "tbB";
			this.tbB.Size = new System.Drawing.Size(72, 20);
			this.tbB.TabIndex = 2;
			this.tbB.Text = "";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(200, 93);
			this.Controls.Add(this.tbB);
			this.Controls.Add(this.tbA);
			this.Controls.Add(this.bnCalc);
			this.Name = "Form1";
			this.Text = "Add two numbers";
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

		private void bnCalc_Click(object sender, System.EventArgs e)
		{			
			DynamicWebServiceProxy ws = new DynamicWebServiceProxy();
			
			ws.WSDL = "http://www.xmlwebservices.cc/ws/v1/calc/SimpleCalc.asmx?WSDL";
			ws.TypeName = "SimpleCalc";
			ws.MethodName = "Add";
			ws.AddParameter(Convert.ToInt64(tbA.Text));
			ws.AddParameter(Convert.ToInt64(tbB.Text));

			object result = ws.InvokeCall();

			MessageBox.Show(result.ToString());
		}
	}
}


