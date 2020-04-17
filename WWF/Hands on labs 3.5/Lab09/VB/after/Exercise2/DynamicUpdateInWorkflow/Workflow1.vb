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

Public class Workflow1
    Inherits SequentialWorkflowActivity

    Private Sub CheckAmount(ByVal sender As System.Object, ByVal e As System.Workflow.Activities.ConditionalEventArgs)





        If (Amount >= 1000) Then
            e.Result = True
        Else
            e.Result = False
        End If

        Console.WriteLine(vbTab & "CheckAmount : amount '{0}' result '{1}'", Amount, e.Result)





    End Sub





    Private Sub AddApproval(ByVal sender As System.Object, ByVal e As System.EventArgs)




        Dim invokeNewStepWorkflow As InvokeWorkflowActivity = New InvokeWorkflowActivity()

        'use WorkflowChanges class to author dynamic change
        Dim changes As WorkflowChanges = New WorkflowChanges(Me)

        'setup to invoke NewStepWorkflow type
        Dim type2 As Type = GetType(DynamicUpdateInWorkflow.Workflow2)

        invokeNewStepWorkflow.Name = "Workflow2"
        invokeNewStepWorkflow.TargetWorkflow = type2

        'insert invokeNewStepWorkflow in ifElseApproval 
        'transient activity collection

        Dim ifElse As CompositeActivity = CType(changes.TransientWorkflow.Activities("ifElseActivity1"), CompositeActivity)
        Dim branch1 As CompositeActivity = CType(ifElse.Activities("ifElseBranchActivity1"), CompositeActivity)
        branch1.Activities.Add(invokeNewStepWorkflow)

        ' apply transient changes to instance
        Me.ApplyWorkflowChanges(changes)
        Console.WriteLine(vbTab & "Added a new step from within workflow")

    End Sub

    Private Sub PurchaseOrderCreate(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Console.WriteLine(vbTab & "Creating Purchase Order")
    End Sub

    Public Shared AmountProperty As DependencyProperty = DependencyProperty.Register("Amount", GetType(Integer), GetType(Workflow1))

    <Description("This is the description which appears in the Property Browser")> _
    <Category("This is the category which will be displayed in the Property Browser")> _
    <Browsable(True)> _
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)> _
    Public Property Amount() As Integer
        Get
            Return (CType((MyBase.GetValue(Workflow1.AmountProperty)), Integer))
        End Get
        Set(ByVal Value As Integer)
            MyBase.SetValue(Workflow1.AmountProperty, Value)
        End Set
    End Property


End Class
