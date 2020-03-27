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
        Me.components = New System.ComponentModel.Container
        Dim departmentIDLabel As System.Windows.Forms.Label
        Dim nameLabel As System.Windows.Forms.Label
        Dim groupNameLabel As System.Windows.Forms.Label
        Dim label1 As System.Windows.Forms.Label
        Dim label2 As System.Windows.Forms.Label
        Dim label3 As System.Windows.Forms.Label
        Dim departmentIDLabel1 As System.Windows.Forms.Label
        Dim nameLabel1 As System.Windows.Forms.Label
        Dim groupNameLabel1 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.bindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.bindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
        Me.bindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
        Me.departmentIDTextBox = New System.Windows.Forms.TextBox
        Me.splitContainer1 = New System.Windows.Forms.SplitContainer
        Me.groupNameTextBox = New System.Windows.Forms.TextBox
        Me.nameTextBox = New System.Windows.Forms.TextBox
        Me.employeeDataGridView = New System.Windows.Forms.DataGridView
        Me.tabPage2 = New System.Windows.Forms.TabPage
        Me.bindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.bindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
        Me.bindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
        Me.bindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
        Me.bindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
        Me.bindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.bindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
        Me.employeeDataGridView2 = New System.Windows.Forms.DataGridView
        Me.departmentIDTextBox2 = New System.Windows.Forms.TextBox
        Me.departmentTableAdapter = New CreatingMasterDetails.AdventureWorks_DataDataSetTableAdapters.DepartmentTableAdapter
        Me.employeeTableAdapter1 = New CreatingMasterDetails.AdventureWorks_DataDataSetTableAdapters.EmployeeTableAdapter
        Me.employeeTableAdapter = New CreatingMasterDetails.AdventureWorks_DataDataSetTableAdapters.EmployeeTableAdapter
        Me.splitContainer4 = New System.Windows.Forms.SplitContainer
        Me.nameTextBox2 = New System.Windows.Forms.TextBox
        Me.groupNameTextBox2 = New System.Windows.Forms.TextBox
        Me.splitContainer3 = New System.Windows.Forms.SplitContainer
        Me.departmentIDTextBox1 = New System.Windows.Forms.TextBox
        Me.departmentBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.adventureWorks_DataDataSet = New CreatingMasterDetails.AdventureWorks_DataDataSet
        Me.groupNameTextBox1 = New System.Windows.Forms.TextBox
        Me.nameTextBox1 = New System.Windows.Forms.TextBox
        Me.employeeDataGridView1 = New System.Windows.Forms.DataGridView
        Me.EmployeeID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContactID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DepartmentID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ManagerID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Title = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BaseRate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.employeeBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.tabPage3 = New System.Windows.Forms.TabPage
        Me.bindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton
        Me.tabPage1 = New System.Windows.Forms.TabPage
        Me.departmentBindingSource1BindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.tabControl1 = New System.Windows.Forms.TabControl
        departmentIDLabel = New System.Windows.Forms.Label
        nameLabel = New System.Windows.Forms.Label
        groupNameLabel = New System.Windows.Forms.Label
        label1 = New System.Windows.Forms.Label
        label2 = New System.Windows.Forms.Label
        label3 = New System.Windows.Forms.Label
        departmentIDLabel1 = New System.Windows.Forms.Label
        nameLabel1 = New System.Windows.Forms.Label
        groupNameLabel1 = New System.Windows.Forms.Label
        Me.splitContainer1.Panel1.SuspendLayout()
        Me.splitContainer1.Panel2.SuspendLayout()
        Me.splitContainer1.SuspendLayout()
        CType(Me.employeeDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPage2.SuspendLayout()
        CType(Me.employeeDataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitContainer4.Panel1.SuspendLayout()
        Me.splitContainer4.Panel2.SuspendLayout()
        Me.splitContainer4.SuspendLayout()
        Me.splitContainer3.Panel1.SuspendLayout()
        Me.splitContainer3.Panel2.SuspendLayout()
        Me.splitContainer3.SuspendLayout()
        CType(Me.departmentBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.adventureWorks_DataDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.employeeDataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.employeeBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPage3.SuspendLayout()
        Me.tabPage1.SuspendLayout()
        CType(Me.departmentBindingSource1BindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.departmentBindingSource1BindingNavigator.SuspendLayout()
        Me.tabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'departmentIDLabel
        '
        departmentIDLabel.AutoSize = True
        departmentIDLabel.Location = New System.Drawing.Point(8, 11)
        departmentIDLabel.Name = "departmentIDLabel"
        departmentIDLabel.Size = New System.Drawing.Size(79, 13)
        departmentIDLabel.TabIndex = 0
        departmentIDLabel.Text = "Department ID:"
        '
        'nameLabel
        '
        nameLabel.AutoSize = True
        nameLabel.Location = New System.Drawing.Point(8, 38)
        nameLabel.Name = "nameLabel"
        nameLabel.Size = New System.Drawing.Size(67, 13)
        nameLabel.TabIndex = 2
        nameLabel.Text = "Dept. Name:"
        '
        'groupNameLabel
        '
        groupNameLabel.AutoSize = True
        groupNameLabel.Location = New System.Drawing.Point(8, 65)
        groupNameLabel.Name = "groupNameLabel"
        groupNameLabel.Size = New System.Drawing.Size(70, 13)
        groupNameLabel.TabIndex = 4
        groupNameLabel.Text = "Group Name:"
        '
        'label1
        '
        label1.AutoSize = True
        label1.Location = New System.Drawing.Point(11, 14)
        label1.Name = "label1"
        label1.Size = New System.Drawing.Size(79, 13)
        label1.TabIndex = 6
        label1.Text = "Department ID:"
        '
        'label2
        '
        label2.AutoSize = True
        label2.Location = New System.Drawing.Point(11, 41)
        label2.Name = "label2"
        label2.Size = New System.Drawing.Size(67, 13)
        label2.TabIndex = 8
        label2.Text = "Dept. Name:"
        '
        'label3
        '
        label3.AutoSize = True
        label3.Location = New System.Drawing.Point(11, 68)
        label3.Name = "label3"
        label3.Size = New System.Drawing.Size(70, 13)
        label3.TabIndex = 10
        label3.Text = "Group Name:"
        '
        'departmentIDLabel1
        '
        departmentIDLabel1.AutoSize = True
        departmentIDLabel1.Location = New System.Drawing.Point(9, 11)
        departmentIDLabel1.Name = "departmentIDLabel1"
        departmentIDLabel1.Size = New System.Drawing.Size(79, 13)
        departmentIDLabel1.TabIndex = 9
        departmentIDLabel1.Text = "Department ID:"
        '
        'nameLabel1
        '
        nameLabel1.AutoSize = True
        nameLabel1.Location = New System.Drawing.Point(8, 37)
        nameLabel1.Name = "nameLabel1"
        nameLabel1.Size = New System.Drawing.Size(67, 13)
        nameLabel1.TabIndex = 11
        nameLabel1.Text = "Dept. Name:"
        '
        'groupNameLabel1
        '
        groupNameLabel1.AutoSize = True
        groupNameLabel1.Location = New System.Drawing.Point(8, 63)
        groupNameLabel1.Name = "groupNameLabel1"
        groupNameLabel1.Size = New System.Drawing.Size(70, 13)
        groupNameLabel1.TabIndex = 13
        groupNameLabel1.Text = "Group Name:"
        '
        'bindingNavigatorSeparator2
        '
        Me.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2"
        Me.bindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'bindingNavigatorMoveLastItem
        '
        Me.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.bindingNavigatorMoveLastItem.Image = CType(resources.GetObject("bindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem"
        Me.bindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.bindingNavigatorMoveLastItem.Text = "Move last"
        '
        'bindingNavigatorMoveNextItem
        '
        Me.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.bindingNavigatorMoveNextItem.Image = CType(resources.GetObject("bindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem"
        Me.bindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.bindingNavigatorMoveNextItem.Text = "Move next"
        '
        'departmentIDTextBox
        '
        Me.departmentIDTextBox.Enabled = False
        Me.departmentIDTextBox.Location = New System.Drawing.Point(90, 8)
        Me.departmentIDTextBox.Name = "departmentIDTextBox"
        Me.departmentIDTextBox.Size = New System.Drawing.Size(200, 20)
        Me.departmentIDTextBox.TabIndex = 1
        '
        'splitContainer1
        '
        Me.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.splitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.splitContainer1.Name = "splitContainer1"
        Me.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitContainer1.Panel1
        '
        Me.splitContainer1.Panel1.Controls.Add(Me.groupNameTextBox)
        Me.splitContainer1.Panel1.Controls.Add(departmentIDLabel)
        Me.splitContainer1.Panel1.Controls.Add(Me.departmentIDTextBox)
        Me.splitContainer1.Panel1.Controls.Add(nameLabel)
        Me.splitContainer1.Panel1.Controls.Add(Me.nameTextBox)
        Me.splitContainer1.Panel1.Controls.Add(groupNameLabel)
        '
        'splitContainer1.Panel2
        '
        Me.splitContainer1.Panel2.Controls.Add(Me.employeeDataGridView)
        Me.splitContainer1.Size = New System.Drawing.Size(528, 384)
        Me.splitContainer1.SplitterDistance = 89
        Me.splitContainer1.TabIndex = 0
        Me.splitContainer1.Text = "splitContainer1"
        '
        'groupNameTextBox
        '
        Me.groupNameTextBox.Enabled = False
        Me.groupNameTextBox.Location = New System.Drawing.Point(90, 62)
        Me.groupNameTextBox.Name = "groupNameTextBox"
        Me.groupNameTextBox.Size = New System.Drawing.Size(200, 20)
        Me.groupNameTextBox.TabIndex = 5
        '
        'nameTextBox
        '
        Me.nameTextBox.Enabled = False
        Me.nameTextBox.Location = New System.Drawing.Point(90, 35)
        Me.nameTextBox.Name = "nameTextBox"
        Me.nameTextBox.Size = New System.Drawing.Size(200, 20)
        Me.nameTextBox.TabIndex = 3
        '
        'employeeDataGridView
        '
        Me.employeeDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.employeeDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.employeeDataGridView.Name = "employeeDataGridView"
        Me.employeeDataGridView.Size = New System.Drawing.Size(528, 291)
        Me.employeeDataGridView.TabIndex = 1
        '
        'tabPage2
        '
        Me.tabPage2.Controls.Add(Me.splitContainer1)
        Me.tabPage2.Location = New System.Drawing.Point(4, 22)
        Me.tabPage2.Name = "tabPage2"
        Me.tabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage2.Size = New System.Drawing.Size(534, 390)
        Me.tabPage2.TabIndex = 1
        Me.tabPage2.Text = "Run time w/ Relations"
        '
        'bindingNavigatorSeparator1
        '
        Me.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1"
        Me.bindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'bindingNavigatorMoveFirstItem
        '
        Me.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.bindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("bindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem"
        Me.bindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.bindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'bindingNavigatorDeleteItem
        '
        Me.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.bindingNavigatorDeleteItem.Image = CType(resources.GetObject("bindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem"
        Me.bindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.bindingNavigatorDeleteItem.Text = "Delete"
        '
        'bindingNavigatorCountItem
        '
        Me.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem"
        Me.bindingNavigatorCountItem.Size = New System.Drawing.Size(36, 22)
        Me.bindingNavigatorCountItem.Text = "of {0}"
        Me.bindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'bindingNavigatorPositionItem
        '
        Me.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem"
        Me.bindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 25)
        Me.bindingNavigatorPositionItem.Text = "0"
        Me.bindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'bindingNavigatorSeparator
        '
        Me.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator"
        Me.bindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'bindingNavigatorMovePreviousItem
        '
        Me.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.bindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("bindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem"
        Me.bindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.bindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'employeeDataGridView2
        '
        Me.employeeDataGridView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.employeeDataGridView2.Location = New System.Drawing.Point(0, 0)
        Me.employeeDataGridView2.Name = "employeeDataGridView2"
        Me.employeeDataGridView2.Size = New System.Drawing.Size(534, 294)
        Me.employeeDataGridView2.TabIndex = 1
        '
        'departmentIDTextBox2
        '
        Me.departmentIDTextBox2.Enabled = False
        Me.departmentIDTextBox2.Location = New System.Drawing.Point(93, 11)
        Me.departmentIDTextBox2.Name = "departmentIDTextBox2"
        Me.departmentIDTextBox2.Size = New System.Drawing.Size(200, 20)
        Me.departmentIDTextBox2.TabIndex = 7
        '
        'departmentTableAdapter
        '
        Me.departmentTableAdapter.ClearBeforeFill = True
        '
        'employeeTableAdapter1
        '
        Me.employeeTableAdapter1.ClearBeforeFill = True
        '
        'employeeTableAdapter
        '
        Me.employeeTableAdapter.ClearBeforeFill = True
        '
        'splitContainer4
        '
        Me.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.splitContainer4.Location = New System.Drawing.Point(0, 0)
        Me.splitContainer4.Name = "splitContainer4"
        Me.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitContainer4.Panel1
        '
        Me.splitContainer4.Panel1.Controls.Add(label1)
        Me.splitContainer4.Panel1.Controls.Add(Me.departmentIDTextBox2)
        Me.splitContainer4.Panel1.Controls.Add(label2)
        Me.splitContainer4.Panel1.Controls.Add(Me.nameTextBox2)
        Me.splitContainer4.Panel1.Controls.Add(label3)
        Me.splitContainer4.Panel1.Controls.Add(Me.groupNameTextBox2)
        '
        'splitContainer4.Panel2
        '
        Me.splitContainer4.Panel2.Controls.Add(Me.employeeDataGridView2)
        Me.splitContainer4.Size = New System.Drawing.Size(534, 390)
        Me.splitContainer4.SplitterDistance = 92
        Me.splitContainer4.TabIndex = 0
        Me.splitContainer4.Text = "splitContainer4"
        '
        'nameTextBox2
        '
        Me.nameTextBox2.Enabled = False
        Me.nameTextBox2.Location = New System.Drawing.Point(93, 38)
        Me.nameTextBox2.Name = "nameTextBox2"
        Me.nameTextBox2.Size = New System.Drawing.Size(200, 20)
        Me.nameTextBox2.TabIndex = 9
        '
        'groupNameTextBox2
        '
        Me.groupNameTextBox2.Enabled = False
        Me.groupNameTextBox2.Location = New System.Drawing.Point(93, 65)
        Me.groupNameTextBox2.Name = "groupNameTextBox2"
        Me.groupNameTextBox2.Size = New System.Drawing.Size(200, 20)
        Me.groupNameTextBox2.TabIndex = 11
        '
        'splitContainer3
        '
        Me.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.splitContainer3.Location = New System.Drawing.Point(3, 28)
        Me.splitContainer3.Name = "splitContainer3"
        Me.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitContainer3.Panel1
        '
        Me.splitContainer3.Panel1.Controls.Add(departmentIDLabel1)
        Me.splitContainer3.Panel1.Controls.Add(Me.departmentIDTextBox1)
        Me.splitContainer3.Panel1.Controls.Add(nameLabel1)
        Me.splitContainer3.Panel1.Controls.Add(Me.groupNameTextBox1)
        Me.splitContainer3.Panel1.Controls.Add(Me.nameTextBox1)
        Me.splitContainer3.Panel1.Controls.Add(groupNameLabel1)
        '
        'splitContainer3.Panel2
        '
        Me.splitContainer3.Panel2.Controls.Add(Me.employeeDataGridView1)
        Me.splitContainer3.Size = New System.Drawing.Size(528, 359)
        Me.splitContainer3.SplitterDistance = 92
        Me.splitContainer3.TabIndex = 10
        Me.splitContainer3.Text = "splitContainer3"
        '
        'departmentIDTextBox1
        '
        Me.departmentIDTextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.departmentBindingSource1, "DepartmentID", True))
        Me.departmentIDTextBox1.Enabled = False
        Me.departmentIDTextBox1.Location = New System.Drawing.Point(90, 8)
        Me.departmentIDTextBox1.Name = "departmentIDTextBox1"
        Me.departmentIDTextBox1.Size = New System.Drawing.Size(200, 20)
        Me.departmentIDTextBox1.TabIndex = 10
        '
        'departmentBindingSource1
        '
        Me.departmentBindingSource1.AllowNew = False
        Me.departmentBindingSource1.DataMember = "Department"
        Me.departmentBindingSource1.DataSource = Me.adventureWorks_DataDataSet
        '
        'adventureWorks_DataDataSet
        '
        Me.adventureWorks_DataDataSet.DataSetName = "AdventureWorks_DataDataSet"
        Me.adventureWorks_DataDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'groupNameTextBox1
        '
        Me.groupNameTextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.departmentBindingSource1, "GroupName", True))
        Me.groupNameTextBox1.Enabled = False
        Me.groupNameTextBox1.Location = New System.Drawing.Point(90, 60)
        Me.groupNameTextBox1.Name = "groupNameTextBox1"
        Me.groupNameTextBox1.Size = New System.Drawing.Size(200, 20)
        Me.groupNameTextBox1.TabIndex = 14
        '
        'nameTextBox1
        '
        Me.nameTextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.departmentBindingSource1, "Name", True))
        Me.nameTextBox1.Enabled = False
        Me.nameTextBox1.Location = New System.Drawing.Point(90, 34)
        Me.nameTextBox1.Name = "nameTextBox1"
        Me.nameTextBox1.Size = New System.Drawing.Size(200, 20)
        Me.nameTextBox1.TabIndex = 12
        '
        'employeeDataGridView1
        '
        Me.employeeDataGridView1.AllowUserToAddRows = False
        Me.employeeDataGridView1.AllowUserToOrderColumns = True
        Me.employeeDataGridView1.AutoGenerateColumns = False
        Me.employeeDataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.employeeDataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EmployeeID, Me.ContactID, Me.DepartmentID, Me.ManagerID, Me.Title, Me.BaseRate})
        Me.employeeDataGridView1.DataSource = Me.employeeBindingSource1
        Me.employeeDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.employeeDataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.employeeDataGridView1.Name = "employeeDataGridView1"
        Me.employeeDataGridView1.Size = New System.Drawing.Size(528, 263)
        Me.employeeDataGridView1.TabIndex = 17
        '
        'EmployeeID
        '
        Me.EmployeeID.DataPropertyName = "EmployeeID"
        Me.EmployeeID.HeaderText = "Employee ID"
        Me.EmployeeID.Name = "EmployeeID"
        Me.EmployeeID.ReadOnly = True
        Me.EmployeeID.Width = 92
        '
        'ContactID
        '
        Me.ContactID.DataPropertyName = "ContactID"
        Me.ContactID.HeaderText = "Contact ID"
        Me.ContactID.Name = "ContactID"
        Me.ContactID.Width = 83
        '
        'DepartmentID
        '
        Me.DepartmentID.DataPropertyName = "DepartmentID"
        Me.DepartmentID.HeaderText = "Dept ID"
        Me.DepartmentID.Name = "DepartmentID"
        Me.DepartmentID.Width = 69
        '
        'ManagerID
        '
        Me.ManagerID.DataPropertyName = "ManagerID"
        Me.ManagerID.HeaderText = "Manager ID"
        Me.ManagerID.Name = "ManagerID"
        Me.ManagerID.Width = 88
        '
        'Title
        '
        Me.Title.DataPropertyName = "Title"
        Me.Title.HeaderText = "Title"
        Me.Title.Name = "Title"
        Me.Title.Width = 52
        '
        'BaseRate
        '
        Me.BaseRate.DataPropertyName = "BaseRate"
        Me.BaseRate.HeaderText = "Base Rate"
        Me.BaseRate.Name = "BaseRate"
        Me.BaseRate.Width = 82
        '
        'employeeBindingSource1
        '
        Me.employeeBindingSource1.AllowNew = True
        Me.employeeBindingSource1.DataMember = "FK_Employee_Department_DepartmentID"
        Me.employeeBindingSource1.DataSource = Me.departmentBindingSource1
        '
        'tabPage3
        '
        Me.tabPage3.Controls.Add(Me.splitContainer4)
        Me.tabPage3.Location = New System.Drawing.Point(4, 22)
        Me.tabPage3.Name = "tabPage3"
        Me.tabPage3.Size = New System.Drawing.Size(534, 390)
        Me.tabPage3.TabIndex = 2
        Me.tabPage3.Text = "Run time w/ Events"
        '
        'bindingNavigatorAddNewItem
        '
        Me.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.bindingNavigatorAddNewItem.Image = CType(resources.GetObject("bindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem"
        Me.bindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.bindingNavigatorAddNewItem.Text = "Add new"
        '
        'tabPage1
        '
        Me.tabPage1.AutoScroll = True
        Me.tabPage1.Controls.Add(Me.splitContainer3)
        Me.tabPage1.Controls.Add(Me.departmentBindingSource1BindingNavigator)
        Me.tabPage1.Location = New System.Drawing.Point(4, 22)
        Me.tabPage1.Name = "tabPage1"
        Me.tabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage1.Size = New System.Drawing.Size(534, 390)
        Me.tabPage1.TabIndex = 0
        Me.tabPage1.Text = "Design time"
        '
        'departmentBindingSource1BindingNavigator
        '
        Me.departmentBindingSource1BindingNavigator.AddNewItem = Me.bindingNavigatorAddNewItem
        Me.departmentBindingSource1BindingNavigator.BindingSource = Me.departmentBindingSource1
        Me.departmentBindingSource1BindingNavigator.CountItem = Me.bindingNavigatorCountItem
        Me.departmentBindingSource1BindingNavigator.DeleteItem = Me.bindingNavigatorDeleteItem
        Me.departmentBindingSource1BindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.bindingNavigatorMoveFirstItem, Me.bindingNavigatorMovePreviousItem, Me.bindingNavigatorSeparator, Me.bindingNavigatorPositionItem, Me.bindingNavigatorCountItem, Me.bindingNavigatorSeparator1, Me.bindingNavigatorMoveNextItem, Me.bindingNavigatorMoveLastItem, Me.bindingNavigatorSeparator2, Me.bindingNavigatorAddNewItem, Me.bindingNavigatorDeleteItem})
        Me.departmentBindingSource1BindingNavigator.Location = New System.Drawing.Point(3, 3)
        Me.departmentBindingSource1BindingNavigator.MoveFirstItem = Me.bindingNavigatorMoveFirstItem
        Me.departmentBindingSource1BindingNavigator.MoveLastItem = Me.bindingNavigatorMoveLastItem
        Me.departmentBindingSource1BindingNavigator.MoveNextItem = Me.bindingNavigatorMoveNextItem
        Me.departmentBindingSource1BindingNavigator.MovePreviousItem = Me.bindingNavigatorMovePreviousItem
        Me.departmentBindingSource1BindingNavigator.Name = "departmentBindingSource1BindingNavigator"
        Me.departmentBindingSource1BindingNavigator.PositionItem = Me.bindingNavigatorPositionItem
        Me.departmentBindingSource1BindingNavigator.Size = New System.Drawing.Size(528, 25)
        Me.departmentBindingSource1BindingNavigator.TabIndex = 9
        Me.departmentBindingSource1BindingNavigator.Text = "bindingNavigator1"
        '
        'tabControl1
        '
        Me.tabControl1.Controls.Add(Me.tabPage1)
        Me.tabControl1.Controls.Add(Me.tabPage2)
        Me.tabControl1.Controls.Add(Me.tabPage3)
        Me.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabControl1.Location = New System.Drawing.Point(0, 0)
        Me.tabControl1.Name = "tabControl1"
        Me.tabControl1.SelectedIndex = 0
        Me.tabControl1.Size = New System.Drawing.Size(542, 416)
        Me.tabControl1.TabIndex = 1
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(542, 416)
        Me.Controls.Add(Me.tabControl1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Creating a Master-Details View"
        Me.splitContainer1.Panel1.ResumeLayout(False)
        Me.splitContainer1.Panel1.PerformLayout()
        Me.splitContainer1.Panel2.ResumeLayout(False)
        Me.splitContainer1.ResumeLayout(False)
        CType(Me.employeeDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPage2.ResumeLayout(False)
        CType(Me.employeeDataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitContainer4.Panel1.ResumeLayout(False)
        Me.splitContainer4.Panel1.PerformLayout()
        Me.splitContainer4.Panel2.ResumeLayout(False)
        Me.splitContainer4.ResumeLayout(False)
        Me.splitContainer3.Panel1.ResumeLayout(False)
        Me.splitContainer3.Panel1.PerformLayout()
        Me.splitContainer3.Panel2.ResumeLayout(False)
        Me.splitContainer3.ResumeLayout(False)
        CType(Me.departmentBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.adventureWorks_DataDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.employeeDataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.employeeBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPage3.ResumeLayout(False)
        Me.tabPage1.ResumeLayout(False)
        Me.tabPage1.PerformLayout()
        CType(Me.departmentBindingSource1BindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.departmentBindingSource1BindingNavigator.ResumeLayout(False)
        Me.departmentBindingSource1BindingNavigator.PerformLayout()
        Me.tabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents bindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents bindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents bindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents departmentIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents splitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents groupNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents nameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents employeeDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents tabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents bindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents bindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents bindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents bindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents bindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents bindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents bindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents employeeDataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents departmentIDTextBox2 As System.Windows.Forms.TextBox
    Friend departmentTableAdapter As CreatingMasterDetails.AdventureWorks_DataDataSetTableAdapters.DepartmentTableAdapter
    Friend employeeTableAdapter1 As CreatingMasterDetails.AdventureWorks_DataDataSetTableAdapters.EmployeeTableAdapter
    Friend employeeTableAdapter As CreatingMasterDetails.AdventureWorks_DataDataSetTableAdapters.EmployeeTableAdapter
    Friend WithEvents splitContainer4 As System.Windows.Forms.SplitContainer
    Friend WithEvents nameTextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents groupNameTextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents splitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents departmentIDTextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents departmentBindingSource1 As System.Windows.Forms.BindingSource
    Friend adventureWorks_DataDataSet As CreatingMasterDetails.AdventureWorks_DataDataSet
    Friend WithEvents groupNameTextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents nameTextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents employeeDataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents dataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents employeeBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents tabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents bindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents tabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents departmentBindingSource1BindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents tabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents EmployeeID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContactID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DepartmentID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ManagerID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Title As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BaseRate As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
