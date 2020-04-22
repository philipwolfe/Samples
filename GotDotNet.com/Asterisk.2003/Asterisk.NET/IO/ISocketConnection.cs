using System;
using System.Net;

namespace Asterisk.NET.IO
{
	/// <summary>
	/// The SocketConnection provides read and write operation for
	/// communication over TCP/IP sockets.<br/>
	/// It hides the details of the underlying I/O system used for socket
	/// communication.
	/// </summary>
	public interface ISocketConnection
	{
		/// <summary>
		/// Returns the connection state of the socket.
		/// </summary>
		/// <returns><code>true</code> if the socket successfuly connected to a server</returns>
		bool IsConnected
		{
			get;
		}
		/// <summary>
		/// Get/Set ReceiveTimeout in millisecond to read operation.
		/// </summary>
		int ReceiveTimeout
		{
			get;
			set;
		}

		/// <summary>
		/// Reads a line of text from the socket connection. The current thread is
		/// blocked until either the next line is received or an IOException
		/// encounters.
		/// </summary>
		/// <returns>the line of text received excluding any newline character</returns>
		/// <throws>  IOException if the connection has been closed. </throws>
		string ReadLine();

		/// <summary>
		/// Sends a given String to the socket connection.
		/// </summary>
		/// <param name="s">the String to send.</param>
		/// <throws> IOException if the String cannot be sent, maybe because the </throws>
		/// <summary>connection has already been closed.</summary>
		void  Write(string s);

		/// <summary>
		/// Flushes the socket connection, that is sends any buffered but yet unsent data.
		/// </summary>
		/// <throws>  IOException if the connection cannot be flushed. </throws>
		void  Flush();

		/// <summary>
		/// Closes the socket connection including its input and output stream and
		/// frees all associated ressources.<br/>
		/// When calling close() any Thread currently blocked by a call to readLine()
		/// will be unblocked and receive an IOException.
		/// </summary>
		/// <throws>  IOException if the socket connection cannot be closed. </throws>
		void  Close();

		/// <summary>
		/// Get/Set the local address this socket connection.
		/// </summary>
		IPAddress LocalAddress
		{
			get;
		}

		/// <summary>
		/// Get/Set the local port this socket connection.
		/// </summary>
		int LocalPort
		{
			get;
		}

		/// <summary>
		/// Get/Set the remote address this socket connection.
		/// </summary>
		IPAddress RemoteAddress
		{
			get;
		}

		/// <summary>
		/// Get/Set the remote port this socket connection.
		/// </summary>
		int RemotePort
		{
			get;
		}
	}
}
