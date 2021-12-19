'Option Strict Off

Imports System.Drawing
Imports System.Windows.Forms
Imports System.Threading

Imports System.ComponentModel

Public Class frmThread
    Inherits System.Windows.Forms.Form
    Private oThreads(6) As Thread
    Private oThreadStart As ThreadStart
    Private strThreadState(6) As String
    Private Const STARTED As String = "Started"
    Private Const STOPPED As String = "Stopped"
    Private Const FINISHED As String = "Finished"
    
    Public Sub New()
        MyBase.New()
        
        frmThread = Me
        
        'This call is required by the Win Form Designer.
        InitializeComponent()
        
        'TODO: Add any initialization after the InitializeComponent() call
        'Initialize the ProgressBars
        ProgressBar1.Minimum = 1
        ProgressBar1.Maximum = 50
        ProgressBar2.Minimum = 1
        ProgressBar2.Maximum = 50
        ProgressBar3.Minimum = 1
        ProgressBar3.Maximum = 50
        ProgressBar4.Minimum = 1
        ProgressBar4.Maximum = 50
        ProgressBar5.Minimum = 1
        ProgressBar5.Maximum = 50
        
    End Sub
    
    'Form overrides dispose to clean up the component list.
    Public Overrides Sub Dispose()
        MyBase.Dispose()
        components.Dispose()
    End Sub
    
#Region " Windows Form Designer generated code "
    
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container
    Private WithEvents Button6 As System.Windows.Forms.Button
    Private WithEvents Button5 As System.Windows.Forms.Button
    Private WithEvents Button4 As System.Windows.Forms.Button
    Private WithEvents Button3 As System.Windows.Forms.Button
    
    
    
    
    Private WithEvents Button2 As System.Windows.Forms.Button
    
    
    
    Private WithEvents Button1 As System.Windows.Forms.Button
    Private WithEvents ProgressBar5 As System.Windows.Forms.ProgressBar
    Private WithEvents ProgressBar4 As System.Windows.Forms.ProgressBar
    Private WithEvents ProgressBar3 As System.Windows.Forms.ProgressBar
    Private WithEvents ProgressBar2 As System.Windows.Forms.ProgressBar
    Private WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    
    Dim WithEvents frmThread As System.Windows.Forms.Form
    
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ProgressBar5 = New System.Windows.Forms.ProgressBar()
        Me.ProgressBar4 = New System.Windows.Forms.ProgressBar()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.ProgressBar3 = New System.Windows.Forms.ProgressBar()
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        
        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        Button4.Location = New System.Drawing.Point(152, 152)
        Button4.Size = New System.Drawing.Size(64, 23)
        Button4.TabIndex = 8
        Button4.Text = "Suspend"
        
        Button3.Location = New System.Drawing.Point(152, 104)
        Button3.Size = New System.Drawing.Size(64, 23)
        Button3.TabIndex = 7
        Button3.Text = "Suspend"
        
        Button2.Location = New System.Drawing.Point(152, 64)
        Button2.Size = New System.Drawing.Size(64, 23)
        Button2.TabIndex = 6
        Button2.Text = "Suspend"
        
        ProgressBar5.Location = New System.Drawing.Point(16, 232)
        ProgressBar5.TabIndex = 4
        ProgressBar5.Size = New System.Drawing.Size(128, 23)
        
        ProgressBar4.Location = New System.Drawing.Point(16, 192)
        ProgressBar4.TabIndex = 3
        ProgressBar4.Size = New System.Drawing.Size(128, 23)
        
        ProgressBar1.Location = New System.Drawing.Point(16, 64)
        ProgressBar1.TabIndex = 0
        ProgressBar1.Size = New System.Drawing.Size(128, 23)
        
        ProgressBar3.Location = New System.Drawing.Point(16, 152)
        ProgressBar3.TabIndex = 2
        ProgressBar3.Size = New System.Drawing.Size(128, 23)
        
        ProgressBar2.Location = New System.Drawing.Point(16, 104)
        ProgressBar2.TabIndex = 1
        ProgressBar2.Size = New System.Drawing.Size(128, 23)
        
        Button1.Location = New System.Drawing.Point(16, 16)
        Button1.Size = New System.Drawing.Size(88, 32)
        Button1.TabIndex = 5
        Button1.Text = "StartThreads"
        
        Button6.Location = New System.Drawing.Point(152, 232)
        Button6.Size = New System.Drawing.Size(64, 23)
        Button6.TabIndex = 10
        Button6.Text = "Suspend"
        
        Button5.Location = New System.Drawing.Point(152, 192)
        Button5.Size = New System.Drawing.Size(64, 23)
        Button5.TabIndex = 9
        Button5.Text = "Suspend"
        Me.Text = "frmThread"
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(296, 285)
        
        Me.Controls.Add(Button6)
        Me.Controls.Add(Button5)
        Me.Controls.Add(Button4)
        Me.Controls.Add(Button3)
        Me.Controls.Add(Button2)
        Me.Controls.Add(Button1)
        Me.Controls.Add(ProgressBar5)
        Me.Controls.Add(ProgressBar4)
        Me.Controls.Add(ProgressBar3)
        Me.Controls.Add(ProgressBar2)
        Me.Controls.Add(ProgressBar1)
    End Sub
    
#End Region
    
    Protected Sub Button6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button6.click
        Call ThreadState(5, Me.Button6)
    End Sub

    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.click
        Call ThreadState(4, Me.Button5)
    End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.click
        Call ThreadState(3, Me.Button4)
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.click
        Call ThreadState(2, Me.Button3)
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.click
        Call ThreadState(1, Me.Button2)
    End Sub

    Private Sub ThreadState(ByVal ThreadName As Integer, ByVal TheButton As Windows.Forms.Button)
        Select Case strThreadState(ThreadName)
            Case STARTED
                strThreadState(ThreadName) = STOPPED
                TheButton.Text = "Resume"
                oThreads(ThreadName).Suspend()
            Case STOPPED
                strThreadState(ThreadName) = STARTED
                TheButton.Text = "Suspend"
                oThreads(ThreadName).Resume()
            Case FINISHED
                'Do nothing
        End Select

    End Sub

    Public Sub NewThread()
        Dim oThread As Thread
        Dim oProgressBar As System.Windows.Forms.ProgressBar
        Dim oRandom As Random
        Dim i As Integer

        'Get a reference to myself
        'We will use this later to get the name of the thread        
        oThread = System.Threading.Thread.CurrentThread()

        'Here we go!
        Debug.Write("NewThread is running on thread" & oThread.Name)

        'Create an instance of a Random object
        'We are seeding the random number generator with
        'The thread number + the current second, which will
        'Give each thread a different sequence of random numbers
        oRandom = New Random(CInt(oThread.Name) + Second(Now))

        'Using the thread's name we get a reference to the
        'ProgressBar it is responsible for updating
        Select Case oThread.Name
            Case "1"
                oProgressBar = ProgressBar1
            Case "2"
                oProgressBar = ProgressBar2
            Case "3"
                oProgressBar = ProgressBar3
            Case "4"
                oProgressBar = ProgressBar4
            Case "5"
                oProgressBar = ProgressBar5
        End Select

        For i = 1 To 50

            Try
                SyncLock oThread
                    'Update the ProgressBar
                    oProgressBar.Value = i
                    'Sleep a random number of milliseconds
                    'NextDouble will return the next random
                    'Number in the sequence

                    oThread.Sleep(Convert.ToInt32(oRandom.NextDouble) * 1000)
                End SyncLock

            Catch
                'sync conflict
            End Try
        Next i
        'We're through so let's announce it        
        Debug.Write("Thread" & oThread.Name & " has exited.")

        'Mark the thread as "finished"
        strThreadState(CInt(oThread.Name)) = FINISHED

    End Sub


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.click
        Dim i As Integer

        For i = 1 To 5
            'Create a ThreadStart object, passing the address of NewThread             
            oThreadStart = New ThreadStart(AddressOf NewThread)
            'clear any existing threads (if the start button was clicked more than once)
            oThreads(i) = Nothing
            'Create a Thread object 
            oThreads(i) = New Thread(oThreadStart)
            'Starting the thread invokes the ThreadStart delegate
            oThreads(i).Name = i.ToString
            strThreadState(i) = STARTED

            oThreads(i).Start()

        Next i

        Debug.Write("All threads started")
    End Sub

End Class
