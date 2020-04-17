//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

namespace Microsoft.Samples.WF.WorkflowInstances
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public interface IHostView
    {
        bool UsePersistence { get; }

        bool UseActivityTracking { get; }

        TextWriter OutputWriter { get; }

        TextWriter ErrorWriter { get; }

        TextWriter CreateInstanceWriter();

        void Initialize(WorkflowInstanceManager manager);

        //rebuild the view of instances and refresh current view state
        void UpdateInstances(List<WorkflowInstanceInfo> instances);

        void SelectInstance(Guid id);

        void Dispatch(Action work);
    }
}
