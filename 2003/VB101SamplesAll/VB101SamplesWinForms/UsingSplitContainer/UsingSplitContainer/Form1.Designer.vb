<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Bob Franklin")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Sue Wilson")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Northwest", New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2})
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Frank Roberts")
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Southwest", New System.Windows.Forms.TreeNode() {TreeNode4})
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Sales By Region", New System.Windows.Forms.TreeNode() {TreeNode3, TreeNode5})
        Me.label3 = New System.Windows.Forms.Label
        Me.dataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesDataGridView = New System.Windows.Forms.DataGridView
        Me.dataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.YTDSalesTextBox = New System.Windows.Forms.TextBox
        Me.VerticalSplitContainer = New System.Windows.Forms.SplitContainer
        Me.SalesTreeView = New System.Windows.Forms.TreeView
        Me.SalesGroupBox = New System.Windows.Forms.GroupBox
        Me.DetailsGroupBox = New System.Windows.Forms.GroupBox
        Me.label2 = New System.Windows.Forms.Label
        Me.PhoneTextBox = New System.Windows.Forms.TextBox
        Me.label1 = New System.Windows.Forms.Label
        Me.EmployeeTextBox = New System.Windows.Forms.TextBox
        CType(Me.SalesDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.VerticalSplitContainer.Panel1.SuspendLayout()
        Me.VerticalSplitContainer.Panel2.SuspendLayout()
        Me.VerticalSplitContainer.SuspendLayout()
        Me.SalesGroupBox.SuspendLayout()
        Me.DetailsGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(6, 76)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(57, 13)
        Me.label3.TabIndex = 5
        Me.label3.Text = "YTD Sales:"
        '
        'dataGridViewTextBoxColumn2
        '
        Me.dataGridViewTextBoxColumn2.HeaderText = "Customer ID"
        Me.dataGridViewTextBoxColumn2.Name = "Column1"
        Me.dataGridViewTextBoxColumn2.ReadOnly = True
        '
        'SalesDataGridView
        '
        Me.SalesDataGridView.AllowUserToAddRows = False
        Me.SalesDataGridView.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.SalesDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.SalesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.SalesDataGridView.Columns.Add(Me.dataGridViewTextBoxColumn1)
        Me.SalesDataGridView.Columns.Add(Me.dataGridViewTextBoxColumn2)
        Me.SalesDataGridView.Columns.Add(Me.dataGridViewTextBoxColumn3)
        Me.SalesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SalesDataGridView.Enabled = False
        Me.SalesDataGridView.GridColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.SalesDataGridView.Location = New System.Drawing.Point(3, 16)
        Me.SalesDataGridView.Name = "SalesDataGridView"
        Me.SalesDataGridView.ReadOnly = True
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SalesDataGridView.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.SalesDataGridView.RowHeadersWidth = 39
        Me.SalesDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Blue
        Me.SalesDataGridView.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.SalesDataGridView.Size = New System.Drawing.Size(194, 81)
        Me.SalesDataGridView.TabIndex = 0
        Me.SalesDataGridView.Text = "dataGridView1"
        '
        'dataGridViewTextBoxColumn1
        '
        Me.dataGridViewTextBoxColumn1.HeaderText = "Date"
        Me.dataGridViewTextBoxColumn1.Name = "Date"
        Me.dataGridViewTextBoxColumn1.ReadOnly = True
        '
        'dataGridViewTextBoxColumn3
        '
        Me.dataGridViewTextBoxColumn3.HeaderText = "Amount"
        Me.dataGridViewTextBoxColumn3.Name = "Column2"
        Me.dataGridViewTextBoxColumn3.ReadOnly = True
        '
        'YTDSalesTextBox
        '
        Me.YTDSalesTextBox.Enabled = False
        Me.YTDSalesTextBox.Location = New System.Drawing.Point(94, 73)
        Me.YTDSalesTextBox.Name = "YTDSalesTextBox"
        Me.YTDSalesTextBox.Size = New System.Drawing.Size(100, 20)
        Me.YTDSalesTextBox.TabIndex = 4
        '
        'VerticalSplitContainer
        '
        Me.VerticalSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.VerticalSplitContainer.Location = New System.Drawing.Point(0, 0)
        Me.VerticalSplitContainer.Name = "VerticalSplitContainer"
        '
        'VerticalSplitContainer.Panel1
        '
        Me.VerticalSplitContainer.Panel1.Controls.Add(Me.SalesTreeView)
        '
        'VerticalSplitContainer.Panel2
        '
        Me.VerticalSplitContainer.Panel2.Controls.Add(Me.SalesGroupBox)
        Me.VerticalSplitContainer.Panel2.Controls.Add(Me.DetailsGroupBox)
        Me.VerticalSplitContainer.Size = New System.Drawing.Size(542, 416)
        Me.VerticalSplitContainer.SplitterDistance = 181
        Me.VerticalSplitContainer.TabIndex = 4
        '
        'SalesTreeView
        '
        Me.SalesTreeView.Location = New System.Drawing.Point(5, 10)
        Me.SalesTreeView.Name = "SalesTreeView"
        TreeNode1.Name = "Node6"
        TreeNode1.Text = "Bob Franklin"
        TreeNode2.Name = "Node7"
        TreeNode2.Text = "Sue Wilson"
        TreeNode3.Name = "Node1"
        TreeNode3.Text = "Northwest"
        TreeNode4.Name = "Node8"
        TreeNode4.Text = "Frank Roberts"
        TreeNode5.Name = "Node2"
        TreeNode5.Text = "Southwest"
        TreeNode6.Name = "Node0"
        TreeNode6.Text = "Sales By Region"
        Me.SalesTreeView.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode6})
        Me.SalesTreeView.Size = New System.Drawing.Size(162, 332)
        Me.SalesTreeView.TabIndex = 0
        '
        'SalesGroupBox
        '
        Me.SalesGroupBox.Controls.Add(Me.SalesDataGridView)
        Me.SalesGroupBox.Location = New System.Drawing.Point(13, 148)
        Me.SalesGroupBox.Name = "SalesGroupBox"
        Me.SalesGroupBox.Size = New System.Drawing.Size(200, 100)
        Me.SalesGroupBox.TabIndex = 2
        Me.SalesGroupBox.TabStop = False
        Me.SalesGroupBox.Text = "Sales"
        '
        'DetailsGroupBox
        '
        Me.DetailsGroupBox.Controls.Add(Me.label3)
        Me.DetailsGroupBox.Controls.Add(Me.YTDSalesTextBox)
        Me.DetailsGroupBox.Controls.Add(Me.label2)
        Me.DetailsGroupBox.Controls.Add(Me.PhoneTextBox)
        Me.DetailsGroupBox.Controls.Add(Me.label1)
        Me.DetailsGroupBox.Controls.Add(Me.EmployeeTextBox)
        Me.DetailsGroupBox.Location = New System.Drawing.Point(13, 10)
        Me.DetailsGroupBox.MinimumSize = New System.Drawing.Size(200, 100)
        Me.DetailsGroupBox.Name = "DetailsGroupBox"
        Me.DetailsGroupBox.Size = New System.Drawing.Size(201, 102)
        Me.DetailsGroupBox.TabIndex = 1
        Me.DetailsGroupBox.TabStop = False
        Me.DetailsGroupBox.Text = "Details"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(6, 49)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(37, 13)
        Me.label2.TabIndex = 3
        Me.label2.Text = "Phone:"
        '
        'PhoneTextBox
        '
        Me.PhoneTextBox.Enabled = False
        Me.PhoneTextBox.Location = New System.Drawing.Point(94, 46)
        Me.PhoneTextBox.Name = "PhoneTextBox"
        Me.PhoneTextBox.Size = New System.Drawing.Size(100, 20)
        Me.PhoneTextBox.TabIndex = 2
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(6, 22)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(52, 13)
        Me.label1.TabIndex = 1
        Me.label1.Text = "Employee:"
        '
        'EmployeeTextBox
        '
        Me.EmployeeTextBox.Enabled = False
        Me.EmployeeTextBox.Location = New System.Drawing.Point(94, 19)
        Me.EmployeeTextBox.Name = "EmployeeTextBox"
        Me.EmployeeTextBox.Size = New System.Drawing.Size(100, 20)
        Me.EmployeeTextBox.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(542, 416)
        Me.Controls.Add(Me.VerticalSplitContainer)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Using SplitContainer"
        CType(Me.SalesDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.VerticalSplitContainer.Panel1.ResumeLayout(False)
        Me.VerticalSplitContainer.Panel2.ResumeLayout(False)
        Me.VerticalSplitContainer.ResumeLayout(False)
        Me.SalesGroupBox.ResumeLayout(False)
        Me.DetailsGroupBox.ResumeLayout(False)
        Me.DetailsGroupBox.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents label3 As System.Windows.Forms.Label
    Friend WithEvents dataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents dataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents YTDSalesTextBox As System.Windows.Forms.TextBox
    Friend WithEvents VerticalSplitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents SalesTreeView As System.Windows.Forms.TreeView
    Friend WithEvents SalesGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents DetailsGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents PhoneTextBox As System.Windows.Forms.TextBox
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents EmployeeTextBox As System.Windows.Forms.TextBox

End Class
