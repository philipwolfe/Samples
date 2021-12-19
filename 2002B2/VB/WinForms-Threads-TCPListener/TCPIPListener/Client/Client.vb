Option Explicit On 
Option Strict On

Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Threading
Imports System.Net.Sockets

Public Class Form1
    Inherits System.Windows.Forms.Form
    
    Private ActiveThreads() As Thread
    Private ActiveThreadsState() As Integer

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
        If Not (components Is Nothing) Then
            components.Dispose()
        End If
    End Sub

#Region " Windows Form Designer generated code "

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container
    Private WithEvents lstOutput As System.Windows.Forms.ListBox
    Private WithEvents cmdStop As System.Windows.Forms.Button
    Private WithEvents Label1 As System.Windows.Forms.Label


    Private WithEvents txtClientCount As System.Windows.Forms.TextBox

    Private WithEvents cmdStart As System.Windows.Forms.Button

    Dim WithEvents Form1 As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.txtClientCount = New System.Windows.Forms.TextBox()
        Me.cmdStop = New System.Windows.Forms.Button()
        Me.cmdStart = New System.Windows.Forms.Button()
        Me.lstOutput = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()

        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        '@design Me.GridSize = New System.Drawing.Size(8, 8)
        txtClientCount.Location = New System.Drawing.Point(160, 8)
        txtClientCount.Text = "10"
        txtClientCount.TabIndex = 2
        txtClientCount.Size = New System.Drawing.Size(32, 20)

        cmdStop.Location = New System.Drawing.Point(208, 8)
        cmdStop.Size = New System.Drawing.Size(64, 24)
        cmdStop.TabIndex = 6
        cmdStop.Text = "Stop"

        cmdStart.Location = New System.Drawing.Point(8, 8)
        cmdStart.Size = New System.Drawing.Size(64, 24)
        cmdStart.TabIndex = 0
        cmdStart.Text = "Start"

        lstOutput.Location = New System.Drawing.Point(8, 48)
        lstOutput.Size = New System.Drawing.Size(328, 225)
        lstOutput.TabIndex = 7

        Label1.Location = New System.Drawing.Point(80, 10)
        Label1.Text = "Client Count:"
        Label1.Size = New System.Drawing.Size(72, 16)
        Label1.TabIndex = 5
        Label1.TextAlign = ContentAlignment.MiddleRight

        Me.Text = "Client"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(344, 285)

        Me.Controls.Add(lstOutput)
        Me.Controls.Add(cmdStop)
        Me.Controls.Add(Label1)
        Me.Controls.Add(txtClientCount)
        Me.Controls.Add(cmdStart)
    End Sub

#End Region

    Protected Sub cmdStop_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdStop.click

        Dim i As Integer

        For i = 0 To UBound(ActiveThreads)
            ActiveThreads(i).Abort()
            ActiveThreads(i) = Nothing
        Next

    End Sub

    Protected Sub cmdStart_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdStart.click

        Dim i As Integer
        Dim ClientCount As Integer
        Dim ActiveThreadStart As ThreadStart
        ClientCount = Int32.Parse(txtClientCount.Text)
        ReDim ActiveThreads(ClientCount - 1)
        ReDim ActiveThreadsState(ClientCount - 1)

        For i = 0 To ClientCount - 1
            'Create a ThreadStart object, passing the address of NewThread             
            ActiveThreadStart = New ThreadStart(AddressOf StartClient)
            'clear any existing threads (if the start button was clicked more than once)
            ActiveThreads(i) = Nothing
            'Create a Thread object 
            ActiveThreads(i) = New Thread(ActiveThreadstart)
            'Starting the thread invokes the ThreadStart delegate
            ActiveThreads(i).Name = i.ToString
            ActiveThreadsState(i) = System.Threading.ThreadState.Running

            ActiveThreads(i).Start()
        Next i

    End Sub

    Protected Sub StartClient()

        Dim NewThread As Thread
        Dim ThreadName As String
        Dim Client As TcpClient
        Dim Buffer() As Byte
        Dim InBuff(100) As Byte
        Dim Temp As String

        NewThread = System.Threading.Thread.CurrentThread
        ThreadName = NewThread.Name

        While True
            Client = New TcpClient()

            Try
                Client.Connect("localhost", 9105)
            Catch e As Exception
                SyncLock NewThread
                    lstOutput.Items.Insert(lstOutput.Items.Count, "Connection to server failed with return code: " & e.Message)
                    lstOutput.SelectedIndex = lstOutput.Items.Count - 1
                End SyncLock

                Exit Sub
            End Try

            Temp = System.DateTime.Now & " Message from Client #" & ThreadName
            Buffer = System.Text.Encoding.ASCII.GetBytes(Temp.ToCharArray)

            Client.GetStream().Write(Buffer, 0, Buffer.Length)

            While Not Client.GetStream.DataAvailable()
                Application.DoEvents()
            End While

            If Client.GetStream.DataAvailable() Then
                Client.GetStream().Read(InBuff, 0, InBuff.Length)
                Temp = "Client #" & ThreadName & " " & System.Text.Encoding.ASCII.GetString(InBuff)
                SyncLock NewThread
                    lstOutput.Items.Insert(lstOutput.Items.Count, Temp)
                    lstOutput.SelectedIndex = lstOutput.Items.Count - 1
                End SyncLock
            End If

            Client.Close()
        End While

    End Sub

End Class
