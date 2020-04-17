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
using System.Reflection;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace FabrikamWorkflows
{
	partial class processPOWorkflow
	{
		#region Designer generated code
		
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
		private void InitializeComponent()
		{
            this.CanModifyActivities = true;
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding1 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding2 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            this.webServiceResponsePO = new System.Workflow.Activities.WebServiceOutputActivity();
            this.webServiceReceivePO = new System.Workflow.Activities.WebServiceInputActivity();
            // 
            // webServiceResponsePO
            // 
            this.webServiceResponsePO.InputActivityName = "webServiceReceivePO";
            this.webServiceResponsePO.Name = "webServiceResponsePO";
            activitybind1.Name = "processPOWorkflow";
            activitybind1.Path = "returnedPO";
            workflowparameterbinding1.ParameterName = "(ReturnValue)";
            workflowparameterbinding1.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            this.webServiceResponsePO.ParameterBindings.Add(workflowparameterbinding1);
            this.webServiceResponsePO.SendingOutput += new System.EventHandler(this.webServiceResponsePO_SendingOutput);
            // 
            // webServiceReceivePO
            // 
            this.webServiceReceivePO.InterfaceType = typeof(FabrikamWorkflows.IProcessReceivedPO);
            this.webServiceReceivePO.IsActivating = true;
            this.webServiceReceivePO.MethodName = "ReceiveAndProcessPO";
            this.webServiceReceivePO.Name = "webServiceReceivePO";
            activitybind2.Name = "processPOWorkflow";
            activitybind2.Path = "receivedPO";
            workflowparameterbinding2.ParameterName = "aPO";
            workflowparameterbinding2.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            this.webServiceReceivePO.ParameterBindings.Add(workflowparameterbinding2);
            // 
            // processPOWorkflow
            // 
            this.Activities.Add(this.webServiceReceivePO);
            this.Activities.Add(this.webServiceResponsePO);
            this.Name = "processPOWorkflow";
            this.CanModifyActivities = false;

		}

		#endregion

        private WebServiceOutputActivity webServiceResponsePO;
        private WebServiceInputActivity webServiceReceivePO;




    }
}
