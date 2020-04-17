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

Public class DynamicRulesWorkflow
    Inherits SequentialWorkflowActivity
    Private runCounter As Integer = 0
    Public Shared AmountProperty As DependencyProperty = DependencyProperty.Register("Amount", GetType(System.Int32), GetType(DynamicRulesWorkflow))

    <Description("This is the description which appears in the Property Browser")> _
    <Category("This is the category which will be displayed in the Property Browser")> _
    <Browsable(True)> _
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)> _
    Public Property Amount() As System.Int32
        Get
            Return (CType((MyBase.GetValue(DynamicRulesWorkflow.AmountProperty)), System.Int32))
        End Get
        Set(ByVal Value As System.Int32)
            MyBase.SetValue(DynamicRulesWorkflow.AmountProperty, Value)
        End Set
    End Property


    Private Sub ReRun(ByVal sender As Object, ByVal e As ConditionalEventArgs)

        e.Result = (runCounter < 2)
        runCounter += 1

    End Sub

    Private Sub initAmount_ExecuteCode(ByVal sender As Object, ByVal e As EventArgs)
        Console.WriteLine("Loop {0}", runCounter)
    End Sub

    Private Sub getManagerApproval_ExecuteCode(ByVal sender As Object, ByVal e As EventArgs)
        Console.WriteLine(vbTab & "Inside ifElseBranch1: Amount is '{0}', Get Manager Approval", Amount)
    End Sub

    Private Sub getVPApproval_ExecuteCode(ByVal sender As Object, ByVal e As EventArgs)
        Console.WriteLine(vbTab & "Inside ifElseBranch2: Amount is '{0}', Get VP Approval", Amount)
    End Sub
End Class
