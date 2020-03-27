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
    Friend WithEvents rexUsZipcode As VBNET.HowTo.RegExTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rexEmail As VBNET.HowTo.EMailTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents rexSsn As VBNET.HowTo.SsnTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents rexPhone As VBNET.HowTo.PhoneTextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtInvalidControls As System.Windows.Forms.TextBox
    Friend WithEvents rexIpAddress As VBNET.HowTo.IPAddressTextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rexUsZipcode = New VBNET.HowTo.RegExTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rexEmail = New VBNET.HowTo.EMailTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.rexIpAddress = New VBNET.HowTo.IPAddressTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.rexSsn = New VBNET.HowTo.SsnTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.rexPhone = New VBNET.HowTo.PhoneTextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtInvalidControls = New System.Windows.Forms.TextBox()
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
        'rexUsZipcode
        '
        Me.rexUsZipcode.AccessibleDescription = CType(resources.GetObject("rexUsZipcode.AccessibleDescription"), String)
        Me.rexUsZipcode.AccessibleName = CType(resources.GetObject("rexUsZipcode.AccessibleName"), String)
        Me.rexUsZipcode.Anchor = CType(resources.GetObject("rexUsZipcode.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.rexUsZipcode.AutoSize = CType(resources.GetObject("rexUsZipcode.AutoSize"), Boolean)
        Me.rexUsZipcode.BackgroundImage = CType(resources.GetObject("rexUsZipcode.BackgroundImage"), System.Drawing.Image)
        Me.rexUsZipcode.Dock = CType(resources.GetObject("rexUsZipcode.Dock"), System.Windows.Forms.DockStyle)
        Me.rexUsZipcode.Enabled = CType(resources.GetObject("rexUsZipcode.Enabled"), Boolean)
        Me.rexUsZipcode.ErrorColor = System.Drawing.Color.Red
        Me.rexUsZipcode.ErrorMessage = "The zip-code must be in the format 55555"
        Me.rexUsZipcode.Font = CType(resources.GetObject("rexUsZipcode.Font"), System.Drawing.Font)
        Me.rexUsZipcode.ImeMode = CType(resources.GetObject("rexUsZipcode.ImeMode"), System.Windows.Forms.ImeMode)
        Me.rexUsZipcode.Location = CType(resources.GetObject("rexUsZipcode.Location"), System.Drawing.Point)
        Me.rexUsZipcode.MaxLength = CType(resources.GetObject("rexUsZipcode.MaxLength"), Integer)
        Me.rexUsZipcode.Multiline = CType(resources.GetObject("rexUsZipcode.Multiline"), Boolean)
        Me.rexUsZipcode.Name = "rexUsZipcode"
        Me.rexUsZipcode.PasswordChar = CType(resources.GetObject("rexUsZipcode.PasswordChar"), Char)
        Me.rexUsZipcode.RightToLeft = CType(resources.GetObject("rexUsZipcode.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.rexUsZipcode.ScrollBars = CType(resources.GetObject("rexUsZipcode.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.rexUsZipcode.Size = CType(resources.GetObject("rexUsZipcode.Size"), System.Drawing.Size)
        Me.rexUsZipcode.TabIndex = CType(resources.GetObject("rexUsZipcode.TabIndex"), Integer)
        Me.rexUsZipcode.Text = resources.GetString("rexUsZipcode.Text")
        Me.rexUsZipcode.TextAlign = CType(resources.GetObject("rexUsZipcode.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.rexUsZipcode.ValidationExpression = "^\d{5}$"
        Me.rexUsZipcode.Visible = CType(resources.GetObject("rexUsZipcode.Visible"), Boolean)
        Me.rexUsZipcode.WordWrap = CType(resources.GetObject("rexUsZipcode.WordWrap"), Boolean)
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
        'rexEmail
        '
        Me.rexEmail.AccessibleDescription = CType(resources.GetObject("rexEmail.AccessibleDescription"), String)
        Me.rexEmail.AccessibleName = CType(resources.GetObject("rexEmail.AccessibleName"), String)
        Me.rexEmail.Anchor = CType(resources.GetObject("rexEmail.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.rexEmail.AutoSize = CType(resources.GetObject("rexEmail.AutoSize"), Boolean)
        Me.rexEmail.BackgroundImage = CType(resources.GetObject("rexEmail.BackgroundImage"), System.Drawing.Image)
        Me.rexEmail.Dock = CType(resources.GetObject("rexEmail.Dock"), System.Windows.Forms.DockStyle)
        Me.rexEmail.Enabled = CType(resources.GetObject("rexEmail.Enabled"), Boolean)
        Me.rexEmail.ErrorColor = System.Drawing.Color.Red
        Me.rexEmail.ErrorMessage = "The e-mail address must be in the form of abc@microsoft.com"
        Me.rexEmail.Font = CType(resources.GetObject("rexEmail.Font"), System.Drawing.Font)
        Me.rexEmail.ImeMode = CType(resources.GetObject("rexEmail.ImeMode"), System.Windows.Forms.ImeMode)
        Me.rexEmail.Location = CType(resources.GetObject("rexEmail.Location"), System.Drawing.Point)
        Me.rexEmail.MaxLength = CType(resources.GetObject("rexEmail.MaxLength"), Integer)
        Me.rexEmail.Multiline = CType(resources.GetObject("rexEmail.Multiline"), Boolean)
        Me.rexEmail.Name = "rexEmail"
        Me.rexEmail.PasswordChar = CType(resources.GetObject("rexEmail.PasswordChar"), Char)
        Me.rexEmail.RightToLeft = CType(resources.GetObject("rexEmail.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.rexEmail.ScrollBars = CType(resources.GetObject("rexEmail.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.rexEmail.Size = CType(resources.GetObject("rexEmail.Size"), System.Drawing.Size)
        Me.rexEmail.TabIndex = CType(resources.GetObject("rexEmail.TabIndex"), Integer)
        Me.rexEmail.Text = resources.GetString("rexEmail.Text")
        Me.rexEmail.TextAlign = CType(resources.GetObject("rexEmail.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.rexEmail.ValidationExpression = "^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0" & _
        "-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-" & _
        "9][0-9]|[1-9][0-9]|[0-9])\])$"
        Me.rexEmail.Visible = CType(resources.GetObject("rexEmail.Visible"), Boolean)
        Me.rexEmail.WordWrap = CType(resources.GetObject("rexEmail.WordWrap"), Boolean)
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
        'rexIpAddress
        '
        Me.rexIpAddress.AccessibleDescription = CType(resources.GetObject("rexIpAddress.AccessibleDescription"), String)
        Me.rexIpAddress.AccessibleName = CType(resources.GetObject("rexIpAddress.AccessibleName"), String)
        Me.rexIpAddress.Anchor = CType(resources.GetObject("rexIpAddress.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.rexIpAddress.AutoSize = CType(resources.GetObject("rexIpAddress.AutoSize"), Boolean)
        Me.rexIpAddress.BackgroundImage = CType(resources.GetObject("rexIpAddress.BackgroundImage"), System.Drawing.Image)
        Me.rexIpAddress.Dock = CType(resources.GetObject("rexIpAddress.Dock"), System.Windows.Forms.DockStyle)
        Me.rexIpAddress.Enabled = CType(resources.GetObject("rexIpAddress.Enabled"), Boolean)
        Me.rexIpAddress.ErrorColor = System.Drawing.Color.Red
        Me.rexIpAddress.ErrorMessage = "The IP address must be in the form of 111.111.111.111"
        Me.rexIpAddress.Font = CType(resources.GetObject("rexIpAddress.Font"), System.Drawing.Font)
        Me.rexIpAddress.ImeMode = CType(resources.GetObject("rexIpAddress.ImeMode"), System.Windows.Forms.ImeMode)
        Me.rexIpAddress.Location = CType(resources.GetObject("rexIpAddress.Location"), System.Drawing.Point)
        Me.rexIpAddress.MaxLength = CType(resources.GetObject("rexIpAddress.MaxLength"), Integer)
        Me.rexIpAddress.Multiline = CType(resources.GetObject("rexIpAddress.Multiline"), Boolean)
        Me.rexIpAddress.Name = "rexIpAddress"
        Me.rexIpAddress.PasswordChar = CType(resources.GetObject("rexIpAddress.PasswordChar"), Char)
        Me.rexIpAddress.RightToLeft = CType(resources.GetObject("rexIpAddress.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.rexIpAddress.ScrollBars = CType(resources.GetObject("rexIpAddress.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.rexIpAddress.Size = CType(resources.GetObject("rexIpAddress.Size"), System.Drawing.Size)
        Me.rexIpAddress.TabIndex = CType(resources.GetObject("rexIpAddress.TabIndex"), Integer)
        Me.rexIpAddress.Text = resources.GetString("rexIpAddress.Text")
        Me.rexIpAddress.TextAlign = CType(resources.GetObject("rexIpAddress.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.rexIpAddress.ValidationExpression = "^((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}(25[0-5]|2[0-4][0-9]|1[" & _
        "0-9][0-9]|[1-9][0-9]|[0-9])$"
        Me.rexIpAddress.Visible = CType(resources.GetObject("rexIpAddress.Visible"), Boolean)
        Me.rexIpAddress.WordWrap = CType(resources.GetObject("rexIpAddress.WordWrap"), Boolean)
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
        'rexSsn
        '
        Me.rexSsn.AccessibleDescription = CType(resources.GetObject("rexSsn.AccessibleDescription"), String)
        Me.rexSsn.AccessibleName = CType(resources.GetObject("rexSsn.AccessibleName"), String)
        Me.rexSsn.Anchor = CType(resources.GetObject("rexSsn.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.rexSsn.AutoSize = CType(resources.GetObject("rexSsn.AutoSize"), Boolean)
        Me.rexSsn.BackgroundImage = CType(resources.GetObject("rexSsn.BackgroundImage"), System.Drawing.Image)
        Me.rexSsn.Dock = CType(resources.GetObject("rexSsn.Dock"), System.Windows.Forms.DockStyle)
        Me.rexSsn.Enabled = CType(resources.GetObject("rexSsn.Enabled"), Boolean)
        Me.rexSsn.ErrorColor = System.Drawing.Color.Red
        Me.rexSsn.ErrorMessage = "The social security number must be in the form of 555-55-5555"
        Me.rexSsn.Font = CType(resources.GetObject("rexSsn.Font"), System.Drawing.Font)
        Me.rexSsn.ImeMode = CType(resources.GetObject("rexSsn.ImeMode"), System.Windows.Forms.ImeMode)
        Me.rexSsn.Location = CType(resources.GetObject("rexSsn.Location"), System.Drawing.Point)
        Me.rexSsn.MaxLength = CType(resources.GetObject("rexSsn.MaxLength"), Integer)
        Me.rexSsn.Multiline = CType(resources.GetObject("rexSsn.Multiline"), Boolean)
        Me.rexSsn.Name = "rexSsn"
        Me.rexSsn.PasswordChar = CType(resources.GetObject("rexSsn.PasswordChar"), Char)
        Me.rexSsn.RightToLeft = CType(resources.GetObject("rexSsn.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.rexSsn.ScrollBars = CType(resources.GetObject("rexSsn.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.rexSsn.Size = CType(resources.GetObject("rexSsn.Size"), System.Drawing.Size)
        Me.rexSsn.TabIndex = CType(resources.GetObject("rexSsn.TabIndex"), Integer)
        Me.rexSsn.Text = resources.GetString("rexSsn.Text")
        Me.rexSsn.TextAlign = CType(resources.GetObject("rexSsn.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.rexSsn.ValidationExpression = "^\d{3}-\d{2}-\d{4}$"
        Me.rexSsn.Visible = CType(resources.GetObject("rexSsn.Visible"), Boolean)
        Me.rexSsn.WordWrap = CType(resources.GetObject("rexSsn.WordWrap"), Boolean)
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
        'rexPhone
        '
        Me.rexPhone.AccessibleDescription = CType(resources.GetObject("rexPhone.AccessibleDescription"), String)
        Me.rexPhone.AccessibleName = CType(resources.GetObject("rexPhone.AccessibleName"), String)
        Me.rexPhone.Anchor = CType(resources.GetObject("rexPhone.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.rexPhone.AutoSize = CType(resources.GetObject("rexPhone.AutoSize"), Boolean)
        Me.rexPhone.BackgroundImage = CType(resources.GetObject("rexPhone.BackgroundImage"), System.Drawing.Image)
        Me.rexPhone.Dock = CType(resources.GetObject("rexPhone.Dock"), System.Windows.Forms.DockStyle)
        Me.rexPhone.Enabled = CType(resources.GetObject("rexPhone.Enabled"), Boolean)
        Me.rexPhone.ErrorColor = System.Drawing.Color.Red
        Me.rexPhone.ErrorMessage = "The phone number must be in the form of (555) 555-1212 or 555-555-1212."
        Me.rexPhone.Font = CType(resources.GetObject("rexPhone.Font"), System.Drawing.Font)
        Me.rexPhone.ImeMode = CType(resources.GetObject("rexPhone.ImeMode"), System.Windows.Forms.ImeMode)
        Me.rexPhone.Location = CType(resources.GetObject("rexPhone.Location"), System.Drawing.Point)
        Me.rexPhone.MaxLength = CType(resources.GetObject("rexPhone.MaxLength"), Integer)
        Me.rexPhone.Multiline = CType(resources.GetObject("rexPhone.Multiline"), Boolean)
        Me.rexPhone.Name = "rexPhone"
        Me.rexPhone.PasswordChar = CType(resources.GetObject("rexPhone.PasswordChar"), Char)
        Me.rexPhone.RightToLeft = CType(resources.GetObject("rexPhone.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.rexPhone.ScrollBars = CType(resources.GetObject("rexPhone.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.rexPhone.Size = CType(resources.GetObject("rexPhone.Size"), System.Drawing.Size)
        Me.rexPhone.TabIndex = CType(resources.GetObject("rexPhone.TabIndex"), Integer)
        Me.rexPhone.Text = resources.GetString("rexPhone.Text")
        Me.rexPhone.TextAlign = CType(resources.GetObject("rexPhone.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.rexPhone.ValidationExpression = "^((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"
        Me.rexPhone.Visible = CType(resources.GetObject("rexPhone.Visible"), Boolean)
        Me.rexPhone.WordWrap = CType(resources.GetObject("rexPhone.WordWrap"), Boolean)
        '
        'Button1
        '
        Me.Button1.AccessibleDescription = CType(resources.GetObject("Button1.AccessibleDescription"), String)
        Me.Button1.AccessibleName = CType(resources.GetObject("Button1.AccessibleName"), String)
        Me.Button1.Anchor = CType(resources.GetObject("Button1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.Dock = CType(resources.GetObject("Button1.Dock"), System.Windows.Forms.DockStyle)
        Me.Button1.Enabled = CType(resources.GetObject("Button1.Enabled"), Boolean)
        Me.Button1.FlatStyle = CType(resources.GetObject("Button1.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.Button1.Font = CType(resources.GetObject("Button1.Font"), System.Drawing.Font)
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = CType(resources.GetObject("Button1.ImageAlign"), System.Drawing.ContentAlignment)
        Me.Button1.ImageIndex = CType(resources.GetObject("Button1.ImageIndex"), Integer)
        Me.Button1.ImeMode = CType(resources.GetObject("Button1.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Button1.Location = CType(resources.GetObject("Button1.Location"), System.Drawing.Point)
        Me.Button1.Name = "Button1"
        Me.Button1.RightToLeft = CType(resources.GetObject("Button1.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Button1.Size = CType(resources.GetObject("Button1.Size"), System.Drawing.Size)
        Me.Button1.TabIndex = CType(resources.GetObject("Button1.TabIndex"), Integer)
        Me.Button1.Text = resources.GetString("Button1.Text")
        Me.Button1.TextAlign = CType(resources.GetObject("Button1.TextAlign"), System.Drawing.ContentAlignment)
        Me.Button1.Visible = CType(resources.GetObject("Button1.Visible"), Boolean)
        '
        'txtInvalidControls
        '
        Me.txtInvalidControls.AccessibleDescription = CType(resources.GetObject("txtInvalidControls.AccessibleDescription"), String)
        Me.txtInvalidControls.AccessibleName = CType(resources.GetObject("txtInvalidControls.AccessibleName"), String)
        Me.txtInvalidControls.Anchor = CType(resources.GetObject("txtInvalidControls.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtInvalidControls.AutoSize = CType(resources.GetObject("txtInvalidControls.AutoSize"), Boolean)
        Me.txtInvalidControls.BackgroundImage = CType(resources.GetObject("txtInvalidControls.BackgroundImage"), System.Drawing.Image)
        Me.txtInvalidControls.Dock = CType(resources.GetObject("txtInvalidControls.Dock"), System.Windows.Forms.DockStyle)
        Me.txtInvalidControls.Enabled = CType(resources.GetObject("txtInvalidControls.Enabled"), Boolean)
        Me.txtInvalidControls.Font = CType(resources.GetObject("txtInvalidControls.Font"), System.Drawing.Font)
        Me.txtInvalidControls.ImeMode = CType(resources.GetObject("txtInvalidControls.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtInvalidControls.Location = CType(resources.GetObject("txtInvalidControls.Location"), System.Drawing.Point)
        Me.txtInvalidControls.MaxLength = CType(resources.GetObject("txtInvalidControls.MaxLength"), Integer)
        Me.txtInvalidControls.Multiline = CType(resources.GetObject("txtInvalidControls.Multiline"), Boolean)
        Me.txtInvalidControls.Name = "txtInvalidControls"
        Me.txtInvalidControls.PasswordChar = CType(resources.GetObject("txtInvalidControls.PasswordChar"), Char)
        Me.txtInvalidControls.ReadOnly = True
        Me.txtInvalidControls.RightToLeft = CType(resources.GetObject("txtInvalidControls.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtInvalidControls.ScrollBars = CType(resources.GetObject("txtInvalidControls.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtInvalidControls.Size = CType(resources.GetObject("txtInvalidControls.Size"), System.Drawing.Size)
        Me.txtInvalidControls.TabIndex = CType(resources.GetObject("txtInvalidControls.TabIndex"), Integer)
        Me.txtInvalidControls.Text = resources.GetString("txtInvalidControls.Text")
        Me.txtInvalidControls.TextAlign = CType(resources.GetObject("txtInvalidControls.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtInvalidControls.Visible = CType(resources.GetObject("txtInvalidControls.Visible"), Boolean)
        Me.txtInvalidControls.WordWrap = CType(resources.GetObject("txtInvalidControls.WordWrap"), Boolean)
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
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtInvalidControls, Me.Button1, Me.rexPhone, Me.Label5, Me.Label4, Me.Label3, Me.Label2, Me.Label1, Me.rexSsn, Me.rexIpAddress, Me.rexEmail, Me.rexUsZipcode})
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


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' Used to loop through all the controls on the form.
        Dim genericControl As Control

        ' Holds the message that will be displayed to the user indicating whether
        ' all the controls contain valid input.
        Dim validationMessage As String

        ' Loop through all the controls on the form.
        For Each genericControl In Controls
            ' If the current control is a RegExTextBox, or inherits RegExTextbox
            If TypeOf genericControl Is RegExTextBox Then
                ' Cast it from a GenericControl type to a RegExTextBox type.  This
                ' will allow you to access the IsValid property
                Dim regExControl As RegExTextBox = CType(genericControl, RegExTextBox)

                ' If the text in the control isn't correct, then add this control
                ' to the list of invalid controls.
                If Not regExControl.IsValid Then
                    validationMessage &= regExControl.Name & ":" & _
                        regExControl.ErrorMessage & vbCrLf
                End If
            End If
        Next

        ' Are there any controls that contain invalid text?
        If validationMessage <> "" Then
            ' Output those controls in the textbox.
            txtInvalidControls.Text = "The following controls have invalid values : " _
                & vbCrLf & validationMessage
        Else
            ' Otherwise, indicate that everything is ok.
            txtInvalidControls.Text = "All controls contain valid input"
        End If

    End Sub
End Class