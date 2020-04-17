//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Samples.Discovery
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Description;
    using System.ServiceModel.Discovery;

    class Program
    {
        public static void Main()
        {
            Uri baseAddress = new Uri("http://localhost:8000/" + Guid.NewGuid().ToString());            

            // Create a ServiceHost for the CalculatorService type.
            using (ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress))
            {
                // Add an endpoint to the service
                ServiceEndpoint discoverableCalculatorEndpoint = serviceHost.AddServiceEndpoint(typeof(ICalculatorService), new WSHttpBinding(), "/DiscoverableEndpoint");
                EndpointDiscoveryBehavior discoverableEndpointBehavior = new EndpointDiscoveryBehavior();
                discoverableEndpointBehavior.Scopes.Add(new Uri("ldap:///ou=engineering,o=exampleorg,c=us"));
                discoverableCalculatorEndpoint.Behaviors.Add(discoverableEndpointBehavior);

                // Add an endpoint to the service and disable discoverability of that endpoint
                ServiceEndpoint nonDiscoverableCalculatorEndpoint = serviceHost.AddServiceEndpoint(typeof(ICalculatorService), new WSHttpBinding(), "/NonDiscoverableEndpoint");
                EndpointDiscoveryBehavior nonDiscoverableEndpointBehavior = new EndpointDiscoveryBehavior();
                nonDiscoverableEndpointBehavior.Scopes.Add(new Uri("ldap:///ou=engineering,o=exampleorg,c=us"));
                nonDiscoverableEndpointBehavior.Enabled = false;
                nonDiscoverableCalculatorEndpoint.Behaviors.Add(nonDiscoverableEndpointBehavior);

                // Make the service discoverable over UDP multicast
                serviceHost.Description.Behaviors.Add(new ServiceDiscoveryBehavior());                
                serviceHost.AddServiceEndpoint(new UdpDiscoveryEndpoint());

                serviceHost.Open();

                Console.WriteLine("Calculator Service started at {0}", baseAddress);
                Console.WriteLine();
                Console.WriteLine("Press <ENTER> to terminate the service.");
                Console.WriteLine();
                Console.ReadLine();
            }
        }
    }
}
