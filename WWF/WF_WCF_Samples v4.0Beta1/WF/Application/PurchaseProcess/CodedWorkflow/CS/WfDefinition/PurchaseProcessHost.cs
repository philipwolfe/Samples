﻿//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------
namespace Microsoft.Samples.WF.PurchaseProcess
{
    using System;
    using System.Activities;
    using System.Collections.Generic;
    using System.ServiceModel.Persistence;    

    /// <summary>
    /// Sample implementation of the host. It uses custom persistence
    /// for loading and saving the workflow instances and caches them in 
    /// a private dictionary.
    /// </summary>
    public class PurchaseProcessHost : IPurchaseProcessHost
    {                        
        private IDictionary<Guid, WorkflowInstance> instances;

        public PurchaseProcessHost()
        {
            instances = new Dictionary<Guid, WorkflowInstance>();
        }

        // load and resume a workflow instance. If the instance is in memory, 
        // will return the version from memory. If not, will load it from the 
        // persistent store
        public WorkflowInstance LoadInstance(Guid instanceId)
        {
            // if the instance is in memory, return it
            if (this.instances.ContainsKey(instanceId))
                return this.instances[instanceId];

            // load the instance
            WorkflowInstance instance = WorkflowInstance.Load(new PurchaseProcessWorkflow(), new XmlPersistenceProvider(instanceId));
            instance.OnCompleted += OnWorkflowCompleted;
            instance.OnIdle += OnIdle;

            // add a tracking participant
            instance.Extensions.Add(new SaveAllEventsToTestFileTrackingParticipant());

            // add the instance to the list of running instances in the host
            this.instances.Add(instance.Id, instance);
            return instance;
        }

        // creates a workflow instance, binds parameters, links extensions and run it
        public WorkflowInstance CreateAndRun(RequestForProposal rfp)
        {
            // input parameters for the WF program
            IDictionary<string, object> inputs = new Dictionary<string, object>();
            inputs.Add("Rfp", rfp);            

            // create and run the WF instance
            WorkflowElement wf = new PurchaseProcessWorkflow();
            WorkflowInstance instance = new WorkflowInstance(wf, inputs);
            instance.OnCompleted += OnWorkflowCompleted;
            instance.OnIdle += OnIdle;            

            // create the persistence provider and add it to the workflow instance            
            PersistenceProvider persistenceProvider = new XmlPersistenceProvider(instance.Id);
            instance.Extensions.Add(persistenceProvider);

            // add a tracking participant
            instance.Extensions.Add(new SaveAllEventsToTestFileTrackingParticipant());

            // add instance to the host list of running instances
            this.instances.Add(instance.Id, instance);
            
            // continue executing this instance
            instance.Run();

            return instance;
        }      

        // executed when instance goes idle
        public IdleAction OnIdle()
        {
            return IdleAction.Persist;
        }

        // executed when instance is persisted
        public void OnWorkflowCompleted(WorkflowCompletedEventArgs e)        
        {
        }

        // submit a proposal to a vendor. To submit the proposal, a bookmark is resumed
        public void SubmitVendorProposal(Guid instanceId, int vendorId, double value)
        {
            WorkflowInstance instance = this.LoadInstance(instanceId);
            string bookmarkName = "waitingFor_" + vendorId.ToString();
            instance.ResumeBookmark(bookmarkName, value);
        }

        // returns true if the instance is waiting for proposals (has pending vendor bookmarks)
        public bool IsInstanceWaitingForProposals(Guid instanceId)
        {
            WorkflowInstance instance = this.LoadInstance(instanceId);
            return instance.GetAllBookmarks().Count > 0;
        }

        // returns true if a vendor can submit a proposal to an instance by 
        // checking if there is a pending bookmark for that vendor
        public bool CanSubmitProposalToInstance(Guid instanceId, int vendorId)
        {
            WorkflowInstance instance = this.LoadInstance(instanceId);

            // if there are no bookmarks, the process has finalized
            if (instance.GetAllBookmarks().Count == 0)
            {
                return false;
            }
            else // if there are bookmarks, check if one of them correspond with the "logged" vendor
            {
                foreach (BookmarkInfo bookmarkInfo in instance.GetAllBookmarks())
                {
                    if (bookmarkInfo.BookmarkName.Equals("waitingFor_" + vendorId))
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}