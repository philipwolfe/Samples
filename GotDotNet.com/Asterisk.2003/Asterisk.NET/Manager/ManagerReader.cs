using System;
using System.IO;
using System.Collections;

namespace Asterisk.NET.Manager
{
	
	/// <summary>
	/// Default implementation of the ManagerReader interface.
	/// </summary>
	public class ManagerReader
	{
		/// <summary> Instance logger.</summary>
		private Util.ILog logger;
		/// <summary> The event builder utility to convert a map of attributes reveived from asterisk to instances of registered event classes.</summary>
		private EventBuilder eventBuilder;
		/// <summary> The response builder utility to convert a map of attributes reveived from asterisk to instances of well known response classes.</summary>
		private ResponseBuilder responseBuilder;
		/// <summary> The dispatcher to use for dispatching events and responses.</summary>
		private IDispatcher dispatcher;
		/// <summary> The asterisk server we are reading from.</summary>
		private AsteriskServer asteriskServer;
		/// <summary> The socket to use for reading from the asterisk server.</summary>
		private IO.SocketConnection socket;
		/// <summary> If set to <code>true</code>, terminates and closes the reader.</summary>
		private bool die = false;

		#region ManagerReader(dispatcher, asteriskServer)
		/// <summary>
		/// Creates a new ManagerReader.
		/// </summary>
		/// <param name="dispatcher">the dispatcher to use for dispatching events and responses.</param>
		public ManagerReader(IDispatcher dispatcher, AsteriskServer asteriskServer)
		{
			logger = Util.LogFactory.getLog(GetType());

			this.dispatcher = dispatcher;
			this.asteriskServer = asteriskServer;

			this.eventBuilder = new EventBuilder();
			this.responseBuilder = new ResponseBuilder();
		}
		#endregion

		#region Socket
		/// <summary>
		/// Sets the socket to use for reading from the asterisk server.
		/// </summary>
		virtual public IO.SocketConnection Socket
		{
			set
			{
				lock (this)
				{
					this.socket = value;
				}
			}
		}
		#endregion

		#region RegisterEventClass(class)
		public virtual void RegisterEventClass(Type eventClass)
		{
			eventBuilder.RegisterEventClass(eventClass);
		}
		#endregion

		#region Run()
		/// <summary>
		/// Reads line by line from the asterisk server, sets the protocol identifier as soon as it is
		/// received and dispatches the received events and responses via the associated dispatcher.
		/// </summary>
		/// <seealso cref="ManagerConnection.DispatchEvent(Event.ManagerEvent)" />
		/// <seealso cref="ManagerConnection.DispatchResponse(Response.ManagerResponse)" />
		/// <seealso cref="ManagerConnection.setProtocolIdentifier(String)" />
		public void  Run()
		{
			IDictionary buffer = new Hashtable();
			IList commandResult = new ArrayList();
			string line;
			bool processingCommandResult = false;
			int delimiterIndex;

			if (this.socket == null)
				throw new SystemException("Unable to run: socket is null.");

			this.die = false;

			try
			{
				while ((line = this.socket.ReadLine()) != null && !this.die)
				{
					line = line.Trim();

					// Check to processing CommandResult
					if (processingCommandResult)
					{
						if (line == "--END COMMAND--")
						{
							Response.CommandResponse commandResponse = new Response.CommandResponse();
							string[] crNVPair;
							for (int crIdx = 0; crIdx < commandResult.Count; crIdx++)
							{
								crNVPair = ((string)commandResult[crIdx]).Split(new char[]{':'}, 2);
								if (crNVPair.Length < 2) continue;
								// "ActionId : ..." and "Privilege : ..." must be first in commandResult
								if (crNVPair[0].ToLower() == "actionid")
								{
									commandResult.RemoveAt(crIdx--);
									commandResponse.ActionId = crNVPair[1].Trim();
								}
								else if (crNVPair[0].ToLower() == "privilege")
									commandResult.RemoveAt(crIdx--);
								else
								{
									// other result pair name, so we're now in the command results.  Stop processing the nv pairs.
									break;
								}
							}
							commandResponse.Response = "Follows";
							commandResponse.DateReceived = Utils.Date;
							commandResponse.Result = commandResult;
							IDictionary attributes = new Hashtable();
							attributes["actionid"] = commandResponse.ActionId;
							attributes["response"] = commandResponse.Response;
							commandResponse.Attributes = attributes;
							dispatcher.DispatchResponse(commandResponse);
							processingCommandResult = false;
						}
						else
							commandResult.Add(line);
						continue;
					}

					// Reponse: Follows indicates that the output starting on the next line until
					// --END COMMAND-- must be treated as raw output of a command executed by a
					// CommandAction.
					if (line.Trim().ToLower() == "response: follows")
					{
						processingCommandResult = true;
						commandResult.Clear();
						continue;
					}

					// Check to protocol identifier
					if (line.StartsWith("Asterisk Call Manager/"))
					{
						Event.ConnectEvent connectEvent = new Event.ConnectEvent(asteriskServer);
						connectEvent.ProtocolIdentifier = line;
						connectEvent.DateReceived = Utils.Date;
						dispatcher.DispatchEvent(connectEvent);
						continue;
					}

					// an empty line indicates a normal response's or event's end so we build
					// the corresponding value object and dispatch it through the ManagerConnection.
					if (line.Length == 0)
					{
						if (buffer.Contains("response"))
						{
							Response.ManagerResponse response = buildResponse(buffer);
							logger.debug("Attempting to build response");
							if (response != null)
								dispatcher.DispatchResponse(response);
						}
						else if (buffer.Contains("event"))
						{
							logger.debug("Attempting to build event: " + buffer["event"].ToString());
							Event.ManagerEvent evt = buildEvent(asteriskServer, buffer);
							if (evt != null)
								dispatcher.DispatchEvent(evt);
							else
								logger.debug("BuildEvent returned null");
						}
						else if (buffer.Count > 0)
							logger.debug("Buffer contains neither response nor event");

						buffer.Clear();
					}
					else
					{
						delimiterIndex = line.IndexOf(":");
						if (delimiterIndex > 0 && line.Length > delimiterIndex + 2)
						{
							string name = line.Substring(0, delimiterIndex).ToLower().Trim();
							string val = line.Substring(delimiterIndex + 2).Trim();
							buffer[name] = val;
							logger.debug("Got name [" + name + "], value: [" + val + "]");
						}
					}
				}
				logger.info("Reached end of stream, terminating reader.");
			}
			catch (IOException e)
			{
				logger.info("IOException while reading from asterisk server, terminating reader thread: " + e.Message);
			}
			// cleans resources and reconnects if needed
			Event.DisconnectEvent disconnectEvent = new Event.DisconnectEvent(asteriskServer);
			disconnectEvent.DateReceived = Utils.Date;
			dispatcher.DispatchEvent(disconnectEvent);
		}
		#endregion

		#region Die
		public virtual void Die()
		{
			this.die = true;
		}
		#endregion

		#region buildResponse(buffer)
		private Response.ManagerResponse buildResponse(IDictionary buffer)
		{
			Response.ManagerResponse response = responseBuilder.BuildResponse(buffer);
			if (response != null)
				response.DateReceived = Utils.Date;
			return response;
		}
		#endregion
		#region buildEvent(source, buffer)
		private Event.ManagerEvent buildEvent(object source, IDictionary buffer)
		{
			Event.ManagerEvent evt = eventBuilder.BuildEvent(source, buffer);
			if (evt != null)
				evt.DateReceived = Utils.Date;
			return evt;
		}
		#endregion
	}
}
