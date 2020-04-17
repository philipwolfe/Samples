
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;

using System.ServiceModel.Channels;
using System.ServiceModel;

namespace Microsoft.ServiceModel.Samples
{
    // The service contract is defined in generatedProxy.cs, generated from the service by the svcutil tool.

    class Client
    {
        static void Main()
        {
            // Create a proxy with given client endpoint configuration
            using (CalculatorProxy proxy = new CalculatorProxy())
            {
                try
                {
                    double value1;
                    double value2;
                    double result;

                    // Call the Multiply service operation with arguments between 1 and 10
                    value1 = 2.00D;
                    value2 = 5.25D;
                    result = proxy.Multiply(value1, value2);
                    Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result);

                    // Call the Multiply service operation with arguments outside 1 and 10
                    value1 = 9.00D;
                    value2 = 81.25D;
                    result = proxy.Multiply(value1, value2);
                    Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result);
                }
                catch (FaultException e)
                {
                    Console.WriteLine("{0}: {1}", e.GetType(), e.Message);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate client.");
            Console.ReadLine();
        }
    }
}