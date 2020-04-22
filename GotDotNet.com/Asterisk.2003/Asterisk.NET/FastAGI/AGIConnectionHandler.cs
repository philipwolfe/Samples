using System;
using System.IO;
using System.Threading;

namespace Asterisk.NET.FastAGI
{
	/// <summary>
	/// An AGIConnectionHandler is created and run by the AGIServer whenever a new
	/// socket connection from an Asterisk Server is received.<br/>
	/// It reads the request using an AGIReader and runs the AGIScript configured to
	/// handle this type of request. Finally it closes the socket connection.
	/// </summary>
	public class AGIConnectionHandler : IThreadRunnable
	{
		private Util.ILog logger;
		private static readonly LocalDataStoreSlot channel = Thread.AllocateDataSlot();
		private IO.SocketConnection socket;
		private MappingStrategy mappingStrategy;

		#region Channel
		/// <summary>
		/// Returns the AGIChannel associated with the current thread.
		/// </summary>
		/// <returns>the AGIChannel associated with the current thread or <code>null</code> if none is associated.</returns>
		internal static AGIChannel Channel
		{
			get
			{
				return (AGIChannel) Thread.GetData(AGIConnectionHandler.channel);
			}
		}
		#endregion

		#region AGIConnectionHandler(socket, mappingStrategy)
		/// <summary>
		/// Creates a new AGIConnectionHandler to handle the given socket connection.
		/// </summary>
		/// <param name="socket">the socket connection to handle.</param>
		/// <param name="mappingStrategy">the strategy to use to determine which script to run.</param>
		public AGIConnectionHandler(IO.SocketConnection socket, MappingStrategy mappingStrategy)
		{
			logger = Util.LogFactory.getLog(this.GetType());
			this.socket = socket;
			this.mappingStrategy = mappingStrategy;
		}
		#endregion

		public virtual void  Run()
		{
			try
			{
				AGIReader reader = new AGIReader(socket);
				AGIWriter writer = new AGIWriter(socket);
				AGIRequest request = reader.ReadRequest();
				AGIChannel channel = new AGIChannel(writer, reader);
				IAGIScript script = mappingStrategy.DetermineScript(request);
				Utils.ThreadClass thread = Utils.ThreadClass.Current();
				string threadName = thread.Name;
				Thread.SetData(AGIConnectionHandler.channel, channel);

				if (script != null)
				{
					logger.info("Begin AGIScript " + script.GetType().FullName + " on " + threadName);
					script.Service(request, channel);
					logger.info("End AGIScript " + script.GetType().FullName + " on " + threadName);
				}
				else
				{
					string error;

					error = "No script configured for " + request.RequestURL;
					channel.SendCommand(new Command.VerboseCommand(error, 1));
					logger.error(error);
				}
			}
			catch (AGIException e)
			{
				logger.error("AGIException while handling request", e);
			}
			catch (Exception e)
			{
				logger.error("Unexpected Exception while handling request", e);
			}

			Thread.SetData(AGIConnectionHandler.channel, null);
			try
			{
				socket.Close();
			}
			catch(IOException e)
			{
				// swallow
				logger.error("Error on close socket", e);
			}
		}
	}
}