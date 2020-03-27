<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class bulkCopyForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(bulkCopyForm))
        Me.elapsedTimeLabel = New System.Windows.Forms.Label
        Me.progressLabel = New System.Windows.Forms.Label
        Me.copyProgressProgressBar = New System.Windows.Forms.ProgressBar
        Me.rowsCopiedLabel = New System.Windows.Forms.Label
        Me.numberOfRowsComboBox = New System.Windows.Forms.ComboBox
        Me.chooseRowsLabel = New System.Windows.Forms.Label
        Me.copyDataLabel = New System.Windows.Forms.Label
        Me.fillTableLabel = New System.Windows.Forms.Label
        Me.copyDataButton = New System.Windows.Forms.Button
        Me.fillTableButton = New System.Windows.Forms.Button
        Me.rowsCopiedTextLabel = New System.Windows.Forms.Label
        Me.descriptionGroupBox = New System.Windows.Forms.GroupBox
        Me.o = New System.Windows.Forms.Label
        Me.elapsedTimeTextLabel = New System.Windows.Forms.Label
        Me.resultsDataGridView = New System.Windows.Forms.DataGridView
        Me.testResultsGroupBox = New System.Windows.Forms.GroupBox
        Me.descriptionGroupBox.SuspendLayout()
        CType(Me.resultsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.testResultsGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'elapsedTimeLabel
        '
        Me.elapsedTimeLabel.AutoSize = True
        Me.elapsedTimeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.elapsedTimeLabel.Location = New System.Drawing.Point(8, 57)
        Me.elapsedTimeLabel.Name = "elapsedTimeLabel"
        Me.elapsedTimeLabel.Size = New System.Drawing.Size(0, 13)
        Me.elapsedTimeLabel.TabIndex = 1
        '
        'progressLabel
        '
        Me.progressLabel.AutoSize = True
        Me.progressLabel.Location = New System.Drawing.Point(13, 301)
        Me.progressLabel.Name = "progressLabel"
        Me.progressLabel.Size = New System.Drawing.Size(48, 13)
        Me.progressLabel.TabIndex = 23
        Me.progressLabel.Text = "Progress"
        '
        'copyProgressProgressBar
        '
        Me.copyProgressProgressBar.Location = New System.Drawing.Point(11, 317)
        Me.copyProgressProgressBar.Name = "copyProgressProgressBar"
        Me.copyProgressProgressBar.Size = New System.Drawing.Size(100, 23)
        Me.copyProgressProgressBar.TabIndex = 22
        '
        'rowsCopiedLabel
        '
        Me.rowsCopiedLabel.AutoSize = True
        Me.rowsCopiedLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rowsCopiedLabel.Location = New System.Drawing.Point(6, 112)
        Me.rowsCopiedLabel.Name = "rowsCopiedLabel"
        Me.rowsCopiedLabel.Size = New System.Drawing.Size(0, 13)
        Me.rowsCopiedLabel.TabIndex = 2
        '
        'numberOfRowsComboBox
        '
        Me.numberOfRowsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.numberOfRowsComboBox.FormattingEnabled = True
        Me.numberOfRowsComboBox.Location = New System.Drawing.Point(13, 138)
        Me.numberOfRowsComboBox.Name = "numberOfRowsComboBox"
        Me.numberOfRowsComboBox.Size = New System.Drawing.Size(121, 21)
        Me.numberOfRowsComboBox.TabIndex = 16
        '
        'chooseRowsLabel
        '
        Me.chooseRowsLabel.AutoSize = True
        Me.chooseRowsLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chooseRowsLabel.Location = New System.Drawing.Point(13, 118)
        Me.chooseRowsLabel.Name = "chooseRowsLabel"
        Me.chooseRowsLabel.Size = New System.Drawing.Size(160, 13)
        Me.chooseRowsLabel.TabIndex = 21
        Me.chooseRowsLabel.Text = "Step 1: Choose # of Rows:"
        '
        'copyDataLabel
        '
        Me.copyDataLabel.AutoSize = True
        Me.copyDataLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.copyDataLabel.Location = New System.Drawing.Point(12, 226)
        Me.copyDataLabel.Name = "copyDataLabel"
        Me.copyDataLabel.Size = New System.Drawing.Size(111, 13)
        Me.copyDataLabel.TabIndex = 20
        Me.copyDataLabel.Text = "Step 3: Copy Data"
        '
        'fillTableLabel
        '
        Me.fillTableLabel.AutoSize = True
        Me.fillTableLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fillTableLabel.Location = New System.Drawing.Point(13, 165)
        Me.fillTableLabel.Name = "fillTableLabel"
        Me.fillTableLabel.Size = New System.Drawing.Size(104, 13)
        Me.fillTableLabel.TabIndex = 19
        Me.fillTableLabel.Text = "Step 2: Fill Table"
        '
        'copyDataButton
        '
        Me.copyDataButton.Location = New System.Drawing.Point(11, 253)
        Me.copyDataButton.Name = "copyDataButton"
        Me.copyDataButton.Size = New System.Drawing.Size(75, 23)
        Me.copyDataButton.TabIndex = 18
        Me.copyDataButton.Text = "Copy Data"
        '
        'fillTableButton
        '
        Me.fillTableButton.Location = New System.Drawing.Point(13, 187)
        Me.fillTableButton.Name = "fillTableButton"
        Me.fillTableButton.Size = New System.Drawing.Size(75, 23)
        Me.fillTableButton.TabIndex = 17
        Me.fillTableButton.Text = "Fill Data"
        '
        'rowsCopiedTextLabel
        '
        Me.rowsCopiedTextLabel.AutoSize = True
        Me.rowsCopiedTextLabel.Location = New System.Drawing.Point(8, 83)
        Me.rowsCopiedTextLabel.Name = "rowsCopiedTextLabel"
        Me.rowsCopiedTextLabel.Size = New System.Drawing.Size(70, 13)
        Me.rowsCopiedTextLabel.TabIndex = 3
        Me.rowsCopiedTextLabel.Text = "Rows Copied"
        '
        'descriptionGroupBox
        '
        Me.descriptionGroupBox.Controls.Add(Me.o)
        Me.descriptionGroupBox.Location = New System.Drawing.Point(13, 12)
        Me.descriptionGroupBox.Name = "descriptionGroupBox"
        Me.descriptionGroupBox.Size = New System.Drawing.Size(632, 93)
        Me.descriptionGroupBox.TabIndex = 13
        Me.descriptionGroupBox.TabStop = False
        Me.descriptionGroupBox.Text = "Description"
        '
        'o
        '
        Me.o.AutoSize = True
        Me.o.Location = New System.Drawing.Point(4, 20)
        Me.o.Name = "o"
        Me.o.Size = New System.Drawing.Size(577, 65)
        Me.o.TabIndex = 1
        Me.o.Text = resources.GetString("o.Text")
        '
        'elapsedTimeTextLabel
        '
        Me.elapsedTimeTextLabel.AutoSize = True
        Me.elapsedTimeTextLabel.Location = New System.Drawing.Point(7, 33)
        Me.elapsedTimeTextLabel.Name = "elapsedTimeTextLabel"
        Me.elapsedTimeTextLabel.Size = New System.Drawing.Size(74, 13)
        Me.elapsedTimeTextLabel.TabIndex = 0
        Me.elapsedTimeTextLabel.Text = "Elapsed Time:"
        '
        'resultsDataGridView
        '
        Me.resultsDataGridView.Location = New System.Drawing.Point(336, 123)
        Me.resultsDataGridView.Name = "resultsDataGridView"
        Me.resultsDataGridView.Size = New System.Drawing.Size(309, 232)
        Me.resultsDataGridView.TabIndex = 15
        Me.resultsDataGridView.Text = "dataGridView1"
        '
        'testResultsGroupBox
        '
        Me.testResultsGroupBox.Controls.Add(Me.rowsCopiedTextLabel)
        Me.testResultsGroupBox.Controls.Add(Me.rowsCopiedLabel)
        Me.testResultsGroupBox.Controls.Add(Me.elapsedTimeLabel)
        Me.testResultsGroupBox.Controls.Add(Me.elapsedTimeTextLabel)
        Me.testResultsGroupBox.Location = New System.Drawing.Point(208, 123)
        Me.testResultsGroupBox.Name = "testResultsGroupBox"
        Me.testResultsGroupBox.Size = New System.Drawing.Size(121, 217)
        Me.testResultsGroupBox.TabIndex = 14
        Me.testResultsGroupBox.TabStop = False
        Me.testResultsGroupBox.Text = "Test Results"
        '
        'bulkCopyForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(656, 367)
        Me.Controls.Add(Me.progressLabel)
        Me.Controls.Add(Me.copyProgressProgressBar)
        Me.Controls.Add(Me.numberOfRowsComboBox)
        Me.Controls.Add(Me.chooseRowsLabel)
        Me.Controls.Add(Me.copyDataLabel)
        Me.Controls.Add(Me.fillTableLabel)
        Me.Controls.Add(Me.copyDataButton)
        Me.Controls.Add(Me.fillTableButton)
        Me.Controls.Add(Me.descriptionGroupBox)
        Me.Controls.Add(Me.resultsDataGridView)
        Me.Controls.Add(Me.testResultsGroupBox)
        Me.Name = "bulkCopyForm"
        Me.Text = "Using SqlBulkCopy"
        Me.descriptionGroupBox.ResumeLayout(False)
        Me.descriptionGroupBox.PerformLayout()
        CType(Me.resultsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.testResultsGroupBox.ResumeLayout(False)
        Me.testResultsGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents elapsedTimeLabel As System.Windows.Forms.Label
    Friend WithEvents progressLabel As System.Windows.Forms.Label
    Friend WithEvents copyProgressProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents rowsCopiedLabel As System.Windows.Forms.Label
    Friend WithEvents numberOfRowsComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents chooseRowsLabel As System.Windows.Forms.Label
    Friend WithEvents copyDataLabel As System.Windows.Forms.Label
    Friend WithEvents fillTableLabel As System.Windows.Forms.Label
    Friend WithEvents copyDataButton As System.Windows.Forms.Button
    Friend WithEvents fillTableButton As System.Windows.Forms.Button
    Friend WithEvents rowsCopiedTextLabel As System.Windows.Forms.Label
    Friend WithEvents descriptionGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents elapsedTimeTextLabel As System.Windows.Forms.Label
    Friend WithEvents resultsDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents testResultsGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents o As System.Windows.Forms.Label

End Class
