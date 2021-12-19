Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System
Imports System.IO


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
    Overrides Public Sub Dispose()
        MyBase.Dispose
        components.Dispose
    End Sub 

#Region " Windows Form Designer generated code "

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents Button1 As System.Windows.Forms.Button
    
    Dim WithEvents Form1 As System.Windows.Forms.Form

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
        Button1.Location = New System.Drawing.Point(56, 80)
        Button1.Size = New System.Drawing.Size(75, 23)
        Button1.TabIndex = 0
        Button1.Text = "Go"
        
        Label1.Location = New System.Drawing.Point(24, 16)
        Label1.Text = "View the File details for everything in the app directory."
        Label1.Size = New System.Drawing.Size(192, 40)
        Label1.TabIndex = 1
        Me.Text = "Form1"
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(224, 109)
        
        Me.Controls.Add(Label1)
        Me.Controls.Add(Button1)
    End Sub
    
#End Region
    
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.click
        Dim dir As New DirectoryInfo(".")
        PrintFiles(dir)

    End Sub



    Public Shared Sub PrintFiles(ByVal dir As DirectoryInfo)

        Dim d As Object

        'loop through the contents of the directory and grab information about files
        For Each d In dir.GetFiles
            Dim f As FileInfo
            f = CType(d, FileInfo)
            Dim Name As String
            Name = f.FullName
            Dim size As Long
            size = f.Length
            Dim creationTime As DateTime
            creationTime = f.CreationTime
            MsgBox(size & ", " & creationTime & ", " & Name, Microsoft.VisualBasic.MsgBoxStyle.Information, "Directory Info")
        Next

        'make a recursive call to PrintFiles if there are any subdirectories
        For Each d In dir.GetDirectories
            PrintFiles(CType(d, DirectoryInfo))
        Next
    End Sub

End Class
