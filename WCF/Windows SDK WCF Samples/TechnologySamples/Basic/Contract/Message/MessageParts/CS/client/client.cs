
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.ServiceModel;

namespace Microsoft.ServiceModel.Samples
{
    //The service contract is defined in generatedClient.cs, generated from the service by the svcutil tool.

    //Client implementation code.
    class Client
    {
        static void Main()
        {
            // Create a client
            CalculatorClient client = new CalculatorClient();

            // Perform addition using a typed message.
            MyMessage request = new MyMessage();
            request.special1 = 100D;
            request.special2 = 15.99D;
            request.operation = "+";
            MyMessage response = client.Calculate(request);

            Console.WriteLine("Add({0},{1}) = {2}", request.special1, request.special2, response.result);

            // Perform subtraction using a typed message.
            request = new MyMessage();
            request.special1 = 145D;
            request.special2 = 76.54D;
            request.operation = "-";
            response = client.Calculate(request);
            Console.WriteLine("Subtract({0},{1}) = {2}", request.special1, request.special2, response.result);

            // Perform multiplication using a typed message.
            request = new MyMessage();
            request.special1 = 9D;
            request.special2 = 81.25D;
            request.operation = "*";
            response = client.Calculate(request);
            Console.WriteLine("Multiply({0},{1}) = {2}", request.special1, request.special2, response.result);

            // Perform multiplication using a typed message.
            request = new MyMessage();
            request.special1 = 22D;
            request.special2 = 7D;
            request.operation = "/";
            response = client.Calculate(request);
            Console.WriteLine("Divide({0},{1}) = {2}", request.special1, request.special2, response.result);

            //Closing the client gracefully closes the connection and cleans up resources
            client.Close();

            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate client.");
            Console.ReadLine();
        }
    }
}
