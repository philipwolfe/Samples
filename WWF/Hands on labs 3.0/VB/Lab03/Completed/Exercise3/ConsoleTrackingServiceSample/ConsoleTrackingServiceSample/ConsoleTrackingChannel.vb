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

Imports System
Imports System.IO
Imports System.Workflow.Runtime
Imports System.Workflow.Runtime.Tracking
Imports System.Workflow.ComponentModel
Imports System.Workflow.Runtime.Hosting

Public Class ConsoleTrackingChannel
    Inherits TrackingChannel

    Private parameters As TrackingParameters = Nothing

    Protected Sub New()
        MyBase.new()
    End Sub

    Public Sub New(ByVal parameters As TrackingParameters)
        MyBase.New()
        Me.parameters = parameters
    End Sub


    Protected Overrides Sub InstanceCompletedOrTerminated()
        WriteTitle("Workflow Instance Completed or Terminated")
    End Sub

    Protected Overrides Sub Send(ByVal record As TrackingRecord)
        ' filter on record type
        If (TypeOf (record) Is WorkflowTrackingRecord) Then
            WriteWorkflowTrackingRecord(CType(record, WorkflowTrackingRecord))
        End If
        If (TypeOf (record) Is ActivityTrackingRecord) Then
            WriteActivityTrackingRecord(CType(record, ActivityTrackingRecord))
        End If
        If (TypeOf (record) Is UserTrackingRecord) Then
            WriteUserTrackingRecord(CType(record, UserTrackingRecord))
        End If
    End Sub

#Region "support-code"

    Private Shared Sub WriteTitle(ByVal title As String)
        Console.WriteLine(vbLf & "******************************************")
        Console.WriteLine(vbTab & title)
        Console.WriteLine("******************************************")
    End Sub

    Private Shared Sub WriteWorkflowTrackingRecord(ByVal workflowTrackingRecord As WorkflowTrackingRecord)
        WriteTitle("Workflow Tracking Record")
        Console.WriteLine("EventDateTime: " & workflowTrackingRecord.EventDateTime.ToString)
        Console.WriteLine("Status: " & workflowTrackingRecord.TrackingWorkflowEvent.ToString)
    End Sub

    Private Shared Sub WriteActivityTrackingRecord(ByVal activityTrackingRecord As ActivityTrackingRecord)
        WriteTitle("Activity Tracking Record")
        Console.WriteLine("EventDateTime: " & activityTrackingRecord.EventDateTime.ToString)
        Console.WriteLine("QualifiedName: " & activityTrackingRecord.QualifiedName.ToString)
        Console.WriteLine("Type: " & activityTrackingRecord.ActivityType.ToString)
        Console.WriteLine("Status: " & activityTrackingRecord.ExecutionStatus.ToString)
    End Sub

    Private Shared Sub WriteUserTrackingRecord(ByVal userTrackingRecord As UserTrackingRecord)
        WriteTitle("User Activity Record")
        Console.WriteLine("EventDateTime: " & userTrackingRecord.EventDateTime.ToString)
        Console.WriteLine("QualifiedName: " & userTrackingRecord.QualifiedName.ToString)
        Console.WriteLine("ActivityType: " & userTrackingRecord.ActivityType.FullName.ToString)
        Console.WriteLine("Args: " & userTrackingRecord.UserData.ToString)
    End Sub

#End Region

End Class