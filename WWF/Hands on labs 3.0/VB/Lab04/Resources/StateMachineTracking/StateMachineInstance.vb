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

Public Class StateMachineInstance
    Private _completedState As String
    Private currentStateQualifiedId As String

    Private _initialState As String
    Private _instanceId As Guid
    Private _isRunning As Boolean
    Private stateMachineTrackingService As StateMachineTrackingService
    Private _workflowInstance As WorkflowInstance
    Private WorkflowRuntime As WorkflowRuntime
    Private workflowType As Type

    Friend Sub New(ByVal WorkflowRuntime As WorkflowRuntime, ByVal workflowType As Type, ByVal instanceId As Guid, ByVal stateTrackingService As StateMachineTrackingService)
        Me.WorkflowRuntime = WorkflowRuntime
        Me.workflowType = workflowType
        Me._instanceId = instanceId
        Me.stateMachineTrackingService = stateTrackingService
    End Sub

    Private Sub CheckRunning()
        If Not Me.isRunning Then
            Throw New InvalidOperationException("StateMachineInstance is not running")
        End If
    End Sub

    Friend Function FindActivity(ByVal id As String) As Activity
        Return StateMachineInstance.FindActivity(Me.StateMachineWorkflow, id)
    End Function

    Friend Shared Function FindActivity(ByVal parent As CompositeActivity, ByVal id As String) As Activity
        Using enumerator1 As IEnumerator(Of Activity) = parent.EnabledActivities.GetEnumerator
            Do While enumerator1.MoveNext
                Dim activity1 As Activity = enumerator1.Current
                If activity1.Name.Equals(id) Then
                    Return activity1
                End If
                If TypeOf activity1 Is CompositeActivity Then
                    Dim activity2 As Activity = StateMachineInstance.FindActivity(DirectCast(activity1, CompositeActivity), id)
                    If (Not activity2 Is Nothing) Then
                        Return activity2
                    End If
                End If
            Loop
        End Using
        Return Nothing
    End Function

    Friend Function FindActivityByQualifiedId(ByVal qualifiedId As String) As Activity
        Return StateMachineInstance.FindActivityByQualifiedId(Me.StateMachineWorkflow, qualifiedId)
    End Function

    Friend Shared Function FindActivityByQualifiedId(ByVal parent As CompositeActivity, ByVal qualifiedId As String) As Activity
        Using enumerator1 As IEnumerator(Of Activity) = parent.EnabledActivities.GetEnumerator
            Do While enumerator1.MoveNext
                Dim activity1 As Activity = enumerator1.Current
                If activity1.QualifiedName.Equals(qualifiedId) Then
                    Return activity1
                End If
                If TypeOf activity1 Is CompositeActivity Then
                    Dim activity2 As Activity = StateMachineInstance.FindActivityByQualifiedId(DirectCast(activity1, CompositeActivity), qualifiedId)
                    If (Not activity2 Is Nothing) Then
                        Return activity2
                    End If
                End If
            Loop
        End Using
        Return Nothing
    End Function


    Private Sub FindMessagesAllowed(ByVal parent As CompositeActivity, ByVal messages As List(Of String))
        Using enumerator1 As IEnumerator(Of Activity) = parent.EnabledActivities.GetEnumerator
            Do While enumerator1.MoveNext
                Dim activity1 As Activity = enumerator1.Current
                If TypeOf activity1 Is HandleExternalEventActivity Then
                    Dim text1 As String = DirectCast(activity1, HandleExternalEventActivity).EventName
                    If (Not text1 Is Nothing) Then
                        messages.Add(text1)
                    End If
                ElseIf TypeOf activity1 Is CompositeActivity Then
                    Me.FindMessagesAllowed(DirectCast(activity1, CompositeActivity), messages)
                End If
            Loop
        End Using
    End Sub

    Private Sub FindSetStates(ByVal parent As CompositeActivity, ByVal states As List(Of StateActivity))
        Using enumerator1 As IEnumerator(Of Activity) = parent.EnabledActivities.GetEnumerator
            Do While enumerator1.MoveNext
                Dim activity1 As Activity = enumerator1.Current
                If TypeOf activity1 Is SetStateActivity Then
                    Dim activity2 As StateActivity = DirectCast(Me.FindActivityByQualifiedId(DirectCast(activity1, SetStateActivity).TargetStateName), StateActivity)
                    If (Not activity2 Is Nothing) Then
                        states.Add(activity2)
                    End If
                ElseIf TypeOf activity1 Is CompositeActivity Then
                    Me.FindSetStates(DirectCast(activity1, CompositeActivity), states)
                End If
            Loop
        End Using
    End Sub


    Private Sub FindStates(ByVal parent As CompositeActivity, ByVal states As List(Of StateActivity))
        Using enumerator1 As IEnumerator(Of Activity) = parent.EnabledActivities.GetEnumerator
            Do While enumerator1.MoveNext
                Dim activity1 As Activity = enumerator1.Current
                If TypeOf activity1 Is StateActivity Then
                    states.Add(DirectCast(activity1, StateActivity))
                ElseIf TypeOf activity1 Is CompositeActivity Then
                    Me.FindStates(DirectCast(activity1, CompositeActivity), states)
                End If
            Loop
        End Using
    End Sub


    Public Function GetStates() As StateActivity()
        Me.CheckRunning()
        Dim list1 As New List(Of StateActivity)
        Me.FindStates(Me.StateMachineWorkflow, list1)
        Return list1.ToArray
    End Function

    Public Property CompletedState() As String
        Get
            Return Me._completedState
        End Get
        Set(ByVal value As String)
            Me._completedState = value
        End Set
    End Property

    Public ReadOnly Property CurrentState() As StateActivity
        Get
            Me.CheckRunning()
            Dim activity1 As StateMachineWorkflowActivity = Me.StateMachineWorkflow
            Return DirectCast(Me.FindActivityByQualifiedId(Me.currentStateQualifiedId), StateActivity)
        End Get
    End Property


    Public Property InitialState() As String
        Get
            Return Me._initialState
        End Get
        Set(ByVal value As String)
            Me._initialState = value
        End Set
    End Property


    Public ReadOnly Property InstanceId() As Guid
        Get
            Return Me._instanceId
        End Get
    End Property

    Friend Property IsRunning() As Boolean
        Get
            Return Me._isRunning
        End Get
        Set(ByVal value As Boolean)
            Me._isRunning = value
        End Set
    End Property


    Public ReadOnly Property MessagesAllowed() As ReadOnlyCollection(Of String)
        Get
            Me.CheckRunning()
            Dim list1 As New List(Of String)
            Dim activity1 As Activity
            For Each activity1 In Me.CurrentState.EnabledActivities
                If TypeOf activity1 Is EventDrivenActivity Then
                    Me.FindMessagesAllowed(DirectCast(activity1, CompositeActivity), list1)
                End If
            Next
            Dim activity2 As CompositeActivity = Me.CurrentState.Parent
            Do While (Not activity2 Is Nothing)
                Dim activity3 As Activity
                For Each activity3 In activity2.EnabledActivities
                    If TypeOf activity3 Is EventDrivenActivity Then
                        Me.FindMessagesAllowed(DirectCast(activity3, CompositeActivity), list1)
                    End If
                Next
                activity2 = activity2.Parent
            Loop
            Return list1.AsReadOnly
        End Get
    End Property

    Public ReadOnly Property PossibleStateTransitions() As StateActivity()
        Get
            Me.CheckRunning()
            Dim list1 As New List(Of StateActivity)
            Dim activity1 As Activity
            For Each activity1 In Me.CurrentState.EnabledActivities
                If TypeOf activity1 Is EventDrivenActivity Then
                    Me.FindSetStates(DirectCast(activity1, CompositeActivity), list1)
                End If
            Next
            Dim activity2 As CompositeActivity = Me.CurrentState
            Do While (Not activity2 Is Nothing)
                Dim activity3 As Activity
                For Each activity3 In activity2.EnabledActivities
                    If TypeOf activity3 Is EventDrivenActivity Then
                        Me.FindSetStates(DirectCast(activity3, CompositeActivity), list1)
                    End If
                Next
                activity2 = activity2.Parent
            Loop
            Return list1.ToArray
        End Get
    End Property

    Friend ReadOnly Property StateMachineWorkflow() As StateMachineWorkflowActivity
        Get
            Me.CheckRunning()
            Return DirectCast(Me.WorkflowInstance.GetWorkflowDefinition, StateMachineWorkflowActivity)
        End Get
    End Property

    Public ReadOnly Property WorkflowInstance() As WorkflowInstance
        Get
            Me.CheckRunning()
            If (Me._workflowInstance Is Nothing) Then
                Me._workflowInstance = Me.WorkflowRuntime.GetWorkflow(Me.instanceId)
            End If
            Return Me._workflowInstance
        End Get
    End Property
    Friend Sub OnEventDrivenClosed(ByVal e As ActivityEventArgs)
        If (Not Me.EventDrivenClosedEvent Is Nothing) Then
            RaiseEvent EventDrivenClosed(Me, e)

        End If
    End Sub

    Friend Sub OnEventDrivenExecuting(ByVal e As ActivityEventArgs)
        If (Not Me.EventDrivenExecutingEvent Is Nothing) Then
            RaiseEvent EventDrivenExecuting(Me, e)
        End If
    End Sub

    Friend Sub OnStateChanged(ByVal e As ActivityEventArgs)
        If (Not Me.StateChangedEvent Is Nothing) Then
            Dim num1 As Integer = 0
            Do While (num1 < 10)
                Thread.Sleep(10)
                num1 += 1
            Loop
            RaiseEvent StateChanged(Me, e)
        End If
    End Sub
    Friend Sub OnStateClosed(ByVal e As ActivityEventArgs)
        If (Not Me.StateClosedEvent Is Nothing) Then
            RaiseEvent StateClosed(Me, e)
        End If
    End Sub

    Friend Sub OnStateExecuting(ByVal e As ActivityEventArgs)
        Me.currentStateQualifiedId = e.QualifiedId
        If (Not Me.StateExecutingEvent Is Nothing) Then
            Dim num1 As Integer = 0
            Do While (num1 < 10)
                Thread.Sleep(10)
                num1 += 1
            Loop
            RaiseEvent StateExecuting(Me, e)
        End If
    End Sub

    Public Sub StartWorkflow()
        Dim instance1 As WorkflowInstance = Me.WorkflowRuntime.CreateWorkflow(Me.workflowType, Nothing, Me.instanceId)
        instance1.Start()
        Me.initialState = Me.StateMachineWorkflow.InitialStateName
        Me.completedState = Me.StateMachineWorkflow.CompletedStateName
        Me._workflowInstance = instance1
        Me.isRunning = True
    End Sub







    ' Events
    Public Event EventDrivenClosed As EventHandler(Of ActivityEventArgs)
    Public Event EventDrivenExecuting As EventHandler(Of ActivityEventArgs)
    Public Event StateChanged As EventHandler(Of ActivityEventArgs)
    Public Event StateClosed As EventHandler(Of ActivityEventArgs)
    Public Event StateExecuting As EventHandler(Of ActivityEventArgs)




End Class


