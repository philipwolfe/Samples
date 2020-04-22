namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// An AgentLoginEvent is triggered when an agent is successfully logged in using AgentLogin.<br/>
	/// It is implemented in <code>channels/chan_agent.c</code>
	/// </summary>
	/// <seealso cref="Manager.event.AgentLogoffEvent" />
	public class AgentLoginEvent : ManagerEvent
	{
		private string agent;
		private string loginChan;
		private string uniqueId;

		/// <summary>
		/// Get/Set the name of the agent that logged in.
		/// </summary>
		virtual public string Agent
		{
			get { return agent; }
			set { this.agent = value; }
		}
		virtual public string LoginChan
		{
			get { return loginChan; }
			set { this.loginChan = value; }
		}
		virtual public string UniqueId
		{
			get { return uniqueId; }
			set { this.uniqueId = value; }
		}

		public AgentLoginEvent(object source)
			: base(source)
		{
		}
	}
}