//--------------------------------------------------------------------------------
// This file is a "Sample" as from Windows Workflow Foundation
// Hands on Labs RC
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

namespace WorkflowConsoleApplication1
{
	public sealed partial class Workflow1: SequentialWorkflowActivity
	{
		public Workflow1()
		{
			InitializeComponent();
		}

        public void replicatorActivity1_Initialized(object sender, EventArgs e)
        {
            // Populate the data used for each instance of the Replicator's 
            // child instance that are created
            ArrayList children = new ArrayList();
            children.Add("Child Instance 1");
            children.Add("Child Instance 2");
            children.Add("Child Instance 3");
            children.Add("Child Instance 4");
            children.Add("Child Instance 5");
            children.Add("Child Instance 6");
            replicatorActivity1.InitialChildData = children;

            // Specify how the child instances should be created - in parallel 
            // or in a sequence
            replicatorActivity1.ExecutionType = ExecutionType.Sequence;
        }

        public void codeActivity1_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("In codeActivity1_ExecuteCode");
        }


        private void childCompleted(object sender, ReplicatorChildEventArgs e)
        {
            Console.WriteLine("Completed {0}", e.InstanceData.ToString());
        }
        private void childInitialized(object sender, ReplicatorChildEventArgs e)
        {
            Console.WriteLine("Initialized {0}", e.InstanceData.ToString());
        }

        private void workflowCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("Workflow finished");
        }
	}
}
