namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// Abstract base class for several agent related events.
	/// </summary>
	public abstract class AbstractAgentEvent : ManagerEvent
	{
		private string channel;
		private string uniqueId;
		private string queue;
		private string member;

		/// <summary>
		/// Get/Set the name of the channel.
		/// </summary>
		virtual public string Channel
		{
			get { return channel; }
			set { this.channel = value; }
		}
		/// <summary>
		/// Get/Set the unique id of the channel.
		/// </summary>
		virtual public string UniqueId
		{
			get { return uniqueId; }
			set { this.uniqueId = value; }
		}
		/// <summary>
		/// Get/Set the name of the queue.
		/// </summary>
		virtual public string Queue
		{
			get { return queue; }
			set { this.queue = value; }
		}
		/// <summary>
		/// Get/Set the name of the member's interface.
		/// </summary>
		virtual public string Member
		{
			get { return member; }
			set { this.member = value; }
		}
		
		public AbstractAgentEvent(object source)
			: base(source)
		{
		}
	}
}