'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

' Since the survey form uses an XML document to provide information
'   the System.Xml namespace is imported for simplicity.
Imports System.Xml

Public Class frmMain
    Inherits System.Windows.Forms.Form

    ' Create constants to use in the form.
    Private Const CONTROL_WIDTH As Integer = 300
    Private Const CHARS_PER_LINE As Integer = 30
    Private Const HEIGHT_PER_LINE As Integer = 19

    ' Create class variables to use during the form.
    Private m_ControlCount As Integer = 0
    Private m_Location As New Point(10, 10)


#Region " Windows Form Designer generated code "

	Public Sub New()
		MyBase.New()

		'This call is required by the Windows Form Designer.
		InitializeComponent()

		'Add any initialization after the InitializeComponent() call

		' So that we only need to set the title of the application once,
		' we use the AssemblyInfo class (defined in the AssemblyInfo.vb file)
        ' to read the AssemblyTitle attribute.
        GetAssemblyAttributes()

    End Sub

    Private Sub GetAssemblyAttributes()
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
    Friend WithEvents btnClearControls As System.Windows.Forms.Button
    Friend WithEvents btnTightlyBoundControls As System.Windows.Forms.Button
    Friend WithEvents btnAddButton As System.Windows.Forms.Button
    Friend WithEvents btnCreateSurvey As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.btnAddButton = New System.Windows.Forms.Button()
        Me.btnClearControls = New System.Windows.Forms.Button()
        Me.btnTightlyBoundControls = New System.Windows.Forms.Button()
        Me.btnCreateSurvey = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
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
        'btnAddButton
        '
        Me.btnAddButton.AccessibleDescription = resources.GetString("btnAddButton.AccessibleDescription")
        Me.btnAddButton.AccessibleName = resources.GetString("btnAddButton.AccessibleName")
        Me.btnAddButton.Anchor = CType(resources.GetObject("btnAddButton.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnAddButton.BackgroundImage = CType(resources.GetObject("btnAddButton.BackgroundImage"), System.Drawing.Image)
        Me.btnAddButton.Dock = CType(resources.GetObject("btnAddButton.Dock"), System.Windows.Forms.DockStyle)
        Me.btnAddButton.Enabled = CType(resources.GetObject("btnAddButton.Enabled"), Boolean)
        Me.btnAddButton.FlatStyle = CType(resources.GetObject("btnAddButton.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnAddButton.Font = CType(resources.GetObject("btnAddButton.Font"), System.Drawing.Font)
        Me.btnAddButton.Image = CType(resources.GetObject("btnAddButton.Image"), System.Drawing.Image)
        Me.btnAddButton.ImageAlign = CType(resources.GetObject("btnAddButton.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnAddButton.ImageIndex = CType(resources.GetObject("btnAddButton.ImageIndex"), Integer)
        Me.btnAddButton.ImeMode = CType(resources.GetObject("btnAddButton.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnAddButton.Location = CType(resources.GetObject("btnAddButton.Location"), System.Drawing.Point)
        Me.btnAddButton.Name = "btnAddButton"
        Me.btnAddButton.RightToLeft = CType(resources.GetObject("btnAddButton.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnAddButton.Size = CType(resources.GetObject("btnAddButton.Size"), System.Drawing.Size)
        Me.btnAddButton.TabIndex = CType(resources.GetObject("btnAddButton.TabIndex"), Integer)
        Me.btnAddButton.Text = resources.GetString("btnAddButton.Text")
        Me.btnAddButton.TextAlign = CType(resources.GetObject("btnAddButton.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnAddButton.Visible = CType(resources.GetObject("btnAddButton.Visible"), Boolean)
        '
        'btnClearControls
        '
        Me.btnClearControls.AccessibleDescription = resources.GetString("btnClearControls.AccessibleDescription")
        Me.btnClearControls.AccessibleName = resources.GetString("btnClearControls.AccessibleName")
        Me.btnClearControls.Anchor = CType(resources.GetObject("btnClearControls.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnClearControls.BackgroundImage = CType(resources.GetObject("btnClearControls.BackgroundImage"), System.Drawing.Image)
        Me.btnClearControls.Dock = CType(resources.GetObject("btnClearControls.Dock"), System.Windows.Forms.DockStyle)
        Me.btnClearControls.Enabled = CType(resources.GetObject("btnClearControls.Enabled"), Boolean)
        Me.btnClearControls.FlatStyle = CType(resources.GetObject("btnClearControls.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnClearControls.Font = CType(resources.GetObject("btnClearControls.Font"), System.Drawing.Font)
        Me.btnClearControls.Image = CType(resources.GetObject("btnClearControls.Image"), System.Drawing.Image)
        Me.btnClearControls.ImageAlign = CType(resources.GetObject("btnClearControls.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnClearControls.ImageIndex = CType(resources.GetObject("btnClearControls.ImageIndex"), Integer)
        Me.btnClearControls.ImeMode = CType(resources.GetObject("btnClearControls.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnClearControls.Location = CType(resources.GetObject("btnClearControls.Location"), System.Drawing.Point)
        Me.btnClearControls.Name = "btnClearControls"
        Me.btnClearControls.RightToLeft = CType(resources.GetObject("btnClearControls.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnClearControls.Size = CType(resources.GetObject("btnClearControls.Size"), System.Drawing.Size)
        Me.btnClearControls.TabIndex = CType(resources.GetObject("btnClearControls.TabIndex"), Integer)
        Me.btnClearControls.Text = resources.GetString("btnClearControls.Text")
        Me.btnClearControls.TextAlign = CType(resources.GetObject("btnClearControls.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnClearControls.Visible = CType(resources.GetObject("btnClearControls.Visible"), Boolean)
        '
        'btnTightlyBoundControls
        '
        Me.btnTightlyBoundControls.AccessibleDescription = resources.GetString("btnTightlyBoundControls.AccessibleDescription")
        Me.btnTightlyBoundControls.AccessibleName = resources.GetString("btnTightlyBoundControls.AccessibleName")
        Me.btnTightlyBoundControls.Anchor = CType(resources.GetObject("btnTightlyBoundControls.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnTightlyBoundControls.BackgroundImage = CType(resources.GetObject("btnTightlyBoundControls.BackgroundImage"), System.Drawing.Image)
        Me.btnTightlyBoundControls.Dock = CType(resources.GetObject("btnTightlyBoundControls.Dock"), System.Windows.Forms.DockStyle)
        Me.btnTightlyBoundControls.Enabled = CType(resources.GetObject("btnTightlyBoundControls.Enabled"), Boolean)
        Me.btnTightlyBoundControls.FlatStyle = CType(resources.GetObject("btnTightlyBoundControls.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnTightlyBoundControls.Font = CType(resources.GetObject("btnTightlyBoundControls.Font"), System.Drawing.Font)
        Me.btnTightlyBoundControls.Image = CType(resources.GetObject("btnTightlyBoundControls.Image"), System.Drawing.Image)
        Me.btnTightlyBoundControls.ImageAlign = CType(resources.GetObject("btnTightlyBoundControls.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnTightlyBoundControls.ImageIndex = CType(resources.GetObject("btnTightlyBoundControls.ImageIndex"), Integer)
        Me.btnTightlyBoundControls.ImeMode = CType(resources.GetObject("btnTightlyBoundControls.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnTightlyBoundControls.Location = CType(resources.GetObject("btnTightlyBoundControls.Location"), System.Drawing.Point)
        Me.btnTightlyBoundControls.Name = "btnTightlyBoundControls"
        Me.btnTightlyBoundControls.RightToLeft = CType(resources.GetObject("btnTightlyBoundControls.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnTightlyBoundControls.Size = CType(resources.GetObject("btnTightlyBoundControls.Size"), System.Drawing.Size)
        Me.btnTightlyBoundControls.TabIndex = CType(resources.GetObject("btnTightlyBoundControls.TabIndex"), Integer)
        Me.btnTightlyBoundControls.Text = resources.GetString("btnTightlyBoundControls.Text")
        Me.btnTightlyBoundControls.TextAlign = CType(resources.GetObject("btnTightlyBoundControls.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnTightlyBoundControls.Visible = CType(resources.GetObject("btnTightlyBoundControls.Visible"), Boolean)
        '
        'btnCreateSurvey
        '
        Me.btnCreateSurvey.AccessibleDescription = resources.GetString("btnCreateSurvey.AccessibleDescription")
        Me.btnCreateSurvey.AccessibleName = resources.GetString("btnCreateSurvey.AccessibleName")
        Me.btnCreateSurvey.Anchor = CType(resources.GetObject("btnCreateSurvey.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnCreateSurvey.BackgroundImage = CType(resources.GetObject("btnCreateSurvey.BackgroundImage"), System.Drawing.Image)
        Me.btnCreateSurvey.Dock = CType(resources.GetObject("btnCreateSurvey.Dock"), System.Windows.Forms.DockStyle)
        Me.btnCreateSurvey.Enabled = CType(resources.GetObject("btnCreateSurvey.Enabled"), Boolean)
        Me.btnCreateSurvey.FlatStyle = CType(resources.GetObject("btnCreateSurvey.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnCreateSurvey.Font = CType(resources.GetObject("btnCreateSurvey.Font"), System.Drawing.Font)
        Me.btnCreateSurvey.Image = CType(resources.GetObject("btnCreateSurvey.Image"), System.Drawing.Image)
        Me.btnCreateSurvey.ImageAlign = CType(resources.GetObject("btnCreateSurvey.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnCreateSurvey.ImageIndex = CType(resources.GetObject("btnCreateSurvey.ImageIndex"), Integer)
        Me.btnCreateSurvey.ImeMode = CType(resources.GetObject("btnCreateSurvey.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnCreateSurvey.Location = CType(resources.GetObject("btnCreateSurvey.Location"), System.Drawing.Point)
        Me.btnCreateSurvey.Name = "btnCreateSurvey"
        Me.btnCreateSurvey.RightToLeft = CType(resources.GetObject("btnCreateSurvey.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnCreateSurvey.Size = CType(resources.GetObject("btnCreateSurvey.Size"), System.Drawing.Size)
        Me.btnCreateSurvey.TabIndex = CType(resources.GetObject("btnCreateSurvey.TabIndex"), Integer)
        Me.btnCreateSurvey.Text = resources.GetString("btnCreateSurvey.Text")
        Me.btnCreateSurvey.TextAlign = CType(resources.GetObject("btnCreateSurvey.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnCreateSurvey.Visible = CType(resources.GetObject("btnCreateSurvey.Visible"), Boolean)
        '
        'Label1
        '
        Me.Label1.AccessibleDescription = resources.GetString("Label1.AccessibleDescription")
        Me.Label1.AccessibleName = resources.GetString("Label1.AccessibleName")
        Me.Label1.Anchor = CType(resources.GetObject("Label1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = CType(resources.GetObject("Label1.AutoSize"), Boolean)
        Me.Label1.Dock = CType(resources.GetObject("Label1.Dock"), System.Windows.Forms.DockStyle)
        Me.Label1.Enabled = CType(resources.GetObject("Label1.Enabled"), Boolean)
        Me.Label1.Font = CType(resources.GetObject("Label1.Font"), System.Drawing.Font)
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
        'Label2
        '
        Me.Label2.AccessibleDescription = resources.GetString("Label2.AccessibleDescription")
        Me.Label2.AccessibleName = resources.GetString("Label2.AccessibleName")
        Me.Label2.Anchor = CType(resources.GetObject("Label2.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = CType(resources.GetObject("Label2.AutoSize"), Boolean)
        Me.Label2.Dock = CType(resources.GetObject("Label2.Dock"), System.Windows.Forms.DockStyle)
        Me.Label2.Enabled = CType(resources.GetObject("Label2.Enabled"), Boolean)
        Me.Label2.Font = CType(resources.GetObject("Label2.Font"), System.Drawing.Font)
        Me.Label2.Image = CType(resources.GetObject("Label2.Image"), System.Drawing.Image)
        Me.Label2.ImageAlign = CType(resources.GetObject("Label2.ImageAlign"), System.Drawing.ContentAlignment)
        Me.Label2.ImageIndex = CType(resources.GetObject("Label2.ImageIndex"), Integer)
        Me.Label2.ImeMode = CType(resources.GetObject("Label2.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Label2.Location = CType(resources.GetObject("Label2.Location"), System.Drawing.Point)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = CType(resources.GetObject("Label2.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Label2.Size = CType(resources.GetObject("Label2.Size"), System.Drawing.Size)
        Me.Label2.TabIndex = CType(resources.GetObject("Label2.TabIndex"), Integer)
        Me.Label2.Text = resources.GetString("Label2.Text")
        Me.Label2.TextAlign = CType(resources.GetObject("Label2.TextAlign"), System.Drawing.ContentAlignment)
        Me.Label2.Visible = CType(resources.GetObject("Label2.Visible"), Boolean)
        '
        'Label3
        '
        Me.Label3.AccessibleDescription = resources.GetString("Label3.AccessibleDescription")
        Me.Label3.AccessibleName = resources.GetString("Label3.AccessibleName")
        Me.Label3.Anchor = CType(resources.GetObject("Label3.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = CType(resources.GetObject("Label3.AutoSize"), Boolean)
        Me.Label3.Dock = CType(resources.GetObject("Label3.Dock"), System.Windows.Forms.DockStyle)
        Me.Label3.Enabled = CType(resources.GetObject("Label3.Enabled"), Boolean)
        Me.Label3.Font = CType(resources.GetObject("Label3.Font"), System.Drawing.Font)
        Me.Label3.Image = CType(resources.GetObject("Label3.Image"), System.Drawing.Image)
        Me.Label3.ImageAlign = CType(resources.GetObject("Label3.ImageAlign"), System.Drawing.ContentAlignment)
        Me.Label3.ImageIndex = CType(resources.GetObject("Label3.ImageIndex"), Integer)
        Me.Label3.ImeMode = CType(resources.GetObject("Label3.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Label3.Location = CType(resources.GetObject("Label3.Location"), System.Drawing.Point)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = CType(resources.GetObject("Label3.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Label3.Size = CType(resources.GetObject("Label3.Size"), System.Drawing.Size)
        Me.Label3.TabIndex = CType(resources.GetObject("Label3.TabIndex"), Integer)
        Me.Label3.Text = resources.GetString("Label3.Text")
        Me.Label3.TextAlign = CType(resources.GetObject("Label3.TextAlign"), System.Drawing.ContentAlignment)
        Me.Label3.Visible = CType(resources.GetObject("Label3.Visible"), Boolean)
        '
        'Label4
        '
        Me.Label4.AccessibleDescription = resources.GetString("Label4.AccessibleDescription")
        Me.Label4.AccessibleName = resources.GetString("Label4.AccessibleName")
        Me.Label4.Anchor = CType(resources.GetObject("Label4.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = CType(resources.GetObject("Label4.AutoSize"), Boolean)
        Me.Label4.Dock = CType(resources.GetObject("Label4.Dock"), System.Windows.Forms.DockStyle)
        Me.Label4.Enabled = CType(resources.GetObject("Label4.Enabled"), Boolean)
        Me.Label4.Font = CType(resources.GetObject("Label4.Font"), System.Drawing.Font)
        Me.Label4.Image = CType(resources.GetObject("Label4.Image"), System.Drawing.Image)
        Me.Label4.ImageAlign = CType(resources.GetObject("Label4.ImageAlign"), System.Drawing.ContentAlignment)
        Me.Label4.ImageIndex = CType(resources.GetObject("Label4.ImageIndex"), Integer)
        Me.Label4.ImeMode = CType(resources.GetObject("Label4.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Label4.Location = CType(resources.GetObject("Label4.Location"), System.Drawing.Point)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = CType(resources.GetObject("Label4.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Label4.Size = CType(resources.GetObject("Label4.Size"), System.Drawing.Size)
        Me.Label4.TabIndex = CType(resources.GetObject("Label4.TabIndex"), Integer)
        Me.Label4.Text = resources.GetString("Label4.Text")
        Me.Label4.TextAlign = CType(resources.GetObject("Label4.TextAlign"), System.Drawing.ContentAlignment)
        Me.Label4.Visible = CType(resources.GetObject("Label4.Visible"), Boolean)
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
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label4, Me.Label3, Me.Label2, Me.Label1, Me.btnCreateSurvey, Me.btnTightlyBoundControls, Me.btnClearControls, Me.btnAddButton})
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

    ' This subroutine adds a new button to the form, and sets up event handlers
    '   for it that will be fired on the Click and MouseHover events.
    Private Sub btnAddButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddButton.Click

        ' Increment the control count
        m_ControlCount += 1

        ' Only allow 5 buttons, just to simplify drawing of the user interface
        If m_ControlCount <= 5 Then
            ' Create a new Button
            Dim x As New Button()

            ' Add properties to the form
            x.Name = "btn" + m_ControlCount.ToString()
            x.Text = "btn" + m_ControlCount.ToString()
            x.Location = New Point(Me.m_Location.X + 250, Me.m_Location.Y)
            m_Location.Y += x.Height + 5

            ' Add the two event handlers 
            AddHandler x.Click, AddressOf myButtonHandler_Click
            AddHandler x.MouseHover, AddressOf myButtonHandler_MouseHover

            ' Add the control to the collection of controls
            Controls.Add(x)
        Else
            ' Just allow 5 controls to simplify UI.
            MsgBox("You've reached 5 controls. Clear controls to start again.", _
                MsgBoxStyle.OKOnly, Me.Text)
        End If
    End Sub

    ' This subroutine clears all of the dynamically generated controls 
    '   on the page.  It does this by removing all of the controls, then calling
    '   the InitializeComponent() subroutine that was automatically generated
    '   by Visual Studio .NET.  This is a very easy way of resetting a form to
    '   its original state.
    Private Sub btnClearControls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearControls.Click

        ' Clear all the controls.
        Controls.Clear()

        ' Re-Add all of the original controls
        InitializeComponent()
        ' Re-set properties such as the app title from Assembly attributes
        GetAssemblyAttributes()

        ' Reset the m_Location to its original location.
        m_Location = New Point(10, 10)

        ' Reset the number of controls.
        m_ControlCount = 0

        ' Show the form again.
        Show()

    End Sub

    ' This subroutine handles the btnCreateSurvey.Click event and creates
    '   a new frmSurveyForm. The controls that are generated are added to the
    '   created survey form. There are no event handlers associated with the 
    '   created controls.
    ' The created form is fairly general, and creates a survey with questions
    '   that are based off information provided by the Questions.xml document.
    '   By changing, adding, or removing nodes in the XML document, you can 
    '   change the structure and form of the survey.
    Private Sub btnCreateSurvey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateSurvey.Click

        ' Create a new Survey Form to display to the User.
        Dim survey As New frmSurveyForm()

        ' Get the controls collection of the Survey form.
        Dim surveyControls As Control.ControlCollection = survey.SurveyFormControls

        ' Reset the m_Location in case the user creates multiple forms
        m_Location = New Point(10, 10)

        ' Create an XML document to read in the survey questions
        Dim xr As New Xml.XmlDocument()
        xr.Load("..\Questions.xml")

        ' Get the Tag used for each of the Controls we'll create. This may
        '   be useful later, if the example was extended to break apart
        '   different types of questions/responses for analysis.
        Dim myTag As String = xr.SelectSingleNode("//survey").Attributes("name").Value

        ' Set the Title on the survey form to the Display Name of the Survey
        survey.SurveyTitle = xr.SelectSingleNode("//survey").Attributes("displayName").Value

        ' Create an XmlNodeList to contain each of the questions. Fill it.
        Dim nodeList As Xml.XmlNodeList
        nodeList = xr.GetElementsByTagName("question")

        ' Create a temporary XML Node to use when retrieving information
        '   about the nodes in the nodeList just created.
        Dim myNode As XmlNode
        For Each myNode In nodeList
            If Not myNode.Attributes Is Nothing Then
                ' Determine what type of control should be created. Pass
                '   in the required information, including the Controls collection
                '   from the frmSurveyForm form.
                Select Case myNode.Attributes("type").Value
                    Case "dropdown"
                        m_Location = Survey_AddComboBox(myNode, surveyControls, _
                            m_Location, myTag)
                    Case "multilist"
                        m_Location = Survey_AddListBox(myNode, surveyControls, _
                            m_Location, myTag, True)
                    Case "text"
                        m_Location = Survey_AddTextBox(myNode, surveyControls, _
                            m_Location, myTag)
                    Case "radio"
                        m_Location = Survey_AddRadioButtons(myNode, surveyControls, _
                            m_Location, myTag)
                End Select
            End If
        Next

        ' Set the size of the form, based off of how many controls
        '   have been placed on the form, and their dimensions.
        survey.Width = m_Location.X + CONTROL_WIDTH + 30
        ' Add a bit extra to leave room for the OK and Cancel buttons.
        survey.Height = m_Location.Y + 75

        ' Show the form.  You can also use the Show() method if you like.
        survey.ShowDialog()

        ' Show the response to the user.
        MsgBox(survey.SurveyResponse, MsgBoxStyle.OKOnly, Me.Text)
    End Sub

    ' This subroutine handles the btnTightlyBoundControls.Click event and creates
    '   two tightly bound controls. It uses the event handlers that have been 
    '   previously defined to handle the events. These event handlers are 
    '   have to be defined beforehand, unless Reflection.Emit is used.
    ' The two controls are a Button and a TextBox. When the Button is pressed, the
    '   text in the TextBox is displayed in a MsgBox.  In order to ensure that
    '   we know which TextBox is being used, it is added to the Tag property of
    '   the Button. (We don't know the name of the TextBox while creating the 
    '   event handler, since the TextBox will be created dynamically.
    Private Sub btnTightlyBoundControls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTightlyBoundControls.Click

        ' Increment the number of controls (only by one, even though two 
        '   will be added.
        m_ControlCount += 1

        ' Only allow 5 buttons, just to simplify drawing of the user interface
        If m_ControlCount <= 5 Then

            ' Create the TextBox that will contain the text to speak
            Dim txtSpeakText As New TextBox()

            ' Set up some properties for the TextBox
            txtSpeakText.Text = "Hello, World"
            txtSpeakText.Name = "txtSpeakText"
            txtSpeakText.Location = New Point(m_Location.X + 250, m_Location.Y)
            txtSpeakText.Size = New Size(200, txtSpeakText.Height)

            ' Add the TextBox to the controls collection.
            Controls.Add(txtSpeakText)

            ' Increment the m_LocationY so the next control won't overwrite it
            m_Location.Y += txtSpeakText.Height + 5

            ' Create a button that will be used to react to clicks
            ' Since this button is tightly coupled to the TextBox which will
            '   provide it with the text to display, we'll add the TextBox created
            '   above as the Tag of this Button. 
            Dim btnSpeakText As New Button()

            ' Set up some properties for the TextBox
            btnSpeakText.Text = "Speak Text"
            btnSpeakText.Name = "btnSpeakText"
            btnSpeakText.Location = New Point(m_Location.X + 250, m_Location.Y)
            btnSpeakText.Size = New Size(100, btnSpeakText.Height)

            ' Add the previously created TextBox to this button
            btnSpeakText.Tag = txtSpeakText

            ' Add the TextBox to the controls collection.
            Controls.Add(btnSpeakText)

            ' Increment the m_LocationY so the next control won't overwrite it
            m_Location.Y += btnSpeakText.Height + 5

            ' Add the event handler that will handle the event when the
            '   button is pressed.
            AddHandler btnSpeakText.Click, AddressOf SpeakTextClickHandler
        Else
            ' Just allow 5 controls to simplify UI.
            MsgBox("You've reached 5 controls. Clear controls to start again.", _
                MsgBoxStyle.OKOnly, Me.Text)
        End If

    End Sub

    ' This subroutine handles the Click events of all the dynamically generated
    '   buttons.  It is attached to all the buttons using the AddHandler function
    '   at the time of button creation.
    Private Sub myButtonHandler_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Verify that the type of control triggering this event is indeed
        '   a Button. This is necessary since this handler can be attached
        '   to any event.
        If TypeOf sender Is Button Then
            ' Let the user know what Button was pressed.
            MsgBox(CType(sender, Button).Text + " was pressed!", _
                    MsgBoxStyle.OKOnly, Me.Text)
        End If
    End Sub

    ' This subroutine handles the MouseHover events of all the dynamically generated
    '   buttons.  It is attached to all the buttons using the AddHandler function
    '   at the time of button creation.
    Private Sub myButtonHandler_MouseHover(ByVal sender As Object, ByVal e As EventArgs)
        ' Verify that the type of control triggering this event is indeed
        '   a Button. This is necessary since this handler can be attached
        '   to any event.
        If TypeOf sender Is Button Then
            ' Let the user know what Button was hovered over.
            MsgBox(CType(sender, Button).Text + " was hovered over!", _
                    MsgBoxStyle.OKOnly, Me.Text)
        End If
    End Sub


    ' This subroutine handles the Click event of the Button created in the
    '   tightly bound controls example. It displays in a MsgBox the text that
    '   is inside of the Tag of the Button (which is provided in the 'sender' 
    '   parameter.  Although those event handlers are sophisticated, 
    '   they do have to be defined beforehand, unless Reflection.Emit is used.
    Private Sub SpeakTextClickHandler(ByVal sender As System.Object, _
        ByVal e As System.EventArgs)

        ' Check to see if the sender is a button, and that it has
        '   a valid, tightly-coupled TextBox object attached as its
        '   Tag property.
        If TypeOf sender Is Button Then
            ' Create a button object to use in its place
            Dim myButton As Button = CType(sender, Button)
            ' Check to see if the Button has a TextBox in its Tag property
            If TypeOf myButton.Tag Is TextBox Then
                ' Display the text to the user
                MsgBox(CType(myButton.Tag, TextBox).Text, MsgBoxStyle.OKOnly, _
                    Me.Text)
            End If
        End If
    End Sub

    ' This function adds a ComboBox to the passed control collection, along
    '   with an associated Label control to display the survey question.
    Private Function Survey_AddComboBox(ByVal inNode As XmlNode, _
        ByVal inControls As Control.ControlCollection, _
        ByVal location As Point, ByVal tag As String) As Point

        ' Create a new control.
        Dim myCombo As New ComboBox()

        ' Set up some properties for the control
        myCombo.Text = ""
        myCombo.Name = inNode.Attributes("name").Value
        myCombo.Tag = tag
        myCombo.Width = CONTROL_WIDTH

        ' Create a temporary XML Node to use when retrieving information
        '   about the response nodes in the passed node.
        Dim myNode As XmlNode
        ' Get the response nodes.
        For Each myNode In inNode.SelectNodes("responses/response")
            ' Add the InnerText of the response nodes as the values for
            '   the drop down options.
            myCombo.Items.Add(myNode.InnerText)
            ' If a default has been specified, use it as the current text.
            If Not myNode.Attributes("default") Is Nothing Then
                If myNode.Attributes("default").Value = "true" Then
                    myCombo.Text = myNode.InnerText
                End If
            End If
        Next

        ' Create a Label and add it to the collection
        Dim myLabel As New Label()

        ' Set up some properties for the control
        myLabel.Name = myCombo.Name & "Label"
        myLabel.Text = inNode.SelectSingleNode("text").InnerText
        myLabel.Width = CONTROL_WIDTH

        ' Add the control to the Controls collection, and reset
        '   the location to the location for the next control.
        myLabel.Location = location
        inControls.Add(myLabel)
        location.Y += myLabel.Height

        ' Add the control to the Controls collection, and reset
        '   the location to the location for the next control.
        myCombo.Location = location
        inControls.Add(myCombo)
        location.Y += myCombo.Height + 10

        ' Send back the location for the next control to be added.
        Return location
    End Function

    ' This function adds a ListBox to the passed control collection, along
    '   with an associated Label control to display the survey question.
    Private Function Survey_AddListBox(ByVal inNode As XmlNode, _
        ByVal inControls As Control.ControlCollection, _
        ByVal location As Point, ByVal tag As String, _
        ByVal isMultiSelect As Boolean) As Point

        ' Create a new control.
        Dim myList As New ListBox()

        ' Set up some properties for the control
        myList.Text = ""
        myList.Name = inNode.Attributes("name").Value
        myList.Tag = tag
        myList.Width = CONTROL_WIDTH

        ' Since this function can be used with either multi or single select
        '   list boxes, set the proper SelectionMode based on the passed
        '   isMultiSelect Boolean variable.
        If isMultiSelect Then
            myList.SelectionMode = SelectionMode.MultiSimple
        Else
            myList.SelectionMode = SelectionMode.One
        End If


        ' Create a temporary XML Node to use when retrieving information
        '   about the response nodes in the passed node.
        Dim myNode As XmlNode
        ' Add the InnerText of the response nodes as the values for
        '   the list box options.
        For Each myNode In inNode.SelectNodes("responses/response")
            myList.Items.Add(myNode.InnerText)
            ' If a default has been specified, use it as the current text.
            If Not myNode.Attributes("default") Is Nothing Then
                If myNode.Attributes("default").Value = "true" Then
                    myList.Text = myNode.InnerText
                End If
            End If
        Next

        ' Create a Label and add it to the collection
        Dim myLabel As New Label()

        ' Set up some properties for the control
        myLabel.Name = myList.Name & "Label"
        myLabel.Text = inNode.SelectSingleNode("text").InnerText
        myLabel.Width = CONTROL_WIDTH

        ' Add the control to the Controls collection, and reset
        '   the location to the location for the next control.
        myLabel.Location = location
        inControls.Add(myLabel)
        location.Y += myLabel.Height

        ' Add the control to the Controls collection, and reset
        '   the location to the location for the next control.
        myList.Location = location
        inControls.Add(myList)
        location.Y += myList.Height + 10

        ' Send back the location for the next control
        Return location
    End Function

    ' This function adds a GroupBox to the passed control collection, along
    '   with all the appropriate radio buttons, one for each available response.
    '   It also adds an associated Label control to display the survey question.
    Private Function Survey_AddRadioButtons(ByVal inNode As XmlNode, _
        ByVal inControls As Control.ControlCollection, _
        ByVal location As Point, ByVal tag As String) As Point

        ' Must create a GroupBox to contain the radio buttons
        '   otherwise they are not logically distinct from the other
        '   radio buttons on the form.
        Dim myGroupBox As New GroupBox()

        ' Set up some properties for the control.
        myGroupBox.Text = ""
        myGroupBox.Name = inNode.Attributes("name").Value
        myGroupBox.Tag = tag
        myGroupBox.Width = CONTROL_WIDTH + 20

        ' Create some useful variables to use in the following block of code.
        Dim myRadio As RadioButton
        Dim myRadioPoint As New Point(5, 10)
        Dim myNode As XmlNode

        ' Loop through each response, and add it as a new radio button.
        For Each myNode In inNode.SelectNodes("responses/response")
            ' Create the radio button.
            myRadio = New RadioButton()
            ' Add the appropriate properties.
            myRadio.Text = myNode.InnerText
            myRadio.Location = myRadioPoint
            myRadioPoint.Y += myRadio.Height

            ' Set the default value as the selected radio button, but
            '   only if the default attribute exists and is set to true.
            If Not myNode.Attributes("default") Is Nothing Then
                If myNode.Attributes("default").Value = "true" Then
                    myRadio.Checked = True
                End If
            End If
            ' Add the control to the group box.
            myGroupBox.Controls.Add(myRadio)
        Next

        ' Reset the height for the textbox, based on the 
        '   contained Radio Buttons.
        myGroupBox.Height = myRadioPoint.Y + 5

        ' Create a Label and add it to the collection.
        Dim myLabel As New Label()

        ' Fix the label properties.
        myLabel.Name = myGroupBox.Name & "Label"
        myLabel.Text = inNode.SelectSingleNode("text").InnerText
        myLabel.Width = CONTROL_WIDTH

        ' Add the control to the Controls collection, and reset
        '   the location to the location for the next control.
        myLabel.Location = location
        inControls.Add(myLabel)
        location.Y += myLabel.Height - 5

        ' Add the control to the Controls collection, and reset
        '   the location to the location for the next control.
        myGroupBox.Location = location
        inControls.Add(myGroupBox)
        location.Y += myGroupBox.Height + 10

        ' Send back the location for the next control
        Return location
    End Function

    ' This function adds a TextBox to the passed control collection, along
    '   with an associated Label control to display the survey question.
    Private Function Survey_AddTextBox(ByVal inNode As XmlNode, _
        ByVal inControls As Control.ControlCollection, _
        ByVal location As Point, ByVal tag As String _
        ) As Point

        ' Create a new control.
        Dim myText As New TextBox()

        ' Fill in some of the appropriate properties
        If Not inNode.SelectSingleNode("defaultResponse") Is Nothing Then
            myText.Text = inNode.SelectSingleNode("defaultResponse").InnerText
        End If
        If Not inNode.Attributes("name") Is Nothing Then
            myText.Name = inNode.Attributes("name").Value
        End If
        myText.Tag = tag
        myText.Width = CONTROL_WIDTH

        ' Set the MaxLength property based off of the XML node information.
        If Not inNode.SelectSingleNode("maxCharacters") Is Nothing Then
            myText.MaxLength = Integer.Parse(inNode.SelectSingleNode("maxCharacters").InnerText)
        End If

        ' Calculate the number of lines that should be allowed for
        If myText.MaxLength > 0 Then
            Dim numLines As Integer = (myText.MaxLength \ CHARS_PER_LINE) + 1

            ' Calculate how large the textbox should be, and whether 
            '   scrollbars are necessary.
            If numLines = 1 Then
                myText.Multiline = False
            Else
                If numLines >= 4 Then
                    myText.Multiline = True
                    myText.Height = 4 * HEIGHT_PER_LINE
                    myText.ScrollBars = ScrollBars.Vertical
                Else
                    myText.Multiline = True
                    myText.Height = numLines * HEIGHT_PER_LINE
                    myText.ScrollBars = ScrollBars.None
                End If

            End If

        End If

        ' Create a Label and add it to the collection
        Dim myLabel As New Label()
        myLabel.Name = myText.Name & "Label"
        If Not inNode.SelectSingleNode("text") Is Nothing Then
            myLabel.Text = inNode.SelectSingleNode("text").InnerText
        End If
        myLabel.Width = CONTROL_WIDTH

        ' Add the control to the Controls collection, and reset
        '   the location to the location for the next control.
        myLabel.Location = location
        inControls.Add(myLabel)
        location.Y += myLabel.Height

        ' Add the control to the Controls collection, and reset
        '   the location to the location for the next control.
        myText.Location = location
        inControls.Add(myText)
        location.Y += myText.Height + 10

        ' Send back the location for the next control.
        Return location
    End Function

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class