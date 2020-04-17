//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization;
using System.Runtime.InteropServices;
using System.Security;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.Xml;
using System.ServiceModel.Security;

namespace Microsoft.Samples.Indigo.GZipEncoder
{
    //This class is used to create the custom encoder (CompressionMessageEncoder)
    public class CompressionMessageEncoderFactory : MessageEncoderFactory
    {
        #region Private fields
        //The factory will always return the same encoder
        MessageEncoder encoder;
        #endregion

        #region Constructor
        //The compression encoder wraps an inner encoder
        //We require a factory to be passed in that will create this inner encoder
        public CompressionMessageEncoderFactory(MessageEncoderFactory messageEncoderFactory)
        {
            if (messageEncoderFactory == null)
                throw new ArgumentNullException("messageEncoderFactory", "A valid message encoder factory must be passed to the CompressionEncoder");
            encoder = new CompressionMessageEncoder(messageEncoderFactory.Encoder);

        }
        #endregion

        #region Properties
        //The service framework uses this property to obtain an encoder from this encoder factory
        public override MessageEncoder Encoder
        {
            get { return encoder; }
        }

        public override MessageVersion MessageVersion
        {
            get { return encoder.MessageVersion; }
        }
        #endregion
    }

    //This is the actual compression encoder
    class CompressionMessageEncoder :MessageEncoder 
    {
        #region Private fields
        static string compressionContentType = "application/x-gzip";

        //This implementation wraps an inner encoder that actually converts a WCF Message
        //into textual XML, binary XML or some other format. This implementation then compresses the results.
        //The opposite happens when reading messages.
        //This member stores this inner encoder.
        MessageEncoder innerEncoder;
        #endregion

        #region Constructor
        //We require an inner encoder to be supplied (see comment above)
        internal CompressionMessageEncoder(MessageEncoder messageEncoder)
            : base()
        {
            if (messageEncoder == null)
                throw new ArgumentNullException("messageEncoder", "A valid message encoder must be passed to the CompressionEncoder");
            innerEncoder = messageEncoder;
        }
        #endregion

        #region Properties
        //public override string CharSet
        //{
        //    get { return ""; }
        //}

        public override string ContentType
        {
            get { return compressionContentType; }
        }

        public override string MediaType
        {
            get { return compressionContentType; }
        }

        //SOAP version to use - we delegate to the inner encoder for this
        public override MessageVersion MessageVersion
        {
            get { return innerEncoder.MessageVersion; }
        }
        #endregion

        #region Buffer compression and decompression
        
        //Helper method to compress an array of bytes
        static ArraySegment<byte> CompressBuffer(ArraySegment<byte> buffer, BufferManager bufferManager, int messageOffset)
        {
            MemoryStream memoryStream = new MemoryStream();
            memoryStream.Write(buffer.Array, 0, messageOffset);

            using (GZipStream gzStream = new GZipStream(memoryStream, CompressionMode.Compress, true))
            {
                gzStream.Write(buffer.Array, messageOffset, buffer.Count);
            }


            byte[] compressedBytes = memoryStream.ToArray();
            byte[] bufferedBytes = bufferManager.TakeBuffer(compressedBytes.Length);

            Array.Copy(compressedBytes, 0, bufferedBytes, 0, compressedBytes.Length);

            bufferManager.ReturnBuffer(buffer.Array);
            ArraySegment<byte> byteArray = new ArraySegment<byte>(bufferedBytes, messageOffset, bufferedBytes.Length - messageOffset);

            return byteArray;
        }

        //Helper method to decompress an array of bytes
        static ArraySegment<byte> DecompressBuffer(ArraySegment<byte> buffer, BufferManager bufferManager)
        {
            MemoryStream memoryStream = new MemoryStream(buffer.Array, buffer.Offset, buffer.Count - buffer.Offset);
            MemoryStream decompressedStream = new MemoryStream();
            int totalRead = 0;
            int blockSize = 1024;
            byte[] tempBuffer = bufferManager.TakeBuffer(blockSize);
            using (GZipStream gzStream = new GZipStream(memoryStream, CompressionMode.Decompress))
            {
                while (true)
                {
                    int bytesRead = gzStream.Read(tempBuffer, 0, blockSize);
                    if (bytesRead == 0)
                        break;
                    decompressedStream.Write(tempBuffer, 0, bytesRead);
                    totalRead += bytesRead;
                }
            }
            bufferManager.ReturnBuffer(tempBuffer);

            byte[] decompressedBytes = decompressedStream.ToArray();
            byte[] bufferManagerBuffer = bufferManager.TakeBuffer(decompressedBytes.Length + buffer.Offset);
            Array.Copy(buffer.Array, 0, bufferManagerBuffer, 0, buffer.Offset);
            Array.Copy(decompressedBytes, 0, bufferManagerBuffer, buffer.Offset, decompressedBytes.Length);

            ArraySegment<byte> byteArray = new ArraySegment<byte>(bufferManagerBuffer, buffer.Offset, decompressedBytes.Length);
            bufferManager.ReturnBuffer(buffer.Array);

            return byteArray;
        }
        #endregion

        
        #region Buffered message handling
        //One of the two main entry points into the encoder. Called by WCF to decode a buffered byte array into a Message.
        public override Message ReadMessage(ArraySegment<byte> buffer, BufferManager bufferManager, string contentType)
        {
            //Decompress the buffer
            ArraySegment<byte> decompressedBuffer = DecompressBuffer(buffer, bufferManager);
            //Use the inner encoder to decode the decompressed buffer
            Message returnMessage = innerEncoder.ReadMessage(decompressedBuffer, bufferManager);
            returnMessage.Properties.Encoder = this;
            return returnMessage;
        }

        //One of the two main entry points into the encoder. Called by WCF to encode a Message into a buffered byte array.
        public override ArraySegment<byte> WriteMessage(Message message, int maxMessageSize, BufferManager bufferManager, int messageOffset)
        {
            //Use the inner encoder to encode a Message into a buffered byte array
            ArraySegment<byte> buffer = innerEncoder.WriteMessage(message, maxMessageSize, bufferManager, messageOffset);
            //Compress the resulting byte array
            return CompressBuffer(buffer, bufferManager, messageOffset);
        }
        #endregion

        //Streaming equivalents of the above methods are not implemented
        #region Streaming message handling
        public override Message ReadMessage(System.IO.Stream stream, int maxSizeOfHeaders, string contentType)
        {
            GZipStream gzStream = new GZipStream(stream, CompressionMode.Decompress, true);
            return innerEncoder.ReadMessage(gzStream, maxSizeOfHeaders);
        }

        public override void WriteMessage(Message message, System.IO.Stream stream)
        {
            using (GZipStream gzStream = new GZipStream(stream, CompressionMode.Compress, true))
            {
                innerEncoder.WriteMessage(message, gzStream);
            }

            // innerEncoder.WriteMessage(message, gzStream) depends on that it can flush data by flushing 
            // the stream passed in, but the implementation of GZipStream.Flush will not flush underlying
            // stream, so we need to flush here.
            stream.Flush();
        }
        #endregion

    }

    //This is the binding element that, when plugged into a custom binding, will enable the compression encoder
    public sealed class CompressionMessageEncodingBindingElement : MessageEncodingBindingElement //BindingElement
    {

        #region Private fields
        //We will use an inner binding element to store information required for the inner encoder
        MessageEncodingBindingElement innerBindingElement;
        #endregion

        #region Constructor
        //By default, use the default text encoder as the inner encoder
        public CompressionMessageEncodingBindingElement()
            : this(new TextMessageEncodingBindingElement()) { }

        public CompressionMessageEncodingBindingElement(MessageEncodingBindingElement messageEncoderBindingElement)
        {
            this.innerBindingElement = messageEncoderBindingElement;
        }
        #endregion

        #region Properties
        public MessageEncodingBindingElement InnerMessageEncodingBindingElement
        {
            get { return innerBindingElement; }
            set { innerBindingElement = value; }
        }
        #endregion

        #region MessageEncodingBindingElement methods
        //Main entry point into the encoder binding element. Called by WCF to get the factory that will create the
        //message encoder
        public override MessageEncoderFactory CreateMessageEncoderFactory()
        {
            return new CompressionMessageEncoderFactory(innerBindingElement.CreateMessageEncoderFactory());
        }
       
        public override MessageVersion MessageVersion
        {
            get { return innerBindingElement.MessageVersion; }
            set { innerBindingElement.MessageVersion = value; }
        }
        #endregion

        #region BindingElement overrides
        public override BindingElement Clone()
        {
            return new CompressionMessageEncodingBindingElement(this.innerBindingElement);
        }
        public override T GetProperty<T>(BindingContext context)
        {
            return context.GetInnerProperty<T>();
        }

        public override IChannelFactory<TChannel> BuildChannelFactory<TChannel>(BindingContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            context.BindingParameters.Add(this);
            return context.BuildInnerChannelFactory<TChannel>();
        }

        public override IChannelListener<TChannel> BuildChannelListener<TChannel>(BindingContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            context.BindingParameters.Add(this);
            return context.BuildInnerChannelListener<TChannel>();
        }

        public override bool CanBuildChannelListener<TChannel>(BindingContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            context.BindingParameters.Add(this);
            return context.CanBuildInnerChannelListener<TChannel>();
        }
        #endregion
      
    }

    //This class is necessary to be able to plug in the compression encoder binding element through
    //a configuration file
    public class CompressionMessageEncodingElement : BindingElementExtensionElement
    {
        #region Constructor
        public CompressionMessageEncodingElement()
        {
        }
        #endregion

        #region Properties
        //Called by the WCF to discover the type of binding element this config section enables
        public override Type BindingElementType
        {
            get { return typeof(CompressionMessageEncodingBindingElement); }
        }

        //The only property we need to configure for our binding element is the type of
        //inner encoder to use. Here, we support text and binary.
        [ConfigurationProperty("innerMessageEncoding", DefaultValue = "textMessageEncoding")]
        public string InnerMessageEncoding
        {
            get { return (string)base["innerMessageEncoding"]; }
            set { base["innerMessageEncoding"] = value; }
        }
        #endregion

        #region BindingElementExtensionSection overrides
        //Called by the WCF to apply the configuration settings (the property above) to the binding element
        public override void ApplyConfiguration(BindingElement bindingElement)
        {
            CompressionMessageEncodingBindingElement binding = (CompressionMessageEncodingBindingElement)bindingElement;
            PropertyInformationCollection propertyInfo = this.ElementInformation.Properties;
            if (propertyInfo["innerMessageEncoding"].ValueOrigin != PropertyValueOrigin.Default)
            {
                switch (this.InnerMessageEncoding)
                {
                    case "textMessageEncoding":
                        binding.InnerMessageEncodingBindingElement = new TextMessageEncodingBindingElement();
                        break;
                    case "binaryMessageEncoding":
                        binding.InnerMessageEncodingBindingElement = new BinaryMessageEncodingBindingElement();
                        break;
                }
            }
        }

        //Called by the WCF to create the binding element
        protected override BindingElement CreateBindingElement()
        {
            CompressionMessageEncodingBindingElement bindingElement = new CompressionMessageEncodingBindingElement();
            this.ApplyConfiguration(bindingElement);
            return bindingElement;
        }
        #endregion
    }
}
