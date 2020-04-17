//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

namespace Microsoft.Samples.WF.WorkflowInstances
{
    using System;
    using System.Windows;

    class Program
    {
        [STAThread]
        static void Main()
        {
            HostView hostView = new HostView();
            WorkflowInstanceManager manager = new WorkflowInstanceManager(hostView);
            Application application = new Application();
            application.Run(hostView);
        }
    }
}
