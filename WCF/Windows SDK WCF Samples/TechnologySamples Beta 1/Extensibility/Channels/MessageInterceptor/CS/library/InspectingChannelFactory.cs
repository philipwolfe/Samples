
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Microsoft.ServiceModel.Samples
{
    /// <summary>
    /// ChannelFactory that performs message inspection
    /// </summary>
    class InspectingChannelFactory<TChannel> 
        : ChannelFactoryBase<TChannel>
    {
        IChannelMessageInspector inspector;
        IChannelFactory<TChannel> innerChannelFactory;

        public InspectingChannelFactory(IChannelMessageInspector inspector, BindingContext context)
        {
            this.inspector = inspector;
            this.innerChannelFactory = context.BuildInnerChannelFactory<TChannel>();
            if (this.innerChannelFactory == null)
            {
                throw new InvalidOperationException("InspectingChannelFactory requires an inner IChannelFactory.");
            }
        }

        public IChannelMessageInspector Inspector
        {
            get { return this.inspector; }
        }

        public override T GetProperty<T>()
        {
            T baseProperty = base.GetProperty<T>();
            if (baseProperty != null)
            {
                return baseProperty;
            }

            return this.innerChannelFactory.GetProperty<T>();
        }

        protected override void OnOpen(TimeSpan timeout)
        {
            this.innerChannelFactory.Open(timeout);
        }

        protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return this.innerChannelFactory.BeginOpen(timeout, callback, state);
        }

        protected override void OnEndOpen(IAsyncResult result)
        {
            this.innerChannelFactory.EndOpen(result);
        }

        protected override void OnClose(TimeSpan timeout)
        {
            this.innerChannelFactory.Close(timeout);
        }

        protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return this.innerChannelFactory.BeginClose(timeout, callback, state);
        }

        protected override void OnEndClose(IAsyncResult result)
        {
            this.innerChannelFactory.EndClose(result);
        }

        protected override TChannel OnCreateChannel(EndpointAddress to, Uri via)
        {
            TChannel innerChannel = this.innerChannelFactory.CreateChannel(to, via);
            if (typeof(TChannel) == typeof(IOutputChannel))
            {
                return (TChannel)(object)new InspectingOutputChannel(this, (IOutputChannel)innerChannel);
            }
            else if (typeof(TChannel) == typeof(IRequestChannel))
            {
                return (TChannel)(object)new InspectingRequestChannel(this, (IRequestChannel)innerChannel);
            }
            else if (typeof(TChannel) == typeof(IDuplexChannel))
            {
                return (TChannel)(object)new InspectingDuplexChannel(this, Inspector, (IDuplexChannel)innerChannel);
            }
            else if (typeof(TChannel) == typeof(IOutputSessionChannel))
            {
                return (TChannel)(object)new InspectingOutputSessionChannel(this, (IOutputSessionChannel)innerChannel);
            }
            else if (typeof(TChannel) == typeof(IRequestSessionChannel))
            {
                return (TChannel)(object)new InspectingRequestSessionChannel(this,
                    (IRequestSessionChannel)innerChannel);
            }
            else if (typeof(TChannel) == typeof(IDuplexSessionChannel))
            {
                return (TChannel)(object)new InspectingDuplexSessionChannel(this, Inspector, (IDuplexSessionChannel)innerChannel);
            }

            throw new InvalidOperationException();
        }

        class InspectingOutputChannel 
            : InspectingChannelBase<IOutputChannel>, IOutputChannel
        {
            public InspectingOutputChannel(InspectingChannelFactory<TChannel> factory, IOutputChannel innerChannel)
                : base(factory, factory.Inspector, innerChannel)
            {
                // empty
            }

            public EndpointAddress RemoteAddress
            {
                get
                {
                    return this.InnerChannel.RemoteAddress;
                }
            }

            public Uri Via
            {
                get
                {
                    return this.InnerChannel.Via;
                }
            }

            public IAsyncResult BeginSend(Message message, AsyncCallback callback, object state)
            {
                this.OnSend(ref message);
                return this.InnerChannel.BeginSend(message, callback, state);
            }

            public IAsyncResult BeginSend(Message message, TimeSpan timeout, AsyncCallback callback, object state)
            {
                this.OnSend(ref message);
                return this.InnerChannel.BeginSend(message, timeout, callback, state);
            }

            public void EndSend(IAsyncResult result)
            {
                this.InnerChannel.EndSend(result);
            }

            public void Send(Message message)
            {
                base.OnSend(ref message);

                if (message != null)
                {
                    this.InnerChannel.Send(message);
                }
            }

            public void Send(Message message, TimeSpan timeout)
            {
                base.OnSend(ref message);

                if (message != null)
                {
                    this.InnerChannel.Send(message, timeout);
                }
            }
        }

        class InspectingRequestChannel 
            : InspectingChannelBase<IRequestChannel>, IRequestChannel
        {
            public InspectingRequestChannel(
                InspectingChannelFactory<TChannel> factory, IRequestChannel innerChannel)
                : base(factory, factory.Inspector, innerChannel)
            {
                // empty
            }

            public EndpointAddress RemoteAddress
            {
                get
                {
                    return this.InnerChannel.RemoteAddress;
                }
            }

            public Uri Via
            {
                get
                {
                    return this.InnerChannel.Via;
                }
            }

            public IAsyncResult BeginRequest(Message message, AsyncCallback callback, object state)
            {
                return this.BeginRequest(message, this.DefaultSendTimeout, callback, state);
            }

            public IAsyncResult BeginRequest(Message message, TimeSpan timeout, AsyncCallback callback, object state)
            {
                base.OnSend(ref message);
                return this.InnerChannel.BeginRequest(message, timeout, callback, state);
            }

            public Message EndRequest(IAsyncResult result)
            {
                Message reply = this.InnerChannel.EndRequest(result);
                this.OnReceive(ref reply);
                return reply;
            }

            public Message Request(Message message)
            {
                return this.Request(message, this.DefaultSendTimeout);
            }

            public Message Request(Message message, TimeSpan timeout)
            {
                this.OnSend(ref message);
                Message reply = null;
                if (message != null)
                {
                    reply = this.InnerChannel.Request(message);
                }

                this.OnReceive(ref reply);
                return reply;
            }
        }

        class InspectingOutputSessionChannel : InspectingOutputChannel, IOutputSessionChannel
        {
            IOutputSessionChannel innerSessionChannel;

            public InspectingOutputSessionChannel(
                InspectingChannelFactory<TChannel> factory, IOutputSessionChannel innerChannel)
                : base(factory, innerChannel)
            {
                this.innerSessionChannel = innerChannel;
            }

            public IOutputSession Session
            {
                get
                {
                    return this.innerSessionChannel.Session;
                }
            }
        }

        class InspectingRequestSessionChannel : InspectingRequestChannel, IRequestSessionChannel
        {
            IRequestSessionChannel innerSessionChannel;

            public InspectingRequestSessionChannel(
                InspectingChannelFactory<TChannel> factory, IRequestSessionChannel innerChannel)
                : base(factory, innerChannel)
            {
                this.innerSessionChannel = innerChannel;
            }

            public IOutputSession Session
            {
                get
                {
                    return this.innerSessionChannel.Session;
                }
            }
        }
    }
}
