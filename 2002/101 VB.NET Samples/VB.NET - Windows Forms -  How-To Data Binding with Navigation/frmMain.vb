'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).
'Requires SQL Server or MSDE with the Northwind sample database installed.

Option Strict On

Imports System.Data.SqlClient

Public Class frmMain
	Inherits System.Windows.Forms.Form

    Protected productInfo As New ProductDataSet()

    Protected Const SQL_CONNECTION_STRING As String = _
       "Server=localhost;" & _
       "DataBase=Northwind;" & _
       "Integrated Security=SSPI"

    Protected Const MSDE_CONNECTION_STRING As String = _
        "Server=(local)\NetSDK;" & _
        "DataBase=Northwind;" & _
        "Integrated Security=SSPI"


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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtProductID As System.Windows.Forms.TextBox
    Friend WithEvents txtProductName As System.Windows.Forms.TextBox
    Friend WithEvents txtSupplier As System.Windows.Forms.TextBox
    Friend WithEvents txtCategory As System.Windows.Forms.TextBox
    Friend WithEvents txtQuantityPerUnit As System.Windows.Forms.TextBox
    Friend WithEvents txtUnitPrice As System.Windows.Forms.TextBox
    Friend WithEvents txtUnitsInStock As System.Windows.Forms.TextBox
    Friend WithEvents txtUnitsOnOrder As System.Windows.Forms.TextBox
    Friend WithEvents txtReorderLevel As System.Windows.Forms.TextBox
    Friend WithEvents txtDiscontinued As System.Windows.Forms.TextBox
    Friend WithEvents btnFirst As System.Windows.Forms.Button
    Friend WithEvents btnPrevious As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnLast As System.Windows.Forms.Button
    Friend WithEvents lblRecordNumber As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtProductID = New System.Windows.Forms.TextBox()
        Me.txtProductName = New System.Windows.Forms.TextBox()
        Me.txtSupplier = New System.Windows.Forms.TextBox()
        Me.txtCategory = New System.Windows.Forms.TextBox()
        Me.txtQuantityPerUnit = New System.Windows.Forms.TextBox()
        Me.txtUnitPrice = New System.Windows.Forms.TextBox()
        Me.txtUnitsInStock = New System.Windows.Forms.TextBox()
        Me.txtUnitsOnOrder = New System.Windows.Forms.TextBox()
        Me.txtReorderLevel = New System.Windows.Forms.TextBox()
        Me.txtDiscontinued = New System.Windows.Forms.TextBox()
        Me.btnFirst = New System.Windows.Forms.Button()
        Me.btnPrevious = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnLast = New System.Windows.Forms.Button()
        Me.lblRecordNumber = New System.Windows.Forms.Label()
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
        'txtProductID
        '
        Me.txtProductID.AccessibleDescription = CType(resources.GetObject("txtProductID.AccessibleDescription"), String)
        Me.txtProductID.AccessibleName = CType(resources.GetObject("txtProductID.AccessibleName"), String)
        Me.txtProductID.Anchor = CType(resources.GetObject("txtProductID.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtProductID.AutoSize = CType(resources.GetObject("txtProductID.AutoSize"), Boolean)
        Me.txtProductID.BackgroundImage = CType(resources.GetObject("txtProductID.BackgroundImage"), System.Drawing.Image)
        Me.txtProductID.Dock = CType(resources.GetObject("txtProductID.Dock"), System.Windows.Forms.DockStyle)
        Me.txtProductID.Enabled = CType(resources.GetObject("txtProductID.Enabled"), Boolean)
        Me.txtProductID.Font = CType(resources.GetObject("txtProductID.Font"), System.Drawing.Font)
        Me.txtProductID.ImeMode = CType(resources.GetObject("txtProductID.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtProductID.Location = CType(resources.GetObject("txtProductID.Location"), System.Drawing.Point)
        Me.txtProductID.MaxLength = CType(resources.GetObject("txtProductID.MaxLength"), Integer)
        Me.txtProductID.Multiline = CType(resources.GetObject("txtProductID.Multiline"), Boolean)
        Me.txtProductID.Name = "txtProductID"
        Me.txtProductID.PasswordChar = CType(resources.GetObject("txtProductID.PasswordChar"), Char)
        Me.txtProductID.ReadOnly = True
        Me.txtProductID.RightToLeft = CType(resources.GetObject("txtProductID.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtProductID.ScrollBars = CType(resources.GetObject("txtProductID.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtProductID.Size = CType(resources.GetObject("txtProductID.Size"), System.Drawing.Size)
        Me.txtProductID.TabIndex = CType(resources.GetObject("txtProductID.TabIndex"), Integer)
        Me.txtProductID.Text = resources.GetString("txtProductID.Text")
        Me.txtProductID.TextAlign = CType(resources.GetObject("txtProductID.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtProductID.Visible = CType(resources.GetObject("txtProductID.Visible"), Boolean)
        Me.txtProductID.WordWrap = CType(resources.GetObject("txtProductID.WordWrap"), Boolean)
        '
        'txtProductName
        '
        Me.txtProductName.AccessibleDescription = CType(resources.GetObject("txtProductName.AccessibleDescription"), String)
        Me.txtProductName.AccessibleName = CType(resources.GetObject("txtProductName.AccessibleName"), String)
        Me.txtProductName.Anchor = CType(resources.GetObject("txtProductName.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtProductName.AutoSize = CType(resources.GetObject("txtProductName.AutoSize"), Boolean)
        Me.txtProductName.BackgroundImage = CType(resources.GetObject("txtProductName.BackgroundImage"), System.Drawing.Image)
        Me.txtProductName.Dock = CType(resources.GetObject("txtProductName.Dock"), System.Windows.Forms.DockStyle)
        Me.txtProductName.Enabled = CType(resources.GetObject("txtProductName.Enabled"), Boolean)
        Me.txtProductName.Font = CType(resources.GetObject("txtProductName.Font"), System.Drawing.Font)
        Me.txtProductName.ImeMode = CType(resources.GetObject("txtProductName.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtProductName.Location = CType(resources.GetObject("txtProductName.Location"), System.Drawing.Point)
        Me.txtProductName.MaxLength = CType(resources.GetObject("txtProductName.MaxLength"), Integer)
        Me.txtProductName.Multiline = CType(resources.GetObject("txtProductName.Multiline"), Boolean)
        Me.txtProductName.Name = "txtProductName"
        Me.txtProductName.PasswordChar = CType(resources.GetObject("txtProductName.PasswordChar"), Char)
        Me.txtProductName.ReadOnly = True
        Me.txtProductName.RightToLeft = CType(resources.GetObject("txtProductName.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtProductName.ScrollBars = CType(resources.GetObject("txtProductName.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtProductName.Size = CType(resources.GetObject("txtProductName.Size"), System.Drawing.Size)
        Me.txtProductName.TabIndex = CType(resources.GetObject("txtProductName.TabIndex"), Integer)
        Me.txtProductName.Text = resources.GetString("txtProductName.Text")
        Me.txtProductName.TextAlign = CType(resources.GetObject("txtProductName.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtProductName.Visible = CType(resources.GetObject("txtProductName.Visible"), Boolean)
        Me.txtProductName.WordWrap = CType(resources.GetObject("txtProductName.WordWrap"), Boolean)
        '
        'txtSupplier
        '
        Me.txtSupplier.AccessibleDescription = CType(resources.GetObject("txtSupplier.AccessibleDescription"), String)
        Me.txtSupplier.AccessibleName = CType(resources.GetObject("txtSupplier.AccessibleName"), String)
        Me.txtSupplier.Anchor = CType(resources.GetObject("txtSupplier.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtSupplier.AutoSize = CType(resources.GetObject("txtSupplier.AutoSize"), Boolean)
        Me.txtSupplier.BackgroundImage = CType(resources.GetObject("txtSupplier.BackgroundImage"), System.Drawing.Image)
        Me.txtSupplier.Dock = CType(resources.GetObject("txtSupplier.Dock"), System.Windows.Forms.DockStyle)
        Me.txtSupplier.Enabled = CType(resources.GetObject("txtSupplier.Enabled"), Boolean)
        Me.txtSupplier.Font = CType(resources.GetObject("txtSupplier.Font"), System.Drawing.Font)
        Me.txtSupplier.ImeMode = CType(resources.GetObject("txtSupplier.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtSupplier.Location = CType(resources.GetObject("txtSupplier.Location"), System.Drawing.Point)
        Me.txtSupplier.MaxLength = CType(resources.GetObject("txtSupplier.MaxLength"), Integer)
        Me.txtSupplier.Multiline = CType(resources.GetObject("txtSupplier.Multiline"), Boolean)
        Me.txtSupplier.Name = "txtSupplier"
        Me.txtSupplier.PasswordChar = CType(resources.GetObject("txtSupplier.PasswordChar"), Char)
        Me.txtSupplier.ReadOnly = True
        Me.txtSupplier.RightToLeft = CType(resources.GetObject("txtSupplier.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtSupplier.ScrollBars = CType(resources.GetObject("txtSupplier.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtSupplier.Size = CType(resources.GetObject("txtSupplier.Size"), System.Drawing.Size)
        Me.txtSupplier.TabIndex = CType(resources.GetObject("txtSupplier.TabIndex"), Integer)
        Me.txtSupplier.Text = resources.GetString("txtSupplier.Text")
        Me.txtSupplier.TextAlign = CType(resources.GetObject("txtSupplier.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtSupplier.Visible = CType(resources.GetObject("txtSupplier.Visible"), Boolean)
        Me.txtSupplier.WordWrap = CType(resources.GetObject("txtSupplier.WordWrap"), Boolean)
        '
        'txtCategory
        '
        Me.txtCategory.AccessibleDescription = CType(resources.GetObject("txtCategory.AccessibleDescription"), String)
        Me.txtCategory.AccessibleName = CType(resources.GetObject("txtCategory.AccessibleName"), String)
        Me.txtCategory.Anchor = CType(resources.GetObject("txtCategory.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtCategory.AutoSize = CType(resources.GetObject("txtCategory.AutoSize"), Boolean)
        Me.txtCategory.BackgroundImage = CType(resources.GetObject("txtCategory.BackgroundImage"), System.Drawing.Image)
        Me.txtCategory.Dock = CType(resources.GetObject("txtCategory.Dock"), System.Windows.Forms.DockStyle)
        Me.txtCategory.Enabled = CType(resources.GetObject("txtCategory.Enabled"), Boolean)
        Me.txtCategory.Font = CType(resources.GetObject("txtCategory.Font"), System.Drawing.Font)
        Me.txtCategory.ImeMode = CType(resources.GetObject("txtCategory.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtCategory.Location = CType(resources.GetObject("txtCategory.Location"), System.Drawing.Point)
        Me.txtCategory.MaxLength = CType(resources.GetObject("txtCategory.MaxLength"), Integer)
        Me.txtCategory.Multiline = CType(resources.GetObject("txtCategory.Multiline"), Boolean)
        Me.txtCategory.Name = "txtCategory"
        Me.txtCategory.PasswordChar = CType(resources.GetObject("txtCategory.PasswordChar"), Char)
        Me.txtCategory.ReadOnly = True
        Me.txtCategory.RightToLeft = CType(resources.GetObject("txtCategory.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtCategory.ScrollBars = CType(resources.GetObject("txtCategory.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtCategory.Size = CType(resources.GetObject("txtCategory.Size"), System.Drawing.Size)
        Me.txtCategory.TabIndex = CType(resources.GetObject("txtCategory.TabIndex"), Integer)
        Me.txtCategory.Text = resources.GetString("txtCategory.Text")
        Me.txtCategory.TextAlign = CType(resources.GetObject("txtCategory.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtCategory.Visible = CType(resources.GetObject("txtCategory.Visible"), Boolean)
        Me.txtCategory.WordWrap = CType(resources.GetObject("txtCategory.WordWrap"), Boolean)
        '
        'txtQuantityPerUnit
        '
        Me.txtQuantityPerUnit.AccessibleDescription = CType(resources.GetObject("txtQuantityPerUnit.AccessibleDescription"), String)
        Me.txtQuantityPerUnit.AccessibleName = CType(resources.GetObject("txtQuantityPerUnit.AccessibleName"), String)
        Me.txtQuantityPerUnit.Anchor = CType(resources.GetObject("txtQuantityPerUnit.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtQuantityPerUnit.AutoSize = CType(resources.GetObject("txtQuantityPerUnit.AutoSize"), Boolean)
        Me.txtQuantityPerUnit.BackgroundImage = CType(resources.GetObject("txtQuantityPerUnit.BackgroundImage"), System.Drawing.Image)
        Me.txtQuantityPerUnit.Dock = CType(resources.GetObject("txtQuantityPerUnit.Dock"), System.Windows.Forms.DockStyle)
        Me.txtQuantityPerUnit.Enabled = CType(resources.GetObject("txtQuantityPerUnit.Enabled"), Boolean)
        Me.txtQuantityPerUnit.Font = CType(resources.GetObject("txtQuantityPerUnit.Font"), System.Drawing.Font)
        Me.txtQuantityPerUnit.ImeMode = CType(resources.GetObject("txtQuantityPerUnit.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtQuantityPerUnit.Location = CType(resources.GetObject("txtQuantityPerUnit.Location"), System.Drawing.Point)
        Me.txtQuantityPerUnit.MaxLength = CType(resources.GetObject("txtQuantityPerUnit.MaxLength"), Integer)
        Me.txtQuantityPerUnit.Multiline = CType(resources.GetObject("txtQuantityPerUnit.Multiline"), Boolean)
        Me.txtQuantityPerUnit.Name = "txtQuantityPerUnit"
        Me.txtQuantityPerUnit.PasswordChar = CType(resources.GetObject("txtQuantityPerUnit.PasswordChar"), Char)
        Me.txtQuantityPerUnit.ReadOnly = True
        Me.txtQuantityPerUnit.RightToLeft = CType(resources.GetObject("txtQuantityPerUnit.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtQuantityPerUnit.ScrollBars = CType(resources.GetObject("txtQuantityPerUnit.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtQuantityPerUnit.Size = CType(resources.GetObject("txtQuantityPerUnit.Size"), System.Drawing.Size)
        Me.txtQuantityPerUnit.TabIndex = CType(resources.GetObject("txtQuantityPerUnit.TabIndex"), Integer)
        Me.txtQuantityPerUnit.Text = resources.GetString("txtQuantityPerUnit.Text")
        Me.txtQuantityPerUnit.TextAlign = CType(resources.GetObject("txtQuantityPerUnit.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtQuantityPerUnit.Visible = CType(resources.GetObject("txtQuantityPerUnit.Visible"), Boolean)
        Me.txtQuantityPerUnit.WordWrap = CType(resources.GetObject("txtQuantityPerUnit.WordWrap"), Boolean)
        '
        'txtUnitPrice
        '
        Me.txtUnitPrice.AccessibleDescription = CType(resources.GetObject("txtUnitPrice.AccessibleDescription"), String)
        Me.txtUnitPrice.AccessibleName = CType(resources.GetObject("txtUnitPrice.AccessibleName"), String)
        Me.txtUnitPrice.Anchor = CType(resources.GetObject("txtUnitPrice.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtUnitPrice.AutoSize = CType(resources.GetObject("txtUnitPrice.AutoSize"), Boolean)
        Me.txtUnitPrice.BackgroundImage = CType(resources.GetObject("txtUnitPrice.BackgroundImage"), System.Drawing.Image)
        Me.txtUnitPrice.Dock = CType(resources.GetObject("txtUnitPrice.Dock"), System.Windows.Forms.DockStyle)
        Me.txtUnitPrice.Enabled = CType(resources.GetObject("txtUnitPrice.Enabled"), Boolean)
        Me.txtUnitPrice.Font = CType(resources.GetObject("txtUnitPrice.Font"), System.Drawing.Font)
        Me.txtUnitPrice.ImeMode = CType(resources.GetObject("txtUnitPrice.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtUnitPrice.Location = CType(resources.GetObject("txtUnitPrice.Location"), System.Drawing.Point)
        Me.txtUnitPrice.MaxLength = CType(resources.GetObject("txtUnitPrice.MaxLength"), Integer)
        Me.txtUnitPrice.Multiline = CType(resources.GetObject("txtUnitPrice.Multiline"), Boolean)
        Me.txtUnitPrice.Name = "txtUnitPrice"
        Me.txtUnitPrice.PasswordChar = CType(resources.GetObject("txtUnitPrice.PasswordChar"), Char)
        Me.txtUnitPrice.ReadOnly = True
        Me.txtUnitPrice.RightToLeft = CType(resources.GetObject("txtUnitPrice.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtUnitPrice.ScrollBars = CType(resources.GetObject("txtUnitPrice.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtUnitPrice.Size = CType(resources.GetObject("txtUnitPrice.Size"), System.Drawing.Size)
        Me.txtUnitPrice.TabIndex = CType(resources.GetObject("txtUnitPrice.TabIndex"), Integer)
        Me.txtUnitPrice.Text = resources.GetString("txtUnitPrice.Text")
        Me.txtUnitPrice.TextAlign = CType(resources.GetObject("txtUnitPrice.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtUnitPrice.Visible = CType(resources.GetObject("txtUnitPrice.Visible"), Boolean)
        Me.txtUnitPrice.WordWrap = CType(resources.GetObject("txtUnitPrice.WordWrap"), Boolean)
        '
        'txtUnitsInStock
        '
        Me.txtUnitsInStock.AccessibleDescription = CType(resources.GetObject("txtUnitsInStock.AccessibleDescription"), String)
        Me.txtUnitsInStock.AccessibleName = CType(resources.GetObject("txtUnitsInStock.AccessibleName"), String)
        Me.txtUnitsInStock.Anchor = CType(resources.GetObject("txtUnitsInStock.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtUnitsInStock.AutoSize = CType(resources.GetObject("txtUnitsInStock.AutoSize"), Boolean)
        Me.txtUnitsInStock.BackgroundImage = CType(resources.GetObject("txtUnitsInStock.BackgroundImage"), System.Drawing.Image)
        Me.txtUnitsInStock.Dock = CType(resources.GetObject("txtUnitsInStock.Dock"), System.Windows.Forms.DockStyle)
        Me.txtUnitsInStock.Enabled = CType(resources.GetObject("txtUnitsInStock.Enabled"), Boolean)
        Me.txtUnitsInStock.Font = CType(resources.GetObject("txtUnitsInStock.Font"), System.Drawing.Font)
        Me.txtUnitsInStock.ImeMode = CType(resources.GetObject("txtUnitsInStock.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtUnitsInStock.Location = CType(resources.GetObject("txtUnitsInStock.Location"), System.Drawing.Point)
        Me.txtUnitsInStock.MaxLength = CType(resources.GetObject("txtUnitsInStock.MaxLength"), Integer)
        Me.txtUnitsInStock.Multiline = CType(resources.GetObject("txtUnitsInStock.Multiline"), Boolean)
        Me.txtUnitsInStock.Name = "txtUnitsInStock"
        Me.txtUnitsInStock.PasswordChar = CType(resources.GetObject("txtUnitsInStock.PasswordChar"), Char)
        Me.txtUnitsInStock.ReadOnly = True
        Me.txtUnitsInStock.RightToLeft = CType(resources.GetObject("txtUnitsInStock.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtUnitsInStock.ScrollBars = CType(resources.GetObject("txtUnitsInStock.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtUnitsInStock.Size = CType(resources.GetObject("txtUnitsInStock.Size"), System.Drawing.Size)
        Me.txtUnitsInStock.TabIndex = CType(resources.GetObject("txtUnitsInStock.TabIndex"), Integer)
        Me.txtUnitsInStock.Text = resources.GetString("txtUnitsInStock.Text")
        Me.txtUnitsInStock.TextAlign = CType(resources.GetObject("txtUnitsInStock.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtUnitsInStock.Visible = CType(resources.GetObject("txtUnitsInStock.Visible"), Boolean)
        Me.txtUnitsInStock.WordWrap = CType(resources.GetObject("txtUnitsInStock.WordWrap"), Boolean)
        '
        'txtUnitsOnOrder
        '
        Me.txtUnitsOnOrder.AccessibleDescription = CType(resources.GetObject("txtUnitsOnOrder.AccessibleDescription"), String)
        Me.txtUnitsOnOrder.AccessibleName = CType(resources.GetObject("txtUnitsOnOrder.AccessibleName"), String)
        Me.txtUnitsOnOrder.Anchor = CType(resources.GetObject("txtUnitsOnOrder.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtUnitsOnOrder.AutoSize = CType(resources.GetObject("txtUnitsOnOrder.AutoSize"), Boolean)
        Me.txtUnitsOnOrder.BackgroundImage = CType(resources.GetObject("txtUnitsOnOrder.BackgroundImage"), System.Drawing.Image)
        Me.txtUnitsOnOrder.Dock = CType(resources.GetObject("txtUnitsOnOrder.Dock"), System.Windows.Forms.DockStyle)
        Me.txtUnitsOnOrder.Enabled = CType(resources.GetObject("txtUnitsOnOrder.Enabled"), Boolean)
        Me.txtUnitsOnOrder.Font = CType(resources.GetObject("txtUnitsOnOrder.Font"), System.Drawing.Font)
        Me.txtUnitsOnOrder.ImeMode = CType(resources.GetObject("txtUnitsOnOrder.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtUnitsOnOrder.Location = CType(resources.GetObject("txtUnitsOnOrder.Location"), System.Drawing.Point)
        Me.txtUnitsOnOrder.MaxLength = CType(resources.GetObject("txtUnitsOnOrder.MaxLength"), Integer)
        Me.txtUnitsOnOrder.Multiline = CType(resources.GetObject("txtUnitsOnOrder.Multiline"), Boolean)
        Me.txtUnitsOnOrder.Name = "txtUnitsOnOrder"
        Me.txtUnitsOnOrder.PasswordChar = CType(resources.GetObject("txtUnitsOnOrder.PasswordChar"), Char)
        Me.txtUnitsOnOrder.ReadOnly = True
        Me.txtUnitsOnOrder.RightToLeft = CType(resources.GetObject("txtUnitsOnOrder.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtUnitsOnOrder.ScrollBars = CType(resources.GetObject("txtUnitsOnOrder.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtUnitsOnOrder.Size = CType(resources.GetObject("txtUnitsOnOrder.Size"), System.Drawing.Size)
        Me.txtUnitsOnOrder.TabIndex = CType(resources.GetObject("txtUnitsOnOrder.TabIndex"), Integer)
        Me.txtUnitsOnOrder.Text = resources.GetString("txtUnitsOnOrder.Text")
        Me.txtUnitsOnOrder.TextAlign = CType(resources.GetObject("txtUnitsOnOrder.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtUnitsOnOrder.Visible = CType(resources.GetObject("txtUnitsOnOrder.Visible"), Boolean)
        Me.txtUnitsOnOrder.WordWrap = CType(resources.GetObject("txtUnitsOnOrder.WordWrap"), Boolean)
        '
        'txtReorderLevel
        '
        Me.txtReorderLevel.AccessibleDescription = CType(resources.GetObject("txtReorderLevel.AccessibleDescription"), String)
        Me.txtReorderLevel.AccessibleName = CType(resources.GetObject("txtReorderLevel.AccessibleName"), String)
        Me.txtReorderLevel.Anchor = CType(resources.GetObject("txtReorderLevel.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtReorderLevel.AutoSize = CType(resources.GetObject("txtReorderLevel.AutoSize"), Boolean)
        Me.txtReorderLevel.BackgroundImage = CType(resources.GetObject("txtReorderLevel.BackgroundImage"), System.Drawing.Image)
        Me.txtReorderLevel.Dock = CType(resources.GetObject("txtReorderLevel.Dock"), System.Windows.Forms.DockStyle)
        Me.txtReorderLevel.Enabled = CType(resources.GetObject("txtReorderLevel.Enabled"), Boolean)
        Me.txtReorderLevel.Font = CType(resources.GetObject("txtReorderLevel.Font"), System.Drawing.Font)
        Me.txtReorderLevel.ImeMode = CType(resources.GetObject("txtReorderLevel.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtReorderLevel.Location = CType(resources.GetObject("txtReorderLevel.Location"), System.Drawing.Point)
        Me.txtReorderLevel.MaxLength = CType(resources.GetObject("txtReorderLevel.MaxLength"), Integer)
        Me.txtReorderLevel.Multiline = CType(resources.GetObject("txtReorderLevel.Multiline"), Boolean)
        Me.txtReorderLevel.Name = "txtReorderLevel"
        Me.txtReorderLevel.PasswordChar = CType(resources.GetObject("txtReorderLevel.PasswordChar"), Char)
        Me.txtReorderLevel.ReadOnly = True
        Me.txtReorderLevel.RightToLeft = CType(resources.GetObject("txtReorderLevel.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtReorderLevel.ScrollBars = CType(resources.GetObject("txtReorderLevel.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtReorderLevel.Size = CType(resources.GetObject("txtReorderLevel.Size"), System.Drawing.Size)
        Me.txtReorderLevel.TabIndex = CType(resources.GetObject("txtReorderLevel.TabIndex"), Integer)
        Me.txtReorderLevel.Text = resources.GetString("txtReorderLevel.Text")
        Me.txtReorderLevel.TextAlign = CType(resources.GetObject("txtReorderLevel.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtReorderLevel.Visible = CType(resources.GetObject("txtReorderLevel.Visible"), Boolean)
        Me.txtReorderLevel.WordWrap = CType(resources.GetObject("txtReorderLevel.WordWrap"), Boolean)
        '
        'txtDiscontinued
        '
        Me.txtDiscontinued.AccessibleDescription = CType(resources.GetObject("txtDiscontinued.AccessibleDescription"), String)
        Me.txtDiscontinued.AccessibleName = CType(resources.GetObject("txtDiscontinued.AccessibleName"), String)
        Me.txtDiscontinued.Anchor = CType(resources.GetObject("txtDiscontinued.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtDiscontinued.AutoSize = CType(resources.GetObject("txtDiscontinued.AutoSize"), Boolean)
        Me.txtDiscontinued.BackgroundImage = CType(resources.GetObject("txtDiscontinued.BackgroundImage"), System.Drawing.Image)
        Me.txtDiscontinued.Dock = CType(resources.GetObject("txtDiscontinued.Dock"), System.Windows.Forms.DockStyle)
        Me.txtDiscontinued.Enabled = CType(resources.GetObject("txtDiscontinued.Enabled"), Boolean)
        Me.txtDiscontinued.Font = CType(resources.GetObject("txtDiscontinued.Font"), System.Drawing.Font)
        Me.txtDiscontinued.ImeMode = CType(resources.GetObject("txtDiscontinued.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtDiscontinued.Location = CType(resources.GetObject("txtDiscontinued.Location"), System.Drawing.Point)
        Me.txtDiscontinued.MaxLength = CType(resources.GetObject("txtDiscontinued.MaxLength"), Integer)
        Me.txtDiscontinued.Multiline = CType(resources.GetObject("txtDiscontinued.Multiline"), Boolean)
        Me.txtDiscontinued.Name = "txtDiscontinued"
        Me.txtDiscontinued.PasswordChar = CType(resources.GetObject("txtDiscontinued.PasswordChar"), Char)
        Me.txtDiscontinued.ReadOnly = True
        Me.txtDiscontinued.RightToLeft = CType(resources.GetObject("txtDiscontinued.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtDiscontinued.ScrollBars = CType(resources.GetObject("txtDiscontinued.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtDiscontinued.Size = CType(resources.GetObject("txtDiscontinued.Size"), System.Drawing.Size)
        Me.txtDiscontinued.TabIndex = CType(resources.GetObject("txtDiscontinued.TabIndex"), Integer)
        Me.txtDiscontinued.Text = resources.GetString("txtDiscontinued.Text")
        Me.txtDiscontinued.TextAlign = CType(resources.GetObject("txtDiscontinued.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtDiscontinued.Visible = CType(resources.GetObject("txtDiscontinued.Visible"), Boolean)
        Me.txtDiscontinued.WordWrap = CType(resources.GetObject("txtDiscontinued.WordWrap"), Boolean)
        '
        'btnFirst
        '
        Me.btnFirst.AccessibleDescription = CType(resources.GetObject("btnFirst.AccessibleDescription"), String)
        Me.btnFirst.AccessibleName = CType(resources.GetObject("btnFirst.AccessibleName"), String)
        Me.btnFirst.Anchor = CType(resources.GetObject("btnFirst.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnFirst.BackgroundImage = CType(resources.GetObject("btnFirst.BackgroundImage"), System.Drawing.Image)
        Me.btnFirst.Dock = CType(resources.GetObject("btnFirst.Dock"), System.Windows.Forms.DockStyle)
        Me.btnFirst.Enabled = CType(resources.GetObject("btnFirst.Enabled"), Boolean)
        Me.btnFirst.FlatStyle = CType(resources.GetObject("btnFirst.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnFirst.Font = CType(resources.GetObject("btnFirst.Font"), System.Drawing.Font)
        Me.btnFirst.Image = CType(resources.GetObject("btnFirst.Image"), System.Drawing.Image)
        Me.btnFirst.ImageAlign = CType(resources.GetObject("btnFirst.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnFirst.ImageIndex = CType(resources.GetObject("btnFirst.ImageIndex"), Integer)
        Me.btnFirst.ImeMode = CType(resources.GetObject("btnFirst.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnFirst.Location = CType(resources.GetObject("btnFirst.Location"), System.Drawing.Point)
        Me.btnFirst.Name = "btnFirst"
        Me.btnFirst.RightToLeft = CType(resources.GetObject("btnFirst.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnFirst.Size = CType(resources.GetObject("btnFirst.Size"), System.Drawing.Size)
        Me.btnFirst.TabIndex = CType(resources.GetObject("btnFirst.TabIndex"), Integer)
        Me.btnFirst.Text = resources.GetString("btnFirst.Text")
        Me.btnFirst.TextAlign = CType(resources.GetObject("btnFirst.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnFirst.Visible = CType(resources.GetObject("btnFirst.Visible"), Boolean)
        '
        'btnPrevious
        '
        Me.btnPrevious.AccessibleDescription = CType(resources.GetObject("btnPrevious.AccessibleDescription"), String)
        Me.btnPrevious.AccessibleName = CType(resources.GetObject("btnPrevious.AccessibleName"), String)
        Me.btnPrevious.Anchor = CType(resources.GetObject("btnPrevious.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnPrevious.BackgroundImage = CType(resources.GetObject("btnPrevious.BackgroundImage"), System.Drawing.Image)
        Me.btnPrevious.Dock = CType(resources.GetObject("btnPrevious.Dock"), System.Windows.Forms.DockStyle)
        Me.btnPrevious.Enabled = CType(resources.GetObject("btnPrevious.Enabled"), Boolean)
        Me.btnPrevious.FlatStyle = CType(resources.GetObject("btnPrevious.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnPrevious.Font = CType(resources.GetObject("btnPrevious.Font"), System.Drawing.Font)
        Me.btnPrevious.Image = CType(resources.GetObject("btnPrevious.Image"), System.Drawing.Image)
        Me.btnPrevious.ImageAlign = CType(resources.GetObject("btnPrevious.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnPrevious.ImageIndex = CType(resources.GetObject("btnPrevious.ImageIndex"), Integer)
        Me.btnPrevious.ImeMode = CType(resources.GetObject("btnPrevious.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnPrevious.Location = CType(resources.GetObject("btnPrevious.Location"), System.Drawing.Point)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.RightToLeft = CType(resources.GetObject("btnPrevious.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnPrevious.Size = CType(resources.GetObject("btnPrevious.Size"), System.Drawing.Size)
        Me.btnPrevious.TabIndex = CType(resources.GetObject("btnPrevious.TabIndex"), Integer)
        Me.btnPrevious.Text = resources.GetString("btnPrevious.Text")
        Me.btnPrevious.TextAlign = CType(resources.GetObject("btnPrevious.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnPrevious.Visible = CType(resources.GetObject("btnPrevious.Visible"), Boolean)
        '
        'btnNext
        '
        Me.btnNext.AccessibleDescription = CType(resources.GetObject("btnNext.AccessibleDescription"), String)
        Me.btnNext.AccessibleName = CType(resources.GetObject("btnNext.AccessibleName"), String)
        Me.btnNext.Anchor = CType(resources.GetObject("btnNext.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnNext.BackgroundImage = CType(resources.GetObject("btnNext.BackgroundImage"), System.Drawing.Image)
        Me.btnNext.Dock = CType(resources.GetObject("btnNext.Dock"), System.Windows.Forms.DockStyle)
        Me.btnNext.Enabled = CType(resources.GetObject("btnNext.Enabled"), Boolean)
        Me.btnNext.FlatStyle = CType(resources.GetObject("btnNext.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnNext.Font = CType(resources.GetObject("btnNext.Font"), System.Drawing.Font)
        Me.btnNext.Image = CType(resources.GetObject("btnNext.Image"), System.Drawing.Image)
        Me.btnNext.ImageAlign = CType(resources.GetObject("btnNext.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnNext.ImageIndex = CType(resources.GetObject("btnNext.ImageIndex"), Integer)
        Me.btnNext.ImeMode = CType(resources.GetObject("btnNext.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnNext.Location = CType(resources.GetObject("btnNext.Location"), System.Drawing.Point)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.RightToLeft = CType(resources.GetObject("btnNext.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnNext.Size = CType(resources.GetObject("btnNext.Size"), System.Drawing.Size)
        Me.btnNext.TabIndex = CType(resources.GetObject("btnNext.TabIndex"), Integer)
        Me.btnNext.Text = resources.GetString("btnNext.Text")
        Me.btnNext.TextAlign = CType(resources.GetObject("btnNext.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnNext.Visible = CType(resources.GetObject("btnNext.Visible"), Boolean)
        '
        'btnLast
        '
        Me.btnLast.AccessibleDescription = CType(resources.GetObject("btnLast.AccessibleDescription"), String)
        Me.btnLast.AccessibleName = CType(resources.GetObject("btnLast.AccessibleName"), String)
        Me.btnLast.Anchor = CType(resources.GetObject("btnLast.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnLast.BackgroundImage = CType(resources.GetObject("btnLast.BackgroundImage"), System.Drawing.Image)
        Me.btnLast.Dock = CType(resources.GetObject("btnLast.Dock"), System.Windows.Forms.DockStyle)
        Me.btnLast.Enabled = CType(resources.GetObject("btnLast.Enabled"), Boolean)
        Me.btnLast.FlatStyle = CType(resources.GetObject("btnLast.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnLast.Font = CType(resources.GetObject("btnLast.Font"), System.Drawing.Font)
        Me.btnLast.Image = CType(resources.GetObject("btnLast.Image"), System.Drawing.Image)
        Me.btnLast.ImageAlign = CType(resources.GetObject("btnLast.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnLast.ImageIndex = CType(resources.GetObject("btnLast.ImageIndex"), Integer)
        Me.btnLast.ImeMode = CType(resources.GetObject("btnLast.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnLast.Location = CType(resources.GetObject("btnLast.Location"), System.Drawing.Point)
        Me.btnLast.Name = "btnLast"
        Me.btnLast.RightToLeft = CType(resources.GetObject("btnLast.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnLast.Size = CType(resources.GetObject("btnLast.Size"), System.Drawing.Size)
        Me.btnLast.TabIndex = CType(resources.GetObject("btnLast.TabIndex"), Integer)
        Me.btnLast.Text = resources.GetString("btnLast.Text")
        Me.btnLast.TextAlign = CType(resources.GetObject("btnLast.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnLast.Visible = CType(resources.GetObject("btnLast.Visible"), Boolean)
        '
        'lblRecordNumber
        '
        Me.lblRecordNumber.AccessibleDescription = CType(resources.GetObject("lblRecordNumber.AccessibleDescription"), String)
        Me.lblRecordNumber.AccessibleName = CType(resources.GetObject("lblRecordNumber.AccessibleName"), String)
        Me.lblRecordNumber.Anchor = CType(resources.GetObject("lblRecordNumber.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblRecordNumber.AutoSize = CType(resources.GetObject("lblRecordNumber.AutoSize"), Boolean)
        Me.lblRecordNumber.Dock = CType(resources.GetObject("lblRecordNumber.Dock"), System.Windows.Forms.DockStyle)
        Me.lblRecordNumber.Enabled = CType(resources.GetObject("lblRecordNumber.Enabled"), Boolean)
        Me.lblRecordNumber.Font = CType(resources.GetObject("lblRecordNumber.Font"), System.Drawing.Font)
        Me.lblRecordNumber.Image = CType(resources.GetObject("lblRecordNumber.Image"), System.Drawing.Image)
        Me.lblRecordNumber.ImageAlign = CType(resources.GetObject("lblRecordNumber.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblRecordNumber.ImageIndex = CType(resources.GetObject("lblRecordNumber.ImageIndex"), Integer)
        Me.lblRecordNumber.ImeMode = CType(resources.GetObject("lblRecordNumber.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblRecordNumber.Location = CType(resources.GetObject("lblRecordNumber.Location"), System.Drawing.Point)
        Me.lblRecordNumber.Name = "lblRecordNumber"
        Me.lblRecordNumber.RightToLeft = CType(resources.GetObject("lblRecordNumber.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblRecordNumber.Size = CType(resources.GetObject("lblRecordNumber.Size"), System.Drawing.Size)
        Me.lblRecordNumber.TabIndex = CType(resources.GetObject("lblRecordNumber.TabIndex"), Integer)
        Me.lblRecordNumber.Text = resources.GetString("lblRecordNumber.Text")
        Me.lblRecordNumber.TextAlign = CType(resources.GetObject("lblRecordNumber.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblRecordNumber.Visible = CType(resources.GetObject("lblRecordNumber.Visible"), Boolean)
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
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblRecordNumber, Me.btnLast, Me.btnNext, Me.btnPrevious, Me.btnFirst, Me.txtDiscontinued, Me.txtReorderLevel, Me.txtUnitsOnOrder, Me.txtUnitsInStock, Me.txtUnitPrice, Me.txtQuantityPerUnit, Me.txtCategory, Me.txtSupplier, Me.txtProductName, Me.txtProductID, Me.Label10, Me.Label9, Me.Label8, Me.Label7, Me.Label6, Me.Label5, Me.Label4, Me.Label3, Me.Label2, Me.Label1})
        Me.Dock = CType(resources.GetObject("$this.Dock"), System.Windows.Forms.DockStyle)
        Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
        Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
        Me.KeyPreview = True
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

    ' When databinding to a boolean value, this converts the true/false to
    ' a yes/no string.
    Protected Sub BooleanToYesNo(ByVal sender As Object, ByVal e As ConvertEventArgs)
        ' The method converts only to string type. Test this using the DesiredType.
        If Not e.DesiredType Is GetType(String) Then
            Exit Sub
        End If

        ' If the value is "true", convert to "Yes", otherwise "No"
        e.Value = IIf(CType(e.Value, Boolean), "Yes", "No")
    End Sub

    Protected Sub DecimalToCurrencyString(ByVal sender As Object, ByVal e As ConvertEventArgs)
        ' The method converts only to string type. Test this using the DesiredType.
        If Not e.DesiredType Is GetType(String) Then
            Exit Sub
        End If

        ' Use the ToString method to format the value as currency ("c").
        e.Value = CType(e.Value, Decimal).ToString("c")
    End Sub

    ' Move Back 10 records
    Public Sub Back10()
        ' The position of the binding context controls the "current record"
        Me.BindingContext(productInfo.Products).Position -= 10
    End Sub

    ' Move to the first record
    Public Sub FirstRecord()
        ' The position of the binding context controls the "current record"
        ' Position the first record is record 0 (not 1).
        Me.BindingContext(productInfo.Products).Position = 0
    End Sub

    ' Move forward 10 records
    Public Sub Forward10()
        ' The position of the binding context controls the "current record"
        Me.BindingContext(productInfo.Products).Position += 10
    End Sub

    ' Move to the last record
    Public Sub LastRecord()
        ' The position of the binding context controls the "current record". 
        ' Use productInfo.Products.Count to figure out the total number of 
        ' records.  -1 because position is zero based.
        Me.BindingContext(productInfo.Products).Position = _
            productInfo.Products.Count - 1
    End Sub

    ' Move to the next record
    Public Sub NextRecord()
        ' The position of the binding context controls the "current record"
        Me.BindingContext(productInfo.Products).Position += 1
    End Sub

    ' Move to the previous record
    Public Sub PreviousRecord()
        ' The position of the binding context controls the "current record"
        Me.BindingContext(productInfo.Products).Position -= 1
    End Sub

    ' Output the number of the current record
    Protected Sub ShowCurrentRecord()
        ' The position  of the binding context contains the current record.
        ' +1 so that the first record displays as record 1 (instead of 0).
        ' productInfo.Products.Count gives the total number of records.
        lblRecordNumber.Text = "Record " & _
            Me.BindingContext(productInfo.Products).Position + 1 & " of " & _
            productInfo.Products.Count
    End Sub

    Private Sub btnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirst.Click
        ' Move to the first record
        FirstRecord()
    End Sub

    Private Sub btnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLast.Click
        ' Move to the last record
        LastRecord()
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        ' Move to the next record
        NextRecord()
    End Sub

    Private Sub btnPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevious.Click
        ' Move to the previous record
        PreviousRecord()
    End Sub

    Private Sub frmMain_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        ' Let the user scroll through the records using the cursor keys.
        ' Left and right are next and previous.
        ' Home and end are first and last.
        If e.KeyCode = Keys.Right Then NextRecord()
        If e.KeyCode = Keys.Left Then PreviousRecord()
        If e.KeyCode = Keys.Home Then FirstRecord()
        If e.KeyCode = Keys.End Then LastRecord()
        If e.KeyCode = Keys.PageDown Then Forward10()
        If e.KeyCode = Keys.PageUp Then Back10()
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Static ConnectionString As String = SQL_CONNECTION_STRING
        Static DidPreviouslyConnect As Boolean = False

        ' Display a status message saying that we're attempting to connect.
        ' This only needs to be done the very first time a connection is
        ' attempted.  After we've determined that MSDE or SQL Server is
        ' installed, this message no longer needs to be displayed.
        Dim frmStatusMessage As New frmStatus()
        If Not DidPreviouslyConnect Then
            frmStatusMessage.Show("Connecting to SQL Server")
        End If

        ' Attempt to connect to the local SQL server instance, and a local
        ' MSDE installation (with Northwind).  
        Dim IsConnecting As Boolean = True
        While IsConnecting

            Try
                ' The SqlConnection class allows you to communicate with SQL Server.
                ' The constructor accepts a connection string as an argument.  This
                ' connection string uses Integrated Security, which means that you 
                ' must have a login in SQL Server, or be part of the Administrators
                ' group for this to work.
                Dim northwindConnection As New SqlConnection(ConnectionString)


                ' This select statement retrieves all the products, and looks up the
                ' associated CategoryName, and SupplierName for each product.
                Dim selectCommand As String = _
                    "SELECT Products.ProductID, Products.ProductName, " & _
                        "Products.SupplierID, Products.CategoryID, " & _
                        "Products.QuantityPerUnit, Products.UnitPrice, " & _
                        "Products.UnitsInStock, Products.UnitsOnOrder, " & _
                        "Products.ReorderLevel, Products.Discontinued, " & _
                        "Suppliers.CompanyName AS SupplierName, " & _
                        "Categories.CategoryName " & _
                    "FROM Products INNER JOIN " & _
                        "Suppliers ON Products.SupplierID = Suppliers.SupplierID INNER JOIN " & _
                        "Categories ON Products.CategoryID = Categories.CategoryID"

                ' The SqlDataAdapter will actually issue the command to the database.
                Dim productAdapter As New SqlDataAdapter(selectCommand, northwindConnection)

                ' At this point, the 
                productAdapter.Fill(productInfo.Products)

                txtProductID.DataBindings.Add("Text", productInfo.Products, "ProductID")
                txtProductName.DataBindings.Add("Text", productInfo.Products, "ProductName")
                txtSupplier.DataBindings.Add("Text", productInfo.Products, "SupplierName")
                txtCategory.DataBindings.Add("Text", productInfo.Products, "CategoryName")
                txtQuantityPerUnit.DataBindings.Add("Text", productInfo.Products, "QuantityPerUnit")
                txtUnitsInStock.DataBindings.Add("Text", productInfo.Products, "UnitsInStock")
                txtUnitsOnOrder.DataBindings.Add("Text", productInfo.Products, "UnitsOnOrder")
                txtReorderLevel.DataBindings.Add("Text", productInfo.Products, "ReorderLevel")

                Dim UnitPriceBinding As New Binding("Text", productInfo.Products, "UnitPrice")
                AddHandler UnitPriceBinding.Format, AddressOf DecimalToCurrencyString
                txtUnitPrice.DataBindings.Add(UnitPriceBinding)

                Dim DiscontinuedBinding As New Binding("Text", productInfo.Products, "Discontinued")
                AddHandler DiscontinuedBinding.Format, AddressOf BooleanToYesNo
                txtDiscontinued.DataBindings.Add(DiscontinuedBinding)

                AddHandler Me.BindingContext(productInfo.Products).PositionChanged, _
                    AddressOf ProductInfo_PositionChanged

                ' Data has been successfully retrieved, so break out of the loop.
                IsConnecting = False
                DidPreviouslyConnect = True

            Catch exc As Exception
                If ConnectionString = SQL_CONNECTION_STRING Then
                    ' Couldn't connect to SQL Server.  Now try MSDE.
                    ConnectionString = MSDE_CONNECTION_STRING
                    frmStatusMessage.Show("Connecting to MSDE")
                Else
                    ' Unable to connect to SQL Server or MSDE
                    frmStatusMessage.Close()
                    MessageBox.Show("To run this sample, you must have SQL " & _
                        "or MSDE with the Northwind database installed.  For " & _
                        "instructions on installing MSDE, view the ReadMe file.")
                    End
                End If
            End Try
        End While

        frmStatusMessage.Close()

        ShowCurrentRecord()

    End Sub

    Protected Sub ProductInfo_PositionChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ShowCurrentRecord()
    End Sub

End Class