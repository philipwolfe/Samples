//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Samples.DocumentApprovalProcess.ApprovalManagerActivityLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Activities;

    using Microsoft.Samples.DocumentApprovalProcess.ApprovalMessageContractLibrary;

    public sealed class CreateResponse : CodeActivity
    {
        public InArgument<ApprovalRequest> Request { get; set; }
        public InArgument<bool> Approved { get; set; }
        public OutArgument<ApprovalResponse> Response { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            ApprovalResponse result = new ApprovalResponse(Request.Get(context), Approved.Get(context));
            Response.Set(context, result);
        }
    }
}
