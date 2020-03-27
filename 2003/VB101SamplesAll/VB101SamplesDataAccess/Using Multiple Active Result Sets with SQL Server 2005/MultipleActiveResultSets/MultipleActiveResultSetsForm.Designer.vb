<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class MultipleActiveResultSetsForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MultipleActiveResultSetsForm))
        Me.timeRequiredTextLabel = New System.Windows.Forms.Label
        Me.retrieveDataButton = New System.Windows.Forms.Button
        Me.connectionRequiredTextLabel = New System.Windows.Forms.Label
        Me.descriptionLineLabel = New System.Windows.Forms.Label
        Me.withMARSRadioButton = New System.Windows.Forms.RadioButton
        Me.withoutMARSRadioButton = New System.Windows.Forms.RadioButton
        Me.connectionNumberLabel = New System.Windows.Forms.Label
        Me.testResultsGroupBox = New System.Windows.Forms.GroupBox
        Me.elapsedTimeLabel = New System.Windows.Forms.Label
        Me.displayedDataRichTextBox = New System.Windows.Forms.RichTextBox
        Me.descriptionGroupBox = New System.Windows.Forms.GroupBox
        Me.testResultsGroupBox.SuspendLayout()
        Me.descriptionGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'timeRequiredTextLabel
        '
        Me.timeRequiredTextLabel.AutoSize = True
        Me.timeRequiredTextLabel.Location = New System.Drawing.Point(7, 21)
        Me.timeRequiredTextLabel.Name = "timeRequiredTextLabel"
        Me.timeRequiredTextLabel.Size = New System.Drawing.Size(75, 13)
        Me.timeRequiredTextLabel.TabIndex = 0
        Me.timeRequiredTextLabel.Text = "Time Required:"
        '
        'retrieveDataButton
        '
        Me.retrieveDataButton.Location = New System.Drawing.Point(23, 246)
        Me.retrieveDataButton.Name = "retrieveDataButton"
        Me.retrieveDataButton.Size = New System.Drawing.Size(97, 23)
        Me.retrieveDataButton.TabIndex = 17
        Me.retrieveDataButton.Text = "Retrieve Data"
        '
        'connectionRequiredTextLabel
        '
        Me.connectionRequiredTextLabel.AutoSize = True
        Me.connectionRequiredTextLabel.Location = New System.Drawing.Point(7, 71)
        Me.connectionRequiredTextLabel.Name = "connectionRequiredTextLabel"
        Me.connectionRequiredTextLabel.Size = New System.Drawing.Size(111, 13)
        Me.connectionRequiredTextLabel.TabIndex = 1
        Me.connectionRequiredTextLabel.Text = "Connections Required:"
        '
        'descriptionLineLabel
        '
        Me.descriptionLineLabel.AutoSize = True
        Me.descriptionLineLabel.Location = New System.Drawing.Point(6, 16)
        Me.descriptionLineLabel.Name = "descriptionLineLabel"
        Me.descriptionLineLabel.Size = New System.Drawing.Size(595, 78)
        Me.descriptionLineLabel.TabIndex = 0
        Me.descriptionLineLabel.Text = resources.GetString("descriptionLineLabel.Text")
        '
        'withMARSRadioButton
        '
        Me.withMARSRadioButton.AutoSize = True
        Me.withMARSRadioButton.Location = New System.Drawing.Point(23, 203)
        Me.withMARSRadioButton.Name = "withMARSRadioButton"
        Me.withMARSRadioButton.Size = New System.Drawing.Size(172, 17)
        Me.withMARSRadioButton.TabIndex = 16
        Me.withMARSRadioButton.Text = "With Multiple Active Result Sets"
        '
        'withoutMARSRadioButton
        '
        Me.withoutMARSRadioButton.AutoSize = True
        Me.withoutMARSRadioButton.Location = New System.Drawing.Point(23, 179)
        Me.withoutMARSRadioButton.Name = "withoutMARSRadioButton"
        Me.withoutMARSRadioButton.Size = New System.Drawing.Size(174, 17)
        Me.withoutMARSRadioButton.TabIndex = 15
        Me.withoutMARSRadioButton.Text = "W/O Multiple Active Result Sets"
        '
        'connectionNumberLabel
        '
        Me.connectionNumberLabel.AutoSize = True
        Me.connectionNumberLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.connectionNumberLabel.Location = New System.Drawing.Point(8, 97)
        Me.connectionNumberLabel.Name = "connectionNumberLabel"
        Me.connectionNumberLabel.Size = New System.Drawing.Size(120, 20)
        Me.connectionNumberLabel.TabIndex = 3
        Me.connectionNumberLabel.Text = "# Connections"
        '
        'testResultsGroupBox
        '
        Me.testResultsGroupBox.Controls.Add(Me.connectionNumberLabel)
        Me.testResultsGroupBox.Controls.Add(Me.elapsedTimeLabel)
        Me.testResultsGroupBox.Controls.Add(Me.connectionRequiredTextLabel)
        Me.testResultsGroupBox.Controls.Add(Me.timeRequiredTextLabel)
        Me.testResultsGroupBox.Location = New System.Drawing.Point(218, 158)
        Me.testResultsGroupBox.Name = "testResultsGroupBox"
        Me.testResultsGroupBox.Size = New System.Drawing.Size(135, 208)
        Me.testResultsGroupBox.TabIndex = 14
        Me.testResultsGroupBox.TabStop = False
        Me.testResultsGroupBox.Text = "Test Results"
        '
        'elapsedTimeLabel
        '
        Me.elapsedTimeLabel.AutoSize = True
        Me.elapsedTimeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.elapsedTimeLabel.Location = New System.Drawing.Point(9, 42)
        Me.elapsedTimeLabel.Name = "elapsedTimeLabel"
        Me.elapsedTimeLabel.Size = New System.Drawing.Size(47, 20)
        Me.elapsedTimeLabel.TabIndex = 2
        Me.elapsedTimeLabel.Text = "TIME"
        '
        'displayedDataRichTextBox
        '
        Me.displayedDataRichTextBox.Location = New System.Drawing.Point(364, 158)
        Me.displayedDataRichTextBox.Name = "displayedDataRichTextBox"
        Me.displayedDataRichTextBox.ReadOnly = True
        Me.displayedDataRichTextBox.Size = New System.Drawing.Size(298, 296)
        Me.displayedDataRichTextBox.TabIndex = 13
        Me.displayedDataRichTextBox.Text = ""
        '
        'descriptionGroupBox
        '
        Me.descriptionGroupBox.Controls.Add(Me.descriptionLineLabel)
        Me.descriptionGroupBox.Location = New System.Drawing.Point(23, 21)
        Me.descriptionGroupBox.Name = "descriptionGroupBox"
        Me.descriptionGroupBox.Size = New System.Drawing.Size(631, 113)
        Me.descriptionGroupBox.TabIndex = 12
        Me.descriptionGroupBox.TabStop = False
        Me.descriptionGroupBox.Text = "Description"
        '
        'MultipleActiveResultSetsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(684, 475)
        Me.Controls.Add(Me.retrieveDataButton)
        Me.Controls.Add(Me.withMARSRadioButton)
        Me.Controls.Add(Me.withoutMARSRadioButton)
        Me.Controls.Add(Me.testResultsGroupBox)
        Me.Controls.Add(Me.displayedDataRichTextBox)
        Me.Controls.Add(Me.descriptionGroupBox)
        Me.Name = "MultipleActiveResultSetsForm"
        Me.Text = "Using Multiple Active Result Sets"
        Me.testResultsGroupBox.ResumeLayout(False)
        Me.testResultsGroupBox.PerformLayout()
        Me.descriptionGroupBox.ResumeLayout(False)
        Me.descriptionGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents timeRequiredTextLabel As System.Windows.Forms.Label
    Friend WithEvents retrieveDataButton As System.Windows.Forms.Button
    Friend WithEvents connectionRequiredTextLabel As System.Windows.Forms.Label
    Friend WithEvents descriptionLineLabel As System.Windows.Forms.Label
    Friend WithEvents withMARSRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents withoutMARSRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents connectionNumberLabel As System.Windows.Forms.Label
    Friend WithEvents testResultsGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents elapsedTimeLabel As System.Windows.Forms.Label
    Friend WithEvents displayedDataRichTextBox As System.Windows.Forms.RichTextBox
    Friend WithEvents descriptionGroupBox As System.Windows.Forms.GroupBox

End Class
