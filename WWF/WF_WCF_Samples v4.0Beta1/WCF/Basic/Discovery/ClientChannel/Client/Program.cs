//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Samples.Discovery
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Discovery;
    using System.ServiceModel.Channels;

    class Program
    {
        public static void Main()
        {
            try
            {
                // Instantiate the client with a dynamic EndpointAddress and a customer binding with a discovery binding element.
                CalculatorServiceClient client = new CalculatorServiceClient(CreateCustomBindingWithDiscoveryElement(), DiscoveryClientBindingElement.DiscoveryEndpointAddress);
                Console.WriteLine("Discovering and invoking CalculatorService.");

                double value1 = 1023;
                double value2 = 1534;
                double value3 = 2342;

                // Call the Add service operation.
                double result = client.Add(value1, value2);
                Console.WriteLine("Adding({0}, {1}) = {2}", value1, value2, result);

                // Call the Subtract service operation.
                result = client.Subtract(value3, value2);
                Console.WriteLine("Subtracting ({0}, {1}) = {2}", value3, value2, result);

                //Closing the client gracefully closes the connection and cleans up resources
                client.Close();
            }

            catch (EndpointNotFoundException)
            {
                Console.WriteLine("Unable to connect to the calculator service because a valid endpoint was not found.");
            }

            Console.WriteLine("Press <ENTER> to exit.");
            Console.ReadLine();
        }

        static CustomBinding CreateCustomBindingWithDiscoveryElement()
        {
            DiscoveryClientBindingElement discoveryBindingElement = new DiscoveryClientBindingElement();

            // Add the find criteria for the service.
            discoveryBindingElement.FindCriteria = new FindCriteria(typeof(ICalculatorService));
            discoveryBindingElement.DiscoveryEndpoint = new UdpDiscoveryEndpoint();

            CustomBinding customBinding = new CustomBinding(new NetTcpBinding());
            customBinding.Elements.Insert(0, discoveryBindingElement);

            return customBinding;
        }
    }
}
