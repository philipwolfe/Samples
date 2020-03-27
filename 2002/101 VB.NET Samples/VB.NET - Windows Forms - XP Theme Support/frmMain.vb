'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Public Class frmMain
    Inherits System.Windows.Forms.Form
    Private entree As String = ""

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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents tabMain As System.Windows.Forms.TabControl
    Friend WithEvents CheckedListBox1 As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents grpMainCourse As System.Windows.Forms.GroupBox
    Friend WithEvents grpCondiments As System.Windows.Forms.GroupBox
    Friend WithEvents chkMustard As System.Windows.Forms.CheckBox
    Friend WithEvents optHamburger As System.Windows.Forms.RadioButton
    Friend WithEvents chkKetchup As System.Windows.Forms.CheckBox
    Friend WithEvents chkMayo As System.Windows.Forms.CheckBox
    Friend WithEvents optCheesburger As System.Windows.Forms.RadioButton
    Friend WithEvents optHotDog As System.Windows.Forms.RadioButton
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents txtLastName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lbl1 As System.Windows.Forms.Label
    Friend WithEvents calArrivalDate As System.Windows.Forms.MonthCalendar
    Friend WithEvents calDepartureDate As System.Windows.Forms.MonthCalendar
    Friend WithEvents cboArrivalCity As System.Windows.Forms.ComboBox
    Friend WithEvents cboDepartureCity As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dudMaleFemale As System.Windows.Forms.DomainUpDown
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnSubmitOrder As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lbl1 = New System.Windows.Forms.Label()
        Me.cboArrivalCity = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.calArrivalDate = New System.Windows.Forms.MonthCalendar()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.cboDepartureCity = New System.Windows.Forms.ComboBox()
        Me.calDepartureDate = New System.Windows.Forms.MonthCalendar()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.btnSubmitOrder = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.optHotDog = New System.Windows.Forms.RadioButton()
        Me.optCheesburger = New System.Windows.Forms.RadioButton()
        Me.chkMayo = New System.Windows.Forms.CheckBox()
        Me.chkKetchup = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkMustard = New System.Windows.Forms.CheckBox()
        Me.optHamburger = New System.Windows.Forms.RadioButton()
        Me.grpMainCourse = New System.Windows.Forms.GroupBox()
        Me.grpCondiments = New System.Windows.Forms.GroupBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.DataGrid1 = New System.Windows.Forms.DataGrid()
        Me.dudMaleFemale = New System.Windows.Forms.DomainUpDown()
        Me.tabMain.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'txtFirstName
        '
        Me.txtFirstName.AccessibleDescription = resources.GetString("txtFirstName.AccessibleDescription")
        Me.txtFirstName.AccessibleName = resources.GetString("txtFirstName.AccessibleName")
        Me.txtFirstName.Anchor = CType(resources.GetObject("txtFirstName.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtFirstName.AutoSize = CType(resources.GetObject("txtFirstName.AutoSize"), Boolean)
        Me.txtFirstName.BackgroundImage = CType(resources.GetObject("txtFirstName.BackgroundImage"), System.Drawing.Image)
        Me.txtFirstName.Dock = CType(resources.GetObject("txtFirstName.Dock"), System.Windows.Forms.DockStyle)
        Me.txtFirstName.Enabled = CType(resources.GetObject("txtFirstName.Enabled"), Boolean)
        Me.txtFirstName.Font = CType(resources.GetObject("txtFirstName.Font"), System.Drawing.Font)
        Me.txtFirstName.ImeMode = CType(resources.GetObject("txtFirstName.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtFirstName.Location = CType(resources.GetObject("txtFirstName.Location"), System.Drawing.Point)
        Me.txtFirstName.MaxLength = CType(resources.GetObject("txtFirstName.MaxLength"), Integer)
        Me.txtFirstName.Multiline = CType(resources.GetObject("txtFirstName.Multiline"), Boolean)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.PasswordChar = CType(resources.GetObject("txtFirstName.PasswordChar"), Char)
        Me.txtFirstName.RightToLeft = CType(resources.GetObject("txtFirstName.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtFirstName.ScrollBars = CType(resources.GetObject("txtFirstName.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtFirstName.Size = CType(resources.GetObject("txtFirstName.Size"), System.Drawing.Size)
        Me.txtFirstName.TabIndex = CType(resources.GetObject("txtFirstName.TabIndex"), Integer)
        Me.txtFirstName.Text = resources.GetString("txtFirstName.Text")
        Me.txtFirstName.TextAlign = CType(resources.GetObject("txtFirstName.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtFirstName.Visible = CType(resources.GetObject("txtFirstName.Visible"), Boolean)
        Me.txtFirstName.WordWrap = CType(resources.GetObject("txtFirstName.WordWrap"), Boolean)
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
        'txtLastName
        '
        Me.txtLastName.AccessibleDescription = resources.GetString("txtLastName.AccessibleDescription")
        Me.txtLastName.AccessibleName = resources.GetString("txtLastName.AccessibleName")
        Me.txtLastName.Anchor = CType(resources.GetObject("txtLastName.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtLastName.AutoSize = CType(resources.GetObject("txtLastName.AutoSize"), Boolean)
        Me.txtLastName.BackgroundImage = CType(resources.GetObject("txtLastName.BackgroundImage"), System.Drawing.Image)
        Me.txtLastName.Dock = CType(resources.GetObject("txtLastName.Dock"), System.Windows.Forms.DockStyle)
        Me.txtLastName.Enabled = CType(resources.GetObject("txtLastName.Enabled"), Boolean)
        Me.txtLastName.Font = CType(resources.GetObject("txtLastName.Font"), System.Drawing.Font)
        Me.txtLastName.ImeMode = CType(resources.GetObject("txtLastName.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtLastName.Location = CType(resources.GetObject("txtLastName.Location"), System.Drawing.Point)
        Me.txtLastName.MaxLength = CType(resources.GetObject("txtLastName.MaxLength"), Integer)
        Me.txtLastName.Multiline = CType(resources.GetObject("txtLastName.Multiline"), Boolean)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.PasswordChar = CType(resources.GetObject("txtLastName.PasswordChar"), Char)
        Me.txtLastName.RightToLeft = CType(resources.GetObject("txtLastName.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtLastName.ScrollBars = CType(resources.GetObject("txtLastName.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtLastName.Size = CType(resources.GetObject("txtLastName.Size"), System.Drawing.Size)
        Me.txtLastName.TabIndex = CType(resources.GetObject("txtLastName.TabIndex"), Integer)
        Me.txtLastName.Text = resources.GetString("txtLastName.Text")
        Me.txtLastName.TextAlign = CType(resources.GetObject("txtLastName.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtLastName.Visible = CType(resources.GetObject("txtLastName.Visible"), Boolean)
        Me.txtLastName.WordWrap = CType(resources.GetObject("txtLastName.WordWrap"), Boolean)
        '
        'tabMain
        '
        Me.tabMain.AccessibleDescription = CType(resources.GetObject("tabMain.AccessibleDescription"), String)
        Me.tabMain.AccessibleName = CType(resources.GetObject("tabMain.AccessibleName"), String)
        Me.tabMain.Alignment = CType(resources.GetObject("tabMain.Alignment"), System.Windows.Forms.TabAlignment)
        Me.tabMain.Anchor = CType(resources.GetObject("tabMain.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.tabMain.Appearance = CType(resources.GetObject("tabMain.Appearance"), System.Windows.Forms.TabAppearance)
        Me.tabMain.BackgroundImage = CType(resources.GetObject("tabMain.BackgroundImage"), System.Drawing.Image)
        Me.tabMain.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabPage1, Me.TabPage3, Me.TabPage2})
        Me.tabMain.Dock = CType(resources.GetObject("tabMain.Dock"), System.Windows.Forms.DockStyle)
        Me.tabMain.Enabled = CType(resources.GetObject("tabMain.Enabled"), Boolean)
        Me.tabMain.Font = CType(resources.GetObject("tabMain.Font"), System.Drawing.Font)
        Me.tabMain.ImeMode = CType(resources.GetObject("tabMain.ImeMode"), System.Windows.Forms.ImeMode)
        Me.tabMain.ItemSize = CType(resources.GetObject("tabMain.ItemSize"), System.Drawing.Size)
        Me.tabMain.Location = CType(resources.GetObject("tabMain.Location"), System.Drawing.Point)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.Padding = CType(resources.GetObject("tabMain.Padding"), System.Drawing.Point)
        Me.tabMain.RightToLeft = CType(resources.GetObject("tabMain.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.tabMain.SelectedIndex = 0
        Me.tabMain.ShowToolTips = CType(resources.GetObject("tabMain.ShowToolTips"), Boolean)
        Me.tabMain.Size = CType(resources.GetObject("tabMain.Size"), System.Drawing.Size)
        Me.tabMain.TabIndex = CType(resources.GetObject("tabMain.TabIndex"), Integer)
        Me.tabMain.Text = resources.GetString("tabMain.Text")
        Me.tabMain.Visible = CType(resources.GetObject("tabMain.Visible"), Boolean)
        '
        'TabPage1
        '
        Me.TabPage1.AccessibleDescription = CType(resources.GetObject("TabPage1.AccessibleDescription"), String)
        Me.TabPage1.AccessibleName = CType(resources.GetObject("TabPage1.AccessibleName"), String)
        Me.TabPage1.Anchor = CType(resources.GetObject("TabPage1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.TabPage1.AutoScroll = CType(resources.GetObject("TabPage1.AutoScroll"), Boolean)
        Me.TabPage1.AutoScrollMargin = CType(resources.GetObject("TabPage1.AutoScrollMargin"), System.Drawing.Size)
        Me.TabPage1.AutoScrollMinSize = CType(resources.GetObject("TabPage1.AutoScrollMinSize"), System.Drawing.Size)
        Me.TabPage1.BackgroundImage = CType(resources.GetObject("TabPage1.BackgroundImage"), System.Drawing.Image)
        Me.TabPage1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label11, Me.lbl1, Me.cboArrivalCity, Me.Label8, Me.Label3, Me.Label7, Me.Label6, Me.calArrivalDate, Me.ListBox1, Me.cboDepartureCity, Me.calDepartureDate, Me.Label1, Me.txtFirstName, Me.Label2, Me.txtLastName})
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
        Me.TabPage1.Tag = "Supported_Controls"
        Me.TabPage1.Text = resources.GetString("TabPage1.Text")
        Me.TabPage1.ToolTipText = resources.GetString("TabPage1.ToolTipText")
        Me.TabPage1.Visible = CType(resources.GetObject("TabPage1.Visible"), Boolean)
        '
        'Label11
        '
        Me.Label11.AccessibleDescription = CType(resources.GetObject("Label11.AccessibleDescription"), String)
        Me.Label11.AccessibleName = CType(resources.GetObject("Label11.AccessibleName"), String)
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
        'lbl1
        '
        Me.lbl1.AccessibleDescription = CType(resources.GetObject("lbl1.AccessibleDescription"), String)
        Me.lbl1.AccessibleName = CType(resources.GetObject("lbl1.AccessibleName"), String)
        Me.lbl1.Anchor = CType(resources.GetObject("lbl1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lbl1.AutoSize = CType(resources.GetObject("lbl1.AutoSize"), Boolean)
        Me.lbl1.Dock = CType(resources.GetObject("lbl1.Dock"), System.Windows.Forms.DockStyle)
        Me.lbl1.Enabled = CType(resources.GetObject("lbl1.Enabled"), Boolean)
        Me.lbl1.Font = CType(resources.GetObject("lbl1.Font"), System.Drawing.Font)
        Me.lbl1.Image = CType(resources.GetObject("lbl1.Image"), System.Drawing.Image)
        Me.lbl1.ImageAlign = CType(resources.GetObject("lbl1.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lbl1.ImageIndex = CType(resources.GetObject("lbl1.ImageIndex"), Integer)
        Me.lbl1.ImeMode = CType(resources.GetObject("lbl1.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lbl1.Location = CType(resources.GetObject("lbl1.Location"), System.Drawing.Point)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.RightToLeft = CType(resources.GetObject("lbl1.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lbl1.Size = CType(resources.GetObject("lbl1.Size"), System.Drawing.Size)
        Me.lbl1.TabIndex = CType(resources.GetObject("lbl1.TabIndex"), Integer)
        Me.lbl1.Text = resources.GetString("lbl1.Text")
        Me.lbl1.TextAlign = CType(resources.GetObject("lbl1.TextAlign"), System.Drawing.ContentAlignment)
        Me.lbl1.Visible = CType(resources.GetObject("lbl1.Visible"), Boolean)
        '
        'cboArrivalCity
        '
        Me.cboArrivalCity.AccessibleDescription = resources.GetString("cboArrivalCity.AccessibleDescription")
        Me.cboArrivalCity.AccessibleName = resources.GetString("cboArrivalCity.AccessibleName")
        Me.cboArrivalCity.Anchor = CType(resources.GetObject("cboArrivalCity.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.cboArrivalCity.BackgroundImage = CType(resources.GetObject("cboArrivalCity.BackgroundImage"), System.Drawing.Image)
        Me.cboArrivalCity.Dock = CType(resources.GetObject("cboArrivalCity.Dock"), System.Windows.Forms.DockStyle)
        Me.cboArrivalCity.Enabled = CType(resources.GetObject("cboArrivalCity.Enabled"), Boolean)
        Me.cboArrivalCity.Font = CType(resources.GetObject("cboArrivalCity.Font"), System.Drawing.Font)
        Me.cboArrivalCity.ImeMode = CType(resources.GetObject("cboArrivalCity.ImeMode"), System.Windows.Forms.ImeMode)
        Me.cboArrivalCity.IntegralHeight = CType(resources.GetObject("cboArrivalCity.IntegralHeight"), Boolean)
        Me.cboArrivalCity.ItemHeight = CType(resources.GetObject("cboArrivalCity.ItemHeight"), Integer)
        Me.cboArrivalCity.Items.AddRange(New Object() {resources.GetString("cboArrivalCity.Items.Items"), resources.GetString("cboArrivalCity.Items.Items1"), resources.GetString("cboArrivalCity.Items.Items2"), resources.GetString("cboArrivalCity.Items.Items3"), resources.GetString("cboArrivalCity.Items.Items4")})
        Me.cboArrivalCity.Location = CType(resources.GetObject("cboArrivalCity.Location"), System.Drawing.Point)
        Me.cboArrivalCity.MaxDropDownItems = CType(resources.GetObject("cboArrivalCity.MaxDropDownItems"), Integer)
        Me.cboArrivalCity.MaxLength = CType(resources.GetObject("cboArrivalCity.MaxLength"), Integer)
        Me.cboArrivalCity.Name = "cboArrivalCity"
        Me.cboArrivalCity.RightToLeft = CType(resources.GetObject("cboArrivalCity.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.cboArrivalCity.Size = CType(resources.GetObject("cboArrivalCity.Size"), System.Drawing.Size)
        Me.cboArrivalCity.TabIndex = CType(resources.GetObject("cboArrivalCity.TabIndex"), Integer)
        Me.cboArrivalCity.Text = resources.GetString("cboArrivalCity.Text")
        Me.cboArrivalCity.Visible = CType(resources.GetObject("cboArrivalCity.Visible"), Boolean)
        '
        'Label8
        '
        Me.Label8.AccessibleDescription = CType(resources.GetObject("Label8.AccessibleDescription"), String)
        Me.Label8.AccessibleName = CType(resources.GetObject("Label8.AccessibleName"), String)
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
        'Label7
        '
        Me.Label7.AccessibleDescription = CType(resources.GetObject("Label7.AccessibleDescription"), String)
        Me.Label7.AccessibleName = CType(resources.GetObject("Label7.AccessibleName"), String)
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
        'calArrivalDate
        '
        Me.calArrivalDate.AccessibleDescription = resources.GetString("calArrivalDate.AccessibleDescription")
        Me.calArrivalDate.AccessibleName = resources.GetString("calArrivalDate.AccessibleName")
        Me.calArrivalDate.Anchor = CType(resources.GetObject("calArrivalDate.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.calArrivalDate.AnnuallyBoldedDates = CType(resources.GetObject("calArrivalDate.AnnuallyBoldedDates"), Date())
        Me.calArrivalDate.BackgroundImage = CType(resources.GetObject("calArrivalDate.BackgroundImage"), System.Drawing.Image)
        Me.calArrivalDate.BoldedDates = CType(resources.GetObject("calArrivalDate.BoldedDates"), Date())
        Me.calArrivalDate.CalendarDimensions = CType(resources.GetObject("calArrivalDate.CalendarDimensions"), System.Drawing.Size)
        Me.calArrivalDate.Dock = CType(resources.GetObject("calArrivalDate.Dock"), System.Windows.Forms.DockStyle)
        Me.calArrivalDate.Enabled = CType(resources.GetObject("calArrivalDate.Enabled"), Boolean)
        Me.calArrivalDate.FirstDayOfWeek = CType(resources.GetObject("calArrivalDate.FirstDayOfWeek"), System.Windows.Forms.Day)
        Me.calArrivalDate.Font = CType(resources.GetObject("calArrivalDate.Font"), System.Drawing.Font)
        Me.calArrivalDate.ImeMode = CType(resources.GetObject("calArrivalDate.ImeMode"), System.Windows.Forms.ImeMode)
        Me.calArrivalDate.Location = CType(resources.GetObject("calArrivalDate.Location"), System.Drawing.Point)
        Me.calArrivalDate.MonthlyBoldedDates = CType(resources.GetObject("calArrivalDate.MonthlyBoldedDates"), Date())
        Me.calArrivalDate.Name = "calArrivalDate"
        Me.calArrivalDate.RightToLeft = CType(resources.GetObject("calArrivalDate.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.calArrivalDate.ShowWeekNumbers = CType(resources.GetObject("calArrivalDate.ShowWeekNumbers"), Boolean)
        Me.calArrivalDate.Size = CType(resources.GetObject("calArrivalDate.Size"), System.Drawing.Size)
        Me.calArrivalDate.TabIndex = CType(resources.GetObject("calArrivalDate.TabIndex"), Integer)
        Me.calArrivalDate.Visible = CType(resources.GetObject("calArrivalDate.Visible"), Boolean)
        '
        'ListBox1
        '
        Me.ListBox1.AccessibleDescription = resources.GetString("ListBox1.AccessibleDescription")
        Me.ListBox1.AccessibleName = resources.GetString("ListBox1.AccessibleName")
        Me.ListBox1.Anchor = CType(resources.GetObject("ListBox1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.ListBox1.BackgroundImage = CType(resources.GetObject("ListBox1.BackgroundImage"), System.Drawing.Image)
        Me.ListBox1.ColumnWidth = CType(resources.GetObject("ListBox1.ColumnWidth"), Integer)
        Me.ListBox1.Dock = CType(resources.GetObject("ListBox1.Dock"), System.Windows.Forms.DockStyle)
        Me.ListBox1.Enabled = CType(resources.GetObject("ListBox1.Enabled"), Boolean)
        Me.ListBox1.Font = CType(resources.GetObject("ListBox1.Font"), System.Drawing.Font)
        Me.ListBox1.HorizontalExtent = CType(resources.GetObject("ListBox1.HorizontalExtent"), Integer)
        Me.ListBox1.HorizontalScrollbar = CType(resources.GetObject("ListBox1.HorizontalScrollbar"), Boolean)
        Me.ListBox1.ImeMode = CType(resources.GetObject("ListBox1.ImeMode"), System.Windows.Forms.ImeMode)
        Me.ListBox1.IntegralHeight = CType(resources.GetObject("ListBox1.IntegralHeight"), Boolean)
        Me.ListBox1.ItemHeight = CType(resources.GetObject("ListBox1.ItemHeight"), Integer)
        Me.ListBox1.Items.AddRange(New Object() {resources.GetString("ListBox1.Items.Items"), resources.GetString("ListBox1.Items.Items1"), resources.GetString("ListBox1.Items.Items2")})
        Me.ListBox1.Location = CType(resources.GetObject("ListBox1.Location"), System.Drawing.Point)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.RightToLeft = CType(resources.GetObject("ListBox1.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.ListBox1.ScrollAlwaysVisible = CType(resources.GetObject("ListBox1.ScrollAlwaysVisible"), Boolean)
        Me.ListBox1.Size = CType(resources.GetObject("ListBox1.Size"), System.Drawing.Size)
        Me.ListBox1.TabIndex = CType(resources.GetObject("ListBox1.TabIndex"), Integer)
        Me.ListBox1.Visible = CType(resources.GetObject("ListBox1.Visible"), Boolean)
        '
        'cboDepartureCity
        '
        Me.cboDepartureCity.AccessibleDescription = resources.GetString("cboDepartureCity.AccessibleDescription")
        Me.cboDepartureCity.AccessibleName = resources.GetString("cboDepartureCity.AccessibleName")
        Me.cboDepartureCity.Anchor = CType(resources.GetObject("cboDepartureCity.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.cboDepartureCity.BackgroundImage = CType(resources.GetObject("cboDepartureCity.BackgroundImage"), System.Drawing.Image)
        Me.cboDepartureCity.Dock = CType(resources.GetObject("cboDepartureCity.Dock"), System.Windows.Forms.DockStyle)
        Me.cboDepartureCity.Enabled = CType(resources.GetObject("cboDepartureCity.Enabled"), Boolean)
        Me.cboDepartureCity.Font = CType(resources.GetObject("cboDepartureCity.Font"), System.Drawing.Font)
        Me.cboDepartureCity.ImeMode = CType(resources.GetObject("cboDepartureCity.ImeMode"), System.Windows.Forms.ImeMode)
        Me.cboDepartureCity.IntegralHeight = CType(resources.GetObject("cboDepartureCity.IntegralHeight"), Boolean)
        Me.cboDepartureCity.ItemHeight = CType(resources.GetObject("cboDepartureCity.ItemHeight"), Integer)
        Me.cboDepartureCity.Items.AddRange(New Object() {resources.GetString("cboDepartureCity.Items.Items"), resources.GetString("cboDepartureCity.Items.Items1"), resources.GetString("cboDepartureCity.Items.Items2"), resources.GetString("cboDepartureCity.Items.Items3"), resources.GetString("cboDepartureCity.Items.Items4")})
        Me.cboDepartureCity.Location = CType(resources.GetObject("cboDepartureCity.Location"), System.Drawing.Point)
        Me.cboDepartureCity.MaxDropDownItems = CType(resources.GetObject("cboDepartureCity.MaxDropDownItems"), Integer)
        Me.cboDepartureCity.MaxLength = CType(resources.GetObject("cboDepartureCity.MaxLength"), Integer)
        Me.cboDepartureCity.Name = "cboDepartureCity"
        Me.cboDepartureCity.RightToLeft = CType(resources.GetObject("cboDepartureCity.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.cboDepartureCity.Size = CType(resources.GetObject("cboDepartureCity.Size"), System.Drawing.Size)
        Me.cboDepartureCity.TabIndex = CType(resources.GetObject("cboDepartureCity.TabIndex"), Integer)
        Me.cboDepartureCity.Text = resources.GetString("cboDepartureCity.Text")
        Me.cboDepartureCity.Visible = CType(resources.GetObject("cboDepartureCity.Visible"), Boolean)
        '
        'calDepartureDate
        '
        Me.calDepartureDate.AccessibleDescription = resources.GetString("calDepartureDate.AccessibleDescription")
        Me.calDepartureDate.AccessibleName = resources.GetString("calDepartureDate.AccessibleName")
        Me.calDepartureDate.Anchor = CType(resources.GetObject("calDepartureDate.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.calDepartureDate.AnnuallyBoldedDates = CType(resources.GetObject("calDepartureDate.AnnuallyBoldedDates"), Date())
        Me.calDepartureDate.BackgroundImage = CType(resources.GetObject("calDepartureDate.BackgroundImage"), System.Drawing.Image)
        Me.calDepartureDate.BoldedDates = CType(resources.GetObject("calDepartureDate.BoldedDates"), Date())
        Me.calDepartureDate.CalendarDimensions = CType(resources.GetObject("calDepartureDate.CalendarDimensions"), System.Drawing.Size)
        Me.calDepartureDate.Dock = CType(resources.GetObject("calDepartureDate.Dock"), System.Windows.Forms.DockStyle)
        Me.calDepartureDate.Enabled = CType(resources.GetObject("calDepartureDate.Enabled"), Boolean)
        Me.calDepartureDate.FirstDayOfWeek = CType(resources.GetObject("calDepartureDate.FirstDayOfWeek"), System.Windows.Forms.Day)
        Me.calDepartureDate.Font = CType(resources.GetObject("calDepartureDate.Font"), System.Drawing.Font)
        Me.calDepartureDate.ImeMode = CType(resources.GetObject("calDepartureDate.ImeMode"), System.Windows.Forms.ImeMode)
        Me.calDepartureDate.Location = CType(resources.GetObject("calDepartureDate.Location"), System.Drawing.Point)
        Me.calDepartureDate.MonthlyBoldedDates = CType(resources.GetObject("calDepartureDate.MonthlyBoldedDates"), Date())
        Me.calDepartureDate.Name = "calDepartureDate"
        Me.calDepartureDate.RightToLeft = CType(resources.GetObject("calDepartureDate.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.calDepartureDate.ShowWeekNumbers = CType(resources.GetObject("calDepartureDate.ShowWeekNumbers"), Boolean)
        Me.calDepartureDate.Size = CType(resources.GetObject("calDepartureDate.Size"), System.Drawing.Size)
        Me.calDepartureDate.TabIndex = CType(resources.GetObject("calDepartureDate.TabIndex"), Integer)
        Me.calDepartureDate.Visible = CType(resources.GetObject("calDepartureDate.Visible"), Boolean)
        '
        'TabPage3
        '
        Me.TabPage3.AccessibleDescription = CType(resources.GetObject("TabPage3.AccessibleDescription"), String)
        Me.TabPage3.AccessibleName = CType(resources.GetObject("TabPage3.AccessibleName"), String)
        Me.TabPage3.Anchor = CType(resources.GetObject("TabPage3.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.TabPage3.AutoScroll = CType(resources.GetObject("TabPage3.AutoScroll"), Boolean)
        Me.TabPage3.AutoScrollMargin = CType(resources.GetObject("TabPage3.AutoScrollMargin"), System.Drawing.Size)
        Me.TabPage3.AutoScrollMinSize = CType(resources.GetObject("TabPage3.AutoScrollMinSize"), System.Drawing.Size)
        Me.TabPage3.BackgroundImage = CType(resources.GetObject("TabPage3.BackgroundImage"), System.Drawing.Image)
        Me.TabPage3.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnSubmitOrder, Me.Label10, Me.optHotDog, Me.optCheesburger, Me.chkMayo, Me.chkKetchup, Me.Label5, Me.Label4, Me.chkMustard, Me.optHamburger, Me.grpMainCourse, Me.grpCondiments})
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
        Me.TabPage3.Tag = "Requires_Flat_Style_Set"
        Me.TabPage3.Text = resources.GetString("TabPage3.Text")
        Me.TabPage3.ToolTipText = resources.GetString("TabPage3.ToolTipText")
        Me.TabPage3.Visible = CType(resources.GetObject("TabPage3.Visible"), Boolean)
        '
        'btnSubmitOrder
        '
        Me.btnSubmitOrder.AccessibleDescription = resources.GetString("btnSubmitOrder.AccessibleDescription")
        Me.btnSubmitOrder.AccessibleName = resources.GetString("btnSubmitOrder.AccessibleName")
        Me.btnSubmitOrder.Anchor = CType(resources.GetObject("btnSubmitOrder.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnSubmitOrder.BackgroundImage = CType(resources.GetObject("btnSubmitOrder.BackgroundImage"), System.Drawing.Image)
        Me.btnSubmitOrder.Dock = CType(resources.GetObject("btnSubmitOrder.Dock"), System.Windows.Forms.DockStyle)
        Me.btnSubmitOrder.Enabled = CType(resources.GetObject("btnSubmitOrder.Enabled"), Boolean)
        Me.btnSubmitOrder.FlatStyle = CType(resources.GetObject("btnSubmitOrder.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnSubmitOrder.Font = CType(resources.GetObject("btnSubmitOrder.Font"), System.Drawing.Font)
        Me.btnSubmitOrder.Image = CType(resources.GetObject("btnSubmitOrder.Image"), System.Drawing.Image)
        Me.btnSubmitOrder.ImageAlign = CType(resources.GetObject("btnSubmitOrder.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnSubmitOrder.ImageIndex = CType(resources.GetObject("btnSubmitOrder.ImageIndex"), Integer)
        Me.btnSubmitOrder.ImeMode = CType(resources.GetObject("btnSubmitOrder.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnSubmitOrder.Location = CType(resources.GetObject("btnSubmitOrder.Location"), System.Drawing.Point)
        Me.btnSubmitOrder.Name = "btnSubmitOrder"
        Me.btnSubmitOrder.RightToLeft = CType(resources.GetObject("btnSubmitOrder.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnSubmitOrder.Size = CType(resources.GetObject("btnSubmitOrder.Size"), System.Drawing.Size)
        Me.btnSubmitOrder.TabIndex = CType(resources.GetObject("btnSubmitOrder.TabIndex"), Integer)
        Me.btnSubmitOrder.Text = resources.GetString("btnSubmitOrder.Text")
        Me.btnSubmitOrder.TextAlign = CType(resources.GetObject("btnSubmitOrder.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnSubmitOrder.Visible = CType(resources.GetObject("btnSubmitOrder.Visible"), Boolean)
        '
        'Label10
        '
        Me.Label10.AccessibleDescription = CType(resources.GetObject("Label10.AccessibleDescription"), String)
        Me.Label10.AccessibleName = CType(resources.GetObject("Label10.AccessibleName"), String)
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
        'optHotDog
        '
        Me.optHotDog.AccessibleDescription = resources.GetString("optHotDog.AccessibleDescription")
        Me.optHotDog.AccessibleName = resources.GetString("optHotDog.AccessibleName")
        Me.optHotDog.Anchor = CType(resources.GetObject("optHotDog.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.optHotDog.Appearance = CType(resources.GetObject("optHotDog.Appearance"), System.Windows.Forms.Appearance)
        Me.optHotDog.BackgroundImage = CType(resources.GetObject("optHotDog.BackgroundImage"), System.Drawing.Image)
        Me.optHotDog.CheckAlign = CType(resources.GetObject("optHotDog.CheckAlign"), System.Drawing.ContentAlignment)
        Me.optHotDog.Dock = CType(resources.GetObject("optHotDog.Dock"), System.Windows.Forms.DockStyle)
        Me.optHotDog.Enabled = CType(resources.GetObject("optHotDog.Enabled"), Boolean)
        Me.optHotDog.FlatStyle = CType(resources.GetObject("optHotDog.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.optHotDog.Font = CType(resources.GetObject("optHotDog.Font"), System.Drawing.Font)
        Me.optHotDog.Image = CType(resources.GetObject("optHotDog.Image"), System.Drawing.Image)
        Me.optHotDog.ImageAlign = CType(resources.GetObject("optHotDog.ImageAlign"), System.Drawing.ContentAlignment)
        Me.optHotDog.ImageIndex = CType(resources.GetObject("optHotDog.ImageIndex"), Integer)
        Me.optHotDog.ImeMode = CType(resources.GetObject("optHotDog.ImeMode"), System.Windows.Forms.ImeMode)
        Me.optHotDog.Location = CType(resources.GetObject("optHotDog.Location"), System.Drawing.Point)
        Me.optHotDog.Name = "optHotDog"
        Me.optHotDog.RightToLeft = CType(resources.GetObject("optHotDog.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.optHotDog.Size = CType(resources.GetObject("optHotDog.Size"), System.Drawing.Size)
        Me.optHotDog.TabIndex = CType(resources.GetObject("optHotDog.TabIndex"), Integer)
        Me.optHotDog.Text = resources.GetString("optHotDog.Text")
        Me.optHotDog.TextAlign = CType(resources.GetObject("optHotDog.TextAlign"), System.Drawing.ContentAlignment)
        Me.optHotDog.Visible = CType(resources.GetObject("optHotDog.Visible"), Boolean)
        '
        'optCheesburger
        '
        Me.optCheesburger.AccessibleDescription = resources.GetString("optCheesburger.AccessibleDescription")
        Me.optCheesburger.AccessibleName = resources.GetString("optCheesburger.AccessibleName")
        Me.optCheesburger.Anchor = CType(resources.GetObject("optCheesburger.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.optCheesburger.Appearance = CType(resources.GetObject("optCheesburger.Appearance"), System.Windows.Forms.Appearance)
        Me.optCheesburger.BackgroundImage = CType(resources.GetObject("optCheesburger.BackgroundImage"), System.Drawing.Image)
        Me.optCheesburger.CheckAlign = CType(resources.GetObject("optCheesburger.CheckAlign"), System.Drawing.ContentAlignment)
        Me.optCheesburger.Dock = CType(resources.GetObject("optCheesburger.Dock"), System.Windows.Forms.DockStyle)
        Me.optCheesburger.Enabled = CType(resources.GetObject("optCheesburger.Enabled"), Boolean)
        Me.optCheesburger.FlatStyle = CType(resources.GetObject("optCheesburger.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.optCheesburger.Font = CType(resources.GetObject("optCheesburger.Font"), System.Drawing.Font)
        Me.optCheesburger.Image = CType(resources.GetObject("optCheesburger.Image"), System.Drawing.Image)
        Me.optCheesburger.ImageAlign = CType(resources.GetObject("optCheesburger.ImageAlign"), System.Drawing.ContentAlignment)
        Me.optCheesburger.ImageIndex = CType(resources.GetObject("optCheesburger.ImageIndex"), Integer)
        Me.optCheesburger.ImeMode = CType(resources.GetObject("optCheesburger.ImeMode"), System.Windows.Forms.ImeMode)
        Me.optCheesburger.Location = CType(resources.GetObject("optCheesburger.Location"), System.Drawing.Point)
        Me.optCheesburger.Name = "optCheesburger"
        Me.optCheesburger.RightToLeft = CType(resources.GetObject("optCheesburger.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.optCheesburger.Size = CType(resources.GetObject("optCheesburger.Size"), System.Drawing.Size)
        Me.optCheesburger.TabIndex = CType(resources.GetObject("optCheesburger.TabIndex"), Integer)
        Me.optCheesburger.Text = resources.GetString("optCheesburger.Text")
        Me.optCheesburger.TextAlign = CType(resources.GetObject("optCheesburger.TextAlign"), System.Drawing.ContentAlignment)
        Me.optCheesburger.Visible = CType(resources.GetObject("optCheesburger.Visible"), Boolean)
        '
        'chkMayo
        '
        Me.chkMayo.AccessibleDescription = resources.GetString("chkMayo.AccessibleDescription")
        Me.chkMayo.AccessibleName = resources.GetString("chkMayo.AccessibleName")
        Me.chkMayo.Anchor = CType(resources.GetObject("chkMayo.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.chkMayo.Appearance = CType(resources.GetObject("chkMayo.Appearance"), System.Windows.Forms.Appearance)
        Me.chkMayo.BackgroundImage = CType(resources.GetObject("chkMayo.BackgroundImage"), System.Drawing.Image)
        Me.chkMayo.CheckAlign = CType(resources.GetObject("chkMayo.CheckAlign"), System.Drawing.ContentAlignment)
        Me.chkMayo.Dock = CType(resources.GetObject("chkMayo.Dock"), System.Windows.Forms.DockStyle)
        Me.chkMayo.Enabled = CType(resources.GetObject("chkMayo.Enabled"), Boolean)
        Me.chkMayo.FlatStyle = CType(resources.GetObject("chkMayo.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.chkMayo.Font = CType(resources.GetObject("chkMayo.Font"), System.Drawing.Font)
        Me.chkMayo.Image = CType(resources.GetObject("chkMayo.Image"), System.Drawing.Image)
        Me.chkMayo.ImageAlign = CType(resources.GetObject("chkMayo.ImageAlign"), System.Drawing.ContentAlignment)
        Me.chkMayo.ImageIndex = CType(resources.GetObject("chkMayo.ImageIndex"), Integer)
        Me.chkMayo.ImeMode = CType(resources.GetObject("chkMayo.ImeMode"), System.Windows.Forms.ImeMode)
        Me.chkMayo.Location = CType(resources.GetObject("chkMayo.Location"), System.Drawing.Point)
        Me.chkMayo.Name = "chkMayo"
        Me.chkMayo.RightToLeft = CType(resources.GetObject("chkMayo.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.chkMayo.Size = CType(resources.GetObject("chkMayo.Size"), System.Drawing.Size)
        Me.chkMayo.TabIndex = CType(resources.GetObject("chkMayo.TabIndex"), Integer)
        Me.chkMayo.Text = resources.GetString("chkMayo.Text")
        Me.chkMayo.TextAlign = CType(resources.GetObject("chkMayo.TextAlign"), System.Drawing.ContentAlignment)
        Me.chkMayo.Visible = CType(resources.GetObject("chkMayo.Visible"), Boolean)
        '
        'chkKetchup
        '
        Me.chkKetchup.AccessibleDescription = resources.GetString("chkKetchup.AccessibleDescription")
        Me.chkKetchup.AccessibleName = resources.GetString("chkKetchup.AccessibleName")
        Me.chkKetchup.Anchor = CType(resources.GetObject("chkKetchup.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.chkKetchup.Appearance = CType(resources.GetObject("chkKetchup.Appearance"), System.Windows.Forms.Appearance)
        Me.chkKetchup.BackgroundImage = CType(resources.GetObject("chkKetchup.BackgroundImage"), System.Drawing.Image)
        Me.chkKetchup.CheckAlign = CType(resources.GetObject("chkKetchup.CheckAlign"), System.Drawing.ContentAlignment)
        Me.chkKetchup.Dock = CType(resources.GetObject("chkKetchup.Dock"), System.Windows.Forms.DockStyle)
        Me.chkKetchup.Enabled = CType(resources.GetObject("chkKetchup.Enabled"), Boolean)
        Me.chkKetchup.FlatStyle = CType(resources.GetObject("chkKetchup.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.chkKetchup.Font = CType(resources.GetObject("chkKetchup.Font"), System.Drawing.Font)
        Me.chkKetchup.Image = CType(resources.GetObject("chkKetchup.Image"), System.Drawing.Image)
        Me.chkKetchup.ImageAlign = CType(resources.GetObject("chkKetchup.ImageAlign"), System.Drawing.ContentAlignment)
        Me.chkKetchup.ImageIndex = CType(resources.GetObject("chkKetchup.ImageIndex"), Integer)
        Me.chkKetchup.ImeMode = CType(resources.GetObject("chkKetchup.ImeMode"), System.Windows.Forms.ImeMode)
        Me.chkKetchup.Location = CType(resources.GetObject("chkKetchup.Location"), System.Drawing.Point)
        Me.chkKetchup.Name = "chkKetchup"
        Me.chkKetchup.RightToLeft = CType(resources.GetObject("chkKetchup.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.chkKetchup.Size = CType(resources.GetObject("chkKetchup.Size"), System.Drawing.Size)
        Me.chkKetchup.TabIndex = CType(resources.GetObject("chkKetchup.TabIndex"), Integer)
        Me.chkKetchup.Text = resources.GetString("chkKetchup.Text")
        Me.chkKetchup.TextAlign = CType(resources.GetObject("chkKetchup.TextAlign"), System.Drawing.ContentAlignment)
        Me.chkKetchup.Visible = CType(resources.GetObject("chkKetchup.Visible"), Boolean)
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
        'chkMustard
        '
        Me.chkMustard.AccessibleDescription = resources.GetString("chkMustard.AccessibleDescription")
        Me.chkMustard.AccessibleName = resources.GetString("chkMustard.AccessibleName")
        Me.chkMustard.Anchor = CType(resources.GetObject("chkMustard.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.chkMustard.Appearance = CType(resources.GetObject("chkMustard.Appearance"), System.Windows.Forms.Appearance)
        Me.chkMustard.BackgroundImage = CType(resources.GetObject("chkMustard.BackgroundImage"), System.Drawing.Image)
        Me.chkMustard.CheckAlign = CType(resources.GetObject("chkMustard.CheckAlign"), System.Drawing.ContentAlignment)
        Me.chkMustard.Dock = CType(resources.GetObject("chkMustard.Dock"), System.Windows.Forms.DockStyle)
        Me.chkMustard.Enabled = CType(resources.GetObject("chkMustard.Enabled"), Boolean)
        Me.chkMustard.FlatStyle = CType(resources.GetObject("chkMustard.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.chkMustard.Font = CType(resources.GetObject("chkMustard.Font"), System.Drawing.Font)
        Me.chkMustard.Image = CType(resources.GetObject("chkMustard.Image"), System.Drawing.Image)
        Me.chkMustard.ImageAlign = CType(resources.GetObject("chkMustard.ImageAlign"), System.Drawing.ContentAlignment)
        Me.chkMustard.ImageIndex = CType(resources.GetObject("chkMustard.ImageIndex"), Integer)
        Me.chkMustard.ImeMode = CType(resources.GetObject("chkMustard.ImeMode"), System.Windows.Forms.ImeMode)
        Me.chkMustard.Location = CType(resources.GetObject("chkMustard.Location"), System.Drawing.Point)
        Me.chkMustard.Name = "chkMustard"
        Me.chkMustard.RightToLeft = CType(resources.GetObject("chkMustard.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.chkMustard.Size = CType(resources.GetObject("chkMustard.Size"), System.Drawing.Size)
        Me.chkMustard.TabIndex = CType(resources.GetObject("chkMustard.TabIndex"), Integer)
        Me.chkMustard.Text = resources.GetString("chkMustard.Text")
        Me.chkMustard.TextAlign = CType(resources.GetObject("chkMustard.TextAlign"), System.Drawing.ContentAlignment)
        Me.chkMustard.Visible = CType(resources.GetObject("chkMustard.Visible"), Boolean)
        '
        'optHamburger
        '
        Me.optHamburger.AccessibleDescription = resources.GetString("optHamburger.AccessibleDescription")
        Me.optHamburger.AccessibleName = resources.GetString("optHamburger.AccessibleName")
        Me.optHamburger.Anchor = CType(resources.GetObject("optHamburger.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.optHamburger.Appearance = CType(resources.GetObject("optHamburger.Appearance"), System.Windows.Forms.Appearance)
        Me.optHamburger.BackgroundImage = CType(resources.GetObject("optHamburger.BackgroundImage"), System.Drawing.Image)
        Me.optHamburger.CheckAlign = CType(resources.GetObject("optHamburger.CheckAlign"), System.Drawing.ContentAlignment)
        Me.optHamburger.Dock = CType(resources.GetObject("optHamburger.Dock"), System.Windows.Forms.DockStyle)
        Me.optHamburger.Enabled = CType(resources.GetObject("optHamburger.Enabled"), Boolean)
        Me.optHamburger.FlatStyle = CType(resources.GetObject("optHamburger.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.optHamburger.Font = CType(resources.GetObject("optHamburger.Font"), System.Drawing.Font)
        Me.optHamburger.Image = CType(resources.GetObject("optHamburger.Image"), System.Drawing.Image)
        Me.optHamburger.ImageAlign = CType(resources.GetObject("optHamburger.ImageAlign"), System.Drawing.ContentAlignment)
        Me.optHamburger.ImageIndex = CType(resources.GetObject("optHamburger.ImageIndex"), Integer)
        Me.optHamburger.ImeMode = CType(resources.GetObject("optHamburger.ImeMode"), System.Windows.Forms.ImeMode)
        Me.optHamburger.Location = CType(resources.GetObject("optHamburger.Location"), System.Drawing.Point)
        Me.optHamburger.Name = "optHamburger"
        Me.optHamburger.RightToLeft = CType(resources.GetObject("optHamburger.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.optHamburger.Size = CType(resources.GetObject("optHamburger.Size"), System.Drawing.Size)
        Me.optHamburger.TabIndex = CType(resources.GetObject("optHamburger.TabIndex"), Integer)
        Me.optHamburger.Text = resources.GetString("optHamburger.Text")
        Me.optHamburger.TextAlign = CType(resources.GetObject("optHamburger.TextAlign"), System.Drawing.ContentAlignment)
        Me.optHamburger.Visible = CType(resources.GetObject("optHamburger.Visible"), Boolean)
        '
        'grpMainCourse
        '
        Me.grpMainCourse.AccessibleDescription = CType(resources.GetObject("grpMainCourse.AccessibleDescription"), String)
        Me.grpMainCourse.AccessibleName = CType(resources.GetObject("grpMainCourse.AccessibleName"), String)
        Me.grpMainCourse.Anchor = CType(resources.GetObject("grpMainCourse.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.grpMainCourse.BackgroundImage = CType(resources.GetObject("grpMainCourse.BackgroundImage"), System.Drawing.Image)
        Me.grpMainCourse.Dock = CType(resources.GetObject("grpMainCourse.Dock"), System.Windows.Forms.DockStyle)
        Me.grpMainCourse.Enabled = CType(resources.GetObject("grpMainCourse.Enabled"), Boolean)
        Me.grpMainCourse.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.grpMainCourse.Font = CType(resources.GetObject("grpMainCourse.Font"), System.Drawing.Font)
        Me.grpMainCourse.ImeMode = CType(resources.GetObject("grpMainCourse.ImeMode"), System.Windows.Forms.ImeMode)
        Me.grpMainCourse.Location = CType(resources.GetObject("grpMainCourse.Location"), System.Drawing.Point)
        Me.grpMainCourse.Name = "grpMainCourse"
        Me.grpMainCourse.RightToLeft = CType(resources.GetObject("grpMainCourse.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.grpMainCourse.Size = CType(resources.GetObject("grpMainCourse.Size"), System.Drawing.Size)
        Me.grpMainCourse.TabIndex = CType(resources.GetObject("grpMainCourse.TabIndex"), Integer)
        Me.grpMainCourse.TabStop = False
        Me.grpMainCourse.Text = resources.GetString("grpMainCourse.Text")
        Me.grpMainCourse.Visible = CType(resources.GetObject("grpMainCourse.Visible"), Boolean)
        '
        'grpCondiments
        '
        Me.grpCondiments.AccessibleDescription = CType(resources.GetObject("grpCondiments.AccessibleDescription"), String)
        Me.grpCondiments.AccessibleName = CType(resources.GetObject("grpCondiments.AccessibleName"), String)
        Me.grpCondiments.Anchor = CType(resources.GetObject("grpCondiments.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.grpCondiments.BackgroundImage = CType(resources.GetObject("grpCondiments.BackgroundImage"), System.Drawing.Image)
        Me.grpCondiments.Dock = CType(resources.GetObject("grpCondiments.Dock"), System.Windows.Forms.DockStyle)
        Me.grpCondiments.Enabled = CType(resources.GetObject("grpCondiments.Enabled"), Boolean)
        Me.grpCondiments.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.grpCondiments.Font = CType(resources.GetObject("grpCondiments.Font"), System.Drawing.Font)
        Me.grpCondiments.ImeMode = CType(resources.GetObject("grpCondiments.ImeMode"), System.Windows.Forms.ImeMode)
        Me.grpCondiments.Location = CType(resources.GetObject("grpCondiments.Location"), System.Drawing.Point)
        Me.grpCondiments.Name = "grpCondiments"
        Me.grpCondiments.RightToLeft = CType(resources.GetObject("grpCondiments.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.grpCondiments.Size = CType(resources.GetObject("grpCondiments.Size"), System.Drawing.Size)
        Me.grpCondiments.TabIndex = CType(resources.GetObject("grpCondiments.TabIndex"), Integer)
        Me.grpCondiments.TabStop = False
        Me.grpCondiments.Text = resources.GetString("grpCondiments.Text")
        Me.grpCondiments.Visible = CType(resources.GetObject("grpCondiments.Visible"), Boolean)
        '
        'TabPage2
        '
        Me.TabPage2.AccessibleDescription = CType(resources.GetObject("TabPage2.AccessibleDescription"), String)
        Me.TabPage2.AccessibleName = CType(resources.GetObject("TabPage2.AccessibleName"), String)
        Me.TabPage2.Anchor = CType(resources.GetObject("TabPage2.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.TabPage2.AutoScroll = CType(resources.GetObject("TabPage2.AutoScroll"), Boolean)
        Me.TabPage2.AutoScrollMargin = CType(resources.GetObject("TabPage2.AutoScrollMargin"), System.Drawing.Size)
        Me.TabPage2.AutoScrollMinSize = CType(resources.GetObject("TabPage2.AutoScrollMinSize"), System.Drawing.Size)
        Me.TabPage2.BackgroundImage = CType(resources.GetObject("TabPage2.BackgroundImage"), System.Drawing.Image)
        Me.TabPage2.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label9, Me.CheckedListBox1, Me.DataGrid1, Me.dudMaleFemale})
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
        Me.TabPage2.Tag = "Non_Supported_Controls"
        Me.TabPage2.Text = resources.GetString("TabPage2.Text")
        Me.TabPage2.ToolTipText = resources.GetString("TabPage2.ToolTipText")
        Me.TabPage2.Visible = CType(resources.GetObject("TabPage2.Visible"), Boolean)
        '
        'Label9
        '
        Me.Label9.AccessibleDescription = CType(resources.GetObject("Label9.AccessibleDescription"), String)
        Me.Label9.AccessibleName = CType(resources.GetObject("Label9.AccessibleName"), String)
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
        'CheckedListBox1
        '
        Me.CheckedListBox1.AccessibleDescription = resources.GetString("CheckedListBox1.AccessibleDescription")
        Me.CheckedListBox1.AccessibleName = resources.GetString("CheckedListBox1.AccessibleName")
        Me.CheckedListBox1.Anchor = CType(resources.GetObject("CheckedListBox1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.CheckedListBox1.BackgroundImage = CType(resources.GetObject("CheckedListBox1.BackgroundImage"), System.Drawing.Image)
        Me.CheckedListBox1.ColumnWidth = CType(resources.GetObject("CheckedListBox1.ColumnWidth"), Integer)
        Me.CheckedListBox1.Dock = CType(resources.GetObject("CheckedListBox1.Dock"), System.Windows.Forms.DockStyle)
        Me.CheckedListBox1.Enabled = CType(resources.GetObject("CheckedListBox1.Enabled"), Boolean)
        Me.CheckedListBox1.Font = CType(resources.GetObject("CheckedListBox1.Font"), System.Drawing.Font)
        Me.CheckedListBox1.HorizontalExtent = CType(resources.GetObject("CheckedListBox1.HorizontalExtent"), Integer)
        Me.CheckedListBox1.HorizontalScrollbar = CType(resources.GetObject("CheckedListBox1.HorizontalScrollbar"), Boolean)
        Me.CheckedListBox1.ImeMode = CType(resources.GetObject("CheckedListBox1.ImeMode"), System.Windows.Forms.ImeMode)
        Me.CheckedListBox1.IntegralHeight = CType(resources.GetObject("CheckedListBox1.IntegralHeight"), Boolean)
        Me.CheckedListBox1.Items.AddRange(New Object() {resources.GetString("CheckedListBox1.Items.Items"), resources.GetString("CheckedListBox1.Items.Items1")})
        Me.CheckedListBox1.Location = CType(resources.GetObject("CheckedListBox1.Location"), System.Drawing.Point)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.RightToLeft = CType(resources.GetObject("CheckedListBox1.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.CheckedListBox1.ScrollAlwaysVisible = CType(resources.GetObject("CheckedListBox1.ScrollAlwaysVisible"), Boolean)
        Me.CheckedListBox1.Size = CType(resources.GetObject("CheckedListBox1.Size"), System.Drawing.Size)
        Me.CheckedListBox1.TabIndex = CType(resources.GetObject("CheckedListBox1.TabIndex"), Integer)
        Me.CheckedListBox1.Visible = CType(resources.GetObject("CheckedListBox1.Visible"), Boolean)
        '
        'DataGrid1
        '
        Me.DataGrid1.AccessibleDescription = resources.GetString("DataGrid1.AccessibleDescription")
        Me.DataGrid1.AccessibleName = resources.GetString("DataGrid1.AccessibleName")
        Me.DataGrid1.Anchor = CType(resources.GetObject("DataGrid1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.DataGrid1.BackgroundImage = CType(resources.GetObject("DataGrid1.BackgroundImage"), System.Drawing.Image)
        Me.DataGrid1.CaptionFont = CType(resources.GetObject("DataGrid1.CaptionFont"), System.Drawing.Font)
        Me.DataGrid1.CaptionText = resources.GetString("DataGrid1.CaptionText")
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.Dock = CType(resources.GetObject("DataGrid1.Dock"), System.Windows.Forms.DockStyle)
        Me.DataGrid1.Enabled = CType(resources.GetObject("DataGrid1.Enabled"), Boolean)
        Me.DataGrid1.FlatMode = True
        Me.DataGrid1.Font = CType(resources.GetObject("DataGrid1.Font"), System.Drawing.Font)
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.ImeMode = CType(resources.GetObject("DataGrid1.ImeMode"), System.Windows.Forms.ImeMode)
        Me.DataGrid1.Location = CType(resources.GetObject("DataGrid1.Location"), System.Drawing.Point)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.RightToLeft = CType(resources.GetObject("DataGrid1.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.DataGrid1.Size = CType(resources.GetObject("DataGrid1.Size"), System.Drawing.Size)
        Me.DataGrid1.TabIndex = CType(resources.GetObject("DataGrid1.TabIndex"), Integer)
        Me.DataGrid1.Visible = CType(resources.GetObject("DataGrid1.Visible"), Boolean)
        '
        'dudMaleFemale
        '
        Me.dudMaleFemale.AccessibleDescription = resources.GetString("dudMaleFemale.AccessibleDescription")
        Me.dudMaleFemale.AccessibleName = resources.GetString("dudMaleFemale.AccessibleName")
        Me.dudMaleFemale.Anchor = CType(resources.GetObject("dudMaleFemale.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.dudMaleFemale.Dock = CType(resources.GetObject("dudMaleFemale.Dock"), System.Windows.Forms.DockStyle)
        Me.dudMaleFemale.Enabled = CType(resources.GetObject("dudMaleFemale.Enabled"), Boolean)
        Me.dudMaleFemale.Font = CType(resources.GetObject("dudMaleFemale.Font"), System.Drawing.Font)
        Me.dudMaleFemale.ImeMode = CType(resources.GetObject("dudMaleFemale.ImeMode"), System.Windows.Forms.ImeMode)
        Me.dudMaleFemale.Items.Add(resources.GetString("dudMaleFemale.Items.Items"))
        Me.dudMaleFemale.Items.Add(resources.GetString("dudMaleFemale.Items.Items1"))
        Me.dudMaleFemale.Location = CType(resources.GetObject("dudMaleFemale.Location"), System.Drawing.Point)
        Me.dudMaleFemale.Name = "dudMaleFemale"
        Me.dudMaleFemale.RightToLeft = CType(resources.GetObject("dudMaleFemale.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.dudMaleFemale.Size = CType(resources.GetObject("dudMaleFemale.Size"), System.Drawing.Size)
        Me.dudMaleFemale.TabIndex = CType(resources.GetObject("dudMaleFemale.TabIndex"), Integer)
        Me.dudMaleFemale.Text = resources.GetString("dudMaleFemale.Text")
        Me.dudMaleFemale.TextAlign = CType(resources.GetObject("dudMaleFemale.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.dudMaleFemale.UpDownAlign = CType(resources.GetObject("dudMaleFemale.UpDownAlign"), System.Windows.Forms.LeftRightAlignment)
        Me.dudMaleFemale.Visible = CType(resources.GetObject("dudMaleFemale.Visible"), Boolean)
        Me.dudMaleFemale.Wrap = CType(resources.GetObject("dudMaleFemale.Wrap"), Boolean)
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
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.tabMain})
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
        Me.tabMain.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
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

#Region "SetupControlDefaultValues"

    Private Sub SetupControlDefaultValues()

        ' Set some default values for the controls on the form.

        cboDepartureCity.SelectedIndex = 0
        cboArrivalCity.SelectedIndex = 1
        calDepartureDate.ShowToday = False
        calArrivalDate.ShowToday = False
        calDepartureDate.SetDate(DateTime.Now.AddDays(7))
        calArrivalDate.SetDate(DateTime.Now.AddDays(14))

        Dim dt As New DataTable()
        dt.Columns.Add("Product Name")
        dt.Columns.Add("Product Price")

        Dim dr As DataRow
        ' Add Row 1
        dr = dt.NewRow()
        dr("Product Name") = "Ketchup"
        dr("Product Price") = "1.24"
        dt.Rows.Add(dr)
        ' Add Row 2
        dr = dt.NewRow()
        dr("Product Name") = "Mustard"
        dr("Product Price") = "1.37"
        dt.Rows.Add(dr)

        DataGrid1.DataSource = dt

        dudMaleFemale.SelectedIndex = 0

    End Sub

#End Region

    ' Enabling XP Theme support is largely a matter of associating your application with the appropriate
    ' defined manifest file.
    ' Information on how to do this is placed in the readme.htm associated with this How-To.
    ' A manifest file is already associated with this application and thererfore the application 
    ' will automatically support the current theme for controls that support themeing.
    ' No code and only the setting of a single property on a few controls that do not automatically
    ' support themes with their default property settings is all that is needed.

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetupControlDefaultValues()
    End Sub



End Class