using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Web.Services;
using System.Runtime.Remoting.Messaging;






namespace AsyncTestClient
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button cmdCallWebService;
		private System.Windows.Forms.Button cmdWebServAsync;
		private System.Windows.Forms.TextBox txtDelay;
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
			this.txtDelay = new System.Windows.Forms.TextBox();
			this.cmdWebServAsync = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.cmdCallWebService = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtDelay
			// 
			this.txtDelay.Location = new System.Drawing.Point(128, 16);
			this.txtDelay.Name = "txtDelay";
			this.txtDelay.Size = new System.Drawing.Size(64, 20);
			this.txtDelay.TabIndex = 1;
			this.txtDelay.Text = "1000";
			// 
			// cmdWebServAsync
			// 
			this.cmdWebServAsync.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmdWebServAsync.Location = new System.Drawing.Point(128, 88);
			this.cmdWebServAsync.Name = "cmdWebServAsync";
			this.cmdWebServAsync.Size = new System.Drawing.Size(144, 24);
			this.cmdWebServAsync.TabIndex = 0;
			this.cmdWebServAsync.Text = "Call Web Service Async";
			this.cmdWebServAsync.Click += new System.EventHandler(this.cmdWebServAsync_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 40);
			this.label1.TabIndex = 2;
			this.label1.Text = "Specify milliseconds delay before web service completes:";
			// 
			// cmdCallWebService
			// 
			this.cmdCallWebService.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmdCallWebService.Location = new System.Drawing.Point(128, 48);
			this.cmdCallWebService.Name = "cmdCallWebService";
			this.cmdCallWebService.Size = new System.Drawing.Size(144, 24);
			this.cmdCallWebService.TabIndex = 0;
			this.cmdCallWebService.Text = "Call Web Service Sync";
			this.cmdCallWebService.Click += new System.EventHandler(this.cmdCallWebService_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(296, 133);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.label1,
																		  this.txtDelay,
																		  this.cmdWebServAsync,
																		  this.cmdCallWebService});
			this.Name = "Form1";
			this.Text = "Web Service Client";
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

		private void cmdCallWebService_Click(object sender, System.EventArgs e)
		{
			 //Create instance of web service proxy
			localhost.Service1 WebServ = new localhost.Service1();
								
	        //Call the web service synchronously and display the results in a message box.
			MessageBox.Show("Return Value: " + WebServ.DoSomeWork(Int32.Parse(txtDelay.Text)), "Synchronous Call");
			
		}
		
		public delegate int myAsyncDelegate(int intReturn);
		
		private void cmdWebServAsync_Click(object sender, System.EventArgs e)
		{
			
			//Create instance of web service proxy
			localhost.Service1 WebServ = new localhost.Service1();
									
			AsyncCallback asyncCallback = new AsyncCallback(this.MyCallBack);
			myAsyncDelegate asyncDelegate = new myAsyncDelegate(WebServ.DoSomeWork);

			//Call the web service asynchronously and display the results in a message box.
			IAsyncResult ar = asyncDelegate.BeginInvoke(Int32.Parse(txtDelay.Text), asyncCallback, null);

			MessageBox.Show("Async call started", "Asynchronous Call");
		}
	
		

		private void MyCallBack(System.IAsyncResult ar)
		{
			
			myAsyncDelegate asyncDelegate  = (myAsyncDelegate)((AsyncResult)ar).AsyncDelegate;
			int result = 0;
					
			//End async call
			result = asyncDelegate.EndInvoke(ar);
			
			MessageBox.Show("Asynchronous response has returned with the value: " + result.ToString());
			
		}
	}
}
