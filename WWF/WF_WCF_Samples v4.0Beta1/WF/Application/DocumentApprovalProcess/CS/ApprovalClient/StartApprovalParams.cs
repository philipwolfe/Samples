//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;

using Microsoft.Samples.DocumentApprovalProcess.ApprovalMessageContractLibrary;

namespace Microsoft.Samples.DocumentApprovalProcess.ApprovalClient
{
    [MessageContract(IsWrapped = false)]
    class StartApprovalParams
    {
        ApprovalRequest request;
        Uri serviceAddress;

        [MessageBodyMember]
        public ApprovalRequest Request
        {
            get { return request; }
            set { request = value; }
        }

        [MessageBodyMember]
        public Uri ServiceAddress
        {
            get { return serviceAddress; }
            set { serviceAddress = value; }
        }

        StartApprovalParams()
        {

        }

        StartApprovalParams(ApprovalRequest newRequest, Uri newServiceAddress)
        {
            request = newRequest;
            serviceAddress = newServiceAddress;
        }
    }
}
