
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Net;

namespace Microsoft.ServiceModel.Samples
{
    /// <summary>
    /// This class implements the request session channel.
    /// </summary>
    class HttpCookieRequestSessionChannel: ChannelBase, IRequestSessionChannel
    {
        #region Private Fields

        // Reference to the inner channel.
        private IRequestChannel innerChannel;

        // Reference to the parent channel factory.
        private HttpCookieSessionChannelFactory<IRequestSessionChannel> channelFactory;

        // Indicates whether the terminate message is 
        // exchanged when the client closes the request channel.
        private bool exchangeTerminateMessage;                      

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new instance of HttpCookieRequestSessionChannel.
        /// </summary>        
        public HttpCookieRequestSessionChannel(HttpCookieSessionChannelFactory<IRequestSessionChannel> parent, 
            IRequestChannel innerChannel, bool exchangeTerminateMessage) : base(parent)
        {
            this.innerChannel = innerChannel;
            this.channelFactory = parent;
            this.exchangeTerminateMessage = exchangeTerminateMessage;
        }

        #endregion

        #region Communication Object Overrides

        /// <summary>
        /// Performs the actions that needs to be taken before 
        /// the channel is opened.
        /// </summary>        
        protected override void OnOpen(TimeSpan timeout)
        {
            // Open the inner channel.
            innerChannel.Open(timeout);
         }

        /// <summary>
        /// Performs the actions that needs to be 
        /// taken when the channel is closed.
        /// </summary>        
        protected override void OnClose(TimeSpan timeout)
        {
            SendTerminateSession();

            // Close the inner channel.
            innerChannel.Close(timeout); 
        }

        /// <summary>
        /// Begins the asynchronous Open method.
        /// </summary>        
        protected override IAsyncResult OnBeginOpen(
            TimeSpan timeout, AsyncCallback callback, object state)
        {            
            return innerChannel.BeginOpen(timeout, callback, state);
        }

        /// <summary>
        /// Ends the asynchronous Open method.
        /// </summary>       
        protected override void OnEndOpen(IAsyncResult result)
        {
            this.innerChannel.EndOpen(result);
        }

        /// <summary>
        /// Begins the asynchronous Close method.
        /// </summary>        
        protected override IAsyncResult OnBeginClose(
            TimeSpan timeout, AsyncCallback callback, object state)
        {
            SendTerminateSession();
            return innerChannel.BeginClose(timeout, callback, state);
        }

        /// <summary>
        /// Ends the asynchronous Close method.
        /// </summary>        
        protected override void OnEndClose(IAsyncResult result)
        {
            innerChannel.EndClose(result);
        }


        protected override void OnAbort()
        {
            innerChannel.Abort();
        }

#endregion

        #region IRequestChannel Members

        /// <summary>
        /// Begins the asynchronous Request method.
        /// </summary>        
        public IAsyncResult BeginRequest(Message message, 
            TimeSpan timeout, AsyncCallback callback, 
            object state)
        {            
            return this.innerChannel.BeginRequest(message, 
                timeout, callback, state);
        }

        /// <summary>
        /// Begins the asynchronous Request method.
        /// </summary>        
        public IAsyncResult BeginRequest(Message message, 
            AsyncCallback callback, object state)
        {
            return this.innerChannel.BeginRequest(message, 
                callback, state);
        }

        /// <summary>
        /// Ends the asynchronous Request method.
        /// </summary>        
        public Message EndRequest(IAsyncResult result)
        {
            Message message = 
                this.innerChannel.EndRequest(result);
            
            return message;
        }

        /// <summary>
        /// Gets the remote endpoint address.
        /// </summary>        
        public EndpointAddress RemoteAddress
        {
            get { return this.innerChannel.RemoteAddress; }
        }

        /// <summary>
        /// Sends a request to the remote endpoint and 
        /// returns the reply.
        /// </summary>        
        public Message Request(Message message, TimeSpan timeout)
        {                       
            Message replyMessage = 
                this.innerChannel.Request(message, timeout);                       
            
            return replyMessage;
        }

        /// <summary>
        /// Sends a request to the remote endpoint and 
        /// returns the reply.
        /// </summary>        
        public Message Request(Message message)
        {
            Message replyMessage = 
                this.innerChannel.Request(message);
            
            return replyMessage;
        }

        /// <summary>
        /// Gets the uri of the local endpoint. 
        /// *Please verify this comment.*
        /// </summary>        
        public Uri Via
        {
            get { return this.innerChannel.Via; }
        }

        #endregion

        #region Helper members

        /// <summary>
        /// Sends the terminate session message to the service.
        /// </summary>
        void SendTerminateSession()
        {
            if (exchangeTerminateMessage)
            {

                Message terminateSession =
                    Message.CreateMessage(innerChannel.GetProperty<MessageVersion>(),
                    ResourceHelper.GetString("TerminateRequestAction"),
                    "");

                Message terminateAck = null;
                try
                {
                    terminateAck = innerChannel.Request(terminateSession);
                }
                catch (Exception ex)
                {
                    throw new Exception(
                        ResourceHelper.GetString("TerminateRequestFailed"), ex);
                }

                // Check whether the response message contains the Ack header.
                if (terminateAck != null)                                    
                {
                    int headerPos = terminateAck.Headers.FindHeader("TerminateAck",
                        ResourceHelper.GetString("TerminateAck"));

                    if (headerPos < 0)
                    {
                        throw new Exception(
                            ResourceHelper.GetString("TerminateRequestFailed"));
                    }
                }
            }
        }

        #endregion


        #region ISessionChannel<IOutputSession> Members

        public IOutputSession Session
        {
            //the Session property is not used from the client
            get { return null; }
        }

        #endregion
    }
}
