
' Copyright (c) Microsoft Corporation.  All rights reserved.

Imports System

Imports System.ServiceModel.Channels
Imports System.Text
Imports System.Configuration
Imports System.ServiceModel
Imports System.ServiceModel.Configuration

Namespace Microsoft.ServiceModel.Samples
    Partial Public Class WSStreamedHttpBindingConfigurationElement
        Inherits StandardBindingElement

        Public Sub New()
            Me.New(Nothing)
        End Sub

        Public Sub New(ByVal configurationName As String)
            MyBase.New(configurationName)
        End Sub

        Protected Overrides ReadOnly Property BindingElementType() As Type
            Get
                Return GetType(WSStreamedHttpBinding)
            End Get
        End Property

        <ConfigurationProperty(WSStreamedHttpBindingConstants.HostnameComparisonMode, DefaultValue:=HostnameComparisonMode.StrongWildcard)> _
        Public Property HostnameComparisonMode() As HostnameComparisonMode
            Get
                Return MyBase.Item(WSStreamedHttpBindingConstants.HostnameComparisonMode)
            End Get
            Set(ByVal value As HostnameComparisonMode)
                MyBase.Item(WSStreamedHttpBindingConstants.HostnameComparisonMode) = value
            End Set
        End Property

        <ConfigurationProperty(WSStreamedHttpBindingConstants.MaxReceivedMessageSize, DefaultValue:=Long.MaxValue)> _
        <LongValidator(MinValue:=1)> _
        Public Property MaxReceivedMessageSize() As Long
            Get
                Return MyBase.Item(WSStreamedHttpBindingConstants.MaxReceivedMessageSize)
            End Get
            Set(ByVal value As Long)
                MyBase.Item(WSStreamedHttpBindingConstants.MaxReceivedMessageSize) = value
            End Set
        End Property

        <ConfigurationProperty(WSStreamedHttpBindingConstants.MaxBufferSize, DefaultValue:=65536)> _
        Public Property MaxBufferSize() As Integer
            Get
                Return MyBase.Item(WSStreamedHttpBindingConstants.MaxBufferSize)
            End Get
            Set(ByVal value As Integer)
                MyBase.Item(WSStreamedHttpBindingConstants.MaxBufferSize) = value
            End Set
        End Property

        <ConfigurationProperty(WSStreamedHttpBindingConstants.ProxyAddress, DefaultValue:=Nothing)> _
        Public Property ProxyAddress() As Uri
            Get
                Return MyBase.Item(WSStreamedHttpBindingConstants.ProxyAddress)
            End Get
            Set(ByVal value As Uri)
                MyBase.Item(WSStreamedHttpBindingConstants.ProxyAddress) = value
            End Set
        End Property

        <ConfigurationProperty(WSStreamedHttpBindingConstants.BypassProxyOnLocal, DefaultValue:=True)> _
        Public Property BypassProxyOnLocal() As Boolean
            Get
                Return MyBase.Item(WSStreamedHttpBindingConstants.BypassProxyOnLocal)
            End Get
            Set(ByVal value As Boolean)
                MyBase.Item(WSStreamedHttpBindingConstants.BypassProxyOnLocal) = value
            End Set
        End Property

        <ConfigurationProperty(WSStreamedHttpBindingConstants.UseDefaultWebProxy, DefaultValue:=True)> _
        Public Property UseDefaultWebProxy() As Boolean
            Get
                Return MyBase.Item(WSStreamedHttpBindingConstants.UseDefaultWebProxy)
            End Get
            Set(ByVal value As Boolean)
                MyBase.Item(WSStreamedHttpBindingConstants.UseDefaultWebProxy) = value
            End Set
        End Property

        <ConfigurationProperty(WSStreamedHttpBindingConstants.TransferMode, DefaultValue:=StreamedTransferMode.Streamed)> _
        Public Property TransferMode() As StreamedTransferMode
            Get
                Return MyBase.Item(WSStreamedHttpBindingConstants.TransferMode)
            End Get
            Set(ByVal value As StreamedTransferMode)
                MyBase.Item(WSStreamedHttpBindingConstants.TransferMode) = value
            End Set
        End Property

        <ConfigurationProperty(WSStreamedHttpBindingConstants.TextEncoding, DefaultValue:=WSStreamedHttpBindingConstants.EncodingString)> _
        Public Property TextEncoding() As Encoding
            Get
                Return MyBase.Item(WSStreamedHttpBindingConstants.TextEncoding)
            End Get
            Set(ByVal value As Encoding)
                MyBase.Item(WSStreamedHttpBindingConstants.TextEncoding) = value
            End Set
        End Property

        <ConfigurationProperty(WSStreamedHttpBindingConstants.FlowTransactions, DefaultValue:=False)> _
        Public Property FlowTransactions() As Boolean
            Get
                Return MyBase.Item(WSStreamedHttpBindingConstants.FlowTransactions)
            End Get
            Set(ByVal value As Boolean)
                MyBase.Item(WSStreamedHttpBindingConstants.FlowTransactions) = value
            End Set
        End Property

        <ConfigurationProperty(WSStreamedHttpBindingConstants.SecurityMode, DefaultValue:=StreamedSecurityMode.Transport)> _
        Public Property SecurityMode() As StreamedSecurityMode
            Get
                Return MyBase.Item(WSStreamedHttpBindingConstants.SecurityMode)
            End Get
            Set(ByVal value As StreamedSecurityMode)
                MyBase.Item(WSStreamedHttpBindingConstants.SecurityMode) = value
            End Set
        End Property

        Protected Overrides Sub InitializeFrom(ByVal streamedBinding As Binding)
            If streamedBinding Is Nothing Then
                Throw New ArgumentNullException("streamedBinding")
            End If
            If Not TypeOf streamedBinding Is WSStreamedHttpBinding Then
                Throw New ArgumentException()
            End If

            Dim wssBinding As WSStreamedHttpBinding = streamedBinding

            Me.HostnameComparisonMode = wssBinding.HostnameComparisonMode
            Me.MaxReceivedMessageSize = wssBinding.MaxReceivedMessageSize
            Me.MaxBufferSize = wssBinding.MaxBufferSize
            Me.ProxyAddress = wssBinding.ProxyAddress
            Me.BypassProxyOnLocal = wssBinding.BypassProxyOnLocal
            Me.UseDefaultWebProxy = wssBinding.UseDefaultWebProxy
            Me.TransferMode = wssBinding.TransferMode
            Me.TextEncoding = wssBinding.TextEncoding
            Me.FlowTransactions = wssBinding.FlowTransactions
            Me.SecurityMode = wssBinding.SecurityMode
        End Sub

        Protected Overrides Sub OnApplyConfiguration(ByVal streamedBinding As Binding)
            If streamedBinding Is Nothing Then
                Throw New ArgumentNullException("streamedBinding")
            End If

            If Not TypeOf streamedBinding Is WSStreamedHttpBinding Then
                Throw New ArgumentException()
            End If

            Dim wssBinding As WSStreamedHttpBinding = streamedBinding

            wssBinding.HostnameComparisonMode = Me.HostnameComparisonMode
            wssBinding.MaxReceivedMessageSize = Me.MaxReceivedMessageSize
            wssBinding.MaxBufferSize = Me.MaxBufferSize
            wssBinding.ProxyAddress = Me.ProxyAddress
            wssBinding.BypassProxyOnLocal = Me.BypassProxyOnLocal
            wssBinding.UseDefaultWebProxy = Me.UseDefaultWebProxy
            wssBinding.TransferMode = Me.TransferMode
            wssBinding.TextEncoding = Me.TextEncoding
            wssBinding.FlowTransactions = Me.FlowTransactions
            wssBinding.SecurityMode = Me.SecurityMode
        End Sub

        Protected Overrides ReadOnly Property Properties() As ConfigurationPropertyCollection
            Get
                Dim prop As ConfigurationPropertyCollection = MyBase.Properties
                prop.Add(New ConfigurationProperty(WSStreamedHttpBindingConstants.HostnameComparisonMode, GetType(System.ServiceModel.HostNameComparisonMode), System.ServiceModel.HostNameComparisonMode.StrongWildcard, Nothing, Nothing, System.Configuration.ConfigurationPropertyOptions.None))
                prop.Add(New ConfigurationProperty(WSStreamedHttpBindingConstants.MaxReceivedMessageSize, GetType(System.Int64), Long.MaxValue, Nothing, New System.Configuration.LongValidator(1, 9223372036854775807, False), System.Configuration.ConfigurationPropertyOptions.None))
                prop.Add(New ConfigurationProperty(WSStreamedHttpBindingConstants.MaxBufferSize, GetType(System.Int32), 65536, Nothing, Nothing, System.Configuration.ConfigurationPropertyOptions.None))
                prop.Add(New ConfigurationProperty(WSStreamedHttpBindingConstants.ProxyAddress, GetType(System.Uri), Nothing, Nothing, Nothing, System.Configuration.ConfigurationPropertyOptions.None))
                prop.Add(New ConfigurationProperty(WSStreamedHttpBindingConstants.BypassProxyOnLocal, GetType(System.Boolean), False, Nothing, Nothing, System.Configuration.ConfigurationPropertyOptions.None))
                prop.Add(New ConfigurationProperty(WSStreamedHttpBindingConstants.UseDefaultWebProxy, GetType(System.Boolean), True, Nothing, Nothing, System.Configuration.ConfigurationPropertyOptions.None))
                prop.Add(New ConfigurationProperty(WSStreamedHttpBindingConstants.TransferMode, GetType(StreamedTransferMode), StreamedTransferMode.Streamed, Nothing, Nothing, System.Configuration.ConfigurationPropertyOptions.None))
                prop.Add(New ConfigurationProperty(WSStreamedHttpBindingConstants.TextEncoding, GetType(System.Text.Encoding), "utf-8", New TextEncodingConverter(), Nothing, System.Configuration.ConfigurationPropertyOptions.None))
                prop.Add(New ConfigurationProperty(WSStreamedHttpBindingConstants.FlowTransactions, GetType(System.Boolean), False, Nothing, Nothing, System.Configuration.ConfigurationPropertyOptions.None))
                prop.Add(New ConfigurationProperty(WSStreamedHttpBindingConstants.SecurityMode, GetType(StreamedSecurityMode), StreamedSecurityMode.Transport, Nothing, Nothing, System.Configuration.ConfigurationPropertyOptions.None))
                Return prop
            End Get
        End Property
    End Class
End Namespace