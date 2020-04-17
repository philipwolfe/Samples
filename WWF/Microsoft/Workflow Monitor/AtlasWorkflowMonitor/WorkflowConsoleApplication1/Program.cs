#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;
using System.Workflow.Runtime.Tracking;

#endregion

namespace WorkflowConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            using(WorkflowRuntime workflowRuntime = new WorkflowRuntime())
            {
                SqlTrackingService ts = new SqlTrackingService("server=.;database=WFAtlasTracking;trusted_connection=yes");
                ts.IsTransactional = false;
                workflowRuntime.AddService(ts);
                AutoResetEvent waitHandle = new AutoResetEvent(false);
                workflowRuntime.WorkflowCompleted += delegate(object sender, WorkflowCompletedEventArgs e) {waitHandle.Set();};
                workflowRuntime.WorkflowTerminated += delegate(object sender, WorkflowTerminatedEventArgs e)
                {
                    Console.WriteLine(e.Exception.Message);
                    waitHandle.Set();
                };

                WorkflowInstance instance = workflowRuntime.CreateWorkflow(typeof(WorkflowLibrary1.Workflow1));
                instance.Start();

                waitHandle.WaitOne();
            }
        }
    }
}
