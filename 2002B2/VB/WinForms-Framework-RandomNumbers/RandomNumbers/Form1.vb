Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms


Public Class Form1
    Inherits System.Windows.Forms.Form

    'create an instance of the Random class
    Private GenerateRandomNumber As New Random()

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
    Private WithEvents btnClear As System.Windows.Forms.Button


    Private WithEvents txtLetter As System.Windows.Forms.TextBox
    Private WithEvents btnGenLetter As System.Windows.Forms.Button
    Private WithEvents txtZeroOrOne As System.Windows.Forms.TextBox
    Private WithEvents btnGenZeroOrOne As System.Windows.Forms.Button
    Private WithEvents txtNumber As System.Windows.Forms.TextBox
    Private WithEvents btnGenNumbers As System.Windows.Forms.Button

    Dim WithEvents Form1 As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.txtZeroOrOne = New System.Windows.Forms.TextBox()
        Me.txtLetter = New System.Windows.Forms.TextBox()
        Me.btnGenZeroOrOne = New System.Windows.Forms.Button()
        Me.btnGenNumbers = New System.Windows.Forms.Button()
        Me.txtNumber = New System.Windows.Forms.TextBox()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnGenLetter = New System.Windows.Forms.Button()

        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        txtZeroOrOne.Location = New System.Drawing.Point(184, 80)
        txtZeroOrOne.TabIndex = 3
        txtZeroOrOne.Size = New System.Drawing.Size(160, 20)

        txtLetter.Location = New System.Drawing.Point(184, 120)
        txtLetter.TabIndex = 5
        txtLetter.Size = New System.Drawing.Size(160, 20)

        btnGenZeroOrOne.Location = New System.Drawing.Point(16, 80)
        btnGenZeroOrOne.Size = New System.Drawing.Size(152, 23)
        btnGenZeroOrOne.TabIndex = 2
        btnGenZeroOrOne.Text = "Between 0 and 1"

        btnGenNumbers.Location = New System.Drawing.Point(16, 40)
        btnGenNumbers.Size = New System.Drawing.Size(152, 23)
        btnGenNumbers.TabIndex = 0
        btnGenNumbers.Text = "Random Digits"

        txtNumber.Location = New System.Drawing.Point(184, 40)
        txtNumber.TabIndex = 1
        txtNumber.Size = New System.Drawing.Size(160, 20)

        btnClear.Location = New System.Drawing.Point(140, 172)
        btnClear.Size = New System.Drawing.Size(75, 23)
        btnClear.TabIndex = 8
        btnClear.Text = "Clear Fields"

        btnGenLetter.Location = New System.Drawing.Point(16, 120)
        btnGenLetter.Size = New System.Drawing.Size(152, 23)
        btnGenLetter.TabIndex = 4
        btnGenLetter.Text = "Random Letter"
        Me.Text = "Using Random"
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(376, 217)

        Me.Controls.Add(btnClear)
        Me.Controls.Add(txtLetter)
        Me.Controls.Add(btnGenLetter)
        Me.Controls.Add(txtZeroOrOne)
        Me.Controls.Add(btnGenZeroOrOne)
        Me.Controls.Add(txtNumber)
        Me.Controls.Add(btnGenNumbers)
    End Sub

#End Region

    Protected Sub btnGenLetter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenLetter.click
        'restrict the random number generator to uppercase ASCII character values
        txtLetter.Text = ChrW(GenerateRandomNumber.Next(65, 90))
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.click
        'Clear the results
        txtZeroOrOne.Text = ""
        txtNumber.Text = ""
        txtLetter.Text = ""
    End Sub

    Protected Sub btnGenZeroOrOne_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenZeroOrOne.click
        'Generate a random number between zero and one
        txtZeroOrOne.Text = GenerateRandomNumber.NextDouble().ToString
    End Sub

    Protected Sub btnGenNumbers_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenNumbers.click
        'Generate a random number 
        txtNumber.Text = GenerateRandomNumber.Next().ToString
    End Sub

End Class
