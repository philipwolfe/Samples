//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.IO;
using System.ServiceModel;
using System.Activities;
using System.ServiceModel.Activities;
using System.Xaml;
using System.ServiceModel.Activities.Description;
using System.Collections.Generic;

namespace Microsoft.Samples.WF.ManagementEndpoint
{
    class Program
    {
        static void Main()
        {
            // Same workflow as Dataflow sample
            WorkflowServiceHost host = new WorkflowServiceHost("Dataflow.xaml",
                new Uri("http://localhost/Dataflow.xaml"));
            
            WorkflowControlEndpoint localEndpoint = new WorkflowControlEndpoint();

            WorkflowControlEndpoint publicEndpoint = new WorkflowControlEndpoint(
                new BasicHttpBinding(),
                new EndpointAddress(new Uri("http://localhost/DataflowControl.xaml")));
            
            host.AddServiceEndpoint(localEndpoint);
            host.AddServiceEndpoint(publicEndpoint);

            host.Open();

            Console.WriteLine("Host open...");

            IWorkflowControlService client = new ChannelFactory<IWorkflowControlService>(localEndpoint.Binding, localEndpoint.Address).CreateChannel();

            // Start a new instance of the workflow
            client.Run(client.Create(null));

            Console.WriteLine("Hit any key to exit Host...");
            Console.ReadLine();
        }
    }    
}
