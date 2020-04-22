using System;

namespace Asterisk.NET.Manager.Action
{
	/// <summary>
	/// The StopMonitorAction ends monitoring (recording) a channel.<br/>
	/// It is implemented in <code>res/res_monitor.c</code>
	/// </summary>
	public class StopMonitorAction : AbstractManagerAction
	{
		/// <summary> The name of the channel to end monitoring.</summary>
		private string channel;

		/// <summary>
		/// Get the name of this action, i.e. "StopMonitor".
		/// </summary>
		override public string Action
		{
			get { return "StopMonitor"; }
		}
		/// <summary>
		/// Get/Set the name of the channel to end monitoring.<br/>
		/// This property is mandatory.
		/// </summary>
		virtual public string Channel
		{
			get { return this.channel; }
			set { this.channel = value; }
		}
		
		/// <summary>
		/// Creates a new empty StopMonitorAction.
		/// </summary>
		public StopMonitorAction()
		{
		}
		
		/// <summary>
		/// Creates a new StopMonitorAction that ends monitoring of the given channel.
		/// </summary>
		public StopMonitorAction(string channel)
		{
			this.channel = channel;
		}
	}
}