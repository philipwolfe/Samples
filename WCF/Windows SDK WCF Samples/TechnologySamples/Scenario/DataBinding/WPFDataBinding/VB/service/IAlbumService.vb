' Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System
Imports System.ServiceModel
Imports System.Collections
Imports System.Collections.Generic

Namespace Microsoft.ServiceModel.Samples

    <ServiceContractAttribute([Namespace]:="http://Microsoft.ServiceModel.Samples")> _
    Interface IAlbumService

        <OperationContract()> _
        Function GetAlbumList() As Album()
        <OperationContract()> _
        Sub AddAlbum(ByVal title As String)

    End Interface

End Namespace
