using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Messaging;

namespace vbMessageQueue
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label Label3;
		private System.Windows.Forms.TextBox txtQueueName;
		private System.Windows.Forms.TextBox txtReceived;
		private System.Windows.Forms.Button cmdSend;
		private System.Windows.Forms.Label lblDirections;
		private System.Windows.Forms.TextBox txtMsgBody;
		private System.Windows.Forms.TextBox txtMsgLabel;
		private System.Windows.Forms.Label Label4;
		private System.Windows.Forms.Label Label2;
		private System.Windows.Forms.Label Label1;
		private System.Windows.Forms.Button cmdConnect;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components;
		
		
		//Member variable message queue
		private System.Messaging.MessageQueue mQueue = new System.Messaging.MessageQueue();
				
		public Form1()
		{

			//define the mq event handler
			this.mQueue.ReceiveCompleted += new System.Messaging.ReceiveCompletedEventHandler(this.mQueue_ReceiveCompleted);
			

			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			
			//define the mq event handler
			//this.mQueue.ReceiveCompleted += new System.Messaging.ReceiveCompletedEventHandler(this.mQueue_ReceiveCompleted);
			
			//Fill in the directions label
			string sDirText;
			string sCRLF;
			sCRLF = "\r\n";
			sDirText = "Step 1" + sCRLF;
			sDirText = sDirText + "Connect to queue." + sCRLF + sCRLF;
			sDirText = sDirText + "Step 2" + sCRLF;
			sDirText = sDirText + "Enter a message label and message text into textboxes." + sCRLF + sCRLF + sCRLF + sCRLF + sCRLF;
			sDirText = sDirText + "Step 3" + sCRLF;
			sDirText = sDirText + "Click send message." + sCRLF + sCRLF;
			sDirText = sDirText + "Step 4" + sCRLF;
			sDirText = sDirText + "The returned text is what was received by message queue." + sCRLF + sCRLF;
			this.lblDirections.Text = sDirText;
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
			this.Label3 = new System.Windows.Forms.Label();
			this.txtQueueName = new System.Windows.Forms.TextBox();
			this.txtReceived = new System.Windows.Forms.TextBox();
			this.cmdSend = new System.Windows.Forms.Button();
			this.lblDirections = new System.Windows.Forms.Label();
			this.txtMsgBody = new System.Windows.Forms.TextBox();
			this.txtMsgLabel = new System.Windows.Forms.TextBox();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.cmdConnect = new System.Windows.Forms.Button();
			this.Label3.Location = new System.Drawing.Point(20, 72);
			this.Label3.Size = new System.Drawing.Size(80, 16);
			this.Label3.TabIndex = 10;
			this.Label3.Text = "Body:";
			this.txtQueueName.Location = new System.Drawing.Point(104, 8);
			this.txtQueueName.TabIndex = 2;
			this.txtQueueName.Text = "demoQueue1";
			this.txtReceived.BackColor = System.Drawing.SystemColors.Control;
			this.txtReceived.Location = new System.Drawing.Point(104, 176);
			this.txtReceived.Multiline = true;
			this.txtReceived.Size = new System.Drawing.Size(212, 84);
			this.txtReceived.TabIndex = 12;
			this.txtReceived.Text = "";
			this.cmdSend.Location = new System.Drawing.Point(212, 136);
			this.cmdSend.Size = new System.Drawing.Size(104, 24);
			this.cmdSend.TabIndex = 1;
			this.cmdSend.Text = "Send Message";
			this.cmdSend.Click += new System.EventHandler(this.cmdSend_Click);
			this.lblDirections.ForeColor = System.Drawing.SystemColors.Highlight;
			this.lblDirections.Location = new System.Drawing.Point(328, 4);
			this.lblDirections.Size = new System.Drawing.Size(112, 256);
			this.lblDirections.TabIndex = 13;
			this.lblDirections.Text = "Directions:";
			this.txtMsgBody.Location = new System.Drawing.Point(104, 68);
			this.txtMsgBody.Multiline = true;
			this.txtMsgBody.Size = new System.Drawing.Size(212, 60);
			this.txtMsgBody.TabIndex = 9;
			this.txtMsgBody.Text = "Message Body";
			this.txtMsgLabel.Location = new System.Drawing.Point(104, 40);
			this.txtMsgLabel.Size = new System.Drawing.Size(212, 20);
			this.txtMsgLabel.TabIndex = 7;
			this.txtMsgLabel.Text = "Message Label";
			this.Label4.Location = new System.Drawing.Point(20, 180);
			this.Label4.Size = new System.Drawing.Size(80, 16);
			this.Label4.TabIndex = 11;
			this.Label4.Text = "Received:";
			this.Label2.Location = new System.Drawing.Point(20, 44);
			this.Label2.Size = new System.Drawing.Size(80, 16);
			this.Label2.TabIndex = 8;
			this.Label2.Text = "Label:";
			this.Label1.Location = new System.Drawing.Point(20, 12);
			this.Label1.Size = new System.Drawing.Size(80, 16);
			this.Label1.TabIndex = 3;
			this.Label1.Text = "Queue Name:";
			this.cmdConnect.Location = new System.Drawing.Point(208, 4);
			this.cmdConnect.Size = new System.Drawing.Size(104, 24);
			this.cmdConnect.TabIndex = 0;
			this.cmdConnect.Text = "Connect";
			this.cmdConnect.Click += new System.EventHandler(this.cmdConnect_Click);
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(448, 273);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.Label3,
																		  this.Label2,
																		  this.Label1,
																		  this.txtMsgBody,
																		  this.lblDirections,
																		  this.txtMsgLabel,
																		  this.txtReceived,
																		  this.Label4,
																		  this.cmdSend,
																		  this.txtQueueName,
																		  this.cmdConnect});
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

		private string GetQueueName()
		{
			//Appends the private to the front of the user entered queue name to make it a local queue to this machine.  
			string sPrefix;
			sPrefix = ".\\PRIVATE$\\";
			return sPrefix + this.txtQueueName.Text;
		}

		private void cmdConnect_Click(object sender, System.EventArgs e)
		{
			try
			{
				//Create Queue if necessary				
				if (System.Messaging.MessageQueue.Exists(GetQueueName()) == false)
				{
					System.Messaging.MessageQueue.Create(GetQueueName());
				}

				//Set Queue Path
				mQueue.Path = GetQueueName();

				//Change Controls values
				this.cmdConnect.Text = "-- Connected --";
				this.cmdConnect.Enabled = false;

				//Enable Receive Event on Queue
				mQueue.BeginReceive();

				//Enable Send Button
				this.cmdSend.Enabled = true;

				//Disable Editing of QueueName
				this.txtQueueName.Enabled = false;
			}
			catch (Exception excp)
			{
				MessageBox.Show(excp.Message);
			}
		}

		private void cmdSend_Click(object sender, System.EventArgs e)
		{
			System.Messaging.Message oMsg = new System.Messaging.Message();

			//Assumes the dest queue already exists
			System.Messaging.XmlMessageFormatter oFormat = new System.Messaging.XmlMessageFormatter();

			//We are using the formatter to encode a single string for the body
			oFormat.Write(oMsg, this.txtMsgBody.Text);
			mQueue.Send(oMsg, this.txtMsgLabel.Text);
		}

		//public void mQueue_ReceiveCompleted(object sender, System.EventArgs e)
		public void mQueue_ReceiveCompleted(object sender, System.Messaging.ReceiveCompletedEventArgs args)
		{
			//Implements Message Recieved Event for MSMQ
			//Only called when that event occurs
			//Disable recieve event on Queue
			System.Messaging.Message oMsg = mQueue.EndReceive(args.AsyncResult);
			
			string sMsgBody = "";
			string sMsgLabel = "";
			System.Messaging.XmlMessageFormatter oFormat = new System.Messaging.XmlMessageFormatter();

			//Since we encoded the message as a string, we need to indicate the cast to the formatter on this end
			oFormat.TargetTypeNames = new string[] {"System.String"};

			//Decode the message into a string
			sMsgBody = oFormat.Read(oMsg).ToString();
			sMsgLabel = oMsg.Label;

			//Write out Message Label and Body
			string sSeperator = "";
			sSeperator = "\r\n" + "-------------------------------------------" + "\r\n";

			this.txtReceived.Text = "Label:" + sMsgLabel + sSeperator + sMsgBody;

			//Reactivate the receive event
			mQueue.BeginReceive();
		}
	}
}