namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A NewExtenEvent is triggered when a channel is connected to a new extension.<br/>
	/// It is implemented in <code>pbx.c</code>
	/// </summary>
	public class NewExtenEvent : ManagerEvent
	{
		private string uniqueId;
		private string context;
		private string extension;
		private string application;
		private string appData;
		private int priority;
		private string channel;

		/// <summary>
		/// Get/Set the unique id of the channel.
		/// </summary>
		virtual public string UniqueId
		{
			get { return uniqueId; }
			set { this.uniqueId = value; }
		}
		/// <summary>
		/// Get/Set the name of the application that is executed.
		/// </summary>
		virtual public string Application
		{
			get { return application; }
			set { this.application = value; }
		}
		/// <summary>
		/// Get/Set the parameters passed to the application that is executed. The parameters are separated by a '|' character.
		/// </summary>
		virtual public string AppData
		{
			get { return appData; }
			set { this.appData = value; }
		}
		/// <summary>
		/// Get/Set the name of the channel.
		/// </summary>
		virtual public string Channel
		{
			get { return channel; }
			set { this.channel = value; }
		}
		/// <summary>
		/// Get/Set the name of the context of the connected extension.
		/// </summary>
		virtual public string Context
		{
			get { return context; }
			set { this.context = value; }
		}
		/// <summary>
		/// Get/Set the extension.
		/// </summary>
		virtual public string Extension
		{
			get { return extension; }
			set { this.extension = value; }
		}
		/// <summary>
		/// Get/Set the priority.
		/// </summary>
		virtual public int Priority
		{
			get { return priority; }
			set { this.priority = value; }
		}
	
		public NewExtenEvent(object source)
			: base(source)
		{
		}
	}
}