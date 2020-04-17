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
            Uri baseAddress = new Uri("net.tcp://localhost/");

            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);
            try
            {
                ServiceEndpoint netTcpEndpoint = serviceHost.AddServiceEndpoint(typeof(ICalculatorService), new NetTcpBinding(), string.Empty);

                // Set the ListenUri mode to unique
                netTcpEndpoint.ListenUriMode = ListenUriMode.Unique;

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
