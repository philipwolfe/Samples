'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).



Option Strict On

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
    Friend WithEvents DisplayText As System.Windows.Forms.RichTextBox
    Friend WithEvents btnCurrentProcessInfo As System.Windows.Forms.Button
    Friend WithEvents btnStartProcess As System.Windows.Forms.Button
    Friend WithEvents btnProcessStartInfo As System.Windows.Forms.Button
    Friend WithEvents btnTaskManager As System.Windows.Forms.Button
    Friend WithEvents btnShellExecute As System.Windows.Forms.Button
    Friend WithEvents btnCommandLine As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.btnStartProcess = New System.Windows.Forms.Button()
        Me.btnProcessStartInfo = New System.Windows.Forms.Button()
        Me.btnCurrentProcessInfo = New System.Windows.Forms.Button()
        Me.btnTaskManager = New System.Windows.Forms.Button()
        Me.DisplayText = New System.Windows.Forms.RichTextBox()
        Me.btnShellExecute = New System.Windows.Forms.Button()
        Me.btnCommandLine = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'mnuMain
        '
        Me.mnuMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.mnuHelp})
        Me.mnuMain.RightToLeft = CType(resources.GetObject("mnuMain.RightToLeft"), System.Windows.Forms.RightToLeft)
        '
        'mnuFile
        '
        Me.mnuFile.Enabled = CType(resources.GetObject("mnuFile.Enabled"), Boolean)
        Me.mnuFile.Index = 0
        Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuExit})
        Me.mnuFile.Shortcut = CType(resources.GetObject("mnuFile.Shortcut"), System.Windows.Forms.Shortcut)
        Me.mnuFile.ShowShortcut = CType(resources.GetObject("mnuFile.ShowShortcut"), Boolean)
        Me.mnuFile.Text = resources.GetString("mnuFile.Text")
        Me.mnuFile.Visible = CType(resources.GetObject("mnuFile.Visible"), Boolean)
        '
        'mnuExit
        '
        Me.mnuExit.Enabled = CType(resources.GetObject("mnuExit.Enabled"), Boolean)
        Me.mnuExit.Index = 0
        Me.mnuExit.Shortcut = CType(resources.GetObject("mnuExit.Shortcut"), System.Windows.Forms.Shortcut)
        Me.mnuExit.ShowShortcut = CType(resources.GetObject("mnuExit.ShowShortcut"), Boolean)
        Me.mnuExit.Text = resources.GetString("mnuExit.Text")
        Me.mnuExit.Visible = CType(resources.GetObject("mnuExit.Visible"), Boolean)
        '
        'mnuHelp
        '
        Me.mnuHelp.Enabled = CType(resources.GetObject("mnuHelp.Enabled"), Boolean)
        Me.mnuHelp.Index = 1
        Me.mnuHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAbout})
        Me.mnuHelp.Shortcut = CType(resources.GetObject("mnuHelp.Shortcut"), System.Windows.Forms.Shortcut)
        Me.mnuHelp.ShowShortcut = CType(resources.GetObject("mnuHelp.ShowShortcut"), Boolean)
        Me.mnuHelp.Text = resources.GetString("mnuHelp.Text")
        Me.mnuHelp.Visible = CType(resources.GetObject("mnuHelp.Visible"), Boolean)
        '
        'mnuAbout
        '
        Me.mnuAbout.Enabled = CType(resources.GetObject("mnuAbout.Enabled"), Boolean)
        Me.mnuAbout.Index = 0
        Me.mnuAbout.Shortcut = CType(resources.GetObject("mnuAbout.Shortcut"), System.Windows.Forms.Shortcut)
        Me.mnuAbout.ShowShortcut = CType(resources.GetObject("mnuAbout.ShowShortcut"), Boolean)
        Me.mnuAbout.Text = resources.GetString("mnuAbout.Text")
        Me.mnuAbout.Visible = CType(resources.GetObject("mnuAbout.Visible"), Boolean)
        '
        'btnStartProcess
        '
        Me.btnStartProcess.AccessibleDescription = CType(resources.GetObject("btnStartProcess.AccessibleDescription"), String)
        Me.btnStartProcess.AccessibleName = CType(resources.GetObject("btnStartProcess.AccessibleName"), String)
        Me.btnStartProcess.Anchor = CType(resources.GetObject("btnStartProcess.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnStartProcess.BackgroundImage = CType(resources.GetObject("btnStartProcess.BackgroundImage"), System.Drawing.Image)
        Me.btnStartProcess.Dock = CType(resources.GetObject("btnStartProcess.Dock"), System.Windows.Forms.DockStyle)
        Me.btnStartProcess.Enabled = CType(resources.GetObject("btnStartProcess.Enabled"), Boolean)
        Me.btnStartProcess.FlatStyle = CType(resources.GetObject("btnStartProcess.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnStartProcess.Font = CType(resources.GetObject("btnStartProcess.Font"), System.Drawing.Font)
        Me.btnStartProcess.Image = CType(resources.GetObject("btnStartProcess.Image"), System.Drawing.Image)
        Me.btnStartProcess.ImageAlign = CType(resources.GetObject("btnStartProcess.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnStartProcess.ImageIndex = CType(resources.GetObject("btnStartProcess.ImageIndex"), Integer)
        Me.btnStartProcess.ImeMode = CType(resources.GetObject("btnStartProcess.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnStartProcess.Location = CType(resources.GetObject("btnStartProcess.Location"), System.Drawing.Point)
        Me.btnStartProcess.Name = "btnStartProcess"
        Me.btnStartProcess.RightToLeft = CType(resources.GetObject("btnStartProcess.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnStartProcess.Size = CType(resources.GetObject("btnStartProcess.Size"), System.Drawing.Size)
        Me.btnStartProcess.TabIndex = CType(resources.GetObject("btnStartProcess.TabIndex"), Integer)
        Me.btnStartProcess.Text = resources.GetString("btnStartProcess.Text")
        Me.btnStartProcess.TextAlign = CType(resources.GetObject("btnStartProcess.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnStartProcess.Visible = CType(resources.GetObject("btnStartProcess.Visible"), Boolean)
        '
        'btnProcessStartInfo
        '
        Me.btnProcessStartInfo.AccessibleDescription = CType(resources.GetObject("btnProcessStartInfo.AccessibleDescription"), String)
        Me.btnProcessStartInfo.AccessibleName = CType(resources.GetObject("btnProcessStartInfo.AccessibleName"), String)
        Me.btnProcessStartInfo.Anchor = CType(resources.GetObject("btnProcessStartInfo.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnProcessStartInfo.BackgroundImage = CType(resources.GetObject("btnProcessStartInfo.BackgroundImage"), System.Drawing.Image)
        Me.btnProcessStartInfo.Dock = CType(resources.GetObject("btnProcessStartInfo.Dock"), System.Windows.Forms.DockStyle)
        Me.btnProcessStartInfo.Enabled = CType(resources.GetObject("btnProcessStartInfo.Enabled"), Boolean)
        Me.btnProcessStartInfo.FlatStyle = CType(resources.GetObject("btnProcessStartInfo.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnProcessStartInfo.Font = CType(resources.GetObject("btnProcessStartInfo.Font"), System.Drawing.Font)
        Me.btnProcessStartInfo.Image = CType(resources.GetObject("btnProcessStartInfo.Image"), System.Drawing.Image)
        Me.btnProcessStartInfo.ImageAlign = CType(resources.GetObject("btnProcessStartInfo.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnProcessStartInfo.ImageIndex = CType(resources.GetObject("btnProcessStartInfo.ImageIndex"), Integer)
        Me.btnProcessStartInfo.ImeMode = CType(resources.GetObject("btnProcessStartInfo.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnProcessStartInfo.Location = CType(resources.GetObject("btnProcessStartInfo.Location"), System.Drawing.Point)
        Me.btnProcessStartInfo.Name = "btnProcessStartInfo"
        Me.btnProcessStartInfo.RightToLeft = CType(resources.GetObject("btnProcessStartInfo.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnProcessStartInfo.Size = CType(resources.GetObject("btnProcessStartInfo.Size"), System.Drawing.Size)
        Me.btnProcessStartInfo.TabIndex = CType(resources.GetObject("btnProcessStartInfo.TabIndex"), Integer)
        Me.btnProcessStartInfo.Text = resources.GetString("btnProcessStartInfo.Text")
        Me.btnProcessStartInfo.TextAlign = CType(resources.GetObject("btnProcessStartInfo.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnProcessStartInfo.Visible = CType(resources.GetObject("btnProcessStartInfo.Visible"), Boolean)
        '
        'btnCurrentProcessInfo
        '
        Me.btnCurrentProcessInfo.AccessibleDescription = CType(resources.GetObject("btnCurrentProcessInfo.AccessibleDescription"), String)
        Me.btnCurrentProcessInfo.AccessibleName = CType(resources.GetObject("btnCurrentProcessInfo.AccessibleName"), String)
        Me.btnCurrentProcessInfo.Anchor = CType(resources.GetObject("btnCurrentProcessInfo.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnCurrentProcessInfo.BackgroundImage = CType(resources.GetObject("btnCurrentProcessInfo.BackgroundImage"), System.Drawing.Image)
        Me.btnCurrentProcessInfo.Dock = CType(resources.GetObject("btnCurrentProcessInfo.Dock"), System.Windows.Forms.DockStyle)
        Me.btnCurrentProcessInfo.Enabled = CType(resources.GetObject("btnCurrentProcessInfo.Enabled"), Boolean)
        Me.btnCurrentProcessInfo.FlatStyle = CType(resources.GetObject("btnCurrentProcessInfo.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnCurrentProcessInfo.Font = CType(resources.GetObject("btnCurrentProcessInfo.Font"), System.Drawing.Font)
        Me.btnCurrentProcessInfo.Image = CType(resources.GetObject("btnCurrentProcessInfo.Image"), System.Drawing.Image)
        Me.btnCurrentProcessInfo.ImageAlign = CType(resources.GetObject("btnCurrentProcessInfo.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnCurrentProcessInfo.ImageIndex = CType(resources.GetObject("btnCurrentProcessInfo.ImageIndex"), Integer)
        Me.btnCurrentProcessInfo.ImeMode = CType(resources.GetObject("btnCurrentProcessInfo.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnCurrentProcessInfo.Location = CType(resources.GetObject("btnCurrentProcessInfo.Location"), System.Drawing.Point)
        Me.btnCurrentProcessInfo.Name = "btnCurrentProcessInfo"
        Me.btnCurrentProcessInfo.RightToLeft = CType(resources.GetObject("btnCurrentProcessInfo.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnCurrentProcessInfo.Size = CType(resources.GetObject("btnCurrentProcessInfo.Size"), System.Drawing.Size)
        Me.btnCurrentProcessInfo.TabIndex = CType(resources.GetObject("btnCurrentProcessInfo.TabIndex"), Integer)
        Me.btnCurrentProcessInfo.Text = resources.GetString("btnCurrentProcessInfo.Text")
        Me.btnCurrentProcessInfo.TextAlign = CType(resources.GetObject("btnCurrentProcessInfo.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnCurrentProcessInfo.Visible = CType(resources.GetObject("btnCurrentProcessInfo.Visible"), Boolean)
        '
        'btnTaskManager
        '
        Me.btnTaskManager.AccessibleDescription = CType(resources.GetObject("btnTaskManager.AccessibleDescription"), String)
        Me.btnTaskManager.AccessibleName = CType(resources.GetObject("btnTaskManager.AccessibleName"), String)
        Me.btnTaskManager.Anchor = CType(resources.GetObject("btnTaskManager.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnTaskManager.BackgroundImage = CType(resources.GetObject("btnTaskManager.BackgroundImage"), System.Drawing.Image)
        Me.btnTaskManager.Dock = CType(resources.GetObject("btnTaskManager.Dock"), System.Windows.Forms.DockStyle)
        Me.btnTaskManager.Enabled = CType(resources.GetObject("btnTaskManager.Enabled"), Boolean)
        Me.btnTaskManager.FlatStyle = CType(resources.GetObject("btnTaskManager.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnTaskManager.Font = CType(resources.GetObject("btnTaskManager.Font"), System.Drawing.Font)
        Me.btnTaskManager.Image = CType(resources.GetObject("btnTaskManager.Image"), System.Drawing.Image)
        Me.btnTaskManager.ImageAlign = CType(resources.GetObject("btnTaskManager.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnTaskManager.ImageIndex = CType(resources.GetObject("btnTaskManager.ImageIndex"), Integer)
        Me.btnTaskManager.ImeMode = CType(resources.GetObject("btnTaskManager.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnTaskManager.Location = CType(resources.GetObject("btnTaskManager.Location"), System.Drawing.Point)
        Me.btnTaskManager.Name = "btnTaskManager"
        Me.btnTaskManager.RightToLeft = CType(resources.GetObject("btnTaskManager.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnTaskManager.Size = CType(resources.GetObject("btnTaskManager.Size"), System.Drawing.Size)
        Me.btnTaskManager.TabIndex = CType(resources.GetObject("btnTaskManager.TabIndex"), Integer)
        Me.btnTaskManager.Text = resources.GetString("btnTaskManager.Text")
        Me.btnTaskManager.TextAlign = CType(resources.GetObject("btnTaskManager.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnTaskManager.Visible = CType(resources.GetObject("btnTaskManager.Visible"), Boolean)
        '
        'DisplayText
        '
        Me.DisplayText.AccessibleDescription = CType(resources.GetObject("DisplayText.AccessibleDescription"), String)
        Me.DisplayText.AccessibleName = CType(resources.GetObject("DisplayText.AccessibleName"), String)
        Me.DisplayText.Anchor = CType(resources.GetObject("DisplayText.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.DisplayText.AutoSize = CType(resources.GetObject("DisplayText.AutoSize"), Boolean)
        Me.DisplayText.BackgroundImage = CType(resources.GetObject("DisplayText.BackgroundImage"), System.Drawing.Image)
        Me.DisplayText.BulletIndent = CType(resources.GetObject("DisplayText.BulletIndent"), Integer)
        Me.DisplayText.Dock = CType(resources.GetObject("DisplayText.Dock"), System.Windows.Forms.DockStyle)
        Me.DisplayText.Enabled = CType(resources.GetObject("DisplayText.Enabled"), Boolean)
        Me.DisplayText.Font = CType(resources.GetObject("DisplayText.Font"), System.Drawing.Font)
        Me.DisplayText.ImeMode = CType(resources.GetObject("DisplayText.ImeMode"), System.Windows.Forms.ImeMode)
        Me.DisplayText.Location = CType(resources.GetObject("DisplayText.Location"), System.Drawing.Point)
        Me.DisplayText.MaxLength = CType(resources.GetObject("DisplayText.MaxLength"), Integer)
        Me.DisplayText.Multiline = CType(resources.GetObject("DisplayText.Multiline"), Boolean)
        Me.DisplayText.Name = "DisplayText"
        Me.DisplayText.RightMargin = CType(resources.GetObject("DisplayText.RightMargin"), Integer)
        Me.DisplayText.RightToLeft = CType(resources.GetObject("DisplayText.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.DisplayText.ScrollBars = CType(resources.GetObject("DisplayText.ScrollBars"), System.Windows.Forms.RichTextBoxScrollBars)
        Me.DisplayText.Size = CType(resources.GetObject("DisplayText.Size"), System.Drawing.Size)
        Me.DisplayText.TabIndex = CType(resources.GetObject("DisplayText.TabIndex"), Integer)
        Me.DisplayText.Text = resources.GetString("DisplayText.Text")
        Me.DisplayText.Visible = CType(resources.GetObject("DisplayText.Visible"), Boolean)
        Me.DisplayText.WordWrap = CType(resources.GetObject("DisplayText.WordWrap"), Boolean)
        Me.DisplayText.ZoomFactor = CType(resources.GetObject("DisplayText.ZoomFactor"), Single)
        '
        'btnShellExecute
        '
        Me.btnShellExecute.AccessibleDescription = CType(resources.GetObject("btnShellExecute.AccessibleDescription"), String)
        Me.btnShellExecute.AccessibleName = CType(resources.GetObject("btnShellExecute.AccessibleName"), String)
        Me.btnShellExecute.Anchor = CType(resources.GetObject("btnShellExecute.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnShellExecute.BackgroundImage = CType(resources.GetObject("btnShellExecute.BackgroundImage"), System.Drawing.Image)
        Me.btnShellExecute.Dock = CType(resources.GetObject("btnShellExecute.Dock"), System.Windows.Forms.DockStyle)
        Me.btnShellExecute.Enabled = CType(resources.GetObject("btnShellExecute.Enabled"), Boolean)
        Me.btnShellExecute.FlatStyle = CType(resources.GetObject("btnShellExecute.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnShellExecute.Font = CType(resources.GetObject("btnShellExecute.Font"), System.Drawing.Font)
        Me.btnShellExecute.Image = CType(resources.GetObject("btnShellExecute.Image"), System.Drawing.Image)
        Me.btnShellExecute.ImageAlign = CType(resources.GetObject("btnShellExecute.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnShellExecute.ImageIndex = CType(resources.GetObject("btnShellExecute.ImageIndex"), Integer)
        Me.btnShellExecute.ImeMode = CType(resources.GetObject("btnShellExecute.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnShellExecute.Location = CType(resources.GetObject("btnShellExecute.Location"), System.Drawing.Point)
        Me.btnShellExecute.Name = "btnShellExecute"
        Me.btnShellExecute.RightToLeft = CType(resources.GetObject("btnShellExecute.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnShellExecute.Size = CType(resources.GetObject("btnShellExecute.Size"), System.Drawing.Size)
        Me.btnShellExecute.TabIndex = CType(resources.GetObject("btnShellExecute.TabIndex"), Integer)
        Me.btnShellExecute.Text = resources.GetString("btnShellExecute.Text")
        Me.btnShellExecute.TextAlign = CType(resources.GetObject("btnShellExecute.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnShellExecute.Visible = CType(resources.GetObject("btnShellExecute.Visible"), Boolean)
        '
        'btnCommandLine
        '
        Me.btnCommandLine.AccessibleDescription = CType(resources.GetObject("btnCommandLine.AccessibleDescription"), String)
        Me.btnCommandLine.AccessibleName = CType(resources.GetObject("btnCommandLine.AccessibleName"), String)
        Me.btnCommandLine.Anchor = CType(resources.GetObject("btnCommandLine.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnCommandLine.BackgroundImage = CType(resources.GetObject("btnCommandLine.BackgroundImage"), System.Drawing.Image)
        Me.btnCommandLine.Dock = CType(resources.GetObject("btnCommandLine.Dock"), System.Windows.Forms.DockStyle)
        Me.btnCommandLine.Enabled = CType(resources.GetObject("btnCommandLine.Enabled"), Boolean)
        Me.btnCommandLine.FlatStyle = CType(resources.GetObject("btnCommandLine.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnCommandLine.Font = CType(resources.GetObject("btnCommandLine.Font"), System.Drawing.Font)
        Me.btnCommandLine.Image = CType(resources.GetObject("btnCommandLine.Image"), System.Drawing.Image)
        Me.btnCommandLine.ImageAlign = CType(resources.GetObject("btnCommandLine.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnCommandLine.ImageIndex = CType(resources.GetObject("btnCommandLine.ImageIndex"), Integer)
        Me.btnCommandLine.ImeMode = CType(resources.GetObject("btnCommandLine.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnCommandLine.Location = CType(resources.GetObject("btnCommandLine.Location"), System.Drawing.Point)
        Me.btnCommandLine.Name = "btnCommandLine"
        Me.btnCommandLine.RightToLeft = CType(resources.GetObject("btnCommandLine.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnCommandLine.Size = CType(resources.GetObject("btnCommandLine.Size"), System.Drawing.Size)
        Me.btnCommandLine.TabIndex = CType(resources.GetObject("btnCommandLine.TabIndex"), Integer)
        Me.btnCommandLine.Text = resources.GetString("btnCommandLine.Text")
        Me.btnCommandLine.TextAlign = CType(resources.GetObject("btnCommandLine.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnCommandLine.Visible = CType(resources.GetObject("btnCommandLine.Visible"), Boolean)
        '
        'frmMain
        '
        Me.AccessibleDescription = CType(resources.GetObject("$this.AccessibleDescription"), String)
        Me.AccessibleName = CType(resources.GetObject("$this.AccessibleName"), String)
        Me.Anchor = CType(resources.GetObject("$this.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.AutoScaleBaseSize = CType(resources.GetObject("$this.AutoScaleBaseSize"), System.Drawing.Size)
        Me.AutoScroll = CType(resources.GetObject("$this.AutoScroll"), Boolean)
        Me.AutoScrollMargin = CType(resources.GetObject("$this.AutoScrollMargin"), System.Drawing.Size)
        Me.AutoScrollMinSize = CType(resources.GetObject("$this.AutoScrollMinSize"), System.Drawing.Size)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = CType(resources.GetObject("$this.ClientSize"), System.Drawing.Size)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCommandLine, Me.btnShellExecute, Me.DisplayText, Me.btnTaskManager, Me.btnCurrentProcessInfo, Me.btnProcessStartInfo, Me.btnStartProcess})
        Me.Dock = CType(resources.GetObject("$this.Dock"), System.Windows.Forms.DockStyle)
        Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
        Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Location = CType(resources.GetObject("$this.Location"), System.Drawing.Point)
        Me.MaximizeBox = False
        Me.MaximumSize = CType(resources.GetObject("$this.MaximumSize"), System.Drawing.Size)
        Me.Menu = Me.mnuMain
        Me.MinimumSize = CType(resources.GetObject("$this.MinimumSize"), System.Drawing.Size)
        Me.Name = "frmMain"
        Me.RightToLeft = CType(resources.GetObject("$this.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.StartPosition = CType(resources.GetObject("$this.StartPosition"), System.Windows.Forms.FormStartPosition)
        Me.Text = resources.GetString("$this.Text")
        Me.Visible = CType(resources.GetObject("$this.Visible"), Boolean)
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


    Private Sub CurrentProcessInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCurrentProcessInfo.Click
        ' Shows how to retrieve information about the current Process.
        Dim curProc As Process = Process.GetCurrentProcess()

        Dim s As String = "The total working set of the current process is: " + _
                curProc.WorkingSet.ToString() + vbCrLf

        s += "The minimum working set of the current process is: " + _
                curProc.MinWorkingSet.ToString() + vbCrLf

        s += "The max working set of the current process is: " + _
                curProc.MaxWorkingSet.ToString() + vbCrLf

        s += "The start time of the current process is: " + _
                curProc.StartTime.ToLongTimeString() + vbCrLf

        s += "The processor time used by the current process is: " + _
        curProc.TotalProcessorTime.ToString() + vbCrLf

        DisplayText.Text = s
    End Sub

    Private Sub btnStartProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStartProcess.Click
        ' Simple Demonstration of starting a process using the process class.
        Process.Start("notepad.exe")
    End Sub

    Private Sub btnProcessStartInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcessStartInfo.Click
        ' The StartInfo object allows you to pass additional parameters to your application 
        ' before starting it.  In this case the default window state of the application is set.
        Dim startInfo As New ProcessStartInfo("notepad.exe")
        startInfo.WindowStyle = ProcessWindowStyle.Maximized
        Process.Start(startInfo)
    End Sub

    Private Sub btnTaskManager_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTaskManager.Click
        ' Using the process class you can get access to additional information such as the 
        ' modules loaded by a process.  The form shown by this code illustrates this.
        Dim f As New frmTaskManager()
        f.Show()
    End Sub

    Private Sub btnShellExecute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShellExecute.Click
        
        If Not System.IO.File.Exists("c:\demofile_shell.txt") Then
            Dim sw As New System.IO.StreamWriter("c:\demofile_shell.txt")
            sw.WriteLine("Shell Execute Demo")
            sw.Close()
        End If

        ' The StartInfo class can also be used to specify that you wish Operating System Shell 
        ' to execute the process.  'This means that you can pass file names with extensions that
        ' are known by the operating system and the operating system will launch the appropriate
        ' application type.
        Dim startInfo As New ProcessStartInfo("c:\demofile_shell.txt")
        ' The default for UseShellExecute is false. If this is not set an exception would be 
        ' thrown when the start method is executed.
        startInfo.UseShellExecute = True
        Process.Start(startInfo)

    End Sub

    Private Sub btnCommandLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCommandLine.Click
        ' Starts Windows Explorer with two different command line arguments.
        Dim startInfo As New ProcessStartInfo("explorer.exe")
        ' Opens a new single-pane Window for the default selection. 
        ' This is usually the root of the drive on which Windows is installed. 
        startInfo.Arguments = "/n"
        Process.Start(startInfo)
    End Sub

End Class