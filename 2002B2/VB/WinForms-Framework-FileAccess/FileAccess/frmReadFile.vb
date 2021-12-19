Imports System.Drawing
Imports System.Windows.Forms
Imports System.IO


Imports System.ComponentModel


Public Class frmReadFile
    Inherits System.Windows.Forms.Form

    Public Sub New()
        MyBase.New

        frmReadFile = Me

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
    Private WithEvents TextBox1 As System.Windows.Forms.TextBox
    Private WithEvents cmdReadFile As System.Windows.Forms.Button

    Dim WithEvents frmReadFile As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.cmdReadFile = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        
        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        cmdReadFile.Location = New System.Drawing.Point(24, 12)
        cmdReadFile.Size = New System.Drawing.Size(75, 23)
        cmdReadFile.TabIndex = 0
        cmdReadFile.Text = "Read File"
        
        TextBox1.Location = New System.Drawing.Point(24, 48)
        TextBox1.Multiline = True
        TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        TextBox1.TabIndex = 1
        TextBox1.Size = New System.Drawing.Size(488, 232)
        
        Me.Text = "frmReadFile"
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(536, 296)
        
        Me.Controls.Add(TextBox1)
        Me.Controls.Add(cmdReadFile)
    End Sub
    
#End Region
    
    Protected Sub cmdReadFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdReadFile.click
        'Read the contents of the file we just created and output it to the textbox
        Try
            Dim sr As StreamReader = File.OpenText("c:\temp\MyFile.txt")
            Do While sr.Peek() <> -1
                TextBox1.Text = TextBox1.Text & sr.ReadLine() & Chr(13) & Chr(10)
            Loop
        catch ex as Exception
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try

    End Sub

End Class
