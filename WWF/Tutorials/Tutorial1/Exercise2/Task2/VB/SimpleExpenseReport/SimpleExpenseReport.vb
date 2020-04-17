'---------------------------------------------------------------------
'  This file is part of the Windows Workflow Foundation SDK Code Samples.
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
'---------------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System
Imports System.Workflow.Runtime
Imports System.Workflow.Activities
Imports System.Workflow.Activities.Rules
Imports System.Workflow.ComponentModel

Namespace Microsoft.Samples.Workflow.Tutorials.SequentialWorkflow
    <ExternalDataExchange()> _
    Public Interface IExpenseReportService
        Sub GetLeadApproval(ByVal message As String)
        Sub GetManagerApproval(ByVal message As String)
        Event ExpenseReportApproved As EventHandler(Of ExternalDataEventArgs)
        Event ExpenseReportRejected As EventHandler(Of ExternalDataEventArgs)
    End Interface

    Public Class ExpenseReportWorkflow : Inherits SequentialWorkflowActivity
        Private reportAmount As Integer = 0
        Private reportResult As String = ""

        Public WriteOnly Property Amount() As Integer
            Set(ByVal value As Integer)
                Me.reportAmount = Value
            End Set
        End Property

        Public ReadOnly Property Result() As String
            Get
                Return Me.reportResult
            End Get
        End Property

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub InitializeComponent()
            Me.CanModifyActivities = True
            Me.Name = "ExpenseReportWorkflow"
            Me.CanModifyActivities = False
        End Sub
    End Class
End Namespace
