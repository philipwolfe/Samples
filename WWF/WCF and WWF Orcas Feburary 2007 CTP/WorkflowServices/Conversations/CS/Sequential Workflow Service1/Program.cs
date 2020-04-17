#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;
using System.ServiceModel;


#endregion

namespace Sequential_Workflow_Service1
{
    class Program
    {
        static void Main(string[] args)
        {

            WorkflowServiceHost svcHost = new WorkflowServiceHost((typeof(Workflow1));
            svcHost.Open();

            Console.WriteLine("Service Started, Please Press <Enter> to exit");
            Console.ReadLine();
        }
    }
}
