using System;
using System.Text;

namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// Abstract base class for all Events that can be received from the Asterisk server.<br/>
	/// Events contain data pertaining to an event generated from within the Asterisk
	/// core or an extension module.<br/>
	/// There is one conrete subclass of ManagerEvent per each supported Asterisk
	/// Event.
	/// </summary>
	public abstract class ManagerEvent : EventArgs
	{
		/// <summary> The point in time this event has been received from the Asterisk server.</summary>
		private DateTime dateReceived;
		/// <summary> AMI authorization class.</summary>
		private string privilege;
		private object src;

		#region DateReceived
		/// <summary>
		/// Get/Set the point in time this event was received from the Asterisk server.<br/>
		/// Pseudo events that are not directly received from the asterisk server
		/// (for example ConnectEvent and DisconnectEvent) may return <code>null</code>.
		/// </summary>
		virtual public DateTime DateReceived
		{
			get { return dateReceived; }
			set { this.dateReceived = value; }
		}
		#endregion
		#region Privilege
		/// <summary>
		/// Get/Set the AMI authorization class of this event.<br/>
		/// This is one or more of system, call, log, verbose, command, agent or user.
		/// Multiple privileges are separated by comma.<br/>
		/// Note: This property is not available from Asterisk 1.0 servers.
		/// </summary>
		virtual public string Privilege
		{
			get { return privilege; }
			set { this.privilege = value; }
		}
		#endregion
		#region Source
		virtual public object Source
		{
			get { return this.src; }
		}
		#endregion

		#region Constructor - ManagerEvent()
		public ManagerEvent()
			: base()
		{
		}
		#endregion
		#region Constructor - ManagerEvent(object source)
		public ManagerEvent(object source)
			: base()
		{
			this.src = source;
		}
		#endregion

		#region ToString()
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder(GetType().FullName);
			sb.Append(": dateReceived=" + DateReceived.ToString("r"));
			if (Privilege != null)
				sb.Append("; privilege=" + Privilege);
			sb.Append("; systemHashcode=" + this.GetHashCode());
			return sb.ToString();
		}
		#endregion
	}
}
