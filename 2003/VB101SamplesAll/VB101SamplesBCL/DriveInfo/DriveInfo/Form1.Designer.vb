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
        Me.label10 = New System.Windows.Forms.Label
        Me.driveRootDirectory = New System.Windows.Forms.TextBox
        Me.label6 = New System.Windows.Forms.Label
        Me.driveType = New System.Windows.Forms.TextBox
        Me.driveFormat = New System.Windows.Forms.TextBox
        Me.driveVolumeLabel = New System.Windows.Forms.TextBox
        Me.driveName = New System.Windows.Forms.TextBox
        Me.driveReadyStatus = New System.Windows.Forms.Label
        Me.label5 = New System.Windows.Forms.Label
        Me.label4 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.drivesOnPc = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'label10
        '
        Me.label10.AutoSize = True
        Me.label10.Location = New System.Drawing.Point(12, 9)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(73, 13)
        Me.label10.TabIndex = 35
        Me.label10.Text = "Select a Drive:"
        '
        'driveRootDirectory
        '
        Me.driveRootDirectory.Enabled = False
        Me.driveRootDirectory.Location = New System.Drawing.Point(105, 161)
        Me.driveRootDirectory.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.driveRootDirectory.Name = "driveRootDirectory"
        Me.driveRootDirectory.Size = New System.Drawing.Size(116, 20)
        Me.driveRootDirectory.TabIndex = 34
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(10, 164)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(74, 13)
        Me.label6.TabIndex = 33
        Me.label6.Text = "Root Directory:"
        '
        'driveType
        '
        Me.driveType.Enabled = False
        Me.driveType.Location = New System.Drawing.Point(106, 77)
        Me.driveType.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.driveType.Name = "driveType"
        Me.driveType.Size = New System.Drawing.Size(81, 20)
        Me.driveType.TabIndex = 32
        '
        'driveFormat
        '
        Me.driveFormat.Enabled = False
        Me.driveFormat.Location = New System.Drawing.Point(106, 118)
        Me.driveFormat.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.driveFormat.Name = "driveFormat"
        Me.driveFormat.Size = New System.Drawing.Size(116, 20)
        Me.driveFormat.TabIndex = 31
        '
        'driveVolumeLabel
        '
        Me.driveVolumeLabel.Enabled = False
        Me.driveVolumeLabel.Location = New System.Drawing.Point(106, 42)
        Me.driveVolumeLabel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.driveVolumeLabel.Name = "driveVolumeLabel"
        Me.driveVolumeLabel.Size = New System.Drawing.Size(116, 20)
        Me.driveVolumeLabel.TabIndex = 30
        '
        'driveName
        '
        Me.driveName.Enabled = False
        Me.driveName.Location = New System.Drawing.Point(105, 206)
        Me.driveName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.driveName.Name = "driveName"
        Me.driveName.Size = New System.Drawing.Size(116, 20)
        Me.driveName.TabIndex = 29
        '
        'driveReadyStatus
        '
        Me.driveReadyStatus.AutoSize = True
        Me.driveReadyStatus.Location = New System.Drawing.Point(159, 9)
        Me.driveReadyStatus.Name = "driveReadyStatus"
        Me.driveReadyStatus.Size = New System.Drawing.Size(54, 13)
        Me.driveReadyStatus.TabIndex = 28
        Me.driveReadyStatus.Text = "Not Ready"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(58, 209)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(34, 13)
        Me.label5.TabIndex = 27
        Me.label5.Text = "Name:"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(14, 45)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(70, 13)
        Me.label4.TabIndex = 26
        Me.label4.Text = "Volume Label:"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(63, 80)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(30, 13)
        Me.label3.TabIndex = 25
        Me.label3.Text = "Type:"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(25, 121)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(59, 13)
        Me.label2.TabIndex = 24
        Me.label2.Text = "File System:"
        '
        'drivesOnPc
        '
        Me.drivesOnPc.FormattingEnabled = True
        Me.drivesOnPc.Location = New System.Drawing.Point(106, 6)
        Me.drivesOnPc.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.drivesOnPc.Name = "drivesOnPc"
        Me.drivesOnPc.Size = New System.Drawing.Size(47, 21)
        Me.drivesOnPc.TabIndex = 23
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(672, 346)
        Me.Controls.Add(Me.label10)
        Me.Controls.Add(Me.driveRootDirectory)
        Me.Controls.Add(Me.label6)
        Me.Controls.Add(Me.driveType)
        Me.Controls.Add(Me.driveFormat)
        Me.Controls.Add(Me.driveVolumeLabel)
        Me.Controls.Add(Me.driveName)
        Me.Controls.Add(Me.driveReadyStatus)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.drivesOnPc)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DriveInfo Sample"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents label10 As System.Windows.Forms.Label
    Friend WithEvents driveRootDirectory As System.Windows.Forms.TextBox
    Friend WithEvents label6 As System.Windows.Forms.Label
    Friend WithEvents driveType As System.Windows.Forms.TextBox
    Friend WithEvents driveFormat As System.Windows.Forms.TextBox
    Friend WithEvents driveVolumeLabel As System.Windows.Forms.TextBox
    Friend WithEvents driveName As System.Windows.Forms.TextBox
    Friend WithEvents driveReadyStatus As System.Windows.Forms.Label
    Friend WithEvents label5 As System.Windows.Forms.Label
    Friend WithEvents label4 As System.Windows.Forms.Label
    Friend WithEvents label3 As System.Windows.Forms.Label
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents drivesOnPc As System.Windows.Forms.ComboBox

End Class
