<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class UserDefinedTypesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserDefinedTypesForm))
        Me.testResultsGroupBox = New System.Windows.Forms.GroupBox
        Me.timeElapsedLabel = New System.Windows.Forms.Label
        Me.rowsAffectedLabel = New System.Windows.Forms.Label
        Me.cityLabel = New System.Windows.Forms.Label
        Me.latitudeLabel = New System.Windows.Forms.Label
        Me.longitudeLabel = New System.Windows.Forms.Label
        Me.displayRichTextBox = New System.Windows.Forms.RichTextBox
        Me.descriptionLineLabel = New System.Windows.Forms.Label
        Me.enterNewLocationButton = New System.Windows.Forms.Button
        Me.cityTextBox = New System.Windows.Forms.TextBox
        Me.latitudeTextBox = New System.Windows.Forms.TextBox
        Me.longitudeTextBox = New System.Windows.Forms.TextBox
        Me.descriptionGroupBox = New System.Windows.Forms.GroupBox
        Me.testResultsGroupBox.SuspendLayout()
        Me.descriptionGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'testResultsGroupBox
        '
        Me.testResultsGroupBox.Controls.Add(Me.timeElapsedLabel)
        Me.testResultsGroupBox.Controls.Add(Me.rowsAffectedLabel)
        Me.testResultsGroupBox.Location = New System.Drawing.Point(205, 210)
        Me.testResultsGroupBox.Name = "testResultsGroupBox"
        Me.testResultsGroupBox.Size = New System.Drawing.Size(175, 159)
        Me.testResultsGroupBox.TabIndex = 19
        Me.testResultsGroupBox.TabStop = False
        Me.testResultsGroupBox.Text = "Test Results"
        '
        'timeElapsedLabel
        '
        Me.timeElapsedLabel.AutoSize = True
        Me.timeElapsedLabel.Location = New System.Drawing.Point(7, 84)
        Me.timeElapsedLabel.Name = "timeElapsedLabel"
        Me.timeElapsedLabel.Size = New System.Drawing.Size(70, 13)
        Me.timeElapsedLabel.TabIndex = 1
        Me.timeElapsedLabel.Text = "Time Elapsed:"
        '
        'rowsAffectedLabel
        '
        Me.rowsAffectedLabel.AutoSize = True
        Me.rowsAffectedLabel.Location = New System.Drawing.Point(7, 37)
        Me.rowsAffectedLabel.Name = "rowsAffectedLabel"
        Me.rowsAffectedLabel.Size = New System.Drawing.Size(76, 13)
        Me.rowsAffectedLabel.TabIndex = 0
        Me.rowsAffectedLabel.Text = "Rows Affected:"
        '
        'cityLabel
        '
        Me.cityLabel.AutoSize = True
        Me.cityLabel.Location = New System.Drawing.Point(12, 289)
        Me.cityLabel.Name = "cityLabel"
        Me.cityLabel.Size = New System.Drawing.Size(23, 13)
        Me.cityLabel.TabIndex = 18
        Me.cityLabel.Text = "City:"
        '
        'latitudeLabel
        '
        Me.latitudeLabel.AutoSize = True
        Me.latitudeLabel.Location = New System.Drawing.Point(12, 249)
        Me.latitudeLabel.Name = "latitudeLabel"
        Me.latitudeLabel.Size = New System.Drawing.Size(44, 13)
        Me.latitudeLabel.TabIndex = 17
        Me.latitudeLabel.Text = "Latitude:"
        '
        'longitudeLabel
        '
        Me.longitudeLabel.AutoSize = True
        Me.longitudeLabel.Location = New System.Drawing.Point(12, 213)
        Me.longitudeLabel.Name = "longitudeLabel"
        Me.longitudeLabel.Size = New System.Drawing.Size(53, 13)
        Me.longitudeLabel.TabIndex = 16
        Me.longitudeLabel.Text = "Longitude:"
        '
        'displayRichTextBox
        '
        Me.displayRichTextBox.Location = New System.Drawing.Point(386, 210)
        Me.displayRichTextBox.Name = "displayRichTextBox"
        Me.displayRichTextBox.ReadOnly = True
        Me.displayRichTextBox.Size = New System.Drawing.Size(208, 159)
        Me.displayRichTextBox.TabIndex = 15
        Me.displayRichTextBox.Text = ""
        '
        'descriptionLineLabel
        '
        Me.descriptionLineLabel.AutoSize = True
        Me.descriptionLineLabel.Location = New System.Drawing.Point(6, 16)
        Me.descriptionLineLabel.Name = "descriptionLineLabel"
        Me.descriptionLineLabel.Size = New System.Drawing.Size(546, 156)
        Me.descriptionLineLabel.TabIndex = 0
        Me.descriptionLineLabel.Text = resources.GetString("descriptionLineLabel.Text")
        '
        'enterNewLocationButton
        '
        Me.enterNewLocationButton.Location = New System.Drawing.Point(13, 324)
        Me.enterNewLocationButton.Name = "enterNewLocationButton"
        Me.enterNewLocationButton.Size = New System.Drawing.Size(187, 23)
        Me.enterNewLocationButton.TabIndex = 14
        Me.enterNewLocationButton.Text = "Enter a New Geocache Location"
        '
        'cityTextBox
        '
        Me.cityTextBox.Location = New System.Drawing.Point(71, 286)
        Me.cityTextBox.Name = "cityTextBox"
        Me.cityTextBox.Size = New System.Drawing.Size(100, 20)
        Me.cityTextBox.TabIndex = 13
        '
        'latitudeTextBox
        '
        Me.latitudeTextBox.Location = New System.Drawing.Point(71, 246)
        Me.latitudeTextBox.Name = "latitudeTextBox"
        Me.latitudeTextBox.Size = New System.Drawing.Size(100, 20)
        Me.latitudeTextBox.TabIndex = 12
        '
        'longitudeTextBox
        '
        Me.longitudeTextBox.Location = New System.Drawing.Point(71, 210)
        Me.longitudeTextBox.Name = "longitudeTextBox"
        Me.longitudeTextBox.Size = New System.Drawing.Size(100, 20)
        Me.longitudeTextBox.TabIndex = 11
        '
        'descriptionGroupBox
        '
        Me.descriptionGroupBox.Controls.Add(Me.descriptionLineLabel)
        Me.descriptionGroupBox.Location = New System.Drawing.Point(12, 12)
        Me.descriptionGroupBox.Name = "descriptionGroupBox"
        Me.descriptionGroupBox.Size = New System.Drawing.Size(582, 192)
        Me.descriptionGroupBox.TabIndex = 10
        Me.descriptionGroupBox.TabStop = False
        Me.descriptionGroupBox.Text = "Description"
        '
        'UserDefinedTypesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(606, 381)
        Me.Controls.Add(Me.testResultsGroupBox)
        Me.Controls.Add(Me.cityLabel)
        Me.Controls.Add(Me.latitudeLabel)
        Me.Controls.Add(Me.longitudeLabel)
        Me.Controls.Add(Me.displayRichTextBox)
        Me.Controls.Add(Me.enterNewLocationButton)
        Me.Controls.Add(Me.cityTextBox)
        Me.Controls.Add(Me.latitudeTextBox)
        Me.Controls.Add(Me.longitudeTextBox)
        Me.Controls.Add(Me.descriptionGroupBox)
        Me.Name = "UserDefinedTypesForm"
        Me.Text = "User Defined Type Example"
        Me.testResultsGroupBox.ResumeLayout(False)
        Me.testResultsGroupBox.PerformLayout()
        Me.descriptionGroupBox.ResumeLayout(False)
        Me.descriptionGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents testResultsGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents timeElapsedLabel As System.Windows.Forms.Label
    Friend WithEvents rowsAffectedLabel As System.Windows.Forms.Label
    Friend WithEvents cityLabel As System.Windows.Forms.Label
    Friend WithEvents latitudeLabel As System.Windows.Forms.Label
    Friend WithEvents longitudeLabel As System.Windows.Forms.Label
    Friend WithEvents displayRichTextBox As System.Windows.Forms.RichTextBox
    Friend WithEvents descriptionLineLabel As System.Windows.Forms.Label
    Friend WithEvents enterNewLocationButton As System.Windows.Forms.Button
    Friend WithEvents cityTextBox As System.Windows.Forms.TextBox
    Friend WithEvents latitudeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents longitudeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents descriptionGroupBox As System.Windows.Forms.GroupBox

End Class
