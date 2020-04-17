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
            System.Workflow.Runtime.CorrelationToken correlationtoken1 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding1 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding2 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.Runtime.CorrelationToken correlationtoken2 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind3 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding3 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind4 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding4 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding5 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding6 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            this.AliceReject = new System.Workflow.Activities.HandleExternalEventActivity();
            this.AliceApprove = new System.Workflow.Activities.HandleExternalEventActivity();
            this.JimReject = new System.Workflow.Activities.HandleExternalEventActivity();
            this.JimApprove = new System.Workflow.Activities.HandleExternalEventActivity();
            this.WaitForAliceRejection = new System.Workflow.Activities.EventDrivenActivity();
            this.WaitForAliceApproval = new System.Workflow.Activities.EventDrivenActivity();
            this.WaitForJimRejection = new System.Workflow.Activities.EventDrivenActivity();
            this.WaitForJimApproval = new System.Workflow.Activities.EventDrivenActivity();
            this.WaitForAliceResponse = new System.Workflow.Activities.ListenActivity();
            this.CreateBallotForAlice = new System.Workflow.Activities.CallExternalMethodActivity();
            this.WaitForJimResponse = new System.Workflow.Activities.ListenActivity();
            this.CreateBallotForJim = new System.Workflow.Activities.CallExternalMethodActivity();
            this.AliceSequence = new System.Workflow.Activities.SequenceActivity();
            this.JimSequence = new System.Workflow.Activities.SequenceActivity();
            this.cancellationHandlerActivity1 = new System.Workflow.ComponentModel.CancellationHandlerActivity();
            this.faultHandlersActivity1 = new System.Workflow.ComponentModel.FaultHandlersActivity();
            this.SendBallots = new System.Workflow.Activities.ParallelActivity();
            // 
            // AliceReject
            // 
            correlationtoken1.Name = "correlationTokenForAlice";
            correlationtoken1.OwnerActivityName = "AliceSequence";
            this.AliceReject.CorrelationToken = correlationtoken1;
            this.AliceReject.EventName = "RejectProposal";
            this.AliceReject.InterfaceType = typeof(CommunicationsWorkflow.IVotingServiceCorrelated);
            this.AliceReject.Name = "AliceReject";
            activitybind1.Name = "VotingWorkflow";
            activitybind1.Path = "votingArgs";
            workflowparameterbinding1.ParameterName = "e";
            workflowparameterbinding1.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            this.AliceReject.ParameterBindings.Add(workflowparameterbinding1);
            this.AliceReject.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.OnRejected);
            // 
            // AliceApprove
            // 
            this.AliceApprove.CorrelationToken = correlationtoken1;
            this.AliceApprove.EventName = "ApproveProposal";
            this.AliceApprove.InterfaceType = typeof(CommunicationsWorkflow.IVotingServiceCorrelated);
            this.AliceApprove.Name = "AliceApprove";
            activitybind2.Name = "VotingWorkflow";
            activitybind2.Path = "votingArgs";
            workflowparameterbinding2.ParameterName = "e";
            workflowparameterbinding2.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            this.AliceApprove.ParameterBindings.Add(workflowparameterbinding2);
            this.AliceApprove.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.OnApproved);
            // 
            // JimReject
            // 
            correlationtoken2.Name = "correlationTokenForJim";
            correlationtoken2.OwnerActivityName = "JimSequence";
            this.JimReject.CorrelationToken = correlationtoken2;
            this.JimReject.EventName = "RejectProposal";
            this.JimReject.InterfaceType = typeof(CommunicationsWorkflow.IVotingServiceCorrelated);
            this.JimReject.Name = "JimReject";
            activitybind3.Name = "VotingWorkflow";
            activitybind3.Path = "votingArgs";
            workflowparameterbinding3.ParameterName = "e";
            workflowparameterbinding3.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            this.JimReject.ParameterBindings.Add(workflowparameterbinding3);
            this.JimReject.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.OnRejected);
            // 
            // JimApprove
            // 
            this.JimApprove.CorrelationToken = correlationtoken2;
            this.JimApprove.EventName = "ApproveProposal";
            this.JimApprove.InterfaceType = typeof(CommunicationsWorkflow.IVotingServiceCorrelated);
            this.JimApprove.Name = "JimApprove";
            activitybind4.Name = "VotingWorkflow";
            activitybind4.Path = "votingArgs";
            workflowparameterbinding4.ParameterName = "e";
            workflowparameterbinding4.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind4)));
            this.JimApprove.ParameterBindings.Add(workflowparameterbinding4);
            this.JimApprove.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.OnApproved);
            // 
            // WaitForAliceRejection
            // 
            this.WaitForAliceRejection.Activities.Add(this.AliceReject);
            this.WaitForAliceRejection.Name = "WaitForAliceRejection";
            // 
            // WaitForAliceApproval
            // 
            this.WaitForAliceApproval.Activities.Add(this.AliceApprove);
            this.WaitForAliceApproval.Name = "WaitForAliceApproval";
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
            // WaitForAliceResponse
            // 
            this.WaitForAliceResponse.Activities.Add(this.WaitForAliceApproval);
            this.WaitForAliceResponse.Activities.Add(this.WaitForAliceRejection);
            this.WaitForAliceResponse.Name = "WaitForAliceResponse";
            // 
            // CreateBallotForAlice
            // 
            this.CreateBallotForAlice.CorrelationToken = correlationtoken1;
            this.CreateBallotForAlice.InterfaceType = typeof(CommunicationsWorkflow.IVotingServiceCorrelated);
            this.CreateBallotForAlice.MethodName = "CreateBallot";
            this.CreateBallotForAlice.Name = "CreateBallotForAlice";
            workflowparameterbinding5.ParameterName = "alias";
            workflowparameterbinding5.Value = "Alice";
            this.CreateBallotForAlice.ParameterBindings.Add(workflowparameterbinding5);
            // 
            // WaitForJimResponse
            // 
            this.WaitForJimResponse.Activities.Add(this.WaitForJimApproval);
            this.WaitForJimResponse.Activities.Add(this.WaitForJimRejection);
            this.WaitForJimResponse.Name = "WaitForJimResponse";
            // 
            // CreateBallotForJim
            // 
            this.CreateBallotForJim.CorrelationToken = correlationtoken2;
            this.CreateBallotForJim.InterfaceType = typeof(CommunicationsWorkflow.IVotingServiceCorrelated);
            this.CreateBallotForJim.MethodName = "CreateBallot";
            this.CreateBallotForJim.Name = "CreateBallotForJim";
            workflowparameterbinding6.ParameterName = "alias";
            workflowparameterbinding6.Value = "Jim";
            this.CreateBallotForJim.ParameterBindings.Add(workflowparameterbinding6);
            // 
            // AliceSequence
            // 
            this.AliceSequence.Activities.Add(this.CreateBallotForAlice);
            this.AliceSequence.Activities.Add(this.WaitForAliceResponse);
            this.AliceSequence.Name = "AliceSequence";
            // 
            // JimSequence
            // 
            this.JimSequence.Activities.Add(this.CreateBallotForJim);
            this.JimSequence.Activities.Add(this.WaitForJimResponse);
            this.JimSequence.Name = "JimSequence";
            // 
            // cancellationHandlerActivity1
            // 
            this.cancellationHandlerActivity1.Name = "cancellationHandlerActivity1";
            // 
            // faultHandlersActivity1
            // 
            this.faultHandlersActivity1.Name = "faultHandlersActivity1";
            // 
            // SendBallots
            // 
            this.SendBallots.Activities.Add(this.JimSequence);
            this.SendBallots.Activities.Add(this.AliceSequence);
            this.SendBallots.Name = "SendBallots";
            // 
            // VotingWorkflow
            // 
            this.Activities.Add(this.SendBallots);
            this.Activities.Add(this.faultHandlersActivity1);
            this.Activities.Add(this.cancellationHandlerActivity1);
            this.Name = "VotingWorkflow";
            this.CanModifyActivities = false;

		}

		#endregion

        private EventDrivenActivity WaitForAliceRejection;
        private EventDrivenActivity WaitForAliceApproval;
        private ListenActivity WaitForAliceResponse;
        private CallExternalMethodActivity CreateBallotForAlice;
        private SequenceActivity AliceSequence;
        private SequenceActivity JimSequence;
        private ParallelActivity SendBallots;
        private HandleExternalEventActivity AliceReject;
        private HandleExternalEventActivity AliceApprove;
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
