namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// Abstract base class providing common properties for LinkEvent and UnlinkEvent.
	/// </summary>
	public abstract class LinkageEvent : ManagerEvent
	{
		private string uniqueId1;
		private string uniqueId2;
		private string channel1;
		private string channel2;
		private string callerId1;
		private string callerId2;

		/// <summary>
		/// Get/Set the unique id of the first channel.
		/// </summary>
		virtual public string UniqueId1
		{
			get { return uniqueId1; }
			set { this.uniqueId1 = value; }
		}
		/// <summary>
		/// Get/Set the unique id of the second channel.
		/// </summary>
		virtual public string UniqueId2
		{
			get { return uniqueId2; }
			set { this.uniqueId2 = value; }
		}
		/// <summary>
		/// Get/Set the name of the first channel.
		/// </summary>
		virtual public string Channel1
		{
			get { return channel1; }
			set { this.channel1 = value; }
		}
		/// <summary>
		/// Get/Set the name of the second channel.
		/// </summary>
		virtual public string Channel2
		{
			get { return channel2; }
			set { this.channel2 = value; }
		}
		/// <summary>
		/// Get/Set the Caller*Id number of the first channel.
		/// </summary>
		virtual public string CallerId1
		{
			get { return callerId1; }
			set { this.callerId1 = value; }
		}
		/// <summary>
		/// Get/Set the Caller*Id number of the second channel.
		/// </summary>
		virtual public string CallerId2
		{
			get { return callerId2; }
			set { this.callerId2 = value; }
		}
		
		public LinkageEvent(object source)
			: base(source)
		{
		}
	}
}