namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// An AgentCalledEvent is triggered when an agent is rung.<br/>
	/// To enable AgentCalledEvents you have to set <code>eventwhencalled = yes</code> in <code>queues.conf</code>.<br/>
	/// This event is implemented in <code>apps/app_queue.c</code>
	/// </summary>
	public class AgentCalledEvent : ManagerEvent
	{
		private string agentCalled;
		private string channelCalling;
		private string callerId;
		private string callerIdName;
		private string context;
		private string extension;
		private string priority;

		virtual public string AgentCalled
		{
			get { return agentCalled; }
			set { this.agentCalled = value; }
		}
		virtual public string ChannelCalling
		{
			get { return channelCalling; }
			set { this.channelCalling = value; }
		}
		virtual public string CallerId
		{
			get { return callerId; }
			set { this.callerId = value; }
		}
		/// <summary>
		/// Get/Set the Caller*ID name of the calling channel.
		/// </summary>
		virtual public string CallerIdName
		{
			get { return callerIdName; }
			set { this.callerIdName = value; }
		}
		virtual public string Context
		{
			get { return context; }
			set { this.context = value; }
		}
		virtual public string Extension
		{
			get { return extension; }
			set { this.extension = value; }
		}
		virtual public string Priority
		{
			get { return priority; }
			set { this.priority = value; }
		}
		
		public AgentCalledEvent(object source)
			: base(source)
		{
		}
	}
}