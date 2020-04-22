using System;
using Asterisk.NET.Manager.Action;

namespace Asterisk.NET.Manager
{
	public class ManagerWriter
	{
		private Util.ILog logger;
		/// <summary>The action builder utility to convert ManagerAction to a String suitable to be sent to the asterisk server.</summary>
		private ActionBuilder actionBuilder;
		private IO.SocketConnection socket;

		#region Constructor - ManagerWriter()
		/// <summary>
		/// Creates a new ManagerWriter.
		/// </summary>
		public ManagerWriter()
		{
			logger = Util.LogFactory.getLog(GetType());
			this.actionBuilder = new ActionBuilder();
		}
		#endregion

		#region TargetVersion
		/// <summary>
		/// Get/Set the version of the Asterisk server to built the action for.
		/// </summary>
		public AsteriskVersion TargetVersion
		{
			get { return this.actionBuilder.TargetVersion; }
			set { this.actionBuilder.TargetVersion = value; }
		}
		#endregion
		#region Socket
		/// <summary>
		/// Sets the socket to use for writing to the asterisk server.
		/// </summary>
		virtual public IO.SocketConnection Socket
		{
			get { return this.socket; }
			set
			{
				lock (this)
				{
					this.socket = value;
				}
			}
		}
		#endregion

		#region SendAction(Action.IManagerAction action)
		public virtual void SendAction(IManagerAction action)
		{
			lock (this)
			{
				string actionString;
				if (socket == null)
					throw new SystemException("Unable to send action: socket is null");

				actionString = actionBuilder.BuildAction(action);
				logger.debug("Sent " + action.Action + " action with actionId '" + action.ActionId + "':\n" + actionString);

				socket.Write(actionString);
				socket.Flush();
			}
		}
		#endregion
	}
}