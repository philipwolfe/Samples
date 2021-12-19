Imports System.Drawing
Imports System.Windows.Forms
Imports System
Imports System.IO

Imports System.ComponentModel


Public Class WriteFile
    Inherits System.Windows.Forms.Form

    Public Sub New()
        MyBase.New

        WriteFile = Me

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
    Private WithEvents TextBox3 As System.Windows.Forms.TextBox
    Private WithEvents TextBox2 As System.Windows.Forms.TextBox
    Private WithEvents TextBox1 As System.Windows.Forms.TextBox
    Private WithEvents cmdWriteFile As System.Windows.Forms.Button
    
    Dim WithEvents WriteFile As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.cmdWriteFile = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        
        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        cmdWriteFile.Location = New System.Drawing.Point(420, 116)
        cmdWriteFile.Size = New System.Drawing.Size(75, 23)
        cmdWriteFile.TabIndex = 0
        cmdWriteFile.Text = "Write File"
        
        TextBox2.Location = New System.Drawing.Point(24, 52)
        TextBox2.Text = "This is line  two."
        TextBox2.TabIndex = 2
        TextBox2.Size = New System.Drawing.Size(472, 20)
        
        TextBox1.Location = New System.Drawing.Point(24, 20)
        TextBox1.Text = "This is line one."
        TextBox1.TabIndex = 1
        TextBox1.Size = New System.Drawing.Size(472, 20)
        
        TextBox3.Location = New System.Drawing.Point(24, 84)
        TextBox3.Text = "This is line three."
        TextBox3.TabIndex = 3
        TextBox3.Size = New System.Drawing.Size(472, 20)
        
        Me.Text = "WriteFile"
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(520, 161)
        
        Me.Controls.Add(TextBox3)
        Me.Controls.Add(TextBox2)
        Me.Controls.Add(TextBox1)
        Me.Controls.Add(cmdWriteFile)
    End Sub
    
#End Region
    

    Protected Sub cmdWriteFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdWriteFile.click
        'write the contents of the text boxes to a file
        Try
            Dim sw As StreamWriter = File.CreateText("c:\temp\MyFile.txt")
            sw.WriteLine(TextBox1.Text)
            sw.WriteLine(TextBox2.Text)
            sw.WriteLine(TextBox3.Text)
            sw.Close()

            'tell the user we're done
            MessageBox.Show("File successfully written!", "WriteFile", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

End Class
