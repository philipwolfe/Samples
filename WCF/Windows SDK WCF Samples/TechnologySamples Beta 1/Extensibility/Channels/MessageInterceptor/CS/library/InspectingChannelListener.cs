
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Security.Permissions;

namespace Microsoft.ServiceModel.Samples
{
    class InspectingChannelListener<TChannel> 
        : ChannelListenerBase<TChannel>
        where TChannel : class, IChannel
    {
        IChannelMessageInspector inspector;
        IChannelListener<TChannel> innerChannelListener;

        public InspectingChannelListener(IChannelMessageInspector inspector, BindingContext context)
        {
            this.inspector = inspector;
            this.innerChannelListener = context.BuildInnerChannelListener<TChannel>();
            if (this.innerChannelListener == null)
            {
                throw new InvalidOperationException(
                    "InspectingChannelListener requires an inner IChannelListener.");
            }
        }

        public IChannelMessageInspector Inspector
        {
            get { return this.inspector; }
        }

        public override Uri Uri
        {
            get
            {
                return this.innerChannelListener.Uri;
            }
        }

        public override T GetProperty<T>()
        {
            T baseProperty = base.GetProperty<T>();
            if (baseProperty != null)
            {
                return baseProperty;
            }

            return this.innerChannelListener.GetProperty<T>();
        }

        protected override void OnOpen(TimeSpan timeout)
        {
            this.innerChannelListener.Open(timeout);
        }

        protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return this.innerChannelListener.BeginOpen(timeout, callback, state);
        }

        protected override void OnEndOpen(IAsyncResult result)
        {
            this.innerChannelListener.EndOpen(result);
        }

        protected override void OnClose(TimeSpan timeout)
        {
            this.innerChannelListener.Close(timeout);
        }

        protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return this.innerChannelListener.BeginClose(timeout, callback, state);
        }

        protected override void OnEndClose(IAsyncResult result)
        {
            this.innerChannelListener.EndClose(result);
        }

        protected override void OnAbort()
        {
            this.innerChannelListener.Abort();
        }

        protected override TChannel OnAcceptChannel(TimeSpan timeout)
        {
            TChannel innerChannel = this.innerChannelListener.AcceptChannel(timeout);
            return WrapChannel(innerChannel);
        }

        protected override IAsyncResult OnBeginAcceptChannel(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return this.innerChannelListener.BeginAcceptChannel(timeout, callback, state);
        }

        protected override TChannel OnEndAcceptChannel(IAsyncResult result)
        {
            TChannel innerChannel = this.innerChannelListener.EndAcceptChannel(result);
            return WrapChannel(innerChannel);
        }

        protected override bool OnWaitForChannel(TimeSpan timeout)
        {
            return this.innerChannelListener.WaitForChannel(timeout);
        }

        protected override IAsyncResult OnBeginWaitForChannel(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return this.innerChannelListener.BeginWaitForChannel(timeout, callback, state);
        }

        protected override bool OnEndWaitForChannel(IAsyncResult result)
        {
            return this.innerChannelListener.EndWaitForChannel(result);
        }

        TChannel WrapChannel(TChannel innerChannel)
        {
            if (innerChannel == null)
            {
                return null;
            }

            if (typeof(TChannel) == typeof(IInputChannel))
            {
                return (TChannel)(object)new InspectingInputChannel<IInputChannel>(this, this.Inspector, (IInputChannel)innerChannel);
            }
            else if (typeof(TChannel) == typeof(IReplyChannel))
            {
                return (TChannel)(object)new InspectingReplyChannel(this, (IReplyChannel)innerChannel);
            }
            else if (typeof(TChannel) == typeof(IDuplexChannel))
            {
                return (TChannel)(object)new InspectingDuplexChannel(this, Inspector, (IDuplexChannel)innerChannel);
            }
            else if (typeof(TChannel) == typeof(IInputSessionChannel))
            {
                return (TChannel)(object)new InspectingInputSessionChannel(this,
                    (IInputSessionChannel)innerChannel);
            }
            else if (typeof(TChannel) == typeof(IReplySessionChannel))
            {
                return (TChannel)(object)new InspectingReplySessionChannel(this,
                    (IReplySessionChannel)innerChannel);
            }
            else if (typeof(TChannel) == typeof(IDuplexSessionChannel))
            {
                return (TChannel)(object)new InspectingDuplexSessionChannel(this, Inspector, 
                    (IDuplexSessionChannel)innerChannel);
            }

            // Cannot wrap this channel.
            return innerChannel;
        }

        class InspectingReplyChannel : InspectingChannelBase<IReplyChannel>, IReplyChannel
        {
            public InspectingReplyChannel(
                InspectingChannelListener<TChannel> listener, IReplyChannel innerChannel)
                : base(listener, listener.Inspector, innerChannel)
            {
                // empty
            }

            public EndpointAddress LocalAddress
            {
                get
                {
                    return this.InnerChannel.LocalAddress;
                }
            }

            public RequestContext ReceiveRequest()
            {
                RequestContext requestContext = this.InnerChannel.ReceiveRequest();
                Message m = requestContext.RequestMessage;
                this.OnReceive(ref m);
                return new InterceptingRequestContext(this, requestContext);
            }

            public RequestContext ReceiveRequest(TimeSpan timeout)
            {
                RequestContext requestContext = this.InnerChannel.ReceiveRequest(timeout);
                Message m = requestContext.RequestMessage;
                this.OnReceive(ref m);
                return new InterceptingRequestContext(this, requestContext);
            }

            public IAsyncResult BeginReceiveRequest(AsyncCallback callback, object state)
            {
                return this.InnerChannel.BeginReceiveRequest(callback, state);
            }

            public IAsyncResult BeginReceiveRequest(TimeSpan timeout, AsyncCallback callback, object state)
            {
                return this.InnerChannel.BeginReceiveRequest(timeout, callback, state);
            }

            public RequestContext EndReceiveRequest(IAsyncResult result)
            {
                RequestContext requestContext = this.InnerChannel.EndReceiveRequest(result);
                Message m = requestContext.RequestMessage;
                this.OnReceive(ref m);
                return new InterceptingRequestContext(this, requestContext);
            }

            public bool TryReceiveRequest(TimeSpan timeout, out RequestContext requestContext)
            {
                RequestContext innerRequestContext;
                if (this.InnerChannel.TryReceiveRequest(timeout, out innerRequestContext))
                {
                    Message m = innerRequestContext.RequestMessage;
                    this.OnReceive(ref m);
                    requestContext = new InterceptingRequestContext(this, innerRequestContext);
                    return true;
                }
                else
                {
                    requestContext = null;
                    return false;
                }
            }

            public IAsyncResult BeginTryReceiveRequest(TimeSpan timeout, AsyncCallback callback, object state)
            {
                return this.InnerChannel.BeginTryReceiveRequest(timeout, callback, state);
            }

            public bool EndTryReceiveRequest(IAsyncResult result, out RequestContext requestContext)
            {
                RequestContext innerRequestContext;
                if (this.InnerChannel.EndTryReceiveRequest(result, out innerRequestContext))
                {
                    if (innerRequestContext == null)
                    {
                        requestContext = null;
                        return true;
                    }
                    Message m = innerRequestContext.RequestMessage;
                    this.OnReceive(ref m);
                    requestContext = new InterceptingRequestContext(this, innerRequestContext);
                    return true;
                }
                else
                {
                    requestContext = null;
                    return false;
                }
            }

            public bool WaitForRequest(TimeSpan timeout)
            {
                return this.InnerChannel.WaitForRequest(timeout);
            }

            public IAsyncResult BeginWaitForRequest(TimeSpan timeout, AsyncCallback callback, object state)
            {
                return this.InnerChannel.BeginWaitForRequest(timeout, callback, state);
            }

            public bool EndWaitForRequest(IAsyncResult result)
            {
                return this.InnerChannel.EndWaitForRequest(result);
            }

            class InterceptingRequestContext : RequestContext
            {
                InspectingReplyChannel channel;
                RequestContext innerContext;

                public InterceptingRequestContext(InspectingReplyChannel channel, RequestContext innerContext)
                {
                    this.channel = channel;
                    this.innerContext = innerContext;
                }

                public override Message RequestMessage
                {
                    get
                    {
                        return this.innerContext.RequestMessage;
                    }
                }

                public override void Abort()
                {
                    this.innerContext.Abort();
                }

                public override IAsyncResult BeginReply(Message message, AsyncCallback callback, object state)
                {
                    Message m = message;
                    this.OnSend(ref m);
                    return this.innerContext.BeginReply(m, callback, state);
                }

                public override IAsyncResult BeginReply(Message message, TimeSpan timeout, AsyncCallback callback, object state)
                {
                    Message m = message;
                    this.OnSend(ref m);
                    return this.innerContext.BeginReply(m, timeout, callback, state);
                }

                public override void Close()
                {
                    this.innerContext.Close();
                }

                public override void Close(TimeSpan timeout)
                {
                    this.innerContext.Close(timeout);
                }

                protected override void Dispose(bool disposing)
                {
                    if(disposing)
                        ((IDisposable)this.innerContext).Dispose();
                }

                public override void EndReply(IAsyncResult result)
                {
                    this.innerContext.EndReply(result);
                }

                void OnSend(ref Message message)
                {
                    this.channel.OnSend(ref message);
                }

                public override void Reply(Message message, TimeSpan timeout)
                {
                    Message m = message;

                    this.OnSend(ref m);
                    this.innerContext.Reply(m, timeout);
                }

                public override void Reply(Message message)
                {
                    Message m = message;
                    this.OnSend(ref m);
                    this.innerContext.Reply(m);
                }
            }
        }

        class InspectingInputSessionChannel : InspectingInputChannel<IInputSessionChannel>, IInputSessionChannel
        {
            IInputSessionChannel innerSessionChannel;

            public InspectingInputSessionChannel(
                InspectingChannelListener<TChannel> listener, IInputSessionChannel innerChannel)
                : base(listener, listener.Inspector, innerChannel)
            {
                this.innerSessionChannel = innerChannel;
            }

            public IInputSession Session
            {
                get
                {
                    return this.innerSessionChannel.Session;
                }
            }
        }

        class InspectingReplySessionChannel : InspectingReplyChannel, IReplySessionChannel
        {
            IReplySessionChannel innerSessionChannel;

            public InspectingReplySessionChannel(
                InspectingChannelListener<TChannel> listener, IReplySessionChannel innerChannel)
                : base(listener, innerChannel)
            {
                this.innerSessionChannel = innerChannel;
            }

            public IInputSession Session
            {
                get
                {
                    return this.innerSessionChannel.Session;
                }
            }
        }
    }
}
