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

Imports System.Workflow.Runtime.Tracking
Public Class StateMachineTrackingService
    Inherits TrackingService



    Private stateMachineInstance As StateMachineInstance
    Private trackingRecord As TrackingRecord

    Private container As WorkflowRuntime
    Private trackedInstances As Dictionary(Of Guid, StateMachineInstance)


    Public Sub New(ByVal container As WorkflowRuntime)

        Me.trackedInstances = New Dictionary(Of Guid, StateMachineInstance)
        Me.container = container
        Dim runtime1 As WorkflowRuntime = Me.container
        AddHandler runtime1.WorkflowCreated, New EventHandler(Of WorkflowEventArgs)(AddressOf Me.WorkflowCreated)
        AddHandler runtime1.WorkflowCompleted, New EventHandler(Of WorkflowCompletedEventArgs)(AddressOf Me.WorkflowCompleted)
        AddHandler runtime1.WorkflowTerminated, New EventHandler(Of WorkflowTerminatedEventArgs)(AddressOf Me.WorkflowTerminated)
        Me.container.AddService(Me)

    End Sub

    Protected Overloads Overrides Function GetProfile(ByVal workflowInstanceId As System.Guid) As System.Workflow.Runtime.Tracking.TrackingProfile

        Return Nothing

    End Function

    Protected Overloads Overrides Function GetProfile(ByVal workflowType As System.Type, ByVal profileVersionId As System.Version) As System.Workflow.Runtime.Tracking.TrackingProfile

        Dim profile1 As New TrackingProfile
        profile1.Version = New Version("1.0")
        Dim point1 As New ActivityTrackPoint
        Dim location1 As New ActivityTrackingLocation(GetType(Activity))
        location1.MatchDerivedTypes = True
        Dim status1 As ActivityExecutionStatus
        For Each status1 In [Enum].GetValues(GetType(ActivityExecutionStatus))
            location1.ExecutionStatusEvents.Add(status1)
        Next
        point1.MatchingLocations.Add(location1)
        profile1.ActivityTrackPoints.Add(point1)
        Return profile1

    End Function

    Protected Overrides Function GetTrackingChannel(ByVal parameters As System.Workflow.Runtime.Tracking.TrackingParameters) As System.Workflow.Runtime.Tracking.TrackingChannel

        Return New StateMachineTrackingChannel(parameters, Me)


    End Function

    Public Function RegisterInstance(ByVal workflowType As Type, ByVal instanceId As Guid) As StateMachineInstance
        Dim instance1 As New StateMachineInstance(Me.container, workflowType, instanceId, Me)
        SyncLock Me.trackedInstances
            Me.trackedInstances.Item(instanceId) = instance1
        End SyncLock
        Return instance1
    End Function

    Public Overridable Sub Track(ByVal instanceId As Guid, ByVal record As TrackingRecord)
        If Me.trackedInstances.ContainsKey(instanceId) Then
            Dim instance1 As StateMachineInstance = Me.trackedInstances.Item(instanceId)
            Dim record1 As ActivityTrackingRecord = TryCast(record, ActivityTrackingRecord)
            If (Not record1 Is Nothing) Then
                Select Case record1.ExecutionStatus
                    Case ActivityExecutionStatus.Executing
                        Me.TrackExecuting(instance1, record1)
                        Return
                    Case ActivityExecutionStatus.Canceling
                        Return
                    Case ActivityExecutionStatus.Closed
                        Me.TrackClosed(instance1, record1)
                        Return
                End Select
            End If
        End If
    End Sub

    Public Overridable Sub Track(ByVal instanceId As Guid, ByVal modelChanges As ICollection, ByVal changeDateTime As DateTime)
        Console.WriteLine("Dynamic update is applied")
    End Sub

    Private Sub TrackClosed(ByVal state As Object)
        Dim data1 As TrackingData = DirectCast(state, TrackingData)
        Dim instance1 As StateMachineInstance = data1.StateMachineInstance
        Dim record1 As ActivityTrackingRecord = TryCast(data1.TrackingRecord, ActivityTrackingRecord)
        If (Not record1 Is Nothing) Then
            If record1.ActivityType.Equals(GetType(StateActivity)) Then
                instance1.OnStateClosed(New ActivityEventArgs(record1.ActivityType, record1.QualifiedName))
            ElseIf record1.ActivityType.Equals(GetType(EventDrivenActivity)) Then
                instance1.OnEventDrivenClosed(New ActivityEventArgs(record1.ActivityType, record1.QualifiedName))
            End If
        End If
    End Sub

    Private Sub TrackClosed(ByVal instance As StateMachineInstance, ByVal record As ActivityTrackingRecord)
        Dim data1 As New TrackingData(instance, record)
        ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Me.TrackClosed), data1)
    End Sub
    Private Sub TrackExecuting(ByVal state As Object)
        Dim data1 As TrackingData = DirectCast(state, TrackingData)
        Dim instance1 As StateMachineInstance = data1.StateMachineInstance
        Dim record1 As ActivityTrackingRecord = TryCast(data1.TrackingRecord, ActivityTrackingRecord)
        If (Not record1 Is Nothing) Then
            If record1.ActivityType.Equals(GetType(StateActivity)) Then
                instance1.OnStateExecuting(New ActivityEventArgs(record1.ActivityType, record1.QualifiedName))
                instance1.OnStateChanged(New ActivityEventArgs(record1.ActivityType, record1.QualifiedName))
            ElseIf record1.ActivityType.Equals(GetType(EventDrivenActivity)) Then
                instance1.OnEventDrivenExecuting(New ActivityEventArgs(record1.ActivityType, record1.QualifiedName))
            End If
        End If
    End Sub

    Private Sub TrackExecuting(ByVal instance As StateMachineInstance, ByVal record As ActivityTrackingRecord)
        Dim data1 As New TrackingData(instance, record)
        ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Me.TrackExecuting), data1)
    End Sub

    Protected Overrides Function TryGetProfile(ByVal workflowType As Type, ByRef profile As TrackingProfile) As Boolean
        profile = Me.GetProfile(workflowType, New Version("1.0"))
        Return True
    End Function


    Protected Overrides Function TryReloadProfile(ByVal workflowType As Type, ByVal workflowInstanceId As Guid, ByRef profile As TrackingProfile) As Boolean
        profile = Nothing
        Return False
    End Function
    Public Sub UnregisterInstance(ByVal instanceId As Guid)
        If Me.trackedInstances.ContainsKey(instanceId) Then
            SyncLock Me.trackedInstances
                Me.trackedInstances.Remove(instanceId)
            End SyncLock
        End If
    End Sub

    'Shared Sub OnWorkflowCompleted(ByVal sender As Object, ByVal e As WorkflowCompletedEventArgs)
    Private Sub WorkflowCompleted(ByVal sender As Object, ByVal instance As WorkflowCompletedEventArgs)
        Me.UnregisterInstance(instance.WorkflowInstance.InstanceId)
    End Sub

    Private Sub WorkflowCreated(ByVal sender As Object, ByVal instance As WorkflowEventArgs)

        If Me.trackedInstances.ContainsKey(instance.WorkflowInstance.InstanceId) Then
            Dim instance1 As StateMachineInstance = Me.trackedInstances.Item(instance.WorkflowInstance.InstanceId)

            instance1.IsRunning = True
        End If
    End Sub

    Private Sub WorkflowTerminated(ByVal sender As Object, ByVal instance As WorkflowTerminatedEventArgs)
        Me.UnregisterInstance(instance.WorkflowInstance.InstanceId)
    End Sub









    Private Class TrackingData
        ' Methods




        Public Sub New(ByVal stateMachineInstance As StateMachineInstance, ByVal trackingRecord As TrackingRecord)
            Me._stateMachineInstance = stateMachineInstance
            Me._trackingRecord = trackingRecord
        End Sub

        Public ReadOnly Property TrackingRecord() As TrackingRecord
            Get
                Return Me._trackingRecord
            End Get
        End Property
        Public ReadOnly Property StateMachineInstance() As StateMachineInstance
            Get
                Return Me._stateMachineInstance
            End Get
        End Property



        ' Fields
        Private _stateMachineInstance As StateMachineInstance
        Private _trackingRecord As TrackingRecord
    End Class


End Class
