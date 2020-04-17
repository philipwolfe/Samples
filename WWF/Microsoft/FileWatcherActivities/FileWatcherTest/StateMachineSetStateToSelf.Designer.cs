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

namespace FileWatcherTest
{
    partial class StateMachineSetStateToSelf
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
            this.StateMachineSetStateToSelfInitialState = new System.Workflow.Activities.StateActivity();
            this.eventDrivenActivity1 = new System.Workflow.Activities.EventDrivenActivity();
            this.Event1 = new FileWatcherActivities.FileSystemEventActivity();
            this.codeActivity1 = new System.Workflow.Activities.CodeActivity();
            this.setStateActivity1 = new System.Workflow.Activities.SetStateActivity();
            // 
            // StateMachineSetStateToSelfInitialState
            // 
            this.StateMachineSetStateToSelfInitialState.Activities.Add(this.eventDrivenActivity1);
            this.StateMachineSetStateToSelfInitialState.Name = "StateMachineSetStateToSelfInitialState";
            // 
            // eventDrivenActivity1
            // 
            this.eventDrivenActivity1.Activities.Add(this.Event1);
            this.eventDrivenActivity1.Activities.Add(this.codeActivity1);
            this.eventDrivenActivity1.Activities.Add(this.setStateActivity1);
            this.eventDrivenActivity1.Name = "eventDrivenActivity1";
            // 
            // Event1
            // 
            this.Event1.EventSubscriptionId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.Event1.IncludeSubdirectories = false;
            this.Event1.Name = "Event1";
            ActivityBind binding = new ActivityBind();
            binding.Path = "Path";
            binding.Name = "StateMachineSetStateToSelf";
            this.Event1.SetBinding(FileWatcherActivities.FileSystemEventActivity.PathProperty, binding);
            this.Event1.FileSystemEventOccurred += new System.EventHandler<FileWatcherActivities.FileSystemEventArgs>(this.FileSystemEventOccurred);
            // 
            // codeActivity1
            // 
            this.codeActivity1.Name = "codeActivity1";
            this.codeActivity1.ExecuteCode += new System.EventHandler(this.codeActivity1_ExecuteCode);
            // 
            // setStateActivity1
            // 
            this.setStateActivity1.Name = "setStateActivity1";
            this.setStateActivity1.TargetStateName = "StateMachineSetStateToSelfInitialState";
            // 
            // StateMachineSetStateToSelf
            // 
            this.Activities.Add(this.StateMachineSetStateToSelfInitialState);
            this.CompletedStateName = null;
            this.DynamicUpdateCondition = null;
            this.InitialStateName = "StateMachineSetStateToSelfInitialState";
            this.Name = "StateMachineSetStateToSelf";
            this.CanModifyActivities = false;

        }

        #endregion

        private SetStateActivity setStateActivity1;
        private CodeActivity codeActivity1;
        private EventDrivenActivity eventDrivenActivity1;
        private FileWatcherActivities.FileSystemEventActivity Event1;
        private StateActivity StateMachineSetStateToSelfInitialState;
    }
}
