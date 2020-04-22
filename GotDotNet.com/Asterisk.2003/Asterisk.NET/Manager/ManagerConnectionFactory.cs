namespace Asterisk.NET.Manager
{
	/// <summary>
	/// This factory is used to obtain new ManagerConnections.
	/// </summary>
	/// <seealso cref="Manager.IManagerConnection" />
	public class ManagerConnectionFactory
	{
		private const int DEFAULT_PORT = 5038;
		private const string DEFAULT_HOSTNAME = "localhost";
		private const string DEFAULT_USERNAME = "admin";
		private const string DEFAULT_PASSWORD = "admin";

		private int port;
		private string hostname;
		private string username;
		private string password;

		#region Hostname
		/// <summary>
		/// Sets the default hostname.<br/>
		/// Default is "localhost".
		/// </summary>
		virtual public string Hostname
		{
			get { return this.hostname; }
			set { this.hostname = value; }
		}
		#endregion
		#region Port
		/// <summary>
		/// Sets the default port.<br/>
		/// Default is 5038.
		/// </summary>
		virtual public int Port
		{
			get { return this.port; }
			set { this.port = value; }
		}
		#endregion
		#region Username
		/// <summary>
		/// Sets the default username.<br/>
		/// Default is "admin".
		/// </summary>
		virtual public string Username
		{
			get { return this.username; }
			set { this.username = value; }
		}
		#endregion
		#region Password
		/// <summary>
		/// Sets the default password.<br/>
		/// Default is "admin".
		/// </summary>
		virtual public string Password
		{
			get { return this.password; }
			set { this.password = value; }
		}
		#endregion

		#region Constructor
		/// <summary>
		/// Creates a new ManagerConnectionFactory.
		/// </summary>
		public ManagerConnectionFactory()
		{
			this.hostname = DEFAULT_HOSTNAME;
			this.port = DEFAULT_PORT;
			this.username = DEFAULT_USERNAME;
			this.password = DEFAULT_PASSWORD;
		}
		#endregion

		#region GetManagerConnection()
		/// <summary>
		/// Returns a new ManagerConnection with the default values for hostname,
		/// port, username and password. It uses either the built-in defaults
		/// ("localhost", 5038, "admin", "admin") or the custom default values you
		/// set via setHostname(String), setPort(int), setUsername(String) and setPassword(String).
		/// </summary>
		/// <returns>the created connection to the Asterisk call manager</returns>
		/// <throws>IOException if the connection cannot be established.</throws>
		public virtual IManagerConnection GetManagerConnection()
		{
			return new ManagerConnection(this.hostname, this.port, this.username, this.password);
		}
		#endregion
		#region GetManagerConnection(username, password)
		/// <summary>
		/// Returns a new ManagerConnection to an Asterisk server running on default
		/// host ("localhost" if you didn't change that via setHostname(String)) with the call manager interface listening
		/// on the default port (5038 if you didn't change that via setPort(int)).
		/// </summary>
		/// <param name="username">the username as specified in Asterisk's <code>manager.conf</code></param>
		/// <param name="password">the password as specified in Asterisk's <code>manager.conf</code></param>
		/// <returns>the created connection to the Asterisk call manager</returns>
		/// <throws>IOException if the connection cannot be established.</throws>
		public virtual IManagerConnection GetManagerConnection(string username, string password)
		{
			return new ManagerConnection(this.hostname, this.port, username, password);
		}
		#endregion
		#region GetManagerConnection(hostname, username, password)
		/// <summary>
		/// Returns a new ManagerConnection to an Asterisk server running on given
		/// host with the call manager interface listening on the default port (5038 if you didn't change that via setPort(int)).
		/// </summary>
		/// <param name="hostname">the name of the host the Asterisk server is running on</param>
		/// <param name="username">the username as specified in Asterisk's <code>manager.conf</code></param>
		/// <param name="password">the password as specified in Asterisk's <code>manager.conf</code></param>
		/// <returns>the created connection to the Asterisk call manager</returns>
		/// <throws>IOException if the connection cannot be established.</throws>
		public virtual IManagerConnection GetManagerConnection(string hostname, string username, string password)
		{
			return new ManagerConnection(hostname, this.port, username, password);
		}
		#endregion
		#region GetManagerConnection(hostname, port, username, password)
		/// <summary>
		/// Returns a new ManagerConnection to an Asterisk server running on given
		/// host with the call manager interface listening on the given port.
		/// </summary>
		/// <param name="hostname">the name of the host the Asterisk server is running on</param>
		/// <param name="port">the port the call manager interface is listening on</param>
		/// <param name="username">the username as specified in Asterisk's
		/// <code>manager.conf</code>
		/// </param>
		/// <param name="password">the password as specified in Asterisk's
		/// <code>manager.conf</code>
		/// </param>
		/// <returns>the created connection to the Asterisk call manager</returns>
		/// <throws>IOException if the connection cannot be established.</throws>
		public virtual IManagerConnection GetManagerConnection(string hostname, int port, string username, string password)
		{
			return new ManagerConnection(hostname, port, username, password);
		}
		#endregion
	}
}