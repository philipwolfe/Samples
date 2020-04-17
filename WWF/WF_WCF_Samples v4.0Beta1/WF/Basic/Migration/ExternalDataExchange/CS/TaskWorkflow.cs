//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Samples.Interop
{
    using System;
    using System.ComponentModel;
    using System.Workflow.Activities;

    public sealed partial class TaskWorkflow : SequentialWorkflowActivity
    {
        public TaskWorkflow()
        {
            InitializeComponent();
        }

        private void OnTaskCompleted(object sender, EventArgs e)
        {
            TaskEventArgs eventArgs = e as TaskEventArgs;
            Console.WriteLine("task {0} is done", eventArgs.Id);
        }
    }
}
