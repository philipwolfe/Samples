namespace Microsoft.Samples.TestInteropInDesigner
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

            WorkflowInstance myInstance = new WorkflowInstance(new Sequence1());
            myInstance.OnCompleted = delegate(WorkflowCompletedEventArgs e) { syncEvent.Set(); };
            myInstance.Run();

            syncEvent.WaitOne();

            // wait for user input
            Console.WriteLine("\nPress any key to exit");
            Console.ReadKey();

        }
    }
}
