//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Samples.BlobMessageEncoder
{
    using System;
    using System.ServiceModel;

    class Server
    {
        public static void Main()
        {
            Console.WriteLine("Testing image upload and download using BlobHttpBinding");
            using (ServiceHost host = new ServiceHost(new FileService()))
            {
                host.Open();
                Console.WriteLine("Service started at: " + host.ChannelDispatchers[0].Listener.Uri.AbsoluteUri);
                Console.WriteLine("Press <ENTER> to terminate service");
                Console.ReadLine();
            }
        }
    }
}
