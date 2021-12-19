Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms


Public Class Form1
    Inherits System.Windows.Forms.Form

    Public Sub New()
        
        MyBase.New()
        
        Form1 = Me
        
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




    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents txtMessage As System.Windows.Forms.TextBox
    Private WithEvents cmdFile As System.Windows.Forms.Button
    Private WithEvents cmdEventLog As System.Windows.Forms.Button

    Dim WithEvents Form1 As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.cmdEventLog = New System.Windows.Forms.Button()
        Me.txtMessage = New System.Windows.Forms.TextBox()
        Me.cmdFile = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()

        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        cmdEventLog.Location = New System.Drawing.Point(240, 116)
        cmdEventLog.Size = New System.Drawing.Size(124, 23)
        cmdEventLog.TabIndex = 0
        cmdEventLog.Text = "Write to Event Log"

        txtMessage.Location = New System.Drawing.Point(24, 36)
        txtMessage.Text = "Sample Log Message"
        txtMessage.Multiline = True
        txtMessage.TabIndex = 2
        txtMessage.Size = New System.Drawing.Size(368, 60)

        cmdFile.Location = New System.Drawing.Point(56, 116)
        cmdFile.Size = New System.Drawing.Size(124, 23)
        cmdFile.TabIndex = 1
        cmdFile.Text = "Write to File"

        Label1.Location = New System.Drawing.Point(24, 16)
        Label1.Text = "Message to Log:"
        Label1.Size = New System.Drawing.Size(100, 16)
        Label1.TabIndex = 3
        Me.Text = "WinLogger"
        Me.MaximizeBox = False
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.MinimizeBox = False
        Me.ClientSize = New System.Drawing.Size(416, 157)

        Me.Controls.Add(Label1)
        Me.Controls.Add(txtMessage)
        Me.Controls.Add(cmdFile)
        Me.Controls.Add(cmdEventLog)
    End Sub

#End Region

    Protected Sub cmdEventLog_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdEventLog.click
        'Use the EventLogger class and place a new entry in the Windows Event Log
        Dim Log As New Logging.EventLogger("Logging Sample App")

        Log.WriteLog(Me.txtMessage.Text, Diagnostics.EventLogEntryType.Information)

        MessageBox.Show("Event Log entry written!", "WinLogger")
    End Sub

    Protected Sub cmdFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFile.click
        'Use the FileLogger class and place new entry in a text log file
        Dim Log As New Logging.FileLogger("LogFile.txt")

        Log.WriteLog(Me.txtMessage.Text, Diagnostics.EventLogEntryType.Information)

        MessageBox.Show("Log file entry written!", "WinLogger")
    End Sub
End Class
