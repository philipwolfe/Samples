'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On
Imports System.Data.SqlClient
Imports System.Text
Imports System.IO

Public Class frmMain
    Inherits System.Windows.Forms.Form

    ' Initialize constants for connecting to the database
    ' and displaying a connection error to the user.
    Protected Const SQL_CONNECTION_STRING As String = _
        "Server=localhost;" & _
        "DataBase=Northwind;" & _
        "Integrated Security=SSPI"

    Protected Const MSDE_CONNECTION_STRING As String = _
        "Server=(local)\NetSDK;" & _
        "DataBase=Northwind;" & _
        "Integrated Security=SSPI"

    Protected Const CONNECTION_ERROR_MSG As String = _
        "To run this sample, you must have SQL " & _
        "or MSDE with the Northwind database installed.  For " & _
        "instructions on installing MSDE, view the ReadMe file."

    Protected da As SqlDataAdapter
    Protected cbd As SqlCommandBuilder
    Protected dsPictures As DataSet
    Protected didPreviouslyConnect As Boolean = False
    Protected connectionString As String = MSDE_CONNECTION_STRING

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
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents lblFilePath As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnDisplay As System.Windows.Forms.Button
    Friend WithEvents lstPictures As System.Windows.Forms.ListBox
    Friend WithEvents btnModifyDB As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblFileName As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnModifyDB = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.lblFilePath = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.lblFileName = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnDisplay = New System.Windows.Forms.Button()
        Me.lstPictures = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
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
        'TabControl1
        '
        Me.TabControl1.AccessibleDescription = CType(resources.GetObject("TabControl1.AccessibleDescription"), String)
        Me.TabControl1.AccessibleName = CType(resources.GetObject("TabControl1.AccessibleName"), String)
        Me.TabControl1.Alignment = CType(resources.GetObject("TabControl1.Alignment"), System.Windows.Forms.TabAlignment)
        Me.TabControl1.Anchor = CType(resources.GetObject("TabControl1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Appearance = CType(resources.GetObject("TabControl1.Appearance"), System.Windows.Forms.TabAppearance)
        Me.TabControl1.BackgroundImage = CType(resources.GetObject("TabControl1.BackgroundImage"), System.Drawing.Image)
        Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabPage1, Me.TabPage2, Me.TabPage3})
        Me.TabControl1.Dock = CType(resources.GetObject("TabControl1.Dock"), System.Windows.Forms.DockStyle)
        Me.TabControl1.Enabled = CType(resources.GetObject("TabControl1.Enabled"), Boolean)
        Me.TabControl1.Font = CType(resources.GetObject("TabControl1.Font"), System.Drawing.Font)
        Me.TabControl1.ImeMode = CType(resources.GetObject("TabControl1.ImeMode"), System.Windows.Forms.ImeMode)
        Me.TabControl1.ItemSize = CType(resources.GetObject("TabControl1.ItemSize"), System.Drawing.Size)
        Me.TabControl1.Location = CType(resources.GetObject("TabControl1.Location"), System.Drawing.Point)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.Padding = CType(resources.GetObject("TabControl1.Padding"), System.Drawing.Point)
        Me.TabControl1.RightToLeft = CType(resources.GetObject("TabControl1.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.ShowToolTips = CType(resources.GetObject("TabControl1.ShowToolTips"), Boolean)
        Me.TabControl1.Size = CType(resources.GetObject("TabControl1.Size"), System.Drawing.Size)
        Me.TabControl1.TabIndex = CType(resources.GetObject("TabControl1.TabIndex"), Integer)
        Me.TabControl1.Text = resources.GetString("TabControl1.Text")
        Me.TabControl1.Visible = CType(resources.GetObject("TabControl1.Visible"), Boolean)
        '
        'TabPage1
        '
        Me.TabPage1.AccessibleDescription = CType(resources.GetObject("TabPage1.AccessibleDescription"), String)
        Me.TabPage1.AccessibleName = CType(resources.GetObject("TabPage1.AccessibleName"), String)
        Me.TabPage1.Anchor = CType(resources.GetObject("TabPage1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.TabPage1.AutoScroll = CType(resources.GetObject("TabPage1.AutoScroll"), Boolean)
        Me.TabPage1.AutoScrollMargin = CType(resources.GetObject("TabPage1.AutoScrollMargin"), System.Drawing.Size)
        Me.TabPage1.AutoScrollMinSize = CType(resources.GetObject("TabPage1.AutoScrollMinSize"), System.Drawing.Size)
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Info
        Me.TabPage1.BackgroundImage = CType(resources.GetObject("TabPage1.BackgroundImage"), System.Drawing.Image)
        Me.TabPage1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label7, Me.Label6, Me.btnModifyDB})
        Me.TabPage1.Dock = CType(resources.GetObject("TabPage1.Dock"), System.Windows.Forms.DockStyle)
        Me.TabPage1.Enabled = CType(resources.GetObject("TabPage1.Enabled"), Boolean)
        Me.TabPage1.Font = CType(resources.GetObject("TabPage1.Font"), System.Drawing.Font)
        Me.TabPage1.ImageIndex = CType(resources.GetObject("TabPage1.ImageIndex"), Integer)
        Me.TabPage1.ImeMode = CType(resources.GetObject("TabPage1.ImeMode"), System.Windows.Forms.ImeMode)
        Me.TabPage1.Location = CType(resources.GetObject("TabPage1.Location"), System.Drawing.Point)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.RightToLeft = CType(resources.GetObject("TabPage1.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.TabPage1.Size = CType(resources.GetObject("TabPage1.Size"), System.Drawing.Size)
        Me.TabPage1.TabIndex = CType(resources.GetObject("TabPage1.TabIndex"), Integer)
        Me.TabPage1.Text = resources.GetString("TabPage1.Text")
        Me.TabPage1.ToolTipText = resources.GetString("TabPage1.ToolTipText")
        Me.TabPage1.Visible = CType(resources.GetObject("TabPage1.Visible"), Boolean)
        '
        'Label7
        '
        Me.Label7.AccessibleDescription = CType(resources.GetObject("Label7.AccessibleDescription"), String)
        Me.Label7.AccessibleName = CType(resources.GetObject("Label7.AccessibleName"), String)
        Me.Label7.Anchor = CType(resources.GetObject("Label7.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = CType(resources.GetObject("Label7.AutoSize"), Boolean)
        Me.Label7.Dock = CType(resources.GetObject("Label7.Dock"), System.Windows.Forms.DockStyle)
        Me.Label7.Enabled = CType(resources.GetObject("Label7.Enabled"), Boolean)
        Me.Label7.Font = CType(resources.GetObject("Label7.Font"), System.Drawing.Font)
        Me.Label7.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label7.Image = CType(resources.GetObject("Label7.Image"), System.Drawing.Image)
        Me.Label7.ImageAlign = CType(resources.GetObject("Label7.ImageAlign"), System.Drawing.ContentAlignment)
        Me.Label7.ImageIndex = CType(resources.GetObject("Label7.ImageIndex"), Integer)
        Me.Label7.ImeMode = CType(resources.GetObject("Label7.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Label7.Location = CType(resources.GetObject("Label7.Location"), System.Drawing.Point)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = CType(resources.GetObject("Label7.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Label7.Size = CType(resources.GetObject("Label7.Size"), System.Drawing.Size)
        Me.Label7.TabIndex = CType(resources.GetObject("Label7.TabIndex"), Integer)
        Me.Label7.Text = resources.GetString("Label7.Text")
        Me.Label7.TextAlign = CType(resources.GetObject("Label7.TextAlign"), System.Drawing.ContentAlignment)
        Me.Label7.Visible = CType(resources.GetObject("Label7.Visible"), Boolean)
        '
        'Label6
        '
        Me.Label6.AccessibleDescription = CType(resources.GetObject("Label6.AccessibleDescription"), String)
        Me.Label6.AccessibleName = CType(resources.GetObject("Label6.AccessibleName"), String)
        Me.Label6.Anchor = CType(resources.GetObject("Label6.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = CType(resources.GetObject("Label6.AutoSize"), Boolean)
        Me.Label6.Dock = CType(resources.GetObject("Label6.Dock"), System.Windows.Forms.DockStyle)
        Me.Label6.Enabled = CType(resources.GetObject("Label6.Enabled"), Boolean)
        Me.Label6.Font = CType(resources.GetObject("Label6.Font"), System.Drawing.Font)
        Me.Label6.Image = CType(resources.GetObject("Label6.Image"), System.Drawing.Image)
        Me.Label6.ImageAlign = CType(resources.GetObject("Label6.ImageAlign"), System.Drawing.ContentAlignment)
        Me.Label6.ImageIndex = CType(resources.GetObject("Label6.ImageIndex"), Integer)
        Me.Label6.ImeMode = CType(resources.GetObject("Label6.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Label6.Location = CType(resources.GetObject("Label6.Location"), System.Drawing.Point)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = CType(resources.GetObject("Label6.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Label6.Size = CType(resources.GetObject("Label6.Size"), System.Drawing.Size)
        Me.Label6.TabIndex = CType(resources.GetObject("Label6.TabIndex"), Integer)
        Me.Label6.Text = resources.GetString("Label6.Text")
        Me.Label6.TextAlign = CType(resources.GetObject("Label6.TextAlign"), System.Drawing.ContentAlignment)
        Me.Label6.Visible = CType(resources.GetObject("Label6.Visible"), Boolean)
        '
        'btnModifyDB
        '
        Me.btnModifyDB.AccessibleDescription = CType(resources.GetObject("btnModifyDB.AccessibleDescription"), String)
        Me.btnModifyDB.AccessibleName = CType(resources.GetObject("btnModifyDB.AccessibleName"), String)
        Me.btnModifyDB.Anchor = CType(resources.GetObject("btnModifyDB.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnModifyDB.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.btnModifyDB.BackgroundImage = CType(resources.GetObject("btnModifyDB.BackgroundImage"), System.Drawing.Image)
        Me.btnModifyDB.Dock = CType(resources.GetObject("btnModifyDB.Dock"), System.Windows.Forms.DockStyle)
        Me.btnModifyDB.Enabled = CType(resources.GetObject("btnModifyDB.Enabled"), Boolean)
        Me.btnModifyDB.FlatStyle = CType(resources.GetObject("btnModifyDB.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnModifyDB.Font = CType(resources.GetObject("btnModifyDB.Font"), System.Drawing.Font)
        Me.btnModifyDB.Image = CType(resources.GetObject("btnModifyDB.Image"), System.Drawing.Image)
        Me.btnModifyDB.ImageAlign = CType(resources.GetObject("btnModifyDB.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnModifyDB.ImageIndex = CType(resources.GetObject("btnModifyDB.ImageIndex"), Integer)
        Me.btnModifyDB.ImeMode = CType(resources.GetObject("btnModifyDB.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnModifyDB.Location = CType(resources.GetObject("btnModifyDB.Location"), System.Drawing.Point)
        Me.btnModifyDB.Name = "btnModifyDB"
        Me.btnModifyDB.RightToLeft = CType(resources.GetObject("btnModifyDB.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnModifyDB.Size = CType(resources.GetObject("btnModifyDB.Size"), System.Drawing.Size)
        Me.btnModifyDB.TabIndex = CType(resources.GetObject("btnModifyDB.TabIndex"), Integer)
        Me.btnModifyDB.Text = resources.GetString("btnModifyDB.Text")
        Me.btnModifyDB.TextAlign = CType(resources.GetObject("btnModifyDB.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnModifyDB.Visible = CType(resources.GetObject("btnModifyDB.Visible"), Boolean)
        '
        'TabPage2
        '
        Me.TabPage2.AccessibleDescription = CType(resources.GetObject("TabPage2.AccessibleDescription"), String)
        Me.TabPage2.AccessibleName = CType(resources.GetObject("TabPage2.AccessibleName"), String)
        Me.TabPage2.Anchor = CType(resources.GetObject("TabPage2.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.TabPage2.AutoScroll = CType(resources.GetObject("TabPage2.AutoScroll"), Boolean)
        Me.TabPage2.AutoScrollMargin = CType(resources.GetObject("TabPage2.AutoScrollMargin"), System.Drawing.Size)
        Me.TabPage2.AutoScrollMinSize = CType(resources.GetObject("TabPage2.AutoScrollMinSize"), System.Drawing.Size)
        Me.TabPage2.BackColor = System.Drawing.SystemColors.Info
        Me.TabPage2.BackgroundImage = CType(resources.GetObject("TabPage2.BackgroundImage"), System.Drawing.Image)
        Me.TabPage2.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblFilePath, Me.btnSave, Me.Label3, Me.Label2, Me.btnBrowse, Me.PictureBox1})
        Me.TabPage2.Dock = CType(resources.GetObject("TabPage2.Dock"), System.Windows.Forms.DockStyle)
        Me.TabPage2.Enabled = CType(resources.GetObject("TabPage2.Enabled"), Boolean)
        Me.TabPage2.Font = CType(resources.GetObject("TabPage2.Font"), System.Drawing.Font)
        Me.TabPage2.ImageIndex = CType(resources.GetObject("TabPage2.ImageIndex"), Integer)
        Me.TabPage2.ImeMode = CType(resources.GetObject("TabPage2.ImeMode"), System.Windows.Forms.ImeMode)
        Me.TabPage2.Location = CType(resources.GetObject("TabPage2.Location"), System.Drawing.Point)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.RightToLeft = CType(resources.GetObject("TabPage2.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.TabPage2.Size = CType(resources.GetObject("TabPage2.Size"), System.Drawing.Size)
        Me.TabPage2.TabIndex = CType(resources.GetObject("TabPage2.TabIndex"), Integer)
        Me.TabPage2.Text = resources.GetString("TabPage2.Text")
        Me.TabPage2.ToolTipText = resources.GetString("TabPage2.ToolTipText")
        Me.TabPage2.Visible = CType(resources.GetObject("TabPage2.Visible"), Boolean)
        '
        'lblFilePath
        '
        Me.lblFilePath.AccessibleDescription = CType(resources.GetObject("lblFilePath.AccessibleDescription"), String)
        Me.lblFilePath.AccessibleName = CType(resources.GetObject("lblFilePath.AccessibleName"), String)
        Me.lblFilePath.Anchor = CType(resources.GetObject("lblFilePath.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblFilePath.AutoSize = CType(resources.GetObject("lblFilePath.AutoSize"), Boolean)
        Me.lblFilePath.Dock = CType(resources.GetObject("lblFilePath.Dock"), System.Windows.Forms.DockStyle)
        Me.lblFilePath.Enabled = CType(resources.GetObject("lblFilePath.Enabled"), Boolean)
        Me.lblFilePath.Font = CType(resources.GetObject("lblFilePath.Font"), System.Drawing.Font)
        Me.lblFilePath.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblFilePath.Image = CType(resources.GetObject("lblFilePath.Image"), System.Drawing.Image)
        Me.lblFilePath.ImageAlign = CType(resources.GetObject("lblFilePath.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblFilePath.ImageIndex = CType(resources.GetObject("lblFilePath.ImageIndex"), Integer)
        Me.lblFilePath.ImeMode = CType(resources.GetObject("lblFilePath.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblFilePath.Location = CType(resources.GetObject("lblFilePath.Location"), System.Drawing.Point)
        Me.lblFilePath.Name = "lblFilePath"
        Me.lblFilePath.RightToLeft = CType(resources.GetObject("lblFilePath.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblFilePath.Size = CType(resources.GetObject("lblFilePath.Size"), System.Drawing.Size)
        Me.lblFilePath.TabIndex = CType(resources.GetObject("lblFilePath.TabIndex"), Integer)
        Me.lblFilePath.Text = resources.GetString("lblFilePath.Text")
        Me.lblFilePath.TextAlign = CType(resources.GetObject("lblFilePath.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblFilePath.Visible = CType(resources.GetObject("lblFilePath.Visible"), Boolean)
        '
        'btnSave
        '
        Me.btnSave.AccessibleDescription = CType(resources.GetObject("btnSave.AccessibleDescription"), String)
        Me.btnSave.AccessibleName = CType(resources.GetObject("btnSave.AccessibleName"), String)
        Me.btnSave.Anchor = CType(resources.GetObject("btnSave.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.btnSave.BackgroundImage = CType(resources.GetObject("btnSave.BackgroundImage"), System.Drawing.Image)
        Me.btnSave.Dock = CType(resources.GetObject("btnSave.Dock"), System.Windows.Forms.DockStyle)
        Me.btnSave.Enabled = CType(resources.GetObject("btnSave.Enabled"), Boolean)
        Me.btnSave.FlatStyle = CType(resources.GetObject("btnSave.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnSave.Font = CType(resources.GetObject("btnSave.Font"), System.Drawing.Font)
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = CType(resources.GetObject("btnSave.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnSave.ImageIndex = CType(resources.GetObject("btnSave.ImageIndex"), Integer)
        Me.btnSave.ImeMode = CType(resources.GetObject("btnSave.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnSave.Location = CType(resources.GetObject("btnSave.Location"), System.Drawing.Point)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.RightToLeft = CType(resources.GetObject("btnSave.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnSave.Size = CType(resources.GetObject("btnSave.Size"), System.Drawing.Size)
        Me.btnSave.TabIndex = CType(resources.GetObject("btnSave.TabIndex"), Integer)
        Me.btnSave.Text = resources.GetString("btnSave.Text")
        Me.btnSave.TextAlign = CType(resources.GetObject("btnSave.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnSave.Visible = CType(resources.GetObject("btnSave.Visible"), Boolean)
        '
        'Label3
        '
        Me.Label3.AccessibleDescription = CType(resources.GetObject("Label3.AccessibleDescription"), String)
        Me.Label3.AccessibleName = CType(resources.GetObject("Label3.AccessibleName"), String)
        Me.Label3.Anchor = CType(resources.GetObject("Label3.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = CType(resources.GetObject("Label3.AutoSize"), Boolean)
        Me.Label3.Dock = CType(resources.GetObject("Label3.Dock"), System.Windows.Forms.DockStyle)
        Me.Label3.Enabled = CType(resources.GetObject("Label3.Enabled"), Boolean)
        Me.Label3.Font = CType(resources.GetObject("Label3.Font"), System.Drawing.Font)
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaption
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
        'Label2
        '
        Me.Label2.AccessibleDescription = CType(resources.GetObject("Label2.AccessibleDescription"), String)
        Me.Label2.AccessibleName = CType(resources.GetObject("Label2.AccessibleName"), String)
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
        'btnBrowse
        '
        Me.btnBrowse.AccessibleDescription = CType(resources.GetObject("btnBrowse.AccessibleDescription"), String)
        Me.btnBrowse.AccessibleName = CType(resources.GetObject("btnBrowse.AccessibleName"), String)
        Me.btnBrowse.Anchor = CType(resources.GetObject("btnBrowse.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnBrowse.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.btnBrowse.BackgroundImage = CType(resources.GetObject("btnBrowse.BackgroundImage"), System.Drawing.Image)
        Me.btnBrowse.Dock = CType(resources.GetObject("btnBrowse.Dock"), System.Windows.Forms.DockStyle)
        Me.btnBrowse.Enabled = CType(resources.GetObject("btnBrowse.Enabled"), Boolean)
        Me.btnBrowse.FlatStyle = CType(resources.GetObject("btnBrowse.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnBrowse.Font = CType(resources.GetObject("btnBrowse.Font"), System.Drawing.Font)
        Me.btnBrowse.Image = CType(resources.GetObject("btnBrowse.Image"), System.Drawing.Image)
        Me.btnBrowse.ImageAlign = CType(resources.GetObject("btnBrowse.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnBrowse.ImageIndex = CType(resources.GetObject("btnBrowse.ImageIndex"), Integer)
        Me.btnBrowse.ImeMode = CType(resources.GetObject("btnBrowse.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnBrowse.Location = CType(resources.GetObject("btnBrowse.Location"), System.Drawing.Point)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.RightToLeft = CType(resources.GetObject("btnBrowse.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnBrowse.Size = CType(resources.GetObject("btnBrowse.Size"), System.Drawing.Size)
        Me.btnBrowse.TabIndex = CType(resources.GetObject("btnBrowse.TabIndex"), Integer)
        Me.btnBrowse.Text = resources.GetString("btnBrowse.Text")
        Me.btnBrowse.TextAlign = CType(resources.GetObject("btnBrowse.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnBrowse.Visible = CType(resources.GetObject("btnBrowse.Visible"), Boolean)
        '
        'PictureBox1
        '
        Me.PictureBox1.AccessibleDescription = CType(resources.GetObject("PictureBox1.AccessibleDescription"), String)
        Me.PictureBox1.AccessibleName = CType(resources.GetObject("PictureBox1.AccessibleName"), String)
        Me.PictureBox1.Anchor = CType(resources.GetObject("PictureBox1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.Menu
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.Dock = CType(resources.GetObject("PictureBox1.Dock"), System.Windows.Forms.DockStyle)
        Me.PictureBox1.Enabled = CType(resources.GetObject("PictureBox1.Enabled"), Boolean)
        Me.PictureBox1.Font = CType(resources.GetObject("PictureBox1.Font"), System.Drawing.Font)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.ImeMode = CType(resources.GetObject("PictureBox1.ImeMode"), System.Windows.Forms.ImeMode)
        Me.PictureBox1.Location = CType(resources.GetObject("PictureBox1.Location"), System.Drawing.Point)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.RightToLeft = CType(resources.GetObject("PictureBox1.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.PictureBox1.Size = CType(resources.GetObject("PictureBox1.Size"), System.Drawing.Size)
        Me.PictureBox1.SizeMode = CType(resources.GetObject("PictureBox1.SizeMode"), System.Windows.Forms.PictureBoxSizeMode)
        Me.PictureBox1.TabIndex = CType(resources.GetObject("PictureBox1.TabIndex"), Integer)
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Text = resources.GetString("PictureBox1.Text")
        Me.PictureBox1.Visible = CType(resources.GetObject("PictureBox1.Visible"), Boolean)
        '
        'TabPage3
        '
        Me.TabPage3.AccessibleDescription = CType(resources.GetObject("TabPage3.AccessibleDescription"), String)
        Me.TabPage3.AccessibleName = CType(resources.GetObject("TabPage3.AccessibleName"), String)
        Me.TabPage3.Anchor = CType(resources.GetObject("TabPage3.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.TabPage3.AutoScroll = CType(resources.GetObject("TabPage3.AutoScroll"), Boolean)
        Me.TabPage3.AutoScrollMargin = CType(resources.GetObject("TabPage3.AutoScrollMargin"), System.Drawing.Size)
        Me.TabPage3.AutoScrollMinSize = CType(resources.GetObject("TabPage3.AutoScrollMinSize"), System.Drawing.Size)
        Me.TabPage3.BackColor = System.Drawing.SystemColors.Info
        Me.TabPage3.BackgroundImage = CType(resources.GetObject("TabPage3.BackgroundImage"), System.Drawing.Image)
        Me.TabPage3.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblFileName, Me.Label5, Me.Label4, Me.PictureBox2, Me.btnDelete, Me.btnDisplay, Me.lstPictures})
        Me.TabPage3.Dock = CType(resources.GetObject("TabPage3.Dock"), System.Windows.Forms.DockStyle)
        Me.TabPage3.Enabled = CType(resources.GetObject("TabPage3.Enabled"), Boolean)
        Me.TabPage3.Font = CType(resources.GetObject("TabPage3.Font"), System.Drawing.Font)
        Me.TabPage3.ImageIndex = CType(resources.GetObject("TabPage3.ImageIndex"), Integer)
        Me.TabPage3.ImeMode = CType(resources.GetObject("TabPage3.ImeMode"), System.Windows.Forms.ImeMode)
        Me.TabPage3.Location = CType(resources.GetObject("TabPage3.Location"), System.Drawing.Point)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.RightToLeft = CType(resources.GetObject("TabPage3.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.TabPage3.Size = CType(resources.GetObject("TabPage3.Size"), System.Drawing.Size)
        Me.TabPage3.TabIndex = CType(resources.GetObject("TabPage3.TabIndex"), Integer)
        Me.TabPage3.Text = resources.GetString("TabPage3.Text")
        Me.TabPage3.ToolTipText = resources.GetString("TabPage3.ToolTipText")
        Me.TabPage3.Visible = CType(resources.GetObject("TabPage3.Visible"), Boolean)
        '
        'lblFileName
        '
        Me.lblFileName.AccessibleDescription = CType(resources.GetObject("lblFileName.AccessibleDescription"), String)
        Me.lblFileName.AccessibleName = CType(resources.GetObject("lblFileName.AccessibleName"), String)
        Me.lblFileName.Anchor = CType(resources.GetObject("lblFileName.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblFileName.AutoSize = CType(resources.GetObject("lblFileName.AutoSize"), Boolean)
        Me.lblFileName.Dock = CType(resources.GetObject("lblFileName.Dock"), System.Windows.Forms.DockStyle)
        Me.lblFileName.Enabled = CType(resources.GetObject("lblFileName.Enabled"), Boolean)
        Me.lblFileName.Font = CType(resources.GetObject("lblFileName.Font"), System.Drawing.Font)
        Me.lblFileName.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblFileName.Image = CType(resources.GetObject("lblFileName.Image"), System.Drawing.Image)
        Me.lblFileName.ImageAlign = CType(resources.GetObject("lblFileName.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblFileName.ImageIndex = CType(resources.GetObject("lblFileName.ImageIndex"), Integer)
        Me.lblFileName.ImeMode = CType(resources.GetObject("lblFileName.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblFileName.Location = CType(resources.GetObject("lblFileName.Location"), System.Drawing.Point)
        Me.lblFileName.Name = "lblFileName"
        Me.lblFileName.RightToLeft = CType(resources.GetObject("lblFileName.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblFileName.Size = CType(resources.GetObject("lblFileName.Size"), System.Drawing.Size)
        Me.lblFileName.TabIndex = CType(resources.GetObject("lblFileName.TabIndex"), Integer)
        Me.lblFileName.Text = resources.GetString("lblFileName.Text")
        Me.lblFileName.TextAlign = CType(resources.GetObject("lblFileName.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblFileName.Visible = CType(resources.GetObject("lblFileName.Visible"), Boolean)
        '
        'Label5
        '
        Me.Label5.AccessibleDescription = CType(resources.GetObject("Label5.AccessibleDescription"), String)
        Me.Label5.AccessibleName = CType(resources.GetObject("Label5.AccessibleName"), String)
        Me.Label5.Anchor = CType(resources.GetObject("Label5.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = CType(resources.GetObject("Label5.AutoSize"), Boolean)
        Me.Label5.Dock = CType(resources.GetObject("Label5.Dock"), System.Windows.Forms.DockStyle)
        Me.Label5.Enabled = CType(resources.GetObject("Label5.Enabled"), Boolean)
        Me.Label5.Font = CType(resources.GetObject("Label5.Font"), System.Drawing.Font)
        Me.Label5.Image = CType(resources.GetObject("Label5.Image"), System.Drawing.Image)
        Me.Label5.ImageAlign = CType(resources.GetObject("Label5.ImageAlign"), System.Drawing.ContentAlignment)
        Me.Label5.ImageIndex = CType(resources.GetObject("Label5.ImageIndex"), Integer)
        Me.Label5.ImeMode = CType(resources.GetObject("Label5.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Label5.Location = CType(resources.GetObject("Label5.Location"), System.Drawing.Point)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = CType(resources.GetObject("Label5.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Label5.Size = CType(resources.GetObject("Label5.Size"), System.Drawing.Size)
        Me.Label5.TabIndex = CType(resources.GetObject("Label5.TabIndex"), Integer)
        Me.Label5.Text = resources.GetString("Label5.Text")
        Me.Label5.TextAlign = CType(resources.GetObject("Label5.TextAlign"), System.Drawing.ContentAlignment)
        Me.Label5.Visible = CType(resources.GetObject("Label5.Visible"), Boolean)
        '
        'Label4
        '
        Me.Label4.AccessibleDescription = CType(resources.GetObject("Label4.AccessibleDescription"), String)
        Me.Label4.AccessibleName = CType(resources.GetObject("Label4.AccessibleName"), String)
        Me.Label4.Anchor = CType(resources.GetObject("Label4.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = CType(resources.GetObject("Label4.AutoSize"), Boolean)
        Me.Label4.Dock = CType(resources.GetObject("Label4.Dock"), System.Windows.Forms.DockStyle)
        Me.Label4.Enabled = CType(resources.GetObject("Label4.Enabled"), Boolean)
        Me.Label4.Font = CType(resources.GetObject("Label4.Font"), System.Drawing.Font)
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaption
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
        'PictureBox2
        '
        Me.PictureBox2.AccessibleDescription = CType(resources.GetObject("PictureBox2.AccessibleDescription"), String)
        Me.PictureBox2.AccessibleName = CType(resources.GetObject("PictureBox2.AccessibleName"), String)
        Me.PictureBox2.Anchor = CType(resources.GetObject("PictureBox2.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.BackColor = System.Drawing.SystemColors.Menu
        Me.PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox2.Dock = CType(resources.GetObject("PictureBox2.Dock"), System.Windows.Forms.DockStyle)
        Me.PictureBox2.Enabled = CType(resources.GetObject("PictureBox2.Enabled"), Boolean)
        Me.PictureBox2.Font = CType(resources.GetObject("PictureBox2.Font"), System.Drawing.Font)
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.ImeMode = CType(resources.GetObject("PictureBox2.ImeMode"), System.Windows.Forms.ImeMode)
        Me.PictureBox2.Location = CType(resources.GetObject("PictureBox2.Location"), System.Drawing.Point)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.RightToLeft = CType(resources.GetObject("PictureBox2.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.PictureBox2.Size = CType(resources.GetObject("PictureBox2.Size"), System.Drawing.Size)
        Me.PictureBox2.SizeMode = CType(resources.GetObject("PictureBox2.SizeMode"), System.Windows.Forms.PictureBoxSizeMode)
        Me.PictureBox2.TabIndex = CType(resources.GetObject("PictureBox2.TabIndex"), Integer)
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Text = resources.GetString("PictureBox2.Text")
        Me.PictureBox2.Visible = CType(resources.GetObject("PictureBox2.Visible"), Boolean)
        '
        'btnDelete
        '
        Me.btnDelete.AccessibleDescription = CType(resources.GetObject("btnDelete.AccessibleDescription"), String)
        Me.btnDelete.AccessibleName = CType(resources.GetObject("btnDelete.AccessibleName"), String)
        Me.btnDelete.Anchor = CType(resources.GetObject("btnDelete.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.btnDelete.BackgroundImage = CType(resources.GetObject("btnDelete.BackgroundImage"), System.Drawing.Image)
        Me.btnDelete.Dock = CType(resources.GetObject("btnDelete.Dock"), System.Windows.Forms.DockStyle)
        Me.btnDelete.Enabled = CType(resources.GetObject("btnDelete.Enabled"), Boolean)
        Me.btnDelete.FlatStyle = CType(resources.GetObject("btnDelete.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnDelete.Font = CType(resources.GetObject("btnDelete.Font"), System.Drawing.Font)
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageAlign = CType(resources.GetObject("btnDelete.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnDelete.ImageIndex = CType(resources.GetObject("btnDelete.ImageIndex"), Integer)
        Me.btnDelete.ImeMode = CType(resources.GetObject("btnDelete.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnDelete.Location = CType(resources.GetObject("btnDelete.Location"), System.Drawing.Point)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.RightToLeft = CType(resources.GetObject("btnDelete.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnDelete.Size = CType(resources.GetObject("btnDelete.Size"), System.Drawing.Size)
        Me.btnDelete.TabIndex = CType(resources.GetObject("btnDelete.TabIndex"), Integer)
        Me.btnDelete.Text = resources.GetString("btnDelete.Text")
        Me.btnDelete.TextAlign = CType(resources.GetObject("btnDelete.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnDelete.Visible = CType(resources.GetObject("btnDelete.Visible"), Boolean)
        '
        'btnDisplay
        '
        Me.btnDisplay.AccessibleDescription = CType(resources.GetObject("btnDisplay.AccessibleDescription"), String)
        Me.btnDisplay.AccessibleName = CType(resources.GetObject("btnDisplay.AccessibleName"), String)
        Me.btnDisplay.Anchor = CType(resources.GetObject("btnDisplay.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnDisplay.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.btnDisplay.BackgroundImage = CType(resources.GetObject("btnDisplay.BackgroundImage"), System.Drawing.Image)
        Me.btnDisplay.Dock = CType(resources.GetObject("btnDisplay.Dock"), System.Windows.Forms.DockStyle)
        Me.btnDisplay.Enabled = CType(resources.GetObject("btnDisplay.Enabled"), Boolean)
        Me.btnDisplay.FlatStyle = CType(resources.GetObject("btnDisplay.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnDisplay.Font = CType(resources.GetObject("btnDisplay.Font"), System.Drawing.Font)
        Me.btnDisplay.Image = CType(resources.GetObject("btnDisplay.Image"), System.Drawing.Image)
        Me.btnDisplay.ImageAlign = CType(resources.GetObject("btnDisplay.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnDisplay.ImageIndex = CType(resources.GetObject("btnDisplay.ImageIndex"), Integer)
        Me.btnDisplay.ImeMode = CType(resources.GetObject("btnDisplay.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnDisplay.Location = CType(resources.GetObject("btnDisplay.Location"), System.Drawing.Point)
        Me.btnDisplay.Name = "btnDisplay"
        Me.btnDisplay.RightToLeft = CType(resources.GetObject("btnDisplay.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnDisplay.Size = CType(resources.GetObject("btnDisplay.Size"), System.Drawing.Size)
        Me.btnDisplay.TabIndex = CType(resources.GetObject("btnDisplay.TabIndex"), Integer)
        Me.btnDisplay.Text = resources.GetString("btnDisplay.Text")
        Me.btnDisplay.TextAlign = CType(resources.GetObject("btnDisplay.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnDisplay.Visible = CType(resources.GetObject("btnDisplay.Visible"), Boolean)
        '
        'lstPictures
        '
        Me.lstPictures.AccessibleDescription = CType(resources.GetObject("lstPictures.AccessibleDescription"), String)
        Me.lstPictures.AccessibleName = CType(resources.GetObject("lstPictures.AccessibleName"), String)
        Me.lstPictures.Anchor = CType(resources.GetObject("lstPictures.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lstPictures.BackgroundImage = CType(resources.GetObject("lstPictures.BackgroundImage"), System.Drawing.Image)
        Me.lstPictures.ColumnWidth = CType(resources.GetObject("lstPictures.ColumnWidth"), Integer)
        Me.lstPictures.Dock = CType(resources.GetObject("lstPictures.Dock"), System.Windows.Forms.DockStyle)
        Me.lstPictures.Enabled = CType(resources.GetObject("lstPictures.Enabled"), Boolean)
        Me.lstPictures.Font = CType(resources.GetObject("lstPictures.Font"), System.Drawing.Font)
        Me.lstPictures.HorizontalExtent = CType(resources.GetObject("lstPictures.HorizontalExtent"), Integer)
        Me.lstPictures.HorizontalScrollbar = CType(resources.GetObject("lstPictures.HorizontalScrollbar"), Boolean)
        Me.lstPictures.ImeMode = CType(resources.GetObject("lstPictures.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lstPictures.IntegralHeight = CType(resources.GetObject("lstPictures.IntegralHeight"), Boolean)
        Me.lstPictures.ItemHeight = CType(resources.GetObject("lstPictures.ItemHeight"), Integer)
        Me.lstPictures.Location = CType(resources.GetObject("lstPictures.Location"), System.Drawing.Point)
        Me.lstPictures.Name = "lstPictures"
        Me.lstPictures.RightToLeft = CType(resources.GetObject("lstPictures.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lstPictures.ScrollAlwaysVisible = CType(resources.GetObject("lstPictures.ScrollAlwaysVisible"), Boolean)
        Me.lstPictures.Size = CType(resources.GetObject("lstPictures.Size"), System.Drawing.Size)
        Me.lstPictures.TabIndex = CType(resources.GetObject("lstPictures.TabIndex"), Integer)
        Me.lstPictures.Visible = CType(resources.GetObject("lstPictures.Visible"), Boolean)
        '
        'Label1
        '
        Me.Label1.AccessibleDescription = CType(resources.GetObject("Label1.AccessibleDescription"), String)
        Me.Label1.AccessibleName = CType(resources.GetObject("Label1.AccessibleName"), String)
        Me.Label1.Anchor = CType(resources.GetObject("Label1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = CType(resources.GetObject("Label1.AutoSize"), Boolean)
        Me.Label1.Dock = CType(resources.GetObject("Label1.Dock"), System.Windows.Forms.DockStyle)
        Me.Label1.Enabled = CType(resources.GetObject("Label1.Enabled"), Boolean)
        Me.Label1.Font = CType(resources.GetObject("Label1.Font"), System.Drawing.Font)
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
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
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = resources.GetString("OpenFileDialog1.Filter")
        Me.OpenFileDialog1.Title = resources.GetString("OpenFileDialog1.Title")
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
        Me.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = CType(resources.GetObject("$this.ClientSize"), System.Drawing.Size)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.TabControl1})
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
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
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

    ' Handles the Browse button click event, allowing the user to find an image, 
    ' display it in a PictureBox control, and save the image to the database.
    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        ' Use an OpenFileDialog to enable the user to find an image to save to the 
        ' database. Provide a pipe-delimited set of pipe-delimited pairs of file 
        ' types that will appear in the dialog. Set the FilterIndex to the default 
        ' file type.
        With OpenFileDialog1
            .InitialDirectory = "C:\"
            .Filter = "All Files|*.*|Bitmaps|*.bmp|GIFs|*.gif|JPEGs|*.jpg"
            .FilterIndex = 2
        End With

        ' When the user clicks the Open button (DialogResult.OK is the only option;
        ' there is not DialogResult.Open), display the image centered in the 
        ' PictureBox and display the full path of the image.
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            With PictureBox1
                .Image = Image.FromFile(OpenFileDialog1.FileName)
                .SizeMode = PictureBoxSizeMode.CenterImage
                .BorderStyle = BorderStyle.Fixed3D
            End With
            lblFilePath.Text = OpenFileDialog1.FileName
        End If
    End Sub

    ' Handles the Delete button click event, allowing the user to delete an image 
    ' stored in the database.
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        ' When nothing is selected in the ListBox, the SelectedIndex = -1.
        If lstPictures.SelectedIndex < 0 Then
            MessageBox.Show("There are no images in the database to delete.", _
                "Empty Database!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            ' Use the SqlCommandBuilder to get a delete command and update the DataSet
            ' after you delete the row in the DataSet that corresponds with the picture
            ' the user has selected.
            dsPictures.Tables(0).Rows(lstPictures.SelectedIndex).Delete()
            da.UpdateCommand = cbd.GetDeleteCommand
            da.Update(dsPictures)

            ' Clear the image and filename
            lblFileName.Text = ""
            PictureBox2.Image = Nothing
        End If
    End Sub

    ' Handles the Display button click event, allowing the user to display an image 
    ' stored in the database.
    Private Sub btnDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        ' When nothing is selected in the ListBox, the SelectedIndex = -1.
        If lstPictures.SelectedIndex < 0 Then
            MessageBox.Show("There are no images in the database to display.", _
                "Empty Database!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            ' The SQL Server Image datatype is a binary datatype. Therefore, to 
            ' generate an image from it you must first create a stream object 
            ' containing the binary data. Then you can generate the image by 
            ' calling Image.FromStream().
            Dim arrPicture() As Byte = _
             CType(dsPictures.Tables(0).Rows(lstPictures.SelectedIndex)("Picture"), _
             Byte())
            Dim ms As New MemoryStream(arrPicture)

            With PictureBox2
                .Image = Image.FromStream(ms)
                .SizeMode = PictureBoxSizeMode.CenterImage
                .BorderStyle = BorderStyle.Fixed3D
            End With

            lblFileName.Text = _
             dsPictures.Tables(0).Rows(lstPictures.SelectedIndex)("FileName").ToString

            ' Close the stream object to release the resource.
            ms.Close()
        End If
    End Sub

    ' Handles the Create Table button click event, allowing the user to drop (if it exists)
    ' and create the Picture table in the Northwind database.
    Private Sub btnModifyDB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModifyDB.Click
        Dim strSQL As String = _
            "IF EXISTS (" & _
            "SELECT * " & _
            "FROM northwind.dbo.sysobjects " & _
            "WHERE NAME = 'Picture' " & _
            "AND TYPE = 'u')" & vbCrLf & _
            "BEGIN" & vbCrLf & _
            "DROP TABLE northwind.dbo.picture" & vbCrLf & _
            "END" & vbCrLf & _
            "CREATE TABLE Picture (" & _
            "PictureID Int IDENTITY(1,1) NOT NULL," & _
            "[FileName] Varchar(255) NOT NULL," & _
            "Picture Image NOT NULL," & _
            "CONSTRAINT [PK_Picture] PRIMARY KEY CLUSTERED" & _
            "(PictureID))"

        ' Display a status message saying that we're attempting to connect.
        ' This only needs to be done the very first time a connection is
        ' attempted.  After we've determined that MSDE or SQL Server is
        ' installed, this message no longer needs to be displayed.
        Dim frmStatusMessage As New frmStatus()
        If Not didPreviouslyConnect Then
            frmStatusMessage.Show("Connecting to MSDE")
        End If

        ' Attempt to connect to the local SQL server instance, and a local
        ' MSDE installation (with Northwind).  
        Dim isConnecting As Boolean = True
        While isConnecting
            Try
                ' The SqlConnection class allows you to communicate with SQL Server.
                ' The constructor accepts a connection string as an argument.  This
                ' connection string uses Integrated Security, which means that you 
                ' must have a login in SQL Server, or be part of the Administrators
                ' group for this to work.
                Dim northwindConnection As New SqlConnection(connectionString)

                ' A SqlCommand object is used to execute the SQL commands.
                Dim cmd As New SqlCommand(strSQL, northwindConnection)

                ' Open the connection, execute the command, and close the connection.
                ' It is more efficient to ExecuteNonQuery when data is not being 
                ' returned.
                northwindConnection.Open()
                cmd.ExecuteNonQuery()
                northwindConnection.Close()

                ' Data has been successfully submitted, so break out of the loop
                ' and close the status form.
                isConnecting = False
                didPreviouslyConnect = True
                frmStatusMessage.Close()
                MessageBox.Show("Table successfully created.", "Table Creation Status", _
                    MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch sqlExc As SqlException
                If connectionString = MSDE_CONNECTION_STRING Then
                    ' Couldn't connect to SQL Server.  Now try MSDE.
                    connectionString = SQL_CONNECTION_STRING
                    frmStatusMessage.Show("Connecting to SQL Server")
                Else
                    ' Unable to connect to SQL Server or MSDE
                    frmStatusMessage.Close()
                    MessageBox.Show(CONNECTION_ERROR_MSG, _
                            "Connection Failed!", MessageBoxButtons.OK, _
                            MessageBoxIcon.Error)
                    End
                End If
                
            Catch exc As Exception
                MessageBox.Show(exc.ToString, "SQL Exception Error!", _
                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit While

            End Try
        End While
        frmStatusMessage.Close()
    End Sub

    ' Handles the Save button click event, allowing the user to save the image
    ' viewed in the PictureBox to the database.
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        ' PREPARE DATA TO BE PASSED TO DATABASE:
        ' You only need to save the filename, not the entire path. Therefore, 
        ' Split the path, creating an array of strings. Make sure you pass in 
        ' the delimiter. Then reverse the array so that you can assign the 
        ' first string in the array to the SQL parameter.
        Dim arrFilename() As String = Split(lblFilePath.Text, "\")
        arrFilename.Reverse(arrFilename)

        ' The SQL Server Image datatype is a binary datatype. Therefore, to save 
        ' it to the database you must convert the image to an array of bytes. You
        ' could use a FileStream object to open the image file and then read it to 
        ' the stream, but a MemoryStream with the Image.Save method is a bit easier.
        Dim ms As New MemoryStream()
        PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
        Dim arrImage() As Byte = ms.GetBuffer

        ' Close the stream object to release the resource.
        ms.Close()

        ' Display a status message saying that we're attempting to connect.
        ' This only needs to be done the very first time a connection is
        ' attempted.  After we've determined that MSDE or SQL Server is
        ' installed, this message no longer needs to be displayed.
        Dim frmStatusMessage As New frmStatus()
        If Not didPreviouslyConnect Then
            frmStatusMessage.Show("Connecting to MSDE")
        End If

        ' Attempt to connect to the local SQL server instance, and a local
        ' MSDE installation (with Northwind).  
        Dim isConnecting As Boolean = True
        While isConnecting

            Try
                ' The SqlConnection class allows you to communicate with SQL Server.
                ' The constructor accepts a connection string as an argument.  This
                ' connection string uses Integrated Security, which means that you 
                ' must have a login in SQL Server, or be part of the Administrators
                ' group for this to work.
                Dim northwindConnection As New SqlConnection(connectionString)
                Dim strSQL As String = _
                    "INSERT INTO Picture (Filename, Picture)" & _
                    "VALUES (@Filename, @Picture)"

                ' A SqlCommand object is used to execute the SQL statement.
                Dim cmd As New SqlCommand(strSQL, northwindConnection)
                With cmd
                    ' Add parameters required by SQL statement. PictureID is an 
                    ' identity field (in Microsoft Access, an AutoNumber field), 
                    ' so you only need to pass values for the two remaining fields.
                    .Parameters.Add(New SqlParameter("@Filename", _
                        SqlDbType.NVarChar, 50)).Value = arrFilename(0)
                    .Parameters.Add(New SqlParameter("@Picture", _
                        SqlDbType.Image)).Value = arrImage
                End With

                ' Open the connection, execute the command, and close the 
                ' connection. It is more efficient to ExecuteNonQuery when data 
                ' is not being returned.
                northwindConnection.Open()
                cmd.ExecuteNonQuery()
                northwindConnection.Close()

                ' Data has been successfully submitted, so break out of the loop
                ' and close the status form.
                isConnecting = False
                didPreviouslyConnect = True
                frmStatusMessage.Close()
                MessageBox.Show(arrFilename(0) & " saved to the database.", _
                    "Image Save Status", MessageBoxButtons.OK, _
                    MessageBoxIcon.Information)

            Catch sqlExc As SqlException
                If connectionString = MSDE_CONNECTION_STRING Then
                    ' Couldn't connect to SQL Server.  Now try MSDE.
                    connectionString = SQL_CONNECTION_STRING
                    frmStatusMessage.Show("Connecting to SQL Server")
                Else
                    ' Unable to connect to SQL Server or MSDE
                    frmStatusMessage.Close()
                    MessageBox.Show(CONNECTION_ERROR_MSG, _
                            "Connection Failed!", MessageBoxButtons.OK, _
                            MessageBoxIcon.Error)
                    End
                End If
                
            Catch exc As Exception
                MessageBox.Show(exc.ToString, "SQL Exception Error!", _
                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit While

            End Try
        End While
    End Sub

    ' Handles the SelectedIndexChanged event of the TabControl, causing a DataSet to 
    ' be created and bound to a ListBox control when the user clicks the Manage tab.
    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged

        If TabControl1.SelectedIndex = 2 Then

            ' Display a status message saying that we're attempting to connect.
            ' This only needs to be done the very first time a connection is
            ' attempted.  After we've determined that MSDE or SQL Server is
            ' installed, this message no longer needs to be displayed.
            Dim frmStatusMessage As New frmStatus()
            If Not didPreviouslyConnect Then
                frmStatusMessage.Show("Connecting to MSDE")
            End If

            ' Attempt to connect to the local SQL server instance, and a local
            ' MSDE installation (with Northwind).  
            Dim isConnecting As Boolean = True
            While isConnecting

                Try
                    ' The SqlConnection class allows you to communicate with SQL 
                    ' Server. The constructor accepts a connection string as an 
                    ' argument.This connection string uses Integrated Security, 
                    ' which means that you must have a login in SQL Server, or be 
                    ' part of the Administrators group for this to work.
                    Dim northwindConnection As New SqlConnection(connectionString)

                    ' A SqlCommand object is used to execute the SQL commands.
                    Dim cmd As New SqlCommand("SELECT * " & _
                                              "FROM Picture", _
                                              northwindConnection)

                    ' The SqlDataAdapter is responsible for filling a DataSet.
                    da = New SqlDataAdapter(cmd)

                    ' TheSqlCommandBuilder will be used for deleting pictures from 
                    ' the database in the btnDelete click event handler.
                    cbd = New SqlCommandBuilder(da)

                    dsPictures = New DataSet()

                    da.Fill(dsPictures)

                    ' Data has been successfully retrieved, so break out of the loop
                    ' and close the status form.
                    isConnecting = False
                    didPreviouslyConnect = True
                    frmStatusMessage.Close()

                    ' Display the filenames of the pictures in the DataSet.
                    With lstPictures
                        .DataSource = dsPictures.Tables(0)
                        .DisplayMember = "FileName"
                    End With

                Catch sqlExc As SqlException
                    If connectionString = MSDE_CONNECTION_STRING Then
                        ' Couldn't connect to SQL Server.  Now try MSDE.
                        connectionString = SQL_CONNECTION_STRING
                        frmStatusMessage.Show("Connecting to SQL Server")
                    Else
                        ' Unable to connect to SQL Server or MSDE
                        frmStatusMessage.Close()
                        MessageBox.Show(CONNECTION_ERROR_MSG, _
                                "Connection Failed!", MessageBoxButtons.OK, _
                                MessageBoxIcon.Error)
                    End If                   

                Catch exc As Exception
                    MessageBox.Show(exc.ToString, "SQL Exception Error!", _
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit While

                End Try
            End While
        End If
    End Sub

End Class