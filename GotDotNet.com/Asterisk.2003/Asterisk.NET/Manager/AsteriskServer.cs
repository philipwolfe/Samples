namespace Asterisk.NET.Manager
{
	/// <summary>
	/// Represents an Asterisk server that is connected via the Manager API.
	/// </summary>
	public class AsteriskServer
	{
		/// <summary> The hostname to use if none is provided.</summary>
		private const string DEFAULT_HOSTNAME = "localhost";
		/// <summary> The port to use if none is provided.</summary>
		private const int DEFAULT_PORT = 5038;
		/// <summary> The hostname of the Asterisk server.</summary>
		private string hostname;
		/// <summary> The port on the Asterisk server the Asterisk Manager API is listening on.</summary>
		private int port;

		#region Hostname
		/// <summary>
		/// Get/Set the hostname.
		/// </summary>
		/// <returns>the hostname</returns>
		/// <param name="hostname">the hostname to set</param>
		virtual public string Hostname
		{
			get
			{
				return hostname;
			}
			
			set
			{
				this.hostname = value;
			}

		}
		#endregion Hostname
		#region
		/// <summary>
		/// Get/Set the port.
		/// </summary>
		/// <returns> the port</returns>
		/// <param name="port">the port to set.</param>
		virtual public int Port
		{
			get
			{
				return port;
			}
			
			set
			{
				this.port = value;
			}

		}
		#endregion Port

		#region AsteriskServer()
		/// <summary>
		/// Creates a new AsteriskServer with default hostname and default port.
		/// </summary>
		public AsteriskServer()
		{
			this.hostname = DEFAULT_HOSTNAME;
			this.port = DEFAULT_PORT;
		}
		#endregion
		#region AsteriskServer(hostname, port)
		/// <summary>
		/// Creates a new Asterisk server with the given hostname and port.
		/// </summary>
		/// <param name="hostname">the hostname of the Asterisk server</param>
		/// <param name="port">the port on the Asterisk server the Asterisk Manager API is listening on</param>
		public AsteriskServer(string hostname, int port)
		{
			this.hostname = hostname;
			this.port = port;
		}
		#endregion

		#region Equals(o)
		public  override bool Equals(object o)
		{
			if (o == null || !(o is AsteriskServer))
			{
				return false;
			}
			
			AsteriskServer s = (AsteriskServer) o;
			if (this.Hostname != null)
			{
				if (!this.Hostname.Equals(s.Hostname))
					return false;
			}
			else if (s.Hostname != null)
					return false;
		
			if (this.Port != s.Port)
				return false;
		
			return true;
		}
		#endregion

		#region ToString()
		public override string ToString()
		{
			return "AsteriskServer[hostname='" + hostname + "',port=" + port + "]";
		}
		#endregion

		#region GetHashCode()
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
		#endregion
	}
}