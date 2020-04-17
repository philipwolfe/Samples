using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;

namespace Microsoft.ServiceModel.Samples
{
    class SimplexSessionChannelFactory : ChannelFactoryBase<IOutputSessionChannel>
    {
        IChannelFactory<IDuplexSessionChannel> innerChannelFactory;

        public SimplexSessionChannelFactory(IChannelFactory<IDuplexSessionChannel> innerChannelFactory)
        {
            this.innerChannelFactory = innerChannelFactory;
        }

        protected override void OnAbort()
        {
            this.innerChannelFactory.Abort();
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

        protected override IOutputSessionChannel OnCreateChannel(EndpointAddress address, Uri via)
        {
            return new OutputSessionChannel(this, this.innerChannelFactory.CreateChannel(address, via));
        }

        class OutputSessionChannel : ChannelBase, IOutputSessionChannel
        {
            IDuplexSessionChannel innerChannel;

            public OutputSessionChannel(ChannelManagerBase manager, IDuplexSessionChannel innerChannel)
                : base(manager)
            {
                this.innerChannel = innerChannel;
            }

            public EndpointAddress RemoteAddress
            {
                get { return this.innerChannel.RemoteAddress; }
            }

            public Uri Via
            {
                get { return this.innerChannel.Via; }
            }

            public IOutputSession Session
            {
                get { return this.innerChannel.Session; }
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

            public void Send(Message message)
            {
                this.innerChannel.Send(message);
            }

            public void Send(Message message, TimeSpan timeout)
            {
                this.innerChannel.Send(message, timeout);
            }

            public IAsyncResult BeginSend(Message message, AsyncCallback callback, object state)
            {
                return this.innerChannel.BeginSend(message, callback, state);
            }

            public IAsyncResult BeginSend(Message message, TimeSpan timeout, AsyncCallback callback, object state)
            {
                return this.innerChannel.BeginSend(message, timeout, callback, state);
            }

            public void EndSend(IAsyncResult result)
            {
                this.innerChannel.EndSend(result);
            }

            class OutputSession
            {
                IDuplexSession innerSession;

                public OutputSession(IDuplexSession innerSession)
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
