namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// An AgentConnectEvent is triggered when a caller is connected to an agent.<br/>
	/// It is implemented in <code>apps/app_queue.c</code>.<br/>
	/// Available since Asterisk 1.2
	/// </summary>
	public class AgentConnectEvent : AbstractAgentEvent
	{
		/// <summary>
		/// Get/Set the amount of time the caller was on hold.
		/// </summary>
		virtual public long HoldTime
		{
			get { return holdTime; }
			set { this.holdTime = value; }
		}
		
		private long holdTime;
		
		public AgentConnectEvent(object source)
			: base(source)
		{
		}
	}
}