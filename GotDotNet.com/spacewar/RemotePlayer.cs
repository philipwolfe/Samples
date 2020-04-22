using System;
using System.Net.Sockets;

namespace SpaceWar
{
	/// <summary>
	/// Summary description for RemotePlayer.
	/// </summary>
	public class RemotePlayer
	{
		Ship ship;
		UdpClient remoteClient;
		string hostName;
		string reflectToPlayer;			// reflect next buffer to this player...
		int scoreToMe;					// points other player gives to us
		int scoreToOther;				// points we give to this player...
		DateTime updateTime;			// last tick count at update
		bool active = true;				// is this player active

		public RemotePlayer(string hostName, Ship ship)
		{
			this.hostName = hostName;
			this.ship = ship;
		}

		public override string ToString()
		{
			return hostName;
		}

		public Ship Ship
		{
			get
			{
				return ship;
			}
		}

		public int ScoreToMe
		{
			get
			{
				return scoreToMe;
			}
			set
			{
				scoreToMe = value;
			}
		}

		public int ScoreToOther
		{
			get
			{
				return scoreToOther;
			}
			set
			{
				scoreToOther = value;
			}
		}

		public string ReflectToPlayer
		{
			get
			{
				return reflectToPlayer;
			}
			set
			{
				reflectToPlayer = value;
			}
		}
		
		public DateTime UpdateTime
		{
			get
			{
				return updateTime;
			}
			set
			{
				updateTime = value;
			}
		}

		public bool Active
		{
			get
			{
				return active;
			}
			set
			{
				active = value;
			}
		}

		public void DoRemoteConnection()
		{
			remoteClient = new UdpClient(hostName, 50000);
		}

		public void Send(byte[] buffer, int length)
		{
			remoteClient.Send(buffer, length);
		}
	}
}
