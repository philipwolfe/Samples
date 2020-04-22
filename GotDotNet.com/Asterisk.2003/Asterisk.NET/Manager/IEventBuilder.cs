using System;
using System.Collections;

namespace Asterisk.NET.Manager
{
	/// <summary>
	/// Transforms maps of attributes to instances of ManagerEvent.
	/// </summary>
	/// <seealso cref="Manager.Event.ManagerEvent" />
	public interface IEventBuilder
	{
		/// <summary>
		/// Registers a new event class. The event this class is registered for is simply derived from
		/// the name of the class by stripping any package name (if present) and stripping the sufffix
		/// "Event". For example <code>Manager.Event.JoinEvent</code> is registered for
		/// the event "Join".
		/// </summary>
		/// <param name="clazz">the event class to register, must extend Manager.event.Event.</param>
		void  RegisterEventClass(Type clazz);
		/// <summary>
		/// Builds the event based on the given map of attributes and the registered event classes.
		/// </summary>
		/// <param name="source">source attribute for the event</param>
		/// <param name="attributes">map containing event attributes</param>
		/// <returns>a concrete instance of ManagerEvent or <code>null</code> if no event class was registered for the event type.</returns>
		Event.ManagerEvent BuildEvent(object source, IDictionary attributes);
	}
}