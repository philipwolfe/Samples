namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// An UnlinkEvent is triggered when a link between two voice channels is discontinued, for example,
	/// just before call completion.<br/>
	/// It is implemented in <code>channel.c</code>
	/// </summary>
	public class UnlinkEvent : LinkageEvent
	{
		public UnlinkEvent(object source): base(source)
		{
		}
	}
}