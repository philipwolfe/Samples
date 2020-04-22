using System;
using System.Text;
using System.Collections;
using System.Reflection;
using Asterisk.NET.Manager.Event;

namespace Asterisk.NET.Manager
{
	/// <summary>
	/// Default implementation of the EventBuilder interface.
	/// </summary>
	/// <seealso cref="Manager.event.ManagerEvent"/>
	public class EventBuilder : IEventBuilder
	{
		private Util.ILog logger;
		private IDictionary registeredEventClasses;

		#region Constructor - EventBuilder()
		public EventBuilder()
		{
			logger = Util.LogFactory.getLog(GetType());
			this.registeredEventClasses = new Hashtable();
			registerBuiltinEventClasses();
		}
		#endregion

		#region RegisterEventClass(Type clazz)
		public virtual void  RegisterEventClass(Type clazz)
		{
			string eventType = clazz.Name.ToLower();

			// Remove "event" at the end (if presents)
			if (eventType.EndsWith("event"))
				eventType = eventType.Substring(0, (eventType.Length - "event".Length) - (0));

			// If assignable from UserEvent and no "userevent" at the start - add "userevent" to beginning
			if (typeof(Event.UserEvent).IsAssignableFrom(clazz) && !eventType.StartsWith("userevent"))
				eventType = "userevent" + eventType;

			RegisterEventClass(eventType, clazz);
		}
		#endregion
		#region RegisterEventClass(string eventType, Type clazz)
		/// <summary>
		/// Registers a new event class for the event given by eventType.
		/// </summary>
		/// <param name="eventType">the name of the event to register the class for. For example "Join".</param>
		/// <param name="clazz">the event class to register, must extend Manager.event.Event.</param>
		public virtual void  RegisterEventClass(string eventType, Type clazz)
		{
			ConstructorInfo defaultConstructor;

			if (!typeof(Event.ManagerEvent).IsAssignableFrom(clazz))
				throw new ArgumentException("RegisterEventClass : " + clazz + " is not a ManagerEvent");

			if (clazz.IsAbstract)
				throw new ArgumentException("RegisterEventClass : " + clazz + " is abstract");

			try
			{
				defaultConstructor = clazz.GetConstructor(new Type[] { typeof(object) });
			}
			catch (MethodAccessException ex)
			{
				throw new ArgumentException("RegisterEventClass : " + clazz + " has no usable constructor.", ex);
			}
			
			if (Utils.GetConstructorModifiers(defaultConstructor) != 1)
				throw new ArgumentException("RegisterEventClass : " + clazz + " has no public default constructor");
			
			registeredEventClasses[eventType.ToLower()] = clazz;

			logger.debug("RegisterEventClass : Registered event type '" + eventType + "' (" + clazz + ")");
		}
		#endregion
		#region BuildEvent(object source, IDictionary attributes)
		/// <summary>
		/// Builds the event based on the given map of attributes and the registered event classes.
		/// </summary>
		/// <param name="source">source attribute for the event</param>
		/// <param name="attributes">map containing event attributes</param>
		/// <returns>a concrete instance of ManagerEvent or <code>null</code> if no event class was registered for the event type.</returns>
		public virtual ManagerEvent BuildEvent(object source, IDictionary attributes)
		{
			ManagerEvent evt;
			string eventType;
			Type eventClass;
			ConstructorInfo constructor;
			
			if (attributes["event"] == null)
			{
				logger.error("No event event type in properties");
				return null;
			}
			
			eventType = ((string) attributes["event"]).ToLower();
			eventClass = (Type) registeredEventClasses[eventType];
			if (eventClass == null)
			{
				logger.info("No event class registered for event type '" + eventType + "', attributes: " + Utils.CollectionToString(attributes));
				return null;
			}
			
			try
			{
				constructor = eventClass.GetConstructor(new Type[]{typeof(object)});
			}
			catch (MethodAccessException ex)
			{
				logger.error("Unable to get constructor of " + eventClass, ex);
				return null;
			}
			
			try
			{
				evt = (Event.ManagerEvent) constructor.Invoke(new object[]{source});
			}
			catch (Exception ex)
			{
				logger.error("Unable to create new instance of " + eventClass, ex);
				return null;
			}
			
			setAttributes(evt, attributes);
			
			// ResponseEvents are sent in response to a ManagerAction if the
			// response contains lots of data. They include the actionId of
			// the corresponding ManagerAction.
			if (evt is Event.ResponseEvent)
			{
				Event.ResponseEvent responseEvent;
				string actionId;
				
				responseEvent = (Event.ResponseEvent) evt;
				actionId = responseEvent.ActionId;
				if (actionId != null)
				{
					responseEvent.ActionId = Utils.StripInternalActionId(actionId);
					responseEvent.InternalActionId = Utils.GetInternalActionId(actionId);
				}
			}
			
			return evt;
		}
		#endregion

		#region registerBuiltinEventClasses()
		private void registerBuiltinEventClasses()
		{
			RegisterEventClass(typeof(Event.AgentCallbackLoginEvent));
			RegisterEventClass(typeof(Event.AgentCallbackLogoffEvent));
			RegisterEventClass(typeof(Event.AgentCalledEvent));
			RegisterEventClass(typeof(Event.AgentConnectEvent));
			RegisterEventClass(typeof(Event.AgentCompleteEvent));
			RegisterEventClass(typeof(Event.AgentDumpEvent));
			RegisterEventClass(typeof(Event.AgentLoginEvent));
			RegisterEventClass(typeof(Event.AgentLogoffEvent));
			RegisterEventClass(typeof(Event.AgentsEvent));
			RegisterEventClass(typeof(Event.AgentsCompleteEvent));
			RegisterEventClass(typeof(Event.AlarmEvent));
			RegisterEventClass(typeof(Event.AlarmClearEvent));
			RegisterEventClass(typeof(Event.CdrEvent));
			RegisterEventClass(typeof(Event.DBGetResponseEvent));
			RegisterEventClass(typeof(Event.DialEvent));
			RegisterEventClass(typeof(Event.DNDStateEvent));
			RegisterEventClass(typeof(Event.ExtensionStatusEvent));
			RegisterEventClass(typeof(Event.FaxReceivedEvent));
			RegisterEventClass(typeof(Event.HangupEvent));
			RegisterEventClass(typeof(Event.HoldedCallEvent));
			RegisterEventClass(typeof(Event.HoldEvent));
			RegisterEventClass(typeof(Event.JoinEvent));
			RegisterEventClass(typeof(Event.LeaveEvent));
			RegisterEventClass(typeof(Event.LinkEvent));
			RegisterEventClass(typeof(Event.LogChannelEvent));
			RegisterEventClass(typeof(Event.MeetMeJoinEvent));
			RegisterEventClass(typeof(Event.MeetMeLeaveEvent));
			RegisterEventClass(typeof(Event.MessageWaitingEvent));
			RegisterEventClass(typeof(Event.NewCallerIdEvent));
			RegisterEventClass(typeof(Event.NewChannelEvent));
			RegisterEventClass(typeof(Event.NewExtenEvent));
			RegisterEventClass(typeof(Event.NewStateEvent));
			RegisterEventClass(typeof(Event.OriginateFailureEvent));
			RegisterEventClass(typeof(Event.OriginateSuccessEvent));
			RegisterEventClass(typeof(Event.ParkedCallGiveUpEvent));
			RegisterEventClass(typeof(Event.ParkedCallEvent));
			RegisterEventClass(typeof(Event.ParkedCallTimeOutEvent));
			RegisterEventClass(typeof(Event.ParkedCallsCompleteEvent));
			RegisterEventClass(typeof(Event.PeerEntryEvent));
			RegisterEventClass(typeof(Event.PeerlistCompleteEvent));
			RegisterEventClass(typeof(Event.PeerStatusEvent));
			RegisterEventClass(typeof(Event.QueueEntryEvent));
			RegisterEventClass(typeof(Event.QueueMemberAddedEvent));
			RegisterEventClass(typeof(Event.QueueMemberEvent));
			RegisterEventClass(typeof(Event.QueueMemberPausedEvent));
			RegisterEventClass(typeof(Event.QueueMemberRemovedEvent));
			RegisterEventClass(typeof(Event.QueueMemberStatusEvent));
			RegisterEventClass(typeof(Event.QueueParamsEvent));
			RegisterEventClass(typeof(Event.QueueStatusCompleteEvent));
			RegisterEventClass(typeof(Event.RegistryEvent));
			RegisterEventClass(typeof(Event.ReloadEvent));
			RegisterEventClass(typeof(Event.RenameEvent));
			RegisterEventClass(typeof(Event.ShutdownEvent));
			RegisterEventClass(typeof(Event.StatusEvent));
			RegisterEventClass(typeof(Event.StatusCompleteEvent));
			RegisterEventClass(typeof(Event.UnholdEvent));
			RegisterEventClass(typeof(Event.UnlinkEvent));
			RegisterEventClass(typeof(Event.UnparkedCallEvent));
			RegisterEventClass(typeof(Event.ZapShowChannelsEvent));
			RegisterEventClass(typeof(Event.ZapShowChannelsCompleteEvent));
		}
		#endregion
		#region setAttributes(Event.ManagerEvent evt, IDictionary attributes)
		private void  setAttributes(Event.ManagerEvent e, IDictionary attributes)
		{
			Type dataType;
			MethodInfo setter;
			IDictionary setters = getSetters(e.GetType());
			object val;

			foreach (string name in attributes.Keys)
			{
				if (name == "event")
					continue;
				if (name == "source")
					setter = (MethodInfo)setters["src"];
				else
					setter = (MethodInfo)setters[stripIllegalCharacters(name)];

				if (setter == null)
				{
					logger.error("Unable to set property '" + name + "' on " + e.GetType() + ": no setter");
					continue;
				}
				dataType = (setter.GetParameters()[0]).ParameterType;
				if (dataType == typeof(bool))
					val = Utils.IsTrue((string)attributes[name]);
				else if (dataType.IsAssignableFrom(typeof(string)))
					val = attributes[name];
				else if (dataType == typeof(Int32))
					val = Convert.ToInt32(attributes[name]);
				else if (dataType == typeof(Int64))
					val = Convert.ToInt64(attributes[name]);
				else if (dataType == typeof(double))
					val = Convert.ToDouble(attributes[name], Utils.CultureInfoEn);
				else
				{
					try
					{
						ConstructorInfo constructor = dataType.GetConstructor(new Type[] { typeof(string) });
						val = constructor.Invoke(new object[] { attributes[name] });
					}
					catch (Exception ex)
					{
						logger.error("Unable to convert value '" + attributes[name] + "' of property '" + name + "' on " + e.GetType() + " to required type " + dataType, ex);
						continue;
					}
				}
				try
				{
					setter.Invoke(e, new object[] { val });
				}
				catch (Exception ex)
				{
					logger.error("Unable to set property '" + name + "' on " + e.GetType(), ex);
					continue;
				}
			}
		}
		#endregion
		#region stripIllegalCharacters(string s)
		/// <summary>
		/// Strips all illegal charaters from the given lower case string.
		/// </summary>
		/// <param name="s">the original string</param>
		/// <returns>the string with all illegal characters stripped</returns>
		private string stripIllegalCharacters(string s)
		{
			char c;
			bool needsStrip = false;
			
			if (s == null)
				return null;
			
			for (int i = 0; i < s.Length; i++)
			{
				c = s[i];
				if (c >= '0' && c <= '9')
					continue;
				else if (c >= 'a' && c <= 'z')
					continue;
				else if (c >= 'A' && c <= 'Z')
					continue;
				else
				{
					needsStrip = true;
					break;
				}
			}
			
			if (!needsStrip)
				return s;
			
			StringBuilder sb = new StringBuilder(s.Length);
			for (int i = 0; i < s.Length; i++)
			{
				c = s[i];
				if (c >= '0' && c <= '9')
					sb.Append(c);
				else if (c >= 'a' && c <= 'z')
					sb.Append(c);
				else if (c >= 'A' && c <= 'Z')
					sb.Append(c);
			}
			
			return sb.ToString();
		}
		#endregion
		#region getSetters(Type clazz)
		/// <summary>
		/// Returns a Map of setter methods of the given class.<br/>
		/// The key of the map contains the name of the attribute that can be accessed by the setter, the
		/// value the setter itself. A method is considered a setter if its name starts with "set",
		/// it is declared public and takes no arguments.
		/// </summary>
		/// <param name="clazz">the class to return the setters for</param>
		/// <returns> a Map of attributes and their accessor methods (setters)</returns>
		private IDictionary getSetters(Type clazz)
		{
			IDictionary accessors = new Hashtable();
			MethodInfo[] methods = clazz.GetMethods();
			string name;
			string methodName;
			MethodInfo method;

			for (int i = 0; i < methods.Length; i++)
			{
				method = methods[i];
				methodName = method.Name;
				// skip not "set..." methods and  skip methods with != 1 parameters
				if (!methodName.StartsWith("set_") || method.GetParameters().Length != 1)
					continue;
				name = methodName.Substring("set_".Length).ToLower();
				if (name.Length == 0) continue;
				accessors[name] = method;
			}
			return accessors;
		}
		#endregion
	}
}
