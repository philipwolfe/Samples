//---------------------------------------------------------------------
//  This file is part of the Windows Workflow Foundation Sample Code.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//  This source code is intended only as a supplement to Microsoft
//  Development Tools and/or on-line documentation.  See these other
//  materials for detailed information regarding Microsoft code samples.
// 
//  THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//  PARTICULAR PURPOSE.
//---------------------------------------------------------------------

using System;
using System.Workflow.Activities;

namespace SendDataToStateMachine
{
    partial class Workflow1
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
            this.setStateActivity1 = new System.Workflow.Activities.SetStateActivity();
            this.handleExternalEventActivity1 = new System.Workflow.Activities.HandleExternalEventActivity();
            this.eventDrivenActivity1 = new System.Workflow.Activities.EventDrivenActivity();
            this.stateActivity1 = new System.Workflow.Activities.StateActivity();
            this.Workflow1InitialState = new System.Workflow.Activities.StateActivity();
            // 
            // setStateActivity1
            // 
            this.setStateActivity1.Name = "setStateActivity1";
            this.setStateActivity1.TargetStateName = "stateActivity1";
            // 
            // handleExternalEventActivity1
            // 
            this.handleExternalEventActivity1.EventName = "Completed";
            this.handleExternalEventActivity1.InterfaceType = typeof(SendDataToStateMachine.IMyService);
            this.handleExternalEventActivity1.Name = "handleExternalEventActivity1";
            this.handleExternalEventActivity1.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.CompletedInvoked);
            // 
            // eventDrivenActivity1
            // 
            this.eventDrivenActivity1.Activities.Add(this.handleExternalEventActivity1);
            this.eventDrivenActivity1.Activities.Add(this.setStateActivity1);
            this.eventDrivenActivity1.Name = "eventDrivenActivity1";
            // 
            // stateActivity1
            // 
            this.stateActivity1.Name = "stateActivity1";
            // 
            // Workflow1InitialState
            // 
            this.Workflow1InitialState.Activities.Add(this.eventDrivenActivity1);
            this.Workflow1InitialState.Name = "Workflow1InitialState";
            // 
            // Workflow1
            // 
            this.Activities.Add(this.Workflow1InitialState);
            this.Activities.Add(this.stateActivity1);
            this.CompletedStateName = "stateActivity1";
            this.DynamicUpdateCondition = null;
            this.InitialStateName = "Workflow1InitialState";
            this.Name = "Workflow1";
            this.CanModifyActivities = false;

        }

        #endregion

        private EventDrivenActivity eventDrivenActivity1;
        private HandleExternalEventActivity handleExternalEventActivity1;
        private SetStateActivity setStateActivity1;
        private StateActivity stateActivity1;
        private StateActivity Workflow1InitialState;
    }
}
