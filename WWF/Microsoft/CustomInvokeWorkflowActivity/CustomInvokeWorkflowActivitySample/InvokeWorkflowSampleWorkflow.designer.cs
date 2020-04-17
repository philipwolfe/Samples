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
using System.Reflection;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace CustomInvokeWorkflowActivitySample
{
	partial class InvokeWorkflowSampleWorkflow
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
            System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
            this.customInvokeWorkflowActivity1 = new CustomInvokeWorkflowActivityLibrary.CustomInvokeWorkflowActivity();
            activitybind2.Name = "InvokeWorkflowSampleWorkflow";
            activitybind2.Path = "targetWorkflow";
            // 
            // customInvokeWorkflowActivity1
            // 
            activitybind1.Name = "InvokeWorkflowSampleWorkflow";
            activitybind1.Path = "InvokedInstanceId";
            this.customInvokeWorkflowActivity1.Name = "customInvokeWorkflowActivity1";
            this.customInvokeWorkflowActivity1.AfterInvoking += new System.EventHandler(this.TraceInstanceId);
            this.customInvokeWorkflowActivity1.BeforeInvoked += new System.EventHandler(this.SetWorkflowTypeToInvoke);
            this.customInvokeWorkflowActivity1.SetBinding(CustomInvokeWorkflowActivityLibrary.CustomInvokeWorkflowActivity.InstanceIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            this.customInvokeWorkflowActivity1.SetBinding(CustomInvokeWorkflowActivityLibrary.CustomInvokeWorkflowActivity.TargetWorkflowProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            // 
            // InvokeWorkflowSampleWorkflow
            // 
            this.Activities.Add(this.customInvokeWorkflowActivity1);
            this.Name = "InvokeWorkflowSampleWorkflow";
            this.CanModifyActivities = false;
		}

		#endregion

        private CustomInvokeWorkflowActivityLibrary.CustomInvokeWorkflowActivity customInvokeWorkflowActivity1;
    }
}
