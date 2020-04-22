using System;

namespace SpaceWar
{
	/// <summary>
	/// Summary description for NetConnect.
	/// </summary>
	/// 
	[Serializable]
	public class NetConnectMessage
	{
		string hostName;

		public NetConnectMessage(string hostName)
		{
			this.hostName = hostName;
		}

		public string HostName
		{
			get
			{
				return hostName;
			}
		}
	}
}
