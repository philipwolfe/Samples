namespace Asterisk.NET.FastAGI
{
	/// <summary>
	/// AGIScripts are used by the AsteriskServer to handle AGIRequests received from the Asterisk server.<br/>
	/// To implement functionality using this framework you have to implement this interface.<br/>
	/// Note: The implementation of AGIScript must be threadsafe as only one instance is used by AsteriskServer to handle all requests to a resource.
	/// </summary>
	public interface IAGIScript
	{
		/// <summary>
		/// The service method is called by the AsteriskServer whenever this AGIScript should handle an incoming AGIRequest.
		/// </summary>
		/// <param name="request">the initial data received from Asterisk when requesting this script.</param>
		/// <param name="channel">a handle to communicate with Asterisk such as sending commands to the channel sending the request.</param>
		/// <throws>AGIException any exception thrown by your script will be logged.</throws>
		void  Service(AGIRequest request, AGIChannel channel);
	}
}
