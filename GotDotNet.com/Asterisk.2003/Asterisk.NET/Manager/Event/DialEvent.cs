namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A dial event is triggered whenever a phone attempts to dial someone.<br/>
	/// This event is implemented in <code>apps/app_dial.c</code>.<br/>
	/// Available since Asterisk 1.2.
	/// </summary>
	public class DialEvent : ManagerEvent
	{
		/// <summary> The name of the source channel.</summary>
		private string src;
		/// <summary> The name of the destination channel.</summary>
		private string destination;
		/// <summary> The new Caller*ID.</summary>
		private string callerId;
		/// <summary> The new Caller*ID Name.</summary>
		private string callerIdName;
		/// <summary> The unique id of the source channel.</summary>
		private string srcUniqueId;
		/// <summary> The unique id of the destination channel.</summary>
		private string destUniqueId;

		/// <summary>
		/// Returns the name of the source channel.
		/// </summary>
		virtual public string Src
		{
			get { return src; }
			set { this.src = value; }
		}
		/// <summary>
		/// Get/Set the name of the destination channel.
		/// </summary>
		virtual public string Destination
		{
			get { return destination; }
			set { this.destination = value; }
		}
		/// <summary>
		/// Get/Set the Caller*ID.
		/// </summary>
		virtual public string CallerId
		{
			get { return callerId; }
			set { this.callerId = value; }
		}
		/// <summary>
		/// Get/Set the Caller*ID Name.
		/// </summary>
		virtual public string CallerIdName
		{
			get { return callerIdName; }
			set { this.callerIdName = value; }
		}
		/// <summary>
		/// Get/Set the unique ID of the source channel.
		/// </summary>
		virtual public string SrcUniqueId
		{
			get { return srcUniqueId; }
			set { this.srcUniqueId = value; }
		}
		/// <summary>
		/// Get/Set the unique ID of the distination channel.
		/// </summary>
		virtual public string DestUniqueId
		{
			get { return destUniqueId; }
			set { this.destUniqueId = value; }
		}
	
		/// <summary>
		/// Creates a new DialEvent.
		/// </summary>
		public DialEvent(object source)
			: base(source)
		{
		}
	}
}