Partial Public Class WebSettingsClient
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WebSettingsClient))
        Me.textSetting = New System.Windows.Forms.TextBox
        Me.buttonSaveSettings = New System.Windows.Forms.Button
        Me.checkSetting1 = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.comboSetting = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.checkSetting2 = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'textSetting
        '
        Me.textSetting.Location = New System.Drawing.Point(104, 18)
        Me.textSetting.Name = "textSetting"
        Me.textSetting.Size = New System.Drawing.Size(149, 20)
        Me.textSetting.TabIndex = 0
        '
        'buttonSaveSettings
        '
        Me.buttonSaveSettings.Location = New System.Drawing.Point(163, 201)
        Me.buttonSaveSettings.Name = "buttonSaveSettings"
        Me.buttonSaveSettings.Size = New System.Drawing.Size(154, 26)
        Me.buttonSaveSettings.TabIndex = 2
        Me.buttonSaveSettings.Text = "&Save Settings"
        '
        'checkSetting1
        '
        Me.checkSetting1.AutoSize = True
        Me.checkSetting1.Location = New System.Drawing.Point(10, 20)
        Me.checkSetting1.Name = "checkSetting1"
        Me.checkSetting1.Size = New System.Drawing.Size(127, 17)
        Me.checkSetting1.TabIndex = 0
        Me.checkSetting1.Text = "Random CheckBox &1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Random Text:"
        '
        'comboSetting
        '
        Me.comboSetting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboSetting.FormattingEnabled = True
        Me.comboSetting.Items.AddRange(New Object() {"First Choice", "Second Choice", "Third Choice"})
        Me.comboSetting.Location = New System.Drawing.Point(104, 42)
        Me.comboSetting.Name = "comboSetting"
        Me.comboSetting.Size = New System.Drawing.Size(149, 21)
        Me.comboSetting.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.checkSetting2)
        Me.GroupBox1.Controls.Add(Me.checkSetting1)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 116)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(178, 69)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Random Checkboxes"
        '
        'checkSetting2
        '
        Me.checkSetting2.AutoSize = True
        Me.checkSetting2.Location = New System.Drawing.Point(10, 44)
        Me.checkSetting2.Name = "checkSetting2"
        Me.checkSetting2.Size = New System.Drawing.Size(127, 17)
        Me.checkSetting2.TabIndex = 1
        Me.checkSetting2.Text = "Random CheckBox &2"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Random Choice:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(445, 91)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = resources.GetString("Label3.Text")
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.comboSetting)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.textSetting)
        Me.GroupBox2.Location = New System.Drawing.Point(209, 116)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(259, 69)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Random Text"
        '
        'WebSettingsClient
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(480, 240)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.buttonSaveSettings)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "WebSettingsClient"
        Me.Text = "WebSettingsClient Sample"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents textSetting As System.Windows.Forms.TextBox
    Friend WithEvents buttonSaveSettings As System.Windows.Forms.Button
    Friend WithEvents checkSetting1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents comboSetting As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents checkSetting2 As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox

End Class
