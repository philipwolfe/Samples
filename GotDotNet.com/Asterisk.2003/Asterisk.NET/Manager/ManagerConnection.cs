using System;
using System.IO;
using System.Threading;
using System.Collections;
using Asterisk.NET.Manager.Action;
using Asterisk.NET.Manager.Event;
using Asterisk.NET.Manager.Response;

namespace Asterisk.NET.Manager
{
	public delegate void  ManagerConnectionEventHandler(Object sender, ManagerEvent ManagerEventHandlerDelegateParam);

    /// <summary>
	/// Default implemention of the ManagerConnection interface.
	/// </summary>
	public class ManagerConnection : IManagerConnection, IDispatcher
	{
		#region Variables
		/// <summary> Instance logger.</summary>
		private Util.ILog logger;
		/// <summary> Used to construct the internalActionId.</summary>
		private long actionIdCount = 0;
		/// <summary> The Asterisk server to connect to.</summary>
		private AsteriskServer asteriskServer;
		/// <summary> The username to use for login as defined in Asterisk's <code>manager.conf</code>.</summary>
		protected internal string username;
		/// <summary> The password to use for login as defined in Asterisk's <code>manager.conf</code>.</summary>
		protected internal string password;
		/// <summary> The default timeout to wait for a ManagerResponse after sending a ManagerAction.</summary>
		private long defaultResponseTimeout = 2000;
		/// <summary> The default timeout to wait for the last ResponseEvent after sending an EventGeneratingAction.</summary>
		private long defaultEventTimeout = 5000;
		/// <summary> The timeout to use when connecting the the Asterisk server.</summary>
	    private int socketTimeout = 0;
		/// <summary>The time the calling thread is sleeping between checking if a reponse or the protocol identifer has been received.</summary>
		private long sleepTime = 50;
		/// <summary> Should we continue to reconnect after an authentication failure?</summary>
		private bool keepAliveAfterAuthenticationFailure = false;
		/// <summary> The socket to use for TCP/IP communication with Asterisk.</summary>
		private IO.SocketConnection socket;
		/// <summary> The thread that runs the reader.</summary>
		private Utils.ThreadClass readerThread;
		/// <summary> The reader to use to receive events and responses from asterisk.</summary>
		private ManagerReader reader;
		/// <summary> The writer to use to send actions to asterisk.</summary>
		private ManagerWriter writer;
		/// <summary> The protocol identifer Asterisk sends on connect.</summary>
		private string protocolIdentifier;
		/// <summary> The version of the Asterisk server we are connected to. </summary>
		private AsteriskVersion targetVersion;
		/// <summary>
		/// Contains the registered handlers that process the ManagerResponses.<br/>
		/// Key is the internalActionId of the Action sent and value the corresponding ResponseHandler.
		/// </summary>
		private IDictionary responseHandlers;
		/// <summary> Contains the event handlers that handle ResponseEvents for the SendEventGeneratingAction methods.<br/>
		/// Key is the internalActionId of the Action sent and value the corresponding EventHandler.
		/// </summary>
		private IDictionary responseEventHandlers;
		/// <summary>Should we attempt to reconnect when the connection is lost?<br/>
		/// This is set to <code>true</code> after successful login and to <code>false</code> after logoff or after an authentication failure when keepAliveAfterAuthenticationFailure is <code>false</code>.
		/// </summary>
		protected internal bool keepAlive = false;
		protected internal bool enableEvents = true;
		#endregion

        #region Events
        public event ManagerConnectionEventHandler Events; ///Handler;
        #endregion

        #region Constructor - ManagerConnection()
        /// <summary> Creates a new instance.</summary>
		public ManagerConnection()
		{
			logger = Util.LogFactory.getLog(GetType());
			this.asteriskServer = new AsteriskServer();

			this.responseHandlers = new Hashtable();
			this.responseEventHandlers = new Hashtable();
			// this.eventHandlers = new ArrayList();
		}
		#endregion
		#region Constructor - ManagerConnection(hostname, port, username, password)
		/// <summary>
		/// Creates a new instance with the given connection parameters.
		/// </summary>
		/// <param name="hostname">the hosname of the Asterisk server to connect to.</param>
		/// <param name="port">the port where Asterisk listens for incoming Manager API connections, usually 5038.</param>
		/// <param name="username">the username to use for login</param>
		/// <param name="password">the password to use for login</param>
		public ManagerConnection(string hostname, int port, string username, string password)
			: this()
		{

			Hostname = hostname;
			Port = port;
			Username = username;
			Password = password;
		}
		#endregion

		#region Hostname
		/// <summary> Sets the hostname of the asterisk server to connect to.<br/>
		/// Default is <code>localhost</code>.
		/// </summary>
		virtual public string Hostname
		{
			set { this.asteriskServer.Hostname = value; }
		}
		#endregion
		#region Port
		/// <summary>
		/// Sets the port to use to connect to the asterisk server. This is the port
		/// specified in asterisk's <code>manager.conf</code> file.<br/>
		/// Default is 5038.
		/// </summary>
		virtual public int Port
		{
			set { this.asteriskServer.Port = value; }
		}
		#endregion
		#region UserName
		/// <summary>
		/// Sets the username to use to connect to the asterisk server. This is the
		/// username specified in asterisk's <code>manager.conf</code> file.
		/// </summary>
		public virtual string Username
		{
			set { this.username = value; }
		}
		#endregion
		#region Password
		/// <summary>
		/// Sets the password to use to connect to the asterisk server. This is the
		/// password specified in asterisk's <code>manager.conf</code> file.
		/// </summary>
		public virtual string Password
		{
			set { this.password = value; }
		}
		#endregion
		#region DefaultTimeout
		/// <summary> Sets the time in milliseconds the synchronous SendAction methods
		/// <see cref="SendAction(Action.IManagerAction)"/> will wait for a response before
		/// throwing a TimeoutException.<br/>
		/// Default is 2000.
		/// </summary>
		virtual public long DefaultTimeout
		{
			set { DefaultResponseTimeout = value; }
		}
		#endregion
		#region DefaultResponseTimeout
		/// <summary> Sets the time in milliseconds the synchronous method
		/// <see cref="SendAction(Action.IManagerAction)"/> will wait for a response before
		/// throwing a TimeoutException.<br/>
		/// Default is 2000.
		/// </summary>
		virtual public long DefaultResponseTimeout
		{
			set { this.defaultResponseTimeout = value; }
		}
		#endregion
		#region DefaultEventTimeout
		/// <summary> Sets the time in milliseconds the synchronous method
		/// <see cref="SendEventGeneratingAction(Action.IEventGeneratingAction)"/> will wait for a
		/// response and the last response event before throwing a TimeoutException.<br/>
		/// Default is 5000.
		/// </summary>
		virtual public long DefaultEventTimeout
		{
			set { this.defaultEventTimeout = value; }
		}
		#endregion
		#region SleepTime
		/// <summary> Sets the time in milliseconds the synchronous methods
		///SendAction(Action.ManagerAction) and
		/// SendAction(Action.ManagerAction, long) will sleep between two checks
		/// for the arrival of a response. This value should be rather small.<br/>
		/// The sleepTime attribute is also used when checking for the protocol
		/// identifer.<br/>
		/// Default is 50.
		/// </summary>
		/// <deprecated> this has been replaced by an interrupt based response checking approach.</deprecated>
		virtual public long SleepTime
		{
			set { this.sleepTime = value; }
		}
		#endregion
		#region KeepAliveAfterAuthenticationFailure
		/// <summary> Set to <code>true</code> to try reconnecting to ther asterisk serve
		/// even if the reconnection attempt threw an AuthenticationFailedException.<br/>
		/// Default is <code>false</code>.
		/// </summary>
		virtual public bool KeepAliveAfterAuthenticationFailure
		{
			set { this.keepAliveAfterAuthenticationFailure = value; }
		}
		#endregion
		#region AsteriskServer
		virtual public AsteriskServer AsteriskServer
		{
			get { return asteriskServer; }
		}
		#endregion
		#region SocketTimeout
		/// <summary>
		/// The timeout to use when connecting the the Asterisk server.
		/// </summary>
		virtual public int SocketTimeout
		{
			get { return this.socketTimeout; }
			set { this.socketTimeout = value; }
		}
		#endregion

		/*
		#region EnableEvents
		/// <summary>
		/// Get/Set enable translate events to external handler(s).
		/// </summary>
		virtual public bool EnableEvents
		{
			get { return this.enableEvents; }
			set { this.enableEvents = value; }
		}
		#endregion
		*/

		#region login(timeout)
		/// <summary>
		/// Does the real login, following the steps outlined below.<br/>
		/// Connects to the asterisk server by calling connect() if not already connected<br/>
		/// Waits until the protocol identifier is received. This is checked every sleepTime ms but not longer than timeout ms in total.<br/>
		/// Sends a ChallengeAction requesting a challenge for authType MD5.<br/>
		/// When the ChallengeResponse is received a LoginAction is sent using the calculated key (MD5 hash of the password appended to the received challenge).<br/>
		/// </summary>
		/// <param name="timeout">the maximum time to wait for the protocol identifier (in ms)</param>
		/// <throws>
		/// AuthenticationFailedException if username or password are incorrect and the login action returns an error or if the MD5
		/// hash cannot be computed. The connection is closed in this case.
		/// </throws>
		/// <throws>
		/// TimeoutException if a timeout occurs either while waiting for the
		/// protocol identifier or when sending the challenge or login
		/// action. The connection is closed in this case.
		/// </throws>
		private void login(long timeout)
		{
			enableEvents = false;

			if (socket == null)
				connect();

			long timeSpent, start = (DateTime.Now.Ticks - Utils.DateTime01011970) / 10000;
			while (GetProtocolIdentifier() == null)
			{
				try
				{
					Thread.Sleep(new TimeSpan((long)10000 * sleepTime));
				}
				catch (ThreadInterruptedException)
				{ }

				timeSpent = (DateTime.Now.Ticks - Utils.DateTime01011970) / 10000 - start;
				if (GetProtocolIdentifier() == null)
				{
					if (timeout > 0 && timeSpent > timeout)
					{
						disconnect();
						throw new TimeoutException("Timeout waiting for protocol identifier");
					}
				}
			}

			ChallengeAction challengeAction = new ChallengeAction("MD5");
			ChallengeResponse challengeResponse = (ChallengeResponse)SendAction(challengeAction);
			string key, challenge = challengeResponse.Challenge;
			try
			{
				Utils.MessageDigestSupport md = Utils.MessageDigestSupport.GetInstance("MD5");
				if (challenge != null)
					md.Update(Utils.ToByteArray(challenge));
				if (password != null)
					md.Update(Utils.ToByteArray(password));
				key = Utils.ToHexString(md.DigestData());
			}
			catch (Exception ex)
			{
				disconnect();
				throw new AuthenticationFailedException("Unable to create login key using MD5 Message Digest", ex);
			}

			Action.LoginAction loginAction = new Action.LoginAction(username, "MD5", key);
			Response.ManagerResponse loginResponse = SendAction(loginAction);
			if (loginResponse is Response.ManagerError)
			{
				disconnect();
				throw new AuthenticationFailedException(loginResponse.Message);
			}

			// successfully logged in so assure that we keep trying to reconnect when disconnected
			this.keepAlive = true;

			logger.info("Successfully logged in");
			this.targetVersion = determineVersion();
			this.writer.TargetVersion = targetVersion;
			logger.info("Determined Asterisk version: " + targetVersion);
			enableEvents = true;
		}
		#endregion
		#region determineVersion()
		protected internal virtual AsteriskVersion determineVersion()
		{
			Response.ManagerResponse showVersionFilesResponse = SendAction(new Action.CommandAction("show version files"));
			if (showVersionFilesResponse is Response.CommandResponse)
			{
				IList showVersionFilesResult = ((Response.CommandResponse)showVersionFilesResponse).Result;
				if (showVersionFilesResult != null && showVersionFilesResult.Count > 0)
				{
					string line1;
					line1 = (string)showVersionFilesResult[0]; 
					if (line1 != null && line1.StartsWith("File"))
						return AsteriskVersion.ASTERISK_1_2;
				}
			}
			return AsteriskVersion.ASTERISK_1_0;
		}

		#endregion
		#region connect()
		protected internal virtual void connect()
		{
			lock (this)
			{
				logger.info("Connecting to " + asteriskServer.Hostname + " port " + asteriskServer.Port);
				if(this.socket == null)
					this.socket = new IO.SocketConnection(asteriskServer.Hostname, asteriskServer.Port, socketTimeout);

				if (this.reader == null)
					this.reader = new ManagerReader(this, AsteriskServer);
                this.reader.Socket = socket;

				if (this.writer == null)
					this.writer = new ManagerWriter();
				this.writer.Socket = socket;

				this.readerThread = new Utils.ThreadClass(new ThreadStart(this.reader.Run), "ManagerReader");
				this.readerThread.Start();
			}
		}
		#endregion
		#region reconnect()
		/// <summary>
		/// Reconnects to the asterisk server when the connection is lost.<br/>
		/// While keepAlive is <code>true</code> we will try to reconnect.
		/// Reconnection attempts will be stopped when the logoff() method
		/// is called or when the login after a successful reconnect results in an
		/// AuthenticationFailedException suggesting that the manager
		/// credentials have changed and keepAliveAfterAuthenticationFailure is not set.<br/>
		/// This method is called when a DisconnectEvent is received from the reader.
		/// </summary>
		private void reconnect()
		{
			int numTries;

			// clean up at first
			disconnect();

			// try to reconnect
			numTries = 0;
			while (this.keepAlive)
			{
				try
				{
					if (numTries < 10)
					{
						// try to reconnect quite fast for the firt 10 times
						// this succeeds if the server has just been restarted
						Thread.Sleep(new TimeSpan((long)10000 * 50));
					}
					else
					{
						// slow down after 10 unsuccessful attempts asuming a shutdown of the server
						Thread.Sleep(new TimeSpan((long)10000 * 5000));
					}
				}
				catch (ThreadInterruptedException)
				{
					// it's ok to wake us
				}

				try
				{
					connect();
					try
					{
						Login();
						logger.info("Successfully reconnected.");
						// everything is ok again, so we leave
						break;
					}
					catch (AuthenticationFailedException)
					{
						if (this.keepAliveAfterAuthenticationFailure)
							logger.error("Unable to log in after reconnect.");
						else
						{
							logger.error("Unable to log in after reconnect. " + "Giving up.");
							this.keepAlive = false;
						}
					}
					catch (TimeoutException)
					{
						// shouldn't happen
						logger.error("TimeoutException while trying to log in " + "after reconnect.");
						lock (this)
						{
							socket.Close();
						}
					}
				}
				catch (IOException ex)
				{
					// server seems to be still down, just continue to attempt reconnection
					logger.warn("Exception while trying to reconnect: " + ex.Message);
				}
				numTries++;
			}
		}
		#endregion
		#region disconnect()
		/// <summary> Closes the socket connection.</summary>
		private void  disconnect()
		{
			lock (this)
			{
				if (this.reader != null)
					this.reader.Die();
				if (this.socket != null)
				{
					logger.info("Closing socket.");
					try
					{
						this.socket.Close();
					}
					catch (IOException ex)
					{
						logger.warn("Unable to close socket: " + ex.Message);
					}
					this.socket = null;
				}
			}
		}
		#endregion
		#region setProtocolIdentifier
		/// <summary>
		/// This method is called when a <see cref="ConnectEvent"/>ConnectEvent is received from the reader.
		/// Having received a correct protocol identifier is the precodition for logging in.
		/// </summary>
		/// <param name="protocolIdentifier">the protocol version used by the Asterisk server.</param>
		private void  setProtocolIdentifier(string protocolIdentifier)
		{
			logger.info("Connected via " + protocolIdentifier);
			if (protocolIdentifier != "Asterisk Call Manager/1.0")
				logger.warn("Unsupported protocol version '" + protocolIdentifier + "'. Use at your own risk.");
			this.protocolIdentifier = protocolIdentifier;
		}
		#endregion
		#region createInternalActionId()
		/// <summary>
		/// Creates a new unique internal action id based on the hash code of this connection and a sequence.
		/// </summary>
		private string createInternalActionId()
		{
			return this.GetHashCode() + "_" + (this.actionIdCount++);
		}
		#endregion

		#region Login()
		/// <summary>
		/// Logs in to the asterisk manager using asterisk's MD5 based
		/// challenge/response protocol. The login is delayed until the protocol
		/// identifier has been received by the reader.
		/// </summary>
		/// <throws>  AuthenticationFailedException if the username and/or password are incorrect</throws>
		/// <throws>  TimeoutException if no response is received within the specified timeout period</throws>
		/// <seealso cref="Action.ChallengeAction"/>
		/// <seealso cref="Action.LoginAction"/>
		public virtual void Login()
		{
			login(defaultResponseTimeout);
		}
		#endregion
		#region IsConnected()
		/// <summary> Returns <code>true</code> if there is a socket connection to the
		/// asterisk server, <code>false</code> otherwise.
		/// 
		/// </summary>
		/// <returns> <code>true</code> if there is a socket connection to the
		/// asterisk server, <code>false</code> otherwise.
		/// </returns>
		public virtual bool IsConnected()
		{
			lock (this)
			{
				return socket != null && socket.IsConnected;	// 2005
				// return socket != null;						// 2003
			}
		}
		#endregion
		#region Logoff()
		/// <summary>
		/// Sends a LogoffAction and disconnects from the server.
		/// </summary>
		public virtual void Logoff()
		{
			lock (this)
			{
				// stop reconnecting when we got disconnected
				this.keepAlive = false;
				if (socket != null)
				{
					SendAction(new Action.LogoffAction());
					disconnect();
				}
			}
		}
		#endregion

		#region SendAction(action)
		public virtual Response.ManagerResponse SendAction(Action.IManagerAction action)
		{
			return SendAction(action, defaultResponseTimeout);
		}
		#endregion
		#region SendAction(action, timeout)
		public virtual Response.ManagerResponse SendAction(Action.IManagerAction action, long timeout)
		{
			long start;
			long timeSpent;
			ResponseHandlerResult result = new ResponseHandlerResult(this);
			IManagerResponseHandler callbackHandler = new ResponseHandler(this, result, Utils.ThreadClass.Current());

			SendAction(action, callbackHandler);

			start = (DateTime.Now.Ticks - Utils.DateTime01011970) / 10000;
			timeSpent = 0;
			while (result.Response == null)
			{
				try
				{
					if (timeout > 0)
						Thread.Sleep(new TimeSpan((long)10000 * (timeout - timeSpent)));
					else
						Thread.Sleep(new TimeSpan((long)10000 * (5000)));
				}
				catch (ThreadInterruptedException)
				{}

				timeSpent = (DateTime.Now.Ticks - Utils.DateTime01011970) / 10000 - start;
				if (result.Response == null)
				{
					if(timeout > 0  && timeSpent > timeout)
						throw new TimeoutException("Timeout waiting for response to " + action.Action);
				}
			}

			return result.Response;
		}
		#endregion
		#region SendAction(action, callbackHandler)
		public virtual void  SendAction(Action.IManagerAction action, IManagerResponseHandler callbackHandler)
		{
			string internalActionId;

			if (action == null)
				throw new ArgumentException("Unable to send action: action is null.");
			
			if (socket == null)
				throw new SystemException("Unable to send " + action.Action + " action: not connected.");
			
			internalActionId = createInternalActionId();
			action.ActionId = Utils.AddInternalActionId(action.ActionId, internalActionId);
			
			// if the callbackHandler is null the user is obviously not interested in the response, thats fine.
			if (callbackHandler != null)
			{
				lock (this.responseHandlers)
				{
					this.responseHandlers[internalActionId] = callbackHandler;
				}
			}
			writer.SendAction(action);
		}
		#endregion

		#region SendEventGeneratingAction(action)
		public virtual IResponseEvents SendEventGeneratingAction(Action.IEventGeneratingAction action)
		{
			return SendEventGeneratingAction(action, defaultEventTimeout);
		}
		#endregion
		#region SendEventGeneratingAction(action, timeout)
		public virtual IResponseEvents SendEventGeneratingAction(Action.IEventGeneratingAction action, long timeout)
		{
			if (action == null)
				throw new ArgumentException("Unable to send action: action is null.");
			else if (action.ActionCompleteEventClass == null)
				throw new ArgumentException("Unable to send action: ActionCompleteEventClass is null.");
			else if (!typeof(ResponseEvent).IsAssignableFrom(action.ActionCompleteEventClass))
				throw new ArgumentException("Unable to send action: ActionCompleteEventClass is not a ResponseEvent.");
			
			if (socket == null)
				throw new SystemException("Unable to send " + action.Action + " action: not connected.");
			
			ResponseEvents responseEvents = new ResponseEvents();
			ResponseEventHandler responseEventHandler = new ResponseEventHandler(this, responseEvents, action.ActionCompleteEventClass, Utils.ThreadClass.Current());

			string internalActionId = createInternalActionId();
			action.ActionId = Utils.AddInternalActionId(action.ActionId, internalActionId);

			// register response handler...
			lock (this.responseHandlers)
			{
				this.responseHandlers[internalActionId] = responseEventHandler;
			}

			// ...and event handler.
			lock (this.responseEventHandlers)
			{
				this.responseEventHandlers[internalActionId] = responseEventHandler;
			}

			writer.SendAction(action);
			
			// let's wait to see what we get
			long start = (DateTime.Now.Ticks - Utils.DateTime01011970) / 10000;
			long timeSpent = 0;
			while (responseEvents.Response == null || !responseEvents.Complete)
			{
				try
				{
					if(timeout > 0)
						Thread.Sleep(new TimeSpan((long) 10000 * (timeout - timeSpent)));
					else
						Thread.Sleep(new TimeSpan((long)10000 * (5000)));
				}
				catch (ThreadInterruptedException)
				{}
				
				// still no response or not all events received and timed out?
				timeSpent = (DateTime.Now.Ticks - Utils.DateTime01011970) / 10000 - start;
				if ((responseEvents.Response == null || !responseEvents.Complete))
				{
					if (timeout > 0 && timeSpent > timeout)
					{
						// clean up
						lock (this.responseEventHandlers)
						{
							this.responseEventHandlers.Remove(internalActionId);
						}
						throw new EventTimeoutException("Timeout waiting for response or response events to " + action.Action, responseEvents);
					}
				}
			}
			
			// remove the event handler (note: the response handler is removed
			// automatically when the response is received)
			lock (this.responseEventHandlers)
			{
				this.responseEventHandlers.Remove(internalActionId);
			}
			
			return responseEvents;
		}
		#endregion

        #region GetProtocolIdentifier()
        public virtual string GetProtocolIdentifier()
		{
			return this.protocolIdentifier;
		}
		#endregion

		#region RegisterUserEventClass(class)
		/// <summary>
		/// Register User Event Class
		/// </summary>
		/// <param name="userEventClass"></param>
		public virtual void  RegisterUserEventClass(Type userEventClass)
		{
			if (this.reader == null)
				this.reader = new ManagerReader(this, AsteriskServer);
			this.reader.RegisterEventClass(userEventClass);
		}
		#endregion

		#region DispatchResponse(response)
		/// <summary>
		/// This method is called by the reader whenever a ManagerResponse is
		/// received. The response is dispatched to the associated <see cref="IManagerResponseHandler"/>ManagerResponseHandler.
		/// </summary>
		/// <param name="response">the response received by the reader</param>
		/// <seealso cref="ManagerReader" />
		public virtual void  DispatchResponse(ManagerResponse response)
		{
			// shouldn't happen
			if (response == null)
			{
				logger.error("Unable to dispatch null response");
				return ;
			}
			string actionId = response.ActionId;
			string internalActionId = Utils.GetInternalActionId(actionId);
			response.ActionId = Utils.StripInternalActionId(actionId);

			if (internalActionId == null)
			{
				logger.error("Unable to retrieve internalActionId from response: " + "actionId '" + actionId + "':\n" + response);
				return;
			}

			logger.debug("Dispatching response with internalActionId '" + internalActionId + "':\n" + response);

			IManagerResponseHandler responseHandler = null;
			lock (responseHandlers)
			{
				responseHandler = (IManagerResponseHandler)this.responseHandlers[internalActionId];
				if (responseHandler != null)
					responseHandlers.Remove(internalActionId);
				else
				{
					// when using the async SendAction it's ok not to register a
					// callback so if we don't find a response handler thats ok
					logger.debug("No response handler registered for " + "internalActionId '" + internalActionId + "'");
				}
			}
			if (responseHandler != null)
			{
				try
				{
					responseHandler.HandleResponse(response);
				}
				catch (SystemException e)
				{
					logger.warn("Unexpected exception in responseHandler " + responseHandler.GetType().FullName, e);
				}
			}
		}
		#endregion

		#region DispatchEvent(ManagerEvent e)
		/// <summary>
		/// This method is called by the reader whenever a ManagerEvent is received.
		/// The event is dispatched to all registered ManagerEventHandlers.
		/// </summary>
		/// <param name="e">the event received by the reader</param>
		/// <seealso cref="ManagerReader"/>
		public virtual void  DispatchEvent(ManagerEvent e)
		{
			// shouldn't happen
			if (e == null)
			{
				logger.error("Unable to dispatch null event");
				return ;
			}

			logger.debug("Dispatching event:\n" + e.ToString());

			// dispatch ResponseEvents to the appropriate responseEventHandler
			if (e is ResponseEvent)
			{
				ResponseEvent responseEvent = (ResponseEvent)e; ;
				string internalActionId = responseEvent.InternalActionId;
				if (internalActionId != null)
				{
					lock (responseEventHandlers.SyncRoot)
					{
						IManagerEventHandler eventHandler = (IManagerEventHandler)responseEventHandlers[internalActionId];
						if (eventHandler != null)
						{
							try
							{
								eventHandler.HandleEvent(e);
							}
							catch (SystemException ex)
							{
								logger.warn("Unexpected exception in eventHandler " + eventHandler.GetType().FullName, ex);
							}
						}
					}
				}
				else
					logger.error("Unable to handle ResponseEvent without " + "internalActionId:\n" + responseEvent);
			}

			if (e is ConnectEvent)
				setProtocolIdentifier(((ConnectEvent)e).ProtocolIdentifier);

			if(enableEvents && Events != null)
				Events(this, e);

			if (e is DisconnectEvent)
				reconnect();
			if (e is ReloadEvent)
				reconnect();
		}
		#endregion

		#region Class - ResponseHandlerResult
		/// <summary>
		/// A simple data object to store a ManagerResult.
		/// </summary>
		public class ResponseHandlerResult
		{
			private ManagerConnection enclosingInstance;
			virtual public Response.ManagerResponse Response
			{
				get { return this.response; }
				set { this.response = value; }
			}
			public ManagerConnection Enclosing_Instance
			{
				get
				{
					return enclosingInstance;
				}
				
			}
			private Response.ManagerResponse response;
			
			public ResponseHandlerResult(ManagerConnection enclosingInstance)
			{
				this.enclosingInstance = enclosingInstance;
			}
		}
		#endregion
		#region Class - ResponseHandler
		/// <summary>
		/// A simple response handler that stores the received response in a ResponseHandlerResult for further processing.
		/// </summary>
		private class ResponseHandler : IManagerResponseHandler
		{
			private ManagerConnection enclosingInstance;
			private ResponseHandlerResult result;
			private Utils.ThreadClass thread;

			public ManagerConnection Enclosing_Instance
			{
				get { return enclosingInstance; }
			}
			
			/// <summary>
			/// Creates a new instance.
			/// </summary>
			/// <param name="result">the result to store the response in</param>
			/// <param name="thread">the thread to interrupt when the response has been received</param>
			public ResponseHandler(ManagerConnection enclosingInstance, ResponseHandlerResult result, Utils.ThreadClass thread)
			{
				this.enclosingInstance = enclosingInstance;
				this.result = result;
				this.thread = thread;
			}
			
			public virtual void  HandleResponse(Response.ManagerResponse response)
			{
				result.Response = response;
				thread.Interrupt();
			}
		}
		#endregion
		#region Class - ResponseEventHandler
		/// <summary>
		/// A combinded event and response handler that adds received events and the response to a ResponseEvents object.
		/// </summary>
		private class ResponseEventHandler : IManagerEventHandler, IManagerResponseHandler
		{
			private ResponseEvents events;
			private Type actionCompleteEventClass;
			private Utils.ThreadClass thread;

			private ManagerConnection enclosingInstance;
			public ManagerConnection Enclosing_Instance
			{
				get { return enclosingInstance; }
			}
			/// <summary>
			/// Creates a new instance.
			/// </summary>
			/// <param name="events">the ResponseEventsImpl to store the events in</param>
			/// <param name="actionCompleteEventClass">the type of event that indicates that all events have been received</param>
			/// <param name="thread">the thread to interrupt when the actionCompleteEventClass has been received</param>
			public ResponseEventHandler(
				ManagerConnection enclosingInstance,
				ResponseEvents events,
				Type actionCompleteEventClass,
				Utils.ThreadClass thread)
			{
				this.enclosingInstance = enclosingInstance;
				this.events = events;
				this.actionCompleteEventClass = actionCompleteEventClass;
				this.thread = thread;
			}
			
			public virtual void  HandleEvent(ManagerEvent e)
			{
				// should always be a ResponseEvent, anyway...
				if (e is ResponseEvent)
				{
					ResponseEvent responseEvent;
					
					responseEvent = (ResponseEvent) e;
					events.AddEvent(responseEvent);
				}
				
				// finished?
				if (actionCompleteEventClass.IsAssignableFrom(e.GetType()))
				{
					lock (events)
					{
						events.Complete = true;
						if (events.Response != null)
						{
							thread.Interrupt();
						}
					}
				}
			}
			
			public virtual void  HandleResponse(Response.ManagerResponse response)
			{
				lock (events)
				{
					events.Repsonse = response;
					if (response is Response.ManagerError)
						events.Complete = true;

					// finished?
					if (events.Complete)
					{
						thread.Interrupt();
					}
				}
			}
		}
		#endregion
	}
}
