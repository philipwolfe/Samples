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
        Me.playSystemSoundButton = New System.Windows.Forms.Button
        Me.instructionsLabel = New System.Windows.Forms.Label
        Me.systemSoundsComboBox = New System.Windows.Forms.ComboBox
        Me.systemSoundsGroupBox = New System.Windows.Forms.GroupBox
        Me.loopCheckBox = New System.Windows.Forms.CheckBox
        Me.statusStrip1 = New System.Windows.Forms.StatusStrip
        Me.stopAsyncPlayButton = New System.Windows.Forms.Button
        Me.playAsyncButton = New System.Windows.Forms.Button
        Me.playSyncButton = New System.Windows.Forms.Button
        Me.wavFilesGroupBox = New System.Windows.Forms.GroupBox
        Me.browseButton = New System.Windows.Forms.Button
        Me.soundFileNameTextBox = New System.Windows.Forms.TextBox
        Me.systemSoundsGroupBox.SuspendLayout()
        Me.wavFilesGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'playSystemSoundButton
        '
        Me.playSystemSoundButton.Location = New System.Drawing.Point(340, 18)
        Me.playSystemSoundButton.Name = "playSystemSoundButton"
        Me.playSystemSoundButton.Size = New System.Drawing.Size(75, 23)
        Me.playSystemSoundButton.TabIndex = 9
        Me.playSystemSoundButton.Text = "Play"
        '
        'instructionsLabel
        '
        Me.instructionsLabel.Location = New System.Drawing.Point(6, 21)
        Me.instructionsLabel.Name = "instructionsLabel"
        Me.instructionsLabel.Size = New System.Drawing.Size(409, 33)
        Me.instructionsLabel.TabIndex = 13
        Me.instructionsLabel.Text = "Enter the path to a sound file or click Browse and navigate to a file.  Then clic" & _
            "k one of the Play buttons."
        '
        'systemSoundsComboBox
        '
        Me.systemSoundsComboBox.FormattingEnabled = True
        Me.systemSoundsComboBox.Location = New System.Drawing.Point(16, 20)
        Me.systemSoundsComboBox.Name = "systemSoundsComboBox"
        Me.systemSoundsComboBox.Size = New System.Drawing.Size(318, 21)
        Me.systemSoundsComboBox.TabIndex = 8
        '
        'systemSoundsGroupBox
        '
        Me.systemSoundsGroupBox.Controls.Add(Me.playSystemSoundButton)
        Me.systemSoundsGroupBox.Controls.Add(Me.systemSoundsComboBox)
        Me.systemSoundsGroupBox.Location = New System.Drawing.Point(12, 176)
        Me.systemSoundsGroupBox.Name = "systemSoundsGroupBox"
        Me.systemSoundsGroupBox.Size = New System.Drawing.Size(518, 47)
        Me.systemSoundsGroupBox.TabIndex = 12
        Me.systemSoundsGroupBox.TabStop = False
        Me.systemSoundsGroupBox.Text = "System Sounds"
        '
        'loopCheckBox
        '
        Me.loopCheckBox.AutoSize = True
        Me.loopCheckBox.Location = New System.Drawing.Point(16, 114)
        Me.loopCheckBox.Name = "loopCheckBox"
        Me.loopCheckBox.Size = New System.Drawing.Size(112, 17)
        Me.loopCheckBox.TabIndex = 11
        Me.loopCheckBox.Text = "Loop (Async Only)"
        '
        'statusStrip1
        '
        Me.statusStrip1.Location = New System.Drawing.Point(0, 394)
        Me.statusStrip1.Name = "statusStrip1"
        Me.statusStrip1.Size = New System.Drawing.Size(542, 22)
        Me.statusStrip1.TabIndex = 13
        Me.statusStrip1.Text = "statusStrip1"
        '
        'stopAsyncPlayButton
        '
        Me.stopAsyncPlayButton.AutoSize = True
        Me.stopAsyncPlayButton.Location = New System.Drawing.Point(178, 85)
        Me.stopAsyncPlayButton.Name = "stopAsyncPlayButton"
        Me.stopAsyncPlayButton.Size = New System.Drawing.Size(68, 23)
        Me.stopAsyncPlayButton.TabIndex = 10
        Me.stopAsyncPlayButton.Text = "Stop"
        '
        'playAsyncButton
        '
        Me.playAsyncButton.Location = New System.Drawing.Point(16, 85)
        Me.playAsyncButton.Name = "playAsyncButton"
        Me.playAsyncButton.Size = New System.Drawing.Size(75, 23)
        Me.playAsyncButton.TabIndex = 9
        Me.playAsyncButton.Text = "Play Async"
        '
        'playSyncButton
        '
        Me.playSyncButton.Location = New System.Drawing.Point(97, 85)
        Me.playSyncButton.Name = "playSyncButton"
        Me.playSyncButton.Size = New System.Drawing.Size(75, 23)
        Me.playSyncButton.TabIndex = 8
        Me.playSyncButton.Text = "Play"
        '
        'wavFilesGroupBox
        '
        Me.wavFilesGroupBox.Controls.Add(Me.instructionsLabel)
        Me.wavFilesGroupBox.Controls.Add(Me.loopCheckBox)
        Me.wavFilesGroupBox.Controls.Add(Me.stopAsyncPlayButton)
        Me.wavFilesGroupBox.Controls.Add(Me.playAsyncButton)
        Me.wavFilesGroupBox.Controls.Add(Me.playSyncButton)
        Me.wavFilesGroupBox.Controls.Add(Me.browseButton)
        Me.wavFilesGroupBox.Controls.Add(Me.soundFileNameTextBox)
        Me.wavFilesGroupBox.Location = New System.Drawing.Point(12, 11)
        Me.wavFilesGroupBox.Name = "wavFilesGroupBox"
        Me.wavFilesGroupBox.Size = New System.Drawing.Size(518, 159)
        Me.wavFilesGroupBox.TabIndex = 11
        Me.wavFilesGroupBox.TabStop = False
        Me.wavFilesGroupBox.Text = "WAV files"
        '
        'browseButton
        '
        Me.browseButton.Location = New System.Drawing.Point(340, 57)
        Me.browseButton.Name = "browseButton"
        Me.browseButton.Size = New System.Drawing.Size(75, 23)
        Me.browseButton.TabIndex = 7
        Me.browseButton.Text = "Browse..."
        '
        'soundFileNameTextBox
        '
        Me.soundFileNameTextBox.Location = New System.Drawing.Point(16, 59)
        Me.soundFileNameTextBox.Name = "soundFileNameTextBox"
        Me.soundFileNameTextBox.Size = New System.Drawing.Size(318, 20)
        Me.soundFileNameTextBox.TabIndex = 6
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(542, 416)
        Me.Controls.Add(Me.systemSoundsGroupBox)
        Me.Controls.Add(Me.statusStrip1)
        Me.Controls.Add(Me.wavFilesGroupBox)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Playing Sounds"
        Me.systemSoundsGroupBox.ResumeLayout(False)
        Me.wavFilesGroupBox.ResumeLayout(False)
        Me.wavFilesGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents playSystemSoundButton As System.Windows.Forms.Button
    Friend WithEvents instructionsLabel As System.Windows.Forms.Label
    Friend WithEvents systemSoundsComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents systemSoundsGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents loopCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents statusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents stopAsyncPlayButton As System.Windows.Forms.Button
    Friend WithEvents playAsyncButton As System.Windows.Forms.Button
    Friend WithEvents playSyncButton As System.Windows.Forms.Button
    Friend WithEvents wavFilesGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents browseButton As System.Windows.Forms.Button
    Friend WithEvents soundFileNameTextBox As System.Windows.Forms.TextBox

End Class
