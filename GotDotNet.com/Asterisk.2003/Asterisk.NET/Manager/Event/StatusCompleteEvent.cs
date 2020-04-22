namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A StatusCompleteEvent is triggered after the state of all channels has been reported in response
	/// to a StatusAction.
	/// </summary>
	/// <seealso cref="Manager.Action.StatusAction"/>
	/// <seealso cref="Manager.event.StatusEvent"/>
	public class StatusCompleteEvent : ResponseEvent
	{
		public StatusCompleteEvent(object source)
			: base(source)
		{
		}
	}
}