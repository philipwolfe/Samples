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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.computerNameLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.userNameLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.blankSpacerLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.clockLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.DirectorySearcher1 = New System.DirectoryServices.DirectorySearcher
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.refreshFormsListButton = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.openFormsListBox = New System.Windows.Forms.ListBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.form3Button = New System.Windows.Forms.Button
        Me.form2Button = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.stringResource1TextBox = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.appSetting2TextBox = New System.Windows.Forms.TextBox
        Me.appSetting1TextBox = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Computer = New System.Windows.Forms.Label
        Me.computerInfoPropertyGrid = New System.Windows.Forms.PropertyGrid
        Me.playSoundButton = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.soundsComboBox = New System.Windows.Forms.ComboBox
        Me.drivesDataGridView = New System.Windows.Forms.DataGridView
        Me.Label5 = New System.Windows.Forms.Label
        Me.currentDirTextBox = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.StatusStrip1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.drivesDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.computerNameLabel, Me.userNameLabel, Me.blankSpacerLabel, Me.clockLabel})
        Me.StatusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 393)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(542, 23)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'computerNameLabel
        '
        Me.computerNameLabel.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.computerNameLabel.Name = "computerNameLabel"
        Me.computerNameLabel.Text = "ComputerName"
        '
        'userNameLabel
        '
        Me.userNameLabel.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.userNameLabel.Name = "userNameLabel"
        Me.userNameLabel.Text = "UserName"
        '
        'blankSpacerLabel
        '
        Me.blankSpacerLabel.Name = "blankSpacerLabel"
        Me.blankSpacerLabel.Spring = True
        '
        'clockLabel
        '
        Me.clockLabel.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.clockLabel.Name = "clockLabel"
        Me.clockLabel.Text = "Clock"
        '
        'DirectorySearcher1
        '
        Me.DirectorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01")
        Me.DirectorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01")
        Me.DirectorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01")
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox2)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox5)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox4)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox3)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox1)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(542, 393)
        Me.FlowLayoutPanel1.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.refreshFormsListButton)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.openFormsListBox)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(200, 122)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "My.Application"
        '
        'refreshFormsListButton
        '
        Me.refreshFormsListButton.Location = New System.Drawing.Point(119, 9)
        Me.refreshFormsListButton.Name = "refreshFormsListButton"
        Me.refreshFormsListButton.Size = New System.Drawing.Size(75, 23)
        Me.refreshFormsListButton.TabIndex = 2
        Me.refreshFormsListButton.Text = "Refresh"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Open Forms:"
        '
        'openFormsListBox
        '
        Me.openFormsListBox.FormattingEnabled = True
        Me.openFormsListBox.Location = New System.Drawing.Point(6, 39)
        Me.openFormsListBox.Name = "openFormsListBox"
        Me.openFormsListBox.Size = New System.Drawing.Size(188, 69)
        Me.openFormsListBox.TabIndex = 0
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.form3Button)
        Me.GroupBox5.Controls.Add(Me.form2Button)
        Me.GroupBox5.Location = New System.Drawing.Point(3, 131)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(200, 52)
        Me.GroupBox5.TabIndex = 9
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "My.Forms"
        '
        'form3Button
        '
        Me.form3Button.Location = New System.Drawing.Point(119, 19)
        Me.form3Button.Name = "form3Button"
        Me.form3Button.Size = New System.Drawing.Size(75, 23)
        Me.form3Button.TabIndex = 1
        Me.form3Button.Text = "Open Form3"
        '
        'form2Button
        '
        Me.form2Button.Location = New System.Drawing.Point(9, 19)
        Me.form2Button.Name = "form2Button"
        Me.form2Button.Size = New System.Drawing.Size(75, 23)
        Me.form2Button.TabIndex = 0
        Me.form2Button.Text = "Open Form2"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.stringResource1TextBox)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.PictureBox2)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.PictureBox1)
        Me.GroupBox4.Location = New System.Drawing.Point(3, 189)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(200, 79)
        Me.GroupBox4.TabIndex = 8
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "My.Resources"
        '
        'stringResource1TextBox
        '
        Me.stringResource1TextBox.Location = New System.Drawing.Point(102, 51)
        Me.stringResource1TextBox.Name = "stringResource1TextBox"
        Me.stringResource1TextBox.Size = New System.Drawing.Size(92, 20)
        Me.stringResource1TextBox.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "String Resource:"
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(134, 19)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(26, 26)
        Me.PictureBox2.TabIndex = 1
        Me.PictureBox2.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Image Resources:"
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(102, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(26, 26)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.appSetting2TextBox)
        Me.GroupBox3.Controls.Add(Me.appSetting1TextBox)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 274)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(200, 71)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "My.Settings"
        '
        'appSetting2TextBox
        '
        Me.appSetting2TextBox.Location = New System.Drawing.Point(78, 43)
        Me.appSetting2TextBox.Name = "appSetting2TextBox"
        Me.appSetting2TextBox.Size = New System.Drawing.Size(116, 20)
        Me.appSetting2TextBox.TabIndex = 3
        '
        'appSetting1TextBox
        '
        Me.appSetting1TextBox.Location = New System.Drawing.Point(77, 17)
        Me.appSetting1TextBox.Name = "appSetting1TextBox"
        Me.appSetting1TextBox.Size = New System.Drawing.Size(116, 20)
        Me.appSetting1TextBox.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 46)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "AppSetting2:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "AppSetting1:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Computer)
        Me.GroupBox1.Controls.Add(Me.computerInfoPropertyGrid)
        Me.GroupBox1.Controls.Add(Me.playSoundButton)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.soundsComboBox)
        Me.GroupBox1.Controls.Add(Me.drivesDataGridView)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.currentDirTextBox)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(209, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(334, 342)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "My.Computer"
        '
        'Computer
        '
        Me.Computer.AutoSize = True
        Me.Computer.Location = New System.Drawing.Point(7, 210)
        Me.Computer.Name = "Computer"
        Me.Computer.Size = New System.Drawing.Size(72, 13)
        Me.Computer.TabIndex = 10
        Me.Computer.Text = "Computer Info:"
        '
        'computerInfoPropertyGrid
        '
        Me.computerInfoPropertyGrid.HelpVisible = False
        Me.computerInfoPropertyGrid.Location = New System.Drawing.Point(6, 226)
        Me.computerInfoPropertyGrid.Name = "computerInfoPropertyGrid"
        Me.computerInfoPropertyGrid.Size = New System.Drawing.Size(322, 108)
        Me.computerInfoPropertyGrid.TabIndex = 9
        '
        'playSoundButton
        '
        Me.playSoundButton.Location = New System.Drawing.Point(263, 180)
        Me.playSoundButton.Name = "playSoundButton"
        Me.playSoundButton.Size = New System.Drawing.Size(65, 23)
        Me.playSoundButton.TabIndex = 8
        Me.playSoundButton.Text = "Play"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 166)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(33, 13)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Audio:"
        '
        'soundsComboBox
        '
        Me.soundsComboBox.FormattingEnabled = True
        Me.soundsComboBox.Location = New System.Drawing.Point(6, 182)
        Me.soundsComboBox.Name = "soundsComboBox"
        Me.soundsComboBox.Size = New System.Drawing.Size(251, 21)
        Me.soundsComboBox.TabIndex = 6
        '
        'drivesDataGridView
        '
        Me.drivesDataGridView.Location = New System.Drawing.Point(7, 64)
        Me.drivesDataGridView.Name = "drivesDataGridView"
        Me.drivesDataGridView.Size = New System.Drawing.Size(321, 95)
        Me.drivesDataGridView.TabIndex = 5
        Me.drivesDataGridView.Text = "DataGridView1"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Current directory:"
        '
        'currentDirTextBox
        '
        Me.currentDirTextBox.Location = New System.Drawing.Point(100, 19)
        Me.currentDirTextBox.Name = "currentDirTextBox"
        Me.currentDirTextBox.Size = New System.Drawing.Size(228, 20)
        Me.currentDirTextBox.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Drives:"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(542, 416)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Using My"
        Me.StatusStrip1.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.drivesDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents userNameLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents computerNameLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents clockLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents blankSpacerLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents DirectorySearcher1 As System.DirectoryServices.DirectorySearcher
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents stringResource1TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents form2Button As System.Windows.Forms.Button
    Friend WithEvents form3Button As System.Windows.Forms.Button
    Friend WithEvents openFormsListBox As System.Windows.Forms.ListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents refreshFormsListButton As System.Windows.Forms.Button
    Friend WithEvents currentDirTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents drivesDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents playSoundButton As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents soundsComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Computer As System.Windows.Forms.Label
    Friend WithEvents computerInfoPropertyGrid As System.Windows.Forms.PropertyGrid
    Friend WithEvents appSetting1TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents appSetting2TextBox As System.Windows.Forms.TextBox

End Class
