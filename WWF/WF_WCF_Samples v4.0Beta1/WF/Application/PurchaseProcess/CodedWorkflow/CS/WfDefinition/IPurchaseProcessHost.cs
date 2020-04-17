//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------
namespace Microsoft.Samples.WF.PurchaseProcess
{
    using System;
    using System.Activities;

    /// <summary>
    /// Interface of the host
    /// </summary>
    interface IPurchaseProcessHost
    {
        bool CanSubmitProposalToInstance(Guid instanceId, int vendorId);
        WorkflowInstance CreateAndRun(Microsoft.Samples.WF.PurchaseProcess.RequestForProposal rfp);
        bool IsInstanceWaitingForProposals(Guid instanceId);
        WorkflowInstance LoadInstance(Guid instanceId);
        void SubmitVendorProposal(Guid instanceId, int vendorId, double value);
    }
}