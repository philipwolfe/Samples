using System;
namespace Asterisk.NET.FastAGI
{
	/// <summary>
	/// Listens for incoming AGI connections, reads the inital data and builds an
	/// AGIRequest using an AGIRequestBuilder.<br/>
	/// The AGIRequest is then handed over to the appropriate AGIScript for
	/// processing.
	/// </summary>
	public interface IAGIServer
	{
		/// <summary>
		/// Starts this AGIServer.<br/>
		/// After calling startup() this AGIServer is ready to receive requests from
		/// Asterisk servers and process them.
		/// </summary>
		/// <throws>  IOException if the server socket cannot be bound. </throws>
		/// <throws>  IllegalStateException if this AGIServer is already running. </throws>
		void  Startup();

		/// <summary>
		/// Shuts this AGIServer down.<br/>
		/// The server socket is closed and all resources are freed.
		/// </summary>
		/// <throws>  IOException if the connection cannot be shut down. </throws>
		/// <throws>  IllegalStateException if this AGIServer is already shut down or </throws>
		void  Shutdown();
	}
}