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
        Me.groupBox2 = New System.Windows.Forms.GroupBox
        Me.AddRule = New System.Windows.Forms.Button
        Me.UserName = New System.Windows.Forms.TextBox
        Me.label8 = New System.Windows.Forms.Label
        Me.label6 = New System.Windows.Forms.Label
        Me.AccessControlTypeSelection = New System.Windows.Forms.ComboBox
        Me.FileSystemRightsSelection = New System.Windows.Forms.ComboBox
        Me.label7 = New System.Windows.Forms.Label
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.label2 = New System.Windows.Forms.Label
        Me.RemoveRule = New System.Windows.Forms.Button
        Me.ACEDetails = New System.Windows.Forms.TreeView
        Me.BrowseFile = New System.Windows.Forms.Button
        Me.label1 = New System.Windows.Forms.Label
        Me.fileName = New System.Windows.Forms.TextBox
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.groupBox2.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.AddRule)
        Me.groupBox2.Controls.Add(Me.UserName)
        Me.groupBox2.Controls.Add(Me.label8)
        Me.groupBox2.Controls.Add(Me.label6)
        Me.groupBox2.Controls.Add(Me.AccessControlTypeSelection)
        Me.groupBox2.Controls.Add(Me.FileSystemRightsSelection)
        Me.groupBox2.Controls.Add(Me.label7)
        Me.groupBox2.Location = New System.Drawing.Point(12, 349)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(403, 106)
        Me.groupBox2.TabIndex = 8
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Add Access Rule"
        '
        'AddRule
        '
        Me.AddRule.Location = New System.Drawing.Point(286, 17)
        Me.AddRule.Name = "AddRule"
        Me.AddRule.Size = New System.Drawing.Size(108, 23)
        Me.AddRule.TabIndex = 12
        Me.AddRule.Text = "Add Rule"
        '
        'UserName
        '
        Me.UserName.Location = New System.Drawing.Point(76, 19)
        Me.UserName.Name = "UserName"
        Me.UserName.Size = New System.Drawing.Size(193, 20)
        Me.UserName.TabIndex = 15
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(34, 75)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(34, 13)
        Me.label8.TabIndex = 19
        Me.label8.Text = "Type:"
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(11, 22)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(63, 13)
        Me.label6.TabIndex = 14
        Me.label6.Text = "User Name:"
        '
        'AccessControlTypeSelection
        '
        Me.AccessControlTypeSelection.FormattingEnabled = True
        Me.AccessControlTypeSelection.Location = New System.Drawing.Point(76, 72)
        Me.AccessControlTypeSelection.Name = "AccessControlTypeSelection"
        Me.AccessControlTypeSelection.Size = New System.Drawing.Size(93, 21)
        Me.AccessControlTypeSelection.TabIndex = 18
        '
        'FileSystemRightsSelection
        '
        Me.FileSystemRightsSelection.FormattingEnabled = True
        Me.FileSystemRightsSelection.Location = New System.Drawing.Point(76, 45)
        Me.FileSystemRightsSelection.Name = "FileSystemRightsSelection"
        Me.FileSystemRightsSelection.Size = New System.Drawing.Size(121, 21)
        Me.FileSystemRightsSelection.TabIndex = 16
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(34, 48)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(40, 13)
        Me.label7.TabIndex = 17
        Me.label7.Text = "Rights:"
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.label2)
        Me.groupBox1.Controls.Add(Me.RemoveRule)
        Me.groupBox1.Controls.Add(Me.ACEDetails)
        Me.groupBox1.Controls.Add(Me.BrowseFile)
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.Controls.Add(Me.fileName)
        Me.groupBox1.Location = New System.Drawing.Point(12, 12)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(403, 331)
        Me.groupBox1.TabIndex = 7
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "File Access Security"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(12, 75)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(75, 13)
        Me.label2.TabIndex = 14
        Me.label2.Text = "Access Rules:"
        '
        'RemoveRule
        '
        Me.RemoveRule.Location = New System.Drawing.Point(138, 296)
        Me.RemoveRule.Name = "RemoveRule"
        Me.RemoveRule.Size = New System.Drawing.Size(108, 23)
        Me.RemoveRule.TabIndex = 13
        Me.RemoveRule.Text = "Remove Rule"
        '
        'ACEDetails
        '
        Me.ACEDetails.Location = New System.Drawing.Point(13, 91)
        Me.ACEDetails.Name = "ACEDetails"
        Me.ACEDetails.Size = New System.Drawing.Size(371, 191)
        Me.ACEDetails.TabIndex = 5
        '
        'BrowseFile
        '
        Me.BrowseFile.Location = New System.Drawing.Point(309, 49)
        Me.BrowseFile.Name = "BrowseFile"
        Me.BrowseFile.Size = New System.Drawing.Size(75, 23)
        Me.BrowseFile.TabIndex = 0
        Me.BrowseFile.Text = "Browse"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(12, 27)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(57, 13)
        Me.label1.TabIndex = 1
        Me.label1.Text = "File Name:"
        '
        'fileName
        '
        Me.fileName.Location = New System.Drawing.Point(71, 23)
        Me.fileName.Name = "fileName"
        Me.fileName.Size = New System.Drawing.Size(313, 20)
        Me.fileName.TabIndex = 2
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(429, 470)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.groupBox1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ACL Sample"
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents AddRule As System.Windows.Forms.Button
    Friend WithEvents UserName As System.Windows.Forms.TextBox
    Friend WithEvents label8 As System.Windows.Forms.Label
    Friend WithEvents label6 As System.Windows.Forms.Label
    Friend WithEvents AccessControlTypeSelection As System.Windows.Forms.ComboBox
    Friend WithEvents FileSystemRightsSelection As System.Windows.Forms.ComboBox
    Friend WithEvents label7 As System.Windows.Forms.Label
    Friend WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents RemoveRule As System.Windows.Forms.Button
    Friend WithEvents ACEDetails As System.Windows.Forms.TreeView
    Friend WithEvents BrowseFile As System.Windows.Forms.Button
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents fileName As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog

End Class
