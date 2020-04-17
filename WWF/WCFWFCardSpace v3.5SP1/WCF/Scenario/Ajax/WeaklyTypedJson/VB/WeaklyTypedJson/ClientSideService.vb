' Copyright (c) Microsoft Corporation. All rights reserved.

Imports Microsoft.VisualBasic
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.ServiceModel.Web

Namespace Microsoft.Ajax.Samples

    <ServiceContract()> _
    Friend Interface IClientSideProfileService
        ' There is no need to write a DataContract for the complex type returned by the service.
        ' The client will use a JsonObject to browse the JSON in the received message.

        <OperationContract(), WebGet(ResponseFormat:=WebMessageFormat.Json)> _
        Function GetMemberProfile() As Message
    End Interface

End Namespace