﻿
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.ServiceModel;

namespace Microsoft.Samples.XmlSerializerFaults
{
    //The service contract is defined in generatedClient.cs, generated from the service by the svcutil tool.

    //Client implementation code.
    class Client
    {
        static void Main()
        {
            // Create a client with given client endpoint configuration
            CalculatorClient client = new CalculatorClient();

            try
            {
                // Call the Add service operation.
                int value1 = 15;
                int value2 = 3;
                int result = client.Add(value1, value2);
                Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result);

                // Call the Subtract service operation.
                value1 = 145;
                value2 = 76;
                result = client.Subtract(value1, value2);
                Console.WriteLine("Subtract({0},{1}) = {2}", value1, value2, result);

                // Call the Multiply service operation.
                value1 = 9;
                value2 = 81;
                result = client.Multiply(value1, value2);
                Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result);

                // Call the Divide service operation - trigger a divide by zero error.
                value1 = 22;
                value2 = 0;
                result = client.Divide(value1, value2);
                Console.WriteLine("Divide({0},{1}) = {2}", value1, value2, result);

                //Closing the client gracefully closes the connection and cleans up resources
                client.Close();
            }
            catch (FaultException<MathFault> e)
            {
                Console.WriteLine("FaultException<MathFault>: Math fault while doing " + e.Detail.Operation + ". Problem: " + e.Detail.ProblemType);
                client.Abort();
            }
            catch (FaultException e)
            {
                Console.WriteLine("Unknown FaultException: " + e.GetType().Name + " - " + e.Message);
                client.Abort();
            }
            catch (Exception e)
            {
                Console.WriteLine("EXCEPTION: " + e.GetType().Name + " - " + e.Message);
                client.Abort();
            }

            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate client.");
            Console.ReadLine();
        }
    }
}
