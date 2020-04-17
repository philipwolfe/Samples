//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Samples.WorkflowServicesSamples.EchoWorkflowService
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.ServiceModel;
    using System.ServiceModel.Description;
    using System.Activities;
    using System.Activities.Statements;
    using System.ServiceModel.Activities;
    using System.ServiceModel.Activities.Description;
    using System.Text;
    using System.Xml;
    using System.Xaml;
    using Microsoft.Samples.WorkflowServicesSamples.Common;

    class Program
    {
        static Service service;

        private static void CreateService()
        {
            Variable<string> message = new Variable<string> { Name = "message" };
            Variable<string> echo = new Variable<string> { Name = "echo" };
            Variable<CorrelationHandle> echoHandle = new Variable<CorrelationHandle> { Name = "EchoHandle" };

            ReceiveParameters receiveString = new ReceiveParameters
            {
                OperationName = "Echo",
                ServiceContractName = "Echo",
                CorrelatesWith = echoHandle,
                CanCreateInstance = true,
                Parameters =
                {
                    {"message", new OutArgument<string>(message)},
                }
            };
            Sequence workflow = new Sequence()
                {
                    Variables = {message, echo, echoHandle },
                    Activities =
                    {
                        receiveString,
                        new WriteLine
                        {
                            Text = new InArgument<string>(env =>("Message received: " + message.Get(env)))
                        },
                        new Assign<string>
                        {
                            Value = new InArgument<string>(env =>("Hello, " + message.Get(env))),
                            To = new OutArgument<string>(echo)
                        },
                        new WriteLine
                        {
                            Text = new InArgument<string>(env =>("Message sent: " + echo.Get(env)))
                        },
                        new SendReplyParameters
                        {                           
                            Request = receiveString,
                            CorrelatesWith = echoHandle,
                            Parameters =
                            {
                                {"echo", new InArgument<string>(echo)},
                            }
                        },
                    },
                };
            service = new Service
                {                    
                    Implementation = new WorkflowServiceImplementation
                    {                        
                        Name = "Echo",
                        Body = workflow
                    },
                    Endpoints =
                    {
                        new Endpoint
                        {
                            ServiceContractName="Echo",
                            Uri = new Uri(Constants.EchoServiceAddress),
                            Binding = new BasicHttpBinding(),
                        }
                    }
                };
        }

      

        static void Main(string[] args)
        {
            Console.WriteLine("Starting up...");           
            CreateService();            
            Uri address = new Uri(Constants.ServiceBaseAddress);
            System.ServiceModel.Activities.WorkflowServiceHost host = new System.ServiceModel.Activities.WorkflowServiceHost(service, address);

            try
            {
                Console.WriteLine("Opening service...");
                host.Open();

                Console.WriteLine("Service is listening on {0}...", address);
                Console.WriteLine("To terminate press ENTER");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Service terminated with exception {0}", ex.ToString());
            }
            finally
            {
                host.Close();
            }
        }


        private static void OnCompleteInstanceExecution(object sender, WorkflowCompletedEventArgs e)
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

