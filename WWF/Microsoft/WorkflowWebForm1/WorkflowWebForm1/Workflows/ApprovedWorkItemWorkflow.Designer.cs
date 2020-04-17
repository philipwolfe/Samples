//--------------------------------------------------------------------------------
// This file is a "Sample" as from Windows Workflow Foundation
// Samples
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

namespace Workflows
{
	partial class ApprovedWorkItemWorkflow
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
			System.Workflow.ComponentModel.ActivityBind activitybind3 = new System.Workflow.ComponentModel.ActivityBind();
			this.SaveDeclinedWorkItems = new Workflows.SaveWorkItems();
			this.SetWorkItemsToDeclined = new System.Workflow.Activities.CodeActivity();
			this.EscalateTimer = new System.Workflow.Activities.DelayActivity();
			this.ManagerApproval = new Workflows.UserActivity();
			this.Escalate = new System.Workflow.Activities.EventDrivenActivity();
			this.Approve = new System.Workflow.Activities.EventDrivenActivity();
			this.faultHandlersActivity1 = new System.Workflow.ComponentModel.FaultHandlersActivity();
			this.cancellationHandlerActivity1 = new System.Workflow.ComponentModel.CancellationHandlerActivity();
			this.WaitForResolution = new Workflows.UserActivity();
			this.ApprovalForWorkItems = new System.Workflow.Activities.ListenActivity();
			this.EnterApprovalRequest = new Workflows.UserActivity();
			// 
			// SaveDeclinedWorkItems
			// 
			this.SaveDeclinedWorkItems.Name = "SaveDeclinedWorkItems";
			this.SaveDeclinedWorkItems.WorkItems = null;
			// 
			// SetWorkItemsToDeclined
			// 
			this.SetWorkItemsToDeclined.Name = "SetWorkItemsToDeclined";
			this.SetWorkItemsToDeclined.ExecuteCode += new System.EventHandler(this.SetWorkItemsToDeclined_ExecuteCode);
			// 
			// EscalateTimer
			// 
			this.EscalateTimer.Name = "EscalateTimer";
			this.EscalateTimer.TimeoutDuration = System.TimeSpan.Parse("00:05:00");
			// 
			// ManagerApproval
			// 
			this.ManagerApproval.ActivityType = Workflows.UserActivityType.ManagerApproval;
			activitybind1.Name = "ApprovedWorkItemWorkflow";
			activitybind1.Path = "WorkItems";
			this.ManagerApproval.Description = "Work Item Request for Approval";
			this.ManagerApproval.Name = "ManagerApproval";
			this.ManagerApproval.RequiredRole = Workflows.UserRole.Manager;
			this.ManagerApproval.SetBinding(Workflows.UserActivity.DataSetProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
			// 
			// Escalate
			// 
			this.Escalate.Activities.Add(this.EscalateTimer);
			this.Escalate.Activities.Add(this.SetWorkItemsToDeclined);
			this.Escalate.Activities.Add(this.SaveDeclinedWorkItems);
			this.Escalate.Name = "Escalate";
			// 
			// Approve
			// 
			this.Approve.Activities.Add(this.ManagerApproval);
			this.Approve.Name = "Approve";
			// 
			// faultHandlersActivity1
			// 
			this.faultHandlersActivity1.Name = "faultHandlersActivity1";
			// 
			// cancellationHandlerActivity1
			// 
			this.cancellationHandlerActivity1.Name = "cancellationHandlerActivity1";
			// 
			// WaitForResolution
			// 
			this.WaitForResolution.ActivityType = Workflows.UserActivityType.EnterResolution;
			activitybind2.Name = "ApprovedWorkItemWorkflow";
			activitybind2.Path = "WorkItems";
			this.WaitForResolution.Description = "Work Item Awaiting Resolution";
			this.WaitForResolution.Name = "WaitForResolution";
			this.WaitForResolution.RequiredRole = Workflows.UserRole.EnterResolution;
			this.WaitForResolution.SetBinding(Workflows.UserActivity.DataSetProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
			// 
			// ApprovalForWorkItems
			// 
			this.ApprovalForWorkItems.Activities.Add(this.Approve);
			this.ApprovalForWorkItems.Activities.Add(this.Escalate);
			this.ApprovalForWorkItems.Name = "ApprovalForWorkItems";
			// 
			// EnterApprovalRequest
			// 
			this.EnterApprovalRequest.ActivityType = Workflows.UserActivityType.EnterApprovalRequest;
			activitybind3.Name = "ApprovedWorkItemWorkflow";
			activitybind3.Path = "WorkItems";
			this.EnterApprovalRequest.Description = "Work Item Approval Request";
			this.EnterApprovalRequest.Name = "EnterApprovalRequest";
			this.EnterApprovalRequest.RequiredRole = Workflows.UserRole.RequestApproval;
			this.EnterApprovalRequest.SetBinding(Workflows.UserActivity.DataSetProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
			// 
			// ApprovedWorkItemWorkflow
			// 
			this.Activities.Add(this.EnterApprovalRequest);
			this.Activities.Add(this.ApprovalForWorkItems);
			this.Activities.Add(this.WaitForResolution);
			this.Activities.Add(this.cancellationHandlerActivity1);
			this.Activities.Add(this.faultHandlersActivity1);
			this.Name = "ApprovedWorkItemWorkflow";
			this.CanModifyActivities = false;

		}

		#endregion

		private FaultHandlersActivity faultHandlersActivity1;
		private CancellationHandlerActivity cancellationHandlerActivity1;
		private SaveWorkItems SaveDeclinedWorkItems;
		private UserActivity WaitForResolution;
		private DelayActivity EscalateTimer;
		private UserActivity ManagerApproval;
		private CodeActivity SetWorkItemsToDeclined;
		private UserActivity EnterApprovalRequest;
		private EventDrivenActivity Escalate;
		private EventDrivenActivity Approve;
		private ListenActivity ApprovalForWorkItems;


























	}
}
