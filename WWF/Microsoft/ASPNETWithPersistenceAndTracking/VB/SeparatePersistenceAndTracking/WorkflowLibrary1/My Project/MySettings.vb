'--------------------------------------------------------------------------------
' This file is part of the Windows Workflow Foundation Sample Code
'
' Copyright (c) Microsoft Corporation. All rights reserved.
'
' This source code is intended only as a supplement to Microsoft
' Development Tools and/or on-line documentation.  See these other
' materials for detailed information regarding Microsoft code samples.
' 
' THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
' KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
' IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
' PARTICULAR PURPOSE.
'--------------------------------------------------------------------------------

Option Strict Off
Option Explicit On



Public Class MySettings
    Inherits System.Configuration.ApplicationSettingsBase

    Private Shared defaultSettingsInstance As MySettings

    Private Shared syncObject As Object = New Object

    Public Shared ReadOnly Property DefaultInstance() As MySettings
        Get
            If (MySettings.defaultSettingsInstance Is Nothing) Then
                System.Threading.Monitor.Enter(MySettings.syncObject)
                If (MySettings.defaultSettingsInstance Is Nothing) Then
                    Try
                        MySettings.defaultSettingsInstance = New MySettings
                    Finally
                        System.Threading.Monitor.Exit(MySettings.syncObject)
                    End Try
                End If
            End If
            Return MySettings.defaultSettingsInstance
        End Get
    End Property
End Class
