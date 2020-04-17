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

namespace FabrikamWorkflows
{
    //Webservice interface definition for the workflow
    public interface IProcessReceivedPO
    {
        POSchema.PO ReceiveAndProcessPO(POSchema.PO aPO);
    }

	public sealed partial class processPOWorkflow: SequentialWorkflowActivity
	{
		public processPOWorkflow()
		{
			InitializeComponent();
		}

        public POSchema.PO receivedPO = new POSchema.PO();
        public POSchema.PO returnedPO = new POSchema.PO();

        private void webServiceResponsePO_SendingOutput(object sender, EventArgs e)
        {
            POSchema.PO.GenerateResponseHeader(receivedPO, returnedPO, "Fabrikam_");
            POSchema.PO.CopyHistoryAndChangeStatus(receivedPO, returnedPO, "Accepted");
            POSchema.PO.CopyPOItems(receivedPO, returnedPO);
        }
	}
}
