namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A ConnectEvent is triggered after successful login to the asterisk server.<br/>
	/// It is a pseudo event not directly related to an asterisk generated event.
	/// </summary>
	public class ConnectEvent : ManagerEvent
	{
		/// <summary> The version of the manager protocol.</summary>
		private string protocolIdentifier;
		
		/// <summary>
		/// Get/Set the version of the protocol.
		/// </summary>
		virtual public string ProtocolIdentifier
		{
			get { return protocolIdentifier; }
			set { this.protocolIdentifier = value; }
		}
		
		public ConnectEvent(object source)
			: base(source)
		{
		}
	}
}