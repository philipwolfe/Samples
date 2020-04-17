//------------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------------------------
namespace Microsoft.ServiceModel.Samples
{
    using System.ServiceModel;
	using System.ServiceModel.Channels;

    public enum StreamedTransferMode
    {
        Streamed = TransferMode.Streamed,
        StreamedRequest = TransferMode.StreamedRequest,
        StreamedResponse = TransferMode.StreamedResponse
    }
}
