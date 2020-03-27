<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class XMLDataTypeForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(XMLDataTypeForm))
        Me.chooseCategoryLabel = New System.Windows.Forms.Label
        Me.withMarkupRadioButton = New System.Windows.Forms.RadioButton
        Me.withoutMarkupRadioButton = New System.Windows.Forms.RadioButton
        Me.dataRichTextBox = New System.Windows.Forms.RichTextBox
        Me.dataLabel = New System.Windows.Forms.Label
        Me.definitionLabel = New System.Windows.Forms.Label
        Me.webBrowser1 = New System.Windows.Forms.WebBrowser
        Me.displayDataLabel = New System.Windows.Forms.Label
        Me.resultsLabel = New System.Windows.Forms.Label
        Me.descriptionGroupBox = New System.Windows.Forms.GroupBox
        Me.descriptionLine1Label = New System.Windows.Forms.Label
        Me.showDefinitionButton = New System.Windows.Forms.Button
        Me.collectionListComboBox = New System.Windows.Forms.ComboBox
        Me.showDataButton = New System.Windows.Forms.Button
        Me.schemaDataGridView = New System.Windows.Forms.DataGridView
        Me.insertDataButton = New System.Windows.Forms.Button
        Me.descriptionGroupBox.SuspendLayout()
        CType(Me.schemaDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chooseCategoryLabel
        '
        Me.chooseCategoryLabel.AutoSize = True
        Me.chooseCategoryLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chooseCategoryLabel.Location = New System.Drawing.Point(7, 118)
        Me.chooseCategoryLabel.Name = "chooseCategoryLabel"
        Me.chooseCategoryLabel.Size = New System.Drawing.Size(167, 20)
        Me.chooseCategoryLabel.TabIndex = 31
        Me.chooseCategoryLabel.Text = "Choose a Category:"
        '
        'withMarkupRadioButton
        '
        Me.withMarkupRadioButton.AutoSize = True
        Me.withMarkupRadioButton.Location = New System.Drawing.Point(591, 312)
        Me.withMarkupRadioButton.Name = "withMarkupRadioButton"
        Me.withMarkupRadioButton.Size = New System.Drawing.Size(86, 17)
        Me.withMarkupRadioButton.TabIndex = 30
        Me.withMarkupRadioButton.Text = "With Markup"
        '
        'withoutMarkupRadioButton
        '
        Me.withoutMarkupRadioButton.AutoSize = True
        Me.withoutMarkupRadioButton.Location = New System.Drawing.Point(503, 312)
        Me.withoutMarkupRadioButton.Name = "withoutMarkupRadioButton"
        Me.withoutMarkupRadioButton.Size = New System.Drawing.Size(88, 17)
        Me.withoutMarkupRadioButton.TabIndex = 29
        Me.withoutMarkupRadioButton.Text = "W/O Markup"
        '
        'dataRichTextBox
        '
        Me.dataRichTextBox.Location = New System.Drawing.Point(462, 155)
        Me.dataRichTextBox.Name = "dataRichTextBox"
        Me.dataRichTextBox.ReadOnly = True
        Me.dataRichTextBox.Size = New System.Drawing.Size(202, 150)
        Me.dataRichTextBox.TabIndex = 28
        Me.dataRichTextBox.Text = ""
        '
        'dataLabel
        '
        Me.dataLabel.AutoSize = True
        Me.dataLabel.Location = New System.Drawing.Point(638, 137)
        Me.dataLabel.Name = "dataLabel"
        Me.dataLabel.Size = New System.Drawing.Size(30, 13)
        Me.dataLabel.TabIndex = 27
        Me.dataLabel.Text = "Data"
        '
        'definitionLabel
        '
        Me.definitionLabel.AutoSize = True
        Me.definitionLabel.Location = New System.Drawing.Point(385, 137)
        Me.definitionLabel.Name = "definitionLabel"
        Me.definitionLabel.Size = New System.Drawing.Size(79, 13)
        Me.definitionLabel.TabIndex = 26
        Me.definitionLabel.Text = "Definition/Data"
        '
        'webBrowser1
        '
        Me.webBrowser1.Location = New System.Drawing.Point(551, 155)
        Me.webBrowser1.Name = "webBrowser1"
        Me.webBrowser1.Size = New System.Drawing.Size(65, 29)
        Me.webBrowser1.TabIndex = 32
        '
        'displayDataLabel
        '
        Me.displayDataLabel.AutoSize = True
        Me.displayDataLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.displayDataLabel.Location = New System.Drawing.Point(7, 219)
        Me.displayDataLabel.Name = "displayDataLabel"
        Me.displayDataLabel.Size = New System.Drawing.Size(147, 20)
        Me.displayDataLabel.TabIndex = 25
        Me.displayDataLabel.Text = "Display the Data:"
        '
        'resultsLabel
        '
        Me.resultsLabel.AutoSize = True
        Me.resultsLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.resultsLabel.Location = New System.Drawing.Point(209, 132)
        Me.resultsLabel.Name = "resultsLabel"
        Me.resultsLabel.Size = New System.Drawing.Size(75, 20)
        Me.resultsLabel.TabIndex = 24
        Me.resultsLabel.Text = "Results:"
        '
        'descriptionGroupBox
        '
        Me.descriptionGroupBox.Controls.Add(Me.descriptionLine1Label)
        Me.descriptionGroupBox.Location = New System.Drawing.Point(22, 20)
        Me.descriptionGroupBox.Name = "descriptionGroupBox"
        Me.descriptionGroupBox.Size = New System.Drawing.Size(642, 81)
        Me.descriptionGroupBox.TabIndex = 23
        Me.descriptionGroupBox.TabStop = False
        Me.descriptionGroupBox.Text = "Description"
        '
        'descriptionLine1Label
        '
        Me.descriptionLine1Label.AutoSize = True
        Me.descriptionLine1Label.Location = New System.Drawing.Point(19, 14)
        Me.descriptionLine1Label.Name = "descriptionLine1Label"
        Me.descriptionLine1Label.Size = New System.Drawing.Size(608, 52)
        Me.descriptionLine1Label.TabIndex = 1
        Me.descriptionLine1Label.Text = resources.GetString("descriptionLine1Label.Text")
        '
        'showDefinitionButton
        '
        Me.showDefinitionButton.Location = New System.Drawing.Point(7, 264)
        Me.showDefinitionButton.Name = "showDefinitionButton"
        Me.showDefinitionButton.Size = New System.Drawing.Size(121, 23)
        Me.showDefinitionButton.TabIndex = 22
        Me.showDefinitionButton.Text = "Show Table Definition"
        '
        'collectionListComboBox
        '
        Me.collectionListComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.collectionListComboBox.FormattingEnabled = True
        Me.collectionListComboBox.Location = New System.Drawing.Point(7, 142)
        Me.collectionListComboBox.Name = "collectionListComboBox"
        Me.collectionListComboBox.Size = New System.Drawing.Size(121, 21)
        Me.collectionListComboBox.TabIndex = 21
        '
        'showDataButton
        '
        Me.showDataButton.Location = New System.Drawing.Point(22, 306)
        Me.showDataButton.Name = "showDataButton"
        Me.showDataButton.Size = New System.Drawing.Size(75, 23)
        Me.showDataButton.TabIndex = 20
        Me.showDataButton.Text = "Show Data"
        '
        'schemaDataGridView
        '
        Me.schemaDataGridView.Location = New System.Drawing.Point(211, 155)
        Me.schemaDataGridView.Name = "schemaDataGridView"
        Me.schemaDataGridView.ReadOnly = True
        Me.schemaDataGridView.Size = New System.Drawing.Size(244, 150)
        Me.schemaDataGridView.TabIndex = 19
        Me.schemaDataGridView.Text = "dataGridView1"
        '
        'insertDataButton
        '
        Me.insertDataButton.Location = New System.Drawing.Point(23, 177)
        Me.insertDataButton.Name = "insertDataButton"
        Me.insertDataButton.Size = New System.Drawing.Size(75, 23)
        Me.insertDataButton.TabIndex = 18
        Me.insertDataButton.Text = "Insert Data"
        '
        'XMLDataTypeForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(681, 349)
        Me.Controls.Add(Me.chooseCategoryLabel)
        Me.Controls.Add(Me.withMarkupRadioButton)
        Me.Controls.Add(Me.withoutMarkupRadioButton)
        Me.Controls.Add(Me.dataRichTextBox)
        Me.Controls.Add(Me.dataLabel)
        Me.Controls.Add(Me.definitionLabel)
        Me.Controls.Add(Me.webBrowser1)
        Me.Controls.Add(Me.displayDataLabel)
        Me.Controls.Add(Me.resultsLabel)
        Me.Controls.Add(Me.descriptionGroupBox)
        Me.Controls.Add(Me.showDefinitionButton)
        Me.Controls.Add(Me.collectionListComboBox)
        Me.Controls.Add(Me.showDataButton)
        Me.Controls.Add(Me.schemaDataGridView)
        Me.Controls.Add(Me.insertDataButton)
        Me.Name = "XMLDataTypeForm"
        Me.Text = "XML Data Type  Example"
        Me.descriptionGroupBox.ResumeLayout(False)
        Me.descriptionGroupBox.PerformLayout()
        CType(Me.schemaDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chooseCategoryLabel As System.Windows.Forms.Label
    Friend WithEvents withMarkupRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents withoutMarkupRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents dataRichTextBox As System.Windows.Forms.RichTextBox
    Friend WithEvents dataLabel As System.Windows.Forms.Label
    Friend WithEvents definitionLabel As System.Windows.Forms.Label
    Friend WithEvents webBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents displayDataLabel As System.Windows.Forms.Label
    Friend WithEvents resultsLabel As System.Windows.Forms.Label
    Friend WithEvents descriptionGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents showDefinitionButton As System.Windows.Forms.Button
    Friend WithEvents collectionListComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents showDataButton As System.Windows.Forms.Button
    Friend WithEvents schemaDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents insertDataButton As System.Windows.Forms.Button
    Friend WithEvents descriptionLine1Label As System.Windows.Forms.Label

End Class
