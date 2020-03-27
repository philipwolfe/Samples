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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnShowDataGridForm As System.Windows.Forms.Button
    Friend WithEvents btnShowRichTextBoxForm As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnShowDataGridForm = New System.Windows.Forms.Button()
        Me.btnShowRichTextBoxForm = New System.Windows.Forms.Button()
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
        'Label1
        '
        Me.Label1.AccessibleDescription = resources.GetString("Label1.AccessibleDescription")
        Me.Label1.AccessibleName = resources.GetString("Label1.AccessibleName")
        Me.Label1.Anchor = CType(resources.GetObject("Label1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = CType(resources.GetObject("Label1.AutoSize"), Boolean)
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Dock = CType(resources.GetObject("Label1.Dock"), System.Windows.Forms.DockStyle)
        Me.Label1.Enabled = CType(resources.GetObject("Label1.Enabled"), Boolean)
        Me.Label1.Font = CType(resources.GetObject("Label1.Font"), System.Drawing.Font)
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
        Me.Label1.ImageAlign = CType(resources.GetObject("Label1.ImageAlign"), System.Drawing.ContentAlignment)
        Me.Label1.ImageIndex = CType(resources.GetObject("Label1.ImageIndex"), Integer)
        Me.Label1.ImeMode = CType(resources.GetObject("Label1.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Label1.Location = CType(resources.GetObject("Label1.Location"), System.Drawing.Point)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = CType(resources.GetObject("Label1.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Label1.Size = CType(resources.GetObject("Label1.Size"), System.Drawing.Size)
        Me.Label1.TabIndex = CType(resources.GetObject("Label1.TabIndex"), Integer)
        Me.Label1.Text = resources.GetString("Label1.Text")
        Me.Label1.TextAlign = CType(resources.GetObject("Label1.TextAlign"), System.Drawing.ContentAlignment)
        Me.Label1.Visible = CType(resources.GetObject("Label1.Visible"), Boolean)
        '
        'btnShowDataGridForm
        '
        Me.btnShowDataGridForm.AccessibleDescription = resources.GetString("btnShowDataGridForm.AccessibleDescription")
        Me.btnShowDataGridForm.AccessibleName = resources.GetString("btnShowDataGridForm.AccessibleName")
        Me.btnShowDataGridForm.Anchor = CType(resources.GetObject("btnShowDataGridForm.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnShowDataGridForm.BackColor = System.Drawing.SystemColors.Control
        Me.btnShowDataGridForm.BackgroundImage = CType(resources.GetObject("btnShowDataGridForm.BackgroundImage"), System.Drawing.Image)
        Me.btnShowDataGridForm.Dock = CType(resources.GetObject("btnShowDataGridForm.Dock"), System.Windows.Forms.DockStyle)
        Me.btnShowDataGridForm.Enabled = CType(resources.GetObject("btnShowDataGridForm.Enabled"), Boolean)
        Me.btnShowDataGridForm.FlatStyle = CType(resources.GetObject("btnShowDataGridForm.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnShowDataGridForm.Font = CType(resources.GetObject("btnShowDataGridForm.Font"), System.Drawing.Font)
        Me.btnShowDataGridForm.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnShowDataGridForm.Image = CType(resources.GetObject("btnShowDataGridForm.Image"), System.Drawing.Image)
        Me.btnShowDataGridForm.ImageAlign = CType(resources.GetObject("btnShowDataGridForm.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnShowDataGridForm.ImageIndex = CType(resources.GetObject("btnShowDataGridForm.ImageIndex"), Integer)
        Me.btnShowDataGridForm.ImeMode = CType(resources.GetObject("btnShowDataGridForm.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnShowDataGridForm.Location = CType(resources.GetObject("btnShowDataGridForm.Location"), System.Drawing.Point)
        Me.btnShowDataGridForm.Name = "btnShowDataGridForm"
        Me.btnShowDataGridForm.RightToLeft = CType(resources.GetObject("btnShowDataGridForm.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnShowDataGridForm.Size = CType(resources.GetObject("btnShowDataGridForm.Size"), System.Drawing.Size)
        Me.btnShowDataGridForm.TabIndex = CType(resources.GetObject("btnShowDataGridForm.TabIndex"), Integer)
        Me.btnShowDataGridForm.Text = resources.GetString("btnShowDataGridForm.Text")
        Me.btnShowDataGridForm.TextAlign = CType(resources.GetObject("btnShowDataGridForm.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnShowDataGridForm.Visible = CType(resources.GetObject("btnShowDataGridForm.Visible"), Boolean)
        '
        'btnShowRichTextBoxForm
        '
        Me.btnShowRichTextBoxForm.AccessibleDescription = resources.GetString("btnShowRichTextBoxForm.AccessibleDescription")
        Me.btnShowRichTextBoxForm.AccessibleName = resources.GetString("btnShowRichTextBoxForm.AccessibleName")
        Me.btnShowRichTextBoxForm.Anchor = CType(resources.GetObject("btnShowRichTextBoxForm.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnShowRichTextBoxForm.BackColor = System.Drawing.SystemColors.Control
        Me.btnShowRichTextBoxForm.BackgroundImage = CType(resources.GetObject("btnShowRichTextBoxForm.BackgroundImage"), System.Drawing.Image)
        Me.btnShowRichTextBoxForm.Dock = CType(resources.GetObject("btnShowRichTextBoxForm.Dock"), System.Windows.Forms.DockStyle)
        Me.btnShowRichTextBoxForm.Enabled = CType(resources.GetObject("btnShowRichTextBoxForm.Enabled"), Boolean)
        Me.btnShowRichTextBoxForm.FlatStyle = CType(resources.GetObject("btnShowRichTextBoxForm.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnShowRichTextBoxForm.Font = CType(resources.GetObject("btnShowRichTextBoxForm.Font"), System.Drawing.Font)
        Me.btnShowRichTextBoxForm.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnShowRichTextBoxForm.Image = CType(resources.GetObject("btnShowRichTextBoxForm.Image"), System.Drawing.Image)
        Me.btnShowRichTextBoxForm.ImageAlign = CType(resources.GetObject("btnShowRichTextBoxForm.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnShowRichTextBoxForm.ImageIndex = CType(resources.GetObject("btnShowRichTextBoxForm.ImageIndex"), Integer)
        Me.btnShowRichTextBoxForm.ImeMode = CType(resources.GetObject("btnShowRichTextBoxForm.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnShowRichTextBoxForm.Location = CType(resources.GetObject("btnShowRichTextBoxForm.Location"), System.Drawing.Point)
        Me.btnShowRichTextBoxForm.Name = "btnShowRichTextBoxForm"
        Me.btnShowRichTextBoxForm.RightToLeft = CType(resources.GetObject("btnShowRichTextBoxForm.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnShowRichTextBoxForm.Size = CType(resources.GetObject("btnShowRichTextBoxForm.Size"), System.Drawing.Size)
        Me.btnShowRichTextBoxForm.TabIndex = CType(resources.GetObject("btnShowRichTextBoxForm.TabIndex"), Integer)
        Me.btnShowRichTextBoxForm.Text = resources.GetString("btnShowRichTextBoxForm.Text")
        Me.btnShowRichTextBoxForm.TextAlign = CType(resources.GetObject("btnShowRichTextBoxForm.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnShowRichTextBoxForm.Visible = CType(resources.GetObject("btnShowRichTextBoxForm.Visible"), Boolean)
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
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnShowRichTextBoxForm, Me.btnShowDataGridForm, Me.Label1})
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

    ' Handles the "Show DataGrid Form" button click event.
    Private Sub btnShowDataGridForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowDataGridForm.Click
        Dim frmDG As New frmDataGrid()
        frmDG.Show()
    End Sub

    ' Handles the "Show RichTextBox Form" button click event.
    Private Sub btnShowRichTextBoxForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowRichTextBoxForm.Click
        Dim frmRTB As New frmRichTextBox()
        frmRTB.Show()
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class