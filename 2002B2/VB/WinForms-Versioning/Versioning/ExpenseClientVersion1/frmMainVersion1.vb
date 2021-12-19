Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports ExpenseApproval.ExpenseApproval


Public Class Form1
    Inherits System.Windows.Forms.Form
    
    Public Sub New()
        MyBase.New()
        
        Form1 = Me
        
        'This call is required by the Win Form Designer.
        InitializeComponent()
        
        'TODO: Add any initialization after the InitializeComponent() call
    End Sub
    
    'Form overrides dispose to clean up the component list.
    Public Overloads Overrides Sub Dispose()
        MyBase.Dispose()
        components.Dispose()
    End Sub

#Region " Windows Form Designer generated code "

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container
    Private WithEvents btnSubmit As System.Windows.Forms.Button
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents lblExpenseAmount As System.Windows.Forms.Label
    Private WithEvents cmbExpenseType As System.Windows.Forms.ComboBox
    Private WithEvents txtExpenseAmount As System.Windows.Forms.TextBox

    Dim WithEvents Form1 As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.txtExpenseAmount = New System.Windows.Forms.TextBox()
        Me.cmbExpenseType = New System.Windows.Forms.ComboBox()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblExpenseAmount = New System.Windows.Forms.Label()

        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        '@design Me.GridSize = New System.Drawing.Size(8, 8)
        txtExpenseAmount.Location = New System.Drawing.Point(128, 32)
        txtExpenseAmount.Text = "0.00"
        txtExpenseAmount.TabIndex = 0
        txtExpenseAmount.Size = New System.Drawing.Size(120, 20)

        cmbExpenseType.Location = New System.Drawing.Point(128, 64)
        cmbExpenseType.Size = New System.Drawing.Size(121, 21)
        cmbExpenseType.TabIndex = 1
        Dim a__2(4) As Object
        a__2(0) = "Training"
        a__2(1) = "Travel"
        a__2(2) = "Software"
        a__2(3) = "Hardware"
        a__2(4) = "Entertainment"
        cmbExpenseType.Items.AddRange(a__2)

        btnSubmit.Location = New System.Drawing.Point(88, 112)
        btnSubmit.Size = New System.Drawing.Size(112, 24)
        btnSubmit.TabIndex = 4
        btnSubmit.Text = "Submit Expense"

        Label1.Location = New System.Drawing.Point(24, 64)
        Label1.Text = "Expense Amount"
        Label1.Size = New System.Drawing.Size(100, 16)
        Label1.TabIndex = 3
        Label1.Visible = False

        lblExpenseAmount.Location = New System.Drawing.Point(24, 32)
        lblExpenseAmount.Text = "Expense Amount"
        lblExpenseAmount.Size = New System.Drawing.Size(100, 16)
        lblExpenseAmount.TabIndex = 2
        Me.Text = "Expense Approval"
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 189)

        Me.Controls.Add(btnSubmit)
        Me.Controls.Add(Label1)
        Me.Controls.Add(lblExpenseAmount)
        Me.Controls.Add(cmbExpenseType)
        Me.Controls.Add(txtExpenseAmount)
    End Sub

#End Region

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Dim objExpenseApproval As New ExpenseApproval.ExpenseApproval()
        Dim strReturnString As String

        strReturnString = objExpenseApproval.ApproveExpense(CSng(txtExpenseAmount.Text), _
            cmbExpenseType.Text)

        MsgBox(strReturnString, Microsoft.VisualBasic.MsgBoxStyle.OKOnly, "Approval Results")

    End Sub

End Class
