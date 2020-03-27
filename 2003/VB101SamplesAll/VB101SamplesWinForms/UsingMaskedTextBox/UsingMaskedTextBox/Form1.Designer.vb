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
        Me.CurrencyMaskLabel = New System.Windows.Forms.Label
        Me.TesterMaskedTextBox = New System.Windows.Forms.MaskedTextBox
        Me.CurrencyLabel = New System.Windows.Forms.Label
        Me.CurrencyMaskedTextBox = New System.Windows.Forms.MaskedTextBox
        Me.label8 = New System.Windows.Forms.Label
        Me.LatitudeMaskLabel = New System.Windows.Forms.Label
        Me.tabPage2 = New System.Windows.Forms.TabPage
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.label7 = New System.Windows.Forms.Label
        Me.MaskTextBox = New System.Windows.Forms.TextBox
        Me.Custom3MaskLabel = New System.Windows.Forms.Label
        Me.Custom2MaskLabel = New System.Windows.Forms.Label
        Me.Custom1MaskLabel = New System.Windows.Forms.Label
        Me.SSNMaskLabel = New System.Windows.Forms.Label
        Me.ShortDateMaskLabel = New System.Windows.Forms.Label
        Me.PhoneNoMaskLabel = New System.Windows.Forms.Label
        Me.LatitudeLabel = New System.Windows.Forms.Label
        Me.LatitudeMaskedTextBox = New System.Windows.Forms.MaskedTextBox
        Me.Custom3Label = New System.Windows.Forms.Label
        Me.Custom3MaskedTextBox = New System.Windows.Forms.MaskedTextBox
        Me.Custom2Label = New System.Windows.Forms.Label
        Me.Custom2MaskedTextBox = New System.Windows.Forms.MaskedTextBox
        Me.Custom1Label = New System.Windows.Forms.Label
        Me.Custom1MaskedTextBox = New System.Windows.Forms.MaskedTextBox
        Me.SSNLabel = New System.Windows.Forms.Label
        Me.SSNMaskedTextBox = New System.Windows.Forms.MaskedTextBox
        Me.ShortDateMaskedTextBox = New System.Windows.Forms.MaskedTextBox
        Me.ShortDateLabel = New System.Windows.Forms.Label
        Me.PhoneNoLabel = New System.Windows.Forms.Label
        Me.tabControl1 = New System.Windows.Forms.TabControl
        Me.tabPage1 = New System.Windows.Forms.TabPage
        Me.PhoneNoMaskedTextBox = New System.Windows.Forms.MaskedTextBox
        Me.tabPage2.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.tabControl1.SuspendLayout()
        Me.tabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CurrencyMaskLabel
        '
        Me.CurrencyMaskLabel.AutoSize = True
        Me.CurrencyMaskLabel.Location = New System.Drawing.Point(236, 182)
        Me.CurrencyMaskLabel.Name = "CurrencyMaskLabel"
        Me.CurrencyMaskLabel.Size = New System.Drawing.Size(0, 0)
        Me.CurrencyMaskLabel.TabIndex = 36
        '
        'TesterMaskedTextBox
        '
        Me.TesterMaskedTextBox.Location = New System.Drawing.Point(112, 46)
        Me.TesterMaskedTextBox.Name = "TesterMaskedTextBox"
        Me.TesterMaskedTextBox.Size = New System.Drawing.Size(161, 20)
        Me.TesterMaskedTextBox.TabIndex = 4
        '
        'CurrencyLabel
        '
        Me.CurrencyLabel.AutoSize = True
        Me.CurrencyLabel.Location = New System.Drawing.Point(14, 182)
        Me.CurrencyLabel.Name = "CurrencyLabel"
        Me.CurrencyLabel.Size = New System.Drawing.Size(45, 13)
        Me.CurrencyLabel.TabIndex = 35
        Me.CurrencyLabel.Text = "Currency"
        '
        'CurrencyMaskedTextBox
        '
        Me.CurrencyMaskedTextBox.Location = New System.Drawing.Point(125, 179)
        Me.CurrencyMaskedTextBox.Name = "CurrencyMaskedTextBox"
        Me.CurrencyMaskedTextBox.Size = New System.Drawing.Size(105, 20)
        Me.CurrencyMaskedTextBox.TabIndex = 6
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(7, 49)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(79, 13)
        Me.label8.TabIndex = 3
        Me.label8.Text = "Test mask here:"
        '
        'LatitudeMaskLabel
        '
        Me.LatitudeMaskLabel.AutoSize = True
        Me.LatitudeMaskLabel.Location = New System.Drawing.Point(236, 208)
        Me.LatitudeMaskLabel.Name = "LatitudeMaskLabel"
        Me.LatitudeMaskLabel.Size = New System.Drawing.Size(0, 0)
        Me.LatitudeMaskLabel.TabIndex = 33
        '
        'tabPage2
        '
        Me.tabPage2.Controls.Add(Me.groupBox1)
        Me.tabPage2.Location = New System.Drawing.Point(4, 22)
        Me.tabPage2.Name = "tabPage2"
        Me.tabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage2.Size = New System.Drawing.Size(534, 390)
        Me.tabPage2.TabIndex = 1
        Me.tabPage2.Text = "Mask Testing"
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.TesterMaskedTextBox)
        Me.groupBox1.Controls.Add(Me.label8)
        Me.groupBox1.Controls.Add(Me.label7)
        Me.groupBox1.Controls.Add(Me.MaskTextBox)
        Me.groupBox1.Location = New System.Drawing.Point(6, 6)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(283, 75)
        Me.groupBox1.TabIndex = 26
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Test your mask here"
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(7, 23)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(91, 13)
        Me.label7.TabIndex = 1
        Me.label7.Text = "Enter mask to test:"
        '
        'MaskTextBox
        '
        Me.MaskTextBox.Location = New System.Drawing.Point(112, 20)
        Me.MaskTextBox.Name = "MaskTextBox"
        Me.MaskTextBox.Size = New System.Drawing.Size(161, 20)
        Me.MaskTextBox.TabIndex = 0
        '
        'Custom3MaskLabel
        '
        Me.Custom3MaskLabel.AutoSize = True
        Me.Custom3MaskLabel.Location = New System.Drawing.Point(236, 156)
        Me.Custom3MaskLabel.Name = "Custom3MaskLabel"
        Me.Custom3MaskLabel.Size = New System.Drawing.Size(0, 0)
        Me.Custom3MaskLabel.TabIndex = 32
        '
        'Custom2MaskLabel
        '
        Me.Custom2MaskLabel.AutoSize = True
        Me.Custom2MaskLabel.Location = New System.Drawing.Point(236, 129)
        Me.Custom2MaskLabel.Name = "Custom2MaskLabel"
        Me.Custom2MaskLabel.Size = New System.Drawing.Size(0, 0)
        Me.Custom2MaskLabel.TabIndex = 31
        '
        'Custom1MaskLabel
        '
        Me.Custom1MaskLabel.AutoSize = True
        Me.Custom1MaskLabel.Location = New System.Drawing.Point(236, 102)
        Me.Custom1MaskLabel.Name = "Custom1MaskLabel"
        Me.Custom1MaskLabel.Size = New System.Drawing.Size(0, 0)
        Me.Custom1MaskLabel.TabIndex = 30
        '
        'SSNMaskLabel
        '
        Me.SSNMaskLabel.AutoSize = True
        Me.SSNMaskLabel.Location = New System.Drawing.Point(236, 75)
        Me.SSNMaskLabel.Name = "SSNMaskLabel"
        Me.SSNMaskLabel.Size = New System.Drawing.Size(0, 0)
        Me.SSNMaskLabel.TabIndex = 29
        '
        'ShortDateMaskLabel
        '
        Me.ShortDateMaskLabel.AutoSize = True
        Me.ShortDateMaskLabel.Location = New System.Drawing.Point(236, 48)
        Me.ShortDateMaskLabel.Name = "ShortDateMaskLabel"
        Me.ShortDateMaskLabel.Size = New System.Drawing.Size(0, 0)
        Me.ShortDateMaskLabel.TabIndex = 28
        '
        'PhoneNoMaskLabel
        '
        Me.PhoneNoMaskLabel.AutoSize = True
        Me.PhoneNoMaskLabel.Location = New System.Drawing.Point(236, 21)
        Me.PhoneNoMaskLabel.Name = "PhoneNoMaskLabel"
        Me.PhoneNoMaskLabel.Size = New System.Drawing.Size(0, 0)
        Me.PhoneNoMaskLabel.TabIndex = 27
        '
        'LatitudeLabel
        '
        Me.LatitudeLabel.AutoSize = True
        Me.LatitudeLabel.Location = New System.Drawing.Point(14, 208)
        Me.LatitudeLabel.Name = "LatitudeLabel"
        Me.LatitudeLabel.Size = New System.Drawing.Size(41, 13)
        Me.LatitudeLabel.TabIndex = 26
        Me.LatitudeLabel.Text = "Latitude"
        '
        'LatitudeMaskedTextBox
        '
        Me.LatitudeMaskedTextBox.Location = New System.Drawing.Point(125, 205)
        Me.LatitudeMaskedTextBox.Name = "LatitudeMaskedTextBox"
        Me.LatitudeMaskedTextBox.Size = New System.Drawing.Size(105, 20)
        Me.LatitudeMaskedTextBox.TabIndex = 7
        '
        'Custom3Label
        '
        Me.Custom3Label.AutoSize = True
        Me.Custom3Label.Location = New System.Drawing.Point(14, 156)
        Me.Custom3Label.Name = "Custom3Label"
        Me.Custom3Label.Size = New System.Drawing.Size(47, 13)
        Me.Custom3Label.TabIndex = 24
        Me.Custom3Label.Text = "Custom 3"
        '
        'Custom3MaskedTextBox
        '
        Me.Custom3MaskedTextBox.Location = New System.Drawing.Point(125, 153)
        Me.Custom3MaskedTextBox.Name = "Custom3MaskedTextBox"
        Me.Custom3MaskedTextBox.Size = New System.Drawing.Size(105, 20)
        Me.Custom3MaskedTextBox.TabIndex = 5
        '
        'Custom2Label
        '
        Me.Custom2Label.AutoSize = True
        Me.Custom2Label.Location = New System.Drawing.Point(14, 129)
        Me.Custom2Label.Name = "Custom2Label"
        Me.Custom2Label.Size = New System.Drawing.Size(47, 13)
        Me.Custom2Label.TabIndex = 22
        Me.Custom2Label.Text = "Custom 2"
        '
        'Custom2MaskedTextBox
        '
        Me.Custom2MaskedTextBox.Location = New System.Drawing.Point(125, 126)
        Me.Custom2MaskedTextBox.Name = "Custom2MaskedTextBox"
        Me.Custom2MaskedTextBox.Size = New System.Drawing.Size(105, 20)
        Me.Custom2MaskedTextBox.TabIndex = 4
        '
        'Custom1Label
        '
        Me.Custom1Label.AutoSize = True
        Me.Custom1Label.Location = New System.Drawing.Point(14, 102)
        Me.Custom1Label.Name = "Custom1Label"
        Me.Custom1Label.Size = New System.Drawing.Size(47, 13)
        Me.Custom1Label.TabIndex = 20
        Me.Custom1Label.Text = "Custom 1"
        '
        'Custom1MaskedTextBox
        '
        Me.Custom1MaskedTextBox.Location = New System.Drawing.Point(125, 99)
        Me.Custom1MaskedTextBox.Name = "Custom1MaskedTextBox"
        Me.Custom1MaskedTextBox.Size = New System.Drawing.Size(105, 20)
        Me.Custom1MaskedTextBox.TabIndex = 3
        '
        'SSNLabel
        '
        Me.SSNLabel.AutoSize = True
        Me.SSNLabel.Location = New System.Drawing.Point(14, 75)
        Me.SSNLabel.Name = "SSNLabel"
        Me.SSNLabel.Size = New System.Drawing.Size(25, 13)
        Me.SSNLabel.TabIndex = 18
        Me.SSNLabel.Text = "SSN"
        '
        'SSNMaskedTextBox
        '
        Me.SSNMaskedTextBox.Location = New System.Drawing.Point(125, 72)
        Me.SSNMaskedTextBox.Name = "SSNMaskedTextBox"
        Me.SSNMaskedTextBox.Size = New System.Drawing.Size(105, 20)
        Me.SSNMaskedTextBox.TabIndex = 2
        '
        'ShortDateMaskedTextBox
        '
        Me.ShortDateMaskedTextBox.Location = New System.Drawing.Point(125, 45)
        Me.ShortDateMaskedTextBox.Name = "ShortDateMaskedTextBox"
        Me.ShortDateMaskedTextBox.Size = New System.Drawing.Size(105, 20)
        Me.ShortDateMaskedTextBox.TabIndex = 1
        '
        'ShortDateLabel
        '
        Me.ShortDateLabel.AutoSize = True
        Me.ShortDateLabel.Location = New System.Drawing.Point(14, 48)
        Me.ShortDateLabel.Name = "ShortDateLabel"
        Me.ShortDateLabel.Size = New System.Drawing.Size(54, 13)
        Me.ShortDateLabel.TabIndex = 15
        Me.ShortDateLabel.Text = "Short Date"
        '
        'PhoneNoLabel
        '
        Me.PhoneNoLabel.AutoSize = True
        Me.PhoneNoLabel.Location = New System.Drawing.Point(14, 21)
        Me.PhoneNoLabel.Name = "PhoneNoLabel"
        Me.PhoneNoLabel.Size = New System.Drawing.Size(74, 13)
        Me.PhoneNoLabel.TabIndex = 14
        Me.PhoneNoLabel.Text = "Phone Number"
        '
        'tabControl1
        '
        Me.tabControl1.Controls.Add(Me.tabPage1)
        Me.tabControl1.Controls.Add(Me.tabPage2)
        Me.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabControl1.Location = New System.Drawing.Point(0, 0)
        Me.tabControl1.Name = "tabControl1"
        Me.tabControl1.SelectedIndex = 0
        Me.tabControl1.Size = New System.Drawing.Size(542, 416)
        Me.tabControl1.TabIndex = 1
        '
        'tabPage1
        '
        Me.tabPage1.Controls.Add(Me.CurrencyMaskLabel)
        Me.tabPage1.Controls.Add(Me.CurrencyLabel)
        Me.tabPage1.Controls.Add(Me.CurrencyMaskedTextBox)
        Me.tabPage1.Controls.Add(Me.LatitudeMaskLabel)
        Me.tabPage1.Controls.Add(Me.Custom3MaskLabel)
        Me.tabPage1.Controls.Add(Me.Custom2MaskLabel)
        Me.tabPage1.Controls.Add(Me.Custom1MaskLabel)
        Me.tabPage1.Controls.Add(Me.SSNMaskLabel)
        Me.tabPage1.Controls.Add(Me.ShortDateMaskLabel)
        Me.tabPage1.Controls.Add(Me.PhoneNoMaskLabel)
        Me.tabPage1.Controls.Add(Me.LatitudeLabel)
        Me.tabPage1.Controls.Add(Me.LatitudeMaskedTextBox)
        Me.tabPage1.Controls.Add(Me.Custom3Label)
        Me.tabPage1.Controls.Add(Me.Custom3MaskedTextBox)
        Me.tabPage1.Controls.Add(Me.Custom2Label)
        Me.tabPage1.Controls.Add(Me.Custom2MaskedTextBox)
        Me.tabPage1.Controls.Add(Me.Custom1Label)
        Me.tabPage1.Controls.Add(Me.Custom1MaskedTextBox)
        Me.tabPage1.Controls.Add(Me.SSNLabel)
        Me.tabPage1.Controls.Add(Me.SSNMaskedTextBox)
        Me.tabPage1.Controls.Add(Me.ShortDateMaskedTextBox)
        Me.tabPage1.Controls.Add(Me.ShortDateLabel)
        Me.tabPage1.Controls.Add(Me.PhoneNoLabel)
        Me.tabPage1.Controls.Add(Me.PhoneNoMaskedTextBox)
        Me.tabPage1.Location = New System.Drawing.Point(4, 22)
        Me.tabPage1.Name = "tabPage1"
        Me.tabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage1.Size = New System.Drawing.Size(534, 390)
        Me.tabPage1.TabIndex = 0
        Me.tabPage1.Text = "Mask Examples"
        '
        'PhoneNoMaskedTextBox
        '
        Me.PhoneNoMaskedTextBox.Location = New System.Drawing.Point(125, 18)
        Me.PhoneNoMaskedTextBox.Name = "PhoneNoMaskedTextBox"
        Me.PhoneNoMaskedTextBox.Size = New System.Drawing.Size(105, 20)
        Me.PhoneNoMaskedTextBox.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(542, 416)
        Me.Controls.Add(Me.tabControl1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Using the MaskedTextBox"
        Me.tabPage2.ResumeLayout(False)
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.tabControl1.ResumeLayout(False)
        Me.tabPage1.ResumeLayout(False)
        Me.tabPage1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CurrencyMaskLabel As System.Windows.Forms.Label
    Friend WithEvents TesterMaskedTextBox As System.Windows.Forms.MaskedTextBox
    Friend WithEvents CurrencyLabel As System.Windows.Forms.Label
    Friend WithEvents CurrencyMaskedTextBox As System.Windows.Forms.MaskedTextBox
    Friend WithEvents label8 As System.Windows.Forms.Label
    Friend WithEvents LatitudeMaskLabel As System.Windows.Forms.Label
    Friend WithEvents tabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents label7 As System.Windows.Forms.Label
    Friend WithEvents MaskTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Custom3MaskLabel As System.Windows.Forms.Label
    Friend WithEvents Custom2MaskLabel As System.Windows.Forms.Label
    Friend WithEvents Custom1MaskLabel As System.Windows.Forms.Label
    Friend WithEvents SSNMaskLabel As System.Windows.Forms.Label
    Friend WithEvents ShortDateMaskLabel As System.Windows.Forms.Label
    Friend WithEvents PhoneNoMaskLabel As System.Windows.Forms.Label
    Friend WithEvents LatitudeLabel As System.Windows.Forms.Label
    Friend WithEvents LatitudeMaskedTextBox As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Custom3Label As System.Windows.Forms.Label
    Friend WithEvents Custom3MaskedTextBox As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Custom2Label As System.Windows.Forms.Label
    Friend WithEvents Custom2MaskedTextBox As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Custom1Label As System.Windows.Forms.Label
    Friend WithEvents Custom1MaskedTextBox As System.Windows.Forms.MaskedTextBox
    Friend WithEvents SSNLabel As System.Windows.Forms.Label
    Friend WithEvents SSNMaskedTextBox As System.Windows.Forms.MaskedTextBox
    Friend WithEvents ShortDateMaskedTextBox As System.Windows.Forms.MaskedTextBox
    Friend WithEvents ShortDateLabel As System.Windows.Forms.Label
    Friend WithEvents PhoneNoLabel As System.Windows.Forms.Label
    Friend WithEvents tabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents PhoneNoMaskedTextBox As System.Windows.Forms.MaskedTextBox

End Class
