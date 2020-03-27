<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Form1
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.comboBox1 = New System.Windows.Forms.ComboBox
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip
        Me.newToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.openToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.saveToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.userIntNumPicker = New System.Windows.Forms.NumericUpDown
        Me.label1 = New System.Windows.Forms.Label
        Me.setUserIntDefaultButton = New System.Windows.Forms.Button
        Me.toolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.comboBox1Label = New System.Windows.Forms.Label
        Me.appStringTextBox = New System.Windows.Forms.TextBox
        Me.userIdentityTextBox = New System.Windows.Forms.TextBox
        Me.toolStripContainer1 = New System.Windows.Forms.ToolStripContainer
        Me.appSettingsGroupBox = New System.Windows.Forms.GroupBox
        Me.appIntNumPicker = New System.Windows.Forms.NumericUpDown
        Me.userSettingsGroupBox = New System.Windows.Forms.GroupBox
        Me.userStringTextBox = New System.Windows.Forms.TextBox
        Me.setUserStringDefaultButton = New System.Windows.Forms.Button
        Me.setCheckBox1DefaultButton = New System.Windows.Forms.Button
        Me.checkBox1 = New System.Windows.Forms.CheckBox
        Me.toolStrip1.SuspendLayout()
        CType(Me.userIntNumPicker, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.toolStripContainer1.ContentPanel.SuspendLayout()
        Me.toolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.toolStripContainer1.SuspendLayout()
        Me.appSettingsGroupBox.SuspendLayout()
        CType(Me.appIntNumPicker, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.userSettingsGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'comboBox1
        '
        Me.comboBox1.FormattingEnabled = True
        Me.comboBox1.Items.AddRange(New Object() {"Lorem", "ipsum", "dolor", "sit", "amet", "consectetuer", "adipiscing", "elit"})
        Me.comboBox1.Location = New System.Drawing.Point(28, 104)
        Me.comboBox1.Name = "comboBox1"
        Me.comboBox1.Size = New System.Drawing.Size(121, 21)
        Me.comboBox1.TabIndex = 26
        '
        'toolStrip1
        '
        Me.toolStrip1.AllowItemReorder = True
        Me.toolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.newToolStripButton, Me.openToolStripButton, Me.saveToolStripButton})
        Me.toolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(542, 25)
        Me.toolStrip1.Stretch = True
        Me.toolStrip1.TabIndex = 1
        Me.toolStrip1.Text = "toolStrip1"
        Me.toolTip1.SetToolTip(Me.toolStrip1, "Move and resize the ToolStrip, then restart the sample the changes persisted.")
        '
        'newToolStripButton
        '
        Me.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.newToolStripButton.Image = CType(resources.GetObject("newToolStripButton.Image"), System.Drawing.Image)
        Me.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.newToolStripButton.Name = "newToolStripButton"
        Me.newToolStripButton.Text = "&New"
        '
        'openToolStripButton
        '
        Me.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.openToolStripButton.Image = CType(resources.GetObject("openToolStripButton.Image"), System.Drawing.Image)
        Me.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.openToolStripButton.Name = "openToolStripButton"
        Me.openToolStripButton.Text = "&Open"
        '
        'saveToolStripButton
        '
        Me.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.saveToolStripButton.Image = CType(resources.GetObject("saveToolStripButton.Image"), System.Drawing.Image)
        Me.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.saveToolStripButton.Name = "saveToolStripButton"
        Me.saveToolStripButton.Text = "&Save"
        '
        'userIntNumPicker
        '
        Me.userIntNumPicker.Location = New System.Drawing.Point(28, 75)
        Me.userIntNumPicker.Maximum = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.userIntNumPicker.Minimum = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
        Me.userIntNumPicker.Name = "userIntNumPicker"
        Me.userIntNumPicker.Size = New System.Drawing.Size(42, 20)
        Me.userIntNumPicker.TabIndex = 25
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(148, 45)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(63, 13)
        Me.label1.TabIndex = 22
        Me.label1.Text = "Current user:"
        '
        'setUserIntDefaultButton
        '
        Me.setUserIntDefaultButton.Location = New System.Drawing.Point(155, 75)
        Me.setUserIntDefaultButton.Name = "setUserIntDefaultButton"
        Me.setUserIntDefaultButton.Size = New System.Drawing.Size(81, 23)
        Me.setUserIntDefaultButton.TabIndex = 24
        Me.setUserIntDefaultButton.Text = "Set as Default"
        '
        'comboBox1Label
        '
        Me.comboBox1Label.Location = New System.Drawing.Point(154, 101)
        Me.comboBox1Label.Name = "comboBox1Label"
        Me.comboBox1Label.Size = New System.Drawing.Size(80, 39)
        Me.comboBox1Label.TabIndex = 30
        Me.comboBox1Label.Text = "Changes do not persist. "
        '
        'appStringTextBox
        '
        Me.appStringTextBox.Location = New System.Drawing.Point(28, 19)
        Me.appStringTextBox.Name = "appStringTextBox"
        Me.appStringTextBox.Size = New System.Drawing.Size(209, 20)
        Me.appStringTextBox.TabIndex = 29
        '
        'userIdentityTextBox
        '
        Me.userIdentityTextBox.BackColor = System.Drawing.SystemColors.ControlLight
        Me.userIdentityTextBox.Location = New System.Drawing.Point(217, 42)
        Me.userIdentityTextBox.Name = "userIdentityTextBox"
        Me.userIdentityTextBox.ReadOnly = True
        Me.userIdentityTextBox.Size = New System.Drawing.Size(160, 20)
        Me.userIdentityTextBox.TabIndex = 24
        '
        'toolStripContainer1
        '
        '
        'toolStripContainer1.ContentPanel
        '
        Me.toolStripContainer1.ContentPanel.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.toolStripContainer1.ContentPanel.Controls.Add(Me.appSettingsGroupBox)
        Me.toolStripContainer1.ContentPanel.Controls.Add(Me.userIdentityTextBox)
        Me.toolStripContainer1.ContentPanel.Controls.Add(Me.userSettingsGroupBox)
        Me.toolStripContainer1.ContentPanel.Controls.Add(Me.label1)
        Me.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.toolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.toolStripContainer1.Name = "toolStripContainer1"
        Me.toolStripContainer1.Size = New System.Drawing.Size(542, 416)
        Me.toolStripContainer1.TabIndex = 2
        Me.toolStripContainer1.Text = "toolStripContainer1"
        '
        'toolStripContainer1.TopToolStripPanel
        '
        Me.toolStripContainer1.TopToolStripPanel.Controls.Add(Me.toolStrip1)
        '
        'appSettingsGroupBox
        '
        Me.appSettingsGroupBox.Controls.Add(Me.appStringTextBox)
        Me.appSettingsGroupBox.Controls.Add(Me.appIntNumPicker)
        Me.appSettingsGroupBox.Location = New System.Drawing.Point(140, 87)
        Me.appSettingsGroupBox.Name = "appSettingsGroupBox"
        Me.appSettingsGroupBox.Size = New System.Drawing.Size(265, 77)
        Me.appSettingsGroupBox.TabIndex = 25
        Me.appSettingsGroupBox.TabStop = False
        Me.appSettingsGroupBox.Text = "Application-Scoped (changes do not persist)"
        '
        'appIntNumPicker
        '
        Me.appIntNumPicker.Location = New System.Drawing.Point(29, 45)
        Me.appIntNumPicker.Maximum = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.appIntNumPicker.Minimum = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
        Me.appIntNumPicker.Name = "appIntNumPicker"
        Me.appIntNumPicker.Size = New System.Drawing.Size(38, 20)
        Me.appIntNumPicker.TabIndex = 30
        Me.appIntNumPicker.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'userSettingsGroupBox
        '
        Me.userSettingsGroupBox.Controls.Add(Me.comboBox1Label)
        Me.userSettingsGroupBox.Controls.Add(Me.comboBox1)
        Me.userSettingsGroupBox.Controls.Add(Me.userIntNumPicker)
        Me.userSettingsGroupBox.Controls.Add(Me.setUserIntDefaultButton)
        Me.userSettingsGroupBox.Controls.Add(Me.userStringTextBox)
        Me.userSettingsGroupBox.Controls.Add(Me.setUserStringDefaultButton)
        Me.userSettingsGroupBox.Controls.Add(Me.setCheckBox1DefaultButton)
        Me.userSettingsGroupBox.Controls.Add(Me.checkBox1)
        Me.userSettingsGroupBox.Location = New System.Drawing.Point(142, 189)
        Me.userSettingsGroupBox.Name = "userSettingsGroupBox"
        Me.userSettingsGroupBox.Size = New System.Drawing.Size(265, 152)
        Me.userSettingsGroupBox.TabIndex = 23
        Me.userSettingsGroupBox.TabStop = False
        Me.userSettingsGroupBox.Text = "User-Scoped"
        '
        'userStringTextBox
        '
        Me.userStringTextBox.Location = New System.Drawing.Point(28, 46)
        Me.userStringTextBox.Name = "userStringTextBox"
        Me.userStringTextBox.Size = New System.Drawing.Size(121, 20)
        Me.userStringTextBox.TabIndex = 22
        '
        'setUserStringDefaultButton
        '
        Me.setUserStringDefaultButton.Location = New System.Drawing.Point(155, 46)
        Me.setUserStringDefaultButton.Name = "setUserStringDefaultButton"
        Me.setUserStringDefaultButton.Size = New System.Drawing.Size(81, 23)
        Me.setUserStringDefaultButton.TabIndex = 21
        Me.setUserStringDefaultButton.Text = "Set as Default"
        '
        'setCheckBox1DefaultButton
        '
        Me.setCheckBox1DefaultButton.Location = New System.Drawing.Point(155, 19)
        Me.setCheckBox1DefaultButton.Name = "setCheckBox1DefaultButton"
        Me.setCheckBox1DefaultButton.Size = New System.Drawing.Size(81, 23)
        Me.setCheckBox1DefaultButton.TabIndex = 20
        Me.setCheckBox1DefaultButton.Text = "Set as Default"
        '
        'checkBox1
        '
        Me.checkBox1.AutoSize = True
        Me.checkBox1.Location = New System.Drawing.Point(28, 23)
        Me.checkBox1.Name = "checkBox1"
        Me.checkBox1.Size = New System.Drawing.Size(76, 17)
        Me.checkBox1.TabIndex = 16
        Me.checkBox1.Text = "checkBox1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(542, 416)
        Me.Controls.Add(Me.toolStripContainer1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Client Configuration"
        Me.toolStrip1.ResumeLayout(False)
        CType(Me.userIntNumPicker, System.ComponentModel.ISupportInitialize).EndInit()
        Me.toolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.toolStripContainer1.ContentPanel.PerformLayout()
        Me.toolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.toolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.toolStripContainer1.ResumeLayout(False)
        Me.toolStripContainer1.PerformLayout()
        Me.appSettingsGroupBox.ResumeLayout(False)
        Me.appSettingsGroupBox.PerformLayout()
        CType(Me.appIntNumPicker, System.ComponentModel.ISupportInitialize).EndInit()
        Me.userSettingsGroupBox.ResumeLayout(False)
        Me.userSettingsGroupBox.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents comboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents newToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents openToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents saveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents userIntNumPicker As System.Windows.Forms.NumericUpDown
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents setUserIntDefaultButton As System.Windows.Forms.Button
    Friend WithEvents comboBox1Label As System.Windows.Forms.Label
    Friend WithEvents appStringTextBox As System.Windows.Forms.TextBox
    Friend WithEvents userIdentityTextBox As System.Windows.Forms.TextBox
    Friend WithEvents toolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents appSettingsGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents appIntNumPicker As System.Windows.Forms.NumericUpDown
    Friend WithEvents userSettingsGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents userStringTextBox As System.Windows.Forms.TextBox
    Friend WithEvents setUserStringDefaultButton As System.Windows.Forms.Button
    Friend WithEvents setCheckBox1DefaultButton As System.Windows.Forms.Button
    Friend WithEvents checkBox1 As System.Windows.Forms.CheckBox

End Class
