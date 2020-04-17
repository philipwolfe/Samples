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

namespace HostingWorkflowRuntime
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WorkflowRuntime workflowRuntime = new WorkflowRuntime())
            {
                string connectionString = "Initial Catalog=TrackingStore; " +
            "Data Source=localhost\\SQLEXPRESS; " +
            "Integrated Security=SSPI;";
                workflowRuntime.AddService(new System.Workflow.Runtime.Tracking.SqlTrackingService(connectionString));

                AutoResetEvent waitHandle = new AutoResetEvent(false);
                workflowRuntime.WorkflowCompleted += delegate(object sender, WorkflowCompletedEventArgs e) { waitHandle.Set(); };
                workflowRuntime.WorkflowTerminated += delegate(object sender, WorkflowTerminatedEventArgs e)
                {
                    Console.WriteLine(e.Exception.Message);
                    waitHandle.Set();
                };
                workflowRuntime.Started += new
  EventHandler<WorkflowRuntimeEventArgs>(workflowRuntime_Started);
                workflowRuntime.Stopped += new
                  EventHandler<WorkflowRuntimeEventArgs>(workflowRuntime_Stopped);
                workflowRuntime.WorkflowResumed += new
  EventHandler<WorkflowEventArgs>(workflowRuntime_WorkflowResumed);
                workflowRuntime.WorkflowSuspended += new
                  EventHandler<WorkflowSuspendedEventArgs>(workflowRuntime_WorkflowSuspended);

                WorkflowInstance instance = workflowRuntime.CreateWorkflow(typeof(HostingWorkflowRuntime.SimpleWorkflow));
                instance.Start();

                instance.Suspend("Reason we are suspending the workflow.");
                instance.Resume();

                waitHandle.WaitOne();
                Console.WriteLine("Workflow Completed - press ENTER to continue");
                Console.Read();
            }
        }

        static void workflowRuntime_Stopped(object sender, WorkflowRuntimeEventArgs e)
        {
            Console.WriteLine("Runtime stopped event.");
        }

        static void workflowRuntime_Started(object sender, WorkflowRuntimeEventArgs e)
        {
            WorkflowRuntime w = (WorkflowRuntime)sender;
            ICollection<object> services = w.GetAllServices(typeof(object));
            foreach (object o in services)
            {
                Console.WriteLine("Service of type " + o.ToString() + " started.");
            }
        }

        static void workflowRuntime_WorkflowSuspended(object sender,
                                              WorkflowSuspendedEventArgs e)
        {
            Console.WriteLine("In WorkflowSuspended, reason: " + e.Error);
        }

        static void workflowRuntime_WorkflowResumed(object sender, WorkflowEventArgs e)
        {
            Console.WriteLine("In WorkflowResumed");
        }

    }
}
