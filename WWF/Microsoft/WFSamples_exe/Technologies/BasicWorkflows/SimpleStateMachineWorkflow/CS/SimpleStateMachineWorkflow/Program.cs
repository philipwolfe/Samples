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
using System.Threading;
using System.Workflow.Runtime;

namespace Microsoft.Samples.Workflow.SimpleStateMachineWorkflow
{
    static class Program
    {
        static AutoResetEvent waitHandle = new AutoResetEvent(false);
        
        static void Main()
        {
            using (WorkflowRuntime workflowRuntime = new WorkflowRuntime())
            {
                try
                {
                    workflowRuntime.StartRuntime();
                    workflowRuntime.WorkflowCompleted += OnWorkflowCompleted;
                    workflowRuntime.WorkflowTerminated += OnWorkflowTerminated;

                    Type type = typeof(StateMachineWorkflow);
                    workflowRuntime.CreateWorkflow(type).Start();

                    Console.WriteLine("Running the workflow. Waiting for the timer events...");

                    waitHandle.WaitOne();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Encountered an exception. Exception Source: {0}, Exception Message: {1} ", e.Source, e.Message);
                }
                finally
                {
                    if (workflowRuntime != null)
                        workflowRuntime.StopRuntime();
                    Console.WriteLine("Done running the workflow.");
                }
            }
        }

        static void OnWorkflowCompleted(object sender, WorkflowCompletedEventArgs instance)
        {
            waitHandle.Set();
        }

        static void OnWorkflowTerminated(object sender, WorkflowTerminatedEventArgs e)
        {
            Console.WriteLine(e.Exception.Message);
            waitHandle.Set();
        }
    }
}
