

Partial Public Class SimpleFlowLayout
    Inherits System.Windows.Forms.Form
    '/ <summary>
    '/ Required method for Designer support - do not modify
    '/ the contents of this method with the code editor.
    '/ </summary>
    Private Sub InitializeComponent()
        Me.leftRaftingContainer = New System.Windows.Forms.ToolStripPanel
        Me.leftRaftingContainer1 = New System.Windows.Forms.ToolStripPanel
        Me.topRaftingContainer = New System.Windows.Forms.ToolStripPanel
        Me.bottomRaftingContainer = New System.Windows.Forms.ToolStripPanel
        Me.flowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.label3 = New System.Windows.Forms.Label
        Me.button2 = New System.Windows.Forms.Button
        Me.button1 = New System.Windows.Forms.Button
        Me.textBox2 = New System.Windows.Forms.TextBox
        Me.label2 = New System.Windows.Forms.Label
        Me.textBox1 = New System.Windows.Forms.TextBox
        Me.label1 = New System.Windows.Forms.Label
        Me.groupBox2 = New System.Windows.Forms.GroupBox
        Me.radioVertical = New System.Windows.Forms.RadioButton
        Me.radioHorizontal = New System.Windows.Forms.RadioButton
        Me.panel1 = New System.Windows.Forms.Panel
        Me.button5 = New System.Windows.Forms.Button
        Me.button4 = New System.Windows.Forms.Button
        Me.button3 = New System.Windows.Forms.Button
        Me.button6 = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.flowLayoutPanel1.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        Me.panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'leftRaftingContainer
        '
        Me.leftRaftingContainer.Dock = System.Windows.Forms.DockStyle.Left
        Me.leftRaftingContainer.Location = New System.Drawing.Point(4, 4)
        Me.leftRaftingContainer.Name = "leftRaftingContainer"
        Me.leftRaftingContainer.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.leftRaftingContainer.RowMargin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.leftRaftingContainer.Size = New System.Drawing.Size(0, 287)
        '
        'leftRaftingContainer1
        '
        Me.leftRaftingContainer1.Dock = System.Windows.Forms.DockStyle.Left
        Me.leftRaftingContainer1.Location = New System.Drawing.Point(4, 4)
        Me.leftRaftingContainer1.Name = "leftRaftingContainer1"
        Me.leftRaftingContainer1.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.leftRaftingContainer1.RowMargin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.leftRaftingContainer1.Size = New System.Drawing.Size(0, 287)
        '
        'topRaftingContainer
        '
        Me.topRaftingContainer.Dock = System.Windows.Forms.DockStyle.Top
        Me.topRaftingContainer.Location = New System.Drawing.Point(4, 4)
        Me.topRaftingContainer.Name = "topRaftingContainer"
        Me.topRaftingContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.topRaftingContainer.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.topRaftingContainer.Size = New System.Drawing.Size(231, 0)
        '
        'bottomRaftingContainer
        '
        Me.bottomRaftingContainer.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bottomRaftingContainer.Location = New System.Drawing.Point(4, 291)
        Me.bottomRaftingContainer.Name = "bottomRaftingContainer"
        Me.bottomRaftingContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.bottomRaftingContainer.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.bottomRaftingContainer.Size = New System.Drawing.Size(231, 0)
        '
        'flowLayoutPanel1
        '
        Me.flowLayoutPanel1.Controls.Add(Me.groupBox1)
        Me.flowLayoutPanel1.Controls.Add(Me.groupBox2)
        Me.flowLayoutPanel1.Controls.Add(Me.panel1)
        Me.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flowLayoutPanel1.Location = New System.Drawing.Point(4, 4)
        Me.flowLayoutPanel1.Name = "flowLayoutPanel1"
        Me.flowLayoutPanel1.Size = New System.Drawing.Size(231, 287)
        Me.flowLayoutPanel1.TabIndex = 4
        '
        'groupBox1
        '
        Me.groupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBox1.Controls.Add(Me.Label4)
        Me.groupBox1.Controls.Add(Me.label3)
        Me.groupBox1.Controls.Add(Me.button2)
        Me.groupBox1.Controls.Add(Me.button1)
        Me.groupBox1.Controls.Add(Me.textBox2)
        Me.groupBox1.Controls.Add(Me.label2)
        Me.groupBox1.Controls.Add(Me.textBox1)
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.Location = New System.Drawing.Point(3, 3)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(217, 135)
        Me.groupBox1.TabIndex = 0
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Random Settings"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(42, 92)
        Me.label3.Margin = New System.Windows.Forms.Padding(3, 1, 3, 3)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(0, 13)
        Me.label3.TabIndex = 6
        '
        'button2
        '
        Me.button2.Location = New System.Drawing.Point(124, 64)
        Me.button2.Margin = New System.Windows.Forms.Padding(3, 3, 3, 2)
        Me.button2.Name = "button2"
        Me.button2.Size = New System.Drawing.Size(75, 23)
        Me.button2.TabIndex = 5
        Me.button2.Text = "Cancel"
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(42, 64)
        Me.button1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 3)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(75, 23)
        Me.button1.TabIndex = 4
        Me.button1.Text = "Apply"
        '
        'textBox2
        '
        Me.textBox2.Location = New System.Drawing.Point(52, 38)
        Me.textBox2.Margin = New System.Windows.Forms.Padding(3, 0, 3, 2)
        Me.textBox2.Name = "textBox2"
        Me.textBox2.Size = New System.Drawing.Size(147, 20)
        Me.textBox2.TabIndex = 3
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(10, 41)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(33, 13)
        Me.label2.TabIndex = 2
        Me.label2.Text = "Rank"
        '
        'textBox1
        '
        Me.textBox1.Location = New System.Drawing.Point(52, 17)
        Me.textBox1.Margin = New System.Windows.Forms.Padding(3, 3, 3, 1)
        Me.textBox1.Name = "textBox1"
        Me.textBox1.Size = New System.Drawing.Size(147, 20)
        Me.textBox1.TabIndex = 1
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(10, 20)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(35, 13)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Name"
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.radioVertical)
        Me.groupBox2.Controls.Add(Me.radioHorizontal)
        Me.groupBox2.Location = New System.Drawing.Point(3, 144)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(117, 135)
        Me.groupBox2.TabIndex = 1
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Orientation"
        '
        'radioVertical
        '
        Me.radioVertical.AutoSize = True
        Me.radioVertical.Checked = True
        Me.radioVertical.Location = New System.Drawing.Point(23, 60)
        Me.radioVertical.Name = "radioVertical"
        Me.radioVertical.Size = New System.Drawing.Size(60, 17)
        Me.radioVertical.TabIndex = 1
        Me.radioVertical.Text = "Vertical"
        '
        'radioHorizontal
        '
        Me.radioHorizontal.AutoSize = True
        Me.radioHorizontal.Location = New System.Drawing.Point(23, 29)
        Me.radioHorizontal.Name = "radioHorizontal"
        Me.radioHorizontal.Size = New System.Drawing.Size(72, 17)
        Me.radioHorizontal.TabIndex = 0
        Me.radioHorizontal.TabStop = False
        Me.radioHorizontal.Text = "Horizontal"
        '
        'panel1
        '
        Me.panel1.Controls.Add(Me.button5)
        Me.panel1.Controls.Add(Me.button4)
        Me.panel1.Controls.Add(Me.button3)
        Me.panel1.Controls.Add(Me.button6)
        Me.panel1.Location = New System.Drawing.Point(126, 144)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(97, 135)
        Me.panel1.TabIndex = 2
        '
        'button5
        '
        Me.button5.Location = New System.Drawing.Point(13, 72)
        Me.button5.Name = "button5"
        Me.button5.Size = New System.Drawing.Size(75, 23)
        Me.button5.TabIndex = 2
        Me.button5.Text = "Remove"
        '
        'button4
        '
        Me.button4.Location = New System.Drawing.Point(13, 44)
        Me.button4.Name = "button4"
        Me.button4.Size = New System.Drawing.Size(75, 23)
        Me.button4.TabIndex = 1
        Me.button4.Text = "Edit"
        '
        'button3
        '
        Me.button3.Location = New System.Drawing.Point(13, 14)
        Me.button3.Name = "button3"
        Me.button3.Size = New System.Drawing.Size(75, 23)
        Me.button3.TabIndex = 0
        Me.button3.Text = "New"
        '
        'button6
        '
        Me.button6.Location = New System.Drawing.Point(13, 102)
        Me.button6.Name = "button6"
        Me.button6.Size = New System.Drawing.Size(75, 23)
        Me.button6.TabIndex = 3
        Me.button6.Text = "Reset"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(39, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(128, 26)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Lorem ipsum Lorem ipsum" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Lorem ipsum " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'SimpleFlowLayout
        '
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(239, 295)
        Me.Controls.Add(Me.flowLayoutPanel1)
        Me.Controls.Add(Me.leftRaftingContainer)
        Me.Controls.Add(Me.leftRaftingContainer1)
        Me.Controls.Add(Me.topRaftingContainer)
        Me.Controls.Add(Me.bottomRaftingContainer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SimpleFlowLayout"
        Me.Padding = New System.Windows.Forms.Padding(4)
        Me.Text = "SimpleFlowLayout Sample"
        Me.flowLayoutPanel1.ResumeLayout(False)
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.panel1.ResumeLayout(False)
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
    Friend WithEvents leftRaftingContainer As System.Windows.Forms.ToolStripPanel
    Friend WithEvents leftRaftingContainer1 As System.Windows.Forms.ToolStripPanel
    Friend WithEvents topRaftingContainer As System.Windows.Forms.ToolStripPanel
    Friend WithEvents bottomRaftingContainer As System.Windows.Forms.ToolStripPanel
    Friend WithEvents flowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents button2 As System.Windows.Forms.Button
    Friend WithEvents button1 As System.Windows.Forms.Button
    Friend WithEvents textBox2 As System.Windows.Forms.TextBox
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents textBox1 As System.Windows.Forms.TextBox
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents radioHorizontal As System.Windows.Forms.RadioButton
    Friend WithEvents radioVertical As System.Windows.Forms.RadioButton
    Friend WithEvents panel1 As System.Windows.Forms.Panel
    Friend WithEvents button3 As System.Windows.Forms.Button
    Friend WithEvents button4 As System.Windows.Forms.Button
    Friend WithEvents button5 As System.Windows.Forms.Button
    Friend WithEvents button6 As System.Windows.Forms.Button
    Friend WithEvents label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label 'Dispose
End Class 'Form1
