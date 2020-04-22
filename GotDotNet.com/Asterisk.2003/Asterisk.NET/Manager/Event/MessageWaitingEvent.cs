namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A MessageWaitingEvent is triggered when someone leaves voicemail.<br/>
	/// It is implemented in <code>apps/app_voicemail.c</code>
	/// </summary>
	public class MessageWaitingEvent : ManagerEvent
	{
		private string mailbox;
		private int waiting;
		private int newMessages;
		private int oldMessages;

		/// <summary>
		/// Get/Set the name of the mailbox that has waiting messages.<br/>
		/// The name of the mailbox is of the form numberOfMailbox@context, e.g. 1234@default.
		/// </summary>
		virtual public string Mailbox
		{
			get { return mailbox; }
			set { this.mailbox = value; }
		}
		/// <summary>
		/// Get/Set the number of new messages in the mailbox.
		/// </summary>
		virtual public int Waiting
		{
			get { return waiting; }
			set { this.waiting = value; }
		}
		/// <summary>
		/// Get/Set the number of new messages in this mailbox.
		/// </summary>
		virtual public int New
		{
			get { return newMessages; }
			set { this.newMessages = value; }
		}
		/// <summary>
		/// Get/Set the number of old messages in this mailbox.
		/// </summary>
		virtual public int Old
		{
			get { return oldMessages; }
			set { this.oldMessages = value; }
		}
		
		public MessageWaitingEvent(object source)
			: base(source)
		{
		}
	}
}