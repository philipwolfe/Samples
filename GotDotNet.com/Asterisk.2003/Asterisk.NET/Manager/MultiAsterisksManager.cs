using System;
using System.Collections;

namespace Asterisk.NET.Manager
{
	public class MultiAsterisksManager : IAsteriskManager
	{
		private Util.ILog logger;
		/// <summary> A map of all Asterisk servers connections by their unique hostname.</summary>
		private IDictionary managerConnections;
		/// <summary>A map of all active channel by theirs hostname of connection and unique id. keyMap -> "hostname:uniqueId"</summary>
		private IDictionary channels;
		private IDictionary queues;
		private IList queuedEvents;
		/// <summary> A map of all "Initiallize flag" per connection. keyMap -> "hostname"</summary>
		private IDictionary initialized;

		#region Constructor - MultiAsterisksManager()
		public MultiAsterisksManager()
		{
			logger = Util.LogFactory.getLog(this.GetType());
			this.channels = Hashtable.Synchronized(new Hashtable(new Hashtable()));
			this.queues = Hashtable.Synchronized(new Hashtable(new Hashtable()));
			this.queuedEvents = (IList) ArrayList.Synchronized(new ArrayList(new ArrayList()));
			this.managerConnections = Hashtable.Synchronized(new Hashtable(new Hashtable()));
			this.initialized = Hashtable.Synchronized(new Hashtable(new Hashtable()));
		}
		#endregion

		#region AddManagerConnection(IManagerConnection connection)
		public virtual void  AddManagerConnection(IManagerConnection connection)
		{
			managerConnections[connection.AsteriskServer] = connection;
			Hashtable initializedBoolean = Hashtable.Synchronized(new Hashtable(3, 1));
			initializedBoolean["channelsInitialized"] = false;
			initializedBoolean["queuesInitialized"] = true;
			initializedBoolean["initialized"] = false;

			initialized[connection.AsteriskServer] = initializedBoolean;
		}
		#endregion

		#region Initialize()
		public virtual void  Initialize()
		{
			foreach (ManagerConnection connection in managerConnections.Values)
			{
				connection.Login();
				connection.SendAction(new Action.StatusAction());
				connection.SendAction(new Action.QueueStatusAction());
				connection.Events += new ManagerConnectionEventHandler(handleEvents);
			}
		}
		#endregion

		#region Channels
		/// <summary>
		/// Get a map of all active channels by their unique id: "hostname:ChannelId".
		/// </summary>
		virtual public IDictionary Channels
		{
			get { return channels; }
		}
		#endregion
		#region Add/Remove Channel
		protected internal virtual void addChannel(Channel channel)
		{
			channels[channel.AsteriskServer.Hostname + "/" + channel.Id] = channel;
		}

		protected internal virtual void removeChannel(Channel channel)
		{
			channels.Remove(channel.AsteriskServer.Hostname + "/" + channel.Id);
		}
		#endregion
		#region channelByName(string name)
		/// <summary>
		/// Returns a channel by its name.
		/// </summary>
		/// <param name="name">name of the channel to return</param>
		/// <returns> the channel with the given name</returns>
		private Channel channelByName(string name)
		{
			Channel channel = null;
			foreach (Channel tmp in channels.Values)
			{
				if (tmp.Name != null && tmp.Name == name)
				{
					channel = tmp;
					break;
				}
			}
			return channel;
		}
		#endregion

		#region Queue
		/// <summary>
		/// Get a map of all active queues.
		/// </summary>
		virtual public IDictionary Queues
		{
			get { return queues; }
		}
		#endregion
		#region Add/Remove Queue
		protected internal virtual void addQueue(Queue queue)
		{
			queues[queue.Name] = queue;
		}

		protected internal virtual void removeQueue(Queue queue)
		{
			queues.Remove(queue.Name);
		}
		#endregion

		#region handleEvent(object sender, Event.ManagerEvent evt)
		/// <summary>
		/// Handles all events received from the asterisk server.<br/>
		/// Events are queued until channels and queues are initialized and then delegated to the dispatchEvent method.
		/// </summary>
        protected internal virtual void handleEvents(object sender, Event.ManagerEvent evt)
		{
			logger.debug("Event received: " + evt);

			Hashtable initializedBoolean = (Hashtable) initialized[(AsteriskServer) evt.Source];
			if ((bool) initializedBoolean["initialized"])
				dispatchEvent(evt);
			else
			{
				if (evt is Event.StatusEvent)
					handleStatusEvent((Event.StatusEvent)evt);
				else if (evt is Event.StatusCompleteEvent)
					handleStatusCompleteEvent((Event.StatusCompleteEvent)evt);
				else if (evt is Event.QueueParamsEvent)
					handleQueueParamsEvent((Event.QueueParamsEvent)evt);
				else if (evt is Event.QueueMemberEvent)
					handleQueueMemberEvent((Event.QueueMemberEvent)evt);
				else if (evt is Event.QueueEntryEvent)
					handleQueueEntryEvent((Event.QueueEntryEvent)evt);
				else
					queuedEvents.Add(evt);
				
				if (((bool) initializedBoolean["channelsInitialized"]) && ((bool) initializedBoolean["queuesInitialized"]))
				{
					foreach (Event.ManagerEvent queuedEvent in queuedEvents)
					{
						dispatchEvent(queuedEvent);
						queuedEvents.Remove(queuedEvent);
					}
					initializedBoolean["initialized"] = true;
				}
			}
		}
		#endregion
		#region dispatchEvent(Event.ManagerEvent evt)
		protected internal virtual void dispatchEvent(Event.ManagerEvent evt)
		{
			if (evt is Event.NewChannelEvent)
				handleNewChannelEvent((Event.NewChannelEvent)evt);
			else if (evt is Event.NewExtenEvent)
				handleNewExtenEvent((Event.NewExtenEvent)evt);
			else if (evt is Event.NewStateEvent)
				handleNewStateEvent((Event.NewStateEvent)evt);
			else if (evt is Event.LinkEvent)
				handleLinkEvent((Event.LinkEvent)evt);
			else if (evt is Event.UnlinkEvent)
				handleUnlinkEvent((Event.UnlinkEvent)evt);
			else if (evt is Event.RenameEvent)
				handleRenameEvent((Event.RenameEvent)evt);
			else if (evt is Event.HangupEvent)
				handleHangupEvent((Event.HangupEvent)evt);
		}
		#endregion
		#region handleStatusEvent(Event.StatusEvent evt)
		protected internal virtual void  handleStatusEvent(Event.StatusEvent evt)
		{
			Channel channel;
			bool isNew = false;
			
			channel = (Channel) channels[((AsteriskServer) evt.Source).Hostname + "/" + evt.UniqueId];
			if (channel == null)
			{
				channel = new Channel(evt.Channel, evt.UniqueId, (AsteriskServer) evt.Source);
				if (evt.Seconds > -1)
				{
					channel.DateOfCreation = new DateTime((DateTime.Now.Ticks - Utils.DateTime01011970) / 10000 - (evt.Seconds * 1000));
				}
				isNew = true;
			}
			
			lock (channel)
			{
				channel.CallerId = evt.CallerId;
				channel.Account = evt.Account;
				channel.State = ChannelStateEnum.getEnum(evt.State);
				if (evt.Link != null)
				{
					Channel linkedChannel = channelByName(evt.Link);
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
				logger.info("Adding new channel " + channel.Name + ", from server " + channel.AsteriskServer.Hostname);
				addChannel(channel);
			}
		}
		#endregion
		#region handleStatusCompleteEvent(Event.StatusCompleteEvent evt)
		protected internal virtual void  handleStatusCompleteEvent(Event.StatusCompleteEvent evt)
		{
			logger.info("Channels are now initialized");
			Hashtable initializedBoolean = (Hashtable) initialized[(AsteriskServer) evt.Source];
			initializedBoolean["channelsInitialized"] = true;
		}
		#endregion
		#region handleQueueParamsEvent(Event.QueueParamsEvent evt)
		protected internal virtual void  handleQueueParamsEvent(Event.QueueParamsEvent evt)
		{
			Queue queue;
			bool isNew = false;
			
			queue = (Queue) queues[evt.Queue];
			
			if (queue == null)
			{
				queue = new Queue(evt.Queue);
				isNew = true;
			}
			
			lock (queue)
			{
				queue.Max = evt.Max;
			}
			
			if (isNew)
			{
				logger.info("Adding new queue " + queue.Name);
				addQueue(queue);
			}
		}
		#endregion
		#region handleQueueMemberEvent(Event.QueueMemberEvent evt)
		protected internal virtual void  handleQueueMemberEvent(Event.QueueMemberEvent evt)
		{
		}
		#endregion
		#region handleQueueEntryEvent(Event.QueueEntryEvent evt)
		protected internal virtual void  handleQueueEntryEvent(Event.QueueEntryEvent evt)
		{
			Queue queue = (Queue) queues[evt.Queue];
			Channel channel = channelByName(evt.Channel);
			
			if (queue == null)
			{
				logger.error("ignored QueueEntryEvent for unknown queue " + evt.Queue);
				return ;
			}
			if (channel == null)
			{
				logger.error("ignored QueueEntryEvent for unknown channel " + evt.Channel);
				return ;
			}
			
			if (!queue.Entries.Contains(channel))
				queue.AddEntry(channel);
		}
		#endregion
		#region handleNewChannelEvent(Event.NewChannelEvent evt)
		protected internal virtual void  handleNewChannelEvent(Event.NewChannelEvent evt)
		{
			Channel channel = new Channel(evt.Channel, evt.UniqueId, (AsteriskServer) evt.Source);

			channel.CallerId = evt.CallerId;
			channel.State = ChannelStateEnum.getEnum(evt.State);
			
			logger.info("Adding channel " + channel.Name + ", on server " + channel.AsteriskServer.Hostname);
			addChannel(channel);
		}
		#endregion
		#region handleNewExtenEvent(Event.NewExtenEvent evt)
		protected internal virtual void  handleNewExtenEvent(Event.NewExtenEvent evt)
		{
			Channel channel = (Channel) channels[((AsteriskServer) evt.Source).Hostname + "/" + evt.UniqueId];
			if (channel == null)
			{
				logger.error("Ignored NewExtenEvent for unknown channel " + evt.Channel);
				return ;
			}
			
			lock (channel)
			{
				// TODO handle new extension
			}
		}
		#endregion
		#region handleNewStateEvent(Event.NewStateEvent evt)
		protected internal virtual void  handleNewStateEvent(Event.NewStateEvent evt)
		{
			Channel channel = (Channel) channels[((AsteriskServer) evt.Source).Hostname + "/" + evt.UniqueId];
			if (channel == null)
			{
				logger.error("Ignored NewStateEvent for unknown channel " + evt.Channel);
				return ;
			}
			
			channel.State = ChannelStateEnum.getEnum(evt.State);
		}
		#endregion
		#region handleHangupEvent(Event.HangupEvent evt)
		protected internal virtual void  handleHangupEvent(Event.HangupEvent evt)
		{
			Channel channel = (Channel) channels[((AsteriskServer) evt.Source).Hostname + "/" + evt.UniqueId];
			if (channel == null)
			{
				logger.error("Ignored HangupEvent for unknown channel " + evt.Channel);
				return ;
			}
			
			lock (channel)
			{
				channel.State = ChannelStateEnum.HUNGUP;
			}
			
			logger.info("Removing channel " + channel.Name + " due to hangup");
			removeChannel(channel);
		}
		#endregion
		#region handleLinkEvent(Event.LinkEvent evt)
		protected internal virtual void  handleLinkEvent(Event.LinkEvent evt)
		{
			Channel channel1 = (Channel) channels[((AsteriskServer) evt.Source).Hostname + "/" + evt.UniqueId1];
			Channel channel2 = (Channel) channels[((AsteriskServer) evt.Source).Hostname + "/" + evt.UniqueId2];
			
			if (channel1 == null)
			{
				logger.error("Ignored LinkEvent for unknown channel " + evt.Channel1);
				return ;
			}
			if (channel2 == null)
			{
				logger.error("Ignored LinkEvent for unknown channel " + evt.Channel2);
				return ;
			}
			
			logger.info("Linking channels " + channel1.Name + " and " + channel2.Name);
			lock (this)
			{
				channel1.LinkedChannel = channel2;
				channel2.LinkedChannel = channel1;
			}
		}
		#endregion
		#region handleUnlinkEvent(Event.UnlinkEvent evt)
		protected internal virtual void  handleUnlinkEvent(Event.UnlinkEvent evt)
		{
			Channel channel1 = channelByName(evt.Channel1);
			Channel channel2 = channelByName(evt.Channel2);
			
			if (channel1 == null)
			{
				logger.error("Ignored UnlinkEvent for unknown channel " + evt.Channel1);
				return ;
			}
			if (channel2 == null)
			{
				logger.error("Ignored UnlinkEvent for unknown channel " + evt.Channel2);
				return ;
			}
			
			logger.info("Unlinking channels " + channel1.Name + " and " + channel2.Name);
			lock (channel1)
			{
				channel1.LinkedChannel = null;
			}
			
			lock (channel2)
			{
				channel2.LinkedChannel = null;
			}
		}
		#endregion
		#region handleRenameEvent(Event.RenameEvent evt)
		protected internal virtual void  handleRenameEvent(Event.RenameEvent evt)
		{
			Channel channel = (Channel) channels[((AsteriskServer) evt.Source).Hostname + "/" + evt.UniqueId];
			logger.info("Renaming channel '" + channel.Name + "' to '" + evt.Newname + "'");
			channel.Name = evt.Newname;
		}
		#endregion

		#region OriginateCall(Originate originate)
		public virtual Call OriginateCall(Originate originate)
		{
			throw new NotSupportedException();
		}
		#endregion

		#region Version(string file)
		public virtual int[] Version(string file)
		{
			throw new NotSupportedException();
		}
		#endregion
		#region Version()
		public virtual string Version()
		{
			throw new NotSupportedException();
		}
		#endregion
	}
}