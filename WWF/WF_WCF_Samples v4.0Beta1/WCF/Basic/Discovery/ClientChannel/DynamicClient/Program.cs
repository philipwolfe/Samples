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
        static void Main(string[] args)
        {
            try
            {
                CalculatorServiceClient client = new CalculatorServiceClient(CreateDynamicCalculatorServiceEndpoint());
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
        static DynamicEndpoint CreateDynamicCalculatorServiceEndpoint()
        {
            // Create a Dynamic Endpoint
            DynamicEndpoint dynamicEndpoint = new DynamicEndpoint(
                ContractDescription.GetContract(typeof(ICalculatorService)),
                new NetTcpBinding());

            // Add a scope to the find criteria of the FindCriteria
            dynamicEndpoint.FindCriteria.Scopes.Add(new Uri("ldap:///ou=engineering,o=exampleorg,c=us"));

            return dynamicEndpoint;
        }
    }
}
