//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Samples.BlobMessageEncoder
{
    using System.ServiceModel;
    using System.ServiceModel.Channels;

    [ServiceContract]
    interface IHttpHandler
    {
        [OperationContract(Action = "*", ReplyAction = "*")]
        Message ProcessRequest(Message request);
    }
}
