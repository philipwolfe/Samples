//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

using Microsoft.Samples.DocumentApprovalProcess.ApprovalMessageContractLibrary;

namespace Microsoft.Samples.DocumentApprovalProcess.ApprovalClient
{
    [ServiceContract]
    interface IClientApproval
    {
        [OperationContract(IsOneWay=true)]
        void RequestClientResponse(ApprovalRequest docApprovalRequest);
    }

    class ApprovalRequestsService : IClientApproval
    {
        public void RequestClientResponse(ApprovalRequest docApprovalRequest)
        {
            ExternalToMainComm.NewApprovalRequest(docApprovalRequest);
        }
    }
}
