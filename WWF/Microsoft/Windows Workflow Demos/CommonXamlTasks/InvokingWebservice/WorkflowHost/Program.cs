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
using System.Threading;
using System.Workflow.Runtime;
using System.IO;
using System.Xml;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.Activities;
using SimpleCommunication;
using System.Reflection;

namespace WorkflowHost
{
    class Program
    {
        static string Files = @"..\..\..\Files\";
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

                // Add LocalServices to WorkflowRuntime
                ExternalDataExchangeService edx = new ExternalDataExchangeService();
                workflowRuntime.AddService(edx);
                edx.AddService(new LocalService());

                // TypeProvider to hold CustomWorkflowTypes assembly
                string file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\CustomWorkflowTypes\bin\Debug\CustomWorkflowTypes.dll");
                TypeProvider t = new TypeProvider(workflowRuntime);
                t.AddAssembly(Assembly.LoadFile(file));
                workflowRuntime.AddService(t);

                // Input Parameters
                Dictionary<string, object> inputs = new Dictionary<string, object>();
                inputs.Add("PersonName", "Steve");

                // Load it up
                StreamReader s = File.OpenText(Path.Combine(Files, "MyWorkflow.xoml"));
                XmlReader reader = XmlReader.Create(s);

                // and Execute it
                try
                {
                    WorkflowInstance instance = workflowRuntime.CreateWorkflow(reader, null, inputs);
                    instance.Start();
                }
                catch (WorkflowValidationFailedException ex)
                {
                    Console.WriteLine("Exception: {0}", ex.Message);
                    Console.WriteLine("Errors collection: {0} errors", ex.Errors.Count);
                    foreach (ValidationError error in ex.Errors)
                    {
                        Console.WriteLine(error.ToString());
                    }
                } 

                waitHandle.WaitOne();
            }
        }
    }
}
