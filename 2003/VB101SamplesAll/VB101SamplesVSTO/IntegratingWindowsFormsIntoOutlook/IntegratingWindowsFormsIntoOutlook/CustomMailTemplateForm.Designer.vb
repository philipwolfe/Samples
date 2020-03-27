<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomMailTemplateForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
        Me.cancelMailButton = New System.Windows.Forms.Button
        Me.sendMailButton = New System.Windows.Forms.Button
        Me.messageTextBox = New System.Windows.Forms.TextBox
        Me.label4 = New System.Windows.Forms.Label
        Me.dueDateTextBox = New System.Windows.Forms.MaskedTextBox
        Me.label2 = New System.Windows.Forms.Label
        Me.amountTextBox = New System.Windows.Forms.MaskedTextBox
        Me.label3 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.customerComboBox = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'cancelMailButton
        '
        Me.cancelMailButton.Location = New System.Drawing.Point(204, 250)
        Me.cancelMailButton.Name = "cancelMailButton"
        Me.cancelMailButton.Size = New System.Drawing.Size(75, 23)
        Me.cancelMailButton.TabIndex = 21
        Me.cancelMailButton.Text = "Ca&ncel"
        Me.cancelMailButton.UseVisualStyleBackColor = True
        '
        'sendMailButton
        '
        Me.sendMailButton.Location = New System.Drawing.Point(11, 250)
        Me.sendMailButton.Name = "sendMailButton"
        Me.sendMailButton.Size = New System.Drawing.Size(75, 23)
        Me.sendMailButton.TabIndex = 20
        Me.sendMailButton.Text = "&Send"
        Me.sendMailButton.UseVisualStyleBackColor = True
        '
        'messageTextBox
        '
        Me.messageTextBox.Location = New System.Drawing.Point(11, 107)
        Me.messageTextBox.Multiline = True
        Me.messageTextBox.Name = "messageTextBox"
        Me.messageTextBox.Size = New System.Drawing.Size(268, 137)
        Me.messageTextBox.TabIndex = 19
        Me.messageTextBox.Text = "Please give your prompt attention to this matter." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Thank you!"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(8, 91)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(50, 13)
        Me.label4.TabIndex = 18
        Me.label4.Text = "&Message"
        '
        'dueDateTextBox
        '
        Me.dueDateTextBox.Location = New System.Drawing.Point(105, 58)
        Me.dueDateTextBox.Mask = "00/00/0000"
        Me.dueDateTextBox.Name = "dueDateTextBox"
        Me.dueDateTextBox.Size = New System.Drawing.Size(100, 20)
        Me.dueDateTextBox.TabIndex = 17
        Me.dueDateTextBox.ValidatingType = GetType(Date)
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(48, 61)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(51, 13)
        Me.label2.TabIndex = 16
        Me.label2.Text = "&Due date"
        '
        'amountTextBox
        '
        Me.amountTextBox.Location = New System.Drawing.Point(105, 32)
        Me.amountTextBox.Mask = "00000"
        Me.amountTextBox.Name = "amountTextBox"
        Me.amountTextBox.Size = New System.Drawing.Size(100, 20)
        Me.amountTextBox.TabIndex = 15
        Me.amountTextBox.ValidatingType = GetType(Integer)
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(12, 35)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(87, 13)
        Me.label3.TabIndex = 14
        Me.label3.Text = "&Amount Overdue"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(48, 8)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(51, 13)
        Me.label1.TabIndex = 12
        Me.label1.Text = "&Customer"
        '
        'customerComboBox
        '
        Me.customerComboBox.FormattingEnabled = True
        Me.customerComboBox.Location = New System.Drawing.Point(105, 5)
        Me.customerComboBox.Name = "customerComboBox"
        Me.customerComboBox.Size = New System.Drawing.Size(159, 21)
        Me.customerComboBox.TabIndex = 13
        '
        'CustomMailTemplateForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 279)
        Me.ControlBox = False
        Me.Controls.Add(Me.cancelMailButton)
        Me.Controls.Add(Me.sendMailButton)
        Me.Controls.Add(Me.messageTextBox)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.dueDateTextBox)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.amountTextBox)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.customerComboBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "CustomMailTemplateForm"
        Me.Text = "Overdue Mail Template"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents cancelMailButton As System.Windows.Forms.Button
    Private WithEvents sendMailButton As System.Windows.Forms.Button
    Private WithEvents messageTextBox As System.Windows.Forms.TextBox
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents dueDateTextBox As System.Windows.Forms.MaskedTextBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents amountTextBox As System.Windows.Forms.MaskedTextBox
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents customerComboBox As System.Windows.Forms.ComboBox
End Class
