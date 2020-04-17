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
        static Dictionary<string, object> parameters = new Dictionary<string, object>();

        static void Main(string[] args)
        {
            WorkflowRuntime workflowRuntime = new WorkflowRuntime();

            // workflow runtime events
            workflowRuntime.Started += new 
                EventHandler<WorkflowRuntimeEventArgs>(workflowRuntime_Started);
            workflowRuntime.Stopped += new 
                EventHandler<WorkflowRuntimeEventArgs>(workflowRuntime_Stopped);

            workflowRuntime.WorkflowCompleted += new 
                EventHandler<WorkflowCompletedEventArgs>
                (workflowRuntime_WorkflowCompleted);

            workflowRuntime.StartRuntime();

            // retrieve workflow parameters
            do
            {
                try
                {
                    Console.Write("Enter a value for operand1: ");
                    parameters["Operand1"] = Int32.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + Environment.NewLine);
                }
            } while (parameters.ContainsKey("Operand1") == false);

            do
            {
                try
                {
                    Console.Write("Enter a value for operand2: ");
                    parameters["Operand2"] = Int32.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + Environment.NewLine);
                }
            } while (parameters.ContainsKey("Operand2") == false);

            Type type = typeof(HostingWorkflows);
            WorkflowInstance workflowInstance = workflowRuntime.CreateWorkflow(type, parameters);

            workflowInstance.Start();

            waitHandle.WaitOne();

            workflowRuntime.StopRuntime();
        }

        static void workflowRuntime_Started(object sender, WorkflowRuntimeEventArgs e)
        {
            Console.WriteLine("Workflow runtime started");
        }

        static void workflowRuntime_Stopped(object sender, WorkflowRuntimeEventArgs e)
        {
            Console.WriteLine("Workflow runtime stopped");
        }

        static void workflowRuntime_WorkflowCompleted(object sender, 
            WorkflowCompletedEventArgs e)
        {
            Console.WriteLine("Result: {0}", e.OutputParameters["Result"]);
            waitHandle.Set();
        }
    }
}
