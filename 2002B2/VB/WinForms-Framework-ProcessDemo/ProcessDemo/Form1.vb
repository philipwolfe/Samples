Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System
Imports System.Diagnostics
Imports System.Threading

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
    Private WithEvents TextBox1 As System.Windows.Forms.TextBox
    Private WithEvents Button1 As System.Windows.Forms.Button
    Private WithEvents Label1 As System.Windows.Forms.Label

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
        Button1.Location = New System.Drawing.Point(336, 56)
        Button1.Size = New System.Drawing.Size(104, 23)
        Button1.TabIndex = 1
        Button1.Text = "Launch Program"

        Label1.Location = New System.Drawing.Point(8, 8)
        Label1.Text = "Launch and shut down an executable."
        Label1.Size = New System.Drawing.Size(360, 23)
        Label1.TabIndex = 0

        TextBox1.Location = New System.Drawing.Point(8, 56)
        TextBox1.Text = "Calc.exe"
        TextBox1.TabIndex = 2
        TextBox1.Size = New System.Drawing.Size(264, 20)
        Me.Text = "Form1"
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(448, 117)

        Me.Controls.Add(TextBox1)
        Me.Controls.Add(Button1)
        Me.Controls.Add(Label1)
    End Sub

#End Region

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.click
        Dim ExecutableFilename As String
        ExecutableFilename = Me.TextBox1.Text

        'tell the user what is going to happen
        MessageBox.Show(ExecutableFilename & " will be launched and after a second will be shut down again.")
        'create a new process
        Dim Process As Process
        Process = New Process()
        Process.StartInfo.FileName = ExecutableFilename
        Process.Start()

        Process.WaitForInputIdle()

        'sleep for a second then kill the process
        Thread.Sleep(1000)
        If (Not Process.CloseMainWindow()) Then
            Process.Kill()
        End If

    End Sub

End Class
