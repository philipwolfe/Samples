'-----------------------------------------------------------------------
'  This file is part of the Microsoft .NET Framework SDK Code Samples.
' 
'  Copyright (C) Microsoft Corporation.  All rights reserved.
' 
'This source code is intended only as a supplement to Microsoft
'Development Tools and/or on-line documentation.  See these other
'materials for detailed information regarding Microsoft code samples.
' 
'THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
'KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
'IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
'PARTICULAR PURPOSE.
'-----------------------------------------------------------------------

Imports System.Configuration.Provider
Imports System.Configuration
Imports System.Drawing

' This class shows a basic implementation of a class to get/set application settings
' via an XML Web Service.  The only real key code here is the SettingsProvider
' attribute on the class indicating that the WebServiceSettingsProvider is
' to be used, and the SerializeSettingAs attribute on some of the classes to
' make sure they're persisted as text. 
'
' This class implements a sample group of settings, used by the SettingsTestForm.
'
' Note that the type name passed to the SettingsProviderAttribtue is NOT 
' just simply a class name, but an Assembly-Qualified name, that also tells
' the .NET framework WHERE to find this class.  Otherwise, you will get an
' exception claiming that the type cannot be found.
'
' Note that in general you'd only want to have one instance of each settings type, so
' you could add a singleton creator/accessor on this type. The settings class automatically 
' created by the Settings Designer uses this pattern. Multiple instances of a given settings 
' class ARE supported, but you would then need to set the SettingsKey property on the settings object
' so that the different instances would map to a different set of values.

<SettingsProvider("Microsoft.Samples.Windows.Forms.WebSettingsClient.WebServiceSettingsProvider, WebSettingsClient")> _
Partial Public Class MyWebSettings
    Inherits System.Configuration.ApplicationSettingsBase

    ' The following properties implement a simple group of settings, for demonstration purposes.
    <SettingsSerializeAs(SettingsSerializeAs.String), UserScopedSetting()> _
    Public Property TextSetting() As String

        Get
            Return CType(Me.Item("TextSetting"), String)
        End Get

        Set(ByVal value As String)
            Me.Item("TextSetting") = value
        End Set

    End Property

    <SettingsSerializeAs(SettingsSerializeAs.String), UserScopedSetting()> _
    Public Property ComboSetting() As Integer

        Get
            Return CType(Me.Item("ComboSetting"), Integer)
        End Get

        Set(ByVal value As Integer)
            Me.Item("ComboSetting") = value
        End Set

    End Property

    <SettingsSerializeAs(SettingsSerializeAs.String), UserScopedSetting()> _
    Public Property CheckSetting1() As Boolean

        Get
            Return CType(Me.Item("CheckSetting1"), Boolean)
        End Get

        Set(ByVal value As Boolean)
            Me.Item("CheckSetting1") = value
        End Set

    End Property

    <SettingsSerializeAs(SettingsSerializeAs.String), UserScopedSetting()> _
    Public Property CheckSetting2() As Boolean

        Get
            Return CType(Me.Item("CheckSetting2"), Boolean)
        End Get

        Set(ByVal value As Boolean)
            Me.Item("CheckSetting2") = value
        End Set

    End Property

End Class
