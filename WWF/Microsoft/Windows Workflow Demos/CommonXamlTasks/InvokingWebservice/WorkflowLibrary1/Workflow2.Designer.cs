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
using System.Reflection;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace WorkflowLibrary1
{
	partial class Workflow2
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
            System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding1 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind3 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding2 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            this.consoleWriteLineActivity1 = new CustomWorkflowTypes.ConsoleWriteLineActivity();
            this.invokeWebServiceActivity1 = new System.Workflow.Activities.InvokeWebServiceActivity();
            // 
            // consoleWriteLineActivity1
            // 
            activitybind1.Name = "Workflow2";
            activitybind1.Path = "WSResults";
            this.consoleWriteLineActivity1.Name = "consoleWriteLineActivity1";
            this.consoleWriteLineActivity1.SetBinding(CustomWorkflowTypes.ConsoleWriteLineActivity.MessageProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            // 
            // invokeWebServiceActivity1
            // 
            this.invokeWebServiceActivity1.MethodName = "SayHello";
            this.invokeWebServiceActivity1.Name = "invokeWebServiceActivity1";
            activitybind2.Name = "Workflow2";
            activitybind2.Path = "PersonName";
            workflowparameterbinding1.ParameterName = "PersonName";
            workflowparameterbinding1.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            activitybind3.Name = "Workflow2";
            activitybind3.Path = "WSResults";
            workflowparameterbinding2.ParameterName = "(ReturnValue)";
            workflowparameterbinding2.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            this.invokeWebServiceActivity1.ParameterBindings.Add(workflowparameterbinding1);
            this.invokeWebServiceActivity1.ParameterBindings.Add(workflowparameterbinding2);
            this.invokeWebServiceActivity1.ProxyClass = typeof(WorkflowLibrary1.LocalWS.Service);
            this.invokeWebServiceActivity1.Invoking += new System.EventHandler<System.Workflow.Activities.InvokeWebServiceEventArgs>(this.WSInvoking);
            this.invokeWebServiceActivity1.Invoked += new System.EventHandler<System.Workflow.Activities.InvokeWebServiceEventArgs>(this.WSInvoked);
            // 
            // Workflow2
            // 
            this.Activities.Add(this.invokeWebServiceActivity1);
            this.Activities.Add(this.consoleWriteLineActivity1);
            this.Name = "Workflow2";
            this.CanModifyActivities = false;

		}

		#endregion

        private CustomWorkflowTypes.ConsoleWriteLineActivity consoleWriteLineActivity1;
        private InvokeWebServiceActivity invokeWebServiceActivity1;




    }
}
