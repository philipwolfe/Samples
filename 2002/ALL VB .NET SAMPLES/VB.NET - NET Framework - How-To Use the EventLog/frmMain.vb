
'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Public Class frmMain
    Inherits System.Windows.Forms.Form
    Private entryType As EventLogEntryType = EventLogEntryType.Error
    'When writing to an event log you need to pass the machine name where 
    'the log resides.  Here the MachineName Property of the Environment class 
    'is used to determine the name of the local machine.  Assuming you have 
    'the appropriate permissions it is also easy to write to event logs on 
    'other machines.
    Private machineName As String = Environment.MachineName
    Private logType As String = ""
    Dim frmWrite As New frmWrite()
    Dim frmRead As New frmRead()
    Dim frmCreateDelete As New frmCreateDelete()

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
    Friend WithEvents btnWrite As System.Windows.Forms.Button
    Friend WithEvents btnRead As System.Windows.Forms.Button
    Friend WithEvents btnCreateDelete As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.btnWrite = New System.Windows.Forms.Button()
        Me.btnRead = New System.Windows.Forms.Button()
        Me.btnCreateDelete = New System.Windows.Forms.Button()
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
        'btnWrite
        '
        Me.btnWrite.AccessibleDescription = resources.GetString("btnWrite.AccessibleDescription")
        Me.btnWrite.AccessibleName = resources.GetString("btnWrite.AccessibleName")
        Me.btnWrite.Anchor = CType(resources.GetObject("btnWrite.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnWrite.BackgroundImage = CType(resources.GetObject("btnWrite.BackgroundImage"), System.Drawing.Image)
        Me.btnWrite.Dock = CType(resources.GetObject("btnWrite.Dock"), System.Windows.Forms.DockStyle)
        Me.btnWrite.Enabled = CType(resources.GetObject("btnWrite.Enabled"), Boolean)
        Me.btnWrite.FlatStyle = CType(resources.GetObject("btnWrite.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnWrite.Font = CType(resources.GetObject("btnWrite.Font"), System.Drawing.Font)
        Me.btnWrite.Image = CType(resources.GetObject("btnWrite.Image"), System.Drawing.Image)
        Me.btnWrite.ImageAlign = CType(resources.GetObject("btnWrite.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnWrite.ImageIndex = CType(resources.GetObject("btnWrite.ImageIndex"), Integer)
        Me.btnWrite.ImeMode = CType(resources.GetObject("btnWrite.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnWrite.Location = CType(resources.GetObject("btnWrite.Location"), System.Drawing.Point)
        Me.btnWrite.Name = "btnWrite"
        Me.btnWrite.RightToLeft = CType(resources.GetObject("btnWrite.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnWrite.Size = CType(resources.GetObject("btnWrite.Size"), System.Drawing.Size)
        Me.btnWrite.TabIndex = CType(resources.GetObject("btnWrite.TabIndex"), Integer)
        Me.btnWrite.Text = resources.GetString("btnWrite.Text")
        Me.btnWrite.TextAlign = CType(resources.GetObject("btnWrite.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnWrite.Visible = CType(resources.GetObject("btnWrite.Visible"), Boolean)
        '
        'btnRead
        '
        Me.btnRead.AccessibleDescription = resources.GetString("btnRead.AccessibleDescription")
        Me.btnRead.AccessibleName = resources.GetString("btnRead.AccessibleName")
        Me.btnRead.Anchor = CType(resources.GetObject("btnRead.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnRead.BackgroundImage = CType(resources.GetObject("btnRead.BackgroundImage"), System.Drawing.Image)
        Me.btnRead.Dock = CType(resources.GetObject("btnRead.Dock"), System.Windows.Forms.DockStyle)
        Me.btnRead.Enabled = CType(resources.GetObject("btnRead.Enabled"), Boolean)
        Me.btnRead.FlatStyle = CType(resources.GetObject("btnRead.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnRead.Font = CType(resources.GetObject("btnRead.Font"), System.Drawing.Font)
        Me.btnRead.Image = CType(resources.GetObject("btnRead.Image"), System.Drawing.Image)
        Me.btnRead.ImageAlign = CType(resources.GetObject("btnRead.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnRead.ImageIndex = CType(resources.GetObject("btnRead.ImageIndex"), Integer)
        Me.btnRead.ImeMode = CType(resources.GetObject("btnRead.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnRead.Location = CType(resources.GetObject("btnRead.Location"), System.Drawing.Point)
        Me.btnRead.Name = "btnRead"
        Me.btnRead.RightToLeft = CType(resources.GetObject("btnRead.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnRead.Size = CType(resources.GetObject("btnRead.Size"), System.Drawing.Size)
        Me.btnRead.TabIndex = CType(resources.GetObject("btnRead.TabIndex"), Integer)
        Me.btnRead.Text = resources.GetString("btnRead.Text")
        Me.btnRead.TextAlign = CType(resources.GetObject("btnRead.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnRead.Visible = CType(resources.GetObject("btnRead.Visible"), Boolean)
        '
        'btnCreateDelete
        '
        Me.btnCreateDelete.AccessibleDescription = resources.GetString("btnCreateDelete.AccessibleDescription")
        Me.btnCreateDelete.AccessibleName = resources.GetString("btnCreateDelete.AccessibleName")
        Me.btnCreateDelete.Anchor = CType(resources.GetObject("btnCreateDelete.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnCreateDelete.BackgroundImage = CType(resources.GetObject("btnCreateDelete.BackgroundImage"), System.Drawing.Image)
        Me.btnCreateDelete.Dock = CType(resources.GetObject("btnCreateDelete.Dock"), System.Windows.Forms.DockStyle)
        Me.btnCreateDelete.Enabled = CType(resources.GetObject("btnCreateDelete.Enabled"), Boolean)
        Me.btnCreateDelete.FlatStyle = CType(resources.GetObject("btnCreateDelete.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnCreateDelete.Font = CType(resources.GetObject("btnCreateDelete.Font"), System.Drawing.Font)
        Me.btnCreateDelete.Image = CType(resources.GetObject("btnCreateDelete.Image"), System.Drawing.Image)
        Me.btnCreateDelete.ImageAlign = CType(resources.GetObject("btnCreateDelete.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnCreateDelete.ImageIndex = CType(resources.GetObject("btnCreateDelete.ImageIndex"), Integer)
        Me.btnCreateDelete.ImeMode = CType(resources.GetObject("btnCreateDelete.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnCreateDelete.Location = CType(resources.GetObject("btnCreateDelete.Location"), System.Drawing.Point)
        Me.btnCreateDelete.Name = "btnCreateDelete"
        Me.btnCreateDelete.RightToLeft = CType(resources.GetObject("btnCreateDelete.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnCreateDelete.Size = CType(resources.GetObject("btnCreateDelete.Size"), System.Drawing.Size)
        Me.btnCreateDelete.TabIndex = CType(resources.GetObject("btnCreateDelete.TabIndex"), Integer)
        Me.btnCreateDelete.Text = resources.GetString("btnCreateDelete.Text")
        Me.btnCreateDelete.TextAlign = CType(resources.GetObject("btnCreateDelete.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnCreateDelete.Visible = CType(resources.GetObject("btnCreateDelete.Visible"), Boolean)
        '
        'frmMain
        '
        Me.AccessibleDescription = resources.GetString("$this.AccessibleDescription")
        Me.AccessibleName = resources.GetString("$this.AccessibleName")
        Me.Anchor = CType(resources.GetObject("$this.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.AutoScaleBaseSize = CType(resources.GetObject("$this.AutoScaleBaseSize"), System.Drawing.Size)
        Me.AutoScroll = CType(resources.GetObject("$this.AutoScroll"), Boolean)
        Me.AutoScrollMargin = CType(resources.GetObject("$this.AutoScrollMargin"), System.Drawing.Size)
        Me.AutoScrollMinSize = CType(resources.GetObject("$this.AutoScrollMinSize"), System.Drawing.Size)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = CType(resources.GetObject("$this.ClientSize"), System.Drawing.Size)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCreateDelete, Me.btnRead, Me.btnWrite})
        Me.Dock = CType(resources.GetObject("$this.Dock"), System.Windows.Forms.DockStyle)
        Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
        Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
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

    Private Sub btnWrite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWrite.Click
        If frmWrite Is Nothing OrElse frmWrite.IsDisposed Then
            frmWrite = New frmWrite()
        End If
        frmWrite.Show()
        frmWrite.BringToFront()
    End Sub

    Private Sub btnRead_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRead.Click
        If frmRead Is Nothing OrElse frmRead.IsDisposed Then
            frmRead = New frmRead()
        End If
        frmRead.Show()
        frmRead.BringToFront()
    End Sub

    Private Sub btnCreateDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateDelete.Click
        If frmCreateDelete Is Nothing OrElse frmCreateDelete.IsDisposed Then
            frmCreateDelete = New frmCreateDelete()
        End If
        frmCreateDelete.Show()
        frmCreateDelete.BringToFront()
    End Sub

End Class