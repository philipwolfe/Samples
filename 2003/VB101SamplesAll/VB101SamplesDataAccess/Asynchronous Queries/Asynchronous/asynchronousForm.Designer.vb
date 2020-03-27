<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class asynchronousForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(asynchronousForm))
        Me.queryStatusStatusBar = New System.Windows.Forms.ProgressBar
        Me.fillTablesButton = New System.Windows.Forms.Button
        Me.population2Label = New System.Windows.Forms.Label
        Me.elapsedTime2 = New System.Windows.Forms.Label
        Me.population1Label = New System.Windows.Forms.Label
        Me.statusLabel = New System.Windows.Forms.Label
        Me.waitAsynchButton = New System.Windows.Forms.Button
        Me.population2DataGridView = New System.Windows.Forms.DataGridView
        Me.population1DataGridView = New System.Windows.Forms.DataGridView
        Me.callBackAsynchButton = New System.Windows.Forms.Button
        Me.pollingAsynchButton = New System.Windows.Forms.Button
        Me.elapsedTime = New System.Windows.Forms.Label
        Me.descriptionGroupBox = New System.Windows.Forms.GroupBox
        Me.descriptionLineLabel = New System.Windows.Forms.Label
        Me.elapsedTimeLabel = New System.Windows.Forms.Label
        Me.messageReturned = New System.Windows.Forms.Label
        Me.messageTextLabel = New System.Windows.Forms.Label
        Me.testResultsGroupBox = New System.Windows.Forms.GroupBox
        CType(Me.population2DataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.population1DataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.descriptionGroupBox.SuspendLayout()
        Me.testResultsGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'queryStatusStatusBar
        '
        Me.queryStatusStatusBar.Enabled = False
        Me.queryStatusStatusBar.Location = New System.Drawing.Point(6, 184)
        Me.queryStatusStatusBar.Name = "queryStatusStatusBar"
        Me.queryStatusStatusBar.Size = New System.Drawing.Size(100, 23)
        Me.queryStatusStatusBar.TabIndex = 5
        '
        'fillTablesButton
        '
        Me.fillTablesButton.Location = New System.Drawing.Point(26, 164)
        Me.fillTablesButton.Name = "fillTablesButton"
        Me.fillTablesButton.Size = New System.Drawing.Size(75, 23)
        Me.fillTablesButton.TabIndex = 10
        Me.fillTablesButton.Text = "Fill Tables"
        '
        'population2Label
        '
        Me.population2Label.AutoSize = True
        Me.population2Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.population2Label.Location = New System.Drawing.Point(523, 154)
        Me.population2Label.Name = "population2Label"
        Me.population2Label.Size = New System.Drawing.Size(147, 13)
        Me.population2Label.TabIndex = 17
        Me.population2Label.Text = "Population in County # 2"
        '
        'elapsedTime2
        '
        Me.elapsedTime2.AutoSize = True
        Me.elapsedTime2.Location = New System.Drawing.Point(6, 144)
        Me.elapsedTime2.Name = "elapsedTime2"
        Me.elapsedTime2.Size = New System.Drawing.Size(0, 13)
        Me.elapsedTime2.TabIndex = 6
        '
        'population1Label
        '
        Me.population1Label.AutoSize = True
        Me.population1Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.population1Label.Location = New System.Drawing.Point(320, 154)
        Me.population1Label.Name = "population1Label"
        Me.population1Label.Size = New System.Drawing.Size(147, 13)
        Me.population1Label.TabIndex = 16
        Me.population1Label.Text = "Population in County # 1"
        '
        'statusLabel
        '
        Me.statusLabel.AutoSize = True
        Me.statusLabel.Enabled = False
        Me.statusLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.statusLabel.Location = New System.Drawing.Point(6, 166)
        Me.statusLabel.Name = "statusLabel"
        Me.statusLabel.Size = New System.Drawing.Size(43, 13)
        Me.statusLabel.TabIndex = 4
        Me.statusLabel.Text = "Status"
        '
        'waitAsynchButton
        '
        Me.waitAsynchButton.Location = New System.Drawing.Point(26, 301)
        Me.waitAsynchButton.Name = "waitAsynchButton"
        Me.waitAsynchButton.Size = New System.Drawing.Size(75, 23)
        Me.waitAsynchButton.TabIndex = 9
        Me.waitAsynchButton.Text = "Wait"
        '
        'population2DataGridView
        '
        Me.population2DataGridView.Location = New System.Drawing.Point(524, 176)
        Me.population2DataGridView.Name = "population2DataGridView"
        Me.population2DataGridView.ReadOnly = True
        Me.population2DataGridView.Size = New System.Drawing.Size(186, 194)
        Me.population2DataGridView.TabIndex = 15
        Me.population2DataGridView.Text = "dataGridView2"
        '
        'population1DataGridView
        '
        Me.population1DataGridView.Location = New System.Drawing.Point(321, 176)
        Me.population1DataGridView.Name = "population1DataGridView"
        Me.population1DataGridView.ReadOnly = True
        Me.population1DataGridView.Size = New System.Drawing.Size(197, 194)
        Me.population1DataGridView.TabIndex = 14
        Me.population1DataGridView.Text = "dataGridView1"
        '
        'callBackAsynchButton
        '
        Me.callBackAsynchButton.Location = New System.Drawing.Point(26, 257)
        Me.callBackAsynchButton.Name = "callBackAsynchButton"
        Me.callBackAsynchButton.Size = New System.Drawing.Size(75, 23)
        Me.callBackAsynchButton.TabIndex = 13
        Me.callBackAsynchButton.Text = "Callback"
        '
        'pollingAsynchButton
        '
        Me.pollingAsynchButton.Location = New System.Drawing.Point(26, 211)
        Me.pollingAsynchButton.Name = "pollingAsynchButton"
        Me.pollingAsynchButton.Size = New System.Drawing.Size(75, 23)
        Me.pollingAsynchButton.TabIndex = 12
        Me.pollingAsynchButton.Text = "Polling"
        '
        'elapsedTime
        '
        Me.elapsedTime.AutoSize = True
        Me.elapsedTime.Location = New System.Drawing.Point(6, 122)
        Me.elapsedTime.Name = "elapsedTime"
        Me.elapsedTime.Size = New System.Drawing.Size(0, 13)
        Me.elapsedTime.TabIndex = 3
        '
        'descriptionGroupBox
        '
        Me.descriptionGroupBox.Controls.Add(Me.descriptionLineLabel)
        Me.descriptionGroupBox.Location = New System.Drawing.Point(12, 12)
        Me.descriptionGroupBox.Name = "descriptionGroupBox"
        Me.descriptionGroupBox.Size = New System.Drawing.Size(698, 117)
        Me.descriptionGroupBox.TabIndex = 8
        Me.descriptionGroupBox.TabStop = False
        Me.descriptionGroupBox.Text = "Description"
        '
        'descriptionLineLabel
        '
        Me.descriptionLineLabel.AutoSize = True
        Me.descriptionLineLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.descriptionLineLabel.Location = New System.Drawing.Point(3, 16)
        Me.descriptionLineLabel.Name = "descriptionLineLabel"
        Me.descriptionLineLabel.Size = New System.Drawing.Size(692, 78)
        Me.descriptionLineLabel.TabIndex = 1
        Me.descriptionLineLabel.Text = resources.GetString("descriptionLineLabel.Text")
        '
        'elapsedTimeLabel
        '
        Me.elapsedTimeLabel.AutoSize = True
        Me.elapsedTimeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.elapsedTimeLabel.Location = New System.Drawing.Point(6, 95)
        Me.elapsedTimeLabel.Name = "elapsedTimeLabel"
        Me.elapsedTimeLabel.Size = New System.Drawing.Size(87, 13)
        Me.elapsedTimeLabel.TabIndex = 2
        Me.elapsedTimeLabel.Text = "Elapsed Time:"
        '
        'messageReturned
        '
        Me.messageReturned.AutoSize = True
        Me.messageReturned.Location = New System.Drawing.Point(6, 59)
        Me.messageReturned.Name = "messageReturned"
        Me.messageReturned.Size = New System.Drawing.Size(0, 13)
        Me.messageReturned.TabIndex = 1
        '
        'messageTextLabel
        '
        Me.messageTextLabel.AutoSize = True
        Me.messageTextLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.messageTextLabel.Location = New System.Drawing.Point(6, 29)
        Me.messageTextLabel.Name = "messageTextLabel"
        Me.messageTextLabel.Size = New System.Drawing.Size(61, 13)
        Me.messageTextLabel.TabIndex = 0
        Me.messageTextLabel.Text = "Message:"
        '
        'testResultsGroupBox
        '
        Me.testResultsGroupBox.Controls.Add(Me.elapsedTime2)
        Me.testResultsGroupBox.Controls.Add(Me.queryStatusStatusBar)
        Me.testResultsGroupBox.Controls.Add(Me.statusLabel)
        Me.testResultsGroupBox.Controls.Add(Me.elapsedTime)
        Me.testResultsGroupBox.Controls.Add(Me.elapsedTimeLabel)
        Me.testResultsGroupBox.Controls.Add(Me.messageReturned)
        Me.testResultsGroupBox.Controls.Add(Me.messageTextLabel)
        Me.testResultsGroupBox.Location = New System.Drawing.Point(138, 135)
        Me.testResultsGroupBox.Name = "testResultsGroupBox"
        Me.testResultsGroupBox.Size = New System.Drawing.Size(176, 235)
        Me.testResultsGroupBox.TabIndex = 11
        Me.testResultsGroupBox.TabStop = False
        Me.testResultsGroupBox.Text = "Test Results"
        '
        'asynchronousForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(722, 382)
        Me.Controls.Add(Me.fillTablesButton)
        Me.Controls.Add(Me.population2Label)
        Me.Controls.Add(Me.population1Label)
        Me.Controls.Add(Me.waitAsynchButton)
        Me.Controls.Add(Me.population2DataGridView)
        Me.Controls.Add(Me.population1DataGridView)
        Me.Controls.Add(Me.callBackAsynchButton)
        Me.Controls.Add(Me.pollingAsynchButton)
        Me.Controls.Add(Me.descriptionGroupBox)
        Me.Controls.Add(Me.testResultsGroupBox)
        Me.Name = "asynchronousForm"
        Me.Text = "Asynchronous Example"
        CType(Me.population2DataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.population1DataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.descriptionGroupBox.ResumeLayout(False)
        Me.descriptionGroupBox.PerformLayout()
        Me.testResultsGroupBox.ResumeLayout(False)
        Me.testResultsGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents queryStatusStatusBar As System.Windows.Forms.ProgressBar
    Friend WithEvents fillTablesButton As System.Windows.Forms.Button
    Friend WithEvents population2Label As System.Windows.Forms.Label
    Friend WithEvents elapsedTime2 As System.Windows.Forms.Label
    Friend WithEvents population1Label As System.Windows.Forms.Label
    Friend WithEvents statusLabel As System.Windows.Forms.Label
    Friend WithEvents waitAsynchButton As System.Windows.Forms.Button
    Friend WithEvents population2DataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents population1DataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents callBackAsynchButton As System.Windows.Forms.Button
    Friend WithEvents pollingAsynchButton As System.Windows.Forms.Button
    Friend WithEvents elapsedTime As System.Windows.Forms.Label
    Friend WithEvents descriptionGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents elapsedTimeLabel As System.Windows.Forms.Label
    Friend WithEvents messageReturned As System.Windows.Forms.Label
    Friend WithEvents messageTextLabel As System.Windows.Forms.Label
    Friend WithEvents testResultsGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents descriptionLineLabel As System.Windows.Forms.Label

End Class
