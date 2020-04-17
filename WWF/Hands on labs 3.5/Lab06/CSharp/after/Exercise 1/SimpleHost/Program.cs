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

#endregion

namespace SimpleHost
{
    class Program
    {
        static AutoResetEvent waitHandle = new AutoResetEvent(false);

        static void Main(string[] args)
        {
            WorkflowRuntime workflowRuntime = new WorkflowRuntime();
            workflowRuntime.StartRuntime();

            workflowRuntime.WorkflowCompleted += OnWorkflowCompleted;

            Type type = typeof(ContosoWorkflows.processPOWorkflow);
			// Type type = typeof(SimpleHost.Workflow1);

            workflowRuntime.CreateWorkflow(type).Start(); 

            waitHandle.WaitOne();

            workflowRuntime.StopRuntime();
        }

        static void OnWorkflowCompleted(object sender, WorkflowCompletedEventArgs e)
        {
			System.Console.WriteLine("Press Enter to continue...");
			System.Console.ReadLine();
            waitHandle.Set();
        }
    }
}
