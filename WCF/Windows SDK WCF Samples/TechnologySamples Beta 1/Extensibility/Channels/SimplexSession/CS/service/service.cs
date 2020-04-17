
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.Configuration;
using System.ServiceModel;

namespace Microsoft.ServiceModel.Samples
{
    // Define a service contract.
    [ServiceContract(Namespace="http://Microsoft.ServiceModel.Samples")]
    public interface IPrintMessage
    {
        [OperationContract(IsOneWay = true)]
        void Print(string message);
    }

    // Service class which implements the service contract.
    public class PrintMessageService : IPrintMessage
    {
        public void Print(string message)
        {
            Console.WriteLine("The service has received the following message: " + message);
        }

        // Host the service within this EXE console application.
        public static void Main()
        {
            // Create a ServiceHost for the PrintMessageService type.
            using (ServiceHost serviceHost = new ServiceHost(typeof(PrintMessageService)))
            {
                // Open the ServiceHost to create listeners and start listening for messages.
                serviceHost.Open();

                // The service can now be accessed.
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

                // Close the ServiceHost to shutdown the service.
                serviceHost.Close();
            }
        }
    }
}
