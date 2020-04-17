//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Samples.Discovery
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Description;
    using System.ServiceModel.Discovery;
    using System.Xml;
    using System.Xml.Linq;

    class Service
    {
        public static void Main()
        {
            Uri baseAddress = new Uri("net.tcp://localhost/8000/" + Guid.NewGuid().ToString());

            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);
            try
            {
                ServiceEndpoint netTcpEndpoint = serviceHost.AddServiceEndpoint(typeof(ICalculatorService), new NetTcpBinding(), string.Empty);
                EndpointDiscoveryBehavior endpointDiscoveryBehavior = new EndpointDiscoveryBehavior();

                // Create XML metadata to add to the service endpoint
                XElement endpointMetadata = new XElement(
                    "Root",
                    new XElement("Information", "This endpoint is for a service of type: ICalculatorService."),
                    new XElement("Time", System.DateTime.Now.ToString("MM/dd/yyyy HH:mm")));

                // Add the XML metadata to the endpoint discovery behavior.
                endpointDiscoveryBehavior.Extensions.Add(endpointMetadata);

                // Add the discovery behavior to the endpoint.
                netTcpEndpoint.Behaviors.Add(endpointDiscoveryBehavior);

                // Make the service discoverable over UDP multicast
                serviceHost.Description.Behaviors.Add(new ServiceDiscoveryBehavior());
                serviceHost.AddServiceEndpoint(new UdpDiscoveryEndpoint()); 

                serviceHost.Open();

                Console.WriteLine("Calculator Service started at {0}", baseAddress);
                Console.WriteLine();
                Console.WriteLine("Press <ENTER> to terminate the service.");
                Console.WriteLine();
                Console.ReadLine();

                serviceHost.Close();
            }
            catch (TimeoutException)
            {
                Console.WriteLine("ServiceHost timed out during the open or close operation");
            }
            catch (CommunicationException)
            {
                Console.WriteLine("ServiceHost was unable to open or close properly");
            }
        }
    }
}
