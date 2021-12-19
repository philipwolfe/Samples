using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using Logging;

namespace WinLogger
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button cmdFile;
		private System.Windows.Forms.Label Label1;
		private System.Windows.Forms.Button cmdEventLog;
		private System.Windows.Forms.TextBox txtMessage;
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
			this.cmdFile = new System.Windows.Forms.Button();
			this.Label1 = new System.Windows.Forms.Label();
			this.cmdEventLog = new System.Windows.Forms.Button();
			this.txtMessage = new System.Windows.Forms.TextBox();
			this.cmdFile.Location = new System.Drawing.Point(56, 116);
			this.cmdFile.Size = new System.Drawing.Size(124, 23);
			this.cmdFile.TabIndex = 1;
			this.cmdFile.Text = "Write to File";
			this.cmdFile.Click += new System.EventHandler(this.cmdFile_Click);
			this.Label1.Location = new System.Drawing.Point(24, 16);
			this.Label1.Size = new System.Drawing.Size(100, 16);
			this.Label1.TabIndex = 3;
			this.Label1.Text = "Message to Log:";
			this.cmdEventLog.Location = new System.Drawing.Point(240, 116);
			this.cmdEventLog.Size = new System.Drawing.Size(124, 23);
			this.cmdEventLog.TabIndex = 0;
			this.cmdEventLog.Text = "Write to Event Log";
			this.cmdEventLog.Click += new System.EventHandler(this.cmdEventLog_Click);
			this.txtMessage.Location = new System.Drawing.Point(24, 36);
			this.txtMessage.Multiline = true;
			this.txtMessage.Size = new System.Drawing.Size(368, 60);
			this.txtMessage.TabIndex = 2;
			this.txtMessage.Text = "Sample Log Message";
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(416, 157);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.cmdFile,
																		  this.cmdEventLog,
																		  this.txtMessage,
																		  this.Label1});
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

		private void cmdFile_Click(object sender, System.EventArgs e)
		{
	        FileLogger oLog = new FileLogger("LogFile.txt");
			oLog.WriteLog(this.txtMessage.Text, System.Diagnostics.EventLogEntryType.Information);

		}

		private void cmdEventLog_Click(object sender, System.EventArgs e)
		{
			Logging.EventLogger oLog = new Logging.EventLogger("Logging Sample App");
			oLog.WriteLog(this.txtMessage.Text, System.Diagnostics.EventLogEntryType.Information);
		}
	}
}
