namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// Abstract base class providing common properties for HangupEvent, NewChannelEvent and NewStateEvent.
	/// </summary>
	public abstract class ChannelEvent : ManagerEvent
	{
		/// <summary> The name of the channel.</summary>
		private string channel;
		/// <summary> The state of the channel.</summary>
		private string state;
		/// <summary> This Caller*ID of the channel.</summary>
		private string callerId;
		/// <summary> The Caller*ID Name of the channel.</summary>
		private string callerIdName;
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
		/// Get/Set the Caller*ID of the channel if set or &lt;unknown&gt; if none has been set.
		/// </summary>
		virtual public string CallerId
		{
			get { return callerId; }
			set { this.callerId = value; }
		}
		/// <summary>
		/// Get/Set the Caller*ID Name of the channel if set or &lg;unknown&gt; if none has been set.
		/// </summary>
		virtual public string CallerIdName
		{
			get { return callerIdName; }
			set { this.callerIdName = value; }
		}
		/// <summary>
		/// Get/Set the (new) state of the channel.<br/>
		/// The following states are used:<br/>
		/// <ul>
		/// <li>Down</li>
		/// <li>OffHook</li>
		/// <li>Dialing</li>
		/// <li>Ring</li>
		/// <li>Ringing</li>
		/// <li>Up</li>
		/// <li>Busy</li>
		/// <ul>
		/// </summary>
		virtual public string State
		{
			get { return state; }
			set { this.state = value; }
		}
		
		public ChannelEvent(object source)
			: base(source)
		{
		}
	}
}