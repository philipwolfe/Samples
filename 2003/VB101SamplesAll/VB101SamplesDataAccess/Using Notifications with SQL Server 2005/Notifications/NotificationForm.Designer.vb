<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class NotificationForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NotificationForm))
        Me.actionLabel = New System.Windows.Forms.Label
        Me.resultsDataGridView = New System.Windows.Forms.DataGridView
        Me.IDTextLabel = New System.Windows.Forms.Label
        Me.chooseIDLabel = New System.Windows.Forms.Label
        Me.updateComboBox = New System.Windows.Forms.ComboBox
        Me.value1TextBox = New System.Windows.Forms.TextBox
        Me.enterIntegerValueLabel = New System.Windows.Forms.Label
        Me.testResultsGroupBox = New System.Windows.Forms.GroupBox
        Me.elapsedTimeLabel = New System.Windows.Forms.Label
        Me.descriptionLineLabel = New System.Windows.Forms.Label
        Me.descriptionGroupBox = New System.Windows.Forms.GroupBox
        Me.insertButton = New System.Windows.Forms.Button
        Me.updateButton = New System.Windows.Forms.Button
        CType(Me.resultsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.testResultsGroupBox.SuspendLayout()
        Me.descriptionGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'actionLabel
        '
        Me.actionLabel.AutoSize = True
        Me.actionLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.actionLabel.Location = New System.Drawing.Point(6, 68)
        Me.actionLabel.Name = "actionLabel"
        Me.actionLabel.Size = New System.Drawing.Size(43, 13)
        Me.actionLabel.TabIndex = 1
        Me.actionLabel.Text = "Action:"
        '
        'resultsDataGridView
        '
        Me.resultsDataGridView.Location = New System.Drawing.Point(333, 159)
        Me.resultsDataGridView.Name = "resultsDataGridView"
        Me.resultsDataGridView.ReadOnly = True
        Me.resultsDataGridView.Size = New System.Drawing.Size(191, 180)
        Me.resultsDataGridView.TabIndex = 15
        Me.resultsDataGridView.Text = "dataGridView1"
        '
        'IDTextLabel
        '
        Me.IDTextLabel.AutoSize = True
        Me.IDTextLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IDTextLabel.Location = New System.Drawing.Point(27, 250)
        Me.IDTextLabel.Name = "IDTextLabel"
        Me.IDTextLabel.Size = New System.Drawing.Size(20, 13)
        Me.IDTextLabel.TabIndex = 7
        Me.IDTextLabel.Text = "ID:"
        '
        'chooseIDLabel
        '
        Me.chooseIDLabel.AutoSize = True
        Me.chooseIDLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chooseIDLabel.Location = New System.Drawing.Point(24, 227)
        Me.chooseIDLabel.Name = "chooseIDLabel"
        Me.chooseIDLabel.Size = New System.Drawing.Size(144, 13)
        Me.chooseIDLabel.TabIndex = 10
        Me.chooseIDLabel.Text = "Choose an ID to Update:"
        '
        'updateComboBox
        '
        Me.updateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.updateComboBox.FormattingEnabled = True
        Me.updateComboBox.Location = New System.Drawing.Point(53, 248)
        Me.updateComboBox.Name = "updateComboBox"
        Me.updateComboBox.Size = New System.Drawing.Size(56, 21)
        Me.updateComboBox.TabIndex = 11
        '
        'value1TextBox
        '
        Me.value1TextBox.Location = New System.Drawing.Point(24, 175)
        Me.value1TextBox.Name = "value1TextBox"
        Me.value1TextBox.Size = New System.Drawing.Size(57, 20)
        Me.value1TextBox.TabIndex = 8
        '
        'enterIntegerValueLabel
        '
        Me.enterIntegerValueLabel.AutoSize = True
        Me.enterIntegerValueLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.enterIntegerValueLabel.Location = New System.Drawing.Point(23, 159)
        Me.enterIntegerValueLabel.Name = "enterIntegerValueLabel"
        Me.enterIntegerValueLabel.Size = New System.Drawing.Size(135, 13)
        Me.enterIntegerValueLabel.TabIndex = 6
        Me.enterIntegerValueLabel.Text = "Enter an Integer Value:"
        '
        'testResultsGroupBox
        '
        Me.testResultsGroupBox.Controls.Add(Me.actionLabel)
        Me.testResultsGroupBox.Controls.Add(Me.elapsedTimeLabel)
        Me.testResultsGroupBox.Location = New System.Drawing.Point(175, 159)
        Me.testResultsGroupBox.Name = "testResultsGroupBox"
        Me.testResultsGroupBox.Size = New System.Drawing.Size(151, 180)
        Me.testResultsGroupBox.TabIndex = 14
        Me.testResultsGroupBox.TabStop = False
        Me.testResultsGroupBox.Text = "Test Results"
        '
        'elapsedTimeLabel
        '
        Me.elapsedTimeLabel.AutoSize = True
        Me.elapsedTimeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.elapsedTimeLabel.Location = New System.Drawing.Point(6, 23)
        Me.elapsedTimeLabel.Name = "elapsedTimeLabel"
        Me.elapsedTimeLabel.Size = New System.Drawing.Size(83, 13)
        Me.elapsedTimeLabel.TabIndex = 0
        Me.elapsedTimeLabel.Text = "Elapsed Time:"
        '
        'descriptionLineLabel
        '
        Me.descriptionLineLabel.AutoSize = True
        Me.descriptionLineLabel.Location = New System.Drawing.Point(6, 16)
        Me.descriptionLineLabel.Name = "descriptionLineLabel"
        Me.descriptionLineLabel.Size = New System.Drawing.Size(434, 91)
        Me.descriptionLineLabel.TabIndex = 0
        Me.descriptionLineLabel.Text = resources.GetString("descriptionLineLabel.Text")
        '
        'descriptionGroupBox
        '
        Me.descriptionGroupBox.Controls.Add(Me.descriptionLineLabel)
        Me.descriptionGroupBox.Location = New System.Drawing.Point(24, 16)
        Me.descriptionGroupBox.Name = "descriptionGroupBox"
        Me.descriptionGroupBox.Size = New System.Drawing.Size(500, 121)
        Me.descriptionGroupBox.TabIndex = 13
        Me.descriptionGroupBox.TabStop = False
        Me.descriptionGroupBox.Text = "Description"
        '
        'insertButton
        '
        Me.insertButton.Location = New System.Drawing.Point(24, 201)
        Me.insertButton.Name = "insertButton"
        Me.insertButton.Size = New System.Drawing.Size(129, 23)
        Me.insertButton.TabIndex = 12
        Me.insertButton.Text = "Insert Data"
        '
        'updateButton
        '
        Me.updateButton.Location = New System.Drawing.Point(24, 275)
        Me.updateButton.Name = "updateButton"
        Me.updateButton.Size = New System.Drawing.Size(129, 23)
        Me.updateButton.TabIndex = 9
        Me.updateButton.Text = "Update Data"
        '
        'NotificationForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(547, 355)
        Me.Controls.Add(Me.resultsDataGridView)
        Me.Controls.Add(Me.IDTextLabel)
        Me.Controls.Add(Me.chooseIDLabel)
        Me.Controls.Add(Me.updateComboBox)
        Me.Controls.Add(Me.value1TextBox)
        Me.Controls.Add(Me.enterIntegerValueLabel)
        Me.Controls.Add(Me.testResultsGroupBox)
        Me.Controls.Add(Me.descriptionGroupBox)
        Me.Controls.Add(Me.insertButton)
        Me.Controls.Add(Me.updateButton)
        Me.Name = "NotificationForm"
        Me.Text = "SQL Notification Services Example"
        CType(Me.resultsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.testResultsGroupBox.ResumeLayout(False)
        Me.testResultsGroupBox.PerformLayout()
        Me.descriptionGroupBox.ResumeLayout(False)
        Me.descriptionGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents actionLabel As System.Windows.Forms.Label
    Friend WithEvents resultsDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents IDTextLabel As System.Windows.Forms.Label
    Friend WithEvents chooseIDLabel As System.Windows.Forms.Label
    Friend WithEvents updateComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents value1TextBox As System.Windows.Forms.TextBox
    Friend WithEvents enterIntegerValueLabel As System.Windows.Forms.Label
    Friend WithEvents testResultsGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents elapsedTimeLabel As System.Windows.Forms.Label
    Friend WithEvents descriptionLineLabel As System.Windows.Forms.Label
    Friend WithEvents descriptionGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents insertButton As System.Windows.Forms.Button
    Friend WithEvents updateButton As System.Windows.Forms.Button

End Class
