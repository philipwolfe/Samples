namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A ParkedCallEvent is triggered when a channel is parked (in this case no
	/// action id is set) and in response to a ParkedCallsAction.<br/>
	/// It is implemented in <code>res/res_features.c</code>
	/// </summary>
	/// <seealso cref="Manager.Action.ParkedCallsAction"/>
	public class ParkedCallEvent : ResponseEvent
	{
		private string exten;
		private string channel;
		private string from;
		private int timeout;
		private string callerId;
		private string callerIdName;
		private string uniqueId;

		/// <summary>Get/Set the extension the channel is parked at.</summary>
		virtual public string Exten
		{
			get { return exten; }
			set { this.exten = value; }
		}
		/// <summary>Get/Set the name of the channel that is parked.</summary>
		virtual public string Channel
		{
			get { return channel; }
			set { this.channel = value; }
		}
		/// <summary>Get/Set the name of the channel that parked the call.</summary>
		virtual public string From
		{
			get { return from; }
			set { this.from = value; }
		}
		/// <summary>
		/// Get/Set the number of seconds this call will be parked.<br/>
		/// This corresponds to the <code>parkingtime</code> option in
		/// <code>features.conf</code>.
		/// </summary>
		virtual public int Timeout
		{
			get { return timeout; }
			set { this.timeout = value; }
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
		/// <summary>
		/// Get/Set the unique id of the parked channel.
		/// </summary>
		virtual public string UniqueId
		{
			get { return uniqueId; }
			set { this.uniqueId = value; }
		}
		
		public ParkedCallEvent(object source)
			: base(source)
		{
		}
	}
}