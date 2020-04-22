using Asterisk.NET.Manager.Event;
using Asterisk.NET.Manager.Response;

namespace Asterisk.NET.Manager
{
	public interface IDispatcher
	{
		/// <summary>
		/// This method is called by the reader whenever a ManagerResponse is received. The
		/// response is dispatched to the associated ManagerResponseHandler.
		/// </summary>
		/// <param name="response">the resonse received by the reader</param>
		/// <seealso cref="ManagerReader" />
		void  DispatchResponse(ManagerResponse response);
		
		/// <summary>
		/// This method is called by the reader whenever a ManagerEvent is received. The event is
		/// dispatched to all registered ManagerEventHandlers.
		/// </summary>
		/// <param name="e">the event received by the reader</param>
		/// <seealso cref="ManagerReader" />
		void  DispatchEvent(ManagerEvent e);
	}
}