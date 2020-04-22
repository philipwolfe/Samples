using System;

namespace Asterisk.NET.Manager.Event
{
	public class VIPCallEvent : UserEvent
	{
		private string firstName;
		// Constructor
		public VIPCallEvent()
		{
		}
		// Property
		public string FirstName
		{
			get { return this.firstName; }
			set { this.firstName = value; }
		}
	}

	/// <summary>
	/// Abstract base class for user events.<br/>
	/// You can send arbitrary user events via the UserEvent application provided with asterisk.
	/// A user event by default has the attributes channel and uniqueId but you can add custom
	/// attributes by specifying an event body.<br/>
	/// To add your own user events you must subclass this class and name it corresponding to your event.<br/>
	/// If you plan to send an event by <code>UserEvent(VIPCall)</code> you will create a new class
	/// called VIPCallEvent that extends UserEvent. The name of this class is important: Just use the
	/// name of the event you will send (VIPCall in this example) and append "Event".<br/> 
	/// To pass additional data create appropriate attributes with getter and setter methods in your new class.<br/>
	/// Example:
	/// <pre>
	 /// public class VIPCallEvent : UserEvent
	 /// {
	/// 	 private string firstName;
	/// 	 // Constructor
	/// 	 public VIPCallEvent()
	/// 	 {
	/// 	 }
	/// 	 // Property
	/// 	 public string FirstName
	/// 	 {
	/// 		 get { return this.firstName; }
	/// 		 set { this.firstName = value; }
	/// 	 }
	 ///  }
	 /// </pre>
	/// To send this event use <code>UserEvent(VIPCall|firstName: Jon)</code> in your dialplan.<br/>
	/// The UserEvent is implemented in <code>apps/app_userevent.c</code>.<br/>
	/// Note that you must register your UserEvent with the ManagerConnection you are using in order to be recognized.
	/// </summary>
	/// <seealso cref="Manager.ManagerConnection.RegisterUserEventClass(Type userEventClass)"/>
	public abstract class UserEvent : ManagerEvent
	{
		private string channel;
		private string uniqueId;

		/// <summary>
		/// Get/Set the name of the channel this event occured in.
		/// </summary>
		virtual public string Channel
		{
			get { return channel; }
			set { this.channel = value; }
		}
		/// <summary>
		/// Get/Set the unqiue id of the channel this event occured in.
		/// </summary>
		virtual public string UniqueId
		{
			get { return uniqueId; }
			set { this.uniqueId = value; }
		}
		
		public UserEvent()
			: base()
		{
		}
	}
}