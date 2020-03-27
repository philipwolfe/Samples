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
        Dim LastNameLabel As System.Windows.Forms.Label
        Dim FirstNameLabel As System.Windows.Forms.Label
        Dim JobTitleLabel As System.Windows.Forms.Label
        Me.selectButton = New System.Windows.Forms.Button
        Me.VEmployeeTableAdapter = New UsingVBAandVSTOTogether.AdventureWorks_DataDataSetTableAdapters.vEmployeeTableAdapter
        Me.AdventureWorks_DataDataSet = New UsingVBAandVSTOTogether.AdventureWorks_DataDataSet
        Me.VEmployeeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.VEmployeeBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
        Me.LastNameTextBox = New System.Windows.Forms.TextBox
        Me.FirstNameTextBox = New System.Windows.Forms.TextBox
        Me.JobTitleTextBox = New System.Windows.Forms.TextBox
        LastNameLabel = New System.Windows.Forms.Label
        FirstNameLabel = New System.Windows.Forms.Label
        JobTitleLabel = New System.Windows.Forms.Label
        CType(Me.AdventureWorks_DataDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VEmployeeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VEmployeeBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.VEmployeeBindingNavigator.SuspendLayout()
        Me.SuspendLayout()
        '
        'selectButton
        '
        Me.selectButton.Location = New System.Drawing.Point(68, 124)
        Me.selectButton.Name = "selectButton"
        Me.selectButton.Size = New System.Drawing.Size(75, 23)
        Me.selectButton.TabIndex = 15
        Me.selectButton.Text = "Select"
        Me.selectButton.UseVisualStyleBackColor = True
        '
        'VEmployeeTableAdapter
        '
        Me.VEmployeeTableAdapter.ClearBeforeFill = True
        '
        'AdventureWorks_DataDataSet
        '
        Me.AdventureWorks_DataDataSet.DataSetName = "AdventureWorks_DataDataSet"
        Me.AdventureWorks_DataDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'VEmployeeBindingSource
        '
        Me.VEmployeeBindingSource.DataMember = "vEmployee"
        Me.VEmployeeBindingSource.DataSource = Me.AdventureWorks_DataDataSet
        '
        'VEmployeeBindingNavigator
        '
        Me.VEmployeeBindingNavigator.AddNewItem = Nothing
        Me.VEmployeeBindingNavigator.BindingSource = Me.VEmployeeBindingSource
        Me.VEmployeeBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.VEmployeeBindingNavigator.DeleteItem = Nothing
        Me.VEmployeeBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem})
        Me.VEmployeeBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.VEmployeeBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.VEmployeeBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.VEmployeeBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.VEmployeeBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.VEmployeeBindingNavigator.Name = "VEmployeeBindingNavigator"
        Me.VEmployeeBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.VEmployeeBindingNavigator.Size = New System.Drawing.Size(211, 25)
        Me.VEmployeeBindingNavigator.TabIndex = 16
        Me.VEmployeeBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 20)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(34, 22)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'LastNameLabel
        '
        LastNameLabel.AutoSize = True
        LastNameLabel.Location = New System.Drawing.Point(11, 31)
        LastNameLabel.Name = "LastNameLabel"
        LastNameLabel.Size = New System.Drawing.Size(61, 13)
        LastNameLabel.TabIndex = 16
        LastNameLabel.Text = "Last Name:"
        '
        'LastNameTextBox
        '
        Me.LastNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.VEmployeeBindingSource, "LastName", True))
        Me.LastNameTextBox.Location = New System.Drawing.Point(78, 28)
        Me.LastNameTextBox.Name = "LastNameTextBox"
        Me.LastNameTextBox.Size = New System.Drawing.Size(121, 20)
        Me.LastNameTextBox.TabIndex = 17
        '
        'FirstNameLabel
        '
        FirstNameLabel.AutoSize = True
        FirstNameLabel.Location = New System.Drawing.Point(12, 61)
        FirstNameLabel.Name = "FirstNameLabel"
        FirstNameLabel.Size = New System.Drawing.Size(60, 13)
        FirstNameLabel.TabIndex = 17
        FirstNameLabel.Text = "First Name:"
        '
        'FirstNameTextBox
        '
        Me.FirstNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.VEmployeeBindingSource, "FirstName", True))
        Me.FirstNameTextBox.Location = New System.Drawing.Point(78, 58)
        Me.FirstNameTextBox.Name = "FirstNameTextBox"
        Me.FirstNameTextBox.Size = New System.Drawing.Size(121, 20)
        Me.FirstNameTextBox.TabIndex = 18
        '
        'JobTitleLabel
        '
        JobTitleLabel.AutoSize = True
        JobTitleLabel.Location = New System.Drawing.Point(22, 92)
        JobTitleLabel.Name = "JobTitleLabel"
        JobTitleLabel.Size = New System.Drawing.Size(50, 13)
        JobTitleLabel.TabIndex = 18
        JobTitleLabel.Text = "Job Title:"
        '
        'JobTitleTextBox
        '
        Me.JobTitleTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.VEmployeeBindingSource, "JobTitle", True))
        Me.JobTitleTextBox.Location = New System.Drawing.Point(78, 89)
        Me.JobTitleTextBox.Name = "JobTitleTextBox"
        Me.JobTitleTextBox.Size = New System.Drawing.Size(121, 20)
        Me.JobTitleTextBox.TabIndex = 19
        '
        'EmployeeSelectorUserControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(JobTitleLabel)
        Me.Controls.Add(Me.JobTitleTextBox)
        Me.Controls.Add(FirstNameLabel)
        Me.Controls.Add(Me.FirstNameTextBox)
        Me.Controls.Add(LastNameLabel)
        Me.Controls.Add(Me.LastNameTextBox)
        Me.Controls.Add(Me.VEmployeeBindingNavigator)
        Me.Controls.Add(Me.selectButton)
        Me.Name = "EmployeeSelectorUserControl"
        Me.Size = New System.Drawing.Size(211, 167)
        CType(Me.AdventureWorks_DataDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VEmployeeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VEmployeeBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.VEmployeeBindingNavigator.ResumeLayout(False)
        Me.VEmployeeBindingNavigator.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents selectButton As System.Windows.Forms.Button
    Friend WithEvents VEmployeeTableAdapter As UsingVBAandVSTOTogether.AdventureWorks_DataDataSetTableAdapters.vEmployeeTableAdapter
    Friend WithEvents AdventureWorks_DataDataSet As UsingVBAandVSTOTogether.AdventureWorks_DataDataSet
    Friend WithEvents VEmployeeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VEmployeeBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents LastNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents FirstNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents JobTitleTextBox As System.Windows.Forms.TextBox

End Class
