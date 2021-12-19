Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Text


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

    Private WithEvents TextBox1 As System.Windows.Forms.TextBox
    Private WithEvents Button1 As System.Windows.Forms.Button

    Dim WithEvents Form1 As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()

        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        Button1.Location = New System.Drawing.Point(48, 48)
        Button1.Size = New System.Drawing.Size(144, 24)
        Button1.TabIndex = 0
        Button1.Text = "Get System Directory"

        Label1.Location = New System.Drawing.Point(48, 96)
        Label1.Text = "Your System Directory is:"
        Label1.Size = New System.Drawing.Size(132, 16)
        Label1.TabIndex = 2

        TextBox1.Location = New System.Drawing.Point(48, 112)
        TextBox1.TabIndex = 1
        TextBox1.Size = New System.Drawing.Size(184, 20)

        Me.Text = "Form1"
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 169)

        Me.Controls.Add(Label1)
        Me.Controls.Add(TextBox1)
        Me.Controls.Add(Button1)
    End Sub

#End Region

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.click

        'Setup the StringBuilder we will use to get the API return Value
        Const MAX_PATH As Integer = 256
        Dim Builder As New StringBuilder(MAX_PATH)

        'Call the Win32 API
        API.GetSystemDirectory(Builder, MAX_PATH)

        'Display the results in the TextBox
        TextBox1.Text = Builder.ToString

    End Sub

End Class
