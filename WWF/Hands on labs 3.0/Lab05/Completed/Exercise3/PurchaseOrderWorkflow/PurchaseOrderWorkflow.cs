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
using System.Workflow.Activities;
using System.Security.Principal;

namespace Microsoft.Samples.Workflow.WebWorkflow
{
    public sealed partial class PurchaseOrderWorkflow : SequentialWorkflowActivity
    {
        public PurchaseOrderWorkflow()
        {
            InitializeComponent();
        }

        public WorkflowRoleCollection poInitiators = new WorkflowRoleCollection();

        private void OnSetupRoles(object sender, EventArgs e)
        {
            WebWorkflowRole poInitiatorsRole = new WebWorkflowRole("Clerk");

            // Add the role to the RoleCollection representing the POInitiators
            poInitiators.Add(poInitiatorsRole);
        }

        private void OnInitiatePO(object sender, ExternalDataEventArgs e)
        {
            Console.WriteLine("Purchase Order initiated successfully");
        }

        private void AuthExceptionHandler(object sender, EventArgs e)
        {
            Console.WriteLine("Exception message: {0}", faultHandlerActivity1.Fault.Message.ToString());
        }
    }
}
