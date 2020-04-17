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
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;
using System.Xml;
using System.IO;
using System.Workflow.ComponentModel.Compiler;
using System.Reflection;
using System.Workflow.Activities;
using System.Workflow.ComponentModel;
using ActivityLibrary1;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.Runtime.Configuration;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // This is the location of the resources used in this demo
            string Files = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\Files\");

            /*
            // You can set a property in the config or you can
            // programmatically use this method to disable validation
            WorkflowRuntimeSection wrs = new WorkflowRuntimeSection();

            wrs.ValidateOnCreate = false;

            // When you create the runtime, pass in the runtime section
            WorkflowRuntime wfruntime = new WorkflowRuntime(wrs);
            /*/
            // By default, you get validation of Xaml
            // activated workflows
            WorkflowRuntime wfruntime = new WorkflowRuntime();
            //*/

            wfruntime.AddService(new ManualWorkflowSchedulerService());

            TypeProvider typeProvider = new TypeProvider(wfruntime);
            Assembly a = Assembly.LoadFrom(Path.Combine(Files, "ActivityLibrary1.dll"));
            typeProvider.AddAssembly(a);
            wfruntime.AddService(typeProvider);

            /*
            // Use Xaml activation to load and execute Workflow1.xoml
            StreamReader s = File.OpenText(Path.Combine(Files, "Workflow1.xoml"));
            XmlReader reader = XmlReader.Create(s);

            /*/
            // Create a Workflow in memory and use the WorkflowMarkupSerializer
            // to get the Xaml, and then load and execute it
            //SequentialWorkflowActivity wf = new SequentialWorkflowActivity();
            //SequentialWorkflowBase
            WorkflowBase wf = new WorkflowBase();
            ConsoleWriteLineActivity cwl = new ConsoleWriteLineActivity();
            cwl.Msg = "Hello from created by code Xaml workflow";
            wf.Activities.Add(cwl);

            StringBuilder sb = new StringBuilder();
            XmlWriter wr = XmlTextWriter.Create(sb);
            WorkflowMarkupSerializer wms = new WorkflowMarkupSerializer();
            wms.Serialize(wr, wf);
            wr.Close();

            Console.WriteLine(sb);
             
            // Create the XmlReader that holds the Xaml
            XmlReader reader = XmlReader.Create(new StringReader(sb.ToString()));
            //*/

            try
            {
                WorkflowInstance instance = wfruntime.CreateWorkflow(reader);
                instance.Start();
                wfruntime.GetService<ManualWorkflowSchedulerService>().RunWorkflow(instance.InstanceId);
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
        }
    }
}
