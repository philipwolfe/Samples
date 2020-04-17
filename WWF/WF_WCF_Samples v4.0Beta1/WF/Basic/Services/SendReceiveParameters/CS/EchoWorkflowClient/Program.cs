//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Samples.WorkflowServicesSamples.EchoWorkflowClient
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.ServiceModel;
    using System.Activities;
    using System.Activities.Statements;
    using System.ServiceModel.Activities;
    using System.ServiceModel.Activities.Description;
    using System.Xaml;
    using System.Xml;
    using Microsoft.Samples.WorkflowServicesSamples.Common;
    using System.Xml.Linq;

    class Program
    {       
        static WorkflowElement workflow;

        static void Main(string[] args)
        {
            CreateClientWorkflow(); 
            WorkflowInstance instance = new WorkflowInstance(workflow);
            instance.OnCompleted = OnCompleteInstanceExecution;
            instance.Run();
            Console.WriteLine("To exit press ENTER.");
            Console.ReadLine();
        }

        private static void CreateClientWorkflow()
        {
            Variable<string> message = new Variable<string>
                {
                    Name = "message",
                    Default = ValueExpression.CreateLiteral("client")
                };
            Variable<string> result = new Variable<string>
                {
                    Name = "result"
                };
            Variable<CorrelationHandle> echoHandle = new Variable<CorrelationHandle>
                {
                    Name = "echoHandle"
                };

            Endpoint endpoint = new Endpoint
            {
                Uri = new Uri(Microsoft.Samples.WorkflowServicesSamples.Common.Constants.EchoServiceAddress),
                Binding = new BasicHttpBinding(),
            };

            SendParameters requestEcho = new SendParameters
                {
                    ServiceContractName = XName.Get("Echo", "http://tempuri.org/"),
                    Endpoint = endpoint,
                    OperationName = "Echo",
                    CorrelatesWith = echoHandle,
                    Parameters = 
                    {
                        { "message", new InArgument<string>{ Expression = ValueExpression.Create(message) }}, 
                    }
                };
            workflow = new Sequence
                {
                    Variables = { message, result, echoHandle},
                    Activities =
                    {
                        new WriteLine {
                            Text = new InArgument<string>("Hello")
                        },
                        requestEcho,
                        new ReceiveReplyParameters
                        {
                            Request = requestEcho,
                            CorrelatesWith = echoHandle,
                            Parameters = 
                            {
                                { "echo", new OutArgument<string>{ Expression = ValueExpression.CreateLocationExpression(result) } }
                            }
                        },
                        new WriteLine {
                            Text = new InArgument<string>(result)
                        }
                    }
                };
        }

        private static void OnCompleteInstanceExecution(WorkflowCompletedEventArgs e)
        {
            if (e.TerminationException != null)
            {
                Console.WriteLine("Workflow completed with {0}: {1}.", e.TerminationException.GetType().FullName, e.TerminationException.Message);
            }
            else
            {
                Console.WriteLine("Workflow completed successfully.");
            }
        }
    }
}
