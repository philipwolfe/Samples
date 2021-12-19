Imports System.Drawing
Imports System.Windows.Forms


Imports System.ComponentModel


Public Class SettingsForm
    Inherits System.Windows.Forms.Form

    Public Sub New()
        MyBase.New

        SettingsForm = Me

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
    Private WithEvents Button1 As System.Windows.Forms.Button
    Private WithEvents Label1 As System.Windows.Forms.Label

    Dim WithEvents SettingsForm As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()

        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        Button1.Location = New System.Drawing.Point(196, 128)
        Button1.Size = New System.Drawing.Size(75, 23)
        Button1.TabIndex = 1
        Button1.Text = "Close"

        Label1.Location = New System.Drawing.Point(12, 20)
        Label1.Text = "This form would contain the settings options."
        Label1.Size = New System.Drawing.Size(264, 92)
        Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16!)
        Label1.TabIndex = 0
        Me.Text = "SettingsForm"
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 173)

        Me.Controls.Add(Button1)
        Me.Controls.Add(Label1)
    End Sub

#End Region

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.click
        'close the form
        Me.Close()
    End Sub

End Class
