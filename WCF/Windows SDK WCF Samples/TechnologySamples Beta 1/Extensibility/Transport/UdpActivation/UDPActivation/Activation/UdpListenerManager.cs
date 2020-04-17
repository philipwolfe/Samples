// ----------------------------------------------------------------------------
// Copyright (C) 2003-2005 Microsoft Corporation, All rights reserved.
// ----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Microsoft.ServiceModel.Samples.Channels;

namespace Microsoft.ServiceModel.Samples.Activation
{
    class UdpListenerManager
    {
        // TODO: Make the following configurable
        const int MaxBufferPoolSize = 1 << 20;
        const int MaxMessageSize = 1 << 20;

        Dictionary<IPEndPoint, UdpSocketListener> listeners;
        DataReceivedCallback dataReceivedCallback;
        public UdpListenerManager(DataReceivedCallback dataReceivedCallback)
        {
            listeners = new Dictionary<IPEndPoint, UdpSocketListener>();
            this.dataReceivedCallback = dataReceivedCallback;
        }

        public void Listen(IPEndPoint endpoint)
        {
            lock (listeners)
            {
                if (listeners.ContainsKey(endpoint))
                {
                    UdpSocketListener listener = listeners[endpoint];
                    listener.AddRef();
                }
                else
                {
                    UdpSocketListener listener = new UdpSocketListener(endpoint, false, MaxBufferPoolSize, MaxMessageSize, dataReceivedCallback);
                    listener.Open();
                    listener.AddRef();
                    listeners.Add(endpoint, listener);
                }
            }
        }

        public void StopListen(IPEndPoint endpoint)
        {
            lock (listeners)
            {
                if (listeners.ContainsKey(endpoint))
                {
                    UdpSocketListener listener = listeners[endpoint];
                    if (listener.Release() == 0)
                    {
                        listeners.Remove(endpoint);
                    }
                }
            }
        }
    }
}
