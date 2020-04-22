namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// An AgentCompleteEvent is triggered when at the end of a call if the caller
	/// was connected to an agent.<br/>
	/// It is implemented in <code>apps/app_queue.c</code>.<br/>
	/// Available since Asterisk 1.2
	/// </summary>
	public class AgentCompleteEvent : AbstractAgentEvent
	{
		/// <summary>
		/// Get/Set the amount of time the caller was on hold.
		/// </summary>
		virtual public long HoldTime
		{
			get { return holdTime; }
			set { this.holdTime = value; }
		}
		/// <summary>
		/// Get/Set the amount of time the caller talked to the agent.
		/// </summary>
		virtual public long TalkTime
		{
			get { return talkTime; }
			set { this.talkTime = value; }
		}
		/// <summary>
		/// Get/Set if the agent or the caller terminated the call.
		/// </summary>
		virtual public string Reason
		{
			get { return reason; }
			set { this.reason = value; }
		}
		
		private long holdTime;
		private long talkTime;
		private string reason;
		
		public AgentCompleteEvent(object source)
			: base(source)
		{
		}
	}
}