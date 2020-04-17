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
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;

namespace Microsoft.Samples.Workflow.Tutorials.Hosting
{
    class Program
    {
        static AutoResetEvent waitHandle = new AutoResetEvent(false);

        static void Main(string[] args)
        {
            WorkflowRuntime workflowRuntime = new WorkflowRuntime();
            workflowRuntime.StartRuntime();
            workflowRuntime.WorkflowCompleted += new 
                EventHandler<WorkflowCompletedEventArgs>
                (workflowRuntime_WorkflowCompleted);

            Type type = typeof(HostingWorkflows);
            WorkflowInstance workflowInstance = workflowRuntime.CreateWorkflow(type);
            workflowInstance.Start();

            waitHandle.WaitOne();
            workflowRuntime.StopRuntime();
        }

        static void workflowRuntime_WorkflowCompleted(object sender, 
            WorkflowCompletedEventArgs e)
        {
            waitHandle.Set();
        }
    }
}
