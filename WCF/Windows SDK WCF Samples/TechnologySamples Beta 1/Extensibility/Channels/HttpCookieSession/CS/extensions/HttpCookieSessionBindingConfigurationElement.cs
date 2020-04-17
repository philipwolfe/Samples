
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
    public sealed class HttpCookieSessionBindingConfigurationElement
        : StandardBindingElement
    {       
        #region Constructor

        /// <summary>
        /// Creates an instance of 
        /// HttpCookieSessionBindingElementSection class.
        /// </summary>
        public HttpCookieSessionBindingConfigurationElement()
            :base(null)
        {            
        }

        public HttpCookieSessionBindingConfigurationElement(
            string configurationName)
            :base(configurationName)
        {            
        }

        #endregion

        #region StandardBindingConfigurationElement Overrides

        /// <summary>
        /// Gets the properties collection for this 
        /// binding element.
        /// </summary>
        protected override ConfigurationPropertyCollection Properties
        {
            get
            {
                base.Properties.Add(
                        new ConfigurationProperty(
                            HttpCookieSessionDefaults.SessionTimeoutProperty, 
                            typeof(int), 
                            HttpCookieSessionDefaults.SessionTimeout.ToString()));

                base.Properties.Add(
                        new ConfigurationProperty(
                            HttpCookieSessionDefaults.ExchangeTerminateMessageProperty, 
                            typeof(bool),
                            HttpCookieSessionDefaults.ExchangeTerminateMessage.ToString().ToLower()));
                
                return base.Properties;
            }
        }

        /// <summary>
        /// Initialize the configuration element with
        /// the specified binding.
        /// Q: Should I call the base method after doing
        ///    my work?
        /// </summary>        
        protected override void InitializeFrom(Binding binding)
        {
            base.InitializeFrom(binding);
            
            HttpCookieSessionBinding sessionBinding = 
                (HttpCookieSessionBinding)binding;

            this.SessionTimeout = sessionBinding.SessionTimeout;
            
            this.ExchangeTerminateMessage = 
                sessionBinding.ExchangeTerminateMessage;
        }

        /// <summary>
        /// Apply the configuration.
        /// </summary>        
        protected override void OnApplyConfiguration(Binding binding)
        {
            HttpCookieSessionBinding sessionBinding =
                (HttpCookieSessionBinding)binding;

            sessionBinding.SessionTimeout = this.SessionTimeout;

            sessionBinding.ExchangeTerminateMessage =
                this.ExchangeTerminateMessage;
        }

        /// <summary>
        /// Gets the binding element type.
        /// </summary>
        protected override Type BindingElementType
        {
            get { return typeof(HttpCookieSessionBinding); }
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the session timeout.
        /// </summary>  
        [ConfigurationProperty(
            HttpCookieSessionDefaults.SessionTimeoutProperty, 
            DefaultValue = HttpCookieSessionDefaults.SessionTimeout)]
        public int SessionTimeout
        {
            get 
            { 
                return (int)base[HttpCookieSessionDefaults.SessionTimeoutProperty]; 
            }
            set 
            { 
                base[HttpCookieSessionDefaults.SessionTimeoutProperty] = value; 
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the 
        /// terminate message is exchanged when the 
        /// client closes the request channel.
        /// </summary>
        [ConfigurationProperty(
           HttpCookieSessionDefaults.ExchangeTerminateMessageProperty,
           DefaultValue = HttpCookieSessionDefaults.ExchangeTerminateMessage)]
        public bool ExchangeTerminateMessage
        {
            get 
            {
                return (bool)base[HttpCookieSessionDefaults.ExchangeTerminateMessageProperty]; 
            }
            set 
            { 
                base[HttpCookieSessionDefaults.ExchangeTerminateMessageProperty] = value; 
            }
        }

        #endregion
    }
}
