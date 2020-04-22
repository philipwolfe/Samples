using System;
namespace Asterisk.NET.IO
{
	public interface IServerSocket
	{
		/// <summary>
		/// Waits for a new incoming connection.
		/// </summary>
		/// <returns>the new connection.</returns>
		/// <throws>IOException</throws>
		SocketConnection Accept();
		
		/// <summary>
		/// Unbinds and closes the server socket.
		/// </summary>
		/// <throws>IOException if the server socket cannot be closed.</throws>
		void  Close();
	}
}