
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

#region using

using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Net;

#endregion

namespace Microsoft.ServiceModel.Samples
{
    /// <summary>
    /// This class contains the RequestContext 
    /// implementation used by 
    /// HttpCookieSessionExtension. This gives a 
    /// wrapper to an RequestContext coming from 
    /// the lower channels. 
    /// </summary>
    class HttpCookieSessionRequestContext : RequestContext
    {
        #region Private Fields

        // Reference to the inner request context.
        private RequestContext innerRequestContext;

        // A Boolean value to indicate whether this request 
        // is the initial request for the session or not.
        private bool isInitial;

        // Reference to the session channel this 
        // request belongs to.
        private IReplySessionChannel replySessionChannel;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates an instance of 
        /// HttpCookieSessionRequestContext class.
        /// </summary>
        public HttpCookieSessionRequestContext(
            RequestContext innerRequestContext, 
            IReplySessionChannel replySessionChannel) 
            : this(innerRequestContext, replySessionChannel, false)
        {            
        }

        /// <summary>
        /// Creates an instance of 
        /// HttpCookieSessionRequestContext class.
        /// </summary>       
        public HttpCookieSessionRequestContext(
            RequestContext innerRequestContext, 
            IReplySessionChannel replySessionChannel, 
            bool isInitial)
        {
            this.replySessionChannel = replySessionChannel;
            this.innerRequestContext = innerRequestContext;
            this.isInitial = isInitial;
        }

        #endregion

        #region RequestContext Members

        /// <summary>
        /// Asynchronously invokes the Reply message.
        /// Q: When is this used?
        /// </summary>
        public override IAsyncResult BeginReply(
            Message message, TimeSpan timeout, 
            AsyncCallback callback, object state)
        {
            // Add the session metadata.
            AddSessionData(message);    

            return innerRequestContext.BeginReply(
                message, timeout, callback, state);
        }

        /// <summary>
        /// Asynchronously invokes the Reply message.
        /// </summary>
        public override IAsyncResult BeginReply(
            Message message, AsyncCallback callback, 
            object state)
        {
            AddSessionData(message);
            return innerRequestContext.BeginReply(
                message, callback, state);
        }

        /// <summary>
        /// Closes the inner request context.
        /// </summary>
        public override void Close(TimeSpan timeout)
        {
            innerRequestContext.Close(timeout);
        }

        /// <summary>
        /// Closes the inner request context.
        /// </summary>
        public override void Close()
        {
            innerRequestContext.Close();
        }

        /// <summary>
        /// Ends the asynchronous Reply method call.
        /// </summary>        
        public override void EndReply(IAsyncResult result)
        {
            innerRequestContext.EndReply(result);
        }

        /// <summary>
        /// Sends the reply message to the requester.
        /// </summary>        
        public override void Reply(Message message, TimeSpan timeout)
        {
            AddSessionData(message);
            innerRequestContext.Reply(message, timeout);
        }

        /// <summary>
        /// Sends the reply message to the requester.
        /// </summary>        
        public override void Reply(Message message)
        {
            AddSessionData(message);            
            innerRequestContext.Reply(message);
            TraceHelper.WriteDebugMessage("Reply sent");
                        
        }

        /// <summary>
        /// Get the Message from the inner request 
        /// context and returns it.
        /// </summary>        
        public override Message RequestMessage
        {
            get { return innerRequestContext.RequestMessage; }
        }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// Dispose the inner request context.       
        /// </summary>
        public void Dispose()
        {
            ((IDisposable)innerRequestContext).Dispose();
        }

        #endregion

        #region Helper Members

        /// <summary>
        /// Adds session id to the out going http 
        /// response header.
        /// </summary>        
        void AddSessionData(Message message)
        {
            // Add the http response header only 
            // if this is the first request.
            if (isInitial)
            {
                string sessionCookie = 
                    string.Format("{0}", replySessionChannel.Session.Id);

                string httpResponseKey = ResourceHelper.GetString(
                    "httpResponseProperties");

                HttpResponseMessageProperty httpResponse;
                
                if (message.Properties.ContainsKey(httpResponseKey))
                {
                    httpResponse = 
                        (HttpResponseMessageProperty)message.Properties[httpResponseKey];
                }
                else
                {
                    httpResponse = 
                        new HttpResponseMessageProperty();

                    message.Properties.Add(httpResponseKey, httpResponse);
                }
                
                httpResponse.Headers[HttpResponseHeader.SetCookie] = sessionCookie;
            }
        }

        #endregion

        public override void Abort()
        {
            innerRequestContext.Abort();
        }
    }
}
