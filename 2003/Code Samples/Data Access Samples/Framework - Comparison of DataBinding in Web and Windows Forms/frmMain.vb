'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On
Imports System.Data.SqlClient
Imports System.Text

Public Class frmMain
    Inherits System.Windows.Forms.Form

    Protected Const CONNECTION_ERROR_MSG As String = _
    "To run this sample, you must have SQL " & _
    "or MSDE with the Northwind database installed.  For " & _
    "instructions on installing MSDE, view the ReadMe file."

    Protected Const SQL_CONNECTION_STRING As String = _
        "Server=(local)\NetSDK;" & _
        "DataBase=Northwind;" & _
        "Integrated Security=SSPI"
    'Swaped the names of Sqlconnectionstring and Msdeconnectionstring to enforce the use of MSDE connection.
    Protected Const MSDE_CONNECTION_STRING As String = _
        "Server=localhost;" & _
        "DataBase=Northwind;" & _
        "Integrated Security=SSPI"

    Private arlProducts As ArrayList
    Private dsProducts As DataSet
    Private FormHasLoaded As Boolean = False
    Private sdrProducts As SqlDataReader
    Private strConn As String

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
    Friend WithEvents lblSelected As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNewOption As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents optDataSet As System.Windows.Forms.RadioButton
    Friend WithEvents optDataReader As System.Windows.Forms.RadioButton
    Friend WithEvents cboProducts As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtChecked As System.Windows.Forms.TextBox
    Friend WithEvents clstProducts As System.Windows.Forms.CheckedListBox
    Friend WithEvents btnBindComboBox As System.Windows.Forms.Button
    Friend WithEvents btnShowSelectedItem As System.Windows.Forms.Button
    Friend WithEvents btnShowCheckedItems As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnShowSelectedItem = New System.Windows.Forms.Button()
        Me.lblSelected = New System.Windows.Forms.Label()
        Me.btnBindComboBox = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNewOption = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.optDataSet = New System.Windows.Forms.RadioButton()
        Me.optDataReader = New System.Windows.Forms.RadioButton()
        Me.cboProducts = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.txtChecked = New System.Windows.Forms.TextBox()
        Me.btnShowCheckedItems = New System.Windows.Forms.Button()
        Me.clstProducts = New System.Windows.Forms.CheckedListBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
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
        Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabPage1, Me.TabPage2})
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
        Me.TabPage1.BackgroundImage = CType(resources.GetObject("TabPage1.BackgroundImage"), System.Drawing.Image)
        Me.TabPage1.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnShowSelectedItem, Me.lblSelected, Me.btnBindComboBox, Me.Label3, Me.txtNewOption, Me.Label2, Me.optDataSet, Me.optDataReader, Me.cboProducts, Me.Label1})
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
        'btnShowSelectedItem
        '
        Me.btnShowSelectedItem.AccessibleDescription = resources.GetString("btnShowSelectedItem.AccessibleDescription")
        Me.btnShowSelectedItem.AccessibleName = resources.GetString("btnShowSelectedItem.AccessibleName")
        Me.btnShowSelectedItem.Anchor = CType(resources.GetObject("btnShowSelectedItem.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnShowSelectedItem.BackgroundImage = CType(resources.GetObject("btnShowSelectedItem.BackgroundImage"), System.Drawing.Image)
        Me.btnShowSelectedItem.Dock = CType(resources.GetObject("btnShowSelectedItem.Dock"), System.Windows.Forms.DockStyle)
        Me.btnShowSelectedItem.Enabled = CType(resources.GetObject("btnShowSelectedItem.Enabled"), Boolean)
        Me.btnShowSelectedItem.FlatStyle = CType(resources.GetObject("btnShowSelectedItem.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnShowSelectedItem.Font = CType(resources.GetObject("btnShowSelectedItem.Font"), System.Drawing.Font)
        Me.btnShowSelectedItem.Image = CType(resources.GetObject("btnShowSelectedItem.Image"), System.Drawing.Image)
        Me.btnShowSelectedItem.ImageAlign = CType(resources.GetObject("btnShowSelectedItem.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnShowSelectedItem.ImageIndex = CType(resources.GetObject("btnShowSelectedItem.ImageIndex"), Integer)
        Me.btnShowSelectedItem.ImeMode = CType(resources.GetObject("btnShowSelectedItem.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnShowSelectedItem.Location = CType(resources.GetObject("btnShowSelectedItem.Location"), System.Drawing.Point)
        Me.btnShowSelectedItem.Name = "btnShowSelectedItem"
        Me.btnShowSelectedItem.RightToLeft = CType(resources.GetObject("btnShowSelectedItem.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnShowSelectedItem.Size = CType(resources.GetObject("btnShowSelectedItem.Size"), System.Drawing.Size)
        Me.btnShowSelectedItem.TabIndex = CType(resources.GetObject("btnShowSelectedItem.TabIndex"), Integer)
        Me.btnShowSelectedItem.Text = resources.GetString("btnShowSelectedItem.Text")
        Me.btnShowSelectedItem.TextAlign = CType(resources.GetObject("btnShowSelectedItem.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnShowSelectedItem.Visible = CType(resources.GetObject("btnShowSelectedItem.Visible"), Boolean)
        '
        'lblSelected
        '
        Me.lblSelected.AccessibleDescription = resources.GetString("lblSelected.AccessibleDescription")
        Me.lblSelected.AccessibleName = resources.GetString("lblSelected.AccessibleName")
        Me.lblSelected.Anchor = CType(resources.GetObject("lblSelected.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblSelected.AutoSize = CType(resources.GetObject("lblSelected.AutoSize"), Boolean)
        Me.lblSelected.Dock = CType(resources.GetObject("lblSelected.Dock"), System.Windows.Forms.DockStyle)
        Me.lblSelected.Enabled = CType(resources.GetObject("lblSelected.Enabled"), Boolean)
        Me.lblSelected.Font = CType(resources.GetObject("lblSelected.Font"), System.Drawing.Font)
        Me.lblSelected.Image = CType(resources.GetObject("lblSelected.Image"), System.Drawing.Image)
        Me.lblSelected.ImageAlign = CType(resources.GetObject("lblSelected.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblSelected.ImageIndex = CType(resources.GetObject("lblSelected.ImageIndex"), Integer)
        Me.lblSelected.ImeMode = CType(resources.GetObject("lblSelected.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblSelected.Location = CType(resources.GetObject("lblSelected.Location"), System.Drawing.Point)
        Me.lblSelected.Name = "lblSelected"
        Me.lblSelected.RightToLeft = CType(resources.GetObject("lblSelected.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblSelected.Size = CType(resources.GetObject("lblSelected.Size"), System.Drawing.Size)
        Me.lblSelected.TabIndex = CType(resources.GetObject("lblSelected.TabIndex"), Integer)
        Me.lblSelected.Text = resources.GetString("lblSelected.Text")
        Me.lblSelected.TextAlign = CType(resources.GetObject("lblSelected.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblSelected.Visible = CType(resources.GetObject("lblSelected.Visible"), Boolean)
        '
        'btnBindComboBox
        '
        Me.btnBindComboBox.AccessibleDescription = resources.GetString("btnBindComboBox.AccessibleDescription")
        Me.btnBindComboBox.AccessibleName = resources.GetString("btnBindComboBox.AccessibleName")
        Me.btnBindComboBox.Anchor = CType(resources.GetObject("btnBindComboBox.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnBindComboBox.BackgroundImage = CType(resources.GetObject("btnBindComboBox.BackgroundImage"), System.Drawing.Image)
        Me.btnBindComboBox.Dock = CType(resources.GetObject("btnBindComboBox.Dock"), System.Windows.Forms.DockStyle)
        Me.btnBindComboBox.Enabled = CType(resources.GetObject("btnBindComboBox.Enabled"), Boolean)
        Me.btnBindComboBox.FlatStyle = CType(resources.GetObject("btnBindComboBox.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnBindComboBox.Font = CType(resources.GetObject("btnBindComboBox.Font"), System.Drawing.Font)
        Me.btnBindComboBox.Image = CType(resources.GetObject("btnBindComboBox.Image"), System.Drawing.Image)
        Me.btnBindComboBox.ImageAlign = CType(resources.GetObject("btnBindComboBox.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnBindComboBox.ImageIndex = CType(resources.GetObject("btnBindComboBox.ImageIndex"), Integer)
        Me.btnBindComboBox.ImeMode = CType(resources.GetObject("btnBindComboBox.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnBindComboBox.Location = CType(resources.GetObject("btnBindComboBox.Location"), System.Drawing.Point)
        Me.btnBindComboBox.Name = "btnBindComboBox"
        Me.btnBindComboBox.RightToLeft = CType(resources.GetObject("btnBindComboBox.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnBindComboBox.Size = CType(resources.GetObject("btnBindComboBox.Size"), System.Drawing.Size)
        Me.btnBindComboBox.TabIndex = CType(resources.GetObject("btnBindComboBox.TabIndex"), Integer)
        Me.btnBindComboBox.Text = resources.GetString("btnBindComboBox.Text")
        Me.btnBindComboBox.TextAlign = CType(resources.GetObject("btnBindComboBox.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnBindComboBox.Visible = CType(resources.GetObject("btnBindComboBox.Visible"), Boolean)
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
        'txtNewOption
        '
        Me.txtNewOption.AccessibleDescription = resources.GetString("txtNewOption.AccessibleDescription")
        Me.txtNewOption.AccessibleName = resources.GetString("txtNewOption.AccessibleName")
        Me.txtNewOption.Anchor = CType(resources.GetObject("txtNewOption.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtNewOption.AutoSize = CType(resources.GetObject("txtNewOption.AutoSize"), Boolean)
        Me.txtNewOption.BackgroundImage = CType(resources.GetObject("txtNewOption.BackgroundImage"), System.Drawing.Image)
        Me.txtNewOption.Dock = CType(resources.GetObject("txtNewOption.Dock"), System.Windows.Forms.DockStyle)
        Me.txtNewOption.Enabled = CType(resources.GetObject("txtNewOption.Enabled"), Boolean)
        Me.txtNewOption.Font = CType(resources.GetObject("txtNewOption.Font"), System.Drawing.Font)
        Me.txtNewOption.ImeMode = CType(resources.GetObject("txtNewOption.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtNewOption.Location = CType(resources.GetObject("txtNewOption.Location"), System.Drawing.Point)
        Me.txtNewOption.MaxLength = CType(resources.GetObject("txtNewOption.MaxLength"), Integer)
        Me.txtNewOption.Multiline = CType(resources.GetObject("txtNewOption.Multiline"), Boolean)
        Me.txtNewOption.Name = "txtNewOption"
        Me.txtNewOption.PasswordChar = CType(resources.GetObject("txtNewOption.PasswordChar"), Char)
        Me.txtNewOption.RightToLeft = CType(resources.GetObject("txtNewOption.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtNewOption.ScrollBars = CType(resources.GetObject("txtNewOption.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtNewOption.Size = CType(resources.GetObject("txtNewOption.Size"), System.Drawing.Size)
        Me.txtNewOption.TabIndex = CType(resources.GetObject("txtNewOption.TabIndex"), Integer)
        Me.txtNewOption.Text = resources.GetString("txtNewOption.Text")
        Me.txtNewOption.TextAlign = CType(resources.GetObject("txtNewOption.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtNewOption.Visible = CType(resources.GetObject("txtNewOption.Visible"), Boolean)
        Me.txtNewOption.WordWrap = CType(resources.GetObject("txtNewOption.WordWrap"), Boolean)
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
        'optDataSet
        '
        Me.optDataSet.AccessibleDescription = resources.GetString("optDataSet.AccessibleDescription")
        Me.optDataSet.AccessibleName = resources.GetString("optDataSet.AccessibleName")
        Me.optDataSet.Anchor = CType(resources.GetObject("optDataSet.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.optDataSet.Appearance = CType(resources.GetObject("optDataSet.Appearance"), System.Windows.Forms.Appearance)
        Me.optDataSet.BackgroundImage = CType(resources.GetObject("optDataSet.BackgroundImage"), System.Drawing.Image)
        Me.optDataSet.CheckAlign = CType(resources.GetObject("optDataSet.CheckAlign"), System.Drawing.ContentAlignment)
        Me.optDataSet.Checked = True
        Me.optDataSet.Dock = CType(resources.GetObject("optDataSet.Dock"), System.Windows.Forms.DockStyle)
        Me.optDataSet.Enabled = CType(resources.GetObject("optDataSet.Enabled"), Boolean)
        Me.optDataSet.FlatStyle = CType(resources.GetObject("optDataSet.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.optDataSet.Font = CType(resources.GetObject("optDataSet.Font"), System.Drawing.Font)
        Me.optDataSet.Image = CType(resources.GetObject("optDataSet.Image"), System.Drawing.Image)
        Me.optDataSet.ImageAlign = CType(resources.GetObject("optDataSet.ImageAlign"), System.Drawing.ContentAlignment)
        Me.optDataSet.ImageIndex = CType(resources.GetObject("optDataSet.ImageIndex"), Integer)
        Me.optDataSet.ImeMode = CType(resources.GetObject("optDataSet.ImeMode"), System.Windows.Forms.ImeMode)
        Me.optDataSet.Location = CType(resources.GetObject("optDataSet.Location"), System.Drawing.Point)
        Me.optDataSet.Name = "optDataSet"
        Me.optDataSet.RightToLeft = CType(resources.GetObject("optDataSet.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.optDataSet.Size = CType(resources.GetObject("optDataSet.Size"), System.Drawing.Size)
        Me.optDataSet.TabIndex = CType(resources.GetObject("optDataSet.TabIndex"), Integer)
        Me.optDataSet.TabStop = True
        Me.optDataSet.Text = resources.GetString("optDataSet.Text")
        Me.optDataSet.TextAlign = CType(resources.GetObject("optDataSet.TextAlign"), System.Drawing.ContentAlignment)
        Me.optDataSet.Visible = CType(resources.GetObject("optDataSet.Visible"), Boolean)
        '
        'optDataReader
        '
        Me.optDataReader.AccessibleDescription = resources.GetString("optDataReader.AccessibleDescription")
        Me.optDataReader.AccessibleName = resources.GetString("optDataReader.AccessibleName")
        Me.optDataReader.Anchor = CType(resources.GetObject("optDataReader.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.optDataReader.Appearance = CType(resources.GetObject("optDataReader.Appearance"), System.Windows.Forms.Appearance)
        Me.optDataReader.BackgroundImage = CType(resources.GetObject("optDataReader.BackgroundImage"), System.Drawing.Image)
        Me.optDataReader.CheckAlign = CType(resources.GetObject("optDataReader.CheckAlign"), System.Drawing.ContentAlignment)
        Me.optDataReader.Dock = CType(resources.GetObject("optDataReader.Dock"), System.Windows.Forms.DockStyle)
        Me.optDataReader.Enabled = CType(resources.GetObject("optDataReader.Enabled"), Boolean)
        Me.optDataReader.FlatStyle = CType(resources.GetObject("optDataReader.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.optDataReader.Font = CType(resources.GetObject("optDataReader.Font"), System.Drawing.Font)
        Me.optDataReader.Image = CType(resources.GetObject("optDataReader.Image"), System.Drawing.Image)
        Me.optDataReader.ImageAlign = CType(resources.GetObject("optDataReader.ImageAlign"), System.Drawing.ContentAlignment)
        Me.optDataReader.ImageIndex = CType(resources.GetObject("optDataReader.ImageIndex"), Integer)
        Me.optDataReader.ImeMode = CType(resources.GetObject("optDataReader.ImeMode"), System.Windows.Forms.ImeMode)
        Me.optDataReader.Location = CType(resources.GetObject("optDataReader.Location"), System.Drawing.Point)
        Me.optDataReader.Name = "optDataReader"
        Me.optDataReader.RightToLeft = CType(resources.GetObject("optDataReader.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.optDataReader.Size = CType(resources.GetObject("optDataReader.Size"), System.Drawing.Size)
        Me.optDataReader.TabIndex = CType(resources.GetObject("optDataReader.TabIndex"), Integer)
        Me.optDataReader.Text = resources.GetString("optDataReader.Text")
        Me.optDataReader.TextAlign = CType(resources.GetObject("optDataReader.TextAlign"), System.Drawing.ContentAlignment)
        Me.optDataReader.Visible = CType(resources.GetObject("optDataReader.Visible"), Boolean)
        '
        'cboProducts
        '
        Me.cboProducts.AccessibleDescription = resources.GetString("cboProducts.AccessibleDescription")
        Me.cboProducts.AccessibleName = resources.GetString("cboProducts.AccessibleName")
        Me.cboProducts.Anchor = CType(resources.GetObject("cboProducts.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.cboProducts.BackgroundImage = CType(resources.GetObject("cboProducts.BackgroundImage"), System.Drawing.Image)
        Me.cboProducts.Dock = CType(resources.GetObject("cboProducts.Dock"), System.Windows.Forms.DockStyle)
        Me.cboProducts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProducts.Enabled = CType(resources.GetObject("cboProducts.Enabled"), Boolean)
        Me.cboProducts.Font = CType(resources.GetObject("cboProducts.Font"), System.Drawing.Font)
        Me.cboProducts.ImeMode = CType(resources.GetObject("cboProducts.ImeMode"), System.Windows.Forms.ImeMode)
        Me.cboProducts.IntegralHeight = CType(resources.GetObject("cboProducts.IntegralHeight"), Boolean)
        Me.cboProducts.ItemHeight = CType(resources.GetObject("cboProducts.ItemHeight"), Integer)
        Me.cboProducts.Location = CType(resources.GetObject("cboProducts.Location"), System.Drawing.Point)
        Me.cboProducts.MaxDropDownItems = CType(resources.GetObject("cboProducts.MaxDropDownItems"), Integer)
        Me.cboProducts.MaxLength = CType(resources.GetObject("cboProducts.MaxLength"), Integer)
        Me.cboProducts.Name = "cboProducts"
        Me.cboProducts.RightToLeft = CType(resources.GetObject("cboProducts.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.cboProducts.Size = CType(resources.GetObject("cboProducts.Size"), System.Drawing.Size)
        Me.cboProducts.TabIndex = CType(resources.GetObject("cboProducts.TabIndex"), Integer)
        Me.cboProducts.Text = resources.GetString("cboProducts.Text")
        Me.cboProducts.Visible = CType(resources.GetObject("cboProducts.Visible"), Boolean)
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
        'TabPage2
        '
        Me.TabPage2.AccessibleDescription = CType(resources.GetObject("TabPage2.AccessibleDescription"), String)
        Me.TabPage2.AccessibleName = CType(resources.GetObject("TabPage2.AccessibleName"), String)
        Me.TabPage2.Anchor = CType(resources.GetObject("TabPage2.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.TabPage2.AutoScroll = CType(resources.GetObject("TabPage2.AutoScroll"), Boolean)
        Me.TabPage2.AutoScrollMargin = CType(resources.GetObject("TabPage2.AutoScrollMargin"), System.Drawing.Size)
        Me.TabPage2.AutoScrollMinSize = CType(resources.GetObject("TabPage2.AutoScrollMinSize"), System.Drawing.Size)
        Me.TabPage2.BackgroundImage = CType(resources.GetObject("TabPage2.BackgroundImage"), System.Drawing.Image)
        Me.TabPage2.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtChecked, Me.btnShowCheckedItems, Me.clstProducts})
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
        'txtChecked
        '
        Me.txtChecked.AccessibleDescription = resources.GetString("txtChecked.AccessibleDescription")
        Me.txtChecked.AccessibleName = resources.GetString("txtChecked.AccessibleName")
        Me.txtChecked.Anchor = CType(resources.GetObject("txtChecked.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtChecked.AutoSize = CType(resources.GetObject("txtChecked.AutoSize"), Boolean)
        Me.txtChecked.BackgroundImage = CType(resources.GetObject("txtChecked.BackgroundImage"), System.Drawing.Image)
        Me.txtChecked.Dock = CType(resources.GetObject("txtChecked.Dock"), System.Windows.Forms.DockStyle)
        Me.txtChecked.Enabled = CType(resources.GetObject("txtChecked.Enabled"), Boolean)
        Me.txtChecked.Font = CType(resources.GetObject("txtChecked.Font"), System.Drawing.Font)
        Me.txtChecked.ImeMode = CType(resources.GetObject("txtChecked.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtChecked.Location = CType(resources.GetObject("txtChecked.Location"), System.Drawing.Point)
        Me.txtChecked.MaxLength = CType(resources.GetObject("txtChecked.MaxLength"), Integer)
        Me.txtChecked.Multiline = CType(resources.GetObject("txtChecked.Multiline"), Boolean)
        Me.txtChecked.Name = "txtChecked"
        Me.txtChecked.PasswordChar = CType(resources.GetObject("txtChecked.PasswordChar"), Char)
        Me.txtChecked.RightToLeft = CType(resources.GetObject("txtChecked.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtChecked.ScrollBars = CType(resources.GetObject("txtChecked.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtChecked.Size = CType(resources.GetObject("txtChecked.Size"), System.Drawing.Size)
        Me.txtChecked.TabIndex = CType(resources.GetObject("txtChecked.TabIndex"), Integer)
        Me.txtChecked.Text = resources.GetString("txtChecked.Text")
        Me.txtChecked.TextAlign = CType(resources.GetObject("txtChecked.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtChecked.Visible = CType(resources.GetObject("txtChecked.Visible"), Boolean)
        Me.txtChecked.WordWrap = CType(resources.GetObject("txtChecked.WordWrap"), Boolean)
        '
        'btnShowCheckedItems
        '
        Me.btnShowCheckedItems.AccessibleDescription = resources.GetString("btnShowCheckedItems.AccessibleDescription")
        Me.btnShowCheckedItems.AccessibleName = resources.GetString("btnShowCheckedItems.AccessibleName")
        Me.btnShowCheckedItems.Anchor = CType(resources.GetObject("btnShowCheckedItems.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnShowCheckedItems.BackgroundImage = CType(resources.GetObject("btnShowCheckedItems.BackgroundImage"), System.Drawing.Image)
        Me.btnShowCheckedItems.Dock = CType(resources.GetObject("btnShowCheckedItems.Dock"), System.Windows.Forms.DockStyle)
        Me.btnShowCheckedItems.Enabled = CType(resources.GetObject("btnShowCheckedItems.Enabled"), Boolean)
        Me.btnShowCheckedItems.FlatStyle = CType(resources.GetObject("btnShowCheckedItems.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnShowCheckedItems.Font = CType(resources.GetObject("btnShowCheckedItems.Font"), System.Drawing.Font)
        Me.btnShowCheckedItems.Image = CType(resources.GetObject("btnShowCheckedItems.Image"), System.Drawing.Image)
        Me.btnShowCheckedItems.ImageAlign = CType(resources.GetObject("btnShowCheckedItems.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnShowCheckedItems.ImageIndex = CType(resources.GetObject("btnShowCheckedItems.ImageIndex"), Integer)
        Me.btnShowCheckedItems.ImeMode = CType(resources.GetObject("btnShowCheckedItems.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnShowCheckedItems.Location = CType(resources.GetObject("btnShowCheckedItems.Location"), System.Drawing.Point)
        Me.btnShowCheckedItems.Name = "btnShowCheckedItems"
        Me.btnShowCheckedItems.RightToLeft = CType(resources.GetObject("btnShowCheckedItems.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnShowCheckedItems.Size = CType(resources.GetObject("btnShowCheckedItems.Size"), System.Drawing.Size)
        Me.btnShowCheckedItems.TabIndex = CType(resources.GetObject("btnShowCheckedItems.TabIndex"), Integer)
        Me.btnShowCheckedItems.Text = resources.GetString("btnShowCheckedItems.Text")
        Me.btnShowCheckedItems.TextAlign = CType(resources.GetObject("btnShowCheckedItems.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnShowCheckedItems.Visible = CType(resources.GetObject("btnShowCheckedItems.Visible"), Boolean)
        '
        'clstProducts
        '
        Me.clstProducts.AccessibleDescription = resources.GetString("clstProducts.AccessibleDescription")
        Me.clstProducts.AccessibleName = resources.GetString("clstProducts.AccessibleName")
        Me.clstProducts.Anchor = CType(resources.GetObject("clstProducts.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.clstProducts.BackgroundImage = CType(resources.GetObject("clstProducts.BackgroundImage"), System.Drawing.Image)
        Me.clstProducts.CheckOnClick = True
        Me.clstProducts.ColumnWidth = CType(resources.GetObject("clstProducts.ColumnWidth"), Integer)
        Me.clstProducts.Dock = CType(resources.GetObject("clstProducts.Dock"), System.Windows.Forms.DockStyle)
        Me.clstProducts.Enabled = CType(resources.GetObject("clstProducts.Enabled"), Boolean)
        Me.clstProducts.Font = CType(resources.GetObject("clstProducts.Font"), System.Drawing.Font)
        Me.clstProducts.HorizontalExtent = CType(resources.GetObject("clstProducts.HorizontalExtent"), Integer)
        Me.clstProducts.HorizontalScrollbar = CType(resources.GetObject("clstProducts.HorizontalScrollbar"), Boolean)
        Me.clstProducts.ImeMode = CType(resources.GetObject("clstProducts.ImeMode"), System.Windows.Forms.ImeMode)
        Me.clstProducts.IntegralHeight = CType(resources.GetObject("clstProducts.IntegralHeight"), Boolean)
        Me.clstProducts.Location = CType(resources.GetObject("clstProducts.Location"), System.Drawing.Point)
        Me.clstProducts.MultiColumn = True
        Me.clstProducts.Name = "clstProducts"
        Me.clstProducts.RightToLeft = CType(resources.GetObject("clstProducts.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.clstProducts.ScrollAlwaysVisible = CType(resources.GetObject("clstProducts.ScrollAlwaysVisible"), Boolean)
        Me.clstProducts.Size = CType(resources.GetObject("clstProducts.Size"), System.Drawing.Size)
        Me.clstProducts.TabIndex = CType(resources.GetObject("clstProducts.TabIndex"), Integer)
        Me.clstProducts.Visible = CType(resources.GetObject("clstProducts.Visible"), Boolean)
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
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1})
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

    ' This routine handles the "Bind ComboBox" button Click event.
    Private Sub btnBindComboBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBindComboBox.Click
        lblSelected.Text = ""

        If optDataReader.Checked Then
            BindComboBoxUsingDataReader()
        Else
            BindComboBoxUsingDataSet()
        End If
    End Sub

    ' This routine handles the "Show Checked Items" button Click event. It displays
    ' a list of all the checked items in the CheckedListBox control.
    Private Sub btnShowChecked_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowCheckedItems.Click
        Dim sb As New StringBuilder()
        ' DataRowView is the Type of the objects stored in the CheckedItemCollection
        ' object exposed by the CheckedItems property.
        Dim drwvItem As DataRowView

        ' Make sure you access the CheckedItems property, not the SelectedItems 
        ' property. The latter contains only up to one item, as the SelectionMode
        ' for a CheckedListBox can only be set to "One" or "None". "Selected" means
        ' "highlighted", not "checked".
        For Each drwvItem In clstProducts.CheckedItems
            ' Because the objects in the collection are of type DataRowView, you
            ' cannot access the Text and Value like you would with a ComboBox
            ' (e.g., using .SelectedValue or .Text).
            sb.Append(drwvItem("Name"))
            sb.Append(" (")
            sb.Append(drwvItem("ID"))
            sb.Append("), ")
        Next

        txtChecked.Text = sb.ToString
    End Sub

    ' This routine handles the "Show Selected Item" button Click event. It displays
    ' the index, text, and value of the selected item in the ComboBox control.
    Private Sub btnShowSelectedItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowSelectedItem.Click
        With cboProducts
            ' Notice that to show the text of the selected item you do not access the
            ' SelectedText property (as you might think, because you accessed the
            ' SelectedValue property). Rather, this property is only for highlighted
            ' text when the DropDownStyle property of the ComboBox is not set to 
            ' DropDownList (an uneditable mode). This seems unintuitive. However, it 
            ' is consistent with the naming conventions of other controls with a 
            ' SelectedText property (e.g., the TextBox).
            lblSelected.Text = "You selected option " & .SelectedIndex.ToString & _
                ". Its value is " & .SelectedValue.ToString & " and its " & _
                "text is """ & .Text & """."
        End With
    End Sub

    ' This routine handles the Form's Load event.
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FormHasLoaded = True
        BindComboBoxUsingDataSet()
        BindCheckedListBoxUsingDataSet()
    End Sub

    ' This subroutine is used within a While...End While iteration through the 
    ' contents of a DataReader. It fills an ArrayList with instances of the custom
    ' Product class, the property values of which are initialized with data
    ' from the DataReader.
    Private Sub AddItemToDataSource(ByRef arl As ArrayList)
        With arl
            ' The DataReader value in the first column is retrieved in its native 
            ' datatype, which is the fastest way to retrieve data because it avoids
            ' late binding. You will notice that all of the Get____ methods take
            ' only the index as an argument.
            '
            ' For demonstration purposes, the second column is referenced by its 
            ' column name and late binding is implicitly used because the data is
            ' being retrieved as an Object type and ToString() invoked. In this case 
            ' you can use either an index or a column name. Using an index iis faster 
            ' as a column name lookup does not have to take place.
            '
            ' There is, however, a pitfall when only using ordinal values.
            ' If the field order changes in the SQL SELECT statement, the 
            ' data will be out of sync with the code. Using field names to
            ' reference the data in the DataReader ensures that the data properly 
            ' corresponds to the code (unless, of course, the field name is changed 
            ' in the database or a SQL "AS" keyword is used to alias the column.
            '
            ' For ProductName you could also use sdrProducts.GetString(1).
            .Add(New Helper.Product(sdrProducts.GetInt32(0), _
                sdrProducts("ProductName").ToString))
        End With
    End Sub

    ' This routine binds the CheckedListBox to a DataSet. As the code is identical 
    ' to that for the ComboBox, only binding to a DataSet is demonstrated.
    Private Sub BindCheckedListBoxUsingDataSet()
        ' See BindComboBoxUsingDataSet for further comments.
        With clstProducts
            .DisplayMember = "Name"
            .ValueMember = "ID"

            If Trim(txtNewOption.Text) <> "" Then
                .DataSource = Helper.UI.AddOption(dsProducts, .DisplayMember, _
                    .ValueMember, txtNewOption.Text, "0").Tables(0)
            Else
                .DataSource = dsProducts.Tables(0)
            End If
        End With
    End Sub

    ' This routine binds the ComboBox to an ArrayList filled by iterating 
    ' through a SqlDataReader. See also the comments in the Helper.Product
    ' class.
    Private Sub BindComboBoxUsingDataReader()
        strConn = SQL_CONNECTION_STRING

        Dim strSQL As String = _
            "SELECT ProductID, ProductName " & _
            "FROM Products " & _
            "ORDER BY ProductName"

        Dim scnnNorthwind As New SqlConnection(strConn)
        Dim scmd As New SqlCommand(strSQL, scnnNorthwind)
        arlProducts = New ArrayList()

        Dim frmStatusMessage As New frmStatus()

        Try
            frmStatusMessage.Show("Connecting to SQL Server to load Products " & _
                "using a DataReader")
            ' Demo purposes only: Wait 1 second so the user can see the status 
            ' message and verify that the ComboBox is loading from a DataReader.
            System.Threading.Thread.Sleep(1000)

            scnnNorthwind.Open()
            sdrProducts = scmd.ExecuteReader(CommandBehavior.CloseConnection)

            ' Iterate through the DataReader Items collection. The Read method
            ' returns a Boolean value = True while there are more rows to read.
            While sdrProducts.Read
                ' Fill one of the objects that implements the IList interface
                ' (in this case, an ArrayList) so that complex databinding can
                ' be used.
                AddItemToDataSource(arlProducts)
            End While

            With cboProducts
                .ValueMember = "ID"
                .DisplayMember = "Name"

                If Trim(txtNewOption.Text) <> "" Then
                    .DataSource = Helper.UI.AddOption(arlProducts, _
                        New Helper.Product(0, txtNewOption.Text))
                Else
                    .DataSource = arlProducts
                End If
            End With

            ' Close the DataReader and the status form.
            sdrProducts.Close()
            frmStatusMessage.Close()

        Catch expSql As SqlException
            MsgBox(expSql.ToString, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    ' This routine binds the ComboBox to a DataTable in a DataSet.
    Private Sub BindComboBoxUsingDataSet()
        strConn = SQL_CONNECTION_STRING

        ' Note: Column aliases are used so that the DisplayMember and
        ' ValueMember names are the same for both the SqlDataReader example
        ' and the DataSet example. If they are different a runtime error is
        ' thrown when switching back and forth between the two types of 
        ' databinding.
        Dim strSQL As String = _
            "SELECT ProductID As ID, ProductName As Name " & _
            "FROM Products " & _
            "ORDER BY ProductName"

        Dim scnnNorthwind As New SqlConnection(strConn)
        Dim scmd As New SqlCommand(strSQL, scnnNorthwind)
        Dim sda As New SqlDataAdapter(scmd)

        dsProducts = New DataSet()

        ' Display a status message saying that we're attempting to connect.
        ' This only needs to be done the very first time a connection is
        ' attempted.  After we've determined that MSDE or SQL Server is
        ' installed, this message no longer needs to be displayed.
        Dim frmStatusMessage As New frmStatus()
        frmStatusMessage.Show("Connecting to SQL Server to load Products " & _
            "using a DataSet")

        ' Attempt to connect to the local SQL server instance, or a local
        ' MSDE installation.
        Dim IsConnecting As Boolean = True
        While IsConnecting

            Try
                ' Bind the DataSet.
                sda.Fill(dsProducts)

                ' Connection successful so break out of the While loop and close 
                ' the status form.
                IsConnecting = False
                ' Wait 1 second so the user can see the status message.
                System.Threading.Thread.Sleep(1000)
                frmStatusMessage.Close()

            Catch expSql As SqlException
                MessageBox.Show(expSql.ToString, Me.Text, _
                    MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End While

        With cboProducts
            .DisplayMember = "Name"
            .ValueMember = "ID"

            ' Unlike the DropDownList WebControl, you have to access the 
            ' DataSet's Tables collection to databind, even if there is only 
            ' one DataTable in the DataSet.
            If Trim(txtNewOption.Text) <> "" Then
                .DataSource = Helper.UI.AddOption(dsProducts, .DisplayMember, _
                    .ValueMember, txtNewOption.Text, "0").Tables(0)
            Else
                .DataSource = dsProducts.Tables(0)
            End If
        End With
    End Sub

End Class