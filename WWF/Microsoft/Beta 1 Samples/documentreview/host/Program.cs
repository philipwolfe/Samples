//---------------------------------------------------------------------
//  This file is part of the Windows Workflow Foundation SDK Code Samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//---------------------------------------------------------------------
namespace Microsoft.Samples.Workflow.Applications.DocumentReview
{
    using System;
    using System.Threading;
    using System.Workflow.ComponentModel;
    using System.Workflow.Runtime;
    using System.Workflow.Runtime.Hosting;

    class Program
    {
        private static ManualResetEvent mre = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            try
            {
                WorkflowRuntime runtime = new WorkflowRuntime();

                // Add services to the workflow runtime
                SubscriptionService subscriptionService = new SubscriptionService();
                runtime.AddService(subscriptionService);

                runtime.AddService(new ConsoleTrackingService());

                DocumentReviewInterfaceImpl docImpl = new DocumentReviewInterfaceImpl(subscriptionService);
                runtime.AddService(docImpl);

                DocumentReviewTaskImpl reviewImpl = new DocumentReviewTaskImpl(subscriptionService, docImpl);
                runtime.AddService(reviewImpl);

                // Start runtime
                runtime.StartRuntime();

                //Enlist Workflow
                IRootActivity activity = runtime.GetWorkflowDefinition(typeof(DocumentReviewWorkflow));
                DefaultDeploymentService enlistContext = new DefaultDeploymentService(activity, runtime);
                enlistContext.Deploy();

                // Subscribe for workflow completion event
                runtime.WorkflowCompleted += new EventHandler<WorkflowCompletedEventArgs>(instanceService_OnScheduleCompletion);

                // Start the document review workflow
                WorkflowInstance workflowInstance = runtime.StartWorkflow(typeof(DocumentReviewWorkflow));

                // Send initializing message
                docImpl.SubmitReviewStarted(
                    workflowInstance.InstanceId,
                    new DocumentInfo("John", "http://someserver/document1.doc"),
                    new string[] {"Dona", "Mark"});

                // Wait until schedule is complete
                mre.WaitOne(System.Threading.Timeout.Infinite, false);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
        }

        /// <summary>
        /// Schedule completed event handler
        /// </summary>
        public static void instanceService_OnScheduleCompletion(object sender, WorkflowCompletedEventArgs schedInstanceArgs)
        {
            Console.WriteLine("ScheduleCompleted event is raised");
            mre.Set();
        }
    }
}
