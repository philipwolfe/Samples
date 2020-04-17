
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.Xml;
using System.ServiceModel;
using System.Configuration;

namespace Microsoft.ServiceModel.Samples
{
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
    public interface ILoadBalancedEchoContract
    {
        [OperationContract]
        string Echo(string message);
    }

    public class LoadBalancedEchoService : ILoadBalancedEchoContract
    {
        public string Echo(string message)
        {
            return message;
        }
    }
}
