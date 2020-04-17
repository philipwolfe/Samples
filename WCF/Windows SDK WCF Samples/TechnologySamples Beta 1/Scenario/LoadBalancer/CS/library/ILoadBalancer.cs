
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.Xml;
using System.ServiceModel;

namespace Microsoft.ServiceModel.Samples
{
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
    public interface ILoadBalancer
    {
        [OperationContract]
        string Register(string contractQName, string bindingQName, EndpointAddress10 serviceAddress);

        [OperationContract(IsOneWay = true)]
        void Unregister(string registrationId);

        [OperationContract]
        EndpointAddress10 GetServiceAddress(string contractQName, string bindingQName);
    }
}
