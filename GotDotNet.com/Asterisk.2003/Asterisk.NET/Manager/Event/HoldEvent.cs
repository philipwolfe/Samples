namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A HoldEvent is triggered by the SIP channel driver when a channel is put on hold.<br/>
	/// It is implemented in <code>channels/chan_sip.c</code>.<br/>
	/// Available since Asterisk 1.2
	/// </summary>
	/// <seealso cref="Manager.event.UnholdEvent" />
	public class HoldEvent : ManagerEvent
	{
		private string channel;
		private string uniqueId;
		
		/// <summary>
		/// Get/Set the name of the channel.
		/// </summary>
		virtual public string Channel
		{
			get { return channel; }
			set { this.channel = value; }
		}
		/// <summary>
		/// Get/Set the unique id of the channel.
		/// </summary>
		virtual public string UniqueId
		{
			get { return uniqueId; }
			set { this.uniqueId = value; }
		}
		
		public HoldEvent(object source)
			: base(source)
		{
		}
	}
}