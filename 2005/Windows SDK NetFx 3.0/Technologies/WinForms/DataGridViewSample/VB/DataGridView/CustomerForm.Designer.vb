'---------------------------------------------------------------------
'  This file is part of the Microsoft .NET Framework SDK Code Samples.
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved.
' 
'This source code is intended only as a supplement to Microsoft
'Development Tools and/or on-line documentation.  See these other
'materials for detailed information regarding Microsoft code samples.
' 
'THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
'KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
'IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
'PARTICULAR PURPOSE.
'---------------------------------------------------------------------
Partial Public Class CustomerForm
    Inherits System.Windows.Forms.Form

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerNonUserCode()> Private Sub InitializeComponent()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dataGridView1 = New System.Windows.Forms.DataGridView
        Me.CustomerID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerOrders = New System.Windows.Forms.DataGridViewLinkColumn
        Me.Company = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContactName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContactTitle = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Address = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.City = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RegionCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Country = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Phone = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Fax = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.menuStrip1 = New System.Windows.Forms.MenuStrip
        Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.customerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.newToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.viewOrdersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dataGridView1
        '
        Me.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CustomerID, Me.CustomerOrders, Me.Company, Me.ContactName, Me.ContactTitle, Me.Address, Me.City, Me.RegionCode, Me.Country, Me.Phone, Me.Fax})
        Me.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dataGridView1.Location = New System.Drawing.Point(0, 24)
        Me.dataGridView1.Name = "dataGridView1"
        Me.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dataGridView1.Size = New System.Drawing.Size(676, 361)
        Me.dataGridView1.TabIndex = 0
        '
        'CustomerID
        '
        Me.CustomerID.DataPropertyName = "CustomerID"
        Me.CustomerID.HeaderText = "ID"
        Me.CustomerID.Name = "CustomerID"
        Me.CustomerID.ReadOnly = True
        Me.CustomerID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CustomerID.Width = 43
        '
        'CustomerOrders
        '
        Me.CustomerOrders.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.CustomerOrders.DataPropertyName = "CustomerID"
        Me.CustomerOrders.HeaderText = "Orders"
        Me.CustomerOrders.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.CustomerOrders.Name = "CustomerOrders"
        Me.CustomerOrders.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CustomerOrders.Text = "View Orders "
        Me.CustomerOrders.UseColumnTextForLinkValue = True
        Me.CustomerOrders.Width = 44
        '
        'Company
        '
        Me.Company.DataPropertyName = "CompanyName"
        Me.Company.HeaderText = "Company"
        Me.Company.Name = "Company"
        Me.Company.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Company.Width = 107
        '
        'ContactName
        '
        Me.ContactName.DataPropertyName = "ContactName"
        Me.ContactName.HeaderText = "Contact Name"
        Me.ContactName.Name = "ContactName"
        Me.ContactName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'ContactTitle
        '
        Me.ContactTitle.DataPropertyName = "ContactTitle"
        Me.ContactTitle.HeaderText = "Contact Title"
        Me.ContactTitle.Name = "ContactTitle"
        Me.ContactTitle.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ContactTitle.Width = 92
        '
        'Address
        '
        Me.Address.DataPropertyName = "Address"
        Me.Address.HeaderText = "Address"
        Me.Address.Name = "Address"
        Me.Address.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Address.Width = 70
        '
        'City
        '
        Me.City.DataPropertyName = "City"
        Me.City.HeaderText = "City"
        Me.City.Name = "City"
        Me.City.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.City.Width = 49
        '
        'RegionCode
        '
        Me.RegionCode.DataPropertyName = "Region"
        DataGridViewCellStyle3.NullValue = "[Unknown]"
        Me.RegionCode.DefaultCellStyle = DataGridViewCellStyle3
        Me.RegionCode.HeaderText = "Region Code"
        Me.RegionCode.Name = "RegionCode"
        Me.RegionCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.RegionCode.Width = 66
        '
        'Country
        '
        Me.Country.DataPropertyName = "Country"
        Me.Country.HeaderText = "Country"
        Me.Country.Name = "Country"
        Me.Country.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Country.Width = 68
        '
        'Phone
        '
        Me.Phone.DataPropertyName = "Phone"
        Me.Phone.HeaderText = "Phone"
        Me.Phone.Name = "Phone"
        Me.Phone.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Phone.Width = 63
        '
        'Fax
        '
        Me.Fax.DataPropertyName = "Fax"
        Me.Fax.HeaderText = "Fax"
        Me.Fax.Name = "Fax"
        Me.Fax.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Fax.Width = 49
        '
        'menuStrip1
        '
        Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileToolStripMenuItem, Me.customerToolStripMenuItem})
        Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip1.Name = "menuStrip1"
        Me.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.menuStrip1.Size = New System.Drawing.Size(676, 24)
        Me.menuStrip1.TabIndex = 0
        Me.menuStrip1.Text = "menuStrip1"
        '
        'fileToolStripMenuItem
        '
        Me.fileToolStripMenuItem.DoubleClickEnabled = True
        Me.fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.exitToolStripMenuItem})
        Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
        Me.fileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.fileToolStripMenuItem.Text = "&File"
        '
        'exitToolStripMenuItem
        '
        Me.exitToolStripMenuItem.DoubleClickEnabled = True
        Me.exitToolStripMenuItem.Name = "exitToolStripMenuItem"
        Me.exitToolStripMenuItem.Size = New System.Drawing.Size(95, 22)
        Me.exitToolStripMenuItem.Text = "E&xit"
        '
        'customerToolStripMenuItem
        '
        Me.customerToolStripMenuItem.DoubleClickEnabled = True
        Me.customerToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.newToolStripMenuItem, Me.viewOrdersToolStripMenuItem})
        Me.customerToolStripMenuItem.Name = "customerToolStripMenuItem"
        Me.customerToolStripMenuItem.Size = New System.Drawing.Size(65, 20)
        Me.customerToolStripMenuItem.Text = "&Customer"
        '
        'newToolStripMenuItem
        '
        Me.newToolStripMenuItem.DoubleClickEnabled = True
        Me.newToolStripMenuItem.Name = "newToolStripMenuItem"
        Me.newToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.newToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.newToolStripMenuItem.Text = "New &Customer"
        '
        'viewOrdersToolStripMenuItem
        '
        Me.viewOrdersToolStripMenuItem.DoubleClickEnabled = True
        Me.viewOrdersToolStripMenuItem.Name = "viewOrdersToolStripMenuItem"
        Me.viewOrdersToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.viewOrdersToolStripMenuItem.Text = "View &Orders..."
        '
        'CustomerForm
        '
        Me.ClientSize = New System.Drawing.Size(676, 385)
        Me.Controls.Add(Me.dataGridView1)
        Me.Controls.Add(Me.menuStrip1)
        Me.Name = "CustomerForm"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.Text = "Customer Order Viewer"
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menuStrip1.ResumeLayout(False)
        Me.menuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents menuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents exitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents customerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents newToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents viewOrdersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CustomerID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerOrders As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents Company As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContactName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContactTitle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Address As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents City As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RegionCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Country As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Phone As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fax As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
