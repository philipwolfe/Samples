//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

namespace Microsoft.Samples.Rules.Client
{
    using System;
    using System.Activities;
    using System.Threading;

    class Program
    {
        static void Main(string[] args)
        {
            AutoResetEvent syncEvent = new AutoResetEvent(false);

            WorkflowInstance myInstance = new WorkflowInstance(new Sequence1());
            myInstance.OnCompleted = delegate(WorkflowCompletedEventArgs e) { syncEvent.Set(); };
            myInstance.Run();

            syncEvent.WaitOne();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
