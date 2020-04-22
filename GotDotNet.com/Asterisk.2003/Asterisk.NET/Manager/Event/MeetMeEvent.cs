namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// Abstract base class providing common properties for meet me (asterisk's conference system) events.
	/// </summary>
	public abstract class MeetMeEvent : ManagerEvent
	{
		private string channel;
		private string uniqueId;
		private string meetMe;
		private int userNum;

		/// <summary>
		/// Get/Set the name of the channel that joined of left a conference.
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
		/// Get/Set the conference number.
		/// </summary>
		virtual public string MeetMe
		{
			get { return meetMe; }
			set { this.meetMe = value; }
		}
		virtual public int UserNum
		{
			get { return userNum; }
			set { this.userNum = value; }
		}
		
		public MeetMeEvent(object source)
			: base(source)
		{
		}
	}
}