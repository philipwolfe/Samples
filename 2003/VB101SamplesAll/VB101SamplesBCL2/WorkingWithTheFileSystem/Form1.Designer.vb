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
    Private sourcePathTextBox As System.Windows.Forms.TextBox
    Private WithEvents sourceListBox As System.Windows.Forms.ListBox
    Private destPathTextBox As System.Windows.Forms.TextBox
    Private WithEvents browseLeft As System.Windows.Forms.Button
    Private WithEvents browseRight As System.Windows.Forms.Button
    Private destListBox As System.Windows.Forms.ListBox
    Private WithEvents deleteButton As System.Windows.Forms.Button
    Private WithEvents copyButton As System.Windows.Forms.Button
    Private WithEvents moveButton As System.Windows.Forms.Button
    Private WithEvents createButton As System.Windows.Forms.Button
    Private label1 As System.Windows.Forms.Label
    Private label2 As System.Windows.Forms.Label
    Private WithEvents fileInfoButton As System.Windows.Forms.Button
    Private WithEvents closeButton As System.Windows.Forms.Button
    Private label3 As System.Windows.Forms.Label
    Private label4 As System.Windows.Forms.Label
    Private WithEvents menuStrip1 As System.Windows.Forms.MenuStrip
    Private WithEvents fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents exitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents openButton As System.Windows.Forms.Button

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.sourcePathTextBox = New System.Windows.Forms.TextBox
        Me.sourceListBox = New System.Windows.Forms.ListBox
        Me.destPathTextBox = New System.Windows.Forms.TextBox
        Me.browseLeft = New System.Windows.Forms.Button
        Me.browseRight = New System.Windows.Forms.Button
        Me.destListBox = New System.Windows.Forms.ListBox
        Me.deleteButton = New System.Windows.Forms.Button
        Me.copyButton = New System.Windows.Forms.Button
        Me.moveButton = New System.Windows.Forms.Button
        Me.createButton = New System.Windows.Forms.Button
        Me.label1 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.fileInfoButton = New System.Windows.Forms.Button
        Me.closeButton = New System.Windows.Forms.Button
        Me.label3 = New System.Windows.Forms.Label
        Me.label4 = New System.Windows.Forms.Label
        Me.menuStrip1 = New System.Windows.Forms.MenuStrip
        Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.openButton = New System.Windows.Forms.Button
        Me.menuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'sourcePathTextBox
        '
        Me.sourcePathTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.sourcePathTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem
        Me.sourcePathTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sourcePathTextBox.Location = New System.Drawing.Point(87, 46)
        Me.sourcePathTextBox.Name = "sourcePathTextBox"
        Me.sourcePathTextBox.Size = New System.Drawing.Size(675, 18)
        Me.sourcePathTextBox.TabIndex = 2
        '
        'sourceListBox
        '
        Me.sourceListBox.FormattingEnabled = True
        Me.sourceListBox.HorizontalScrollbar = True
        Me.sourceListBox.Location = New System.Drawing.Point(22, 122)
        Me.sourceListBox.Name = "sourceListBox"
        Me.sourceListBox.Size = New System.Drawing.Size(336, 225)
        Me.sourceListBox.TabIndex = 8
        '
        'destPathTextBox
        '
        Me.destPathTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.destPathTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem
        Me.destPathTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.destPathTextBox.Location = New System.Drawing.Point(87, 72)
        Me.destPathTextBox.Name = "destPathTextBox"
        Me.destPathTextBox.Size = New System.Drawing.Size(675, 18)
        Me.destPathTextBox.TabIndex = 5
        '
        'browseLeft
        '
        Me.browseLeft.Location = New System.Drawing.Point(767, 46)
        Me.browseLeft.Name = "browseLeft"
        Me.browseLeft.Size = New System.Drawing.Size(31, 20)
        Me.browseLeft.TabIndex = 3
        Me.browseLeft.Text = ". . ."
        Me.browseLeft.UseVisualStyleBackColor = True
        '
        'browseRight
        '
        Me.browseRight.Location = New System.Drawing.Point(767, 71)
        Me.browseRight.Name = "browseRight"
        Me.browseRight.Size = New System.Drawing.Size(31, 20)
        Me.browseRight.TabIndex = 6
        Me.browseRight.Text = ". . ."
        Me.browseRight.UseVisualStyleBackColor = True
        '
        'destListBox
        '
        Me.destListBox.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.destListBox.Enabled = False
        Me.destListBox.FormattingEnabled = True
        Me.destListBox.HorizontalScrollbar = True
        Me.destListBox.Location = New System.Drawing.Point(460, 122)
        Me.destListBox.Name = "destListBox"
        Me.destListBox.Size = New System.Drawing.Size(336, 225)
        Me.destListBox.TabIndex = 15
        '
        'deleteButton
        '
        Me.deleteButton.Enabled = False
        Me.deleteButton.Location = New System.Drawing.Point(373, 184)
        Me.deleteButton.Name = "deleteButton"
        Me.deleteButton.Size = New System.Drawing.Size(75, 23)
        Me.deleteButton.TabIndex = 11
        Me.deleteButton.Text = "Delete"
        Me.deleteButton.UseVisualStyleBackColor = True
        '
        'copyButton
        '
        Me.copyButton.Enabled = False
        Me.copyButton.Location = New System.Drawing.Point(373, 122)
        Me.copyButton.Name = "copyButton"
        Me.copyButton.Size = New System.Drawing.Size(75, 23)
        Me.copyButton.TabIndex = 9
        Me.copyButton.Text = "Copy"
        Me.copyButton.UseVisualStyleBackColor = True
        '
        'moveButton
        '
        Me.moveButton.Enabled = False
        Me.moveButton.Location = New System.Drawing.Point(373, 153)
        Me.moveButton.Name = "moveButton"
        Me.moveButton.Size = New System.Drawing.Size(75, 23)
        Me.moveButton.TabIndex = 10
        Me.moveButton.Text = "Move"
        Me.moveButton.UseVisualStyleBackColor = True
        '
        'createButton
        '
        Me.createButton.Location = New System.Drawing.Point(373, 279)
        Me.createButton.Name = "createButton"
        Me.createButton.Size = New System.Drawing.Size(75, 23)
        Me.createButton.TabIndex = 13
        Me.createButton.Text = "Create"
        Me.createButton.UseVisualStyleBackColor = True
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(19, 106)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(41, 13)
        Me.label1.TabIndex = 7
        Me.label1.Text = "Source"
        Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(457, 106)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(60, 13)
        Me.label2.TabIndex = 14
        Me.label2.Text = "Destination"
        Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'fileInfoButton
        '
        Me.fileInfoButton.Location = New System.Drawing.Point(373, 213)
        Me.fileInfoButton.Name = "fileInfoButton"
        Me.fileInfoButton.Size = New System.Drawing.Size(75, 23)
        Me.fileInfoButton.TabIndex = 12
        Me.fileInfoButton.Text = "File Info"
        Me.fileInfoButton.UseVisualStyleBackColor = True
        '
        'closeButton
        '
        Me.closeButton.Location = New System.Drawing.Point(721, 357)
        Me.closeButton.Name = "closeButton"
        Me.closeButton.Size = New System.Drawing.Size(75, 23)
        Me.closeButton.TabIndex = 16
        Me.closeButton.Text = "Close"
        Me.closeButton.UseVisualStyleBackColor = True
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(19, 48)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(41, 13)
        Me.label3.TabIndex = 1
        Me.label3.Text = "Source"
        Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(19, 74)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(60, 13)
        Me.label4.TabIndex = 4
        Me.label4.Text = "Destination"
        Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'menuStrip1
        '
        Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileToolStripMenuItem})
        Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip1.Name = "menuStrip1"
        Me.menuStrip1.Size = New System.Drawing.Size(817, 24)
        Me.menuStrip1.TabIndex = 0
        Me.menuStrip1.Text = "menuStrip1"
        '
        'fileToolStripMenuItem
        '
        Me.fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.exitToolStripMenuItem})
        Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
        Me.fileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.fileToolStripMenuItem.Text = "&File"
        '
        'exitToolStripMenuItem
        '
        Me.exitToolStripMenuItem.Name = "exitToolStripMenuItem"
        Me.exitToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.exitToolStripMenuItem.Text = "E&xit"
        '
        'openButton
        '
        Me.openButton.Location = New System.Drawing.Point(373, 308)
        Me.openButton.Name = "openButton"
        Me.openButton.Size = New System.Drawing.Size(75, 23)
        Me.openButton.TabIndex = 13
        Me.openButton.Text = "Open"
        Me.openButton.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(817, 388)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.closeButton)
        Me.Controls.Add(Me.fileInfoButton)
        Me.Controls.Add(Me.openButton)
        Me.Controls.Add(Me.createButton)
        Me.Controls.Add(Me.moveButton)
        Me.Controls.Add(Me.copyButton)
        Me.Controls.Add(Me.deleteButton)
        Me.Controls.Add(Me.browseRight)
        Me.Controls.Add(Me.browseLeft)
        Me.Controls.Add(Me.destListBox)
        Me.Controls.Add(Me.sourceListBox)
        Me.Controls.Add(Me.destPathTextBox)
        Me.Controls.Add(Me.sourcePathTextBox)
        Me.Controls.Add(Me.menuStrip1)
        Me.MainMenuStrip = Me.menuStrip1
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Working with the File System"
        Me.menuStrip1.ResumeLayout(False)
        Me.menuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

End Class
