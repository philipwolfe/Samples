//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Sample.Transaction.TransactedParallelConvoy.Client
{
    using Microsoft.Sample.Transaction.TransactedParallelConvoy.Common;
    using System;
    using System.Activities;

    class Program
    {
        static void Main()
        {
            TCSSampleClientWorkflow client = new TCSSampleClientWorkflow
            {
                ServerEndpoint = ConnectionData.serverEndpoint,
                ServiceContractName = ConnectionData.serviceContractName,
            };
            
            Console.WriteLine("\nPress any key when the server is running.");
            Console.ReadKey();
                                   
            //Start the client
            Console.WriteLine("Starting the client.");
            new WorkflowInvoker(client).Invoke();
            
            Console.WriteLine("\nClient complete. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
