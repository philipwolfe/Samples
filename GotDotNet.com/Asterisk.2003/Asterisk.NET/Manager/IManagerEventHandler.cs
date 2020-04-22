namespace Asterisk.NET.Manager
{
	/// <summary>
	/// An Interface to handle events received from an asterisk server.
	/// </summary>
	/// <seealso cref="Manager.event.ManagerEvent"/>
	public interface IManagerEventHandler
	{
		/// <summary>
		/// This method is called when an event is received.
		/// </summary>
		/// <param name="e">the event received</param>
		void  HandleEvent(Event.ManagerEvent e);
	}
}