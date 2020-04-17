using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;

namespace Microsoft.ServiceModel.Samples
{
    class SimplexSessionChannelListener: ChannelListenerBase<IInputSessionChannel>
    {
        IChannelListener<IDuplexSessionChannel> innerChannelListener;

        public SimplexSessionChannelListener(IChannelListener<IDuplexSessionChannel> innerChannelListener)
        {
            this.innerChannelListener = innerChannelListener;
        }

        public override Uri Uri
        {
            get { return this.innerChannelListener.Uri; }
        }

        protected override void OnAbort()
        {
            this.innerChannelListener.Abort();
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

        protected override IInputSessionChannel OnAcceptChannel(TimeSpan timeout)
        {
            IDuplexSessionChannel innerChannel = this.innerChannelListener.AcceptChannel(timeout);

            if (innerChannel == null)
                return null;

            return new InputSessionChannel(this, innerChannel);
        }

        protected override IAsyncResult OnBeginAcceptChannel(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return this.innerChannelListener.BeginAcceptChannel(timeout, callback, state);
        }

        protected override IInputSessionChannel OnEndAcceptChannel(IAsyncResult result)
        {
            IDuplexSessionChannel innerChannel = this.innerChannelListener.EndAcceptChannel(result);

            if(innerChannel == null)
                return null;

            return new InputSessionChannel(this, innerChannel);
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

        class InputSessionChannel: ChannelBase, IInputSessionChannel
        {
            IDuplexSessionChannel innerChannel;
            IInputSession session;

            public InputSessionChannel(ChannelManagerBase manager, IDuplexSessionChannel innerChannel)
                :base(manager)
            {
                this.innerChannel = innerChannel;
                this.session = new InputSession(innerChannel.Session);
            }

            public EndpointAddress LocalAddress
            {
                get { return this.innerChannel.LocalAddress; }
            }

            public IInputSession Session
            {
                get { return this.session; }
            }

            protected override void OnAbort()
            {
                this.innerChannel.Abort();
            }

            protected override void OnOpen(TimeSpan timeout)
            {
                this.innerChannel.Open(timeout);
            }

            protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
            {
                return this.innerChannel.BeginOpen(timeout, callback, state);
            }

            protected override void OnEndOpen(IAsyncResult result)
            {
                this.innerChannel.EndOpen(result);
            }

            protected override void OnClose(TimeSpan timeout)
            {
                this.innerChannel.Close(timeout);
            }

            protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
            {
                return this.innerChannel.BeginClose(timeout, callback, state);
            }

            protected override void OnEndClose(IAsyncResult result)
            {
                this.innerChannel.EndClose(result);
            }

            public Message Receive()
            {
                return this.innerChannel.Receive();
            }

            public Message Receive(TimeSpan timeout)
            {
                return this.innerChannel.Receive(timeout);
            }

            public IAsyncResult BeginReceive(AsyncCallback callback, object state)
            {
                return this.innerChannel.BeginReceive(callback, state);
            }

            public IAsyncResult BeginReceive(TimeSpan timeout, AsyncCallback callback, object state)
            {
                return this.innerChannel.BeginReceive(timeout, callback, state);
            }

            public Message EndReceive(IAsyncResult result)
            {
                return this.innerChannel.EndReceive(result);
            }

            public bool TryReceive(TimeSpan timeout, out Message message)
            {
                return this.innerChannel.TryReceive(timeout, out message);
            }

            public IAsyncResult BeginTryReceive(TimeSpan timeout, AsyncCallback callback, object state)
            {
                return this.innerChannel.BeginTryReceive(timeout, callback, state);
            }

            public bool EndTryReceive(IAsyncResult result, out Message message)
            {
                return this.innerChannel.EndTryReceive(result, out message);
            }

            public bool WaitForMessage(TimeSpan timeout)
            {
                return this.innerChannel.WaitForMessage(timeout);
            }

            public IAsyncResult BeginWaitForMessage(TimeSpan timeout, AsyncCallback callback, object state)
            {
                return this.innerChannel.BeginWaitForMessage(timeout, callback, state);
            }

            public bool EndWaitForMessage(IAsyncResult result)
            {
                return this.innerChannel.EndWaitForMessage(result);
            }

            class InputSession : IInputSession
            {
                IDuplexSession innerSession;

                public InputSession(IDuplexSession innerSession)
                {
                    this.innerSession = innerSession;
                }

                public string Id
                {
                    get { return this.innerSession.Id; }
                }
            }
        }
    }
}
