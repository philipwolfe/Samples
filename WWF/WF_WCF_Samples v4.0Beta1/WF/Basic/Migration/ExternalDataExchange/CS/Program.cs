//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Samples.Interop
{
    using System;
    using System.Collections;
    using System.Workflow.Activities;
    using System.Activities;
    using System.Activities.Statements;
    using System.ServiceModel;
    using System.ServiceModel.Activities;
    using System.ServiceModel.Activities.Description;
    using System.Threading;
    using System.Xml;

    class Program
    {
        [ServiceContract]
        public interface IWorkflow
        {
            [OperationContract(IsOneWay = true)]
            void Start();
        }
        
        static WorkflowElement CreateWorkflow()
        {
            return new Sequence()
            {
                Activities = 
                { 
                    new Sequence()
                    {
                        Activities =
                        {
                            new Receive()
                            {
                                CanCreateInstance = true,
                                OperationName = "Start",
                                ServiceContractName = "IWorkflow"
                            },
                            new WriteLine() { Text = "BEFORE" },
                            new Interop() { Body = typeof(TaskWorkflow) },
                            new WriteLine() { Text = "AFTER" }
                        }
                    }
                }
            };
        }

        static string baseAddress = "http://localhost:8080/Test/";

        static void Main()
        {
            WorkflowElement workflow = CreateWorkflow();

            WorkflowServiceHost host = new WorkflowServiceHost(workflow, new Uri(Program.baseAddress));

            ExternalDataExchangeService dataExchangeService = new ExternalDataExchangeService();
            TaskService taskService = new TaskService();
            dataExchangeService.AddService(taskService);

            WorkflowRuntimeServicesBehavior workflowRuntimeBehavior = new WorkflowRuntimeServicesBehavior();
            workflowRuntimeBehavior.AddService(dataExchangeService);
            host.Description.Behaviors.Add(workflowRuntimeBehavior);

            host.AddDefaultEndpoints();
            host.Open();

            IWorkflow proxy = ChannelFactory<IWorkflow>.CreateChannel(new BasicHttpBinding(), new EndpointAddress(Program.baseAddress + "IWorkflow"));
            proxy.Start();

            Console.ReadLine();
            host.Close();
        }
    }
}