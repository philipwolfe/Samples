using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace MQWrite
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox txtQueueName;
		private System.Windows.Forms.TextBox txtMsgLabel;
		private System.Windows.Forms.Button btnCreateQueue;
		private System.Windows.Forms.TextBox txtServer;
		private System.Windows.Forms.Label lblResults;
		private System.Windows.Forms.Button btnSend;
		private System.Windows.Forms.Button btnListen;
		private System.Windows.Forms.GroupBox GroupBox1;
		private System.Windows.Forms.GroupBox GroupBox2;
		private System.Windows.Forms.Label Label1;
		private System.Windows.Forms.Label Label2;
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
			//default the machine name
			txtServer.Text = System.Net.Dns.GetHostName();

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
			this.txtQueueName = new System.Windows.Forms.TextBox();
			this.txtMsgLabel = new System.Windows.Forms.TextBox();
			this.btnCreateQueue = new System.Windows.Forms.Button();
			this.txtServer = new System.Windows.Forms.TextBox();
			this.lblResults = new System.Windows.Forms.Label();
			this.btnSend = new System.Windows.Forms.Button();
			this.btnListen = new System.Windows.Forms.Button();
			this.GroupBox1 = new System.Windows.Forms.GroupBox();
			this.GroupBox2 = new System.Windows.Forms.GroupBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.txtQueueName.Location = new System.Drawing.Point(96, 16);
			this.txtQueueName.Size = new System.Drawing.Size(96, 20);
			this.txtQueueName.TabIndex = 1;
			this.txtQueueName.Text = "testqueue";
			this.txtMsgLabel.Location = new System.Drawing.Point(120, 152);
			this.txtMsgLabel.TabIndex = 1;
			this.txtMsgLabel.Text = "Test Label";
			this.btnCreateQueue.Location = new System.Drawing.Point(16, 120);
			this.btnCreateQueue.Size = new System.Drawing.Size(96, 23);
			this.btnCreateQueue.TabIndex = 2;
			this.btnCreateQueue.Text = "Create Queue";
			this.btnCreateQueue.Click += new System.EventHandler(this.btnCreateQueue_Click);
			this.txtServer.Location = new System.Drawing.Point(96, 16);
			this.txtServer.TabIndex = 1;
			this.txtServer.Text = "";
			this.lblResults.Location = new System.Drawing.Point(8, 224);
			this.lblResults.Size = new System.Drawing.Size(216, 23);
			this.lblResults.TabIndex = 9;
			this.lblResults.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.btnSend.Location = new System.Drawing.Point(16, 152);
			this.btnSend.Size = new System.Drawing.Size(96, 23);
			this.btnSend.TabIndex = 0;
			this.btnSend.Text = "Send Message";
			this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
			this.btnListen.Location = new System.Drawing.Point(16, 184);
			this.btnListen.Size = new System.Drawing.Size(96, 23);
			this.btnListen.TabIndex = 8;
			this.btnListen.Text = "Listen";
			this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
			this.GroupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {this.txtQueueName,
																					this.Label1});
			this.GroupBox1.Location = new System.Drawing.Point(16, 56);
			this.GroupBox1.Size = new System.Drawing.Size(208, 56);
			this.GroupBox1.TabIndex = 6;
			this.GroupBox1.TabStop = false;
			this.GroupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {this.txtServer,
																					this.Label2});
			this.GroupBox2.Location = new System.Drawing.Point(16, 8);
			this.GroupBox2.Size = new System.Drawing.Size(208, 48);
			this.GroupBox2.TabIndex = 7;
			this.GroupBox2.TabStop = false;
			this.Label1.Location = new System.Drawing.Point(16, 16);
			this.Label1.Size = new System.Drawing.Size(72, 23);
			this.Label1.TabIndex = 0;
			this.Label1.Text = "Queue Name";
			this.Label2.Location = new System.Drawing.Point(16, 16);
			this.Label2.Size = new System.Drawing.Size(80, 23);
			this.Label2.TabIndex = 0;
			this.Label2.Text = "Local Machine Name";
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(232, 285);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.btnCreateQueue,
																		  this.btnListen,
																		  this.txtMsgLabel,
																		  this.GroupBox2,
																		  this.btnSend,
																		  this.GroupBox1,
																		  this.lblResults});
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

		private void btnCreateQueue_Click(object sender, System.EventArgs e)
		{
			//Create a MessageQueue object
			System.Messaging.MessageQueue objMQ  = new System.Messaging.MessageQueue();

			//Update the status label on the main form
			lblResults.Text = "Creating queue " + txtQueueName.Text;

			//In this example we pass the path to the queue we want to create to one of
			//the overloaded Create methods on the MessageQueue object.
			//For example, "betats1\private$\testqueue" is the single argument where 
			//betats1 is the local machine name and testqueue is the queue name
			try
			{
				System.Messaging.MessageQueue.Create(txtServer.Text + System.IO.Path.DirectorySeparatorChar + "Private$" + System.IO.Path.DirectorySeparatorChar + txtQueueName.Text);
				lblResults.Text = "Queue " + txtQueueName.Text + " created";
			}
			catch (Exception excp)
			{
				//Catch any exception thrown while creating the queue				
				System.Windows.Forms.MessageBox.Show("Exception caught while creating queue: " + excp.Message);
				lblResults.Text = "Couldn//t create queue";
			}

		}

		private void btnSend_Click(object sender, System.EventArgs e)
		{
			//Create a MessageQueue object
			System.Messaging.MessageQueue objMQ  = new System.Messaging.MessageQueue();
			//Create a Message object
			System.Messaging.Message objMsg = new System.Messaging.Message();

			lblResults.Text = "Beginning to send a message";

			//tell the queue object what path to use to access the queue
			objMQ.Path = txtServer.Text + System.IO.Path.DirectorySeparatorChar + "Private$" + System.IO.Path.DirectorySeparatorChar + txtQueueName.Text;
			//Set the Message object//s body
			objMsg.Body = "test body";
			//set the Message object//s label
			objMsg.Label = txtMsgLabel.Text;

			//send the Message
			objMQ.Send(objMsg);

			lblResults.Text = "Message Sent";

			//Check your queue for the message.
		}

		private void btnListen_Click(object sender, System.EventArgs e)
		{
			//Create a MessageQueue object
			System.Messaging.MessageQueue objMQ = new System.Messaging.MessageQueue();
			//Create a Message object
			System.Messaging.Message objMsg = new System.Messaging.Message();

			lblResults.Text = "Starting to listen to " + txtQueueName.Text;

			//Set the path property on the MessageQueue object
			//For example, "betats1\private$\testqueue" is the single argument where 
			//betats1 is the local machine name and testqueue is the queue name
			objMQ.Path = txtServer.Text + "\\private$\\" + txtQueueName.Text;
			try
			{
				//Set the Message object equal to the result from the receive function
				//there are 2 implementations of Receive.  The one I use requires a 
				//TimeSpan object which specifies the timeout period.  There is also an
				//implementation of Receive which requires nothing and will wait indefinitely
				//for a message to arrive on a queue.
				objMsg = objMQ.Receive(new TimeSpan(0, 0, 0, 10));

				//Display the received message//s label
				System.Windows.Forms.MessageBox.Show(" Label: " + objMsg.Label);
			}
			catch (Exception excp)
			{
				//Catch any exceptions thrown
				MessageBox.Show(excp.Message, "Message from listener");
			}

			lblResults.Text = "Listen Complete";
		}
	}
}
