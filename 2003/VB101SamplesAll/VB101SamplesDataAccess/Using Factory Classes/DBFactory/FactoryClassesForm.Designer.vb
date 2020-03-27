<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class factoryClassesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(factoryClassesForm))
        Me.testResultsGroupBox = New System.Windows.Forms.GroupBox
        Me.connectionStringLabel = New System.Windows.Forms.Label
        Me.label4 = New System.Windows.Forms.Label
        Me.providerNameLabel = New System.Windows.Forms.Label
        Me.providerNameTextLabel = New System.Windows.Forms.Label
        Me.elapsedTimeLabel = New System.Windows.Forms.Label
        Me.elapsedTimeTextLabel = New System.Windows.Forms.Label
        Me.getDataButton = New System.Windows.Forms.Button
        Me.chooseDBLabel = New System.Windows.Forms.Label
        Me.descriptionGroupBox = New System.Windows.Forms.GroupBox
        Me.descriptionLabel = New System.Windows.Forms.Label
        Me.providerComboBox = New System.Windows.Forms.ComboBox
        Me.displayDataGridView = New System.Windows.Forms.DataGridView
        Me.testResultsGroupBox.SuspendLayout()
        Me.descriptionGroupBox.SuspendLayout()
        CType(Me.displayDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'testResultsGroupBox
        '
        Me.testResultsGroupBox.Controls.Add(Me.connectionStringLabel)
        Me.testResultsGroupBox.Controls.Add(Me.label4)
        Me.testResultsGroupBox.Controls.Add(Me.providerNameLabel)
        Me.testResultsGroupBox.Controls.Add(Me.providerNameTextLabel)
        Me.testResultsGroupBox.Controls.Add(Me.elapsedTimeLabel)
        Me.testResultsGroupBox.Controls.Add(Me.elapsedTimeTextLabel)
        Me.testResultsGroupBox.Location = New System.Drawing.Point(6, 221)
        Me.testResultsGroupBox.Name = "testResultsGroupBox"
        Me.testResultsGroupBox.Size = New System.Drawing.Size(677, 153)
        Me.testResultsGroupBox.TabIndex = 11
        Me.testResultsGroupBox.TabStop = False
        Me.testResultsGroupBox.Text = "Test Results"
        '
        'connectionStringLabel
        '
        Me.connectionStringLabel.AutoEllipsis = False
        Me.connectionStringLabel.AutoSize = False
        Me.connectionStringLabel.Location = New System.Drawing.Point(10, 120)
        Me.connectionStringLabel.Name = "connectionStringLabel"
        Me.connectionStringLabel.Size = New System.Drawing.Size(600, 13)
        Me.connectionStringLabel.TabIndex = 5
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label4.Location = New System.Drawing.Point(17, 103)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(112, 13)
        Me.label4.TabIndex = 4
        Me.label4.Text = "Connection String:"
        '
        'providerNameLabel
        '
        Me.providerNameLabel.AutoSize = True
        Me.providerNameLabel.Location = New System.Drawing.Point(0, 51)
        Me.providerNameLabel.Name = "providerNameLabel"
        Me.providerNameLabel.Size = New System.Drawing.Size(0, 13)
        Me.providerNameLabel.TabIndex = 3
        '
        'providerNameTextLabel
        '
        Me.providerNameTextLabel.AutoSize = True
        Me.providerNameTextLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.providerNameTextLabel.Location = New System.Drawing.Point(18, 35)
        Me.providerNameTextLabel.Name = "providerNameTextLabel"
        Me.providerNameTextLabel.Size = New System.Drawing.Size(58, 13)
        Me.providerNameTextLabel.TabIndex = 2
        Me.providerNameTextLabel.Text = "Provider:"
        '
        'elapsedTimeLabel
        '
        Me.elapsedTimeLabel.AutoSize = True
        Me.elapsedTimeLabel.Location = New System.Drawing.Point(192, 51)
        Me.elapsedTimeLabel.Name = "elapsedTimeLabel"
        Me.elapsedTimeLabel.Size = New System.Drawing.Size(0, 13)
        Me.elapsedTimeLabel.TabIndex = 1
        '
        'elapsedTimeTextLabel
        '
        Me.elapsedTimeTextLabel.AutoSize = True
        Me.elapsedTimeTextLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.elapsedTimeTextLabel.Location = New System.Drawing.Point(18, 65)
        Me.elapsedTimeTextLabel.Name = "elapsedTimeTextLabel"
        Me.elapsedTimeTextLabel.Size = New System.Drawing.Size(87, 13)
        Me.elapsedTimeTextLabel.TabIndex = 0
        Me.elapsedTimeTextLabel.Text = "Elapsed Time:"
        '
        'getDataButton
        '
        Me.getDataButton.Location = New System.Drawing.Point(27, 183)
        Me.getDataButton.Name = "getDataButton"
        Me.getDataButton.Size = New System.Drawing.Size(75, 23)
        Me.getDataButton.TabIndex = 10
        Me.getDataButton.Text = "Get Data"
        '
        'chooseDBLabel
        '
        Me.chooseDBLabel.AutoSize = True
        Me.chooseDBLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chooseDBLabel.Location = New System.Drawing.Point(5, 126)
        Me.chooseDBLabel.Name = "chooseDBLabel"
        Me.chooseDBLabel.Size = New System.Drawing.Size(107, 17)
        Me.chooseDBLabel.TabIndex = 6
        Me.chooseDBLabel.Text = "Choose a DB:"
        '
        'descriptionGroupBox
        '
        Me.descriptionGroupBox.Controls.Add(Me.descriptionLabel)
        Me.descriptionGroupBox.Location = New System.Drawing.Point(6, 12)
        Me.descriptionGroupBox.Name = "descriptionGroupBox"
        Me.descriptionGroupBox.Size = New System.Drawing.Size(666, 100)
        Me.descriptionGroupBox.TabIndex = 7
        Me.descriptionGroupBox.TabStop = False
        Me.descriptionGroupBox.Text = "Description"
        '
        'descriptionLabel
        '
        Me.descriptionLabel.AutoSize = True
        Me.descriptionLabel.Location = New System.Drawing.Point(0, 16)
        Me.descriptionLabel.Name = "descriptionLabel"
        Me.descriptionLabel.Size = New System.Drawing.Size(565, 78)
        Me.descriptionLabel.TabIndex = 0
        Me.descriptionLabel.Text = resources.GetString("descriptionLabel.Text")
        '
        'providerComboBox
        '
        Me.providerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.providerComboBox.FormattingEnabled = True
        Me.providerComboBox.Items.AddRange(New Object() {"SQL Server", "MS Access"})
        Me.providerComboBox.Location = New System.Drawing.Point(6, 149)
        Me.providerComboBox.Name = "providerComboBox"
        Me.providerComboBox.Size = New System.Drawing.Size(121, 21)
        Me.providerComboBox.TabIndex = 9
        '
        'displayDataGridView
        '
        Me.displayDataGridView.Location = New System.Drawing.Point(141, 118)
        Me.displayDataGridView.Name = "displayDataGridView"
        Me.displayDataGridView.ReadOnly = True
        Me.displayDataGridView.Size = New System.Drawing.Size(509, 99)
        Me.displayDataGridView.TabIndex = 8
        Me.displayDataGridView.Text = "dataGridView1"
        '
        'factoryClassesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(689, 389)
        Me.Controls.Add(Me.testResultsGroupBox)
        Me.Controls.Add(Me.getDataButton)
        Me.Controls.Add(Me.chooseDBLabel)
        Me.Controls.Add(Me.descriptionGroupBox)
        Me.Controls.Add(Me.providerComboBox)
        Me.Controls.Add(Me.displayDataGridView)
        Me.Name = "factoryClassesForm"
        Me.Text = "DBFactory Class Example"
        Me.testResultsGroupBox.ResumeLayout(False)
        Me.testResultsGroupBox.PerformLayout()
        Me.descriptionGroupBox.ResumeLayout(False)
        Me.descriptionGroupBox.PerformLayout()
        CType(Me.displayDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents testResultsGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents connectionStringLabel As System.Windows.Forms.Label
    Friend WithEvents label4 As System.Windows.Forms.Label
    Friend WithEvents providerNameLabel As System.Windows.Forms.Label
    Friend WithEvents providerNameTextLabel As System.Windows.Forms.Label
    Friend WithEvents elapsedTimeLabel As System.Windows.Forms.Label
    Friend WithEvents elapsedTimeTextLabel As System.Windows.Forms.Label
    Friend WithEvents getDataButton As System.Windows.Forms.Button
    Friend WithEvents chooseDBLabel As System.Windows.Forms.Label
    Friend WithEvents descriptionGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents descriptionLabel As System.Windows.Forms.Label
    Friend WithEvents providerComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents displayDataGridView As System.Windows.Forms.DataGridView

End Class
