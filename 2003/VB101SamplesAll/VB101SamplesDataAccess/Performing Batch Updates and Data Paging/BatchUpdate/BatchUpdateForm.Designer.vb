<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class batchUpdateForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(batchUpdateForm))
        Me.finalResultWebBrowser = New System.Windows.Forms.WebBrowser
        Me.sampleDataDataGridView = New System.Windows.Forms.DataGridView
        Me.label5 = New System.Windows.Forms.Label
        Me.label4 = New System.Windows.Forms.Label
        Me.descriptionGroupBox = New System.Windows.Forms.GroupBox
        Me.descriptionLineLabel = New System.Windows.Forms.Label
        Me.dataSetSizeComboBox = New System.Windows.Forms.ComboBox
        Me.dataSetSizeLabel = New System.Windows.Forms.Label
        Me.chooseBatchSizeLabel = New System.Windows.Forms.Label
        Me.testResultsGroupBox = New System.Windows.Forms.GroupBox
        Me.rowsInsertedLabel = New System.Windows.Forms.Label
        Me.elapsedTimeLabel = New System.Windows.Forms.Label
        Me.elapsedTimeTextLabel = New System.Windows.Forms.Label
        Me.insertDataButton = New System.Windows.Forms.Button
        Me.batchSizeComboBox = New System.Windows.Forms.ComboBox
        CType(Me.sampleDataDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.descriptionGroupBox.SuspendLayout()
        Me.testResultsGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'finalResultWebBrowser
        '
        Me.finalResultWebBrowser.Location = New System.Drawing.Point(463, 158)
        Me.finalResultWebBrowser.Name = "finalResultWebBrowser"
        Me.finalResultWebBrowser.Size = New System.Drawing.Size(172, 216)
        '
        'sampleDataDataGridView
        '
        Me.sampleDataDataGridView.Location = New System.Drawing.Point(286, 158)
        Me.sampleDataDataGridView.Name = "sampleDataDataGridView"
        Me.sampleDataDataGridView.ReadOnly = True
        Me.sampleDataDataGridView.Size = New System.Drawing.Size(170, 220)
        Me.sampleDataDataGridView.TabIndex = 13
        Me.sampleDataDataGridView.Text = "dataGridView1"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(6, 65)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(0, 0)
        Me.label5.TabIndex = 2
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(6, 39)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(6, 13)
        Me.label4.TabIndex = 1
        Me.label4.Text = " "
        '
        'descriptionGroupBox
        '
        Me.descriptionGroupBox.Controls.Add(Me.label5)
        Me.descriptionGroupBox.Controls.Add(Me.label4)
        Me.descriptionGroupBox.Controls.Add(Me.descriptionLineLabel)
        Me.descriptionGroupBox.Location = New System.Drawing.Point(12, 17)
        Me.descriptionGroupBox.Name = "descriptionGroupBox"
        Me.descriptionGroupBox.Size = New System.Drawing.Size(623, 135)
        Me.descriptionGroupBox.TabIndex = 10
        Me.descriptionGroupBox.TabStop = False
        Me.descriptionGroupBox.Text = "Description"
        '
        'descriptionLineLabel
        '
        Me.descriptionLineLabel.AutoSize = True
        Me.descriptionLineLabel.Location = New System.Drawing.Point(13, 12)
        Me.descriptionLineLabel.Name = "descriptionLineLabel"
        Me.descriptionLineLabel.Size = New System.Drawing.Size(594, 104)
        Me.descriptionLineLabel.TabIndex = 0
        Me.descriptionLineLabel.Text = resources.GetString("descriptionLineLabel.Text")
        '
        'dataSetSizeComboBox
        '
        Me.dataSetSizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.dataSetSizeComboBox.FormattingEnabled = True
        Me.dataSetSizeComboBox.Location = New System.Drawing.Point(15, 182)
        Me.dataSetSizeComboBox.Name = "dataSetSizeComboBox"
        Me.dataSetSizeComboBox.Size = New System.Drawing.Size(75, 21)
        Me.dataSetSizeComboBox.TabIndex = 21
        '
        'dataSetSizeLabel
        '
        Me.dataSetSizeLabel.AutoSize = True
        Me.dataSetSizeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dataSetSizeLabel.Location = New System.Drawing.Point(6, 161)
        Me.dataSetSizeLabel.Name = "dataSetSizeLabel"
        Me.dataSetSizeLabel.Size = New System.Drawing.Size(127, 13)
        Me.dataSetSizeLabel.TabIndex = 20
        Me.dataSetSizeLabel.Text = "Choose DataSet Size:"
        '
        'chooseBatchSizeLabel
        '
        Me.chooseBatchSizeLabel.AutoSize = True
        Me.chooseBatchSizeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chooseBatchSizeLabel.Location = New System.Drawing.Point(6, 209)
        Me.chooseBatchSizeLabel.Name = "chooseBatchSizeLabel"
        Me.chooseBatchSizeLabel.Size = New System.Drawing.Size(114, 13)
        Me.chooseBatchSizeLabel.TabIndex = 16
        Me.chooseBatchSizeLabel.Text = "Choose Batch Size:"
        '
        'testResultsGroupBox
        '
        Me.testResultsGroupBox.Controls.Add(Me.rowsInsertedLabel)
        Me.testResultsGroupBox.Controls.Add(Me.elapsedTimeLabel)
        Me.testResultsGroupBox.Controls.Add(Me.elapsedTimeTextLabel)
        Me.testResultsGroupBox.Location = New System.Drawing.Point(143, 159)
        Me.testResultsGroupBox.Name = "testResultsGroupBox"
        Me.testResultsGroupBox.Size = New System.Drawing.Size(134, 183)
        Me.testResultsGroupBox.TabIndex = 19
        Me.testResultsGroupBox.TabStop = False
        Me.testResultsGroupBox.Text = "Test Results"
        '
        'rowsInsertedLabel
        '
        Me.rowsInsertedLabel.AutoSize = True
        Me.rowsInsertedLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rowsInsertedLabel.Location = New System.Drawing.Point(4, 111)
        Me.rowsInsertedLabel.Name = "rowsInsertedLabel"
        Me.rowsInsertedLabel.Size = New System.Drawing.Size(88, 13)
        Me.rowsInsertedLabel.TabIndex = 2
        Me.rowsInsertedLabel.Text = "Rows Inserted:"
        '
        'elapsedTimeLabel
        '
        Me.elapsedTimeLabel.AutoSize = True
        Me.elapsedTimeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.elapsedTimeLabel.Location = New System.Drawing.Point(15, 70)
        Me.elapsedTimeLabel.Name = "elapsedTimeLabel"
        Me.elapsedTimeLabel.Size = New System.Drawing.Size(0, 0)
        Me.elapsedTimeLabel.TabIndex = 1
        '
        'elapsedTimeTextLabel
        '
        Me.elapsedTimeTextLabel.AutoSize = True
        Me.elapsedTimeTextLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.elapsedTimeTextLabel.Location = New System.Drawing.Point(5, 34)
        Me.elapsedTimeTextLabel.Name = "elapsedTimeTextLabel"
        Me.elapsedTimeTextLabel.Size = New System.Drawing.Size(83, 13)
        Me.elapsedTimeTextLabel.TabIndex = 0
        Me.elapsedTimeTextLabel.Text = "Elapsed Time:"
        '
        'insertDataButton
        '
        Me.insertDataButton.Location = New System.Drawing.Point(15, 260)
        Me.insertDataButton.Name = "insertDataButton"
        Me.insertDataButton.Size = New System.Drawing.Size(75, 23)
        Me.insertDataButton.TabIndex = 18
        Me.insertDataButton.Text = "Insert Data"
        '
        'batchSizeComboBox
        '
        Me.batchSizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.batchSizeComboBox.FormattingEnabled = True
        Me.batchSizeComboBox.Items.AddRange(New Object() {"0", "1", "50", "100", "500"})
        Me.batchSizeComboBox.Location = New System.Drawing.Point(15, 230)
        Me.batchSizeComboBox.Name = "batchSizeComboBox"
        Me.batchSizeComboBox.Size = New System.Drawing.Size(75, 21)
        Me.batchSizeComboBox.TabIndex = 17
        '
        'batchUpdateForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(647, 394)
        Me.Controls.Add(Me.dataSetSizeComboBox)
        Me.Controls.Add(Me.dataSetSizeLabel)
        Me.Controls.Add(Me.chooseBatchSizeLabel)
        Me.Controls.Add(Me.testResultsGroupBox)
        Me.Controls.Add(Me.insertDataButton)
        Me.Controls.Add(Me.batchSizeComboBox)
        Me.Controls.Add(Me.finalResultWebBrowser)
        Me.Controls.Add(Me.sampleDataDataGridView)
        Me.Controls.Add(Me.descriptionGroupBox)
        Me.Name = "batchUpdateForm"
        Me.Text = "Batch Update Example"
        CType(Me.sampleDataDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.descriptionGroupBox.ResumeLayout(False)
        Me.descriptionGroupBox.PerformLayout()
        Me.testResultsGroupBox.ResumeLayout(False)
        Me.testResultsGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents finalResultWebBrowser As System.Windows.Forms.WebBrowser
    Friend WithEvents sampleDataDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents label5 As System.Windows.Forms.Label
    Friend WithEvents label4 As System.Windows.Forms.Label
    Friend WithEvents descriptionGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents descriptionLineLabel As System.Windows.Forms.Label
    Friend WithEvents dataSetSizeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents dataSetSizeLabel As System.Windows.Forms.Label
    Friend WithEvents chooseBatchSizeLabel As System.Windows.Forms.Label
    Friend WithEvents testResultsGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents rowsInsertedLabel As System.Windows.Forms.Label
    Friend WithEvents elapsedTimeLabel As System.Windows.Forms.Label
    Friend WithEvents elapsedTimeTextLabel As System.Windows.Forms.Label
    Friend WithEvents insertDataButton As System.Windows.Forms.Button
    Friend WithEvents batchSizeComboBox As System.Windows.Forms.ComboBox

End Class
