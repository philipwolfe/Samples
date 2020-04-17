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
#endregion

namespace Microsoft.ServiceModel.Samples.Transport
{
    abstract class TcpDuplexSessionChannel : ChannelBase, IDuplexSessionChannel
    {
        #region member variables
        const int maxBufferSize = 64 * 1024;
        BufferManager bufferManager;
        MessageEncoder encoder;
        EndpointAddress localAddress;
        EndpointAddress remoteAddress;
        Uri via;
        IDuplexSession session;
        Socket socket;
        object readLock = new object();
        object writeLock = new object();

        protected MessageEncoder MessageEncoder
        {
            get { return this.encoder; }
        }
        #endregion
        internal static readonly EndpointAddress AnonymousAddress = 
            new EndpointAddress("http://schemas.xmlsoap.org/ws/2004/08/addressing/role/anonymous");

        #region Ctor and initialization
        protected TcpDuplexSessionChannel(
            MessageEncoderFactory messageEncoderFactory, BufferManager bufferManager,
            EndpointAddress remoteAddress, EndpointAddress localAddress, Uri via, ChannelManagerBase channelManager)
            : base (channelManager)
        {
            this.remoteAddress = remoteAddress;
            this.localAddress = localAddress;
            this.via = via;
            this.session = new TcpDuplexSession(this);
            this.encoder = messageEncoderFactory.CreateSessionEncoder();
            this.bufferManager = bufferManager;
        }

        protected void InitializeSocket(Socket socket)
        {
            if (this.socket != null)
            {
                throw new InvalidOperationException("Socket is already set");
            }

            this.socket = socket;
        }
        #endregion

        #region Exception Conversion
        protected static Exception ConvertSocketException(SocketException socketException, string operation)
        {
            if (socketException.ErrorCode == 10049 // WSAEADDRNOTAVAIL 
                || socketException.ErrorCode == 10061 // WSAECONNREFUSED 
                || socketException.ErrorCode == 10050 // WSAENETDOWN 
                || socketException.ErrorCode == 10051 // WSAENETUNREACH 
                || socketException.ErrorCode == 10064 // WSAEHOSTDOWN 
                || socketException.ErrorCode == 10065) // WSAEHOSTUNREACH
            {
                return new EndpointNotFoundException(string.Format(operation + " error: {0} ({1})", socketException.Message, socketException.ErrorCode), socketException);
            }
            if (socketException.ErrorCode == 10060) // WSAETIMEDOUT
            {
                return new TimeoutException(operation + " timed out.", socketException);
            }
            else
            {
                return new CommunicationException(string.Format(operation + " error: {0} ({1})", socketException.Message, socketException.ErrorCode), socketException);
            }
        }

        void SocketSend(byte[] buffer)
        {
            SocketSend(new ArraySegment<byte>(buffer));
        }

        void SocketSend(ArraySegment<byte> buffer)
        {
            try
            {
                socket.Send(buffer.Array, buffer.Offset, buffer.Count, SocketFlags.None);
            }
            catch (SocketException socketException)
            {
                throw ConvertSocketException(socketException, "Send");
            }
        }

        int SocketReceive(byte[] buffer, int offset, int size)
        {
            try
            {
                return socket.Receive(buffer, offset, size, SocketFlags.None);
            }
            catch (SocketException socketException)
            {
                throw ConvertSocketException(socketException, "Receive");
            }
        }

        byte[] SocketReceive(int size)
        {
            int bytesReadTotal = 0;
            int bytesRead = 0;
            byte[] data = bufferManager.TakeBuffer(size);

            while (bytesReadTotal < size)
            {
                bytesRead = SocketReceive(data, bytesReadTotal, size - bytesReadTotal);
                bytesReadTotal += bytesRead;
                if (bytesRead == 0)
                {
                    throw new CommunicationException("Premature EOF reached");
                }
            }

            return data;
        }
        #endregion

        #region Encoding Members
        // Address the Message and serialize it into a byte array.
        ArraySegment<byte> EncodeMessage(Message message)
        {
            try
            {
                this.RemoteAddress.ApplyTo(message);
                return encoder.WriteMessage(message, maxBufferSize, bufferManager);
            }
            finally
            {
                // we've consumed the message by serializing it, so clean up
                message.Close();
            }
        }

        Message DecodeMessage(ArraySegment<byte> data)
        {
            if (data.Array == null)
                return null;
            else
                return encoder.ReadMessage(data, bufferManager);
        }
        #endregion

        #region IOutputChannel Members
        public void Send(Message message, TimeSpan timeout)
        {
            base.ThrowIfDisposedOrNotOpen();
            lock (writeLock)
            {
                try
                {
                    ArraySegment<byte> encodedBytes = EncodeMessage(message);
                    WriteData(encodedBytes);
                }
                catch (SocketException socketException)
                {
                    throw ConvertSocketException(socketException, "Receive");
                }
            }
        }

        public void Send(Message message)
        {
            this.Send(message, DefaultSendTimeout);
        }
        #endregion

        #region WSE Framing 
        ArraySegment<byte> ReadData()
        {
            // 4 bytes for WSE preamble and 8 bytes for lengths
            int bytesToRead = 12;
            byte[] preambleBytes = this.bufferManager.TakeBuffer(bytesToRead);
            int bytesRead = 0;
            int bytesReadTotal = 0;

            while (bytesReadTotal < bytesToRead)
            {
                bytesRead = SocketReceive(preambleBytes, bytesReadTotal,
                    bytesToRead - bytesReadTotal);

                bytesReadTotal += bytesRead;

                if (bytesRead == 0)
                {
                    if (bytesReadTotal != 0)
                    {
                        throw new CommunicationException("Premature EOF reached");
                    }
                    else
                    {
                        return new ArraySegment<byte>();
                    }
                }
            }

            // drain the ID + TYPE
            int idLength = (preambleBytes[4] << 8) + preambleBytes[5];
            int typeLength = (preambleBytes[6] << 8) + preambleBytes[7];

            // need to also drain padding
            if ((idLength % 4) > 0)
            {
                idLength += (4 - (idLength % 4));
            }

            if ((typeLength % 4) > 0)
            {
                typeLength += (4 - (typeLength % 4));
            }

            byte[] dummy = SocketReceive(idLength + typeLength);
            this.bufferManager.ReturnBuffer(dummy);

            // now read the data itself
            int dataLength = (preambleBytes[8] << 24)
                + (preambleBytes[9] << 16)
                + (preambleBytes[10] << 8)
                + preambleBytes[11];

            // total to read should include padding
            bytesToRead = dataLength;
            if ((dataLength % 4) > 0)
            {
                bytesToRead += (4 - (dataLength % 4));
            }

            byte[] data = SocketReceive(bytesToRead);

            if ((preambleBytes[0] & 0x02) == 0)
            {
                // if ME wasn't set, read another record (WSE sends a second with ME set)
                byte[] WseEndRecord = { 
                    0x0A, 0x40, 0, 0, // version 0x01+ME, no type, no options
                    0, 0, 0, 0, 0, 0, 0, 0 }; // no lengths

                byte[] endRecord = SocketReceive(WseEndRecord.Length);
                for (int i = 0; i < WseEndRecord.Length; i++)
                {
                    if (endRecord[i] != WseEndRecord[i])
                    {
                        throw new CommunicationException("Invalid second framing record");
                    }
                }
                this.bufferManager.ReturnBuffer(endRecord);
            }
            this.bufferManager.ReturnBuffer(preambleBytes);

            return new ArraySegment<byte>(data, 0, dataLength);
        }

        void WriteData(ArraySegment<byte> data)
        {
            byte[] ID = { 0x00, 0x00, 0x00, 0x00 };

            // WSE 3.0 uses the SOAP namespace
            //byte[] TYPE = Encoding.UTF8.GetBytes(MessageEncoder.ContentType);
            byte[] TYPE;

            if (MessageEncoder.MessageVersion.Envelope == EnvelopeVersion.Soap11)
            {
                TYPE = Encoding.UTF8.GetBytes("http://schemas.xmlsoap.org/soap/envelope/");
            }
            else
            {
                TYPE = Encoding.UTF8.GetBytes("http://www.w3.org/2003/05/soap-envelope");
            }

            // first write the preamble (4 bytes)
            byte[] WsePreamble = {
                0x0E, // version 0x01+MB+ME
                0x20, 0, 0 }; // TYPE_T=URI, no options

            SocketSend(WsePreamble);

            // then write the length fields(8 bytes)
            byte[] lengthBytes = new byte[] {
                (byte)((ID.Length & 0x0000FF00) >> 8),
                (byte)(ID.Length & 0x000000FF),
                (byte)((TYPE.Length & 0x0000FF00) >> 8),
                (byte)(TYPE.Length & 0x000000FF),
                (byte)((data.Count & 0xFF000000) >> 24),
                (byte)((data.Count & 0x00FF0000) >> 16),
                (byte)((data.Count & 0x0000FF00) >> 8),
                (byte)(data.Count & 0x000000FF)
                };

            SocketSend(lengthBytes);
            SocketSend(ID);
            SocketSend(TYPE);

            if ((TYPE.Length % 4) > 0) // need to pad to multiple of 4 bytes
            {
                byte[] padBytes = new byte[4 - (TYPE.Length % 4)];
                SocketSend(padBytes);
            }
            SocketSend(data);
            if ((data.Count % 4) > 0) // need to pad data to multiple of 4 bytes as well
            {
                byte[] padBytes = new byte[4 - (data.Count % 4)];
                SocketSend(padBytes);
            }
        }
        #endregion

        protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return new CompletedAsyncResult(callback, state);
        }

        protected override void OnEndOpen(IAsyncResult result)
        {
            CompletedAsyncResult.End(result);
        }

        protected override void OnOpen(TimeSpan timeout)
        {
        }

        protected override void OnAbort()
        {
            if (this.socket != null)
            {
                socket.Close(0);
            }
        }

        protected override void OnClose(TimeSpan timeout)
        {
            socket.Close((int)timeout.TotalMilliseconds);
        }

        protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
        {
            socket.Close((int)timeout.TotalMilliseconds);
            return new CompletedAsyncResult(callback, state);
        }

        protected override void OnEndClose(IAsyncResult result)
        {
            CompletedAsyncResult.End(result);
        }

        #region IInputChannel Members
        public EndpointAddress LocalAddress
        {
            get { return this.localAddress; }
        }

        public Message Receive()
        {
            return this.Receive(DefaultReceiveTimeout);
        }

        public Message Receive(TimeSpan timeout)
        {
            base.ThrowIfDisposedOrNotOpen();
            lock (readLock)
            {
                try
                {
                    ArraySegment<byte> encodedBytes = ReadData();
                    return DecodeMessage(encodedBytes);
                }
                catch (SocketException socketException)
                {
                    throw ConvertSocketException(socketException, "Receive");
                }
            }
        }

        public bool TryReceive(TimeSpan timeout, out Message message)
        {
            try
            {
                message = Receive(timeout);
                return true;
            }
            catch (TimeoutException)
            {
                message = null;
                return false;
            }
        }
        #endregion

        #region ISessionChannel<IDuplexSession> Members

        public IDuplexSession Session
        {
            get { return this.session; }
        }

        class TcpDuplexSession : IDuplexSession
        {
            TcpDuplexSessionChannel channel;
            string id;

            public TcpDuplexSession(TcpDuplexSessionChannel channel)
            {
                this.channel = channel;
                this.id = Guid.NewGuid().ToString();
            }

            public void CloseOutputSession(TimeSpan timeout)
            {
                if (channel.State != CommunicationState.Closing)
                {
                    channel.ThrowIfDisposedOrNotOpen();
                }
                channel.socket.Shutdown(SocketShutdown.Send);
            }

            #region IDuplexSession Members

            public IAsyncResult BeginCloseOutputSession(TimeSpan timeout, AsyncCallback callback, object state)
            {
                throw new Exception("The method or operation is not implemented.");
            }

            public IAsyncResult BeginCloseOutputSession(AsyncCallback callback, object state)
            {
                throw new Exception("The method or operation is not implemented.");
            }

            public void EndCloseOutputSession(IAsyncResult result)
            {
                throw new Exception("The method or operation is not implemented.");
            }

            public void CloseOutputSession()
            {
                CloseOutputSession(channel.DefaultCloseTimeout);
            }

            #endregion

            #region ISession Members

            public string Id
            {
                get { return this.id; }
            }

            #endregion
        }
        #endregion

        #region Advanced Members
        #region IInputChannel Advanced Members
        public IAsyncResult BeginReceive(TimeSpan timeout, AsyncCallback callback, object state)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IAsyncResult BeginReceive(AsyncCallback callback, object state)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IAsyncResult BeginTryReceive(TimeSpan timeout, AsyncCallback callback, object state)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IAsyncResult BeginWaitForMessage(TimeSpan timeout, AsyncCallback callback, object state)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public Message EndReceive(IAsyncResult result)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool EndTryReceive(IAsyncResult result, out Message message)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool EndWaitForMessage(IAsyncResult result)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool WaitForMessage(TimeSpan timeout)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        #endregion

        #region IOutputChannel Advanced Members
        public IAsyncResult BeginSend(Message message, TimeSpan timeout, AsyncCallback callback, object state)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IAsyncResult BeginSend(Message message, AsyncCallback callback, object state)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void EndSend(IAsyncResult result)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public EndpointAddress RemoteAddress
        {
            get { return this.remoteAddress; }
        }

        public Uri Via
        {
            get { return this.via; }
        }
        #endregion
        #endregion
    }
}