
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
            PrintMessageClient client = new PrintMessageClient();

            // Call the PrintMessage service operation.
            string message = "This is a message sent from the client.";
            Console.WriteLine("Client calling Print({0})", message);
            client.Print(message);

            //Closing the client gracefully closes the connection and cleans up resources
            client.Close();

            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate client.");
            Console.ReadLine();
        }
    }
}
