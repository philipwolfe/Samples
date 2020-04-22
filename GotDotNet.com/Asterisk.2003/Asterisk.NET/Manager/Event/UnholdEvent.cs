namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// An UnholdEvent is triggered by the SIP channel driver when a channel is no
	/// longer put on hold.<br/>
	/// It is implemented in <code>channels/chan_sip.c</code>.<br/>
	/// Available since Asterisk 1.2
	/// </summary>
	/// <seealso cref="Manager.event.HoldEvent"/>
	public class UnholdEvent : ManagerEvent
	{
		/// <summary> The name of the channel.</summary>
		private string channel;
		/// <summary> The unique id of the channel.</summary>
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
	
		/// <summary>
		/// Creates a new UnholdEvent.
		/// </summary>
		public UnholdEvent(object source)
			: base(source)
		{
		}
	}
}