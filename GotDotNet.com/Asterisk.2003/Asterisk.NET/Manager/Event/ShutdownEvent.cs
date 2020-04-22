namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A ShutdownEvent is triggered when the asterisk server is shut down or restarted.<br/>
	/// It is implemented in <code>asterisk.c</code>
	/// </summary>
	public class ShutdownEvent : ManagerEvent
	{
		private bool restart = false;
		private string shutdown;

		/// <summary>
		/// Get/Set the kind of shutdown or restart. Possible values are "Uncleanly" and "Cleanly". A
		/// shutdown is considered unclean if there are any active channels when the system is shut down.
		/// </summary>
		virtual public string Shutdown
		{
			get { return shutdown; }
			set { this.shutdown = value; }
		}
		/// <summary>
		/// Get/Set <code>true</code> if the server has been restarted; <code>false</code> if it has been halted.
		/// </summary>
		virtual public bool Restart
		{
			get { return restart; }
			set { this.restart = value; }
		}
		
		public ShutdownEvent(object source)
			: base(source)
		{
		}
	}
}