using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;

namespace Asterisk.NET.Manager
{
	public delegate void AgentCallbackLoginEventHandler(object sender, Event.AgentCallbackLoginEvent e);
	public delegate void AgentCallbackLogoffEventHandler(object sender, Event.AgentCallbackLogoffEvent e);
	public delegate void AgentCalledEventHandler(object sender, Event.AgentCalledEvent e);
	public delegate void AgentCompleteEventHandler(object sender, Event.AgentCompleteEvent e);
	public delegate void AgentConnectEventHandler(object sender, Event.AgentConnectEvent e);
	public delegate void AgentDumpEventHandler(object sender, Event.AgentDumpEvent e);
	public delegate void AgentLoginEventHandler(object sender, Event.AgentLoginEvent e);
	public delegate void AgentLogoffEventHandler(object sender, Event.AgentLogoffEvent e);
	public delegate void AgentsCompleteEventHandler(object sender, Event.AgentsCompleteEvent e);
	public delegate void AgentsEventHandler(object sender, Event.AgentsEvent e);
	public delegate void AlarmClearEventHandler(object sender, Event.AlarmClearEvent e);
	public delegate void AlarmEventHandler(object sender, Event.AlarmEvent e);

	public delegate void CdrEventHandler(object sender, Event.CdrEvent e);
	public delegate void ConnectEventHandler(object sender, Event.ConnectEvent e);

	public delegate void DBGetResponseEventHandler(object sender, Event.DBGetResponseEvent e);
	public delegate void DialEventHandler(object sender, Event.DialEvent e);
	public delegate void DisconnectEventHandler(object sender, Event.DisconnectEvent e);
	public delegate void DNDStateEventHandler(object sender, Event.DNDStateEvent e);

	public delegate void ExtensionStatusEventHandler(object sender, Event.ExtensionStatusEvent e);

    public delegate void HangupEventHandler(object sender, Event.HangupEvent e);
	public delegate void HoldedCallEventHandler(object sender, Event.HoldedCallEvent e);
	public delegate void HoldEventHandler(object sender, Event.HoldEvent e);

	public delegate void JoinEventHandler(object sender, Event.JoinEvent e);

	public delegate void LeaveEventHandler(object sender, Event.LeaveEvent e);
    public delegate void LinkEventHandler(object sender, Event.LinkEvent e);
	public delegate void LogChannelEventHandler(object sender, Event.LogChannelEvent e);

	public delegate void MeetMeJoinEventHandler(object sender, Event.MeetMeJoinEvent e);
	public delegate void MeetMeLeaveEventHandler(object sender, Event.MeetMeLeaveEvent e);
	// public delegate void MeetMeStopTalkingEventHandler(object sender, Event.MeetMeStopTalkingEvent e);
	// public delegate void MeetMeTalkingEventHandler(object sender, Event.MeetMeTalkingEvent e);
	public delegate void MessageWaitingEventHandler(object sender, Event.MessageWaitingEvent e);

    public delegate void NewCallerIdEventHandler(object sender, Event.NewCallerIdEvent e);
	public delegate void NewChannelEventHandler(object sender, Event.NewChannelEvent e);
    public delegate void NewExtenEventHandler(object sender, Event.NewExtenEvent e);
    public delegate void NewStateEventHandler(object sender, Event.NewStateEvent e);

	// public delegate void OriginateEventHandler(object sender, Event.OriginateEvent e);
	public delegate void OriginateFailureEventHandler(object sender, Event.OriginateFailureEvent e);
	public delegate void OriginateSuccessEventHandler(object sender, Event.OriginateSuccessEvent e);

	public delegate void ParkedCallEventHandler(object sender, Event.ParkedCallEvent e);
	public delegate void ParkedCallGiveUpEventHandler(object sender, Event.ParkedCallGiveUpEvent e);
	public delegate void ParkedCallsCompleteEventHandler(object sender, Event.ParkedCallsCompleteEvent e);
	public delegate void ParkedCallTimeOutEventHandler(object sender, Event.ParkedCallTimeOutEvent e);

	public delegate void PeerEntryEventHandler(object sender, Event.PeerEntryEvent e);
	public delegate void PeerlistCompleteEventHandler(object sender, Event.PeerlistCompleteEvent e);
	public delegate void PeerStatusEventHandler(object sender, Event.PeerStatusEvent e);

    public delegate void QueueEntryEventHandler(object sender, Event.QueueEntryEvent e);
	public delegate void QueueMemberAddedEventHandler(object sender, Event.QueueMemberAddedEvent e);
    public delegate void QueueMemberEventHandler(object sender, Event.QueueMemberEvent e);
	public delegate void QueueMemberPausedEventHandler(object sender, Event.QueueMemberPausedEvent e);
	public delegate void QueueMemberRemovedEventHandler(object sender, Event.QueueMemberRemovedEvent e);
	public delegate void QueueMemberStatusEventHandler(object sender, Event.QueueMemberStatusEvent e);
	public delegate void QueueParamsEventHandler(object sender, Event.QueueParamsEvent e);
	public delegate void QueueStatusCompleteEventHandler(object sender, Event.QueueStatusCompleteEvent e);

	public delegate void RegistryEventHandler(object sender, Event.RegistryEvent e);
	public delegate void ReloadEventHandler(object sender, Event.ReloadEvent e);
    public delegate void RenameEventHandler(object sender, Event.RenameEvent e);

	public delegate void ShutdownEventHandler(object sender, Event.ShutdownEvent e);
	public delegate void StatusCompleteEventHandler(object sender, Event.StatusCompleteEvent e);
	public delegate void StatusEventHandler(object sender, Event.StatusEvent e);

	public delegate void UnholdEventHandler(object sender, Event.UnholdEvent e);
    public delegate void UnlinkEventHandler(object sender, Event.UnlinkEvent e);
	public delegate void UnparkedCallEventHandler(object sender, Event.UnparkedCallEvent e);

	public delegate void ZapShowChannelsCompleteEventHandler(object sender, Event.ZapShowChannelsCompleteEvent e);
	public delegate void ZapShowChannelsEventHandler(object sender, Event.ZapShowChannelsEvent e);

	/// <summary>
	/// Default implementation of the AsteriskManager interface.
	/// </summary>
	/// <seealso cref="Manager.AsteriskManager"/>
    public class AsteriskManager : IAsteriskManager
	{
		#region Variables
		private static Regex SHOW_VERSION_FILES_PATTERN = new Regex("^([\\S]+)\\s+Revision: ([0-9\\.]+)");
		private Util.ILog logger;

		/// <summary> The underlying manager connection used to talk to Asterisk.</summary>
		private ManagerConnection connection;
		/// <summary> A map of all active channel by their unique id.</summary>
		private IDictionary channels;
		/// <summary> A map of ACD queues by there name.</summary>
		private IDictionary queues;
		/// <summary> The version of the Asterisk server we are connected to.<br/>
		/// Contains <code>null</code> until lazily initialized.
		/// </summary>
		private string version;
		/// <summary> Holds the version of Asterisk's source files.<br/>
		/// That corresponds to the output of the CLI command <code>show version files</code>.<br/>
		/// Contains <code>null</code> until lazily initialized.
		/// </summary>
		private IDictionary versions;
		/// <summary>
		/// Flag to skip initializing queues as that results in a timeout on Asterisk 1.0.x.
		/// </summary>
		private bool skipQueues;
		#endregion

		#region Events
		/// <summary>
		/// An AgentCallbackLogin is triggered when an agent is successfully logged in.<br/>
		/// It is implemented in <code>channels/chan_agent.c</code>
		/// </summary>
		public event AgentCallbackLoginEventHandler AgentCallbackLogin;
		/// <summary>
		/// An AgentCallbackLogoff is triggered when an agent that previously logged in is logged of.<br/>
		/// It is implemented in <code>channels/chan_agent.c</code>
		/// </summary>
		public event AgentCallbackLogoffEventHandler AgentCallbackLogoff;
		/// <summary>
		/// An AgentCalled is triggered when an agent is rung.<br/>
		/// To enable AgentCalled you have to set <code>eventwhencalled = yes</code> in <code>queues.conf</code>.<br/>
		/// This event is implemented in <code>apps/app_queue.c</code>
		/// </summary>
		public event AgentCalledEventHandler AgentCalled;
		public event AgentCompleteEventHandler AgentComplete;
		public event AgentConnectEventHandler AgentConnect;
		public event AgentDumpEventHandler AgentDump;
		public event AgentLoginEventHandler AgentLogin;
		public event AgentLogoffEventHandler AgentLogoff;
		public event AgentsCompleteEventHandler AgentsComplete;
		public event AgentsEventHandler Agents;
		public event AlarmClearEventHandler AlarmClear;
		public event AlarmEventHandler Alarm;
		public event CdrEventHandler Cdr;
		public event ConnectEventHandler Connect;
		public event DBGetResponseEventHandler DBGetResponse;
		/// <summary>
		/// A Dial is triggered whenever a phone attempts to dial someone.<br/>
		/// This event is implemented in <code>apps/app_dial.c</code>.<br/>
		/// Available since Asterisk 1.2.
		/// </summary>
		public event DialEventHandler Dial;
		public event DisconnectEventHandler DisconnectEvent;
		public event DNDStateEventHandler DNDState;
		/// <summary>
		/// An ExtensionStatus is triggered when the state of an extension changes.<br/>
		/// It is implemented in <code>manager.c</code>
		/// </summary>
		public event ExtensionStatusEventHandler ExtensionStatus;
		/// <summary>
		/// A Hangup is triggered when a channel is hung up.<br/>
		/// It is implemented in <code>channel.c</code>
		/// </summary>
		public event HangupEventHandler Hangup;
		/// <summary>
		/// A HoldedCall is triggered when a channel is put on hold.<br/>
		/// It is implemented in <code>res/res_features.c</code>
		/// </summary>
		public event HoldedCallEventHandler HoldedCall;
		/// <summary>
		/// A Hold is triggered by the SIP channel driver when a channel is put on hold.<br/>
		/// It is implemented in <code>channels/chan_sip.c</code>.<br/>
		/// Available since Asterisk 1.2
		/// </summary>
		public event HoldEventHandler Hold;
		/// <summary>
		/// A Join is triggered when a channel joines a queue.<br/>
		/// It is implemented in <code>apps/app_queue.c</code>
		/// </summary>
		public event JoinEventHandler Join;
		/// <summary>
		/// A Leave is triggered when a channel leaves a queue.<br/>
		/// It is implemented in <code>apps/app_queue.c</code>
		/// </summary>
		public event LeaveEventHandler Leave;
		/// <summary>
		/// A Link is triggered when two voice channels are linked together and voice data exchange commences.<br/>
		/// Several Link events may be seen for a single call. This can occur when Asterisk fails to setup a
		/// native bridge for the call.This is when Asterisk must sit between two telephones and perform
		/// CODEC conversion on their behalf.<br/>
		/// It is implemented in <code>channel.c</code>
		/// </summary>
		public event LinkEventHandler Link;
		/// <summary>
		/// A LogChannel is triggered when logging is turned on or off.<br/>
		/// It is implemented in <code>logger.c</code><br/>
		/// </summary>
		public event LogChannelEventHandler LogChannel;
		/// <summary>
		/// A MeetMeJoin is triggered if a channel joins a meet me conference.<br/>
		/// It is implemented in <code>apps/app_meetme.c</code>
		/// </summary>
		public event MeetMeJoinEventHandler MeetMeJoin;
		/// <summary>
		/// A MeetMeLeave is triggered if a channel leaves a meet me conference.<br/>
		/// It is implemented in <code>apps/app_meetme.c</code>
		/// </summary>
		public event MeetMeLeaveEventHandler MeetMeLeave;
		// public event MeetMeStopTalkingEventHandler MeetMeStopTalking;
		/// <summary>
		/// A MeetMeTalking is triggered when a user starts talking in a meet me conference.<br/>
		/// It is implemented in <code>apps/app_meetme.c</code><br/>
		/// </summary>
		// public event MeetMeTalkingEventHandler MeetMeTalking;
		/// <summary>
		/// A MessageWaiting is triggered when someone leaves voicemail.<br/>
		/// It is implemented in <code>apps/app_voicemail.c</code>
		/// </summary>
		public event MessageWaitingEventHandler MessageWaiting;
		/// <summary>
		/// A NewCallerId is triggered when the caller id of a channel changes.<br/>
		/// It is implemented in <code>channel.c</code>
		/// </summary>
		public event NewCallerIdEventHandler NewCallerId;
		/// <summary>
		/// A NewChannel is triggered when a new channel is created.<br/>
		/// It is implemented in <code>channel.c</code>
		/// </summary>
		public event NewChannelEventHandler NewChannel;
		/// <summary>
		/// A NewExten is triggered when a channel is connected to a new extension.<br/>
		/// It is implemented in <code>pbx.c</code>
		/// </summary>
		public event NewExtenEventHandler NewExten;
		/// <summary>
		/// A NewState is triggered when the state of a channel has changed.<br/>
		/// It is implemented in <code>channel.c</code>
		/// </summary>
		public event NewStateEventHandler NewState;
		// public event OriginateEventHandler Originate;
		/// <summary>
		/// An OriginateFailure is triggered when the execution of an OriginateAction failed.
		/// </summary>
		public event OriginateFailureEventHandler OriginateFailure;
		/// <summary>
		/// An OriginateSuccess is triggered when the execution of an OriginateAction succeeded.
		/// </summary>
		public event OriginateSuccessEventHandler OriginateSuccess;
		/// <summary>
		/// A ParkedCall is triggered when a channel is parked (in this case no
		/// action id is set) and in response to a ParkedCallsAction.<br/>
		/// It is implemented in <code>res/res_features.c</code>
		/// </summary>
		public event ParkedCallEventHandler ParkedCall;
		/// <summary>
		/// A ParkedCallGiveUp is triggered when a channel that has been parked is hung up.<br/>
		/// It is implemented in <code>res/res_features.c</code><br/>
		/// Available since Asterisk 1.2
		/// </summary>
		public event ParkedCallGiveUpEventHandler ParkedCallGiveUp;
		/// <summary>
		/// A ParkedCallsComplete is triggered after all parked calls have been reported in response to a ParkedCallsAction.
		/// </summary>
		public event ParkedCallsCompleteEventHandler ParkedCallsComplete;
		/// <summary>
		/// A ParkedCallTimeOut is triggered when call parking times out for a given channel.<br/>
		/// It is implemented in <code>res/res_features.c</code><br/>
		/// Available since Asterisk 1.2
		/// </summary>
		public event ParkedCallTimeOutEventHandler ParkedCallTimeOut;
		/// <summary>
		/// A PeerEntry is triggered in response to a SIPPeersAction or SIPShowPeerAction and contains information about a peer.<br/>
		/// It is implemented in <code>channels/chan_sip.c</code>
		/// </summary>
		public event PeerEntryEventHandler PeerEntry;
		/// <summary>
		/// A PeerlistComplete is triggered after the details of all peers has been reported in response to an SIPPeersAction or SIPShowPeerAction.<br/>
		/// Available since Asterisk 1.2
		/// </summary>
		public event PeerlistCompleteEventHandler PeerlistComplete;
		/// <summary>
		/// A PeerStatus is triggered when a SIP or IAX client attempts to registrer at this asterisk server.<br/>
		/// This event is implemented in <code>channels/chan_iax2.c</code> and <code>channels/chan_sip.c</code>
		/// </summary>
		public event PeerStatusEventHandler PeerStatus;
        public event QueueEntryEventHandler QueueEntry;
		public event QueueMemberAddedEventHandler QueueMemberAdded;
        public event QueueMemberEventHandler QueueMember;
		public event QueueMemberPausedEventHandler QueueMemberPaused;
		public event QueueMemberRemovedEventHandler QueueMemberRemoved;
		public event QueueMemberStatusEventHandler QueueMemberStatus;
		public event QueueParamsEventHandler QueueParams;
		public event QueueStatusCompleteEventHandler QueueStatusComplete;
		/// <summary>
		/// A Registry is triggered when this asterisk server attempts to register
		/// as a client at another SIP or IAX server.<br/>
		/// This event is implemented in <code>channels/chan_iax2.c</code> and
		/// <code>channels/chan_sip.c</code>
		/// </summary>
		public event RegistryEventHandler Registry;
		/// <summary>
		/// A Reload is triggerd when the <code>reload</code> console command is executed or the Asterisk server is started.<br/>
		/// It is implemented in <code>manager.c</code>
		/// </summary>
		public event ReloadEventHandler Reload;
        public event RenameEventHandler Rename;
		/// <summary>
		/// A Shutdown is triggered when the asterisk server is shut down or restarted.<br/>
		/// It is implemented in <code>asterisk.c</code>
		/// </summary>
		public event ShutdownEventHandler Shutdown;
		public event StatusCompleteEventHandler StatusComplete;
        public event StatusEventHandler Status;
		public event UnholdEventHandler Unhold;
        public event UnlinkEventHandler Unlink;
		public event UnparkedCallEventHandler UnparkedCall;
		public event ZapShowChannelsCompleteEventHandler ZapShowChannelsComplete;
		public event ZapShowChannelsEventHandler ZapShowChannels;
		/// <summary>
		/// A Event is triggered to all unhandled events.<br/>
		/// </summary>
		public event ManagerConnectionEventHandler Events;
		#endregion

		#region SkipQueues
		/// <summary>
		/// Determines if queue status is retrieved at startup. If you don't need
		/// queue information and still run Asterisk 1.0.x you can set this to
		/// <code>true</code> to circumvent the startup delay caused by the missing
		/// QueueStatusComplete event.<br/>
		/// Default is <code>false</code>.
		/// </summary>
		virtual public bool SkipQueues
		{
			set { this.skipQueues = value; }
		}
		#endregion
		#region Channels
		/// <summary>
		/// Returns a map of all active channel by their unique id.
		/// </summary>
		virtual public IDictionary Channels
		{
			get { return channels; }
		}
		#endregion
		#region Queues
		virtual public IDictionary Queues
		{
			get { return queues; }
		}
		#endregion
		#region Connection
		/// <summary>
		/// The manager connection used to talk to Asterisk.
		/// </summary>
		public ManagerConnection Connection
		{
			get { return this.connection; }
			set { this.connection = value; }
		}
		#endregion

		#region Constructor - AsteriskManager()
		/// <summary> Creates a new instance.</summary>
		internal AsteriskManager()
		{
			logger = Util.LogFactory.getLog(this.GetType());
			this.channels = Hashtable.Synchronized(new Hashtable(new Hashtable()));
			this.queues = Hashtable.Synchronized(new Hashtable(new Hashtable()));
		}
		#endregion
		#region Constructor - AsteriskManager(connection)
		/// <summary>
		/// Creates a new instance.
		/// </summary>
		/// <param name="connection">the manager connection to use</param>
		public AsteriskManager(ManagerConnection connection)
			: this()
		{
			this.connection = connection;
			this.connection.Events += new ManagerConnectionEventHandler(handleEvents);
		}
		#endregion
		#region Constructor - AsteriskManager(hostname, port, username, password)
		/// <summary>
		/// Creates a new instance.
		/// </summary>
		/// <param name="hostname">the hosname of the Asterisk server to connect to.</param>
		/// <param name="port">the port where Asterisk listens for incoming Manager API connections, usually 5038.</param>
		/// <param name="username">the username to use for login</param>
		/// <param name="password">the password to use for login</param>
		public AsteriskManager(string hostname, int port, string username, string password)
			: this()
		{
			this.connection = new ManagerConnection(hostname, port, username, password);
			this.connection.Events += new ManagerConnectionEventHandler(handleEvents);
		}
		#endregion

		#region Initialize()
		/// <summary>
		/// Initialize AsteriskManager. Prepare Login action, initialize and load Queues and Channels and attach to events.
		/// </summary>
		public virtual void Initialize()
		{
            this.connection.Login();
			initializeChannels();
			initializeQueues();
		}
		#endregion

		#region initializeChannels()
		private void  initializeChannels()
		{
			this.connection.enableEvents = false;
			channels.Clear();
			IResponseEvents re = connection.SendEventGeneratingAction(new Action.StatusAction());
			foreach (Event.ManagerEvent e in re.Events)
			{
				if (e is Event.StatusEvent)
					handleStatusEvent((Event.StatusEvent)e);
			}
			this.connection.enableEvents = true;
		}
		#endregion
		#region initializeQueues()
		private void  initializeQueues()
		{
			if (skipQueues) return;
			this.connection.enableEvents = false;
			queues.Clear();
			IResponseEvents re;
			try
			{
				re = connection.SendEventGeneratingAction(new Action.QueueStatusAction());
			}
			catch (EventTimeoutException e)
			{
				// this happens with Asterisk 1.0.x as it doesn't send a QueueStatusCompleteEvent
				re = e.PartialResult;
			}
			foreach (Event.ManagerEvent e in re.Events)
			{
				if (e is Event.QueueParamsEvent)
					handleQueueParamsEvent((Event.QueueParamsEvent)e);
				else if (e is Event.QueueMemberEvent)
					handleQueueMemberEvent((Event.QueueMemberEvent)e);
				else if (e is Event.QueueEntryEvent)
					handleQueueEntryEvent((Event.QueueEntryEvent)e);
			}
			this.connection.enableEvents = true;
		}
		#endregion

		#region Login()
		/// <summary>
		/// Logs in to the asterisk manager using asterisk's MD5 based challenge/response protocol.
		/// The login is delayed until the protocol identifier has been received by the reader.
		/// </summary>
		/// <throws>  AuthenticationFailedException if the username and/or password are incorrect</throws>
		/// <throws>  TimeoutException if no response is received within the specified timeout period</throws>
		/// <seealso cref="Action.ChallengeAction"/>
		/// <seealso cref="Action.LoginAction"/>
		public void Login()
		{
			this.connection.Login();
		}
		#endregion
		#region Logoff()
		/// <summary>
		/// Sends a LogoffAction and disconnects from the server.
		/// </summary>
		public void Logoff()
		{
			this.connection.Logoff();
		}
		#endregion

		#region OriginateCall(originate)
		/// <summary>
		/// Generates an outgoing call.
		/// </summary>
		/// <param name="originate">conatins the details of the call to originate</param>
		/// <returns> a Call object representing the originated call</returns>
		/// <throws>  TimeoutException if the originated call is not answered in time </throws>
		/// <throws>  IOException if the action cannot be sent to the asterisk server </throws>
		public virtual Call OriginateCall(Originate originate)
		{
			long timeout = (originate.Timeout == 0 ? 30000 : originate.Timeout);

			Action.OriginateAction originateAction = new Action.OriginateAction();
			originateAction.Account = originate.Account;
			originateAction.Application = originate.Application;
			originateAction.CallerId = originate.CallerId;
			originateAction.Channel = originate.Channel;
			originateAction.Context = originate.Context;
			originateAction.Data = originate.Data;
			originateAction.Exten = originate.Exten;
			originateAction.Priority = originate.Priority;
			originateAction.Timeout = timeout;
			originateAction.SetVariables(originate.GetVariables());
			
			// must set async to true to receive OriginateEvents.
			originateAction.Async = true;
			
			// 2000 ms extra for the OriginateFailureEvent should be fine
			IResponseEvents responseEvents = connection.SendEventGeneratingAction(originateAction, timeout + 2000);
			return createOriginateCall((Event.OriginateEvent)(responseEvents.Events[0]));
		}
		#endregion
		#region createOriginateCall(Event.OriginateEvent e)
		protected internal virtual Call createOriginateCall(Event.OriginateEvent e)
		{
			Channel channel = ChannelById(e.UniqueId);
			Call call = new Call();
			call.UniqueId = e.UniqueId;
			call.Channel = channel;
			call.StartTime = e.DateReceived;
			if (e is Event.OriginateFailureEvent)
				call.EndTime = e.DateReceived;
			call.Reason = e.Reason;
			return call;
		}
		#endregion

		#region Version()
		public virtual string Version()
		{
			if (version == null)
			{
				try
				{
					Response.ManagerResponse response = connection.SendAction(new Action.CommandAction("show version"));
					if (response is Response.CommandResponse)
					{
						IList result;
						result = ((Response.CommandResponse)response).Result;
						if (result.Count > 0)
							version = ((string)result[0]);
					}
				}
				catch (Exception e)
				{
					logger.warn("Unable to send 'show version' command.", e);
				}
			}
			return version;
		}
		#endregion
		#region Version(string file)
		public virtual int[] Version(string file)
		{
			string fileVersion = null;

			if (versions == null)
			{
				try
				{
					IDictionary map = new Hashtable();
					Response.ManagerResponse response = connection.SendAction(new Action.CommandAction("show version files"));
					if (response is Response.CommandResponse)
					{
						IList result = ((Response.CommandResponse) response).Result;
						string line, key, ver;
						Match matcher;
						for (int i = 2; i < result.Count; i++)
						{
							line = ((string) result[i]);
							matcher = SHOW_VERSION_FILES_PATTERN.Match(line);
							if (matcher.Success)
							{
								key = matcher.Groups[1].Value;
								ver = matcher.Groups[2].Value;
								map[key] = ver;
							}
						}
						fileVersion = ((string) map[file]);
						versions = map;
					}
				}
				catch (Exception e)
				{
					logger.warn("Unable to send 'show version files' command.", e);
				}
			}
			else
			{
				lock (versions.SyncRoot)
				{
					fileVersion = ((string) versions[file]);
				}
			}
			
			if (fileVersion == null)
				return null;

			string[] parts = fileVersion.Split('.');
			int[] intParts = new int[parts.Length];
			for (int i = 0; i < parts.Length; i++)
			{
				try
				{
					intParts[i] = int.Parse(parts[i]);
				}
				catch (FormatException)
				{
					intParts[i] = 0;
				}
			}

			return intParts;
		}
		#endregion
		#region VersionString(string file)
		public virtual string VersionString(string file)
		{
			string fileVersion = null;

			if (versions == null)
			{
				try
				{
					IDictionary map = new Hashtable();
					Response.ManagerResponse response = connection.SendAction(new Action.CommandAction("show version files"));
					if (response is Response.CommandResponse)
					{
						IList result = ((Response.CommandResponse)response).Result;
						string line, key, ver;
						Match matcher;
						for (int i = 2; i < result.Count; i++)
						{
							line = ((string)result[i]);
							matcher = SHOW_VERSION_FILES_PATTERN.Match(line);
							if (matcher.Success)
							{
								key = matcher.Groups[1].Value;
								ver = matcher.Groups[2].Value;
								map[key] = ver;
							}
						}
						fileVersion = ((string)map[file]);
						versions = map;
					}
				}
				catch (Exception e)
				{
					logger.warn("Unable to send 'show version files' command.", e);
				}
			}
			else
			{
				lock (versions.SyncRoot)
				{
					fileVersion = ((string)versions[file]);
				}
			}

			return fileVersion;
		}
		#endregion

		#region ChannelByName(name)
		/// <summary>
		/// Returns a channel by its name.
		/// </summary>
		/// <param name="name">name of the channel to return</param>
		/// <returns>the channel with the given name</returns>
		public virtual Channel ChannelByName(string name)
		{
			Channel channel = null;

			lock (channels.SyncRoot)
			{
				foreach(Channel tmp in channels.Values)
				{
					if (tmp.Name != null && tmp.Name == name)
					{
						channel = tmp;
						break;
					}
				}
			}
			return channel;
		}
		#endregion
		#region ChannelById(id)
		/// <summary>
		/// Returns a channel by its unique id.
		/// </summary>
		/// <param name="id">the unique id of the channel to return</param>
		/// <returns>the channel with the given unique id</returns>
		public virtual Channel ChannelById(string id)
		{
			Channel channel = null;
			lock (channels.SyncRoot)
			{
				if(channels.Contains(id))
					channel = (Channel)channels[id];
			}
			return channel;
		}
		#endregion
		#region Add/Remove Channel
		protected internal virtual void addChannel(Channel channel)
		{
			if(channel == null) return;
			string id = channel.Id.Trim();
			if (id == null || id.Length == 0) return;
			lock (channels.SyncRoot)
			{
				if(channels.Contains(channel.Id))
					channels[channel.Id] = channel;
				else
					channels.Add(channel.Id, channel);
			}
		}
		protected internal virtual void removeChannel(Channel channel)
		{
			if(channel == null) return;
			string id = channel.Id.Trim();
			if (id == null || id.Length == 0) return;
			lock (channels.SyncRoot)
			{
				if (channels.Contains(channel.Id))
					channels.Remove(channel.Id);
			}
		}
		#endregion

		#region QueueByName(name)
		/// <summary>
		/// Returns a queue by its name.
		/// </summary>
		/// <param name="name">name of the queue to return</param>
		/// <returns>the queue with the given name</returns>
		public virtual Queue QueueByName(string name)
		{
			Queue queue = null;
			lock (queues.SyncRoot)
			{
				foreach (Queue tmp in queues.Values)
				{
					if (tmp.Name != null && tmp.Name == name)
					{
						queue = tmp;
						break;
					}
				}
			}
			return queue;
		}
		#endregion
		#region Add/Remove Queue
		protected internal virtual void addQueue(Queue queue)
		{
			if(queue == null) return;
			string name = queue.Name.Trim();
			if(name == null || name.Length == 0) return;
			lock (queues.SyncRoot)
			{
				if(queues.Contains(name))
					queues[name] = queue;
				else
					queues.Add(name, queue);
			}
		}

		protected internal virtual void removeQueue(Queue queue)
		{
			if(queue == null) return;
			string name = queue.Name.Trim();
			if(name == null || name.Length == 0) return;
			lock (queues.SyncRoot)
			{
				if(queues.Contains(name))
					queues.Remove(queue.Name);
			}
		}
		#endregion

        #region handleEvent(object sender, Event.ManagerEvent evt)
        /// <summary>
		/// Handles all events received from the asterisk server.<br/>
		/// Events are queued until channels and queues are initialized and then
		/// delegated to the DispatchEvent method.
		/// </summary>
		protected internal virtual void handleEvents(object sender, Event.ManagerEvent e)
		{
			if ( e is Event.AgentCallbackLoginEvent)
			{
				if (AgentCallbackLogin != null)
				{
					AgentCallbackLogin(this, (Event.AgentCallbackLoginEvent)e);
					return;
				}
			}
			else if ( e is Event.AgentCallbackLogoffEvent)
			{
				if (AgentCallbackLogoff != null)
				{
					AgentCallbackLogoff(this, (Event.AgentCallbackLogoffEvent)e);
					return;
				}
			}
			else if ( e is Event.AgentCalledEvent)
			{
				if (AgentCalled != null)
				{
					AgentCalled(this, (Event.AgentCalledEvent)e);
					return;
				}
			}
			else if ( e is Event.AgentCompleteEvent)
			{
				if (AgentComplete != null)
				{
					AgentComplete(this, (Event.AgentCompleteEvent)e);
					return;
				}
			}
			else if ( e is Event.AgentConnectEvent)
			{
				if (AgentConnect != null)
				{
					AgentConnect(this, (Event.AgentConnectEvent)e);
					return;
				}
			}
			else if ( e is Event.AgentDumpEvent)
			{
				if (AgentDump != null)
				{
					AgentDump(this, (Event.AgentDumpEvent)e);
					return;
				}
			}
			else if ( e is Event.AgentLoginEvent)
			{
				if (AgentLogin != null)
				{
					AgentLogin(this, (Event.AgentLoginEvent)e);
					return;
				}
			}
			else if ( e is Event.AgentLogoffEvent)
			{
				if (AgentLogoff != null)
				{
					AgentLogoff(this, (Event.AgentLogoffEvent)e);
					return;
				}
			}
			else if ( e is Event.AgentsCompleteEvent)
			{
				if (AgentsComplete != null)
				{
					AgentsComplete(this, (Event.AgentsCompleteEvent)e);
					return;
				}
			}
			else if ( e is Event.AgentsEvent)
			{
				if (Agents != null)
				{
					Agents(this, (Event.AgentsEvent)e);
					return;
				}
			}
			else if ( e is Event.AlarmClearEvent)
			{
				if (AlarmClear != null)
				{
					AlarmClear(this, (Event.AlarmClearEvent)e);
					return;
				}
			}
			else if ( e is Event.AlarmEvent)
			{
				if (Alarm != null)
				{
					Alarm(this, (Event.AlarmEvent)e);
					return;
				}
			}
			else if ( e is Event.CdrEvent)
			{
				if (Cdr != null)
				{
					Cdr(this, (Event.CdrEvent)e);
					return;
				}
			}
			else if (e is Event.ConnectEvent)
			{
				if (handleConnectEvent((Event.ConnectEvent)e))
					return;
			}
			else if ( e is Event.DBGetResponseEvent)
			{
				if (DBGetResponse != null)
				{
					DBGetResponse(this, (Event.DBGetResponseEvent)e);
					return;
				}
			}
			else if (e is Event.DialEvent)
			{
				if (Dial != null)
				{
					Dial(this, (Event.DialEvent)e);
					return;
				}
			}
			else if (e is Event.DisconnectEvent)
			{
				if (handleDisconnectEvent((Event.DisconnectEvent)e))
					return;
			}
			else if ( e is Event.DNDStateEvent)
			{
				if (DNDState != null)
				{
					DNDState(this, (Event.DNDStateEvent)e);
					return;
				}
			}
			else if (e is Event.ExtensionStatusEvent)
			{
				if (ExtensionStatus != null)
				{
					ExtensionStatus(this, (Event.ExtensionStatusEvent)e);
					return;
				}
			}
			else if (e is Event.HangupEvent)
			{
				if (handleHangupEvent((Event.HangupEvent)e))
					return;
			}
			else if ( e is Event.HoldedCallEvent)
			{
				if (HoldedCall != null)
				{
					HoldedCall(this, (Event.HoldedCallEvent)e);
					return;
				}
			}
			else if ( e is Event.HoldEvent)
			{
				if (Hold != null)
				{
					Hold(this, (Event.HoldEvent)e);
					return;
				}
			}
			else if (e is Event.JoinEvent)
			{
				if (handleJoinEvent((Event.JoinEvent)e))
					return;
			}
			else if (e is Event.LeaveEvent)
			{
				if (handleLeaveEvent((Event.LeaveEvent)e))
					return;
			}
			else if (e is Event.LinkEvent)
			{
				if (handleLinkEvent((Event.LinkEvent)e))
					return;
			}
			else if ( e is Event.LogChannelEvent)
			{
				if (LogChannel != null)
				{
					LogChannel(this, (Event.LogChannelEvent)e);
					return;
				}
			}
			else if ( e is Event.MeetMeJoinEvent)
			{
				if (MeetMeJoin != null)
				{
					MeetMeJoin(this, (Event.MeetMeJoinEvent)e);
					return;
				}
			}
			else if ( e is Event.MeetMeLeaveEvent)
			{
				if (MeetMeLeave != null)
				{
					MeetMeLeave(this, (Event.MeetMeLeaveEvent)e);
					return;
				}
			}
//			else if ( e is Event.MeetMeStopTalkingEvent)
//			{
//				if (MeetMeStopTalking != null)
//				{
//					MeetMeStopTalking(this, (Event.MeetMeStopTalkingEvent)e);
//					return;
//				}
//			}
//			else if ( e is Event.MeetMeTalkingEvent)
//			{
//				if (MeetMeTalking != null)
//				{
//					MeetMeTalking(this, (Event.MeetMeTalkingEvent)e);
//					return;
//				}
//			}
			else if ( e is Event.MessageWaitingEvent)
			{
				if (MessageWaiting != null)
				{
					MessageWaiting(this, (Event.MessageWaitingEvent)e);
					return;
				}
			}
			else if (e is Event.NewCallerIdEvent)
			{
				if (handleNewCallerIdEvent((Event.NewCallerIdEvent)e))
					return;
			}
			else if (e is Event.NewChannelEvent)
			{
				if (handleNewChannelEvent((Event.NewChannelEvent)e))
					return;
			}
			else if (e is Event.NewExtenEvent)
			{
				if (handleNewExtenEvent((Event.NewExtenEvent)e))
					return;
			}
			else if (e is Event.NewStateEvent)
			{
				if (handleNewStateEvent((Event.NewStateEvent)e))
					return;
			}
//			else if ( e is Event.OriginateEvent)
//			{
//				if (handleOriginateEvent((Event.OriginateEvent)e))
//					return;
//			}
			else if ( e is Event.OriginateFailureEvent)
			{
				if (OriginateFailure != null)
				{
					OriginateFailure(this, (Event.OriginateFailureEvent)e);
					return;
				}
			}
			else if ( e is Event.OriginateSuccessEvent)
			{
				if (OriginateSuccess != null)
				{
					OriginateSuccess(this, (Event.OriginateSuccessEvent)e);
					return;
				}
			}
			else if ( e is Event.ParkedCallEvent)
			{
				if (ParkedCall != null)
				{
					ParkedCall(this, (Event.ParkedCallEvent)e);
					return;
				}
			}
			else if ( e is Event.ParkedCallGiveUpEvent)
			{
				if (ParkedCallGiveUp != null)
				{
					ParkedCallGiveUp(this, (Event.ParkedCallGiveUpEvent)e);
					return;
				}
			}
			else if ( e is Event.ParkedCallsCompleteEvent)
			{
				if (ParkedCallsComplete != null)
				{
					ParkedCallsComplete(this, (Event.ParkedCallsCompleteEvent)e);
					return;
				}
			}
			else if ( e is Event.ParkedCallTimeOutEvent)
			{
				if (ParkedCallTimeOut != null)
				{
					ParkedCallTimeOut(this, (Event.ParkedCallTimeOutEvent)e);
					return;
				}
			}
			else if ( e is Event.PeerEntryEvent)
			{
				if (PeerEntry != null)
				{
					PeerEntry(this, (Event.PeerEntryEvent)e);
					return;
				}
			}
			else if ( e is Event.PeerlistCompleteEvent)
			{
				if (PeerlistComplete != null)
				{
					PeerlistComplete(this, (Event.PeerlistCompleteEvent)e);
					return;
				}
			}
			else if (e is Event.PeerStatusEvent)
			{
				if (PeerStatus != null)
				{
					PeerStatus(this, (Event.PeerStatusEvent)e);
					return;
				}
			}
			else if ( e is Event.QueueEntryEvent)
			{
				if (handleQueueEntryEvent((Event.QueueEntryEvent) e))
					return;
			}
			else if ( e is Event.QueueMemberAddedEvent)
			{
				if (QueueMemberAdded != null)
				{
					QueueMemberAdded(this, (Event.QueueMemberAddedEvent)e);
					return;
				}
			}
			else if ( e is Event.QueueMemberEvent)
			{
				if(handleQueueMemberEvent((Event.QueueMemberEvent)e))
					return;
			}
			else if ( e is Event.QueueMemberPausedEvent)
			{
				if (QueueMemberPaused != null)
				{
					QueueMemberPaused(this, (Event.QueueMemberPausedEvent)e);
					return;
				}
			}
			else if ( e is Event.QueueMemberRemovedEvent)
			{
				if (QueueMemberRemoved != null)
				{
					QueueMemberRemoved(this, (Event.QueueMemberRemovedEvent)e);
					return;
				}
			}
			else if ( e is Event.QueueMemberStatusEvent)
			{
				if (QueueMemberStatus != null)
				{
					QueueMemberStatus(this, (Event.QueueMemberStatusEvent)e);
					return;
				}
			}
			else if ( e is Event.QueueParamsEvent)
			{
				if (handleQueueParamsEvent((Event.QueueParamsEvent)e))
					return;
			}
			else if ( e is Event.QueueStatusCompleteEvent)
			{
				if (QueueStatusComplete != null)
				{
					QueueStatusComplete(this, (Event.QueueStatusCompleteEvent)e);
					return;
				}
			}
			else if ( e is Event.RegistryEvent)
			{
				if (Registry != null)
				{
					Registry(this, (Event.RegistryEvent)e);
					return;
				}
			}
			else if (e is Event.ReloadEvent)
			{
				if (handleReloadEvent((Event.ReloadEvent)e))
					return;
			}
			else if (e is Event.RenameEvent)
			{
				if (handleRenameEvent((Event.RenameEvent)e))
					return;
			}
			else if ( e is Event.ShutdownEvent)
			{
				if (Shutdown != null)
				{
					Shutdown(this, (Event.ShutdownEvent)e);
					return;
				}
			}
			else if ( e is Event.StatusCompleteEvent)
			{
				if (StatusComplete != null)
				{
					StatusComplete(this, (Event.StatusCompleteEvent)e);
					return;
				}
			}
			else if ( e is Event.StatusEvent)
			{
				if (handleStatusEvent((Event.StatusEvent)e))
					return;
			}
			else if ( e is Event.UnholdEvent)
			{
				if (Unhold != null)
				{
					Unhold(this, (Event.UnholdEvent)e);
					return;
				}
			}
			else if (e is Event.UnlinkEvent)
			{
				if (handleUnlinkEvent((Event.UnlinkEvent)e))
					return;
			}
			else if ( e is Event.UnparkedCallEvent)
			{
				if (UnparkedCall != null)
				{
					UnparkedCall(this, (Event.UnparkedCallEvent)e);
					return;
				}
			}
			else if ( e is Event.ZapShowChannelsCompleteEvent)
			{
				if (ZapShowChannelsComplete != null)
				{
					ZapShowChannelsComplete(this, (Event.ZapShowChannelsCompleteEvent)e);
					return;
				}
			}
			else if ( e is Event.ZapShowChannelsEvent)
			{
				if (ZapShowChannels != null)
				{
					ZapShowChannels(this, (Event.ZapShowChannelsEvent)e);
					return;
				}
			}
			if (Events != null)
				Events(this, e);
		}
		#endregion

		#region handleConnectEvent(e)
		/// <summary>
		/// Requests the current state from the asterisk server after the connection
		/// to the asterisk server is restored.
		/// </summary>
		protected internal virtual bool  handleConnectEvent(Event.ConnectEvent evt)
		{
			try
			{
				initializeChannels();
			}
			catch (Exception e)
			{
				logger.error("Unable to initialize channels after reconnect.", e);
			}
			
			try
			{
				initializeQueues();
			}
			catch (IOException e)
			{
				logger.error("Unable to initialize queues after reconnect.", e);
			}
			if (Connect != null)
			{
				Connect(this, evt);
				return true;
			}
			return false;
		}
		#endregion
		#region handleDisconnectEvent(e)
		/// <summary>
		/// Resets the internal state when the connection to the asterisk server is lost.
		/// </summary>
		protected internal virtual bool handleDisconnectEvent(Event.DisconnectEvent e)
		{
			// reset version information as it might have changed while Asterisk restarted
			version = null;
			versions = null;

			channels.Clear();
			queues.Clear();

			if (DisconnectEvent != null)
			{
				DisconnectEvent(this, e);
				return true;
			}
			return false;
		}
		#endregion
		#region handleHangupEvent(e)
		protected internal virtual bool handleHangupEvent(Event.HangupEvent e)
		{
			bool result = false;
			Channel channel = ChannelById(e.UniqueId);
			if (channel == null)
				logger.error("Ignored HangupEvent for unknown channel " + e.Channel);
			else
			{
				lock (channel)
				{
					channel.State = ChannelStateEnum.Hungup;
				}
				if (Hangup != null)
				{
					Hangup(this, e);
					result = true;
				}
				logger.info("Removing channel " + channel.Name + " due to hangup");
				removeChannel(channel);
			}
			return result;
		}
		#endregion
		#region handleJoinEvent(e)
		protected internal virtual bool handleJoinEvent(Event.JoinEvent e)
		{
			Queue queue = QueueByName(e.Queue);
			Channel channel = ChannelByName(e.Channel);
			if (channel == null)
				logger.error("Ignored JoinEvent for unknown channel " + e.Channel);
			if (queue == null)
				logger.error("Ignored JoinEvent for unknown queue " + e.Queue);
			else
				queue.AddEntry(channel);

			if (Join != null)
			{
				Join(this, e);
				return true;
			}
			return false;
		}
		#endregion
		#region handleLeaveEvent(e)
		protected internal virtual bool handleLeaveEvent(Event.LeaveEvent e)
		{
			Queue queue = QueueByName(e.Queue);
			Channel channel = ChannelByName(e.Channel);

			if (channel == null)
				logger.error("Ignored LeaveEvent for unknown channel " + e.Channel);
			if (queue == null)
				logger.error("Ignored LeaveEvent for unknown queue " + e.Queue);
			else
				queue.RemoveEntry(channel);

			if (Leave != null)
			{
				Leave(this, e);
				return true;
			}
			return false;
		}
		#endregion
		#region handleLinkEvent(e)
		protected internal virtual bool handleLinkEvent(Event.LinkEvent e)
		{
			Channel channel1 = ChannelById(e.UniqueId1);
			Channel channel2 = ChannelById(e.UniqueId2);
			
			if (channel1 != null && channel2 == null)
			{
				lock (this)
				{
					channel1.LinkedChannel = channel2;
					channel2.LinkedChannel = channel1;
				}
				logger.info("Linking channels " + channel1.Name + " and " + channel2.Name);
			}
			else
				logger.error("Ignored LinkEvent for unknown channels " + e.UniqueId1 + "/" + e.UniqueId2);

			if (Link != null)
			{
				Link(this, e);
				return true;
			}
			return false;
		}
		#endregion
		#region handleNewChannelEvent(e)
		protected internal virtual bool handleNewChannelEvent(Event.NewChannelEvent e)
		{
			Channel channel = new Channel(e.Channel, e.UniqueId);
			channel.DateOfCreation = e.DateReceived;
			channel.CallerId = e.CallerId;
			channel.CallerIdName = e.CallerIdName;
			channel.State = ChannelStateEnum.GetEnum(e.State);
			addChannel(channel);
			logger.info("Adding channel " + channel.Name);
			if (NewChannel != null)
			{
				NewChannel(this, e);
				return true;
			}
			return false;
		}
		#endregion
		#region handleNewCallerIdEvent(e)
		protected internal virtual bool handleNewCallerIdEvent(Event.NewCallerIdEvent e)
		{
			Channel channel = ChannelById(e.UniqueId);
			if (channel == null)
				logger.error("Ignored NewCallerIdEvent for unknown channel " + e.Channel);
			else
				lock (channel)
				{
					channel.CallerId = e.CallerId;
					channel.CallerIdName = e.CallerIdName;
				}
			if (NewCallerId != null)
			{
				NewCallerId(this, e);
				return true;
			}
			return false;
		}
		#endregion
		#region handleNewExtenEvent(e)
		protected internal virtual bool handleNewExtenEvent(Event.NewExtenEvent e)
		{
			Channel channel;
			Extension extension;
			
			channel = ChannelById(e.UniqueId);
			if (channel == null)
				logger.error("Ignored NewExtenEvent for unknown channel " + e.Channel);
			else
			{
				extension = new Extension(e.DateReceived, e.Context, e.Extension, e.Priority, e.Application, e.AppData);
				lock (channel)
				{
					channel.AddExtension(extension);
				}
			}
			if (NewExten != null)
			{
				NewExten(this, e);
				return true;
			}
			return false;
		}
		#endregion
		#region handleNewStateEvent(e)
		protected internal virtual bool handleNewStateEvent(Event.NewStateEvent e)
		{
			Channel channel = ChannelById(e.UniqueId);
			if (channel == null)
				logger.error("Ignored NewStateEvent for unknown channel " + e.Channel);
			else
				lock (channel)
				{
					channel.State = ChannelStateEnum.GetEnum(e.State);
				}
			if (NewState != null)
			{
				NewState(this, e);
				return true;
			}
			return false;
		}
		#endregion
		#region handleReloadEvent(e)
		/// <summary>
		/// Resets the internal state when the Asterisk server is reload.
		/// </summary>
		protected internal virtual bool  handleReloadEvent(Event.ReloadEvent e)
		{
			// reset version information as it might have changed while Asterisk restarted
			version = null;
			versions = null;

			channels.Clear();
			queues.Clear();

			if (Reload != null)
			{
				Reload(this, e);
				return true;
			}
			return false;
		}
		#endregion
		#region handleRenameEvent(e)
		protected internal virtual bool handleRenameEvent(Event.RenameEvent e)
		{
			Channel channel = ChannelById(e.UniqueId);
			if (channel == null)
				logger.error("Ignored RenameEvent for unknown channel with uniqueId " + e.UniqueId);
			else
			{
				lock(channel)
				{
					channel.Name = e.Newname;
				}
				logger.info("Renaming channel " + channel.Name + " to " + e.Newname);
			}
			if (Rename != null)
			{
				Rename(this, e);
				return true;
			}
			return false;
		}
		#endregion
		#region handleStatusEvent(e)
		protected internal virtual bool handleStatusEvent(Event.StatusEvent e)
		{
			Channel channel;
			Extension extension;
			bool isNew = false;
	
			channel = ChannelById(e.UniqueId);
			if (channel == null)
			{
				channel = new Channel(e.Channel, e.UniqueId);
				if (e.Seconds != 0)
					channel.DateOfCreation = new DateTime((DateTime.Now.Ticks - Utils.DateTime01011970) / 10000 - (e.Seconds * 1000));
				isNew = true;
			}

			if (e.Context == null && e.Extension == null && e.Priority == 0)
				extension = null;
			else
				extension = new Extension(e.DateReceived, e.Context, e.Extension, e.Priority);
			
			lock (channel)
			{
				channel.CallerId = e.CallerId;
				channel.CallerIdName = e.CallerIdName;
				channel.Account = e.Account;
				channel.State = ChannelStateEnum.GetEnum(e.State);
				channel.AddExtension(extension);
				
				if (e.Link != null)
				{
					Channel linkedChannel = ChannelByName(e.Link);
					if (linkedChannel != null)
					{
						channel.LinkedChannel = linkedChannel;
						lock (linkedChannel)
						{
							linkedChannel.LinkedChannel = channel;
						}
					}
				}
			}
			
			if (isNew)
			{
				logger.info("Adding new channel " + channel.Name);
				addChannel(channel);
			}
			if(Status != null)
			{
				Status(this, e);
				return true;
			}
			return false;
		}
		#endregion
		#region handleUnlinkEvent(e)
		protected internal virtual bool handleUnlinkEvent(Event.UnlinkEvent e)
		{
			Channel channel1 = ChannelByName(e.Channel1);
			Channel channel2 = ChannelByName(e.Channel2);
			
			if (channel1 != null && channel2 == null)
			{
				lock (channel1)
				{
					channel1.LinkedChannel = null;
				}
				lock (channel2)
				{
					channel2.LinkedChannel = null;
				}
				logger.info("Unlinking channels " + channel1.Name + " and " + channel2.Name);
			}
			else
				logger.error("Ignored UnlinkEvent for unknown channels " + e.Channel1 + "/" + e.Channel2);

			if (Unlink != null)
			{
				Unlink(this, e);
				return true;
			}
			return false;
		}
		#endregion
		#region handleQueueParamsEvent(e)
		protected internal virtual bool  handleQueueParamsEvent(Event.QueueParamsEvent e)
		{
			bool isNew = false;

			Queue queue = QueueByName(e.Queue);
			if (queue == null)
			{
				queue = new Queue(e.Queue);
				isNew = true;
			}
			lock (queue)
			{
				queue.Max = e.Max;
			}
			if (isNew)
			{
				logger.info("Adding new queue " + queue.Name);
				addQueue(queue);
			}
			if (QueueParams != null)
			{
				QueueParams(this, e);
				return true;
			}
			return false;
		}
		#endregion
		#region handleQueueMemberEvent(e)
		protected internal virtual bool handleQueueMemberEvent(Event.QueueMemberEvent e)
		{
			Channel channel = new Channel(e.Location, null);
			Queue queue = QueueByName(e.Queue);
			if(queue == null)
				logger.warn("Queue not found :" + e.Queue);
			else
				queue.AddEntry(channel);

			if (QueueMember != null)
			{
				QueueMember(this, e);
				return true;
			}
			return false;
		}
		#endregion
		#region handleQueueEntryEvent(e)
		protected internal virtual bool handleQueueEntryEvent(Event.QueueEntryEvent e)
		{
			Queue queue = QueueByName(e.Queue);
			Channel channel = ChannelByName(e.Channel);
			if (channel == null)
				logger.error("ignored QueueEntryEvent for unknown channel " + e.Channel);
			if (queue == null)
				logger.error("ignored QueueEntryEvent for unknown queue " + e.Queue);
			else
				queue.AddEntry(channel);

			if (QueueEntry != null)
			{
				QueueEntry(this, e);
				return true;
			}
			return false;
		}
		#endregion
	}
}
