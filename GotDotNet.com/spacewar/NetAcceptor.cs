using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace SpaceWar
{
	/// <summary>
	/// Summary description for NetAcceptor.
	/// </summary>
	public class NetAcceptor
	{
		int port;
		int nextPort;
		DataReadyHandler handler;
		UdpClient client;

		public delegate void DataReadyHandler(object sender, GameDataEventArgs e);

		public NetAcceptor(int port, DataReadyHandler handler)
		{
			this.port = port;
			nextPort = port;
			this.handler = handler;
		}

		public void Close()
		{
			client.Close();
		}

		public void AcceptLoop()
		{
			client = new UdpClient(port);

			IPEndPoint epHost = null;

			byte[] buffer;
			GameDataEventArgs args;
			while (true)
			{
				try
				{
					buffer = client.Receive(ref epHost);
				}
				catch (ObjectDisposedException)
				{
					return;
				}
				catch (NullReferenceException)
				{
					return;
				}
				catch (Exception e)
				{
					Console.WriteLine("Caught: {0}", e);
					return;
				}

				try
				{
					args = new GameDataEventArgs(buffer);
					handler(this, args);
				}
				catch (Exception e)
				{
					Console.WriteLine("Caught: {0}", e);
				}
			}
		}
	}
}
