namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// Abstract base class for several queue member related events.
	/// </summary>
	public abstract class AbstractQueueMemberEvent : ManagerEvent
	{
		private string queue;
		private string location;

		/// <summary>
		/// Returns the name of the queue.
		/// </summary>
		virtual public string Queue
		{
			get { return queue; }
			set { this.queue = value; }
		}
		/// <summary>
		/// Returns the name of the member's interface.<br/>
		/// E.g. the channel name or agent group.
		/// </summary>
		virtual public string Location
		{
			get { return location; }
			set { this.location = value; }
		}
		
		public AbstractQueueMemberEvent(object source)
			: base(source)
		{
		}
	}
}