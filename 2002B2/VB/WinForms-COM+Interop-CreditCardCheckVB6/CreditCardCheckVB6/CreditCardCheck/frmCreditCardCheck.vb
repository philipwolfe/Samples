Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms


Public Class Form1
    Inherits System.Windows.Forms.Form

    Public Sub New()
        MyBase.New

        Form1 = Me

        'This call is required by the Win Form Designer.
        InitializeComponent

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
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents lblResult As System.Windows.Forms.Label
    Private WithEvents btnVerfiyNumber As System.Windows.Forms.Button
    Private WithEvents btnTestNumber As System.Windows.Forms.Button
    Private WithEvents txtCreditCardNumber As System.Windows.Forms.TextBox

    Dim WithEvents Form1 As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btnTestNumber = New System.Windows.Forms.Button()
        Me.btnVerfiyNumber = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCreditCardNumber = New System.Windows.Forms.TextBox()
        Me.lblResult = New System.Windows.Forms.Label()

        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        btnTestNumber.Location = New System.Drawing.Point(256, 28)
        btnTestNumber.Size = New System.Drawing.Size(136, 24)
        btnTestNumber.TabIndex = 1
        btnTestNumber.Text = "Get Test Number"

        btnVerfiyNumber.Location = New System.Drawing.Point(88, 64)
        btnVerfiyNumber.Size = New System.Drawing.Size(96, 24)
        btnVerfiyNumber.TabIndex = 2
        btnVerfiyNumber.Text = "Check Number"

        Label1.Location = New System.Drawing.Point(12, 12)
        Label1.Text = "Enter a credit card number:"
        Label1.Size = New System.Drawing.Size(140, 16)
        Label1.TabIndex = 4

        txtCreditCardNumber.Location = New System.Drawing.Point(8, 32)
        txtCreditCardNumber.TabIndex = 0
        txtCreditCardNumber.Size = New System.Drawing.Size(240, 20)

        lblResult.Location = New System.Drawing.Point(12, 112)
        lblResult.Size = New System.Drawing.Size(288, 40)
        lblResult.Font = New System.Drawing.Font("Microsoft Sans Serif", 16!, System.Drawing.FontStyle.Bold)
        lblResult.TabIndex = 3

        Me.Text = "Credit Card Check"
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(424, 181)

        Me.Controls.Add(Label1)
        Me.Controls.Add(lblResult)
        Me.Controls.Add(btnVerfiyNumber)
        Me.Controls.Add(btnTestNumber)
        Me.Controls.Add(txtCreditCardNumber)
    End Sub

#End Region

    Protected Sub btnVerfiyNumber_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVerfiyNumber.Click
        Dim objCreditCard As New CreditCardCheck20.CreditCard()

        Try
            If Me.txtCreditCardNumber.Text.Length > 0 Then
                Me.lblResult.Text = objCreditCard.CheckCreditCard(txtCreditCardNumber.Text).ToString
            Else
                Me.lblResult.Text = "Please enter a credit card number"
            End If
        Catch er As Exception
            Me.lblResult.Text = er.Message
        End Try

    End Sub

    Protected Sub btnTestNumber_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTestNumber.Click
        'provide a valid test card number
        txtCreditCardNumber.Text = "4111111111111111"
    End Sub

End Class
