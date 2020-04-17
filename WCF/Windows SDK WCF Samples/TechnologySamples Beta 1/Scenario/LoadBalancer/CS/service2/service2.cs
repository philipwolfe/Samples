
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.ServiceModel.Channels;
using System.ServiceModel;

namespace Microsoft.ServiceModel.Samples
{
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
    public interface ILoadBalancedEchoContract
    {
        [OperationContract]
        string Echo(string message);
    }

    public class LoadBalancedEchoService : ILoadBalancedEchoContract
    {
        public string Echo(string message)
        {
            Console.WriteLine("Echo method of LoadBalancedEchoService class is invoked");
            return message;
        }
    }

    public class Service2
    {
        static void Main(string[] args)
        {
            // Get base address from app settings in configuration
            Uri baseAddress = new Uri("http://localhost:9000/servicemodelsamples/echoService/");

            // Create a ServiceHost for the LoadBalancedEchoService type and provide the base address.
            using (ServiceHost serviceHost = new ServiceHost(typeof(LoadBalancedEchoService), baseAddress))
            {
                serviceHost.AddServiceEndpoint(typeof(ILoadBalancedEchoContract), new WSHttpBinding(), "");

                // Add the LoadBalancedBehavior in code to register with the load balancer
                EndpointAddress loadBalancerAddress = new EndpointAddress("net.tcp://localhost/servicemodelsamples/loadBalancerService/");
                LoadBalancerBehavior behavior = new LoadBalancerBehavior(loadBalancerAddress, new NetTcpBinding(SecurityMode.None));
                serviceHost.Description.Endpoints[0].Behaviors.Add(behavior);

                // Open the ServiceHostBase to create listeners and start listening for messages.
                serviceHost.Open();

                // The service can now be accessed.
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

                serviceHost.Close();
                Console.WriteLine("The service has shutdown.");
            }
        }
    }
}
