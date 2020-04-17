//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Samples.WF.ManagementEndpoint
{
    using System;

    using System.ServiceModel;

    using System.ServiceModel.Activities;

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Client starting...");

            IWorkflowControlService client = new ChannelFactory<IWorkflowControlService>(new BasicHttpBinding(), "http://localhost/DataflowControl.xaml").CreateChannel(); 

            // Start a new instance of the workflow
            client.Run(client.Create(null));

            Console.WriteLine("Client exiting...");
        }
    }
}
