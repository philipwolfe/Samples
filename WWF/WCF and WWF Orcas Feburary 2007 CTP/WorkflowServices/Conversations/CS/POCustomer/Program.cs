#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;
using System.ServiceModel;


#endregion

namespace Microsoft.NetFx35.Silver.Samples
{
    class Program
    {
        static void Main(string[] args)
        {

            WorkflowServiceHost svcHost = new WorkflowServiceHost(typeof(POCustomer));
            WorkflowRuntime wr = svcHost.WorkflowRuntime;
            wr.AddService(new ChannelManagerService());
            svcHost.Open();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Press enter to send the order");
            Console.ReadLine();
            WorkflowInstance wi = wr.CreateWorkflow(typeof(POCustomer));
            wi.Start();
            Console.WriteLine("Service Started, Please Press <Enter> to exit");
            Console.ReadLine();
        }
    }
}