//--------------------------------------------------------------------------------
// This file is a Windows Workflow Foundation "Sample" built by
// Customer Support & Services
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

using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Workflow.Runtime.Tracking;
using System.Workflow.Runtime;
using System.Configuration;
using System.Workflow.Runtime.Hosting;
using System.Workflow.ComponentModel;
using NumberGuessWorkflowLibrary;
using System.Workflow.Activities;

namespace UpdateRunningWFs
{
    class Program
    {
        static string PrevAssembly = @"C:\Workflow\PSS Training Agenda\Training Materials Folder\In Progress\Module 9 projects\EventsDemo\PrevVersions\1.0.0.0\NumberGuessWorkflowLibrary.dll";

        static void Main(string[] args)
        {
            // We need a WorkflowRuntime to do DynamicUpdate
            // And we need Persistence Service in order to
            // Load the Persisted Workflows to update
            WorkflowRuntime wfruntime = new WorkflowRuntime();
            SqlWorkflowPersistenceService service = new SqlWorkflowPersistenceService(ConnectionString);
            wfruntime.AddService(service);
            wfruntime.StartRuntime();

            // Load up them all from SqlTracking
            SqlTrackingQuery query = new SqlTrackingQuery(ConnectionString);
            SqlTrackingQueryOptions options = new SqlTrackingQueryOptions();
            options.WorkflowStatus = WorkflowStatus.Running;

            IList<SqlTrackingWorkflowInstance> list = query.GetWorkflows(options);

            foreach (SqlTrackingWorkflowInstance i in list)
            {
                // These are the v 1.0.0.0 Workflows
                // Use DynamicUpdate to add a WriteLineActivity
                // After the CEM in the game loop
                WorkflowInstance instance = wfruntime.GetWorkflow(i.WorkflowInstanceId);

                // Initialize WorkflowChanges
                WorkflowChanges changes = new WorkflowChanges(instance.GetWorkflowDefinition());

                CompositeActivity root = changes.TransientWorkflow;
                SequenceActivity sa = root.GetActivityByName("sequenceActivity1") as SequenceActivity;

                // Only update if we have not already done so
                // This is up to the host to determine
                // In our case, we know that there should be only 4
                // Activities in this sequence and we are adding
                // a 5th
                if (sa.Activities.Count == 4)
                {
                    WriteLineActivity a = new WriteLineActivity();
                    a.Msg = "Updated via Dynamic Update";

                    sa.Activities.Add(a);

                    instance.ApplyWorkflowChanges(changes);

                    instance.Unload();
                }
            }
        }

        static private string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["NumberGuess"].ConnectionString;
            }
        }
    }
}
