﻿//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Workflow.Activities;
using System.Workflow.Runtime;

namespace Microsoft.Samples.InteropDemo
{

    public sealed partial class TaskWorkflow 
    {
        #region Designer generated code
   

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCode()]
        private void InitializeComponent()
        {
            this.CanModifyActivities = true;
            CorrelationToken correlationtoken1 = new CorrelationToken();
            CorrelationToken correlationtoken2 = new CorrelationToken();
            this.taskCompleted2 = new TaskCompleted();
            this.createTask2 = new CreateTask();
            this.taskCompleted1 = new TaskCompleted();
            this.createTask1 = new CreateTask();
            this.sequence2 = new SequenceActivity();
            this.sequence1 = new SequenceActivity();
            this.parallel1 = new ParallelActivity();
            // 
            // taskCompleted2
            // 
            correlationtoken1.Name = "c2";
            correlationtoken1.OwnerActivityName = "sequence2";
            this.taskCompleted2.CorrelationToken = correlationtoken1;
            this.taskCompleted2.EventArgs = null;
            this.taskCompleted2.EventName = "TaskCompleted";
            this.taskCompleted2.InterfaceType = typeof(ITaskService);
            this.taskCompleted2.Name = "taskCompleted2";
            this.taskCompleted2.Sender = null;
            this.taskCompleted2.Invoked += new EventHandler<ExternalDataEventArgs>(this.OnTaskCompleted);
            // 
            // createTask2
            // 
            this.createTask2.Assignee = "Kim";
            this.createTask2.CorrelationToken = correlationtoken1;
            this.createTask2.InterfaceType = typeof(ITaskService);
            this.createTask2.MethodName = "CreateTask";
            this.createTask2.Name = "createTask2";
            this.createTask2.TaskId = "002";
            this.createTask2.Text = "task 2";
            // 
            // taskCompleted1
            // 
            correlationtoken2.Name = "c1";
            correlationtoken2.OwnerActivityName = "sequence1";
            this.taskCompleted1.CorrelationToken = correlationtoken2;
            this.taskCompleted1.EventArgs = null;
            this.taskCompleted1.EventName = "TaskCompleted";
            this.taskCompleted1.InterfaceType = typeof(ITaskService);
            this.taskCompleted1.Name = "taskCompleted1";
            this.taskCompleted1.Sender = null;
            this.taskCompleted1.Invoked += new EventHandler<ExternalDataEventArgs>(this.OnTaskCompleted);
            // 
            // createTask1
            // 
            this.createTask1.Assignee = "Joe";
            this.createTask1.CorrelationToken = correlationtoken2;
            this.createTask1.InterfaceType = typeof(ITaskService);
            this.createTask1.MethodName = "CreateTask";
            this.createTask1.Name = "createTask1";
            this.createTask1.TaskId = "001";
            this.createTask1.Text = "task 1";
            // 
            // sequence2
            // 
            this.sequence2.Activities.Add(this.createTask2);
            this.sequence2.Activities.Add(this.taskCompleted2);
            this.sequence2.Name = "sequence2";
            // 
            // sequence1
            // 
            this.sequence1.Activities.Add(this.createTask1);
            this.sequence1.Activities.Add(this.taskCompleted1);
            this.sequence1.Name = "sequence1";
            // 
            // parallel1
            // 
            this.parallel1.Activities.Add(this.sequence1);
            this.parallel1.Activities.Add(this.sequence2);
            this.parallel1.Name = "parallel1";
            // 
            // TaskWorkflow
            // 
            this.Activities.Add(this.parallel1);
            this.Name = "TaskWorkflow";
            this.CanModifyActivities = false;

        }

        #endregion

        private CreateTask createTask1;
        private TaskCompleted taskCompleted1;
        private CreateTask createTask2;
        private TaskCompleted taskCompleted2;
        private ParallelActivity parallel1;
        private SequenceActivity sequence1;
        private SequenceActivity sequence2;

    }
}
