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

namespace CommunicationsWorkflow
{
	partial class VotingWorkflow
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
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding3 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            this.JimReject = new System.Workflow.Activities.HandleExternalEventActivity();
            this.JimApprove = new System.Workflow.Activities.HandleExternalEventActivity();
            this.WaitForJimRejection = new System.Workflow.Activities.EventDrivenActivity();
            this.WaitForJimApproval = new System.Workflow.Activities.EventDrivenActivity();
            this.cancellationHandlerActivity1 = new System.Workflow.ComponentModel.CancellationHandlerActivity();
            this.faultHandlersActivity1 = new System.Workflow.ComponentModel.FaultHandlersActivity();
            this.WaitForJimResponse = new System.Workflow.Activities.ListenActivity();
            this.CreateBallotForJim = new System.Workflow.Activities.CallExternalMethodActivity();
            // 
            // JimReject
            // 
            this.JimReject.EventName = "RejectProposal";
            this.JimReject.InterfaceType = typeof(CommunicationsWorkflow.IVotingService);
            this.JimReject.Name = "JimReject";
            activitybind1.Name = "VotingWorkflow";
            activitybind1.Path = "votingArgs";
            workflowparameterbinding1.ParameterName = "e";
            workflowparameterbinding1.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            this.JimReject.ParameterBindings.Add(workflowparameterbinding1);
            this.JimReject.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.OnRejected);
            // 
            // JimApprove
            // 
            this.JimApprove.EventName = "ApproveProposal";
            this.JimApprove.InterfaceType = typeof(CommunicationsWorkflow.IVotingService);
            this.JimApprove.Name = "JimApprove";
            activitybind2.Name = "VotingWorkflow";
            activitybind2.Path = "votingArgs";
            workflowparameterbinding2.ParameterName = "e";
            workflowparameterbinding2.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            this.JimApprove.ParameterBindings.Add(workflowparameterbinding2);
            this.JimApprove.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.OnApproved);
            // 
            // WaitForJimRejection
            // 
            this.WaitForJimRejection.Activities.Add(this.JimReject);
            this.WaitForJimRejection.Name = "WaitForJimRejection";
            // 
            // WaitForJimApproval
            // 
            this.WaitForJimApproval.Activities.Add(this.JimApprove);
            this.WaitForJimApproval.Name = "WaitForJimApproval";
            // 
            // cancellationHandlerActivity1
            // 
            this.cancellationHandlerActivity1.Name = "cancellationHandlerActivity1";
            // 
            // faultHandlersActivity1
            // 
            this.faultHandlersActivity1.Name = "faultHandlersActivity1";
            // 
            // WaitForJimResponse
            // 
            this.WaitForJimResponse.Activities.Add(this.WaitForJimApproval);
            this.WaitForJimResponse.Activities.Add(this.WaitForJimRejection);
            this.WaitForJimResponse.Name = "WaitForJimResponse";
            // 
            // CreateBallotForJim
            // 
            this.CreateBallotForJim.InterfaceType = typeof(CommunicationsWorkflow.IVotingService);
            this.CreateBallotForJim.MethodName = "CreateBallot";
            this.CreateBallotForJim.Name = "CreateBallotForJim";
            workflowparameterbinding3.ParameterName = "alias";
            workflowparameterbinding3.Value = "Jim";
            this.CreateBallotForJim.ParameterBindings.Add(workflowparameterbinding3);
            // 
            // VotingWorkflow
            // 
            this.Activities.Add(this.CreateBallotForJim);
            this.Activities.Add(this.WaitForJimResponse);
            this.Activities.Add(this.faultHandlersActivity1);
            this.Activities.Add(this.cancellationHandlerActivity1);
            this.Name = "VotingWorkflow";
            this.CanModifyActivities = false;

		}

		#endregion

        private HandleExternalEventActivity JimReject;
        private HandleExternalEventActivity JimApprove;
        private EventDrivenActivity WaitForJimRejection;
        private EventDrivenActivity WaitForJimApproval;
        private ListenActivity WaitForJimResponse;
        private CancellationHandlerActivity cancellationHandlerActivity1;
        private FaultHandlersActivity faultHandlersActivity1;
        private CallExternalMethodActivity CreateBallotForJim;






    }
}
