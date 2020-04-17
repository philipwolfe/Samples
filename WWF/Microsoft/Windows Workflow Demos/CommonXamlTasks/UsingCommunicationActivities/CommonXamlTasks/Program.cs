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

using CustomWorkflowTypes;

namespace CommonXamlTasks
{
    class Program
    {
        static string Files = @"..\..\..\Files\";
        static void Main(string[] args)
        {
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

            // Add HandleExternalEvent and CallExternalMethod
            CallExternalMethodActivity cem = new CallExternalMethodActivity();
            cem.InterfaceType = typeof(SimpleCommunication.ILocalService);
            cem.MethodName = "GetResult";

            wf.Activities.Add(cem);

            HandleExternalEventActivity hee = new HandleExternalEventActivity();
            hee.InterfaceType = typeof(SimpleCommunication.ILocalService);
            hee.EventName = "WorkComplete";

            ActivityBind heeab = new ActivityBind("BaseWorkflow", "EventReceived");
            hee.SetBinding(HandleExternalEventActivity.InvokedEvent, heeab);

            wf.Activities.Add(hee);

            // Use the WCA Activities
            SimpleCommunication.GetResult gr = new SimpleCommunication.GetResult();
            wf.Activities.Add(gr);

            SimpleCommunication.WorkComplete wc = new SimpleCommunication.WorkComplete();
            wc.SetBinding(SimpleCommunication.WorkComplete.InvokedEvent, heeab);
            wf.Activities.Add(wc);

            // Serialize it out to a file
            StreamWriter sw = File.CreateText(Path.Combine(Files, "MyWorkflow.xoml"));
            XmlWriter wr = XmlTextWriter.Create(sw);
            WorkflowMarkupSerializer wms = new WorkflowMarkupSerializer();
            wms.Serialize(wr, wf);
            wr.Close();
            sw.Close();

            Console.WriteLine("Workflow Serialized");
        }
    }
}
