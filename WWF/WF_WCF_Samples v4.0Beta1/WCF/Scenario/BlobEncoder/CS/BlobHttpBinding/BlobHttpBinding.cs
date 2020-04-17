//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Samples.BlobMessageEncoder
{
    using System.Configuration;
    using System.Globalization;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Configuration;
    using System.Xml;

    public class BlobHttpBinding : Binding
    {
        HttpTransportBindingElement httpTransport;
        BlobMessageEncodingBindingElement blobEncoding;

        public BlobHttpBinding()
        {
            this.httpTransport = new HttpTransportBindingElement();

            this.blobEncoding = new BlobMessageEncodingBindingElement();
        }
        public BlobHttpBinding(string configurationName)
        {
            if (configurationName != null)
            {
                ApplyConfiguration(configurationName);
            }
            else
            {
                throw new System.Configuration.ConfigurationErrorsException("The configuration name provided is null ");
            }
        }

        public HostNameComparisonMode HostNameComparisonMode
        {
            get
            {
                return httpTransport.HostNameComparisonMode;
            }
            set
            {
                httpTransport.HostNameComparisonMode = value;

            }
        }

        public int MaxBufferSize
        {
            get
            {
                return httpTransport.MaxBufferSize;
            }
            set
            {
                httpTransport.MaxBufferSize = value;

            }
        }

        public long MaxBufferPoolSize
        {
            get
            {
                return httpTransport.MaxBufferPoolSize;
            }
            set
            {
                httpTransport.MaxBufferPoolSize = value;

            }
        }

        public long MaxReceivedMessageSize
        {
            get
            {
                return httpTransport.MaxReceivedMessageSize;
            }
            set
            {
                httpTransport.MaxReceivedMessageSize = value;

            }
        }

        public TransferMode TransferMode
        {
            get
            {
                return httpTransport.TransferMode;
            }
            set
            {
                httpTransport.TransferMode = value;

            }
        }

        public XmlDictionaryReaderQuotas ReaderQuotas
        {
            get
            {
                return blobEncoding.ReaderQuotas;
            }
            set
            {
                if (value != null)
                {
                    value.CopyTo(blobEncoding.ReaderQuotas);
                }
            }
        }

        public EnvelopeVersion EnvelopeVersion
        {
            get { return EnvelopeVersion.None; }
        }

        public override string Scheme
        {
            get
            {
                return httpTransport.Scheme;
            }
        }

        void ApplyConfiguration(string configurationName)
        {
            BindingsSection bindings = ((BindingsSection)(ConfigurationManager.GetSection("system.serviceModel/bindings")));
            BlobHttpBindingCollectionElement section = (BlobHttpBindingCollectionElement)bindings["blobHttpBinding"];
            BlobHttpBindingElement element = section.Bindings[configurationName];

            if (element == null)
            {
                throw new System.Configuration.ConfigurationErrorsException(string.Format(CultureInfo.CurrentCulture, "There is no binding named {0} at {1}.", configurationName, section.BindingName));
            }
            else
            {
                element.ApplyConfiguration(this);
            }
        }

        public override BindingElementCollection CreateBindingElements()
        { 
            BindingElementCollection bindingElements = new BindingElementCollection();
            bindingElements.Add(this.blobEncoding);
            bindingElements.Add(this.httpTransport);
            return bindingElements.Clone();
        }

    }
}
