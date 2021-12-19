Imports System.Threading
Imports System.IO
Imports System.Messaging


Public Class Form1
    Inherits System.Windows.Forms.Form

    Dim BolStop As Boolean = False

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        Me.txtServer.Text = System.Net.Dns.GetHostName()

        'Add any initialization after the InitializeComponent() call
    End Sub

    'Form overrides dispose to clean up the component list.
    Public Overrides Sub Dispose()
        MyBase.Dispose()
        If Not (components Is Nothing) Then
            components.Dispose()
        End If
    End Sub
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents txtServer As System.Windows.Forms.TextBox
    Private WithEvents cmdStop As System.Windows.Forms.Button
    Private WithEvents txtQueue As System.Windows.Forms.TextBox
    Private WithEvents lblResult As System.Windows.Forms.Label
    Private WithEvents cmdStart As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtServer = New System.Windows.Forms.TextBox()
        Me.lblResult = New System.Windows.Forms.Label()
        Me.txtQueue = New System.Windows.Forms.TextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.cmdStart = New System.Windows.Forms.Button()
        Me.cmdStop = New System.Windows.Forms.Button()
        Me.label2 = New System.Windows.Forms.Label()
        Me.txtServer.Location = New System.Drawing.Point(80, 24)
        Me.txtServer.Size = New System.Drawing.Size(136, 20)
        Me.txtServer.TabIndex = 0
        Me.txtServer.Text = ""
        Me.lblResult.Location = New System.Drawing.Point(32, 160)
        Me.lblResult.Size = New System.Drawing.Size(216, 24)
        Me.lblResult.TabIndex = 3
        Me.txtQueue.Location = New System.Drawing.Point(80, 56)
        Me.txtQueue.Size = New System.Drawing.Size(136, 20)
        Me.txtQueue.TabIndex = 0
        Me.txtQueue.Text = ""
        Me.label1.Location = New System.Drawing.Point(24, 56)
        Me.label1.Size = New System.Drawing.Size(48, 24)
        Me.label1.TabIndex = 1
        Me.label1.Text = "Queue:"
        Me.cmdStart.Location = New System.Drawing.Point(16, 96)
        Me.cmdStart.Size = New System.Drawing.Size(96, 32)
        Me.cmdStart.TabIndex = 2
        Me.cmdStart.Text = "Start Listening"
        Me.cmdStop.Location = New System.Drawing.Point(144, 96)
        Me.cmdStop.Size = New System.Drawing.Size(96, 32)
        Me.cmdStop.TabIndex = 2
        Me.cmdStop.Text = "Stop Listening"
        Me.label2.Location = New System.Drawing.Point(24, 24)
        Me.label2.Size = New System.Drawing.Size(48, 24)
        Me.label2.TabIndex = 1
        Me.label2.Text = "Server:"
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(259, 216)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblResult, Me.cmdStop, Me.cmdStart, Me.label2, Me.label1, Me.txtQueue, Me.txtServer})
        Me.Text = "Listener"

    End Sub

#End Region

    Private Sub cmdStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStart.Click
        lblResult().Text = "Starting Threads"

        Call StartThreads()
    End Sub

    Private Sub cmdStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStop.Click
        'User has clicked stop.
        BolStop = True
    End Sub

    Public Sub StartThreads()
        Dim i As Integer 'Thread count
        Dim ObjMQListen As MQListen
        'declare an array of 5 threads to be worker threads
        Dim OThread(5) As Thread
        Dim ObjThreadStart As ThreadStart

        'declare the Class that will run our threads
        ObjMQListen = New MQListen()
        ObjMQListen.MQListen(Me.txtServer.Text, Me.txtQueue.Text)

        ' Create a ThreadStart object, passing the address of objMQListener.Listen
        ObjThreadStart = New ThreadStart(AddressOf ObjMQListen.Listen)

        BolStop = False

        For i = 0 To 4
            ' Create a Thread object 
            OThread(i) = New Thread(ObjThreadStart)
            ' Starting the thread invokes the ThreadStart delegate
            OThread(i).Start()
        Next i

        lblResult().Text = i & " listener threads started"

        While True
            'wait for the user to press the stop button
            If BolStop Then
                'user has pressed stop, proceed to shut down threads    
                Exit While
            End If
            'Let the system handle other events
            System.Windows.Forms.Application.DoEvents()
        End While
        lblResult().Text = "Stop request received, stopping threads"
        'send an interrupt request to each thread
        For i = 0 To 4
            OThread(i).Interrupt()
        Next i

        lblResult().Text = "All Threads have been stopped"

    End Sub
End Class

'This class encapsulates the worker thread functionality.  
Class MQListen

    Private m_strMachineName As String
    Private m_strQueueName As String

    'constructor accepts the necessary queue information
    Sub MQListen(ByVal MachineName As String, ByVal QueueName As String)
        m_strMachineName = MachineName
        m_strQueueName = QueueName
    End Sub

    'One and only method that each thread uses to 
    Sub Listen()

        'Create a MessageQueue object
        Dim ObjMQ As System.Messaging.MessageQueue = New System.Messaging.MessageQueue()
        'Create a Message object
        Dim ObjMsg As System.Messaging.Message = New System.Messaging.Message()

        Try

            'Set the path property on the MessageQueue object
            ObjMQ.Path = m_strMachineName & "\private$\" & m_strQueueName

            While True
                Try
                    'sleep in order to catch the interrupt if it has been thrown
                    'Interrupt will only be processed by a thread that is in a 
                    'wait, sleep or join state
                    Thread.CurrentThread.Sleep(100)

                    'Set the Message object equal to the result from the receive function
                    'there are 2 implementations of Receive.  The one I use requires a 
                    'TimeSpan object which specifies the timeout period.  There is also an
                    'implementation of Receive which requires nothing and will wait indefinitely
                    'for a message to arrive on a queue
                    'Timespan(days, hours, minutes, seconds)
                    objMsg = objMQ.Receive(New TimeSpan(0, 0, 0, 1))

                    'Display the received message's label
                    MessageBox.Show(" Label: " & ObjMsg.Label)
                Catch e As ThreadInterruptedException
                    'catch the ThreadInterrupt from the main thread and exit
                    Console.WriteLine("Exiting Thread")
                    Exit While
                Catch Excp As Exception
                    'Catch any exceptions thrown in receive
                    'MsgBox("No message received in 10 seconds")
                    Console.WriteLine(Excp.Message)
                End Try

            End While

        Catch e As ThreadInterruptedException
            'catch the ThreadInterrupt from the main thread and exit
            Console.WriteLine("Exiting Thread")

        End Try

        'exit thread

    End Sub


End Class
