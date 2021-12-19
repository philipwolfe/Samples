Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System
Imports System.IO
Imports System.Collections.Specialized


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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(272, 56)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "This Program reads data from a file, inserts it into a StringCollection and then " & _
        "prints it out a row at a time."
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(32, 104)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Go"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(296, 157)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.Button1})
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.click

        Dim InputFile As StreamReader = File.OpenText("words.txt")
        Dim FileLine As String
        Dim Word As String
        Dim StringCol As StringCollection = New StringCollection()

        'read the information from the text file
        Do
            FileLine = InputFile.ReadLine()
            If FileLine <> Nothing Then
                'add the contents to the string table
                StringCol.Add(FileLine)
            End If
        Loop Until FileLine = Nothing

        'display the contents of the string table one string at a time
        For Each Word In StringCol
            MessageBox.Show(Word, "String Reader", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Next
    End Sub

End Class
