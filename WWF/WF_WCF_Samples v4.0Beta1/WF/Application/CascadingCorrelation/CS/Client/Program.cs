//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Threading;
using System.Activities;
using System.Activities.Statements;
using System.ServiceModel;
using System.ServiceModel.Activities;
using Microsoft.Samples.CascadingCorrelation.SharedTypes;

namespace Microsoft.Samples.CascadingCorrelation.FaultClient
{
    class Program
    {
        static void Main(string[] args)
        {
            AutoResetEvent syncEvent = new AutoResetEvent(false);

            WorkflowInstance myInstance = new WorkflowInstance(GetClientWorkflow());
            myInstance.OnCompleted = delegate(WorkflowCompletedEventArgs e) { syncEvent.Set(); };
            myInstance.OnUnhandledException = delegate(WorkflowUnhandledExceptionEventArgs e)
            {
                Console.WriteLine(e.UnhandledException.Message);
                return UnhandledExceptionAction.Terminate;
            };
            myInstance.Run();

            syncEvent.WaitOne();

            Console.WriteLine("Press [ENTER] to exit");
            Console.ReadLine();

        }

        static WorkflowElement GetClientWorkflow()
        {
            Variable<PurchaseOrder> po = new Variable<PurchaseOrder>() { Default = new PurchaseOrder() { PartName = "Widget", Quantity = 150 } };
            Variable<Customer> customer = new Variable<Customer>() { Default = new Customer() { Id = 12345678, Name = "John Smith" } };
            Variable<CorrelationHandle> handle = new Variable<CorrelationHandle>();

            Endpoint clientEndpoint = new Endpoint
            {
                Binding = Constants.Binding,
                Uri = new Uri(Constants.ServiceAddress)
            };

            Send submitPO = new Send
            {
                Endpoint = clientEndpoint,
                ServiceContractName = Constants.POContractName,
                OperationName = Constants.SubmitPOName,
                CorrelatesWith = handle,
                Value = new InArgument<PurchaseOrder>(po)
            };

            return new Sequence
            {
                Variables = { po, customer, handle },
                Activities = 
                {
                    submitPO,
                    new ReceiveReply
                    {
                        Request = submitPO,
                        CorrelatesWith = handle,
                        Value = new OutArgument<int>( (e) => po.Get(e).Id )
                    },
                    new WriteLine { Text = new InArgument<string>( (e) => string.Format("Got PoId: {0}", po.Get(e).Id) ) },
                    new Assign<int> { To = new OutArgument<int>( (e) => po.Get(e).Quantity ), Value = 250 },
                    new Send
                    {
                        Endpoint = clientEndpoint,
                        ServiceContractName = Constants.POContractName,
                        OperationName = Constants.UpdatePOName,
                        Value = new InArgument<PurchaseOrder>(po)
                    },
                    new WriteLine { Text = "Updated PO with new quantity" },
                    new Assign<int> 
                    { 
                        To = new OutArgument<int>( (e) => po.Get(e).CustomerId ), 
                        Value = new InArgument<int>( (e) => customer.Get(e).Id )
                    },
                    new Send
                    {
                        Endpoint = clientEndpoint,
                        ServiceContractName = Constants.POContractName,
                        OperationName = Constants.AddCustomerInfoName,
                        Value = new InArgument<PurchaseOrder>(po)
                    },
                    new WriteLine { Text = "Updated PO with Customer data" },
                    new Send
                    {
                        Endpoint = clientEndpoint,
                        ServiceContractName = Constants.POContractName,
                        OperationName = Constants.UpdateCustomerName,
                        Value = new InArgument<Customer>(customer)
                    },
                    new WriteLine { Text = "Client completed." }
                }


            };
        }
    }
}
