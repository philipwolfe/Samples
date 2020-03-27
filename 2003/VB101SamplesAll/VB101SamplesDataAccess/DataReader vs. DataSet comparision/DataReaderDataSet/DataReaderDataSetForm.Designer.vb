<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class dataReaderDataSetForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dataReaderDataSetForm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.descriptionGroupBox = New System.Windows.Forms.GroupBox
        Me.descriptionLineLabel = New System.Windows.Forms.Label
        Me.testOptionsGroupBox = New System.Windows.Forms.GroupBox
        Me.iterationsListBox = New System.Windows.Forms.NumericUpDown
        Me.dataReaderRadioButton = New System.Windows.Forms.RadioButton
        Me.dataSetRadioButton = New System.Windows.Forms.RadioButton
        Me.rowsToQueryLabel = New System.Windows.Forms.Label
        Me.dataRetrievedGroupBox = New System.Windows.Forms.GroupBox
        Me.integersRadioButton = New System.Windows.Forms.RadioButton
        Me.stringsRadioButton = New System.Windows.Forms.RadioButton
        Me.testDataDataGridView = New System.Windows.Forms.DataGridView
        Me.IntegerDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TestDataDataSet = New DataReaderDataSet.TestDataDataSet
        Me.testResultsGroupBox = New System.Windows.Forms.GroupBox
        Me.elapsedTimeLabel = New System.Windows.Forms.Label
        Me.rowsQueriedLabel = New System.Windows.Forms.Label
        Me.retrieveMethodLabel = New System.Windows.Forms.Label
        Me.runTestButton = New System.Windows.Forms.Button
        Me.IntegerDataTableAdapter = New DataReaderDataSet.TestDataDataSetTableAdapters.IntegerDataTableAdapter
        Me.descriptionGroupBox.SuspendLayout()
        Me.testOptionsGroupBox.SuspendLayout()
        CType(Me.iterationsListBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.dataRetrievedGroupBox.SuspendLayout()
        CType(Me.testDataDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IntegerDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TestDataDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.testResultsGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'descriptionGroupBox
        '
        Me.descriptionGroupBox.Controls.Add(Me.descriptionLineLabel)
        Me.descriptionGroupBox.Location = New System.Drawing.Point(6, 36)
        Me.descriptionGroupBox.Name = "descriptionGroupBox"
        Me.descriptionGroupBox.Size = New System.Drawing.Size(578, 76)
        Me.descriptionGroupBox.TabIndex = 61
        Me.descriptionGroupBox.TabStop = False
        Me.descriptionGroupBox.Text = "Description"
        '
        'descriptionLineLabel
        '
        Me.descriptionLineLabel.AutoSize = True
        Me.descriptionLineLabel.Location = New System.Drawing.Point(6, 16)
        Me.descriptionLineLabel.Name = "descriptionLineLabel"
        Me.descriptionLineLabel.Size = New System.Drawing.Size(515, 39)
        Me.descriptionLineLabel.TabIndex = 1
        Me.descriptionLineLabel.Text = resources.GetString("descriptionLineLabel.Text")
        '
        'testOptionsGroupBox
        '
        Me.testOptionsGroupBox.Controls.Add(Me.iterationsListBox)
        Me.testOptionsGroupBox.Controls.Add(Me.dataReaderRadioButton)
        Me.testOptionsGroupBox.Controls.Add(Me.dataSetRadioButton)
        Me.testOptionsGroupBox.Controls.Add(Me.rowsToQueryLabel)
        Me.testOptionsGroupBox.Location = New System.Drawing.Point(34, 140)
        Me.testOptionsGroupBox.Name = "testOptionsGroupBox"
        Me.testOptionsGroupBox.Size = New System.Drawing.Size(178, 100)
        Me.testOptionsGroupBox.TabIndex = 58
        Me.testOptionsGroupBox.TabStop = False
        Me.testOptionsGroupBox.Text = "Test Options"
        '
        'iterationsListBox
        '
        Me.iterationsListBox.Increment = New Decimal(New Integer() {250, 0, 0, 0})
        Me.iterationsListBox.Location = New System.Drawing.Point(107, 19)
        Me.iterationsListBox.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.iterationsListBox.Minimum = New Decimal(New Integer() {250, 0, 0, 0})
        Me.iterationsListBox.Name = "iterationsListBox"
        Me.iterationsListBox.ReadOnly = True
        Me.iterationsListBox.Size = New System.Drawing.Size(48, 20)
        Me.iterationsListBox.TabIndex = 20
        Me.iterationsListBox.Value = New Decimal(New Integer() {250, 0, 0, 0})
        '
        'dataReaderRadioButton
        '
        Me.dataReaderRadioButton.AutoSize = True
        Me.dataReaderRadioButton.Checked = True
        Me.dataReaderRadioButton.Location = New System.Drawing.Point(23, 46)
        Me.dataReaderRadioButton.Margin = New System.Windows.Forms.Padding(3, 3, 0, 3)
        Me.dataReaderRadioButton.Name = "dataReaderRadioButton"
        Me.dataReaderRadioButton.Size = New System.Drawing.Size(79, 17)
        Me.dataReaderRadioButton.TabIndex = 25
        Me.dataReaderRadioButton.Text = "DataReader"
        '
        'dataSetRadioButton
        '
        Me.dataSetRadioButton.AutoSize = True
        Me.dataSetRadioButton.Location = New System.Drawing.Point(23, 72)
        Me.dataSetRadioButton.Margin = New System.Windows.Forms.Padding(1, 3, 3, 3)
        Me.dataSetRadioButton.Name = "dataSetRadioButton"
        Me.dataSetRadioButton.Size = New System.Drawing.Size(60, 17)
        Me.dataSetRadioButton.TabIndex = 26
        Me.dataSetRadioButton.Text = "DataSet"
        '
        'rowsToQueryLabel
        '
        Me.rowsToQueryLabel.AutoSize = True
        Me.rowsToQueryLabel.Location = New System.Drawing.Point(23, 21)
        Me.rowsToQueryLabel.Name = "rowsToQueryLabel"
        Me.rowsToQueryLabel.Size = New System.Drawing.Size(71, 13)
        Me.rowsToQueryLabel.TabIndex = 31
        Me.rowsToQueryLabel.Text = "Rows to query"
        '
        'dataRetrievedGroupBox
        '
        Me.dataRetrievedGroupBox.Controls.Add(Me.integersRadioButton)
        Me.dataRetrievedGroupBox.Controls.Add(Me.stringsRadioButton)
        Me.dataRetrievedGroupBox.Location = New System.Drawing.Point(415, 140)
        Me.dataRetrievedGroupBox.Name = "dataRetrievedGroupBox"
        Me.dataRetrievedGroupBox.Size = New System.Drawing.Size(131, 42)
        Me.dataRetrievedGroupBox.TabIndex = 60
        Me.dataRetrievedGroupBox.TabStop = False
        Me.dataRetrievedGroupBox.Text = "Data Retreived"
        '
        'integersRadioButton
        '
        Me.integersRadioButton.AutoSize = True
        Me.integersRadioButton.Location = New System.Drawing.Point(64, 19)
        Me.integersRadioButton.Name = "integersRadioButton"
        Me.integersRadioButton.Size = New System.Drawing.Size(59, 17)
        Me.integersRadioButton.TabIndex = 1
        Me.integersRadioButton.Text = "Integers"
        '
        'stringsRadioButton
        '
        Me.stringsRadioButton.AutoSize = True
        Me.stringsRadioButton.Checked = True
        Me.stringsRadioButton.Location = New System.Drawing.Point(6, 19)
        Me.stringsRadioButton.Name = "stringsRadioButton"
        Me.stringsRadioButton.Size = New System.Drawing.Size(53, 17)
        Me.stringsRadioButton.TabIndex = 0
        Me.stringsRadioButton.Text = "Strings"
        '
        'testDataDataGridView
        '
        Me.testDataDataGridView.AllowUserToAddRows = False
        Me.testDataDataGridView.AllowUserToDeleteRows = False
        Me.testDataDataGridView.BackgroundColor = System.Drawing.Color.Lavender
        Me.testDataDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.MidnightBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Lavender
        Me.testDataDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
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
        Me.testDataDataGridView.Location = New System.Drawing.Point(22, 267)
        Me.testDataDataGridView.Name = "testDataDataGridView"
        Me.testDataDataGridView.ReadOnly = True
        Me.testDataDataGridView.RowHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.testDataDataGridView.Size = New System.Drawing.Size(516, 121)
        Me.testDataDataGridView.TabIndex = 57
        '
        'IntegerDataBindingSource
        '
        Me.IntegerDataBindingSource.DataMember = "IntegerData"
        Me.IntegerDataBindingSource.DataSource = Me.TestDataDataSet
        '
        'TestDataDataSet
        '
        Me.TestDataDataSet.DataSetName = "TestDataDataSet"
        '
        'testResultsGroupBox
        '
        Me.testResultsGroupBox.Controls.Add(Me.elapsedTimeLabel)
        Me.testResultsGroupBox.Controls.Add(Me.rowsQueriedLabel)
        Me.testResultsGroupBox.Controls.Add(Me.retrieveMethodLabel)
        Me.testResultsGroupBox.Location = New System.Drawing.Point(219, 140)
        Me.testResultsGroupBox.Name = "testResultsGroupBox"
        Me.testResultsGroupBox.Size = New System.Drawing.Size(189, 100)
        Me.testResultsGroupBox.TabIndex = 59
        Me.testResultsGroupBox.TabStop = False
        Me.testResultsGroupBox.Text = "Test Results"
        '
        'elapsedTimeLabel
        '
        Me.elapsedTimeLabel.AutoSize = True
        Me.elapsedTimeLabel.Location = New System.Drawing.Point(6, 67)
        Me.elapsedTimeLabel.Name = "elapsedTimeLabel"
        Me.elapsedTimeLabel.Size = New System.Drawing.Size(66, 13)
        Me.elapsedTimeLabel.TabIndex = 2
        Me.elapsedTimeLabel.Text = "Elapsed time:"
        '
        'rowsQueriedLabel
        '
        Me.rowsQueriedLabel.AutoSize = True
        Me.rowsQueriedLabel.Location = New System.Drawing.Point(6, 44)
        Me.rowsQueriedLabel.Name = "rowsQueriedLabel"
        Me.rowsQueriedLabel.Size = New System.Drawing.Size(73, 13)
        Me.rowsQueriedLabel.TabIndex = 1
        Me.rowsQueriedLabel.Text = "Rows Queried:"
        '
        'retrieveMethodLabel
        '
        Me.retrieveMethodLabel.AutoSize = True
        Me.retrieveMethodLabel.Location = New System.Drawing.Point(6, 21)
        Me.retrieveMethodLabel.Name = "retrieveMethodLabel"
        Me.retrieveMethodLabel.Size = New System.Drawing.Size(84, 13)
        Me.retrieveMethodLabel.TabIndex = 0
        Me.retrieveMethodLabel.Text = "Retrieve method:"
        '
        'runTestButton
        '
        Me.runTestButton.Location = New System.Drawing.Point(415, 201)
        Me.runTestButton.Margin = New System.Windows.Forms.Padding(3, 3, 3, 2)
        Me.runTestButton.Name = "runTestButton"
        Me.runTestButton.Size = New System.Drawing.Size(130, 31)
        Me.runTestButton.TabIndex = 56
        Me.runTestButton.Text = "Run Test"
        '
        'IntegerDataTableAdapter
        '
        Me.IntegerDataTableAdapter.ClearBeforeFill = True
        '
        'dataReaderDataSetForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(590, 425)
        Me.Controls.Add(Me.descriptionGroupBox)
        Me.Controls.Add(Me.testOptionsGroupBox)
        Me.Controls.Add(Me.dataRetrievedGroupBox)
        Me.Controls.Add(Me.testDataDataGridView)
        Me.Controls.Add(Me.testResultsGroupBox)
        Me.Controls.Add(Me.runTestButton)
        Me.Name = "dataReaderDataSetForm"
        Me.Text = "DataSet vs DataReader"
        Me.descriptionGroupBox.ResumeLayout(False)
        Me.descriptionGroupBox.PerformLayout()
        Me.testOptionsGroupBox.ResumeLayout(False)
        Me.testOptionsGroupBox.PerformLayout()
        CType(Me.iterationsListBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.dataRetrievedGroupBox.ResumeLayout(False)
        Me.dataRetrievedGroupBox.PerformLayout()
        CType(Me.testDataDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IntegerDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TestDataDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.testResultsGroupBox.ResumeLayout(False)
        Me.testResultsGroupBox.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents descriptionGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents testOptionsGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents iterationsListBox As System.Windows.Forms.NumericUpDown
    Friend WithEvents dataReaderRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents dataSetRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents rowsToQueryLabel As System.Windows.Forms.Label
    Friend WithEvents dataRetrievedGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents integersRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents stringsRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents testDataDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents testResultsGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents elapsedTimeLabel As System.Windows.Forms.Label
    Friend WithEvents rowsQueriedLabel As System.Windows.Forms.Label
    Friend WithEvents retrieveMethodLabel As System.Windows.Forms.Label
    Friend WithEvents runTestButton As System.Windows.Forms.Button
    Friend WithEvents TestDataDataSet As DataReaderDataSet.TestDataDataSet
    Friend WithEvents IntegerDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents IntegerDataTableAdapter As DataReaderDataSet.TestDataDataSetTableAdapters.IntegerDataTableAdapter
    Friend WithEvents descriptionLineLabel As System.Windows.Forms.Label

End Class
