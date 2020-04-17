//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------
namespace Microsoft.Samples.Discovery
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ServiceModel;
    using System.ServiceModel.Discovery;
    using System.Threading;
    using System.Xml;


    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class DiscoveryProxy : DiscoveryProxyBase
    {
        Dictionary<EndpointAddress, EndpointDiscoveryMetadata> onlineServices;

        public DiscoveryProxy()
        {
            this.onlineServices = new Dictionary<EndpointAddress, EndpointDiscoveryMetadata>();
        }

        void AddOnlineService(EndpointDiscoveryMetadata endpointDiscoveryMetadata)
        {
            lock (this.onlineServices)
            {
                this.onlineServices[endpointDiscoveryMetadata.Address] = endpointDiscoveryMetadata;
                PrintDiscoveryMetadata(endpointDiscoveryMetadata, "Adding");
            }
        }

        void RemoveOnlineService(EndpointDiscoveryMetadata endpointDiscoveryMetadata)
        {
            if (endpointDiscoveryMetadata != null)
            {
                lock (this.onlineServices)
                {
                    this.onlineServices.Remove(endpointDiscoveryMetadata.Address);
                    PrintDiscoveryMetadata(endpointDiscoveryMetadata, "Removing");
                }
            }    
        }

        private void PrintDiscoveryMetadata(EndpointDiscoveryMetadata endpointDiscoveryMetadata, string verb)
        {
            Console.WriteLine("\n**** " + verb + " service of the following type from cache. ");
            foreach (XmlQualifiedName contractName in endpointDiscoveryMetadata.ContractTypeNames)
            {
                Console.WriteLine("** " + contractName.ToString());
                break;
            }
            Console.WriteLine("**** Operation Completed");
        }

        private Collection<EndpointDiscoveryMetadata> MatchFromOnlineService(FindCriteria criteria)
        {
            Collection<EndpointDiscoveryMetadata> matchingEndpoints = new Collection<EndpointDiscoveryMetadata>();
            lock (this.onlineServices)
            {
                foreach (EndpointDiscoveryMetadata endpointDiscoveryMetadata in this.onlineServices.Values)
                {
                    if (criteria.IsMatch(endpointDiscoveryMetadata))
                    {
                        matchingEndpoints.Add(endpointDiscoveryMetadata);
                    }
                }
            }
            return matchingEndpoints;
        }

        private EndpointDiscoveryMetadata MatchFromOnlineService(ResolveCriteria criteria)
        {
            EndpointDiscoveryMetadata matchingEndpoint = null;
            lock (this.onlineServices)
            {
                foreach (EndpointDiscoveryMetadata endpointDiscoveryMetadata in this.onlineServices.Values)
                {
                    if (criteria.Address == endpointDiscoveryMetadata.Address)
                    {
                        matchingEndpoint = endpointDiscoveryMetadata;
                    }
                }
            }
            return matchingEndpoint;
        }
        
        protected override IAsyncResult OnBeginOnlineAnnouncement(AnnouncementMessage announcementMessage, AsyncCallback callback, object state)
        {        
            this.AddOnlineService(announcementMessage.EndpointDiscoveryMetadata);
            return base.OnBeginOnlineAnnouncement(announcementMessage, callback, state);
        }

        protected override void OnEndOnlineAnnouncement(IAsyncResult result)
        {
            base.OnEndOnlineAnnouncement(result);
        }

        protected override IAsyncResult OnBeginOfflineAnnouncement(AnnouncementMessage announcementMessage, AsyncCallback callback, object state)
        {
            this.RemoveOnlineService(announcementMessage.EndpointDiscoveryMetadata);
            return base.OnBeginOfflineAnnouncement(announcementMessage, callback, state);
        }

        protected override void OnEndOfflineAnnouncement(IAsyncResult result)
        {
            base.OnEndOfflineAnnouncement(result);
        }


        protected override IAsyncResult OnBeginFind(FindRequest findRequest, AsyncCallback callback, object state)
        {
            return new OnFindAsyncResult(
                this.MatchFromOnlineService(findRequest.Criteria),
                callback,
                state);
        }

        protected override Collection<EndpointDiscoveryMetadata> OnEndFind(IAsyncResult result)
        {
            return OnFindAsyncResult.End(result);
        }    
    }
}
