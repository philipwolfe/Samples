using System;
using System.Text;
using System.Collections;

namespace Asterisk.NET.Manager
{
	public class Channel
	{
		#region Variables
		private AsteriskServer asteriskServer;

		/// <summary>Unique id of this channel.</summary>
		private string id;
		/// <summary>Name of this channel.</summary>
		private string name;
		/// <summary> Caller ID of this channel.</summary>
		private string callerId;
		/// <summary> Caller ID Name of this channel.</summary>
		private string callerIdName;
		/// <summary> State of this channel.</summary>
		private ChannelStateEnum state;
		/// <summary> Account code used to bill this channel.</summary>
		private string account;
		private IList extensions;
		/// <summary>Date this channel has been created.</summary>
		private DateTime dateOfCreation;
		/// <summary>If this channel is bridged to another channel, the linkedChannel contains the channel this channel is bridged with.</summary>
		private Channel linkedChannel;
		/// <summary>Indicates if this channel was linked to another channel at least once.</summary>
		private bool wasLinked;
		#endregion

		#region Channel(name, id)
		/// <summary>
		/// Creates a new Channel.
		/// </summary>
		/// <param name="name">name of this channel, for example "SIP/1310-20da".</param>
		/// <param name="id">unique id of this channel, for example "1099015093.165".</param>
		public Channel(string name, string id)
			: this(name, id, null)
		{
		}
		#endregion
		#region Channel(name, id, server)
		/// <summary>
		/// Creates a new Channel on the given server.
		/// </summary>
		/// <param name="name">name of this channel, for example "SIP/1310-20da".</param>
		/// <param name="id">unique id of this channel, for example "1099015093.165".</param>
		/// <param name="server">the Asterisk server this channel exists on.</param>
		public Channel(string name, string id, AsteriskServer server)
		{
			this.name = name;
			this.id = id;
			this.asteriskServer = server;
			this.extensions = new ArrayList();
		}
		#endregion

		#region AsteriskServer
		/// <summary>
		/// Get/Set the Asterisk server.
		/// </summary>
		virtual public AsteriskServer AsteriskServer
		{
			get { return asteriskServer; }
			set { this.asteriskServer = value; }
		}
		#endregion
		#region Id
		/// <summary>
		/// Get the unique id of this channel, for example "1099015093.165".
		/// </summary>
		virtual public string Id
		{
			get { return id; }
		}
		#endregion
		#region Name
		/// <summary>
		/// Get/Set the name of this channel, for example "SIP/1310-20da".
		/// </summary>
		virtual public string Name
		{
			get { return name; }
			set { this.name = value; }
		}
		#endregion
		#region CallerId
		/// <summary>
		/// Get/Set the caller id of this channel.
		/// </summary>
		virtual public string CallerId
		{
			get { return callerId; }
			set { this.callerId = value; }
		}
		#endregion
		#region CallerIdName
		/// <summary>
		/// Get/Set the caller id name of this channel.
		/// </summary>
		virtual public string CallerIdName
		{
			get { return callerIdName; }
			set { this.callerIdName = value; }
		}
		#endregion
		#region State
		/// <summary>
		/// Get/Set the state of this channel.
		/// </summary>
		virtual public ChannelStateEnum State
		{
			get { return state; }
			set { this.state = value; }
		}
		#endregion
		#region Account
		/// <summary>
		/// Get/Set the account code used to bill this channel.
		/// </summary>
		virtual public string Account
		{
			get { return account; }
			set { this.account = value; }
		}
		#endregion
		#region CurrentExtension
		/// <summary>
		/// Get the last visited dialplan entry.
		/// </summary>
		/// <returns> the last visited dialplan entry.</returns>
		virtual public Extension CurrentExtension
		{
			get
			{
				Extension extension;
				lock (extensions.SyncRoot)
				{
					if ((extensions.Count == 0))
						extension = null;
					else
						extension = (Extension) extensions[extensions.Count - 1];
				}
				return extension;
			}
		}
		#endregion
		#region FirstExtension
		/// <summary>
		/// Get the first visited dialplan entry.
		/// </summary>
		virtual public Extension FirstExtension
		{
			get
			{
				Extension extension;
				lock (extensions.SyncRoot)
				{
					if ((extensions.Count == 0))
						extension = null;
					else
						extension = (Extension) extensions[0];
				}
				return extension;
			}
		}
		#endregion
		#region Context
		/// <summary>
		/// Get the context of the current extension. This is a shortcut for <code>CurrentExtension.Context</code>.
		/// </summary>
		virtual public string Context
		{
			get
			{
				Extension currentExtension = this.CurrentExtension;
				return (currentExtension == null ? null : currentExtension.Context);
			}
		}
		#endregion
		#region Extension
		/// <summary>
		/// Get the extension of the current extension. This is a shortcut for <code>CurrentExtension.Extension</code>.
		/// </summary>
		virtual public string Extension
		{
			get
			{
				Extension currentExtension = this.CurrentExtension;
				return (currentExtension == null ? null : currentExtension.GetExtension());
			}
		}
		#endregion
		#region Priority
		/// <summary>
		/// Get the priority of the current extension. This is a shortcut for <code>urrentExtension.Priority</code>.
		/// </summary>
		virtual public int Priority
		{
			get
			{
				Extension currentExtension = CurrentExtension;
				return (currentExtension == null ? 0 : currentExtension.Priority);
			}
		}
		#endregion
		#region Extensions
		/// <summary>
		/// Returns a list of all visited dialplan entries.
		/// </summary>
		/// <returns>a list of all visited dialplan entries.</returns>
		virtual public IList Extensions
		{
			get
			{
				IList extensionsCopy;
				lock (extensions.SyncRoot)
				{
					extensionsCopy = new ArrayList(extensions);
				}
				return extensionsCopy;
			}
		}
		#endregion
		#region DateOfCreation
		/// <summary>
		/// Get/Set the date this channel has been created.
		/// </summary>
		virtual public DateTime DateOfCreation
		{
			get { return dateOfCreation; }
			set { this.dateOfCreation = value; }
		}
		#endregion
		#region LinkedChannel
		/// <summary>
		/// Get/Set the channel this channel is bridged with, if any.
		/// </summary>
		/// <returns>the channel this channel is bridged with, or <code>null</code>
		/// if this channel is currently not bridged to another channel.
		/// </returns>
		virtual public Channel LinkedChannel
		{
			get { return linkedChannel; }
			set
			{
				this.linkedChannel = value;
				if (value != null)
					this.wasLinked = true;
			}
		}
		#endregion
		#region WasLinked
		/// <summary>
		/// Indicates if this channel was linked to another channel at least once.
		/// </summary>
		/// <returns><code>true</code> if this channel was linked to another channel at least once, <code>false</code> otherwise.</returns>
		virtual public bool WasLinked
		{
			get { return wasLinked; }
		}
		#endregion

		#region AddExtension(extension)
		/// <summary>
		/// Adds a visted dialplan entry to the history.
		/// </summary>
		/// <param name="extension">the visted dialplan entry to add.</param>
		public virtual void  AddExtension(Extension extension)
		{
			lock (extensions.SyncRoot)
			{
				if(!extensions.Contains(extension))
					extensions.Add(extension);
			}
		}
		#endregion
		#region ToString()
		public override string ToString()
		{
			Channel linkedChannel;
			int systemHashcode;
			StringBuilder sb = new StringBuilder(GetType().FullName);
			lock (this)
			{
				sb.Append(": id='" + Id);
				sb.Append("'; name='" + Name);
				sb.Append("'; callerId='" + CallerId);
				sb.Append("'; state='" + State);
				sb.Append("'; account='" + Account);
				sb.Append("'; dateOfCreation=" + DateOfCreation.ToString("r"));
				linkedChannel = this.linkedChannel;
				systemHashcode = this.GetHashCode();
			}
			if (linkedChannel == null)
				sb.Append("; linkedChannel=null");
			else
			{
				sb.Append("; linkedChannel=[");
				lock (linkedChannel)
				{
					sb.Append(linkedChannel.GetType().FullName);
					sb.Append(": id='" + linkedChannel.Id);
					sb.Append("'; name='" + linkedChannel.Name);
					sb.Append("'; systemHashcode=" + linkedChannel.GetHashCode());
				}
				sb.Append("]");
			}
			sb.Append("; systemHashcode=" + systemHashcode);
			return sb.ToString();
		}
		#endregion
	}
}