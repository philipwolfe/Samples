<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class StoredProcedureUDFForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StoredProcedureUDFForm))
        Me.elapsedTimeLabel = New System.Windows.Forms.Label
        Me.resultsDataGridView = New System.Windows.Forms.DataGridView
        Me.actionLabel = New System.Windows.Forms.Label
        Me.insertNewDataButton = New System.Windows.Forms.Button
        Me.latitude2Label = New System.Windows.Forms.Label
        Me.longitude2Label = New System.Windows.Forms.Label
        Me.latitude1Label = New System.Windows.Forms.Label
        Me.longitude1Label = New System.Windows.Forms.Label
        Me.latitude2TextBox = New System.Windows.Forms.TextBox
        Me.longitude2TextBox = New System.Windows.Forms.TextBox
        Me.latitude1TextBox = New System.Windows.Forms.TextBox
        Me.testResultsGroupBox = New System.Windows.Forms.GroupBox
        Me.longitude1TextBox = New System.Windows.Forms.TextBox
        Me.descriptionGroupBox = New System.Windows.Forms.GroupBox
        Me.descriptionLineLabel = New System.Windows.Forms.Label
        Me.retrieveDataButton = New System.Windows.Forms.Button
        CType(Me.resultsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.testResultsGroupBox.SuspendLayout()
        Me.descriptionGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'elapsedTimeLabel
        '
        Me.elapsedTimeLabel.AutoSize = True
        Me.elapsedTimeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.elapsedTimeLabel.Location = New System.Drawing.Point(6, 68)
        Me.elapsedTimeLabel.Name = "elapsedTimeLabel"
        Me.elapsedTimeLabel.Size = New System.Drawing.Size(83, 13)
        Me.elapsedTimeLabel.TabIndex = 1
        Me.elapsedTimeLabel.Text = "Elapsed Time:"
        '
        'resultsDataGridView
        '
        Me.resultsDataGridView.Location = New System.Drawing.Point(309, 193)
        Me.resultsDataGridView.Name = "resultsDataGridView"
        Me.resultsDataGridView.ReadOnly = True
        Me.resultsDataGridView.Size = New System.Drawing.Size(282, 248)
        Me.resultsDataGridView.TabIndex = 23
        Me.resultsDataGridView.Text = "dataGridView1"
        '
        'actionLabel
        '
        Me.actionLabel.AutoSize = True
        Me.actionLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.actionLabel.Location = New System.Drawing.Point(6, 27)
        Me.actionLabel.Name = "actionLabel"
        Me.actionLabel.Size = New System.Drawing.Size(43, 13)
        Me.actionLabel.TabIndex = 0
        Me.actionLabel.Text = "Action:"
        '
        'insertNewDataButton
        '
        Me.insertNewDataButton.Location = New System.Drawing.Point(13, 378)
        Me.insertNewDataButton.Name = "insertNewDataButton"
        Me.insertNewDataButton.Size = New System.Drawing.Size(100, 23)
        Me.insertNewDataButton.TabIndex = 18
        Me.insertNewDataButton.Text = "Insert New Data"
        '
        'latitude2Label
        '
        Me.latitude2Label.AutoSize = True
        Me.latitude2Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.latitude2Label.Location = New System.Drawing.Point(12, 319)
        Me.latitude2Label.Name = "latitude2Label"
        Me.latitude2Label.Size = New System.Drawing.Size(64, 13)
        Me.latitude2Label.TabIndex = 22
        Me.latitude2Label.Text = "Latitude 2:"
        '
        'longitude2Label
        '
        Me.longitude2Label.AutoSize = True
        Me.longitude2Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.longitude2Label.Location = New System.Drawing.Point(12, 277)
        Me.longitude2Label.Name = "longitude2Label"
        Me.longitude2Label.Size = New System.Drawing.Size(74, 13)
        Me.longitude2Label.TabIndex = 21
        Me.longitude2Label.Text = "Longitude 2:"
        '
        'latitude1Label
        '
        Me.latitude1Label.AutoSize = True
        Me.latitude1Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.latitude1Label.Location = New System.Drawing.Point(12, 236)
        Me.latitude1Label.Name = "latitude1Label"
        Me.latitude1Label.Size = New System.Drawing.Size(64, 13)
        Me.latitude1Label.TabIndex = 20
        Me.latitude1Label.Text = "Latitude 1:"
        '
        'longitude1Label
        '
        Me.longitude1Label.AutoSize = True
        Me.longitude1Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.longitude1Label.Location = New System.Drawing.Point(12, 191)
        Me.longitude1Label.Name = "longitude1Label"
        Me.longitude1Label.Size = New System.Drawing.Size(74, 13)
        Me.longitude1Label.TabIndex = 14
        Me.longitude1Label.Text = "Longitude 1:"
        '
        'latitude2TextBox
        '
        Me.latitude2TextBox.Location = New System.Drawing.Point(13, 341)
        Me.latitude2TextBox.Name = "latitude2TextBox"
        Me.latitude2TextBox.Size = New System.Drawing.Size(100, 20)
        Me.latitude2TextBox.TabIndex = 17
        '
        'longitude2TextBox
        '
        Me.longitude2TextBox.Location = New System.Drawing.Point(13, 296)
        Me.longitude2TextBox.Name = "longitude2TextBox"
        Me.longitude2TextBox.Size = New System.Drawing.Size(100, 20)
        Me.longitude2TextBox.TabIndex = 15
        '
        'latitude1TextBox
        '
        Me.latitude1TextBox.Location = New System.Drawing.Point(13, 254)
        Me.latitude1TextBox.Name = "latitude1TextBox"
        Me.latitude1TextBox.Size = New System.Drawing.Size(100, 20)
        Me.latitude1TextBox.TabIndex = 13
        '
        'testResultsGroupBox
        '
        Me.testResultsGroupBox.Controls.Add(Me.elapsedTimeLabel)
        Me.testResultsGroupBox.Controls.Add(Me.actionLabel)
        Me.testResultsGroupBox.Location = New System.Drawing.Point(134, 193)
        Me.testResultsGroupBox.Name = "testResultsGroupBox"
        Me.testResultsGroupBox.Size = New System.Drawing.Size(153, 248)
        Me.testResultsGroupBox.TabIndex = 16
        Me.testResultsGroupBox.TabStop = False
        Me.testResultsGroupBox.Text = "Test Results"
        '
        'longitude1TextBox
        '
        Me.longitude1TextBox.Location = New System.Drawing.Point(13, 213)
        Me.longitude1TextBox.Name = "longitude1TextBox"
        Me.longitude1TextBox.Size = New System.Drawing.Size(100, 20)
        Me.longitude1TextBox.TabIndex = 12
        '
        'descriptionGroupBox
        '
        Me.descriptionGroupBox.Controls.Add(Me.descriptionLineLabel)
        Me.descriptionGroupBox.Location = New System.Drawing.Point(13, 13)
        Me.descriptionGroupBox.Name = "descriptionGroupBox"
        Me.descriptionGroupBox.Size = New System.Drawing.Size(578, 154)
        Me.descriptionGroupBox.TabIndex = 11
        Me.descriptionGroupBox.TabStop = False
        Me.descriptionGroupBox.Text = "Description"
        '
        'descriptionLineLabel
        '
        Me.descriptionLineLabel.AutoSize = True
        Me.descriptionLineLabel.Location = New System.Drawing.Point(6, 16)
        Me.descriptionLineLabel.Name = "descriptionLineLabel"
        Me.descriptionLineLabel.Size = New System.Drawing.Size(530, 117)
        Me.descriptionLineLabel.TabIndex = 0
        Me.descriptionLineLabel.Text = resources.GetString("descriptionLineLabel.Text")
        '
        'retrieveDataButton
        '
        Me.retrieveDataButton.Location = New System.Drawing.Point(13, 418)
        Me.retrieveDataButton.Name = "retrieveDataButton"
        Me.retrieveDataButton.Size = New System.Drawing.Size(100, 23)
        Me.retrieveDataButton.TabIndex = 19
        Me.retrieveDataButton.Text = "Retrieve Data"
        '
        'StoredProcedureUDFForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(602, 455)
        Me.Controls.Add(Me.resultsDataGridView)
        Me.Controls.Add(Me.insertNewDataButton)
        Me.Controls.Add(Me.latitude2Label)
        Me.Controls.Add(Me.longitude2Label)
        Me.Controls.Add(Me.latitude1Label)
        Me.Controls.Add(Me.longitude1Label)
        Me.Controls.Add(Me.latitude2TextBox)
        Me.Controls.Add(Me.longitude2TextBox)
        Me.Controls.Add(Me.latitude1TextBox)
        Me.Controls.Add(Me.testResultsGroupBox)
        Me.Controls.Add(Me.longitude1TextBox)
        Me.Controls.Add(Me.descriptionGroupBox)
        Me.Controls.Add(Me.retrieveDataButton)
        Me.Name = "StoredProcedureUDFForm"
        Me.Text = "Stored Procedure and User Defined Function Example"
        CType(Me.resultsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.testResultsGroupBox.ResumeLayout(False)
        Me.testResultsGroupBox.PerformLayout()
        Me.descriptionGroupBox.ResumeLayout(False)
        Me.descriptionGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents elapsedTimeLabel As System.Windows.Forms.Label
    Friend WithEvents resultsDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents actionLabel As System.Windows.Forms.Label
    Friend WithEvents insertNewDataButton As System.Windows.Forms.Button
    Friend WithEvents latitude2Label As System.Windows.Forms.Label
    Friend WithEvents longitude2Label As System.Windows.Forms.Label
    Friend WithEvents latitude1Label As System.Windows.Forms.Label
    Friend WithEvents longitude1Label As System.Windows.Forms.Label
    Friend WithEvents latitude2TextBox As System.Windows.Forms.TextBox
    Friend WithEvents longitude2TextBox As System.Windows.Forms.TextBox
    Friend WithEvents latitude1TextBox As System.Windows.Forms.TextBox
    Friend WithEvents testResultsGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents longitude1TextBox As System.Windows.Forms.TextBox
    Friend WithEvents descriptionGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents descriptionLineLabel As System.Windows.Forms.Label
    Friend WithEvents retrieveDataButton As System.Windows.Forms.Button

End Class
