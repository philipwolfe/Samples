using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

namespace Microsoft.ServiceModel.Samples
{
    public class EndpointValidateBehavior : IServiceBehavior
    {
        #region Data Members

        bool secureElementFound;

        #endregion

        #region Member Functions

        // Write a message to the System Event Log.
        private void WriteMessage(String message, EventLogEntryType entryType)
        {
            using (EventLog logger = new EventLog("Application"))
            {
                logger.Source = "Service Endpoint Validator";

                logger.WriteEntry(message, entryType);
            }
        }

        #endregion

        #region IServiceBehavior Members

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }

        // The validation process will scan each endpoint to see if it's bindings have binding elements
        // that are secure. These elements consist of: Transport, Asymetric, Symmetric,
        // HttpsTransport, WindowsStream and SSLStream.
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            // Loop through each endpoint individually gathering their binding elements.
            foreach (ServiceEndpoint endpoint in serviceDescription.Endpoints)
            {
                secureElementFound = false;

                // Retrieve the endpoint's binding element collection.
                BindingElementCollection bindingElements = endpoint.Binding.CreateBindingElements();

                // Look to see if the binding elements collection contains any secure binding
                // elements. Transport, Assymetric and Symmetric binding elements are all
                // derived from SecurityBindingElement.
                if ((bindingElements.Find<SecurityBindingElement>() != null) ||
                    (bindingElements.Find<HttpsTransportBindingElement>() != null) ||
                    (bindingElements.Find<WindowsStreamSecurityBindingElement>() != null) ||
                    (bindingElements.Find<SslStreamSecurityBindingElement>() != null))
                {
                    secureElementFound = true;
                }

                // Send a message to the system event viewer whhen an endpoint is deemed insecure.
                if (!secureElementFound)
                    this.WriteMessage("Endpoint: " + endpoint.Name + " has no secure bindings.", EventLogEntryType.Warning);
            }
        }

        #endregion
    }
}
