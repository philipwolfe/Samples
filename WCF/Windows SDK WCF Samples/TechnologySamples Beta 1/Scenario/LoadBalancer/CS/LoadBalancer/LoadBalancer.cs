
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.ServiceModel;
using System.Collections.Generic;
using System.Configuration;
using System.Xml;

namespace Microsoft.ServiceModel.Samples
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class LoadBalancerService : ILoadBalancer
    {
        static Dictionary<string, string> registrationTable = new Dictionary<string, string>();
        static Dictionary<string, Dictionary<string, EndpointAddress>> serviceTable = new Dictionary<string, Dictionary<string, EndpointAddress>>();

        public string Register(string contractQName, string bindingQName, EndpointAddress10 serviceAddress)
        {
            string guid;

            if (contractQName == null || bindingQName == null || serviceAddress.ToEndpointAddress() == null)
            {
                return null;
            }

            lock (registrationTable)
            {
                lock (serviceTable)
                {
                    string key = contractQName + ":" + bindingQName;

                    if (!serviceTable.ContainsKey(key))
                    {
                        serviceTable.Add(key, new Dictionary<string, EndpointAddress>());
                    }

                    guid = Guid.NewGuid().ToString();

                    
                    serviceTable[key][guid] = serviceAddress.ToEndpointAddress();
                    registrationTable[guid] = key;
                }
            }

            return guid;
        }

        public void Unregister(string registrationId)
        {
            if (registrationId == null)
            {
                return;
            }

            lock (registrationTable)
            {
                if (!registrationTable.ContainsKey(registrationId))
                {
                    return;
                }

                string key = registrationTable[registrationId];

                if (key != null)
                {
                    lock (serviceTable)
                    {
                        serviceTable[key].Remove(registrationId);
                        if (serviceTable[key].Count == 0)
                        {
                            serviceTable.Remove(key);
                        }
                    }

                    registrationTable.Remove(registrationId);
                }
            }
        }

        public EndpointAddress10 GetServiceAddress(string contractQName, string bindingQName)
        {
            if (contractQName == null || bindingQName == null)
            {
                return null;
            }

            string key = contractQName + ":" + bindingQName;

            lock (serviceTable)
            {
                if (serviceTable.ContainsKey(key))
                {
                    foreach (EndpointAddress address in serviceTable[key].Values)
                    {
                        // Current implementation simply returns the first service's address.
                        // More complicated algorithm can be used to determine which service's address should be returned.
                        return EndpointAddress10.FromEndpointAddress(address);
                    }
                }
            }

            return null;
        }
    }

    public class App
    {
        // Host the service within this EXE console application.
        public static void Main()
        {
            // Create a ServiceHost for the CalculatorService type and provide the base address.
            using (ServiceHost serviceHost = new ServiceHost(typeof(LoadBalancerService)))
            {
                // Open the ServiceHostBase to create listeners and start listening for messages.
                serviceHost.Open();

                // The service can now be accessed.
                Console.WriteLine("The load balancer is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

                // Close the ServiceHostBase to shutdown the service.
                serviceHost.Close();
                Console.WriteLine("The load balancer has shutdown.");
            }
        }
    }
}
