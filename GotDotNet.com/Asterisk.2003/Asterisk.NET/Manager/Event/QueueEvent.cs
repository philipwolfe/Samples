namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// Abstract base class providing common properties for JoinEvent and LeaveEvent.
	/// </summary>
	public abstract class QueueEvent : ManagerEvent
	{
		private string channel;
		private string queue;
		private int count;

		/// <summary>
		/// Get/Set the name of the channel that joines or leaves a queue.
		/// </summary>
		virtual public string Channel
		{
			get { return channel; }
			set { this.channel = value; }
		}
		/// <summary>
		/// Get/Set the number of elements in the queue, i.e. the number of calls waiting to be answered by an agent.
		/// </summary>
		virtual public int Count
		{
			get { return count; }
			set { this.count = value; }
		}
		/// <summary>
		/// Get/Set the name of the queue.
		/// </summary>
		virtual public string Queue
		{
			get { return queue; }
			set { this.queue = value; }
		}
		
		public QueueEvent(object source)
			: base(source)
		{
		}
	}
}