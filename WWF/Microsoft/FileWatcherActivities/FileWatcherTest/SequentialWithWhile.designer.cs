//---------------------------------------------------------------------
//  This file is part of the WindowsWorkflow.NET web site samples.
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
using FileWatcherActivities;

namespace FileWatcherTest
{
    public sealed partial class SequentialWithWhile
	{
		#region Designer generated code
		
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.CanModifyActivities = true;
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding1 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.Activities.CodeCondition codecondition1 = new System.Workflow.Activities.CodeCondition();
            this.invokeWorkflowActivity1 = new System.Workflow.Activities.InvokeWorkflowActivity();
            this.whileActivity1 = new System.Workflow.Activities.WhileActivity();
            this.Event1 = new FileWatcherActivities.FileSystemEventActivity();
            // 
            // invokeWorkflowActivity1
            // 
            this.invokeWorkflowActivity1.Name = "invokeWorkflowActivity1";
            activitybind1.Name = "SequentialWithWhile";
            activitybind1.Path = "path";
            workflowparameterbinding1.ParameterName = "Path";
            workflowparameterbinding1.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            this.invokeWorkflowActivity1.ParameterBindings.Add(workflowparameterbinding1);
            this.invokeWorkflowActivity1.TargetWorkflow = typeof(FileWatcherTest.StateMachineSetStateToSelf);
            this.invokeWorkflowActivity1.Invoking += new System.EventHandler(this.Before_Invoking);
            // 
            // whileActivity1
            // 
            this.whileActivity1.Activities.Add(this.Event1);
            codecondition1.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.AlwaysRun);
            this.whileActivity1.Condition = codecondition1;
            this.whileActivity1.Name = "whileActivity1";
            // 
            // Event1
            // 
            this.Event1.EventSubscriptionId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.Event1.IncludeSubdirectories = false;
            this.Event1.Name = "Event1";
            this.Event1.Path = "C:\\temp1";
            this.Event1.FileSystemEventOccurred += new System.EventHandler<FileWatcherActivities.FileSystemEventArgs>(this.FileSystemEventOccurred);
            // 
            // SequentialWithWhile
            // 
            this.Activities.Add(this.invokeWorkflowActivity1);
            this.Activities.Add(this.whileActivity1);
            this.Name = "SequentialWithWhile";
            this.CanModifyActivities = false;

		}

		#endregion

        private InvokeWorkflowActivity invokeWorkflowActivity1;
        private FileSystemEventActivity Event1;
        private WhileActivity whileActivity1;


    }
}
