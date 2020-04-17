
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.ServiceModel;

namespace Microsoft.ServiceModel.Samples
{
    //The service contract is defined in generatedProxy.cs, generated from the service by the svcutil tool.

    //Client implementation code.
    class Client
    {
        static void Main()
        {
            // Create a proxy with given client endpoint configuration
            using (InstanceContextCalculatorProxy proxy = new InstanceContextCalculatorProxy())
            {
                // Call the Add service operation.
                int value1 = 15;
                int value2 = 3;
                int result = proxy.Add(value1, value2);
                Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result);

                // Call the Subtract service operation.
                value1 = 145;
                value2 = 76;
                result = proxy.Subtract(value1, value2);
                Console.WriteLine("Subtract({0},{1}) = {2}", value1, value2, result);

                // Call the Multiply service operation.
                value1 = 9;
                value2 = 81;
                result = proxy.Multiply(value1, value2);
                Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result);

                // Call the Divide service operation - trigger a divide by zero error.
                value1 = 22;
                value2 = 7;
                result = proxy.Divide(value1, value2);
                Console.WriteLine("Divide({0},{1}) = {2}", value1, value2, result);

                // Obtain InstanceContext information from the service.
                Console.WriteLine("GetInstanceContextInfo");
                Console.WriteLine(proxy.GetInstanceContextInfo());

            }

            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate client.");
            Console.ReadLine();
        }
    }
}
