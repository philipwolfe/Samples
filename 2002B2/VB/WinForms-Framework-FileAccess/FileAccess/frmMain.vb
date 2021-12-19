Imports System.Drawing
Imports System.Windows.Forms


Imports System.ComponentModel


Public Class frmMain
    Inherits System.Windows.Forms.Form

    Public Sub New()
        MyBase.New

        frmMain = Me

        'This call is required by the Win Form Designer.
        InitializeComponent()

       'TODO: Add any initialization after the InitializeComponent() call
    End Sub

    'Form overrides dispose to clean up the component list.
    Overrides Public Sub Dispose()
        MyBase.Dispose
        components.Dispose
    End Sub 

#Region " Windows Form Designer generated code "

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container
    Private WithEvents cmdReadFile As System.Windows.Forms.Button
    Private WithEvents cmdCreateFile As System.Windows.Forms.Button
    Private WithEvents cmdDir As System.Windows.Forms.Button
    
    Dim WithEvents frmMain As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.cmdCreateFile = New System.Windows.Forms.Button()
        Me.cmdReadFile = New System.Windows.Forms.Button()
        Me.cmdDir = New System.Windows.Forms.Button()
        
        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        cmdCreateFile.Location = New System.Drawing.Point(32, 60)
        cmdCreateFile.Size = New System.Drawing.Size(96, 23)
        cmdCreateFile.TabIndex = 1
        cmdCreateFile.Text = "Create File"
        
        cmdReadFile.Location = New System.Drawing.Point(32, 96)
        cmdReadFile.Size = New System.Drawing.Size(96, 23)
        cmdReadFile.TabIndex = 2
        cmdReadFile.Text = "Read File"
        
        cmdDir.Location = New System.Drawing.Point(32, 24)
        cmdDir.Size = New System.Drawing.Size(96, 23)
        cmdDir.TabIndex = 0
        cmdDir.Text = "Dir List"
        Me.Text = "frmMain"
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(164, 153)
        
        Me.Controls.Add(cmdReadFile)
        Me.Controls.Add(cmdCreateFile)
        Me.Controls.Add(cmdDir)
    End Sub
    
#End Region
    
    Protected Sub cmdReadFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdReadFile.click
        'display the read file dialog
        Dim frmReadFile As New frmReadFile()
        frmReadFile.Show()
    End Sub

    Protected Sub cmdCreateFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCreateFile.click
        'display the write file dialog
        Dim frmCreateFile As New WriteFile()
        frmCreateFile.Show()
    End Sub

    Protected Sub cmdDir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDir.click
        'display the Directory List dialog
        Dim frmDir As New frmDirList()
        frmDir.Show()
    End Sub

End Class
