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

namespace WorkflowLibrary1
{
	public sealed partial class Workflow2: SequentialWorkflowActivity
	{
		public Workflow2()
		{
			InitializeComponent();
		}

        private void WSInvoked(object sender, InvokeWebServiceEventArgs e)
        {

        }

        private void WSInvoking(object sender, InvokeWebServiceEventArgs e)
        {

        }

        private string personName;

        public string PersonName
        {
            get { return personName; }
            set { personName = value; }
        }

        private string wsResults;

        public string WSResults
        {
            get { return wsResults; }
            set { wsResults = value; }
        }
	}

}
