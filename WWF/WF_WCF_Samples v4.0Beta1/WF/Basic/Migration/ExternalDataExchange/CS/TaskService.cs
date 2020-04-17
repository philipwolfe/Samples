//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Samples.Interop
{
    using System;
    using System.Workflow.Activities;
    using System.Workflow.Runtime;
    using System.Threading;

    public class TaskService : ITaskService
    {
        public event EventHandler<TaskEventArgs> TaskCompleted;

        public void CreateTask(string taskId, string assignee, string text)
        {
            Console.WriteLine("task " + taskId + " created for " + assignee);
            ThreadPool.QueueUserWorkItem(RaiseEvent, new TaskEventArgs(WorkflowEnvironment.WorkflowInstanceId, taskId, assignee, text));
        }

        public void RaiseEvent(object state)
        {
            TaskEventArgs args = state as TaskEventArgs;
            EventHandler<TaskEventArgs> taskCompleted = this.TaskCompleted;
            if (taskCompleted != null)
            {
                taskCompleted(null, args);
            }
        }
    }
}
