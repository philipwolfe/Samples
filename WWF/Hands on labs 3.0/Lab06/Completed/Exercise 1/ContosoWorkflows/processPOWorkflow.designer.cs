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

namespace ContosoWorkflows
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
            System.Workflow.ComponentModel.ActivityBind activitybind3 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding3 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind4 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding4 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference1 = new System.Workflow.Activities.Rules.RuleConditionReference();
            this.afterWSNorthwindInvoke = new System.Workflow.Activities.CodeActivity();
            this.invokePOSubmissionWSNorthwind = new System.Workflow.Activities.InvokeWebServiceActivity();
            this.afterWSFabrikamInvoke = new System.Workflow.Activities.CodeActivity();
            this.invokePOSubmissionWSFabrikam = new System.Workflow.Activities.InvokeWebServiceActivity();
            this.Else = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifOrderSmallerThan1000 = new System.Workflow.Activities.IfElseBranchActivity();
            this.checkOrderTotal = new System.Workflow.Activities.IfElseActivity();
            // 
            // afterWSNorthwindInvoke
            // 
            this.afterWSNorthwindInvoke.Name = "afterWSNorthwindInvoke";
            this.afterWSNorthwindInvoke.ExecuteCode += new System.EventHandler(this.afterWSNorthwindInvoke_ExecuteCode);
            // 
            // invokePOSubmissionWSNorthwind
            // 
            this.invokePOSubmissionWSNorthwind.MethodName = "SubmitPO";
            this.invokePOSubmissionWSNorthwind.Name = "invokePOSubmissionWSNorthwind";
            activitybind1.Name = "processPOWorkflow";
            activitybind1.Path = "outgoingPOforNorthwind";
            workflowparameterbinding1.ParameterName = "incomingPO";
            workflowparameterbinding1.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            activitybind2.Name = "processPOWorkflow";
            activitybind2.Path = "POResponsefromNorthwind";
            workflowparameterbinding2.ParameterName = "(ReturnValue)";
            workflowparameterbinding2.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            this.invokePOSubmissionWSNorthwind.ParameterBindings.Add(workflowparameterbinding1);
            this.invokePOSubmissionWSNorthwind.ParameterBindings.Add(workflowparameterbinding2);
            this.invokePOSubmissionWSNorthwind.ProxyClass = typeof(ContosoWorkflows.Northwind.Service);
            this.invokePOSubmissionWSNorthwind.Invoking += new System.EventHandler<System.Workflow.Activities.InvokeWebServiceEventArgs>(this.invokePOSubmissionWSNorthwind_Invoking);
            this.invokePOSubmissionWSNorthwind.Invoked += new System.EventHandler<System.Workflow.Activities.InvokeWebServiceEventArgs>(this.invokePOSubmissionWSNorthwind_Invoked);
            // 
            // afterWSFabrikamInvoke
            // 
            this.afterWSFabrikamInvoke.Name = "afterWSFabrikamInvoke";
            this.afterWSFabrikamInvoke.ExecuteCode += new System.EventHandler(this.afterWSFabrikamInvoke_ExecuteCode);
            // 
            // invokePOSubmissionWSFabrikam
            // 
            this.invokePOSubmissionWSFabrikam.MethodName = "SubmitPO";
            this.invokePOSubmissionWSFabrikam.Name = "invokePOSubmissionWSFabrikam";
            activitybind3.Name = "processPOWorkflow";
            activitybind3.Path = "outgoingPOforFabrikam";
            workflowparameterbinding3.ParameterName = "incomingPO";
            workflowparameterbinding3.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            activitybind4.Name = "processPOWorkflow";
            activitybind4.Path = "POResponsefromFabrikam";
            workflowparameterbinding4.ParameterName = "(ReturnValue)";
            workflowparameterbinding4.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind4)));
            this.invokePOSubmissionWSFabrikam.ParameterBindings.Add(workflowparameterbinding3);
            this.invokePOSubmissionWSFabrikam.ParameterBindings.Add(workflowparameterbinding4);
            this.invokePOSubmissionWSFabrikam.ProxyClass = typeof(ContosoWorkflows.Fabrikam.Service);
            this.invokePOSubmissionWSFabrikam.Invoking += new System.EventHandler<System.Workflow.Activities.InvokeWebServiceEventArgs>(this.invokePOSubmissionWSFabrikam_Invoking);
            this.invokePOSubmissionWSFabrikam.Invoked += new System.EventHandler<System.Workflow.Activities.InvokeWebServiceEventArgs>(this.invokePOSubmissionWSFabrikam_Invoked);
            // 
            // Else
            // 
            this.Else.Activities.Add(this.invokePOSubmissionWSNorthwind);
            this.Else.Activities.Add(this.afterWSNorthwindInvoke);
            this.Else.Name = "Else";
            // 
            // ifOrderSmallerThan1000
            // 
            this.ifOrderSmallerThan1000.Activities.Add(this.invokePOSubmissionWSFabrikam);
            this.ifOrderSmallerThan1000.Activities.Add(this.afterWSFabrikamInvoke);
            ruleconditionreference1.ConditionName = "ifOrderSmallerThan1000";
            this.ifOrderSmallerThan1000.Condition = ruleconditionreference1;
            this.ifOrderSmallerThan1000.Name = "ifOrderSmallerThan1000";
            // 
            // checkOrderTotal
            // 
            this.checkOrderTotal.Activities.Add(this.ifOrderSmallerThan1000);
            this.checkOrderTotal.Activities.Add(this.Else);
            this.checkOrderTotal.Name = "checkOrderTotal";
            // 
            // processPOWorkflow
            // 
            this.Activities.Add(this.checkOrderTotal);
            this.Name = "processPOWorkflow";
            this.CanModifyActivities = false;

		}

		#endregion

        private CodeActivity afterWSNorthwindInvoke;
        private CodeActivity afterWSFabrikamInvoke;
        private InvokeWebServiceActivity invokePOSubmissionWSNorthwind;
        private IfElseBranchActivity Else;
        private IfElseBranchActivity ifOrderSmallerThan1000;
        private IfElseActivity checkOrderTotal;
        private InvokeWebServiceActivity invokePOSubmissionWSFabrikam;















    }
}
