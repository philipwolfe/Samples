// ----------------------------------------------------------------------------
// Copyright (C) 2003-2005 Microsoft Corporation, All rights reserved.
// ----------------------------------------------------------------------------

#region using
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Xml;
#endregion

namespace Microsoft.ServiceModel.Samples.Transport
{
    class TcpChannelFactory : ChannelFactoryBase<IDuplexSessionChannel>
    {
        BufferManager bufferManager;
        MessageEncoderFactory encoderFactory;

        public TcpChannelFactory(TcpTransportBindingElement bindingElement, BindingContext context)
            : base(context.Binding)
        {
            // populate members from binding element
            int maxBufferSize = (int)bindingElement.MaxReceivedMessageSize;
            this.bufferManager = BufferManager.CreateBufferManager(bindingElement.MaxBufferPoolSize, maxBufferSize);

            Collection<MessageEncodingBindingElement> messageEncoderBindingElements
                = context.BindingParameters.FindAll<MessageEncodingBindingElement>();

            if (messageEncoderBindingElements.Count > 1)
            {
                throw new InvalidOperationException("More than one MessageEncodingBindingElement was found in the BindingParameters of the BindingContext");
            }
            else if (messageEncoderBindingElements.Count == 1)
            {
                this.encoderFactory = messageEncoderBindingElements[0].CreateMessageEncoderFactory();
            }
            else
            {
                this.encoderFactory = new MtomMessageEncodingBindingElement().CreateMessageEncoderFactory();
            }
        }

        protected override IDuplexSessionChannel OnCreateChannel(EndpointAddress remoteAddress, Uri via)
        {
            return new ClientTcpDuplexSessionChannel(encoderFactory, bufferManager, remoteAddress, via, this);
        }

        protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return new CompletedAsyncResult(callback, state);
        }

        protected override void OnEndOpen(IAsyncResult result)
        {
            CompletedAsyncResult.End(result);
        }

        protected override void OnOpen(TimeSpan timeout)
        {
        }

        class ClientTcpDuplexSessionChannel : TcpDuplexSessionChannel
        {
            public ClientTcpDuplexSessionChannel(
                MessageEncoderFactory messageEncoderFactory, BufferManager bufferManager,
                EndpointAddress remoteAddress, Uri via, ChannelManagerBase channelManager)
                : base(messageEncoderFactory, bufferManager, remoteAddress, TcpDuplexSessionChannel.AnonymousAddress, via, channelManager)
            {
            }

            void Connect()
            {
                Socket socket = null;
                int port = Via.Port;
                if (port == -1)
                {
                    port = 8081; // the default port used by WSE 3.0
                }

                IPHostEntry hostEntry;

                try
                {
                    hostEntry = Dns.GetHostEntry(Via.Host);
                }
                catch (SocketException socketException)
                {
                    throw new EndpointNotFoundException("Unable to resolve host" + Via.Host, socketException);
                }

                for (int i = 0; i < hostEntry.AddressList.Length; i++)
                {
                    try
                    {
                        IPAddress address = hostEntry.AddressList[i];
                        socket = new Socket(address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                        socket.Connect(new IPEndPoint(address, port));
                    }
                    catch (SocketException socketException)
                    {
                        if (i == hostEntry.AddressList.Length - 1)
                        {
                            throw ConvertSocketException(socketException, "Connect");
                        }
                    }
                }

                base.InitializeSocket(socket);
            }

            protected override void OnOpen(TimeSpan timeout)
            {
                Connect();
                base.OnOpen(timeout);
            }

            protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
            {
                Connect(); // would be asynchronous in production
                return base.OnBeginOpen(timeout, callback, state);
            }
        }
    }
}