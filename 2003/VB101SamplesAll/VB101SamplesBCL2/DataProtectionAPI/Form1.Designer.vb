<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.DataTextBox = New System.Windows.Forms.TextBox
        Me.EncryptButton = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.DecryptButton = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.EncryptedBytesTextBox = New System.Windows.Forms.TextBox
        Me.RawBytesTextBox = New System.Windows.Forms.TextBox
        Me.VerifyTextBox = New System.Windows.Forms.TextBox
        Me.WriteFileTextBox = New System.Windows.Forms.TextBox
        Me.EncryptedDestinationComboBox = New System.Windows.Forms.ComboBox
        Me.FileNameLabel = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Data To Encrpyt"
        '
        'DataTextBox
        '
        Me.DataTextBox.Location = New System.Drawing.Point(16, 29)
        Me.DataTextBox.Name = "DataTextBox"
        Me.DataTextBox.Size = New System.Drawing.Size(148, 20)
        Me.DataTextBox.TabIndex = 1
        '
        'EncryptButton
        '
        Me.EncryptButton.Location = New System.Drawing.Point(170, 29)
        Me.EncryptButton.Name = "EncryptButton"
        Me.EncryptButton.Size = New System.Drawing.Size(75, 23)
        Me.EncryptButton.TabIndex = 2
        Me.EncryptButton.Text = "Encrypt"
        Me.EncryptButton.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(248, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Encrypted Bytes"
        '
        'DecryptButton
        '
        Me.DecryptButton.Location = New System.Drawing.Point(16, 215)
        Me.DecryptButton.Name = "DecryptButton"
        Me.DecryptButton.Size = New System.Drawing.Size(75, 23)
        Me.DecryptButton.TabIndex = 7
        Me.DecryptButton.Text = "Decrypt"
        Me.DecryptButton.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 197)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(143, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Decrpyt and Verify Data"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Raw Bytes"
        '
        'EncryptedBytesTextBox
        '
        Me.EncryptedBytesTextBox.BackColor = System.Drawing.SystemColors.Info
        Me.EncryptedBytesTextBox.ForeColor = System.Drawing.SystemColors.InfoText
        Me.EncryptedBytesTextBox.Location = New System.Drawing.Point(251, 78)
        Me.EncryptedBytesTextBox.Multiline = True
        Me.EncryptedBytesTextBox.Name = "EncryptedBytesTextBox"
        Me.EncryptedBytesTextBox.ReadOnly = True
        Me.EncryptedBytesTextBox.Size = New System.Drawing.Size(518, 116)
        Me.EncryptedBytesTextBox.TabIndex = 6
        '
        'RawBytesTextBox
        '
        Me.RawBytesTextBox.BackColor = System.Drawing.SystemColors.Info
        Me.RawBytesTextBox.ForeColor = System.Drawing.SystemColors.InfoText
        Me.RawBytesTextBox.Location = New System.Drawing.Point(16, 78)
        Me.RawBytesTextBox.Multiline = True
        Me.RawBytesTextBox.Name = "RawBytesTextBox"
        Me.RawBytesTextBox.ReadOnly = True
        Me.RawBytesTextBox.Size = New System.Drawing.Size(229, 116)
        Me.RawBytesTextBox.TabIndex = 5
        '
        'VerifyTextBox
        '
        Me.VerifyTextBox.BackColor = System.Drawing.SystemColors.Info
        Me.VerifyTextBox.ForeColor = System.Drawing.SystemColors.InfoText
        Me.VerifyTextBox.Location = New System.Drawing.Point(97, 217)
        Me.VerifyTextBox.Name = "VerifyTextBox"
        Me.VerifyTextBox.ReadOnly = True
        Me.VerifyTextBox.Size = New System.Drawing.Size(148, 20)
        Me.VerifyTextBox.TabIndex = 8
        '
        'WriteFileTextBox
        '
        Me.WriteFileTextBox.BackColor = System.Drawing.SystemColors.Info
        Me.WriteFileTextBox.ForeColor = System.Drawing.SystemColors.InfoText
        Me.WriteFileTextBox.Location = New System.Drawing.Point(378, 29)
        Me.WriteFileTextBox.Name = "WriteFileTextBox"
        Me.WriteFileTextBox.ReadOnly = True
        Me.WriteFileTextBox.Size = New System.Drawing.Size(60, 20)
        Me.WriteFileTextBox.TabIndex = 4
        Me.WriteFileTextBox.Text = "Data.dat"
        '
        'EncryptedDestinationComboBox
        '
        Me.EncryptedDestinationComboBox.FormattingEnabled = True
        Me.EncryptedDestinationComboBox.Items.AddRange(New Object() {"Encrypt to Memory", "Encrypt to File"})
        Me.EncryptedDestinationComboBox.Location = New System.Drawing.Point(251, 29)
        Me.EncryptedDestinationComboBox.Name = "EncryptedDestinationComboBox"
        Me.EncryptedDestinationComboBox.Size = New System.Drawing.Size(121, 21)
        Me.EncryptedDestinationComboBox.TabIndex = 3
        '
        'FileNameLabel
        '
        Me.FileNameLabel.AutoSize = True
        Me.FileNameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FileNameLabel.Location = New System.Drawing.Point(375, 13)
        Me.FileNameLabel.Name = "FileNameLabel"
        Me.FileNameLabel.Size = New System.Drawing.Size(63, 13)
        Me.FileNameLabel.TabIndex = 17
        Me.FileNameLabel.Text = "File Name"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(251, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Destination"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 266)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.FileNameLabel)
        Me.Controls.Add(Me.EncryptedDestinationComboBox)
        Me.Controls.Add(Me.WriteFileTextBox)
        Me.Controls.Add(Me.VerifyTextBox)
        Me.Controls.Add(Me.RawBytesTextBox)
        Me.Controls.Add(Me.EncryptedBytesTextBox)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DecryptButton)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.EncryptButton)
        Me.Controls.Add(Me.DataTextBox)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataTextBox As System.Windows.Forms.TextBox
    Friend WithEvents EncryptButton As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DecryptButton As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents EncryptedBytesTextBox As System.Windows.Forms.TextBox
    Friend WithEvents RawBytesTextBox As System.Windows.Forms.TextBox
    Friend WithEvents VerifyTextBox As System.Windows.Forms.TextBox
    Friend WithEvents WriteFileTextBox As System.Windows.Forms.TextBox
    Friend WithEvents EncryptedDestinationComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents FileNameLabel As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label

End Class
