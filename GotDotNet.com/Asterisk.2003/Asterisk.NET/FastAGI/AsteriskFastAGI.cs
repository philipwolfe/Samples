using System.IO;

namespace Asterisk.NET.FastAGI
{
	public class AsteriskFastAGI : IAGIServer
	{
		private Util.ILog logger;
		/// <summary> The default bind port.</summary>
		private const int DEFAULT_BIND_PORT = 4573;
		/// <summary> The default thread pool size.</summary>
		private const int DEFAULT_POOL_SIZE = 10;
		/// <summary> The default bind address.</summary>
		private const string DEFAULT_BIND_ADDRESS = "0.0.0.0";

		#region Variables and Constants
		private IO.ServerSocket serverSocket;
		/// <summary> The port to listen on.</summary>
		private int bindPort;
		/// <summary> The address to listen on.</summary>
		private string bindAddress;

		/// <summary>The thread pool that contains the worker threads to process incoming requests.</summary>
		private Util.ThreadPool pool;
		/// <summary>The number of worker threads in the thread pool. This equals the maximum number of concurrent requests this AGIServer can serve.</summary>
		private int poolSize;
		/// <summary> True while this server is shut down. </summary>
		private bool die;
		/// <summary>
		/// The strategy to use for 	ping AGIRequests to AGIScripts that serve them.
		/// </summary>
		private MappingStrategy mappingStrategy;
		#endregion

		#region PoolSize
		/// <summary>
		/// Sets the number of worker threads in the thread pool.<br/>
		/// This equals the maximum number of concurrent requests this AGIServer can serve.<br/>
		/// The default pool size is 10.
		/// </summary>
		virtual public int PoolSize
		{
			set { this.poolSize = value; }
		}
		#endregion
		#region BindPort
		/// <summary>
		/// Sets the TCP port to listen on for new connections.<br/>
		/// The default bind port is 4573.
		/// </summary>
		virtual public int BindPort
		{
			set
			{
				this.bindPort = value;
			}
		}
		#endregion
		#region 	pingStrategy
		/// <summary>
		/// Sets the strategy to use for mapping AGIRequests to AGIScripts that serve them.<br/>
		/// The default mapping is a MappingStrategy.
		/// </summary>
		/// <seealso cref="MappingStrategy" />
		virtual public MappingStrategy MappingStrategy
		{
			set
			{
				this.mappingStrategy = value;
			}
		}
		#endregion

		#region Constructor - DefaultAGIServer()
		/// <summary>
		/// Creates a new DefaultAGIServer.
		/// </summary>
		public AsteriskFastAGI()
		{
			this.logger = Util.LogFactory.getLog(GetType());
			this.bindAddress = DEFAULT_BIND_ADDRESS;
			this.bindPort = DEFAULT_BIND_PORT;
			this.poolSize = DEFAULT_POOL_SIZE;
			this.mappingStrategy = new MappingStrategy();
		}
		#endregion
		#region Constructor - DefaultAGIServer(int port, int poolSize)
		/// <summary>
		/// Creates a new DefaultAGIServer.
		/// </summary>
		/// <param name="port">The port to listen on.</param>
		/// <param name="poolSize">The number of worker threads in the thread pool.
		/// This equals the maximum number of concurrent requests this AGIServer can serve.</param>
		public AsteriskFastAGI(int port, int poolSize)
		{
			this.logger = Util.LogFactory.getLog(GetType());
			this.bindPort = port;
			this.poolSize = poolSize;
			this.mappingStrategy = new MappingStrategy();
		}
		#endregion
		#region Constructor - DefaultAGIServer(string address, int port, int poolSize)
		/// <summary>
		/// Creates a new DefaultAGIServer.
		/// </summary>
		/// <param name="ipaddress">The address to listen on.</param>
		/// <param name="port">The port to listen on.</param>
		/// <param name="poolSize">The number of worker threads in the thread pool.
		/// This equals the maximum number of concurrent requests this AGIServer can serve.</param>
		public AsteriskFastAGI(string ipaddress, int port, int poolSize)
		{
			this.logger = Util.LogFactory.getLog(GetType());
			this.bindAddress = ipaddress;
			this.bindPort = port;
			this.poolSize = poolSize;
			this.MappingStrategy = new MappingStrategy();
		}
		#endregion

		public virtual void Startup()
		{
			Run();
		}

		public virtual void Run()
		{
			die = false;
			pool = new Util.ThreadPool("AGIServer", poolSize);
			logger.info("Thread pool started.");
			try
			{
                
				System.Net.IPAddress ipAddress = System.Net.IPAddress.Parse(bindAddress);
				serverSocket = new IO.ServerSocket(bindPort, 0, ipAddress);
				logger.info("Listening on *:" + bindPort + ".");

				AGIConnectionHandler connectionHandler;
				IO.SocketConnection socket;
				while ((socket = serverSocket.Accept()) != null)
				{
					logger.info("Received connection.");
					connectionHandler = new AGIConnectionHandler(socket, mappingStrategy);
					pool.AddJob(connectionHandler);
				}
			}
			catch (IOException e)
			{
				if (!die)
					logger.error("IOException while waiting for connections (1).", e);
			}
			finally
			{
				if (serverSocket != null)
				{
					try
					{
						serverSocket.Close();
					}
					catch (IOException e)
					{
						logger.error("IOException while waiting for connections (2).", e);
						// swallow
					}
				}
				serverSocket = null;
				pool.Shutdown();
				logger.info("AGIServer shut down.");
			}
		}
		
		public virtual void  Die()
		{
			die = true;
			if (serverSocket != null)
				serverSocket.Close();
		}
		
		public virtual void  Shutdown()
		{
			Die();
		}
	}
}
