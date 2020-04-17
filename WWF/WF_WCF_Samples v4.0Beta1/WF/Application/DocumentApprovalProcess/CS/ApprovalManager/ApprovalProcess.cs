//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

using Microsoft.Samples.DocumentApprovalProcess.ApprovalMessageContractLibrary;

namespace Microsoft.Samples.DocumentApprovalProcess.ApprovalManager
{
    [ServiceContract]
    public interface IApprovalProcess
    {
        [OperationContract]
        void RequestApproval(ApprovalRequest docApprovalRequest);

        [OperationContract]
        void ResponsedToApprovalRequest(ApprovalResponse response);
    }
}
