namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A RenameEvent is triggered when the name of a channel is changed.<br/>
	/// It is implemented in <code>channel.c</code>
	/// </summary>
	public class RenameEvent : ManagerEvent
	{
		/// <summary> Old name of the channel before renaming occured.</summary>
		protected internal string oldname;
		/// <summary> New name of the channel after renaming occured.</summary>
		protected internal string newname;
		/// <summary> Unique id of the channel.</summary>
		protected internal string uniqueId;

		/// <summary>
		/// Get/Set the new name of the channel.
		/// </summary>
		virtual public string Newname
		{
			get { return newname; }
			set { this.newname = value; }
		}
		/// <summary>
		/// Get/Set the old name of the channel.
		/// </summary>
		virtual public string Oldname
		{
			get { return oldname; }
			set { this.oldname = value; }
		}
		/// <summary>
		/// Get/Set the unique id of the channel.
		/// </summary>
		virtual public string UniqueId
		{
			get { return uniqueId; }
			set { this.uniqueId = value; }
		}

		public RenameEvent(object source)
			: base(source)
		{
		}
	}
}