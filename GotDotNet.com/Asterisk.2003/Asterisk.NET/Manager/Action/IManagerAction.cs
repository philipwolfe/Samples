using System;

namespace Asterisk.NET.Manager.Action
{
	/// <summary>
	/// Interface that all Actions that can be sent to the Asterisk server must impement.<br/>
	/// Instances of this class represent a command sent to Asterisk via Manager API,
	/// requesting a particular Action be performed. The number of actions available
	/// to the client are determined by the modules presently loaded in the Asterisk engine.<br/>
	/// There is one conrete subclass of ManagerAction per each supported Asterisk Action.
	/// </summary>
	public interface IManagerAction
	{
		/// <summary>
		/// Get the name of the action.
		/// </summary>
		string Action
		{
			get;
		}
		/// <summary>
		/// Get/Set  the action id.<br/>
		/// If the action id is set and sent to the asterisk server any response
		/// returned by the asterisk server will include the same action id. This way
		/// the action id can be used to track actions and their corresponding
		/// responses.
		/// </summary>
		string ActionId
		{
			get;
			set;
		}
	}
}