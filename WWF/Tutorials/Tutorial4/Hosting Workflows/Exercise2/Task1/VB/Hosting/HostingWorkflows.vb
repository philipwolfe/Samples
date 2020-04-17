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
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Collections
Imports System.Drawing
Imports System.Workflow.Runtime
Imports System.Workflow.Activities

Namespace Microsoft.Samples.Workflow.Tutorials.Hosting
    Public NotInheritable Class HostingWorkflows : Inherits SequentialWorkflowActivity
        Private delayActivity1 As DelayActivity
        Private codeActivity2 As CodeActivity
        Private codeActivity1 As CodeActivity

        Private op1 As Integer
        Private op2 As Integer
        Private opResult As Integer

        Public Sub New()
            InitializeComponent()
        End Sub

        Public WriteOnly Property Operand1() As Integer
            Set(ByVal value As Integer)
                Me.op1 = Value
            End Set
        End Property

        Public WriteOnly Property Operand2() As Integer
            Set(ByVal value As Integer)
                Me.op2 = Value
            End Set
        End Property

        Public ReadOnly Property Result() As Integer
            Get
                Return Me.opResult
            End Get
        End Property

        Private Sub InitializeComponent()
            Me.CanModifyActivities = True

            Me.codeActivity1 = New System.Workflow.Activities.CodeActivity()
            Me.delayActivity1 = New System.Workflow.Activities.DelayActivity()
            Me.codeActivity2 = New System.Workflow.Activities.CodeActivity()
            ' 
            ' codeActivity1
            ' 
            Me.codeActivity1.Name = "codeActivity1"
            AddHandler Me.codeActivity1.ExecuteCode, _
                AddressOf Me.codeActivity1_ExecuteCode
            ' 
            ' delayActivity1
            ' 
            Me.delayActivity1.Name = "delayActivity1"
            Me.delayActivity1.TimeoutDuration = System.TimeSpan.Parse("00:00:05")
            ' 
            ' codeActivity2
            ' 
            Me.codeActivity2.Name = "codeActivity2"
            AddHandler Me.codeActivity2.ExecuteCode, _
                AddressOf Me.codeActivity2_ExecuteCode
            ' 
            ' HostingWorkflows
            ' 
            Me.Activities.Add(Me.codeActivity1)
            Me.Activities.Add(Me.delayActivity1)
            Me.Activities.Add(Me.codeActivity2)
            Me.Name = "HostingWorkflows"

            Me.CanModifyActivities = False
        End Sub

        Private Sub codeActivity1_ExecuteCode(ByVal sender As Object, _
            ByVal e As EventArgs)
            Console.WriteLine("In codeActivity1_ExecuteCode. Adding operands")
            Me.opResult = Me.op1 + Me.op2
        End Sub

        Private Sub codeActivity2_ExecuteCode(ByVal sender As Object, _
            ByVal e As EventArgs)
            Console.WriteLine("In codeActivity2_ExecuteCode ")
        End Sub
    End Class
End Namespace
