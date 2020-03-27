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
        Me.updateLinkLabel = New System.Windows.Forms.LinkLabel
        Me.label4 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.timeOfLastCheckLabel = New System.Windows.Forms.Label
        Me.versionLabel = New System.Windows.Forms.Label
        Me.checkForUpdatesLinkLabel = New System.Windows.Forms.LinkLabel
        Me.label1 = New System.Windows.Forms.Label
        Me.asyncCheckForUpdatesLinkLabel = New System.Windows.Forms.LinkLabel
        Me.stopAsyncCheckLinkLabel = New System.Windows.Forms.LinkLabel
        Me.asyncCheckStatusLabel = New System.Windows.Forms.Label
        Me.updateAsyncLinkLabel = New System.Windows.Forms.LinkLabel
        Me.stopAsyncUpdateLinkLabel = New System.Windows.Forms.LinkLabel
        Me.asyncUpdateStatusLabel = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'updateLinkLabel
        '
        Me.updateLinkLabel.AutoSize = True
        Me.updateLinkLabel.Location = New System.Drawing.Point(12, 159)
        Me.updateLinkLabel.Name = "updateLinkLabel"
        Me.updateLinkLabel.Size = New System.Drawing.Size(63, 13)
        Me.updateLinkLabel.TabIndex = 37
        Me.updateLinkLabel.TabStop = True
        Me.updateLinkLabel.Text = "Update Now"
        '
        'label4
        '
        Me.label4.Location = New System.Drawing.Point(167, 200)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(352, 39)
        Me.label4.TabIndex = 36
        Me.label4.Text = "Update the application in the background.  Click the Stop button to stop the upda" & _
            "te.  Application will require restart to see the new version."
        '
        'label3
        '
        Me.label3.Location = New System.Drawing.Point(167, 159)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(352, 29)
        Me.label3.TabIndex = 35
        Me.label3.Text = "Stop application use and update the application.  Application will require restar" & _
            "t to see the new version."
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(167, 106)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(352, 34)
        Me.label2.TabIndex = 34
        Me.label2.Text = "Check for updates in the background.  Click the Stop button to stop the check."
        '
        'timeOfLastCheckLabel
        '
        Me.timeOfLastCheckLabel.AutoSize = True
        Me.timeOfLastCheckLabel.Location = New System.Drawing.Point(12, 30)
        Me.timeOfLastCheckLabel.Name = "timeOfLastCheckLabel"
        Me.timeOfLastCheckLabel.Size = New System.Drawing.Size(125, 13)
        Me.timeOfLastCheckLabel.TabIndex = 33
        Me.timeOfLastCheckLabel.Text = "Last checked for update: "
        '
        'versionLabel
        '
        Me.versionLabel.AutoSize = True
        Me.versionLabel.Location = New System.Drawing.Point(12, 9)
        Me.versionLabel.Name = "versionLabel"
        Me.versionLabel.Size = New System.Drawing.Size(41, 13)
        Me.versionLabel.TabIndex = 32
        Me.versionLabel.Text = "Version:"
        '
        'checkForUpdatesLinkLabel
        '
        Me.checkForUpdatesLinkLabel.AutoSize = True
        Me.checkForUpdatesLinkLabel.Location = New System.Drawing.Point(11, 58)
        Me.checkForUpdatesLinkLabel.Name = "checkForUpdatesLinkLabel"
        Me.checkForUpdatesLinkLabel.Size = New System.Drawing.Size(92, 13)
        Me.checkForUpdatesLinkLabel.TabIndex = 24
        Me.checkForUpdatesLinkLabel.TabStop = True
        Me.checkForUpdatesLinkLabel.Text = "Check for Updates"
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(167, 58)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(352, 30)
        Me.label1.TabIndex = 25
        Me.label1.Text = "Synchronously check for updates.  The application will be frozen during this oper" & _
            "ation."
        '
        'asyncCheckForUpdatesLinkLabel
        '
        Me.asyncCheckForUpdatesLinkLabel.AutoSize = True
        Me.asyncCheckForUpdatesLinkLabel.Location = New System.Drawing.Point(11, 106)
        Me.asyncCheckForUpdatesLinkLabel.Name = "asyncCheckForUpdatesLinkLabel"
        Me.asyncCheckForUpdatesLinkLabel.Size = New System.Drawing.Size(130, 13)
        Me.asyncCheckForUpdatesLinkLabel.TabIndex = 26
        Me.asyncCheckForUpdatesLinkLabel.TabStop = True
        Me.asyncCheckForUpdatesLinkLabel.Text = "Check for Updates (Async)"
        '
        'stopAsyncCheckLinkLabel
        '
        Me.stopAsyncCheckLinkLabel.AutoSize = True
        Me.stopAsyncCheckLinkLabel.Location = New System.Drawing.Point(31, 126)
        Me.stopAsyncCheckLinkLabel.Name = "stopAsyncCheckLinkLabel"
        Me.stopAsyncCheckLinkLabel.Size = New System.Drawing.Size(25, 13)
        Me.stopAsyncCheckLinkLabel.TabIndex = 27
        Me.stopAsyncCheckLinkLabel.TabStop = True
        Me.stopAsyncCheckLinkLabel.Text = "Stop"
        '
        'asyncCheckStatusLabel
        '
        Me.asyncCheckStatusLabel.AutoSize = True
        Me.asyncCheckStatusLabel.Location = New System.Drawing.Point(64, 126)
        Me.asyncCheckStatusLabel.Name = "asyncCheckStatusLabel"
        Me.asyncCheckStatusLabel.Size = New System.Drawing.Size(33, 13)
        Me.asyncCheckStatusLabel.TabIndex = 28
        Me.asyncCheckStatusLabel.Text = "Status"
        '
        'updateAsyncLinkLabel
        '
        Me.updateAsyncLinkLabel.AutoSize = True
        Me.updateAsyncLinkLabel.Location = New System.Drawing.Point(11, 200)
        Me.updateAsyncLinkLabel.Name = "updateAsyncLinkLabel"
        Me.updateAsyncLinkLabel.Size = New System.Drawing.Size(76, 13)
        Me.updateAsyncLinkLabel.TabIndex = 29
        Me.updateAsyncLinkLabel.TabStop = True
        Me.updateAsyncLinkLabel.Text = "Update (Async)"
        '
        'stopAsyncUpdateLinkLabel
        '
        Me.stopAsyncUpdateLinkLabel.AutoSize = True
        Me.stopAsyncUpdateLinkLabel.Location = New System.Drawing.Point(31, 220)
        Me.stopAsyncUpdateLinkLabel.Name = "stopAsyncUpdateLinkLabel"
        Me.stopAsyncUpdateLinkLabel.Size = New System.Drawing.Size(25, 13)
        Me.stopAsyncUpdateLinkLabel.TabIndex = 30
        Me.stopAsyncUpdateLinkLabel.TabStop = True
        Me.stopAsyncUpdateLinkLabel.Text = "Stop"
        '
        'asyncUpdateStatusLabel
        '
        Me.asyncUpdateStatusLabel.AutoSize = True
        Me.asyncUpdateStatusLabel.Location = New System.Drawing.Point(64, 220)
        Me.asyncUpdateStatusLabel.Name = "asyncUpdateStatusLabel"
        Me.asyncUpdateStatusLabel.Size = New System.Drawing.Size(33, 13)
        Me.asyncUpdateStatusLabel.TabIndex = 31
        Me.asyncUpdateStatusLabel.Text = "Status"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(542, 416)
        Me.Controls.Add(Me.updateLinkLabel)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.timeOfLastCheckLabel)
        Me.Controls.Add(Me.versionLabel)
        Me.Controls.Add(Me.checkForUpdatesLinkLabel)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.asyncCheckForUpdatesLinkLabel)
        Me.Controls.Add(Me.stopAsyncCheckLinkLabel)
        Me.Controls.Add(Me.asyncCheckStatusLabel)
        Me.Controls.Add(Me.updateAsyncLinkLabel)
        Me.Controls.Add(Me.stopAsyncUpdateLinkLabel)
        Me.Controls.Add(Me.asyncUpdateStatusLabel)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Using ClickOnce"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents updateLinkLabel As System.Windows.Forms.LinkLabel
    Friend WithEvents label4 As System.Windows.Forms.Label
    Friend WithEvents label3 As System.Windows.Forms.Label
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents timeOfLastCheckLabel As System.Windows.Forms.Label
    Friend WithEvents versionLabel As System.Windows.Forms.Label
    Friend WithEvents checkForUpdatesLinkLabel As System.Windows.Forms.LinkLabel
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents asyncCheckForUpdatesLinkLabel As System.Windows.Forms.LinkLabel
    Friend WithEvents stopAsyncCheckLinkLabel As System.Windows.Forms.LinkLabel
    Friend WithEvents asyncCheckStatusLabel As System.Windows.Forms.Label
    Friend WithEvents updateAsyncLinkLabel As System.Windows.Forms.LinkLabel
    Friend WithEvents stopAsyncUpdateLinkLabel As System.Windows.Forms.LinkLabel
    Friend WithEvents asyncUpdateStatusLabel As System.Windows.Forms.Label

End Class
