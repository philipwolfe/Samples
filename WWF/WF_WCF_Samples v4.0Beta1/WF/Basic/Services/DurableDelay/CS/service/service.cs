//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------
using System;
using System.ServiceModel;
using System.ServiceModel.Activities;

namespace Microsoft.Samples.DurableDelay
{
    class Service //This code contains the Delay Workflow Service Host
    {  
        static void Main()
        {
            string myConnectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=DefaultSampleStore;Integrated Security=True;Asynchronous Processing=True";
            TimerService myTimerService = new TimerService(myConnectionString);
            
            string serviceBaseAddress = "http://localhost:8080/TimerService";
            ServiceHost myServiceHost = new ServiceHost(myTimerService, new Uri(serviceBaseAddress));
            myServiceHost.AddServiceEndpoint(typeof(ITimerService), new BasicHttpBinding(), serviceBaseAddress + "/TimerServiceEndPoint");

            myServiceHost.Open();
            Console.WriteLine("Service started:");
            Console.WriteLine("Press <ENTER> to terminate service.");
            Console.ReadLine();            
            myServiceHost.Close();
        }
    }
}
