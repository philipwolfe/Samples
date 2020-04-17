//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------
namespace Microsoft.Samples.StopWatchService
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Activities;
    using System.Activities.Statements;
    using System.ServiceModel.Activities;
    using System.ServiceModel.Description;

    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:8081/StopWatchService";

            using (WorkflowServiceHost host = new WorkflowServiceHost(typeof(StopWatchWorkflow), new Uri(baseAddress)))
            {
                host.Description.Behaviors.Add(new ServiceMetadataBehavior() { HttpGetEnabled = true });
                host.AddDefaultEndpoints();

                host.Open();
                Console.WriteLine("StopWatchService waiting at: " + baseAddress);
                Console.WriteLine("Press [ENTER] to exit");
                Console.ReadLine();
                host.Close();
            }
            

        }
    }

}
