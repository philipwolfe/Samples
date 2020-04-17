//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------
namespace Microsoft.Samples.DurableDelay
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Activities;
    using System.ServiceModel.Activities.Description;
    using System.ServiceModel.Description;
    using System.ServiceModel.Persistence;
    using System.Xml.Linq;

    class Client //This code contains the Delay Timer Service Host
    {
        static void Main()
        {            
            System.ServiceModel.Activities.WorkflowServiceHost myServiceHost = new System.ServiceModel.Activities.WorkflowServiceHost(new Sequence1(), new Uri("http://localhost:8080/Client"));

            //Set up connection with Timer Service Host
            TimerExpiredNotificationEndpoint myTimerNotificationEndpoint = new TimerExpiredNotificationEndpoint()
            {
                Address = new EndpointAddress(new Uri("net.pipe://localhost/Client/TimerNotificationEndPoint")),
                TimerServiceUri = new Uri("http://localhost:8080/TimerService/TimerServiceEndPoint"),
                TimerServiceBinding = new BasicHttpBinding()
            };
            myServiceHost.AddServiceEndpoint(myTimerNotificationEndpoint);

            //Set up an endpoint for the receive activity to communicate with the proxy          
            myServiceHost.AddDefaultEndpoints();
                
           //Determines how long will the delay be store in memory before being persisted to the database
            UnloadInstanceBehavior unloadInstanceBehavior = new UnloadInstanceBehavior(TimeSpan.FromSeconds(2));
            myServiceHost.Description.Behaviors.Add(unloadInstanceBehavior);

            //Set up SQL persistence provider            
            string myConnectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=DefaultSampleStore;Integrated Security=True;Asynchronous Processing=True";
            SqlPersistenceProviderFactory myPersistenceProviderFactory = new SqlPersistenceProviderFactory(myConnectionString, true, true, TimeSpan.FromMinutes(1));
            PersistenceProviderBehavior myPersistenceProviderBehavior = new PersistenceProviderBehavior(myPersistenceProviderFactory);
            myServiceHost.Description.Behaviors.Add(myPersistenceProviderBehavior);

            myServiceHost.Open();
            Console.WriteLine("Client started:");

            //Sending a message to create an instance of the workflow
            IWorkflow proxy = ChannelFactory<IWorkflow>.CreateChannel(new BasicHttpBinding(), new EndpointAddress("http://localhost:8080/Client/IWorkflow"));
            proxy.Start();
                        
            Console.ReadLine();
            myServiceHost.Close(); 
        }
    }
}
