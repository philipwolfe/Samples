namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A DNDStateEvent is triggered by the Zap channel driver when a channel enters
	/// or leaves DND (do not disturb) state.<br/>
	/// It is implemented in <code>channels/chan_zap.c</code>.<br/>
	/// Available since Asterisk 1.2
	/// </summary>
	public class DNDStateEvent : ManagerEvent
	{
		/// <summary> The name of the channel.</summary>
		private string channel;
		/// <summary> The DND state of the channel.</summary>
		private string state;

		/// <summary>
		/// Get/Set the name of the channel. The channel name is of the form "Zap/&lt;channel number&gt;".
		/// </summary>
		virtual public string Channel
		{
			get { return channel; }
			set { this.channel = value; }
		}
		/// <summary>
		/// Get/Set DND state of the channel. "enabled" if do not disturb is on, "disabled" if it is off.
		virtual public string State
		{
			get { return state; }
			set { this.state = value; }
		}
		
		/// <summary>
		/// Creates a new DNDStateEvent.
		/// </summary>
		public DNDStateEvent(object source)
			: base(source)
		{
		}
	}
}