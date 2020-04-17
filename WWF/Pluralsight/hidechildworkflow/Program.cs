#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;
using CallWorkflowActivityLibrary;

#endregion

namespace HideChildWorkflow
{
    class Program
    {
        static void Main(string[] args)
        {
            using(WorkflowRuntime workflowRuntime = new WorkflowRuntime())
            {
                SqlWorkflowPersistenceService ps = new SqlWorkflowPersistenceService("server=.;database=CallWorkflowPersistence;trusted_connection=yes", true, new TimeSpan(0, 20, 0), new TimeSpan(0, 0, 15));
                workflowRuntime.AddService(ps);
                workflowRuntime.AddService(new CallWorkflowService());
                workflowRuntime.AddService(new CallWorkflowWorkflowLoaderService());

                AutoResetEvent waitHandle = new AutoResetEvent(false);
                Dictionary<string, object> p = new Dictionary<string, object>();
                p.Add("CalledWorkflowInProperty", "Data to pass to called workflow");
                WorkflowInstance instance = workflowRuntime.CreateWorkflow(typeof(HideChildWorkflow.Workflow1));
                instance.Start();
                workflowRuntime.WorkflowCompleted += delegate(object sender, WorkflowCompletedEventArgs e) { 
                    if(e.WorkflowInstance.InstanceId==instance.InstanceId)
                        waitHandle.Set(); };
                workflowRuntime.WorkflowTerminated += delegate(object sender, WorkflowTerminatedEventArgs e)
                {
                    if (e.WorkflowInstance.InstanceId == instance.InstanceId)
                    {
                        Console.WriteLine("Workflow Terminated {0}",e.Exception.Message);
                        waitHandle.Set();
                    }
                };
                waitHandle.WaitOne();
            }
        }
    }
}
