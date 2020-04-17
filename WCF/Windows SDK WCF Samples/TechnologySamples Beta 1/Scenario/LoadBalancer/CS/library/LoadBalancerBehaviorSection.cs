
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.ServiceModel.Channels;
using System.Configuration;
using System.Globalization;
using System.ServiceModel;
using System.ServiceModel.Configuration;

namespace Microsoft.ServiceModel.Samples
{
    public class LoadBalancerBehaviorElement : BehaviorExtensionElement
    {
        const string AddressString = "address";
        const string BindingConfigurationString = "bindingConfiguration";
        const string BindingString = "binding";
        const string BindingsSectionGroupPath = "system.serviceModel/bindings";

        [ConfigurationProperty(LoadBalancerBehaviorElement.AddressString, DefaultValue = "")]
        public Uri Address
        {
            get { return (Uri)base[LoadBalancerBehaviorElement.AddressString]; }
            set { base[LoadBalancerBehaviorElement.AddressString] = value; }
        }

        [ConfigurationProperty(LoadBalancerBehaviorElement.BindingConfigurationString, DefaultValue = "")]
        [StringValidator(MinLength = 0)]
        public string BindingConfiguration
        {
            get { return (string)base[LoadBalancerBehaviorElement.BindingConfigurationString]; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    value = string.Empty;
                }
                base[LoadBalancerBehaviorElement.BindingConfigurationString] = value;
            }
        }

        [ConfigurationProperty(LoadBalancerBehaviorElement.BindingString, Options = ConfigurationPropertyOptions.IsRequired)]
        [StringValidator(MinLength = 0)]
        public string Binding
        {
            get { return (string)base[LoadBalancerBehaviorElement.BindingString]; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    value = string.Empty;
                }
                base[LoadBalancerBehaviorElement.BindingString] = value;
            }
        }

        static object GetSection(string sectionPath)
        {
            object retval = ConfigurationManager.GetSection(sectionPath);
            if (retval == null)
            {
                throw new ConfigurationErrorsException("Configuration section not found");
            }
            return retval;
        }

        static Binding LookupBinding(string binding, string configurationName)
        {
            if (string.IsNullOrEmpty(binding))
            {
                throw new ConfigurationErrorsException("Binding type cannot be null or empty.");
            }

            BindingsSection bindingsSection = (BindingsSection)ConfigurationManager.GetSection(LoadBalancerBehaviorElement.BindingsSectionGroupPath);
            BindingCollectionElement bindingCollectionElement = bindingsSection[binding];


            Binding retval = (Binding)System.Activator.CreateInstance(bindingCollectionElement.BindingType);
            if (!string.IsNullOrEmpty(configurationName))
            {
                // We are looking for a specific instance, not the default. 
                bool configuredBindingFound = false;

                // The Bindings property is always public
                foreach (object configElement in bindingCollectionElement.ConfiguredBindings)
                {
                    IBindingConfigurationElement bindingElement = configElement as IBindingConfigurationElement;
                    if (bindingElement != null)
                    {
                        if (bindingElement.Name.Equals(configurationName, StringComparison.CurrentCulture))
                        {
                            bindingElement.ApplyConfiguration(retval);
                            configuredBindingFound = true;
                        }
                    }
                }
                if (!configuredBindingFound)
                {
                    // We expected to find an instance, but didn't.
                    // Return null. 
                    retval = null;
                }
            }
            return retval;
        }

        protected override object CreateBehavior()
        {
            EndpointAddress loadBalancerAddress = new EndpointAddress((Uri)base[LoadBalancerBehaviorElement.AddressString]);

            string bindingType = (string)base[LoadBalancerBehaviorElement.BindingString];
            string configName = (string)base[LoadBalancerBehaviorElement.BindingConfigurationString];
            Binding binding = LookupBinding(bindingType, configName);

            if (binding == null)
                throw new ConfigurationErrorsException("Could not find specified binding.");

            return new LoadBalancerBehavior(loadBalancerAddress, binding);
        }

        public override Type BehaviorType
        {
            get { return typeof(LoadBalancerBehavior); }
        }
    }
}
