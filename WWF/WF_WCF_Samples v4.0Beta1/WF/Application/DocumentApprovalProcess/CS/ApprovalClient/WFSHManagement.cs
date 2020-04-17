//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Samples.DocumentApprovalProcess.ApprovalClient
{
    public interface IManageApproval
    {
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ISubscriptionService/Subscribe", ReplyAction = "http://tempuri.org/ISubscriptionService/SubscribeResponse")]
        Microsoft.Samples.DocumentApprovalProcess.ApprovalMessageContractLibrary.User Subscribe(Microsoft.Samples.DocumentApprovalProcess.ApprovalMessageContractLibrary.User newuser);

    }

    public interface ISubscriptionServiceChannel : ISubscriptionService, System.ServiceModel.IClientChannel
    {
    }

    public partial class SubscriptionServiceClient : System.ServiceModel.ClientBase<ISubscriptionService>, ISubscriptionService
    {

        public SubscriptionServiceClient()
        {
        }

        public SubscriptionServiceClient(string endpointConfigurationName) :
            base(endpointConfigurationName)
        {
        }

        public SubscriptionServiceClient(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public SubscriptionServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public SubscriptionServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
        {
        }

        public Microsoft.Samples.DocumentApprovalProcess.ApprovalMessageContractLibrary.User Subscribe(Microsoft.Samples.DocumentApprovalProcess.ApprovalMessageContractLibrary.User newuser)
        {
            return base.Channel.Subscribe(newuser);
        }

        public void Unsubscribe(Microsoft.Samples.DocumentApprovalProcess.ApprovalMessageContractLibrary.User id)
        {
            base.Channel.Unsubscribe(id);
        }
    }
}
