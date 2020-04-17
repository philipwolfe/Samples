
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.ServiceModel.Channels;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.Configuration;

namespace Microsoft.ServiceModel.Samples
{
    /// <summary>
    /// This class contains the implementation of the binding.
    /// </summary>
    public class HttpCookieSessionBinding : Binding
    {
        #region Private Fields

        HttpCookieSessionBindingElement sessionElement;
        HttpTransportBindingElement transportElement;
        TextMessageEncodingBindingElement encodingElement;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates an instance of HttpCookieSessionBinding 
        /// class.
        /// </summary>
        public HttpCookieSessionBinding()
        {
            sessionElement = new HttpCookieSessionBindingElement();

            transportElement = new HttpTransportBindingElement();
            transportElement.AllowCookies = true;

            encodingElement = new TextMessageEncodingBindingElement();
            encodingElement.MessageVersion = MessageVersion.Soap11WSAddressing10;
        }

        public HttpCookieSessionBinding(string configurationName) : this()
        {
            ApplyConfiguration(configurationName);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the session timeout.
        /// </summary>
        public int SessionTimeout
        {
            get { return sessionElement.SessionTimeout; }
            set { sessionElement.SessionTimeout = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the 
        /// terminate message is exchanged, when the 
        /// client closes the request channel.
        /// </summary>
        public bool ExchangeTerminateMessage
        {
            get { return sessionElement.ExchangeTerminateMessage; }
            set { sessionElement.ExchangeTerminateMessage = value; }
        }
        
        #endregion

        #region Binding Overrides

        /// <summary>
        /// Prepares the binding elements, adds it to 
        /// an instance of BindingElementCollection 
        /// and finally returns it.
        /// </summary>        
        public override BindingElementCollection CreateBindingElements()
        {

            BindingElementCollection bindingElements = new BindingElementCollection();
            
            bindingElements.Add(sessionElement);
            bindingElements.Add(encodingElement);
            bindingElements.Add(transportElement);
            
            return bindingElements.Clone();
        }

        /// <summary>
        /// Gets the scheme for this binding.
        /// </summary>
        public override string Scheme
        {
            // Read the scheme from the transport.
            get { return transportElement.Scheme; }
        }

        #endregion

        /// <summary>
        /// Apply the configuration.
        /// </summary>       
        void ApplyConfiguration(string configurationName)
        {
            HttpCookieSessionBindingCollectionElement section =
                (HttpCookieSessionBindingCollectionElement)ConfigurationManager.GetSection(
                    HttpCookieSessionDefaults.HttpCookieSessionBindingSectionName);

            HttpCookieSessionBindingConfigurationElement element = 
                section.Bindings[configurationName];

            element.ApplyConfiguration(this);
        }
        

    }
}
