namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A LinkEvent is triggered when two voice channels are linked together and voice data exchange commences.<br/>
	/// Several Link events may be seen for a single call. This can occur when Asterisk fails to setup a
	/// native bridge for the call.This is when Asterisk must sit between two telephones and perform
	/// CODEC conversion on their behalf.<br/>
	/// It is implemented in <code>channel.c</code>
	/// </summary>
	public class LinkEvent:LinkageEvent
	{
		public LinkEvent(object source)
			: base(source)
		{
		}
	}
}