//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Samples.Discovery
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Discovery;
    using System.Threading;

    class Client
    {
        static EndpointAddress endpointAddress;
        static AutoResetEvent syncEvent;

        public static void Main()
        {            
            FindCalculatorServiceAddress();

            if (endpointAddress != null)
            {
                InvokeCalculatorService(endpointAddress);
            }

            Console.WriteLine("Press <ENTER> to exit.");
            Console.ReadLine();
        }

        static void FindCalculatorServiceAddress()
        {
            syncEvent = new AutoResetEvent(false);

            DiscoveryClient discoveryClient = new DiscoveryClient(new UdpDiscoveryEndpoint());

            discoveryClient.FindCompleted += new EventHandler<FindCompletedEventArgs>(ClientFindCompleted);
            discoveryClient.FindProgressChanged += new EventHandler<FindProgressChangedEventArgs>(ClientFindProgressChanged);             

            Console.WriteLine("Finding ICalculatorServices endpoints asynchronously...");
            Console.WriteLine();

            // Find ICalculatorService endpoint asynchronously. The results are returned asynchronously via events            
            discoveryClient.FindAsync(new FindCriteria(typeof(ICalculatorService)));

            // Wait for the asynchronous find operation to complete
            syncEvent.WaitOne();
        }

        static void ClientFindProgressChanged(object sender, FindProgressChangedEventArgs e)
        {
            Console.WriteLine("Found ICalculatorService endpoint at {0}", e.EndpointDiscoveryMetadata.Address.Uri);            
        }

        static void ClientFindCompleted(object sender, FindCompletedEventArgs e)
        {
            Console.WriteLine("Asynchronous find completed. Found {0} ICalculatorService endpoint(s).", e.Result.Endpoints.Count);
            Console.WriteLine();

            if (e.Result.Endpoints.Count > 0)
            {
                endpointAddress = e.Result.Endpoints[0].Address;
            }

            syncEvent.Set();                        
        }

        static void InvokeCalculatorService(EndpointAddress endpointAddress)
        {
            // Create a client
            CalculatorServiceClient client = new CalculatorServiceClient();

            // Connect to the discovered service endpoint
            client.Endpoint.Address = endpointAddress;

            Console.WriteLine("Invoking CalculatorService at {0}", endpointAddress);

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

            //Closing the client gracefully closes the connection and cleans up resources
            client.Close();
        }        
    }
}

