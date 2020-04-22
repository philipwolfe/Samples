using System;
using System.Threading;

namespace Asterisk.NET.Manager
{
	/// <summary>
	/// A Thread that pings the Asterisk server at a given interval.<br/>
	/// You can use this to prevent the connection being shut down when there is no
	/// traffic.
	/// </summary>
	public class PingThread : Utils.ThreadClass
	{
		private const long DEFAULT_INTERVAL = 2000;
		private Util.ILog logger;
		private long interval;
		private bool die;
		private IManagerConnection connection;

		#region PingThread(connection)
		/// <summary>
		/// Creates a new PingThread that uses the given ManagerConnection.
		/// </summary>
		/// <param name="connection">ManagerConnection that is pinged</param>
		public PingThread(IManagerConnection connection)
		{
			this.logger = Util.LogFactory.getLog(GetType());
			this.connection = connection;
			this.interval = DEFAULT_INTERVAL;
			this.die = false;
			Name = "Ping";
		}
		#endregion

		#region Interval
		/// <summary>
		/// Adjusts how often a PingAction is sent.<br/>
		/// Default is 2000ms.
		/// </summary>
		virtual public long Interval
		{
			set { this.interval = value; }
		}
		#endregion

		#region Die()
		/// <summary>
		/// Terminates this PingThread.
		/// </summary>
		public virtual void  Die()
		{
			this.die = true;
			Interrupt();
		}
		#endregion
		#region Run()
		override public void  Run()
		{
			Response.ManagerResponse response;
			while (!die)
			{
				try
				{
					Thread.Sleep(new TimeSpan((long) 10000 * interval));
				}
				catch (ThreadInterruptedException)
				{}
				
				if (die)
					break;
				
				try
				{
					response = connection.SendAction(new Action.PingAction());
					logger.debug("Ping response: " + response);
				}
				catch (Exception e)
				{
					logger.warn("Exception on sending Ping", e);
				}
			}
		}
		#endregion
	}
}