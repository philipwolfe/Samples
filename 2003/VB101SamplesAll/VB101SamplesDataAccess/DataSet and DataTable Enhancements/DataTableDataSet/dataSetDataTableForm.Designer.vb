<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class dataSetDataTableForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dataSetDataTableForm))
        Me.xmlResultsDataGridView = New System.Windows.Forms.DataGridView
        Me.xmlReadButton = New System.Windows.Forms.Button
        Me.xmlWriteButton = New System.Windows.Forms.Button
        Me.dataViewsTabPage = New System.Windows.Forms.TabPage
        Me.testResultsDataViewGroupBox = New System.Windows.Forms.GroupBox
        Me.rowsReturnedTimeLabel = New System.Windows.Forms.Label
        Me.rowsReturnedLabel = New System.Windows.Forms.Label
        Me.dataViewDataGridView = New System.Windows.Forms.DataGridView
        Me.dataViewShowDataViewButton = New System.Windows.Forms.Button
        Me.dataViewShowDataSetButton = New System.Windows.Forms.Button
        Me.readWriteTimeLabel = New System.Windows.Forms.Label
        Me.rowsReadWrittenLabel = New System.Windows.Forms.Label
        Me.testResultsPerformanceGroupBox = New System.Windows.Forms.GroupBox
        Me.elapsedTimeLabel = New System.Windows.Forms.Label
        Me.rowsInsertedLabel = New System.Windows.Forms.Label
        Me.dataTableDataSetTabControl = New System.Windows.Forms.TabControl
        Me.performanceTabPage = New System.Windows.Forms.TabPage
        Me.resultsDataGridView = New System.Windows.Forms.DataGridView
        Me.performanceShowRowsButton = New System.Windows.Forms.Button
        Me.performanceAddRowsButton = New System.Windows.Forms.Button
        Me.readWriteXMLTabPage = New System.Windows.Forms.TabPage
        Me.testResultsXMLGroupBox = New System.Windows.Forms.GroupBox
        Me.descriptionXMLGroupBox = New System.Windows.Forms.GroupBox
        Me.descriptionLineXMLLabel = New System.Windows.Forms.Label
        Me.descriptionPerformanceGroupBox = New System.Windows.Forms.GroupBox
        Me.descriptionLineLabel = New System.Windows.Forms.Label
        Me.descriptionDataViewGroupBox = New System.Windows.Forms.GroupBox
        Me.descriptionDataViewLabel = New System.Windows.Forms.Label
        CType(Me.xmlResultsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.dataViewsTabPage.SuspendLayout()
        Me.testResultsDataViewGroupBox.SuspendLayout()
        CType(Me.dataViewDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.testResultsPerformanceGroupBox.SuspendLayout()
        Me.dataTableDataSetTabControl.SuspendLayout()
        Me.performanceTabPage.SuspendLayout()
        CType(Me.resultsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.readWriteXMLTabPage.SuspendLayout()
        Me.testResultsXMLGroupBox.SuspendLayout()
        Me.descriptionXMLGroupBox.SuspendLayout()
        Me.descriptionPerformanceGroupBox.SuspendLayout()
        Me.descriptionDataViewGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'xmlResultsDataGridView
        '
        Me.xmlResultsDataGridView.Location = New System.Drawing.Point(29, 199)
        Me.xmlResultsDataGridView.Name = "xmlResultsDataGridView"
        Me.xmlResultsDataGridView.Size = New System.Drawing.Size(316, 150)
        Me.xmlResultsDataGridView.TabIndex = 8
        Me.xmlResultsDataGridView.Text = "dataGridView2"
        '
        'xmlReadButton
        '
        Me.xmlReadButton.Location = New System.Drawing.Point(270, 156)
        Me.xmlReadButton.Name = "xmlReadButton"
        Me.xmlReadButton.Size = New System.Drawing.Size(75, 23)
        Me.xmlReadButton.TabIndex = 7
        Me.xmlReadButton.Text = "Read XML"
        '
        'xmlWriteButton
        '
        Me.xmlWriteButton.Location = New System.Drawing.Point(270, 110)
        Me.xmlWriteButton.Name = "xmlWriteButton"
        Me.xmlWriteButton.Size = New System.Drawing.Size(75, 23)
        Me.xmlWriteButton.TabIndex = 6
        Me.xmlWriteButton.Text = "Write XML"
        '
        'dataViewsTabPage
        '
        Me.dataViewsTabPage.Controls.Add(Me.descriptionDataViewGroupBox)
        Me.dataViewsTabPage.Controls.Add(Me.testResultsDataViewGroupBox)
        Me.dataViewsTabPage.Controls.Add(Me.dataViewDataGridView)
        Me.dataViewsTabPage.Controls.Add(Me.dataViewShowDataViewButton)
        Me.dataViewsTabPage.Controls.Add(Me.dataViewShowDataSetButton)
        Me.dataViewsTabPage.Location = New System.Drawing.Point(4, 22)
        Me.dataViewsTabPage.Name = "dataViewsTabPage"
        Me.dataViewsTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.dataViewsTabPage.Size = New System.Drawing.Size(361, 362)
        Me.dataViewsTabPage.TabIndex = 2
        Me.dataViewsTabPage.Text = "Data Views"
        '
        'testResultsDataViewGroupBox
        '
        Me.testResultsDataViewGroupBox.Controls.Add(Me.rowsReturnedTimeLabel)
        Me.testResultsDataViewGroupBox.Controls.Add(Me.rowsReturnedLabel)
        Me.testResultsDataViewGroupBox.Location = New System.Drawing.Point(29, 110)
        Me.testResultsDataViewGroupBox.Name = "testResultsDataViewGroupBox"
        Me.testResultsDataViewGroupBox.Size = New System.Drawing.Size(200, 78)
        Me.testResultsDataViewGroupBox.TabIndex = 9
        Me.testResultsDataViewGroupBox.TabStop = False
        Me.testResultsDataViewGroupBox.Text = "Test Results"
        '
        'rowsReturnedTimeLabel
        '
        Me.rowsReturnedTimeLabel.AutoSize = True
        Me.rowsReturnedTimeLabel.Location = New System.Drawing.Point(11, 46)
        Me.rowsReturnedTimeLabel.Name = "rowsReturnedTimeLabel"
        Me.rowsReturnedTimeLabel.Size = New System.Drawing.Size(75, 13)
        Me.rowsReturnedTimeLabel.TabIndex = 1
        Me.rowsReturnedTimeLabel.Text = "Time Required:"
        '
        'rowsReturnedLabel
        '
        Me.rowsReturnedLabel.AutoSize = True
        Me.rowsReturnedLabel.Location = New System.Drawing.Point(11, 18)
        Me.rowsReturnedLabel.Name = "rowsReturnedLabel"
        Me.rowsReturnedLabel.Size = New System.Drawing.Size(83, 13)
        Me.rowsReturnedLabel.TabIndex = 0
        Me.rowsReturnedLabel.Text = "Rows Returned: "
        '
        'dataViewDataGridView
        '
        Me.dataViewDataGridView.Location = New System.Drawing.Point(29, 199)
        Me.dataViewDataGridView.Name = "dataViewDataGridView"
        Me.dataViewDataGridView.Size = New System.Drawing.Size(316, 150)
        Me.dataViewDataGridView.TabIndex = 8
        Me.dataViewDataGridView.Text = "dataGridView3"
        '
        'dataViewShowDataViewButton
        '
        Me.dataViewShowDataViewButton.Location = New System.Drawing.Point(270, 156)
        Me.dataViewShowDataViewButton.Name = "dataViewShowDataViewButton"
        Me.dataViewShowDataViewButton.Size = New System.Drawing.Size(75, 23)
        Me.dataViewShowDataViewButton.TabIndex = 7
        Me.dataViewShowDataViewButton.Text = "DataView"
        '
        'dataViewShowDataSetButton
        '
        Me.dataViewShowDataSetButton.Location = New System.Drawing.Point(270, 110)
        Me.dataViewShowDataSetButton.Name = "dataViewShowDataSetButton"
        Me.dataViewShowDataSetButton.Size = New System.Drawing.Size(75, 23)
        Me.dataViewShowDataSetButton.TabIndex = 6
        Me.dataViewShowDataSetButton.Text = "DataSet"
        '
        'readWriteTimeLabel
        '
        Me.readWriteTimeLabel.AutoSize = True
        Me.readWriteTimeLabel.Location = New System.Drawing.Point(11, 46)
        Me.readWriteTimeLabel.Name = "readWriteTimeLabel"
        Me.readWriteTimeLabel.Size = New System.Drawing.Size(75, 13)
        Me.readWriteTimeLabel.TabIndex = 1
        Me.readWriteTimeLabel.Text = "Time Required:"
        '
        'rowsReadWrittenLabel
        '
        Me.rowsReadWrittenLabel.AutoSize = True
        Me.rowsReadWrittenLabel.Location = New System.Drawing.Point(11, 18)
        Me.rowsReadWrittenLabel.Name = "rowsReadWrittenLabel"
        Me.rowsReadWrittenLabel.Size = New System.Drawing.Size(104, 13)
        Me.rowsReadWrittenLabel.TabIndex = 0
        Me.rowsReadWrittenLabel.Text = "Rows Read/Written: "
        '
        'testResultsPerformanceGroupBox
        '
        Me.testResultsPerformanceGroupBox.Controls.Add(Me.elapsedTimeLabel)
        Me.testResultsPerformanceGroupBox.Controls.Add(Me.rowsInsertedLabel)
        Me.testResultsPerformanceGroupBox.Location = New System.Drawing.Point(19, 100)
        Me.testResultsPerformanceGroupBox.Name = "testResultsPerformanceGroupBox"
        Me.testResultsPerformanceGroupBox.Size = New System.Drawing.Size(200, 78)
        Me.testResultsPerformanceGroupBox.TabIndex = 4
        Me.testResultsPerformanceGroupBox.TabStop = False
        Me.testResultsPerformanceGroupBox.Text = "Test Results"
        '
        'elapsedTimeLabel
        '
        Me.elapsedTimeLabel.AutoSize = True
        Me.elapsedTimeLabel.Location = New System.Drawing.Point(11, 46)
        Me.elapsedTimeLabel.Name = "elapsedTimeLabel"
        Me.elapsedTimeLabel.Size = New System.Drawing.Size(66, 13)
        Me.elapsedTimeLabel.TabIndex = 1
        Me.elapsedTimeLabel.Text = "Elapsed time:"
        '
        'rowsInsertedLabel
        '
        Me.rowsInsertedLabel.AutoSize = True
        Me.rowsInsertedLabel.Location = New System.Drawing.Point(11, 18)
        Me.rowsInsertedLabel.Name = "rowsInsertedLabel"
        Me.rowsInsertedLabel.Size = New System.Drawing.Size(77, 13)
        Me.rowsInsertedLabel.TabIndex = 0
        Me.rowsInsertedLabel.Text = "Rows Inserted: "
        '
        'dataTableDataSetTabControl
        '
        Me.dataTableDataSetTabControl.Controls.Add(Me.performanceTabPage)
        Me.dataTableDataSetTabControl.Controls.Add(Me.readWriteXMLTabPage)
        Me.dataTableDataSetTabControl.Controls.Add(Me.dataViewsTabPage)
        Me.dataTableDataSetTabControl.Location = New System.Drawing.Point(22, 12)
        Me.dataTableDataSetTabControl.Name = "dataTableDataSetTabControl"
        Me.dataTableDataSetTabControl.SelectedIndex = 0
        Me.dataTableDataSetTabControl.Size = New System.Drawing.Size(369, 388)
        Me.dataTableDataSetTabControl.TabIndex = 1
        '
        'performanceTabPage
        '
        Me.performanceTabPage.Controls.Add(Me.descriptionPerformanceGroupBox)
        Me.performanceTabPage.Controls.Add(Me.testResultsPerformanceGroupBox)
        Me.performanceTabPage.Controls.Add(Me.resultsDataGridView)
        Me.performanceTabPage.Controls.Add(Me.performanceShowRowsButton)
        Me.performanceTabPage.Controls.Add(Me.performanceAddRowsButton)
        Me.performanceTabPage.Location = New System.Drawing.Point(4, 22)
        Me.performanceTabPage.Name = "performanceTabPage"
        Me.performanceTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.performanceTabPage.Size = New System.Drawing.Size(361, 362)
        Me.performanceTabPage.TabIndex = 0
        Me.performanceTabPage.Text = "Performance"
        '
        'resultsDataGridView
        '
        Me.resultsDataGridView.Location = New System.Drawing.Point(19, 189)
        Me.resultsDataGridView.Name = "resultsDataGridView"
        Me.resultsDataGridView.Size = New System.Drawing.Size(316, 150)
        Me.resultsDataGridView.TabIndex = 3
        Me.resultsDataGridView.Text = "dataGridView1"
        '
        'performanceShowRowsButton
        '
        Me.performanceShowRowsButton.Location = New System.Drawing.Point(260, 146)
        Me.performanceShowRowsButton.Name = "performanceShowRowsButton"
        Me.performanceShowRowsButton.Size = New System.Drawing.Size(75, 23)
        Me.performanceShowRowsButton.TabIndex = 2
        Me.performanceShowRowsButton.Text = "Show Rows"
        '
        'performanceAddRowsButton
        '
        Me.performanceAddRowsButton.Location = New System.Drawing.Point(260, 100)
        Me.performanceAddRowsButton.Name = "performanceAddRowsButton"
        Me.performanceAddRowsButton.Size = New System.Drawing.Size(75, 23)
        Me.performanceAddRowsButton.TabIndex = 1
        Me.performanceAddRowsButton.Text = "Add Rows"
        '
        'readWriteXMLTabPage
        '
        Me.readWriteXMLTabPage.Controls.Add(Me.descriptionXMLGroupBox)
        Me.readWriteXMLTabPage.Controls.Add(Me.testResultsXMLGroupBox)
        Me.readWriteXMLTabPage.Controls.Add(Me.xmlResultsDataGridView)
        Me.readWriteXMLTabPage.Controls.Add(Me.xmlReadButton)
        Me.readWriteXMLTabPage.Controls.Add(Me.xmlWriteButton)
        Me.readWriteXMLTabPage.Location = New System.Drawing.Point(4, 22)
        Me.readWriteXMLTabPage.Name = "readWriteXMLTabPage"
        Me.readWriteXMLTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.readWriteXMLTabPage.Size = New System.Drawing.Size(361, 362)
        Me.readWriteXMLTabPage.TabIndex = 1
        Me.readWriteXMLTabPage.Text = "Read/Write XML"
        '
        'testResultsXMLGroupBox
        '
        Me.testResultsXMLGroupBox.Controls.Add(Me.readWriteTimeLabel)
        Me.testResultsXMLGroupBox.Controls.Add(Me.rowsReadWrittenLabel)
        Me.testResultsXMLGroupBox.Location = New System.Drawing.Point(29, 110)
        Me.testResultsXMLGroupBox.Name = "testResultsXMLGroupBox"
        Me.testResultsXMLGroupBox.Size = New System.Drawing.Size(200, 78)
        Me.testResultsXMLGroupBox.TabIndex = 9
        Me.testResultsXMLGroupBox.TabStop = False
        Me.testResultsXMLGroupBox.Text = "Test Results"
        '
        'descriptionXMLGroupBox
        '
        Me.descriptionXMLGroupBox.Controls.Add(Me.descriptionLineXMLLabel)
        Me.descriptionXMLGroupBox.Location = New System.Drawing.Point(6, 3)
        Me.descriptionXMLGroupBox.Name = "descriptionXMLGroupBox"
        Me.descriptionXMLGroupBox.Size = New System.Drawing.Size(339, 91)
        Me.descriptionXMLGroupBox.TabIndex = 11
        Me.descriptionXMLGroupBox.TabStop = False
        Me.descriptionXMLGroupBox.Text = "Description"
        '
        'descriptionLineXMLLabel
        '
        Me.descriptionLineXMLLabel.AutoSize = True
        Me.descriptionLineXMLLabel.Location = New System.Drawing.Point(4, 16)
        Me.descriptionLineXMLLabel.Name = "descriptionLineXMLLabel"
        Me.descriptionLineXMLLabel.Size = New System.Drawing.Size(328, 52)
        Me.descriptionLineXMLLabel.TabIndex = 0
        Me.descriptionLineXMLLabel.Text = resources.GetString("descriptionLineXMLLabel.Text")
        '
        'descriptionPerformanceGroupBox
        '
        Me.descriptionPerformanceGroupBox.Controls.Add(Me.descriptionLineLabel)
        Me.descriptionPerformanceGroupBox.Location = New System.Drawing.Point(6, 6)
        Me.descriptionPerformanceGroupBox.Name = "descriptionPerformanceGroupBox"
        Me.descriptionPerformanceGroupBox.Size = New System.Drawing.Size(329, 91)
        Me.descriptionPerformanceGroupBox.TabIndex = 6
        Me.descriptionPerformanceGroupBox.TabStop = False
        Me.descriptionPerformanceGroupBox.Text = "Description"
        '
        'descriptionLineLabel
        '
        Me.descriptionLineLabel.AutoSize = True
        Me.descriptionLineLabel.Location = New System.Drawing.Point(6, 16)
        Me.descriptionLineLabel.Name = "descriptionLineLabel"
        Me.descriptionLineLabel.Size = New System.Drawing.Size(300, 52)
        Me.descriptionLineLabel.TabIndex = 0
        Me.descriptionLineLabel.Text = resources.GetString("descriptionLineLabel.Text")
        '
        'descriptionDataViewGroupBox
        '
        Me.descriptionDataViewGroupBox.Controls.Add(Me.descriptionDataViewLabel)
        Me.descriptionDataViewGroupBox.Location = New System.Drawing.Point(16, 13)
        Me.descriptionDataViewGroupBox.Name = "descriptionDataViewGroupBox"
        Me.descriptionDataViewGroupBox.Size = New System.Drawing.Size(329, 91)
        Me.descriptionDataViewGroupBox.TabIndex = 11
        Me.descriptionDataViewGroupBox.TabStop = False
        Me.descriptionDataViewGroupBox.Text = "Description"
        '
        'descriptionDataViewLabel
        '
        Me.descriptionDataViewLabel.AutoSize = True
        Me.descriptionDataViewLabel.Location = New System.Drawing.Point(6, 16)
        Me.descriptionDataViewLabel.Name = "descriptionDataViewLabel"
        Me.descriptionDataViewLabel.Size = New System.Drawing.Size(299, 52)
        Me.descriptionDataViewLabel.TabIndex = 0
        Me.descriptionDataViewLabel.Text = "This tab shows how you can use the DataView class to display" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "a logical view of a" & _
            " DataTable." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Click DataSet to view the original DataTable in the DataSet." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Click" & _
            " DataView to view the new DataTable."
        '
        'dataSetDataTableForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(412, 413)
        Me.Controls.Add(Me.dataTableDataSetTabControl)
        Me.Name = "dataSetDataTableForm"
        Me.Text = "DataTable and DataSet Enhancements"
        CType(Me.xmlResultsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.dataViewsTabPage.ResumeLayout(False)
        Me.testResultsDataViewGroupBox.ResumeLayout(False)
        Me.testResultsDataViewGroupBox.PerformLayout()
        CType(Me.dataViewDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.testResultsPerformanceGroupBox.ResumeLayout(False)
        Me.testResultsPerformanceGroupBox.PerformLayout()
        Me.dataTableDataSetTabControl.ResumeLayout(False)
        Me.performanceTabPage.ResumeLayout(False)
        CType(Me.resultsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.readWriteXMLTabPage.ResumeLayout(False)
        Me.testResultsXMLGroupBox.ResumeLayout(False)
        Me.testResultsXMLGroupBox.PerformLayout()
        Me.descriptionXMLGroupBox.ResumeLayout(False)
        Me.descriptionXMLGroupBox.PerformLayout()
        Me.descriptionPerformanceGroupBox.ResumeLayout(False)
        Me.descriptionPerformanceGroupBox.PerformLayout()
        Me.descriptionDataViewGroupBox.ResumeLayout(False)
        Me.descriptionDataViewGroupBox.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents xmlResultsDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents xmlReadButton As System.Windows.Forms.Button
    Friend WithEvents xmlWriteButton As System.Windows.Forms.Button
    Friend WithEvents dataViewsTabPage As System.Windows.Forms.TabPage
    Friend WithEvents testResultsDataViewGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents rowsReturnedTimeLabel As System.Windows.Forms.Label
    Friend WithEvents rowsReturnedLabel As System.Windows.Forms.Label
    Friend WithEvents dataViewDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents dataViewShowDataViewButton As System.Windows.Forms.Button
    Friend WithEvents dataViewShowDataSetButton As System.Windows.Forms.Button
    Friend WithEvents readWriteTimeLabel As System.Windows.Forms.Label
    Friend WithEvents rowsReadWrittenLabel As System.Windows.Forms.Label
    Friend WithEvents testResultsPerformanceGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents elapsedTimeLabel As System.Windows.Forms.Label
    Friend WithEvents rowsInsertedLabel As System.Windows.Forms.Label
    Friend WithEvents dataTableDataSetTabControl As System.Windows.Forms.TabControl
    Friend WithEvents performanceTabPage As System.Windows.Forms.TabPage
    Friend WithEvents resultsDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents performanceShowRowsButton As System.Windows.Forms.Button
    Friend WithEvents performanceAddRowsButton As System.Windows.Forms.Button
    Friend WithEvents readWriteXMLTabPage As System.Windows.Forms.TabPage
    Friend WithEvents testResultsXMLGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents descriptionDataViewGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents descriptionDataViewLabel As System.Windows.Forms.Label
    Friend WithEvents descriptionPerformanceGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents descriptionLineLabel As System.Windows.Forms.Label
    Friend WithEvents descriptionXMLGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents descriptionLineXMLLabel As System.Windows.Forms.Label

End Class
