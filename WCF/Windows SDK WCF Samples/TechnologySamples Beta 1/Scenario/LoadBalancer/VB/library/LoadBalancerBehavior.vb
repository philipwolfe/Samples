' Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System
Imports System.ServiceModel.Dispatcher
Imports System.ServiceModel.Description
Imports System.ServiceModel.Channels
Imports System.Collections.ObjectModel
Imports System.ServiceModel

Namespace Microsoft.ServiceModel.Samples

    Public Class LoadBalancerBehavior
        Implements IEndpointBehavior

        Private loadBalancerAddress As EndpointAddress
        Private loadBalancerBinding As Binding
        Private registrationId As String

        Public Sub New(ByVal loadBalancerAddress As EndpointAddress, ByVal loadBalancerBinding As Binding)

            Me.loadBalancerAddress = loadBalancerAddress
            Me.loadBalancerBinding = loadBalancerBinding

        End Sub

        Public Property Address() As EndpointAddress

            Get

                Return Me.loadBalancerAddress

            End Get
            Set(ByVal value As EndpointAddress)

                If value Is Nothing Then
                    Throw New ArgumentNullException("value")
                End If

                Me.loadBalancerAddress = value

            End Set

        End Property

        Public Property Binding() As Binding

            Get

                Return Me.loadBalancerBinding

            End Get
            Set(ByVal value As Binding)

                If value Is Nothing Then
                    Throw New ArgumentNullException("value")
                End If

                Me.loadBalancerBinding = value

            End Set

        End Property

        Public Sub ApplyClientBehavior(ByVal serviceEndpoint As ServiceEndpoint, ByVal clientRuntime As ClientRuntime) Implements IEndpointBehavior.ApplyClientBehavior

        End Sub

        Public Sub Validate(ByVal serviceEndpoint As ServiceEndpoint) Implements IEndpointBehavior.Validate

        End Sub

        Public Sub AddBindingParameters(ByVal serviceEndpoint As ServiceEndpoint, ByVal parameters As BindingParameterCollection) Implements IEndpointBehavior.AddBindingParameters

        End Sub

        Public Sub ApplyDispatchBehavior(ByVal serviceEndpoint As ServiceEndpoint, ByVal endpointDispatcher As EndpointDispatcher) Implements IEndpointBehavior.ApplyDispatchBehavior

            If endpointDispatcher Is Nothing Then
                Throw New ArgumentNullException("endpointDispatcher")
            End If

            Dim contractQName As String = serviceEndpoint.Contract.[Namespace] + ":" + serviceEndpoint.Contract.Name
            Dim bindingQName As String = serviceEndpoint.Binding.[Namespace] + ":" + serviceEndpoint.Binding.Name
            Dim serviceAddress As EndpointAddress = endpointDispatcher.EndpointAddress

            Dim factory As New ChannelFactory(Of ILoadBalancer)(loadBalancerBinding, loadBalancerAddress)
            Dim loadBalancer As ILoadBalancer = factory.CreateChannel()

            registrationId = loadBalancer.Register(contractQName, bindingQName, EndpointAddress10.FromEndpointAddress(serviceAddress))

            DirectCast(loadBalancer, IChannel).Close()

            AddHandler endpointDispatcher.ChannelDispatcher.Closing, AddressOf channelDispatcher_Closing

        End Sub

        Private Sub channelDispatcher_Closing(ByVal sender As Object, ByVal e As EventArgs)

            Dim factory As New ChannelFactory(Of ILoadBalancer)(loadBalancerBinding, loadBalancerAddress)
            Dim loadBalancer As ILoadBalancer = factory.CreateChannel()

            loadBalancer.Unregister(registrationId)

            DirectCast(loadBalancer, IChannel).Close()

        End Sub

    End Class

End Namespace
