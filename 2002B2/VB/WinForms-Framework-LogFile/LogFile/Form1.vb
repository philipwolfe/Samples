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
    Public Overloads Overrides Sub Dispose()
        MyBase.Dispose()
        components.Dispose()
    End Sub

#Region " Windows Form Designer generated code "

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents txtLog As System.Windows.Forms.TextBox

    Private WithEvents txtMessage As System.Windows.Forms.TextBox
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents btnLog As System.Windows.Forms.Button

    Dim WithEvents Form1 As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.txtLog = New System.Windows.Forms.TextBox()
        Me.txtMessage = New System.Windows.Forms.TextBox()
        Me.btnLog = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()

        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        txtLog.Location = New System.Drawing.Point(16, 112)
        txtLog.Multiline = True
        txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        txtLog.TabIndex = 4
        txtLog.Size = New System.Drawing.Size(472, 160)

        txtMessage.Location = New System.Drawing.Point(16, 40)
        txtMessage.Text = "Test Message"
        txtMessage.TabIndex = 2
        txtMessage.Size = New System.Drawing.Size(136, 20)

        btnLog.Location = New System.Drawing.Point(168, 40)
        btnLog.Size = New System.Drawing.Size(75, 23)
        btnLog.TabIndex = 0
        btnLog.Text = "Log"

        Label1.Location = New System.Drawing.Point(16, 8)
        Label1.Text = "Enter a message in the text box below and press the log button to write to the log.txt file."
        Label1.Size = New System.Drawing.Size(480, 24)
        Label1.TabIndex = 1

        Label2.Location = New System.Drawing.Point(16, 80)
        Label2.Text = "Log File Dump:"
        Label2.Size = New System.Drawing.Size(480, 24)
        Label2.TabIndex = 5
        Label2.Visible = False
        Me.Text = "Form1"
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(512, 285)

        Me.Controls.Add(Label2)
        Me.Controls.Add(txtLog)
        Me.Controls.Add(txtMessage)
        Me.Controls.Add(Label1)
        Me.Controls.Add(btnLog)
    End Sub

#End Region

    Protected Sub btnLog_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLog.click
        'create the log file
        Dim OutStream As New FileStream("log.txt", FileMode.OpenOrCreate, FileAccess.Write)

        ' create a Char writer 
        Dim CharWriter As New StreamWriter(OutStream)
        CharWriter.BaseStream.Seek(0, SeekOrigin.End) ' set the file pointer to the end

        'log the new message
        Log(txtMessage.Text, CharWriter)

        'close the writer and underlying file  
        CharWriter.Close()

        'read the conents of the log file
        txtLog.Text = DumpLog("log.txt")
    End Sub

    Private Sub Log(ByVal LogMessage As String, ByVal Writer As StreamWriter)
        'Write the new entry to the log file    
        Writer.WriteLine()
        Writer.Write("Log Entry : ")
        Writer.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString())
        Writer.WriteLine("  :")
        Writer.WriteLine("  :{0}", LogMessage)
        Writer.WriteLine("-------------------------------")
        Writer.Flush()  ' update underlying file
    End Sub

    Private Function DumpLog(ByVal FileName As String) As String
        Dim Contents As String

        'open the file to read the contents
        Dim OutStream As New FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Read)
        Dim Reader As New StreamReader(OutStream) ' create a Char reader

        ' set the file pointer to the beginning
        Reader.BaseStream.Seek(0, SeekOrigin.Begin)


        'Read the contents of the log file
        Contents = Reader.ReadToEnd()

        'close the log file
        Reader.Close()

        'return the contens of the log file
        Return Contents
    End Function
End Class
