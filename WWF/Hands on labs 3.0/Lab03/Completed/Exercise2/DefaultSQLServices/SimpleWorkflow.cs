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

namespace DefaultSQLServices
{
	public sealed partial class SimpleWorkflow: SequentialWorkflowActivity
	{
		public SimpleWorkflow()
		{
			InitializeComponent();
		}

        private void working_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("Here in working_ExecuteCode.");
        }

        private void timeBefore_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("before delay: \'{0}\'", DateTime.Now.ToLongTimeString());
        }

        private void timeAfter_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("after delay: \'{0}\'", DateTime.Now.ToLongTimeString());
        }

        private void code_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("Here in code_ExecuteCode.");
            System.Threading.Thread.Sleep(new TimeSpan(0, 0, 2));

        }
	}

}
