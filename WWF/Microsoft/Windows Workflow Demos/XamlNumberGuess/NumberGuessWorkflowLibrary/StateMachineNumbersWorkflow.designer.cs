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

namespace NumberGuessWorkflowLibrary
{
    partial class StateMachineNumbersWorkflow
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
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference1 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference2 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding1 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding2 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            this.setStateActivity3 = new System.Workflow.Activities.SetStateActivity();
            this.codeActivity4 = new System.Workflow.Activities.CodeActivity();
            this.setStateActivity2 = new System.Workflow.Activities.SetStateActivity();
            this.codeActivity3 = new System.Workflow.Activities.CodeActivity();
            this.setStateActivity1 = new System.Workflow.Activities.SetStateActivity();
            this.codeActivity2 = new System.Workflow.Activities.CodeActivity();
            this.ifElseBranchActivity3 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity2 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity1 = new System.Workflow.Activities.IfElseBranchActivity();
            this.setStateActivity4 = new System.Workflow.Activities.SetStateActivity();
            this.callExternalMethodActivity2 = new System.Workflow.Activities.CallExternalMethodActivity();
            this.codeActivity1 = new System.Workflow.Activities.CodeActivity();
            this.callExternalMethodActivity1 = new System.Workflow.Activities.CallExternalMethodActivity();
            this.ifElseActivity1 = new System.Workflow.Activities.IfElseActivity();
            this.handleExternalEventActivity1 = new System.Workflow.Activities.HandleExternalEventActivity();
            this.stateInitializationActivity1 = new System.Workflow.Activities.StateInitializationActivity();
            this.eventDrivenActivity1 = new System.Workflow.Activities.EventDrivenActivity();
            this.StartingState = new System.Workflow.Activities.StateActivity();
            this.FinalState = new System.Workflow.Activities.StateActivity();
            this.GameState = new System.Workflow.Activities.StateActivity();
            // 
            // setStateActivity3
            // 
            this.setStateActivity3.Name = "setStateActivity3";
            this.setStateActivity3.TargetStateName = "FinalState";
            // 
            // codeActivity4
            // 
            this.codeActivity4.Name = "codeActivity4";
            this.codeActivity4.ExecuteCode += new System.EventHandler(this.codeActivity4_ExecuteCode);
            // 
            // setStateActivity2
            // 
            this.setStateActivity2.Name = "setStateActivity2";
            this.setStateActivity2.TargetStateName = "GameState";
            // 
            // codeActivity3
            // 
            this.codeActivity3.Name = "codeActivity3";
            this.codeActivity3.ExecuteCode += new System.EventHandler(this.codeActivity3_ExecuteCode);
            // 
            // setStateActivity1
            // 
            this.setStateActivity1.Name = "setStateActivity1";
            this.setStateActivity1.TargetStateName = "GameState";
            // 
            // codeActivity2
            // 
            this.codeActivity2.Name = "codeActivity2";
            this.codeActivity2.ExecuteCode += new System.EventHandler(this.codeActivity2_ExecuteCode);
            // 
            // ifElseBranchActivity3
            // 
            this.ifElseBranchActivity3.Activities.Add(this.codeActivity4);
            this.ifElseBranchActivity3.Activities.Add(this.setStateActivity3);
            this.ifElseBranchActivity3.Name = "ifElseBranchActivity3";
            // 
            // ifElseBranchActivity2
            // 
            this.ifElseBranchActivity2.Activities.Add(this.codeActivity3);
            this.ifElseBranchActivity2.Activities.Add(this.setStateActivity2);
            ruleconditionreference1.ConditionName = "TooHighCondition";
            this.ifElseBranchActivity2.Condition = ruleconditionreference1;
            this.ifElseBranchActivity2.Name = "ifElseBranchActivity2";
            // 
            // ifElseBranchActivity1
            // 
            this.ifElseBranchActivity1.Activities.Add(this.codeActivity2);
            this.ifElseBranchActivity1.Activities.Add(this.setStateActivity1);
            ruleconditionreference2.ConditionName = "TooLowCondition";
            this.ifElseBranchActivity1.Condition = ruleconditionreference2;
            this.ifElseBranchActivity1.Name = "ifElseBranchActivity1";
            // 
            // setStateActivity4
            // 
            this.setStateActivity4.Name = "setStateActivity4";
            this.setStateActivity4.TargetStateName = "GameState";
            // 
            // callExternalMethodActivity2
            // 
            this.callExternalMethodActivity2.InterfaceType = typeof(NumberGuessWorkflowLibrary.ILocalService);
            this.callExternalMethodActivity2.MethodName = "SetMessage";
            this.callExternalMethodActivity2.Name = "callExternalMethodActivity2";
            activitybind1.Name = "Workflow2";
            activitybind1.Path = "Msg";
            workflowparameterbinding1.ParameterName = "msg";
            workflowparameterbinding1.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            this.callExternalMethodActivity2.ParameterBindings.Add(workflowparameterbinding1);
            this.callExternalMethodActivity2.MethodInvoking += new System.EventHandler(this.SetInitialMessage);
            // 
            // codeActivity1
            // 
            this.codeActivity1.Name = "codeActivity1";
            this.codeActivity1.ExecuteCode += new System.EventHandler(this.GetStarted);
            // 
            // callExternalMethodActivity1
            // 
            this.callExternalMethodActivity1.InterfaceType = typeof(NumberGuessWorkflowLibrary.ILocalService);
            this.callExternalMethodActivity1.MethodName = "SetMessage";
            this.callExternalMethodActivity1.Name = "callExternalMethodActivity1";
            activitybind2.Name = "Workflow2";
            activitybind2.Path = "Msg";
            workflowparameterbinding2.ParameterName = "msg";
            workflowparameterbinding2.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            this.callExternalMethodActivity1.ParameterBindings.Add(workflowparameterbinding2);
            this.callExternalMethodActivity1.MethodInvoking += new System.EventHandler(this.SendingMessage);
            // 
            // ifElseActivity1
            // 
            this.ifElseActivity1.Activities.Add(this.ifElseBranchActivity1);
            this.ifElseActivity1.Activities.Add(this.ifElseBranchActivity2);
            this.ifElseActivity1.Activities.Add(this.ifElseBranchActivity3);
            this.ifElseActivity1.Name = "ifElseActivity1";
            // 
            // handleExternalEventActivity1
            // 
            this.handleExternalEventActivity1.EventName = "GuessEntered";
            this.handleExternalEventActivity1.InterfaceType = typeof(NumberGuessWorkflowLibrary.ILocalService);
            this.handleExternalEventActivity1.Name = "handleExternalEventActivity1";
            this.handleExternalEventActivity1.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.GuessEnteredInvoked);
            // 
            // stateInitializationActivity1
            // 
            this.stateInitializationActivity1.Activities.Add(this.codeActivity1);
            this.stateInitializationActivity1.Activities.Add(this.callExternalMethodActivity2);
            this.stateInitializationActivity1.Activities.Add(this.setStateActivity4);
            this.stateInitializationActivity1.Name = "stateInitializationActivity1";
            // 
            // eventDrivenActivity1
            // 
            this.eventDrivenActivity1.Activities.Add(this.handleExternalEventActivity1);
            this.eventDrivenActivity1.Activities.Add(this.ifElseActivity1);
            this.eventDrivenActivity1.Activities.Add(this.callExternalMethodActivity1);
            this.eventDrivenActivity1.Name = "eventDrivenActivity1";
            // 
            // StartingState
            // 
            this.StartingState.Activities.Add(this.stateInitializationActivity1);
            this.StartingState.Name = "StartingState";
            // 
            // FinalState
            // 
            this.FinalState.Name = "FinalState";
            // 
            // GameState
            // 
            this.GameState.Activities.Add(this.eventDrivenActivity1);
            this.GameState.Name = "GameState";
            // 
            // Workflow2
            // 
            this.Activities.Add(this.GameState);
            this.Activities.Add(this.FinalState);
            this.Activities.Add(this.StartingState);
            this.CompletedStateName = "FinalState";
            this.DynamicUpdateCondition = null;
            this.InitialStateName = "StartingState";
            this.Name = "Workflow2";
            this.CanModifyActivities = false;

        }

        #endregion

        private CallExternalMethodActivity callExternalMethodActivity2;
        private SetStateActivity setStateActivity4;
        private StateActivity StartingState;
        private SetStateActivity setStateActivity3;
        private SetStateActivity setStateActivity2;
        private SetStateActivity setStateActivity1;
        private StateActivity FinalState;
        private CallExternalMethodActivity callExternalMethodActivity1;
        private CodeActivity codeActivity4;
        private CodeActivity codeActivity3;
        private CodeActivity codeActivity2;
        private IfElseBranchActivity ifElseBranchActivity3;
        private IfElseBranchActivity ifElseBranchActivity2;
        private IfElseBranchActivity ifElseBranchActivity1;
        private IfElseActivity ifElseActivity1;
        private HandleExternalEventActivity handleExternalEventActivity1;
        private EventDrivenActivity eventDrivenActivity1;
        private CodeActivity codeActivity1;
        private StateInitializationActivity stateInitializationActivity1;
        private StateActivity GameState;




















    }
}
