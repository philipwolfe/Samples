<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class attachDBFileNameForm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(attachDBFileNameForm))
        Me.TestDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PerfTestDataSet = New AttachDBFileName.PerfTestDataSet
        Me.TestDataTableAdapter = New AttachDBFileName.PerfTestDataSetTableAdapters.TestDataTableAdapter
        Me.insertedRowsGroupBox = New System.Windows.Forms.GroupBox
        Me.testDataDataGridView = New System.Windows.Forms.DataGridView
        Me.firstValueDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.secondValueDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.descriptionGroupBox = New System.Windows.Forms.GroupBox
        Me.descriptionLineLabel = New System.Windows.Forms.Label
        Me.runTestButton = New System.Windows.Forms.Button
        Me.testResultsGroupBox = New System.Windows.Forms.GroupBox
        Me.elapsedTimeLabel = New System.Windows.Forms.Label
        Me.rowsAddedLabel = New System.Windows.Forms.Label
        Me.insertMethodLabel = New System.Windows.Forms.Label
        Me.testOptionsGroupBox = New System.Windows.Forms.GroupBox
        Me.iterationListBox = New System.Windows.Forms.NumericUpDown
        Me.storedProcedureRadioButton = New System.Windows.Forms.RadioButton
        Me.sqlQueryRadioButton = New System.Windows.Forms.RadioButton
        Me.rowsToAddLabel = New System.Windows.Forms.Label
        Me.attachedDatabaseGroupBox = New System.Windows.Forms.GroupBox
        Me.db2RadioButton = New System.Windows.Forms.RadioButton
        Me.db1RadioButton = New System.Windows.Forms.RadioButton
        CType(Me.TestDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PerfTestDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.insertedRowsGroupBox.SuspendLayout()
        CType(Me.testDataDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.descriptionGroupBox.SuspendLayout()
        Me.testResultsGroupBox.SuspendLayout()
        Me.testOptionsGroupBox.SuspendLayout()
        CType(Me.iterationListBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.attachedDatabaseGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'TestDataBindingSource
        '
        Me.TestDataBindingSource.DataMember = "TestData"
        Me.TestDataBindingSource.DataSource = Me.PerfTestDataSet
        '
        'PerfTestDataSet
        '
        Me.PerfTestDataSet.DataSetName = "PerfTestDataSet"
        '
        'TestDataTableAdapter
        '
        Me.TestDataTableAdapter.ClearBeforeFill = True
        '
        'insertedRowsGroupBox
        '
        Me.insertedRowsGroupBox.Controls.Add(Me.testDataDataGridView)
        Me.insertedRowsGroupBox.Location = New System.Drawing.Point(11, 225)
        Me.insertedRowsGroupBox.Name = "insertedRowsGroupBox"
        Me.insertedRowsGroupBox.Size = New System.Drawing.Size(402, 151)
        Me.insertedRowsGroupBox.TabIndex = 56
        Me.insertedRowsGroupBox.TabStop = False
        Me.insertedRowsGroupBox.Text = "Inserted Rows"
        '
        'testDataDataGridView
        '
        Me.testDataDataGridView.AllowUserToAddRows = False
        Me.testDataDataGridView.AllowUserToDeleteRows = False
        Me.testDataDataGridView.AutoGenerateColumns = False
        Me.testDataDataGridView.BackgroundColor = System.Drawing.Color.Lavender
        Me.testDataDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.MidnightBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Lavender
        Me.testDataDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.testDataDataGridView.Columns.Add(Me.firstValueDataGridViewTextBoxColumn)
        Me.testDataDataGridView.Columns.Add(Me.secondValueDataGridViewTextBoxColumn)
        Me.testDataDataGridView.Columns.Add(Me.dataGridViewTextBoxColumn1)
        Me.testDataDataGridView.DataSource = Me.TestDataBindingSource
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.MidnightBlue
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.testDataDataGridView.DefaultCellStyle = DataGridViewCellStyle2
        Me.testDataDataGridView.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.testDataDataGridView.GridColor = System.Drawing.Color.RoyalBlue
        Me.testDataDataGridView.Location = New System.Drawing.Point(7, 19)
        Me.testDataDataGridView.Name = "testDataDataGridView"
        Me.testDataDataGridView.ReadOnly = True
        Me.testDataDataGridView.RowHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.testDataDataGridView.Size = New System.Drawing.Size(375, 121)
        Me.testDataDataGridView.TabIndex = 45
        '
        'firstValueDataGridViewTextBoxColumn
        '
        Me.firstValueDataGridViewTextBoxColumn.DataPropertyName = "firstValue"
        Me.firstValueDataGridViewTextBoxColumn.HeaderText = "firstValue"
        Me.firstValueDataGridViewTextBoxColumn.Name = "firstValue"
        Me.firstValueDataGridViewTextBoxColumn.ReadOnly = True
        '
        'secondValueDataGridViewTextBoxColumn
        '
        Me.secondValueDataGridViewTextBoxColumn.DataPropertyName = "secondValue"
        Me.secondValueDataGridViewTextBoxColumn.HeaderText = "secondValue"
        Me.secondValueDataGridViewTextBoxColumn.Name = "secondValue"
        Me.secondValueDataGridViewTextBoxColumn.ReadOnly = True
        '
        'dataGridViewTextBoxColumn1
        '
        Me.dataGridViewTextBoxColumn1.DataPropertyName = "timeStamp"
        Me.dataGridViewTextBoxColumn1.HeaderText = "timeStamp"
        Me.dataGridViewTextBoxColumn1.Name = "timeStamp"
        Me.dataGridViewTextBoxColumn1.ReadOnly = True
        '
        'descriptionGroupBox
        '
        Me.descriptionGroupBox.Controls.Add(Me.descriptionLineLabel)
        Me.descriptionGroupBox.Location = New System.Drawing.Point(13, 3)
        Me.descriptionGroupBox.Name = "descriptionGroupBox"
        Me.descriptionGroupBox.Size = New System.Drawing.Size(578, 76)
        Me.descriptionGroupBox.TabIndex = 55
        Me.descriptionGroupBox.TabStop = False
        Me.descriptionGroupBox.Text = "Description"
        '
        'descriptionLineLabel
        '
        Me.descriptionLineLabel.AutoSize = True
        Me.descriptionLineLabel.Location = New System.Drawing.Point(6, 16)
        Me.descriptionLineLabel.Name = "descriptionLineLabel"
        Me.descriptionLineLabel.Size = New System.Drawing.Size(454, 52)
        Me.descriptionLineLabel.TabIndex = 0
        Me.descriptionLineLabel.Text = resources.GetString("descriptionLineLabel.Text")
        '
        'runTestButton
        '
        Me.runTestButton.Location = New System.Drawing.Point(221, 162)
        Me.runTestButton.Margin = New System.Windows.Forms.Padding(3, 3, 3, 2)
        Me.runTestButton.Name = "runTestButton"
        Me.runTestButton.Size = New System.Drawing.Size(130, 31)
        Me.runTestButton.TabIndex = 51
        Me.runTestButton.Text = "Run Test"
        '
        'testResultsGroupBox
        '
        Me.testResultsGroupBox.Controls.Add(Me.elapsedTimeLabel)
        Me.testResultsGroupBox.Controls.Add(Me.rowsAddedLabel)
        Me.testResultsGroupBox.Controls.Add(Me.insertMethodLabel)
        Me.testResultsGroupBox.Location = New System.Drawing.Point(402, 101)
        Me.testResultsGroupBox.Name = "testResultsGroupBox"
        Me.testResultsGroupBox.Size = New System.Drawing.Size(189, 100)
        Me.testResultsGroupBox.TabIndex = 53
        Me.testResultsGroupBox.TabStop = False
        Me.testResultsGroupBox.Text = "Test Results"
        '
        'elapsedTimeLabel
        '
        Me.elapsedTimeLabel.AutoSize = True
        Me.elapsedTimeLabel.Location = New System.Drawing.Point(17, 70)
        Me.elapsedTimeLabel.Name = "elapsedTimeLabel"
        Me.elapsedTimeLabel.Size = New System.Drawing.Size(66, 13)
        Me.elapsedTimeLabel.TabIndex = 2
        Me.elapsedTimeLabel.Text = "Elapsed time:"
        '
        'rowsAddedLabel
        '
        Me.rowsAddedLabel.AutoSize = True
        Me.rowsAddedLabel.Location = New System.Drawing.Point(17, 47)
        Me.rowsAddedLabel.Name = "rowsAddedLabel"
        Me.rowsAddedLabel.Size = New System.Drawing.Size(66, 13)
        Me.rowsAddedLabel.TabIndex = 1
        Me.rowsAddedLabel.Text = "Rows added:"
        '
        'insertMethodLabel
        '
        Me.insertMethodLabel.AutoSize = True
        Me.insertMethodLabel.Location = New System.Drawing.Point(17, 24)
        Me.insertMethodLabel.Name = "insertMethodLabel"
        Me.insertMethodLabel.Size = New System.Drawing.Size(70, 13)
        Me.insertMethodLabel.TabIndex = 0
        Me.insertMethodLabel.Text = "Insert method:"
        '
        'testOptionsGroupBox
        '
        Me.testOptionsGroupBox.Controls.Add(Me.iterationListBox)
        Me.testOptionsGroupBox.Controls.Add(Me.storedProcedureRadioButton)
        Me.testOptionsGroupBox.Controls.Add(Me.sqlQueryRadioButton)
        Me.testOptionsGroupBox.Controls.Add(Me.rowsToAddLabel)
        Me.testOptionsGroupBox.Location = New System.Drawing.Point(13, 101)
        Me.testOptionsGroupBox.Name = "testOptionsGroupBox"
        Me.testOptionsGroupBox.Size = New System.Drawing.Size(178, 100)
        Me.testOptionsGroupBox.TabIndex = 52
        Me.testOptionsGroupBox.TabStop = False
        Me.testOptionsGroupBox.Text = "Test Options"
        '
        'iterationListBox
        '
        Me.iterationListBox.Increment = New Decimal(New Integer() {250, 0, 0, 0})
        Me.iterationListBox.Location = New System.Drawing.Point(109, 24)
        Me.iterationListBox.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.iterationListBox.Minimum = New Decimal(New Integer() {250, 0, 0, 0})
        Me.iterationListBox.Name = "iterationListBox"
        Me.iterationListBox.ReadOnly = True
        Me.iterationListBox.Size = New System.Drawing.Size(48, 20)
        Me.iterationListBox.TabIndex = 20
        Me.iterationListBox.Value = New Decimal(New Integer() {250, 0, 0, 0})
        '
        'storedProcedureRadioButton
        '
        Me.storedProcedureRadioButton.AutoSize = True
        Me.storedProcedureRadioButton.Checked = True
        Me.storedProcedureRadioButton.Location = New System.Drawing.Point(25, 51)
        Me.storedProcedureRadioButton.Margin = New System.Windows.Forms.Padding(3, 3, 0, 3)
        Me.storedProcedureRadioButton.Name = "storedProcedureRadioButton"
        Me.storedProcedureRadioButton.Size = New System.Drawing.Size(103, 17)
        Me.storedProcedureRadioButton.TabIndex = 25
        Me.storedProcedureRadioButton.Text = "Stored procedure"
        '
        'sqlQueryRadioButton
        '
        Me.sqlQueryRadioButton.AutoSize = True
        Me.sqlQueryRadioButton.Location = New System.Drawing.Point(25, 77)
        Me.sqlQueryRadioButton.Margin = New System.Windows.Forms.Padding(1, 3, 3, 3)
        Me.sqlQueryRadioButton.Name = "sqlQueryRadioButton"
        Me.sqlQueryRadioButton.Size = New System.Drawing.Size(100, 17)
        Me.sqlQueryRadioButton.TabIndex = 26
        Me.sqlQueryRadioButton.Text = "SQL Insert query"
        '
        'rowsToAddLabel
        '
        Me.rowsToAddLabel.AutoSize = True
        Me.rowsToAddLabel.Location = New System.Drawing.Point(25, 26)
        Me.rowsToAddLabel.Name = "rowsToAddLabel"
        Me.rowsToAddLabel.Size = New System.Drawing.Size(63, 13)
        Me.rowsToAddLabel.TabIndex = 31
        Me.rowsToAddLabel.Text = "Rows to add"
        '
        'attachedDatabaseGroupBox
        '
        Me.attachedDatabaseGroupBox.Controls.Add(Me.db2RadioButton)
        Me.attachedDatabaseGroupBox.Controls.Add(Me.db1RadioButton)
        Me.attachedDatabaseGroupBox.Location = New System.Drawing.Point(221, 101)
        Me.attachedDatabaseGroupBox.Name = "attachedDatabaseGroupBox"
        Me.attachedDatabaseGroupBox.Size = New System.Drawing.Size(131, 44)
        Me.attachedDatabaseGroupBox.TabIndex = 54
        Me.attachedDatabaseGroupBox.TabStop = False
        Me.attachedDatabaseGroupBox.Text = "Attached Database"
        '
        'db2RadioButton
        '
        Me.db2RadioButton.AutoSize = True
        Me.db2RadioButton.Location = New System.Drawing.Point(70, 20)
        Me.db2RadioButton.Name = "db2RadioButton"
        Me.db2RadioButton.Size = New System.Drawing.Size(42, 17)
        Me.db2RadioButton.TabIndex = 1
        Me.db2RadioButton.Text = "DB2"
        '
        'db1RadioButton
        '
        Me.db1RadioButton.AutoSize = True
        Me.db1RadioButton.Checked = True
        Me.db1RadioButton.Location = New System.Drawing.Point(21, 20)
        Me.db1RadioButton.Name = "db1RadioButton"
        Me.db1RadioButton.Size = New System.Drawing.Size(42, 17)
        Me.db1RadioButton.TabIndex = 0
        Me.db1RadioButton.Text = "DB1"
        '
        'attachDBFileNameForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(602, 379)
        Me.Controls.Add(Me.insertedRowsGroupBox)
        Me.Controls.Add(Me.descriptionGroupBox)
        Me.Controls.Add(Me.runTestButton)
        Me.Controls.Add(Me.testResultsGroupBox)
        Me.Controls.Add(Me.testOptionsGroupBox)
        Me.Controls.Add(Me.attachedDatabaseGroupBox)
        Me.Name = "attachDBFileNameForm"
        Me.Text = "Attach Database File Name Example"
        CType(Me.TestDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PerfTestDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.insertedRowsGroupBox.ResumeLayout(False)
        CType(Me.testDataDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.descriptionGroupBox.ResumeLayout(False)
        Me.descriptionGroupBox.PerformLayout()
        Me.testResultsGroupBox.ResumeLayout(False)
        Me.testResultsGroupBox.PerformLayout()
        Me.testOptionsGroupBox.ResumeLayout(False)
        Me.testOptionsGroupBox.PerformLayout()
        CType(Me.iterationListBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.attachedDatabaseGroupBox.ResumeLayout(False)
        Me.attachedDatabaseGroupBox.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PerfTestDataSet As AttachDBFileName.PerfTestDataSet
    Friend WithEvents TestDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TestDataTableAdapter As AttachDBFileName.PerfTestDataSetTableAdapters.TestDataTableAdapter
    Friend WithEvents insertedRowsGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents testDataDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents firstValueDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents secondValueDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descriptionGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents descriptionLineLabel As System.Windows.Forms.Label
    Friend WithEvents runTestButton As System.Windows.Forms.Button
    Friend WithEvents testResultsGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents elapsedTimeLabel As System.Windows.Forms.Label
    Friend WithEvents rowsAddedLabel As System.Windows.Forms.Label
    Friend WithEvents insertMethodLabel As System.Windows.Forms.Label
    Friend WithEvents testOptionsGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents iterationListBox As System.Windows.Forms.NumericUpDown
    Friend WithEvents storedProcedureRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents sqlQueryRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents rowsToAddLabel As System.Windows.Forms.Label
    Friend WithEvents attachedDatabaseGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents db2RadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents db1RadioButton As System.Windows.Forms.RadioButton

End Class
