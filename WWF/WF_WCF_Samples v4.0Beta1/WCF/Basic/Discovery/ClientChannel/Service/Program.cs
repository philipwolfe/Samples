//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Samples.Discovery
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Discovery;
    using System.ServiceModel.Description;
    class Program
    {
        public static void Main()
        {
            Uri netTcpAddress = new Uri("net.tcp://localhost:5555/CalculatorSvc/" + Guid.NewGuid().ToString());

            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService));

            try
            {
                // Add a NET.TCP endpoint and add a scope to that endpoint.
                ServiceEndpoint netTcpEndpoint = serviceHost.AddServiceEndpoint(typeof(ICalculatorService), new NetTcpBinding(), netTcpAddress);
                EndpointDiscoveryBehavior netTctEndpointBehavior = new EndpointDiscoveryBehavior();
                netTctEndpointBehavior.Scopes.Add(new Uri("ldap:///ou=engineering,o=exampleorg,c=us"));
                netTcpEndpoint.Behaviors.Add(netTctEndpointBehavior);

                serviceHost.Open();

                Console.WriteLine("Calculator Service started at: \n {0}", netTcpAddress);
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

            if (serviceHost.State != CommunicationState.Closed)
            {
                serviceHost.Abort();
            }
        }
    }
}
