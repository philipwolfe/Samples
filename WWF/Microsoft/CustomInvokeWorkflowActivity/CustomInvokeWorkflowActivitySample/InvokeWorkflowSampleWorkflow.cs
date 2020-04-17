//--------------------------------------------------------------------------------
// This file is part of the Windows Workflow Foundation Sample Code
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
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using CustomInvokeWorkflowActivityLibrary;

namespace CustomInvokeWorkflowActivitySample
{
	public sealed partial class InvokeWorkflowSampleWorkflow: SequentialWorkflowActivity
	{
		public InvokeWorkflowSampleWorkflow()
		{
			InitializeComponent();
		}

        public Guid InvokedInstanceId = default(System.Guid);
        public Type targetWorkflow = default(System.Type);

        private void SetWorkflowTypeToInvoke(object sender, EventArgs e)
        {
            Console.WriteLine("Setting the target workflow type and parameters on the invoking workflow");
            targetWorkflow = typeof(InvokedWorkflow);
            (sender as CustomInvokeWorkflowActivity).Parameters.Add("MyProperty", "Incoming value");
        }

        private void TraceInstanceId(object sender, EventArgs e)
        {
            Console.WriteLine(string.Format("The instance id for the invoked workflow is '{0}'", InvokedInstanceId));
        }
	}

}
