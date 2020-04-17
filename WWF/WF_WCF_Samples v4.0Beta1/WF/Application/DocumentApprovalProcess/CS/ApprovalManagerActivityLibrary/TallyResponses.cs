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

    public sealed class TallyResponses : CodeActivity
    {
        public InArgument<LinkedList<ApprovalResponse>> ResponseList { get; set; }
        public OutArgument<int> Tally { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            int count = 0;
            LinkedList<ApprovalResponse> responses = ResponseList.Get(context);
            foreach (ApprovalResponse response in responses)
            {
                if (response.Approved) count++;
            }
            Tally.Set(context, count);
        }
    }
}
