' Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System
Imports System.ServiceModel.Description
Imports System.ServiceModel.Channels
Imports System.ServiceModel

Namespace Microsoft.ServiceModel.Samples

    Public Class LoadBalancerResolver

        Const MicrosoftNamespace As String = "http://schemas.microsoft.com/2005/07/ServiceModel"

        Private loadBalancerAddress As EndpointAddress
        Private loadBalancerBinding As Binding

        Public Sub New(ByVal loadBalancerAddress As EndpointAddress, ByVal loadBalancerBinding As Binding)

            Me.loadBalancerAddress = loadBalancerAddress
            Me.loadBalancerBinding = loadBalancerBinding

        End Sub

        Public Function GetEndpointAddress(Of TChannel)(ByVal binding As Binding) As EndpointAddress10

            Dim contractDesc As ContractDescription = ContractDescription.GetContract(GetType(TChannel))

            Dim contractQName As String = contractDesc.[Namespace] + ":" + contractDesc.Name
            Dim bindingQName As String = binding.[Namespace] + ":" + binding.Name

            Dim factory As New ChannelFactory(Of ILoadBalancer)(loadBalancerBinding, loadBalancerAddress)
            Dim loadBalancer As ILoadBalancer = factory.CreateChannel()

            Dim epr As EndpointAddress10 = loadBalancer.GetServiceAddress(contractQName, bindingQName)

            DirectCast(loadBalancer, IChannel).Close()

            Return epr

        End Function

        Public Function GetChannelFactory(Of TChannel)(ByVal binding As Binding) As ChannelFactory(Of TChannel)

            Dim remoteAddress As EndpointAddress = GetEndpointAddress(Of TChannel)(binding).ToEndpointAddress()

            If remoteAddress Is Nothing Then

                Return Nothing

            End If
            Return New ChannelFactory(Of TChannel)(binding, remoteAddress)

        End Function

    End Class

End Namespace
