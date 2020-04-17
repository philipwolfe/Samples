//---------------------------------------------------------------------
//  This file is part of the Windows Workflow Foundation Sample Code.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//  This source code is intended only as a supplement to Microsoft
//  Development Tools and/or on-line documentation.  See these other
//  materials for detailed information regarding Microsoft code samples.
// 
//  THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//  PARTICULAR PURPOSE.
//---------------------------------------------------------------------

#region Using directives

using System;
using System.Threading;
using System.Workflow.Activities;
using System.Workflow.Runtime;

#endregion

namespace SendDataToStateMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            using(WorkflowRuntime workflowRuntime = new WorkflowRuntime())
            {
                ExternalDataExchangeService dataExchange = new ExternalDataExchangeService();
                workflowRuntime.AddService(dataExchange);
                MyService myService = new MyService();
                dataExchange.AddService(myService);
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

                WorkflowInstance instance = workflowRuntime.CreateWorkflow(typeof(SendDataToStateMachine.Workflow1));
                instance.Start();

                myService.RaiseEvent(new CompletedEventArgs(instance.InstanceId, "All good things must come to an end."));

                waitHandle.WaitOne();
            }
        }
    }
}
