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

namespace AtomicTransactionWorkflow
{
    class Program
    {
        static AutoResetEvent waitHandle = new AutoResetEvent(false);

        static void Main(string[] args)
        {
            WorkflowRuntime workflowRuntime = new WorkflowRuntime();

            string connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
            workflowRuntime.AddService(new SqlWorkflowPersistenceService(connectionString));

            waitHandle = new AutoResetEvent(false);
            workflowRuntime.WorkflowCompleted += new EventHandler<WorkflowCompletedEventArgs>(OnWorkflowCompleted);
            workflowRuntime.WorkflowTerminated += delegate(object sender, WorkflowTerminatedEventArgs e)
            {
                Console.WriteLine(e.Exception.Message);
                waitHandle.Set();
            };



            WorkflowInstance instance = workflowRuntime.CreateWorkflow(typeof(AtomicTransactionWorkflow.Workflow1));
            instance.Start();

            waitHandle.WaitOne();
        }

        static void OnWorkflowCompleted(object sender, WorkflowCompletedEventArgs e)
        {
            Console.WriteLine("Press enter to continue");
            Console.Read();
            waitHandle.Set();
           
        }
    }
}
