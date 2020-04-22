using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net;
using System.Net.Sockets;

namespace SpaceWar
{
	/// <summary>
	/// Summary description for NetConnect.
	/// </summary>
	public class NetConnect
	{
		string hostName;
		int port;

		public NetConnect(string hostName, int port)
		{
			this.hostName = hostName;
			this.port = port;
		}

		TcpClient client;
		NetworkStream networkStream;
		BinaryFormatter formatter = new BinaryFormatter();

		public void DoConnect()
		{
			client = new TcpClient(hostName, port);
			networkStream = client.GetStream();

			NetConnectMessage connectMessage = new NetConnectMessage(hostName);
			
			formatter.Serialize(networkStream, connectMessage);

			NetUsePortMessage portMessage =
				(NetUsePortMessage) formatter.Deserialize(networkStream);

			Console.WriteLine("Use port: {0}", portMessage.Port);

			// drop first port, hook up to real one...
			networkStream.Close();
			client.Close();

			client = new TcpClient(hostName, portMessage.Port);
			networkStream = client.GetStream();
		}

		public unsafe void SendData(byte[] buffer, int length)
		{
			networkStream.Write(buffer, 0, length);
			//networkStream.BeginWrite(buffer, 0, length, null, null);
		}

		public void Close()
		{
			networkStream.Close();
			client.Close();
		}
	}
}
