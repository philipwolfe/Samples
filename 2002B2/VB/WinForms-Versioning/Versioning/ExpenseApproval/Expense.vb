'This method call contains both code that was used for different versions of
'the component.  In Version 2 the logic for an Expense Type Expense changes.

Imports System.ComponentModel


Public Class ExpenseApproval
    Inherits System.ComponentModel.Component
    
    Public Function ApproveExpense(ByVal sngExpenseAmount As Single, _
        ByVal ExpenseType As String) As String
        
        Dim MaxNonApprovalAmount As Single = 250.01
        '*** Version 2 Code
        Dim MaxTrainingNonApprovalAmount As Single = 2500.01
        '*** End Version 2.0 Code
        
        '*** Version 1 Code
        'If (sngExpenseAmount > MaxNonApprovalAmount) Then
        '    ApproveExpense = "Expense Sent to Management for Approval."
        'Else
        '    ApproveExpense = "Expense Approved."
        'End If
        '*** End Version 1 Code
        
        '***Version 2 Code
        If (sngExpenseAmount < MaxTrainingNonApprovalAmount) And _
            (ExpenseType = "Training") Then
            ApproveExpense = "Expense Approved"
        ElseIf ((sngExpenseAmount >= MaxTrainingNonApprovalAmount) And (ExpenseType = "Training Class")) Or _
            (sngExpenseAmount >= MaxNonApprovalAmount) Then
            ApproveExpense = "Expense sent to Management for Approval."
        Else
            ApproveExpense = "Expense Approved."
        End If
        '***End Version 2 Code
        
    End Function
    
    Public Sub New()
        MyBase.New()
        
        'This call is required by the Component Designer.
        InitializeComponent()
        
        ' TODO: Add any initialization after the InitializeComponent() call
        
    End Sub
    
#Region " Component Designer generated code "
    
    'Required by the Component Designer
    Private components As Container
    
    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub
    
#End Region
    
End Class

