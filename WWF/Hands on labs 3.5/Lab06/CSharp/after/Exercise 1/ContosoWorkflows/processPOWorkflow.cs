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

namespace ContosoWorkflows
{
	public sealed partial class processPOWorkflow: SequentialWorkflowActivity
	{
        public POSchema.PO newPO = POSchema.PO.GeneratePOInstance();

		public processPOWorkflow()
		{
			InitializeComponent();
		}

        public ContosoWorkflows.Fabrikam.PO outgoingPOforFabrikam = new ContosoWorkflows.Fabrikam.PO();
        public ContosoWorkflows.Fabrikam.PO POResponsefromFabrikam = new ContosoWorkflows.Fabrikam.PO();

        private void invokePOSubmissionWSFabrikam_Invoking(object sender, InvokeWebServiceEventArgs e)
        {
            POHelpers.CopyPOHeader(newPO, outgoingPOforFabrikam);
            POHelpers.CopyPOHistory(newPO, outgoingPOforFabrikam);
            POHelpers.CopyPOItems(newPO, outgoingPOforFabrikam);

        }

        private void invokePOSubmissionWSFabrikam_Invoked(object sender, InvokeWebServiceEventArgs e)
        {

        }

        public ContosoWorkflows.Northwind.PO outgoingPOforNorthwind = new ContosoWorkflows.Northwind.PO();
        public ContosoWorkflows.Northwind.PO POResponsefromNorthwind = new ContosoWorkflows.Northwind.PO();

        private void invokePOSubmissionWSNorthwind_Invoking(object sender, InvokeWebServiceEventArgs e)
        {
            outgoingPOforNorthwind = new Northwind.PO();
            POHelpers.CopyPOHeader(newPO, outgoingPOforNorthwind);
            POHelpers.CopyPOHistory(newPO, outgoingPOforNorthwind);
            POHelpers.CopyPOItems(newPO, outgoingPOforNorthwind);

        }

        private void invokePOSubmissionWSNorthwind_Invoked(object sender, InvokeWebServiceEventArgs e)
        {

        }

        private void afterWSFabrikamInvoke_ExecuteCode(object sender, EventArgs e)
        {
            // Initialize it to a time where electronic PO processing was not invented.
            DateTime statusDate = new DateTime(1900, 1, 1);
            Fabrikam.POStatus lastStatus = null;

            //Find the last status by looping over the history items
            foreach (Fabrikam.POStatus stat in POResponsefromFabrikam.History)
            {
                if (stat.Timestamp > statusDate)
                {
                    statusDate = stat.Timestamp;
                    lastStatus = stat;
                }
            }

            System.Console.WriteLine("Your PO has been {0} on {1} by Fabrikam", lastStatus.PoStatus, lastStatus.Timestamp);

        }

        private void afterWSNorthwindInvoke_ExecuteCode(object sender, EventArgs e)
        {
            // Initialize it to a time where electronic PO processing was not invented.
            DateTime statusDate = new DateTime(1900, 1, 1);
            Northwind.POStatus lastStatus = null;

            //Find the last status by looping over the history items
            foreach (Northwind.POStatus stat in POResponsefromNorthwind.History)
            {
                if (stat.Timestamp > statusDate)
                {
                    statusDate = stat.Timestamp;
                    lastStatus = stat;
                }
            }
            System.Console.WriteLine("Your PO has been {0} on {1} by Northwind", lastStatus.PoStatus, lastStatus.Timestamp);

        }

  
	}

}
