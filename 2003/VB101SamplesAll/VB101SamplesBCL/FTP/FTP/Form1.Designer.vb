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
        Me.groupBox3 = New System.Windows.Forms.GroupBox
        Me.SetCredentials = New System.Windows.Forms.Button
        Me.password = New System.Windows.Forms.TextBox
        Me.userName = New System.Windows.Forms.TextBox
        Me.label6 = New System.Windows.Forms.Label
        Me.label5 = New System.Windows.Forms.Label
        Me.checkBox1 = New System.Windows.Forms.CheckBox
        Me.groupBox2 = New System.Windows.Forms.GroupBox
        Me.Download = New System.Windows.Forms.Button
        Me.downloadURI = New System.Windows.Forms.TextBox
        Me.label4 = New System.Windows.Forms.Label
        Me.Browse2 = New System.Windows.Forms.Button
        Me.DownloadFileName = New System.Windows.Forms.TextBox
        Me.label3 = New System.Windows.Forms.Label
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.groupBox3.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupBox3
        '
        Me.groupBox3.Controls.Add(Me.SetCredentials)
        Me.groupBox3.Controls.Add(Me.password)
        Me.groupBox3.Controls.Add(Me.userName)
        Me.groupBox3.Controls.Add(Me.label6)
        Me.groupBox3.Controls.Add(Me.label5)
        Me.groupBox3.Location = New System.Drawing.Point(12, 186)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Size = New System.Drawing.Size(437, 100)
        Me.groupBox3.TabIndex = 7
        Me.groupBox3.TabStop = False
        Me.groupBox3.Text = "Credentials"
        '
        'SetCredentials
        '
        Me.SetCredentials.Location = New System.Drawing.Point(289, 33)
        Me.SetCredentials.Name = "SetCredentials"
        Me.SetCredentials.Size = New System.Drawing.Size(75, 23)
        Me.SetCredentials.TabIndex = 7
        Me.SetCredentials.Text = "Set"
        '
        'password
        '
        Me.password.Location = New System.Drawing.Point(70, 58)
        Me.password.Name = "password"
        Me.password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.password.Size = New System.Drawing.Size(186, 20)
        Me.password.TabIndex = 8
        Me.password.UseSystemPasswordChar = True
        '
        'userName
        '
        Me.userName.Location = New System.Drawing.Point(70, 30)
        Me.userName.Name = "userName"
        Me.userName.Size = New System.Drawing.Size(186, 20)
        Me.userName.TabIndex = 7
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(7, 61)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(52, 13)
        Me.label6.TabIndex = 1
        Me.label6.Text = "Password:"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(10, 33)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(54, 13)
        Me.label5.TabIndex = 0
        Me.label5.Text = "Username:"
        '
        'checkBox1
        '
        Me.checkBox1.AutoSize = True
        Me.checkBox1.Location = New System.Drawing.Point(19, 154)
        Me.checkBox1.Name = "checkBox1"
        Me.checkBox1.Size = New System.Drawing.Size(128, 17)
        Me.checkBox1.TabIndex = 6
        Me.checkBox1.Text = "Use Anonomous User:"
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.Download)
        Me.groupBox2.Controls.Add(Me.downloadURI)
        Me.groupBox2.Controls.Add(Me.label4)
        Me.groupBox2.Controls.Add(Me.Browse2)
        Me.groupBox2.Controls.Add(Me.DownloadFileName)
        Me.groupBox2.Controls.Add(Me.label3)
        Me.groupBox2.Location = New System.Drawing.Point(12, 12)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(437, 136)
        Me.groupBox2.TabIndex = 5
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Download"
        '
        'Download
        '
        Me.Download.Location = New System.Drawing.Point(353, 69)
        Me.Download.Name = "Download"
        Me.Download.Size = New System.Drawing.Size(75, 23)
        Me.Download.TabIndex = 6
        Me.Download.Text = "Download"
        '
        'downloadURI
        '
        Me.downloadURI.Location = New System.Drawing.Point(46, 67)
        Me.downloadURI.Name = "downloadURI"
        Me.downloadURI.Size = New System.Drawing.Size(292, 20)
        Me.downloadURI.TabIndex = 6
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(6, 36)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(22, 13)
        Me.label4.TabIndex = 6
        Me.label4.Text = "File:"
        '
        'Browse2
        '
        Me.Browse2.Location = New System.Drawing.Point(353, 31)
        Me.Browse2.Name = "Browse2"
        Me.Browse2.Size = New System.Drawing.Size(75, 23)
        Me.Browse2.TabIndex = 6
        Me.Browse2.Text = "Browse"
        '
        'DownloadFileName
        '
        Me.DownloadFileName.Location = New System.Drawing.Point(46, 33)
        Me.DownloadFileName.Name = "DownloadFileName"
        Me.DownloadFileName.Size = New System.Drawing.Size(292, 20)
        Me.DownloadFileName.TabIndex = 6
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(9, 74)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(19, 13)
        Me.label3.TabIndex = 6
        Me.label3.Text = "Uri:"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(465, 300)
        Me.Controls.Add(Me.groupBox3)
        Me.Controls.Add(Me.checkBox1)
        Me.Controls.Add(Me.groupBox2)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Simple FTP Client"
        Me.groupBox3.ResumeLayout(False)
        Me.groupBox3.PerformLayout()
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents groupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents SetCredentials As System.Windows.Forms.Button
    Friend WithEvents password As System.Windows.Forms.TextBox
    Friend WithEvents userName As System.Windows.Forms.TextBox
    Friend WithEvents label6 As System.Windows.Forms.Label
    Friend WithEvents label5 As System.Windows.Forms.Label
    Friend WithEvents checkBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Download As System.Windows.Forms.Button
    Friend WithEvents downloadURI As System.Windows.Forms.TextBox
    Friend WithEvents label4 As System.Windows.Forms.Label
    Friend WithEvents Browse2 As System.Windows.Forms.Button
    Friend WithEvents DownloadFileName As System.Windows.Forms.TextBox
    Friend WithEvents label3 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog

End Class
