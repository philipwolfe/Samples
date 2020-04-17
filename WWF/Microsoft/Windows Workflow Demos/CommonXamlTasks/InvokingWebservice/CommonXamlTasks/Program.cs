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

            // InvokeWebServiceActivity
            InvokeWebServiceActivity iws = new InvokeWebServiceActivity();
            iws.ProxyClass = typeof(CustomWorkflowTypes.LocalWS.Service);
            iws.MethodName = "SayHello";

            // Bind input parameter
            WorkflowParameterBinding iwspb1 = new WorkflowParameterBinding();
            iwspb1.ParameterName = "PersonName";
            iwspb1.SetBinding(WorkflowParameterBinding.ValueProperty, new ActivityBind("BaseWorkflow", "PersonName"));
            iws.ParameterBindings.Add(iwspb1);

            // Bind Output Parameter
            WorkflowParameterBinding iwspb2 = new WorkflowParameterBinding();
            iwspb2.ParameterName = "(ReturnValue)";
            iwspb2.SetBinding(WorkflowParameterBinding.ValueProperty, new ActivityBind("BaseWorkflow", "WSResults"));
            iws.ParameterBindings.Add(iwspb2);

            // Invoking event
            iws.SetBinding(InvokeWebServiceActivity.InvokingEvent, new ActivityBind("BaseWorkflow", "WSInvoking"));

            // Invoked Event
            iws.SetBinding(InvokeWebServiceActivity.InvokedEvent, new ActivityBind("BaseWorkflow", "WSInvoked"));

            // Add it to the Workflow
            wf.Activities.Add(iws);

            // ConsoleWriteLineActivity
            ConsoleWriteLineActivity cwa = new ConsoleWriteLineActivity();
            cwa.SetBinding(ConsoleWriteLineActivity.MessageProperty, new ActivityBind("BaseWorkflow", "WSResults"));
            wf.Activities.Add(cwa);

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
