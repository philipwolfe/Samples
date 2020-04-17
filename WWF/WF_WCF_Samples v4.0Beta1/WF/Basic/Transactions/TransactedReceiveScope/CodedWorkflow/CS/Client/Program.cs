//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Samples.Transaction.TransactedReceiveScopeSample.Client
{
    using System;
    using System.Activities;
    using System.Activities.Statements;
    using System.Activities.Expressions;
    using System.ServiceModel;
    using System.ServiceModel.Activities;
    using System.Threading;
    using System.Xml.Linq;
    
    class Program
    {
        static void Main(string[] args)
        {
            AutoResetEvent syncEvent = new AutoResetEvent(false);
            string serverAddress = "net.tcp://localhost/TRSSample/Server";
            Endpoint serverEndpoint = new Endpoint
            {
                Binding = new NetTcpBinding
                {
                    TransactionFlow = true,
                    TransactionProtocol = TransactionProtocol.WSAtomicTransaction11,
                },
                Uri = new Uri(serverAddress),
            };
            XName serviceContractName = XName.Get("default", "http://tempuri.org/");

            //Build workflow
            WorkflowElement clientWorkflow = BuildClientTRSWorkflow(serverEndpoint, serviceContractName);
            
            //Build client and server
            WorkflowInstance client = BuildClient(clientWorkflow, syncEvent);
            
            //Start the client            
            Console.WriteLine("Starting the client");
            client.Run();
            syncEvent.WaitOne();
            
            Console.WriteLine("\nPress ENTER to exit");
            Console.ReadLine();
        }

        static WorkflowInstance BuildClient(WorkflowElement clientWorkflow, AutoResetEvent clientResetEvent)
        {
            Console.WriteLine("Constructing the client.");
            WorkflowInstance instance = new WorkflowInstance(clientWorkflow);
            instance.OnCompleted = delegate(WorkflowCompletedEventArgs e)
            {
                clientResetEvent.Set();
            };
            instance.OnAborted = delegate(WorkflowAbortedEventArgs e)
            {
                Console.WriteLine("Client Aborted!");
                Console.WriteLine(e.Reason);
                clientResetEvent.Set();
            };
            instance.OnUnhandledException = delegate(WorkflowUnhandledExceptionEventArgs e)
            {
                Console.WriteLine("Client had an unhandled exception!");
                Console.WriteLine(e.UnhandledException);
                return UnhandledExceptionAction.Cancel;
            };

            return instance;
        }

        static WorkflowElement BuildClientTRSWorkflow(Endpoint serverEndpoint, XName serviceContractName)
        {
            Variable<string> reply = new Variable<string> { Name = "replyString" };
            Variable<CorrelationHandle> requestReplyHandle = new Variable<CorrelationHandle> { Name = "RequestReplyHandle" };

            Send send = new Send
            {
                OperationName = "DoRequestReply",
                Endpoint = serverEndpoint,
                Value = new InArgument<string>("Client side: Send request."),
                ValueType = typeof(string),
                CorrelatesWith = requestReplyHandle,
                ServiceContractName = serviceContractName,
            };

            return new Sequence
            {
                Variables = { reply, requestReplyHandle },

                Activities = 
                 {
                     new WriteLine { Text = "Client workflow begins." },

                     new TransactionScopeActivity
                     {
                         Body = new Sequence
                         {
                             Activities =                                 
                             {
                                new PrintTxDistributedId(),

                                new WriteLine { Text = new InArgument<string>("Client side: Beginning send.") },

                                send,

                                new WriteLine { Text = new InArgument<string>("Client side: Send complete.") },

                                new ReceiveReply
                                {
                                    Request = send,
                                    Value = new OutArgument<string>(reply),
                                    ValueType = typeof(string),
                                    CorrelatesWith = requestReplyHandle
                                },

                                new WriteLine { Text = new InArgument<string>(new VisualBasicValue<string>() { ExpressionText = "\"Client side: Reply received = '\" + replyString.toString() + \"'\"" }) },

                                new PrintTxDistributedId(),

                                new WriteLine { Text = new InArgument<string>("Client side: Receive complete.") },
                             },
                         },
                     },

                     new WriteLine { Text = "Client workflow ends." },
                 },
            };
        }

    }

    sealed class PrintTxDistributedId : NativeActivity
    {
        public String Source { get; set; }
		
        protected override void Execute(ActivityExecutionContext context)
        {
            RuntimeTransactionHandle rth = new RuntimeTransactionHandle();
            rth = context.Properties.Find(rth.ExecutionPropertyName) as RuntimeTransactionHandle;
            Guid distroID = rth.GetCurrentTransaction(context).TransactionInformation.DistributedIdentifier;
            if (distroID == null)
            {
                Console.WriteLine("There is no distributed identifier");
            }
            else
            {
                Console.WriteLine(this.Source + "The distributed identifier is: " + distroID);
            }
        }
    }
}
