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

#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;
using System.Workflow.Activities;
using System.Workflow.ComponentModel;
using System.IO;
using System.Xml;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel.Compiler;

#endregion

namespace CommonXamlTasks
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

                // Input Parameters
                Dictionary<string, object> inputs = new Dictionary<string, object>();
                inputs.Add("PersonName", "Steve");

                // Create a Workflow
                BaseWorkflow wf = new BaseWorkflow();
                wf.Name = "BaseWorkflow";

                // Create the CodeActivity
                CodeActivity ca = new CodeActivity();

                // Specify the ExecuteCode method
                ActivityBind ab = new ActivityBind("BaseWorkflow", "WriteName");
                ca.SetBinding(CodeActivity.ExecuteCodeEvent, ab);

                // Add it to the Workflow
                wf.Activities.Add(ca);

                // Serialize it out to a file
                StreamWriter sw = File.CreateText(Path.Combine(Files, "BaseWorkflow.xoml"));
                XmlWriter wr = XmlTextWriter.Create(sw);
                WorkflowMarkupSerializer wms = new WorkflowMarkupSerializer();
                wms.Serialize(wr, wf);
                wr.Close();
                sw.Close();

                // Load it up
                StreamReader s = File.OpenText(Path.Combine(Files, "BaseWorkflow.xoml"));
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
