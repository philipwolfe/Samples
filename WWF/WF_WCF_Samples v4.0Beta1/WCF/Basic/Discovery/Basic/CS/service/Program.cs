//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Samples.Discovery
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Discovery;

    class CalculatorServiceHost
    {
        public static void Main()
        {
            Uri baseAddress = new Uri("http://localhost:8000/" + Guid.NewGuid().ToString());                        

            using (ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress))
            {
                serviceHost.AddServiceEndpoint(typeof(ICalculatorService), new WSHttpBinding(), String.Empty);

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
