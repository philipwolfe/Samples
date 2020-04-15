Option Strict On
Option Explicit On 

Imports System.Data
Imports System.Data.SqlClient

Public Class frmMain
    Inherits System.Windows.Forms.Form

    Protected Const SQL_CONNECTION_STRING As String = _
        "Server=localhost;" & _
        "DataBase=Northwind;" & _
        "Integrated Security=SSPI;Connect Timeout=5"

    Protected Const MSDE_CONNECTION_STRING As String = _
        "Server=(local)\NetSDK;" & _
        "DataBase=Northwind;" & _
        "Integrated Security=SSPI;Connect Timeout=5"

    Private ConnectionString As String = MSDE_CONNECTION_STRING
    Private HasConnected As Boolean = False
    Private Mode As String = "Update"

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

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
    Friend WithEvents txtProductID As System.Windows.Forms.TextBox
    Friend WithEvents txtProductName As System.Windows.Forms.TextBox
    Friend WithEvents txtUnitPrice As System.Windows.Forms.TextBox
    Friend WithEvents txtUnitsOnOrder As System.Windows.Forms.TextBox
    Friend WithEvents txtUnitsInStock As System.Windows.Forms.TextBox
    Friend WithEvents txtReorderLevel As System.Windows.Forms.TextBox
    Friend WithEvents txtQtyPerUnit As System.Windows.Forms.TextBox
    Friend WithEvents cbSuppliers As System.Windows.Forms.ComboBox
    Friend WithEvents cbCategories As System.Windows.Forms.ComboBox
    Friend WithEvents lstProducts As System.Windows.Forms.ListBox
    Friend WithEvents lblProductID As System.Windows.Forms.Label
    Friend WithEvents lblProductName As System.Windows.Forms.Label
    Friend WithEvents lblSuppliers As System.Windows.Forms.Label
    Friend WithEvents lblCategories As System.Windows.Forms.Label
    Friend WithEvents lblUnitPrice As System.Windows.Forms.Label
    Friend WithEvents lblUnitsInStock As System.Windows.Forms.Label
    Friend WithEvents lblUnitsOnOrder As System.Windows.Forms.Label
    Friend WithEvents lblReorderLevel As System.Windows.Forms.Label
    Friend WithEvents lblQtyPerUnit As System.Windows.Forms.Label
    Friend WithEvents gbHorvRule As System.Windows.Forms.GroupBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents lblProductList As System.Windows.Forms.Label
    Friend WithEvents chkDiscontinued As System.Windows.Forms.CheckBox
    Friend WithEvents mnuMain As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuExit As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAbout As System.Windows.Forms.MenuItem
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.txtProductID = New System.Windows.Forms.TextBox()
        Me.txtProductName = New System.Windows.Forms.TextBox()
        Me.txtUnitPrice = New System.Windows.Forms.TextBox()
        Me.txtUnitsOnOrder = New System.Windows.Forms.TextBox()
        Me.txtUnitsInStock = New System.Windows.Forms.TextBox()
        Me.txtReorderLevel = New System.Windows.Forms.TextBox()
        Me.txtQtyPerUnit = New System.Windows.Forms.TextBox()
        Me.cbSuppliers = New System.Windows.Forms.ComboBox()
        Me.cbCategories = New System.Windows.Forms.ComboBox()
        Me.chkDiscontinued = New System.Windows.Forms.CheckBox()
        Me.lstProducts = New System.Windows.Forms.ListBox()
        Me.lblProductID = New System.Windows.Forms.Label()
        Me.lblProductName = New System.Windows.Forms.Label()
        Me.lblSuppliers = New System.Windows.Forms.Label()
        Me.lblCategories = New System.Windows.Forms.Label()
        Me.lblUnitPrice = New System.Windows.Forms.Label()
        Me.lblUnitsInStock = New System.Windows.Forms.Label()
        Me.lblUnitsOnOrder = New System.Windows.Forms.Label()
        Me.lblReorderLevel = New System.Windows.Forms.Label()
        Me.lblQtyPerUnit = New System.Windows.Forms.Label()
        Me.gbHorvRule = New System.Windows.Forms.GroupBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.lblProductList = New System.Windows.Forms.Label()
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.MenuItem4 = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.SuspendLayout()
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
        Me.txtProductName.AccessibleDescription = resources.GetString("txtProductName.AccessibleDescription")
        Me.txtProductName.AccessibleName = resources.GetString("txtProductName.AccessibleName")
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
        Me.txtProductName.RightToLeft = CType(resources.GetObject("txtProductName.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtProductName.ScrollBars = CType(resources.GetObject("txtProductName.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtProductName.Size = CType(resources.GetObject("txtProductName.Size"), System.Drawing.Size)
        Me.txtProductName.TabIndex = CType(resources.GetObject("txtProductName.TabIndex"), Integer)
        Me.txtProductName.Text = resources.GetString("txtProductName.Text")
        Me.txtProductName.TextAlign = CType(resources.GetObject("txtProductName.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtProductName.Visible = CType(resources.GetObject("txtProductName.Visible"), Boolean)
        Me.txtProductName.WordWrap = CType(resources.GetObject("txtProductName.WordWrap"), Boolean)
        '
        'txtUnitPrice
        '
        Me.txtUnitPrice.AccessibleDescription = resources.GetString("txtUnitPrice.AccessibleDescription")
        Me.txtUnitPrice.AccessibleName = resources.GetString("txtUnitPrice.AccessibleName")
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
        Me.txtUnitPrice.RightToLeft = CType(resources.GetObject("txtUnitPrice.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtUnitPrice.ScrollBars = CType(resources.GetObject("txtUnitPrice.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtUnitPrice.Size = CType(resources.GetObject("txtUnitPrice.Size"), System.Drawing.Size)
        Me.txtUnitPrice.TabIndex = CType(resources.GetObject("txtUnitPrice.TabIndex"), Integer)
        Me.txtUnitPrice.Text = resources.GetString("txtUnitPrice.Text")
        Me.txtUnitPrice.TextAlign = CType(resources.GetObject("txtUnitPrice.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtUnitPrice.Visible = CType(resources.GetObject("txtUnitPrice.Visible"), Boolean)
        Me.txtUnitPrice.WordWrap = CType(resources.GetObject("txtUnitPrice.WordWrap"), Boolean)
        '
        'txtUnitsOnOrder
        '
        Me.txtUnitsOnOrder.AccessibleDescription = resources.GetString("txtUnitsOnOrder.AccessibleDescription")
        Me.txtUnitsOnOrder.AccessibleName = resources.GetString("txtUnitsOnOrder.AccessibleName")
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
        Me.txtUnitsOnOrder.RightToLeft = CType(resources.GetObject("txtUnitsOnOrder.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtUnitsOnOrder.ScrollBars = CType(resources.GetObject("txtUnitsOnOrder.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtUnitsOnOrder.Size = CType(resources.GetObject("txtUnitsOnOrder.Size"), System.Drawing.Size)
        Me.txtUnitsOnOrder.TabIndex = CType(resources.GetObject("txtUnitsOnOrder.TabIndex"), Integer)
        Me.txtUnitsOnOrder.Text = resources.GetString("txtUnitsOnOrder.Text")
        Me.txtUnitsOnOrder.TextAlign = CType(resources.GetObject("txtUnitsOnOrder.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtUnitsOnOrder.Visible = CType(resources.GetObject("txtUnitsOnOrder.Visible"), Boolean)
        Me.txtUnitsOnOrder.WordWrap = CType(resources.GetObject("txtUnitsOnOrder.WordWrap"), Boolean)
        '
        'txtUnitsInStock
        '
        Me.txtUnitsInStock.AccessibleDescription = resources.GetString("txtUnitsInStock.AccessibleDescription")
        Me.txtUnitsInStock.AccessibleName = resources.GetString("txtUnitsInStock.AccessibleName")
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
        Me.txtUnitsInStock.RightToLeft = CType(resources.GetObject("txtUnitsInStock.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtUnitsInStock.ScrollBars = CType(resources.GetObject("txtUnitsInStock.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtUnitsInStock.Size = CType(resources.GetObject("txtUnitsInStock.Size"), System.Drawing.Size)
        Me.txtUnitsInStock.TabIndex = CType(resources.GetObject("txtUnitsInStock.TabIndex"), Integer)
        Me.txtUnitsInStock.Text = resources.GetString("txtUnitsInStock.Text")
        Me.txtUnitsInStock.TextAlign = CType(resources.GetObject("txtUnitsInStock.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtUnitsInStock.Visible = CType(resources.GetObject("txtUnitsInStock.Visible"), Boolean)
        Me.txtUnitsInStock.WordWrap = CType(resources.GetObject("txtUnitsInStock.WordWrap"), Boolean)
        '
        'txtReorderLevel
        '
        Me.txtReorderLevel.AccessibleDescription = resources.GetString("txtReorderLevel.AccessibleDescription")
        Me.txtReorderLevel.AccessibleName = resources.GetString("txtReorderLevel.AccessibleName")
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
        Me.txtReorderLevel.RightToLeft = CType(resources.GetObject("txtReorderLevel.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtReorderLevel.ScrollBars = CType(resources.GetObject("txtReorderLevel.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtReorderLevel.Size = CType(resources.GetObject("txtReorderLevel.Size"), System.Drawing.Size)
        Me.txtReorderLevel.TabIndex = CType(resources.GetObject("txtReorderLevel.TabIndex"), Integer)
        Me.txtReorderLevel.Text = resources.GetString("txtReorderLevel.Text")
        Me.txtReorderLevel.TextAlign = CType(resources.GetObject("txtReorderLevel.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtReorderLevel.Visible = CType(resources.GetObject("txtReorderLevel.Visible"), Boolean)
        Me.txtReorderLevel.WordWrap = CType(resources.GetObject("txtReorderLevel.WordWrap"), Boolean)
        '
        'txtQtyPerUnit
        '
        Me.txtQtyPerUnit.AccessibleDescription = resources.GetString("txtQtyPerUnit.AccessibleDescription")
        Me.txtQtyPerUnit.AccessibleName = resources.GetString("txtQtyPerUnit.AccessibleName")
        Me.txtQtyPerUnit.Anchor = CType(resources.GetObject("txtQtyPerUnit.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtQtyPerUnit.AutoSize = CType(resources.GetObject("txtQtyPerUnit.AutoSize"), Boolean)
        Me.txtQtyPerUnit.BackgroundImage = CType(resources.GetObject("txtQtyPerUnit.BackgroundImage"), System.Drawing.Image)
        Me.txtQtyPerUnit.Dock = CType(resources.GetObject("txtQtyPerUnit.Dock"), System.Windows.Forms.DockStyle)
        Me.txtQtyPerUnit.Enabled = CType(resources.GetObject("txtQtyPerUnit.Enabled"), Boolean)
        Me.txtQtyPerUnit.Font = CType(resources.GetObject("txtQtyPerUnit.Font"), System.Drawing.Font)
        Me.txtQtyPerUnit.ImeMode = CType(resources.GetObject("txtQtyPerUnit.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtQtyPerUnit.Location = CType(resources.GetObject("txtQtyPerUnit.Location"), System.Drawing.Point)
        Me.txtQtyPerUnit.MaxLength = CType(resources.GetObject("txtQtyPerUnit.MaxLength"), Integer)
        Me.txtQtyPerUnit.Multiline = CType(resources.GetObject("txtQtyPerUnit.Multiline"), Boolean)
        Me.txtQtyPerUnit.Name = "txtQtyPerUnit"
        Me.txtQtyPerUnit.PasswordChar = CType(resources.GetObject("txtQtyPerUnit.PasswordChar"), Char)
        Me.txtQtyPerUnit.RightToLeft = CType(resources.GetObject("txtQtyPerUnit.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtQtyPerUnit.ScrollBars = CType(resources.GetObject("txtQtyPerUnit.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtQtyPerUnit.Size = CType(resources.GetObject("txtQtyPerUnit.Size"), System.Drawing.Size)
        Me.txtQtyPerUnit.TabIndex = CType(resources.GetObject("txtQtyPerUnit.TabIndex"), Integer)
        Me.txtQtyPerUnit.Text = resources.GetString("txtQtyPerUnit.Text")
        Me.txtQtyPerUnit.TextAlign = CType(resources.GetObject("txtQtyPerUnit.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtQtyPerUnit.Visible = CType(resources.GetObject("txtQtyPerUnit.Visible"), Boolean)
        Me.txtQtyPerUnit.WordWrap = CType(resources.GetObject("txtQtyPerUnit.WordWrap"), Boolean)
        '
        'cbSuppliers
        '
        Me.cbSuppliers.AccessibleDescription = resources.GetString("cbSuppliers.AccessibleDescription")
        Me.cbSuppliers.AccessibleName = resources.GetString("cbSuppliers.AccessibleName")
        Me.cbSuppliers.Anchor = CType(resources.GetObject("cbSuppliers.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.cbSuppliers.BackgroundImage = CType(resources.GetObject("cbSuppliers.BackgroundImage"), System.Drawing.Image)
        Me.cbSuppliers.Dock = CType(resources.GetObject("cbSuppliers.Dock"), System.Windows.Forms.DockStyle)
        Me.cbSuppliers.Enabled = CType(resources.GetObject("cbSuppliers.Enabled"), Boolean)
        Me.cbSuppliers.Font = CType(resources.GetObject("cbSuppliers.Font"), System.Drawing.Font)
        Me.cbSuppliers.ImeMode = CType(resources.GetObject("cbSuppliers.ImeMode"), System.Windows.Forms.ImeMode)
        Me.cbSuppliers.IntegralHeight = CType(resources.GetObject("cbSuppliers.IntegralHeight"), Boolean)
        Me.cbSuppliers.ItemHeight = CType(resources.GetObject("cbSuppliers.ItemHeight"), Integer)
        Me.cbSuppliers.Location = CType(resources.GetObject("cbSuppliers.Location"), System.Drawing.Point)
        Me.cbSuppliers.MaxDropDownItems = CType(resources.GetObject("cbSuppliers.MaxDropDownItems"), Integer)
        Me.cbSuppliers.MaxLength = CType(resources.GetObject("cbSuppliers.MaxLength"), Integer)
        Me.cbSuppliers.Name = "cbSuppliers"
        Me.cbSuppliers.RightToLeft = CType(resources.GetObject("cbSuppliers.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.cbSuppliers.Size = CType(resources.GetObject("cbSuppliers.Size"), System.Drawing.Size)
        Me.cbSuppliers.TabIndex = CType(resources.GetObject("cbSuppliers.TabIndex"), Integer)
        Me.cbSuppliers.Text = resources.GetString("cbSuppliers.Text")
        Me.cbSuppliers.Visible = CType(resources.GetObject("cbSuppliers.Visible"), Boolean)
        '
        'cbCategories
        '
        Me.cbCategories.AccessibleDescription = resources.GetString("cbCategories.AccessibleDescription")
        Me.cbCategories.AccessibleName = resources.GetString("cbCategories.AccessibleName")
        Me.cbCategories.Anchor = CType(resources.GetObject("cbCategories.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.cbCategories.BackgroundImage = CType(resources.GetObject("cbCategories.BackgroundImage"), System.Drawing.Image)
        Me.cbCategories.Dock = CType(resources.GetObject("cbCategories.Dock"), System.Windows.Forms.DockStyle)
        Me.cbCategories.Enabled = CType(resources.GetObject("cbCategories.Enabled"), Boolean)
        Me.cbCategories.Font = CType(resources.GetObject("cbCategories.Font"), System.Drawing.Font)
        Me.cbCategories.ImeMode = CType(resources.GetObject("cbCategories.ImeMode"), System.Windows.Forms.ImeMode)
        Me.cbCategories.IntegralHeight = CType(resources.GetObject("cbCategories.IntegralHeight"), Boolean)
        Me.cbCategories.ItemHeight = CType(resources.GetObject("cbCategories.ItemHeight"), Integer)
        Me.cbCategories.Location = CType(resources.GetObject("cbCategories.Location"), System.Drawing.Point)
        Me.cbCategories.MaxDropDownItems = CType(resources.GetObject("cbCategories.MaxDropDownItems"), Integer)
        Me.cbCategories.MaxLength = CType(resources.GetObject("cbCategories.MaxLength"), Integer)
        Me.cbCategories.Name = "cbCategories"
        Me.cbCategories.RightToLeft = CType(resources.GetObject("cbCategories.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.cbCategories.Size = CType(resources.GetObject("cbCategories.Size"), System.Drawing.Size)
        Me.cbCategories.TabIndex = CType(resources.GetObject("cbCategories.TabIndex"), Integer)
        Me.cbCategories.Text = resources.GetString("cbCategories.Text")
        Me.cbCategories.Visible = CType(resources.GetObject("cbCategories.Visible"), Boolean)
        '
        'chkDiscontinued
        '
        Me.chkDiscontinued.AccessibleDescription = resources.GetString("chkDiscontinued.AccessibleDescription")
        Me.chkDiscontinued.AccessibleName = resources.GetString("chkDiscontinued.AccessibleName")
        Me.chkDiscontinued.Anchor = CType(resources.GetObject("chkDiscontinued.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.chkDiscontinued.Appearance = CType(resources.GetObject("chkDiscontinued.Appearance"), System.Windows.Forms.Appearance)
        Me.chkDiscontinued.BackgroundImage = CType(resources.GetObject("chkDiscontinued.BackgroundImage"), System.Drawing.Image)
        Me.chkDiscontinued.CheckAlign = CType(resources.GetObject("chkDiscontinued.CheckAlign"), System.Drawing.ContentAlignment)
        Me.chkDiscontinued.Dock = CType(resources.GetObject("chkDiscontinued.Dock"), System.Windows.Forms.DockStyle)
        Me.chkDiscontinued.Enabled = CType(resources.GetObject("chkDiscontinued.Enabled"), Boolean)
        Me.chkDiscontinued.FlatStyle = CType(resources.GetObject("chkDiscontinued.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.chkDiscontinued.Font = CType(resources.GetObject("chkDiscontinued.Font"), System.Drawing.Font)
        Me.chkDiscontinued.Image = CType(resources.GetObject("chkDiscontinued.Image"), System.Drawing.Image)
        Me.chkDiscontinued.ImageAlign = CType(resources.GetObject("chkDiscontinued.ImageAlign"), System.Drawing.ContentAlignment)
        Me.chkDiscontinued.ImageIndex = CType(resources.GetObject("chkDiscontinued.ImageIndex"), Integer)
        Me.chkDiscontinued.ImeMode = CType(resources.GetObject("chkDiscontinued.ImeMode"), System.Windows.Forms.ImeMode)
        Me.chkDiscontinued.Location = CType(resources.GetObject("chkDiscontinued.Location"), System.Drawing.Point)
        Me.chkDiscontinued.Name = "chkDiscontinued"
        Me.chkDiscontinued.RightToLeft = CType(resources.GetObject("chkDiscontinued.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.chkDiscontinued.Size = CType(resources.GetObject("chkDiscontinued.Size"), System.Drawing.Size)
        Me.chkDiscontinued.TabIndex = CType(resources.GetObject("chkDiscontinued.TabIndex"), Integer)
        Me.chkDiscontinued.Text = resources.GetString("chkDiscontinued.Text")
        Me.chkDiscontinued.TextAlign = CType(resources.GetObject("chkDiscontinued.TextAlign"), System.Drawing.ContentAlignment)
        Me.chkDiscontinued.Visible = CType(resources.GetObject("chkDiscontinued.Visible"), Boolean)
        '
        'lstProducts
        '
        Me.lstProducts.AccessibleDescription = resources.GetString("lstProducts.AccessibleDescription")
        Me.lstProducts.AccessibleName = resources.GetString("lstProducts.AccessibleName")
        Me.lstProducts.Anchor = CType(resources.GetObject("lstProducts.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lstProducts.BackgroundImage = CType(resources.GetObject("lstProducts.BackgroundImage"), System.Drawing.Image)
        Me.lstProducts.ColumnWidth = CType(resources.GetObject("lstProducts.ColumnWidth"), Integer)
        Me.lstProducts.Dock = CType(resources.GetObject("lstProducts.Dock"), System.Windows.Forms.DockStyle)
        Me.lstProducts.Enabled = CType(resources.GetObject("lstProducts.Enabled"), Boolean)
        Me.lstProducts.Font = CType(resources.GetObject("lstProducts.Font"), System.Drawing.Font)
        Me.lstProducts.HorizontalExtent = CType(resources.GetObject("lstProducts.HorizontalExtent"), Integer)
        Me.lstProducts.HorizontalScrollbar = CType(resources.GetObject("lstProducts.HorizontalScrollbar"), Boolean)
        Me.lstProducts.ImeMode = CType(resources.GetObject("lstProducts.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lstProducts.IntegralHeight = CType(resources.GetObject("lstProducts.IntegralHeight"), Boolean)
        Me.lstProducts.ItemHeight = CType(resources.GetObject("lstProducts.ItemHeight"), Integer)
        Me.lstProducts.Location = CType(resources.GetObject("lstProducts.Location"), System.Drawing.Point)
        Me.lstProducts.Name = "lstProducts"
        Me.lstProducts.RightToLeft = CType(resources.GetObject("lstProducts.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lstProducts.ScrollAlwaysVisible = CType(resources.GetObject("lstProducts.ScrollAlwaysVisible"), Boolean)
        Me.lstProducts.Size = CType(resources.GetObject("lstProducts.Size"), System.Drawing.Size)
        Me.lstProducts.TabIndex = CType(resources.GetObject("lstProducts.TabIndex"), Integer)
        Me.lstProducts.Visible = CType(resources.GetObject("lstProducts.Visible"), Boolean)
        '
        'lblProductID
        '
        Me.lblProductID.AccessibleDescription = CType(resources.GetObject("lblProductID.AccessibleDescription"), String)
        Me.lblProductID.AccessibleName = CType(resources.GetObject("lblProductID.AccessibleName"), String)
        Me.lblProductID.Anchor = CType(resources.GetObject("lblProductID.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblProductID.AutoSize = CType(resources.GetObject("lblProductID.AutoSize"), Boolean)
        Me.lblProductID.Dock = CType(resources.GetObject("lblProductID.Dock"), System.Windows.Forms.DockStyle)
        Me.lblProductID.Enabled = CType(resources.GetObject("lblProductID.Enabled"), Boolean)
        Me.lblProductID.Font = CType(resources.GetObject("lblProductID.Font"), System.Drawing.Font)
        Me.lblProductID.Image = CType(resources.GetObject("lblProductID.Image"), System.Drawing.Image)
        Me.lblProductID.ImageAlign = CType(resources.GetObject("lblProductID.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblProductID.ImageIndex = CType(resources.GetObject("lblProductID.ImageIndex"), Integer)
        Me.lblProductID.ImeMode = CType(resources.GetObject("lblProductID.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblProductID.Location = CType(resources.GetObject("lblProductID.Location"), System.Drawing.Point)
        Me.lblProductID.Name = "lblProductID"
        Me.lblProductID.RightToLeft = CType(resources.GetObject("lblProductID.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblProductID.Size = CType(resources.GetObject("lblProductID.Size"), System.Drawing.Size)
        Me.lblProductID.TabIndex = CType(resources.GetObject("lblProductID.TabIndex"), Integer)
        Me.lblProductID.Text = resources.GetString("lblProductID.Text")
        Me.lblProductID.TextAlign = CType(resources.GetObject("lblProductID.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblProductID.Visible = CType(resources.GetObject("lblProductID.Visible"), Boolean)
        '
        'lblProductName
        '
        Me.lblProductName.AccessibleDescription = CType(resources.GetObject("lblProductName.AccessibleDescription"), String)
        Me.lblProductName.AccessibleName = CType(resources.GetObject("lblProductName.AccessibleName"), String)
        Me.lblProductName.Anchor = CType(resources.GetObject("lblProductName.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblProductName.AutoSize = CType(resources.GetObject("lblProductName.AutoSize"), Boolean)
        Me.lblProductName.Dock = CType(resources.GetObject("lblProductName.Dock"), System.Windows.Forms.DockStyle)
        Me.lblProductName.Enabled = CType(resources.GetObject("lblProductName.Enabled"), Boolean)
        Me.lblProductName.Font = CType(resources.GetObject("lblProductName.Font"), System.Drawing.Font)
        Me.lblProductName.Image = CType(resources.GetObject("lblProductName.Image"), System.Drawing.Image)
        Me.lblProductName.ImageAlign = CType(resources.GetObject("lblProductName.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblProductName.ImageIndex = CType(resources.GetObject("lblProductName.ImageIndex"), Integer)
        Me.lblProductName.ImeMode = CType(resources.GetObject("lblProductName.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblProductName.Location = CType(resources.GetObject("lblProductName.Location"), System.Drawing.Point)
        Me.lblProductName.Name = "lblProductName"
        Me.lblProductName.RightToLeft = CType(resources.GetObject("lblProductName.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblProductName.Size = CType(resources.GetObject("lblProductName.Size"), System.Drawing.Size)
        Me.lblProductName.TabIndex = CType(resources.GetObject("lblProductName.TabIndex"), Integer)
        Me.lblProductName.Text = resources.GetString("lblProductName.Text")
        Me.lblProductName.TextAlign = CType(resources.GetObject("lblProductName.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblProductName.Visible = CType(resources.GetObject("lblProductName.Visible"), Boolean)
        '
        'lblSuppliers
        '
        Me.lblSuppliers.AccessibleDescription = CType(resources.GetObject("lblSuppliers.AccessibleDescription"), String)
        Me.lblSuppliers.AccessibleName = CType(resources.GetObject("lblSuppliers.AccessibleName"), String)
        Me.lblSuppliers.Anchor = CType(resources.GetObject("lblSuppliers.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblSuppliers.AutoSize = CType(resources.GetObject("lblSuppliers.AutoSize"), Boolean)
        Me.lblSuppliers.Dock = CType(resources.GetObject("lblSuppliers.Dock"), System.Windows.Forms.DockStyle)
        Me.lblSuppliers.Enabled = CType(resources.GetObject("lblSuppliers.Enabled"), Boolean)
        Me.lblSuppliers.Font = CType(resources.GetObject("lblSuppliers.Font"), System.Drawing.Font)
        Me.lblSuppliers.Image = CType(resources.GetObject("lblSuppliers.Image"), System.Drawing.Image)
        Me.lblSuppliers.ImageAlign = CType(resources.GetObject("lblSuppliers.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblSuppliers.ImageIndex = CType(resources.GetObject("lblSuppliers.ImageIndex"), Integer)
        Me.lblSuppliers.ImeMode = CType(resources.GetObject("lblSuppliers.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblSuppliers.Location = CType(resources.GetObject("lblSuppliers.Location"), System.Drawing.Point)
        Me.lblSuppliers.Name = "lblSuppliers"
        Me.lblSuppliers.RightToLeft = CType(resources.GetObject("lblSuppliers.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblSuppliers.Size = CType(resources.GetObject("lblSuppliers.Size"), System.Drawing.Size)
        Me.lblSuppliers.TabIndex = CType(resources.GetObject("lblSuppliers.TabIndex"), Integer)
        Me.lblSuppliers.Text = resources.GetString("lblSuppliers.Text")
        Me.lblSuppliers.TextAlign = CType(resources.GetObject("lblSuppliers.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblSuppliers.Visible = CType(resources.GetObject("lblSuppliers.Visible"), Boolean)
        '
        'lblCategories
        '
        Me.lblCategories.AccessibleDescription = CType(resources.GetObject("lblCategories.AccessibleDescription"), String)
        Me.lblCategories.AccessibleName = CType(resources.GetObject("lblCategories.AccessibleName"), String)
        Me.lblCategories.Anchor = CType(resources.GetObject("lblCategories.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblCategories.AutoSize = CType(resources.GetObject("lblCategories.AutoSize"), Boolean)
        Me.lblCategories.Dock = CType(resources.GetObject("lblCategories.Dock"), System.Windows.Forms.DockStyle)
        Me.lblCategories.Enabled = CType(resources.GetObject("lblCategories.Enabled"), Boolean)
        Me.lblCategories.Font = CType(resources.GetObject("lblCategories.Font"), System.Drawing.Font)
        Me.lblCategories.Image = CType(resources.GetObject("lblCategories.Image"), System.Drawing.Image)
        Me.lblCategories.ImageAlign = CType(resources.GetObject("lblCategories.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblCategories.ImageIndex = CType(resources.GetObject("lblCategories.ImageIndex"), Integer)
        Me.lblCategories.ImeMode = CType(resources.GetObject("lblCategories.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblCategories.Location = CType(resources.GetObject("lblCategories.Location"), System.Drawing.Point)
        Me.lblCategories.Name = "lblCategories"
        Me.lblCategories.RightToLeft = CType(resources.GetObject("lblCategories.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblCategories.Size = CType(resources.GetObject("lblCategories.Size"), System.Drawing.Size)
        Me.lblCategories.TabIndex = CType(resources.GetObject("lblCategories.TabIndex"), Integer)
        Me.lblCategories.Text = resources.GetString("lblCategories.Text")
        Me.lblCategories.TextAlign = CType(resources.GetObject("lblCategories.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblCategories.Visible = CType(resources.GetObject("lblCategories.Visible"), Boolean)
        '
        'lblUnitPrice
        '
        Me.lblUnitPrice.AccessibleDescription = CType(resources.GetObject("lblUnitPrice.AccessibleDescription"), String)
        Me.lblUnitPrice.AccessibleName = CType(resources.GetObject("lblUnitPrice.AccessibleName"), String)
        Me.lblUnitPrice.Anchor = CType(resources.GetObject("lblUnitPrice.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblUnitPrice.AutoSize = CType(resources.GetObject("lblUnitPrice.AutoSize"), Boolean)
        Me.lblUnitPrice.Dock = CType(resources.GetObject("lblUnitPrice.Dock"), System.Windows.Forms.DockStyle)
        Me.lblUnitPrice.Enabled = CType(resources.GetObject("lblUnitPrice.Enabled"), Boolean)
        Me.lblUnitPrice.Font = CType(resources.GetObject("lblUnitPrice.Font"), System.Drawing.Font)
        Me.lblUnitPrice.Image = CType(resources.GetObject("lblUnitPrice.Image"), System.Drawing.Image)
        Me.lblUnitPrice.ImageAlign = CType(resources.GetObject("lblUnitPrice.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblUnitPrice.ImageIndex = CType(resources.GetObject("lblUnitPrice.ImageIndex"), Integer)
        Me.lblUnitPrice.ImeMode = CType(resources.GetObject("lblUnitPrice.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblUnitPrice.Location = CType(resources.GetObject("lblUnitPrice.Location"), System.Drawing.Point)
        Me.lblUnitPrice.Name = "lblUnitPrice"
        Me.lblUnitPrice.RightToLeft = CType(resources.GetObject("lblUnitPrice.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblUnitPrice.Size = CType(resources.GetObject("lblUnitPrice.Size"), System.Drawing.Size)
        Me.lblUnitPrice.TabIndex = CType(resources.GetObject("lblUnitPrice.TabIndex"), Integer)
        Me.lblUnitPrice.Tag = ""
        Me.lblUnitPrice.Text = resources.GetString("lblUnitPrice.Text")
        Me.lblUnitPrice.TextAlign = CType(resources.GetObject("lblUnitPrice.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblUnitPrice.Visible = CType(resources.GetObject("lblUnitPrice.Visible"), Boolean)
        '
        'lblUnitsInStock
        '
        Me.lblUnitsInStock.AccessibleDescription = CType(resources.GetObject("lblUnitsInStock.AccessibleDescription"), String)
        Me.lblUnitsInStock.AccessibleName = CType(resources.GetObject("lblUnitsInStock.AccessibleName"), String)
        Me.lblUnitsInStock.Anchor = CType(resources.GetObject("lblUnitsInStock.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblUnitsInStock.AutoSize = CType(resources.GetObject("lblUnitsInStock.AutoSize"), Boolean)
        Me.lblUnitsInStock.Dock = CType(resources.GetObject("lblUnitsInStock.Dock"), System.Windows.Forms.DockStyle)
        Me.lblUnitsInStock.Enabled = CType(resources.GetObject("lblUnitsInStock.Enabled"), Boolean)
        Me.lblUnitsInStock.Font = CType(resources.GetObject("lblUnitsInStock.Font"), System.Drawing.Font)
        Me.lblUnitsInStock.Image = CType(resources.GetObject("lblUnitsInStock.Image"), System.Drawing.Image)
        Me.lblUnitsInStock.ImageAlign = CType(resources.GetObject("lblUnitsInStock.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblUnitsInStock.ImageIndex = CType(resources.GetObject("lblUnitsInStock.ImageIndex"), Integer)
        Me.lblUnitsInStock.ImeMode = CType(resources.GetObject("lblUnitsInStock.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblUnitsInStock.Location = CType(resources.GetObject("lblUnitsInStock.Location"), System.Drawing.Point)
        Me.lblUnitsInStock.Name = "lblUnitsInStock"
        Me.lblUnitsInStock.RightToLeft = CType(resources.GetObject("lblUnitsInStock.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblUnitsInStock.Size = CType(resources.GetObject("lblUnitsInStock.Size"), System.Drawing.Size)
        Me.lblUnitsInStock.TabIndex = CType(resources.GetObject("lblUnitsInStock.TabIndex"), Integer)
        Me.lblUnitsInStock.Text = resources.GetString("lblUnitsInStock.Text")
        Me.lblUnitsInStock.TextAlign = CType(resources.GetObject("lblUnitsInStock.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblUnitsInStock.Visible = CType(resources.GetObject("lblUnitsInStock.Visible"), Boolean)
        '
        'lblUnitsOnOrder
        '
        Me.lblUnitsOnOrder.AccessibleDescription = CType(resources.GetObject("lblUnitsOnOrder.AccessibleDescription"), String)
        Me.lblUnitsOnOrder.AccessibleName = CType(resources.GetObject("lblUnitsOnOrder.AccessibleName"), String)
        Me.lblUnitsOnOrder.Anchor = CType(resources.GetObject("lblUnitsOnOrder.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblUnitsOnOrder.AutoSize = CType(resources.GetObject("lblUnitsOnOrder.AutoSize"), Boolean)
        Me.lblUnitsOnOrder.Dock = CType(resources.GetObject("lblUnitsOnOrder.Dock"), System.Windows.Forms.DockStyle)
        Me.lblUnitsOnOrder.Enabled = CType(resources.GetObject("lblUnitsOnOrder.Enabled"), Boolean)
        Me.lblUnitsOnOrder.Font = CType(resources.GetObject("lblUnitsOnOrder.Font"), System.Drawing.Font)
        Me.lblUnitsOnOrder.Image = CType(resources.GetObject("lblUnitsOnOrder.Image"), System.Drawing.Image)
        Me.lblUnitsOnOrder.ImageAlign = CType(resources.GetObject("lblUnitsOnOrder.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblUnitsOnOrder.ImageIndex = CType(resources.GetObject("lblUnitsOnOrder.ImageIndex"), Integer)
        Me.lblUnitsOnOrder.ImeMode = CType(resources.GetObject("lblUnitsOnOrder.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblUnitsOnOrder.Location = CType(resources.GetObject("lblUnitsOnOrder.Location"), System.Drawing.Point)
        Me.lblUnitsOnOrder.Name = "lblUnitsOnOrder"
        Me.lblUnitsOnOrder.RightToLeft = CType(resources.GetObject("lblUnitsOnOrder.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblUnitsOnOrder.Size = CType(resources.GetObject("lblUnitsOnOrder.Size"), System.Drawing.Size)
        Me.lblUnitsOnOrder.TabIndex = CType(resources.GetObject("lblUnitsOnOrder.TabIndex"), Integer)
        Me.lblUnitsOnOrder.Text = resources.GetString("lblUnitsOnOrder.Text")
        Me.lblUnitsOnOrder.TextAlign = CType(resources.GetObject("lblUnitsOnOrder.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblUnitsOnOrder.Visible = CType(resources.GetObject("lblUnitsOnOrder.Visible"), Boolean)
        '
        'lblReorderLevel
        '
        Me.lblReorderLevel.AccessibleDescription = CType(resources.GetObject("lblReorderLevel.AccessibleDescription"), String)
        Me.lblReorderLevel.AccessibleName = CType(resources.GetObject("lblReorderLevel.AccessibleName"), String)
        Me.lblReorderLevel.Anchor = CType(resources.GetObject("lblReorderLevel.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblReorderLevel.AutoSize = CType(resources.GetObject("lblReorderLevel.AutoSize"), Boolean)
        Me.lblReorderLevel.Dock = CType(resources.GetObject("lblReorderLevel.Dock"), System.Windows.Forms.DockStyle)
        Me.lblReorderLevel.Enabled = CType(resources.GetObject("lblReorderLevel.Enabled"), Boolean)
        Me.lblReorderLevel.Font = CType(resources.GetObject("lblReorderLevel.Font"), System.Drawing.Font)
        Me.lblReorderLevel.Image = CType(resources.GetObject("lblReorderLevel.Image"), System.Drawing.Image)
        Me.lblReorderLevel.ImageAlign = CType(resources.GetObject("lblReorderLevel.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblReorderLevel.ImageIndex = CType(resources.GetObject("lblReorderLevel.ImageIndex"), Integer)
        Me.lblReorderLevel.ImeMode = CType(resources.GetObject("lblReorderLevel.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblReorderLevel.Location = CType(resources.GetObject("lblReorderLevel.Location"), System.Drawing.Point)
        Me.lblReorderLevel.Name = "lblReorderLevel"
        Me.lblReorderLevel.RightToLeft = CType(resources.GetObject("lblReorderLevel.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblReorderLevel.Size = CType(resources.GetObject("lblReorderLevel.Size"), System.Drawing.Size)
        Me.lblReorderLevel.TabIndex = CType(resources.GetObject("lblReorderLevel.TabIndex"), Integer)
        Me.lblReorderLevel.Text = resources.GetString("lblReorderLevel.Text")
        Me.lblReorderLevel.TextAlign = CType(resources.GetObject("lblReorderLevel.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblReorderLevel.Visible = CType(resources.GetObject("lblReorderLevel.Visible"), Boolean)
        '
        'lblQtyPerUnit
        '
        Me.lblQtyPerUnit.AccessibleDescription = CType(resources.GetObject("lblQtyPerUnit.AccessibleDescription"), String)
        Me.lblQtyPerUnit.AccessibleName = CType(resources.GetObject("lblQtyPerUnit.AccessibleName"), String)
        Me.lblQtyPerUnit.Anchor = CType(resources.GetObject("lblQtyPerUnit.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblQtyPerUnit.AutoSize = CType(resources.GetObject("lblQtyPerUnit.AutoSize"), Boolean)
        Me.lblQtyPerUnit.Dock = CType(resources.GetObject("lblQtyPerUnit.Dock"), System.Windows.Forms.DockStyle)
        Me.lblQtyPerUnit.Enabled = CType(resources.GetObject("lblQtyPerUnit.Enabled"), Boolean)
        Me.lblQtyPerUnit.Font = CType(resources.GetObject("lblQtyPerUnit.Font"), System.Drawing.Font)
        Me.lblQtyPerUnit.Image = CType(resources.GetObject("lblQtyPerUnit.Image"), System.Drawing.Image)
        Me.lblQtyPerUnit.ImageAlign = CType(resources.GetObject("lblQtyPerUnit.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblQtyPerUnit.ImageIndex = CType(resources.GetObject("lblQtyPerUnit.ImageIndex"), Integer)
        Me.lblQtyPerUnit.ImeMode = CType(resources.GetObject("lblQtyPerUnit.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblQtyPerUnit.Location = CType(resources.GetObject("lblQtyPerUnit.Location"), System.Drawing.Point)
        Me.lblQtyPerUnit.Name = "lblQtyPerUnit"
        Me.lblQtyPerUnit.RightToLeft = CType(resources.GetObject("lblQtyPerUnit.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblQtyPerUnit.Size = CType(resources.GetObject("lblQtyPerUnit.Size"), System.Drawing.Size)
        Me.lblQtyPerUnit.TabIndex = CType(resources.GetObject("lblQtyPerUnit.TabIndex"), Integer)
        Me.lblQtyPerUnit.Text = resources.GetString("lblQtyPerUnit.Text")
        Me.lblQtyPerUnit.TextAlign = CType(resources.GetObject("lblQtyPerUnit.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblQtyPerUnit.Visible = CType(resources.GetObject("lblQtyPerUnit.Visible"), Boolean)
        '
        'gbHorvRule
        '
        Me.gbHorvRule.AccessibleDescription = CType(resources.GetObject("gbHorvRule.AccessibleDescription"), String)
        Me.gbHorvRule.AccessibleName = CType(resources.GetObject("gbHorvRule.AccessibleName"), String)
        Me.gbHorvRule.Anchor = CType(resources.GetObject("gbHorvRule.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.gbHorvRule.BackgroundImage = CType(resources.GetObject("gbHorvRule.BackgroundImage"), System.Drawing.Image)
        Me.gbHorvRule.Dock = CType(resources.GetObject("gbHorvRule.Dock"), System.Windows.Forms.DockStyle)
        Me.gbHorvRule.Enabled = CType(resources.GetObject("gbHorvRule.Enabled"), Boolean)
        Me.gbHorvRule.Font = CType(resources.GetObject("gbHorvRule.Font"), System.Drawing.Font)
        Me.gbHorvRule.ImeMode = CType(resources.GetObject("gbHorvRule.ImeMode"), System.Windows.Forms.ImeMode)
        Me.gbHorvRule.Location = CType(resources.GetObject("gbHorvRule.Location"), System.Drawing.Point)
        Me.gbHorvRule.Name = "gbHorvRule"
        Me.gbHorvRule.RightToLeft = CType(resources.GetObject("gbHorvRule.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.gbHorvRule.Size = CType(resources.GetObject("gbHorvRule.Size"), System.Drawing.Size)
        Me.gbHorvRule.TabIndex = CType(resources.GetObject("gbHorvRule.TabIndex"), Integer)
        Me.gbHorvRule.TabStop = False
        Me.gbHorvRule.Text = resources.GetString("gbHorvRule.Text")
        Me.gbHorvRule.Visible = CType(resources.GetObject("gbHorvRule.Visible"), Boolean)
        '
        'btnAdd
        '
        Me.btnAdd.AccessibleDescription = resources.GetString("btnAdd.AccessibleDescription")
        Me.btnAdd.AccessibleName = resources.GetString("btnAdd.AccessibleName")
        Me.btnAdd.Anchor = CType(resources.GetObject("btnAdd.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.BackgroundImage = CType(resources.GetObject("btnAdd.BackgroundImage"), System.Drawing.Image)
        Me.btnAdd.Dock = CType(resources.GetObject("btnAdd.Dock"), System.Windows.Forms.DockStyle)
        Me.btnAdd.Enabled = CType(resources.GetObject("btnAdd.Enabled"), Boolean)
        Me.btnAdd.FlatStyle = CType(resources.GetObject("btnAdd.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnAdd.Font = CType(resources.GetObject("btnAdd.Font"), System.Drawing.Font)
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.ImageAlign = CType(resources.GetObject("btnAdd.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnAdd.ImageIndex = CType(resources.GetObject("btnAdd.ImageIndex"), Integer)
        Me.btnAdd.ImeMode = CType(resources.GetObject("btnAdd.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnAdd.Location = CType(resources.GetObject("btnAdd.Location"), System.Drawing.Point)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.RightToLeft = CType(resources.GetObject("btnAdd.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnAdd.Size = CType(resources.GetObject("btnAdd.Size"), System.Drawing.Size)
        Me.btnAdd.TabIndex = CType(resources.GetObject("btnAdd.TabIndex"), Integer)
        Me.btnAdd.Text = resources.GetString("btnAdd.Text")
        Me.btnAdd.TextAlign = CType(resources.GetObject("btnAdd.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnAdd.Visible = CType(resources.GetObject("btnAdd.Visible"), Boolean)
        '
        'btnUpdate
        '
        Me.btnUpdate.AccessibleDescription = resources.GetString("btnUpdate.AccessibleDescription")
        Me.btnUpdate.AccessibleName = resources.GetString("btnUpdate.AccessibleName")
        Me.btnUpdate.Anchor = CType(resources.GetObject("btnUpdate.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnUpdate.BackgroundImage = CType(resources.GetObject("btnUpdate.BackgroundImage"), System.Drawing.Image)
        Me.btnUpdate.Dock = CType(resources.GetObject("btnUpdate.Dock"), System.Windows.Forms.DockStyle)
        Me.btnUpdate.Enabled = CType(resources.GetObject("btnUpdate.Enabled"), Boolean)
        Me.btnUpdate.FlatStyle = CType(resources.GetObject("btnUpdate.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnUpdate.Font = CType(resources.GetObject("btnUpdate.Font"), System.Drawing.Font)
        Me.btnUpdate.Image = CType(resources.GetObject("btnUpdate.Image"), System.Drawing.Image)
        Me.btnUpdate.ImageAlign = CType(resources.GetObject("btnUpdate.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnUpdate.ImageIndex = CType(resources.GetObject("btnUpdate.ImageIndex"), Integer)
        Me.btnUpdate.ImeMode = CType(resources.GetObject("btnUpdate.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnUpdate.Location = CType(resources.GetObject("btnUpdate.Location"), System.Drawing.Point)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.RightToLeft = CType(resources.GetObject("btnUpdate.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnUpdate.Size = CType(resources.GetObject("btnUpdate.Size"), System.Drawing.Size)
        Me.btnUpdate.TabIndex = CType(resources.GetObject("btnUpdate.TabIndex"), Integer)
        Me.btnUpdate.Text = resources.GetString("btnUpdate.Text")
        Me.btnUpdate.TextAlign = CType(resources.GetObject("btnUpdate.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnUpdate.Visible = CType(resources.GetObject("btnUpdate.Visible"), Boolean)
        '
        'btnDelete
        '
        Me.btnDelete.AccessibleDescription = resources.GetString("btnDelete.AccessibleDescription")
        Me.btnDelete.AccessibleName = resources.GetString("btnDelete.AccessibleName")
        Me.btnDelete.Anchor = CType(resources.GetObject("btnDelete.Anchor"), System.Windows.Forms.AnchorStyles)
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
        'lblProductList
        '
        Me.lblProductList.AccessibleDescription = CType(resources.GetObject("lblProductList.AccessibleDescription"), String)
        Me.lblProductList.AccessibleName = CType(resources.GetObject("lblProductList.AccessibleName"), String)
        Me.lblProductList.Anchor = CType(resources.GetObject("lblProductList.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblProductList.AutoSize = CType(resources.GetObject("lblProductList.AutoSize"), Boolean)
        Me.lblProductList.Dock = CType(resources.GetObject("lblProductList.Dock"), System.Windows.Forms.DockStyle)
        Me.lblProductList.Enabled = CType(resources.GetObject("lblProductList.Enabled"), Boolean)
        Me.lblProductList.Font = CType(resources.GetObject("lblProductList.Font"), System.Drawing.Font)
        Me.lblProductList.Image = CType(resources.GetObject("lblProductList.Image"), System.Drawing.Image)
        Me.lblProductList.ImageAlign = CType(resources.GetObject("lblProductList.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblProductList.ImageIndex = CType(resources.GetObject("lblProductList.ImageIndex"), Integer)
        Me.lblProductList.ImeMode = CType(resources.GetObject("lblProductList.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblProductList.Location = CType(resources.GetObject("lblProductList.Location"), System.Drawing.Point)
        Me.lblProductList.Name = "lblProductList"
        Me.lblProductList.RightToLeft = CType(resources.GetObject("lblProductList.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblProductList.Size = CType(resources.GetObject("lblProductList.Size"), System.Drawing.Size)
        Me.lblProductList.TabIndex = CType(resources.GetObject("lblProductList.TabIndex"), Integer)
        Me.lblProductList.Text = resources.GetString("lblProductList.Text")
        Me.lblProductList.TextAlign = CType(resources.GetObject("lblProductList.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblProductList.Visible = CType(resources.GetObject("lblProductList.Visible"), Boolean)
        '
        'mnuMain
        '
        Me.mnuMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1, Me.MenuItem4})
        Me.mnuMain.RightToLeft = CType(resources.GetObject("mnuMain.RightToLeft"), System.Windows.Forms.RightToLeft)
        '
        'MenuItem1
        '
        Me.MenuItem1.Enabled = CType(resources.GetObject("MenuItem1.Enabled"), Boolean)
        Me.MenuItem1.Index = 0
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuExit})
        Me.MenuItem1.Shortcut = CType(resources.GetObject("MenuItem1.Shortcut"), System.Windows.Forms.Shortcut)
        Me.MenuItem1.ShowShortcut = CType(resources.GetObject("MenuItem1.ShowShortcut"), Boolean)
        Me.MenuItem1.Text = resources.GetString("MenuItem1.Text")
        Me.MenuItem1.Visible = CType(resources.GetObject("MenuItem1.Visible"), Boolean)
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
        'MenuItem4
        '
        Me.MenuItem4.Enabled = CType(resources.GetObject("MenuItem4.Enabled"), Boolean)
        Me.MenuItem4.Index = 1
        Me.MenuItem4.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAbout})
        Me.MenuItem4.Shortcut = CType(resources.GetObject("MenuItem4.Shortcut"), System.Windows.Forms.Shortcut)
        Me.MenuItem4.ShowShortcut = CType(resources.GetObject("MenuItem4.ShowShortcut"), Boolean)
        Me.MenuItem4.Text = resources.GetString("MenuItem4.Text")
        Me.MenuItem4.Visible = CType(resources.GetObject("MenuItem4.Visible"), Boolean)
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
        'btnRefresh
        '
        Me.btnRefresh.AccessibleDescription = resources.GetString("btnRefresh.AccessibleDescription")
        Me.btnRefresh.AccessibleName = resources.GetString("btnRefresh.AccessibleName")
        Me.btnRefresh.Anchor = CType(resources.GetObject("btnRefresh.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.BackgroundImage = CType(resources.GetObject("btnRefresh.BackgroundImage"), System.Drawing.Image)
        Me.btnRefresh.Dock = CType(resources.GetObject("btnRefresh.Dock"), System.Windows.Forms.DockStyle)
        Me.btnRefresh.Enabled = CType(resources.GetObject("btnRefresh.Enabled"), Boolean)
        Me.btnRefresh.FlatStyle = CType(resources.GetObject("btnRefresh.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnRefresh.Font = CType(resources.GetObject("btnRefresh.Font"), System.Drawing.Font)
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.ImageAlign = CType(resources.GetObject("btnRefresh.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnRefresh.ImageIndex = CType(resources.GetObject("btnRefresh.ImageIndex"), Integer)
        Me.btnRefresh.ImeMode = CType(resources.GetObject("btnRefresh.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnRefresh.Location = CType(resources.GetObject("btnRefresh.Location"), System.Drawing.Point)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.RightToLeft = CType(resources.GetObject("btnRefresh.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnRefresh.Size = CType(resources.GetObject("btnRefresh.Size"), System.Drawing.Size)
        Me.btnRefresh.TabIndex = CType(resources.GetObject("btnRefresh.TabIndex"), Integer)
        Me.btnRefresh.Text = resources.GetString("btnRefresh.Text")
        Me.btnRefresh.TextAlign = CType(resources.GetObject("btnRefresh.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnRefresh.Visible = CType(resources.GetObject("btnRefresh.Visible"), Boolean)
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
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRefresh, Me.lblProductList, Me.btnDelete, Me.btnUpdate, Me.btnAdd, Me.gbHorvRule, Me.lblQtyPerUnit, Me.lblReorderLevel, Me.lblUnitsOnOrder, Me.lblUnitsInStock, Me.lblUnitPrice, Me.lblCategories, Me.lblSuppliers, Me.lblProductName, Me.lblProductID, Me.lstProducts, Me.chkDiscontinued, Me.cbCategories, Me.cbSuppliers, Me.txtQtyPerUnit, Me.txtReorderLevel, Me.txtUnitsInStock, Me.txtUnitsOnOrder, Me.txtUnitPrice, Me.txtProductName, Me.txtProductID})
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

    <System.Diagnostics.DebuggerStepThroughAttribute()> Private Sub mnuAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAbout.Click
        ' Open the About form in Dialog Mode
        Dim frm As New frmAbout()
        frm.ShowDialog(Me)
        frm.Dispose()
    End Sub

    ' This code will close the form.
    <System.Diagnostics.DebuggerStepThroughAttribute()> Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
        ' Close the current form
        Me.Close()
    End Sub

#End Region

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        ClearForm()
        Mode = "Add"

        btnDelete.Enabled = False
        btnAdd.Enabled = False
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        DeleteProduct()
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        ' Check mode to determine action
        If Mode = "Add" Then
            AddProduct()
        Else
            UpdateProduct()
        End If

    End Sub

    Private Sub frmDataEntry_Load(ByVal sender As System.Object, _
                                  ByVal e As System.EventArgs) _
                                  Handles MyBase.Load
        ' Populate all the list and combo boxes used on the form
        PopulateCategoryCombo()
        PopulateSupplierCombo()
        PopulateProductList()

    End Sub

    Private Sub lstProducts_SelectedIndexChanged(ByVal sender As System.Object, _
                                                 ByVal e As System.EventArgs) _
                                                 Handles lstProducts.SelectedIndexChanged
        PopulateForm()
        btnDelete.Enabled = True
        btnAdd.Enabled = True
        Mode = "Update"

    End Sub

    Private Sub AddProduct()
        ' This sub is used to add a product record to the database
        ' when the user clicks the Update button and the mode is set
        ' to ADD

        ' Validate form values.
        If Not IsValidForm() Then
            Exit Sub
        End If

        Dim cnSQL As SqlConnection
        Dim cmSQL As SqlCommand
        Dim strSQL As String
        Dim intRowsAffected As Integer
        Dim ProductName As String = txtProductName.Text

        Try
            ' Build Insert statement to insert new product into the products table
            strSQL = "INSERT Products VALUES (" & _
                     PrepareStr(ProductName) & "," & _
                     CType(cbSuppliers.Items(cbSuppliers.SelectedIndex), ListItem).ID & "," & _
                     CType(cbCategories.Items(cbCategories.SelectedIndex), ListItem).ID & "," & _
                     PrepareStr(txtQtyPerUnit.Text) & "," & _
                     txtUnitPrice.Text & "," & _
                     txtUnitsInStock.Text & "," & _
                     txtUnitsOnOrder.Text & "," & _
                     txtReorderLevel.Text & "," & _
                     CType(IIf(chkDiscontinued.Checked, "1", "0"), String) & ")"


            cnSQL = New SqlConnection(ConnectionString)
            cnSQL.Open()

            cmSQL = New SqlCommand(strSQL, cnSQL)
            cmSQL.ExecuteNonQuery()

            ' Close and Clean up objects
            cnSQL.Close()
            cmSQL.Dispose()
            cnSQL.Dispose()

            ' Refresh Product List
            PopulateProductList()
            FindProductByName(lstProducts, ProductName)

        Catch Exp As SqlException
            MsgBox(Exp.Message, MsgBoxStyle.Critical, "SQL Error")

        Catch Exp As Exception
            MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")
        End Try
    End Sub

    Private Sub ClearForm()

        ' Clear the data entry form.
        txtProductID.Text = ""
        txtProductName.Text = ""
        txtQtyPerUnit.Text = ""
        txtUnitPrice.Text = "0.00"
        txtUnitsInStock.Text = "0"
        txtUnitsOnOrder.Text = "0"
        txtReorderLevel.Text = "0"
        chkDiscontinued.Checked = False
        cbSuppliers.SelectedIndex = -1
        cbCategories.SelectedIndex = -1

    End Sub

    Private Sub DeleteProduct()
        ' This sub is used to delete the product record from the database
        ' when the user clicks the delete button

        Dim cnSQL As SqlConnection
        Dim cmSQL As SqlCommand
        Dim strSQL As String
        Dim intRowsAffected As Integer

        Try
            ' Build Delete statement to delete the current product from table
            strSQL = "DELETE FROM Products " & _
                     "WHERE ProductID = " & CInt(txtProductID.Text)

            cnSQL = New SqlConnection(ConnectionString)
            cnSQL.Open()

            cmSQL = New SqlCommand(strSQL, cnSQL)
            intRowsAffected = cmSQL.ExecuteNonQuery()

            If intRowsAffected <> 1 Then
                MsgBox("Delete Failed. Product ID " & txtProductID.Text & _
                       " not found.", MsgBoxStyle.Critical, "Delete")
            End If

            ' Close and Clean up objects
            cnSQL.Close()
            cmSQL.Dispose()
            cnSQL.Dispose()

            PopulateProductList()

        Catch e As SqlException
            MsgBox(e.Message, MsgBoxStyle.Critical, "SQL Error")

        Catch e As Exception
            MsgBox(e.Message, MsgBoxStyle.Critical, "General Error")
        End Try
    End Sub

    Private Sub FindItemByID(ByVal cbCombo As ComboBox, ByVal strID As String)
        ' This sub is used to find an Item in a combobox and
        ' set the selected index of the combo box to that item
        Dim bFound As Boolean
        Dim ListItem As ListItem
        Dim ItemCount As Integer

        ListItem = New ListItem()

        ItemCount = 0
        While Not bFound Or ItemCount <= cbCombo.Items.Count - 1
            ListItem = CType(cbCombo.Items(ItemCount), ListItem)

            If ListItem.ID = CInt(strID) Then
                cbCombo.SelectedIndex = ItemCount
                bFound = True
            End If
            ItemCount += 1
        End While

        If Not bFound Then
            cbCombo.SelectedIndex = -1
        End If

    End Sub

    Private Sub FindProductByName(ByVal lbList As ListBox, ByVal strValue As String)
        ' This sub is used to find a Product in the product
        ' list box and set the selected index of the list box
        ' to that item

        Dim bIsFound As Boolean
        Dim ListItem As ListItem
        Dim ItemCount As Integer

        ListItem = New ListItem()

        ItemCount = 0
        ' Loop through the list until the item is found
        While Not bIsFound And ItemCount <= lbList.Items.Count - 1
            ListItem = CType(lbList.Items(ItemCount), ListItem)

            If ListItem.Value = strValue Then
                lbList.SelectedIndex = ItemCount
                bIsFound = True
            End If
            ItemCount += 1
        End While

        If Not bIsFound Then
            lbList.SelectedIndex = 0
        End If

    End Sub

    Private Function IsValidForm() As Boolean
        ' Check to make sure each field has a valid value
        If txtProductName.Text = "" Or _
           txtQtyPerUnit.Text = "" Or _
           txtUnitPrice.Text = "" Or _
           txtUnitsInStock.Text = "" Or _
           txtUnitsOnOrder.Text = "" Or _
           txtReorderLevel.Text = "" Or _
           cbCategories.SelectedIndex = -1 Or _
           cbSuppliers.SelectedIndex = -1 Or _
           Not IsNumeric(txtUnitPrice.Text) Or _
           Not IsNumeric(txtUnitsInStock.Text) Or _
           Not IsNumeric(txtUnitsOnOrder.Text) Or _
           Not IsNumeric(txtReorderLevel.Text) Then

            MsgBox("Please enter a valid value for each field.", _
                    MsgBoxStyle.Exclamation, Me.Text)
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub PopulateCategoryCombo()
        ' This procedure populates the list box on the
        ' form with a list of Categories from the
        ' Northwind database.

        Dim cnSQL As SqlConnection
        Dim cmSQL As SqlCommand
        Dim drSQL As SqlDataReader
        Dim strSQL As String
        Dim objListItem As ListItem

        ' Display a status message box saying that we are attempting to connect.
        ' This only needs to be done the first time a connection is attempted.
        ' After we have determined that MSDE or SQL Server is installed, this 
        ' message no longer needs to be displayed
        Dim frmStatusMessage As New frmStatus()
        If Not HasConnected Then
            frmStatusMessage.Show("Connecting to MSDE")
        End If

        ' Attempt to connect to SQL server or MSDE
        Dim IsConnecting As Boolean = True
        While IsConnecting
            Try
                ' Build Select statement to query Category Name from the Categories
                ' table.
                strSQL = "SELECT CategoryID, CategoryName FROM Categories"

                cnSQL = New SqlConnection(ConnectionString)
                cnSQL.Open()

                cmSQL = New SqlCommand(strSQL, cnSQL)
                drSQL = cmSQL.ExecuteReader()

                cbCategories.Items.Clear()

                ' Loop through the result set and add the category 
                ' names to the combo box.
                Do While drSQL.Read()
                    objListItem = New ListItem(drSQL.Item("CategoryName").ToString(), _
                                               CInt(drSQL.Item("CategoryID")))
                    cbCategories.Items.Add(objListItem)
                Loop

                IsConnecting = False
                HasConnected = True

                ' Close and Clean up objects
                drSQL.Close()
                cnSQL.Close()
                cmSQL.Dispose()
                cnSQL.Dispose()

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
            frmStatusMessage.Close()
        End While
    End Sub

    Private Sub PopulateForm()
        Dim cnSQL As SqlConnection
        Dim cmSQL As SqlCommand
        Dim drSQL As SqlDataReader
        Dim strSQL As String
        Dim objListItem As ListItem
        Dim strID As String

        Try

            ' Get Primary Key from Listbox
            objListItem = CType(lstProducts.SelectedItem, ListItem)

            ' Build Select statement to query product information from the products
            ' table 
            strSQL = "SELECT ProductID, " & _
                     "       ProductName, " & _
                     "       QuantityPerUnit, " & _
                     "       UnitPrice, " & _
                     "       UnitsInStock, " & _
                     "       UnitsOnOrder, " & _
                     "       ReorderLevel, " & _
                     "       Discontinued, " & _
                     "       SupplierID, " & _
                     "       CategoryID " & _
                     "FROM Products " & _
                     "WHERE ProductID = " & objListItem.ID

            cnSQL = New SqlConnection(ConnectionString)
            cnSQL.Open()

            cmSQL = New SqlCommand(strSQL, cnSQL)
            drSQL = cmSQL.ExecuteReader()

            If drSQL.Read() Then
                ' Populate form with the data
                txtProductID.Text = drSQL.Item("ProductID").ToString()
                txtProductName.Text() = drSQL.Item("ProductName").ToString()
                txtQtyPerUnit.Text() = drSQL.Item("QuantityPerUnit").ToString()
                txtUnitPrice.Text() = drSQL.Item("UnitPrice").ToString()
                txtUnitsInStock.Text() = drSQL.Item("UnitsInStock").ToString()
                txtUnitsOnOrder.Text() = drSQL.Item("UnitsOnOrder").ToString()
                txtReorderLevel.Text() = drSQL.Item("ReorderLevel").ToString()
                chkDiscontinued.Checked = CType(drSQL.Item("Discontinued"), Boolean)
                strID = drSQL.Item("SupplierID").ToString()
                FindItemByID(cbSuppliers, strID)
                strID = drSQL.Item("CategoryID").ToString()
                FindItemByID(cbCategories, strID)
            End If

            ' Close and Clean up objects
            drSQL.Close()
            cnSQL.Close()
            cmSQL.Dispose()
            cnSQL.Dispose()

        Catch e As SqlException
            MsgBox(e.Message, MsgBoxStyle.Critical, "SQL Error")

        Catch e As Exception
            MsgBox(e.Message, MsgBoxStyle.Critical, "General Error")
        End Try
    End Sub

    Private Sub PopulateProductList()
        ' This procedure populates the list box on the
        ' form with a list of available products from the
        ' Northwind database.

        Dim cnSQL As SqlConnection
        Dim cmSQL As SqlCommand
        Dim drSQL As SqlDataReader
        Dim strSQL As String
        Dim objListItem As ListItem

        Try
            ' Build Select statement to query product names from the products
            ' table.
            strSQL = "SELECT ProductName, ProductID FROM Products"

            cnSQL = New SqlConnection(ConnectionString)
            cnSQL.Open()

            cmSQL = New SqlCommand(strSQL, cnSQL)
            drSQL = cmSQL.ExecuteReader()

            lstProducts.Items.Clear()

            ' Loop through the result set using the datareader class.  
            ' The datareader is used here because all that is needed 
            ' is a forward only cursor which is more efficient.             
            Do While drSQL.Read()
                objListItem = New ListItem(drSQL.Item("ProductName").ToString(), _
                                           CInt(drSQL.Item("ProductID")))
                lstProducts.Items.Add(objListItem)
            Loop

            If lstProducts.Items.Count > 0 Then
                lstProducts.SetSelected(0, True)
            End If

            ' Close and Clean up objects
            drSQL.Close()
            cnSQL.Close()
            cmSQL.Dispose()
            cnSQL.Dispose()

        Catch e As SqlException
            MsgBox(e.Message, MsgBoxStyle.Critical, "SQL Error")

        Catch e As Exception
            MsgBox(e.Message, MsgBoxStyle.Critical, "General Error")
        End Try
    End Sub

    Private Sub PopulateSupplierCombo()
        ' This procedure populates the supplier combo box
        ' on the form with a list of available Suppliers 
        ' from the Northwind database.

        Dim cnSQL As SqlConnection
        Dim cmSQL As SqlCommand
        Dim drSQL As SqlDataReader
        Dim strSQL As String
        Dim objListItem As ListItem

        Try
            ' Build Select statement to query Suppliers Name from the Suppliers
            ' table.
            strSQL = "SELECT SupplierID, CompanyName FROM Suppliers"

            cnSQL = New SqlConnection(ConnectionString)
            cnSQL.Open()

            cmSQL = New SqlCommand(strSQL, cnSQL)
            drSQL = cmSQL.ExecuteReader()

            cbSuppliers.Items.Clear()

            ' Loop through the result set and add the supplier names to the combo
            ' box.
            Do While drSQL.Read()
                objListItem = New ListItem(drSQL.Item("CompanyName").ToString(), _
                                           CInt(drSQL.Item("SupplierID")))
                cbSuppliers.Items.Add(objListItem)
            Loop

            ' Close and Clean up objects
            drSQL.Close()
            cnSQL.Close()
            cmSQL.Dispose()
            cnSQL.Dispose()

        Catch e As SqlException
            MsgBox(e.Message, MsgBoxStyle.Critical, "SQL Error")

        Catch e As Exception
            MsgBox(e.Message, MsgBoxStyle.Critical, "General Error")
        End Try
    End Sub

    Private Function PrepareStr(ByVal strValue As String) As String
        ' This function accepts a string and creates a string that can
        ' be used in a SQL statement by adding single quotes around
        ' it and handling empty values.
        If strValue.Trim() = "" Then
            Return "NULL"
        Else
            Return "'" & strValue.Trim() & "'"
        End If
    End Function

    Private Sub UpdateProduct()
        ' This sub is used to update and existing record with values
        ' from the form.
        Dim cnSQL As SqlConnection
        Dim cmSQL As SqlCommand
        Dim strSQL As String
        Dim intRowsAffected As Integer

        ' Validate form values.
        If Not IsValidForm() Then
            Exit Sub
        End If

        Try
            ' Build update statement to update product table with data
            ' on form.
            strSQL = "UPDATE Products SET" & _
                     " ProductName = " & PrepareStr(txtProductName.Text) & _
                     " ,QuantityPerUnit = " & PrepareStr(txtQtyPerUnit.Text) & _
                     " ,UnitPrice = " & txtUnitPrice.Text & _
                     " ,UnitsInStock = " & txtUnitsInStock.Text & _
                     " ,UnitsOnOrder = " & txtUnitsOnOrder.Text & _
                     " ,ReorderLevel = " & txtReorderLevel.Text & _
                     " ,SupplierID = " & CType(cbSuppliers.Items(cbSuppliers.SelectedIndex), ListItem).ID & _
                     " ,CategoryID = " & CType(cbCategories.Items(cbCategories.SelectedIndex), ListItem).ID & _
                     " ,Discontinued = " & CType(IIf(chkDiscontinued.Checked, "1", "0"), String) & " " & _
                     "WHERE ProductID = " & CInt(txtProductID.Text)

            cnSQL = New SqlConnection(ConnectionString)
            cnSQL.Open()

            cmSQL = New SqlCommand(strSQL, cnSQL)
            intRowsAffected = cmSQL.ExecuteNonQuery()

            If intRowsAffected <> 1 Then
                MsgBox("Update Failed.", MsgBoxStyle.Critical, "Update")
            End If

            ' Close and Clean up objects
            cnSQL.Close()
            cmSQL.Dispose()
            cnSQL.Dispose()

        Catch e As SqlException
            MsgBox(e.Message, MsgBoxStyle.Critical, "SQL Error")

        Catch e As Exception
            MsgBox(e.Message, MsgBoxStyle.Critical, "General Error")
        End Try
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        PopulateCategoryCombo()
        PopulateSupplierCombo()
        PopulateProductList()
    End Sub
End Class
