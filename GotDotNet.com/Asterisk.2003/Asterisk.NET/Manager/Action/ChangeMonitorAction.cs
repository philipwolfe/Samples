using System;

namespace Asterisk.NET.Manager.Action
{
	/// <summary>
	/// The ChangeMonitorAction changes the monitoring filename of a channel.
	/// It has no effect if the channel is not monitored.<br/>
	/// It is implemented in <code>res/res_monitor.c</code>
	/// </summary>
	public class ChangeMonitorAction : AbstractManagerAction
	{
		private string channel;
		private string file;

		/// <summary>
		/// Get the name of this action, i.e. "ChangeMonitor".
		/// </summary>
		override public string Action
		{
			get { return "ChangeMonitor"; }
		}
		/// <summary>
		/// Get/Set the name of the monitored channel.<br/>
		/// This property is mandatory.
		/// </summary>
		virtual public string Channel
		{
			get { return this.channel; }
			set { this.channel = value; }
		}
		/// <summary>
		/// Get/Set the name of the file to which the voice data is written.<br/>
		/// This property is mandatory.
		/// </summary>
		virtual public string File
		{
			get { return this.file; }
			set { this.file = value; }
		}

		/// <summary>
		/// Creates a new empty ChangeMonitorAction.
		/// </summary>
		public ChangeMonitorAction()
		{
		}
		
		/// <summary>
		/// Creates a new ChangeMonitorAction that causes monitoring data for the
		/// given channel to be written to the given file(s).
		/// </summary>
		/// <param name="channel">the name of the channel that is monitored</param>
		/// <param name="file">the (base) name of the file(s) to which the voice data is written</param>
		public ChangeMonitorAction(string channel, string file)
		{
			this.channel = channel;
			this.file = file;
		}
	}
}