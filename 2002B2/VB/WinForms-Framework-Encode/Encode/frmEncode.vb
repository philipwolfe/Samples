Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System
Imports System.IO
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
    Private WithEvents btnEncode As System.Windows.Forms.Button

    Dim WithEvents Form1 As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btnEncode = New System.Windows.Forms.Button()

        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        btnEncode.Location = New System.Drawing.Point(48, 32)
        btnEncode.Size = New System.Drawing.Size(120, 32)
        btnEncode.TabIndex = 0
        btnEncode.Text = "Encode"

        Me.Text = "Encode"
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(232, 93)

        Me.Controls.Add(btnEncode)
    End Sub

#End Region

    Protected Sub btnEncode_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEncode.click
        ' Create a text file for this example
        MessageBox.Show("Creating Encode.txt in the \bin directory for the Encode project", "Encode")

        Dim OutStream As FileStream
        OutStream = New FileStream("Encode.txt", FileMode.OpenOrCreate)

        MessageBox.Show("Writing UTF8", "Encode")
        Dim UTF8Writer As StreamWriter
        UTF8Writer = New StreamWriter(OutStream, Encoding.UTF8)
        UTF8Writer.WriteLine("This is in UTF8")
        UTF8Writer.Flush()

        MessageBox.Show("Writing Unicode", "Encode")
        Dim UnicodeWriter As StreamWriter
        UnicodeWriter = New StreamWriter(OutStream, Encoding.Unicode)
        UnicodeWriter.WriteLine("This is in Unicode")
        UnicodeWriter.Flush()

        MessageBox.Show("Writing Ascii", "Encode")
        Dim AsciiWriter As StreamWriter
        AsciiWriter = New StreamWriter(OutStream, Encoding.ASCII)
        AsciiWriter.WriteLine("This is in ASCII")
        AsciiWriter.Flush()

        OutStream.Close()
    End Sub

End Class
