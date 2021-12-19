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
    Private WithEvents btnSubmitExpense As System.Windows.Forms.Button
    Private WithEvents lblExpenseType As System.Windows.Forms.Label
    Private WithEvents lblExpenseAmount As System.Windows.Forms.Label
    Private WithEvents cmbExpenseType As System.Windows.Forms.ComboBox
    Private WithEvents txtExpenseAmount As System.Windows.Forms.TextBox






    Dim WithEvents Form1 As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.lblExpenseAmount = New System.Windows.Forms.Label()
        Me.txtExpenseAmount = New System.Windows.Forms.TextBox()
        Me.cmbExpenseType = New System.Windows.Forms.ComboBox()
        Me.btnSubmitExpense = New System.Windows.Forms.Button()
        Me.lblExpenseType = New System.Windows.Forms.Label()

        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        lblExpenseAmount.Location = New System.Drawing.Point(20, 24)
        lblExpenseAmount.Text = "Expense Amount"
        lblExpenseAmount.Size = New System.Drawing.Size(100, 12)
        lblExpenseAmount.TabIndex = 7

        txtExpenseAmount.Location = New System.Drawing.Point(132, 20)
        txtExpenseAmount.Text = "0.00"
        txtExpenseAmount.TabIndex = 5
        txtExpenseAmount.Size = New System.Drawing.Size(124, 20)

        cmbExpenseType.Location = New System.Drawing.Point(132, 48)
        cmbExpenseType.Size = New System.Drawing.Size(124, 21)
        cmbExpenseType.TabIndex = 6
        Dim a__1(4) As Object
        a__1(0) = "Training"
        a__1(1) = "Travel"
        a__1(2) = "Software"
        a__1(3) = "Hardware"
        a__1(4) = "Entertainment"
        cmbExpenseType.Items.AddRange(a__1)

        btnSubmitExpense.Location = New System.Drawing.Point(92, 88)
        btnSubmitExpense.Size = New System.Drawing.Size(108, 23)
        btnSubmitExpense.TabIndex = 9
        btnSubmitExpense.Text = "Submit Expense"

        lblExpenseType.Location = New System.Drawing.Point(20, 52)
        lblExpenseType.Text = "Expense Type"
        lblExpenseType.Size = New System.Drawing.Size(100, 12)
        lblExpenseType.TabIndex = 8
        lblExpenseType.Visible = False

        Me.Text = "Expense Approval"
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(296, 141)

        Me.Controls.Add(btnSubmitExpense)
        Me.Controls.Add(lblExpenseType)
        Me.Controls.Add(lblExpenseAmount)
        Me.Controls.Add(cmbExpenseType)
        Me.Controls.Add(txtExpenseAmount)
    End Sub

#End Region

    Protected Sub btnSubmitExpense_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmitExpense.Click
        Dim objExpenseApproval As New ExpenseApproval.ExpenseApproval()
        Dim strReturnString As String

        strReturnString = objExpenseApproval.ApproveExpense(CSng(txtExpenseAmount.Text), _
            cmbExpenseType.Text)

        MsgBox(strReturnString, Microsoft.VisualBasic.MsgBoxStyle.OKOnly, "Approval Results")

    End Sub



End Class
