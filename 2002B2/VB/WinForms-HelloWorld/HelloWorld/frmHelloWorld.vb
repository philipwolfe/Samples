Imports System.Drawing
Imports System.Windows.Forms


Imports System.ComponentModel


Public Class frmHelloWorld
    Inherits System.Windows.Forms.Form

    Public Sub New()
        MyBase.New

        frmHelloWorld = Me

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
    Private WithEvents btnClickMe As System.Windows.Forms.Button
    Private WithEvents txtMessage As System.Windows.Forms.TextBox

    Dim WithEvents frmHelloWorld As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btnClickMe = New System.Windows.Forms.Button()
        Me.txtMessage = New System.Windows.Forms.TextBox()

        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        btnClickMe.Location = New System.Drawing.Point(232, 56)
        btnClickMe.Size = New System.Drawing.Size(80, 32)
        btnClickMe.TabIndex = 1
        btnClickMe.Anchor = System.Windows.Forms.AnchorStyles.Bottom.Right
        btnClickMe.Text = "ClickMe!"

        txtMessage.Location = New System.Drawing.Point(8, 8)
        txtMessage.Text = "Hello World!"
        txtMessage.TabIndex = 0
        txtMessage.Anchor = System.Windows.Forms.AnchorStyles.Top.Left.Right
        txtMessage.Size = New System.Drawing.Size(304, 20)
        Me.Text = "frmHelloWorld"
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(320, 93)

        Me.Controls.Add(btnClickMe)
        Me.Controls.Add(txtMessage)
    End Sub

#End Region

    Protected Sub btnClickMe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClickMe.click
        'Display a greeting
        MessageBox.Show(Me.txtMessage.Text)
    End Sub

End Class
