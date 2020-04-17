
' Copyright (c) Microsoft Corporation.  All rights reserved.

Imports System.ServiceModel
Imports System.ServiceModel.Channels
Namespace Microsoft.ServiceModel.Samples
    Public Enum StreamedTransferMode
        Streamed = TransferMode.Streamed
        StreamedRequest = TransferMode.StreamedRequest
        StreamedResponse = TransferMode.StreamedResponse
    End Enum
End Namespace