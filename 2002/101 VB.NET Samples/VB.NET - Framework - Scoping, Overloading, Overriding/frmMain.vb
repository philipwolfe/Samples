'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Public Class frmMain
    Inherits System.Windows.Forms.Form

    Private c_empFull As FullTimeEmployee
    Private c_empPart As PartTimeEmployee
    Private c_empTemp As TempEmployee

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

        txtName.Text = "Carlos Programmer"
        txtHireDate.Text = "7/1/2002"
        txtSalary.Text = "50000"
        txtSocialServicesID.Text = "12345678901"
        txtExpectedTermDate.Text = "10/1/2002"

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
    Friend WithEvents cboEmployeeType As System.Windows.Forms.ComboBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtHireDate As System.Windows.Forms.TextBox
    Friend WithEvents txtSalary As System.Windows.Forms.TextBox
    Friend WithEvents txtSocialServicesID As System.Windows.Forms.TextBox
    Friend WithEvents txtExpectedTermDate As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnHire As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents txtResults As System.Windows.Forms.TextBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.cboEmployeeType = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtHireDate = New System.Windows.Forms.TextBox()
        Me.txtSalary = New System.Windows.Forms.TextBox()
        Me.txtSocialServicesID = New System.Windows.Forms.TextBox()
        Me.txtExpectedTermDate = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnHire = New System.Windows.Forms.Button()
        Me.txtResults = New System.Windows.Forms.TextBox()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
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
        'cboEmployeeType
        '
        Me.cboEmployeeType.AccessibleDescription = resources.GetString("cboEmployeeType.AccessibleDescription")
        Me.cboEmployeeType.AccessibleName = resources.GetString("cboEmployeeType.AccessibleName")
        Me.cboEmployeeType.Anchor = CType(resources.GetObject("cboEmployeeType.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.cboEmployeeType.BackgroundImage = CType(resources.GetObject("cboEmployeeType.BackgroundImage"), System.Drawing.Image)
        Me.cboEmployeeType.Dock = CType(resources.GetObject("cboEmployeeType.Dock"), System.Windows.Forms.DockStyle)
        Me.cboEmployeeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmployeeType.Enabled = CType(resources.GetObject("cboEmployeeType.Enabled"), Boolean)
        Me.cboEmployeeType.Font = CType(resources.GetObject("cboEmployeeType.Font"), System.Drawing.Font)
        Me.cboEmployeeType.ImeMode = CType(resources.GetObject("cboEmployeeType.ImeMode"), System.Windows.Forms.ImeMode)
        Me.cboEmployeeType.IntegralHeight = CType(resources.GetObject("cboEmployeeType.IntegralHeight"), Boolean)
        Me.cboEmployeeType.ItemHeight = CType(resources.GetObject("cboEmployeeType.ItemHeight"), Integer)
        Me.cboEmployeeType.Items.AddRange(New Object() {resources.GetString("cboEmployeeType.Items.Items"), resources.GetString("cboEmployeeType.Items.Items1"), resources.GetString("cboEmployeeType.Items.Items2")})
        Me.cboEmployeeType.Location = CType(resources.GetObject("cboEmployeeType.Location"), System.Drawing.Point)
        Me.cboEmployeeType.MaxDropDownItems = CType(resources.GetObject("cboEmployeeType.MaxDropDownItems"), Integer)
        Me.cboEmployeeType.MaxLength = CType(resources.GetObject("cboEmployeeType.MaxLength"), Integer)
        Me.cboEmployeeType.Name = "cboEmployeeType"
        Me.cboEmployeeType.RightToLeft = CType(resources.GetObject("cboEmployeeType.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.cboEmployeeType.Size = CType(resources.GetObject("cboEmployeeType.Size"), System.Drawing.Size)
        Me.cboEmployeeType.TabIndex = CType(resources.GetObject("cboEmployeeType.TabIndex"), Integer)
        Me.cboEmployeeType.Text = resources.GetString("cboEmployeeType.Text")
        Me.cboEmployeeType.Visible = CType(resources.GetObject("cboEmployeeType.Visible"), Boolean)
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
        'txtName
        '
        Me.txtName.AccessibleDescription = resources.GetString("txtName.AccessibleDescription")
        Me.txtName.AccessibleName = CType(resources.GetObject("txtName.AccessibleName"), String)
        Me.txtName.Anchor = CType(resources.GetObject("txtName.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtName.AutoSize = CType(resources.GetObject("txtName.AutoSize"), Boolean)
        Me.txtName.BackgroundImage = CType(resources.GetObject("txtName.BackgroundImage"), System.Drawing.Image)
        Me.txtName.Dock = CType(resources.GetObject("txtName.Dock"), System.Windows.Forms.DockStyle)
        Me.txtName.Enabled = CType(resources.GetObject("txtName.Enabled"), Boolean)
        Me.txtName.Font = CType(resources.GetObject("txtName.Font"), System.Drawing.Font)
        Me.txtName.ImeMode = CType(resources.GetObject("txtName.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtName.Location = CType(resources.GetObject("txtName.Location"), System.Drawing.Point)
        Me.txtName.MaxLength = CType(resources.GetObject("txtName.MaxLength"), Integer)
        Me.txtName.Multiline = CType(resources.GetObject("txtName.Multiline"), Boolean)
        Me.txtName.Name = "txtName"
        Me.txtName.PasswordChar = CType(resources.GetObject("txtName.PasswordChar"), Char)
        Me.txtName.RightToLeft = CType(resources.GetObject("txtName.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtName.ScrollBars = CType(resources.GetObject("txtName.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtName.Size = CType(resources.GetObject("txtName.Size"), System.Drawing.Size)
        Me.txtName.TabIndex = CType(resources.GetObject("txtName.TabIndex"), Integer)
        Me.txtName.Text = resources.GetString("txtName.Text")
        Me.txtName.TextAlign = CType(resources.GetObject("txtName.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtName.Visible = CType(resources.GetObject("txtName.Visible"), Boolean)
        Me.txtName.WordWrap = CType(resources.GetObject("txtName.WordWrap"), Boolean)
        '
        'txtHireDate
        '
        Me.txtHireDate.AccessibleDescription = resources.GetString("txtHireDate.AccessibleDescription")
        Me.txtHireDate.AccessibleName = resources.GetString("txtHireDate.AccessibleName")
        Me.txtHireDate.Anchor = CType(resources.GetObject("txtHireDate.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtHireDate.AutoSize = CType(resources.GetObject("txtHireDate.AutoSize"), Boolean)
        Me.txtHireDate.BackgroundImage = CType(resources.GetObject("txtHireDate.BackgroundImage"), System.Drawing.Image)
        Me.txtHireDate.Dock = CType(resources.GetObject("txtHireDate.Dock"), System.Windows.Forms.DockStyle)
        Me.txtHireDate.Enabled = CType(resources.GetObject("txtHireDate.Enabled"), Boolean)
        Me.txtHireDate.Font = CType(resources.GetObject("txtHireDate.Font"), System.Drawing.Font)
        Me.txtHireDate.ImeMode = CType(resources.GetObject("txtHireDate.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtHireDate.Location = CType(resources.GetObject("txtHireDate.Location"), System.Drawing.Point)
        Me.txtHireDate.MaxLength = CType(resources.GetObject("txtHireDate.MaxLength"), Integer)
        Me.txtHireDate.Multiline = CType(resources.GetObject("txtHireDate.Multiline"), Boolean)
        Me.txtHireDate.Name = "txtHireDate"
        Me.txtHireDate.PasswordChar = CType(resources.GetObject("txtHireDate.PasswordChar"), Char)
        Me.txtHireDate.RightToLeft = CType(resources.GetObject("txtHireDate.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtHireDate.ScrollBars = CType(resources.GetObject("txtHireDate.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtHireDate.Size = CType(resources.GetObject("txtHireDate.Size"), System.Drawing.Size)
        Me.txtHireDate.TabIndex = CType(resources.GetObject("txtHireDate.TabIndex"), Integer)
        Me.txtHireDate.Text = resources.GetString("txtHireDate.Text")
        Me.txtHireDate.TextAlign = CType(resources.GetObject("txtHireDate.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtHireDate.Visible = CType(resources.GetObject("txtHireDate.Visible"), Boolean)
        Me.txtHireDate.WordWrap = CType(resources.GetObject("txtHireDate.WordWrap"), Boolean)
        '
        'txtSalary
        '
        Me.txtSalary.AccessibleDescription = resources.GetString("txtSalary.AccessibleDescription")
        Me.txtSalary.AccessibleName = resources.GetString("txtSalary.AccessibleName")
        Me.txtSalary.Anchor = CType(resources.GetObject("txtSalary.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtSalary.AutoSize = CType(resources.GetObject("txtSalary.AutoSize"), Boolean)
        Me.txtSalary.BackgroundImage = CType(resources.GetObject("txtSalary.BackgroundImage"), System.Drawing.Image)
        Me.txtSalary.Dock = CType(resources.GetObject("txtSalary.Dock"), System.Windows.Forms.DockStyle)
        Me.txtSalary.Enabled = CType(resources.GetObject("txtSalary.Enabled"), Boolean)
        Me.txtSalary.Font = CType(resources.GetObject("txtSalary.Font"), System.Drawing.Font)
        Me.txtSalary.ImeMode = CType(resources.GetObject("txtSalary.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtSalary.Location = CType(resources.GetObject("txtSalary.Location"), System.Drawing.Point)
        Me.txtSalary.MaxLength = CType(resources.GetObject("txtSalary.MaxLength"), Integer)
        Me.txtSalary.Multiline = CType(resources.GetObject("txtSalary.Multiline"), Boolean)
        Me.txtSalary.Name = "txtSalary"
        Me.txtSalary.PasswordChar = CType(resources.GetObject("txtSalary.PasswordChar"), Char)
        Me.txtSalary.RightToLeft = CType(resources.GetObject("txtSalary.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtSalary.ScrollBars = CType(resources.GetObject("txtSalary.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtSalary.Size = CType(resources.GetObject("txtSalary.Size"), System.Drawing.Size)
        Me.txtSalary.TabIndex = CType(resources.GetObject("txtSalary.TabIndex"), Integer)
        Me.txtSalary.Text = resources.GetString("txtSalary.Text")
        Me.txtSalary.TextAlign = CType(resources.GetObject("txtSalary.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtSalary.Visible = CType(resources.GetObject("txtSalary.Visible"), Boolean)
        Me.txtSalary.WordWrap = CType(resources.GetObject("txtSalary.WordWrap"), Boolean)
        '
        'txtSocialServicesID
        '
        Me.txtSocialServicesID.AccessibleDescription = resources.GetString("txtSocialServicesID.AccessibleDescription")
        Me.txtSocialServicesID.AccessibleName = resources.GetString("txtSocialServicesID.AccessibleName")
        Me.txtSocialServicesID.Anchor = CType(resources.GetObject("txtSocialServicesID.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtSocialServicesID.AutoSize = CType(resources.GetObject("txtSocialServicesID.AutoSize"), Boolean)
        Me.txtSocialServicesID.BackgroundImage = CType(resources.GetObject("txtSocialServicesID.BackgroundImage"), System.Drawing.Image)
        Me.txtSocialServicesID.Dock = CType(resources.GetObject("txtSocialServicesID.Dock"), System.Windows.Forms.DockStyle)
        Me.txtSocialServicesID.Enabled = CType(resources.GetObject("txtSocialServicesID.Enabled"), Boolean)
        Me.txtSocialServicesID.Font = CType(resources.GetObject("txtSocialServicesID.Font"), System.Drawing.Font)
        Me.txtSocialServicesID.ImeMode = CType(resources.GetObject("txtSocialServicesID.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtSocialServicesID.Location = CType(resources.GetObject("txtSocialServicesID.Location"), System.Drawing.Point)
        Me.txtSocialServicesID.MaxLength = CType(resources.GetObject("txtSocialServicesID.MaxLength"), Integer)
        Me.txtSocialServicesID.Multiline = CType(resources.GetObject("txtSocialServicesID.Multiline"), Boolean)
        Me.txtSocialServicesID.Name = "txtSocialServicesID"
        Me.txtSocialServicesID.PasswordChar = CType(resources.GetObject("txtSocialServicesID.PasswordChar"), Char)
        Me.txtSocialServicesID.RightToLeft = CType(resources.GetObject("txtSocialServicesID.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtSocialServicesID.ScrollBars = CType(resources.GetObject("txtSocialServicesID.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtSocialServicesID.Size = CType(resources.GetObject("txtSocialServicesID.Size"), System.Drawing.Size)
        Me.txtSocialServicesID.TabIndex = CType(resources.GetObject("txtSocialServicesID.TabIndex"), Integer)
        Me.txtSocialServicesID.Text = resources.GetString("txtSocialServicesID.Text")
        Me.txtSocialServicesID.TextAlign = CType(resources.GetObject("txtSocialServicesID.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtSocialServicesID.Visible = CType(resources.GetObject("txtSocialServicesID.Visible"), Boolean)
        Me.txtSocialServicesID.WordWrap = CType(resources.GetObject("txtSocialServicesID.WordWrap"), Boolean)
        '
        'txtExpectedTermDate
        '
        Me.txtExpectedTermDate.AccessibleDescription = resources.GetString("txtExpectedTermDate.AccessibleDescription")
        Me.txtExpectedTermDate.AccessibleName = resources.GetString("txtExpectedTermDate.AccessibleName")
        Me.txtExpectedTermDate.Anchor = CType(resources.GetObject("txtExpectedTermDate.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtExpectedTermDate.AutoSize = CType(resources.GetObject("txtExpectedTermDate.AutoSize"), Boolean)
        Me.txtExpectedTermDate.BackgroundImage = CType(resources.GetObject("txtExpectedTermDate.BackgroundImage"), System.Drawing.Image)
        Me.txtExpectedTermDate.Dock = CType(resources.GetObject("txtExpectedTermDate.Dock"), System.Windows.Forms.DockStyle)
        Me.txtExpectedTermDate.Enabled = CType(resources.GetObject("txtExpectedTermDate.Enabled"), Boolean)
        Me.txtExpectedTermDate.Font = CType(resources.GetObject("txtExpectedTermDate.Font"), System.Drawing.Font)
        Me.txtExpectedTermDate.ImeMode = CType(resources.GetObject("txtExpectedTermDate.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtExpectedTermDate.Location = CType(resources.GetObject("txtExpectedTermDate.Location"), System.Drawing.Point)
        Me.txtExpectedTermDate.MaxLength = CType(resources.GetObject("txtExpectedTermDate.MaxLength"), Integer)
        Me.txtExpectedTermDate.Multiline = CType(resources.GetObject("txtExpectedTermDate.Multiline"), Boolean)
        Me.txtExpectedTermDate.Name = "txtExpectedTermDate"
        Me.txtExpectedTermDate.PasswordChar = CType(resources.GetObject("txtExpectedTermDate.PasswordChar"), Char)
        Me.txtExpectedTermDate.RightToLeft = CType(resources.GetObject("txtExpectedTermDate.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtExpectedTermDate.ScrollBars = CType(resources.GetObject("txtExpectedTermDate.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtExpectedTermDate.Size = CType(resources.GetObject("txtExpectedTermDate.Size"), System.Drawing.Size)
        Me.txtExpectedTermDate.TabIndex = CType(resources.GetObject("txtExpectedTermDate.TabIndex"), Integer)
        Me.txtExpectedTermDate.Text = resources.GetString("txtExpectedTermDate.Text")
        Me.txtExpectedTermDate.TextAlign = CType(resources.GetObject("txtExpectedTermDate.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtExpectedTermDate.Visible = CType(resources.GetObject("txtExpectedTermDate.Visible"), Boolean)
        Me.txtExpectedTermDate.WordWrap = CType(resources.GetObject("txtExpectedTermDate.WordWrap"), Boolean)
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
        'btnHire
        '
        Me.btnHire.AccessibleDescription = resources.GetString("btnHire.AccessibleDescription")
        Me.btnHire.AccessibleName = resources.GetString("btnHire.AccessibleName")
        Me.btnHire.Anchor = CType(resources.GetObject("btnHire.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnHire.BackgroundImage = CType(resources.GetObject("btnHire.BackgroundImage"), System.Drawing.Image)
        Me.btnHire.Dock = CType(resources.GetObject("btnHire.Dock"), System.Windows.Forms.DockStyle)
        Me.btnHire.Enabled = CType(resources.GetObject("btnHire.Enabled"), Boolean)
        Me.btnHire.FlatStyle = CType(resources.GetObject("btnHire.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnHire.Font = CType(resources.GetObject("btnHire.Font"), System.Drawing.Font)
        Me.btnHire.Image = CType(resources.GetObject("btnHire.Image"), System.Drawing.Image)
        Me.btnHire.ImageAlign = CType(resources.GetObject("btnHire.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnHire.ImageIndex = CType(resources.GetObject("btnHire.ImageIndex"), Integer)
        Me.btnHire.ImeMode = CType(resources.GetObject("btnHire.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnHire.Location = CType(resources.GetObject("btnHire.Location"), System.Drawing.Point)
        Me.btnHire.Name = "btnHire"
        Me.btnHire.RightToLeft = CType(resources.GetObject("btnHire.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnHire.Size = CType(resources.GetObject("btnHire.Size"), System.Drawing.Size)
        Me.btnHire.TabIndex = CType(resources.GetObject("btnHire.TabIndex"), Integer)
        Me.btnHire.Text = resources.GetString("btnHire.Text")
        Me.btnHire.TextAlign = CType(resources.GetObject("btnHire.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnHire.Visible = CType(resources.GetObject("btnHire.Visible"), Boolean)
        '
        'txtResults
        '
        Me.txtResults.AccessibleDescription = resources.GetString("txtResults.AccessibleDescription")
        Me.txtResults.AccessibleName = resources.GetString("txtResults.AccessibleName")
        Me.txtResults.Anchor = CType(resources.GetObject("txtResults.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtResults.AutoSize = CType(resources.GetObject("txtResults.AutoSize"), Boolean)
        Me.txtResults.BackColor = System.Drawing.SystemColors.Menu
        Me.txtResults.BackgroundImage = CType(resources.GetObject("txtResults.BackgroundImage"), System.Drawing.Image)
        Me.txtResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtResults.Dock = CType(resources.GetObject("txtResults.Dock"), System.Windows.Forms.DockStyle)
        Me.txtResults.Enabled = CType(resources.GetObject("txtResults.Enabled"), Boolean)
        Me.txtResults.Font = CType(resources.GetObject("txtResults.Font"), System.Drawing.Font)
        Me.txtResults.ImeMode = CType(resources.GetObject("txtResults.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtResults.Location = CType(resources.GetObject("txtResults.Location"), System.Drawing.Point)
        Me.txtResults.MaxLength = CType(resources.GetObject("txtResults.MaxLength"), Integer)
        Me.txtResults.Multiline = CType(resources.GetObject("txtResults.Multiline"), Boolean)
        Me.txtResults.Name = "txtResults"
        Me.txtResults.PasswordChar = CType(resources.GetObject("txtResults.PasswordChar"), Char)
        Me.txtResults.ReadOnly = True
        Me.txtResults.RightToLeft = CType(resources.GetObject("txtResults.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtResults.ScrollBars = CType(resources.GetObject("txtResults.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtResults.Size = CType(resources.GetObject("txtResults.Size"), System.Drawing.Size)
        Me.txtResults.TabIndex = CType(resources.GetObject("txtResults.TabIndex"), Integer)
        Me.txtResults.Text = resources.GetString("txtResults.Text")
        Me.txtResults.TextAlign = CType(resources.GetObject("txtResults.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtResults.Visible = CType(resources.GetObject("txtResults.Visible"), Boolean)
        Me.txtResults.WordWrap = CType(resources.GetObject("txtResults.WordWrap"), Boolean)
        '
        'btnClear
        '
        Me.btnClear.AccessibleDescription = resources.GetString("btnClear.AccessibleDescription")
        Me.btnClear.AccessibleName = resources.GetString("btnClear.AccessibleName")
        Me.btnClear.Anchor = CType(resources.GetObject("btnClear.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnClear.BackgroundImage = CType(resources.GetObject("btnClear.BackgroundImage"), System.Drawing.Image)
        Me.btnClear.Dock = CType(resources.GetObject("btnClear.Dock"), System.Windows.Forms.DockStyle)
        Me.btnClear.Enabled = CType(resources.GetObject("btnClear.Enabled"), Boolean)
        Me.btnClear.FlatStyle = CType(resources.GetObject("btnClear.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnClear.Font = CType(resources.GetObject("btnClear.Font"), System.Drawing.Font)
        Me.btnClear.Image = CType(resources.GetObject("btnClear.Image"), System.Drawing.Image)
        Me.btnClear.ImageAlign = CType(resources.GetObject("btnClear.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnClear.ImageIndex = CType(resources.GetObject("btnClear.ImageIndex"), Integer)
        Me.btnClear.ImeMode = CType(resources.GetObject("btnClear.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnClear.Location = CType(resources.GetObject("btnClear.Location"), System.Drawing.Point)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.RightToLeft = CType(resources.GetObject("btnClear.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnClear.Size = CType(resources.GetObject("btnClear.Size"), System.Drawing.Size)
        Me.btnClear.TabIndex = CType(resources.GetObject("btnClear.TabIndex"), Integer)
        Me.btnClear.Text = resources.GetString("btnClear.Text")
        Me.btnClear.TextAlign = CType(resources.GetObject("btnClear.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnClear.Visible = CType(resources.GetObject("btnClear.Visible"), Boolean)
        '
        'btnSave
        '
        Me.btnSave.AccessibleDescription = resources.GetString("btnSave.AccessibleDescription")
        Me.btnSave.AccessibleName = resources.GetString("btnSave.AccessibleName")
        Me.btnSave.Anchor = CType(resources.GetObject("btnSave.Anchor"), System.Windows.Forms.AnchorStyles)
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
        'Label7
        '
        Me.Label7.AccessibleDescription = resources.GetString("Label7.AccessibleDescription")
        Me.Label7.AccessibleName = resources.GetString("Label7.AccessibleName")
        Me.Label7.Anchor = CType(resources.GetObject("Label7.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = CType(resources.GetObject("Label7.AutoSize"), Boolean)
        Me.Label7.Dock = CType(resources.GetObject("Label7.Dock"), System.Windows.Forms.DockStyle)
        Me.Label7.Enabled = CType(resources.GetObject("Label7.Enabled"), Boolean)
        Me.Label7.Font = CType(resources.GetObject("Label7.Font"), System.Drawing.Font)
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
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label7, Me.btnSave, Me.btnClear, Me.txtResults, Me.btnHire, Me.Label6, Me.Label5, Me.Label4, Me.Label3, Me.Label2, Me.txtExpectedTermDate, Me.txtSocialServicesID, Me.txtSalary, Me.txtHireDate, Me.txtName, Me.Label1, Me.cboEmployeeType})
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

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Dim ctl As Control
        cboEmployeeType.SelectedIndex = -1
        For Each ctl In Me.Controls
            If TypeOf ctl Is TextBox Then
                ctl.Text = vbNullString
            End If
        Next
    End Sub

    Private Sub btnHire_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHire.Click
        If Not ValidateData() Then
            Return
        End If
        Select Case cboEmployeeType.SelectedIndex
            Case -1
                Exit Sub
            Case 0
                HireFullTimeEmployee()
            Case 1
                HirePartTimeEmployee()
            Case 2
                HireTempEmployee()
        End Select
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim strResult As String

        ' These simulated save-to-database actions use a shared method
        ' of the EmployeeDataManager class.
        Select Case cboEmployeeType.SelectedIndex
            Case -1
                Exit Sub
            Case 0
                strResult = EmployeeDataManager.WriteEmployeeData(c_empFull)
            Case 1
                strResult = EmployeeDataManager.WriteEmployeeData(c_empPart)
            Case 2
                strResult = EmployeeDataManager.WriteEmployeeData(c_empTemp)
        End Select
        MsgBox(strResult, MsgBoxStyle.Information, Me.Text)
    End Sub

    ' This procedure watches for changes in the textboxes and the
    ' combobox, and enables the Hire button only when the textboxes all
    ' have data.
    Private Sub TextBoxes_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.TextChanged, txtHireDate.TextChanged, txtSalary.TextChanged, txtSocialServicesID.TextChanged, txtExpectedTermDate.TextChanged, cboEmployeeType.SelectedIndexChanged
        Select Case cboEmployeeType.SelectedIndex
            Case -1
                'btnHire.Enabled = False
                txtName.Enabled = False
                txtHireDate.Enabled = False
                txtSalary.Enabled = False
                txtSocialServicesID.Enabled = False
                txtExpectedTermDate.Enabled = False
            Case 0, 1
                'btnHire.Enabled = True
                txtName.Enabled = True
                txtHireDate.Enabled = True
                txtSalary.Enabled = True
                txtSocialServicesID.Enabled = True
                txtExpectedTermDate.Enabled = False
            Case 2
                'btnHire.Enabled = True
                txtName.Enabled = True
                txtHireDate.Enabled = True
                txtSalary.Enabled = True
                txtSocialServicesID.Enabled = True
                txtExpectedTermDate.Enabled = True
        End Select

        btnHire.Enabled = _
            txtName.Text.Trim.Length <> 0 And _
            txtHireDate.Text.Trim.Length <> 0 And _
            txtSalary.Text.Trim.Length <> 0 And _
            txtSocialServicesID.Text.Trim.Length <> 0 And _
            cboEmployeeType.SelectedIndex >= 0

        ' If Temp Employee is chosen, test for text in the ExpectedTermDate text box.
        If cboEmployeeType.SelectedIndex = 2 Then
            btnHire.Enabled = btnHire.Enabled And txtExpectedTermDate.Text.Trim.Length <> 0
        End If
        btnSave.Enabled = False
    End Sub

    Private Sub HireFullTimeEmployee()
        c_empFull = New FullTimeEmployee()
        Try
            With c_empFull
                .Hire(txtName.Text.Trim, CType(txtHireDate.Text.Trim, DateTime), _
                    CType(txtSalary.Text.Trim, Decimal))
                .SocialServicesID = txtSocialServicesID.Text.Trim
                txtResults.Clear()
                txtResults.Text &= "Name: " & .Name & vbCrLf & _
                    "Hire date: " & .HireDate & vbCrLf & _
                    "Salary: " & .Salary & vbCrLf & _
                    "Social Services ID: " & .SocialServicesID & vbCrLf & _
                    "Bonus: " & .Bonus & vbCrLf & _
                    "Annual Leave: " & .AnnualLeave & " days"
            End With
            btnSave.Enabled = True
        Catch exp As Exception
            MsgBox(exp.ToString(), MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub HirePartTimeEmployee()
        c_empPart = New PartTimeEmployee()
        Try
            With c_empPart
                .Hire(txtName.Text.Trim, CType(txtHireDate.Text.Trim, DateTime), _
                    CType(txtSalary.Text.Trim, Decimal), 20)
                .SocialServicesID = txtSocialServicesID.Text.Trim
                txtResults.Clear()
                txtResults.Text &= "Name: " & .Name & vbCrLf & _
                    "Hire date: " & .HireDate & vbCrLf & _
                    "Salary: " & .Salary & vbCrLf & _
                    "Social Services ID: " & .SocialServicesID & vbCrLf & _
                    "Bonus: " & .Bonus & vbCrLf & _
                    "Min hrs. per week: " & .MinHoursPerWeek
            End With
            btnSave.Enabled = True
        Catch exp As Exception
            MsgBox(exp.ToString(), MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub HireTempEmployee()
        Dim c_empTemp As New TempEmployee()
        Try
            With c_empTemp
                .Hire(txtName.Text.Trim, CType(txtHireDate.Text.Trim, DateTime), _
                    CType(txtSalary.Text.Trim, Decimal), CType(txtExpectedTermDate.Text.Trim, DateTime))
                .SocialServicesID = txtSocialServicesID.Text.Trim
                txtResults.Clear()
                txtResults.Text &= "Name: " & .Name & vbCrLf & _
                    "Hire date: " & .HireDate & vbCrLf & _
                    "Salary: " & .Salary & vbCrLf & _
                    "Social Services ID: " & .SocialServicesID & vbCrLf & _
                    "Bonus: " & .Bonus & vbCrLf & _
                    "Expected termination date: " & .ExpectedTermDate.ToShortDateString
            End With
            btnSave.Enabled = True
        Catch exp As Exception
            MsgBox(exp.ToString(), MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Function ValidateData() As Boolean

        Dim dataInValid As Boolean = True

        If Not IsDate(txtHireDate.Text) Then
            MsgBox("Hire Date must be a date in the format MM/DD/YY.", _
                MsgBoxStyle.Exclamation, Me.Text)
            dataInValid = False
        End If

        If txtSocialServicesID.Text.Length <> 11 Then
            MsgBox("Social Services ID must be 11 characters in length", _
             MsgBoxStyle.Exclamation, Me.Text)
            dataInValid = False
        End If

        Return (dataInValid)

    End Function

End Class
