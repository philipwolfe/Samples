using System;
using System.ServiceModel;
using System.Workflow.Runtime;

namespace Microsoft.WorkflowServices.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkflowServiceHost workflowHost = new WorkflowServiceHost(typeof(Microsoft.WorkflowServices.Samples.SequentialCalculatorService));
            workflowHost.WorkflowRuntime.WorkflowTerminated += delegate(object sender, WorkflowTerminatedEventArgs e) { Console.WriteLine("WorkflowTerminated: " + e.Exception.Message); };
            workflowHost.WorkflowRuntime.WorkflowCompleted += delegate(object sender, WorkflowCompletedEventArgs e) { Console.WriteLine("WorkflowCompleted: " + e.WorkflowInstance.InstanceId.ToString()); };
            workflowHost.Open();
            Console.WriteLine("SequentialCalculatorService is ready.");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Press <enter> to exit.");
            Console.ResetColor();
            Console.ReadLine();
            workflowHost.Close();
        }
    }
}
