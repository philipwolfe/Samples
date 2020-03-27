'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

' Drawing2D is required to get access to 2 of the Brushes we'll use
Imports System.Drawing.Drawing2D

Public Class frmMain
    Inherits System.Windows.Forms.Form

    ' Here all the class variables are defined
    ' Since Brush is a MustInherit (abstract) class, this brush will
    '   actually be holding instances of the other 5 types of brushes
    Dim m_Brush As Brush ' Demonstration brush    
    Dim m_Color1 As Color = Color.Blue ' Mainly acts as foreground color
    Dim m_Color2 As Color = Color.White ' Mainly acts as background color
    Dim m_Pen As Pen ' Pen to use when drawing lines
    Dim m_BrushSize As Rectangle ' Rectangle used when tiling brushes
    Dim myGraphics As Graphics ' Graphics object used to draw brushes

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
    Friend WithEvents picDemoArea As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSetColor1 As System.Windows.Forms.Button
    Friend WithEvents txtColor1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboBrushType As System.Windows.Forms.ComboBox
    Friend WithEvents cboDrawing As System.Windows.Forms.ComboBox
    Friend WithEvents btnSetColor2 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtColor2 As System.Windows.Forms.TextBox
    Friend WithEvents cboBrushSize As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboWrapMode As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents sbrDrawingStatus As System.Windows.Forms.StatusBar
    Friend WithEvents cboHatchStyle As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboGradientMode As System.Windows.Forms.ComboBox
    Friend WithEvents nudRotation As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudGradientBlend As System.Windows.Forms.NumericUpDown
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.picDemoArea = New System.Windows.Forms.PictureBox()
        Me.cboBrushType = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSetColor1 = New System.Windows.Forms.Button()
        Me.txtColor1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboDrawing = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnSetColor2 = New System.Windows.Forms.Button()
        Me.txtColor2 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboBrushSize = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboWrapMode = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.sbrDrawingStatus = New System.Windows.Forms.StatusBar()
        Me.cboHatchStyle = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.nudRotation = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.nudGradientBlend = New System.Windows.Forms.NumericUpDown()
        Me.cboGradientMode = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        CType(Me.nudRotation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudGradientBlend, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'picDemoArea
        '
        Me.picDemoArea.AccessibleDescription = resources.GetString("picDemoArea.AccessibleDescription")
        Me.picDemoArea.AccessibleName = resources.GetString("picDemoArea.AccessibleName")
        Me.picDemoArea.Anchor = CType(resources.GetObject("picDemoArea.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.picDemoArea.BackgroundImage = CType(resources.GetObject("picDemoArea.BackgroundImage"), System.Drawing.Image)
        Me.picDemoArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picDemoArea.Dock = CType(resources.GetObject("picDemoArea.Dock"), System.Windows.Forms.DockStyle)
        Me.picDemoArea.Enabled = CType(resources.GetObject("picDemoArea.Enabled"), Boolean)
        Me.picDemoArea.Font = CType(resources.GetObject("picDemoArea.Font"), System.Drawing.Font)
        Me.picDemoArea.Image = CType(resources.GetObject("picDemoArea.Image"), System.Drawing.Image)
        Me.picDemoArea.ImeMode = CType(resources.GetObject("picDemoArea.ImeMode"), System.Windows.Forms.ImeMode)
        Me.picDemoArea.Location = CType(resources.GetObject("picDemoArea.Location"), System.Drawing.Point)
        Me.picDemoArea.Name = "picDemoArea"
        Me.picDemoArea.RightToLeft = CType(resources.GetObject("picDemoArea.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.picDemoArea.Size = CType(resources.GetObject("picDemoArea.Size"), System.Drawing.Size)
        Me.picDemoArea.SizeMode = CType(resources.GetObject("picDemoArea.SizeMode"), System.Windows.Forms.PictureBoxSizeMode)
        Me.picDemoArea.TabIndex = CType(resources.GetObject("picDemoArea.TabIndex"), Integer)
        Me.picDemoArea.TabStop = False
        Me.picDemoArea.Text = resources.GetString("picDemoArea.Text")
        Me.picDemoArea.Visible = CType(resources.GetObject("picDemoArea.Visible"), Boolean)
        '
        'cboBrushType
        '
        Me.cboBrushType.AccessibleDescription = resources.GetString("cboBrushType.AccessibleDescription")
        Me.cboBrushType.AccessibleName = resources.GetString("cboBrushType.AccessibleName")
        Me.cboBrushType.Anchor = CType(resources.GetObject("cboBrushType.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.cboBrushType.BackgroundImage = CType(resources.GetObject("cboBrushType.BackgroundImage"), System.Drawing.Image)
        Me.cboBrushType.Dock = CType(resources.GetObject("cboBrushType.Dock"), System.Windows.Forms.DockStyle)
        Me.cboBrushType.Enabled = CType(resources.GetObject("cboBrushType.Enabled"), Boolean)
        Me.cboBrushType.Font = CType(resources.GetObject("cboBrushType.Font"), System.Drawing.Font)
        Me.cboBrushType.ImeMode = CType(resources.GetObject("cboBrushType.ImeMode"), System.Windows.Forms.ImeMode)
        Me.cboBrushType.IntegralHeight = CType(resources.GetObject("cboBrushType.IntegralHeight"), Boolean)
        Me.cboBrushType.ItemHeight = CType(resources.GetObject("cboBrushType.ItemHeight"), Integer)
        Me.cboBrushType.Items.AddRange(New Object() {resources.GetString("cboBrushType.Items.Items"), resources.GetString("cboBrushType.Items.Items1"), resources.GetString("cboBrushType.Items.Items2"), resources.GetString("cboBrushType.Items.Items3"), resources.GetString("cboBrushType.Items.Items4")})
        Me.cboBrushType.Location = CType(resources.GetObject("cboBrushType.Location"), System.Drawing.Point)
        Me.cboBrushType.MaxDropDownItems = CType(resources.GetObject("cboBrushType.MaxDropDownItems"), Integer)
        Me.cboBrushType.MaxLength = CType(resources.GetObject("cboBrushType.MaxLength"), Integer)
        Me.cboBrushType.Name = "cboBrushType"
        Me.cboBrushType.RightToLeft = CType(resources.GetObject("cboBrushType.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.cboBrushType.Size = CType(resources.GetObject("cboBrushType.Size"), System.Drawing.Size)
        Me.cboBrushType.TabIndex = CType(resources.GetObject("cboBrushType.TabIndex"), Integer)
        Me.cboBrushType.Text = resources.GetString("cboBrushType.Text")
        Me.cboBrushType.Visible = CType(resources.GetObject("cboBrushType.Visible"), Boolean)
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
        'btnSetColor1
        '
        Me.btnSetColor1.AccessibleDescription = resources.GetString("btnSetColor1.AccessibleDescription")
        Me.btnSetColor1.AccessibleName = resources.GetString("btnSetColor1.AccessibleName")
        Me.btnSetColor1.Anchor = CType(resources.GetObject("btnSetColor1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnSetColor1.BackgroundImage = CType(resources.GetObject("btnSetColor1.BackgroundImage"), System.Drawing.Image)
        Me.btnSetColor1.Dock = CType(resources.GetObject("btnSetColor1.Dock"), System.Windows.Forms.DockStyle)
        Me.btnSetColor1.Enabled = CType(resources.GetObject("btnSetColor1.Enabled"), Boolean)
        Me.btnSetColor1.FlatStyle = CType(resources.GetObject("btnSetColor1.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnSetColor1.Font = CType(resources.GetObject("btnSetColor1.Font"), System.Drawing.Font)
        Me.btnSetColor1.Image = CType(resources.GetObject("btnSetColor1.Image"), System.Drawing.Image)
        Me.btnSetColor1.ImageAlign = CType(resources.GetObject("btnSetColor1.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnSetColor1.ImageIndex = CType(resources.GetObject("btnSetColor1.ImageIndex"), Integer)
        Me.btnSetColor1.ImeMode = CType(resources.GetObject("btnSetColor1.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnSetColor1.Location = CType(resources.GetObject("btnSetColor1.Location"), System.Drawing.Point)
        Me.btnSetColor1.Name = "btnSetColor1"
        Me.btnSetColor1.RightToLeft = CType(resources.GetObject("btnSetColor1.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnSetColor1.Size = CType(resources.GetObject("btnSetColor1.Size"), System.Drawing.Size)
        Me.btnSetColor1.TabIndex = CType(resources.GetObject("btnSetColor1.TabIndex"), Integer)
        Me.btnSetColor1.Text = resources.GetString("btnSetColor1.Text")
        Me.btnSetColor1.TextAlign = CType(resources.GetObject("btnSetColor1.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnSetColor1.Visible = CType(resources.GetObject("btnSetColor1.Visible"), Boolean)
        '
        'txtColor1
        '
        Me.txtColor1.AccessibleDescription = resources.GetString("txtColor1.AccessibleDescription")
        Me.txtColor1.AccessibleName = resources.GetString("txtColor1.AccessibleName")
        Me.txtColor1.Anchor = CType(resources.GetObject("txtColor1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtColor1.AutoSize = CType(resources.GetObject("txtColor1.AutoSize"), Boolean)
        Me.txtColor1.BackgroundImage = CType(resources.GetObject("txtColor1.BackgroundImage"), System.Drawing.Image)
        Me.txtColor1.Dock = CType(resources.GetObject("txtColor1.Dock"), System.Windows.Forms.DockStyle)
        Me.txtColor1.Enabled = CType(resources.GetObject("txtColor1.Enabled"), Boolean)
        Me.txtColor1.Font = CType(resources.GetObject("txtColor1.Font"), System.Drawing.Font)
        Me.txtColor1.ImeMode = CType(resources.GetObject("txtColor1.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtColor1.Location = CType(resources.GetObject("txtColor1.Location"), System.Drawing.Point)
        Me.txtColor1.MaxLength = CType(resources.GetObject("txtColor1.MaxLength"), Integer)
        Me.txtColor1.Multiline = CType(resources.GetObject("txtColor1.Multiline"), Boolean)
        Me.txtColor1.Name = "txtColor1"
        Me.txtColor1.PasswordChar = CType(resources.GetObject("txtColor1.PasswordChar"), Char)
        Me.txtColor1.RightToLeft = CType(resources.GetObject("txtColor1.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtColor1.ScrollBars = CType(resources.GetObject("txtColor1.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtColor1.Size = CType(resources.GetObject("txtColor1.Size"), System.Drawing.Size)
        Me.txtColor1.TabIndex = CType(resources.GetObject("txtColor1.TabIndex"), Integer)
        Me.txtColor1.Text = resources.GetString("txtColor1.Text")
        Me.txtColor1.TextAlign = CType(resources.GetObject("txtColor1.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtColor1.Visible = CType(resources.GetObject("txtColor1.Visible"), Boolean)
        Me.txtColor1.WordWrap = CType(resources.GetObject("txtColor1.WordWrap"), Boolean)
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
        'cboDrawing
        '
        Me.cboDrawing.AccessibleDescription = resources.GetString("cboDrawing.AccessibleDescription")
        Me.cboDrawing.AccessibleName = resources.GetString("cboDrawing.AccessibleName")
        Me.cboDrawing.Anchor = CType(resources.GetObject("cboDrawing.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.cboDrawing.BackgroundImage = CType(resources.GetObject("cboDrawing.BackgroundImage"), System.Drawing.Image)
        Me.cboDrawing.Dock = CType(resources.GetObject("cboDrawing.Dock"), System.Windows.Forms.DockStyle)
        Me.cboDrawing.Enabled = CType(resources.GetObject("cboDrawing.Enabled"), Boolean)
        Me.cboDrawing.Font = CType(resources.GetObject("cboDrawing.Font"), System.Drawing.Font)
        Me.cboDrawing.ImeMode = CType(resources.GetObject("cboDrawing.ImeMode"), System.Windows.Forms.ImeMode)
        Me.cboDrawing.IntegralHeight = CType(resources.GetObject("cboDrawing.IntegralHeight"), Boolean)
        Me.cboDrawing.ItemHeight = CType(resources.GetObject("cboDrawing.ItemHeight"), Integer)
        Me.cboDrawing.Items.AddRange(New Object() {resources.GetString("cboDrawing.Items.Items"), resources.GetString("cboDrawing.Items.Items1"), resources.GetString("cboDrawing.Items.Items2")})
        Me.cboDrawing.Location = CType(resources.GetObject("cboDrawing.Location"), System.Drawing.Point)
        Me.cboDrawing.MaxDropDownItems = CType(resources.GetObject("cboDrawing.MaxDropDownItems"), Integer)
        Me.cboDrawing.MaxLength = CType(resources.GetObject("cboDrawing.MaxLength"), Integer)
        Me.cboDrawing.Name = "cboDrawing"
        Me.cboDrawing.RightToLeft = CType(resources.GetObject("cboDrawing.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.cboDrawing.Size = CType(resources.GetObject("cboDrawing.Size"), System.Drawing.Size)
        Me.cboDrawing.TabIndex = CType(resources.GetObject("cboDrawing.TabIndex"), Integer)
        Me.cboDrawing.Text = resources.GetString("cboDrawing.Text")
        Me.cboDrawing.Visible = CType(resources.GetObject("cboDrawing.Visible"), Boolean)
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
        'btnSetColor2
        '
        Me.btnSetColor2.AccessibleDescription = resources.GetString("btnSetColor2.AccessibleDescription")
        Me.btnSetColor2.AccessibleName = resources.GetString("btnSetColor2.AccessibleName")
        Me.btnSetColor2.Anchor = CType(resources.GetObject("btnSetColor2.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnSetColor2.BackgroundImage = CType(resources.GetObject("btnSetColor2.BackgroundImage"), System.Drawing.Image)
        Me.btnSetColor2.Dock = CType(resources.GetObject("btnSetColor2.Dock"), System.Windows.Forms.DockStyle)
        Me.btnSetColor2.Enabled = CType(resources.GetObject("btnSetColor2.Enabled"), Boolean)
        Me.btnSetColor2.FlatStyle = CType(resources.GetObject("btnSetColor2.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnSetColor2.Font = CType(resources.GetObject("btnSetColor2.Font"), System.Drawing.Font)
        Me.btnSetColor2.Image = CType(resources.GetObject("btnSetColor2.Image"), System.Drawing.Image)
        Me.btnSetColor2.ImageAlign = CType(resources.GetObject("btnSetColor2.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnSetColor2.ImageIndex = CType(resources.GetObject("btnSetColor2.ImageIndex"), Integer)
        Me.btnSetColor2.ImeMode = CType(resources.GetObject("btnSetColor2.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnSetColor2.Location = CType(resources.GetObject("btnSetColor2.Location"), System.Drawing.Point)
        Me.btnSetColor2.Name = "btnSetColor2"
        Me.btnSetColor2.RightToLeft = CType(resources.GetObject("btnSetColor2.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnSetColor2.Size = CType(resources.GetObject("btnSetColor2.Size"), System.Drawing.Size)
        Me.btnSetColor2.TabIndex = CType(resources.GetObject("btnSetColor2.TabIndex"), Integer)
        Me.btnSetColor2.Text = resources.GetString("btnSetColor2.Text")
        Me.btnSetColor2.TextAlign = CType(resources.GetObject("btnSetColor2.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnSetColor2.Visible = CType(resources.GetObject("btnSetColor2.Visible"), Boolean)
        '
        'txtColor2
        '
        Me.txtColor2.AccessibleDescription = resources.GetString("txtColor2.AccessibleDescription")
        Me.txtColor2.AccessibleName = resources.GetString("txtColor2.AccessibleName")
        Me.txtColor2.Anchor = CType(resources.GetObject("txtColor2.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtColor2.AutoSize = CType(resources.GetObject("txtColor2.AutoSize"), Boolean)
        Me.txtColor2.BackgroundImage = CType(resources.GetObject("txtColor2.BackgroundImage"), System.Drawing.Image)
        Me.txtColor2.Dock = CType(resources.GetObject("txtColor2.Dock"), System.Windows.Forms.DockStyle)
        Me.txtColor2.Enabled = CType(resources.GetObject("txtColor2.Enabled"), Boolean)
        Me.txtColor2.Font = CType(resources.GetObject("txtColor2.Font"), System.Drawing.Font)
        Me.txtColor2.ImeMode = CType(resources.GetObject("txtColor2.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtColor2.Location = CType(resources.GetObject("txtColor2.Location"), System.Drawing.Point)
        Me.txtColor2.MaxLength = CType(resources.GetObject("txtColor2.MaxLength"), Integer)
        Me.txtColor2.Multiline = CType(resources.GetObject("txtColor2.Multiline"), Boolean)
        Me.txtColor2.Name = "txtColor2"
        Me.txtColor2.PasswordChar = CType(resources.GetObject("txtColor2.PasswordChar"), Char)
        Me.txtColor2.RightToLeft = CType(resources.GetObject("txtColor2.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtColor2.ScrollBars = CType(resources.GetObject("txtColor2.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtColor2.Size = CType(resources.GetObject("txtColor2.Size"), System.Drawing.Size)
        Me.txtColor2.TabIndex = CType(resources.GetObject("txtColor2.TabIndex"), Integer)
        Me.txtColor2.Text = resources.GetString("txtColor2.Text")
        Me.txtColor2.TextAlign = CType(resources.GetObject("txtColor2.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtColor2.Visible = CType(resources.GetObject("txtColor2.Visible"), Boolean)
        Me.txtColor2.WordWrap = CType(resources.GetObject("txtColor2.WordWrap"), Boolean)
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
        'cboBrushSize
        '
        Me.cboBrushSize.AccessibleDescription = resources.GetString("cboBrushSize.AccessibleDescription")
        Me.cboBrushSize.AccessibleName = resources.GetString("cboBrushSize.AccessibleName")
        Me.cboBrushSize.Anchor = CType(resources.GetObject("cboBrushSize.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.cboBrushSize.BackgroundImage = CType(resources.GetObject("cboBrushSize.BackgroundImage"), System.Drawing.Image)
        Me.cboBrushSize.Dock = CType(resources.GetObject("cboBrushSize.Dock"), System.Windows.Forms.DockStyle)
        Me.cboBrushSize.Enabled = CType(resources.GetObject("cboBrushSize.Enabled"), Boolean)
        Me.cboBrushSize.Font = CType(resources.GetObject("cboBrushSize.Font"), System.Drawing.Font)
        Me.cboBrushSize.ImeMode = CType(resources.GetObject("cboBrushSize.ImeMode"), System.Windows.Forms.ImeMode)
        Me.cboBrushSize.IntegralHeight = CType(resources.GetObject("cboBrushSize.IntegralHeight"), Boolean)
        Me.cboBrushSize.ItemHeight = CType(resources.GetObject("cboBrushSize.ItemHeight"), Integer)
        Me.cboBrushSize.Items.AddRange(New Object() {resources.GetString("cboBrushSize.Items.Items"), resources.GetString("cboBrushSize.Items.Items1"), resources.GetString("cboBrushSize.Items.Items2")})
        Me.cboBrushSize.Location = CType(resources.GetObject("cboBrushSize.Location"), System.Drawing.Point)
        Me.cboBrushSize.MaxDropDownItems = CType(resources.GetObject("cboBrushSize.MaxDropDownItems"), Integer)
        Me.cboBrushSize.MaxLength = CType(resources.GetObject("cboBrushSize.MaxLength"), Integer)
        Me.cboBrushSize.Name = "cboBrushSize"
        Me.cboBrushSize.RightToLeft = CType(resources.GetObject("cboBrushSize.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.cboBrushSize.Size = CType(resources.GetObject("cboBrushSize.Size"), System.Drawing.Size)
        Me.cboBrushSize.TabIndex = CType(resources.GetObject("cboBrushSize.TabIndex"), Integer)
        Me.cboBrushSize.Text = resources.GetString("cboBrushSize.Text")
        Me.cboBrushSize.Visible = CType(resources.GetObject("cboBrushSize.Visible"), Boolean)
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
        'cboWrapMode
        '
        Me.cboWrapMode.AccessibleDescription = resources.GetString("cboWrapMode.AccessibleDescription")
        Me.cboWrapMode.AccessibleName = resources.GetString("cboWrapMode.AccessibleName")
        Me.cboWrapMode.Anchor = CType(resources.GetObject("cboWrapMode.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.cboWrapMode.BackgroundImage = CType(resources.GetObject("cboWrapMode.BackgroundImage"), System.Drawing.Image)
        Me.cboWrapMode.Dock = CType(resources.GetObject("cboWrapMode.Dock"), System.Windows.Forms.DockStyle)
        Me.cboWrapMode.Enabled = CType(resources.GetObject("cboWrapMode.Enabled"), Boolean)
        Me.cboWrapMode.Font = CType(resources.GetObject("cboWrapMode.Font"), System.Drawing.Font)
        Me.cboWrapMode.ImeMode = CType(resources.GetObject("cboWrapMode.ImeMode"), System.Windows.Forms.ImeMode)
        Me.cboWrapMode.IntegralHeight = CType(resources.GetObject("cboWrapMode.IntegralHeight"), Boolean)
        Me.cboWrapMode.ItemHeight = CType(resources.GetObject("cboWrapMode.ItemHeight"), Integer)
        Me.cboWrapMode.Location = CType(resources.GetObject("cboWrapMode.Location"), System.Drawing.Point)
        Me.cboWrapMode.MaxDropDownItems = CType(resources.GetObject("cboWrapMode.MaxDropDownItems"), Integer)
        Me.cboWrapMode.MaxLength = CType(resources.GetObject("cboWrapMode.MaxLength"), Integer)
        Me.cboWrapMode.Name = "cboWrapMode"
        Me.cboWrapMode.RightToLeft = CType(resources.GetObject("cboWrapMode.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.cboWrapMode.Size = CType(resources.GetObject("cboWrapMode.Size"), System.Drawing.Size)
        Me.cboWrapMode.TabIndex = CType(resources.GetObject("cboWrapMode.TabIndex"), Integer)
        Me.cboWrapMode.Text = resources.GetString("cboWrapMode.Text")
        Me.cboWrapMode.Visible = CType(resources.GetObject("cboWrapMode.Visible"), Boolean)
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
        'sbrDrawingStatus
        '
        Me.sbrDrawingStatus.AccessibleDescription = resources.GetString("sbrDrawingStatus.AccessibleDescription")
        Me.sbrDrawingStatus.AccessibleName = resources.GetString("sbrDrawingStatus.AccessibleName")
        Me.sbrDrawingStatus.Anchor = CType(resources.GetObject("sbrDrawingStatus.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.sbrDrawingStatus.BackgroundImage = CType(resources.GetObject("sbrDrawingStatus.BackgroundImage"), System.Drawing.Image)
        Me.sbrDrawingStatus.Dock = CType(resources.GetObject("sbrDrawingStatus.Dock"), System.Windows.Forms.DockStyle)
        Me.sbrDrawingStatus.Enabled = CType(resources.GetObject("sbrDrawingStatus.Enabled"), Boolean)
        Me.sbrDrawingStatus.Font = CType(resources.GetObject("sbrDrawingStatus.Font"), System.Drawing.Font)
        Me.sbrDrawingStatus.ImeMode = CType(resources.GetObject("sbrDrawingStatus.ImeMode"), System.Windows.Forms.ImeMode)
        Me.sbrDrawingStatus.Location = CType(resources.GetObject("sbrDrawingStatus.Location"), System.Drawing.Point)
        Me.sbrDrawingStatus.Name = "sbrDrawingStatus"
        Me.sbrDrawingStatus.RightToLeft = CType(resources.GetObject("sbrDrawingStatus.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.sbrDrawingStatus.Size = CType(resources.GetObject("sbrDrawingStatus.Size"), System.Drawing.Size)
        Me.sbrDrawingStatus.TabIndex = CType(resources.GetObject("sbrDrawingStatus.TabIndex"), Integer)
        Me.sbrDrawingStatus.Text = resources.GetString("sbrDrawingStatus.Text")
        Me.sbrDrawingStatus.Visible = CType(resources.GetObject("sbrDrawingStatus.Visible"), Boolean)
        '
        'cboHatchStyle
        '
        Me.cboHatchStyle.AccessibleDescription = resources.GetString("cboHatchStyle.AccessibleDescription")
        Me.cboHatchStyle.AccessibleName = resources.GetString("cboHatchStyle.AccessibleName")
        Me.cboHatchStyle.Anchor = CType(resources.GetObject("cboHatchStyle.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.cboHatchStyle.BackgroundImage = CType(resources.GetObject("cboHatchStyle.BackgroundImage"), System.Drawing.Image)
        Me.cboHatchStyle.Dock = CType(resources.GetObject("cboHatchStyle.Dock"), System.Windows.Forms.DockStyle)
        Me.cboHatchStyle.Enabled = CType(resources.GetObject("cboHatchStyle.Enabled"), Boolean)
        Me.cboHatchStyle.Font = CType(resources.GetObject("cboHatchStyle.Font"), System.Drawing.Font)
        Me.cboHatchStyle.ImeMode = CType(resources.GetObject("cboHatchStyle.ImeMode"), System.Windows.Forms.ImeMode)
        Me.cboHatchStyle.IntegralHeight = CType(resources.GetObject("cboHatchStyle.IntegralHeight"), Boolean)
        Me.cboHatchStyle.ItemHeight = CType(resources.GetObject("cboHatchStyle.ItemHeight"), Integer)
        Me.cboHatchStyle.Location = CType(resources.GetObject("cboHatchStyle.Location"), System.Drawing.Point)
        Me.cboHatchStyle.MaxDropDownItems = CType(resources.GetObject("cboHatchStyle.MaxDropDownItems"), Integer)
        Me.cboHatchStyle.MaxLength = CType(resources.GetObject("cboHatchStyle.MaxLength"), Integer)
        Me.cboHatchStyle.Name = "cboHatchStyle"
        Me.cboHatchStyle.RightToLeft = CType(resources.GetObject("cboHatchStyle.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.cboHatchStyle.Size = CType(resources.GetObject("cboHatchStyle.Size"), System.Drawing.Size)
        Me.cboHatchStyle.TabIndex = CType(resources.GetObject("cboHatchStyle.TabIndex"), Integer)
        Me.cboHatchStyle.Text = resources.GetString("cboHatchStyle.Text")
        Me.cboHatchStyle.Visible = CType(resources.GetObject("cboHatchStyle.Visible"), Boolean)
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
        'nudRotation
        '
        Me.nudRotation.AccessibleDescription = resources.GetString("nudRotation.AccessibleDescription")
        Me.nudRotation.AccessibleName = resources.GetString("nudRotation.AccessibleName")
        Me.nudRotation.Anchor = CType(resources.GetObject("nudRotation.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.nudRotation.Dock = CType(resources.GetObject("nudRotation.Dock"), System.Windows.Forms.DockStyle)
        Me.nudRotation.Enabled = CType(resources.GetObject("nudRotation.Enabled"), Boolean)
        Me.nudRotation.Font = CType(resources.GetObject("nudRotation.Font"), System.Drawing.Font)
        Me.nudRotation.ImeMode = CType(resources.GetObject("nudRotation.ImeMode"), System.Windows.Forms.ImeMode)
        Me.nudRotation.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nudRotation.Location = CType(resources.GetObject("nudRotation.Location"), System.Drawing.Point)
        Me.nudRotation.Maximum = New Decimal(New Integer() {180, 0, 0, 0})
        Me.nudRotation.Name = "nudRotation"
        Me.nudRotation.RightToLeft = CType(resources.GetObject("nudRotation.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.nudRotation.Size = CType(resources.GetObject("nudRotation.Size"), System.Drawing.Size)
        Me.nudRotation.TabIndex = CType(resources.GetObject("nudRotation.TabIndex"), Integer)
        Me.nudRotation.TextAlign = CType(resources.GetObject("nudRotation.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.nudRotation.ThousandsSeparator = CType(resources.GetObject("nudRotation.ThousandsSeparator"), Boolean)
        Me.nudRotation.UpDownAlign = CType(resources.GetObject("nudRotation.UpDownAlign"), System.Windows.Forms.LeftRightAlignment)
        Me.nudRotation.Visible = CType(resources.GetObject("nudRotation.Visible"), Boolean)
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
        'nudGradientBlend
        '
        Me.nudGradientBlend.AccessibleDescription = resources.GetString("nudGradientBlend.AccessibleDescription")
        Me.nudGradientBlend.AccessibleName = resources.GetString("nudGradientBlend.AccessibleName")
        Me.nudGradientBlend.Anchor = CType(resources.GetObject("nudGradientBlend.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.nudGradientBlend.DecimalPlaces = 2
        Me.nudGradientBlend.Dock = CType(resources.GetObject("nudGradientBlend.Dock"), System.Windows.Forms.DockStyle)
        Me.nudGradientBlend.Enabled = CType(resources.GetObject("nudGradientBlend.Enabled"), Boolean)
        Me.nudGradientBlend.Font = CType(resources.GetObject("nudGradientBlend.Font"), System.Drawing.Font)
        Me.nudGradientBlend.ImeMode = CType(resources.GetObject("nudGradientBlend.ImeMode"), System.Windows.Forms.ImeMode)
        Me.nudGradientBlend.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.nudGradientBlend.Location = CType(resources.GetObject("nudGradientBlend.Location"), System.Drawing.Point)
        Me.nudGradientBlend.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudGradientBlend.Name = "nudGradientBlend"
        Me.nudGradientBlend.RightToLeft = CType(resources.GetObject("nudGradientBlend.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.nudGradientBlend.Size = CType(resources.GetObject("nudGradientBlend.Size"), System.Drawing.Size)
        Me.nudGradientBlend.TabIndex = CType(resources.GetObject("nudGradientBlend.TabIndex"), Integer)
        Me.nudGradientBlend.TextAlign = CType(resources.GetObject("nudGradientBlend.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.nudGradientBlend.ThousandsSeparator = CType(resources.GetObject("nudGradientBlend.ThousandsSeparator"), Boolean)
        Me.nudGradientBlend.UpDownAlign = CType(resources.GetObject("nudGradientBlend.UpDownAlign"), System.Windows.Forms.LeftRightAlignment)
        Me.nudGradientBlend.Value = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudGradientBlend.Visible = CType(resources.GetObject("nudGradientBlend.Visible"), Boolean)
        '
        'cboGradientMode
        '
        Me.cboGradientMode.AccessibleDescription = resources.GetString("cboGradientMode.AccessibleDescription")
        Me.cboGradientMode.AccessibleName = resources.GetString("cboGradientMode.AccessibleName")
        Me.cboGradientMode.Anchor = CType(resources.GetObject("cboGradientMode.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.cboGradientMode.BackgroundImage = CType(resources.GetObject("cboGradientMode.BackgroundImage"), System.Drawing.Image)
        Me.cboGradientMode.Dock = CType(resources.GetObject("cboGradientMode.Dock"), System.Windows.Forms.DockStyle)
        Me.cboGradientMode.Enabled = CType(resources.GetObject("cboGradientMode.Enabled"), Boolean)
        Me.cboGradientMode.Font = CType(resources.GetObject("cboGradientMode.Font"), System.Drawing.Font)
        Me.cboGradientMode.ImeMode = CType(resources.GetObject("cboGradientMode.ImeMode"), System.Windows.Forms.ImeMode)
        Me.cboGradientMode.IntegralHeight = CType(resources.GetObject("cboGradientMode.IntegralHeight"), Boolean)
        Me.cboGradientMode.ItemHeight = CType(resources.GetObject("cboGradientMode.ItemHeight"), Integer)
        Me.cboGradientMode.Location = CType(resources.GetObject("cboGradientMode.Location"), System.Drawing.Point)
        Me.cboGradientMode.MaxDropDownItems = CType(resources.GetObject("cboGradientMode.MaxDropDownItems"), Integer)
        Me.cboGradientMode.MaxLength = CType(resources.GetObject("cboGradientMode.MaxLength"), Integer)
        Me.cboGradientMode.Name = "cboGradientMode"
        Me.cboGradientMode.RightToLeft = CType(resources.GetObject("cboGradientMode.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.cboGradientMode.Size = CType(resources.GetObject("cboGradientMode.Size"), System.Drawing.Size)
        Me.cboGradientMode.TabIndex = CType(resources.GetObject("cboGradientMode.TabIndex"), Integer)
        Me.cboGradientMode.Text = resources.GetString("cboGradientMode.Text")
        Me.cboGradientMode.Visible = CType(resources.GetObject("cboGradientMode.Visible"), Boolean)
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
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboGradientMode, Me.Label10, Me.Label1, Me.nudGradientBlend, Me.Label9, Me.nudRotation, Me.cboHatchStyle, Me.Label8, Me.sbrDrawingStatus, Me.cboWrapMode, Me.Label7, Me.cboBrushSize, Me.Label6, Me.btnSetColor2, Me.txtColor2, Me.Label5, Me.cboDrawing, Me.Label4, Me.btnSetColor1, Me.txtColor1, Me.Label3, Me.cboBrushType, Me.Label2, Me.picDemoArea})
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
        CType(Me.nudRotation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudGradientBlend, System.ComponentModel.ISupportInitialize).EndInit()
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

    ' This subroutine is used to set the m_Color1 value
    Private Sub btnSetColor1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetColor1.Click
        Dim cdlg As New ColorDialog()

        If cdlg.ShowDialog() = DialogResult.OK Then
            m_Color1 = cdlg.Color
            txtColor1.Text = cdlg.Color.ToString()
            txtColor1.BackColor = cdlg.Color
        End If
    End Sub

    ' This subroutine is used to set the m_Color2 value
    Private Sub btnSetColor2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetColor2.Click
        Dim cdlg As New ColorDialog()

        If cdlg.ShowDialog() = DialogResult.OK Then
            m_Color2 = cdlg.Color
            txtColor2.Text = cdlg.Color.ToString()
            txtColor2.BackColor = cdlg.Color
        End If

    End Sub

    ' This subrouting changes the size of the brush used to draw in 
    '   the PictureBox by defining a new rectange. These rectangles could be
    '   any size, however, for demonstration simplicity, only three were
    '   defined.
    Private Sub cboBrushSize_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBrushSize.SelectedIndexChanged
        Select Case cboBrushSize.Text
            Case "Large"
                ' "Large" takes up all of picDemoArea
                m_BrushSize = New Rectangle(0, 0, _
                    picDemoArea.Width, picDemoArea.Height)
            Case "Medium"
                ' "Medium" breaks up picDemoArea into 4 pieces
                m_BrushSize = New Rectangle(0, 0, _
                    picDemoArea.Width \ 2, picDemoArea.Height \ 2)
            Case "Small"
                ' "Small" breaks up picDemoArea into 16 pieces
                m_BrushSize = New Rectangle(0, 0, _
                    picDemoArea.Width \ 4, picDemoArea.Height \ 4)
        End Select

        ' Call RedrawPicture
        RedrawPicture(cboBrushSize, New EventArgs())

    End Sub


    ' This subroutine ensures that the User Interface is set up properly
    '   and sets some variables to their initial values.
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim i As Integer ' Used for loops

        ' Set the brush size equal to the entire Picture Box area by defualt
        m_BrushSize = New Rectangle(0, 0, picDemoArea.Width, picDemoArea.Height)

        'Fill the combo boxes with appropriate values
        ' Fill the cdoWrapMode combo box with the various WrapMode enum values
        cboWrapMode.Items.Add(WrapMode.Clamp)
        cboWrapMode.Items.Add(WrapMode.Tile)
        cboWrapMode.Items.Add(WrapMode.TileFlipX)
        cboWrapMode.Items.Add(WrapMode.TileFlipY)
        cboWrapMode.Items.Add(WrapMode.TileFlipXY)

        ' Fill the hatch style combo. We can loop though the enumeration
        '   and, since it is an enumeration, we can cast the integer used in
        '   the loop to the actual enumeration. (This is a very handy way
        '   of walking through an enumeration, as long as the enumerations are 
        '   consecutively numbered.)
        ' The HatchStyle.Max value in .NET is incorrect. The actual value is 52.
        Const maxHatchStyle As Integer = 52
        For i = HatchStyle.Min To maxHatchStyle
            cboHatchStyle.Items.Add(CType(i, HatchStyle))
        Next

        ' Fill the available GradientStyles
        cboGradientMode.Items.Add(LinearGradientMode.BackwardDiagonal)
        cboGradientMode.Items.Add(LinearGradientMode.ForwardDiagonal)
        cboGradientMode.Items.Add(LinearGradientMode.Horizontal)
        cboGradientMode.Items.Add(LinearGradientMode.Vertical)

    End Sub


    ' This subroutine provides the meat of the demonstration. It creates one
    '   of 5 types of brushes, and assigns the appropriate user defined parameters
    '   to the brush. The brush is then assigned to m_Brush, which is used to 
    '   draw one of three different shapes.  There is also code to ensure that 
    '   the UI only displays the options that are appropriate for the type
    '   of brush being used.
    ' Please note that this Error Handler handles virtually all of the events
    '   fired by the UI.
    Private Sub RedrawPicture(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBrushType.SelectedIndexChanged, cboDrawing.SelectedIndexChanged, txtColor1.TextChanged, cboWrapMode.SelectedIndexChanged, cboHatchStyle.SelectedIndexChanged, txtColor2.TextChanged, cboGradientMode.SelectedIndexChanged, nudRotation.ValueChanged, nudGradientBlend.ValueChanged

        ' Reset the PictureBox
        picDemoArea.CreateGraphics().Clear(Color.White)
        picDemoArea.Refresh()

        ' Reset the Status Bar
        sbrDrawingStatus.Text = ""

        ' Construct the brush with the user selected properties. One of five
        '   different brushes will be created based on the user selection.
        ' The reason a brush of the specific type is created, and then assigned
        '   to m_Brush, is that Intellisense is available when working with 
        '   the specific brush objects.
        Select Case cboBrushType.Text

            Case "Solid" ' Use a SolidBrush

                ' Update the UI: deactivate and reactivate all the appropriate 
                '   controls for this brush
                Me.cboBrushSize.Enabled = False
                Me.cboHatchStyle.Enabled = False
                Me.cboWrapMode.Enabled = False
                Me.txtColor2.Enabled = False
                Me.btnSetColor2.Enabled = False
                Me.nudGradientBlend.Enabled = False
                Me.nudRotation.Enabled = False
                Me.cboGradientMode.Enabled = False

                ' Create a solid brush based on selected color
                Dim mySolidBrush As New SolidBrush(m_Color1)

                ' Another good way to get a solid brush, if you know the color
                '   you want at design time is to use the Brushes class
                '   For instance, this line builds an AliceBlue brush
                ' m_Brush = Brushes.AliceBlue

                ' Set m_Brush equal to the newly created brush
                m_Brush = mySolidBrush

            Case "Hatch" ' Use a HatchBrush

                ' Update the UI: deactivate and reactivate all the appropriate 
                '   controls for this brush
                Me.cboBrushSize.Enabled = False
                Me.cboHatchStyle.Enabled = True
                Me.cboWrapMode.Enabled = False
                Me.txtColor2.Enabled = True
                Me.btnSetColor2.Enabled = True
                Me.nudGradientBlend.Enabled = False
                Me.nudRotation.Enabled = False
                Me.cboGradientMode.Enabled = False

                ' Create a new HatchBrush using the two colors for 
                '   foreground and background color settings.
                ' Since the HatchStyle property is Read-Only the HatchStyle
                '   must be set at the creation of the HatchBrush
                Dim myHatchBrush As New HatchBrush( _
                    CType(cboHatchStyle.SelectedItem, HatchStyle), _
                    m_Color1, m_Color2)

                ' Set m_Brush equal to the newly created brush
                m_Brush = myHatchBrush

            Case "Texture" ' Use a TextureBrush

                ' Update the UI: deactivate and reactivate all the appropriate 
                '   controls for this brush
                Me.cboBrushSize.Enabled = True
                Me.cboHatchStyle.Enabled = False
                Me.cboWrapMode.Enabled = True
                Me.txtColor2.Enabled = False
                Me.btnSetColor2.Enabled = False
                Me.nudGradientBlend.Enabled = False
                Me.nudRotation.Enabled = True
                Me.cboGradientMode.Enabled = False

                ' Create a new TextureBrush based on a bitmap. This bitmap can
                '   also be a pattern that you have created. 
                ' Be cautious here, since defining a Rectangle large that
                '   that the provided Bitmap will cause an OutOfMemory 
                '   exception to be thrown.
                Dim myTextureBrush As New TextureBrush( _
                    New Bitmap("..\waterlilies.jpg"), m_BrushSize)

                ' The WrapMode determines how the brush will be tiled if it
                '   is not spread over the entire graphic area.
                myTextureBrush.WrapMode = CType(cboWrapMode.SelectedItem, WrapMode)

                ' The RotateTransform method rotates the brush by the user
                '   specified amount
                myTextureBrush.RotateTransform(nudRotation.Value)

                ' You can also use a ScaleTransform to deform the brush
                '   The following cuts the width of brush in half, and
                '   doubles the height.
                'myTextureBrush.ScaleTransform(0.5F, 2.0F)

                ' Set m_Brush equal to the newly created brush
                m_Brush = myTextureBrush

            Case "LinearGradient" ' Use a LinearGradientBrush

                ' Update the UI: deactivate and reactivate all the appropriate 
                '   controls for this brush
                Me.cboBrushSize.Enabled = True
                Me.cboHatchStyle.Enabled = False
                Me.cboWrapMode.Enabled = True
                Me.txtColor2.Enabled = True
                Me.btnSetColor2.Enabled = True
                Me.nudGradientBlend.Enabled = True
                Me.nudRotation.Enabled = True
                Me.cboGradientMode.Enabled = True

                ' Create a new LinearGradientBrush.  The brush is based on 
                '   a size defined by a rectangle, in this case using the
                '   user defined m_BrushSize. Two colors are used defining
                '   the start and end colors of the gradient. (More advanced 
                '   gradients can be built using the Blend property.)
                '   Finally, the LinearGradientMode is defined in the constructor.
                '   An angle can also be used, but for simplicity it is not here.
                Dim myLinearGradientBrush As New LinearGradientBrush( _
                    m_BrushSize, m_Color1, m_Color2, _
                    CType(cboGradientMode.SelectedItem, LinearGradientMode))

                ' The WrapMode determines how the brush will be tiled if it
                '   is not spread over the entire graphic area.
                ' The LinearGradientBrush cannot use the Clamp value for WrapMode
                If CType(cboWrapMode.SelectedItem, WrapMode) <> WrapMode.Clamp Then
                    myLinearGradientBrush.WrapMode = _
                        CType(cboWrapMode.SelectedItem, WrapMode)
                Else
                    Me.sbrDrawingStatus.Text += _
                        "A Linear Gradient Brush cannot use the Clamp WrapMode."
                End If

                ' The RotateTransform method rotates the brush by the user
                '   specified amount
                myLinearGradientBrush.RotateTransform(nudRotation.Value)

                ' You can also use a ScaleTransform to deform the brush
                '   The following cuts the width of brush in half, and
                '   doubles the height.
                'myLinearGradientBrush.ScaleTransform(0.5F, 2.0F)

                ' Set the point where the blending will focus.  Any single 
                ' between 0 and 1 is allowed. The default is one.
                myLinearGradientBrush.SetBlendTriangularShape( _
                    nudGradientBlend.Value)

                ' For more advanced uses, you can use the SetSigmaBellShape
                '   method to set where the center of the gradient occurs.
                'myLinearGradientBrush.SetSigmaBellShape(0.2)

                ' Set m_Brush equal to the newly created brush
                m_Brush = myLinearGradientBrush

            Case "PathGradient" ' Use a PathGradientBrush

                ' Update the UI: deactivate and reactivate all the appropriate 
                '   controls for this brush
                Me.cboBrushSize.Enabled = True
                Me.cboHatchStyle.Enabled = False
                Me.cboWrapMode.Enabled = True
                Me.txtColor2.Enabled = True
                Me.btnSetColor2.Enabled = True
                Me.nudGradientBlend.Enabled = True
                Me.nudRotation.Enabled = True
                Me.cboGradientMode.Enabled = False

                ' Define a set of points to use for the path this gradient will
                '   follow. A GraphicsPath object could also be defined and used
                '   instead. In this case, we're using a simple triangle.
                Dim pathPoint() As Point = {New Point(0, m_BrushSize.Height), _
                        New Point(m_BrushSize.Width, m_BrushSize.Height), _
                        New Point(m_BrushSize.Width, 0)}

                ' Create a new PathGradientBrush based on the path just created.
                '   (Anything not bounded by the path will be transparent, 
                '   instead of containing coloring.)
                Dim myPathGradientBrush As New PathGradientBrush(pathPoint)

                ' Set the Colors for the PathGradient, this is done differently
                '   from other gradients, since differnt colors can be used for 
                '   each side. In this case, only one color is used, but a color
                '   could be assigned to each side of the path.
                ' The CenterColor is the color that the edges blend into.
                myPathGradientBrush.CenterColor = m_Color1
                ' The SurroundColors is an array of colors that defines the
                '   colors around the edge.
                myPathGradientBrush.SurroundColors = New Color() {m_Color2}

                ' For advanced uses, the CenterPoint property can be set 
                '   somewhere other that the center of the path (even outside 
                '   the rectangle bounding the path).
                'myPathGradientBrush.CenterPoint = New PointF(50, 50)

                ' The WrapMode determines how the brush will be tiled if it
                '   is not spread over the entire graphic area.
                myPathGradientBrush.WrapMode = _
                    CType(cboWrapMode.SelectedItem, WrapMode)

                ' The RotateTransform method rotates the brush by the user
                '   specified amount
                myPathGradientBrush.RotateTransform(nudRotation.Value)

                ' You can also use a ScaleTransform to deform the brush
                '   The following cuts the width of brush in half, and
                '   doubles the height.
                'myPathGradientBrush.ScaleTransform(0.5F, 2.0F)

                ' Set the blending
                myPathGradientBrush.SetBlendTriangularShape( _
                    nudGradientBlend.Value)

                ' For more advanced uses, you can use the SetSigmaBellShape
                '   method to set where the center of the gradient occurs.
                'myPathGradientBrush.SetSigmaBellShape(0.2)

                ' Set m_Brush equal to the newly created brush
                m_Brush = myPathGradientBrush

        End Select

        ' Use the brush to draw the appropriate Drawing in the picDemoArea
        myGraphics = picDemoArea.CreateGraphics()

        ' Select the Type of drawing based on user input
        Select Case cboDrawing.Text
            Case "Fill"
                ' "Fill" fills the entire PictureBox
                myGraphics.FillRectangle(m_Brush, 0, 0, _
                    picDemoArea.Width, picDemoArea.Height)

            Case "Ellipses"
                ' "Ellipses" draws two intesecting ellipses
                myGraphics.FillEllipse(m_Brush, picDemoArea.Width \ 10, _
                    picDemoArea.Height \ 10, picDemoArea.Width \ 2, _
                    picDemoArea.Height \ 2)
                myGraphics.FillEllipse(m_Brush, picDemoArea.Width \ 3, _
                    picDemoArea.Height \ 3, picDemoArea.Width \ 2, _
                    picDemoArea.Height \ 2)
            Case "Lines"
                ' "Lines" draws a series of intersecting lines

                ' First build a Pen based on the brush
                Dim myPen As New Pen(m_Brush, 40)

                ' Now do the drawing from each corner to all other corners
                myGraphics.DrawLine( _
                    myPen, 0, 0, picDemoArea.Width, picDemoArea.Height)
                myGraphics.DrawLine(myPen, 0, 0, 0, picDemoArea.Height)
                myGraphics.DrawLine(myPen, 0, 0, picDemoArea.Width, 0)
                myGraphics.DrawLine(myPen, picDemoArea.Width, 0, _
                    picDemoArea.Width, picDemoArea.Height)
                myGraphics.DrawLine(myPen, 0, picDemoArea.Height, _
                    picDemoArea.Width, picDemoArea.Height)
                myGraphics.DrawLine( _
                    myPen, picDemoArea.Width, 0, 0, picDemoArea.Height)

        End Select

        ' Set the Drawing Status to Success if there weren't any other problems
        If Me.sbrDrawingStatus.Text = "" Then
            Me.sbrDrawingStatus.Text = "Success!"
        End If

    End Sub

End Class