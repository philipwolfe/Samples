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
    using System.ServiceModel.Activities;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.Runtime.Serialization;

    using Microsoft.Samples.DocumentApprovalProcess.ApprovalMessageContractLibrary;
    using System.Xml.Linq;

    public sealed class ApprovalRouteAndExecute : Activity
    {
        public ApprovalRouteAndExecute()
        {
            Variable<ApprovalRequest> request = new Variable<ApprovalRequest> { Name = "request" };
            Variable<ApprovalResponse> response = new Variable<ApprovalResponse> { Name = "response" };
            Variable<String> approvaltype = new Variable<String> { Name = "ApprovalType" };
            Variable<CorrelationHandle> requestReplyHandle = new Variable<CorrelationHandle> { Name = "RequestReplyHandle" };

            Send results = new Send
            {
                OperationName = "ApprovalProcessResults",
                ServiceContractName = "IApprovalResults",
                CorrelatesWith = requestReplyHandle,
                Value = new InArgument<ApprovalResponse>(response),
                EndpointAddress = new InArgument<Uri>(env => new Uri(request.Get(env).Requester.AddressResponse)),
                Endpoint = new Endpoint
                {
                    Binding = new BasicHttpBinding()
                }
            };


            FlowStep sendResults = new FlowStep
            {
                Action = new Sequence
                {
                    Activities = 
                    {
                        results,
                        new WriteLine
                        {
                            Text = new InArgument<string>(env => "Sent response to: " + request.Get(env).Requester.AddressResponse),
                        },
                        new ReceiveReply
                        {
                            Request = results,
                        },
                    }
                }
            };

            FlowStep singleUType2 = new FlowStep
            {
                Action = new SingleApproval
                {
                    ApproverType = "UserType2",
                    Context = new InArgument<User>(env => (request.Get(env)).Requester),
                    Request = new InArgument<ApprovalRequest>(request),
                    Response = response,
                },
                Next = sendResults,
            };

            FlowStep quorumUType2 = new FlowStep
            {
                Action = new QuorumApproval
                {
                    ApproverType = "UserType2",
                    Context = new InArgument<User>(env => (request.Get(env)).Requester),
                    Request = new InArgument<ApprovalRequest>(request),
                    Response = response,
                    RequiredApprovals = new InArgument<int>(1),
                    TotalApprovers = new InArgument<int>(2),
                },
                Next = sendResults,
            };

            FlowStep uType2QuorumThenUType3Single = new FlowStep
            {
                Action = new ComplexApproval
                {
                    Context = new InArgument<User>(env => (request.Get(env)).Requester),
                    Request = new InArgument<ApprovalRequest>(request),
                    Response = response,
                },
                Next = sendResults,
            };

            FlowSwitch approvalTypeSwitch = new FlowSwitch
            {
                Expression = approvaltype,
                Cases =
                {{"Single UserType2 Approval", singleUType2},
                {"Quorum UserType2 Approval", quorumUType2},
                {"UserType2 Quorum Then UserType3 Single Approval", uType2QuorumThenUType3Single}},
                Default = singleUType2,
            };

            FlowStep receiveRequest = new FlowStep
            {
                Action = new Sequence
                {
                    Activities = { 
                        new Receive
                        {
                            OperationName = "RequestApprovalOf",
                            ServiceContractName = "IApprovalProcess",
                            Value = new OutArgument<ApprovalRequest>(request),
                            CanCreateInstance = true,
                        },
                        new WriteLine
                        {
                            Text = new InArgument<string>(env => "Got request from: " + request.Get(env).Requester.AddressResponse),
                        },
                        new Assign 
                        {
                            To = new OutArgument<String>(approvaltype), 
                            Value = new InArgument<String>(env => request.Get(env).ApprovalType)
                        },
                    },
                },
                Next = approvalTypeSwitch,
            };

            this.Body = () => new Flowchart
            {
                DisplayName = "ApprovalRouteAndExecute",
                Variables = { request, response, approvaltype, requestReplyHandle },
                StartNode = receiveRequest,
                Nodes = {
                    receiveRequest,
                    approvalTypeSwitch,
                    singleUType2,
                    quorumUType2,
                    uType2QuorumThenUType3Single,
                    sendResults,
                }
            };
        }
    }
}
