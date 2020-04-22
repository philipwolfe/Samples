namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A MeetMeTalkingEvent is triggered when a user starts talking in a meet me conference.<br/>
	/// It is implemented in <code>apps/app_meetme.c</code><br/>
	/// </summary>
	public class MeetMeTalkingEvent:MeetMeEvent
	{
		public MeetMeTalkingEvent(object source)
			: base(source)
		{
		}
	}
}