using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using System.Net.Sockets;


namespace Client
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListBox lstOutput;
		private System.Windows.Forms.Label Label1;
		private System.Windows.Forms.TextBox txtClientCount;
		private System.Windows.Forms.Button cmdStop;
		private System.Windows.Forms.Button cmdStart;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components;

		private Thread[] oThreads;
		private int[] iThreadState;

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
			this.lstOutput = new System.Windows.Forms.ListBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.txtClientCount = new System.Windows.Forms.TextBox();
			this.cmdStop = new System.Windows.Forms.Button();
			this.cmdStart = new System.Windows.Forms.Button();
			this.lstOutput.Location = new System.Drawing.Point(8, 48);
			this.lstOutput.Size = new System.Drawing.Size(328, 225);
			this.lstOutput.TabIndex = 7;
			this.Label1.Location = new System.Drawing.Point(80, 10);
			this.Label1.Size = new System.Drawing.Size(72, 16);
			this.Label1.TabIndex = 5;
			this.Label1.Text = "Client Count:";
			this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.txtClientCount.Location = new System.Drawing.Point(160, 8);
			this.txtClientCount.Size = new System.Drawing.Size(32, 20);
			this.txtClientCount.TabIndex = 2;
			this.txtClientCount.Text = "10";
			this.cmdStop.Location = new System.Drawing.Point(208, 8);
			this.cmdStop.Size = new System.Drawing.Size(64, 24);
			this.cmdStop.TabIndex = 6;
			this.cmdStop.Text = "Stop";
			this.cmdStop.Click += new System.EventHandler(this.cmdStop_Click);
			this.cmdStart.Location = new System.Drawing.Point(8, 8);
			this.cmdStart.Size = new System.Drawing.Size(64, 24);
			this.cmdStart.TabIndex = 0;
			this.cmdStart.Text = "Start";
			this.cmdStart.Click += new System.EventHandler(this.cmdStart_Click);
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(344, 285);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.cmdStart,
																		  this.lstOutput,
																		  this.cmdStop,
																		  this.Label1,
																		  this.txtClientCount});
			this.Text = "Client";

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
		private void cmdStop_Click(object sender, System.EventArgs e)
		{
			for (int i = 0; i<=oThreads.GetUpperBound(0);i++)
			{
				oThreads[i].Abort();
				oThreads[i] = null;
			}
		}

		private void cmdStart_Click(object sender, System.EventArgs e)
		{
			int i;
			int ClientCount;
			ThreadStart oThreadStart;
			ClientCount = Int32.Parse(txtClientCount.Text);
			oThreads = new Thread[ClientCount - 1];
			iThreadState = new int[ClientCount - 1];

			for (i=0; i < ClientCount - 1;i++)
			{
				//Create a ThreadStart object, passing the address of NewThread             
				oThreadStart = new ThreadStart(this.StartClient);
				//clear any existing threads (if the start button was clicked more than once)
				oThreads[i] = null;
				//Create a Thread object
				oThreads[i] = new Thread(oThreadStart);
				//Starting the thread invokes the ThreadStart delegate
				oThreads[i].Name = i.ToString();
				iThreadState[i] = Convert.ToInt16(System.Threading.ThreadState.Running);

				oThreads[i].Start();
			}
		}

		protected void StartClient()
		{
			Thread oThread;
			string sName;
			TcpClient Client;
			byte[] Buffer;
			byte[] InBuff = new byte[100];
			string Temp;

			oThread = System.Threading.Thread.CurrentThread;
			sName = oThread.Name;

			while (true)
			{
				Client = new TcpClient();

				try
				{
					Client.Connect("localhost", 9105);
				}
				catch (Exception e)
				{
					lock(oThread)
					{
						lstOutput.Items.Insert(lstOutput.Items.Count, "Connection to server failed with return code: " + e.Message);
						lstOutput.SelectedIndex = lstOutput.Items.Count - 1;
					}
					return;
				}

				Temp = System.DateTime.Now + " Message from Client #" + sName;
				Buffer = System.Text.Encoding.ASCII.GetBytes(Temp.ToCharArray());

				Client.GetStream().Write(Buffer, 0, Buffer.Length);

				while (!Client.GetStream().DataAvailable)
				{
					Application.DoEvents();
				}

				if (Client.GetStream().DataAvailable)
				{
					Client.GetStream().Read(InBuff, 0, InBuff.Length);
					Temp = "Client #" + sName + " " + System.Text.Encoding.ASCII.GetString(InBuff);
					lock(oThread)
					{
						lstOutput.Items.Insert(lstOutput.Items.Count, Temp);
						lstOutput.SelectedIndex = lstOutput.Items.Count - 1;
					}
				}

				Client.Close();
			}
		}
	}
}
