//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Sample.Transaction.TransactedParallelConvoy.Server
{
    using Microsoft.Sample.Transaction.TransactedParallelConvoy.Common;
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Activities;
    using System.Threading;

    class Program
    {
        static void Main(string[] args)
        {
            ManualResetEvent serverResetEvent = new ManualResetEvent(false);
            TCSSampleServerWorkflow server = new TCSSampleServerWorkflow()
            {
                ServiceContractName = ConnectionData.serviceContractName,
            };

            //Start the server
            Console.WriteLine("Starting the server.");
            Service service = new Service
            {
                Implementation = new WorkflowServiceImplementation
                {
                    Name = ConnectionData.serviceContractName,
                    Body = server,
                },
            };
            WorkflowServiceHost serverHost = new WorkflowServiceHost(service);

            serverHost.Extensions.Add(new EventNotificationExtension(serverResetEvent));
            serverHost.AddServiceEndpoint(ConnectionData.serviceContractName.LocalName, ConnectionData.serverEndpoint.Binding, ConnectionData.serverAddress);
            serverHost.Open();
            Console.WriteLine("Server is running.");
            serverResetEvent.WaitOne();

            Console.WriteLine("\nServer complete. Press any key to exit.");
            Console.ReadKey();
            serverHost.Close();
            
        }
    }

    class EventNotificationExtension : DurableServiceHostExtension
    {
        ManualResetEvent syncEvent;

        public EventNotificationExtension(ManualResetEvent syncEvent)
        {
            this.syncEvent = syncEvent;
        }

        protected override void InstanceCompleted(System.ServiceModel.Activities.Dispatcher.DurableInstanceContext instanceContext, Exception completionException)
        {
            syncEvent.Set();
        }
    }
}
