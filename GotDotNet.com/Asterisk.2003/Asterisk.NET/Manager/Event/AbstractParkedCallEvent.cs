namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	///  Abstract base class for several call parking related events.
	/// </summary>
	public abstract class AbstractParkedCallEvent : ManagerEvent
	{
		private string exten;
		private string channel;
		private string callerId;
		private string callerIdName;
		
		/// <summary>
		/// Get/Set the extension the channel is or was parked at.
		/// </summary>
		virtual public string Exten
		{
			get { return exten; }
			set { this.exten = value; }
		}
		/// <summary>
		/// Get/Set the name of the channel that is or was parked.
		/// </summary>
		virtual public string Channel
		{
			get { return channel; }
			set { this.channel = value; }
		}
		/// <summary>
		/// Get/Set the Caller*ID number of the parked channel.
		/// </summary>
		virtual public string CallerId
		{
			get { return callerId; }
			set { this.callerId = value; }
		}
		/// <summary>
		/// Get/Set the Caller*ID name of the parked channel.
		/// </summary>
		virtual public string CallerIdName
		{
			get { return callerIdName; }
			set { this.callerIdName = value; }
		}

		public AbstractParkedCallEvent(object source)
			: base(source)
		{
		}
	}
}