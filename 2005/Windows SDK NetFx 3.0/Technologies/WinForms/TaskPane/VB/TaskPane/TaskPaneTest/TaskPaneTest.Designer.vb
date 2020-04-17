Public Partial Class TaskPaneTest
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TaskPaneTest))
        Me.testPanel = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.cornerStyleGroup = New System.Windows.Forms.GroupBox
        Me.squaredCornerStyleRadio = New System.Windows.Forms.RadioButton
        Me.roundedCornerStyleRadio = New System.Windows.Forms.RadioButton
        Me.sysDefCornerStyleRadio = New System.Windows.Forms.RadioButton
        Me.dockGroup = New System.Windows.Forms.GroupBox
        Me.rightDockRadio = New System.Windows.Forms.RadioButton
        Me.bottomDockRadio = New System.Windows.Forms.RadioButton
        Me.topDockRadio = New System.Windows.Forms.RadioButton
        Me.leftDockRadio = New System.Windows.Forms.RadioButton
        Me.expandAndCollapseFramesButton = New System.Windows.Forms.Button
        Me.addAndRemoveButton = New System.Windows.Forms.Button
        Me.TaskPane1 = New Microsoft.Samples.Windows.Forms.TaskPane.TaskPane
        Me.TaskFrame0 = New Microsoft.Samples.Windows.Forms.TaskPane.TaskFrame
        Me.TaskFrame1 = New Microsoft.Samples.Windows.Forms.TaskPane.TaskFrame
        Me.TaskFrame2 = New Microsoft.Samples.Windows.Forms.TaskPane.TaskFrame
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.hiddenTaskFrame = New Microsoft.Samples.Windows.Forms.TaskPane.TaskFrame
        Me.testPanel.SuspendLayout()
        Me.cornerStyleGroup.SuspendLayout()
        Me.dockGroup.SuspendLayout()
        Me.TaskPane1.SuspendLayout()
        Me.TaskFrame2.SuspendLayout()
        Me.SuspendLayout()
        '
        'testPanel
        '
        Me.testPanel.Controls.Add(Me.Label1)
        Me.testPanel.Controls.Add(Me.cornerStyleGroup)
        Me.testPanel.Controls.Add(Me.dockGroup)
        Me.testPanel.Controls.Add(Me.expandAndCollapseFramesButton)
        Me.testPanel.Controls.Add(Me.addAndRemoveButton)
        Me.testPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.testPanel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.testPanel.Location = New System.Drawing.Point(224, 0)
        Me.testPanel.Name = "testPanel"
        Me.testPanel.Size = New System.Drawing.Size(342, 440)
        Me.testPanel.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 204)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(301, 156)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = resources.GetString("Label1.Text")
        '
        'cornerStyleGroup
        '
        Me.cornerStyleGroup.Controls.Add(Me.squaredCornerStyleRadio)
        Me.cornerStyleGroup.Controls.Add(Me.roundedCornerStyleRadio)
        Me.cornerStyleGroup.Controls.Add(Me.sysDefCornerStyleRadio)
        Me.cornerStyleGroup.Location = New System.Drawing.Point(12, 13)
        Me.cornerStyleGroup.Name = "cornerStyleGroup"
        Me.cornerStyleGroup.Size = New System.Drawing.Size(135, 92)
        Me.cornerStyleGroup.TabIndex = 0
        Me.cornerStyleGroup.TabStop = False
        Me.cornerStyleGroup.Text = "Corner Style"
        '
        'squaredCornerStyleRadio
        '
        Me.squaredCornerStyleRadio.AutoSize = True
        Me.squaredCornerStyleRadio.Location = New System.Drawing.Point(7, 68)
        Me.squaredCornerStyleRadio.Name = "squaredCornerStyleRadio"
        Me.squaredCornerStyleRadio.Size = New System.Drawing.Size(65, 17)
        Me.squaredCornerStyleRadio.TabIndex = 2
        Me.squaredCornerStyleRadio.Text = "S&quared"
        '
        'roundedCornerStyleRadio
        '
        Me.roundedCornerStyleRadio.AutoSize = True
        Me.roundedCornerStyleRadio.Location = New System.Drawing.Point(7, 44)
        Me.roundedCornerStyleRadio.Name = "roundedCornerStyleRadio"
        Me.roundedCornerStyleRadio.Size = New System.Drawing.Size(69, 17)
        Me.roundedCornerStyleRadio.TabIndex = 1
        Me.roundedCornerStyleRadio.Text = "Rou&nded"
        '
        'sysDefCornerStyleRadio
        '
        Me.sysDefCornerStyleRadio.AutoSize = True
        Me.sysDefCornerStyleRadio.Checked = True
        Me.sysDefCornerStyleRadio.Location = New System.Drawing.Point(7, 20)
        Me.sysDefCornerStyleRadio.Name = "sysDefCornerStyleRadio"
        Me.sysDefCornerStyleRadio.Size = New System.Drawing.Size(96, 17)
        Me.sysDefCornerStyleRadio.TabIndex = 0
        Me.sysDefCornerStyleRadio.Text = "&System Default"
        '
        'dockGroup
        '
        Me.dockGroup.Controls.Add(Me.rightDockRadio)
        Me.dockGroup.Controls.Add(Me.bottomDockRadio)
        Me.dockGroup.Controls.Add(Me.topDockRadio)
        Me.dockGroup.Controls.Add(Me.leftDockRadio)
        Me.dockGroup.Location = New System.Drawing.Point(162, 15)
        Me.dockGroup.Name = "dockGroup"
        Me.dockGroup.Size = New System.Drawing.Size(167, 90)
        Me.dockGroup.TabIndex = 1
        Me.dockGroup.TabStop = False
        Me.dockGroup.Text = "Dock"
        '
        'rightDockRadio
        '
        Me.rightDockRadio.AutoSize = True
        Me.rightDockRadio.Location = New System.Drawing.Point(86, 20)
        Me.rightDockRadio.Name = "rightDockRadio"
        Me.rightDockRadio.Size = New System.Drawing.Size(50, 17)
        Me.rightDockRadio.TabIndex = 1
        Me.rightDockRadio.Text = "&Right"
        '
        'bottomDockRadio
        '
        Me.bottomDockRadio.AutoSize = True
        Me.bottomDockRadio.Location = New System.Drawing.Point(86, 44)
        Me.bottomDockRadio.Name = "bottomDockRadio"
        Me.bottomDockRadio.Size = New System.Drawing.Size(58, 17)
        Me.bottomDockRadio.TabIndex = 3
        Me.bottomDockRadio.Text = "&Bottom"
        '
        'topDockRadio
        '
        Me.topDockRadio.AutoSize = True
        Me.topDockRadio.Location = New System.Drawing.Point(7, 44)
        Me.topDockRadio.Name = "topDockRadio"
        Me.topDockRadio.Size = New System.Drawing.Size(44, 17)
        Me.topDockRadio.TabIndex = 2
        Me.topDockRadio.Text = "To&p"
        '
        'leftDockRadio
        '
        Me.leftDockRadio.AutoSize = True
        Me.leftDockRadio.Checked = True
        Me.leftDockRadio.Location = New System.Drawing.Point(7, 20)
        Me.leftDockRadio.Name = "leftDockRadio"
        Me.leftDockRadio.Size = New System.Drawing.Size(43, 17)
        Me.leftDockRadio.TabIndex = 0
        Me.leftDockRadio.Text = "&Left"
        '
        'expandAndCollapseFramesButton
        '
        Me.expandAndCollapseFramesButton.Location = New System.Drawing.Point(48, 150)
        Me.expandAndCollapseFramesButton.Name = "expandAndCollapseFramesButton"
        Me.expandAndCollapseFramesButton.Size = New System.Drawing.Size(232, 29)
        Me.expandAndCollapseFramesButton.TabIndex = 3
        Me.expandAndCollapseFramesButton.Text = "E&xpand and Collapse Frames"
        '
        'addAndRemoveButton
        '
        Me.addAndRemoveButton.Location = New System.Drawing.Point(48, 115)
        Me.addAndRemoveButton.Margin = New System.Windows.Forms.Padding(3, 2, 3, 3)
        Me.addAndRemoveButton.Name = "addAndRemoveButton"
        Me.addAndRemoveButton.Size = New System.Drawing.Size(232, 29)
        Me.addAndRemoveButton.TabIndex = 2
        Me.addAndRemoveButton.Text = "A&dd, Remove and Reorder Frames"
        '
        'TaskPane1
        '
        Me.TaskPane1.AutoScroll = True
        Me.TaskPane1.AutoScrollMinSize = New System.Drawing.Size(0, 584)
        Me.TaskPane1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.TaskPane1.Controls.Add(Me.TaskFrame0)
        Me.TaskPane1.Controls.Add(Me.TaskFrame1)
        Me.TaskPane1.Controls.Add(Me.TaskFrame2)
        Me.TaskPane1.Controls.Add(Me.hiddenTaskFrame)
        Me.TaskPane1.CornerStyle = Microsoft.Samples.Windows.Forms.TaskPane.TaskFrameCornerStyle.SystemDefault
        Me.TaskPane1.Dock = System.Windows.Forms.DockStyle.Left
        Me.TaskPane1.Location = New System.Drawing.Point(0, 0)
        Me.TaskPane1.Name = "TaskPane1"
        Me.TaskPane1.Size = New System.Drawing.Size(224, 440)
        Me.TaskPane1.TabIndex = 0
        '
        'TaskFrame0
        '
        Me.TaskFrame0.AllowDrop = True
        Me.TaskFrame0.BackColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TaskFrame0.CaptionBlend = New Microsoft.Samples.Windows.Forms.TaskPane.BlendFill(Microsoft.Samples.Windows.Forms.TaskPane.BlendStyle.Horizontal, System.Drawing.Color.White, System.Drawing.Color.FromArgb(CType(CType(140, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(230, Byte), Integer)))
        Me.TaskFrame0.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TaskFrame0.ForeColor = System.Drawing.Color.FromArgb(CType(CType(113, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.TaskFrame0.Location = New System.Drawing.Point(12, 33)
        Me.TaskFrame0.Name = "TaskFrame0"
        Me.TaskFrame0.Size = New System.Drawing.Size(182, 100)
        Me.TaskFrame0.TabIndex = 0
        Me.TaskFrame0.Text = "First TaskFrame!"
        '
        'TaskFrame1
        '
        Me.TaskFrame1.AllowDrop = True
        Me.TaskFrame1.BackColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TaskFrame1.CaptionBlend = New Microsoft.Samples.Windows.Forms.TaskPane.BlendFill(Microsoft.Samples.Windows.Forms.TaskPane.BlendStyle.Horizontal, System.Drawing.Color.White, System.Drawing.Color.FromArgb(CType(CType(140, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(230, Byte), Integer)))
        Me.TaskFrame1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TaskFrame1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(113, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.TaskFrame1.Location = New System.Drawing.Point(12, 166)
        Me.TaskFrame1.Name = "TaskFrame1"
        Me.TaskFrame1.Size = New System.Drawing.Size(182, 40)
        Me.TaskFrame1.TabIndex = 1
        Me.TaskFrame1.Text = "TaskFrame1"
        '
        'TaskFrame2
        '
        Me.TaskFrame2.AllowDrop = True
        Me.TaskFrame2.BackColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TaskFrame2.CaptionBlend = New Microsoft.Samples.Windows.Forms.TaskPane.BlendFill(Microsoft.Samples.Windows.Forms.TaskPane.BlendStyle.Horizontal, System.Drawing.Color.White, System.Drawing.Color.FromArgb(CType(CType(140, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(230, Byte), Integer)))
        Me.TaskFrame2.Controls.Add(Me.LinkLabel4)
        Me.TaskFrame2.Controls.Add(Me.LinkLabel3)
        Me.TaskFrame2.Controls.Add(Me.LinkLabel2)
        Me.TaskFrame2.Controls.Add(Me.LinkLabel1)
        Me.TaskFrame2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TaskFrame2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(113, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.TaskFrame2.IsExpanded = False
        Me.TaskFrame2.Location = New System.Drawing.Point(12, 239)
        Me.TaskFrame2.Name = "TaskFrame2"
        Me.TaskFrame2.Size = New System.Drawing.Size(182, 200)
        Me.TaskFrame2.TabIndex = 2
        Me.TaskFrame2.Text = "TaskFrame2"
        '
        'LinkLabel4
        '
        Me.LinkLabel4.AutoSize = True
        Me.LinkLabel4.Location = New System.Drawing.Point(21, 81)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(88, 13)
        Me.LinkLabel4.TabIndex = 3
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Text = "Manage Users"
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.Location = New System.Drawing.Point(21, 60)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(92, 13)
        Me.LinkLabel3.TabIndex = 2
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "Show All Users"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Location = New System.Drawing.Point(21, 39)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(83, 13)
        Me.LinkLabel2.TabIndex = 1
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Remove User"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(21, 18)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(132, 13)
        Me.LinkLabel1.TabIndex = 0
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Useless Links Abound"
        '
        'hiddenTaskFrame
        '
        Me.hiddenTaskFrame.AllowDrop = True
        Me.hiddenTaskFrame.BackColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.hiddenTaskFrame.CaptionBlend = New Microsoft.Samples.Windows.Forms.TaskPane.BlendFill(Microsoft.Samples.Windows.Forms.TaskPane.BlendStyle.Horizontal, System.Drawing.Color.White, System.Drawing.Color.FromArgb(CType(CType(140, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(230, Byte), Integer)))
        Me.hiddenTaskFrame.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.hiddenTaskFrame.ForeColor = System.Drawing.Color.FromArgb(CType(CType(113, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.hiddenTaskFrame.Location = New System.Drawing.Point(12, 472)
        Me.hiddenTaskFrame.Name = "TaskFrame3"
        Me.hiddenTaskFrame.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.hiddenTaskFrame.Size = New System.Drawing.Size(182, 100)
        Me.hiddenTaskFrame.TabIndex = 5
        Me.hiddenTaskFrame.Text = "Surprise!"
        Me.hiddenTaskFrame.Visible = False
        '
        'TaskPaneTest
        '
        Me.ClientSize = New System.Drawing.Size(566, 440)
        Me.Controls.Add(Me.testPanel)
        Me.Controls.Add(Me.TaskPane1)
        Me.Name = "TaskPaneTest"
        Me.Text = "TaskPaneTest"
        Me.testPanel.ResumeLayout(False)
        Me.testPanel.PerformLayout()
        Me.cornerStyleGroup.ResumeLayout(False)
        Me.cornerStyleGroup.PerformLayout()
        Me.dockGroup.ResumeLayout(False)
        Me.dockGroup.PerformLayout()
        Me.TaskPane1.ResumeLayout(False)
        Me.TaskFrame2.ResumeLayout(False)
        Me.TaskFrame2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents testPanel As System.Windows.Forms.Panel
    Friend WithEvents dockGroup As System.Windows.Forms.GroupBox
    Friend WithEvents cornerStyleGroup As System.Windows.Forms.GroupBox
    Friend WithEvents squaredCornerStyleRadio As System.Windows.Forms.RadioButton
    Friend WithEvents roundedCornerStyleRadio As System.Windows.Forms.RadioButton
    Friend WithEvents sysDefCornerStyleRadio As System.Windows.Forms.RadioButton
    Friend WithEvents expandAndCollapseFramesButton As System.Windows.Forms.Button
    Friend WithEvents addAndRemoveButton As System.Windows.Forms.Button
    Friend WithEvents topDockRadio As System.Windows.Forms.RadioButton
    Friend WithEvents leftDockRadio As System.Windows.Forms.RadioButton
    Friend WithEvents rightDockRadio As System.Windows.Forms.RadioButton
    Friend WithEvents bottomDockRadio As System.Windows.Forms.RadioButton
    Friend WithEvents TaskPane1 As Microsoft.Samples.Windows.Forms.TaskPane.TaskPane
    Friend WithEvents TaskFrame0 As Microsoft.Samples.Windows.Forms.TaskPane.TaskFrame
    Friend WithEvents TaskFrame1 As Microsoft.Samples.Windows.Forms.TaskPane.TaskFrame
    Friend WithEvents TaskFrame2 As Microsoft.Samples.Windows.Forms.TaskPane.TaskFrame
    Friend WithEvents LinkLabel4 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel3 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents hiddenTaskFrame As Microsoft.Samples.Windows.Forms.TaskPane.TaskFrame
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
