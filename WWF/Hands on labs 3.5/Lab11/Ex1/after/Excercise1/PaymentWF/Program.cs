using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;
using System.ServiceModel;
namespace PaymentWF
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WorkflowServiceHost host = new
   WorkflowServiceHost(typeof(PaymentWF.Checks)))
            {
                host.Open();
                Console.WriteLine("Service is listening.");
                Console.WriteLine("Press any key to close the service.");
                Console.ReadKey();
            }

        }
    }
}
