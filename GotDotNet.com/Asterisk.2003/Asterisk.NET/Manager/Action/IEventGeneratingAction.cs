using System;
namespace Asterisk.NET.Manager.Action
{
	/// <summary>
	/// The EventGeneratingAction interface is implemented by ManagerActions that
	/// return their result not in a ManagerResponse but by sending a series of
	/// events.<br/>
	/// The event type that indicates that Asterisk is finished is returned by the
	/// getActionCompleteEventClass() method.
	/// </summary>
	/// <seealso cref="Asterisk.NET.Manager.Event.ResponseEvent"/>
	public interface IEventGeneratingAction : IManagerAction
	{
		/// <summary>
		/// Returns the event type that indicates that Asterisk is finished sending response events for this action.
		/// </summary>
		/// <seealso cref="Asterisk.NET.Manager.Event.ResponseEvent"/>
		Type ActionCompleteEventClass
		{
			get;
		}
	}
}