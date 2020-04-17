
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.ServiceModel;
using System.ServiceModel.Channels;


namespace Microsoft.ServiceModel.Samples
{
    public class CustomTextMessageBindingElement : MessageEncodingBindingElement
    {
        private MessageVersion msgVersion;
        private string mediaType;
        private string encoding;

        public CustomTextMessageBindingElement(string encoding, string mediaType,
            MessageVersion msgVersion)
        {
            this.MessageVersion = msgVersion;
            this.MediaType = mediaType;
            this.Encoding = encoding;
        }

        public CustomTextMessageBindingElement(string encoding, string mediaType)
            : this(encoding, mediaType, MessageVersion.Soap11WSAddressing10)
        {
        }

        public CustomTextMessageBindingElement(string encoding)
            : this(encoding, "text/xml")
        {

        }

        public CustomTextMessageBindingElement()
            : this("UTF-8")
        {
        }
        
        public override MessageVersion MessageVersion
        {
            get 
            { 
                return this.msgVersion;
            }
            
            set
            {
                this.msgVersion = value;
            }
        }


        public string MediaType
        {
            get
            {
                return this.mediaType;
            }

            set
            {
                this.mediaType = value;
            }
        }

        public string Encoding
        {
            get
            {
                return this.encoding;
            }

            set
            {
                this.encoding = value;
            }
        }
    
        #region IMessageEncodingBindingElement Members

        public override MessageEncoderFactory  CreateMessageEncoderFactory()
        {
            return new CustomTextMessageEncoderFactory(this.MediaType,
                this.Encoding, this.MessageVersion);    
        }

        #endregion
        
        
        public override BindingElement Clone()
        {
            return new CustomTextMessageBindingElement(
                this.Encoding, this.MediaType, this.MessageVersion);
        }

        public override IChannelFactory<TChannel> BuildChannelFactory<TChannel>(BindingContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            context.BindingParameters.Add(this);
            return context.BuildInnerChannelFactory<TChannel>();
        }

        public override bool CanBuildChannelFactory<TChannel>(BindingContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            return context.CanBuildInnerChannelFactory<TChannel>();
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

        public override T GetProperty<T>(BindingContext context)
        {
            return context.GetInnerProperty<T>();
        }
    }
}
