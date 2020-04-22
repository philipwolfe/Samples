namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// An ExtensionStatusEvent is triggered when the state of an extension changes.<br/>
	/// It is implemented in <code>manager.c</code>
	/// </summary>
	public class ExtensionStatusEvent : ManagerEvent
	{
		private string exten;
		private string context;
		private int status;

		/// <summary>
		/// Get/Set the extension.
		/// </summary>
		virtual public string Exten
		{
			get { return exten; }
			set { this.exten = value; }
		}
		/// <summary>
		/// Get/Set the context of the extension.
		/// </summary>
		virtual public string Context
		{
			get { return context; }
			set { this.context = value; }
		}
		/// <summary>
		/// Get/Set the state of the extension.
		/// </summary>
		virtual public int Status
		{
			get { return status; }
			set { this.status = value; }
		}
		
		public ExtensionStatusEvent(object source)
			: base(source)
		{
		}
	}
}