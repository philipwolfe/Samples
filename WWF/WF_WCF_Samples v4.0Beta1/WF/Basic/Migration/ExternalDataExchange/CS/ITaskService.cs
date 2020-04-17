//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Samples.Interop
{
    using System;
    using System.Workflow.Activities;

    [ExternalDataExchange]
    [CorrelationParameter("taskId")]
    public interface ITaskService
    {
        [CorrelationInitializer]
        void CreateTask(string taskId, string assignee, string text);

        [CorrelationAlias("taskId", "e.Id")]
        event EventHandler<TaskEventArgs> TaskCompleted;
    }
}
