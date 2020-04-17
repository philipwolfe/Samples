//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Samples.Transaction.TransactedReceiveScopeSample.Server
{
    using System;
    using System.Activities;
    using System.Activities.Statements;
    using System.ServiceModel;
    using System.ServiceModel.Activities;
    using System.Threading;    
    using System.Xml.Linq;

    sealed class Program
    {        
        static void Main()
        {
            ManualResetEvent syncEvent = new ManualResetEvent(false);
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

            //Build workflows
            WorkflowElement serverWorkflow = BuildServerTRSWorkflow();

            //Build the server
            WorkflowServiceHost serverHost = BuildServer(serverWorkflow, serverEndpoint, serverAddress, serviceContractName, syncEvent);

            //Start the server            
            Console.WriteLine("Starting the server");
            serverHost.Open();
            syncEvent.WaitOne();

            //Shutdown
            serverHost.Close();

            Console.WriteLine("\nPress ENTER to exit");
            Console.ReadLine();
        }

        static WorkflowServiceHost BuildServer(WorkflowElement serverWorkflow, Endpoint serverEndpoint, string serverAddress, XName serviceContractName, ManualResetEvent syncEvent)
        {
            Console.WriteLine("Constructing the server.");
            Service service = new Service
            {
                Implementation = new WorkflowServiceImplementation
                {
                    Name = serviceContractName,
                    Body = serverWorkflow,
                }
            };
            WorkflowServiceHost serverHost = new WorkflowServiceHost(service);
            serverHost.AddServiceEndpoint(serviceContractName, serverEndpoint.Binding, serverAddress);
            serverHost.Extensions.Add(new EventNotificationExtension(syncEvent));
            
            return serverHost;
        }        
        
        static WorkflowElement BuildServerTRSWorkflow()
        {
            Variable<string> request = new Variable<string> { Name = "requestString" };
            Variable<string> reply = new Variable<string> { Name = "replyString" };
            Variable<CorrelationHandle> requestReplyHandle = new Variable<CorrelationHandle> { Name = "ServerRequestReplyHandle" };

            Receive receive = new Receive
            {
                OperationName = "DoRequestReply",
                CanCreateInstance = true,
                CorrelatesWith = requestReplyHandle,
                Value = new OutArgument<string>(request),
                ValueType = typeof(string),
            };

            return new Sequence
            {
                Activities = 
                {
                    new WriteLine { Text = "Server workflow begins." },

                    new TransactedReceiveScope
                    {
                        Variables = { requestReplyHandle, request, reply },
                        ReceiveActivity = receive,
                        Body = new Sequence
                        {
                            Activities =
                            {
                                new WriteLine { Text = new InArgument<string>("Server side: Receive complete.") },
                                
                                new WriteLine { Text = new InArgument<string>(new VisualBasicValue<string>() { ExpressionText = "\"Server side: Received = '\" + requestString.toString() + \"'\"" }) },

                                new PrintTxDistributedId(),

                                new Assign<string>
                                {
                                    Value = new InArgument<string>("Server side: Sending reply."),
                                    To = new OutArgument<string>(reply)
                                },

                                new WriteLine { Text = new InArgument<string>("Server side: Begin reply.") },

                                new SendReply
                                {
                                    Request = receive,
                                    Value = new InArgument<string>(reply),
                                    ValueType = typeof(string),
                                    CorrelatesWith = requestReplyHandle
                                },

                                new WriteLine { Text = new InArgument<string>("Server side: Reply sent.") },
                            },
                        },
                    },

                    new WriteLine { Text = "Server workflow ends." },
                },
            };
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

    class PrintTxDistributedId : NativeActivity
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
