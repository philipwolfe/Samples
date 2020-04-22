using System;
namespace Asterisk.NET.FastAGI
{
	/// <summary>
	/// The AGIWriter sends commands to Asterisk.
	/// </summary>
	public interface IAGIWriter
	{
		/// <summary>
		/// Sends the given command to the Asterisk server.
		/// </summary>
		/// <param name="command">the command to send.</param>
		/// <throws>  AGIException if the command can't be sent. </throws>
		void  SendCommand(Command.AGICommand command);
	}
}