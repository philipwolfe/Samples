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
Partial Public Class CustomerOrdersForm
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CustomerOrdersForm))
        Me.OrderID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmployeeID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OrderDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RequiredDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShippedDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipVia = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Freight = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipAddress = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipCity = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipRegion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipPostalCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipCountry = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dataGridView1 = New System.Windows.Forms.DataGridView
        Me.statusStrip1 = New System.Windows.Forms.StatusStrip
        Me.statusStripPanel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.processToolStripButton = New System.Windows.Forms.ToolStripButton
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.statusStrip1.SuspendLayout()
        Me.toolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'OrderID
        '
        Me.OrderID.DataPropertyName = "OrderID"
        Me.OrderID.HeaderText = "OrderID"
        Me.OrderID.Name = "OrderID"
        Me.OrderID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'EmployeeID
        '
        Me.EmployeeID.DataPropertyName = "EmployeeID"
        Me.EmployeeID.HeaderText = "EmployeeID"
        Me.EmployeeID.Name = "EmployeeID"
        Me.EmployeeID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'OrderDate
        '
        Me.OrderDate.DataPropertyName = "OrderDate"
        Me.OrderDate.HeaderText = "OrderDate"
        Me.OrderDate.Name = "OrderDate"
        Me.OrderDate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'RequiredDate
        '
        Me.RequiredDate.DataPropertyName = "RequiredDate"
        DataGridViewCellStyle1.NullValue = "[Unknown]"
        Me.RequiredDate.DefaultCellStyle = DataGridViewCellStyle1
        Me.RequiredDate.HeaderText = "RequiredDate"
        Me.RequiredDate.Name = "RequiredDate"
        Me.RequiredDate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'ShippedDate
        '
        Me.ShippedDate.DataPropertyName = "ShippedDate"
        DataGridViewCellStyle2.NullValue = "[Not Shipped]"
        Me.ShippedDate.DefaultCellStyle = DataGridViewCellStyle2
        Me.ShippedDate.HeaderText = "ShippedDate"
        Me.ShippedDate.Name = "ShippedDate"
        Me.ShippedDate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'ShipVia
        '
        Me.ShipVia.DataPropertyName = "ShipVia"
        Me.ShipVia.HeaderText = "ShipVia"
        Me.ShipVia.Name = "ShipVia"
        Me.ShipVia.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'Freight
        '
        Me.Freight.DataPropertyName = "Freight"
        Me.Freight.HeaderText = "Freight"
        Me.Freight.Name = "Freight"
        Me.Freight.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'ShipName
        '
        Me.ShipName.DataPropertyName = "ShipName"
        Me.ShipName.HeaderText = "ShipName"
        Me.ShipName.Name = "ShipName"
        Me.ShipName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'ShipAddress
        '
        Me.ShipAddress.DataPropertyName = "ShipAddress"
        Me.ShipAddress.HeaderText = "ShipAddress"
        Me.ShipAddress.Name = "ShipAddress"
        Me.ShipAddress.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'ShipCity
        '
        Me.ShipCity.DataPropertyName = "ShipCity"
        Me.ShipCity.HeaderText = "ShipCity"
        Me.ShipCity.Name = "ShipCity"
        Me.ShipCity.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'ShipRegion
        '
        Me.ShipRegion.DataPropertyName = "ShipRegion"
        DataGridViewCellStyle3.NullValue = "[Unknown]"
        Me.ShipRegion.DefaultCellStyle = DataGridViewCellStyle3
        Me.ShipRegion.HeaderText = "ShipRegion"
        Me.ShipRegion.Name = "ShipRegion"
        Me.ShipRegion.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'ShipPostalCode
        '
        Me.ShipPostalCode.DataPropertyName = "ShipPostalCode"
        Me.ShipPostalCode.HeaderText = "ShipPostalCode"
        Me.ShipPostalCode.Name = "ShipPostalCode"
        Me.ShipPostalCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'ShipCountry
        '
        Me.ShipCountry.DataPropertyName = "ShipCountry"
        Me.ShipCountry.HeaderText = "ShipCountry"
        Me.ShipCountry.Name = "ShipCountry"
        Me.ShipCountry.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'dataGridView1
        '
        Me.dataGridView1.AllowUserToAddRows = False
        Me.dataGridView1.AllowUserToDeleteRows = False
        Me.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.OrderID, Me.EmployeeID, Me.OrderDate, Me.RequiredDate, Me.ShippedDate, Me.ShipVia, Me.Freight, Me.ShipName, Me.ShipAddress, Me.ShipCity, Me.ShipRegion, Me.ShipPostalCode, Me.ShipCountry})
        Me.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dataGridView1.Location = New System.Drawing.Point(0, 27)
        Me.dataGridView1.MultiSelect = False
        Me.dataGridView1.Name = "dataGridView1"
        Me.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dataGridView1.Size = New System.Drawing.Size(612, 312)
        Me.dataGridView1.StandardTab = True
        Me.dataGridView1.TabIndex = 0
        '
        'statusStrip1
        '
        Me.statusStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.statusStrip1.GripMargin = New System.Windows.Forms.Padding(-4, 0, 0, 0)
        Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statusStripPanel1})
        Me.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table
        Me.statusStrip1.Location = New System.Drawing.Point(0, 339)
        Me.statusStrip1.Name = "statusStrip1"
        Me.statusStrip1.Size = New System.Drawing.Size(612, 23)
        Me.statusStrip1.TabIndex = 0
        Me.statusStrip1.Text = "statusStrip1"
        '
        'statusStripPanel1
        '
        Me.statusStripPanel1.AutoSize = False
        Me.statusStripPanel1.Name = "statusStripPanel1"
        Me.statusStripPanel1.Size = New System.Drawing.Size(23, 18)
        Me.statusStripPanel1.Text = "Number of orders selected: 0"
        '
        'toolStrip1
        '
        Me.toolStrip1.ImageList = Me.ImageList1
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.processToolStripButton})
        Me.toolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.toolStrip1.Size = New System.Drawing.Size(612, 27)
        Me.toolStrip1.TabIndex = 0
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.Images.SetKeyName(0, "ProcessOrders.ico")
        '
        'processToolStripButton
        '
        Me.processToolStripButton.Image = CType(resources.GetObject("processToolStripButton.Image"), System.Drawing.Image)
        Me.processToolStripButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.processToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.processToolStripButton.Name = "processToolStripButton"
        Me.processToolStripButton.Size = New System.Drawing.Size(116, 24)
        Me.processToolStripButton.Text = "Process Orders..."
        Me.processToolStripButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CustomerOrdersForm
        '
        Me.ClientSize = New System.Drawing.Size(612, 362)
        Me.Controls.Add(Me.dataGridView1)
        Me.Controls.Add(Me.statusStrip1)
        Me.Controls.Add(Me.toolStrip1)
        Me.KeyPreview = True
        Me.Name = "CustomerOrdersForm"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.Text = "CustomerOrdersForm"
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.statusStrip1.ResumeLayout(False)
        Me.statusStrip1.PerformLayout()
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents statusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents statusStripPanel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend dataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend dataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend dataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend dataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend dataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend dataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend dataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend dataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend dataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend dataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend dataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend dataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend dataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents processToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents OrderID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmployeeID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrderDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RequiredDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShippedDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipVia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Freight As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipAddress As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipCity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipRegion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipPostalCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipCountry As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
