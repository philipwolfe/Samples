﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50727.42
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System.Runtime.Serialization


<System.Runtime.Serialization.DataContractAttribute()> _
Partial Public Class OrbOptionValues
    Inherits Object
    Implements System.Runtime.Serialization.IExtensibleDataObject

    Private extensionDataField As System.Runtime.Serialization.ExtensionDataObject

    Private ComponentPropertiesField As System.Collections.Generic.Dictionary(Of String, Object)

    Public Property ExtensionData() As System.Runtime.Serialization.ExtensionDataObject Implements System.Runtime.Serialization.IExtensibleDataObject.ExtensionData
        Get
            Return Me.extensionDataField
        End Get
        Set(ByVal value As System.Runtime.Serialization.ExtensionDataObject)
            Me.extensionDataField = value
        End Set
    End Property

    <System.Runtime.Serialization.DataMemberAttribute()> _
    Public Property ComponentProperties() As System.Collections.Generic.Dictionary(Of String, Object)
        Get
            Return Me.ComponentPropertiesField
        End Get
        Set(ByVal value As System.Collections.Generic.Dictionary(Of String, Object))
            Me.ComponentPropertiesField = value
        End Set
    End Property
End Class

<System.Runtime.Serialization.DataContractAttribute()> _
Partial Public Class OrbDisplay
    Inherits Object
    Implements System.Runtime.Serialization.IExtensibleDataObject

    Private extensionDataField As System.Runtime.Serialization.ExtensionDataObject

    Private DisplayColorField As Microsoft.Samples.MoodOrb.OrbColor

    Private DisplayMessageField As String

    Private DisplayTypeField As Microsoft.Samples.MoodOrb.OrbAnimationType

    Private PulseInformationField As Microsoft.Samples.MoodOrb.OrbPulseDescriber

    Public Property ExtensionData() As System.Runtime.Serialization.ExtensionDataObject Implements System.Runtime.Serialization.IExtensibleDataObject.ExtensionData
        Get
            Return Me.extensionDataField
        End Get
        Set(ByVal value As System.Runtime.Serialization.ExtensionDataObject)
            Me.extensionDataField = value
        End Set
    End Property

    <System.Runtime.Serialization.DataMemberAttribute()> _
    Public Property DisplayColor() As Microsoft.Samples.MoodOrb.OrbColor
        Get
            Return Me.DisplayColorField
        End Get
        Set(ByVal value As Microsoft.Samples.MoodOrb.OrbColor)
            Me.DisplayColorField = value
        End Set
    End Property

    <System.Runtime.Serialization.DataMemberAttribute()> _
    Public Property DisplayMessage() As String
        Get
            Return Me.DisplayMessageField
        End Get
        Set(ByVal value As String)
            Me.DisplayMessageField = value
        End Set
    End Property

    <System.Runtime.Serialization.DataMemberAttribute()> _
    Public Property DisplayType() As Microsoft.Samples.MoodOrb.OrbAnimationType
        Get
            Return Me.DisplayTypeField
        End Get
        Set(ByVal value As Microsoft.Samples.MoodOrb.OrbAnimationType)
            Me.DisplayTypeField = value
        End Set
    End Property

    <System.Runtime.Serialization.DataMemberAttribute()> _
    Public Property PulseInformation() As Microsoft.Samples.MoodOrb.OrbPulseDescriber
        Get
            Return Me.PulseInformationField
        End Get
        Set(ByVal value As Microsoft.Samples.MoodOrb.OrbPulseDescriber)
            Me.PulseInformationField = value
        End Set
    End Property
End Class

<System.Runtime.Serialization.DataContractAttribute()> _
Partial Public Class OrbColor
    Inherits Object
    Implements System.Runtime.Serialization.IExtensibleDataObject

    Private extensionDataField As System.Runtime.Serialization.ExtensionDataObject

    Private colorValueBField As Integer

    Private colorValueGField As Integer

    Private colorValueRField As Integer

    Public Property ExtensionData() As System.Runtime.Serialization.ExtensionDataObject Implements System.Runtime.Serialization.IExtensibleDataObject.ExtensionData
        Get
            Return Me.extensionDataField
        End Get
        Set(ByVal value As System.Runtime.Serialization.ExtensionDataObject)
            Me.extensionDataField = value
        End Set
    End Property

    <System.Runtime.Serialization.DataMemberAttribute()> _
    Public Property colorValueB() As Integer
        Get
            Return Me.colorValueBField
        End Get
        Set(ByVal value As Integer)
            Me.colorValueBField = value
        End Set
    End Property

    <System.Runtime.Serialization.DataMemberAttribute()> _
    Public Property colorValueG() As Integer
        Get
            Return Me.colorValueGField
        End Get
        Set(ByVal value As Integer)
            Me.colorValueGField = value
        End Set
    End Property

    <System.Runtime.Serialization.DataMemberAttribute()> _
    Public Property colorValueR() As Integer
        Get
            Return Me.colorValueRField
        End Get
        Set(ByVal value As Integer)
            Me.colorValueRField = value
        End Set
    End Property
End Class

<System.Runtime.Serialization.DataContractAttribute()> _
Partial Public Class OrbPulseDescriber
    Inherits Object
    Implements System.Runtime.Serialization.IExtensibleDataObject

    Private extensionDataField As System.Runtime.Serialization.ExtensionDataObject

    Private m_IsForeverField As Boolean

    Private m_PulseColorField As Microsoft.Samples.MoodOrb.OrbColor

    Private m_PulseCountField As Integer

    Public Property ExtensionData() As System.Runtime.Serialization.ExtensionDataObject Implements System.Runtime.Serialization.IExtensibleDataObject.ExtensionData
        Get
            Return Me.extensionDataField
        End Get
        Set(ByVal value As System.Runtime.Serialization.ExtensionDataObject)
            Me.extensionDataField = value
        End Set
    End Property

    <System.Runtime.Serialization.DataMemberAttribute()> _
    Public Property m_IsForever() As Boolean
        Get
            Return Me.m_IsForeverField
        End Get
        Set(ByVal value As Boolean)
            Me.m_IsForeverField = value
        End Set
    End Property

    <System.Runtime.Serialization.DataMemberAttribute()> _
    Public Property m_PulseColor() As Microsoft.Samples.MoodOrb.OrbColor
        Get
            Return Me.m_PulseColorField
        End Get
        Set(ByVal value As Microsoft.Samples.MoodOrb.OrbColor)
            Me.m_PulseColorField = value
        End Set
    End Property

    <System.Runtime.Serialization.DataMemberAttribute()> _
    Public Property m_PulseCount() As Integer
        Get
            Return Me.m_PulseCountField
        End Get
        Set(ByVal value As Integer)
            Me.m_PulseCountField = value
        End Set
    End Property
End Class
<System.Runtime.Serialization.DataContractAttribute()> _
Public Enum OrbAnimationType As Integer
    <System.Runtime.Serialization.DataMemberAttribute()> _
    StaticColor

    <System.Runtime.Serialization.DataMemberAttribute()> _
    Pulse

    <System.Runtime.Serialization.DataMemberAttribute()> _
    Range
End Enum

<System.Runtime.Serialization.DataContractAttribute()> _
Partial Public Class OrbOptions
    Inherits Object
    Implements System.Runtime.Serialization.IExtensibleDataObject

    Private extensionDataField As System.Runtime.Serialization.ExtensionDataObject

    Private ComponentDescriptionField As String

    Private ComponentNameField As String

    Private ComponentPropertiesField As System.Collections.Generic.Dictionary(Of String, Object)

    Public Property ExtensionData() As System.Runtime.Serialization.ExtensionDataObject Implements System.Runtime.Serialization.IExtensibleDataObject.ExtensionData
        Get
            Return Me.extensionDataField
        End Get
        Set(ByVal value As System.Runtime.Serialization.ExtensionDataObject)
            Me.extensionDataField = value
        End Set
    End Property

    <System.Runtime.Serialization.DataMemberAttribute()> _
    Public Property ComponentDescription() As String
        Get
            Return Me.ComponentDescriptionField
        End Get
        Set(ByVal value As String)
            Me.ComponentDescriptionField = value
        End Set
    End Property

    <System.Runtime.Serialization.DataMemberAttribute()> _
    Public Property ComponentName() As String
        Get
            Return Me.ComponentNameField
        End Get
        Set(ByVal value As String)
            Me.ComponentNameField = value
        End Set
    End Property

    <System.Runtime.Serialization.DataMemberAttribute()> _
    Public Property ComponentProperties() As System.Collections.Generic.Dictionary(Of String, Object)
        Get
            Return Me.ComponentPropertiesField
        End Get
        Set(ByVal value As System.Collections.Generic.Dictionary(Of String, Object))
            Me.ComponentPropertiesField = value
        End Set
    End Property
End Class


<System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0"), _
 System.ServiceModel.ServiceContractAttribute()> _
Public Interface IOrbling

    <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IOrbling/GetInformation", ReplyAction:="http://tempuri.org/IOrbling/GetInformationResponse")> _
    Function GetInformation(ByVal Options As Microsoft.Samples.MoodOrb.OrbOptionValues) As Microsoft.Samples.MoodOrb.OrbDisplay

    <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IOrbling/GetOptions", ReplyAction:="http://tempuri.org/IOrbling/GetOptionsResponse")> _
    Function GetOptions() As Microsoft.Samples.MoodOrb.OrbOptions

    <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IOrbling/GetTime", ReplyAction:="http://tempuri.org/IOrbling/GetTimeResponse")> _
    Function GetTime() As System.TimeSpan
End Interface

<System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")> _
Public Interface IOrblingChannel
    Inherits IOrbling, System.ServiceModel.IClientChannel
End Interface

<System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")> _
Partial Public Class OrblingProxy
    Inherits System.ServiceModel.ClientBase(Of IOrbling)
    Implements IOrbling

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal endpointConfigurationName As String)
        MyBase.New(endpointConfigurationName)
    End Sub

    Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As String)
        MyBase.New(endpointConfigurationName, remoteAddress)
    End Sub

    Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
        MyBase.New(endpointConfigurationName, remoteAddress)
    End Sub

    Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
        MyBase.New(binding, remoteAddress)
    End Sub

    Public Function GetInformation(ByVal Options As Microsoft.Samples.MoodOrb.OrbOptionValues) As Microsoft.Samples.MoodOrb.OrbDisplay Implements IOrbling.GetInformation
        Return MyBase.Channel.GetInformation(Options)
    End Function

    Public Function GetOptions() As Microsoft.Samples.MoodOrb.OrbOptions Implements IOrbling.GetOptions
        Return MyBase.Channel.GetOptions
    End Function

    Public Function GetTime() As System.TimeSpan Implements IOrbling.GetTime
        Return MyBase.Channel.GetTime
    End Function
End Class