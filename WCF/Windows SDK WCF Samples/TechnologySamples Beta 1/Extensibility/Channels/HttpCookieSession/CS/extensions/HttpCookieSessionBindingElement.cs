
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

#region using

using System;

using System.ServiceModel.Description;
using System.ServiceModel;
using System.ServiceModel.Channels;

using System.Xml;

#endregion

namespace Microsoft.ServiceModel.Samples
{
    /// <summary>
    /// This class implements the binding element.
    /// </summary>
    public class HttpCookieSessionBindingElement 
        : BindingElement, IPolicyExportExtension, IPolicyImportExtension
    {
        #region Private Fields

        // Session timeout.
        private int sessionTimeout;

        // Indicates whether the terminate message is 
        // exchanged when the client closes the request 
        // channel.
        private bool exchangeTerminateMessage;
        
        // XmlDocument used to generate Policy assertion elements.        
        private static XmlDocument xmlDocument = new XmlDocument();

        #endregion

        #region Constructors

        /// <summary>
        /// Instanciates a new instance of 
        /// HttpCookieSessionBindingElement class.
        /// </summary>
        public HttpCookieSessionBindingElement()
        {
            sessionTimeout = HttpCookieSessionDefaults.SessionTimeout;
            exchangeTerminateMessage = HttpCookieSessionDefaults.ExchangeTerminateMessage;
        }

        public HttpCookieSessionBindingElement(BindingElement other) : base(other)
        {
            if(other.GetType() == this.GetType())
            {
                HttpCookieSessionBindingElement clone = (HttpCookieSessionBindingElement)other;
                sessionTimeout = clone.sessionTimeout;
                exchangeTerminateMessage = clone.ExchangeTerminateMessage;
            }
            else
            {
                sessionTimeout = HttpCookieSessionDefaults.SessionTimeout;
                exchangeTerminateMessage = HttpCookieSessionDefaults.ExchangeTerminateMessage;
            }
        }

        #endregion

        #region BindingElement Overrides
        
        /// <summary>
        /// Returns a Boolean indicating whether a given 
        /// type of channel factory could be created from 
        /// this binding element.
        /// </summary>    
        public override bool CanBuildChannelFactory<TChannel>(BindingContext context)
        {
            ThrowIfNotHttpTransport(context.Binding);
            
            // Return true if the caller asking for IRequestSessionChannel 
            if (typeof(TChannel) == typeof(IRequestSessionChannel))
            {
                return true;
            }

            return base.CanBuildChannelFactory<TChannel>(context);
        }

        /// <summary>
        /// Returns a Boolean indicating whether a given type of channel 
        /// listener could be created from this binding element.
        /// </summary>        
        public override bool CanBuildChannelListener<TChannel>(BindingContext context)
        {
            ThrowIfNotHttpTransport(context.Binding);

            // Return true if the caller asking for IReplySessionChannel 
            if (typeof(TChannel) == typeof(IReplySessionChannel))
            {
                return true;
            }

            return base.CanBuildChannelListener<TChannel>(context);
        }

        /// <summary>
        /// Returns an instance of a class which 
        /// implements IChannelFactory.
        /// </summary>        
        public override IChannelFactory<TChannel> BuildChannelFactory<TChannel>(BindingContext context)
        {
            ThrowIfNotHttpTransport(context.Binding);
            if (typeof(TChannel) == typeof(IRequestSessionChannel))
            {
                if (context.CanBuildInnerChannelFactory<IRequestChannel>())
                {
                    IChannelFactory<IRequestChannel> innerChannelFactory =
                        context.BuildInnerChannelFactory<IRequestChannel>();

                    IChannelFactory<TChannel> channelFactory = 
                        new HttpCookieSessionChannelFactory<TChannel>(exchangeTerminateMessage,innerChannelFactory);
                    
                    return channelFactory;
                }
            }

            return context.BuildInnerChannelFactory<TChannel>();
        }

        /// <summary>
        /// Returns an instance of a class which 
        /// implements IChannelListener.
        /// </summary>        
        public override IChannelListener<TChannel> BuildChannelListener<TChannel>(BindingContext context)
        {
            ThrowIfNotHttpTransport(context.Binding);
            if (typeof(TChannel) == typeof(IReplySessionChannel))
            {                    
                if (context.CanBuildInnerChannelListener<IReplyChannel>())
                {
                    IChannelListener<IReplyChannel> innerChannelListener =
                        context.BuildInnerChannelListener<IReplyChannel>();
                    
                    HttpCookieReplySessionChannelListener channelListener =
                       new HttpCookieReplySessionChannelListener(
                          innerChannelListener, 
                          TimeSpan.FromMinutes(sessionTimeout), 
                          exchangeTerminateMessage);
                    
                    return (IChannelListener<TChannel>)channelListener;
                }
            }

            return context.BuildInnerChannelListener<TChannel>();
        }

        public override BindingElement Clone()
        {
            return new HttpCookieSessionBindingElement(this);
        }

        public override T GetProperty<T>(BindingContext context)
        {
            if (context != null)
                return context.GetInnerProperty<T>();
            return null;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the session timeout.
        /// </summary>
        public int SessionTimeout
        {
            get { return sessionTimeout; }
            set { sessionTimeout = value; }
        }

        /// <summary>
        /// Gets or sets a Boolean value indicating whether 
        /// the terminate message is exchanged when the 
        /// client closes the request channel.
        /// </summary>        
        public bool ExchangeTerminateMessage
        {
            get { return exchangeTerminateMessage; }
            set { exchangeTerminateMessage = value; }
        }
        
        #endregion

        #region Helper Members

        /// <summary>
        /// Throws an exception if the channel stack does 
        /// not use the http transport.
        /// </summary>        
        private void ThrowIfNotHttpTransport(CustomBinding binding)
        {
            HttpTransportBindingElement transport =
                        binding.Elements.Find<HttpTransportBindingElement>();

            if (transport == null)
            {
                throw new InvalidOperationException(
                    string.Format(
                        ResourceHelper.GetString("HttpTransportNotFound"),
                        typeof(HttpTransportBindingElement).Name));
            }
        }

        #endregion

        #region IPolicyExportExtension Members

        /// <summary>
        /// Exports the policy assertions for httpCookieSessionBinding.
        /// </summary>
        public void ExportPolicy(MetadataExporter exporter, 
            PolicyConversionContext context)
        {
            if (exporter == null)
            {
                throw new ApplicationException(
                    ResourceHelper.GetString("NullExporter"));
            }

            if (context == null)
            {
                throw new ApplicationException(
                    ResourceHelper.GetString("NullPolicyContext"));
            }

            XmlElement mhscElement = xmlDocument.CreateElement("mhsc",
                ResourceHelper.GetString("mhscElementName"), 
                ResourceHelper.GetString("mhsc"));

            if (exchangeTerminateMessage)
            {
                XmlAttribute attribute = xmlDocument.CreateAttribute(
                    ResourceHelper.GetString("ExchangeTerminateAttribute"));
                
                attribute.Value = ResourceHelper.GetString(
                    "ExchangeTerminateAttributeValue");

                mhscElement.Attributes.Append(attribute);
            }

            context.GetBindingAssertions().Add(mhscElement);            
        }

        #endregion

        #region IPolicyImportExtension Members

        /// <summary>
        /// Imports the policy assertions.
        /// </summary>        
        public void ImportPolicy(MetadataImporter importer, 
            PolicyConversionContext context)
        {
            foreach (XmlElement assertion in context.GetBindingAssertions())
            {
                TraceHelper.WriteDebugMessage(assertion.Name);

                if (assertion.Name == ResourceHelper.GetString("mhscElementName")
                    && assertion.NamespaceURI ==
                        ResourceHelper.GetString("mhsc"))
                {
                    HttpCookieSessionBindingElement bindingElement =
                        new HttpCookieSessionBindingElement();

                    XmlAttribute attribute =
                        assertion.Attributes[ResourceHelper.GetString("ExchangeTerminateAttribute")];

                    if(attribute != null)
                    {
                        bindingElement.ExchangeTerminateMessage = true;
                    }

                    context.BindingElements.Add(bindingElement);

                    break;
                }
            }
        }

        #endregion
    }
}
