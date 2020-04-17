// ----------------------------------------------------------------------------
// Copyright (C) 2003-2005 Microsoft Corporation, All rights reserved.
// ----------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Microsoft.ServiceModel.Samples.Channels
{
    class UdpInputChannel : ChannelBase, IInputChannel
    {
        InputQueue<Message> messageQueue;

        internal UdpInputChannel(ChannelManagerBase manager)
            : base(manager)
        {
            this.messageQueue = new InputQueue<Message>();
        }

        public EndpointAddress LocalAddress
        {
            get
            {
                return null;
            }
        }

        //Hands the message off to other components higher up the
        //channel stack that have previously called BeginReceive() 
        //and are waiting for messages to arrive on this channel.
        internal void Dispatch(Message message)
        {
            this.messageQueue.EnqueueAndDispatch(message);
        }

        //Closes the channel ungracefully during error conditions.
        protected override void OnAbort()
        {
            try
            {
                this.messageQueue.Close();
            }
            finally
            {
                base.OnAbort();
            }
        }

        //Closes the channel gracefully during normal conditions.
        protected override void OnClose(TimeSpan timeout)
        {
            this.messageQueue.Close();
            base.OnClose(timeout);
        }

        //Opens the channel and allows it to receive messages.
        protected override void OnOpen(TimeSpan timeout)
        {
            base.OnOpen(timeout);
            this.messageQueue.Open();
        }

        public Message Receive()
        {
            return this.Receive(((UdpChannelListener)this.Manager).InternalReceiveTimeout);
        }

        public Message Receive(TimeSpan timeout)
        {
            Message message;
            if (this.TryReceive(timeout, out message))
            {
                return message;
            }
            else
            {
                throw new TimeoutException();
            }
        }

        public IAsyncResult BeginReceive(AsyncCallback callback, object state)
        {
            return this.BeginReceive(((UdpChannelListener)this.Manager).InternalReceiveTimeout, callback, state);
        }

        public IAsyncResult BeginReceive(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return this.BeginTryReceive(timeout, callback, state);
        }

        public Message EndReceive(IAsyncResult result)
        {
            Message message;
            if (this.EndTryReceive(result, out message))
            {
                return message;
            }
            else
            {
                throw new TimeoutException();
            }
        }

        public bool TryReceive(TimeSpan timeout, out Message message)
        {
            return this.messageQueue.TryDequeue(timeout, out message);
        }

        public IAsyncResult BeginTryReceive(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return this.messageQueue.BeginTryDequeue(timeout, callback, state);
        }

        public bool EndTryReceive(IAsyncResult result, out Message message)
        {
            return this.messageQueue.EndTryDequeue(result, out message);
        }

        public bool WaitForMessage(TimeSpan timeout)
        {
            return this.messageQueue.WaitForItem(timeout);
        }

        public IAsyncResult BeginWaitForMessage(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return this.messageQueue.BeginWaitForItem(timeout, callback, state);
        }

        public bool EndWaitForMessage(IAsyncResult result)
        {
            return this.messageQueue.EndWaitForItem(result);
        }
    }
}
