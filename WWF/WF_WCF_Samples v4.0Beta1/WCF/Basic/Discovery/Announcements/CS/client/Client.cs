//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Samples.Discovery
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Discovery;

    class Client
    {
        public static void Main()
        {
            // Create an AnnouncementService instance
            AnnouncementService announcementService = new AnnouncementService();

            // Subscribe the announcement events
            announcementService.OnlineAnnouncementReceived += OnOnlineEvent;
            announcementService.OfflineAnnouncementReceived += OnOfflineEvent;

            // Create ServiceHost for the AnnouncementService
            using (ServiceHost announcementServiceHost = new ServiceHost(announcementService))
            {
                // Listen for the announcements sent over UDP multicast
                announcementServiceHost.AddServiceEndpoint(new UdpAnnouncementEndpoint());
                announcementServiceHost.Open();

                Console.WriteLine("Listening for service announcements.");
                Console.WriteLine();
                Console.WriteLine("Press <ENTER> to terminate.");
                Console.ReadLine();
            }
        }

        static void OnOnlineEvent(object sender, AnnouncementEventArgs e)
        {
            Console.WriteLine();            
            Console.WriteLine("Received an online announcement from {0}:", e.AnnouncementMessage.EndpointDiscoveryMetadata.Address);
            PrintEndpointDiscoveryMetadata(e.AnnouncementMessage.EndpointDiscoveryMetadata);
        }

        static void OnOfflineEvent(object sender, AnnouncementEventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine("Received an offline announcement from {0}:", e.AnnouncementMessage.EndpointDiscoveryMetadata.Address);
            PrintEndpointDiscoveryMetadata(e.AnnouncementMessage.EndpointDiscoveryMetadata);
        }

        static void PrintEndpointDiscoveryMetadata(EndpointDiscoveryMetadata endpointDiscoveryMetadata)
        {
            Console.WriteLine("\tVersion: {0}", endpointDiscoveryMetadata.Version);

            foreach (System.Xml.XmlQualifiedName contractTypeName in endpointDiscoveryMetadata.ContractTypeNames)
            {
                Console.WriteLine("\tContractTypeName: {0}", contractTypeName);
            }
            foreach (Uri scope in endpointDiscoveryMetadata.Scopes)
            {
                Console.WriteLine("\tScope: {0}", scope);
            }
            foreach (Uri listenUri in endpointDiscoveryMetadata.ListenUris)
            {
                Console.WriteLine("\tListenUri: {0}", listenUri);
            }
        }        
    }
}

