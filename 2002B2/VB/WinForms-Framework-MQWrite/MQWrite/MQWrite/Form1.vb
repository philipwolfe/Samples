Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
    
    
    Public Class Form1
    Inherits System.Windows.Forms.Form
    
#Region " Class Initialization Code "
    Public Sub New()
        MyBase.New()
        
        Form1 = Me
        
        'This call is required by the Win Form Designer.
        InitializeComponent()
        
        'TODO: Add any initialization after the InitializeComponent() call
        
        'default the machine name
        txtServer.Text = System.Net.DNS.GetHostName
        
    End Sub
    
    'Form overrides dispose to clean up the component list.
    Public Overrides Sub Dispose()
        MyBase.Dispose()
        components.Dispose()
    End Sub
#End Region
    
#Region " Windows Form Designer generated code "
    
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container
    Private WithEvents lblResults As System.Windows.Forms.Label
    
    Private WithEvents btnListen As System.Windows.Forms.Button
    Private WithEvents txtQueueName As System.Windows.Forms.TextBox
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents txtServer As System.Windows.Forms.TextBox
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    
    
    Private WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    
    
    
    Private WithEvents btnCreateQueue As System.Windows.Forms.Button
    Private WithEvents txtMsgLabel As System.Windows.Forms.TextBox
    Private WithEvents btnSend As System.Windows.Forms.Button
    
    Dim WithEvents Form1 As System.Windows.Forms.Form
    
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnListen = New System.Windows.Forms.Button()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCreateQueue = New System.Windows.Forms.Button()
        Me.txtServer = New System.Windows.Forms.TextBox()
        Me.txtQueueName = New System.Windows.Forms.TextBox()
        Me.txtMsgLabel = New System.Windows.Forms.TextBox()
        Me.lblResults = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        
        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        GroupBox2.Location = New System.Drawing.Point(16, 8)
        GroupBox2.TabIndex = 7
        GroupBox2.TabStop = False
        GroupBox2.Size = New System.Drawing.Size(208, 48)
        
        btnListen.Location = New System.Drawing.Point(16, 184)
        btnListen.Size = New System.Drawing.Size(96, 23)
        btnListen.TabIndex = 8
        btnListen.Text = "Listen"
        
        btnSend.Location = New System.Drawing.Point(16, 152)
        btnSend.Size = New System.Drawing.Size(96, 23)
        btnSend.TabIndex = 0
        btnSend.Text = "Send Message"
        
        Label2.Location = New System.Drawing.Point(16, 16)
        Label2.Text = "Local Machine Name"
        Label2.Size = New System.Drawing.Size(80, 23)
        Label2.TabIndex = 0
        
        Label1.Location = New System.Drawing.Point(16, 16)
        Label1.Text = "Queue Name"
        Label1.Size = New System.Drawing.Size(72, 23)
        Label1.TabIndex = 0
        
        btnCreateQueue.Location = New System.Drawing.Point(16, 120)
        btnCreateQueue.Size = New System.Drawing.Size(96, 23)
        btnCreateQueue.TabIndex = 2
        btnCreateQueue.Text = "Create Queue"
        
        txtServer.Location = New System.Drawing.Point(96, 16)
        txtServer.TabIndex = 1
        txtServer.Size = New System.Drawing.Size(100, 20)
        
        txtQueueName.Location = New System.Drawing.Point(96, 16)
        txtQueueName.Text = "testqueue"
        txtQueueName.TabIndex = 1
        txtQueueName.Size = New System.Drawing.Size(96, 20)
        
        txtMsgLabel.Location = New System.Drawing.Point(120, 152)
        txtMsgLabel.Text = "Test Label"
        txtMsgLabel.TabIndex = 1
        txtMsgLabel.Size = New System.Drawing.Size(100, 20)
        
        lblResults.Location = New System.Drawing.Point(8, 224)
        lblResults.Size = New System.Drawing.Size(216, 23)
        lblResults.TabIndex = 9
        lblResults.TextAlign = ContentAlignment.MiddleCenter
        
        GroupBox1.Location = New System.Drawing.Point(16, 56)
        GroupBox1.TabIndex = 6
        GroupBox1.TabStop = False
        GroupBox1.Size = New System.Drawing.Size(208, 56)
        Me.Text = "Form1"
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(232, 285)
        
        GroupBox1.Controls.Add(txtQueueName)
        GroupBox1.Controls.Add(Label1)
        GroupBox2.Controls.Add(txtServer)
        GroupBox2.Controls.Add(Label2)
        Me.Controls.Add(lblResults)
        Me.Controls.Add(btnListen)
        Me.Controls.Add(GroupBox2)
        Me.Controls.Add(btnCreateQueue)
        Me.Controls.Add(txtMsgLabel)
        Me.Controls.Add(btnSend)
        Me.Controls.Add(GroupBox1)
    End Sub
    
#End Region
    
    'Receive messages from the Queue
    Protected Sub btnListen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnListen.click

        'Create a MessageQueue object
        Dim MQ As System.Messaging.MessageQueue = New System.Messaging.MessageQueue()
        'Create a Message object
        Dim Msg As System.Messaging.Message = New System.Messaging.Message()

        lblResults.Text = "Starting to listen to " & txtQueueName.Text

        'Set the path property on the MessageQueue object
        'For example, "betats1\private$\testqueue" is the single argument where 
        'betats1 is the local machine name and testqueue is the queue name
        MQ.Path = txtServer.Text & "\private$\" & txtQueueName.Text
        Try
            'Set the Message object equal to the result from the receive function
            'there are 2 implementations of Receive.  The one I use requires a 
            'TimeSpan object which specifies the timeout period.  There is also an
            'implementation of Receive which requires nothing and will wait indefinitely
            'for a message to arrive on a queue.
            'Timespan(days, hours, minutes, seconds)
            Msg = MQ.Receive(New TimeSpan(0, 0, 0, 10))

            'Display the received message's label
            MsgBox(" Label: " & Msg.Label)
        Catch excp As Exception
            'Catch any exceptions thrown
            MessageBox.Show(excp.Message, "Message from listener")
        End Try

        lblResults.Text = "Listen Complete"

    End Sub

    'Create a queue
    Protected Sub btnCreateQueue_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCreateQueue.click

        'Create a MessageQueue object
        Dim MQ As System.Messaging.MessageQueue = New System.Messaging.MessageQueue()

        'Update the status label on the main form
        lblResults.Text = "Creating queue " & txtQueueName.Text

        'In this example we pass the path to the queue we want to create to one of
        'the overloaded Create methods on the MessageQueue object.
        'For example, "betats1\private$\testqueue" is the single argument where 
        'betats1 is the local machine name and testqueue is the queue name
        Try
            MQ.Create(txtServer.Text & "\Private$\" & txtQueueName.Text)
            lblResults.Text = "Queue " & txtQueueName.Text & " created"
        Catch excp As Exception
            'Catch any exception thrown while creating the queue
            MsgBox("Exception caught while creating queue: " & excp.Message)
            lblResults.Text = "Couldn't create queue"
        End Try
    End Sub

    'Send a message to a queue
    Protected Sub btnSend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSend.click

        'Create a MessageQueue object
        Dim MQ As System.Messaging.MessageQueue = New System.Messaging.MessageQueue()
        'Create a Message object
        Dim Msg As System.Messaging.Message = New System.Messaging.Message()

        lblResults.Text = "Beginning to send a message"

        'tell the queue object what path to use to access the queue
        MQ.Path = txtServer.Text & "\Private$\" & txtQueueName.Text
        'Set the Message object's body
        Msg.Body = "test body"
        'set the Message object's label
        Msg.Label = txtMsgLabel.Text

        'send the Message
        MQ.Send(Msg)

        lblResults.Text = "Message Sent"

        'Check your queue for the message.

    End Sub
End Class
    