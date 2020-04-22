namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// Abstract base class for events triggered in response to an OriginateAction.
	/// </summary>
	/// <seealso cref="Manager.Action.OriginateAction" />
	public abstract class OriginateEvent : ResponseEvent
	{
		private string channel;
		private string context;
		private string exten;
		private string uniqueId;
		private int reason;

		/// <summary>
		/// Get/Set the name of the channel to connect to the outgoing call.
		/// </summary>
		virtual public string Channel
		{
			get { return this.channel; }
			set { this.channel = value; }
		}
		/// <summary>
		/// Get/Set the name of the context of the extension to connect to.
		/// </summary>
		virtual public string Context
		{
			get { return this.context; }
			set { this.context = value; }
		}
		/// <summary>
		/// Get/Set the the extension to connect to.
		/// </summary>
		virtual public string Exten
		{
			get { return this.exten; }
			set { this.exten = value; }
		}

		virtual public int Reason
		{
			get { return this.reason; }
			set { this.reason = value; }
		}

		virtual public string UniqueId
		{
			get { return this.uniqueId; }
			set { this.uniqueId = value; }
		}
		
		public OriginateEvent(object source)
			: base(source)
		{
		}
	}
}