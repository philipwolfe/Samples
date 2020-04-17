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

Public Class VotingWorkflow
    Inherits SequentialWorkflowActivity

    Private Sub OnRejected(ByVal sender As Object, ByVal e As ExternalDataEventArgs)
        Console.WriteLine(String.Format("Proposal Rejected by {0}", Me.votingArgs.Alias))
    End Sub

    Private Sub OnApproved(ByVal sender As Object, ByVal e As ExternalDataEventArgs)
        Console.WriteLine(String.Format("Proposal Approved by {0}", Me.votingArgs.Alias))
    End Sub

    Public Shared votingArgsProperty As System.Workflow.ComponentModel.DependencyProperty = DependencyProperty.Register("votingArgs", GetType(CommunicationsWorkflow.VotingEventArgs), GetType(CommunicationsWorkflow.VotingWorkflow))

    <System.ComponentModel.DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)> _
    <System.ComponentModel.BrowsableAttribute(True)> _
    <System.ComponentModel.CategoryAttribute("Parameters")> _
    Public Property votingArgs() As VotingEventArgs
        Get
            Return CType(MyBase.GetValue(CommunicationsWorkflow.VotingWorkflow.votingArgsProperty), CommunicationsWorkflow.VotingEventArgs)
        End Get
        Set(ByVal value As VotingEventArgs)
            MyBase.SetValue(CommunicationsWorkflow.VotingWorkflow.votingArgsProperty, value)
        End Set
    End Property

End Class
