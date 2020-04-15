'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Imports System.Data.SqlClient
Imports System.IO

Public Class frmMain
	Inherits System.Windows.Forms.Form

    ' dsCustomers will hold all customers in the USA
    Protected dsCustomers As New CustomersDataSet()
    Protected dsCustomerChanges As New CustomersDataSet()
    Protected daCustomers As SqlDataAdapter

    ' Used to reference the table containing employee information in 
    ' Employee Data.
    Protected Const CUSTOMER_TABLE_NAME As String = "Customers"

    Protected Const SQL_CONNECTION_STRING As String = _
        "Server=localhost;" & _
        "DataBase=Northwind;" & _
        "Integrated Security=SSPI"

    Protected Const MSDE_CONNECTION_STRING As String = _
        "Server=(local)\NetSDK;" & _
        "DataBase=Northwind;" & _
        "Integrated Security=SSPI"

    Dim DidPreviouslyConnect As Boolean = False
    Dim IsAdding As Boolean = False

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
    Friend WithEvents tbCustomerID As System.Windows.Forms.TextBox
    Friend WithEvents tbCompanyName As System.Windows.Forms.TextBox
    Friend WithEvents tbContactName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbContactTitle As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbCity As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tbRegion As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tbPostalCode As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tbPhone As System.Windows.Forms.TextBox
    Friend WithEvents tbFax As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents bnLast As System.Windows.Forms.Button
    Friend WithEvents bnNext As System.Windows.Forms.Button
    Friend WithEvents bnPrev As System.Windows.Forms.Button
    Friend WithEvents bnFirst As System.Windows.Forms.Button
    Friend WithEvents lblPosition As System.Windows.Forms.Label
    Friend WithEvents bnCancel As System.Windows.Forms.Button
    Friend WithEvents bnDelete As System.Windows.Forms.Button
    Friend WithEvents bnAdd As System.Windows.Forms.Button
    Friend WithEvents bnCancelAll As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tbCountry As System.Windows.Forms.TextBox
    Friend WithEvents bnReset As System.Windows.Forms.Button
    Friend WithEvents chkWorkOffline As System.Windows.Forms.CheckBox
    Friend WithEvents bnSaveCustomers As System.Windows.Forms.Button
    Friend WithEvents bnGetCustomers As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbCustomerID = New System.Windows.Forms.TextBox()
        Me.tbCompanyName = New System.Windows.Forms.TextBox()
        Me.tbContactName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbContactTitle = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbAddress = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbCity = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tbRegion = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tbPostalCode = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tbPhone = New System.Windows.Forms.TextBox()
        Me.tbFax = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.bnLast = New System.Windows.Forms.Button()
        Me.bnNext = New System.Windows.Forms.Button()
        Me.bnPrev = New System.Windows.Forms.Button()
        Me.bnFirst = New System.Windows.Forms.Button()
        Me.lblPosition = New System.Windows.Forms.Label()
        Me.bnAdd = New System.Windows.Forms.Button()
        Me.bnSaveCustomers = New System.Windows.Forms.Button()
        Me.bnDelete = New System.Windows.Forms.Button()
        Me.bnCancel = New System.Windows.Forms.Button()
        Me.bnCancelAll = New System.Windows.Forms.Button()
        Me.tbCountry = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.bnGetCustomers = New System.Windows.Forms.Button()
        Me.bnReset = New System.Windows.Forms.Button()
        Me.chkWorkOffline = New System.Windows.Forms.CheckBox()
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
        'tbCustomerID
        '
        Me.tbCustomerID.AccessibleDescription = resources.GetString("tbCustomerID.AccessibleDescription")
        Me.tbCustomerID.AccessibleName = resources.GetString("tbCustomerID.AccessibleName")
        Me.tbCustomerID.Anchor = CType(resources.GetObject("tbCustomerID.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.tbCustomerID.AutoSize = CType(resources.GetObject("tbCustomerID.AutoSize"), Boolean)
        Me.tbCustomerID.BackgroundImage = CType(resources.GetObject("tbCustomerID.BackgroundImage"), System.Drawing.Image)
        Me.tbCustomerID.Dock = CType(resources.GetObject("tbCustomerID.Dock"), System.Windows.Forms.DockStyle)
        Me.tbCustomerID.Enabled = CType(resources.GetObject("tbCustomerID.Enabled"), Boolean)
        Me.tbCustomerID.Font = CType(resources.GetObject("tbCustomerID.Font"), System.Drawing.Font)
        Me.tbCustomerID.ImeMode = CType(resources.GetObject("tbCustomerID.ImeMode"), System.Windows.Forms.ImeMode)
        Me.tbCustomerID.Location = CType(resources.GetObject("tbCustomerID.Location"), System.Drawing.Point)
        Me.tbCustomerID.MaxLength = CType(resources.GetObject("tbCustomerID.MaxLength"), Integer)
        Me.tbCustomerID.Multiline = CType(resources.GetObject("tbCustomerID.Multiline"), Boolean)
        Me.tbCustomerID.Name = "tbCustomerID"
        Me.tbCustomerID.PasswordChar = CType(resources.GetObject("tbCustomerID.PasswordChar"), Char)
        Me.tbCustomerID.RightToLeft = CType(resources.GetObject("tbCustomerID.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.tbCustomerID.ScrollBars = CType(resources.GetObject("tbCustomerID.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.tbCustomerID.Size = CType(resources.GetObject("tbCustomerID.Size"), System.Drawing.Size)
        Me.tbCustomerID.TabIndex = CType(resources.GetObject("tbCustomerID.TabIndex"), Integer)
        Me.tbCustomerID.Text = resources.GetString("tbCustomerID.Text")
        Me.tbCustomerID.TextAlign = CType(resources.GetObject("tbCustomerID.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.tbCustomerID.Visible = CType(resources.GetObject("tbCustomerID.Visible"), Boolean)
        Me.tbCustomerID.WordWrap = CType(resources.GetObject("tbCustomerID.WordWrap"), Boolean)
        '
        'tbCompanyName
        '
        Me.tbCompanyName.AccessibleDescription = resources.GetString("tbCompanyName.AccessibleDescription")
        Me.tbCompanyName.AccessibleName = resources.GetString("tbCompanyName.AccessibleName")
        Me.tbCompanyName.Anchor = CType(resources.GetObject("tbCompanyName.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.tbCompanyName.AutoSize = CType(resources.GetObject("tbCompanyName.AutoSize"), Boolean)
        Me.tbCompanyName.BackgroundImage = CType(resources.GetObject("tbCompanyName.BackgroundImage"), System.Drawing.Image)
        Me.tbCompanyName.Dock = CType(resources.GetObject("tbCompanyName.Dock"), System.Windows.Forms.DockStyle)
        Me.tbCompanyName.Enabled = CType(resources.GetObject("tbCompanyName.Enabled"), Boolean)
        Me.tbCompanyName.Font = CType(resources.GetObject("tbCompanyName.Font"), System.Drawing.Font)
        Me.tbCompanyName.ImeMode = CType(resources.GetObject("tbCompanyName.ImeMode"), System.Windows.Forms.ImeMode)
        Me.tbCompanyName.Location = CType(resources.GetObject("tbCompanyName.Location"), System.Drawing.Point)
        Me.tbCompanyName.MaxLength = CType(resources.GetObject("tbCompanyName.MaxLength"), Integer)
        Me.tbCompanyName.Multiline = CType(resources.GetObject("tbCompanyName.Multiline"), Boolean)
        Me.tbCompanyName.Name = "tbCompanyName"
        Me.tbCompanyName.PasswordChar = CType(resources.GetObject("tbCompanyName.PasswordChar"), Char)
        Me.tbCompanyName.RightToLeft = CType(resources.GetObject("tbCompanyName.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.tbCompanyName.ScrollBars = CType(resources.GetObject("tbCompanyName.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.tbCompanyName.Size = CType(resources.GetObject("tbCompanyName.Size"), System.Drawing.Size)
        Me.tbCompanyName.TabIndex = CType(resources.GetObject("tbCompanyName.TabIndex"), Integer)
        Me.tbCompanyName.Text = resources.GetString("tbCompanyName.Text")
        Me.tbCompanyName.TextAlign = CType(resources.GetObject("tbCompanyName.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.tbCompanyName.Visible = CType(resources.GetObject("tbCompanyName.Visible"), Boolean)
        Me.tbCompanyName.WordWrap = CType(resources.GetObject("tbCompanyName.WordWrap"), Boolean)
        '
        'tbContactName
        '
        Me.tbContactName.AccessibleDescription = resources.GetString("tbContactName.AccessibleDescription")
        Me.tbContactName.AccessibleName = resources.GetString("tbContactName.AccessibleName")
        Me.tbContactName.Anchor = CType(resources.GetObject("tbContactName.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.tbContactName.AutoSize = CType(resources.GetObject("tbContactName.AutoSize"), Boolean)
        Me.tbContactName.BackgroundImage = CType(resources.GetObject("tbContactName.BackgroundImage"), System.Drawing.Image)
        Me.tbContactName.Dock = CType(resources.GetObject("tbContactName.Dock"), System.Windows.Forms.DockStyle)
        Me.tbContactName.Enabled = CType(resources.GetObject("tbContactName.Enabled"), Boolean)
        Me.tbContactName.Font = CType(resources.GetObject("tbContactName.Font"), System.Drawing.Font)
        Me.tbContactName.ImeMode = CType(resources.GetObject("tbContactName.ImeMode"), System.Windows.Forms.ImeMode)
        Me.tbContactName.Location = CType(resources.GetObject("tbContactName.Location"), System.Drawing.Point)
        Me.tbContactName.MaxLength = CType(resources.GetObject("tbContactName.MaxLength"), Integer)
        Me.tbContactName.Multiline = CType(resources.GetObject("tbContactName.Multiline"), Boolean)
        Me.tbContactName.Name = "tbContactName"
        Me.tbContactName.PasswordChar = CType(resources.GetObject("tbContactName.PasswordChar"), Char)
        Me.tbContactName.RightToLeft = CType(resources.GetObject("tbContactName.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.tbContactName.ScrollBars = CType(resources.GetObject("tbContactName.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.tbContactName.Size = CType(resources.GetObject("tbContactName.Size"), System.Drawing.Size)
        Me.tbContactName.TabIndex = CType(resources.GetObject("tbContactName.TabIndex"), Integer)
        Me.tbContactName.Text = resources.GetString("tbContactName.Text")
        Me.tbContactName.TextAlign = CType(resources.GetObject("tbContactName.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.tbContactName.Visible = CType(resources.GetObject("tbContactName.Visible"), Boolean)
        Me.tbContactName.WordWrap = CType(resources.GetObject("tbContactName.WordWrap"), Boolean)
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
        'tbContactTitle
        '
        Me.tbContactTitle.AccessibleDescription = resources.GetString("tbContactTitle.AccessibleDescription")
        Me.tbContactTitle.AccessibleName = resources.GetString("tbContactTitle.AccessibleName")
        Me.tbContactTitle.Anchor = CType(resources.GetObject("tbContactTitle.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.tbContactTitle.AutoSize = CType(resources.GetObject("tbContactTitle.AutoSize"), Boolean)
        Me.tbContactTitle.BackgroundImage = CType(resources.GetObject("tbContactTitle.BackgroundImage"), System.Drawing.Image)
        Me.tbContactTitle.Dock = CType(resources.GetObject("tbContactTitle.Dock"), System.Windows.Forms.DockStyle)
        Me.tbContactTitle.Enabled = CType(resources.GetObject("tbContactTitle.Enabled"), Boolean)
        Me.tbContactTitle.Font = CType(resources.GetObject("tbContactTitle.Font"), System.Drawing.Font)
        Me.tbContactTitle.ImeMode = CType(resources.GetObject("tbContactTitle.ImeMode"), System.Windows.Forms.ImeMode)
        Me.tbContactTitle.Location = CType(resources.GetObject("tbContactTitle.Location"), System.Drawing.Point)
        Me.tbContactTitle.MaxLength = CType(resources.GetObject("tbContactTitle.MaxLength"), Integer)
        Me.tbContactTitle.Multiline = CType(resources.GetObject("tbContactTitle.Multiline"), Boolean)
        Me.tbContactTitle.Name = "tbContactTitle"
        Me.tbContactTitle.PasswordChar = CType(resources.GetObject("tbContactTitle.PasswordChar"), Char)
        Me.tbContactTitle.RightToLeft = CType(resources.GetObject("tbContactTitle.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.tbContactTitle.ScrollBars = CType(resources.GetObject("tbContactTitle.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.tbContactTitle.Size = CType(resources.GetObject("tbContactTitle.Size"), System.Drawing.Size)
        Me.tbContactTitle.TabIndex = CType(resources.GetObject("tbContactTitle.TabIndex"), Integer)
        Me.tbContactTitle.Text = resources.GetString("tbContactTitle.Text")
        Me.tbContactTitle.TextAlign = CType(resources.GetObject("tbContactTitle.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.tbContactTitle.Visible = CType(resources.GetObject("tbContactTitle.Visible"), Boolean)
        Me.tbContactTitle.WordWrap = CType(resources.GetObject("tbContactTitle.WordWrap"), Boolean)
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
        'tbAddress
        '
        Me.tbAddress.AccessibleDescription = resources.GetString("tbAddress.AccessibleDescription")
        Me.tbAddress.AccessibleName = resources.GetString("tbAddress.AccessibleName")
        Me.tbAddress.Anchor = CType(resources.GetObject("tbAddress.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.tbAddress.AutoSize = CType(resources.GetObject("tbAddress.AutoSize"), Boolean)
        Me.tbAddress.BackgroundImage = CType(resources.GetObject("tbAddress.BackgroundImage"), System.Drawing.Image)
        Me.tbAddress.Dock = CType(resources.GetObject("tbAddress.Dock"), System.Windows.Forms.DockStyle)
        Me.tbAddress.Enabled = CType(resources.GetObject("tbAddress.Enabled"), Boolean)
        Me.tbAddress.Font = CType(resources.GetObject("tbAddress.Font"), System.Drawing.Font)
        Me.tbAddress.ImeMode = CType(resources.GetObject("tbAddress.ImeMode"), System.Windows.Forms.ImeMode)
        Me.tbAddress.Location = CType(resources.GetObject("tbAddress.Location"), System.Drawing.Point)
        Me.tbAddress.MaxLength = CType(resources.GetObject("tbAddress.MaxLength"), Integer)
        Me.tbAddress.Multiline = CType(resources.GetObject("tbAddress.Multiline"), Boolean)
        Me.tbAddress.Name = "tbAddress"
        Me.tbAddress.PasswordChar = CType(resources.GetObject("tbAddress.PasswordChar"), Char)
        Me.tbAddress.RightToLeft = CType(resources.GetObject("tbAddress.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.tbAddress.ScrollBars = CType(resources.GetObject("tbAddress.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.tbAddress.Size = CType(resources.GetObject("tbAddress.Size"), System.Drawing.Size)
        Me.tbAddress.TabIndex = CType(resources.GetObject("tbAddress.TabIndex"), Integer)
        Me.tbAddress.Text = resources.GetString("tbAddress.Text")
        Me.tbAddress.TextAlign = CType(resources.GetObject("tbAddress.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.tbAddress.Visible = CType(resources.GetObject("tbAddress.Visible"), Boolean)
        Me.tbAddress.WordWrap = CType(resources.GetObject("tbAddress.WordWrap"), Boolean)
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
        'tbCity
        '
        Me.tbCity.AccessibleDescription = resources.GetString("tbCity.AccessibleDescription")
        Me.tbCity.AccessibleName = resources.GetString("tbCity.AccessibleName")
        Me.tbCity.Anchor = CType(resources.GetObject("tbCity.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.tbCity.AutoSize = CType(resources.GetObject("tbCity.AutoSize"), Boolean)
        Me.tbCity.BackgroundImage = CType(resources.GetObject("tbCity.BackgroundImage"), System.Drawing.Image)
        Me.tbCity.Dock = CType(resources.GetObject("tbCity.Dock"), System.Windows.Forms.DockStyle)
        Me.tbCity.Enabled = CType(resources.GetObject("tbCity.Enabled"), Boolean)
        Me.tbCity.Font = CType(resources.GetObject("tbCity.Font"), System.Drawing.Font)
        Me.tbCity.ImeMode = CType(resources.GetObject("tbCity.ImeMode"), System.Windows.Forms.ImeMode)
        Me.tbCity.Location = CType(resources.GetObject("tbCity.Location"), System.Drawing.Point)
        Me.tbCity.MaxLength = CType(resources.GetObject("tbCity.MaxLength"), Integer)
        Me.tbCity.Multiline = CType(resources.GetObject("tbCity.Multiline"), Boolean)
        Me.tbCity.Name = "tbCity"
        Me.tbCity.PasswordChar = CType(resources.GetObject("tbCity.PasswordChar"), Char)
        Me.tbCity.RightToLeft = CType(resources.GetObject("tbCity.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.tbCity.ScrollBars = CType(resources.GetObject("tbCity.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.tbCity.Size = CType(resources.GetObject("tbCity.Size"), System.Drawing.Size)
        Me.tbCity.TabIndex = CType(resources.GetObject("tbCity.TabIndex"), Integer)
        Me.tbCity.Text = resources.GetString("tbCity.Text")
        Me.tbCity.TextAlign = CType(resources.GetObject("tbCity.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.tbCity.Visible = CType(resources.GetObject("tbCity.Visible"), Boolean)
        Me.tbCity.WordWrap = CType(resources.GetObject("tbCity.WordWrap"), Boolean)
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
        'tbRegion
        '
        Me.tbRegion.AccessibleDescription = resources.GetString("tbRegion.AccessibleDescription")
        Me.tbRegion.AccessibleName = resources.GetString("tbRegion.AccessibleName")
        Me.tbRegion.Anchor = CType(resources.GetObject("tbRegion.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.tbRegion.AutoSize = CType(resources.GetObject("tbRegion.AutoSize"), Boolean)
        Me.tbRegion.BackgroundImage = CType(resources.GetObject("tbRegion.BackgroundImage"), System.Drawing.Image)
        Me.tbRegion.Dock = CType(resources.GetObject("tbRegion.Dock"), System.Windows.Forms.DockStyle)
        Me.tbRegion.Enabled = CType(resources.GetObject("tbRegion.Enabled"), Boolean)
        Me.tbRegion.Font = CType(resources.GetObject("tbRegion.Font"), System.Drawing.Font)
        Me.tbRegion.ImeMode = CType(resources.GetObject("tbRegion.ImeMode"), System.Windows.Forms.ImeMode)
        Me.tbRegion.Location = CType(resources.GetObject("tbRegion.Location"), System.Drawing.Point)
        Me.tbRegion.MaxLength = CType(resources.GetObject("tbRegion.MaxLength"), Integer)
        Me.tbRegion.Multiline = CType(resources.GetObject("tbRegion.Multiline"), Boolean)
        Me.tbRegion.Name = "tbRegion"
        Me.tbRegion.PasswordChar = CType(resources.GetObject("tbRegion.PasswordChar"), Char)
        Me.tbRegion.RightToLeft = CType(resources.GetObject("tbRegion.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.tbRegion.ScrollBars = CType(resources.GetObject("tbRegion.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.tbRegion.Size = CType(resources.GetObject("tbRegion.Size"), System.Drawing.Size)
        Me.tbRegion.TabIndex = CType(resources.GetObject("tbRegion.TabIndex"), Integer)
        Me.tbRegion.Text = resources.GetString("tbRegion.Text")
        Me.tbRegion.TextAlign = CType(resources.GetObject("tbRegion.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.tbRegion.Visible = CType(resources.GetObject("tbRegion.Visible"), Boolean)
        Me.tbRegion.WordWrap = CType(resources.GetObject("tbRegion.WordWrap"), Boolean)
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
        'tbPostalCode
        '
        Me.tbPostalCode.AccessibleDescription = resources.GetString("tbPostalCode.AccessibleDescription")
        Me.tbPostalCode.AccessibleName = resources.GetString("tbPostalCode.AccessibleName")
        Me.tbPostalCode.Anchor = CType(resources.GetObject("tbPostalCode.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.tbPostalCode.AutoSize = CType(resources.GetObject("tbPostalCode.AutoSize"), Boolean)
        Me.tbPostalCode.BackgroundImage = CType(resources.GetObject("tbPostalCode.BackgroundImage"), System.Drawing.Image)
        Me.tbPostalCode.Dock = CType(resources.GetObject("tbPostalCode.Dock"), System.Windows.Forms.DockStyle)
        Me.tbPostalCode.Enabled = CType(resources.GetObject("tbPostalCode.Enabled"), Boolean)
        Me.tbPostalCode.Font = CType(resources.GetObject("tbPostalCode.Font"), System.Drawing.Font)
        Me.tbPostalCode.ImeMode = CType(resources.GetObject("tbPostalCode.ImeMode"), System.Windows.Forms.ImeMode)
        Me.tbPostalCode.Location = CType(resources.GetObject("tbPostalCode.Location"), System.Drawing.Point)
        Me.tbPostalCode.MaxLength = CType(resources.GetObject("tbPostalCode.MaxLength"), Integer)
        Me.tbPostalCode.Multiline = CType(resources.GetObject("tbPostalCode.Multiline"), Boolean)
        Me.tbPostalCode.Name = "tbPostalCode"
        Me.tbPostalCode.PasswordChar = CType(resources.GetObject("tbPostalCode.PasswordChar"), Char)
        Me.tbPostalCode.RightToLeft = CType(resources.GetObject("tbPostalCode.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.tbPostalCode.ScrollBars = CType(resources.GetObject("tbPostalCode.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.tbPostalCode.Size = CType(resources.GetObject("tbPostalCode.Size"), System.Drawing.Size)
        Me.tbPostalCode.TabIndex = CType(resources.GetObject("tbPostalCode.TabIndex"), Integer)
        Me.tbPostalCode.Text = resources.GetString("tbPostalCode.Text")
        Me.tbPostalCode.TextAlign = CType(resources.GetObject("tbPostalCode.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.tbPostalCode.Visible = CType(resources.GetObject("tbPostalCode.Visible"), Boolean)
        Me.tbPostalCode.WordWrap = CType(resources.GetObject("tbPostalCode.WordWrap"), Boolean)
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
        'tbPhone
        '
        Me.tbPhone.AccessibleDescription = resources.GetString("tbPhone.AccessibleDescription")
        Me.tbPhone.AccessibleName = resources.GetString("tbPhone.AccessibleName")
        Me.tbPhone.Anchor = CType(resources.GetObject("tbPhone.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.tbPhone.AutoSize = CType(resources.GetObject("tbPhone.AutoSize"), Boolean)
        Me.tbPhone.BackgroundImage = CType(resources.GetObject("tbPhone.BackgroundImage"), System.Drawing.Image)
        Me.tbPhone.Dock = CType(resources.GetObject("tbPhone.Dock"), System.Windows.Forms.DockStyle)
        Me.tbPhone.Enabled = CType(resources.GetObject("tbPhone.Enabled"), Boolean)
        Me.tbPhone.Font = CType(resources.GetObject("tbPhone.Font"), System.Drawing.Font)
        Me.tbPhone.ImeMode = CType(resources.GetObject("tbPhone.ImeMode"), System.Windows.Forms.ImeMode)
        Me.tbPhone.Location = CType(resources.GetObject("tbPhone.Location"), System.Drawing.Point)
        Me.tbPhone.MaxLength = CType(resources.GetObject("tbPhone.MaxLength"), Integer)
        Me.tbPhone.Multiline = CType(resources.GetObject("tbPhone.Multiline"), Boolean)
        Me.tbPhone.Name = "tbPhone"
        Me.tbPhone.PasswordChar = CType(resources.GetObject("tbPhone.PasswordChar"), Char)
        Me.tbPhone.RightToLeft = CType(resources.GetObject("tbPhone.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.tbPhone.ScrollBars = CType(resources.GetObject("tbPhone.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.tbPhone.Size = CType(resources.GetObject("tbPhone.Size"), System.Drawing.Size)
        Me.tbPhone.TabIndex = CType(resources.GetObject("tbPhone.TabIndex"), Integer)
        Me.tbPhone.Text = resources.GetString("tbPhone.Text")
        Me.tbPhone.TextAlign = CType(resources.GetObject("tbPhone.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.tbPhone.Visible = CType(resources.GetObject("tbPhone.Visible"), Boolean)
        Me.tbPhone.WordWrap = CType(resources.GetObject("tbPhone.WordWrap"), Boolean)
        '
        'tbFax
        '
        Me.tbFax.AccessibleDescription = resources.GetString("tbFax.AccessibleDescription")
        Me.tbFax.AccessibleName = resources.GetString("tbFax.AccessibleName")
        Me.tbFax.Anchor = CType(resources.GetObject("tbFax.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.tbFax.AutoSize = CType(resources.GetObject("tbFax.AutoSize"), Boolean)
        Me.tbFax.BackgroundImage = CType(resources.GetObject("tbFax.BackgroundImage"), System.Drawing.Image)
        Me.tbFax.Dock = CType(resources.GetObject("tbFax.Dock"), System.Windows.Forms.DockStyle)
        Me.tbFax.Enabled = CType(resources.GetObject("tbFax.Enabled"), Boolean)
        Me.tbFax.Font = CType(resources.GetObject("tbFax.Font"), System.Drawing.Font)
        Me.tbFax.ImeMode = CType(resources.GetObject("tbFax.ImeMode"), System.Windows.Forms.ImeMode)
        Me.tbFax.Location = CType(resources.GetObject("tbFax.Location"), System.Drawing.Point)
        Me.tbFax.MaxLength = CType(resources.GetObject("tbFax.MaxLength"), Integer)
        Me.tbFax.Multiline = CType(resources.GetObject("tbFax.Multiline"), Boolean)
        Me.tbFax.Name = "tbFax"
        Me.tbFax.PasswordChar = CType(resources.GetObject("tbFax.PasswordChar"), Char)
        Me.tbFax.RightToLeft = CType(resources.GetObject("tbFax.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.tbFax.ScrollBars = CType(resources.GetObject("tbFax.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.tbFax.Size = CType(resources.GetObject("tbFax.Size"), System.Drawing.Size)
        Me.tbFax.TabIndex = CType(resources.GetObject("tbFax.TabIndex"), Integer)
        Me.tbFax.Text = resources.GetString("tbFax.Text")
        Me.tbFax.TextAlign = CType(resources.GetObject("tbFax.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.tbFax.Visible = CType(resources.GetObject("tbFax.Visible"), Boolean)
        Me.tbFax.WordWrap = CType(resources.GetObject("tbFax.WordWrap"), Boolean)
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
        'bnLast
        '
        Me.bnLast.AccessibleDescription = CType(resources.GetObject("bnLast.AccessibleDescription"), String)
        Me.bnLast.AccessibleName = resources.GetString("bnLast.AccessibleName")
        Me.bnLast.Anchor = CType(resources.GetObject("bnLast.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.bnLast.BackgroundImage = CType(resources.GetObject("bnLast.BackgroundImage"), System.Drawing.Image)
        Me.bnLast.Dock = CType(resources.GetObject("bnLast.Dock"), System.Windows.Forms.DockStyle)
        Me.bnLast.Enabled = CType(resources.GetObject("bnLast.Enabled"), Boolean)
        Me.bnLast.FlatStyle = CType(resources.GetObject("bnLast.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.bnLast.Font = CType(resources.GetObject("bnLast.Font"), System.Drawing.Font)
        Me.bnLast.Image = CType(resources.GetObject("bnLast.Image"), System.Drawing.Image)
        Me.bnLast.ImageAlign = CType(resources.GetObject("bnLast.ImageAlign"), System.Drawing.ContentAlignment)
        Me.bnLast.ImageIndex = CType(resources.GetObject("bnLast.ImageIndex"), Integer)
        Me.bnLast.ImeMode = CType(resources.GetObject("bnLast.ImeMode"), System.Windows.Forms.ImeMode)
        Me.bnLast.Location = CType(resources.GetObject("bnLast.Location"), System.Drawing.Point)
        Me.bnLast.Name = "bnLast"
        Me.bnLast.RightToLeft = CType(resources.GetObject("bnLast.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.bnLast.Size = CType(resources.GetObject("bnLast.Size"), System.Drawing.Size)
        Me.bnLast.TabIndex = CType(resources.GetObject("bnLast.TabIndex"), Integer)
        Me.bnLast.Text = resources.GetString("bnLast.Text")
        Me.bnLast.TextAlign = CType(resources.GetObject("bnLast.TextAlign"), System.Drawing.ContentAlignment)
        Me.bnLast.Visible = CType(resources.GetObject("bnLast.Visible"), Boolean)
        '
        'bnNext
        '
        Me.bnNext.AccessibleDescription = CType(resources.GetObject("bnNext.AccessibleDescription"), String)
        Me.bnNext.AccessibleName = resources.GetString("bnNext.AccessibleName")
        Me.bnNext.Anchor = CType(resources.GetObject("bnNext.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.bnNext.BackgroundImage = CType(resources.GetObject("bnNext.BackgroundImage"), System.Drawing.Image)
        Me.bnNext.Dock = CType(resources.GetObject("bnNext.Dock"), System.Windows.Forms.DockStyle)
        Me.bnNext.Enabled = CType(resources.GetObject("bnNext.Enabled"), Boolean)
        Me.bnNext.FlatStyle = CType(resources.GetObject("bnNext.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.bnNext.Font = CType(resources.GetObject("bnNext.Font"), System.Drawing.Font)
        Me.bnNext.Image = CType(resources.GetObject("bnNext.Image"), System.Drawing.Image)
        Me.bnNext.ImageAlign = CType(resources.GetObject("bnNext.ImageAlign"), System.Drawing.ContentAlignment)
        Me.bnNext.ImageIndex = CType(resources.GetObject("bnNext.ImageIndex"), Integer)
        Me.bnNext.ImeMode = CType(resources.GetObject("bnNext.ImeMode"), System.Windows.Forms.ImeMode)
        Me.bnNext.Location = CType(resources.GetObject("bnNext.Location"), System.Drawing.Point)
        Me.bnNext.Name = "bnNext"
        Me.bnNext.RightToLeft = CType(resources.GetObject("bnNext.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.bnNext.Size = CType(resources.GetObject("bnNext.Size"), System.Drawing.Size)
        Me.bnNext.TabIndex = CType(resources.GetObject("bnNext.TabIndex"), Integer)
        Me.bnNext.Text = resources.GetString("bnNext.Text")
        Me.bnNext.TextAlign = CType(resources.GetObject("bnNext.TextAlign"), System.Drawing.ContentAlignment)
        Me.bnNext.Visible = CType(resources.GetObject("bnNext.Visible"), Boolean)
        '
        'bnPrev
        '
        Me.bnPrev.AccessibleDescription = CType(resources.GetObject("bnPrev.AccessibleDescription"), String)
        Me.bnPrev.AccessibleName = resources.GetString("bnPrev.AccessibleName")
        Me.bnPrev.Anchor = CType(resources.GetObject("bnPrev.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.bnPrev.BackgroundImage = CType(resources.GetObject("bnPrev.BackgroundImage"), System.Drawing.Image)
        Me.bnPrev.Dock = CType(resources.GetObject("bnPrev.Dock"), System.Windows.Forms.DockStyle)
        Me.bnPrev.Enabled = CType(resources.GetObject("bnPrev.Enabled"), Boolean)
        Me.bnPrev.FlatStyle = CType(resources.GetObject("bnPrev.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.bnPrev.Font = CType(resources.GetObject("bnPrev.Font"), System.Drawing.Font)
        Me.bnPrev.Image = CType(resources.GetObject("bnPrev.Image"), System.Drawing.Image)
        Me.bnPrev.ImageAlign = CType(resources.GetObject("bnPrev.ImageAlign"), System.Drawing.ContentAlignment)
        Me.bnPrev.ImageIndex = CType(resources.GetObject("bnPrev.ImageIndex"), Integer)
        Me.bnPrev.ImeMode = CType(resources.GetObject("bnPrev.ImeMode"), System.Windows.Forms.ImeMode)
        Me.bnPrev.Location = CType(resources.GetObject("bnPrev.Location"), System.Drawing.Point)
        Me.bnPrev.Name = "bnPrev"
        Me.bnPrev.RightToLeft = CType(resources.GetObject("bnPrev.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.bnPrev.Size = CType(resources.GetObject("bnPrev.Size"), System.Drawing.Size)
        Me.bnPrev.TabIndex = CType(resources.GetObject("bnPrev.TabIndex"), Integer)
        Me.bnPrev.Text = resources.GetString("bnPrev.Text")
        Me.bnPrev.TextAlign = CType(resources.GetObject("bnPrev.TextAlign"), System.Drawing.ContentAlignment)
        Me.bnPrev.Visible = CType(resources.GetObject("bnPrev.Visible"), Boolean)
        '
        'bnFirst
        '
        Me.bnFirst.AccessibleDescription = CType(resources.GetObject("bnFirst.AccessibleDescription"), String)
        Me.bnFirst.AccessibleName = resources.GetString("bnFirst.AccessibleName")
        Me.bnFirst.Anchor = CType(resources.GetObject("bnFirst.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.bnFirst.BackgroundImage = CType(resources.GetObject("bnFirst.BackgroundImage"), System.Drawing.Image)
        Me.bnFirst.Dock = CType(resources.GetObject("bnFirst.Dock"), System.Windows.Forms.DockStyle)
        Me.bnFirst.Enabled = CType(resources.GetObject("bnFirst.Enabled"), Boolean)
        Me.bnFirst.FlatStyle = CType(resources.GetObject("bnFirst.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.bnFirst.Font = CType(resources.GetObject("bnFirst.Font"), System.Drawing.Font)
        Me.bnFirst.Image = CType(resources.GetObject("bnFirst.Image"), System.Drawing.Image)
        Me.bnFirst.ImageAlign = CType(resources.GetObject("bnFirst.ImageAlign"), System.Drawing.ContentAlignment)
        Me.bnFirst.ImageIndex = CType(resources.GetObject("bnFirst.ImageIndex"), Integer)
        Me.bnFirst.ImeMode = CType(resources.GetObject("bnFirst.ImeMode"), System.Windows.Forms.ImeMode)
        Me.bnFirst.Location = CType(resources.GetObject("bnFirst.Location"), System.Drawing.Point)
        Me.bnFirst.Name = "bnFirst"
        Me.bnFirst.RightToLeft = CType(resources.GetObject("bnFirst.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.bnFirst.Size = CType(resources.GetObject("bnFirst.Size"), System.Drawing.Size)
        Me.bnFirst.TabIndex = CType(resources.GetObject("bnFirst.TabIndex"), Integer)
        Me.bnFirst.Text = resources.GetString("bnFirst.Text")
        Me.bnFirst.TextAlign = CType(resources.GetObject("bnFirst.TextAlign"), System.Drawing.ContentAlignment)
        Me.bnFirst.Visible = CType(resources.GetObject("bnFirst.Visible"), Boolean)
        '
        'lblPosition
        '
        Me.lblPosition.AccessibleDescription = resources.GetString("lblPosition.AccessibleDescription")
        Me.lblPosition.AccessibleName = resources.GetString("lblPosition.AccessibleName")
        Me.lblPosition.Anchor = CType(resources.GetObject("lblPosition.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblPosition.AutoSize = CType(resources.GetObject("lblPosition.AutoSize"), Boolean)
        Me.lblPosition.Dock = CType(resources.GetObject("lblPosition.Dock"), System.Windows.Forms.DockStyle)
        Me.lblPosition.Enabled = CType(resources.GetObject("lblPosition.Enabled"), Boolean)
        Me.lblPosition.Font = CType(resources.GetObject("lblPosition.Font"), System.Drawing.Font)
        Me.lblPosition.Image = CType(resources.GetObject("lblPosition.Image"), System.Drawing.Image)
        Me.lblPosition.ImageAlign = CType(resources.GetObject("lblPosition.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblPosition.ImageIndex = CType(resources.GetObject("lblPosition.ImageIndex"), Integer)
        Me.lblPosition.ImeMode = CType(resources.GetObject("lblPosition.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblPosition.Location = CType(resources.GetObject("lblPosition.Location"), System.Drawing.Point)
        Me.lblPosition.Name = "lblPosition"
        Me.lblPosition.RightToLeft = CType(resources.GetObject("lblPosition.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblPosition.Size = CType(resources.GetObject("lblPosition.Size"), System.Drawing.Size)
        Me.lblPosition.TabIndex = CType(resources.GetObject("lblPosition.TabIndex"), Integer)
        Me.lblPosition.Text = resources.GetString("lblPosition.Text")
        Me.lblPosition.TextAlign = CType(resources.GetObject("lblPosition.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblPosition.Visible = CType(resources.GetObject("lblPosition.Visible"), Boolean)
        '
        'bnAdd
        '
        Me.bnAdd.AccessibleDescription = resources.GetString("bnAdd.AccessibleDescription")
        Me.bnAdd.AccessibleName = resources.GetString("bnAdd.AccessibleName")
        Me.bnAdd.Anchor = CType(resources.GetObject("bnAdd.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.bnAdd.BackgroundImage = CType(resources.GetObject("bnAdd.BackgroundImage"), System.Drawing.Image)
        Me.bnAdd.Dock = CType(resources.GetObject("bnAdd.Dock"), System.Windows.Forms.DockStyle)
        Me.bnAdd.Enabled = CType(resources.GetObject("bnAdd.Enabled"), Boolean)
        Me.bnAdd.FlatStyle = CType(resources.GetObject("bnAdd.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.bnAdd.Font = CType(resources.GetObject("bnAdd.Font"), System.Drawing.Font)
        Me.bnAdd.Image = CType(resources.GetObject("bnAdd.Image"), System.Drawing.Image)
        Me.bnAdd.ImageAlign = CType(resources.GetObject("bnAdd.ImageAlign"), System.Drawing.ContentAlignment)
        Me.bnAdd.ImageIndex = CType(resources.GetObject("bnAdd.ImageIndex"), Integer)
        Me.bnAdd.ImeMode = CType(resources.GetObject("bnAdd.ImeMode"), System.Windows.Forms.ImeMode)
        Me.bnAdd.Location = CType(resources.GetObject("bnAdd.Location"), System.Drawing.Point)
        Me.bnAdd.Name = "bnAdd"
        Me.bnAdd.RightToLeft = CType(resources.GetObject("bnAdd.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.bnAdd.Size = CType(resources.GetObject("bnAdd.Size"), System.Drawing.Size)
        Me.bnAdd.TabIndex = CType(resources.GetObject("bnAdd.TabIndex"), Integer)
        Me.bnAdd.Text = resources.GetString("bnAdd.Text")
        Me.bnAdd.TextAlign = CType(resources.GetObject("bnAdd.TextAlign"), System.Drawing.ContentAlignment)
        Me.bnAdd.Visible = CType(resources.GetObject("bnAdd.Visible"), Boolean)
        '
        'bnSaveCustomers
        '
        Me.bnSaveCustomers.AccessibleDescription = resources.GetString("bnSaveCustomers.AccessibleDescription")
        Me.bnSaveCustomers.AccessibleName = resources.GetString("bnSaveCustomers.AccessibleName")
        Me.bnSaveCustomers.Anchor = CType(resources.GetObject("bnSaveCustomers.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.bnSaveCustomers.BackgroundImage = CType(resources.GetObject("bnSaveCustomers.BackgroundImage"), System.Drawing.Image)
        Me.bnSaveCustomers.Dock = CType(resources.GetObject("bnSaveCustomers.Dock"), System.Windows.Forms.DockStyle)
        Me.bnSaveCustomers.Enabled = CType(resources.GetObject("bnSaveCustomers.Enabled"), Boolean)
        Me.bnSaveCustomers.FlatStyle = CType(resources.GetObject("bnSaveCustomers.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.bnSaveCustomers.Font = CType(resources.GetObject("bnSaveCustomers.Font"), System.Drawing.Font)
        Me.bnSaveCustomers.Image = CType(resources.GetObject("bnSaveCustomers.Image"), System.Drawing.Image)
        Me.bnSaveCustomers.ImageAlign = CType(resources.GetObject("bnSaveCustomers.ImageAlign"), System.Drawing.ContentAlignment)
        Me.bnSaveCustomers.ImageIndex = CType(resources.GetObject("bnSaveCustomers.ImageIndex"), Integer)
        Me.bnSaveCustomers.ImeMode = CType(resources.GetObject("bnSaveCustomers.ImeMode"), System.Windows.Forms.ImeMode)
        Me.bnSaveCustomers.Location = CType(resources.GetObject("bnSaveCustomers.Location"), System.Drawing.Point)
        Me.bnSaveCustomers.Name = "bnSaveCustomers"
        Me.bnSaveCustomers.RightToLeft = CType(resources.GetObject("bnSaveCustomers.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.bnSaveCustomers.Size = CType(resources.GetObject("bnSaveCustomers.Size"), System.Drawing.Size)
        Me.bnSaveCustomers.TabIndex = CType(resources.GetObject("bnSaveCustomers.TabIndex"), Integer)
        Me.bnSaveCustomers.Text = resources.GetString("bnSaveCustomers.Text")
        Me.bnSaveCustomers.TextAlign = CType(resources.GetObject("bnSaveCustomers.TextAlign"), System.Drawing.ContentAlignment)
        Me.bnSaveCustomers.Visible = CType(resources.GetObject("bnSaveCustomers.Visible"), Boolean)
        '
        'bnDelete
        '
        Me.bnDelete.AccessibleDescription = resources.GetString("bnDelete.AccessibleDescription")
        Me.bnDelete.AccessibleName = resources.GetString("bnDelete.AccessibleName")
        Me.bnDelete.Anchor = CType(resources.GetObject("bnDelete.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.bnDelete.BackgroundImage = CType(resources.GetObject("bnDelete.BackgroundImage"), System.Drawing.Image)
        Me.bnDelete.Dock = CType(resources.GetObject("bnDelete.Dock"), System.Windows.Forms.DockStyle)
        Me.bnDelete.Enabled = CType(resources.GetObject("bnDelete.Enabled"), Boolean)
        Me.bnDelete.FlatStyle = CType(resources.GetObject("bnDelete.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.bnDelete.Font = CType(resources.GetObject("bnDelete.Font"), System.Drawing.Font)
        Me.bnDelete.Image = CType(resources.GetObject("bnDelete.Image"), System.Drawing.Image)
        Me.bnDelete.ImageAlign = CType(resources.GetObject("bnDelete.ImageAlign"), System.Drawing.ContentAlignment)
        Me.bnDelete.ImageIndex = CType(resources.GetObject("bnDelete.ImageIndex"), Integer)
        Me.bnDelete.ImeMode = CType(resources.GetObject("bnDelete.ImeMode"), System.Windows.Forms.ImeMode)
        Me.bnDelete.Location = CType(resources.GetObject("bnDelete.Location"), System.Drawing.Point)
        Me.bnDelete.Name = "bnDelete"
        Me.bnDelete.RightToLeft = CType(resources.GetObject("bnDelete.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.bnDelete.Size = CType(resources.GetObject("bnDelete.Size"), System.Drawing.Size)
        Me.bnDelete.TabIndex = CType(resources.GetObject("bnDelete.TabIndex"), Integer)
        Me.bnDelete.Text = resources.GetString("bnDelete.Text")
        Me.bnDelete.TextAlign = CType(resources.GetObject("bnDelete.TextAlign"), System.Drawing.ContentAlignment)
        Me.bnDelete.Visible = CType(resources.GetObject("bnDelete.Visible"), Boolean)
        '
        'bnCancel
        '
        Me.bnCancel.AccessibleDescription = resources.GetString("bnCancel.AccessibleDescription")
        Me.bnCancel.AccessibleName = resources.GetString("bnCancel.AccessibleName")
        Me.bnCancel.Anchor = CType(resources.GetObject("bnCancel.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.bnCancel.BackgroundImage = CType(resources.GetObject("bnCancel.BackgroundImage"), System.Drawing.Image)
        Me.bnCancel.Dock = CType(resources.GetObject("bnCancel.Dock"), System.Windows.Forms.DockStyle)
        Me.bnCancel.Enabled = CType(resources.GetObject("bnCancel.Enabled"), Boolean)
        Me.bnCancel.FlatStyle = CType(resources.GetObject("bnCancel.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.bnCancel.Font = CType(resources.GetObject("bnCancel.Font"), System.Drawing.Font)
        Me.bnCancel.Image = CType(resources.GetObject("bnCancel.Image"), System.Drawing.Image)
        Me.bnCancel.ImageAlign = CType(resources.GetObject("bnCancel.ImageAlign"), System.Drawing.ContentAlignment)
        Me.bnCancel.ImageIndex = CType(resources.GetObject("bnCancel.ImageIndex"), Integer)
        Me.bnCancel.ImeMode = CType(resources.GetObject("bnCancel.ImeMode"), System.Windows.Forms.ImeMode)
        Me.bnCancel.Location = CType(resources.GetObject("bnCancel.Location"), System.Drawing.Point)
        Me.bnCancel.Name = "bnCancel"
        Me.bnCancel.RightToLeft = CType(resources.GetObject("bnCancel.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.bnCancel.Size = CType(resources.GetObject("bnCancel.Size"), System.Drawing.Size)
        Me.bnCancel.TabIndex = CType(resources.GetObject("bnCancel.TabIndex"), Integer)
        Me.bnCancel.Text = resources.GetString("bnCancel.Text")
        Me.bnCancel.TextAlign = CType(resources.GetObject("bnCancel.TextAlign"), System.Drawing.ContentAlignment)
        Me.bnCancel.Visible = CType(resources.GetObject("bnCancel.Visible"), Boolean)
        '
        'bnCancelAll
        '
        Me.bnCancelAll.AccessibleDescription = resources.GetString("bnCancelAll.AccessibleDescription")
        Me.bnCancelAll.AccessibleName = resources.GetString("bnCancelAll.AccessibleName")
        Me.bnCancelAll.Anchor = CType(resources.GetObject("bnCancelAll.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.bnCancelAll.BackgroundImage = CType(resources.GetObject("bnCancelAll.BackgroundImage"), System.Drawing.Image)
        Me.bnCancelAll.Dock = CType(resources.GetObject("bnCancelAll.Dock"), System.Windows.Forms.DockStyle)
        Me.bnCancelAll.Enabled = CType(resources.GetObject("bnCancelAll.Enabled"), Boolean)
        Me.bnCancelAll.FlatStyle = CType(resources.GetObject("bnCancelAll.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.bnCancelAll.Font = CType(resources.GetObject("bnCancelAll.Font"), System.Drawing.Font)
        Me.bnCancelAll.Image = CType(resources.GetObject("bnCancelAll.Image"), System.Drawing.Image)
        Me.bnCancelAll.ImageAlign = CType(resources.GetObject("bnCancelAll.ImageAlign"), System.Drawing.ContentAlignment)
        Me.bnCancelAll.ImageIndex = CType(resources.GetObject("bnCancelAll.ImageIndex"), Integer)
        Me.bnCancelAll.ImeMode = CType(resources.GetObject("bnCancelAll.ImeMode"), System.Windows.Forms.ImeMode)
        Me.bnCancelAll.Location = CType(resources.GetObject("bnCancelAll.Location"), System.Drawing.Point)
        Me.bnCancelAll.Name = "bnCancelAll"
        Me.bnCancelAll.RightToLeft = CType(resources.GetObject("bnCancelAll.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.bnCancelAll.Size = CType(resources.GetObject("bnCancelAll.Size"), System.Drawing.Size)
        Me.bnCancelAll.TabIndex = CType(resources.GetObject("bnCancelAll.TabIndex"), Integer)
        Me.bnCancelAll.Text = resources.GetString("bnCancelAll.Text")
        Me.bnCancelAll.TextAlign = CType(resources.GetObject("bnCancelAll.TextAlign"), System.Drawing.ContentAlignment)
        Me.bnCancelAll.Visible = CType(resources.GetObject("bnCancelAll.Visible"), Boolean)
        '
        'tbCountry
        '
        Me.tbCountry.AccessibleDescription = resources.GetString("tbCountry.AccessibleDescription")
        Me.tbCountry.AccessibleName = resources.GetString("tbCountry.AccessibleName")
        Me.tbCountry.Anchor = CType(resources.GetObject("tbCountry.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.tbCountry.AutoSize = CType(resources.GetObject("tbCountry.AutoSize"), Boolean)
        Me.tbCountry.BackgroundImage = CType(resources.GetObject("tbCountry.BackgroundImage"), System.Drawing.Image)
        Me.tbCountry.Dock = CType(resources.GetObject("tbCountry.Dock"), System.Windows.Forms.DockStyle)
        Me.tbCountry.Enabled = CType(resources.GetObject("tbCountry.Enabled"), Boolean)
        Me.tbCountry.Font = CType(resources.GetObject("tbCountry.Font"), System.Drawing.Font)
        Me.tbCountry.ImeMode = CType(resources.GetObject("tbCountry.ImeMode"), System.Windows.Forms.ImeMode)
        Me.tbCountry.Location = CType(resources.GetObject("tbCountry.Location"), System.Drawing.Point)
        Me.tbCountry.MaxLength = CType(resources.GetObject("tbCountry.MaxLength"), Integer)
        Me.tbCountry.Multiline = CType(resources.GetObject("tbCountry.Multiline"), Boolean)
        Me.tbCountry.Name = "tbCountry"
        Me.tbCountry.PasswordChar = CType(resources.GetObject("tbCountry.PasswordChar"), Char)
        Me.tbCountry.RightToLeft = CType(resources.GetObject("tbCountry.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.tbCountry.ScrollBars = CType(resources.GetObject("tbCountry.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.tbCountry.Size = CType(resources.GetObject("tbCountry.Size"), System.Drawing.Size)
        Me.tbCountry.TabIndex = CType(resources.GetObject("tbCountry.TabIndex"), Integer)
        Me.tbCountry.Text = resources.GetString("tbCountry.Text")
        Me.tbCountry.TextAlign = CType(resources.GetObject("tbCountry.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.tbCountry.Visible = CType(resources.GetObject("tbCountry.Visible"), Boolean)
        Me.tbCountry.WordWrap = CType(resources.GetObject("tbCountry.WordWrap"), Boolean)
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
        'bnGetCustomers
        '
        Me.bnGetCustomers.AccessibleDescription = resources.GetString("bnGetCustomers.AccessibleDescription")
        Me.bnGetCustomers.AccessibleName = resources.GetString("bnGetCustomers.AccessibleName")
        Me.bnGetCustomers.Anchor = CType(resources.GetObject("bnGetCustomers.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.bnGetCustomers.BackgroundImage = CType(resources.GetObject("bnGetCustomers.BackgroundImage"), System.Drawing.Image)
        Me.bnGetCustomers.Dock = CType(resources.GetObject("bnGetCustomers.Dock"), System.Windows.Forms.DockStyle)
        Me.bnGetCustomers.Enabled = CType(resources.GetObject("bnGetCustomers.Enabled"), Boolean)
        Me.bnGetCustomers.FlatStyle = CType(resources.GetObject("bnGetCustomers.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.bnGetCustomers.Font = CType(resources.GetObject("bnGetCustomers.Font"), System.Drawing.Font)
        Me.bnGetCustomers.Image = CType(resources.GetObject("bnGetCustomers.Image"), System.Drawing.Image)
        Me.bnGetCustomers.ImageAlign = CType(resources.GetObject("bnGetCustomers.ImageAlign"), System.Drawing.ContentAlignment)
        Me.bnGetCustomers.ImageIndex = CType(resources.GetObject("bnGetCustomers.ImageIndex"), Integer)
        Me.bnGetCustomers.ImeMode = CType(resources.GetObject("bnGetCustomers.ImeMode"), System.Windows.Forms.ImeMode)
        Me.bnGetCustomers.Location = CType(resources.GetObject("bnGetCustomers.Location"), System.Drawing.Point)
        Me.bnGetCustomers.Name = "bnGetCustomers"
        Me.bnGetCustomers.RightToLeft = CType(resources.GetObject("bnGetCustomers.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.bnGetCustomers.Size = CType(resources.GetObject("bnGetCustomers.Size"), System.Drawing.Size)
        Me.bnGetCustomers.TabIndex = CType(resources.GetObject("bnGetCustomers.TabIndex"), Integer)
        Me.bnGetCustomers.Text = resources.GetString("bnGetCustomers.Text")
        Me.bnGetCustomers.TextAlign = CType(resources.GetObject("bnGetCustomers.TextAlign"), System.Drawing.ContentAlignment)
        Me.bnGetCustomers.Visible = CType(resources.GetObject("bnGetCustomers.Visible"), Boolean)
        '
        'bnReset
        '
        Me.bnReset.AccessibleDescription = resources.GetString("bnReset.AccessibleDescription")
        Me.bnReset.AccessibleName = resources.GetString("bnReset.AccessibleName")
        Me.bnReset.Anchor = CType(resources.GetObject("bnReset.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.bnReset.BackgroundImage = CType(resources.GetObject("bnReset.BackgroundImage"), System.Drawing.Image)
        Me.bnReset.Dock = CType(resources.GetObject("bnReset.Dock"), System.Windows.Forms.DockStyle)
        Me.bnReset.Enabled = CType(resources.GetObject("bnReset.Enabled"), Boolean)
        Me.bnReset.FlatStyle = CType(resources.GetObject("bnReset.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.bnReset.Font = CType(resources.GetObject("bnReset.Font"), System.Drawing.Font)
        Me.bnReset.Image = CType(resources.GetObject("bnReset.Image"), System.Drawing.Image)
        Me.bnReset.ImageAlign = CType(resources.GetObject("bnReset.ImageAlign"), System.Drawing.ContentAlignment)
        Me.bnReset.ImageIndex = CType(resources.GetObject("bnReset.ImageIndex"), Integer)
        Me.bnReset.ImeMode = CType(resources.GetObject("bnReset.ImeMode"), System.Windows.Forms.ImeMode)
        Me.bnReset.Location = CType(resources.GetObject("bnReset.Location"), System.Drawing.Point)
        Me.bnReset.Name = "bnReset"
        Me.bnReset.RightToLeft = CType(resources.GetObject("bnReset.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.bnReset.Size = CType(resources.GetObject("bnReset.Size"), System.Drawing.Size)
        Me.bnReset.TabIndex = CType(resources.GetObject("bnReset.TabIndex"), Integer)
        Me.bnReset.Text = resources.GetString("bnReset.Text")
        Me.bnReset.TextAlign = CType(resources.GetObject("bnReset.TextAlign"), System.Drawing.ContentAlignment)
        Me.bnReset.Visible = CType(resources.GetObject("bnReset.Visible"), Boolean)
        '
        'chkWorkOffline
        '
        Me.chkWorkOffline.AccessibleDescription = CType(resources.GetObject("chkWorkOffline.AccessibleDescription"), String)
        Me.chkWorkOffline.AccessibleName = CType(resources.GetObject("chkWorkOffline.AccessibleName"), String)
        Me.chkWorkOffline.Anchor = CType(resources.GetObject("chkWorkOffline.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.chkWorkOffline.Appearance = CType(resources.GetObject("chkWorkOffline.Appearance"), System.Windows.Forms.Appearance)
        Me.chkWorkOffline.BackgroundImage = CType(resources.GetObject("chkWorkOffline.BackgroundImage"), System.Drawing.Image)
        Me.chkWorkOffline.CheckAlign = CType(resources.GetObject("chkWorkOffline.CheckAlign"), System.Drawing.ContentAlignment)
        Me.chkWorkOffline.Dock = CType(resources.GetObject("chkWorkOffline.Dock"), System.Windows.Forms.DockStyle)
        Me.chkWorkOffline.Enabled = CType(resources.GetObject("chkWorkOffline.Enabled"), Boolean)
        Me.chkWorkOffline.FlatStyle = CType(resources.GetObject("chkWorkOffline.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.chkWorkOffline.Font = CType(resources.GetObject("chkWorkOffline.Font"), System.Drawing.Font)
        Me.chkWorkOffline.Image = CType(resources.GetObject("chkWorkOffline.Image"), System.Drawing.Image)
        Me.chkWorkOffline.ImageAlign = CType(resources.GetObject("chkWorkOffline.ImageAlign"), System.Drawing.ContentAlignment)
        Me.chkWorkOffline.ImageIndex = CType(resources.GetObject("chkWorkOffline.ImageIndex"), Integer)
        Me.chkWorkOffline.ImeMode = CType(resources.GetObject("chkWorkOffline.ImeMode"), System.Windows.Forms.ImeMode)
        Me.chkWorkOffline.Location = CType(resources.GetObject("chkWorkOffline.Location"), System.Drawing.Point)
        Me.chkWorkOffline.Name = "chkWorkOffline"
        Me.chkWorkOffline.RightToLeft = CType(resources.GetObject("chkWorkOffline.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.chkWorkOffline.Size = CType(resources.GetObject("chkWorkOffline.Size"), System.Drawing.Size)
        Me.chkWorkOffline.TabIndex = CType(resources.GetObject("chkWorkOffline.TabIndex"), Integer)
        Me.chkWorkOffline.Text = resources.GetString("chkWorkOffline.Text")
        Me.chkWorkOffline.TextAlign = CType(resources.GetObject("chkWorkOffline.TextAlign"), System.Drawing.ContentAlignment)
        Me.chkWorkOffline.Visible = CType(resources.GetObject("chkWorkOffline.Visible"), Boolean)
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
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkWorkOffline, Me.bnReset, Me.bnGetCustomers, Me.Label11, Me.tbCountry, Me.bnCancelAll, Me.bnCancel, Me.bnDelete, Me.bnSaveCustomers, Me.bnAdd, Me.lblPosition, Me.bnFirst, Me.bnPrev, Me.bnNext, Me.bnLast, Me.Label10, Me.tbFax, Me.tbPhone, Me.Label9, Me.tbPostalCode, Me.Label8, Me.tbRegion, Me.Label7, Me.Label6, Me.tbCity, Me.Label5, Me.tbAddress, Me.Label4, Me.tbContactTitle, Me.Label3, Me.tbContactName, Me.tbCompanyName, Me.tbCustomerID, Me.Label2, Me.Label1})
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

    Private Sub bnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bnAdd.Click
        Try
            'Close any editing
            BindingContext(dsCustomers, "Customers").EndCurrentEdit()
            BindingContext(dsCustomers, "Customers").AddNew()
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

        ' Adding a new record.  View State enables buttons
        ' based on this value
        IsAdding = True

        UpdateViewState()
    End Sub

    Private Sub bnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bnCancel.Click
        ' Return row to original value
        BindingContext(dsCustomers, "Customers").CancelCurrentEdit()

        IsAdding = False

        UpdateViewState()
    End Sub

    Private Sub bnCancelAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bnCancelAll.Click
        ' Return DataSet to original values
        dsCustomers.Customers.RejectChanges()
    End Sub

    Private Sub bnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bnDelete.Click
        'Use Delete method instead of the RemoveAt method
        'when the DataSet will update a data source
        dsCustomers.Customers(BindingContext(dsCustomers, "Customers").Position).Delete()
        UpdateViewState()
    End Sub

    Private Sub bnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bnFirst.Click
        BindingContext(dsCustomers, "Customers").Position = 0
        UpdateViewState()
    End Sub

    Private Sub bnGetCustomers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bnGetCustomers.Click
        ' Data can be retrieved from XML or the server
        If chkWorkOffline.Checked Then
            dsCustomers = GetCustomersFromXML()
        Else
            dsCustomers = GetCustomersFromServer()
        End If

        BindData()
        UpdateViewState()
    End Sub

    Private Sub bnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bnLast.Click
        BindingContext(dsCustomers, "Customers").Position = BindingContext(dsCustomers, "Customers").Count
        UpdateViewState()
    End Sub

    Private Sub bnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bnNext.Click
        BindingContext(dsCustomers, "Customers").Position += 1
        UpdateViewState()
    End Sub

    Private Sub bnPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bnPrev.Click
        BindingContext(dsCustomers, "Customers").Position -= 1
        UpdateViewState()
    End Sub

    Private Sub bnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bnReset.Click
        ' Empty Customers table
        dsCustomers.Customers.Clear()

        ' Update Viewstate to allow retrieval of data
        UpdateViewState()
    End Sub

    Private Sub bnSaveCustomers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bnSaveCustomers.Click
        ' Flush changes into DataSet
        BindingContext(dsCustomers, "Customers").EndCurrentEdit()

        ' Updates can be performed in XML or the server
        If chkWorkOffline.Checked Then
            ' Send DataSet to be written to XML file
            SaveCustomersInXML(dsCustomers)
        Else
            ' Extract changed records from dsCustomers DataSet
            dsCustomerChanges = CType(dsCustomers.GetChanges, CustomersDataSet)

            ' Update data source if changes exist and merge back into
            ' current DataSet
            If Not (dsCustomerChanges Is Nothing) Then
                dsCustomerChanges = SaveCustomersOnServer(dsCustomerChanges)

                ' Merge changes into DataSet if any are returned
                If Not (dsCustomerChanges Is Nothing) Then
                    dsCustomers.Merge(dsCustomerChanges)
                End If
            End If
        End If
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Copy Customers table to CustomersHT to
        ' prevent foreign key constraint errors
        SetupTable()
        UpdateViewState()
    End Sub

    Sub BindData()
        ' Clear all data bindings
        tbCustomerID.DataBindings.Clear()
        tbCompanyName.DataBindings.Clear()
        tbContactName.DataBindings.Clear()
        tbContactTitle.DataBindings.Clear()
        tbAddress.DataBindings.Clear()
        tbCity.DataBindings.Clear()
        tbRegion.DataBindings.Clear()
        tbPostalCode.DataBindings.Clear()
        tbCountry.DataBindings.Clear()
        tbPhone.DataBindings.Clear()
        tbFax.DataBindings.Clear()

        ' Bind the control's property to a field in dsCustomers
        ' so that the data will display that control.  DataBinding will
        ' manage the displaying of the data as the user navigates, inserts, 
        ' updates and deletes the data in the dataset.
        tbCustomerID.DataBindings.Add("Text", dsCustomers, "Customers.CustomerID")
        tbCompanyName.DataBindings.Add("Text", dsCustomers, "Customers.CompanyName")
        tbContactName.DataBindings.Add("Text", dsCustomers, "Customers.ContactName")
        tbContactTitle.DataBindings.Add("Text", dsCustomers, "Customers.ContactTitle")
        tbAddress.DataBindings.Add("Text", dsCustomers, "Customers.Address")
        tbCity.DataBindings.Add("Text", dsCustomers, "Customers.City")
        tbRegion.DataBindings.Add("Text", dsCustomers, "Customers.Region")
        tbPostalCode.DataBindings.Add("Text", dsCustomers, "Customers.PostalCode")
        tbCountry.DataBindings.Add("Text", dsCustomers, "Customers.Country")
        tbPhone.DataBindings.Add("Text", dsCustomers, "Customers.Phone")
        tbFax.DataBindings.Add("Text", dsCustomers, "Customers.Fax")
    End Sub

    Function GetCustomersFromServer() As CustomersDataSet
        ' Gets customer records from CustomersHT table in the
        ' Northwind database.
        Static ConnectionString As String = MSDE_CONNECTION_STRING

        Dim ds As New CustomersDataSet()

        ' Display a status message saying that we're attempting to connect.
        ' This only needs to be done the very first time a connection is
        ' attempted.  After we've determined that MSDE or SQL Server is
        ' installed, this message no longer needs to be displayed.
        Dim frmStatusMessage As New frmStatus()
        If Not DidPreviouslyConnect Then
            frmStatusMessage.Show("Connecting to MSDE")
        End If

        ' Attempt to connect to the local SQL server instance, and a local
        ' MSDE installation (with Northwind).  
        Dim IsConnecting As Boolean = True
        While IsConnecting

            Try
                ' The SqlConnection class allows you to communicate with SQL Server.
                ' The constructor accepts a connection string as an argument.  This
                ' connection string uses Integrated Security, which means that you 
                ' must have a login in to SQL Server, or be part of the Administrators
                ' group on your local machine for this to work.
                Dim cnNorthwind As New SqlConnection(ConnectionString)

                ' The SqlDataAdapter is used to populate a DataSet
                daCustomers = New SqlDataAdapter( _
                    "SELECT CustomerID, CompanyName, ContactName, ContactTitle, " _
                      & "Address, City, Region, PostalCode, Country, Phone, Fax " _
                    & "FROM CustomersHT", _
                    cnNorthwind)

                ' Populate the DataSet with the information from the customers
                ' table.  Since a DataSet can hold multiple result sets, it's
                ' a good idea to "name" the result set when you populate the
                ' DataSet.  In this case, the result set is named "Customers".
                daCustomers.Fill(ds, "Customers")

                ' Data has been successfully retrieved, so break out of the loop.
                IsConnecting = False
                DidPreviouslyConnect = True

            Catch exc As Exception
                If ConnectionString = MSDE_CONNECTION_STRING Then
                    ' Couldn't connect to SQL Server.  Now try MSDE.
                    ConnectionString = SQL_CONNECTION_STRING
                    frmStatusMessage.Show("Connecting to SQL Server")
                Else
                    ' Unable to connect to SQL Server or MSDE
                    frmStatusMessage.Close()
                    MessageBox.Show("To run this sample, you must have SQL " & _
                        "or MSDE with the Northwind database installed.  For " & _
                        "instructions on installing MSDE, view the ReadMe file.", _
                        "SQL Server/MSDE not found", _
                        MessageBoxButtons.OK, _
                        MessageBoxIcon.Exclamation)
                    End
                End If
            End Try
        End While

        frmStatusMessage.Close()

        daCustomers.Dispose()

        Return ds
    End Function

    Function GetCustomersFromXML() As CustomersDataSet
        Dim ds As New CustomersDataSet()

        ' Reads the XML file into the DataSet.  Use the DiffGram
        ' mode so that RowState data can be used to update the 
        ' data source when the SQL Data Adapter's Update method
        ' is called.  The DiffGram mode must also be used when the
        ' DataSet's WriteXML method was called.
        Try
            ds.ReadXml("../dsCustomers.xml", XmlReadMode.DiffGram)
            ds.Tables(0).TableName = "Customers"
        Catch FileNotFound As FileNotFoundException
            ' The XML data must be written before it can be read
            MsgBox("No XML file available.  View data online and save to offline.", MsgBoxStyle.Critical)
        End Try

        Return ds
    End Function

    Function SaveCustomersOnServer(ByVal dsCustomerChanges As CustomersDataSet) As CustomersDataSet
        ' Update CustomersHT table with changes from the DataSet
        Static ConnectionString As String = MSDE_CONNECTION_STRING

        ' Display a status message saying that we're attempting to connect.
        ' This only needs to be done the very first time a connection is
        ' attempted.  After we've determined that MSDE or SQL Server is
        ' installed, this message no longer needs to be displayed.
        Dim frmStatusMessage As New frmStatus()
        If Not DidPreviouslyConnect Then
            frmStatusMessage.Show("Connecting to MSDE")
        End If

        ' Attempt to connect to the local SQL server instance, and a local
        ' MSDE installation (with Northwind).  
        Dim IsConnecting As Boolean = True
        While IsConnecting

            Try
                ' The SqlConnection class allows you to communicate with SQL Server.
                ' The constructor accepts a connection string as an argument.  This
                ' connection string uses Integrated Security, which means that you 
                ' must have a login in to SQL Server, or be part of the Administrators
                ' group on your local machine for this to work.
                Dim cnNorthwind As New SqlConnection(ConnectionString)

                ' The SqlDataAdapter is used to populate a DataSet
                daCustomers = New SqlDataAdapter( _
                    "SELECT CustomerID, CompanyName, ContactName, ContactTitle, " _
                      & "Address, City, Region, PostalCode, Country, Phone, Fax " _
                    & "FROM CustomersHT", _
                    cnNorthwind)

                ' The SqlCommandBuilder examines the Select statement and
                ' builds the SQL command text to perform inserts, updates 
                ' and deletes.
                Dim oCommandBuilder As New SqlCommandBuilder(daCustomers)

                daCustomers.InsertCommand = oCommandBuilder.GetInsertCommand
                daCustomers.UpdateCommand = oCommandBuilder.GetUpdateCommand
                daCustomers.DeleteCommand = oCommandBuilder.GetDeleteCommand

                ' Update the data source with the changed rows
                ' and return the changes
                If Not (dsCustomerChanges Is Nothing) Then
                    ' Must specify which table to update
                    daCustomers.Update(dsCustomerChanges.Tables(0))
                    Return dsCustomerChanges
                Else
                    Return Nothing
                End If

                ' Data has been successfully updated, so break out of the loop.
                IsConnecting = False
                DidPreviouslyConnect = True

            Catch sqlExc As SqlException
                Select Case sqlExc.Number
                    Case 17
                        ' SQL Server does not exist
                        If ConnectionString = MSDE_CONNECTION_STRING Then
                            ' Couldn't connect to SQL Server.  Now try MSDE.
                            ConnectionString = SQL_CONNECTION_STRING
                            frmStatusMessage.Show("Connecting to SQL Server")
                        Else
                            ' Unable to connect to SQL Server or MSDE
                            frmStatusMessage.Close()
                            MessageBox.Show("To run this sample, you must have SQL " & _
                                "or MSDE with the Northwind database installed.  For " & _
                                "instructions on installing MSDE, view the ReadMe file.", _
                                "SQL Server/MSDE not found", _
                                MessageBoxButtons.OK, _
                                MessageBoxIcon.Exclamation)
                            End
                        End If
                    Case 2627
                        'Primary Key Violation
                        MsgBox("2 Records were added with the same primary key.  Changes canceled.", MsgBoxStyle.Critical, Me.Text)
                        dsCustomers.RejectChanges()
                        Exit Function
                End Select
            Catch exc As Exception
                MsgBox(exc.Message, MsgBoxStyle.Critical, Me.Text)
            End Try
        End While

        frmStatusMessage.Close()

    End Function

    Sub SetupTable()
        ' Creates CustomersHT and inserts records from the customers
        ' table.
        Static ConnectionString As String = MSDE_CONNECTION_STRING

        Dim ds As New CustomersDataSet()

        ' Display a status message saying that we're attempting to connect.
        ' This only needs to be done the very first time a connection is
        ' attempted.  After we've determined that MSDE or SQL Server is
        ' installed, this message no longer needs to be displayed.
        Dim frmStatusMessage As New frmStatus()
        If Not DidPreviouslyConnect Then
            frmStatusMessage.Show("Connecting to MSDE")
        End If

        ' Attempt to connect to the local SQL server instance, and a local
        ' MSDE installation (with Northwind).  
        Dim IsConnecting As Boolean = True
        While IsConnecting

            Try
                ' The SqlConnection class allows you to communicate with SQL Server.
                ' The constructor accepts a connection string as an argument.  This
                ' connection string uses Integrated Security, which means that you 
                ' must have a login in to SQL Server, or be part of the Administrators
                ' group on your local machine for this to work.
                Dim cnNorthwind As New SqlConnection(ConnectionString)
                cnNorthwind.Open()

                ' The table used for this How-To must be created
                ' Instantiate Command Object to execute SQL Statements
                Dim cmInitSQL As New SqlCommand()

                ' Attach the command to the connection
                cmInitSQL.Connection = cnNorthwind

                ' Set the command type to Text
                cmInitSQL.CommandType = CommandType.Text

                ' Drop CustomerHT table if it exists.
                cmInitSQL.CommandText = "SELECT count(*) FROM dbo.sysobjects WHERE id = object_id('CustomersHT')"


                ' Execute the statement
                Dim recordCount As Integer = CType(cmInitSQL.ExecuteScalar(), Integer)
                If recordCount > 0 Then
                    ' If table exists in the database return from the function if not create it.
                    ' Destroy cmInitSQl and close connection
                    cmInitSQL.Dispose()
                    cnNorthwind.Close()

                    ' Data has been successfully updated, so break out of the loop.
                    IsConnecting = False
                    DidPreviouslyConnect = True
                    Return
                End If


                ' Create CustomersHT Table
                cmInitSQL.CommandText = "CREATE TABLE [CustomersHT] ( " & _
                                        "[CustomerID] [nchar] (5) NOT NULL PRIMARY KEY ," & _
                                        "[CompanyName] [nvarchar] (40) NOT NULL , " & _
                                        "[ContactName] [nvarchar] (30) NULL , " & _
                                        "[ContactTitle] [nvarchar] (30) NULL , " & _
                                        "[Address] [nvarchar] (60)  NULL , " & _
                                        "[City] [nvarchar] (15) NULL , " & _
                                        "[Region] [nvarchar] (15) NULL , " & _
                                        "[PostalCode] [nvarchar] (10) NULL , " & _
                                        "[Country] [nvarchar] (15) NULL , " & _
                                        "[Phone] [nvarchar] (24) NULL , " & _
                                        "[Fax] [nvarchar] (24) NULL )"

                ' Execute the statement
                cmInitSQL.ExecuteNonQuery()


                ' Insert data into new CustomersHT table from Customers table in northwind
                cmInitSQL.CommandText = "INSERT INTO CustomersHT " & _
                                        "(CustomerID, CompanyName, ContactName," & _
                                        "ContactTitle, Address, City, Region," & _
                                        "PostalCode, Country, Phone, Fax) " & _
                                        "SELECT CustomerID, CompanyName, ContactName," & _
                                        "ContactTitle, Address, City, Region," & _
                                        "PostalCode, Country, Phone, Fax FROM Customers"

                ' Execute the statement
                cmInitSQL.ExecuteNonQuery()

                ' Destroy cmInitSQl and close connection
                cmInitSQL.Dispose()
                cnNorthwind.Close()

                ' Data has been successfully updated, so break out of the loop.
                IsConnecting = False
                DidPreviouslyConnect = True

            Catch e As SqlException
                If ConnectionString = MSDE_CONNECTION_STRING Then
                    ' Couldn't connect to SQL server. Now try MSDE
                    ConnectionString = SQL_CONNECTION_STRING
                    frmStatusMessage.Show("Connecting to SQL Server")
                Else
                    ' Unable to connect to SQL Server or MSDE
                    frmStatusMessage.Close()
                    MsgBox("To run this sample you must have SQL Server ot MSDE with " & _
                           "the Northwind database installed.  For instructions on " & _
                           "installing MSDE, view the Readme file.", MsgBoxStyle.Critical, _
                           "SQL Server/MSDE not found")
                    ' Quit program if neither connection method was successful.
                    End

                End If
            Catch e As Exception
                MsgBox(e.Message, MsgBoxStyle.Critical, "General Error")
            End Try
        End While
    End Sub

    Sub UpdateViewState()
        ' Display the record position so the
        ' user knows what record they are on and
        ' how many are available.
        lblPosition.Text = (((BindingContext(dsCustomers, "Customers").Position + 1).ToString + " of  ") _
            + BindingContext(dsCustomers, "Customers").Count.ToString)

        ' If we have a DataSet with data in it then disable the
        ' Read buttons and enable all the update buttons
        If dsCustomers.Customers.Count <> 0 Then
            bnGetCustomers.Enabled = False

            bnAdd.Enabled = True
            bnDelete.Enabled = True

            bnCancel.Enabled = True
            bnCancelAll.Enabled = True

            bnSaveCustomers.Enabled = True

            bnReset.Enabled = True
        Else
            bnGetCustomers.Enabled = True

            bnAdd.Enabled = False
            bnDelete.Enabled = False

            bnCancel.Enabled = False
            bnCancelAll.Enabled = False

            bnSaveCustomers.Enabled = False

            bnReset.Enabled = False
        End If

        ' Allow user to change CustomerID when
        ' adding a record.  Do not allow deletes
        ' while adding a record.
        If IsAdding Then
            tbCustomerID.Enabled = True
            bnDelete.Enabled = False
        Else
            tbCustomerID.Enabled = False
        End If

        ' IsAdding is no longer needed
        IsAdding = False

    End Sub

    Function SaveCustomersInXML(ByVal dsCustomers As CustomersDataSet) As CustomersDataSet
        ' Write the DataSet to a local XML file.  Use the 
        ' DiffGram mode to store the current all RowState data
        ' so that the SQL Data Adapter can perform the appropriate
        ' operation when the Update method is called.  DiffGram must
        ' also be used when the data is read from the XML file.
        dsCustomers.WriteXml("../dsCustomers.xml", XmlWriteMode.DiffGram)

        Return dsCustomers
    End Function

End Class