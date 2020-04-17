//--------------------------------------------------------------------------------
// This file is a "Sample" as from Windows Workflow Foundation
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
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;
using System.Xml;

#endregion

namespace WorkflowConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            using(WorkflowRuntime workflowRuntime = new WorkflowRuntime())
            {
                //  Used for type resolution for any referenced types.
                TypeProvider typeProvider = new TypeProvider(workflowRuntime);
                typeProvider.AddAssembly(typeof(ActivityLibrary2.BaseWorkflow).Assembly);
                workflowRuntime.AddService(typeProvider);

                AutoResetEvent waitHandle = new AutoResetEvent(false);
                workflowRuntime.WorkflowCompleted += delegate(object sender, WorkflowCompletedEventArgs e) 
                {
                    waitHandle.Set();
                };
                workflowRuntime.WorkflowTerminated += delegate(object sender, WorkflowTerminatedEventArgs e)
                {
                    Console.WriteLine(e.Exception.Message);
                    waitHandle.Set();
                };

                XmlTextReader xomlReader = new XmlTextReader(@"..\..\SequentialXomlActivationSample.xoml");
                XmlTextReader ruleReader = new XmlTextReader(@"..\..\SequentialXomlActivationSample.rules");

                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("PurchaseOrder", new ActivityLibrary2.PurchaseOrder(500));

                WorkflowInstance instance = workflowRuntime.CreateWorkflow(xomlReader, ruleReader, parameters);
                instance.Start();

                waitHandle.WaitOne();
            }
        }
    }
}
