'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Imports System.Drawing.Drawing2D

Public Class frmMain
    Inherits System.Windows.Forms.Form

    ' The necessary class variables are declared here
    Dim m_Pen As New Pen(Color.Black)
    Dim m_penColor As Color = Color.BurlyWood
    Dim m_penBrush As Brush = New SolidBrush(Color.Black)
    Dim m_BlackThinPen As New Pen(Color.Black)

    Dim graphic As Graphics


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
    Friend WithEvents btnSetColor As System.Windows.Forms.Button
    Friend WithEvents txtColor As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents pbLines As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents comboShape As System.Windows.Forms.ComboBox
    Friend WithEvents updownWidth As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents comboStartCap As System.Windows.Forms.ComboBox
    Friend WithEvents comboEndCap As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents comboDashCap As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents comboLineJoin As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents comboLineStyle As System.Windows.Forms.ComboBox
    Friend WithEvents comboAlignment As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents radioBrush As System.Windows.Forms.RadioButton
    Friend WithEvents radioColor As System.Windows.Forms.RadioButton
    Friend WithEvents comboBrush As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents updownMiterLimit As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents comboTransform As System.Windows.Forms.ComboBox
    Friend WithEvents btnCycle As System.Windows.Forms.Button
    Friend WithEvents timerCycle As System.Windows.Forms.Timer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.comboAlignment = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtColor = New System.Windows.Forms.TextBox()
        Me.btnSetColor = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pbLines = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.comboShape = New System.Windows.Forms.ComboBox()
        Me.updownWidth = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.comboStartCap = New System.Windows.Forms.ComboBox()
        Me.comboEndCap = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.comboDashCap = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.comboLineJoin = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.comboLineStyle = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.comboBrush = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.radioBrush = New System.Windows.Forms.RadioButton()
        Me.radioColor = New System.Windows.Forms.RadioButton()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.updownMiterLimit = New System.Windows.Forms.NumericUpDown()
        Me.comboTransform = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnCycle = New System.Windows.Forms.Button()
        Me.timerCycle = New System.Windows.Forms.Timer(Me.components)
        CType(Me.updownWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.updownMiterLimit, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'comboAlignment
        '
        Me.comboAlignment.AccessibleDescription = resources.GetString("comboAlignment.AccessibleDescription")
        Me.comboAlignment.AccessibleName = resources.GetString("comboAlignment.AccessibleName")
        Me.comboAlignment.Anchor = CType(resources.GetObject("comboAlignment.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.comboAlignment.BackgroundImage = CType(resources.GetObject("comboAlignment.BackgroundImage"), System.Drawing.Image)
        Me.comboAlignment.Dock = CType(resources.GetObject("comboAlignment.Dock"), System.Windows.Forms.DockStyle)
        Me.comboAlignment.Enabled = CType(resources.GetObject("comboAlignment.Enabled"), Boolean)
        Me.comboAlignment.Font = CType(resources.GetObject("comboAlignment.Font"), System.Drawing.Font)
        Me.comboAlignment.ImeMode = CType(resources.GetObject("comboAlignment.ImeMode"), System.Windows.Forms.ImeMode)
        Me.comboAlignment.IntegralHeight = CType(resources.GetObject("comboAlignment.IntegralHeight"), Boolean)
        Me.comboAlignment.ItemHeight = CType(resources.GetObject("comboAlignment.ItemHeight"), Integer)
        Me.comboAlignment.Location = CType(resources.GetObject("comboAlignment.Location"), System.Drawing.Point)
        Me.comboAlignment.MaxDropDownItems = CType(resources.GetObject("comboAlignment.MaxDropDownItems"), Integer)
        Me.comboAlignment.MaxLength = CType(resources.GetObject("comboAlignment.MaxLength"), Integer)
        Me.comboAlignment.Name = "comboAlignment"
        Me.comboAlignment.RightToLeft = CType(resources.GetObject("comboAlignment.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.comboAlignment.Size = CType(resources.GetObject("comboAlignment.Size"), System.Drawing.Size)
        Me.comboAlignment.TabIndex = CType(resources.GetObject("comboAlignment.TabIndex"), Integer)
        Me.comboAlignment.Text = resources.GetString("comboAlignment.Text")
        Me.comboAlignment.Visible = CType(resources.GetObject("comboAlignment.Visible"), Boolean)
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
        'txtColor
        '
        Me.txtColor.AccessibleDescription = resources.GetString("txtColor.AccessibleDescription")
        Me.txtColor.AccessibleName = resources.GetString("txtColor.AccessibleName")
        Me.txtColor.Anchor = CType(resources.GetObject("txtColor.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtColor.AutoSize = CType(resources.GetObject("txtColor.AutoSize"), Boolean)
        Me.txtColor.BackgroundImage = CType(resources.GetObject("txtColor.BackgroundImage"), System.Drawing.Image)
        Me.txtColor.Dock = CType(resources.GetObject("txtColor.Dock"), System.Windows.Forms.DockStyle)
        Me.txtColor.Enabled = CType(resources.GetObject("txtColor.Enabled"), Boolean)
        Me.txtColor.Font = CType(resources.GetObject("txtColor.Font"), System.Drawing.Font)
        Me.txtColor.ImeMode = CType(resources.GetObject("txtColor.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtColor.Location = CType(resources.GetObject("txtColor.Location"), System.Drawing.Point)
        Me.txtColor.MaxLength = CType(resources.GetObject("txtColor.MaxLength"), Integer)
        Me.txtColor.Multiline = CType(resources.GetObject("txtColor.Multiline"), Boolean)
        Me.txtColor.Name = "txtColor"
        Me.txtColor.PasswordChar = CType(resources.GetObject("txtColor.PasswordChar"), Char)
        Me.txtColor.RightToLeft = CType(resources.GetObject("txtColor.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtColor.ScrollBars = CType(resources.GetObject("txtColor.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtColor.Size = CType(resources.GetObject("txtColor.Size"), System.Drawing.Size)
        Me.txtColor.TabIndex = CType(resources.GetObject("txtColor.TabIndex"), Integer)
        Me.txtColor.Text = resources.GetString("txtColor.Text")
        Me.txtColor.TextAlign = CType(resources.GetObject("txtColor.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtColor.Visible = CType(resources.GetObject("txtColor.Visible"), Boolean)
        Me.txtColor.WordWrap = CType(resources.GetObject("txtColor.WordWrap"), Boolean)
        '
        'btnSetColor
        '
        Me.btnSetColor.AccessibleDescription = resources.GetString("btnSetColor.AccessibleDescription")
        Me.btnSetColor.AccessibleName = resources.GetString("btnSetColor.AccessibleName")
        Me.btnSetColor.Anchor = CType(resources.GetObject("btnSetColor.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnSetColor.BackgroundImage = CType(resources.GetObject("btnSetColor.BackgroundImage"), System.Drawing.Image)
        Me.btnSetColor.Dock = CType(resources.GetObject("btnSetColor.Dock"), System.Windows.Forms.DockStyle)
        Me.btnSetColor.Enabled = CType(resources.GetObject("btnSetColor.Enabled"), Boolean)
        Me.btnSetColor.FlatStyle = CType(resources.GetObject("btnSetColor.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnSetColor.Font = CType(resources.GetObject("btnSetColor.Font"), System.Drawing.Font)
        Me.btnSetColor.Image = CType(resources.GetObject("btnSetColor.Image"), System.Drawing.Image)
        Me.btnSetColor.ImageAlign = CType(resources.GetObject("btnSetColor.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnSetColor.ImageIndex = CType(resources.GetObject("btnSetColor.ImageIndex"), Integer)
        Me.btnSetColor.ImeMode = CType(resources.GetObject("btnSetColor.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnSetColor.Location = CType(resources.GetObject("btnSetColor.Location"), System.Drawing.Point)
        Me.btnSetColor.Name = "btnSetColor"
        Me.btnSetColor.RightToLeft = CType(resources.GetObject("btnSetColor.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnSetColor.Size = CType(resources.GetObject("btnSetColor.Size"), System.Drawing.Size)
        Me.btnSetColor.TabIndex = CType(resources.GetObject("btnSetColor.TabIndex"), Integer)
        Me.btnSetColor.Text = resources.GetString("btnSetColor.Text")
        Me.btnSetColor.TextAlign = CType(resources.GetObject("btnSetColor.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnSetColor.Visible = CType(resources.GetObject("btnSetColor.Visible"), Boolean)
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
        'pbLines
        '
        Me.pbLines.AccessibleDescription = resources.GetString("pbLines.AccessibleDescription")
        Me.pbLines.AccessibleName = resources.GetString("pbLines.AccessibleName")
        Me.pbLines.Anchor = CType(resources.GetObject("pbLines.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.pbLines.BackgroundImage = CType(resources.GetObject("pbLines.BackgroundImage"), System.Drawing.Image)
        Me.pbLines.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbLines.Dock = CType(resources.GetObject("pbLines.Dock"), System.Windows.Forms.DockStyle)
        Me.pbLines.Enabled = CType(resources.GetObject("pbLines.Enabled"), Boolean)
        Me.pbLines.Font = CType(resources.GetObject("pbLines.Font"), System.Drawing.Font)
        Me.pbLines.Image = CType(resources.GetObject("pbLines.Image"), System.Drawing.Image)
        Me.pbLines.ImeMode = CType(resources.GetObject("pbLines.ImeMode"), System.Windows.Forms.ImeMode)
        Me.pbLines.Location = CType(resources.GetObject("pbLines.Location"), System.Drawing.Point)
        Me.pbLines.Name = "pbLines"
        Me.pbLines.RightToLeft = CType(resources.GetObject("pbLines.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.pbLines.Size = CType(resources.GetObject("pbLines.Size"), System.Drawing.Size)
        Me.pbLines.SizeMode = CType(resources.GetObject("pbLines.SizeMode"), System.Windows.Forms.PictureBoxSizeMode)
        Me.pbLines.TabIndex = CType(resources.GetObject("pbLines.TabIndex"), Integer)
        Me.pbLines.TabStop = False
        Me.pbLines.Text = resources.GetString("pbLines.Text")
        Me.pbLines.Visible = CType(resources.GetObject("pbLines.Visible"), Boolean)
        '
        'Label5
        '
        Me.Label5.AccessibleDescription = resources.GetString("Label5.AccessibleDescription")
        Me.Label5.AccessibleName = resources.GetString("Label5.AccessibleName")
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
        'comboShape
        '
        Me.comboShape.AccessibleDescription = resources.GetString("comboShape.AccessibleDescription")
        Me.comboShape.AccessibleName = resources.GetString("comboShape.AccessibleName")
        Me.comboShape.Anchor = CType(resources.GetObject("comboShape.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.comboShape.BackgroundImage = CType(resources.GetObject("comboShape.BackgroundImage"), System.Drawing.Image)
        Me.comboShape.Dock = CType(resources.GetObject("comboShape.Dock"), System.Windows.Forms.DockStyle)
        Me.comboShape.Enabled = CType(resources.GetObject("comboShape.Enabled"), Boolean)
        Me.comboShape.Font = CType(resources.GetObject("comboShape.Font"), System.Drawing.Font)
        Me.comboShape.ImeMode = CType(resources.GetObject("comboShape.ImeMode"), System.Windows.Forms.ImeMode)
        Me.comboShape.IntegralHeight = CType(resources.GetObject("comboShape.IntegralHeight"), Boolean)
        Me.comboShape.ItemHeight = CType(resources.GetObject("comboShape.ItemHeight"), Integer)
        Me.comboShape.Items.AddRange(New Object() {resources.GetString("comboShape.Items.Items"), resources.GetString("comboShape.Items.Items1"), resources.GetString("comboShape.Items.Items2")})
        Me.comboShape.Location = CType(resources.GetObject("comboShape.Location"), System.Drawing.Point)
        Me.comboShape.MaxDropDownItems = CType(resources.GetObject("comboShape.MaxDropDownItems"), Integer)
        Me.comboShape.MaxLength = CType(resources.GetObject("comboShape.MaxLength"), Integer)
        Me.comboShape.Name = "comboShape"
        Me.comboShape.RightToLeft = CType(resources.GetObject("comboShape.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.comboShape.Size = CType(resources.GetObject("comboShape.Size"), System.Drawing.Size)
        Me.comboShape.TabIndex = CType(resources.GetObject("comboShape.TabIndex"), Integer)
        Me.comboShape.Text = resources.GetString("comboShape.Text")
        Me.comboShape.Visible = CType(resources.GetObject("comboShape.Visible"), Boolean)
        '
        'updownWidth
        '
        Me.updownWidth.AccessibleDescription = resources.GetString("updownWidth.AccessibleDescription")
        Me.updownWidth.AccessibleName = resources.GetString("updownWidth.AccessibleName")
        Me.updownWidth.Anchor = CType(resources.GetObject("updownWidth.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.updownWidth.Dock = CType(resources.GetObject("updownWidth.Dock"), System.Windows.Forms.DockStyle)
        Me.updownWidth.Enabled = CType(resources.GetObject("updownWidth.Enabled"), Boolean)
        Me.updownWidth.Font = CType(resources.GetObject("updownWidth.Font"), System.Drawing.Font)
        Me.updownWidth.ImeMode = CType(resources.GetObject("updownWidth.ImeMode"), System.Windows.Forms.ImeMode)
        Me.updownWidth.Location = CType(resources.GetObject("updownWidth.Location"), System.Drawing.Point)
        Me.updownWidth.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.updownWidth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.updownWidth.Name = "updownWidth"
        Me.updownWidth.RightToLeft = CType(resources.GetObject("updownWidth.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.updownWidth.Size = CType(resources.GetObject("updownWidth.Size"), System.Drawing.Size)
        Me.updownWidth.TabIndex = CType(resources.GetObject("updownWidth.TabIndex"), Integer)
        Me.updownWidth.TextAlign = CType(resources.GetObject("updownWidth.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.updownWidth.ThousandsSeparator = CType(resources.GetObject("updownWidth.ThousandsSeparator"), Boolean)
        Me.updownWidth.UpDownAlign = CType(resources.GetObject("updownWidth.UpDownAlign"), System.Windows.Forms.LeftRightAlignment)
        Me.updownWidth.Value = New Decimal(New Integer() {25, 0, 0, 0})
        Me.updownWidth.Visible = CType(resources.GetObject("updownWidth.Visible"), Boolean)
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
        'comboStartCap
        '
        Me.comboStartCap.AccessibleDescription = resources.GetString("comboStartCap.AccessibleDescription")
        Me.comboStartCap.AccessibleName = resources.GetString("comboStartCap.AccessibleName")
        Me.comboStartCap.Anchor = CType(resources.GetObject("comboStartCap.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.comboStartCap.BackgroundImage = CType(resources.GetObject("comboStartCap.BackgroundImage"), System.Drawing.Image)
        Me.comboStartCap.Dock = CType(resources.GetObject("comboStartCap.Dock"), System.Windows.Forms.DockStyle)
        Me.comboStartCap.Enabled = CType(resources.GetObject("comboStartCap.Enabled"), Boolean)
        Me.comboStartCap.Font = CType(resources.GetObject("comboStartCap.Font"), System.Drawing.Font)
        Me.comboStartCap.ImeMode = CType(resources.GetObject("comboStartCap.ImeMode"), System.Windows.Forms.ImeMode)
        Me.comboStartCap.IntegralHeight = CType(resources.GetObject("comboStartCap.IntegralHeight"), Boolean)
        Me.comboStartCap.ItemHeight = CType(resources.GetObject("comboStartCap.ItemHeight"), Integer)
        Me.comboStartCap.Location = CType(resources.GetObject("comboStartCap.Location"), System.Drawing.Point)
        Me.comboStartCap.MaxDropDownItems = CType(resources.GetObject("comboStartCap.MaxDropDownItems"), Integer)
        Me.comboStartCap.MaxLength = CType(resources.GetObject("comboStartCap.MaxLength"), Integer)
        Me.comboStartCap.Name = "comboStartCap"
        Me.comboStartCap.RightToLeft = CType(resources.GetObject("comboStartCap.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.comboStartCap.Size = CType(resources.GetObject("comboStartCap.Size"), System.Drawing.Size)
        Me.comboStartCap.TabIndex = CType(resources.GetObject("comboStartCap.TabIndex"), Integer)
        Me.comboStartCap.Text = resources.GetString("comboStartCap.Text")
        Me.comboStartCap.Visible = CType(resources.GetObject("comboStartCap.Visible"), Boolean)
        '
        'comboEndCap
        '
        Me.comboEndCap.AccessibleDescription = resources.GetString("comboEndCap.AccessibleDescription")
        Me.comboEndCap.AccessibleName = resources.GetString("comboEndCap.AccessibleName")
        Me.comboEndCap.Anchor = CType(resources.GetObject("comboEndCap.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.comboEndCap.BackgroundImage = CType(resources.GetObject("comboEndCap.BackgroundImage"), System.Drawing.Image)
        Me.comboEndCap.Dock = CType(resources.GetObject("comboEndCap.Dock"), System.Windows.Forms.DockStyle)
        Me.comboEndCap.Enabled = CType(resources.GetObject("comboEndCap.Enabled"), Boolean)
        Me.comboEndCap.Font = CType(resources.GetObject("comboEndCap.Font"), System.Drawing.Font)
        Me.comboEndCap.ImeMode = CType(resources.GetObject("comboEndCap.ImeMode"), System.Windows.Forms.ImeMode)
        Me.comboEndCap.IntegralHeight = CType(resources.GetObject("comboEndCap.IntegralHeight"), Boolean)
        Me.comboEndCap.ItemHeight = CType(resources.GetObject("comboEndCap.ItemHeight"), Integer)
        Me.comboEndCap.Location = CType(resources.GetObject("comboEndCap.Location"), System.Drawing.Point)
        Me.comboEndCap.MaxDropDownItems = CType(resources.GetObject("comboEndCap.MaxDropDownItems"), Integer)
        Me.comboEndCap.MaxLength = CType(resources.GetObject("comboEndCap.MaxLength"), Integer)
        Me.comboEndCap.Name = "comboEndCap"
        Me.comboEndCap.RightToLeft = CType(resources.GetObject("comboEndCap.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.comboEndCap.Size = CType(resources.GetObject("comboEndCap.Size"), System.Drawing.Size)
        Me.comboEndCap.TabIndex = CType(resources.GetObject("comboEndCap.TabIndex"), Integer)
        Me.comboEndCap.Text = resources.GetString("comboEndCap.Text")
        Me.comboEndCap.Visible = CType(resources.GetObject("comboEndCap.Visible"), Boolean)
        '
        'Label6
        '
        Me.Label6.AccessibleDescription = resources.GetString("Label6.AccessibleDescription")
        Me.Label6.AccessibleName = resources.GetString("Label6.AccessibleName")
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
        'comboDashCap
        '
        Me.comboDashCap.AccessibleDescription = resources.GetString("comboDashCap.AccessibleDescription")
        Me.comboDashCap.AccessibleName = resources.GetString("comboDashCap.AccessibleName")
        Me.comboDashCap.Anchor = CType(resources.GetObject("comboDashCap.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.comboDashCap.BackgroundImage = CType(resources.GetObject("comboDashCap.BackgroundImage"), System.Drawing.Image)
        Me.comboDashCap.Dock = CType(resources.GetObject("comboDashCap.Dock"), System.Windows.Forms.DockStyle)
        Me.comboDashCap.Enabled = CType(resources.GetObject("comboDashCap.Enabled"), Boolean)
        Me.comboDashCap.Font = CType(resources.GetObject("comboDashCap.Font"), System.Drawing.Font)
        Me.comboDashCap.ImeMode = CType(resources.GetObject("comboDashCap.ImeMode"), System.Windows.Forms.ImeMode)
        Me.comboDashCap.IntegralHeight = CType(resources.GetObject("comboDashCap.IntegralHeight"), Boolean)
        Me.comboDashCap.ItemHeight = CType(resources.GetObject("comboDashCap.ItemHeight"), Integer)
        Me.comboDashCap.Location = CType(resources.GetObject("comboDashCap.Location"), System.Drawing.Point)
        Me.comboDashCap.MaxDropDownItems = CType(resources.GetObject("comboDashCap.MaxDropDownItems"), Integer)
        Me.comboDashCap.MaxLength = CType(resources.GetObject("comboDashCap.MaxLength"), Integer)
        Me.comboDashCap.Name = "comboDashCap"
        Me.comboDashCap.RightToLeft = CType(resources.GetObject("comboDashCap.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.comboDashCap.Size = CType(resources.GetObject("comboDashCap.Size"), System.Drawing.Size)
        Me.comboDashCap.TabIndex = CType(resources.GetObject("comboDashCap.TabIndex"), Integer)
        Me.comboDashCap.Text = resources.GetString("comboDashCap.Text")
        Me.comboDashCap.Visible = CType(resources.GetObject("comboDashCap.Visible"), Boolean)
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
        'comboLineJoin
        '
        Me.comboLineJoin.AccessibleDescription = resources.GetString("comboLineJoin.AccessibleDescription")
        Me.comboLineJoin.AccessibleName = resources.GetString("comboLineJoin.AccessibleName")
        Me.comboLineJoin.Anchor = CType(resources.GetObject("comboLineJoin.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.comboLineJoin.BackgroundImage = CType(resources.GetObject("comboLineJoin.BackgroundImage"), System.Drawing.Image)
        Me.comboLineJoin.Dock = CType(resources.GetObject("comboLineJoin.Dock"), System.Windows.Forms.DockStyle)
        Me.comboLineJoin.Enabled = CType(resources.GetObject("comboLineJoin.Enabled"), Boolean)
        Me.comboLineJoin.Font = CType(resources.GetObject("comboLineJoin.Font"), System.Drawing.Font)
        Me.comboLineJoin.ImeMode = CType(resources.GetObject("comboLineJoin.ImeMode"), System.Windows.Forms.ImeMode)
        Me.comboLineJoin.IntegralHeight = CType(resources.GetObject("comboLineJoin.IntegralHeight"), Boolean)
        Me.comboLineJoin.ItemHeight = CType(resources.GetObject("comboLineJoin.ItemHeight"), Integer)
        Me.comboLineJoin.Location = CType(resources.GetObject("comboLineJoin.Location"), System.Drawing.Point)
        Me.comboLineJoin.MaxDropDownItems = CType(resources.GetObject("comboLineJoin.MaxDropDownItems"), Integer)
        Me.comboLineJoin.MaxLength = CType(resources.GetObject("comboLineJoin.MaxLength"), Integer)
        Me.comboLineJoin.Name = "comboLineJoin"
        Me.comboLineJoin.RightToLeft = CType(resources.GetObject("comboLineJoin.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.comboLineJoin.Size = CType(resources.GetObject("comboLineJoin.Size"), System.Drawing.Size)
        Me.comboLineJoin.TabIndex = CType(resources.GetObject("comboLineJoin.TabIndex"), Integer)
        Me.comboLineJoin.Text = resources.GetString("comboLineJoin.Text")
        Me.comboLineJoin.Visible = CType(resources.GetObject("comboLineJoin.Visible"), Boolean)
        '
        'Label8
        '
        Me.Label8.AccessibleDescription = resources.GetString("Label8.AccessibleDescription")
        Me.Label8.AccessibleName = resources.GetString("Label8.AccessibleName")
        Me.Label8.Anchor = CType(resources.GetObject("Label8.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = CType(resources.GetObject("Label8.AutoSize"), Boolean)
        Me.Label8.Dock = CType(resources.GetObject("Label8.Dock"), System.Windows.Forms.DockStyle)
        Me.Label8.Enabled = CType(resources.GetObject("Label8.Enabled"), Boolean)
        Me.Label8.Font = CType(resources.GetObject("Label8.Font"), System.Drawing.Font)
        Me.Label8.Image = CType(resources.GetObject("Label8.Image"), System.Drawing.Image)
        Me.Label8.ImageAlign = CType(resources.GetObject("Label8.ImageAlign"), System.Drawing.ContentAlignment)
        Me.Label8.ImageIndex = CType(resources.GetObject("Label8.ImageIndex"), Integer)
        Me.Label8.ImeMode = CType(resources.GetObject("Label8.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Label8.Location = CType(resources.GetObject("Label8.Location"), System.Drawing.Point)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = CType(resources.GetObject("Label8.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Label8.Size = CType(resources.GetObject("Label8.Size"), System.Drawing.Size)
        Me.Label8.TabIndex = CType(resources.GetObject("Label8.TabIndex"), Integer)
        Me.Label8.Text = resources.GetString("Label8.Text")
        Me.Label8.TextAlign = CType(resources.GetObject("Label8.TextAlign"), System.Drawing.ContentAlignment)
        Me.Label8.Visible = CType(resources.GetObject("Label8.Visible"), Boolean)
        '
        'comboLineStyle
        '
        Me.comboLineStyle.AccessibleDescription = resources.GetString("comboLineStyle.AccessibleDescription")
        Me.comboLineStyle.AccessibleName = resources.GetString("comboLineStyle.AccessibleName")
        Me.comboLineStyle.Anchor = CType(resources.GetObject("comboLineStyle.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.comboLineStyle.BackgroundImage = CType(resources.GetObject("comboLineStyle.BackgroundImage"), System.Drawing.Image)
        Me.comboLineStyle.Dock = CType(resources.GetObject("comboLineStyle.Dock"), System.Windows.Forms.DockStyle)
        Me.comboLineStyle.Enabled = CType(resources.GetObject("comboLineStyle.Enabled"), Boolean)
        Me.comboLineStyle.Font = CType(resources.GetObject("comboLineStyle.Font"), System.Drawing.Font)
        Me.comboLineStyle.ImeMode = CType(resources.GetObject("comboLineStyle.ImeMode"), System.Windows.Forms.ImeMode)
        Me.comboLineStyle.IntegralHeight = CType(resources.GetObject("comboLineStyle.IntegralHeight"), Boolean)
        Me.comboLineStyle.ItemHeight = CType(resources.GetObject("comboLineStyle.ItemHeight"), Integer)
        Me.comboLineStyle.Location = CType(resources.GetObject("comboLineStyle.Location"), System.Drawing.Point)
        Me.comboLineStyle.MaxDropDownItems = CType(resources.GetObject("comboLineStyle.MaxDropDownItems"), Integer)
        Me.comboLineStyle.MaxLength = CType(resources.GetObject("comboLineStyle.MaxLength"), Integer)
        Me.comboLineStyle.Name = "comboLineStyle"
        Me.comboLineStyle.RightToLeft = CType(resources.GetObject("comboLineStyle.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.comboLineStyle.Size = CType(resources.GetObject("comboLineStyle.Size"), System.Drawing.Size)
        Me.comboLineStyle.TabIndex = CType(resources.GetObject("comboLineStyle.TabIndex"), Integer)
        Me.comboLineStyle.Text = resources.GetString("comboLineStyle.Text")
        Me.comboLineStyle.Visible = CType(resources.GetObject("comboLineStyle.Visible"), Boolean)
        '
        'Label9
        '
        Me.Label9.AccessibleDescription = resources.GetString("Label9.AccessibleDescription")
        Me.Label9.AccessibleName = resources.GetString("Label9.AccessibleName")
        Me.Label9.Anchor = CType(resources.GetObject("Label9.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = CType(resources.GetObject("Label9.AutoSize"), Boolean)
        Me.Label9.Dock = CType(resources.GetObject("Label9.Dock"), System.Windows.Forms.DockStyle)
        Me.Label9.Enabled = CType(resources.GetObject("Label9.Enabled"), Boolean)
        Me.Label9.Font = CType(resources.GetObject("Label9.Font"), System.Drawing.Font)
        Me.Label9.Image = CType(resources.GetObject("Label9.Image"), System.Drawing.Image)
        Me.Label9.ImageAlign = CType(resources.GetObject("Label9.ImageAlign"), System.Drawing.ContentAlignment)
        Me.Label9.ImageIndex = CType(resources.GetObject("Label9.ImageIndex"), Integer)
        Me.Label9.ImeMode = CType(resources.GetObject("Label9.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Label9.Location = CType(resources.GetObject("Label9.Location"), System.Drawing.Point)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = CType(resources.GetObject("Label9.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Label9.Size = CType(resources.GetObject("Label9.Size"), System.Drawing.Size)
        Me.Label9.TabIndex = CType(resources.GetObject("Label9.TabIndex"), Integer)
        Me.Label9.Text = resources.GetString("Label9.Text")
        Me.Label9.TextAlign = CType(resources.GetObject("Label9.TextAlign"), System.Drawing.ContentAlignment)
        Me.Label9.Visible = CType(resources.GetObject("Label9.Visible"), Boolean)
        '
        'comboBrush
        '
        Me.comboBrush.AccessibleDescription = resources.GetString("comboBrush.AccessibleDescription")
        Me.comboBrush.AccessibleName = resources.GetString("comboBrush.AccessibleName")
        Me.comboBrush.Anchor = CType(resources.GetObject("comboBrush.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.comboBrush.BackgroundImage = CType(resources.GetObject("comboBrush.BackgroundImage"), System.Drawing.Image)
        Me.comboBrush.Dock = CType(resources.GetObject("comboBrush.Dock"), System.Windows.Forms.DockStyle)
        Me.comboBrush.Enabled = CType(resources.GetObject("comboBrush.Enabled"), Boolean)
        Me.comboBrush.Font = CType(resources.GetObject("comboBrush.Font"), System.Drawing.Font)
        Me.comboBrush.ImeMode = CType(resources.GetObject("comboBrush.ImeMode"), System.Windows.Forms.ImeMode)
        Me.comboBrush.IntegralHeight = CType(resources.GetObject("comboBrush.IntegralHeight"), Boolean)
        Me.comboBrush.ItemHeight = CType(resources.GetObject("comboBrush.ItemHeight"), Integer)
        Me.comboBrush.Items.AddRange(New Object() {resources.GetString("comboBrush.Items.Items"), resources.GetString("comboBrush.Items.Items1"), resources.GetString("comboBrush.Items.Items2"), resources.GetString("comboBrush.Items.Items3")})
        Me.comboBrush.Location = CType(resources.GetObject("comboBrush.Location"), System.Drawing.Point)
        Me.comboBrush.MaxDropDownItems = CType(resources.GetObject("comboBrush.MaxDropDownItems"), Integer)
        Me.comboBrush.MaxLength = CType(resources.GetObject("comboBrush.MaxLength"), Integer)
        Me.comboBrush.Name = "comboBrush"
        Me.comboBrush.RightToLeft = CType(resources.GetObject("comboBrush.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.comboBrush.Size = CType(resources.GetObject("comboBrush.Size"), System.Drawing.Size)
        Me.comboBrush.TabIndex = CType(resources.GetObject("comboBrush.TabIndex"), Integer)
        Me.comboBrush.Text = resources.GetString("comboBrush.Text")
        Me.comboBrush.Visible = CType(resources.GetObject("comboBrush.Visible"), Boolean)
        '
        'Label10
        '
        Me.Label10.AccessibleDescription = resources.GetString("Label10.AccessibleDescription")
        Me.Label10.AccessibleName = resources.GetString("Label10.AccessibleName")
        Me.Label10.Anchor = CType(resources.GetObject("Label10.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = CType(resources.GetObject("Label10.AutoSize"), Boolean)
        Me.Label10.Dock = CType(resources.GetObject("Label10.Dock"), System.Windows.Forms.DockStyle)
        Me.Label10.Enabled = CType(resources.GetObject("Label10.Enabled"), Boolean)
        Me.Label10.Font = CType(resources.GetObject("Label10.Font"), System.Drawing.Font)
        Me.Label10.Image = CType(resources.GetObject("Label10.Image"), System.Drawing.Image)
        Me.Label10.ImageAlign = CType(resources.GetObject("Label10.ImageAlign"), System.Drawing.ContentAlignment)
        Me.Label10.ImageIndex = CType(resources.GetObject("Label10.ImageIndex"), Integer)
        Me.Label10.ImeMode = CType(resources.GetObject("Label10.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Label10.Location = CType(resources.GetObject("Label10.Location"), System.Drawing.Point)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = CType(resources.GetObject("Label10.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Label10.Size = CType(resources.GetObject("Label10.Size"), System.Drawing.Size)
        Me.Label10.TabIndex = CType(resources.GetObject("Label10.TabIndex"), Integer)
        Me.Label10.Text = resources.GetString("Label10.Text")
        Me.Label10.TextAlign = CType(resources.GetObject("Label10.TextAlign"), System.Drawing.ContentAlignment)
        Me.Label10.Visible = CType(resources.GetObject("Label10.Visible"), Boolean)
        '
        'GroupBox1
        '
        Me.GroupBox1.AccessibleDescription = CType(resources.GetObject("GroupBox1.AccessibleDescription"), String)
        Me.GroupBox1.AccessibleName = CType(resources.GetObject("GroupBox1.AccessibleName"), String)
        Me.GroupBox1.Anchor = CType(resources.GetObject("GroupBox1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackgroundImage = CType(resources.GetObject("GroupBox1.BackgroundImage"), System.Drawing.Image)
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.radioBrush, Me.radioColor})
        Me.GroupBox1.Dock = CType(resources.GetObject("GroupBox1.Dock"), System.Windows.Forms.DockStyle)
        Me.GroupBox1.Enabled = CType(resources.GetObject("GroupBox1.Enabled"), Boolean)
        Me.GroupBox1.Font = CType(resources.GetObject("GroupBox1.Font"), System.Drawing.Font)
        Me.GroupBox1.ImeMode = CType(resources.GetObject("GroupBox1.ImeMode"), System.Windows.Forms.ImeMode)
        Me.GroupBox1.Location = CType(resources.GetObject("GroupBox1.Location"), System.Drawing.Point)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = CType(resources.GetObject("GroupBox1.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.GroupBox1.Size = CType(resources.GetObject("GroupBox1.Size"), System.Drawing.Size)
        Me.GroupBox1.TabIndex = CType(resources.GetObject("GroupBox1.TabIndex"), Integer)
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = resources.GetString("GroupBox1.Text")
        Me.GroupBox1.Visible = CType(resources.GetObject("GroupBox1.Visible"), Boolean)
        '
        'radioBrush
        '
        Me.radioBrush.AccessibleDescription = resources.GetString("radioBrush.AccessibleDescription")
        Me.radioBrush.AccessibleName = resources.GetString("radioBrush.AccessibleName")
        Me.radioBrush.Anchor = CType(resources.GetObject("radioBrush.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.radioBrush.Appearance = CType(resources.GetObject("radioBrush.Appearance"), System.Windows.Forms.Appearance)
        Me.radioBrush.BackgroundImage = CType(resources.GetObject("radioBrush.BackgroundImage"), System.Drawing.Image)
        Me.radioBrush.CheckAlign = CType(resources.GetObject("radioBrush.CheckAlign"), System.Drawing.ContentAlignment)
        Me.radioBrush.Dock = CType(resources.GetObject("radioBrush.Dock"), System.Windows.Forms.DockStyle)
        Me.radioBrush.Enabled = CType(resources.GetObject("radioBrush.Enabled"), Boolean)
        Me.radioBrush.FlatStyle = CType(resources.GetObject("radioBrush.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.radioBrush.Font = CType(resources.GetObject("radioBrush.Font"), System.Drawing.Font)
        Me.radioBrush.Image = CType(resources.GetObject("radioBrush.Image"), System.Drawing.Image)
        Me.radioBrush.ImageAlign = CType(resources.GetObject("radioBrush.ImageAlign"), System.Drawing.ContentAlignment)
        Me.radioBrush.ImageIndex = CType(resources.GetObject("radioBrush.ImageIndex"), Integer)
        Me.radioBrush.ImeMode = CType(resources.GetObject("radioBrush.ImeMode"), System.Windows.Forms.ImeMode)
        Me.radioBrush.Location = CType(resources.GetObject("radioBrush.Location"), System.Drawing.Point)
        Me.radioBrush.Name = "radioBrush"
        Me.radioBrush.RightToLeft = CType(resources.GetObject("radioBrush.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.radioBrush.Size = CType(resources.GetObject("radioBrush.Size"), System.Drawing.Size)
        Me.radioBrush.TabIndex = CType(resources.GetObject("radioBrush.TabIndex"), Integer)
        Me.radioBrush.TabStop = True
        Me.radioBrush.Text = resources.GetString("radioBrush.Text")
        Me.radioBrush.TextAlign = CType(resources.GetObject("radioBrush.TextAlign"), System.Drawing.ContentAlignment)
        Me.radioBrush.Visible = CType(resources.GetObject("radioBrush.Visible"), Boolean)
        '
        'radioColor
        '
        Me.radioColor.AccessibleDescription = resources.GetString("radioColor.AccessibleDescription")
        Me.radioColor.AccessibleName = resources.GetString("radioColor.AccessibleName")
        Me.radioColor.Anchor = CType(resources.GetObject("radioColor.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.radioColor.Appearance = CType(resources.GetObject("radioColor.Appearance"), System.Windows.Forms.Appearance)
        Me.radioColor.BackgroundImage = CType(resources.GetObject("radioColor.BackgroundImage"), System.Drawing.Image)
        Me.radioColor.CheckAlign = CType(resources.GetObject("radioColor.CheckAlign"), System.Drawing.ContentAlignment)
        Me.radioColor.Checked = True
        Me.radioColor.Dock = CType(resources.GetObject("radioColor.Dock"), System.Windows.Forms.DockStyle)
        Me.radioColor.Enabled = CType(resources.GetObject("radioColor.Enabled"), Boolean)
        Me.radioColor.FlatStyle = CType(resources.GetObject("radioColor.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.radioColor.Font = CType(resources.GetObject("radioColor.Font"), System.Drawing.Font)
        Me.radioColor.Image = CType(resources.GetObject("radioColor.Image"), System.Drawing.Image)
        Me.radioColor.ImageAlign = CType(resources.GetObject("radioColor.ImageAlign"), System.Drawing.ContentAlignment)
        Me.radioColor.ImageIndex = CType(resources.GetObject("radioColor.ImageIndex"), Integer)
        Me.radioColor.ImeMode = CType(resources.GetObject("radioColor.ImeMode"), System.Windows.Forms.ImeMode)
        Me.radioColor.Location = CType(resources.GetObject("radioColor.Location"), System.Drawing.Point)
        Me.radioColor.Name = "radioColor"
        Me.radioColor.RightToLeft = CType(resources.GetObject("radioColor.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.radioColor.Size = CType(resources.GetObject("radioColor.Size"), System.Drawing.Size)
        Me.radioColor.TabIndex = CType(resources.GetObject("radioColor.TabIndex"), Integer)
        Me.radioColor.TabStop = True
        Me.radioColor.Text = resources.GetString("radioColor.Text")
        Me.radioColor.TextAlign = CType(resources.GetObject("radioColor.TextAlign"), System.Drawing.ContentAlignment)
        Me.radioColor.Visible = CType(resources.GetObject("radioColor.Visible"), Boolean)
        '
        'Label11
        '
        Me.Label11.AccessibleDescription = resources.GetString("Label11.AccessibleDescription")
        Me.Label11.AccessibleName = resources.GetString("Label11.AccessibleName")
        Me.Label11.Anchor = CType(resources.GetObject("Label11.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = CType(resources.GetObject("Label11.AutoSize"), Boolean)
        Me.Label11.Dock = CType(resources.GetObject("Label11.Dock"), System.Windows.Forms.DockStyle)
        Me.Label11.Enabled = CType(resources.GetObject("Label11.Enabled"), Boolean)
        Me.Label11.Font = CType(resources.GetObject("Label11.Font"), System.Drawing.Font)
        Me.Label11.Image = CType(resources.GetObject("Label11.Image"), System.Drawing.Image)
        Me.Label11.ImageAlign = CType(resources.GetObject("Label11.ImageAlign"), System.Drawing.ContentAlignment)
        Me.Label11.ImageIndex = CType(resources.GetObject("Label11.ImageIndex"), Integer)
        Me.Label11.ImeMode = CType(resources.GetObject("Label11.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Label11.Location = CType(resources.GetObject("Label11.Location"), System.Drawing.Point)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = CType(resources.GetObject("Label11.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Label11.Size = CType(resources.GetObject("Label11.Size"), System.Drawing.Size)
        Me.Label11.TabIndex = CType(resources.GetObject("Label11.TabIndex"), Integer)
        Me.Label11.Text = resources.GetString("Label11.Text")
        Me.Label11.TextAlign = CType(resources.GetObject("Label11.TextAlign"), System.Drawing.ContentAlignment)
        Me.Label11.Visible = CType(resources.GetObject("Label11.Visible"), Boolean)
        '
        'updownMiterLimit
        '
        Me.updownMiterLimit.AccessibleDescription = resources.GetString("updownMiterLimit.AccessibleDescription")
        Me.updownMiterLimit.AccessibleName = resources.GetString("updownMiterLimit.AccessibleName")
        Me.updownMiterLimit.Anchor = CType(resources.GetObject("updownMiterLimit.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.updownMiterLimit.DecimalPlaces = 2
        Me.updownMiterLimit.Dock = CType(resources.GetObject("updownMiterLimit.Dock"), System.Windows.Forms.DockStyle)
        Me.updownMiterLimit.Enabled = CType(resources.GetObject("updownMiterLimit.Enabled"), Boolean)
        Me.updownMiterLimit.Font = CType(resources.GetObject("updownMiterLimit.Font"), System.Drawing.Font)
        Me.updownMiterLimit.ImeMode = CType(resources.GetObject("updownMiterLimit.ImeMode"), System.Windows.Forms.ImeMode)
        Me.updownMiterLimit.Increment = New Decimal(New Integer() {25, 0, 0, 131072})
        Me.updownMiterLimit.Location = CType(resources.GetObject("updownMiterLimit.Location"), System.Drawing.Point)
        Me.updownMiterLimit.Maximum = New Decimal(New Integer() {15, 0, 0, 0})
        Me.updownMiterLimit.Name = "updownMiterLimit"
        Me.updownMiterLimit.RightToLeft = CType(resources.GetObject("updownMiterLimit.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.updownMiterLimit.Size = CType(resources.GetObject("updownMiterLimit.Size"), System.Drawing.Size)
        Me.updownMiterLimit.TabIndex = CType(resources.GetObject("updownMiterLimit.TabIndex"), Integer)
        Me.updownMiterLimit.TextAlign = CType(resources.GetObject("updownMiterLimit.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.updownMiterLimit.ThousandsSeparator = CType(resources.GetObject("updownMiterLimit.ThousandsSeparator"), Boolean)
        Me.updownMiterLimit.UpDownAlign = CType(resources.GetObject("updownMiterLimit.UpDownAlign"), System.Windows.Forms.LeftRightAlignment)
        Me.updownMiterLimit.Value = New Decimal(New Integer() {4, 0, 0, 0})
        Me.updownMiterLimit.Visible = CType(resources.GetObject("updownMiterLimit.Visible"), Boolean)
        '
        'comboTransform
        '
        Me.comboTransform.AccessibleDescription = resources.GetString("comboTransform.AccessibleDescription")
        Me.comboTransform.AccessibleName = resources.GetString("comboTransform.AccessibleName")
        Me.comboTransform.Anchor = CType(resources.GetObject("comboTransform.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.comboTransform.BackgroundImage = CType(resources.GetObject("comboTransform.BackgroundImage"), System.Drawing.Image)
        Me.comboTransform.Dock = CType(resources.GetObject("comboTransform.Dock"), System.Windows.Forms.DockStyle)
        Me.comboTransform.Enabled = CType(resources.GetObject("comboTransform.Enabled"), Boolean)
        Me.comboTransform.Font = CType(resources.GetObject("comboTransform.Font"), System.Drawing.Font)
        Me.comboTransform.ImeMode = CType(resources.GetObject("comboTransform.ImeMode"), System.Windows.Forms.ImeMode)
        Me.comboTransform.IntegralHeight = CType(resources.GetObject("comboTransform.IntegralHeight"), Boolean)
        Me.comboTransform.ItemHeight = CType(resources.GetObject("comboTransform.ItemHeight"), Integer)
        Me.comboTransform.Items.AddRange(New Object() {resources.GetString("comboTransform.Items.Items"), resources.GetString("comboTransform.Items.Items1"), resources.GetString("comboTransform.Items.Items2"), resources.GetString("comboTransform.Items.Items3")})
        Me.comboTransform.Location = CType(resources.GetObject("comboTransform.Location"), System.Drawing.Point)
        Me.comboTransform.MaxDropDownItems = CType(resources.GetObject("comboTransform.MaxDropDownItems"), Integer)
        Me.comboTransform.MaxLength = CType(resources.GetObject("comboTransform.MaxLength"), Integer)
        Me.comboTransform.Name = "comboTransform"
        Me.comboTransform.RightToLeft = CType(resources.GetObject("comboTransform.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.comboTransform.Size = CType(resources.GetObject("comboTransform.Size"), System.Drawing.Size)
        Me.comboTransform.TabIndex = CType(resources.GetObject("comboTransform.TabIndex"), Integer)
        Me.comboTransform.Text = resources.GetString("comboTransform.Text")
        Me.comboTransform.Visible = CType(resources.GetObject("comboTransform.Visible"), Boolean)
        '
        'Label12
        '
        Me.Label12.AccessibleDescription = resources.GetString("Label12.AccessibleDescription")
        Me.Label12.AccessibleName = resources.GetString("Label12.AccessibleName")
        Me.Label12.Anchor = CType(resources.GetObject("Label12.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = CType(resources.GetObject("Label12.AutoSize"), Boolean)
        Me.Label12.Dock = CType(resources.GetObject("Label12.Dock"), System.Windows.Forms.DockStyle)
        Me.Label12.Enabled = CType(resources.GetObject("Label12.Enabled"), Boolean)
        Me.Label12.Font = CType(resources.GetObject("Label12.Font"), System.Drawing.Font)
        Me.Label12.Image = CType(resources.GetObject("Label12.Image"), System.Drawing.Image)
        Me.Label12.ImageAlign = CType(resources.GetObject("Label12.ImageAlign"), System.Drawing.ContentAlignment)
        Me.Label12.ImageIndex = CType(resources.GetObject("Label12.ImageIndex"), Integer)
        Me.Label12.ImeMode = CType(resources.GetObject("Label12.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Label12.Location = CType(resources.GetObject("Label12.Location"), System.Drawing.Point)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = CType(resources.GetObject("Label12.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Label12.Size = CType(resources.GetObject("Label12.Size"), System.Drawing.Size)
        Me.Label12.TabIndex = CType(resources.GetObject("Label12.TabIndex"), Integer)
        Me.Label12.Text = resources.GetString("Label12.Text")
        Me.Label12.TextAlign = CType(resources.GetObject("Label12.TextAlign"), System.Drawing.ContentAlignment)
        Me.Label12.Visible = CType(resources.GetObject("Label12.Visible"), Boolean)
        '
        'btnCycle
        '
        Me.btnCycle.AccessibleDescription = resources.GetString("btnCycle.AccessibleDescription")
        Me.btnCycle.AccessibleName = resources.GetString("btnCycle.AccessibleName")
        Me.btnCycle.Anchor = CType(resources.GetObject("btnCycle.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnCycle.BackgroundImage = CType(resources.GetObject("btnCycle.BackgroundImage"), System.Drawing.Image)
        Me.btnCycle.Dock = CType(resources.GetObject("btnCycle.Dock"), System.Windows.Forms.DockStyle)
        Me.btnCycle.Enabled = CType(resources.GetObject("btnCycle.Enabled"), Boolean)
        Me.btnCycle.FlatStyle = CType(resources.GetObject("btnCycle.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnCycle.Font = CType(resources.GetObject("btnCycle.Font"), System.Drawing.Font)
        Me.btnCycle.Image = CType(resources.GetObject("btnCycle.Image"), System.Drawing.Image)
        Me.btnCycle.ImageAlign = CType(resources.GetObject("btnCycle.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnCycle.ImageIndex = CType(resources.GetObject("btnCycle.ImageIndex"), Integer)
        Me.btnCycle.ImeMode = CType(resources.GetObject("btnCycle.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnCycle.Location = CType(resources.GetObject("btnCycle.Location"), System.Drawing.Point)
        Me.btnCycle.Name = "btnCycle"
        Me.btnCycle.RightToLeft = CType(resources.GetObject("btnCycle.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnCycle.Size = CType(resources.GetObject("btnCycle.Size"), System.Drawing.Size)
        Me.btnCycle.TabIndex = CType(resources.GetObject("btnCycle.TabIndex"), Integer)
        Me.btnCycle.Text = resources.GetString("btnCycle.Text")
        Me.btnCycle.TextAlign = CType(resources.GetObject("btnCycle.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnCycle.Visible = CType(resources.GetObject("btnCycle.Visible"), Boolean)
        '
        'timerCycle
        '
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
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCycle, Me.comboTransform, Me.Label12, Me.Label11, Me.updownMiterLimit, Me.GroupBox1, Me.comboLineStyle, Me.Label9, Me.comboLineJoin, Me.Label8, Me.comboEndCap, Me.Label6, Me.comboStartCap, Me.Label4, Me.updownWidth, Me.Label5, Me.comboShape, Me.pbLines, Me.Label3, Me.Label2, Me.btnSetColor, Me.txtColor, Me.Label1, Me.comboAlignment, Me.comboDashCap, Me.Label7, Me.comboBrush, Me.Label10})
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
        CType(Me.updownWidth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.updownMiterLimit, System.ComponentModel.ISupportInitialize).EndInit()
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

    ' This is used to turn on and off the timer that handles
    '   the cycling of the dots and dashes.
    Private Sub btnCycle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCycle.Click
        timerCycle.Interval = 333
        timerCycle.Enabled = Not timerCycle.Enabled
        If timerCycle.Enabled Then
            btnCycle.Text = "Stop!"
        Else
            btnCycle.Text = "Animate"
        End If
    End Sub

    ' This Sub sets the Color based on the user selection from
    '   a ColorDialog
    Private Sub btnSetColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetColor.Click
        Dim cdlg As New ColorDialog()

        If cdlg.ShowDialog() = DialogResult.OK Then
            m_penColor = cdlg.Color
            txtColor.Text = cdlg.Color.ToString()
            txtColor.BackColor = cdlg.Color
        End If

    End Sub

    ' When the frmMain is loaded, this Sub sets up defaults for the page
    '   and builds the necessary combo boxes. Notice that the combo
    '   boxes here hold various objects, instead of standard strings. This
    '   way they can be used directly when assigning their values to 
    '   other objects.
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim i As Integer ' Used for looping structures

        ' Set up the ComboBoxes for the form
        ' Set up the StartCap combo
        comboStartCap.Items.Add(LineCap.DiamondAnchor)
        comboStartCap.Items.Add(LineCap.ArrowAnchor)
        comboStartCap.Items.Add(LineCap.DiamondAnchor)
        comboStartCap.Items.Add(LineCap.Flat)
        comboStartCap.Items.Add(LineCap.Round)
        comboStartCap.Items.Add(LineCap.RoundAnchor)

        ' Set up the EndCap combo
        comboEndCap.Items.Add(LineCap.DiamondAnchor)
        comboEndCap.Items.Add(LineCap.ArrowAnchor)
        comboEndCap.Items.Add(LineCap.DiamondAnchor)
        comboEndCap.Items.Add(LineCap.Flat)
        comboEndCap.Items.Add(LineCap.Round)
        comboEndCap.Items.Add(LineCap.RoundAnchor)

        ' Set up Dash Cap
        comboDashCap.Items.Add(DashCap.Flat)
        comboDashCap.Items.Add(DashCap.Round)
        comboDashCap.Items.Add(DashCap.Triangle)

        ' Set up Line Join
        comboLineJoin.Items.Add(LineJoin.Bevel)
        comboLineJoin.Items.Add(LineJoin.Miter)
        comboLineJoin.Items.Add(LineJoin.MiterClipped)
        comboLineJoin.Items.Add(LineJoin.Round)

        ' Set up Line Join
        comboLineStyle.Items.Add(DashStyle.Solid)
        comboLineStyle.Items.Add(DashStyle.Dash)
        comboLineStyle.Items.Add(DashStyle.DashDot)
        comboLineStyle.Items.Add(DashStyle.DashDotDot)
        comboLineStyle.Items.Add(DashStyle.Dot)
        comboLineStyle.Items.Add(DashStyle.Custom)

        ' Set up Alignment
        comboAlignment.Items.Add(PenAlignment.Center)
        comboAlignment.Items.Add(PenAlignment.Inset)
        comboAlignment.Items.Add(PenAlignment.Left)
        comboAlignment.Items.Add(PenAlignment.Outset)
        comboAlignment.Items.Add(PenAlignment.Right)

    End Sub

#Region "RadioCheckBox code"
    Private Sub radioColor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radioColor.CheckedChanged
        txtColor.Enabled = radioColor.Checked
        btnSetColor.Enabled = radioColor.Checked
        comboBrush.Enabled = radioBrush.Checked
    End Sub
#End Region

    ' RedrawPicture collects all the user defined information, and uses it
    '   to create a Pen object, which is then used to draw one of three different
    '   drawings. Notice that this Sub handles virtually all of events triggered
    '   by the user interface.
    Private Sub RedrawPicture(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles MyBase.Activated, comboShape.SelectedIndexChanged, _
        updownWidth.ValueChanged, txtColor.TextChanged, _
        comboAlignment.SelectedIndexChanged, comboStartCap.SelectedIndexChanged, _
        comboEndCap.SelectedIndexChanged, comboDashCap.SelectedIndexChanged, _
        comboLineJoin.SelectedIndexChanged, comboLineStyle.SelectedIndexChanged, _
        updownMiterLimit.ValueChanged, comboTransform.SelectedIndexChanged, _
        comboBrush.SelectedIndexChanged

        ' Reset the PictureBox
        pbLines.CreateGraphics().Clear(pbLines.BackColor)
        pbLines.Refresh()
        ' Get rid of any current transform on the Pen
        m_Pen.ResetTransform()
        ' Set the DashPattern to use if Custom type of Dashed Line is selected
        m_Pen.DashPattern = New Single() {0.5, 0.25, 0.75, 1.5}

        ' Since a Pen can have either a Color or a Brush assigned, but not both,
        '   this code determines which should be used. Note that assigning a Color
        '   is identical to assigning the pen a SolidBrush.
        If radioColor.Checked Then
            m_Pen.Color = m_penColor
        Else
            Select Case comboBrush.Text
                Case "Solid"
                    ' The same as assigning the Pen a Color
                    m_penBrush = New SolidBrush(m_penColor)
                Case "Hatch"
                    ' Defines a HatchBrush to use, in this case a Plaid one.
                    m_penBrush = New HatchBrush(HatchStyle.Plaid, m_penColor)
                Case "Texture"
                    ' Assigns a bitmap image to be used as the Brush.
                    m_penBrush = New TextureBrush( _
                        New Bitmap("..\WaterLilies.jpg"), WrapMode.Tile)
                Case "Gradient"
                    ' Builds a LinearGradientBrush to use as the Brush. Other types
                    '   of gradient brushes could be used here as well.
                    m_penBrush = New LinearGradientBrush( _
                        New Point(0, 0), _
                        New Point(pbLines.Width, pbLines.Height), _
                        Color.AliceBlue, Color.DarkBlue)
            End Select

            m_Pen.Brush = m_penBrush
        End If

        ' Set the user defined values for all the pen objects
        ' Width of the Pen is in pixels 
        m_Pen.Width = updownWidth.Value
        ' DashStyle determines the look of the line.
        '   It can be dashes, dots and dashes, or even custom
        m_Pen.DashStyle = CType(comboLineStyle.SelectedItem, DashStyle)
        ' MiterLimit is a float that determines when the Miter edge of
        '   two adjacent lines should be clipped. The default is 10.0
        m_Pen.MiterLimit = updownMiterLimit.Value
        ' StartCap determines the cap that should be put on
        '   the start of a line drawn by the pen
        m_Pen.StartCap = CType(comboStartCap.SelectedItem, LineCap)
        ' EndCap determines the cap that should be put on
        '   the end of a line drawn by the pen
        m_Pen.EndCap = CType(comboEndCap.SelectedItem, LineCap)
        ' DashCap determines the cap that should be put on
        '   both ends of any dashes in a line drawn by the pen
        m_Pen.DashCap = CType(comboDashCap.SelectedItem, DashCap)
        ' LineJoin determines how two adjacent lines should be joined.
        '   For instance, they can have a rounded join, or a mitered join.
        m_Pen.LineJoin = CType(comboLineJoin.SelectedItem, LineJoin)
        ' Alignment determines which 'side' of the designated line, that
        '   the pen should draw on. For instance, Inset will cause the
        '   pen to draw on the inside of a circle.
        m_Pen.Alignment = CType(comboAlignment.SelectedItem, PenAlignment)

        ' Transforms are used for some advanced features of pens. You can,
        '   for instance, create a caligraphic style pen.
        Select Case comboTransform.Text
            Case "None"
                ' ResetTransform resets the pen to having no transform
                m_Pen.ResetTransform()
            Case "Scale"
                ' ScaleTransform  changes the appearance of the pen, by
                '   by changing the width and height of the pen. For instance,
                '   the transform below makes the width half as thin as the
                '   normal, and doubles the height.
                m_Pen.ScaleTransform(0.5, 2)
            Case "Rotate"
                ' RotateTransform only is used if the underlying 
                '   Brush supports it. It rotates the brush by a number of 
                '   degrees.
                m_Pen.RotateTransform(45)
            Case "Translate"
                ' TranslateTransform only is used if the underlying 
                '   Brush supports it. It translates the underlying brush.
                m_Pen.TranslateTransform(2, 4)
        End Select



        ' Now that the Pen has been defined create a graphics object, and
        '   redraw the image on the PictureBox. Also draw a thin black line
        '   using the same command. This will allow the user to see where
        '   the line was intended to go, and aids in illuminating what
        '   various properties do.
        graphic = pbLines.CreateGraphics()

        If Me.comboShape.Text = "Lines" Then
            ' Draw 3 simple lines. 
            ' Draw using the user defined pen
            graphic.DrawLine(m_Pen, 35, 35, pbLines.Width - 35, 35)
            graphic.DrawLine(m_Pen, 35, 80, 35, pbLines.Height - 35)
            graphic.DrawLine(m_Pen, 90, 90, pbLines.Width - 35, _
                pbLines.Height - 35)

            ' Draw using the thin black pen, to see effects
            graphic.DrawLine(m_BlackThinPen, 35, 35, pbLines.Width - 35, 35)
            graphic.DrawLine(m_BlackThinPen, 35, 80, 35, pbLines.Height - 35)
            graphic.DrawLine(m_BlackThinPen, 90, 90, pbLines.Width - 35, _
                    pbLines.Height - 35)

        ElseIf Me.comboShape.Text = "Intersecting Lines" Then
            ' Draw a compound line

            ' Create a more complex shape using an array of Points
            '   To define a multisegment line. If several independent
            '   lines are used instead, even if they connect, then the 
            '   end and start caps would be placed on each independent line.
            '   Here they are only placed on the beginning and end of the 
            '   compound line.
            Dim ptArray(5) As PointF
            ptArray(0) = New PointF(35, 35)
            ptArray(1) = New PointF(70, pbLines.Height - 75)
            ptArray(2) = New PointF(100, 35)
            ptArray(3) = New PointF(pbLines.Width - 40, pbLines.Height \ 2)
            ptArray(4) = New PointF(pbLines.Width \ 2, pbLines.Height \ 2)
            ptArray(5) = New PointF(pbLines.Width - 25, 25)

            ' Draw the lines using the user defined Pen
            graphic.DrawLines(m_Pen, ptArray)

            ' Draw the lines using the thin, black Pen
            graphic.DrawLines(m_BlackThinPen, ptArray)

        ElseIf Me.comboShape.Text = "Circles and Curves" Then
            ' Draw a circle and a curve

            ' Draw the curves using the user defined Pen
            graphic.DrawEllipse(m_Pen, 25, 25, 200, 200)
            graphic.DrawArc(m_Pen, 55, 55, pbLines.Height - 55, _
                pbLines.Height - 55, 110, 150)

            ' Draw the curves using the thin, black Pen
            graphic.DrawEllipse(m_BlackThinPen, 25, 25, 200, 200)
            graphic.DrawArc(m_BlackThinPen, 55, 55, pbLines.Height - 55, _
                pbLines.Height - 55, 110, 150)

        End If

    End Sub

    ' When the timer fires, the DashOffset property is incremented and the dots
    '   and dashes in a line apprear to animate.
    Private Sub timerCycle_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerCycle.Tick
        m_Pen.DashOffset = (m_Pen.DashOffset + 0.5F) Mod 30
        RedrawPicture(Me, New System.EventArgs())
    End Sub
End Class