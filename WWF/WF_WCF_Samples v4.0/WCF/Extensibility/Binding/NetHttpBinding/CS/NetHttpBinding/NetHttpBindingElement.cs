﻿//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Configuration;
using System.Globalization;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;

namespace Microsoft.Samples.NetHttpBinding {
    
    public class NetHttpBindingElement : StandardBindingElement {
        
        public NetHttpBindingElement(string configurationName) : 
                base(configurationName) {
        }

        public NetHttpBindingElement()
            : 
                this(null) {
        }
        
        protected override Type BindingElementType {
            get {
                return typeof(NetHttpBinding);
            }
        }

        [ConfigurationProperty(NetHttpConfigurationStrings.BypassProxyOnLocal, DefaultValue = NetHttpDefaults.DefaultBypassProxyOnLocal)]
        public bool BypassProxyOnLocal {
            get {
                return ((bool)(base[NetHttpConfigurationStrings.BypassProxyOnLocal]));
            }
            set {
                base[NetHttpConfigurationStrings.BypassProxyOnLocal] = value;
            }
        }

        [ConfigurationProperty(NetHttpConfigurationStrings.HostNameComparisonMode, DefaultValue = NetHttpDefaults.DefaultHostNameComparisonMode)]
        public System.ServiceModel.HostNameComparisonMode HostNameComparisonMode {
            get {
                return ((System.ServiceModel.HostNameComparisonMode)(base[NetHttpConfigurationStrings.HostNameComparisonMode]));
            }
            set {
                base[NetHttpConfigurationStrings.HostNameComparisonMode] = value;
            }
        }

        [ConfigurationProperty(NetHttpConfigurationStrings.MaxBufferSize, DefaultValue = NetHttpDefaults.DefaultMaxBufferSize)]
        public int MaxBufferSize {
            get {
                return ((int)(base[NetHttpConfigurationStrings.MaxBufferSize]));
            }
            set {
                base[NetHttpConfigurationStrings.MaxBufferSize] = value;
            }
        }

        [ConfigurationProperty(NetHttpConfigurationStrings.MaxBufferPoolSize, DefaultValue = NetHttpDefaults.DefaultMaxBufferPoolSize)]
        public long MaxBufferPoolSize {
            get {
                return ((long)(base[NetHttpConfigurationStrings.MaxBufferPoolSize]));
            }
            set {
                base[NetHttpConfigurationStrings.MaxBufferPoolSize] = value;
            }
        }

        [ConfigurationProperty(NetHttpConfigurationStrings.MaxReceivedMessageSize, DefaultValue = NetHttpDefaults.DefaultMaxReceivedMessageSize)]
        public long MaxReceivedMessageSize {
            get {
                return ((long)(base[NetHttpConfigurationStrings.MaxReceivedMessageSize]));
            }
            set {
                base[NetHttpConfigurationStrings.MaxReceivedMessageSize] = value;
            }
        }

        [ConfigurationProperty(NetHttpConfigurationStrings.ProxyAddress, DefaultValue = NetHttpDefaults.DefaultProxyAddress)]
        public System.Uri ProxyAddress {
            get {
                return ((System.Uri)(base[NetHttpConfigurationStrings.ProxyAddress]));
            }
            set {
                base[NetHttpConfigurationStrings.ProxyAddress] = value;
            }
        }

        [ConfigurationProperty(NetHttpConfigurationStrings.SecurityMode, DefaultValue = NetHttpDefaults.DefaultSecurityMode)]
        public Microsoft.Samples.NetHttpBinding.NetHttpSecurityMode SecurityMode {
            get {
                return ((Microsoft.Samples.NetHttpBinding.NetHttpSecurityMode)(base[NetHttpConfigurationStrings.SecurityMode]));
            }
            set {
                base[NetHttpConfigurationStrings.SecurityMode] = value;
            }
        }

        [ConfigurationProperty(NetHttpConfigurationStrings.TransferMode, DefaultValue = NetHttpDefaults.DefaultTransferMode)]
        public System.ServiceModel.TransferMode TransferMode {
            get {
                return ((System.ServiceModel.TransferMode)(base[NetHttpConfigurationStrings.TransferMode]));
            }
            set {
                base[NetHttpConfigurationStrings.TransferMode] = value;
            }
        }

        [ConfigurationProperty(NetHttpConfigurationStrings.UseDefaultWebProxy, DefaultValue = NetHttpDefaults.DefaultUseDefaultWebProxy)]
        public bool UseDefaultWebProxy {
            get {
                return ((bool)(base[NetHttpConfigurationStrings.UseDefaultWebProxy]));
            }
            set {
                base[NetHttpConfigurationStrings.UseDefaultWebProxy] = value;
            }
        }

        [ConfigurationProperty(NetHttpConfigurationStrings.ReaderQuotas, DefaultValue = NetHttpDefaults.DefaultReaderQuotas)]
        public System.Xml.XmlDictionaryReaderQuotas ReaderQuotas {
            get {
                return ((System.Xml.XmlDictionaryReaderQuotas)(base[NetHttpConfigurationStrings.ReaderQuotas]));
            }
            set {
                base[NetHttpConfigurationStrings.ReaderQuotas] = value;
            }
        }
        
        protected override ConfigurationPropertyCollection Properties {
            get {
                ConfigurationPropertyCollection properties = base.Properties;
                properties.Add(new ConfigurationProperty(NetHttpConfigurationStrings.BypassProxyOnLocal, typeof(bool), NetHttpDefaults.DefaultBypassProxyOnLocal));
                properties.Add(new ConfigurationProperty(NetHttpConfigurationStrings.HostNameComparisonMode, typeof(System.ServiceModel.HostNameComparisonMode), NetHttpDefaults.DefaultHostNameComparisonMode));
                properties.Add(new ConfigurationProperty(NetHttpConfigurationStrings.MaxBufferSize, typeof(int), NetHttpDefaults.DefaultMaxBufferSize));
                properties.Add(new ConfigurationProperty(NetHttpConfigurationStrings.MaxBufferPoolSize, typeof(long), NetHttpDefaults.DefaultMaxBufferPoolSize));
                properties.Add(new ConfigurationProperty(NetHttpConfigurationStrings.MaxReceivedMessageSize, typeof(long), NetHttpDefaults.DefaultMaxReceivedMessageSize));
                properties.Add(new ConfigurationProperty(NetHttpConfigurationStrings.ProxyAddress, typeof(System.Uri), NetHttpDefaults.DefaultProxyAddress));
                properties.Add(new ConfigurationProperty(NetHttpConfigurationStrings.SecurityMode, typeof(Microsoft.Samples.NetHttpBinding.NetHttpSecurityMode), NetHttpDefaults.DefaultSecurityMode));
                properties.Add(new ConfigurationProperty(NetHttpConfigurationStrings.TransferMode, typeof(System.ServiceModel.TransferMode), NetHttpDefaults.DefaultTransferMode));
                properties.Add(new ConfigurationProperty(NetHttpConfigurationStrings.UseDefaultWebProxy, typeof(bool), NetHttpDefaults.DefaultUseDefaultWebProxy));
                properties.Add(new ConfigurationProperty(NetHttpConfigurationStrings.ReaderQuotas, typeof(System.Xml.XmlDictionaryReaderQuotas), NetHttpDefaults.DefaultReaderQuotas));
                return properties;
            }
        }
        
        protected override void InitializeFrom(Binding binding) {
            base.InitializeFrom(binding);
            NetHttpBinding netHttpBinding = ((NetHttpBinding)(binding));
            this.BypassProxyOnLocal = netHttpBinding.BypassProxyOnLocal;
            this.HostNameComparisonMode = netHttpBinding.HostNameComparisonMode;
            this.MaxBufferSize = netHttpBinding.MaxBufferSize;
            this.MaxBufferPoolSize = netHttpBinding.MaxBufferPoolSize;
            this.MaxReceivedMessageSize = netHttpBinding.MaxReceivedMessageSize;
            this.ProxyAddress = netHttpBinding.ProxyAddress;
            this.SecurityMode = netHttpBinding.SecurityMode;
            this.TransferMode = netHttpBinding.TransferMode;
            this.UseDefaultWebProxy = netHttpBinding.UseDefaultWebProxy;
            this.ReaderQuotas = netHttpBinding.ReaderQuotas;
        }
        
        protected override void OnApplyConfiguration(Binding binding) {
            if ((binding == null)) {
                throw new System.ArgumentNullException("binding");
            }
            if ((binding.GetType() != typeof(NetHttpBinding))) {
                throw new System.ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid type for binding. Expected type: {0}. Type passed in: {1}.", typeof(NetHttpBinding).AssemblyQualifiedName, binding.GetType().AssemblyQualifiedName));
            }
            NetHttpBinding netHttpBinding = ((NetHttpBinding)(binding));
            netHttpBinding.BypassProxyOnLocal = this.BypassProxyOnLocal;
            netHttpBinding.HostNameComparisonMode = this.HostNameComparisonMode;
            netHttpBinding.MaxBufferSize = this.MaxBufferSize;
            netHttpBinding.MaxBufferPoolSize = this.MaxBufferPoolSize;
            netHttpBinding.MaxReceivedMessageSize = this.MaxReceivedMessageSize;
            netHttpBinding.ProxyAddress = this.ProxyAddress;
            netHttpBinding.SecurityMode = this.SecurityMode;
            netHttpBinding.TransferMode = this.TransferMode;
            netHttpBinding.UseDefaultWebProxy = this.UseDefaultWebProxy;
            netHttpBinding.ReaderQuotas = this.ReaderQuotas;
        }
    }
}
