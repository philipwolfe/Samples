//---------------------------------------------------------------------
//  This file is part of the  BPEL for Windows Workflow Foundation Code Samples.
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
using System.Threading;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.Runtime;
using Microsoft.Workflow.Bpel.Activities;

namespace Microsoft.Samples.Workflow.Bpel.Activities.Compensation
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WorkflowRuntime workflowRuntime = new WorkflowRuntime())
            {
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

                Type workflowType = typeof(CompensationWorkflow);
                TypeProvider typeProvider = new TypeProvider(workflowRuntime);
                typeProvider.AddAssembly(workflowType.Assembly);
                workflowRuntime.AddService(typeProvider);

                BpelInMemoryMessagingService messagingService = new BpelInMemoryMessagingService();
                messagingService.Runtime = workflowRuntime;
                messagingService.RegisterProxy("FileServiceSoap", workflowType.Assembly.Location);
                workflowRuntime.AddService(messagingService);

                workflowRuntime.StartRuntime();
                
                WorkflowInstance instance = workflowRuntime.CreateWorkflow(workflowType);
                instance.Start();
                waitHandle.WaitOne();
            }
        }
    }
}
