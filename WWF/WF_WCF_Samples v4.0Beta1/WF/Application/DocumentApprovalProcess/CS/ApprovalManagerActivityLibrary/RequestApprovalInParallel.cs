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
    using System.Activities.Statements;

    using Microsoft.Samples.DocumentApprovalProcess.ApprovalMessageContractLibrary;

    public sealed class RequestApprovalInParallel : Activity
    {
        public InOutArgument<List<ApprovalResponse>> AResponses { get; set; }
        public InOutArgument<List<ApprovalResponse>> RResponses { get; set; }
        public InArgument<UserWithIndex> ApproverWithIndex { get; set; }
        public InArgument<ApprovalRequest> Request { get; set; }

        public RequestApprovalInParallel()
        {
            Variable<ApprovalResponse> response = new Variable<ApprovalResponse> { Name = "AResponseInParallel" };
            this.Body = () => new Sequence
            {
                Variables = { response },
                Activities = 
                {
                    new RequestApproval
                    {
                        endpointAddress = new InArgument<Uri>(env => new Uri(ApproverWithIndex.Get(env).U.AddressRequest)),
                        request = new InArgument<ApprovalRequest>(env => Request.Get(env)),
                        response = new OutArgument<ApprovalResponse>(env => response.Get(env)),
                    },
                    new If
                    {
                        Condition = new InArgument<bool>(env => response.Get(env).Approved),
                        Then = new Sequence
                        {
                            Activities = 
                            {
                                new WriteLine{ Text = new InArgument<String>(env => "Got Approval for: " + response.Get(env).Id) },
                                new AddToCollection<ApprovalResponse>
                                {
                                    Collection = new InArgument<ICollection<ApprovalResponse>>(env => AResponses.Get(env)),
                                    Item = response,
                                },
                            }
                        },
                        Else = new Sequence
                        {
                            Activities = {
                                new WriteLine{ Text = new InArgument<String>(env => "Got Rejection for: " + response.Get(env).Id) },
                                new AddToCollection<ApprovalResponse>
                                {
                                    Collection = new InArgument<ICollection<ApprovalResponse>>(env => RResponses.Get(env)),
                                    Item = response,
                                }
                            },
                        },
                    }
                }
            };
        }
    }
}
