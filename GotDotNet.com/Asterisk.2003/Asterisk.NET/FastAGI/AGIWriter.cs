using System;
using System.IO;
namespace Asterisk.NET.FastAGI
{
	/// <summary>
	/// Default implementation of the AGIWriter interface.
	/// </summary>
	public class AGIWriter : IAGIWriter
	{
		private IO.SocketConnection socket;

		public AGIWriter(IO.SocketConnection socket)
		{
			this.socket = socket;
		}
		
		public virtual void  SendCommand(Command.AGICommand command)
		{
			try
			{
				socket.Write(command.BuildCommand() + "\n");
				socket.Flush();
			}
			catch (IOException e)
			{
				throw new AGINetworkException("Unable to send command to Asterisk: " + e.Message, e);
			}
		}
	}
}