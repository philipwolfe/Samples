using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace Microsoft.ServiceModel.Samples.Channels
{
    class ExclusiveUdpTransportManager : UdpTransportManager
    {
        UdpSocketListener socketListener;
        List<Socket> listenSockets;
        int maxBufferSize;
        int maxMessageSize;
        bool multicast;
        public ExclusiveUdpTransportManager(Uri listenUri, List<Socket> listenSockets,
            int maxBufferSize, int maxMessageSize)
            : base(listenUri)
        {
            this.listenSockets = listenSockets;
            this.maxBufferSize = maxBufferSize;
            this.maxMessageSize = maxMessageSize;
        }

        public ExclusiveUdpTransportManager(Uri listenUri, bool multicast,
            int maxBufferSize, int maxMessageSize)
            : base(listenUri)
        {
            this.multicast = multicast;
            this.maxBufferSize = maxBufferSize;
            this.maxMessageSize = maxMessageSize;
        }

        public void Open()
        {
            DataReceivedCallback callback = new DataReceivedCallback(OnDataReceived);
            if (listenSockets != null)
            {
                socketListener = new UdpSocketListener(this.listenSockets,
                    this.maxBufferSize, this.maxMessageSize, callback);
            }
            else
            {
                IPAddress address = IPAddress.Broadcast;
                if (this.ListenUri.HostNameType == UriHostNameType.IPv4 || this.ListenUri.HostNameType == UriHostNameType.IPv6)
                {
                    address = IPAddress.Parse(this.ListenUri.DnsSafeHost);
                }

                IPEndPoint endpoint = new IPEndPoint(address, this.ListenUri.Port);
                socketListener = new UdpSocketListener(endpoint, this.multicast,
                    this.maxBufferSize, this.maxMessageSize, callback);
            }

            socketListener.Open();
        }

        public void OnDataReceived(FramingData data)
        {
            base.Dispatch(data);
        }
    }
}
