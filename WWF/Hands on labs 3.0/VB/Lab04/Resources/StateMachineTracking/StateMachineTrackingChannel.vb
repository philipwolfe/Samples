'--------------------------------------------------------------------------------
' This file is a "Sample" as from Windows Workflow Foundation
' Hands on Labs RC
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

'Code ported to VB.net by Serge Luca 
'sergeluca@redwood.be
'www.redwood.be

Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Collections.ObjectModel

Imports System.Text
Imports System.Threading
Imports System.Diagnostics
Imports System.Workflow.ComponentModel
Imports System.Workflow.Activities
Imports System.Workflow.Runtime.Hosting
Imports System.Workflow.Runtime
Imports System.Reflection
Imports System.Workflow.Runtime.Tracking

Public Class StateMachineTrackingChannel
    Inherits TrackingChannel

    Public Sub New(ByVal parameters As TrackingParameters, ByVal service As StateMachineTrackingService)
        Me._service = service
        Me._parameters = parameters
    End Sub

    Protected Overrides Sub Send(ByVal record As TrackingRecord)
        If TypeOf record Is ActivityTrackingRecord Then
            Me._service.Track(Me._parameters.InstanceId, record)
        ElseIf TypeOf record Is WorkflowTrackingRecord Then
            Dim record1 As WorkflowTrackingRecord = DirectCast(record, WorkflowTrackingRecord)
            If (TrackingWorkflowEvent.Changed = record1.TrackingWorkflowEvent) Then
                Dim collection1 As ICollection = DirectCast(record1.EventArgs, ICollection)
                Me._service.Track(Me._parameters.InstanceId, collection1, record1.EventDateTime)
            End If
        End If
    End Sub

    Protected Overrides Sub InstanceCompletedOrTerminated()
    End Sub



    ' Fields
    Private _parameters As TrackingParameters
    Private _service As StateMachineTrackingService

End Class
