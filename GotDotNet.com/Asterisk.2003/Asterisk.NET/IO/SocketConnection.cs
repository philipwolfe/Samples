using System.IO;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace Asterisk.NET.IO
{
	public class SocketConnection : ISocketConnection
	{
		private TcpClient socket;
		private StreamReader reader;
		private StreamWriter writer;

		#region Constructor - SocketConnection(string host, int port, int receiveTimeout)
		public SocketConnection(string host, int port, int receiveTimeout)
			: this(host, port)
		{
			this.socket.ReceiveTimeout = receiveTimeout;
		}
		#endregion
		#region Constructor - SocketConnection(string host, int port)
		public SocketConnection(string host, int port)
		{
			this.socket = new TcpClient(host, port);
			this.reader = new StreamReader(
				new StreamReader(this.socket.GetStream(), Encoding.Default).BaseStream,
				new StreamReader(this.socket.GetStream(), Encoding.Default).CurrentEncoding
				);
			this.writer = new StreamWriter(
				new StreamWriter(this.socket.GetStream(), Encoding.Default).BaseStream,
				new StreamWriter(this.socket.GetStream(), Encoding.Default).Encoding
				);
		}
		#endregion
		#region Constructor - SocketConnection(socket)
		internal SocketConnection(TcpClient socket)
		{
			this.socket = socket;
			this.reader = new StreamReader(
				new StreamReader(this.socket.GetStream(), Encoding.Default).BaseStream,
				new StreamReader(this.socket.GetStream(), Encoding.Default).CurrentEncoding
				);
			this.writer = new StreamWriter(
				new StreamWriter(this.socket.GetStream(), Encoding.Default).BaseStream,
				new StreamWriter(this.socket.GetStream(), Encoding.Default).Encoding
				);
		}
		#endregion

		#region IsConnected
		/// <summary>
		/// Returns the connection state of the socket.
		/// </summary>
		virtual public bool IsConnected
		{
			get { return true; }
		}
		#endregion

		#region ReceiveTimeout
		virtual public int ReceiveTimeout
		{
			get { return this.socket.ReceiveTimeout; }
			set { this.socket.ReceiveTimeout = value; }
		}
		#endregion

		#region LocalAddress
		public IPAddress LocalAddress
		{
			get
			{
				return null;
				//return ((IPEndPoint)(socket.Client.LocalEndPoint)).Address;
			}
		}
		#endregion
		#region LocalPort
		public int LocalPort
		{
			get
			{
				return 0;
				//return ((IPEndPoint)(socket.Client.LocalEndPoint)).Port;
			}
		}
		#endregion
		#region RemoteAddress
		public IPAddress RemoteAddress
		{
			get
			{
				return null;
				//return ((IPEndPoint)(socket.Client.RemoteEndPoint)).Address;
			}
		}
		#endregion
		#region RemotePort
		public int RemotePort
		{
			get
			{
				return 0;
				//return ((IPEndPoint)(socket.Client.LocalEndPoint)).Port;
			}
		}
		#endregion

		#region ReadLine()
		/// <summary>
		/// Reads a line of text from the socket connection. The current thread is
		/// blocked until either the next line is received or an IOException
		/// encounters.
		/// </summary>
		/// <returns>the line of text received excluding any newline character</returns>
		/// <throws>  IOException if the connection has been closed. </throws>
		public virtual string ReadLine()
		{
			return this.reader.ReadLine();
		}
		#endregion
		#region Write(string s)
		/// <summary>
		/// Sends a given String to the socket connection.
		/// </summary>
		/// <param name="s">the String to send.</param>
		/// <throws> IOException if the String cannot be sent, maybe because the </throws>
		/// <summary>connection has already been closed.</summary>
		public virtual void Write(string s)
		{
			writer.Write(s);
		}
		#endregion
		#region Flush()
		/// <summary>
		/// Flushes the socket connection, that is sends any buffered but yet unsent data.
		/// </summary>
		/// <throws>  IOException if the connection cannot be flushed. </throws>
		public virtual void Flush()
		{
			writer.Flush();
		}
		#endregion
		#region Close
		/// <summary>
		/// Closes the socket connection including its input and output stream and
		/// frees all associated ressources.<br/>
		/// When calling close() any Thread currently blocked by a call to readLine()
		/// will be unblocked and receive an IOException.
		/// </summary>
		/// <throws>  IOException if the socket connection cannot be closed. </throws>
		public virtual void Close()
		{
			this.socket.Close();
		}
		#endregion
	}
}
