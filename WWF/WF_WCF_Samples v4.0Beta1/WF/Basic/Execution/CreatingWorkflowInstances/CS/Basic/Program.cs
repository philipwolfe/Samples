//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Samples.WF.WorkflowInstances
{
    using System;

    using System.Threading;

    using System.Activities;

    using System.Activities.Statements;

    class Program
    {
        static WorkflowElement BuildTestWorkflow()
        {
            return new Sequence()
            {
                Activities =
                {
                    new WriteLine() { Text = "one" },
                    new WriteLine() { Text = "two" },
                    new WriteLine() { Text = "buckle my shoe" },
                }
            };
        }

        static void Main()
        {
            // This is how you run a workflow instance synchronously
            WorkflowElement activity = BuildTestWorkflow();
            WorkflowInvoker.Invoke(activity);

            // This is how you run a workflow instance asynchronously,
            // and can receive an event when it completes
            ManualResetEvent resetEvent = new ManualResetEvent(false);
            WorkflowInstance instance = new WorkflowInstance(BuildTestWorkflow());

            instance.OnCompleted = delegate(WorkflowCompletedEventArgs e)
            {
                Console.WriteLine("workflow instance completed, Id = " + instance.Id);
                resetEvent.Set();
            };

            instance.Run();
            resetEvent.WaitOne();

            Console.ReadLine();
        }
    }
}
