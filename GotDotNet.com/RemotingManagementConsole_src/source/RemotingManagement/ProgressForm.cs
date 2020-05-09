//=============================================================================
//	The Remoting Management Console.
//	(C) Copyright 2003, Roman Kiss (rkiss@pathcom.com)
//	All rights reserved.
//	The code and information is provided "as-is" without waranty of any kind,
//	either expresed or implied.
//
//  Note:	
//	This software using the 3rd party library for MMC (www.ironringsoftware.com)
//-----------------------------------------------------------------------------
//	History:
//		03/31/2003	Roman Kiss				Initial Revision
//=============================================================================
//
#region references
using System;
using System.Diagnostics;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.ServiceProcess;
#endregion

namespace RKiss.RemotingManagement
{
	public class ProgressForm : System.Windows.Forms.Form
	{
		#region private members
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.Label label;
		private System.Diagnostics.EventLog eventLog;
		private System.ComponentModel.IContainer components = null;
		//
		private string mstrHostProcessName = null;
		private string mstrCmd = null;
		private System.Timers.Timer timer;
		private WinServiceAgent mWSA = new WinServiceAgent();
		#endregion

		#region constructor
		public ProgressForm(string strCmd, string strHostProcessName)
		{
			InitializeComponent();

			try 
			{
				//---process name
				mstrHostProcessName = strHostProcessName;
				mstrCmd = strCmd;

				//---label
				label.Text = string.Format("The process {0} is {1}ing ... ", strHostProcessName, strCmd); 

				//---event log notification
				eventLog.Source = strHostProcessName;
				eventLog.EntryWritten += new EntryWrittenEventHandler(OnEventLogEntryWritten);
				eventLog.EnableRaisingEvents = true;

				//---call agent
				if(strCmd == "start")
					mWSA.Start(strHostProcessName);	
				else if(strCmd == "stop" || strCmd == "restart")
					mWSA.Stop(strHostProcessName);
				else 
					throw new Exception(string.Format("The command '{0}' doesn't have a handler in the progress controler", strCmd));
			}
			catch(Exception ex) 
			{
				Trace.WriteLine(ex.Message);
			}
		}
		#endregion

		#region Clean up any resources being used.
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.label = new System.Windows.Forms.Label();
			this.eventLog = new System.Diagnostics.EventLog();
			this.timer = new System.Timers.Timer();
			((System.ComponentModel.ISupportInitialize)(this.eventLog)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.timer)).BeginInit();
			this.SuspendLayout();
			// 
			// progressBar
			// 
			this.progressBar.Location = new System.Drawing.Point(6, 32);
			this.progressBar.Maximum = 40;
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(280, 14);
			this.progressBar.Step = 1;
			this.progressBar.TabIndex = 0;
			// 
			// label
			// 
			this.label.Location = new System.Drawing.Point(8, 6);
			this.label.Name = "label";
			this.label.Size = new System.Drawing.Size(278, 23);
			this.label.TabIndex = 1;
			this.label.Text = "label";
			// 
			// eventLog
			// 
			this.eventLog.Log = "Application";
			this.eventLog.SynchronizingObject = this;
			// 
			// timer
			// 
			this.timer.Enabled = true;
			this.timer.Interval = 500;
			this.timer.SynchronizingObject = this;
			this.timer.Elapsed += new System.Timers.ElapsedEventHandler(this.timer_Elapsed);
			// 
			// ProgressForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 54);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																																	this.label,
																																	this.progressBar});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(298, 79);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(298, 79);
			this.Name = "ProgressForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Progress";
			this.TopMost = true;
			this.Closing += new System.ComponentModel.CancelEventHandler(this.ProgressForm_Closing);
			((System.ComponentModel.ISupportInitialize)(this.eventLog)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.timer)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region events
		protected void OnEventLogEntryWritten(object source, EntryWrittenEventArgs e)
		{
			EventLogEntry ele = e.Entry;
			if(ele.Source == mstrHostProcessName) 
			{
				Trace.WriteLine("OnEventLogEntryWritten notification");
				timer.Interval = 10;
			}
		}		

		private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			Trace.WriteLine("Progress Tick for " + mstrCmd);

			if(progressBar.Value == progressBar.Maximum) 
			{
				if(mstrCmd != "done") 
				{
					timer.Stop();
					eventLog.EnableRaisingEvents = false;
					string msg = string.Format("The process couldn’t {0} it during the properly time", mstrCmd);
					eventLog.WriteEntry(msg, EventLogEntryType.Warning);
				}
				this.Close();
			}
			else
				if(progressBar.Value > progressBar.Maximum/3) 
			{
				//---check status
				if(mstrCmd != "done") 
				{
					ServiceControllerStatus scs = mWSA.Status(mstrHostProcessName);
					if(scs == ServiceControllerStatus.Running && mstrCmd == "start")
						mstrCmd = "done";
					else if(scs == ServiceControllerStatus.Stopped && mstrCmd == "stop")
						mstrCmd = "done";
					else if(scs == ServiceControllerStatus.Stopped && mstrCmd == "restart")
					{
						mstrCmd = "start";
						timer.Interval = 1000;
						mWSA.Start(mstrHostProcessName);				
					}
				}
				else
					timer.Interval = 10;
			}
			
			progressBar.Increment(1);
		}

		private void ProgressForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			timer.Stop();
			timer.Close();
			eventLog.Close();
		}
		#endregion
	}
}
