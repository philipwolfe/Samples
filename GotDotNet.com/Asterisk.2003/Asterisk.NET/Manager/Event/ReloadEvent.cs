namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A ReloadEvent is triggerd when the <code>reload</code> console command is executed or the asterisk server is started.<br/>
	/// It is implemented in <code>manager.c</code>
	/// </summary>
	public class ReloadEvent : ManagerEvent
	{
		private string message;

		/// <summary> Always returns "Reload Requested".</summary>
		virtual public string Message
		{
			get { return message; }
			set { this.message = value; }
		}

		public ReloadEvent(object source)
			: base(source)
		{
		}
	}
}