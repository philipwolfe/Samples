#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;
using System.ServiceModel;


#endregion

namespace Microsoft.WorkflowServices.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkflowServiceHost host = new WorkflowServiceHost(typeof(CustomerWorkflow));
            host.WorkflowRuntime.WorkflowTerminated += delegate(object sender, WorkflowTerminatedEventArgs e) { Console.WriteLine("WorkflowTerminated: " + e.Exception.Message); };
            host.WorkflowRuntime.WorkflowCompleted += delegate(object sender, WorkflowCompletedEventArgs e) { Console.WriteLine("WorkflowCompleted."); };
            host.WorkflowRuntime.AddService(new ChannelManagerService());
            host.Open();

            Console.WriteLine("Press <enter> to submit order.");
            Console.ReadLine();

            WorkflowInstance workflow = host.WorkflowRuntime.CreateWorkflow(typeof(CustomerWorkflow));
            workflow.Start();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Press <enter> to exit");
            Console.ResetColor();
            Console.ReadLine();
            host.Close();
        }
    }
}