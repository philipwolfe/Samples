
'  Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System

Imports System.ServiceModel.Channels
Imports System.Text
Imports System.Configuration
Imports System.Globalization
Imports System.ServiceModel
Imports System.Collections.Generic

Namespace Microsoft.ServiceModel.Samples
    Public Class WSStreamedHttpBinding
        Inherits Binding

        Dim security As StreamedSecurityMode
        Dim transport As BindingElement
        Dim streamMode As StreamedTransferMode
        Dim flowTx As Boolean

        ' private BindingElements
        Dim httpTransport As HttpTransportBindingElement
        Dim httpsTransport As HttpsTransportBindingElement
        Dim messageEncoding As TextMessageEncodingBindingElement
        Dim transactionFlow As TransactionFlowBindingElement


        Public Sub New()
            Initialize()
        End Sub

        Public Sub New(ByVal configurationName As String)
            Initialize()
            ApplyConfiguration(configurationName)
        End Sub

        Public Property HostnameComparisonMode() As HostnameComparisonMode
            Get
                Return httpTransport.HostnameComparisonMode
            End Get
            Set(ByVal value As HostnameComparisonMode)
                httpTransport.HostnameComparisonMode = value
                httpsTransport.HostnameComparisonMode = value
            End Set
        End Property

        Public Property MaxReceivedMessageSize() As Long
            Get
                Return httpTransport.MaxReceivedMessageSize
            End Get
            Set(ByVal value As Long)
                httpTransport.MaxReceivedMessageSize = value
                httpsTransport.MaxReceivedMessageSize = value
            End Set
        End Property

        Public Property MaxBufferSize() As Integer
            Get
                Return httpTransport.MaxBufferSize
            End Get
            Set(ByVal value As Integer)
                httpTransport.MaxBufferSize = value
                httpsTransport.MaxBufferSize = value
            End Set
        End Property

        Public Property ProxyAddress() As Uri
            Get
                Return httpTransport.ProxyAddress
            End Get
            Set(ByVal value As Uri)
                httpTransport.ProxyAddress = value
                httpsTransport.ProxyAddress = value
            End Set
        End Property

        Public Property BypassProxyOnLocal() As Boolean
            Get
                Return httpTransport.BypassProxyOnLocal
            End Get
            Set(ByVal value As Boolean)
                httpTransport.BypassProxyOnLocal = value
                httpsTransport.BypassProxyOnLocal = value
            End Set
        End Property

        Public Property UseDefaultWebProxy() As Boolean
            Get
                Return httpTransport.UseDefaultWebProxy
            End Get
            Set(ByVal value As Boolean)
                httpTransport.UseDefaultWebProxy = value
                httpsTransport.UseDefaultWebProxy = value
            End Set
        End Property

        Public Property TransferMode() As StreamedTransferMode
            Get
                Return Me.streamMode
            End Get
            Set(ByVal value As StreamedTransferMode)
                Me.streamMode = value
                httpTransport.TransferMode = value
                httpsTransport.TransferMode = value
            End Set
        End Property

        Public Overrides ReadOnly Property Scheme() As String
            Get
                Return "http"
            End Get
        End Property

        Public ReadOnly Property SoapVersion() As EnvelopeVersion
            Get
                Return EnvelopeVersion.Soap12
            End Get
        End Property

        Public Property TextEncoding() As System.Text.Encoding
            Get
                Return messageEncoding.WriteEncoding
            End Get
            Set(ByVal value As System.Text.Encoding)
                messageEncoding.WriteEncoding = value
            End Set
        End Property

        Public Property FlowTransactions() As Boolean
            Get
                Return Me.flowTx
            End Get
            Set(ByVal value As Boolean)
                Me.flowTx = value
            End Set
        End Property

        Public Property SecurityMode() As StreamedSecurityMode
            Get
                Return security
            End Get
            Set(ByVal value As StreamedSecurityMode)
                security = value
                ' use either Http or Https
                If securityMode = StreamedSecurityMode.None Then
                    transport = httpTransport
                Else
                    transport = httpsTransport
                    httpsTransport.RequireClientCertificate = False
                End If
            End Set
        End Property

        Sub Initialize()
            httpTransport = New HttpTransportBindingElement()
            httpsTransport = New HttpsTransportBindingElement()
            transactionFlow = New TransactionFlowBindingElement()
            messageEncoding = New TextMessageEncodingBindingElement()

            ' setting up configurable settings' default values
            Me.MaxReceivedMessageSize = Long.MaxValue
            Me.SecurityMode = StreamedSecurityMode.Transport
            Me.TransferMode = StreamedTransferMode.Streamed

            ' setting up non-configurable settings' default values
            Me.FlowTransactions = True
            transactionFlow.TransactionProtocol = TransactionProtocol.WSAtomicTransactionOctober2004
        End Sub

        Sub ApplyConfiguration(ByVal configurationName As String)
            Dim section As WSStreamedHttpBindingCollectionElement = WSStreamedHttpBindingCollectionElement.GetCollectionElement()
            Dim element As WSStreamedHttpBindingConfigurationElement = section.Bindings(configurationName)
            If element Is Nothing Then
                Throw New ConfigurationErrorsException()
            Else
                element.ApplyConfiguration(Me)
            End If
        End Sub

        Public Overrides Function CreateBindingElements() As BindingElementCollection
            ' return collection of BindingElements
            Dim bindingElements As BindingElementCollection = New BindingElementCollection()

            ' the order of binding elements within the collection is important: layered channels are applied
            ' in the order included, followed by the message encoder, and finally the transport at the end
            If flowTx Then
	            bindingElements.Add(transactionFlow)
            End If
            bindingElements.Add(messageEncoding)

            ' add transport (http or https)
            bindingElements.Add(transport)

            Return bindingElements.Clone()
        End Function
    End Class
End Namespace



