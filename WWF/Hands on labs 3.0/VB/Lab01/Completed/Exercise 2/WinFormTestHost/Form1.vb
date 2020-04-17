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

Imports System.Workflow.Activities
Imports System.Workflow.ComponentModel
Imports System.Workflow.Runtime
Imports System.Collections.Generic

Public Class Form1

    Private wr As WorkflowRuntime
    Private workflowAssembly As String = ""
    Private workflowTypeName As String = ""

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        workflowAssembly = "HelloWorldWorkflow"
        workflowTypeName = "HelloWorldWorkflow.Workflow1"

    End Sub


    Private Sub btnStartWorkflow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnStartWorkflow.Click
        If (wr Is Nothing) Then

            wr = New WorkflowRuntime()
            wr.StartRuntime()
        End If

        Dim parameters As Dictionary(Of String, Object) = New Dictionary(Of String, Object)()
        parameters.Add("FirstName", txtFirstName.Text)
        parameters.Add("LastName", txtLastName.Text)

        Dim instance As WorkflowInstance = wr.CreateWorkflow(GetType(HelloWorldWorkflow.Workflow1), parameters)
        instance.Start()
    End Sub

    Private Sub Form1_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        If (wr IsNot Nothing) Then
            If (wr.IsStarted) Then
                wr.StopRuntime()
            End If
        End If
    End Sub
End Class
