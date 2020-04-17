// ----------------------------------------------------------------------------
// Copyright (C) 2003-2005 Microsoft Corporation, All rights reserved.
// ----------------------------------------------------------------------------

#region using
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Xml;
using System.Collections.ObjectModel;
#endregion

namespace Microsoft.ServiceModel.Samples.Transport
{
    class TcpChannelListener : ChannelListenerBase<IDuplexSessionChannel>
    {
        BufferManager bufferManager;
        MessageEncoderFactory encoderFactory;
        Socket listenSocket;
        Uri uri;

        public TcpChannelListener(TcpTransportBindingElement bindingElement, BindingContext context)
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

            // TODO, kennyw, context.ListenUriMode
            this.uri = new Uri(context.ListenUriBaseAddress, context.ListenUriRelativeAddress);
        }

        public override Uri Uri
        {
            get { return this.uri; }
        }

        void OpenListenSocket()
        {
            if (uri == null)
            {
                throw new InvalidOperationException("SetUri must be called before opening this Channel Listener");
            }

            IPEndPoint localEndpoint = new IPEndPoint(IPAddress.Any, uri.Port);
            this.listenSocket = new Socket(localEndpoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            this.listenSocket.Bind(localEndpoint);
            this.listenSocket.Listen(10);
        }

        void CloseListenSocket(TimeSpan timeout)
        {
            this.listenSocket.Close((int)timeout.TotalMilliseconds);
        }

        protected override void OnOpen(TimeSpan timeout)
        {
            OpenListenSocket();
        }

        protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
        {
            OpenListenSocket();
            return new CompletedAsyncResult(callback, state);
        }

        protected override void OnEndOpen(IAsyncResult result)
        {
            CompletedAsyncResult.End(result);
        }

        protected override void OnAbort()
        {
            CloseListenSocket(TimeSpan.Zero);
        }

        protected override void OnClose(TimeSpan timeout)
        {
            CloseListenSocket(timeout);
        }

        protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
        {
            CloseListenSocket(timeout);
            return new CompletedAsyncResult(callback, state);
        }

        protected override void OnEndClose(IAsyncResult result)
        {
            CompletedAsyncResult.End(result);
        }

        protected override IDuplexSessionChannel OnAcceptChannel(TimeSpan timeout)
        {
            Socket dataSocket = listenSocket.Accept();
            return new ServerTcpDuplexSessionChannel(this.encoderFactory, this.bufferManager, dataSocket, new EndpointAddress(uri), this);
        }

        protected override IAsyncResult OnBeginAcceptChannel(TimeSpan timeout, AsyncCallback callback, object state)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        protected override IDuplexSessionChannel OnEndAcceptChannel(IAsyncResult result)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        protected override bool OnWaitForChannel(TimeSpan timeout)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        protected override IAsyncResult OnBeginWaitForChannel(TimeSpan timeout, AsyncCallback callback, object state)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        protected override bool OnEndWaitForChannel(IAsyncResult result)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        class ServerTcpDuplexSessionChannel : TcpDuplexSessionChannel
        {
            public ServerTcpDuplexSessionChannel(
                MessageEncoderFactory messageEncoderFactory, BufferManager bufferManager,
                Socket socket, EndpointAddress localAddress, ChannelManagerBase channelManager)
                : base(messageEncoderFactory, bufferManager, TcpDuplexSessionChannel.AnonymousAddress, localAddress, TcpDuplexSessionChannel.AnonymousAddress.Uri, channelManager)
            {
                base.InitializeSocket(socket);
            }
        }
    }
}