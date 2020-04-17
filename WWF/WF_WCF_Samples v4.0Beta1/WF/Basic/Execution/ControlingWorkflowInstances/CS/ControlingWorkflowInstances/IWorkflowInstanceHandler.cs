//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

namespace Microsoft.Samples.WF.WorkflowInstances
{
    using System;
    using System.Activities;

    interface IWorkflowInstanceHandler
    {
        void OnAborted(WorkflowAbortedEventArgs e);

        void OnCompleted(WorkflowCompletedEventArgs e);

        UnhandledExceptionAction OnUnhandledException(WorkflowUnhandledExceptionEventArgs e);

        IdleAction OnIdle(Guid instanceId);

    }
}
