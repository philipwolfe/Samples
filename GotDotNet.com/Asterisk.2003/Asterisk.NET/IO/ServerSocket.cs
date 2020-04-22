using System.Net;
using System.Net.Sockets;

namespace Asterisk.NET.IO
{
	/// <summary>
	/// Default implementation of the ServerSocket interface using standard socket classes (ServerSocket in this case).
	/// </summary>
	public class ServerSocket : IServerSocket
	{
		private TcpListener serverSocket;

		public ServerSocket(int port, int backlog, IPAddress bindAddress)
		{
			TcpListener temp = new TcpListener(new IPEndPoint(bindAddress, port));
			temp.Start();
			this.serverSocket = temp;
		}
		
		public virtual IO.SocketConnection Accept()
		{
			TcpClient socket = serverSocket.AcceptTcpClient();
			return new IO.SocketConnection(socket);
		}
		
		public virtual void Close()
		{
			serverSocket.Stop();
		}
	}
}
