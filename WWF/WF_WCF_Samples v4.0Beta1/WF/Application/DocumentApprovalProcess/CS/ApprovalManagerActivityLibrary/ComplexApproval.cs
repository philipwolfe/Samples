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

    public sealed class ComplexApproval : Activity
    {
        public InArgument<ApprovalRequest> Request { get; set; }
        public InArgument<User> Context { get; set; }
        public OutArgument<ApprovalResponse> Response { get; set; }

        public ComplexApproval()
        {
            Variable<ApprovalResponse> subresponse = new Variable<ApprovalResponse> { Name = "Subresponse" };

            this.Body = () => new Sequence
            {
                Variables = { subresponse },
                Activities =
                {
                    new QuorumApproval
                    {
                        ApproverType = "UserType2",
                        Context = new InArgument<User>(env => (Request.Get(env)).Requester),
                        Request = new InArgument<ApprovalRequest>(env => Request.Get(env)),
                        Response = subresponse,
                        RequiredApprovals = new InArgument<int>(env => 1),
                        TotalApprovers = new InArgument<int>(env => 2),
                    },
                    new If
                    {
                        Condition = new InArgument<bool>(env => subresponse.Get(env).Approved),
                        Then = new SingleApproval
                        {
                            ApproverType = "UserType3",
                            Context = new InArgument<User>(env => (Request.Get(env)).Requester),
                            Request = new InArgument<ApprovalRequest>(env => Request.Get(env)),
                            Response = new OutArgument<ApprovalResponse>(env => Response.Get(env)),
                        },
                        Else = new CreateResponse
                        {
                            Request = new InArgument<ApprovalRequest>(env => Request.Get(env)),
                            Approved = false,
                            Response = new OutArgument<ApprovalResponse>(env => Response.Get(env)),
                        }
                    },
                }
            };
        }
    }
}
