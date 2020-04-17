//--------------------------------------------------------------------------------
// This file is a "Sample" as from Windows Workflow Foundation
// Hands on Labs
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
using System.Workflow.Runtime.Tracking;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

#endregion

namespace DefaultSQLServices
{
    class Program
    {
        static string connectionString = "Initial Catalog=TrackingStore;" +
          "Data Source=localhost\\SQLExpress; Integrated Security=SSPI;";

        static void Main(string[] args)
        {
            using(WorkflowRuntime workflowRuntime = new WorkflowRuntime())
            {
                workflowRuntime.AddService(new SharedConnectionWorkflowCommitWorkBatchService(connectionString));
                workflowRuntime.AddService(new SqlTrackingService(connectionString));
                workflowRuntime.AddService(new SqlWorkflowPersistenceService(connectionString, true, new TimeSpan(0, 0, 0, 10, 0), new TimeSpan(0, 0, 0, 10, 0)));
                workflowRuntime.AddService(new DefaultWorkflowSchedulerService()); 
                AutoResetEvent waitHandle = new AutoResetEvent(false);
                workflowRuntime.WorkflowCompleted += delegate(object sender, WorkflowCompletedEventArgs e) {waitHandle.Set();};
                workflowRuntime.WorkflowTerminated += delegate(object sender, WorkflowTerminatedEventArgs e)
                {
                    Console.WriteLine(e.Exception.Message);
                    waitHandle.Set();
                };
                workflowRuntime.WorkflowLoaded += new
  EventHandler<WorkflowEventArgs>(workflowRuntime_WorkflowLoaded);
                workflowRuntime.WorkflowIdled += new
                  EventHandler<WorkflowEventArgs>(workflowRuntime_WorkflowIdled);
                workflowRuntime.WorkflowPersisted += new
                  EventHandler<WorkflowEventArgs>(workflowRuntime_WorkflowPersisted);
                workflowRuntime.WorkflowUnloaded += new
                  EventHandler<WorkflowEventArgs>(workflowRuntime_WorkflowUnloaded);

                for (int workflowCount = 0; workflowCount < 5; workflowCount++)
                {
                    WorkflowInstance simpleWorkflowInstance = workflowRuntime.CreateWorkflow(typeof(DefaultSQLServices.SimpleWorkflow));
                    simpleWorkflowInstance.Start();
                }

                System.Threading.Thread.Sleep(new TimeSpan(0, 0, 20));

                Console.WriteLine("Workflow Completed - press ENTER to continue");
                Console.Read();
            }
        }

        static void workflowRuntime_WorkflowIdled(object sender, WorkflowEventArgs e)
        {
            Console.WriteLine("Workflow {0} idled", e.WorkflowInstance.InstanceId);
            ThreadPool.QueueUserWorkItem(UnloadInstance, e.WorkflowInstance);
        }

        static void workflowRuntime_WorkflowUnloaded(object sender, WorkflowEventArgs e)
        {
            Console.WriteLine("Workflow {0} unloaded", e.WorkflowInstance.InstanceId);
        }

        static void workflowRuntime_WorkflowPersisted(object sender, WorkflowEventArgs e)
        {
            Console.WriteLine("Workflow {0} persisted", e.WorkflowInstance.InstanceId);
        }

        static void workflowRuntime_WorkflowLoaded(object sender, WorkflowEventArgs e)
        {
            Console.WriteLine("Workflow {0} loaded", e.WorkflowInstance.InstanceId);
        }

        static void UnloadInstance(object workflowInstance)
        {
            WorkflowInstance instance = (WorkflowInstance)workflowInstance;

            try
            {
                Console.WriteLine("UnloadInstance: attempting to unload \'{0}\'", instance.InstanceId);
                instance.Unload();
            }
            catch (Exception ex)
            {
                Console.WriteLine("UnloadInstance: failed \r\n{0}", ex);
            }
        }

        static void GetInstanceTrackingEvents(Guid instanceId)
        {
            Console.WriteLine("\r\nInstance Tracking Events :");

            SqlTrackingQuery sqlTrackingQuery = new SqlTrackingQuery(connectionString);
            SqlTrackingWorkflowInstance sqlTrackingWorkflowInstance;
            sqlTrackingQuery.TryGetWorkflow(instanceId, out sqlTrackingWorkflowInstance);

            try
            {
                foreach (WorkflowTrackingRecord workflowTrackingRecord in sqlTrackingWorkflowInstance.WorkflowEvents)
                {
                    Console.WriteLine("EventDescription : {0}  DateTime : {1}", workflowTrackingRecord.TrackingWorkflowEvent, workflowTrackingRecord.EventDateTime);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("No Instance Tracking Events Found");
            }
        } 		 

    }
}
