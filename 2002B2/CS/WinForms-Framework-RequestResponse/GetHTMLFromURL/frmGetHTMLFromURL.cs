using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace GetHTMLFromURL
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox txtProxy;
		private System.Windows.Forms.Label Label1;
		private System.Windows.Forms.Label Label2;
		private System.Windows.Forms.Button cmdGetHTML;
		private System.Windows.Forms.TextBox txtHTML;
		private System.Windows.Forms.TextBox txtURL;
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
			this.txtProxy = new System.Windows.Forms.TextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.cmdGetHTML = new System.Windows.Forms.Button();
			this.txtHTML = new System.Windows.Forms.TextBox();
			this.txtURL = new System.Windows.Forms.TextBox();
			this.txtProxy.Location = new System.Drawing.Point(148, 368);
			this.txtProxy.Size = new System.Drawing.Size(304, 20);
			this.txtProxy.TabIndex = 3;
			this.txtProxy.Text = "";
			this.Label1.Location = new System.Drawing.Point(12, 372);
			this.Label1.Size = new System.Drawing.Size(136, 16);
			this.Label1.TabIndex = 4;
			this.Label1.Text = "(optional) Proxy Server:";
			this.Label2.Location = new System.Drawing.Point(8, 16);
			this.Label2.Size = new System.Drawing.Size(28, 16);
			this.Label2.TabIndex = 5;
			this.Label2.Text = "Url:";
			this.cmdGetHTML.Location = new System.Drawing.Point(368, 8);
			this.cmdGetHTML.Size = new System.Drawing.Size(80, 24);
			this.cmdGetHTML.TabIndex = 1;
			this.cmdGetHTML.Text = "Get HTML";
			this.cmdGetHTML.Click += new System.EventHandler(this.cmdGetHTML_Click);
			this.txtHTML.Location = new System.Drawing.Point(8, 36);
			this.txtHTML.Multiline = true;
			this.txtHTML.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtHTML.Size = new System.Drawing.Size(440, 328);
			this.txtHTML.TabIndex = 2;
			this.txtHTML.Text = "Hit Get HTML Button";
			this.txtURL.Location = new System.Drawing.Point(36, 12);
			this.txtURL.Size = new System.Drawing.Size(328, 20);
			this.txtURL.TabIndex = 0;
			this.txtURL.Text = "http://www.microsoft.com";
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(475, 421);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.cmdGetHTML,
																		  this.txtURL,
																		  this.txtHTML,
																		  this.Label2,
																		  this.Label1,
																		  this.txtProxy});
			this.Text = "frmHTMLFromURL";

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

		private void cmdGetHTML_Click(object sender, System.EventArgs e)
		{
			//Error Handling
			//Try Statement will execute, unless there's an error at which point the 
			//Catch Statement will execute
			//Get Proxy Value from Form
			string sProxy  = this.txtProxy.Text;
			
			//If Proxy entered then Create a Proxy object pointed to the URL from the form over Port 80
	        if (sProxy != "")
			{
		        System.Net.WebProxy oProxy = new System.Net.WebProxy(sProxy, 80);
		        
				//Set Proxy Selection to Proxy Object
				System.Net.GlobalProxySelection.Select = oProxy;
			}

				//Create a Request Object
				System.Net.WebRequest oReq; 

				//Request object = to Create of URL Request
				oReq = System.Net.WebRequest.Create(this.txtURL.Text);

		        //Create Response Object
				System.Net.WebResponse oResp; 

				//Set Response Object = GetResponse off of Request Object
				oResp = oReq.GetResponse();

				//Create a Stream Object
				System.IO.Stream oStream;

				//Set Stream Object = Response Stream
				oStream = oResp.GetResponseStream();

				//Dim Response Stream Reader
				System.IO.StreamReader oReader = new System.IO.StreamReader(oStream);
				string sRet;

				//Set String = Full Text of Reader
				sRet = oReader.ReadToEnd();

				//Set Text Box = Full Text Stream
				this.txtHTML.Text = sRet;
		}
	}
}
