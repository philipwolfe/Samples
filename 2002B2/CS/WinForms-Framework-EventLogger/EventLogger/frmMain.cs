using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;

namespace EventLogger
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button cmdWriteEvent;
		private System.Windows.Forms.Label Label1;
		private System.Windows.Forms.Label Label2;
		private System.Windows.Forms.TextBox txtEventText;
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
			this.cmdWriteEvent = new System.Windows.Forms.Button();
			this.Label1 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.txtEventText = new System.Windows.Forms.TextBox();
			this.cmdWriteEvent.Location = new System.Drawing.Point(400, 56);
			this.cmdWriteEvent.Size = new System.Drawing.Size(104, 23);
			this.cmdWriteEvent.TabIndex = 0;
			this.cmdWriteEvent.Text = "Write Event";
			this.cmdWriteEvent.Click += new System.EventHandler(this.cmdWriteEvent_Click);
			this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
			this.Label1.Location = new System.Drawing.Point(8, 56);
			this.Label1.TabIndex = 2;
			this.Label1.Text = "Event Text";
			this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
			this.Label2.Location = new System.Drawing.Point(0, 8);
			this.Label2.Size = new System.Drawing.Size(504, 23);
			this.Label2.TabIndex = 3;
			this.Label2.Text = "Event Log Writer";
			this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.txtEventText.Location = new System.Drawing.Point(120, 56);
			this.txtEventText.Size = new System.Drawing.Size(264, 20);
			this.txtEventText.TabIndex = 1;
			this.txtEventText.Text = "";
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(520, 109);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.Label1,
																		  this.Label2,
																		  this.cmdWriteEvent,
																		  this.txtEventText});
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
		private void cmdWriteEvent_Click(object sender, System.EventArgs e)
		{
			if (txtEventText.Text != "")
			{
				//By default we'll log to the local event log.
				//You can change this value to point to another machine on your network
				string sMachineName = System.Net.Dns.GetHostName();

				//The next line creates the eventlogger variable and sets it to an instance of the EventLog component
				//The variables passed into the EventLog are the name of the log (Application)
				//the name of the local server and the name of the event source (myappsource)
				EventLog EventLogger = new EventLog("Application", sMachineName, "MyAppSource");

				//the following line writes the event log entry
				EventLogger.WriteEntry(txtEventText.Text);

				MessageBox.Show("Event log entry written!", "Event Logger");
			}
		}
	}
}
