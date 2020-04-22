using Asterisk.NET.Manager.Response;

namespace Asterisk.NET.Manager
{
	/// <summary>
	/// An Interface to handle responses received from an asterisk server.
	/// </summary>
	/// <seealso cref="ManagerResponse" />
	public interface IManagerResponseHandler
	{
		/// <summary>
		/// This method is called when a response is received.
		/// </summary>
		/// <param name="response">the response received</param>
		void  HandleResponse(ManagerResponse response);
	}
}