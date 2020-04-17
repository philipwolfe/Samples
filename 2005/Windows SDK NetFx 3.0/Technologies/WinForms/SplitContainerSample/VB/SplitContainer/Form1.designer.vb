

Partial Class Form1
    Inherits System.Windows.Forms.Form

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.splitContainer1 = New System.Windows.Forms.SplitContainer
        Me.pictureBox1 = New System.Windows.Forms.PictureBox
        Me.Panel2Collapsed = New System.Windows.Forms.CheckBox
        Me.Panel1Collapsed = New System.Windows.Forms.CheckBox
        Me.label2 = New System.Windows.Forms.Label
        Me.Panel2MinSize = New System.Windows.Forms.TextBox
        Me.label1 = New System.Windows.Forms.Label
        Me.Panel1MinSize = New System.Windows.Forms.TextBox
        Me.OrientationButton = New System.Windows.Forms.Button
        Me.OrientationLabel = New System.Windows.Forms.Label
        Me.SplitterDistanceLabel = New System.Windows.Forms.Label
        Me.SplitterWidthLabel = New System.Windows.Forms.Label
        Me.SplitterIncrementLabel = New System.Windows.Forms.Label
        Me.SplitterIncrement = New System.Windows.Forms.TextBox
        Me.SplitterDistance = New System.Windows.Forms.TextBox
        Me.SplitterWidth = New System.Windows.Forms.TextBox
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.RestorePanel2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.splitContainer1.Panel1.SuspendLayout()
        Me.splitContainer1.Panel2.SuspendLayout()
        Me.splitContainer1.SuspendLayout()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'splitContainer1
        '
        Me.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        resources.ApplyResources(Me.splitContainer1, "splitContainer1")
        Me.splitContainer1.Name = "splitContainer1"
        '
        'splitContainer1.Panel1
        '
        Me.splitContainer1.Panel1.Controls.Add(Me.pictureBox1)
        '
        'splitContainer1.Panel2
        '
        resources.ApplyResources(Me.splitContainer1.Panel2, "splitContainer1.Panel2")
        Me.splitContainer1.Panel2.Controls.Add(Me.Panel2Collapsed)
        Me.splitContainer1.Panel2.Controls.Add(Me.Panel1Collapsed)
        Me.splitContainer1.Panel2.Controls.Add(Me.label2)
        Me.splitContainer1.Panel2.Controls.Add(Me.Panel2MinSize)
        Me.splitContainer1.Panel2.Controls.Add(Me.label1)
        Me.splitContainer1.Panel2.Controls.Add(Me.Panel1MinSize)
        Me.splitContainer1.Panel2.Controls.Add(Me.OrientationButton)
        Me.splitContainer1.Panel2.Controls.Add(Me.OrientationLabel)
        Me.splitContainer1.Panel2.Controls.Add(Me.SplitterDistanceLabel)
        Me.splitContainer1.Panel2.Controls.Add(Me.SplitterWidthLabel)
        Me.splitContainer1.Panel2.Controls.Add(Me.SplitterIncrementLabel)
        Me.splitContainer1.Panel2.Controls.Add(Me.SplitterIncrement)
        Me.splitContainer1.Panel2.Controls.Add(Me.SplitterDistance)
        Me.splitContainer1.Panel2.Controls.Add(Me.SplitterWidth)
        '
        'pictureBox1
        '
        Me.pictureBox1.BackgroundImage = Global.Microsoft.Samples.Windows.Forms.SplitContainer.My.Resources.MyResources.Blue_hills
        resources.ApplyResources(Me.pictureBox1, "pictureBox1")
        Me.pictureBox1.Name = "pictureBox1"
        Me.pictureBox1.TabStop = False
        '
        'Panel2Collapsed
        '
        resources.ApplyResources(Me.Panel2Collapsed, "Panel2Collapsed")
        Me.Panel2Collapsed.Name = "Panel2Collapsed"
        '
        'Panel1Collapsed
        '
        resources.ApplyResources(Me.Panel1Collapsed, "Panel1Collapsed")
        Me.Panel1Collapsed.Name = "Panel1Collapsed"
        '
        'label2
        '
        resources.ApplyResources(Me.label2, "label2")
        Me.label2.Name = "label2"
        '
        'Panel2MinSize
        '
        resources.ApplyResources(Me.Panel2MinSize, "Panel2MinSize")
        Me.Panel2MinSize.Name = "Panel2MinSize"
        '
        'label1
        '
        resources.ApplyResources(Me.label1, "label1")
        Me.label1.Name = "label1"
        '
        'Panel1MinSize
        '
        resources.ApplyResources(Me.Panel1MinSize, "Panel1MinSize")
        Me.Panel1MinSize.Name = "Panel1MinSize"
        '
        'OrientationButton
        '
        resources.ApplyResources(Me.OrientationButton, "OrientationButton")
        Me.OrientationButton.Name = "OrientationButton"
        '
        'OrientationLabel
        '
        resources.ApplyResources(Me.OrientationLabel, "OrientationLabel")
        Me.OrientationLabel.Name = "OrientationLabel"
        '
        'SplitterDistanceLabel
        '
        resources.ApplyResources(Me.SplitterDistanceLabel, "SplitterDistanceLabel")
        Me.SplitterDistanceLabel.Name = "SplitterDistanceLabel"
        '
        'SplitterWidthLabel
        '
        resources.ApplyResources(Me.SplitterWidthLabel, "SplitterWidthLabel")
        Me.SplitterWidthLabel.Name = "SplitterWidthLabel"
        '
        'SplitterIncrementLabel
        '
        resources.ApplyResources(Me.SplitterIncrementLabel, "SplitterIncrementLabel")
        Me.SplitterIncrementLabel.Name = "SplitterIncrementLabel"
        '
        'SplitterIncrement
        '
        resources.ApplyResources(Me.SplitterIncrement, "SplitterIncrement")
        Me.SplitterIncrement.Name = "SplitterIncrement"
        '
        'SplitterDistance
        '
        resources.ApplyResources(Me.SplitterDistance, "SplitterDistance")
        Me.SplitterDistance.Name = "SplitterDistance"
        Me.SplitterDistance.ReadOnly = True
        '
        'SplitterWidth
        '
        resources.ApplyResources(Me.SplitterWidth, "SplitterWidth")
        Me.SplitterWidth.Name = "SplitterWidth"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RestorePanel2ToolStripMenuItem})
        resources.ApplyResources(Me.MenuStrip1, "MenuStrip1")
        Me.MenuStrip1.Name = "MenuStrip1"
        '
        'RestorePanel2ToolStripMenuItem
        '
        Me.RestorePanel2ToolStripMenuItem.Name = "RestorePanel2ToolStripMenuItem"
        resources.ApplyResources(Me.RestorePanel2ToolStripMenuItem, "RestorePanel2ToolStripMenuItem")
        '
        'Form1
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.splitContainer1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.splitContainer1.Panel1.ResumeLayout(False)
        Me.splitContainer1.Panel2.ResumeLayout(False)
        Me.splitContainer1.Panel2.PerformLayout()
        Me.splitContainer1.ResumeLayout(False)
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub 'InitializeComponent


    '/ <summary>
    '/ Clean up any resources being used.
    '/ </summary>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)

    End Sub
    Friend WithEvents splitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents pictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Panel2Collapsed As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1Collapsed As System.Windows.Forms.CheckBox
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents Panel2MinSize As System.Windows.Forms.TextBox
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1MinSize As System.Windows.Forms.TextBox
    Friend WithEvents OrientationButton As System.Windows.Forms.Button
    Friend WithEvents OrientationLabel As System.Windows.Forms.Label
    Friend WithEvents SplitterDistanceLabel As System.Windows.Forms.Label
    Friend WithEvents SplitterWidthLabel As System.Windows.Forms.Label
    Friend WithEvents SplitterIncrementLabel As System.Windows.Forms.Label
    Friend WithEvents SplitterIncrement As System.Windows.Forms.TextBox
    Friend WithEvents SplitterDistance As System.Windows.Forms.TextBox
    Friend WithEvents SplitterWidth As System.Windows.Forms.TextBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents RestorePanel2ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem 'Dispose

End Class 'Form1
