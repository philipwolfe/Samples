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
Imports System.Threading
Imports System.Workflow.ComponentModel
Imports System.Workflow.Runtime
Imports System.Workflow.Activities
Imports System.Windows.Forms

<Serializable()> _
Public Class VotingEventArgs
    Inherits ExternalDataEventArgs

    ' Methods
    Public Sub New(ByVal InstanceID As Guid, ByVal [alias] As String)
        MyBase.New(InstanceID)
        Me.Alias = [alias]
    End Sub

    ' Properties
    Public Property [Alias]() As String
        Get
            Return Me.anAlias
        End Get
        Set(ByVal value As String)
            Me.anAlias = value
        End Set
    End Property


    ' Fields
    Private anAlias As String
End Class

<ExternalDataExchange()> _
Public Interface IVotingService
    ' Events
    Event ApproveProposal As EventHandler(Of VotingEventArgs)
    Event RejectProposal As EventHandler(Of VotingEventArgs)

    ' Methods
    Sub CreateBallot(ByVal [alias] As String)
End Interface

Public Class VotingService
    Implements IVotingService

    Public Event ApproveProposal(ByVal sender As Object, ByVal e As VotingEventArgs) Implements IVotingService.ApproveProposal
    Public Event RejectProposal(ByVal sender As Object, ByVal e As VotingEventArgs) Implements IVotingService.RejectProposal

    Public Sub CreateBallot(ByVal [alias] As String) Implements IVotingService.CreateBallot

        Console.WriteLine(("Ballot created for " & [alias] & "."))
        ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Me.ShowVotingDialog), New VotingEventArgs(WorkflowEnvironment.WorkflowInstanceId, [alias]))
    End Sub

    Public Sub ShowVotingDialog(ByVal o As Object)

        Dim args1 As VotingEventArgs = TryCast(o, VotingEventArgs)
        Dim guid1 As Guid = args1.InstanceId
        Dim text1 As String = args1.Alias
        Dim result1 As DialogResult = MessageBox.Show(("Approve Proposal," & text1 & "?"), (text1 & " Ballot"), MessageBoxButtons.YesNo)

        If (result1 = DialogResult.Yes) Then
            If (Not Me.ApproveProposalEvent Is Nothing) Then
                Me.ApproveProposalEvent.Invoke(Nothing, args1)
            End If

        ElseIf (Not Me.RejectProposalEvent Is Nothing) Then
            Me.RejectProposalEvent.Invoke(Nothing, args1)
        End If
    End Sub

End Class
