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
    Friend WithEvents btnTextModMenu As System.Windows.Forms.Button
    Friend WithEvents btnIconModMenu As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.btnTextModMenu = New System.Windows.Forms.Button()
        Me.btnIconModMenu = New System.Windows.Forms.Button()
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
        'btnTextModMenu
        '
        Me.btnTextModMenu.AccessibleDescription = CType(resources.GetObject("btnTextModMenu.AccessibleDescription"), String)
        Me.btnTextModMenu.AccessibleName = CType(resources.GetObject("btnTextModMenu.AccessibleName"), String)
        Me.btnTextModMenu.Anchor = CType(resources.GetObject("btnTextModMenu.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnTextModMenu.BackgroundImage = CType(resources.GetObject("btnTextModMenu.BackgroundImage"), System.Drawing.Image)
        Me.btnTextModMenu.Dock = CType(resources.GetObject("btnTextModMenu.Dock"), System.Windows.Forms.DockStyle)
        Me.btnTextModMenu.Enabled = CType(resources.GetObject("btnTextModMenu.Enabled"), Boolean)
        Me.btnTextModMenu.FlatStyle = CType(resources.GetObject("btnTextModMenu.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnTextModMenu.Font = CType(resources.GetObject("btnTextModMenu.Font"), System.Drawing.Font)
        Me.btnTextModMenu.Image = CType(resources.GetObject("btnTextModMenu.Image"), System.Drawing.Image)
        Me.btnTextModMenu.ImageAlign = CType(resources.GetObject("btnTextModMenu.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnTextModMenu.ImageIndex = CType(resources.GetObject("btnTextModMenu.ImageIndex"), Integer)
        Me.btnTextModMenu.ImeMode = CType(resources.GetObject("btnTextModMenu.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnTextModMenu.Location = CType(resources.GetObject("btnTextModMenu.Location"), System.Drawing.Point)
        Me.btnTextModMenu.Name = "btnTextModMenu"
        Me.btnTextModMenu.RightToLeft = CType(resources.GetObject("btnTextModMenu.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnTextModMenu.Size = CType(resources.GetObject("btnTextModMenu.Size"), System.Drawing.Size)
        Me.btnTextModMenu.TabIndex = CType(resources.GetObject("btnTextModMenu.TabIndex"), Integer)
        Me.btnTextModMenu.Text = resources.GetString("btnTextModMenu.Text")
        Me.btnTextModMenu.TextAlign = CType(resources.GetObject("btnTextModMenu.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnTextModMenu.Visible = CType(resources.GetObject("btnTextModMenu.Visible"), Boolean)
        '
        'btnIconModMenu
        '
        Me.btnIconModMenu.AccessibleDescription = CType(resources.GetObject("btnIconModMenu.AccessibleDescription"), String)
        Me.btnIconModMenu.AccessibleName = CType(resources.GetObject("btnIconModMenu.AccessibleName"), String)
        Me.btnIconModMenu.Anchor = CType(resources.GetObject("btnIconModMenu.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnIconModMenu.BackgroundImage = CType(resources.GetObject("btnIconModMenu.BackgroundImage"), System.Drawing.Image)
        Me.btnIconModMenu.Dock = CType(resources.GetObject("btnIconModMenu.Dock"), System.Windows.Forms.DockStyle)
        Me.btnIconModMenu.Enabled = CType(resources.GetObject("btnIconModMenu.Enabled"), Boolean)
        Me.btnIconModMenu.FlatStyle = CType(resources.GetObject("btnIconModMenu.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnIconModMenu.Font = CType(resources.GetObject("btnIconModMenu.Font"), System.Drawing.Font)
        Me.btnIconModMenu.Image = CType(resources.GetObject("btnIconModMenu.Image"), System.Drawing.Image)
        Me.btnIconModMenu.ImageAlign = CType(resources.GetObject("btnIconModMenu.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnIconModMenu.ImageIndex = CType(resources.GetObject("btnIconModMenu.ImageIndex"), Integer)
        Me.btnIconModMenu.ImeMode = CType(resources.GetObject("btnIconModMenu.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnIconModMenu.Location = CType(resources.GetObject("btnIconModMenu.Location"), System.Drawing.Point)
        Me.btnIconModMenu.Name = "btnIconModMenu"
        Me.btnIconModMenu.RightToLeft = CType(resources.GetObject("btnIconModMenu.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnIconModMenu.Size = CType(resources.GetObject("btnIconModMenu.Size"), System.Drawing.Size)
        Me.btnIconModMenu.TabIndex = CType(resources.GetObject("btnIconModMenu.TabIndex"), Integer)
        Me.btnIconModMenu.Text = resources.GetString("btnIconModMenu.Text")
        Me.btnIconModMenu.TextAlign = CType(resources.GetObject("btnIconModMenu.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnIconModMenu.Visible = CType(resources.GetObject("btnIconModMenu.Visible"), Boolean)
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
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnIconModMenu, Me.btnTextModMenu})
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

    Private Sub btnTextModMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTextModMenu.Click
        Dim frmText As New frmTextModMenu()
        frmText.ShowDialog()
    End Sub

    Private Sub btnIconModMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIconModMenu.Click
        Dim frmIcon As New frmIconModMenu()
        frmIcon.ShowDialog()
    End Sub
End Class