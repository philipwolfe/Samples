using System;
namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A LogChannelEvent is triggered when logging is turned on or off.<br/>
	/// It is implemented in <code>logger.c</code><br/>
	/// </summary>
	public class LogChannelEvent : ManagerEvent
	{
		private string channel;
		private bool enabled;
		private int reason;
		private string reasonTxt;

		/// <summary>
		/// Get/Set the name of the log channel.
		/// </summary>
		virtual public string Channel
		{
			get { return channel; }
			set { this.channel = value; }
		}
		/// <summary>
		/// Get/Set if logging has been enabled or disabled.
		/// </summary>
		virtual public bool Enabled
		{
			get { return enabled; }
			set { this.enabled = value; }
		}
		/// <summary>
		/// Get the textual representation of the reason for disabling logging.
		/// </summary>
		virtual public string ReasonTxt
		{
			get { return reasonTxt; }
		}
		
		public LogChannelEvent(object source)
			: base(source)
		{
		}
		
		/// <summary>
		/// Get the reason code for disabling logging.
		/// </summary>
		public virtual int getReason()
		{
			return reason;
		}
		
		/// <summary>
		/// Sets the reason for disabling logging.
		/// </summary>
		/// <param name="s">the reason in the form "%d - %s".</param>
		public virtual void  setReason(string s)
		{
			int spaceIdx;
			
			if (s == null)
				return ;
			
			if ((spaceIdx = s.IndexOf(' ')) <= 0)
				spaceIdx = s.Length;

			try
			{
				this.reason = int.Parse(s.Substring(0, (spaceIdx) - (0)));
			}
			catch (FormatException)
			{
				return ;
			}

			if (s.Length > spaceIdx + 3)
				this.reasonTxt = s.Substring(spaceIdx + 3, (s.Length) - (spaceIdx + 3));
		}
	}
}