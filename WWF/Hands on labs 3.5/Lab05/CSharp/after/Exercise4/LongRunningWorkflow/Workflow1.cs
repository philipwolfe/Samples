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

namespace LongRunningWorkflow
{
	public sealed partial class Workflow1: SequentialWorkflowActivity
	{
		public Workflow1()
		{
			InitializeComponent();
		}

        private void BeforeDelay_Execute(object sender, EventArgs e)
        {
            Console.WriteLine("Beginning Delay");
        }

        private void AfterDelay_Execute(object sender, EventArgs e)
        {
            Console.WriteLine(string.Format("Finished Delay ({0} seconds)", this.delayActivity1.TimeoutDuration.Seconds));
        }

        private void AfterBranch_Execute(object sender, EventArgs e)
        {
            Console.WriteLine("Finished Branch");
        }

        private void BeforeBranch_Execute(object sender, EventArgs e)
        {
            Console.WriteLine("Beginning Branch");
        }
    }

}
