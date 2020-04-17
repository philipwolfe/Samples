//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Samples.Workflow.Expressions
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Activities;
    using System.Activities.Statements;

    class Program
    {
        static void Main(string[] args)
        {
            
            AutoResetEvent syncEvent = new AutoResetEvent(false);

            WorkflowInstance myInstance = new WorkflowInstance(new SalaryCalculation());
            myInstance.OnCompleted = delegate(WorkflowCompletedEventArgs e) { syncEvent.Set(); };
            myInstance.OnUnhandledException = delegate(WorkflowUnhandledExceptionEventArgs e)
            {
                Console.WriteLine(e.UnhandledException.ToString());
                return UnhandledExceptionAction.Terminate;
            };
            myInstance.OnAborted = delegate(WorkflowAbortedEventArgs e)
            {
                Console.WriteLine(e.Reason);
                syncEvent.Set();
            };

            Console.WriteLine("Workflow is starting...");
            myInstance.Run();

            syncEvent.WaitOne();

            Console.WriteLine("Workflow completed. Press ENTER to exit...");
            Console.ReadLine();
        }
    }
}
