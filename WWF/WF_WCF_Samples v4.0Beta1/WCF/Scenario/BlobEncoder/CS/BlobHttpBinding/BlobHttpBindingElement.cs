//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Samples.BlobMessageEncoder
{
    using System;
    using System.Configuration;
    using System.Globalization;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Configuration;
    using System.Xml;

    public class BlobHttpBindingElement : StandardBindingElement
    {
        public BlobHttpBindingElement(string configurationName) :
            base(configurationName)
        {
        }

        public BlobHttpBindingElement() :
            this(null)
        {
        }

        [ConfigurationProperty(BlobHttpConfigurationStrings.BypassProxyOnLocal, DefaultValue = BlobHttpDefaults.DefaultBypassProxyOnLocal)]
        public bool BypassProxyOnLocal
        {
            get
            {
                return ((bool)(base[BlobHttpConfigurationStrings.BypassProxyOnLocal]));
            }
            set
            {
                base[BlobHttpConfigurationStrings.BypassProxyOnLocal] = value;
            }
        }

        [ConfigurationProperty(BlobHttpConfigurationStrings.HostNameComparisonMode, DefaultValue = BlobHttpDefaults.DefaultHostNameComparisonMode)]
        [ServiceModelEnumValidator(typeof(HostNameComparisonModeHelper))]
        public System.ServiceModel.HostNameComparisonMode HostNameComparisonMode
        {
            get
            {
                return ((System.ServiceModel.HostNameComparisonMode)(base[BlobHttpConfigurationStrings.HostNameComparisonMode]));
            }
            set
            {
                base[BlobHttpConfigurationStrings.HostNameComparisonMode] = value;
            }
        }

        [ConfigurationProperty(BlobHttpConfigurationStrings.MaxBufferPoolSize, DefaultValue = BlobHttpDefaults.DefaultMaxBufferPoolSize)]
        [LongValidator(MinValue = 0)]
        public long MaxBufferPoolSize
        {
            get
            {
                return ((long)(base[BlobHttpConfigurationStrings.MaxBufferPoolSize]));
            }
            set
            {
                base[BlobHttpConfigurationStrings.MaxBufferPoolSize] = value;
            }
        }

        [ConfigurationProperty(BlobHttpConfigurationStrings.MaxBufferSize, DefaultValue = BlobHttpDefaults.DefaultMaxBufferSize)]
        [IntegerValidator(MinValue = 1)]
        public int MaxBufferSize
        {
            get
            {
                return ((int)(base[BlobHttpConfigurationStrings.MaxBufferSize]));
            }
            set
            {
                base[BlobHttpConfigurationStrings.MaxBufferSize] = value;
            }
        }

        [ConfigurationProperty(BlobHttpConfigurationStrings.MaxReceivedMessageSize, DefaultValue = BlobHttpDefaults.DefaultMaxReceivedMessageSize)]
        [LongValidator(MinValue = 1)]
        public long MaxReceivedMessageSize
        {
            get
            {
                return ((long)(base[BlobHttpConfigurationStrings.MaxReceivedMessageSize]));
            }
            set
            {
                base[BlobHttpConfigurationStrings.MaxReceivedMessageSize] = value;
            }
        }

        [ConfigurationProperty(BlobHttpConfigurationStrings.ProxyAddress, DefaultValue = BlobHttpDefaults.DefaultProxyAddress)]
        [AddressValidator]
        public System.Uri ProxyAddress
        {
            get
            {
                return ((System.Uri)(base[BlobHttpConfigurationStrings.ProxyAddress]));
            }
            set
            {
                base[BlobHttpConfigurationStrings.ProxyAddress] = value;
            }
        }

        [ConfigurationProperty(BlobHttpConfigurationStrings.ReaderQuotas, DefaultValue = BlobHttpDefaults.DefaultReaderQuotas)]
        public XmlDictionaryReaderQuotasElement ReaderQuotas
        {
            get
            {
                return (XmlDictionaryReaderQuotasElement)base[BlobHttpConfigurationStrings.ReaderQuotas];
            }
        }

        [ConfigurationProperty(BlobHttpConfigurationStrings.TransferMode, DefaultValue = BlobHttpDefaults.DefaultTransferMode)]
        [ServiceModelEnumValidator(typeof(TransferModeHelper))]
        public System.ServiceModel.TransferMode TransferMode
        {
            get
            {
                return ((System.ServiceModel.TransferMode)(base[BlobHttpConfigurationStrings.TransferMode]));
            }
            set
            {
                base[BlobHttpConfigurationStrings.TransferMode] = value;
            }
        }

        [ConfigurationProperty(BlobHttpConfigurationStrings.UseDefaultWebProxy, DefaultValue = BlobHttpDefaults.DefaultUseDefaultWebProxy)]
        public bool UseDefaultWebProxy
        {
            get
            {
                return ((bool)(base[BlobHttpConfigurationStrings.UseDefaultWebProxy]));
            }
            set
            {
                base[BlobHttpConfigurationStrings.UseDefaultWebProxy] = value;
            }
        }

        protected override Type BindingElementType
        {
            get
            {
                return typeof(BlobHttpBinding);
            }
        }

        protected override ConfigurationPropertyCollection Properties
        {
            get
            {
                ConfigurationPropertyCollection properties = base.Properties;
                properties.Add(new ConfigurationProperty(BlobHttpConfigurationStrings.HostNameComparisonMode, typeof(System.ServiceModel.HostNameComparisonMode), BlobHttpDefaults.DefaultHostNameComparisonMode));
                properties.Add(new ConfigurationProperty(BlobHttpConfigurationStrings.MaxBufferSize, typeof(int), BlobHttpDefaults.DefaultMaxBufferSize));
                properties.Add(new ConfigurationProperty(BlobHttpConfigurationStrings.MaxBufferPoolSize, typeof(long), BlobHttpDefaults.DefaultMaxBufferPoolSize));
                properties.Add(new ConfigurationProperty(BlobHttpConfigurationStrings.MaxReceivedMessageSize, typeof(long), BlobHttpDefaults.DefaultMaxReceivedMessageSize));
                properties.Add(new ConfigurationProperty(BlobHttpConfigurationStrings.TransferMode, typeof(System.ServiceModel.TransferMode), BlobHttpDefaults.DefaultTransferMode));
                properties.Add(new ConfigurationProperty(BlobHttpConfigurationStrings.ReaderQuotas, typeof(XmlDictionaryReaderQuotasElement), BlobHttpDefaults.DefaultReaderQuotas));
                return properties;
            }
        }

        protected override void InitializeFrom(Binding binding)
        {
            base.InitializeFrom(binding);
            BlobHttpBinding BlobHttpBinding = ((BlobHttpBinding)(binding));
            this.HostNameComparisonMode = BlobHttpBinding.HostNameComparisonMode;
            this.MaxBufferSize = BlobHttpBinding.MaxBufferSize;
            this.MaxBufferPoolSize = BlobHttpBinding.MaxBufferPoolSize;
            this.MaxReceivedMessageSize = BlobHttpBinding.MaxReceivedMessageSize;
            this.TransferMode = BlobHttpBinding.TransferMode;

            // Copy reader quotas over.
            this.ReaderQuotas.MaxDepth = BlobHttpBinding.ReaderQuotas.MaxDepth;
            this.ReaderQuotas.MaxStringContentLength = BlobHttpBinding.ReaderQuotas.MaxStringContentLength;
            this.ReaderQuotas.MaxArrayLength = BlobHttpBinding.ReaderQuotas.MaxArrayLength;
            this.ReaderQuotas.MaxBytesPerRead = BlobHttpBinding.ReaderQuotas.MaxBytesPerRead;
            this.ReaderQuotas.MaxNameTableCharCount = BlobHttpBinding.ReaderQuotas.MaxNameTableCharCount;
        }

        protected override void OnApplyConfiguration(Binding binding)
        {
            if ((binding == null))
            {
                throw new System.ArgumentNullException("binding");
            }
            if ((binding.GetType() != typeof(BlobHttpBinding)))
            {
                throw new System.ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid type for binding. Expected type: {0}. Type passed in: {1}.", typeof(BlobHttpBinding).AssemblyQualifiedName, binding.GetType().AssemblyQualifiedName));
            }
            BlobHttpBinding BlobHttpBinding = ((BlobHttpBinding)(binding));
            BlobHttpBinding.HostNameComparisonMode = this.HostNameComparisonMode;
            BlobHttpBinding.MaxBufferSize = this.MaxBufferSize;
            BlobHttpBinding.MaxBufferPoolSize = this.MaxBufferPoolSize;
            BlobHttpBinding.MaxReceivedMessageSize = this.MaxReceivedMessageSize;
            BlobHttpBinding.TransferMode = this.TransferMode;

            // Copy reader quotas over if set from config.
            if (this.ReaderQuotas.MaxDepth != 0)
            {
                BlobHttpBinding.ReaderQuotas.MaxDepth = this.ReaderQuotas.MaxDepth;
            }
            if (this.ReaderQuotas.MaxStringContentLength != 0)
            {
                BlobHttpBinding.ReaderQuotas.MaxStringContentLength = this.ReaderQuotas.MaxStringContentLength;
            }
            if (this.ReaderQuotas.MaxArrayLength != 0)
            {
                BlobHttpBinding.ReaderQuotas.MaxArrayLength = this.ReaderQuotas.MaxArrayLength;
            }
            if (this.ReaderQuotas.MaxBytesPerRead != 0)
            {
                BlobHttpBinding.ReaderQuotas.MaxBytesPerRead = this.ReaderQuotas.MaxBytesPerRead;
            }
            if (this.ReaderQuotas.MaxNameTableCharCount != 0)
            {
                BlobHttpBinding.ReaderQuotas.MaxNameTableCharCount = this.ReaderQuotas.MaxNameTableCharCount;
            }
        }
    }


}
