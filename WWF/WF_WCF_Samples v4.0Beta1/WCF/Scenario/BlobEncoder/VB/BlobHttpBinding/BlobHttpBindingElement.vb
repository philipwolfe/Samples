'----------------------------------------------------------------
' Copyright (c) Microsoft Corporation.  All rights reserved.
'----------------------------------------------------------------


Imports Microsoft.VisualBasic
Imports System
Imports System.Configuration
Imports System.Globalization
Imports System.ServiceModel.Channels
Imports System.ServiceModel.Configuration
Imports System.Xml

Namespace Microsoft.Samples.BlobMessageEncoder

	Public Class BlobHttpBindingElement
        Inherits StandardBindingElement

		Public Sub New(ByVal configurationName As String)
			MyBase.New(configurationName)
		End Sub

		Public Sub New()
			Me.New(Nothing)
		End Sub

		<ConfigurationProperty(BlobHttpConfigurationStrings.BypassProxyOnLocal, DefaultValue := BlobHttpDefaults.DefaultBypassProxyOnLocal)> _
		Public Property BypassProxyOnLocal() As Boolean
			Get
				Return (CBool(MyBase.Item(BlobHttpConfigurationStrings.BypassProxyOnLocal)))
			End Get
			Set(ByVal value As Boolean)
				MyBase.Item(BlobHttpConfigurationStrings.BypassProxyOnLocal) = value
			End Set
		End Property

		<ConfigurationProperty(BlobHttpConfigurationStrings.HostNameComparisonMode, DefaultValue := BlobHttpDefaults.DefaultHostNameComparisonMode), ServiceModelEnumValidator(GetType(HostNameComparisonModeHelper))> _
		Public Property HostNameComparisonMode() As System.ServiceModel.HostNameComparisonMode
			Get
				Return (CType(MyBase.Item(BlobHttpConfigurationStrings.HostNameComparisonMode), System.ServiceModel.HostNameComparisonMode))
			End Get
			Set(ByVal value As System.ServiceModel.HostNameComparisonMode)
				MyBase.Item(BlobHttpConfigurationStrings.HostNameComparisonMode) = value
			End Set
		End Property

		<ConfigurationProperty(BlobHttpConfigurationStrings.MaxBufferPoolSize, DefaultValue := BlobHttpDefaults.DefaultMaxBufferPoolSize), LongValidator(MinValue := 0)> _
		Public Property MaxBufferPoolSize() As Long
			Get
				Return (CLng(Fix(MyBase.Item(BlobHttpConfigurationStrings.MaxBufferPoolSize))))
			End Get
			Set(ByVal value As Long)
				MyBase.Item(BlobHttpConfigurationStrings.MaxBufferPoolSize) = value
			End Set
		End Property

		<ConfigurationProperty(BlobHttpConfigurationStrings.MaxBufferSize, DefaultValue := BlobHttpDefaults.DefaultMaxBufferSize), IntegerValidator(MinValue := 1)> _
		Public Property MaxBufferSize() As Integer
			Get
				Return (CInt(Fix(MyBase.Item(BlobHttpConfigurationStrings.MaxBufferSize))))
			End Get
			Set(ByVal value As Integer)
				MyBase.Item(BlobHttpConfigurationStrings.MaxBufferSize) = value
			End Set
		End Property

		<ConfigurationProperty(BlobHttpConfigurationStrings.MaxReceivedMessageSize, DefaultValue := BlobHttpDefaults.DefaultMaxReceivedMessageSize), LongValidator(MinValue := 1)> _
		Public Property MaxReceivedMessageSize() As Long
			Get
				Return (CLng(Fix(MyBase.Item(BlobHttpConfigurationStrings.MaxReceivedMessageSize))))
			End Get
			Set(ByVal value As Long)
				MyBase.Item(BlobHttpConfigurationStrings.MaxReceivedMessageSize) = value
			End Set
		End Property

        <ConfigurationProperty(BlobHttpConfigurationStrings.ProxyAddress, DefaultValue:=BlobHttpDefaults.DefaultProxyAddress), AddressValidator()> _
        Public Property ProxyAddress() As System.Uri
            Get
                Return (CType(MyBase.Item(BlobHttpConfigurationStrings.ProxyAddress), System.Uri))
            End Get
            Set(ByVal value As System.Uri)
                MyBase.Item(BlobHttpConfigurationStrings.ProxyAddress) = value
            End Set
        End Property

        <ConfigurationProperty(BlobHttpConfigurationStrings.ReaderQuotas, DefaultValue:=BlobHttpDefaults.DefaultReaderQuotas)> _
        Public ReadOnly Property ReaderQuotas() As XmlDictionaryReaderQuotasElement
            Get
                Return CType(MyBase.Item(BlobHttpConfigurationStrings.ReaderQuotas), XmlDictionaryReaderQuotasElement)
            End Get
        End Property

		<ConfigurationProperty(BlobHttpConfigurationStrings.TransferMode, DefaultValue := BlobHttpDefaults.DefaultTransferMode), ServiceModelEnumValidator(GetType(TransferModeHelper))> _
		Public Property TransferMode() As System.ServiceModel.TransferMode
			Get
				Return (CType(MyBase.Item(BlobHttpConfigurationStrings.TransferMode), System.ServiceModel.TransferMode))
			End Get
			Set(ByVal value As System.ServiceModel.TransferMode)
				MyBase.Item(BlobHttpConfigurationStrings.TransferMode) = value
			End Set
		End Property

		<ConfigurationProperty(BlobHttpConfigurationStrings.UseDefaultWebProxy, DefaultValue := BlobHttpDefaults.DefaultUseDefaultWebProxy)> _
		Public Property UseDefaultWebProxy() As Boolean
			Get
				Return (CBool(MyBase.Item(BlobHttpConfigurationStrings.UseDefaultWebProxy)))
			End Get
			Set(ByVal value As Boolean)
				MyBase.Item(BlobHttpConfigurationStrings.UseDefaultWebProxy) = value
			End Set
		End Property

		Protected Overrides ReadOnly Property BindingElementType() As Type
			Get
				Return GetType(BlobHttpBinding)
			End Get
		End Property

		Protected Overrides ReadOnly Property Properties() As ConfigurationPropertyCollection
			Get
                Dim PropertyColl As ConfigurationPropertyCollection = MyBase.Properties

                PropertyColl.Add(New ConfigurationProperty(BlobHttpConfigurationStrings.HostNameComparisonMode, GetType(System.ServiceModel.HostNameComparisonMode), BlobHttpDefaults.DefaultHostNameComparisonMode))
                PropertyColl.Add(New ConfigurationProperty(BlobHttpConfigurationStrings.MaxBufferSize, GetType(Integer), BlobHttpDefaults.DefaultMaxBufferSize))
                PropertyColl.Add(New ConfigurationProperty(BlobHttpConfigurationStrings.MaxBufferPoolSize, GetType(Long), BlobHttpDefaults.DefaultMaxBufferPoolSize))
                PropertyColl.Add(New ConfigurationProperty(BlobHttpConfigurationStrings.MaxReceivedMessageSize, GetType(Long), BlobHttpDefaults.DefaultMaxReceivedMessageSize))
                PropertyColl.Add(New ConfigurationProperty(BlobHttpConfigurationStrings.TransferMode, GetType(System.ServiceModel.TransferMode), BlobHttpDefaults.DefaultTransferMode))
                PropertyColl.Add(New ConfigurationProperty(BlobHttpConfigurationStrings.ReaderQuotas, GetType(XmlDictionaryReaderQuotasElement), BlobHttpDefaults.DefaultReaderQuotas))

                Return PropertyColl
			End Get
		End Property

		Protected Overrides Sub InitializeFrom(ByVal binding As Binding)
			MyBase.InitializeFrom(binding)
			Dim BlobHttpBinding As BlobHttpBinding = (CType(binding, BlobHttpBinding))
			Me.HostNameComparisonMode = BlobHttpBinding.HostNameComparisonMode
			Me.MaxBufferSize = BlobHttpBinding.MaxBufferSize
			Me.MaxBufferPoolSize = BlobHttpBinding.MaxBufferPoolSize
			Me.MaxReceivedMessageSize = BlobHttpBinding.MaxReceivedMessageSize
			Me.TransferMode = BlobHttpBinding.TransferMode

			' Copy reader quotas over.
			Me.ReaderQuotas.MaxDepth = BlobHttpBinding.ReaderQuotas.MaxDepth
			Me.ReaderQuotas.MaxStringContentLength = BlobHttpBinding.ReaderQuotas.MaxStringContentLength
			Me.ReaderQuotas.MaxArrayLength = BlobHttpBinding.ReaderQuotas.MaxArrayLength
			Me.ReaderQuotas.MaxBytesPerRead = BlobHttpBinding.ReaderQuotas.MaxBytesPerRead
			Me.ReaderQuotas.MaxNameTableCharCount = BlobHttpBinding.ReaderQuotas.MaxNameTableCharCount
		End Sub

		Protected Overrides Sub OnApplyConfiguration(ByVal binding As Binding)
			If (binding Is Nothing) Then
				Throw New System.ArgumentNullException("binding")
			End If
			If (binding.GetType() IsNot GetType(BlobHttpBinding)) Then
				Throw New System.ArgumentException(String.Format(CultureInfo.CurrentCulture, "Invalid type for binding. Expected type: {0}. Type passed in: {1}.", GetType(BlobHttpBinding).AssemblyQualifiedName, binding.GetType().AssemblyQualifiedName))
			End If
			Dim BlobHttpBinding As BlobHttpBinding = (CType(binding, BlobHttpBinding))
			BlobHttpBinding.HostNameComparisonMode = Me.HostNameComparisonMode
			BlobHttpBinding.MaxBufferSize = Me.MaxBufferSize
			BlobHttpBinding.MaxBufferPoolSize = Me.MaxBufferPoolSize
			BlobHttpBinding.MaxReceivedMessageSize = Me.MaxReceivedMessageSize
			BlobHttpBinding.TransferMode = Me.TransferMode

			' Copy reader quotas over if set from config.
			If Me.ReaderQuotas.MaxDepth <> 0 Then
				BlobHttpBinding.ReaderQuotas.MaxDepth = Me.ReaderQuotas.MaxDepth
			End If
			If Me.ReaderQuotas.MaxStringContentLength <> 0 Then
				BlobHttpBinding.ReaderQuotas.MaxStringContentLength = Me.ReaderQuotas.MaxStringContentLength
			End If
			If Me.ReaderQuotas.MaxArrayLength <> 0 Then
				BlobHttpBinding.ReaderQuotas.MaxArrayLength = Me.ReaderQuotas.MaxArrayLength
			End If
			If Me.ReaderQuotas.MaxBytesPerRead <> 0 Then
				BlobHttpBinding.ReaderQuotas.MaxBytesPerRead = Me.ReaderQuotas.MaxBytesPerRead
			End If
			If Me.ReaderQuotas.MaxNameTableCharCount <> 0 Then
				BlobHttpBinding.ReaderQuotas.MaxNameTableCharCount = Me.ReaderQuotas.MaxNameTableCharCount
			End If
		End Sub
	End Class


End Namespace
