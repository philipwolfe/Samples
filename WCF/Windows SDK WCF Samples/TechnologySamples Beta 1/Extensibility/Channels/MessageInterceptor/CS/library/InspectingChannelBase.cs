
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Microsoft.ServiceModel.Samples
{
    /// <summary>
    /// Base channel class that uses an IChannelMessageInspector
    /// </summary>
    class InspectingChannelBase<TChannel> : ChannelBase
        where TChannel : class, IChannel
    {
        IChannelMessageInspector inspector;
        TChannel innerChannel;

        protected InspectingChannelBase(
            ChannelManagerBase manager, IChannelMessageInspector inspector, TChannel innerChannel)
            : base(manager)
        {
            if (innerChannel == null)
            {
                throw new ArgumentException("InspectingChannelBase requires a non-null inner channel.", "innerChannel");
            }

            this.inspector = inspector;
            this.innerChannel = innerChannel;
        }

        protected TChannel InnerChannel
        {
            get
            {
                return this.innerChannel;
            }
        }

        public override T GetProperty<T>()
        {
            T baseProperty = base.GetProperty<T>();
            if (baseProperty != null)
            {
                return baseProperty;
            }

            return this.InnerChannel.GetProperty<T>();
        }

        protected override void OnAbort()
        {
            this.innerChannel.Abort();
        }

        protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return this.innerChannel.BeginClose(timeout, callback, state);
        }

        protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return this.innerChannel.BeginOpen(timeout, callback, state);
        }

        protected override void OnClose(TimeSpan timeout)
        {
            this.innerChannel.Close(timeout);
        }

        protected override void OnEndClose(IAsyncResult result)
        {
            this.innerChannel.EndClose(result);
        }

        protected override void OnEndOpen(IAsyncResult result)
        {
            this.innerChannel.EndOpen(result);
        }

        protected override void OnOpen(TimeSpan timeout)
        {
            this.innerChannel.Open(timeout);
        }

        protected void OnReceive(ref Message message)
        {
            this.inspector.OnReceive(ref message);
        }

        protected void OnSend(ref Message message)
        {
            this.inspector.OnSend(ref message);
        }
    }
}
