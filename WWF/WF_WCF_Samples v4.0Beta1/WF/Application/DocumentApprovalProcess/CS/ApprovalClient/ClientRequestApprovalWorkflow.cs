//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Samples.DocumentApprovalProcess.ApprovalClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Activities;
    using System.Activities.Statements;
    using System.ServiceModel.Activities;
    using System.ServiceModel;

    using Microsoft.Samples.DocumentApprovalProcess.ApprovalMessageContractLibrary;
    using System.ServiceModel.Dispatcher;
    using System.Xml.Linq;

    public sealed class ClientRequestApprovalWorkflow : Activity
    {
        public ClientRequestApprovalWorkflow()
        {
            Variable<CorrelationHandle> corr = new Variable<CorrelationHandle>();
            Variable<ApprovalResponse> response = new Variable<ApprovalResponse>();
            Variable<StartApprovalParams> startParams = new Variable<StartApprovalParams>();
            Variable<CorrelationHandle> requestReplyHandle = new Variable<CorrelationHandle> { Name = "RequestReplyHandle" };

            XPathMessageContext xPathMessageContext = new XPathMessageContext();
            xPathMessageContext.AddNamespace("temp", "http://tempuri.org/");

            Receive receiveResponse = new Receive
            {
                OperationName = "ApprovalProcessResults",
                ServiceContractName = "IApprovalResults",
                CorrelatesWith = corr,
                AdditionalCorrelations =
                {
                    { CorrelationHandle.ChannelHandleName, new InArgument<CorrelationHandle>(requestReplyHandle) }
                },
                CorrelationQuery = new CorrelationQuery
                {
                    Where = new CorrelationActionMessageFilter { Action = "http://tempuri.org/IApprovalResults/ApprovalProcessResults" },
                    Select = new MessageQuerySet{
                                {
                                    "ApprovalProcessId",
                                    new XPathMessageQuery("//temp:Id",  xPathMessageContext)
                                }
                            }
                },
                Value = new OutArgument<ApprovalResponse>(response),
            };       
            this.Body = () => 
                new Sequence
                {
                    Variables = { corr, response, startParams, requestReplyHandle },
                    Activities =
                    {
                        new Receive
                        {
                            OperationName = "StartGetApproval",
                            ServiceContractName = "IApprovalResults",
                            Value = new OutArgument<StartApprovalParams>(startParams),
                            CanCreateInstance = true,
                        },
                        new Send
                        {
                            OperationName = "RequestApprovalOf",
                            ServiceContractName = "IApprovalProcess",
                            EndpointAddress = new InArgument<Uri>(env => startParams.Get(env).ServiceAddress),
                            Endpoint = new Endpoint
                            {
                                 Binding = new BasicHttpBinding(),
                            },
                            Value = new InArgument<ApprovalRequest>(env => startParams.Get(env).Request),
                            CorrelatesWith = corr,
                            CorrelationQuery = new CorrelationQuery
                            {
                                Where = new CorrelationActionMessageFilter { Action = "http://tempuri.org/IApprovalProcess/RequestApprovalOf" },
                                Select = new MessageQuerySet{
                                    {
                                        "ApprovalProcessId",
                                        new XPathMessageQuery("//temp:Id", xPathMessageContext)
                                    }
                                }
                            }
                        },
                        receiveResponse,
                        new SendReply
                        {
                            Request = receiveResponse,
                        },
                        new InvokeMethod
                        {
                            TargetType = typeof(ExternalToMainComm),
                            MethodName = "WriteStatusLine",
                            Parameters = 
                            {
                                new InArgument<String>("Got an approval response..."),
                            },
                        },
                        new InvokeMethod
                        {
                            TargetType = typeof(ExternalToMainComm),
                            MethodName = "ApprovalRequestResponse",
                            Parameters =
                            {
                                new InArgument<ApprovalResponse>(response),
                            }
                        },
                    }
                };
        }
    }
}
