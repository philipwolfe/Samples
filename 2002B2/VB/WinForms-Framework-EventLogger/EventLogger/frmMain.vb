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
    Public Overloads Overrides Sub Dispose()
        MyBase.Dispose()
        components.Dispose()
    End Sub

#Region " Windows Form Designer generated code "

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents txtEventText As System.Windows.Forms.TextBox
    Private WithEvents cmdWriteEvent As System.Windows.Forms.Button


    Dim WithEvents frmMain As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.cmdWriteEvent = New System.Windows.Forms.Button()
        Me.txtEventText = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()

        '@design Me.TrayHeight = 90
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        cmdWriteEvent.Location = New System.Drawing.Point(400, 56)
        cmdWriteEvent.Size = New System.Drawing.Size(104, 23)
        cmdWriteEvent.TabIndex = 0
        cmdWriteEvent.Text = "Write Event"

        txtEventText.Location = New System.Drawing.Point(120, 56)
        txtEventText.TabIndex = 1
        txtEventText.Size = New System.Drawing.Size(264, 20)

        Label2.Location = New System.Drawing.Point(0, 8)
        Label2.Text = "Event Log Writer"
        Label2.Size = New System.Drawing.Size(504, 23)
        Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Bold)
        Label2.TabIndex = 3
        Label2.TextAlign = ContentAlignment.MiddleCenter

        Label1.Location = New System.Drawing.Point(8, 56)
        Label1.Text = "Event Text"
        Label1.Size = New System.Drawing.Size(100, 23)
        Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Bold)
        Label1.TabIndex = 2
        Me.Text = "frmMain"
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(520, 109)

        Me.Controls.Add(Label2)
        Me.Controls.Add(Label1)
        Me.Controls.Add(txtEventText)
        Me.Controls.Add(cmdWriteEvent)
    End Sub

#End Region



    Protected Sub cmdWriteEvent_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdWriteEvent.click
        If txtEventText.Text <> "" Then
            'By default we'll log to the local event log.
            'You can change this value to point to another machine on your network
            Dim MachineName As String = System.Net.Dns.GetHostName

            'The next line creates the eventlogger variable and sets it to an instance of the EventLog component
            'The variables passed into the EventLog are the name of the log (Application)
            'the name of the local server and the name of the event source (myappsource)
            Dim EventLogger As New EventLog("Application", MachineName, "MyAppSource")

            'the following line writes the event log entry
            EventLogger.WriteEntry(txtEventText.Text)

            MessageBox.Show("Event Log entry was written!", "Event Logger")
        End If
    End Sub

End Class
