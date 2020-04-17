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
    using System.ServiceModel;
    using System.ServiceModel.Activities;
    using System.ServiceModel.Channels;

    using Microsoft.Samples.DocumentApprovalProcess.ApprovalMessageContractLibrary;
    using System.Xml.Linq;
    using System.ServiceModel.Dispatcher;

    public sealed class RequestApproval : Activity
    {
        public InArgument<ApprovalRequest> request { get; set; }
        public InArgument<Uri> endpointAddress { get; set; }
        public OutArgument<ApprovalResponse> response { get; set; }

        public RequestApproval()
        {
            Variable<CorrelationHandle> corr = new Variable<CorrelationHandle> { Name = "ApprovalCorrHandle" };

            XPathMessageContext xPathMessageContext = new XPathMessageContext();
            xPathMessageContext.AddNamespace("temp", "http://tempuri.org/");

            MessageQuerySet msq = new MessageQuerySet{
                {
                    "ApprovalProcessId",
                    new XPathMessageQuery("/s11:Envelope/s11:Body/temp:Id", xPathMessageContext)
                },
                {
                    "ApprovalProcessIndex",
                    new XPathMessageQuery("/s11:Envelope/s11:Body/temp:ConcurrentIndex", xPathMessageContext)
                }
            };
            msq.Name = "requestapprovalqueryset";

            this.Body = () => new Sequence
            {
                Variables = { corr },
                Activities =
                {
                    new Send
                    {
                        OperationName = "RequestClientResponse",
                        ServiceContractName = "IClientApproval",
                        EndpointAddress = new InArgument<Uri>(env => endpointAddress.Get(env)),
                        Endpoint = new Endpoint
                        {
                             Binding = new BasicHttpBinding(),
                        },
                        Value = new InArgument<ApprovalRequest>(env => request.Get(env)),
                        CorrelatesWith = corr,
                        CorrelationQuery = new CorrelationQuery
                        {
                            Where = new CorrelationActionMessageFilter { Action = "http://tempuri.org/IClientApproval/RequestClientResponse" },
                            Select = msq
                        }
                        
                    },
                    new WriteLine
                    {
                        Text = new InArgument<String>(env => "Request sent for " + request.Get(env).Id + " with correlation index " + request.Get(env).ConcurrentIndex),
                    },
                    new Receive
                    {
                        OperationName = "ResponsedToApprovalRequest",
                        ServiceContractName = "IApprovalProcess",
                        CorrelatesWith = corr,
                        CorrelationQuery = new CorrelationQuery
                        {
                            Where = new CorrelationActionMessageFilter { Action = "http://tempuri.org/IApprovalProcess/ResponsedToApprovalRequest" },
                            Select = msq,
                        },
                        Value = new OutArgument<ApprovalResponse>(env => response.Get(env)),
                    },
                    new WriteLine
                    {
                        Text = new InArgument<String>(env => "Got response from " + request.Get(env).Requester.Name + " with corr index " + request.Get(env).ConcurrentIndex.ToString()),
                    },
                }
            };
        }
    }
}
