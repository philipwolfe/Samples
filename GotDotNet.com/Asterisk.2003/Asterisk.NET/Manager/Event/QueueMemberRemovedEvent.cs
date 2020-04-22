namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A QueueMemberRemovedEvent is triggered when a queue member is removed from a queue.<br/>
	/// It is implemented in <code>apps/app_queue.c</code>.<br/>
	/// Available since Asterisk 1.2
	/// </summary>
	public class QueueMemberRemovedEvent : AbstractQueueMemberEvent
	{
		public QueueMemberRemovedEvent(object source)
			: base(source)
		{
		}
	}
}