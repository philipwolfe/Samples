using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using System.Net.Sockets;

namespace Listener
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button cmdStopListener;
		private System.Windows.Forms.TextBox txtMaxThreads;
		private System.Windows.Forms.ListBox lstStatus;
		private System.Windows.Forms.Timer Timer1;
		private System.Windows.Forms.Label Label1;
		private System.ComponentModel.IContainer components;

		private TcpListener oListener;
		private bool bStopListener;
		private int ActiveThreads;
		//private int ThreadIndex;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			oListener = new TcpListener(9105);

			oListener.Start();

			lstStatus.Items.Insert(lstStatus.Items.Count, "Listener Started");
			Timer1.Enabled = true;
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
			this.cmdStopListener = new System.Windows.Forms.Button();
			this.txtMaxThreads = new System.Windows.Forms.TextBox();
			this.lstStatus = new System.Windows.Forms.ListBox();
			this.Timer1 = new System.Windows.Forms.Timer(this.components);
			this.Label1 = new System.Windows.Forms.Label();
			this.cmdStopListener.Location = new System.Drawing.Point(324, 12);
			this.cmdStopListener.Size = new System.Drawing.Size(94, 24);
			this.cmdStopListener.TabIndex = 3;
			this.cmdStopListener.Text = "Stop Listener";
			this.cmdStopListener.Click += new System.EventHandler(this.cmdStopListener_Click);
			this.txtMaxThreads.Location = new System.Drawing.Point(112, 12);
			this.txtMaxThreads.Size = new System.Drawing.Size(32, 20);
			this.txtMaxThreads.TabIndex = 5;
			this.txtMaxThreads.Text = "5";
			this.txtMaxThreads.Visible = false;
			this.lstStatus.Location = new System.Drawing.Point(6, 42);
			this.lstStatus.Size = new System.Drawing.Size(414, 199);
			this.lstStatus.TabIndex = 4;
			this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
			this.Label1.Location = new System.Drawing.Point(12, 12);
			this.Label1.Size = new System.Drawing.Size(84, 20);
			this.Label1.TabIndex = 6;
			this.Label1.Text = "Max Threads:";
			this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.Label1.Visible = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(432, 253);
			this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.txtMaxThreads,
																		  this.lstStatus,
																		  this.cmdStopListener,
																		  this.Label1});
			this.Text = "Listener";

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

		public void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			Timer1.Stop();
			if (oListener != null)
			{
				oListener.Stop();
			}
		}
		private void cmdStopListener_Click(object sender, System.EventArgs e)
		{
			bStopListener = true;
			Timer1.Stop();
			oListener.Stop();
		}

		private void Timer1_Tick(object sender, System.EventArgs e)
		{
			ThreadStart oThreadStart;
			Thread oThread;

			if (!oListener.Pending())
			{
				return;
			}

			Timer1.Enabled = false;

			if (ActiveThreads > Convert.ToInt16(txtMaxThreads.Text))
			{
				Timer1.Enabled = true;
				return;
			}

			oThreadStart = new ThreadStart(this.ProcessRequest);
			oThread = new Thread(oThreadStart);

			oThread.Start();
			lock (oThread)
			{
				ActiveThreads += 1;
			}

			Timer1.Enabled = true;

		}
        
		protected void ProcessRequest()
		{
			Thread oThread;
			Socket oSocket;
			byte[] Buffer = new byte[100];
			int bytes;
			string Temp;

			oThread = System.Threading.Thread.CurrentThread;
			oSocket = oListener.AcceptSocket();

			while (!bStopListener)
			{
				if (oSocket.Available > 0)
				{
					bytes = oSocket.Receive(Buffer, Buffer.Length, 0);
					lock (oThread)
					{
						lstStatus.Items.Insert(lstStatus.Items.Count, System.Text.Encoding.ASCII.GetString(Buffer));
						lstStatus.SelectedIndex = lstStatus.Items.Count - 1;
					}
					break;
				}
		
				Application.DoEvents();
				if (!oSocket.Connected)
				{
					bStopListener = true;
				}
			}

			//Simulate work being performed by listener by pausing for 2 seconds
			System.Threading.Thread.Sleep(2000);
			

			//Format the return message - this will normally be the results of the
			//server side processing
			Temp = "Recieved: " + System.DateTime.Now;
			
			Buffer = System.Text.Encoding.ASCII.GetBytes(Temp.ToCharArray());

			//Send the results back to the client application via the open socket and
			//close the socket
			oSocket.Send(Buffer, Buffer.Length, 0);
			oSocket.Close();
			lock (oThread)
			{
				ActiveThreads -= 1;
			}

		}
	}
}
