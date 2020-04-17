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
using System.ServiceModel.Description;
#endregion

namespace Microsoft.ServiceModel.Samples.Transport
{
    /// <summary>
    /// Tcp Binding Element.  
    /// Used to configure and construct Tcp ChannelFactories and ChannelListeners.
    /// </summary>
    class TcpTransportBindingElement
        : TransportBindingElement // to signal that we're a transport
        , IPolicyExportExtension // for policy export
    {
        public TcpTransportBindingElement()
            : base()
        {
        }

        protected TcpTransportBindingElement(TcpTransportBindingElement other)
            : base(other)
        {
        }

        public override string Scheme
        {
            get { return "my.tcp"; }
        }

        public override IChannelFactory<TChannel> BuildChannelFactory<TChannel>(BindingContext context)
        {
            return (IChannelFactory<TChannel>)(object)new TcpChannelFactory(this, context);
        }

        public override IChannelListener<TChannel> BuildChannelListener<TChannel>(BindingContext context)
        {
            return (IChannelListener<TChannel>)(object)new TcpChannelListener(this, context);
        }

        // We only support IDuplexSession for our client ChannelFactories
        public override bool CanBuildChannelFactory<TChannel>(BindingContext context)
        {
            if (typeof(TChannel) == typeof(IDuplexSessionChannel))
            {
                return true;
            }

            return false;
        }

        // We only support IDuplexSession for our Listeners
        public override bool CanBuildChannelListener<TChannel>(BindingContext context)
        {
            if (typeof(TChannel) == typeof(IDuplexSessionChannel))
            {
                return true;
            }

            return false;
        }

        public override BindingElement Clone()
        {
            return new TcpTransportBindingElement(this);
        }

        public override T GetProperty<T>(BindingContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            // default to MTOM if no encoding is specified
            if (context.BindingParameters.Find<MessageEncodingBindingElement>() == null)
            {
                context.BindingParameters.Add(new MtomMessageEncodingBindingElement());
            }

            return base.GetProperty<T>(context);
        }

        // We expose in policy The fact that we're TCP.
        // Import is done through TcpBindingElementImporter.
        void IPolicyExportExtension.ExportPolicy(MetadataExporter exporter, PolicyConversionContext context)
        {
            if (exporter == null)
            {
                throw new ArgumentNullException("exporter");
            }

            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            ICollection<XmlElement> bindingAssertions = context.GetBindingAssertions();
            XmlDocument xmlDocument = new XmlDocument();
            const string prefix = "tcp";
            const string transportAssertion = "my.tcp";
            const string tcpPolicyNamespace = "http://sample.schemas.microsoft.com/policy/tcp";
            bindingAssertions.Add(xmlDocument.CreateElement(prefix, transportAssertion, tcpPolicyNamespace));
        }
    }
}