// ----------------------------------------------------------------------------
// Copyright (C) 2003-2005 Microsoft Corporation, All rights reserved.
// ----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;
using System.ServiceModel.Channels;
using Microsoft.ServiceModel.Samples.Channels;

namespace Microsoft.ServiceModel.Samples.Channels
{
    class UdpSocketListener
    {
        bool multicast = false;
        List<Socket> listenSockets;
        IPEndPoint ipEndPoint;
        object syncRoot = new object();
        int maxMessageSize;
        BufferManager bufferManager;
        AsyncCallback onReceive;
        int refCount;
        bool closed = false;
        DataReceivedCallback dataReceivedCallback;

        public UdpSocketListener(IPEndPoint ipEndPoint, bool multicast, int maxBufferPoolSize, int maxMessageSize, DataReceivedCallback dataReceivedCallback)
        {
            this.ipEndPoint = ipEndPoint;
            this.multicast = multicast;
            this.maxMessageSize = maxMessageSize;
            this.listenSockets = null;
            this.bufferManager = BufferManager.CreateBufferManager(maxBufferPoolSize, maxMessageSize);
            this.dataReceivedCallback = dataReceivedCallback;
        }

        public UdpSocketListener(List<Socket> listenSockets, int maxBufferPoolSize, int maxMessageSize, DataReceivedCallback dataReceivedCallback)
        {
            this.listenSockets = listenSockets;
            this.maxMessageSize = maxMessageSize;
            this.bufferManager = BufferManager.CreateBufferManager(maxBufferPoolSize, maxMessageSize);
            this.dataReceivedCallback = dataReceivedCallback;
        }

        object ThisLock
        {
            get
            {
                return syncRoot;
            }
        }

        public void Open()
        {
            if (listenSockets == null)
            {
                listenSockets = new List<Socket>();
                if (!ipEndPoint.Address.Equals(IPAddress.Broadcast))
                {
                    listenSockets.Add(CreateListenSocket(ipEndPoint, multicast));
                }
                else
                {
                    listenSockets.Add(CreateListenSocket(new IPEndPoint(IPAddress.Any, this.ipEndPoint.Port), multicast));
                    if (Socket.OSSupportsIPv6)
                    {
                        listenSockets.Add(CreateListenSocket(new IPEndPoint(IPAddress.IPv6Any, this.ipEndPoint.Port), multicast));
                    }
                }
            }

            this.onReceive = new AsyncCallback(this.OnReceive);
            WaitCallback startReceivingCallback = new WaitCallback(StartReceiving);

            Socket[] socketsSnapshot = listenSockets.ToArray();
            for (int i = 0; i < socketsSnapshot.Length; i++)
            {
                ThreadPool.QueueUserWorkItem(startReceivingCallback, socketsSnapshot[i]);
            }
        }

        public int AddRef()
        {
            return Interlocked.Increment(ref refCount);
        }

        public int Release()
        {
            int count = Interlocked.Decrement(ref refCount);
            if (count == 0)
            {
                Stop();
            }

            return count;
        }

        void CloseListenSockets(TimeSpan timeout)
        {
            // TODO: telescoping timeout
            for (int i = 0; i < listenSockets.Count; i++)
            {
                this.listenSockets[i].Close((int)timeout.TotalMilliseconds);
            }
            listenSockets.Clear();
        }

        void Stop()
        {
            // TODO: use appropriate timeout
            CloseListenSockets(TimeSpan.MaxValue);

            if (this.bufferManager != null)
            {
                this.bufferManager.Clear();
            }
        }

        void StartReceiving(object state)
        {
            Socket listenSocket = (Socket)state;
            IAsyncResult result = null;

            try
            {
                lock (ThisLock)
                {
                    if (!closed)
                    {
                        EndPoint dummy = CreateDummyEndPoint(listenSocket);
                        byte[] buffer = this.bufferManager.TakeBuffer(maxMessageSize);
                        result = listenSocket.BeginReceiveFrom(buffer, 0, buffer.Length,
                            SocketFlags.None, ref dummy, this.onReceive, new SocketReceiveState(listenSocket, buffer));
                    }
                }

                if (result != null && result.CompletedSynchronously)
                {
                    ContinueReceiving(result, listenSocket);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error in receiving from the socket.");
                Debug.WriteLine(e.ToString());
            }
        }

        EndPoint CreateDummyEndPoint(Socket socket)
        {
            if (socket.AddressFamily == AddressFamily.InterNetwork)
            {
                return new IPEndPoint(IPAddress.Any, 0);
            }
            else
            {
                return new IPEndPoint(IPAddress.IPv6Any, 0);
            }
        }

        public static Socket CreateListenSocket(IPEndPoint endpoint, bool multicast)
        {
            Socket socket = new Socket(endpoint.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
            if (multicast)
            {
                socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, 1);
            }

            socket.Bind(endpoint);

            if (multicast)
            {
                if (endpoint.AddressFamily == AddressFamily.InterNetworkV6)
                {
                    socket.SetSocketOption(SocketOptionLevel.IPv6, SocketOptionName.AddMembership,
                        new IPv6MulticastOption(endpoint.Address));
                }
                else
                {
                    socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership,
                        new MulticastOption(endpoint.Address));
                }
            }

            return socket;
        }

        void ContinueReceiving(IAsyncResult receiveResult, Socket listenSocket)
        {
            bool continueReceiving = true;

            while (continueReceiving)
            {
                FramingData data = null;

                if (receiveResult != null)
                {
                    data = EndReceive(listenSocket, receiveResult);
                    receiveResult = null;
                }

                lock (ThisLock)
                {
                    if (!closed)
                    {
                        EndPoint dummy = CreateDummyEndPoint(listenSocket);
                        byte[] buffer = this.bufferManager.TakeBuffer(maxMessageSize);
                        receiveResult = listenSocket.BeginReceiveFrom(buffer, 0, buffer.Length,
                            SocketFlags.None, ref dummy, this.onReceive, new SocketReceiveState(listenSocket, buffer));
                    }
                }

                if (receiveResult == null || !receiveResult.CompletedSynchronously)
                {
                    continueReceiving = false;
                    Dispatch(data);
                }
                else if (data != null)
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(DispatchCallback), data);
                }
            }
        }

        FramingData EndReceive(Socket listenSocket, IAsyncResult result)
        {
            // if we've started the shutdown process, then we've disposed
            // the socket and calls to socket.EndReceive will throw 
            if (closed)
                return null;

            byte[] buffer = ((SocketReceiveState)result.AsyncState).Buffer;
            Debug.Assert(buffer != null);
            FramingData data = null;

            try
            {
                int count = 0;

                lock (ThisLock)
                {
                    // if we've started the shutdown process, socket is disposed
                    // and calls to socket.EndReceive will throw 
                    if (!closed)
                    {
                        EndPoint dummy = CreateDummyEndPoint(listenSocket);
                        count = listenSocket.EndReceiveFrom(result, ref dummy);
                    }
                }

                if (count > 0)
                {
                    data = FramingCodec.Decode(new ArraySegment<byte>(buffer, 0, count));
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error in completing the async receive via EndReceiveFrom method.");
                Debug.WriteLine(e.ToString());
            }
            finally
            {
                if (data == null)
                {
                    this.bufferManager.ReturnBuffer(buffer);
                    buffer = null;
                }
            }

            return data;
        }

        //Called when an ansynchronous receieve operation completes
        //on the listening socket.
        void OnReceive(IAsyncResult result)
        {
            if (result.CompletedSynchronously)
                return;

            ContinueReceiving(result, ((SocketReceiveState)result.AsyncState).Socket);
        }

        void Dispatch(FramingData data)
        {
            if (data == null)
            {
                // TODO: Error handling
                return;
            }

            dataReceivedCallback(data);
        }

        void DispatchCallback(object state)
        {
            Dispatch((FramingData)state);
        }

        class SocketReceiveState
        {
            Socket socket;
            byte[] buffer;
            public SocketReceiveState(Socket socket, byte[] buffer)
            {
                this.socket = socket;
                this.buffer = buffer;
            }

            public Socket Socket
            {
                get { return this.socket; }
            }

            public byte[] Buffer
            {
                get { return this.buffer; }
            }
        }
    }
}
