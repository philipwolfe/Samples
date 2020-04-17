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

    public sealed class SingleApproval : Activity
    {
        public InArgument<ApprovalRequest> Request { get; set; }
        public InArgument<User> Context { get; set; }
        public InArgument<String> ApproverType { get; set; }
        public OutArgument<ApprovalResponse> Response { get; set; }

        public SingleApproval()
        {
            Variable<List<User>> approver = new Variable<List<User>> { Name = "Approver" };

            this.Body = () => new Sequence
            {
                Variables =
                {
                    approver
                },
                Activities =
                {
                    new WriteLine
                    {
                        Text = "Executing Single Approval",
                    },
                    new SelectUsers
                    {
                        SelectedUsers = approver,
                        UserType = new InArgument<string>(env => ApproverType.Get(env)),
                        UserContext = new InArgument<User>(env => Context.Get(env)),
                        SelectXUsers = 1,
                    },
                    new If
                    {
                        Condition = new InArgument<bool>(env => approver.Get(env).Count < 1),
                        Then = new CreateResponse
                        {
                            Request = new InArgument<ApprovalRequest>(env => Request.Get(env)),
                            Response = new OutArgument<ApprovalResponse>(env => Response.Get(env)),
                            Approved = new InArgument<bool>(env => false),
                        },
                        Else = new RequestApproval
                        {
                            endpointAddress = new InArgument<Uri>(env => new Uri(approver.Get(env)[0].AddressRequest)),
                            request = new InArgument<ApprovalRequest>(env => new ApprovalRequest(Request.Get(env), -1)),
                            response = new OutArgument<ApprovalResponse>(env => Response.Get(env)),
                        },
                    },
                }
            };
        }
    }
}
