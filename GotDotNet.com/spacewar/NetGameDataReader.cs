using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net;
using System.Net.Sockets;

namespace SpaceWar
{
	/// <summary>
	/// Summary description for NetGameDataReader.
	/// </summary>
	public class NetGameDataReader
	{
		int gameDataPort;
		NetAcceptor.DataReadyHandler handler;

		public NetGameDataReader(int gameDataPort, NetAcceptor.DataReadyHandler handler)
		{
			this.gameDataPort = gameDataPort;
			this.handler = handler;
		}

		public void Process()
		{
			Console.WriteLine("Waiting on port: {0}", gameDataPort);
			BinaryFormatter formatter = new BinaryFormatter();
			TcpListener listener = new TcpListener(gameDataPort);
			listener.Start();

			using (TcpClient client = listener.AcceptTcpClient())
			using (NetworkStream networkStream = client.GetStream())
			{
				Console.WriteLine("Accepted connection: {0}", gameDataPort);

				GameDataEventArgs args;
				byte[] buffer = new byte[Constants.NetworkBufferSize];
				while (true)
				{
					try
					{
						networkStream.Read(buffer, 0, Constants.NetworkBufferSize);
						args = new GameDataEventArgs(buffer);
						handler(this, args);
					}
					catch (SerializationException)
					{
						handler(this, null);
						break;
					}
				}

			}
		}
	}
}
