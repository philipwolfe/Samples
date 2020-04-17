//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Samples.Discovery
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Discovery;
    using System.ServiceModel.Description;

    class Client
    {
        public static void Main()
        {
            // Create a Discovery Endpoint that points to the proxy service.
            Uri probeEndpointAddress = new Uri("net.tcp://localhost:8001/Probe");
            DiscoveryEndpoint discoveryEndpoint = new DiscoveryEndpoint(new NetTcpBinding(), new EndpointAddress(probeEndpointAddress));

            // Create DiscoveryClient using the previously created discoveryEndpoint
            DiscoveryClient discoveryClient = new DiscoveryClient(discoveryEndpoint);

            Console.WriteLine("Finding ICalculatorService endpoints...");
            Console.WriteLine();

            // Find ICalculatorService endpoints            
            FindResponse findResponse = discoveryClient.Find(new FindCriteria(typeof(ICalculatorService)));

            Console.WriteLine("Found {0} ICalculatorService endpoint(s).", findResponse.Endpoints.Count);
            Console.WriteLine();

            // Check to see if endpoints were found, if so then invoke the service.
            if (findResponse.Endpoints.Count > 0)
            {                   
                InvokeCalculatorService(findResponse.Endpoints[0].Address);   
            }
            Console.WriteLine("Press <ENTER> to exit.");
            Console.ReadLine();
        }

        static void InvokeCalculatorService(EndpointAddress endpointAddress)
        {
            // Create a client
            CalculatorServiceClient client = new CalculatorServiceClient(new NetTcpBinding(), endpointAddress);
            Console.WriteLine("Invoking CalculatorService at {0}", endpointAddress.Uri);
            Console.WriteLine();

            double value1 = 100.00D;
            double value2 = 15.99D;

            // Call the Add service operation.
            double result = client.Add(value1, value2);
            Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result);

            // Call the Subtract service operation.
            result = client.Subtract(value1, value2);
            Console.WriteLine("Subtract({0},{1}) = {2}", value1, value2, result);

            // Call the Multiply service operation.
            result = client.Multiply(value1, value2);
            Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result);

            // Call the Divide service operation.
            result = client.Divide(value1, value2);
            Console.WriteLine("Divide({0},{1}) = {2}", value1, value2, result);
            Console.WriteLine();

            // Closing the client gracefully closes the connection and cleans up resources
            client.Close();
        }
    }
}
