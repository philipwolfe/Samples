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
    using System.Activities.Expressions;

    public sealed class QuorumApproval : Activity 
    {
        public InArgument<ApprovalRequest> Request { get; set; }
        public InArgument<User> Context { get; set; }
        public InArgument<String> ApproverType { get; set; }
        public InArgument<int> TotalApprovers { get; set; }
        public InArgument<int> RequiredApprovals { get; set; }
        public OutArgument<ApprovalResponse> Response { get; set; }

        public QuorumApproval()
        {
            Variable<List<User>> approvers = new Variable<List<User>> { Name = "Approver", Default = ValueExpression.Create<List<User>>(env => new List<User>()) };
            Variable<List<UserWithIndex>> indexApprovers = new Variable<List<UserWithIndex>> { Name = "IndexApprover", Default = ValueExpression.Create<List<UserWithIndex>>(env => new List<UserWithIndex>()) };
            Variable<List<ApprovalResponse>> aresponses = new Variable<List<ApprovalResponse>> { Name = "ApprovedResponses", Default = ValueExpression.Create<List<ApprovalResponse>>(env => new List<ApprovalResponse>()) };
            Variable<List<ApprovalResponse>> rresponses = new Variable<List<ApprovalResponse>> { Name = "RejectedResponses", Default = ValueExpression.Create<List<ApprovalResponse>>(env => new List<ApprovalResponse>()) };
            Variable<UserWithIndex> i = new Variable<UserWithIndex> { Name = "Iterand" };
            Variable<ApprovalResponse> interResponse = new Variable<ApprovalResponse> { Name = "IntermediateResponse" };

            this.Body = () => new Sequence
            {
                Variables =
                {
                    aresponses, rresponses, approvers, interResponse, indexApprovers
                },
                Activities =
                {
                    new WriteLine
                    {
                        Text = "Executing Quorom Approval",
                    },
                    new SelectUsers
                    {
                        SelectedUsers = approvers,
                        UserType = new InArgument<string>(env => ApproverType.Get(env)),
                        UserContext = new InArgument<User>(env => Context.Get(env)),
                        SelectXUsers = new InArgument<int>(env => TotalApprovers.Get(env)),
                    },
                    new If
                    {
                        Condition = new InArgument<bool>(env => approvers.Get(env).Count < RequiredApprovals.Get(env)),
                        Then = new CreateResponse
                        {
                            Request = new InArgument<ApprovalRequest>(env => Request.Get(env)),
                            Response = new OutArgument<ApprovalResponse>(env => Response.Get(env)),
                            Approved = new InArgument<bool>(env => false),
                        },
                        Else = new Sequence{
                            Activities = {
                                new UserListToUserWithIndexList
                                {
                                     UserList = new InArgument<List<User>>(env => approvers.Get(env)),
                                     UserListWithIndex = new OutArgument<List<UserWithIndex>>(env => indexApprovers.Get(env)),
                                },
                                new ParallelForEach<UserWithIndex>
                                {
                                    Values = new InArgument<IEnumerable<UserWithIndex>>(env => indexApprovers.Get(env)),
                                    Body = new ActivityAction<UserWithIndex>
                                    {
                                        Argument = i,
                                        Handler = new Sequence
                                        {
                                            Activities =
                                            {
                                                new RequestApprovalInParallel
                                                {
                                                    ApproverWithIndex = new InArgument<UserWithIndex>(env => i.Get(env)),
                                                    AResponses = new InOutArgument<List<ApprovalResponse>>(env => aresponses.Get(env)),
                                                    RResponses = new InOutArgument<List<ApprovalResponse>>(env => rresponses.Get(env)),
                                                    Request = new InArgument<ApprovalRequest>(env => new ApprovalRequest(Request.Get(env), i.Get(env).Index)),
                                                }
                                            }
                                        }
                                    }
                                },
                                // This scenario is currently not supported in Beta1.  If one recieved is canceled here,
                                // and a single approval activity is used right after a quorum approval, and a response 
                                // from the canceled receive is received -- it will block the receive in the single 
                                // approval activity.
                                //
                                //new ParallelForEach<UserWithIndex>
                                //{
                                //    Values = new InArgument<IEnumerable<UserWithIndex>>(env => indexApprovers.Get(env)),
                                //    CompletionCondition = ValueExpression.Create<bool>(env => 
                                //        (aresponses.Get(env).Count >= RequiredApprovals.Get(env)) ||  
                                //        ((rresponses.Get(env).Count + RequiredApprovals.Get(env)) > TotalApprovers.Get(env))),
                                //    Body = new ActivityAction<UserWithIndex>
                                //    {
                                //        Argument = i,
                                //        Handler = new Sequence
                                //        {
                                //            Activities =
                                //            {
                                //                new RequestApprovalInParallel
                                //                {
                                //                    ApproverWithIndex = new InArgument<UserWithIndex>(env => i.Get(env)),
                                //                    AResponses = new InOutArgument<List<ApprovalResponse>>(env => aresponses.Get(env)),
                                //                    RResponses = new InOutArgument<List<ApprovalResponse>>(env => rresponses.Get(env)),
                                //                    Request = new InArgument<ApprovalRequest>(env => new ApprovalRequest(Request.Get(env), i.Get(env).Index)),
                                //                    ConcurrentIndex = new InArgument<int>(env => i.Get(env).Index),
                                //                }
                                //            }
                                //        }
                                //    }
                                //},
                                new WriteLine
                                {
                                    Text = new InArgument<string>(env => "Ended Quorum with: " + aresponses.Get(env).Count + " approvals and " + rresponses.Get(env).Count + " Rejections"),
                                },
                                new If
                                {
                                    Condition = new InArgument<bool>(env => aresponses.Get(env).Count >= RequiredApprovals.Get(env)),
                                    Then = new Assign<ApprovalResponse>
                                    {
                                        To = new OutArgument<ApprovalResponse>(env => Response.Get(env)),
                                        Value = new InArgument<ApprovalResponse>(env => new ApprovalResponse(Request.Get(env), true)),
                                    },
                                    Else = new Assign<ApprovalResponse>
                                    {
                                        To = new OutArgument<ApprovalResponse>(env => Response.Get(env)),
                                        Value = new InArgument<ApprovalResponse>(env => new ApprovalResponse(Request.Get(env), false)),
                                    },
                                },
                            },
                        }
                    }
                }
            };
        }
    }
}
