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

namespace CustomWorkflowTypes
{
	partial class TestWorkflow
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
            this.workComplete1 = new SimpleCommunication.WorkComplete();
            this.getResult1 = new SimpleCommunication.GetResult();
            this.handleExternalEventActivity1 = new System.Workflow.Activities.HandleExternalEventActivity();
            this.callExternalMethodActivity1 = new System.Workflow.Activities.CallExternalMethodActivity();
            // 
            // workComplete1
            // 
            this.workComplete1.Name = "workComplete1";
            this.workComplete1.Value = null;
            // 
            // getResult1
            // 
            this.getResult1.Name = "getResult1";
            // 
            // handleExternalEventActivity1
            // 
            this.handleExternalEventActivity1.EventName = "WorkComplete";
            this.handleExternalEventActivity1.InterfaceType = typeof(SimpleCommunication.ILocalService);
            this.handleExternalEventActivity1.Name = "handleExternalEventActivity1";
            this.handleExternalEventActivity1.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.EventReceived);
            // 
            // callExternalMethodActivity1
            // 
            this.callExternalMethodActivity1.InterfaceType = typeof(SimpleCommunication.ILocalService);
            this.callExternalMethodActivity1.MethodName = "GetResult";
            this.callExternalMethodActivity1.Name = "callExternalMethodActivity1";
            // 
            // TestWorkflow
            // 
            this.Activities.Add(this.callExternalMethodActivity1);
            this.Activities.Add(this.handleExternalEventActivity1);
            this.Activities.Add(this.getResult1);
            this.Activities.Add(this.workComplete1);
            this.Name = "TestWorkflow";
            this.CanModifyActivities = false;

		}

		#endregion

        private HandleExternalEventActivity handleExternalEventActivity1;
        private SimpleCommunication.WorkComplete workComplete1;
        private SimpleCommunication.GetResult getResult1;
        private CallExternalMethodActivity callExternalMethodActivity1;



    }
}
