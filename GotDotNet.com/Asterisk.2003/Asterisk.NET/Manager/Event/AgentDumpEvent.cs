namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// An AgentDumpEvent is triggered when an agent dumps the caller while listening
	/// to the queue announcement.<br/>
	/// It is implemented in <code>apps/app_queue.c</code>.<br/>
	/// Available since Asterisk 1.2
	/// </summary>
	public class AgentDumpEvent : AbstractAgentEvent
	{
		public AgentDumpEvent(object source)
			: base(source)
		{
		}
	}
}