'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Public Class frmMain
    Inherits System.Windows.Forms.Form

    ' The following Strings hold the various ways of formatting the
    '   "The Clipboard is Cool!" text.
    Dim strText As String = "The Clipboard is Cool!"
    Dim strHTML As String = "<P>The <B><FONT size='4'><U>Clipboard</U></FONT></B>" & _
        "is <FONT size='5'>Cool!</FONT></P>"
    Dim strRTF As String = "{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{" & _
        "\f0\fswiss\fcharset0 Arial;}}\viewkind4\uc1\pard\f0\fs20 The \ul\b\fs24 " & _
        "Clipboard\ulnone\b0  \fs20 is \fs36 Cool!\par}"
    Dim strXML As String = "<?xml version='1.0'?><Message>The Clipboard " & _
        "is Cool!</Message>"

    ' myImage holds a Bitmap image of two dogs in memory.
    Dim myImage As New System.Drawing.Bitmap("..\twodogs.jpg")


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
    Friend WithEvents mnuEdit As System.Windows.Forms.MenuItem
    Friend WithEvents txtPaste As System.Windows.Forms.TextBox
    Friend WithEvents rtbPaste As System.Windows.Forms.RichTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents mnuCopyTextAs As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCopyTextAsText As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCopyTextAsHTML As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCopyTextAsRTF As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCopyTextAsMXL As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCopyTextAsAllFormats As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCopyImageAs As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCopyImageAsBitmap As System.Windows.Forms.MenuItem
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents picturePaste As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuEdit = New System.Windows.Forms.MenuItem()
        Me.mnuCopyTextAs = New System.Windows.Forms.MenuItem()
        Me.mnuCopyTextAsText = New System.Windows.Forms.MenuItem()
        Me.mnuCopyTextAsHTML = New System.Windows.Forms.MenuItem()
        Me.mnuCopyTextAsRTF = New System.Windows.Forms.MenuItem()
        Me.mnuCopyTextAsMXL = New System.Windows.Forms.MenuItem()
        Me.mnuCopyTextAsAllFormats = New System.Windows.Forms.MenuItem()
        Me.mnuCopyImageAs = New System.Windows.Forms.MenuItem()
        Me.mnuCopyImageAsBitmap = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.txtPaste = New System.Windows.Forms.TextBox()
        Me.rtbPaste = New System.Windows.Forms.RichTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.picturePaste = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'mnuMain
        '
        Me.mnuMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.mnuEdit, Me.mnuHelp})
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
        'mnuEdit
        '
        Me.mnuEdit.Enabled = CType(resources.GetObject("mnuEdit.Enabled"), Boolean)
        Me.mnuEdit.Index = 1
        Me.mnuEdit.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuCopyTextAs, Me.mnuCopyImageAs})
        Me.mnuEdit.Shortcut = CType(resources.GetObject("mnuEdit.Shortcut"), System.Windows.Forms.Shortcut)
        Me.mnuEdit.ShowShortcut = CType(resources.GetObject("mnuEdit.ShowShortcut"), Boolean)
        Me.mnuEdit.Text = resources.GetString("mnuEdit.Text")
        Me.mnuEdit.Visible = CType(resources.GetObject("mnuEdit.Visible"), Boolean)
        '
        'mnuCopyTextAs
        '
        Me.mnuCopyTextAs.Enabled = CType(resources.GetObject("mnuCopyTextAs.Enabled"), Boolean)
        Me.mnuCopyTextAs.Index = 0
        Me.mnuCopyTextAs.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuCopyTextAsText, Me.mnuCopyTextAsHTML, Me.mnuCopyTextAsRTF, Me.mnuCopyTextAsMXL, Me.mnuCopyTextAsAllFormats})
        Me.mnuCopyTextAs.Shortcut = CType(resources.GetObject("mnuCopyTextAs.Shortcut"), System.Windows.Forms.Shortcut)
        Me.mnuCopyTextAs.ShowShortcut = CType(resources.GetObject("mnuCopyTextAs.ShowShortcut"), Boolean)
        Me.mnuCopyTextAs.Text = resources.GetString("mnuCopyTextAs.Text")
        Me.mnuCopyTextAs.Visible = CType(resources.GetObject("mnuCopyTextAs.Visible"), Boolean)
        '
        'mnuCopyTextAsText
        '
        Me.mnuCopyTextAsText.Enabled = CType(resources.GetObject("mnuCopyTextAsText.Enabled"), Boolean)
        Me.mnuCopyTextAsText.Index = 0
        Me.mnuCopyTextAsText.Shortcut = CType(resources.GetObject("mnuCopyTextAsText.Shortcut"), System.Windows.Forms.Shortcut)
        Me.mnuCopyTextAsText.ShowShortcut = CType(resources.GetObject("mnuCopyTextAsText.ShowShortcut"), Boolean)
        Me.mnuCopyTextAsText.Text = resources.GetString("mnuCopyTextAsText.Text")
        Me.mnuCopyTextAsText.Visible = CType(resources.GetObject("mnuCopyTextAsText.Visible"), Boolean)
        '
        'mnuCopyTextAsHTML
        '
        Me.mnuCopyTextAsHTML.Enabled = CType(resources.GetObject("mnuCopyTextAsHTML.Enabled"), Boolean)
        Me.mnuCopyTextAsHTML.Index = 1
        Me.mnuCopyTextAsHTML.Shortcut = CType(resources.GetObject("mnuCopyTextAsHTML.Shortcut"), System.Windows.Forms.Shortcut)
        Me.mnuCopyTextAsHTML.ShowShortcut = CType(resources.GetObject("mnuCopyTextAsHTML.ShowShortcut"), Boolean)
        Me.mnuCopyTextAsHTML.Text = resources.GetString("mnuCopyTextAsHTML.Text")
        Me.mnuCopyTextAsHTML.Visible = CType(resources.GetObject("mnuCopyTextAsHTML.Visible"), Boolean)
        '
        'mnuCopyTextAsRTF
        '
        Me.mnuCopyTextAsRTF.Enabled = CType(resources.GetObject("mnuCopyTextAsRTF.Enabled"), Boolean)
        Me.mnuCopyTextAsRTF.Index = 2
        Me.mnuCopyTextAsRTF.Shortcut = CType(resources.GetObject("mnuCopyTextAsRTF.Shortcut"), System.Windows.Forms.Shortcut)
        Me.mnuCopyTextAsRTF.ShowShortcut = CType(resources.GetObject("mnuCopyTextAsRTF.ShowShortcut"), Boolean)
        Me.mnuCopyTextAsRTF.Text = resources.GetString("mnuCopyTextAsRTF.Text")
        Me.mnuCopyTextAsRTF.Visible = CType(resources.GetObject("mnuCopyTextAsRTF.Visible"), Boolean)
        '
        'mnuCopyTextAsMXL
        '
        Me.mnuCopyTextAsMXL.Enabled = CType(resources.GetObject("mnuCopyTextAsMXL.Enabled"), Boolean)
        Me.mnuCopyTextAsMXL.Index = 3
        Me.mnuCopyTextAsMXL.Shortcut = CType(resources.GetObject("mnuCopyTextAsMXL.Shortcut"), System.Windows.Forms.Shortcut)
        Me.mnuCopyTextAsMXL.ShowShortcut = CType(resources.GetObject("mnuCopyTextAsMXL.ShowShortcut"), Boolean)
        Me.mnuCopyTextAsMXL.Text = resources.GetString("mnuCopyTextAsMXL.Text")
        Me.mnuCopyTextAsMXL.Visible = CType(resources.GetObject("mnuCopyTextAsMXL.Visible"), Boolean)
        '
        'mnuCopyTextAsAllFormats
        '
        Me.mnuCopyTextAsAllFormats.Enabled = CType(resources.GetObject("mnuCopyTextAsAllFormats.Enabled"), Boolean)
        Me.mnuCopyTextAsAllFormats.Index = 4
        Me.mnuCopyTextAsAllFormats.Shortcut = CType(resources.GetObject("mnuCopyTextAsAllFormats.Shortcut"), System.Windows.Forms.Shortcut)
        Me.mnuCopyTextAsAllFormats.ShowShortcut = CType(resources.GetObject("mnuCopyTextAsAllFormats.ShowShortcut"), Boolean)
        Me.mnuCopyTextAsAllFormats.Text = resources.GetString("mnuCopyTextAsAllFormats.Text")
        Me.mnuCopyTextAsAllFormats.Visible = CType(resources.GetObject("mnuCopyTextAsAllFormats.Visible"), Boolean)
        '
        'mnuCopyImageAs
        '
        Me.mnuCopyImageAs.Enabled = CType(resources.GetObject("mnuCopyImageAs.Enabled"), Boolean)
        Me.mnuCopyImageAs.Index = 1
        Me.mnuCopyImageAs.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuCopyImageAsBitmap})
        Me.mnuCopyImageAs.Shortcut = CType(resources.GetObject("mnuCopyImageAs.Shortcut"), System.Windows.Forms.Shortcut)
        Me.mnuCopyImageAs.ShowShortcut = CType(resources.GetObject("mnuCopyImageAs.ShowShortcut"), Boolean)
        Me.mnuCopyImageAs.Text = resources.GetString("mnuCopyImageAs.Text")
        Me.mnuCopyImageAs.Visible = CType(resources.GetObject("mnuCopyImageAs.Visible"), Boolean)
        '
        'mnuCopyImageAsBitmap
        '
        Me.mnuCopyImageAsBitmap.Enabled = CType(resources.GetObject("mnuCopyImageAsBitmap.Enabled"), Boolean)
        Me.mnuCopyImageAsBitmap.Index = 0
        Me.mnuCopyImageAsBitmap.Shortcut = CType(resources.GetObject("mnuCopyImageAsBitmap.Shortcut"), System.Windows.Forms.Shortcut)
        Me.mnuCopyImageAsBitmap.ShowShortcut = CType(resources.GetObject("mnuCopyImageAsBitmap.ShowShortcut"), Boolean)
        Me.mnuCopyImageAsBitmap.Text = resources.GetString("mnuCopyImageAsBitmap.Text")
        Me.mnuCopyImageAsBitmap.Visible = CType(resources.GetObject("mnuCopyImageAsBitmap.Visible"), Boolean)
        '
        'mnuHelp
        '
        Me.mnuHelp.Enabled = CType(resources.GetObject("mnuHelp.Enabled"), Boolean)
        Me.mnuHelp.Index = 2
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
        'txtPaste
        '
        Me.txtPaste.AccessibleDescription = CType(resources.GetObject("txtPaste.AccessibleDescription"), String)
        Me.txtPaste.AccessibleName = CType(resources.GetObject("txtPaste.AccessibleName"), String)
        Me.txtPaste.Anchor = CType(resources.GetObject("txtPaste.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtPaste.AutoSize = CType(resources.GetObject("txtPaste.AutoSize"), Boolean)
        Me.txtPaste.BackgroundImage = CType(resources.GetObject("txtPaste.BackgroundImage"), System.Drawing.Image)
        Me.txtPaste.Dock = CType(resources.GetObject("txtPaste.Dock"), System.Windows.Forms.DockStyle)
        Me.txtPaste.Enabled = CType(resources.GetObject("txtPaste.Enabled"), Boolean)
        Me.txtPaste.Font = CType(resources.GetObject("txtPaste.Font"), System.Drawing.Font)
        Me.txtPaste.ImeMode = CType(resources.GetObject("txtPaste.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtPaste.Location = CType(resources.GetObject("txtPaste.Location"), System.Drawing.Point)
        Me.txtPaste.MaxLength = CType(resources.GetObject("txtPaste.MaxLength"), Integer)
        Me.txtPaste.Multiline = CType(resources.GetObject("txtPaste.Multiline"), Boolean)
        Me.txtPaste.Name = "txtPaste"
        Me.txtPaste.PasswordChar = CType(resources.GetObject("txtPaste.PasswordChar"), Char)
        Me.txtPaste.RightToLeft = CType(resources.GetObject("txtPaste.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtPaste.ScrollBars = CType(resources.GetObject("txtPaste.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtPaste.Size = CType(resources.GetObject("txtPaste.Size"), System.Drawing.Size)
        Me.txtPaste.TabIndex = CType(resources.GetObject("txtPaste.TabIndex"), Integer)
        Me.txtPaste.Text = resources.GetString("txtPaste.Text")
        Me.txtPaste.TextAlign = CType(resources.GetObject("txtPaste.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtPaste.Visible = CType(resources.GetObject("txtPaste.Visible"), Boolean)
        Me.txtPaste.WordWrap = CType(resources.GetObject("txtPaste.WordWrap"), Boolean)
        '
        'rtbPaste
        '
        Me.rtbPaste.AccessibleDescription = CType(resources.GetObject("rtbPaste.AccessibleDescription"), String)
        Me.rtbPaste.AccessibleName = CType(resources.GetObject("rtbPaste.AccessibleName"), String)
        Me.rtbPaste.Anchor = CType(resources.GetObject("rtbPaste.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.rtbPaste.AutoSize = CType(resources.GetObject("rtbPaste.AutoSize"), Boolean)
        Me.rtbPaste.BackgroundImage = CType(resources.GetObject("rtbPaste.BackgroundImage"), System.Drawing.Image)
        Me.rtbPaste.BulletIndent = CType(resources.GetObject("rtbPaste.BulletIndent"), Integer)
        Me.rtbPaste.Dock = CType(resources.GetObject("rtbPaste.Dock"), System.Windows.Forms.DockStyle)
        Me.rtbPaste.Enabled = CType(resources.GetObject("rtbPaste.Enabled"), Boolean)
        Me.rtbPaste.Font = CType(resources.GetObject("rtbPaste.Font"), System.Drawing.Font)
        Me.rtbPaste.ImeMode = CType(resources.GetObject("rtbPaste.ImeMode"), System.Windows.Forms.ImeMode)
        Me.rtbPaste.Location = CType(resources.GetObject("rtbPaste.Location"), System.Drawing.Point)
        Me.rtbPaste.MaxLength = CType(resources.GetObject("rtbPaste.MaxLength"), Integer)
        Me.rtbPaste.Multiline = CType(resources.GetObject("rtbPaste.Multiline"), Boolean)
        Me.rtbPaste.Name = "rtbPaste"
        Me.rtbPaste.RightMargin = CType(resources.GetObject("rtbPaste.RightMargin"), Integer)
        Me.rtbPaste.RightToLeft = CType(resources.GetObject("rtbPaste.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.rtbPaste.ScrollBars = CType(resources.GetObject("rtbPaste.ScrollBars"), System.Windows.Forms.RichTextBoxScrollBars)
        Me.rtbPaste.Size = CType(resources.GetObject("rtbPaste.Size"), System.Drawing.Size)
        Me.rtbPaste.TabIndex = CType(resources.GetObject("rtbPaste.TabIndex"), Integer)
        Me.rtbPaste.Text = resources.GetString("rtbPaste.Text")
        Me.rtbPaste.Visible = CType(resources.GetObject("rtbPaste.Visible"), Boolean)
        Me.rtbPaste.WordWrap = CType(resources.GetObject("rtbPaste.WordWrap"), Boolean)
        Me.rtbPaste.ZoomFactor = CType(resources.GetObject("rtbPaste.ZoomFactor"), Single)
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
        'picturePaste
        '
        Me.picturePaste.AccessibleDescription = CType(resources.GetObject("picturePaste.AccessibleDescription"), String)
        Me.picturePaste.AccessibleName = CType(resources.GetObject("picturePaste.AccessibleName"), String)
        Me.picturePaste.Anchor = CType(resources.GetObject("picturePaste.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.picturePaste.BackColor = System.Drawing.SystemColors.Window
        Me.picturePaste.BackgroundImage = CType(resources.GetObject("picturePaste.BackgroundImage"), System.Drawing.Image)
        Me.picturePaste.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picturePaste.Dock = CType(resources.GetObject("picturePaste.Dock"), System.Windows.Forms.DockStyle)
        Me.picturePaste.Enabled = CType(resources.GetObject("picturePaste.Enabled"), Boolean)
        Me.picturePaste.Font = CType(resources.GetObject("picturePaste.Font"), System.Drawing.Font)
        Me.picturePaste.Image = CType(resources.GetObject("picturePaste.Image"), System.Drawing.Image)
        Me.picturePaste.ImeMode = CType(resources.GetObject("picturePaste.ImeMode"), System.Windows.Forms.ImeMode)
        Me.picturePaste.Location = CType(resources.GetObject("picturePaste.Location"), System.Drawing.Point)
        Me.picturePaste.Name = "picturePaste"
        Me.picturePaste.RightToLeft = CType(resources.GetObject("picturePaste.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.picturePaste.Size = CType(resources.GetObject("picturePaste.Size"), System.Drawing.Size)
        Me.picturePaste.SizeMode = CType(resources.GetObject("picturePaste.SizeMode"), System.Windows.Forms.PictureBoxSizeMode)
        Me.picturePaste.TabIndex = CType(resources.GetObject("picturePaste.TabIndex"), Integer)
        Me.picturePaste.TabStop = False
        Me.picturePaste.Text = resources.GetString("picturePaste.Text")
        Me.picturePaste.Visible = CType(resources.GetObject("picturePaste.Visible"), Boolean)
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
        Me.Label4.AccessibleDescription = CType(resources.GetObject("Label4.AccessibleDescription"), String)
        Me.Label4.AccessibleName = CType(resources.GetObject("Label4.AccessibleName"), String)
        Me.Label4.Anchor = CType(resources.GetObject("Label4.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = CType(resources.GetObject("Label4.AutoSize"), Boolean)
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
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
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label4, Me.Label3, Me.picturePaste, Me.Label2, Me.Label1, Me.rtbPaste, Me.txtPaste})
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

    ' Copy an image of two dogs to the Clipboard as a bitmap.
    Private Sub mnuCopyImageAsBitmap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCopyImageAsBitmap.Click
        Dim myDataObject As New DataObject()
        myDataObject.SetData(DataFormats.Bitmap, True, myImage)
        Clipboard.SetDataObject(myDataObject, True)
    End Sub

    ' Copy "The Clipboard is Cool!" to the Clipboard as all available
    '   formats. This can only be done by using a DataObject instance.
    '   The SetData method is called for all formats, along with their
    '   format name.
    Private Sub mnuCopyTextAsAllFormats_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCopyTextAsAllFormats.Click
        Dim myDataObject As New DataObject()

        ' Place text version in DataObject as text and unicode
        myDataObject.SetData(DataFormats.Text, strText)
        myDataObject.SetData(DataFormats.UnicodeText, strText)

        ' Place HTML version in DataObject 
        myDataObject.SetData(DataFormats.Html, strHTML)

        ' Place RTF version in DataObject 
        myDataObject.SetData(DataFormats.Rtf, strRTF)

        ' Place XML version in DataObject 
        myDataObject.SetData("MyInternalXmlFormat", strXML)

        ' Now place myDataObject, and thus all formats on the Clipboard
        Clipboard.SetDataObject(myDataObject, True)

    End Sub


    ' Copy "The Clipboard is Cool!" to the Clipboard as HTML.
    ' Here the HTML is first added to a DataObject so that the proper
    ' format can be specified.
    Private Sub mnuCopyTextAsHTML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCopyTextAsHTML.Click
        Dim myDataObject As New DataObject()
        myDataObject.SetData(DataFormats.Html, strHTML)
        Clipboard.SetDataObject(myDataObject, True)
    End Sub

    ' Copy "The Clipboard is Cool!" to the Clipboard as RTF.
    ' Here the RTF is first added to a DataObject so that the proper
    ' format can be specified.
    Private Sub mnuCopyTextAsRTF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCopyTextAsRTF.Click
        Dim myDataObject As New DataObject()
        myDataObject.SetData(DataFormats.Rtf, strRTF)
        Clipboard.SetDataObject(myDataObject, True)
    End Sub

    ' Copy "The Clipboard is Cool!" to the Clipboard as text.
    ' Here the text is simply copied directly to the clipboard.
    Private Sub mnuCopyTextAsText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCopyTextAsText.Click
        Clipboard.SetDataObject(strText, True)
    End Sub

    ' Copy "The Clipboard is Cool!" to the Clipboard as XML.
    ' Here the XML is first added to a DataObject so that the proper
    ' format can be specified.
    ' Since XML is not inherently supported by the clipboard (except as 
    ' Unicode Text), this represents a proprietary format. Since this 
    ' format will likely have little meaning outside of this application,
    ' the second parameter has been set to false, forcing the Clipboard to 
    ' not allow other applications access to this data.
    Private Sub mnuCopyTextAsMXL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCopyTextAsMXL.Click
        Dim myDataObject As New DataObject()
        myDataObject.SetData("MyInternalXmlFormat", strXML)
        Clipboard.SetDataObject(myDataObject, False)
    End Sub

    ' MnuEdit_Popup ensures that the when the Edit menu is clicked that
    ' the Paste As menu item is fully populated with only those formats
    ' that the Clipboard can support. 
    Private Sub mnuEdit_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuEdit.Popup
        Dim myPasteAsMenu As MenuItem ' Used to build the Paste As menu
        Dim myTypes() As MenuItem ' used to display different formats
        Dim strArray() As String ' array of different supported formats
        Dim i As Integer ' for loops

        ' If the Clipboard is not empty, fill strArray with a 
        ' list of all supported formats
        If Not (Clipboard.GetDataObject() Is Nothing) Then
            ' GetFormats() returns a string array with the suppored formats
            strArray = Clipboard.GetDataObject().GetFormats()
            ReDim myTypes(strArray.Length - 1)
            ' Create several new MenuItems each using the 
            ' PasteAsMenuEventHandler method as the event handler.
            For i = 0 To strArray.Length - 1
                myTypes(i) = New MenuItem(strArray(i), New System.EventHandler(AddressOf PasteAsMenuEventHandler))
            Next i
        End If

        ' Ensure that the .NET Framework handles showing the menu
        Me.mnuEdit.OwnerDraw = False

        ' Create the Paste As menu, with the available formats
        ' as sub-menu items.
        myPasteAsMenu = New MenuItem("&Paste As", myTypes)

        ' If it has been added before, delete it.
        If mnuEdit.MenuItems.Count = 3 Then
            mnuEdit.MenuItems.RemoveAt(2)
        End If

        ' Add the Paste As menu to the Edit menu.
        Me.mnuEdit.MenuItems.Add(myPasteAsMenu)

    End Sub

    ' PasteAsMenuEventHandler handles all of the Paste commands, regardless
    ' of what format was selected. The string name of the format is passed
    ' as the Text in the sending MenuItem.
    Private Sub PasteAsMenuEventHandler(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim strType As String ' holds the value of the Format
        Dim obj As Object ' used to hold data to be pasted

        ' Clear all output boxes for this paste
        Me.rtbPaste.Clear()
        Me.txtPaste.Clear()
        Me.picturePaste.Image = Nothing

        ' Get the user selected format as a string.
        strType = CType(sender, MenuItem).Text

        ' Ensure that the Clipboard can support the selected format
        If Clipboard.GetDataObject().GetDataPresent(strType) Then
            ' Set obj to the data on the clipboard, in the requested format
            obj = Clipboard.GetDataObject().GetData(strType)
            If Not obj Is Nothing Then

                ' Paste into the RichTextBox using the Paste() method
                Me.rtbPaste.Paste(DataFormats.GetFormat(strType))

                ' Paste the textual representation into the TextBox
                If obj.GetType().ToString() = "System.String" Then
                    Me.txtPaste.AppendText(CType(obj, String))
                Else
                    Me.txtPaste.AppendText(obj.GetType.ToString())
                End If

                ' Attempt to paste into the PictureBox
                '   If it fails, the PictureBox does not support this
                '   format, so set clear the Image.
                Try
                    picturePaste.Image = CType(obj, Image)
                Catch ex As Exception
                    picturePaste.Image = Nothing
                End Try
            End If
        End If

    End Sub

End Class