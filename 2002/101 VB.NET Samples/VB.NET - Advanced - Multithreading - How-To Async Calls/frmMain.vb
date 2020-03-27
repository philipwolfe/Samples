'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Imports System.Threading 'Namespace for Thread class

Public Class frmMain
	Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

	Public Sub New()
		MyBase.New()

		'This call is required by the Windows Form Designer.
		InitializeComponent()

		'Add any initialization after the InitializeComponent() call

		' So that we only need to set the title of the application once,
		' we use the AssemblyInfo class (defined in the AssemblyInfo.vb file)
		' to read the AssemblyTitle attribute.
		Dim ainfo As New AssemblyInfo()

		Me.Text = ainfo.Title
		Me.mnuAbout.Text = String.Format("&About {0} ...", ainfo.Title)

	End Sub

	'Form overrides dispose to clean up the component list.
	Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing Then
			If Not (components Is Nothing) Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(disposing)
	End Sub

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	Friend WithEvents mnuMain As System.Windows.Forms.MainMenu
	Friend WithEvents mnuFile As System.Windows.Forms.MenuItem
	Friend WithEvents mnuExit As System.Windows.Forms.MenuItem
	Friend WithEvents mnuHelp As System.Windows.Forms.MenuItem
	Friend WithEvents mnuAbout As System.Windows.Forms.MenuItem
    Friend WithEvents grpLongRunningTask As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSameThread As System.Windows.Forms.Button
    Friend WithEvents cmdWorkerPoolThread As System.Windows.Forms.Button
    Friend WithEvents cmdRunOnNewWin32Thread As System.Windows.Forms.Button
    Friend WithEvents lblThreadID As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
		Me.mnuMain = New System.Windows.Forms.MainMenu()
		Me.mnuFile = New System.Windows.Forms.MenuItem()
		Me.mnuExit = New System.Windows.Forms.MenuItem()
		Me.mnuHelp = New System.Windows.Forms.MenuItem()
		Me.mnuAbout = New System.Windows.Forms.MenuItem()
		Me.grpLongRunningTask = New System.Windows.Forms.GroupBox()
		Me.cmdRunOnNewWin32Thread = New System.Windows.Forms.Button()
		Me.cmdWorkerPoolThread = New System.Windows.Forms.Button()
		Me.cmdSameThread = New System.Windows.Forms.Button()
		Me.lblThreadID = New System.Windows.Forms.Label()
		Me.grpLongRunningTask.SuspendLayout()
		Me.SuspendLayout()
		'
		'mnuMain
		'
		Me.mnuMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.mnuHelp})
		'
		'mnuFile
		'
		Me.mnuFile.Index = 0
		Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuExit})
		Me.mnuFile.Text = "&File"
		'
		'mnuExit
		'
		Me.mnuExit.Index = 0
		Me.mnuExit.Text = "E&xit"
		'
		'mnuHelp
		'
		Me.mnuHelp.Index = 1
		Me.mnuHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAbout})
		Me.mnuHelp.Text = "&Help"
		'
		'mnuAbout
		'
		Me.mnuAbout.Index = 0
		Me.mnuAbout.Text = "Text Comes from AssemblyInfo"
		'
		'grpLongRunningTask
		'
		Me.grpLongRunningTask.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdRunOnNewWin32Thread, Me.cmdWorkerPoolThread, Me.cmdSameThread})
		Me.grpLongRunningTask.Location = New System.Drawing.Point(16, 56)
		Me.grpLongRunningTask.Name = "grpLongRunningTask"
		Me.grpLongRunningTask.Size = New System.Drawing.Size(232, 144)
		Me.grpLongRunningTask.TabIndex = 3
		Me.grpLongRunningTask.TabStop = False
		Me.grpLongRunningTask.Text = "Execute a long-running task"
		'
		'cmdRunOnNewWin32Thread
		'
		Me.cmdRunOnNewWin32Thread.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.cmdRunOnNewWin32Thread.Location = New System.Drawing.Point(16, 96)
		Me.cmdRunOnNewWin32Thread.Name = "cmdRunOnNewWin32Thread"
		Me.cmdRunOnNewWin32Thread.Size = New System.Drawing.Size(200, 23)
		Me.cmdRunOnNewWin32Thread.TabIndex = 5
		Me.cmdRunOnNewWin32Thread.Text = "Run on &new Win32 thread"
		'
		'cmdWorkerPoolThread
		'
		Me.cmdWorkerPoolThread.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.cmdWorkerPoolThread.Location = New System.Drawing.Point(16, 64)
		Me.cmdWorkerPoolThread.Name = "cmdWorkerPoolThread"
		Me.cmdWorkerPoolThread.Size = New System.Drawing.Size(200, 23)
		Me.cmdWorkerPoolThread.TabIndex = 4
		Me.cmdWorkerPoolThread.Text = "Run on &worker pool thread"
		'
		'cmdSameThread
		'
		Me.cmdSameThread.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.cmdSameThread.Location = New System.Drawing.Point(16, 32)
		Me.cmdSameThread.Name = "cmdSameThread"
		Me.cmdSameThread.Size = New System.Drawing.Size(200, 23)
		Me.cmdSameThread.TabIndex = 3
		Me.cmdSameThread.Text = "Run on &same thread"
		'
		'lblThreadID
		'
		Me.lblThreadID.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.lblThreadID.Location = New System.Drawing.Point(16, 16)
		Me.lblThreadID.Name = "lblThreadID"
		Me.lblThreadID.Size = New System.Drawing.Size(240, 24)
		Me.lblThreadID.TabIndex = 4
		Me.lblThreadID.Text = "This window is being serviced by thread: "
		'
		'frmMain
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(266, 235)
		Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblThreadID, Me.grpLongRunningTask})
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.Menu = Me.mnuMain
		Me.Name = "frmMain"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Title Comes from Assembly Info"
		Me.grpLongRunningTask.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub

#End Region

#Region " Standard Menu Code "
	' <System.Diagnostics.DebuggerStepThrough()> has been added to some procedures since they are
	' not the focus of the demo. Remove them if you wish to debug the procedures.
	' This code simply shows the About form.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub mnuAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAbout.Click
		' Open the About form in Dialog Mode
		Dim frm As New frmAbout()
		frm.ShowDialog(Me)
		frm.Dispose()
	End Sub

	' This code will close the form.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
		' Close the current form
		Me.Close()
	End Sub
#End Region

    Private Sub frmMain_Load(ByVal sender As System.Object, _
                          ByVal e As System.EventArgs) _
                          Handles MyBase.Load
        'Display the main thread for the application 

        lblThreadID.Text &= CStr(AppDomain.GetCurrentThreadId())

    End Sub

    Private Sub cmdSameThread_Click(ByVal sender As System.Object, _
                                 ByVal e As System.EventArgs) _
                                 Handles cmdSameThread.Click
        'Run the task on the same thread that is managing the frmMain window.
		TheLongRunningTask()

    End Sub

    'To run the task on a worker pool thread, you can use an asynchronous
    'invocation on a delegate. For this example, we'll declare a delegate
    'named TaskDelegate, and call it asynchronously. The signature of the
    'delegate declaration must match the method (TheLongRunningTask) exactly.
    Delegate Sub TaskDelegate()

    <DebuggerStepThrough()> Private Sub cmdWorkerPoolThread_Click( _
                                      ByVal sender As System.Object, _
                                      ByVal e As System.EventArgs) _
                                      Handles cmdWorkerPoolThread.Click
        'To run the task an a thread from the worker pool, create an instance
        'of a delegate whose signature matches the method that will be called,
        'then call BeginInvoke on that delegate. For this example, the arguments
        'and return value of BeginInvoke are unneeded. This technique is sometimes
        'referred to as "Fire and Forget".

        Dim td As New TaskDelegate(AddressOf TheLongRunningTask)
        td.BeginInvoke(Nothing, Nothing) 'Runs on a worker thread from the pool

    End Sub

    <DebuggerStepThrough()> Private Sub cmdRunOnNewWin32Thread_Click( _
                                         ByVal sender As System.Object, _
                                         ByVal e As System.EventArgs) _
                                         Handles cmdRunOnNewWin32Thread.Click
        'To run the task on a newly created OS thread (rather than a tread from the
        'thread pool), create a new instance of a managed thread. The constructor 
        'takes the address of a subroutine with no arguments.

        Dim t As New Thread(AddressOf TheLongRunningTask) 'Creates the new thread
        t.Start() 'Begins the execution of the new thread

    End Sub

    <DebuggerStepThrough()> Private Sub TheLongRunningTask()
        'This method simulates some long-running task. To represent the work in 
        'progress, a form with a progress bar will display during its execution.
        'The method displays the form, then updates the progress bar every half
        'second for 5 seconds. After simulating the task, the form is taken down.

		Dim f As New frmTaskProgress()
		f.Show()
		f.Refresh()	   'Refresh causes an instant (non-posted) display of the label.

        'Slowly increment the progress bar
        Dim i As Integer
        For i = 1 To 10
            f.prgTaskProgress.Value += 10
            Thread.CurrentThread.Sleep(500) 'half-second delay
        Next

        'Remove the form after the "task" finishes
		f.Hide()
		f.Dispose()
	End Sub

End Class