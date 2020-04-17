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

namespace SwitchSampleApplication
{
	public sealed partial class SwitchSampleWorkflow: SequentialWorkflowActivity
	{
		public SwitchSampleWorkflow()
		{
			InitializeComponent();
		}

        private void ExecuteIt(object sender, EventArgs e)
        {
            Console.WriteLine(string.Format("Running activity '{0}'.", (sender as Activity).Name));
        }

        public object expression1 = ActivityExecutionResult.Canceled;
        public object expression2 = ActivityExecutionResult.Faulted;
        public object expression3 = ActivityExecutionResult.Uninitialized;
        public object[] case1 = new object[] { ActivityExecutionResult.Compensated, ActivityExecutionResult.Canceled };
        public object case2 = ActivityExecutionResult.Faulted;
        public object[] case3 = new object[] { ActivityExecutionResult.None, ActivityExecutionResult.Succeeded };               
	}    
}
