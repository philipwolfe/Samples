'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated by a tool.
'     Runtime Version:2.0.40120.0
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </autogenerated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On



Partial Public Class MySettings
    Inherits System.Configuration.ApplicationSettingsBase

    Private Shared m_DefaultInstance As MySettings

    Private Shared m_SyncObject As Object = New Object

    Public Shared ReadOnly Property DefaultInstance() As MySettings
        Get
            If (MySettings.m_DefaultInstance Is Nothing) Then
                System.Threading.Monitor.Enter(MySettings.m_SyncObject)
                If (MySettings.m_DefaultInstance Is Nothing) Then
                    Try
                        MySettings.m_DefaultInstance = New MySettings
                    Finally
                        System.Threading.Monitor.Exit(MySettings.m_SyncObject)
                    End Try
                End If
            End If
            Return MySettings.m_DefaultInstance
        End Get
    End Property
End Class
