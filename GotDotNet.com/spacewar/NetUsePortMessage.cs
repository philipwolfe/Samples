using System;

namespace SpaceWar
{
	/// <summary>
	/// Summary description for NetUsePort.
	/// </summary>
	[Serializable]
	public class NetUsePortMessage
	{
		int port;

		public NetUsePortMessage(int port)
		{
			this.port = port;
		}

		public int Port
		{
			get
			{
				return port;
			}
		}
	}
}
