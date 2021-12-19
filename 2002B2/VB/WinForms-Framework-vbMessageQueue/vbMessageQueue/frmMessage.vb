Option Strict Off

Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System.IO



Public Class frmMessageDemo
    Inherits System.Windows.Forms.Form
	' Member variable message queue
	Private WithEvents mQueue As System.Messaging.MessageQueue
	
	Public Sub New()
		MyBase.New()
		
		frmMessageDemo = Me
		
		'This call is required by the Win Form Designer.
		InitializeComponent()
		
		'TODO: Add any initialization after the InitializeComponent() call
		'Fill in the directions label
        Dim DirText As String
        Dim CRLF As String
        CRLF = Chr(13) & Chr(10)
        DirText = "Step 1" & CRLF
        DirText = DirText & "Connect to queue." & CRLF & CRLF
        DirText = DirText & "Step 2" & CRLF
        DirText = DirText & "Enter a message label and message text into textboxes." & CRLF & CRLF & CRLF & CRLF & CRLF
        DirText = DirText & "Step 3" & CRLF
        DirText = DirText & "Click send message." & CRLF & CRLF
        DirText = DirText & "Step 4" & CRLF
        DirText = DirText & "The returned text is what was received by message queue." & CRLF & CRLF
        Me.lblDirections.Text = DirText
		
	End Sub
	
	'Form overrides dispose to clean up the component list.
    Public Overloads Overrides Sub Dispose()
        MyBase.Dispose()
        components.Dispose()
    End Sub

#Region " Windows Form Designer generated code "

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container
    Private WithEvents lblDirections As System.Windows.Forms.Label
    Private WithEvents txtReceived As System.Windows.Forms.TextBox
    Private WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents txtMsgBody As System.Windows.Forms.TextBox
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents txtMsgLabel As System.Windows.Forms.TextBox




    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents txtQueueName As System.Windows.Forms.TextBox
    Private WithEvents cmdSend As System.Windows.Forms.Button
    Private WithEvents cmdConnect As System.Windows.Forms.Button

    Dim WithEvents frmMessageDemo As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMessageDemo))

        Me.components = New System.ComponentModel.Container()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtQueueName = New System.Windows.Forms.TextBox()
        Me.cmdConnect = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdSend = New System.Windows.Forms.Button()
        Me.txtReceived = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtMsgLabel = New System.Windows.Forms.TextBox()
        Me.txtMsgBody = New System.Windows.Forms.TextBox()
        Me.lblDirections = New System.Windows.Forms.Label()

        '@design Me.TrayHeight = 90
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        Label4.Location = New System.Drawing.Point(20, 180)
        Label4.Text = "Received:"
        Label4.Size = New System.Drawing.Size(80, 16)
        Label4.TabIndex = 11
        Label4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right

        txtQueueName.Location = New System.Drawing.Point(104, 8)
        txtQueueName.Text = "demoQueue1"
        txtQueueName.TabIndex = 2
        txtQueueName.Size = New System.Drawing.Size(100, 20)

        cmdConnect.Location = New System.Drawing.Point(208, 4)
        cmdConnect.Size = New System.Drawing.Size(104, 24)
        cmdConnect.TabIndex = 0
        cmdConnect.Text = "Connect"

        Label2.Location = New System.Drawing.Point(20, 44)
        Label2.Text = "Label:"
        Label2.Size = New System.Drawing.Size(80, 16)
        Label2.TabIndex = 8
        Label2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right

        Label1.Location = New System.Drawing.Point(20, 12)
        Label1.Text = "Queue Name:"
        Label1.Size = New System.Drawing.Size(80, 16)
        Label1.TabIndex = 3
        Label1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right

        cmdSend.Location = New System.Drawing.Point(212, 136)
        cmdSend.Size = New System.Drawing.Size(104, 24)
        cmdSend.TabIndex = 1
        cmdSend.Text = "Send Message"

        txtReceived.Location = New System.Drawing.Point(104, 176)
        txtReceived.Multiline = True
        txtReceived.TabIndex = 12
        txtReceived.Size = New System.Drawing.Size(212, 84)
        txtReceived.BackColor = System.Drawing.SystemColors.Control

        Label3.Location = New System.Drawing.Point(20, 72)
        Label3.Text = "Body:"
        Label3.Size = New System.Drawing.Size(80, 16)
        Label3.TabIndex = 10
        Label3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right

        txtMsgLabel.Location = New System.Drawing.Point(104, 40)
        txtMsgLabel.Text = "Message Label"
        txtMsgLabel.TabIndex = 7
        txtMsgLabel.Size = New System.Drawing.Size(212, 20)

        txtMsgBody.Location = New System.Drawing.Point(104, 68)
        txtMsgBody.Text = "Message Body"
        txtMsgBody.Multiline = True
        txtMsgBody.TabIndex = 9
        txtMsgBody.Size = New System.Drawing.Size(212, 60)

        lblDirections.Location = New System.Drawing.Point(328, 4)
        lblDirections.Text = "Directions:"
        lblDirections.Size = New System.Drawing.Size(112, 256)
        lblDirections.ForeColor = System.Drawing.SystemColors.Highlight
        lblDirections.TabIndex = 13
        Me.Text = "Simple Message Queue Sample"
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(448, 273)

        Me.Controls.Add(lblDirections)
        Me.Controls.Add(txtReceived)
        Me.Controls.Add(Label4)
        Me.Controls.Add(Label3)
        Me.Controls.Add(txtMsgBody)
        Me.Controls.Add(Label2)
        Me.Controls.Add(txtMsgLabel)
        Me.Controls.Add(Label1)
        Me.Controls.Add(txtQueueName)
        Me.Controls.Add(cmdSend)
        Me.Controls.Add(cmdConnect)
    End Sub

#End Region


    Private Function GetQueueName() As String
        ' Appends the private to the front of the user entered queue name to make it a local queue to this machine.  
        Dim sPrefix As String
        sPrefix = ".\PRIVATE$\"
        GetQueueName = sPrefix & Me.txtQueueName.Text
    End Function

    Protected Sub cmdSend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSend.Click
        Dim oMsg As New System.Messaging.Message()

        ' Assumes the dest queue already exists
        Dim oQueue As New System.Messaging.MessageQueue(GetQueueName())
        Dim sMsgBody As String
        Dim sMsgLabel As String
        Dim oFormat As New System.Messaging.XmlMessageFormatter()

        ' We are using the formatter to encode a single string for the body
        oFormat.Write(oMsg, Me.txtMsgBody.Text)
        oQueue.Send(oMsg, Me.txtMsgLabel.Text)

    End Sub



    Protected Sub cmdConnect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdConnect.Click
        Try
            ' Set up member variable queue
            mQueue = New System.Messaging.MessageQueue()

            ' Create Queue if necessary
            If mQueue.Exists(GetQueueName()) = False Then
                mQueue.Create(GetQueueName())
            End If

            'Set Queue Path
            mQueue.Path = GetQueueName()

            'Change Controls values
            Me.cmdConnect.Text = "-- Connected --"
            Me.cmdConnect.Enabled = False

            'Enable Receive Event on Queue
            mQueue.BeginReceive()

            'Enable Send Button
            Me.cmdSend.Enabled = True

            'Disable Editing of QueueName
            Me.txtQueueName.Enabled = False
        Catch
            MessageBox.Show(Err().Description)
        End Try

    End Sub



    Public Sub mQueue_ReceiveCompleted(ByVal sender As Object, ByVal args As System.Messaging.ReceiveCompletedEventArgs) Handles mQueue.ReceiveCompleted
        'Implements Message Recieved Event for MSMQ
        'Only called when that event occurs
        'Disable recieve event on Queue
        'Set Message Object = Message in Queue
        Dim oMsg As System.Messaging.Message = mQueue().EndReceive(args.AsyncResult)
        Dim sMsgBody As String
        Dim sMsgLabel As String

        Dim oFormat As New System.Messaging.XmlMessageFormatter()

        ' Since we encoded the message as a string, we need to indicate the cast to the formatter on this end
        oFormat.TargetTypeNames = New String() {"System.String"}

        ' Decode the message into a string
        sMsgBody = oFormat.Read(oMsg)
        sMsgLabel = oMsg.Label

        ' Write out Message Label and Body
        Dim sSeperator As String
        sSeperator = Chr(13) & Chr(10) & "-------------------------------------------" & Chr(13) & Chr(10)

        Me.txtReceived.Text = "Label:" & sMsgLabel & sSeperator & sMsgBody

        ' Reactivate the receive event
        mQueue().BeginReceive()

    End Sub

End Class
