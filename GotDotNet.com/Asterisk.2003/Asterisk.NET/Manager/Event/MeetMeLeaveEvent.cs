namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A MeetMeLeaveEvent is triggered if a channel leaves a meet me conference.<br/>
	/// It is implemented in <code>apps/app_meetme.c</code>
	/// </summary>
	public class MeetMeLeaveEvent:MeetMeEvent
	{
		public MeetMeLeaveEvent(object source)
			: base(source)
		{
		}
	}
}