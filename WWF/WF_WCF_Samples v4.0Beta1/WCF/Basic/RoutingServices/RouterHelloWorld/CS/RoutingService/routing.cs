
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Routing;

namespace Microsoft.Samples.ServiceModel
{
    public class Router
    {

        // Host the service within this EXE console application.
        public static void Main()
        {
            // Create a ServiceHost for the RoutingService type.
            using (ServiceHost serviceHost =
                new ServiceHost(typeof(RoutingService)))
            {
                //Rename or delete the provided App.config and  
                //uncomment this method call to run a code-based Routing Service
                //ConfigureRouterViaCode(serviceHost);
                
                // Open the ServiceHost to create listeners         
                // and start listening for messages.
                Console.WriteLine("The Routing Service configured, opening....");
                try
                {
                    serviceHost.Open();
                    Console.WriteLine("The Routing Service is now running.");
                    Console.WriteLine("Press <ENTER> to terminate router.");

                    // The service can now be accessed.
                    Console.ReadLine();
                    serviceHost.Close();
                }
                catch (CommunicationException)
                {
                    serviceHost.Abort();
                }
            }
        }

        private static void ConfigureRouterViaCode(ServiceHost serviceHost)
        {
            //This code sets up the Routing Sample via code.  Rename or delete the provided
            //App.config and uncomment this method call to run a code-based Routing Service

            //set up some communication defaults
            //you can change the client address to change the service the router will send messages to
            //changing the router address will change the address at which the router can be reached
            string routerAddress = "http://localhost:8000/routingservice/router";
            string clientAddress = "http://localhost:8000/servicemodelsamples/service";

            //change the router binding to change the binding used to communicate with the router
            //change the client binding to change the binding the Router uses to communicate with the back-end service
            Binding routerBinding = new WSHttpBinding();
            Binding clientBinding = new WSHttpBinding();
            
            //add the endpoint the router will use to recieve messages
            //if you wanted to expose multiple different inbound endpoints you could add additional entries here
            serviceHost.AddServiceEndpoint(typeof(IRequestReplyRouter), routerBinding, routerAddress);


            //create the client endpoint the router will route messages to
            ContractDescription contract = ContractDescription.GetContract(typeof(IRequestReplyRouter));

            //again, if there were multiple different endpoints you wanted to send messages to, you could define their
            //addresses and contracts here.
            ServiceEndpoint client = new ServiceEndpoint(contract, clientBinding, new EndpointAddress(clientAddress));

            //create a new routing behavior
            RoutingBehavior rb = new RoutingBehavior();

            //create the endpoint list that contains the service endpoints we want to route to
            List<ServiceEndpoint> endpointList = new List<ServiceEndpoint>();
            endpointList.Add(client);

            //add a MatchAll filter to the Router's filter table
            //map it to the endpoint list defined earlier
            //when a message matches this filter, it will be sent to the endpoint contained in the list
            //There are many different types of message filter which can be used here.  For example: XPath, EndpointName, and others.
            //Detailed examples of the filter types will be provided in another sample.
            rb.FilterTable.Add(new MatchAllMessageFilter(), endpointList);

            //attach the behavior to the service host
            serviceHost.Description.Behaviors.Add(rb);

            ServiceDebugBehavior sdb = serviceHost.Description.Behaviors.Find<ServiceDebugBehavior>();

            if (sdb != null)
            {
                sdb.IncludeExceptionDetailInFaults = true;
            }

        }
    }
    

}
