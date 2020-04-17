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

namespace DynamicUpdateInWorkflow
{
    class Program
    {
        static void Main(string[] args)
        {
            using(WorkflowRuntime workflowRuntime = new WorkflowRuntime())
            {
                AutoResetEvent waitHandle = new AutoResetEvent(false);
                workflowRuntime.WorkflowCompleted += delegate(object sender, WorkflowCompletedEventArgs e) {waitHandle.Set();};
                workflowRuntime.WorkflowTerminated += delegate(object sender, WorkflowTerminatedEventArgs e)
                {
                    Console.WriteLine(e.Exception.Message);
                    waitHandle.Set();
                };

                //start PO approval workflow with purchase less than $1000
                Console.WriteLine("Workflow test 1 (purchase less than $1000) :");
                int workflow1Amount = 750;
                Dictionary<string, object> workflow1NamedValues = new Dictionary<string, object>();
                workflow1NamedValues.Add("Amount", workflow1Amount);
                WorkflowInstance workflow1Instance = workflowRuntime.CreateWorkflow(typeof(DynamicUpdateInWorkflow.Workflow1), workflow1NamedValues);
                workflow1Instance.Start();
                waitHandle.WaitOne();

                //waiting for the workflow to complete so the console output makes sence
                System.Threading.Thread.Sleep(new TimeSpan(0, 0, 0, 10, 0));
                Console.Write("\r\n\r\n");

                // start PO approval workflow with purchase greater than $1000
                Console.WriteLine("Workflow test 2 (purchase greater than $1000) :");
                int workflow2Amount = 1200;
                Dictionary<string, object> workflow2NamedValues = new Dictionary<string, object>();
                workflow2NamedValues.Add("Amount", workflow2Amount);
                WorkflowInstance workflow2Instance = workflowRuntime.CreateWorkflow(typeof(DynamicUpdateInWorkflow.Workflow1), workflow2NamedValues);
                workflow2Instance.Start();
                waitHandle.WaitOne();

                //waiting for the workflow to complete so the console output makes sence
                System.Threading.Thread.Sleep(new TimeSpan(0, 0, 0, 10, 0));
                Console.Write("\r\n\r\n");
                Console.WriteLine("press ENTER to continue");
                Console.ReadLine(); 

                waitHandle.WaitOne();
            }
        }
    }
}
