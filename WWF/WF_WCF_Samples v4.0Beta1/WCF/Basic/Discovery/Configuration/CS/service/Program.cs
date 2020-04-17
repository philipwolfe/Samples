//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Samples.Discovery
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Discovery;

    class Program
    {
        public static void Main()
        {
            Uri baseAddress = new Uri("http://localhost:8000/" + Guid.NewGuid().ToString());            

            using (ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress))
            {
                // ServiceDiscoveryBehavior is added through the configuration.
                // See App.config. The service is discoverable over UDP multicast

                serviceHost.Open();

                Console.WriteLine("Calculator Service started {0}", baseAddress);
                Console.WriteLine();
                Console.WriteLine("Press <ENTER> to terminate the service");
                Console.WriteLine();
                Console.ReadLine();
            }
        }
    }
}
