//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Sample.Transaction.TransactedParallelConvoy.Common
{
    using System;
    using System.ServiceModel;
    using System.Xml.Linq;

    public class ConnectionData
    {
        public static readonly string serverAddress = "net.tcp://localhost/TRSSample/Server";
        public static readonly XName serviceContractName = XName.Get("IServiceContract", "http://tempuri.org/");
        public static readonly Endpoint serverEndpoint = new Endpoint
        {
            Binding = new NetTcpBinding
            {
                TransactionFlow = true,
                TransactionProtocol = TransactionProtocol.WSAtomicTransaction11,
            },
            Uri = new Uri(ConnectionData.serverAddress),
        };
    }
}
