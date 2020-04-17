
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

#region using

using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Collections.Generic;
using System.Threading;

#endregion

namespace Microsoft.ServiceModel.Samples
{
    /// <summary>
    /// This class contains session channel implementation.
    /// </summary>
    class HttpCookieReplySessionChannel : ChannelBase, IReplySessionChannel
    {
        #region Private Fields

        // Reference to the parent channel listener.
        private HttpCookieReplySessionChannelListener parent;

        // Reference to the session object created for this channel.
        private HttpCookieReplySession session;
        
        // This is where the incoming requests for this channel are 
        // queued.
        private Queue<RequestContext> requestsQueue;

        // Lock should be acquired on this object before accessing 
        // the request queue.
        private object queueLock = new object();

        // Wait object used for waiting until a request is queued.
        private ManualResetEvent itemEnqueued;

        // Endpoint address used by the channel listener.    
        private EndpointAddress localAddress;

        // Session timeout.
        private TimeSpan sessionTimeout;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates an instance of HttpCookieReplySessionChannel 
        /// class.
        /// </summary>        
        public HttpCookieReplySessionChannel(
            HttpCookieReplySessionChannelListener parent, 
            EndpointAddress localAddress, TimeSpan sessionTimeout) 
            : base((ChannelManagerBase)parent)
        {
            this.parent = parent;
            this.session = new HttpCookieReplySession();
            this.localAddress = localAddress;
            requestsQueue = new Queue<RequestContext>();
            this.sessionTimeout = sessionTimeout;
            itemEnqueued = new ManualResetEvent(false);            
            
            TraceHelper.WriteDebugMessage(
                string.Format(
                    ResourceHelper.GetString("SessionCreatedMessage"), 
                    session.Id));

        }

        #endregion

        #region CommunicationObject overrides
        
        /// <summary>
        /// Performs the actions that should be taken just 
        /// before the channel is closed.
        /// </summary>        
        protected override void OnClose(TimeSpan timeout)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Channel.Close()");
            Console.ForegroundColor = ConsoleColor.Green;

            TraceHelper.WriteDebugMessage(
                string.Format(
                    ResourceHelper.GetString("SessionClosedMessage"), 
                    session.Id));
        }

        /// <summary>
        /// Performs the actions should be taken while 
        /// the channel is starting to close.
        /// </summary>
        protected override void OnClosing()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("OnClosing()");
            Console.ForegroundColor = ConsoleColor.Green;
            base.OnClosing();

            // We call this method here because OnClosing
            // is called even when the Abort is performed.
            parent.RemoveChannel(session.Id);
        }
        
        protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
        {
            throw new NotImplementedException(ResourceHelper.GetString("NotImplementedException"));
        }

        protected override void OnEndClose(IAsyncResult result)
        {
            throw new NotImplementedException(ResourceHelper.GetString("NotImplementedException"));
        }

        protected override void OnOpen(TimeSpan timeout)
        {
        }

        protected override void OnAbort()
        {
            //OnClosing takes cae of removing the channel from the listener            
        }

        protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
        {
            throw new NotImplementedException(ResourceHelper.GetString("NotImplementedException"));
        }

        protected override void OnEndOpen(IAsyncResult result)
        {
            throw new NotImplementedException(ResourceHelper.GetString("NotImplementedException"));
        }

        #endregion

        #region IReplyChannel Members

        /// <summary>
        /// This method is not implemented because this is
        /// not invoked by the upper channels.
        /// Q: When should we implement this?
        /// </summary>        
        public IAsyncResult BeginReceiveRequest(
            TimeSpan timeout, AsyncCallback callback, 
            object state)
        {                        
            throw new NotImplementedException(
                ResourceHelper.GetString("NotImplementedException"));
        }

        /// <summary>
        /// This method is not implemented because this is
        /// not invoked by the upper channels.
        /// Q: When should we implement this?
        /// </summary>        
        public IAsyncResult BeginReceiveRequest(
            AsyncCallback callback, object state)
        {
            throw new NotImplementedException(
                ResourceHelper.GetString("NotImplementedException"));
        }

        /// <summary>
        /// This method is not implemented because this
        /// is not invoked by upper channels.
        /// Q: When should we implement this?
        /// </summary>
        public RequestContext EndReceiveRequest(IAsyncResult result)
        {
            throw new NotImplementedException(
                ResourceHelper.GetString("NotImplementedException"));
        }

        /// <summary>
        /// Starts receiving the requests asynchronously. 
        /// </summary>        
        public IAsyncResult BeginTryReceiveRequest(
            TimeSpan timeout, AsyncCallback callback, 
            object state)
        {
            TraceHelper.WriteDebugMessage(
                string.Format(
                    ResourceHelper.GetString("BeginTryReceiveInvoked"), 
                    session.Id));                            
            
            AsyncMethodResult requestState = 
                new AsyncMethodResult(callback, state);
            
            requestState.AdditionalData = timeout;
            
            ThreadPool.QueueUserWorkItem(
                new WaitCallback(StartTryReceive), requestState);            
            
            return requestState;            
        }

        /// <summary>
        /// Ends the asynchronous receive and return the results.
        /// </summary>
        public bool EndTryReceiveRequest(IAsyncResult result,
            out RequestContext context)
        {
            AsyncMethodResult requestState = (AsyncMethodResult)result;

            // Obtain the results from the async state
            // object.
            TryReceiveRequestResutls resultsStore =
                (TryReceiveRequestResutls)requestState.AdditionalData;

            // Throw if there is an IO error.
            if (resultsStore.Exception != null)
            {
                throw resultsStore.Exception;
            }

            context = resultsStore.RequestContext;
            return resultsStore.ReturnValue;
        }

        /// <summary>
        /// This method is not implemented because this
        /// is not invoked by upper channels.
        /// Q: When should we implement this?
        /// </summary>
        public IAsyncResult BeginWaitForRequest(
            TimeSpan timeout, AsyncCallback callback, 
            object state)
        {
            throw new NotImplementedException(
                ResourceHelper.GetString("NotImplementedException"));
        }
              
        /// <summary>
        /// This method is not implemented because this
        /// is not invoked by upper channels.
        /// Q: When should we implement this?
        /// </summary>
        public bool EndWaitForRequest(IAsyncResult result)
        {
            throw new NotImplementedException(
                ResourceHelper.GetString("NotImplementedException"));
        }

        /// <summary>
        /// Returns the endpoint address used by this 
        /// channel.
        /// </summary>
        public EndpointAddress LocalAddress
        {
            get { return localAddress; }
        }

        /// <summary>
        /// Starts receiving synchronously.        
        /// </summary>        
        public RequestContext ReceiveRequest(TimeSpan timeout)
        {            
            ThrowIfDisposedOrNotOpen();
            RequestContext requestContext = null;

            bool available = TryReceiveRequest(timeout,
                out requestContext);

            if (available)
            {
                return requestContext;
            }

            throw new TimeoutException("Timeout expired");
        }

        /// <summary>
        /// Starts receiving synchronously with 
        /// default timeout value.        
        /// </summary>        
        public RequestContext ReceiveRequest()
        {
            return ReceiveRequest(DefaultReceiveTimeout);
        }

        /// <summary>
        /// Try to receive items synchronously.
        /// </summary>
        /// <returns>
        /// A boolean value indicating whether the 
        /// receiving succeeded or not.
        /// </returns>
        public bool TryReceiveRequest(TimeSpan timeout, 
            out RequestContext context)
        {
            ThrowIfDisposed();

            context = PickItem(timeout);

            if (context != null)
            {
                return true;
            }
            else
            {
                TraceHelper.WriteDebugMessage(
                    string.Format(ResourceHelper.GetString("SessionTimedOut"),
                        session.Id));

                // Session timed out. So tear down this channel.
                ForceShutDown();
                return false;
            }                      
        }

        /// <summary>
        /// This method is not implemented because this
        /// is not invoked by upper channels.
        /// Q: When should we implement this?
        /// </summary>
        public bool WaitForRequest(TimeSpan timeout)
        {
            throw new NotImplementedException(
                ResourceHelper.GetString("NotImplementedException"));
        }

        #endregion
        
        #region ISessionChannel<IInputSession> Members

        /// <summary>
        /// Gets the session object associated with 
        /// this session.
        /// </summary>
        public IInputSession Session
        {
            get { return this.session; }
        }

        #endregion

        #region Public members

        /// <summary>
        /// Enforces the channel shutdown.
        /// </summary>
        public void ForceShutDown()
        {
            // Q: Should we call Fault here?
            // Q: Is this the correct way to shut 
            // down a channel?
            this.Fault();   
            this.Close();
        }

        /// <summary>
        /// Enqueues a new request to this session channel.
        /// </summary>        
        public void Enqueue(RequestContext item)
        {
            // Before enqueueing, we have to verify that 
            // the communication object is still in 
            // the opened or opening state.
            lock (ThisLock)
            {
                if (State != CommunicationState.Closing &&
                    State != CommunicationState.Closed &&
                    State != CommunicationState.Faulted)
                {
                    lock (queueLock)
                    {
                        requestsQueue.Enqueue(item);
                        TraceHelper.WriteDebugMessage(
                            string.Format(
                                ResourceHelper.GetString("MessageEnqueued"), 
                                session.Id));
                        
                        // Notify the threads waiting for a request.
                        itemEnqueued.Set(); 
                    }
                }
                else
                {
                    TraceHelper.WriteDebugMessage(
                        string.Format(
                            ResourceHelper.GetString("EnqueueFailed"), 
                            session.Id));
                }
            }
        }

        #endregion

        #region Helper members

        /// <summary>
        /// Picks up an item from the request queue and 
        /// returns it. This method waits until the itemEnqueued 
        /// object becomes signaled. If it does not become 
        /// signaled within the session timeout period, 
        /// this method returns null.
        /// </summary>        
        RequestContext PickItem(TimeSpan timeout)
        {
            timeout = sessionTimeout;
            TimerHelper timerHelper = new TimerHelper(timeout);

            Start:
            RequestContext item = null;            
            bool signaled = itemEnqueued.WaitOne(timeout, true); 
           
            if (signaled)
            {                
                lock (queueLock)
                {
                    try
                    {
                        item = requestsQueue.Dequeue();                        
                    }
                    catch (InvalidOperationException)
                    {
                        // No items in the queue. 
                        // Get the remaining time and goto 
                        // the begining.
                        timeout = timerHelper.RemainingTime();
                        goto Start;
                    }
                    finally
                    {
                        // Reset the wait object if there are no 
                        // more items to dequeue.
                        if (requestsQueue.Count == 0)
                        {
                            itemEnqueued.Reset();   
                        }
                    }
                }
                return item;
            }

            return null;
        }
        
        /// <summary>
        /// This is the WaitCallback used to asynchronously
        /// invoke TryReceiveRequest method.
        /// </summary>        
        void StartTryReceive(object state)
        {
            AsyncMethodResult requestState = (AsyncMethodResult)state;  
            RequestContext requestContext = null;
            Exception ex = null;
            bool result = false;

            try
            {
                result = TryReceiveRequest(
                    (TimeSpan)requestState.AdditionalData,
                    out requestContext);
            }
            catch (Exception exception)
            {
                ex = exception;
            }

            TryReceiveRequestResutls resultsStore = 
                new TryReceiveRequestResutls(requestContext, result, 
                    ex);

            requestState.AdditionalData = resultsStore;
            requestState.SetCompleted(true);
            
            if (requestState.Callback != null)
            {
                requestState.Callback(requestState);
            }
        }

        #endregion
        
        #region Helper classes

        /// <summary>
        /// This class defines the data structure used 
        /// to carry TryReceiveRequest results in the 
        /// asynchronous state object.
        /// </summary>
        class TryReceiveRequestResutls
        {
            #region Public Fields

            // Reference to the RequestContext.
            public RequestContext RequestContext;

            // A Boolean indicating whether TryReceiveRequest
            // returned true or false.
            public bool ReturnValue;

            // Reference to any exception occurred while trying 
            // to receive.
            public Exception Exception;

            #endregion

            #region Constructor

            /// <summary>
            /// Creates an instance of TryReceiveRequestResults
            /// with the supplied arguments.
            /// </summary>            
            public TryReceiveRequestResutls(
                RequestContext requestContext, bool returnValue, 
                Exception exception)
            {
                this.RequestContext = requestContext;
                this.ReturnValue = returnValue;
                this.Exception = exception;
            }

            #endregion
        }

        #endregion

    }
}
