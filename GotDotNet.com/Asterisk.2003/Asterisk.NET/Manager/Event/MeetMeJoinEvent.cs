namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A MeetMeJoinEvent is triggered if a channel joins a meet me conference.<br/>
	/// It is implemented in <code>apps/app_meetme.c</code>
	/// </summary>
	public class MeetMeJoinEvent:MeetMeEvent
	{
		public MeetMeJoinEvent(object source)
			: base(source)
		{
		}
	}
}