<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class Form1

    ' <summary>
    ' Required designer variable.
    ' </summary>
    Private components As System.ComponentModel.IContainer = Nothing
    Friend WithEvents clearDataTextBox As System.Windows.Forms.TextBox
    Friend WithEvents clearFileTextBox As System.Windows.Forms.TextBox
    Friend WithEvents closeButton As System.Windows.Forms.Button
    Friend WithEvents decryptButton As System.Windows.Forms.Button
    Friend WithEvents decryptedFileTextBox As System.Windows.Forms.TextBox
    Friend WithEvents encryptButton As System.Windows.Forms.Button
    Friend WithEvents encryptedFileTextBox As System.Windows.Forms.TextBox
    Friend WithEvents exitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents label3 As System.Windows.Forms.Label
    Friend WithEvents label4 As System.Windows.Forms.Label
    Friend WithEvents loadClearDataButton As System.Windows.Forms.Button
    Friend WithEvents loadDecryptedDataButton As System.Windows.Forms.Button
    Friend WithEvents menuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents workFolderTextBox As System.Windows.Forms.TextBox

    ' <summary>
    ' Clean up any resources being used.
    ' </summary>
    ' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If (disposing _
                    AndAlso (Not (components) Is Nothing)) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' <summary>
    ' Required method for Designer support - do not modify
    ' the contents of this method with the code editor.
    ' </summary>
    Private Sub InitializeComponent()
        Me.closeButton = New System.Windows.Forms.Button
        Me.decryptButton = New System.Windows.Forms.Button
        Me.loadClearDataButton = New System.Windows.Forms.Button
        Me.encryptButton = New System.Windows.Forms.Button
        Me.label2 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.encryptedFileTextBox = New System.Windows.Forms.TextBox
        Me.clearFileTextBox = New System.Windows.Forms.TextBox
        Me.clearDataTextBox = New System.Windows.Forms.TextBox
        Me.menuStrip1 = New System.Windows.Forms.MenuStrip
        Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.label3 = New System.Windows.Forms.Label
        Me.workFolderTextBox = New System.Windows.Forms.TextBox
        Me.decryptedFileTextBox = New System.Windows.Forms.TextBox
        Me.label4 = New System.Windows.Forms.Label
        Me.loadDecryptedDataButton = New System.Windows.Forms.Button
        Me.menuStrip1.SuspendLayout()
        Me.SuspendLayout()
        ' 
        ' closeButton
        ' 
        Me.closeButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.closeButton.Location = New System.Drawing.Point(586, 397)
        Me.closeButton.Name = "closeButton"
        Me.closeButton.Size = New System.Drawing.Size(75, 23)
        Me.closeButton.TabIndex = 14
        Me.closeButton.Text = "Close"
        Me.closeButton.UseVisualStyleBackColor = True
        AddHandler closeButton.Click, AddressOf Me.closeButton_Click
        ' 
        ' decryptButton
        ' 
        Me.decryptButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.decryptButton.Location = New System.Drawing.Point(381, 397)
        Me.decryptButton.Name = "decryptButton"
        Me.decryptButton.Size = New System.Drawing.Size(75, 23)
        Me.decryptButton.TabIndex = 12
        Me.decryptButton.Text = "Decrypt"
        Me.decryptButton.UseVisualStyleBackColor = True
        AddHandler decryptButton.Click, AddressOf Me.decryptButton_Click
        ' 
        ' loadClearDataButton
        ' 
        Me.loadClearDataButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.loadClearDataButton.Location = New System.Drawing.Point(199, 397)
        Me.loadClearDataButton.Name = "loadClearDataButton"
        Me.loadClearDataButton.Size = New System.Drawing.Size(95, 23)
        Me.loadClearDataButton.TabIndex = 10
        Me.loadClearDataButton.Text = "Show clear data"
        Me.loadClearDataButton.UseVisualStyleBackColor = True
        AddHandler loadClearDataButton.Click, AddressOf Me.loadClearDataButton_Click
        ' 
        ' encryptButton
        ' 
        Me.encryptButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.encryptButton.Location = New System.Drawing.Point(300, 397)
        Me.encryptButton.Name = "encryptButton"
        Me.encryptButton.Size = New System.Drawing.Size(75, 23)
        Me.encryptButton.TabIndex = 11
        Me.encryptButton.Text = "Encrypt"
        Me.encryptButton.UseVisualStyleBackColor = True
        AddHandler encryptButton.Click, AddressOf Me.encryptButton_Click
        ' 
        ' label2
        ' 
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(27, 83)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(71, 13)
        Me.label2.TabIndex = 5
        Me.label2.Text = "Encrypted file"
        ' 
        ' label1
        ' 
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(27, 57)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(71, 13)
        Me.label1.TabIndex = 3
        Me.label1.Text = "Clear data file"
        ' 
        ' encryptedFileTextBox
        ' 
        Me.encryptedFileTextBox.Location = New System.Drawing.Point(104, 80)
        Me.encryptedFileTextBox.Name = "encryptedFileTextBox"
        Me.encryptedFileTextBox.Size = New System.Drawing.Size(557, 20)
        Me.encryptedFileTextBox.TabIndex = 6
        ' 
        ' clearFileTextBox
        ' 
        Me.clearFileTextBox.Location = New System.Drawing.Point(104, 54)
        Me.clearFileTextBox.Name = "clearFileTextBox"
        Me.clearFileTextBox.Size = New System.Drawing.Size(557, 20)
        Me.clearFileTextBox.TabIndex = 4
        AddHandler clearFileTextBox.TextChanged, AddressOf Me.clearFileTextBox_TextChanged
        ' 
        ' clearDataTextBox
        ' 
        Me.clearDataTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.clearDataTextBox.Location = New System.Drawing.Point(30, 160)
        Me.clearDataTextBox.Multiline = True
        Me.clearDataTextBox.Name = "clearDataTextBox"
        Me.clearDataTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.clearDataTextBox.Size = New System.Drawing.Size(631, 225)
        Me.clearDataTextBox.TabIndex = 9
        ' 
        ' menuStrip1
        ' 
        Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileToolStripMenuItem})
        Me.menuStrip1.Location = New System.Drawing.Point(15, 0)
        Me.menuStrip1.Name = "menuStrip1"
        Me.menuStrip1.Size = New System.Drawing.Size(662, 24)
        Me.menuStrip1.TabIndex = 0
        Me.menuStrip1.Text = "menuStrip1"
        ' 
        ' fileToolStripMenuItem
        ' 
        Me.fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.exitToolStripMenuItem})
        Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
        Me.fileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.fileToolStripMenuItem.Text = "&File"
        ' 
        ' exitToolStripMenuItem
        ' 
        Me.exitToolStripMenuItem.Name = "exitToolStripMenuItem"
        Me.exitToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.exitToolStripMenuItem.Text = "E&xit"
        AddHandler exitToolStripMenuItem.Click, AddressOf Me.exitToolStripMenuItem_Click
        ' 
        ' label3
        ' 
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(27, 35)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(62, 13)
        Me.label3.TabIndex = 1
        Me.label3.Text = "Work folder"
        ' 
        ' workFolderTextBox
        ' 
        Me.workFolderTextBox.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.workFolderTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.workFolderTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.workFolderTextBox.Location = New System.Drawing.Point(104, 35)
        Me.workFolderTextBox.Name = "workFolderTextBox"
        Me.workFolderTextBox.ReadOnly = True
        Me.workFolderTextBox.Size = New System.Drawing.Size(557, 12)
        Me.workFolderTextBox.TabIndex = 2
        Me.workFolderTextBox.TabStop = False
        Me.workFolderTextBox.Text = "Work folder path goes here."
        ' 
        ' decryptedFileTextBox
        ' 
        Me.decryptedFileTextBox.Location = New System.Drawing.Point(104, 106)
        Me.decryptedFileTextBox.Name = "decryptedFileTextBox"
        Me.decryptedFileTextBox.Size = New System.Drawing.Size(557, 20)
        Me.decryptedFileTextBox.TabIndex = 8
        ' 
        ' label4
        ' 
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(27, 109)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(72, 13)
        Me.label4.TabIndex = 7
        Me.label4.Text = "Decrypted file"
        ' 
        ' loadDecryptedDataButton
        ' 
        Me.loadDecryptedDataButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.loadDecryptedDataButton.Location = New System.Drawing.Point(462, 397)
        Me.loadDecryptedDataButton.Name = "loadDecryptedDataButton"
        Me.loadDecryptedDataButton.Size = New System.Drawing.Size(118, 23)
        Me.loadDecryptedDataButton.TabIndex = 13
        Me.loadDecryptedDataButton.Text = "Show decrypted data"
        Me.loadDecryptedDataButton.UseVisualStyleBackColor = True
        AddHandler loadDecryptedDataButton.Click, AddressOf Me.loadDecryptedDataButton_Click
        ' 
        ' Form1
        ' 
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(692, 432)
        Me.Controls.Add(Me.loadDecryptedDataButton)
        Me.Controls.Add(Me.workFolderTextBox)
        Me.Controls.Add(Me.loadClearDataButton)
        Me.Controls.Add(Me.encryptButton)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.decryptedFileTextBox)
        Me.Controls.Add(Me.encryptedFileTextBox)
        Me.Controls.Add(Me.clearFileTextBox)
        Me.Controls.Add(Me.clearDataTextBox)
        Me.Controls.Add(Me.decryptButton)
        Me.Controls.Add(Me.closeButton)
        Me.Controls.Add(Me.menuStrip1)
        Me.MainMenuStrip = Me.menuStrip1
        Me.Name = "Form1"
        Me.Padding = New System.Windows.Forms.Padding(15, 0, 15, 50)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Encryption and Decryption"
        AddHandler Load, AddressOf Me.Form1_Load
        Me.menuStrip1.ResumeLayout(False)
        Me.menuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
End Class
