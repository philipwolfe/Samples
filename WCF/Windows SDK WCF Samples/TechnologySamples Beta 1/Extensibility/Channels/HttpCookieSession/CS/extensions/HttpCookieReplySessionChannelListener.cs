
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

#region using

using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Collections.Generic;
using System.Collections;
using System.Net;
using System.Threading;

#endregion

namespace Microsoft.ServiceModel.Samples
{
    /// <summary>
    /// This class implements the session channel listener.    
    /// </summary>
    class HttpCookieReplySessionChannelListener : 
        ChannelManagerBase, IChannelListener<IReplySessionChannel>
    {
        #region Private Fields

        // Reference to the inner channel listener.
        private IChannelListener<IReplyChannel> innerChannelListener;

        // Dictionary object used to keep track of session
        // channels by its session id.
        private Dictionary<string, IReplySessionChannel> channelsStore;

        // Newly created channels are queued on this queue.
        private Queue<IReplySessionChannel> channelsQueue;

        // A lock for this object should be acquired before
        // accessing the channels queue.
        private object channelsQueueLock = new object();

        // A lock for this object should be acquired before
        // accessing the channels store.
        private object channelsStoreLock = new object();

        // The wait object used to notify when the new 
        // channels are ready to be picked.
        private ManualResetEvent newChannelEnqueued;

        // Reference to the channel created by inner 
        // channel listner.
        private IReplyChannel innerChannel;

        // Session timeout.
        private TimeSpan sessionTimeout;

        // Indicates whether the terminate message is 
        // exchanged when the client closes the request channel.
        private bool exchangeTerminateMessage;                          

        #endregion

        #region Constructor

        /// <summary>
        /// Creates an instance of HttpCoookieReplySessionChannelListener 
        /// class.
        /// </summary>
        /// <param name="innerChannelListener">
        /// A reference to the inner channel listener object.
        /// </param>
        /// <param name="sessionTimeout">
        /// Value specifying the session timeout.
        /// </param>
        /// <param name="exchangeTerminateMessage">
        /// Flag which indicates whether the terminate message 
        /// is exchanged when the client closes the request 
        /// channel.
        /// </param>
        public HttpCookieReplySessionChannelListener
            (IChannelListener<IReplyChannel> innerChannelListener, 
            TimeSpan sessionTimeout, 
            bool exchangeTerminateMessage)
        {            
            if (innerChannelListener == null)
            {
                throw new ArgumentNullException("innerChannelListener");
            }

            this.innerChannelListener = innerChannelListener;
            this.sessionTimeout = sessionTimeout;
            this.exchangeTerminateMessage = exchangeTerminateMessage;
            
            channelsStore = new Dictionary<string, IReplySessionChannel>(32);
            channelsQueue = new Queue<IReplySessionChannel>(32);
            newChannelEnqueued = new ManualResetEvent(false);
            innerChannel = null;  
          
            // Subscribe to the inner channel listener's "Opened" event.            
            innerChannelListener.Opened += 
                new EventHandler(innerChannelListener_Opened);            
        }
        
        #endregion       

        #region Communication Object Overrides

        protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
        {
            throw new NotImplementedException(ResourceHelper.GetString("NotImplementedException"));
        }

        protected override void OnEndOpen(IAsyncResult result)
        {
            throw new NotImplementedException(ResourceHelper.GetString("NotImplementedException"));
        }

        /// <summary>
        /// Performs the actions that need to be taken before 
        /// the communication object's state changes to 
        /// "Opened".
        /// </summary>        
        protected override void OnOpen(TimeSpan timeout)
        {
            TimerHelper timerHelper = new TimerHelper(timeout);
            this.innerChannelListener.Open(timerHelper.RemainingTime());  
            TraceHelper.WriteDebugMessage(
                ResourceHelper.GetString("ListenerOpened"));
        }

        /// <summary>
        /// Performs the actions that need to be taken while 
        /// communication object is preparing to close.
        /// </summary>
        protected override void OnClosing()
        {
            TraceHelper.WriteDebugMessage(
                ResourceHelper.GetString("ListenerClosing"));
            base.OnClosing();

            // Let channel-accepting-thread continue 
            // (which calls the AcceptChannel method) 
            // and fail; by signaling this wait object.
            newChannelEnqueued.Set(); 
        }

        protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
        {
            throw new NotImplementedException(ResourceHelper.GetString("NotImplementedException"));
        }

        protected override void OnEndClose(IAsyncResult result)
        {
            throw new NotImplementedException(ResourceHelper.GetString("NotImplementedException"));
        }

        /// <summary>
        /// Performs the actions that need to be taken when
        /// the communication object is closed. 
        /// </summary>        
        protected override void OnClose(TimeSpan timeout)
        {
            TimerHelper timerHelper = new TimerHelper(timeout);
            innerChannel.Close(timeout);
            
            this.innerChannelListener.Close(
                timerHelper.RemainingTime());
                        
            TraceHelper.WriteDebugMessage(
                ResourceHelper.GetString("ListenerClosing"));
        }

        /// <summary>
        /// Performs the actions that need to be taken 
        /// when the communication object is aborted.
        /// </summary>
        protected override void OnAbort()
        {
            this.innerChannelListener.Abort();
            
            TraceHelper.WriteDebugMessage(
                ResourceHelper.GetString("ListenerAborted"));
        }
        
        /// <summary>
        /// Gets the default close timeout for this 
        /// communicatoin object.
        /// Q: Should I try to read these values from the 
        ///    config file?
        /// </summary>
        protected override TimeSpan DefaultCloseTimeout
        {
            get { return TimeSpan.FromMinutes(1); }
        }

        /// <summary>
        /// Gets the default open timeout for this 
        /// communicatoin object.
        /// </summary>
        protected override TimeSpan DefaultOpenTimeout
        {
            get { return TimeSpan.FromMinutes(1); }
        }

        /// <summary>
        /// Gets the default receive timeout for this 
        /// communicatoin object.
        /// </summary>
        protected override TimeSpan DefaultReceiveTimeout
        {
            get { return this.sessionTimeout; }
        }

        /// <summary>
        /// Gets the default send timeout for this 
        /// communicatoin object.
        /// </summary>
        protected override TimeSpan DefaultSendTimeout
        {
            get { return TimeSpan.FromMinutes(1); }
        }


        #endregion

        #region IChannelListener<IReplySessionChannel> Members

        #region Properties

        /// <summary>
        /// Gets or sets the inner channel listener.
        /// </summary>
        public IChannelListener InnerChannelListener
        {
            get
            {
                return this.innerChannelListener;
            }
            set
            {
                // Throw if the communication object 
                // is disposed or immutable.
                ThrowIfDisposedOrImmutable();   
                
                this.innerChannelListener = 
                    (IChannelListener<IReplyChannel>)value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Accept the channels synchronously. 
        /// Q: When do upper channels call this method?
        /// </summary>
        public IReplySessionChannel AcceptChannel(
            TimeSpan timeout)
        {
            ThrowIfDisposedOrNotOpen();
            return DequeueChannel();
        }

        /// <summary>
        /// Accept the channels synchronously with the 
        /// default timeout.
        /// Q: When do upper channels call this method?
        /// </summary>        
        public IReplySessionChannel AcceptChannel()
        {
            return AcceptChannel(DefaultReceiveTimeout);
        }

        /// <summary>
        /// Starts accepting channels asynchronously. 
        /// </summary>        
        public IAsyncResult BeginAcceptChannel(TimeSpan timeout, 
            AsyncCallback callback, object state)
        {
            TraceHelper.WriteDebugMessage(
                ResourceHelper.GetString("BeginAcceptChannel"));
            ThrowIfDisposedOrNotOpen();     
       
            AsyncMethodResult requestState = 
                new AsyncMethodResult(callback, state);
            
            requestState.AdditionalData = timeout;
            
            ThreadPool.QueueUserWorkItem(
                new WaitCallback(StartDequeueChannel), 
                requestState);
            
            return requestState;
        }

        /// <summary>
        /// Starts accepting channels asynchronously and 
        /// with the default timeout. 
        /// Q: When do upper channels call this overloaded 
        /// method?
        /// </summary>        
        public IAsyncResult BeginAcceptChannel(
            AsyncCallback callback, object state)
        {            
            return BeginAcceptChannel(
                DefaultReceiveTimeout, callback, state);
        }

        /// <summary>
        /// Ends the call to BeginAcceptChannel and returns 
        /// the results.
        /// </summary>
        public IReplySessionChannel EndAcceptChannel(
            IAsyncResult result)
        {
            TraceHelper.WriteDebugMessage(
                ResourceHelper.GetString("EndAcceptChannel"));
            AsyncMethodResult requestState = (AsyncMethodResult)result;

            // Verify that we have a session channel to 
            // return. This is stored in the Additional data 
            // field of the async state object. Presence 
            // of null in this field means, the async read 
            // operation was unable to acquire a channel. 
            // This might be a consequence of closing the 
            // communication object while there is a pending 
            // async method call to AcceptChannel.
            if (requestState.AdditionalData == null)
            {
                TraceHelper.WriteDebugMessage(
                    ResourceHelper.GetString("EndAcceptChannelReturnsNull"));
                return null;
            }

            ThrowIfDisposedOrNotOpen();
            
            TraceHelper.WriteDebugMessage(
                ResourceHelper.GetString("EndAcceptChannelReturnsOK"));
            
            IReplySessionChannel replySessionChannel = 
                (IReplySessionChannel)requestState.AdditionalData;            
            
            return replySessionChannel;
        }
        
        #endregion

        #endregion

        #region IChannelListener Members

        /// <summary>
        /// This method is not implemented because this was 
        /// not called by upper channels. 
        /// Q: When do upper channels call this method?
        /// </summary>
        public IAsyncResult BeginWaitForChannel(
            TimeSpan timeout, AsyncCallback callback, 
            object state)
        {
            throw new NotImplementedException(ResourceHelper.GetString("NotImplementedException"));
        }

        /// <summary>
        /// Gets the channel type listened by 
        /// this channel listener.
        /// </summary>
        public Type ChannelType
        {
            get { return typeof(IInputSessionChannel); }
        }

        /// <summary>
        /// This method is not implemented because this was 
        /// not called by upper channels. 
        /// Q: When do upper channels call this method?
        /// </summary>        
        public bool EndWaitForChannel(IAsyncResult result)
        {
            throw new NotImplementedException(ResourceHelper.GetString("NotImplementedException"));
        }

        /// <summary>
        /// Gets the identity.
        /// Q: Please explain this.
        /// </summary>
        //public Identity Identity
        //{
        //    get { return this.innerChannelListener.Identity; }
        //}

        /// <summary>
        /// Sets a unique uri for the listener.
        /// </summary>
        public Uri Uri
        {
            get { return this.innerChannelListener.Uri; }
        }

        /// <summary>
        /// This method is not implemented because this was 
        /// not called by upper channels. 
        /// Q: When do upper channels call this method?
        /// </summary>        
        public bool WaitForChannel(TimeSpan timeout)
        {
            throw new NotImplementedException(
                ResourceHelper.GetString("NotImplementedException"));
        }

        T IChannelListener.GetProperty<T>()
        {
            return innerChannelListener.GetProperty<T>();
        }

        #endregion

        #region Public Memebers

        /// <summary>
        /// Removes the channel specified by session id 
        /// from the channel store (the dictionary). 
        /// </summary>
        /// <remarks>
        /// This method is called by the session channels
        /// from their OnClosed override.
        /// </remarks>
        public void RemoveChannel(string sessionId)
        {
            lock (channelsStoreLock)
            {
                channelsStore.Remove(sessionId);

                TraceHelper.WriteDebugMessage(
                    string.Format(ResourceHelper.GetString("RemoveChannel"),
                        sessionId.ToString()));
            }
        }

        #endregion

        #region Helper Members
        
        /// <summary>
        /// Accepts the IReplyChannel from the inner 
        /// channel listener and starts pumping the 
        /// messages from it.
        /// </summary>
        void StartMessagePump()
        {
            TraceHelper.WriteDebugMessage(
                ResourceHelper.GetString("MessagePumpStarted"));
            
            innerChannel = innerChannelListener.AcceptChannel();            
            innerChannel.Open();
                
            IAsyncResult result = 
                innerChannel.BeginTryReceiveRequest(
                TimeSpan.MaxValue, new AsyncCallback(OnRequestReceived), 
                null);
            
            if (result.CompletedSynchronously)
            {
                ContinueReceiving();
            }
        }        

        /// <summary>
        /// Continues the asynchronous receive method.
        /// </summary>
        void ContinueReceiving()
        {           
            Start:   
            IAsyncResult result = 
                innerChannel.BeginTryReceiveRequest(
                    TimeSpan.MaxValue, 
                    new AsyncCallback(OnRequestReceived), 
                    null); 
            
            if (result.CompletedSynchronously)
            {
                goto Start;
            }           
        }

        /// <summary>
        /// This callback function is called when there is 
        /// a request lined up in the inner channel. This 
        /// procedure obtains a reference to the incoming 
        /// request and deligates the processing to the 
        /// thread pool.
        /// </summary>        
        void OnRequestReceived(IAsyncResult result)
        {            
            RequestContext receivedRequest = null;
            
            bool isRequestAvailable = 
                innerChannel.EndTryReceiveRequest(
                    result, out receivedRequest);
            
            if (isRequestAvailable && receivedRequest != null)
            {
                TraceHelper.WriteDebugMessage(
                    ResourceHelper.GetString("RequestReceived"));
                
                ThreadPool.QueueUserWorkItem(
                    new WaitCallback(Dispatch), receivedRequest);

                if (!result.CompletedSynchronously)
                {
                    ContinueReceiving();
                }
            }
            else
            {
                TraceHelper.WriteDebugMessage(
                    ResourceHelper.GetString("QuitReceiving"));
            }
        }       

        /// <summary>
        /// Processes the incoming message and routes it 
        /// to the approprite session channel. 
        /// If there is no channel associated with this 
        /// session id (or if the http cookie has no data), 
        /// this procedure creates a new session channel.
        /// </summary>        
        void Dispatch(object data)
        {            
            // Try to read the cookie value from http 
            // request headers collection.
            RequestContext request = (RequestContext)data;
            
            string httpRequestKey = ResourceHelper.GetString(
                    "httpRequestProperties");

            Message requestMessage = request.RequestMessage;            
            
            HttpRequestMessageProperty httpRequest =
                (HttpRequestMessageProperty)
                requestMessage.Properties[httpRequestKey];
            
            string sessionID = httpRequest.Headers[HttpRequestHeader.Cookie];
           
            // Nobody else can add/remove channels to the 
            // channel store untill we are done.
            lock (channelsStoreLock)
            {                
                if (sessionID != null && 
                    channelsStore.ContainsKey(sessionID))
                {
                    HttpCookieReplySessionChannel replySession =
                        (HttpCookieReplySessionChannel)channelsStore[sessionID];

                    // If both ends are WCF ends, this channel is capable 
                    // of exchanging a message, when the client closes the request 
                    // channel. Consequently the server is able to clean up the 
                    // session channel in real-time fashion.
                    if (exchangeTerminateMessage)
                    {
                        if (requestMessage.Headers.Action == 
                            ResourceHelper.GetString("TerminateRequestAction"))
                        {
                            // Send the terminate ack to the client.
                            SendTerminateAck(request);

                            // Close the session channel by force.
                            replySession.ForceShutDown();   

                            return;
                        }
                    }

                    HttpCookieSessionRequestContext requestContext =
                        new HttpCookieSessionRequestContext(request, replySession);

                    // Enqueue the current request the to session 
                    // channel's message queue.
                    replySession.Enqueue(requestContext);   
                }
                else
                {
                    // No session is found in our channel store. 
                    // So we are going to avoid any changes to this communication 
                    // object untill we create a new channel. This also implies 
                    // that we create the new channel only if the 
                    // communication object is in opened state.                    
                    lock (ThisLock) 
                    {
                        if (State == CommunicationState.Opened)
                        {
                            HttpCookieReplySessionChannel replySession =
                                new HttpCookieReplySessionChannel(
                                    this, innerChannel.LocalAddress, 
                                    sessionTimeout);

                            HttpCookieSessionRequestContext requestContext =
                                new HttpCookieSessionRequestContext(
                                request, replySession, true);

                            // Add a new entry in the channel store.
                            channelsStore.Add(replySession.Session.Id, 
                                replySession);

                            // Enqueue the new channel so that threads waiting
                            // in the AcceptChannel method can pick them up.
                            EnqueueChannel(replySession);

                            // Enqueue the request to the session 
                            // channel's message queue.
                            replySession.Enqueue(requestContext);   
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Enqueues a newly created session channels in the 
        /// local channels queue. Consequently the threads 
        /// waiting on the AcceptChannel can accept them.
        /// </summary>        
        void EnqueueChannel(IReplySessionChannel replySessionChannel)
        {
            lock (channelsQueueLock)
            {
                channelsQueue.Enqueue(replySessionChannel);
                newChannelEnqueued.Set();

                TraceHelper.WriteDebugMessage(
                    ResourceHelper.GetString("SessionReady"));
            }
        }

        /// <summary>
        /// This method dequeues and returns a 
        /// channel from the local channels queue.
        /// </summary>        
        IReplySessionChannel DequeueChannel()
        {            
            Start:
            
            // Wait until the wait object is signaled. 
            bool signaled = newChannelEnqueued.WaitOne(-1, true);

            // Make sure the communication object is opened.
            lock (ThisLock)
            {
                if (State != CommunicationState.Opened)
                {
                    TraceHelper.WriteDebugMessage(
                        ResourceHelper.GetString(
                            "DequeueFailedListenerNotOpen"));
                    
                    return null;
                }
            }

            lock (channelsQueueLock)
            {
                try
                {
                    IReplySessionChannel replySessionChannel = 
                        channelsQueue.Dequeue();                    
                    
                    return replySessionChannel;
                }
                catch (InvalidOperationException)
                {                    
                    goto Start;
                }
                finally
                {
                    if (channelsQueue.Count == 0)
                    {
                        // If there are no channels, reset 
                        // the wait object to non-signaled state.
                        newChannelEnqueued.Reset(); 
                    }
                }
            }                        
        }

        /// <summary>
        /// This callbak method is used to deligate 
        /// the DequeueChannel call to a different thread.
        /// </summary>        
        void StartDequeueChannel(object state)
        {
            AsyncMethodResult requestState = (AsyncMethodResult)state;            
            
            IReplySessionChannel replySessionChannel = DequeueChannel();
            
            requestState.AdditionalData = replySessionChannel;
            requestState.SetCompleted(true);
            
            if (requestState.Callback != null)
            {
                requestState.Callback(requestState);
            }
        }

        /// <summary>
        /// This event is fired by the inner channel 
        /// listener when its state changes to Opened. 
        /// Use this place to start the message pump.
        /// </summary>        
        void innerChannelListener_Opened(object sender, 
            EventArgs args)
        {            
            StartMessagePump();
        }

        /// <summary>
        /// Sends the terminate ack to the client being 
        /// closed.
        /// </summary>        
        void SendTerminateAck(RequestContext request)
        {
            Message terminateAck = Message.CreateMessage(request.RequestMessage.Version,
               ResourceHelper.GetString("TerminateAck"),
               "");

            // Add this custom header since the action header,
            // is lost while the transmission. 
            // I think this happens because 
            // MapAddressingHeadersToHttpHeaders is set to 
            // true in the underlaying HttpTransport.
            MessageHeader ackHeader = MessageHeader.CreateHeader("TerminateAck",
                ResourceHelper.GetString("TerminateAck"),
                "",
                true);

            terminateAck.Headers.Add(ackHeader);
            request.Reply(terminateAck);
        }
        
        #endregion

    }
}
