namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// An AgentCallbackLogoffEvent is triggered when an agent that previously logged in using AgentLogin is logged of.<br/>
	/// It is implemented in <code>channels/chan_agent.c</code>
	/// </summary>
	/// <seealso cref="Manager.event.AgentLoginEvent" />
	public class AgentLogoffEvent : ManagerEvent
	{
		/// <summary> The name of the agent that logged off.</summary>
		private string agent;
		private string loginTime;
		private string uniqueId;
		
		/// <summary>
		/// Get/Set the name of the agent that logged off.
		/// </summary>
		virtual public string Agent
		{
			get { return agent; }
			set { this.agent = value; }
		}
		virtual public string LoginTime
		{
			get { return loginTime; }
			set { this.loginTime = value; }
		}
		virtual public string UniqueId
		{
			get { return uniqueId; }
			set { this.uniqueId = value; }
		}
		
		public AgentLogoffEvent(object source)
			: base(source)
		{
		}
	}
}