using System.Collections;
using Asterisk.NET.Manager.Response;

namespace Asterisk.NET.Manager
{
	/// <summary>
	/// Contains the result of executing an EventGeneratingAction, that is the ManagerResponse and any received ManagerEvents.
	/// </summary>
	/// <seealso cref="Action.IEventGeneratingAction" />
	public interface IResponseEvents
	{
		/// <summary>
		/// Returns the ManagerResponse received.
		/// </summary>
		/// <returns>the ManagerResponse received.</returns>
		ManagerResponse Response
		{
			get;
		}
		/// <summary>
		/// Returns a Collection of ManagerEvents that have been received including the last one that indicates completion.
		/// </summary>
		/// <returns>a Collection of ManagerEvents received.</returns>
		ArrayList Events
		{
			get;
		}
	}
}