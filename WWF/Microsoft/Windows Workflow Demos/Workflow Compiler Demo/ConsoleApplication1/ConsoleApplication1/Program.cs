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
using System.Workflow.ComponentModel.Compiler;
using System.IO;
using System.CodeDom.Compiler;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;
using System.Reflection;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // This is the location of the resources used in this demo
            string Files = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\Files\");

            WorkflowCompiler wfc = new WorkflowCompiler();

            string[] compilationFiles = { Path.Combine(Files, "Workflow1.cs"), 
                Path.Combine(Files, "Workflow1.designer.cs"),
                Path.Combine(Files, "Workflow2.xoml"),
                Path.Combine(Files, "Workflow2.xoml.cs") };

            string[] assemblyNames = { };

            WorkflowCompilerParameters wfparams = new WorkflowCompilerParameters();
            wfparams.EmbeddedResources.Add(Path.Combine(Files, "Workflow1.rules"));
            wfparams.OutputAssembly = Path.Combine(Files, "Workflow1.dll");
            
            WorkflowCompilerResults results = wfc.Compile(wfparams, compilationFiles);

            if (results.Errors.Count > 0)
			{
				// Display errors
				Console.WriteLine("Errors found:");
				foreach (CompilerError error in results.Errors)
				{
					Console.WriteLine("  {0}", error.ToString());
				}

                return;
			}
			else
			{
				Console.WriteLine("Compilation successful");
				foreach (string message in results.Output)
				{
					Console.WriteLine("{0}", message);
				}

				Console.WriteLine("Output assembly: {0}", results.PathToAssembly);
			}


            // Now run the workflow
            WorkflowRuntime wfruntime = new WorkflowRuntime();
            wfruntime.AddService(new ManualWorkflowSchedulerService());

            TypeProvider typeProvider = new TypeProvider(wfruntime);

            Assembly wf1 = Assembly.LoadFrom(Path.Combine(Files, "Workflow1.dll"));

            typeProvider.AddAssembly(wf1);
            wfruntime.AddService(typeProvider);

            // Execute Workflow1
            WorkflowInstance instance = wfruntime.CreateWorkflow(wf1.GetType("WorkflowLibrary1.Workflow1"));

            instance.Start();
            wfruntime.GetService<ManualWorkflowSchedulerService>().RunWorkflow(instance.InstanceId);

            // Execute Workflow2
            instance = wfruntime.CreateWorkflow(wf1.GetType("WorkflowLibrary1.Workflow2"));

            instance.Start();
            wfruntime.GetService<ManualWorkflowSchedulerService>().RunWorkflow(instance.InstanceId);
        }
    }
}
