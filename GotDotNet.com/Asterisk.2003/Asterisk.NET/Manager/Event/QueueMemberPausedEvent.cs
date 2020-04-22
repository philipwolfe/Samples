namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A QueueMemberPausedEvent is triggered when a queue member is paused or unpaused.<br/>
	/// It is implemented in <code>apps/app_queue.c</code>.<br/>
	/// Available since Asterisk 1.2
	/// </summary>
	public class QueueMemberPausedEvent : AbstractQueueMemberEvent
	{
		private bool paused;

		/// <summary>
		/// Get/Set if this queue member is paused (not accepting calls).<br/>
		/// <code>true</code> if this member has been paused or
		/// <code>false</code> if not.
		/// </summary>
		virtual public bool Paused
		{
			get { return paused; }
			set { this.paused = value; }
		}
		
		public QueueMemberPausedEvent(object source)
			: base(source)
		{
		}
	}
}