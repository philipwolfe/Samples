///
///This sample is provided as is with no warranties implied or granted whatsoever.  
///Use this code at your own risk.  
///
///Matt Milner
///http://www.pluralsight.com/matt/
///
#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;

#endregion

namespace StateTrackingSample
{
    class Program
    {
        static void Main(string[] args)
        {
            using(WorkflowRuntime workflowRuntime = new WorkflowRuntime())
            {
                workflowRuntime.AddService(new ActiveStateTrackngService());

                AutoResetEvent waitHandle = new AutoResetEvent(false);
                workflowRuntime.WorkflowCompleted += delegate(object sender, WorkflowCompletedEventArgs e) {waitHandle.Set();};
                workflowRuntime.WorkflowTerminated += delegate(object sender, WorkflowTerminatedEventArgs e)
                {
                    Console.WriteLine(e.Exception.Message);
                    waitHandle.Set();
                };

                WorkflowInstance instance = workflowRuntime.CreateWorkflow(typeof(StateTrackingSample.Workflow1));
                instance.Start();

                waitHandle.WaitOne();
                Console.WriteLine("Press Enter to close");
                Console.ReadLine();
            }
        }
    }
}
