namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A QueueEntryEvent is triggered in response to a QueueStatusAction and contains information about an entry in a queue.<br/>
	/// It is implemented in <code>apps/app_queue.c</code>
	/// </summary>
	/// <seealso cref="Manager.Action.QueueStatusAction" />
	public class QueueEntryEvent : ResponseEvent
	{
		private string queue;
		private int position;
		private string channel;
		private string callerId;
		private string callerIdName;
		private long wait;

		/// <summary>
		/// Get/Set the name of the queue that contains this entry.
		/// </summary>
		virtual public string Queue
		{
			get { return this.queue; }
			set { this.queue = value; }
		}
		/// <summary>
		/// Get/Set the position of this entry in the queue.
		/// </summary>
		virtual public int Position
		{
			get { return this.position; }
			set { this.position = value; }
		}
		/// <summary>
		/// Get/Set the name of the channel of this entry.
		/// </summary>
		virtual public string Channel
		{
			get { return this.channel; }
			set { this.channel = value; }
		}
		/// <summary>
		/// Get/Set the the Caller*ID number of this entry.
		/// </summary>
		virtual public string CallerId
		{
			get { return this.callerId; }
			set { this.callerId = value; }
		}
		/// <summary>
		/// Get/Set the Caller*ID name of this entry.
		/// </summary>
		virtual public string CallerIdName
		{
			get { return this.callerIdName; }
			set { this.callerIdName = value; }
		}
		/// <summary>
		/// Get/Set the number of seconds this entry has spent in the queue.
		/// </summary>
		virtual public long Wait
		{
			get { return this.wait; }
			set { this.wait = value; }
		}

		public QueueEntryEvent(object source)
			: base(source)
		{
		}
	}
}