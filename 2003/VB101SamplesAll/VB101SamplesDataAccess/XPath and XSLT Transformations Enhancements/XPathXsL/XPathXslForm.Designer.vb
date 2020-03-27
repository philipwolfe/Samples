<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class xpathXslForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(xpathXslForm))
        Me.rowsReturned = New System.Windows.Forms.Label
        Me.elapsedTime = New System.Windows.Forms.Label
        Me.testResultsGroupBox = New System.Windows.Forms.GroupBox
        Me.rowsReturnedTextLabel = New System.Windows.Forms.Label
        Me.elapsedTimeTextLabel = New System.Windows.Forms.Label
        Me.displayResultsLabel = New System.Windows.Forms.Label
        Me.loadlDataLabel = New System.Windows.Forms.Label
        Me.greaterThanDollarLabel = New System.Windows.Forms.Label
        Me.descriptionLinesLabel = New System.Windows.Forms.Label
        Me.choosePriceLabel = New System.Windows.Forms.Label
        Me.priceChoiceComboBox = New System.Windows.Forms.ComboBox
        Me.loadXMLButton = New System.Windows.Forms.Button
        Me.displayDataButton = New System.Windows.Forms.Button
        Me.resultsWebBrowser = New System.Windows.Forms.WebBrowser
        Me.descriptionGroupBox = New System.Windows.Forms.GroupBox
        Me.testResultsGroupBox.SuspendLayout()
        Me.descriptionGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'rowsReturned
        '
        Me.rowsReturned.AutoSize = True
        Me.rowsReturned.Location = New System.Drawing.Point(10, 92)
        Me.rowsReturned.Name = "rowsReturned"
        Me.rowsReturned.Size = New System.Drawing.Size(0, 0)
        Me.rowsReturned.TabIndex = 3
        '
        'elapsedTime
        '
        Me.elapsedTime.AutoSize = True
        Me.elapsedTime.Location = New System.Drawing.Point(9, 41)
        Me.elapsedTime.Name = "elapsedTime"
        Me.elapsedTime.Size = New System.Drawing.Size(0, 0)
        Me.elapsedTime.TabIndex = 2
        '
        'testResultsGroupBox
        '
        Me.testResultsGroupBox.Controls.Add(Me.rowsReturned)
        Me.testResultsGroupBox.Controls.Add(Me.elapsedTime)
        Me.testResultsGroupBox.Controls.Add(Me.rowsReturnedTextLabel)
        Me.testResultsGroupBox.Controls.Add(Me.elapsedTimeTextLabel)
        Me.testResultsGroupBox.Location = New System.Drawing.Point(217, 119)
        Me.testResultsGroupBox.Name = "testResultsGroupBox"
        Me.testResultsGroupBox.Size = New System.Drawing.Size(128, 145)
        Me.testResultsGroupBox.TabIndex = 18
        Me.testResultsGroupBox.TabStop = False
        Me.testResultsGroupBox.Text = "Test Results"
        '
        'rowsReturnedTextLabel
        '
        Me.rowsReturnedTextLabel.AutoSize = True
        Me.rowsReturnedTextLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rowsReturnedTextLabel.Location = New System.Drawing.Point(6, 65)
        Me.rowsReturnedTextLabel.Name = "rowsReturnedTextLabel"
        Me.rowsReturnedTextLabel.Size = New System.Drawing.Size(94, 13)
        Me.rowsReturnedTextLabel.TabIndex = 1
        Me.rowsReturnedTextLabel.Text = "Rows Returned:"
        '
        'elapsedTimeTextLabel
        '
        Me.elapsedTimeTextLabel.AutoSize = True
        Me.elapsedTimeTextLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.elapsedTimeTextLabel.Location = New System.Drawing.Point(7, 20)
        Me.elapsedTimeTextLabel.Name = "elapsedTimeTextLabel"
        Me.elapsedTimeTextLabel.Size = New System.Drawing.Size(83, 13)
        Me.elapsedTimeTextLabel.TabIndex = 0
        Me.elapsedTimeTextLabel.Text = "Elapsed Time:"
        '
        'displayResultsLabel
        '
        Me.displayResultsLabel.AutoSize = True
        Me.displayResultsLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.displayResultsLabel.Location = New System.Drawing.Point(18, 294)
        Me.displayResultsLabel.Name = "displayResultsLabel"
        Me.displayResultsLabel.Size = New System.Drawing.Size(192, 20)
        Me.displayResultsLabel.TabIndex = 19
        Me.displayResultsLabel.Text = "Step 3: Display Results"
        '
        'loadlDataLabel
        '
        Me.loadlDataLabel.AutoSize = True
        Me.loadlDataLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.loadlDataLabel.Location = New System.Drawing.Point(16, 132)
        Me.loadlDataLabel.Name = "loadlDataLabel"
        Me.loadlDataLabel.Size = New System.Drawing.Size(152, 20)
        Me.loadlDataLabel.TabIndex = 11
        Me.loadlDataLabel.Text = "Step 1: Load Data"
        '
        'greaterThanDollarLabel
        '
        Me.greaterThanDollarLabel.AutoSize = True
        Me.greaterThanDollarLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.greaterThanDollarLabel.Location = New System.Drawing.Point(30, 239)
        Me.greaterThanDollarLabel.Name = "greaterThanDollarLabel"
        Me.greaterThanDollarLabel.Size = New System.Drawing.Size(30, 20)
        Me.greaterThanDollarLabel.TabIndex = 17
        Me.greaterThanDollarLabel.Text = "> $"
        '
        'descriptionLinesLabel
        '
        Me.descriptionLinesLabel.AutoSize = True
        Me.descriptionLinesLabel.Location = New System.Drawing.Point(6, 17)
        Me.descriptionLinesLabel.Name = "descriptionLinesLabel"
        Me.descriptionLinesLabel.Size = New System.Drawing.Size(632, 65)
        Me.descriptionLinesLabel.TabIndex = 0
        Me.descriptionLinesLabel.Text = resources.GetString("descriptionLinesLabel.Text")
        '
        'choosePriceLabel
        '
        Me.choosePriceLabel.AutoSize = True
        Me.choosePriceLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.choosePriceLabel.Location = New System.Drawing.Point(16, 194)
        Me.choosePriceLabel.Name = "choosePriceLabel"
        Me.choosePriceLabel.Size = New System.Drawing.Size(194, 20)
        Me.choosePriceLabel.TabIndex = 16
        Me.choosePriceLabel.Text = "Step 2: Choose a Price:"
        '
        'priceChoiceComboBox
        '
        Me.priceChoiceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.priceChoiceComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.priceChoiceComboBox.FormattingEnabled = True
        Me.priceChoiceComboBox.Location = New System.Drawing.Point(64, 236)
        Me.priceChoiceComboBox.Name = "priceChoiceComboBox"
        Me.priceChoiceComboBox.Size = New System.Drawing.Size(51, 28)
        Me.priceChoiceComboBox.TabIndex = 15
        '
        'loadXMLButton
        '
        Me.loadXMLButton.Location = New System.Drawing.Point(18, 168)
        Me.loadXMLButton.Name = "loadXMLButton"
        Me.loadXMLButton.Size = New System.Drawing.Size(75, 23)
        Me.loadXMLButton.TabIndex = 14
        Me.loadXMLButton.Text = "Load XML"
        '
        'displayDataButton
        '
        Me.displayDataButton.Location = New System.Drawing.Point(18, 332)
        Me.displayDataButton.Name = "displayDataButton"
        Me.displayDataButton.Size = New System.Drawing.Size(75, 23)
        Me.displayDataButton.TabIndex = 13
        Me.displayDataButton.Text = "Display Data"
        '
        'resultsWebBrowser
        '
        Me.resultsWebBrowser.Location = New System.Drawing.Point(362, 119)
        Me.resultsWebBrowser.Name = "resultsWebBrowser"
        Me.resultsWebBrowser.Size = New System.Drawing.Size(350, 273)
        '
        'descriptionGroupBox
        '
        Me.descriptionGroupBox.Controls.Add(Me.descriptionLinesLabel)
        Me.descriptionGroupBox.Location = New System.Drawing.Point(18, 12)
        Me.descriptionGroupBox.Name = "descriptionGroupBox"
        Me.descriptionGroupBox.Size = New System.Drawing.Size(694, 100)
        Me.descriptionGroupBox.TabIndex = 12
        Me.descriptionGroupBox.TabStop = False
        Me.descriptionGroupBox.Text = "Description"
        '
        'xpathXslForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(729, 404)
        Me.Controls.Add(Me.testResultsGroupBox)
        Me.Controls.Add(Me.displayResultsLabel)
        Me.Controls.Add(Me.loadlDataLabel)
        Me.Controls.Add(Me.greaterThanDollarLabel)
        Me.Controls.Add(Me.choosePriceLabel)
        Me.Controls.Add(Me.priceChoiceComboBox)
        Me.Controls.Add(Me.loadXMLButton)
        Me.Controls.Add(Me.displayDataButton)
        Me.Controls.Add(Me.resultsWebBrowser)
        Me.Controls.Add(Me.descriptionGroupBox)
        Me.Name = "xpathXslForm"
        Me.Text = "XPath and XSLT Transformation Example"
        Me.testResultsGroupBox.ResumeLayout(False)
        Me.testResultsGroupBox.PerformLayout()
        Me.descriptionGroupBox.ResumeLayout(False)
        Me.descriptionGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rowsReturned As System.Windows.Forms.Label
    Friend WithEvents elapsedTime As System.Windows.Forms.Label
    Friend WithEvents testResultsGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents rowsReturnedTextLabel As System.Windows.Forms.Label
    Friend WithEvents elapsedTimeTextLabel As System.Windows.Forms.Label
    Friend WithEvents displayResultsLabel As System.Windows.Forms.Label
    Friend WithEvents loadlDataLabel As System.Windows.Forms.Label
    Friend WithEvents greaterThanDollarLabel As System.Windows.Forms.Label
    Friend WithEvents descriptionLinesLabel As System.Windows.Forms.Label
    Friend WithEvents choosePriceLabel As System.Windows.Forms.Label
    Friend WithEvents priceChoiceComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents loadXMLButton As System.Windows.Forms.Button
    Friend WithEvents displayDataButton As System.Windows.Forms.Button
    Friend WithEvents resultsWebBrowser As System.Windows.Forms.WebBrowser
    Friend WithEvents descriptionGroupBox As System.Windows.Forms.GroupBox

End Class
