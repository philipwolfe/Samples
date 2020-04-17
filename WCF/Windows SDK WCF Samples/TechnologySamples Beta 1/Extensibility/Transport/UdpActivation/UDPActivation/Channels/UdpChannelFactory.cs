// ----------------------------------------------------------------------------
// Copyright (C) 2003-2005 Microsoft Corporation, All rights reserved.
// ----------------------------------------------------------------------------

#region using
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Globalization;
#endregion

namespace Microsoft.ServiceModel.Samples.Channels
{
    /// <summary>
    /// IChannelFactory implementation for Udp.
    /// 
    /// Supports IOutputChannel only, as Udp is fundamentally
    /// a datagram protocol.
    /// </summary>
    class UdpChannelFactory : ChannelFactoryBase<IOutputChannel>
    {
        #region member_variables
        BufferManager bufferManager;
        MessageEncoderFactory messageEncoderFactory;
        bool multicast;
        #endregion

        internal UdpChannelFactory(UdpTransportBindingElement bindingElement, BindingContext context)
            : base(context.Binding)
        {
            #region populate_members_from_binding_element
            this.multicast = bindingElement.Multicast;
            this.bufferManager = BufferManager.CreateBufferManager(bindingElement.MaxBufferPoolSize, int.MaxValue);

            Collection<MessageEncodingBindingElement> messageEncoderBindingElements
                = context.BindingParameters.FindAll<MessageEncodingBindingElement>();

            if(messageEncoderBindingElements.Count > 1)
            {
                throw new InvalidOperationException("More than one MessageEncodingBindingElement was found in the BindingParameters of the BindingContext");
            }
            else if (messageEncoderBindingElements.Count == 1)
            {
                this.messageEncoderFactory = messageEncoderBindingElements[0].CreateMessageEncoderFactory();
            }
            else
            {
                this.messageEncoderFactory = UdpConstants.DefaultMessageEncoderFactory;
            }
            #endregion
        }

        #region simple_property_accessors
        public BufferManager BufferManager
        {
            get
            {
                return this.bufferManager;
            }
        }

        public MessageEncoderFactory MessageEncoderFactory
        {
            get
            {
                return this.messageEncoderFactory;
            }
        }

        public bool Multicast
        {
            get
            {
                return this.multicast;
            }
        }
        #endregion

        #region IChannelFactory_Methods
        /// <summary>
        /// We only support the default Message Version
        /// </summary>
        public override MessageVersion MessageVersion
        {
            get
            {
                return messageEncoderFactory.MessageVersion;
            }
        }

        /// <summary>
        /// URI scheme associated with the UDP transport 
        /// </summary>
        public override string Scheme
        {
            get
            {
                return UdpConstants.UriSchemeNetUdp;
            }
        }

        /// <summary>
        /// Create a new Udp Channel. Supports IOutputChannel.
        /// </summary>
        /// <typeparam name="TChannel">The type of Channel to create (e.g. IOutputChannel)</typeparam>
        /// <param name="remoteAddress">The address of the remote endpoint</param>
        /// <returns></returns>
        protected override IOutputChannel OnCreateChannel(EndpointAddress remoteAddress, Uri via)
        {
            return new UdpOutputChannel(this, remoteAddress, via, MessageEncoderFactory.Encoder);
        }

        protected override void OnClosed()
        {
            this.bufferManager.Clear();
            base.OnClosed();
        }
        #endregion
    }
}