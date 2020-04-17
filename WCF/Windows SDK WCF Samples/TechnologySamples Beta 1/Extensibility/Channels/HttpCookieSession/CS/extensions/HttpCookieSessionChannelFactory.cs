
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

#region using

using System;

using System.ServiceModel.Dispatcher;
using System.ServiceModel;
using System.ServiceModel.Channels;

#endregion

namespace Microsoft.ServiceModel.Samples
{
    /// <summary>
    /// This class implements the channel factory.
    /// </summary>
    class HttpCookieSessionChannelFactory<TChannel> : ChannelFactoryBase<TChannel>
    {
        #region Private Fields
        
        // Indicates whether the terminate message is 
        // exchanged when the client closes the request 
        // channel.
        private bool exchangeTerminateMessage;

        IChannelFactory<IRequestChannel> innerChannelFactory;

        #endregion

        #region Constructor
        
        /// <summary>
        /// Instantiates an instance of 
        /// HttpCookieSessionChannelFactory class.
        /// </summary>        
        public HttpCookieSessionChannelFactory(bool exchangeTerminateMessage, IChannelFactory<IRequestChannel> innerChannelFactory)
        {
            this.exchangeTerminateMessage = exchangeTerminateMessage;
            this.innerChannelFactory = innerChannelFactory;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the channel type created by this 
        /// instance of channel factory.
        /// </summary>
        public Type ChannelType
        {
            get { return typeof(IRequestSessionChannel); }
        }

        #endregion

        #region ChannelFactoryBase Overrides


        /// <summary>
        /// Creates a new channel and returns it to the caller.
        /// </summary>        
        protected override TChannel OnCreateChannel(EndpointAddress remoteAddress, Uri via)
        {
            // If the requested type is IRequestChannel, 
            // we create a new instance of 
            // HttpCookieRequestSessionChannel and return it 
            // to the caller. Otherwise we rely on our 
            // inner channel factory.
            if ((typeof(TChannel) == typeof(IRequestSessionChannel)))
            {
                IRequestChannel innerChannel = 
                    this.innerChannelFactory.CreateChannel(remoteAddress);
                
                return (TChannel)(object) new HttpCookieRequestSessionChannel(
                    (HttpCookieSessionChannelFactory<IRequestSessionChannel>)(object)this, 
                    innerChannel, 
                    exchangeTerminateMessage);
            }
            else
            {
                return (TChannel)(object)this.innerChannelFactory.CreateChannel(remoteAddress);
            }
        }

        #endregion


        protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
        {
            throw new NotImplementedException(ResourceHelper.GetString("NotImplementedException"));
        }

        protected override void OnEndOpen(IAsyncResult result)
        {
            throw new NotImplementedException(ResourceHelper.GetString("NotImplementedException"));
        }

        protected override void OnOpen(TimeSpan timeout)
        {
            this.innerChannelFactory.Open(timeout);
        }

        protected override void OnAbort()
        {
            this.innerChannelFactory.Abort();
            base.OnAbort();
        }
    }
}
