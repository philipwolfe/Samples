//--------------------------------------------------------------------------------
// This file is a "Sample" as from Windows Workflow Foundation
// Hands on Labs RC
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//
// This source code is intended only as a supplement to Microsoft
// Development Tools and/or on-line documentation.  See these other
// materials for detailed information regarding Microsoft code samples.
// 
// THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//--------------------------------------------------------------------------------

#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;
using System.Workflow.Activities;

#endregion

namespace CommunicationsWorkflow
{
    class Program
    {
        static AutoResetEvent waitHandle = new AutoResetEvent(false);
        static VotingService votingService;

        static void Main(string[] args)
        {
            WorkflowRuntime workflowRuntime = new WorkflowRuntime();

            ExternalDataExchangeService dataService = new ExternalDataExchangeService();
            workflowRuntime.AddService(dataService);
            votingService = new VotingService();
            dataService.AddService(votingService);

            workflowRuntime.WorkflowCreated += new EventHandler<WorkflowEventArgs>(workflowRuntime_WorkflowCreated);
            workflowRuntime.WorkflowCompleted += new EventHandler<WorkflowCompletedEventArgs>(workflowRuntime_WorkflowCompleted);

            Type type = typeof(VotingWorkflow);
            workflowRuntime.CreateWorkflow(type).Start();

            waitHandle.WaitOne();
            Console.WriteLine("Press any key to exit...");
            Console.Read();
        }

        static void workflowRuntime_WorkflowCompleted(object sender, WorkflowCompletedEventArgs e)
        {
            Console.WriteLine("Workflow " + e.WorkflowInstance.InstanceId.ToString() + " completed.");
            waitHandle.Set();
        }

        static void workflowRuntime_WorkflowCreated(object sender, WorkflowEventArgs e)
        {
            Console.WriteLine("Workflow " + e.WorkflowInstance.InstanceId.ToString() + " created.");
        }
    }
}
