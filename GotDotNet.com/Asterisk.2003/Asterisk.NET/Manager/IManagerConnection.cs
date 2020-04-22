using System;
using Asterisk.NET.Manager.Action;
using Asterisk.NET.Manager.Response;

namespace Asterisk.NET.Manager
{
	/// <summary>
	/// The main interface to talk to an Asterisk server via the Asterisk Manager API.<br/>
	/// The ManagerConnection repesents a connection to an Asterisk Server and is
	/// capable to send Actions and receive Responses and Events. It does not add any
	/// valuable functionality but rather provides a Java view to Asterisk's Manager
	/// API (freeing you from TCP/IP connection and parsing stuff).<br/>
	/// It is used as the foundation for higher leveled interfaces like the
	/// AsteriskManager.<br/>
	/// A concrete implementation of this interface can be obtained from a
	/// ManagerConnectionFactory.
	/// </summary>
	/// <seealso cref="Manager.ManagerConnectionFactory" />
	public interface IManagerConnection
	{
        event ManagerConnectionEventHandler Events;

		/// <summary>
		/// The timeout to use when connecting the the Asterisk server.<br/>
		/// Default is 0, that is using Java's built-in default.
		/// </summary>
  		int SocketTimeout
		{
			get;
			set;
		}

		/// <summary>
		/// Returns the Asterisk server of this connection.
		/// </summary>
		AsteriskServer AsteriskServer
		{
			get;
		}
		/// <summary>
		/// Registers a new user event type.<br/>
		/// Asterisk allows you to send custom events via the UserEvent application.
		/// If you choose to send such events you can extend the abstract class
		/// UserEvent provide a name for your new event and optionally add your own
		/// attributes. After registering a user event type Asterisk-Java will handle
		/// such events the same way it handles the internal events and inform your
		/// registered event handlers.<br/>
		/// Note: If you write your own Asterisk applications that use Asterisk's
		/// <code>manager_event()</code> function directly and don't use the
		/// channel and uniqueid attributes provided by UserEvent you can also
		/// register events that directly subclass ManagerEvent.
		/// </summary>
		/// <seealso cref="Asterisk.NET.Manager.Event.UserEvent" />
		/// <seealso cref="Event.ManagerEvent" />
		/// <param name="userEventClass">the class of the user event to register.</param>
		void  RegisterUserEventClass(Type userEventClass);
		
		/// <summary>
		///  Logs in to the Asterisk server with the username and password specified
		/// when this connection was created.
		/// </summary>
		/// <throws>  IOException if the network connection is disrupted. </throws>
		/// <throws> AuthenticationFailedException if the username and/or password are incorrect or the ChallengeResponse could not be built.</throws>
		/// <throws>
		///  TimeoutException if no response is received within the default timeout period. If the implementation uses challenge/response
		/// this can either be a timeout of the ChallengeAction or the LoginAction; otherwise it is always a timeout of the LoginAction.
		/// </summary>
		/// <seealso cref="Manager.Action.LoginAction" />
		/// <seealso cref="Manager.Action.ChallengeAction" />
		void  Login();
		
		/// <summary>
		/// Sends a LogoffAction to the Asterisk server and disconnects.
		/// </summary>
		/// <throws>  IOException if the network connection is disrupted. </throws>
		/// <throws> TimeoutException if no response to the logoff action is received within the default timeout period.</throws>
		/// <seealso cref="Manager.Action.LogoffAction" />
		void  Logoff();
		
		/// <summary>
        /// Returns the protocol identifier, i.e. a string like "Asterisk Call Manager/1.0".
		/// </summary>
		/// <returns>
        /// the protocol identifier of the Asterisk Manager Interface in use if it has already been received; <code>null</code> otherwise
        /// </returns>
		string GetProtocolIdentifier();
		
		/// <summary>
        /// Sends a ManagerAction to the Asterisk server and waits for the corresponding ManagerResponse.
		/// </summary>
		/// <param name="action">the action to send to the Asterisk server</param>
		/// <returns> the corresponding response received from the Asterisk server
		/// </returns>
		/// <throws>  IOException if the network connection is disrupted. </throws>
		/// <throws> TimeoutException if no response is received within the default timeout period.</throws>
		/// <throws>  IllegalArgumentException if the action is <code>null</code>. </throws>
		/// <throws> IllegalStateException if you are not connected to an Asterisk server.</throws>
		/// <seealso cref="SendAction(Action.IManagerAction, long)" />
		/// <seealso cref="SendAction(Action.IManagerAction, IManagerResponseHandler)" />
		ManagerResponse SendAction(IManagerAction action);
		
		/// <summary>
		/// Sends a ManagerAction to the Asterisk server and waits for the corresponding ManagerResponse.
		/// </summary>
		/// <param name="action">the action to send to the Asterisk server</param>
		/// <param name="timeout">milliseconds to wait for the response before throwing a TimeoutException</param>
		/// <returns> the corresponding response received from the Asterisk server</returns>
		/// <throws>  IOException if the network connection is disrupted. </throws>
		/// <throws> TimeoutException if no response is received within the given timeout period.</throws>
		/// <throws>  IllegalArgumentException if the action is <code>null</code>. </throws>
		/// <throws> IllegalStateException if you are not connected to an Asterisk server.</throws>
		/// <seealso cref="SendAction(Action.IManagerAction, IManagerResponseHandler)" />
		ManagerResponse SendAction(IManagerAction action, long timeout);
		
		/// <summary>
		/// Sends a ManagerAction to the Asterisk server and registers a callback
		/// handler to be called when the corresponding ManagerResponse is received.
		/// </summary>
		/// <param name="action">the action to send to the Asterisk server</param>
		/// <param name="callbackHandler">the callback handler to call when the response is
		/// received or <code>null</code> if you are not interested in the response
		/// </param>
		/// <throws>  IOException if the network connection is disrupted. </throws>
		/// <throws>  IllegalArgumentException if the action is <code>null</code>. </throws>
		/// <throws> IllegalStateException if you are not connected to an Asterisk server. </throws>
		void  SendAction(IManagerAction action, IManagerResponseHandler callbackHandler);
		
		/// <summary>
		/// Sends a EventGeneratingAction to the Asterisk server and waits for the
		/// corresponding ManagerResponse and the ResponseEvents.<br/>
		/// EventGeneratingActions are ManagerActions that don't return their
		/// response in the corresponding ManagerResponse but send a series of events
		/// that contain the payload.<br/>
		/// Examples for EventGeneratingActions are the Manager.Action.StatusAction, the
		/// Manager.Action.QueueAction or the Manager.Action.AgentsAction.
		/// </summary>
		/// <param name="action">the action to send to the Asterisk server</param>
		/// <returns>
		/// a ResponseEvents that contains the corresponding response and
		/// response events received from the Asterisk server
		/// </returns>
		/// <throws>IOException if the network connection is disrupted. </throws>
		/// <throws>
		/// EventTimeoutException if no response or not all response events are 
		/// received within the given timeout period.
		/// </throws>
		/// <throws>
		/// IllegalArgumentException if the action is <code>null</code>,
		/// the actionCompleteEventClass property of the action is <code>null</code>
		/// or if actionCompleteEventClass is not a ResponseEvent.
		/// </throws>
		/// <throws>IllegalStateException if you are not connected to an Asterisk server.</throws>
		/// <seealso cref="Action.IEventGeneratingAction" />
		/// <seealso cref="Event.ResponseEvent"/>
		IResponseEvents SendEventGeneratingAction(IEventGeneratingAction action);
		
		/// <summary>
		/// Sends a EventGeneratingAction to the Asterisk server and waits for the
		/// corresponding ManagerResponse and the ResponseEvents.
		/// EventGeneratingActions are ManagerActions that don't return their
		/// response in the corresponding ManagerResponse but send a series of events
		/// that contain the payload.<br/>
		/// Examples for EventGeneratingActions are the StatusAction, the
		/// QueueAction or the AgentsAction.
		/// </summary>
		/// <param name="action">the action to send to the Asterisk server</param>
		/// <param name="timeout">milliseconds to wait for the response and the response events before throwing a TimeoutException</param>
		/// <returns> a ResponseEvents that contains the corresponding response and response events received from the Asterisk server</returns>
		/// <throws>  IOException if the network connection is disrupted. </throws>
		/// <throws>  EventTimeoutException if no response or not all response events are received within the given timeout period.</throws>
		/// <throws>  IllegalArgumentException if the action is <code>null</code>, the actionCompleteEventClass property of the action is
		/// <code>null</code> or if actionCompleteEventClass is not a ResponseEvent.
		/// </throws>
		/// <throws>  IllegalStateException if you are not connected to an Asterisk server.</throws>
		/// <seealso cref="Action.IEventGeneratingAction" />
		/// <seealso cref="Event.ResponseEvent" />
		IResponseEvents SendEventGeneratingAction(IEventGeneratingAction action, long timeout);
		
		/// <summary>
		/// Checks if the connection to the Asterisk server is established.
		/// </summary>
		/// <returns><code>true</code> if the connection is established, <code>false</code> otherwise.</returns>
		bool IsConnected();
	}
}
