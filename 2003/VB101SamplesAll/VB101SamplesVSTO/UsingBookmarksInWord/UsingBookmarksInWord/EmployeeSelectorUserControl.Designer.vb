<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmployeeSelectorUserControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmployeeSelectorUserControl))
        Dim jobTitleLabel As System.Windows.Forms.Label
        Dim firstNameLabel As System.Windows.Forms.Label
        Dim lastNameLabel As System.Windows.Forms.Label
        Me.firstNameTextBox = New System.Windows.Forms.TextBox
        Me.vEmployeeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.adventureWorks_DataDataSet = New UsingBookmarksInWord.AdventureWorks_DataDataSet
        Me.selectButton = New System.Windows.Forms.Button
        Me.bindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
        Me.bindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
        Me.bindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
        Me.bindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.bindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
        Me.bindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.jobTitleTextBox = New System.Windows.Forms.TextBox
        Me.bindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
        Me.bindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
        Me.vEmployeeBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.lastNameTextBox = New System.Windows.Forms.TextBox
        Me.vEmployeeTableAdapter = New UsingBookmarksInWord.AdventureWorks_DataDataSetTableAdapters.vEmployeeTableAdapter
        jobTitleLabel = New System.Windows.Forms.Label
        firstNameLabel = New System.Windows.Forms.Label
        lastNameLabel = New System.Windows.Forms.Label
        CType(Me.vEmployeeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.adventureWorks_DataDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vEmployeeBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.vEmployeeBindingNavigator.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'firstNameTextBox
        '
        Me.firstNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.firstNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.vEmployeeBindingSource, "FirstName", True))
        Me.firstNameTextBox.Location = New System.Drawing.Point(87, 52)
        Me.firstNameTextBox.Name = "firstNameTextBox"
        Me.firstNameTextBox.ReadOnly = True
        Me.firstNameTextBox.Size = New System.Drawing.Size(100, 20)
        Me.firstNameTextBox.TabIndex = 3
        '
        'vEmployeeBindingSource
        '
        Me.vEmployeeBindingSource.DataMember = "vEmployee"
        Me.vEmployeeBindingSource.DataSource = Me.adventureWorks_DataDataSet
        '
        'adventureWorks_DataDataSet
        '
        Me.adventureWorks_DataDataSet.DataSetName = "AdventureWorks_DataDataSet"
        Me.adventureWorks_DataDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'selectButton
        '
        Me.selectButton.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.selectButton.Location = New System.Drawing.Point(67, 104)
        Me.selectButton.Name = "selectButton"
        Me.selectButton.Size = New System.Drawing.Size(75, 23)
        Me.selectButton.TabIndex = 4
        Me.selectButton.Text = "Select"
        Me.selectButton.UseVisualStyleBackColor = True
        '
        'bindingNavigatorPositionItem
        '
        Me.bindingNavigatorPositionItem.AccessibleName = "Position"
        Me.bindingNavigatorPositionItem.AutoSize = False
        Me.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem"
        Me.bindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 20)
        Me.bindingNavigatorPositionItem.Text = "0"
        Me.bindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'bindingNavigatorMoveFirstItem
        '
        Me.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.bindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("bindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem"
        Me.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.bindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.bindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'bindingNavigatorMovePreviousItem
        '
        Me.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.bindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("bindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem"
        Me.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.bindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.bindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'bindingNavigatorSeparator
        '
        Me.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator"
        Me.bindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'jobTitleLabel
        '
        jobTitleLabel.Anchor = System.Windows.Forms.AnchorStyles.Top
        jobTitleLabel.AutoSize = True
        jobTitleLabel.Location = New System.Drawing.Point(31, 81)
        jobTitleLabel.Name = "jobTitleLabel"
        jobTitleLabel.Size = New System.Drawing.Size(50, 13)
        jobTitleLabel.TabIndex = 5
        jobTitleLabel.Text = "Job Title:"
        '
        'firstNameLabel
        '
        firstNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Top
        firstNameLabel.AutoSize = True
        firstNameLabel.Location = New System.Drawing.Point(21, 55)
        firstNameLabel.Name = "firstNameLabel"
        firstNameLabel.Size = New System.Drawing.Size(60, 13)
        firstNameLabel.TabIndex = 2
        firstNameLabel.Text = "First Name:"
        '
        'bindingNavigatorMoveLastItem
        '
        Me.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.bindingNavigatorMoveLastItem.Image = CType(resources.GetObject("bindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem"
        Me.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.bindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.bindingNavigatorMoveLastItem.Text = "Move last"
        '
        'bindingNavigatorSeparator1
        '
        Me.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1"
        Me.bindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'jobTitleTextBox
        '
        Me.jobTitleTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.jobTitleTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.vEmployeeBindingSource, "JobTitle", True))
        Me.jobTitleTextBox.Location = New System.Drawing.Point(87, 78)
        Me.jobTitleTextBox.Name = "jobTitleTextBox"
        Me.jobTitleTextBox.ReadOnly = True
        Me.jobTitleTextBox.Size = New System.Drawing.Size(100, 20)
        Me.jobTitleTextBox.TabIndex = 6
        '
        'bindingNavigatorMoveNextItem
        '
        Me.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.bindingNavigatorMoveNextItem.Image = CType(resources.GetObject("bindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem"
        Me.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.bindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.bindingNavigatorMoveNextItem.Text = "Move next"
        '
        'bindingNavigatorCountItem
        '
        Me.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem"
        Me.bindingNavigatorCountItem.Size = New System.Drawing.Size(34, 22)
        Me.bindingNavigatorCountItem.Text = "of {0}"
        Me.bindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'lastNameLabel
        '
        lastNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Top
        lastNameLabel.AutoSize = True
        lastNameLabel.Location = New System.Drawing.Point(20, 29)
        lastNameLabel.Name = "lastNameLabel"
        lastNameLabel.Size = New System.Drawing.Size(61, 13)
        lastNameLabel.TabIndex = 0
        lastNameLabel.Text = "Last Name:"
        '
        'vEmployeeBindingNavigator
        '
        Me.vEmployeeBindingNavigator.AddNewItem = Nothing
        Me.vEmployeeBindingNavigator.BindingSource = Me.vEmployeeBindingSource
        Me.vEmployeeBindingNavigator.CountItem = Me.bindingNavigatorCountItem
        Me.vEmployeeBindingNavigator.DeleteItem = Nothing
        Me.vEmployeeBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.bindingNavigatorMoveFirstItem, Me.bindingNavigatorMovePreviousItem, Me.bindingNavigatorSeparator, Me.bindingNavigatorPositionItem, Me.bindingNavigatorCountItem, Me.bindingNavigatorSeparator1, Me.bindingNavigatorMoveNextItem, Me.bindingNavigatorMoveLastItem})
        Me.vEmployeeBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.vEmployeeBindingNavigator.MoveFirstItem = Me.bindingNavigatorMoveFirstItem
        Me.vEmployeeBindingNavigator.MoveLastItem = Me.bindingNavigatorMoveLastItem
        Me.vEmployeeBindingNavigator.MoveNextItem = Me.bindingNavigatorMoveNextItem
        Me.vEmployeeBindingNavigator.MovePreviousItem = Me.bindingNavigatorMovePreviousItem
        Me.vEmployeeBindingNavigator.Name = "vEmployeeBindingNavigator"
        Me.vEmployeeBindingNavigator.PositionItem = Me.bindingNavigatorPositionItem
        Me.vEmployeeBindingNavigator.Size = New System.Drawing.Size(208, 25)
        Me.vEmployeeBindingNavigator.TabIndex = 3
        Me.vEmployeeBindingNavigator.Text = "bindingNavigator1"
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(jobTitleLabel)
        Me.groupBox1.Controls.Add(Me.jobTitleTextBox)
        Me.groupBox1.Controls.Add(Me.selectButton)
        Me.groupBox1.Controls.Add(firstNameLabel)
        Me.groupBox1.Controls.Add(Me.firstNameTextBox)
        Me.groupBox1.Controls.Add(lastNameLabel)
        Me.groupBox1.Controls.Add(Me.lastNameTextBox)
        Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.groupBox1.Location = New System.Drawing.Point(0, 30)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(208, 138)
        Me.groupBox1.TabIndex = 2
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Select an employee"
        '
        'lastNameTextBox
        '
        Me.lastNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lastNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.vEmployeeBindingSource, "LastName", True))
        Me.lastNameTextBox.Location = New System.Drawing.Point(87, 26)
        Me.lastNameTextBox.Name = "lastNameTextBox"
        Me.lastNameTextBox.ReadOnly = True
        Me.lastNameTextBox.Size = New System.Drawing.Size(100, 20)
        Me.lastNameTextBox.TabIndex = 1
        '
        'vEmployeeTableAdapter
        '
        Me.vEmployeeTableAdapter.ClearBeforeFill = True
        '
        'EmployeeSelectorUserControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.vEmployeeBindingNavigator)
        Me.Controls.Add(Me.groupBox1)
        Me.Name = "EmployeeSelectorUserControl"
        Me.Size = New System.Drawing.Size(208, 168)
        CType(Me.vEmployeeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.adventureWorks_DataDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vEmployeeBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.vEmployeeBindingNavigator.ResumeLayout(False)
        Me.vEmployeeBindingNavigator.PerformLayout()
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents firstNameTextBox As System.Windows.Forms.TextBox
    Private WithEvents vEmployeeBindingSource As System.Windows.Forms.BindingSource
    Private WithEvents adventureWorks_DataDataSet As UsingBookmarksInWord.AdventureWorks_DataDataSet
    Public WithEvents selectButton As System.Windows.Forms.Button
    Private WithEvents bindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Private WithEvents bindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Private WithEvents bindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Private WithEvents bindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Private WithEvents bindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Private WithEvents bindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents jobTitleTextBox As System.Windows.Forms.TextBox
    Private WithEvents bindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Private WithEvents bindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Private WithEvents vEmployeeBindingNavigator As System.Windows.Forms.BindingNavigator
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents lastNameTextBox As System.Windows.Forms.TextBox
    Private WithEvents vEmployeeTableAdapter As UsingBookmarksInWord.AdventureWorks_DataDataSetTableAdapters.vEmployeeTableAdapter

End Class
