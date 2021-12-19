using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using System.Messaging;


namespace MultiThreadedQueueListener
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private bool bolStop = false;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtServer;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.TextBox txtQueue;
		private System.Windows.Forms.Button cmdStop;
		private System.Windows.Forms.Button cmdStart;
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
			 this.txtServer.Text = System.Net.Dns.GetHostName();
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
			this.txtServer = new System.Windows.Forms.TextBox();
			this.txtQueue = new System.Windows.Forms.TextBox();
			this.cmdStop = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.lblStatus = new System.Windows.Forms.Label();
			this.cmdStart = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.txtServer.Location = new System.Drawing.Point(96, 16);
			this.txtServer.Size = new System.Drawing.Size(160, 20);
			this.txtServer.TabIndex = 0;
			this.txtServer.Text = "";
			this.txtQueue.Location = new System.Drawing.Point(96, 56);
			this.txtQueue.Size = new System.Drawing.Size(160, 20);
			this.txtQueue.TabIndex = 0;
			this.txtQueue.Text = "";
			this.cmdStop.Location = new System.Drawing.Point(168, 96);
			this.cmdStop.Size = new System.Drawing.Size(120, 24);
			this.cmdStop.TabIndex = 1;
			this.cmdStop.Text = "Stop Listening";
			this.cmdStop.Click += new System.EventHandler(this.cmdStop_Click);
			this.label1.Location = new System.Drawing.Point(40, 56);
			this.label1.Size = new System.Drawing.Size(40, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Queue:";
			this.lblStatus.Location = new System.Drawing.Point(48, 152);
			this.lblStatus.Size = new System.Drawing.Size(240, 16);
			this.lblStatus.TabIndex = 2;
			this.cmdStart.Location = new System.Drawing.Point(24, 96);
			this.cmdStart.Size = new System.Drawing.Size(120, 24);
			this.cmdStart.TabIndex = 1;
			this.cmdStart.Text = "Start Listening";
			this.cmdStart.Click += new System.EventHandler(this.button1_Click);
			this.label2.Location = new System.Drawing.Point(40, 16);
			this.label2.Size = new System.Drawing.Size(48, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Server:";
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(323, 184);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.lblStatus,
																		  this.label2,
																		  this.label1,
																		  this.cmdStop,
																		  this.cmdStart,
																		  this.txtQueue,
																		  this.txtServer});
			this.Text = "Queue Listener";

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
			lblStatus.Text = "Starting Threads";
			StartThreads();
		}

		private void StartThreads()
		{
			int i; //Thread count
			MQListen objMQListen; //declare an array of 5 threads to be worker threads
			Thread[] oThread = new Thread[5];
			//ThreadStart objThreadStart;

			//declare the Class that will run our threads
			objMQListen = new MQListen(this.txtServer.Text,this.txtQueue.Text);

			bolStop = false;

			for (i = 0;i <= 4; i++)
			{
				// Create a Thread object 
				oThread[i] = new Thread(new ThreadStart(objMQListen.Listen));
				// Starting the thread invokes the ThreadStart delegate
				oThread[i].Start();
			}

			lblStatus.Text = i.ToString() + " listener threads started";

			while (true)
			{
				//wait for the user to press the stop button
				if (bolStop)
				{
					//user has pressed stop, proceed to shut down threads    
					break;
				}
				//Let the system handle other events
				System.Windows.Forms.Application.DoEvents();
			}

			lblStatus.Text = "Stop request received, stopping threads";
			//send an interrupt request to each thread
			for (i = 0;i <= 4; i++)
			{      
				oThread[i].Interrupt();
			}

			lblStatus.Text = "All Threads have been stopped";
		}

		private void cmdStop_Click(object sender, System.EventArgs e)
		{
			bolStop = true;
		}
	}

	//This class encapsulates the worker thread functionality.  
	public class MQListen
	{	
		private string m_strMachineName;
		private string m_strQueueName;
		
		//constructor accepts the necessary queue information
		public MQListen(string MachineName,string QueueName)
		{
			m_strMachineName = MachineName;
			m_strQueueName = QueueName;
		}
    
		//One and only method that each thread uses to 
		public void Listen()
		{
			//Create a MessageQueue object
			System.Messaging.MessageQueue objMQ  = new System.Messaging.MessageQueue();
			//Create a Message object
			System.Messaging.Message objMsg = new System.Messaging.Message();
        
			try
			{            
				//Set the path property on the MessageQueue object
				objMQ.Path = m_strMachineName + "\\private$\\" + m_strQueueName;
				//repeat until Interrupt received
				while (true)
				{
					try
					{
						//sleep in order to catch the interrupt if it has been thrown
						//Interrupt will only be processed by a thread that is in a 
						//wait, sleep or join state
						System.Threading.Thread.Sleep(100);
						//Set the Message object equal to the result from the receive function
						//there are 2 implementations of Receive.  The one I use requires a 
						//TimeSpan object which specifies the timeout period.  There is also an
						//implementation of Receive which requires nothing and will wait indefinitely
						//for a message to arrive on a queue
						//Timespan(days, hours, minutes, seconds)
						objMsg = objMQ.Receive(new TimeSpan(0, 0, 0, 1));
			                    
						//Display the received message//s label
						System.Windows.Forms.MessageBox.Show(" Label: " + objMsg.Label);
						
					}
					catch (ThreadInterruptedException e)
					{
						//catch the ThreadInterrupt from the main thread and exit
						Console.WriteLine("Exiting Thread");
						break;
					}
					catch (Exception excp)
					{
						//Catch any exceptions thrown in receive
						Console.WriteLine(excp.Message);
					}		                			

				}
			}
			catch (ThreadInterruptedException e)
			{
				//catch the ThreadInterrupt from the main thread and exit
				Console.WriteLine("Exiting Thread");            
			}
			//exit thread      
		}

	}
}
