using System;

namespace SpaceWar
{
	/// <summary>
	/// Summary description for NetGameDataMessage.
	/// </summary>
	public class NetGameDataMessage
	{
		string hostName;

		public NetGameDataMessage()
		{
		}

		public String HostName
		{
			get
			{
				return hostName;
			}
			set
			{
				hostName = value;
			}
		}
	}
}
