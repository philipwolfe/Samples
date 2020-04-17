' Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System
Imports System.Xml
Imports System.ServiceModel

Namespace Microsoft.ServiceModel.Samples

    <ServiceContract([Namespace]:="http://Microsoft.ServiceModel.Samples")> _
    Public Interface ILoadBalancer

        <OperationContract()> _
        Function Register(ByVal contractQName As String, ByVal bindingQName As String, ByVal serviceAddress As EndpointAddress10) As String
        <OperationContract(IsOneWay:=True)> _
        Sub Unregister(ByVal registrationId As String)
        <OperationContract()> _
        Function GetServiceAddress(ByVal contractQName As String, ByVal bindingQName As String) As EndpointAddress10

    End Interface

End Namespace
