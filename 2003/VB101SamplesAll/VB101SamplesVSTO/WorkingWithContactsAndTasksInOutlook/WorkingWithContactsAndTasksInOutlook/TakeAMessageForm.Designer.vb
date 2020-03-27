<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TakeAMessageForm
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
        Me.contactsComboBox = New System.Windows.Forms.ComboBox
        Me.cancelMessageButton = New System.Windows.Forms.Button
        Me.saveButton = New System.Windows.Forms.Button
        Me.callbackDateTextBox = New System.Windows.Forms.MaskedTextBox
        Me.label3 = New System.Windows.Forms.Label
        Me.messageTextBox = New System.Windows.Forms.TextBox
        Me.label2 = New System.Windows.Forms.Label
        Me.newContactButton = New System.Windows.Forms.Button
        Me.label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'contactsComboBox
        '
        Me.contactsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.contactsComboBox.FormattingEnabled = True
        Me.contactsComboBox.Location = New System.Drawing.Point(50, 12)
        Me.contactsComboBox.Name = "contactsComboBox"
        Me.contactsComboBox.Size = New System.Drawing.Size(173, 21)
        Me.contactsComboBox.TabIndex = 19
        '
        'cancelMessageButton
        '
        Me.cancelMessageButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cancelMessageButton.Location = New System.Drawing.Point(213, 262)
        Me.cancelMessageButton.Name = "cancelMessageButton"
        Me.cancelMessageButton.Size = New System.Drawing.Size(75, 23)
        Me.cancelMessageButton.TabIndex = 18
        Me.cancelMessageButton.Text = "Ca&ncel"
        Me.cancelMessageButton.UseVisualStyleBackColor = True
        '
        'saveButton
        '
        Me.saveButton.Enabled = False
        Me.saveButton.Location = New System.Drawing.Point(6, 262)
        Me.saveButton.Name = "saveButton"
        Me.saveButton.Size = New System.Drawing.Size(75, 23)
        Me.saveButton.TabIndex = 17
        Me.saveButton.Text = "&Save"
        Me.saveButton.UseVisualStyleBackColor = True
        '
        'callbackDateTextBox
        '
        Me.callbackDateTextBox.Location = New System.Drawing.Point(83, 224)
        Me.callbackDateTextBox.Mask = "00/00/0000"
        Me.callbackDateTextBox.Name = "callbackDateTextBox"
        Me.callbackDateTextBox.Size = New System.Drawing.Size(100, 20)
        Me.callbackDateTextBox.TabIndex = 16
        Me.callbackDateTextBox.ValidatingType = GetType(Date)
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(3, 227)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(74, 13)
        Me.label3.TabIndex = 15
        Me.label3.Text = "Callback &Date"
        '
        'messageTextBox
        '
        Me.messageTextBox.Location = New System.Drawing.Point(6, 61)
        Me.messageTextBox.Multiline = True
        Me.messageTextBox.Name = "messageTextBox"
        Me.messageTextBox.Size = New System.Drawing.Size(274, 152)
        Me.messageTextBox.TabIndex = 14
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(3, 45)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(50, 13)
        Me.label2.TabIndex = 13
        Me.label2.Text = "&Message"
        '
        'newContactButton
        '
        Me.newContactButton.Location = New System.Drawing.Point(230, 9)
        Me.newContactButton.Name = "newContactButton"
        Me.newContactButton.Size = New System.Drawing.Size(58, 23)
        Me.newContactButton.TabIndex = 12
        Me.newContactButton.Text = "New..."
        Me.newContactButton.UseVisualStyleBackColor = True
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(0, 15)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(44, 13)
        Me.label1.TabIndex = 11
        Me.label1.Text = "&Contact"
        '
        'TakeAMessageForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 285)
        Me.ControlBox = False
        Me.Controls.Add(Me.contactsComboBox)
        Me.Controls.Add(Me.cancelMessageButton)
        Me.Controls.Add(Me.saveButton)
        Me.Controls.Add(Me.callbackDateTextBox)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.messageTextBox)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.newContactButton)
        Me.Controls.Add(Me.label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "TakeAMessageForm"
        Me.Text = "Take a message"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents contactsComboBox As System.Windows.Forms.ComboBox
    Private WithEvents cancelMessageButton As System.Windows.Forms.Button
    Private WithEvents saveButton As System.Windows.Forms.Button
    Private WithEvents callbackDateTextBox As System.Windows.Forms.MaskedTextBox
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents messageTextBox As System.Windows.Forms.TextBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents newContactButton As System.Windows.Forms.Button
    Private WithEvents label1 As System.Windows.Forms.Label
End Class
