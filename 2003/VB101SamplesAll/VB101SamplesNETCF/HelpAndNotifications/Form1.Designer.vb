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
        Me.HelpContextMenu = New System.Windows.Forms.ContextMenu
        Me.HelpMenuItem = New System.Windows.Forms.MenuItem
        Me.HelpNotification = New Microsoft.WindowsCE.Forms.Notification
        Me.StartTimerButton = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.SecondsLabel = New System.Windows.Forms.Label
        Me.NotificationTimer = New System.Windows.Forms.Timer
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.StatusBar1 = New System.Windows.Forms.StatusBar
        Me.TimerIntervalTrackBar = New System.Windows.Forms.TrackBar
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.DescriptionLabel = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'HelpContextMenu
        '
        Me.HelpContextMenu.MenuItems.Add(Me.HelpMenuItem)
        '
        'HelpMenuItem
        '
        Me.HelpMenuItem.Text = "Help"
        '
        'HelpNotification
        '
        Me.HelpNotification.Text = "Help"
        '
        'StartTimerButton
        '
        Me.StartTimerButton.Location = New System.Drawing.Point(191, 24)
        Me.StartTimerButton.Name = "StartTimerButton"
        Me.StartTimerButton.Size = New System.Drawing.Size(46, 20)
        Me.StartTimerButton.TabIndex = 2
        Me.StartTimerButton.Text = "Start"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label1.ContextMenu = Me.HelpContextMenu
        Me.Label1.Location = New System.Drawing.Point(3, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 20)
        Me.Label1.Text = "Timer:"
        '
        'SecondsLabel
        '
        Me.SecondsLabel.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.SecondsLabel.Location = New System.Drawing.Point(160, 25)
        Me.SecondsLabel.Name = "SecondsLabel"
        Me.SecondsLabel.Size = New System.Drawing.Size(25, 20)
        Me.SecondsLabel.Text = "1 s"
        '
        'NotificationTimer
        '
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ProgressBar1.Location = New System.Drawing.Point(0, 274)
        Me.ProgressBar1.Maximum = 10
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(240, 20)
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 252)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Size = New System.Drawing.Size(240, 22)
        Me.StatusBar1.Text = "StatusBar1"
        '
        'TimerIntervalTrackBar
        '
        Me.TimerIntervalTrackBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TimerIntervalTrackBar.ContextMenu = Me.HelpContextMenu
        Me.TimerIntervalTrackBar.LargeChange = 1
        Me.TimerIntervalTrackBar.Location = New System.Drawing.Point(43, 23)
        Me.TimerIntervalTrackBar.Maximum = 5
        Me.TimerIntervalTrackBar.Minimum = 1
        Me.TimerIntervalTrackBar.Name = "TimerIntervalTrackBar"
        Me.TimerIntervalTrackBar.Size = New System.Drawing.Size(111, 21)
        Me.TimerIntervalTrackBar.TabIndex = 1
        Me.TimerIntervalTrackBar.Value = 1
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(3, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(172, 20)
        Me.Label2.Text = "Notification Timer Interval"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.StartTimerButton)
        Me.Panel1.Controls.Add(Me.TimerIntervalTrackBar)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.SecondsLabel)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 195)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(240, 57)
        '
        'DescriptionLabel
        '
        Me.DescriptionLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DescriptionLabel.Location = New System.Drawing.Point(0, 0)
        Me.DescriptionLabel.Name = "DescriptionLabel"
        Me.DescriptionLabel.Size = New System.Drawing.Size(240, 195)
        Me.DescriptionLabel.Text = "This sample demonstrates both Help features and Notification features."
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(240, 294)
        Me.Controls.Add(Me.DescriptionLabel)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents HelpNotification As Microsoft.WindowsCE.Forms.Notification
    Friend WithEvents StartTimerButton As System.Windows.Forms.Button
    Friend WithEvents HelpContextMenu As System.Windows.Forms.ContextMenu
    Friend WithEvents HelpMenuItem As System.Windows.Forms.MenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SecondsLabel As System.Windows.Forms.Label
    Friend WithEvents NotificationTimer As System.Windows.Forms.Timer
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents TimerIntervalTrackBar As System.Windows.Forms.TrackBar
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DescriptionLabel As System.Windows.Forms.Label

End Class
