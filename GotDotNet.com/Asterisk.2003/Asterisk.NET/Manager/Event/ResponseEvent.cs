namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// Abstract base class for events triggered in response to a ManagerAction.<br/>
	/// All ResponseEvents contain an additional action id property that links the
	/// event to the action that caused it.
	/// </summary>
	/// <seealso cref="Action.IManagerAction" />
	public abstract class ResponseEvent : ManagerEvent
	{
		private string actionId;
		private string internalActionId;

		/// <summary>
		/// Get/Set the action id of the ManagerAction that caused this event.
		/// </summary>
		virtual public string ActionId
		{
			get { return actionId; }
			set { this.actionId = value; }
		}
		/// <summary>
		/// Get/Set the internal action id of the ManagerAction that caused this event.
		/// </summary>
		virtual public string InternalActionId
		{
			get { return internalActionId; }
			set { this.internalActionId = value; }
		}

		public ResponseEvent(object source)
			: base(source)
		{
		}
	}
}