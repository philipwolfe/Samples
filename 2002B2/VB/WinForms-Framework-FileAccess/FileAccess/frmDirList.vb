Imports System.Drawing
Imports System.Windows.Forms
Imports System
Imports System.IO

Imports System.ComponentModel


Public Class frmDirList
    Inherits System.Windows.Forms.Form

    Public Sub New()
        MyBase.New

        frmDirList = Me

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
    Private WithEvents txtDir As System.Windows.Forms.TextBox
    Private WithEvents cmdGetDir As System.Windows.Forms.Button

    Dim WithEvents frmDirList As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.cmdGetDir = New System.Windows.Forms.Button()
        Me.txtDir = New System.Windows.Forms.TextBox()

        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        cmdGetDir.Location = New System.Drawing.Point(12, 12)
        cmdGetDir.Size = New System.Drawing.Size(75, 23)
        cmdGetDir.TabIndex = 0
        cmdGetDir.Text = "Get Dir"

        txtDir.Location = New System.Drawing.Point(12, 44)
        txtDir.Multiline = True
        txtDir.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        txtDir.TabIndex = 1
        txtDir.Size = New System.Drawing.Size(520, 168)

        Me.Text = "frmDirList"
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(552, 225)

        Me.Controls.Add(txtDir)
        Me.Controls.Add(cmdGetDir)
    End Sub

#End Region

    Protected Sub cmdGetDir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGetDir.Click
        'get the list of files within the current directory
        Dim dir As New DirectoryInfo(".")
        Dim f As FileInfo
        Dim name As String
        Dim size As Long
        Dim creationTime As Date

        'display the current directory name
        txtDir.Text = dir.FullName & Chr(13) & Chr(10)

        'insert some descriptive text
        txtDir.Text = txtDir.Text & Chr(13) & Chr(10)
        txtDir.Text = txtDir.Text & "Contains:" & Chr(13) & Chr(10)

        'display the name, size and create date for each file
        For Each f In dir.GetFiles("*.*")
            name = f.Name
            size = f.Length
            creationTime = f.CreationTime
            txtDir.Text = txtDir.Text & " " & name & " " & size & " " & creationTime & Chr(13) & Chr(10)
        Next


    End Sub

End Class
