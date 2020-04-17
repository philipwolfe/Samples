//--------------------------------------------------------------------------------
// This file is a "Sample" as from Windows Workflow Foundation
// Beta 2 Hands on Labs
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
using LongRunningWorkflow.Properties;
using System.Workflow.Activities;

#endregion

namespace LongRunningWorkflow
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkflowRuntime workflowRuntime = new WorkflowRuntime();

            //
            // Add the factoring service to allow the prime factoring to be performed
            // asynchronously to the workflow
            //
            workflowRuntime.AddService(new FactoringService(workflowRuntime));
            
            AutoResetEvent waitHandle = new AutoResetEvent(false);
            workflowRuntime.WorkflowCompleted += delegate(object sender, WorkflowCompletedEventArgs e) 
            {
                waitHandle.Set();
            };

            workflowRuntime.WorkflowTerminated += delegate(object sender, WorkflowTerminatedEventArgs e)
            {
                Console.WriteLine(e.Exception.Message);
                waitHandle.Set();
            };

            WorkflowInstance instance = workflowRuntime.CreateWorkflow(typeof(LongRunningWorkflow.Workflow1));
            instance.Start();

            waitHandle.WaitOne();

            Console.WriteLine("Press Enter to Exit");
            Console.ReadLine();
        }
    }
}
