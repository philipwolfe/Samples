
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

#region using

using System;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.ServiceModel.Channels;
using System.Configuration;

#endregion

namespace Microsoft.ServiceModel.Samples
{
    /// <summary>
    /// Binding element section HttpCookieSessionBinding. 
    /// Implements the configuration for 
    /// HttpCookieSessionBinding.
    /// </summary>
    public sealed class HttpCookieSessionElement 
        : BindingElementExtensionElement
    {
        #region Private Fields 

        private ConfigurationPropertyCollection properties;
        private int sessionTimeout;
        private bool exchangeTerminateMessage;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates an instance of 
        /// HttpCookieSessionBindingElementSection class.
        /// </summary>
        public HttpCookieSessionElement()
        {
        }

        #endregion

        #region BindingElementExtensionElement Overrides

        /// <summary>
        /// Applies the configuration as specified 
        /// by bindingElement parameter.
        /// </summary>        
        public override void ApplyConfiguration(
            BindingElement bindingElement)
        {
            base.ApplyConfiguration(bindingElement);
            
            HttpCookieSessionBindingElement typedBindingElement = 
                (HttpCookieSessionBindingElement)bindingElement;
            
            sessionTimeout = typedBindingElement.SessionTimeout; 
            
            exchangeTerminateMessage = 
                typedBindingElement.ExchangeTerminateMessage;
        }        

        /// <summary>
        /// Gets the type of the binding element.
        /// </summary>
        public override Type BindingElementType
        {
            get { return typeof(HttpCookieSessionBindingElement); }
        }
      
        /// <summary>
        /// Creates the binding element.
        /// </summary>        
        protected override BindingElement CreateBindingElement()
        {
            HttpCookieSessionBindingElement bindingElement = 
                new HttpCookieSessionBindingElement();
            
            bindingElement.ExchangeTerminateMessage = 
                exchangeTerminateMessage;
            
            bindingElement.SessionTimeout = sessionTimeout;
            ApplyConfiguration(bindingElement);
            
            return bindingElement;
        }
        
        /// <summary>
        /// Gets the properties collection for this 
        /// binding element.
        /// </summary>
        protected override ConfigurationPropertyCollection Properties
        {
            get
            {
                if (properties == null)
                {
                    properties = new ConfigurationPropertyCollection();
                    
                    properties.Add(
                        new ConfigurationProperty(
                            ResourceHelper.GetString("sessionTimeoutProperty"), 
                            typeof(int), "10"));

                    properties.Add(
                        new ConfigurationProperty(
                            ResourceHelper.GetString(
                                "exchangeTerminateMessageProperty"), 
                            typeof(bool), "false"));
                }

                return properties;
            }
        }

        /// <summary>
        /// Reads the properties from the config xml reader.
        /// Q: Am I using the correct override to read the 
        ///    values from the config?
        /// </summary>        
        protected override void DeserializeElement(
            System.Xml.XmlReader reader, 
            bool serializeCollectionKey)
        {
            base.DeserializeElement(reader, serializeCollectionKey);    
            
            sessionTimeout = 
                int.Parse(reader.GetAttribute(
                    ResourceHelper.GetString("sessionTimeoutProperty")));
            
            exchangeTerminateMessage = 
                bool.Parse(reader.GetAttribute(
                    ResourceHelper.GetString(
                        "exchangeTerminateMessageProperty")));
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
        /// Gets or sets a value indicating whether the 
        /// terminate message is exchanged when the 
        /// client closes the request channel.
        /// </summary>
        public bool ExchangeTerminateMessage
        {
            get { return exchangeTerminateMessage; }
            set { exchangeTerminateMessage = value; }
        }

        #endregion
    }
}
