Partial Public Class Form1
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ButtonToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.Sep1ToolStripButton = New System.Windows.Forms.ToolStripSeparator
        Me.LabelToolStripButton = New System.Windows.Forms.ToolStripLabel
        Me.TextBoxToolStripButton = New System.Windows.Forms.ToolStripTextBox
        Me.SplitButtonToolStripButton = New System.Windows.Forms.ToolStripSplitButton
        Me.SplitButtonSubItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DropDownButtonToolStripButton = New System.Windows.Forms.ToolStripDropDownButton
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ItsatrapStatusStripPanel = New System.Windows.Forms.ToolStripStatusLabel
        Me.rendererStyleGroupBox = New System.Windows.Forms.GroupBox
        Me.superCoolRendererRadio = New System.Windows.Forms.RadioButton
        Me.normalRendererRadio = New System.Windows.Forms.RadioButton
        Me.superCoolSettingsGroupBox = New System.Windows.Forms.GroupBox
        Me.endColorDemoPanel = New System.Windows.Forms.Panel
        Me.startColorDemoPanel = New System.Windows.Forms.Panel
        Me.endColorButton = New System.Windows.Forms.Button
        Me.startColorButton = New System.Windows.Forms.Button
        Me.drawToolbarBorderCheckbox = New System.Windows.Forms.CheckBox
        Me.chooseColorDialog = New System.Windows.Forms.ColorDialog
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.rendererStyleGroupBox.SuspendLayout()
        Me.superCoolSettingsGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(6, 2, 0, 2)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        'Me.FileToolStripMenuItem.SettingsKey = "Form1.FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        'Me.ExitToolStripMenuItem.SettingsKey = "Form1.ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonToolStripButton, Me.Sep1ToolStripButton, Me.LabelToolStripButton, Me.TextBoxToolStripButton, Me.SplitButtonToolStripButton, Me.DropDownButtonToolStripButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 21)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ButtonToolStripButton
        '
        Me.ButtonToolStripButton.Name = "ButtonToolStripButton"
        'Me.ButtonToolStripButton.SettingsKey = "Form1.ButtonToolStripButton"
        Me.ButtonToolStripButton.Text = "Button"
        '
        'Sep1ToolStripButton
        '
        Me.Sep1ToolStripButton.Name = "Sep1ToolStripButton"
        'Me.Sep1ToolStripButton.SettingsKey = "Form1.Sep1ToolStripButton"
        '
        'LabelToolStripButton
        '
        Me.LabelToolStripButton.Name = "LabelToolStripButton"
        'Me.LabelToolStripButton.SettingsKey = "Form1.LabelToolStripButton"
        Me.LabelToolStripButton.Text = "Label"
        '
        'TextBoxToolStripButton
        '
        Me.TextBoxToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
        Me.TextBoxToolStripButton.Name = "TextBoxToolStripButton"
        'Me.TextBoxToolStripButton.SettingsKey = "Form1.TextBoxToolStripButton"
        Me.TextBoxToolStripButton.Size = New System.Drawing.Size(100, 25)
        Me.TextBoxToolStripButton.Text = "Text Box"
        '
        'SplitButtonToolStripButton
        '
        Me.SplitButtonToolStripButton.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SplitButtonSubItemToolStripMenuItem})
        Me.SplitButtonToolStripButton.Name = "SplitButtonToolStripButton"
        'Me.SplitButtonToolStripButton.SettingsKey = "Form1.SplitButtonToolStripButton"
        'Me.SplitButtonToolStripButton.s(SplitterWidth = 1)
        Me.SplitButtonToolStripButton.Text = "SplitButton"
        '
        'SplitButtonSubItemToolStripMenuItem
        '
        Me.SplitButtonSubItemToolStripMenuItem.Name = "SplitButtonSubItemToolStripMenuItem"
        'Me.SplitButtonSubItemToolStripMenuItem.SettingsKey = "Form1.SplitButtonSubItemToolStripMenuItem"
        Me.SplitButtonSubItemToolStripMenuItem.Text = "SplitButtonSubItem"
        '
        'DropDownButtonToolStripButton
        '
        Me.DropDownButtonToolStripButton.Name = "DropDownButtonToolStripButton"
        'Me.DropDownButtonToolStripButton.SettingsKey = "Form1.DropDownButtonToolStripButton"
        Me.DropDownButtonToolStripButton.Text = "DropDownButton"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ItsatrapStatusStripPanel})
        Me.StatusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 327)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ItsatrapStatusStripPanel
        '
        Me.ItsatrapStatusStripPanel.BorderSides = ToolStripStatusLabelBorderSides.None
        Me.ItsatrapStatusStripPanel.Name = "ItsatrapStatusStripPanel"
        'Me.ItsatrapStatusStripPanel.SettingsKey = "Form1.ItsatrapStatusStripPanel"
        Me.ItsatrapStatusStripPanel.Spring = False
        Me.ItsatrapStatusStripPanel.Text = "When shall we three meet again?"
        '
        'rendererStyleGroupBox
        '
        Me.rendererStyleGroupBox.Controls.Add(Me.superCoolRendererRadio)
        Me.rendererStyleGroupBox.Controls.Add(Me.normalRendererRadio)
        Me.rendererStyleGroupBox.Location = New System.Drawing.Point(18, 54)
        Me.rendererStyleGroupBox.Name = "rendererStyleGroupBox"
        Me.rendererStyleGroupBox.Size = New System.Drawing.Size(120, 65)
        Me.rendererStyleGroupBox.TabIndex = 4
        Me.rendererStyleGroupBox.TabStop = False
        Me.rendererStyleGroupBox.Text = "&Renderer Style"
        '
        'superCoolRendererRadio
        '
        Me.superCoolRendererRadio.AutoSize = True
        Me.superCoolRendererRadio.Location = New System.Drawing.Point(10, 43)
        Me.superCoolRendererRadio.Name = "superCoolRendererRadio"
        Me.superCoolRendererRadio.Size = New System.Drawing.Size(73, 17)
        Me.superCoolRendererRadio.TabIndex = 1
        Me.superCoolRendererRadio.Text = "&Super Cool"
        '
        'normalRendererRadio
        '
        Me.normalRendererRadio.AutoSize = True
        Me.normalRendererRadio.Checked = True
        Me.normalRendererRadio.Location = New System.Drawing.Point(10, 20)
        Me.normalRendererRadio.Name = "normalRendererRadio"
        Me.normalRendererRadio.Size = New System.Drawing.Size(54, 17)
        Me.normalRendererRadio.TabIndex = 0
        Me.normalRendererRadio.Text = "&Normal"
        '
        'superCoolSettingsGroupBox
        '
        Me.superCoolSettingsGroupBox.Controls.Add(Me.endColorDemoPanel)
        Me.superCoolSettingsGroupBox.Controls.Add(Me.startColorDemoPanel)
        Me.superCoolSettingsGroupBox.Controls.Add(Me.endColorButton)
        Me.superCoolSettingsGroupBox.Controls.Add(Me.startColorButton)
        Me.superCoolSettingsGroupBox.Controls.Add(Me.drawToolbarBorderCheckbox)
        Me.superCoolSettingsGroupBox.Location = New System.Drawing.Point(18, 126)
        Me.superCoolSettingsGroupBox.Name = "superCoolSettingsGroupBox"
        Me.superCoolSettingsGroupBox.Size = New System.Drawing.Size(243, 144)
        Me.superCoolSettingsGroupBox.TabIndex = 5
        Me.superCoolSettingsGroupBox.TabStop = False
        Me.superCoolSettingsGroupBox.Text = "Super Cool Settings"
        '
        'endColorDemoPanel
        '
        Me.endColorDemoPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.endColorDemoPanel.Location = New System.Drawing.Point(92, 74)
        Me.endColorDemoPanel.Name = "endColorDemoPanel"
        Me.endColorDemoPanel.Size = New System.Drawing.Size(145, 23)
        Me.endColorDemoPanel.TabIndex = 4
        '
        'startColorDemoPanel
        '
        Me.startColorDemoPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.startColorDemoPanel.Location = New System.Drawing.Point(92, 44)
        Me.startColorDemoPanel.Name = "startColorDemoPanel"
        Me.startColorDemoPanel.Size = New System.Drawing.Size(145, 23)
        Me.startColorDemoPanel.TabIndex = 3
        '
        'endColorButton
        '
        Me.endColorButton.Location = New System.Drawing.Point(10, 74)
        Me.endColorButton.Name = "endColorButton"
        Me.endColorButton.TabIndex = 2
        Me.endColorButton.Text = "&End Color"
        '
        'startColorButton
        '
        Me.startColorButton.Location = New System.Drawing.Point(10, 44)
        Me.startColorButton.Name = "startColorButton"
        Me.startColorButton.TabIndex = 1
        Me.startColorButton.Text = "Star&t Color"
        '
        'drawToolbarBorderCheckbox
        '
        Me.drawToolbarBorderCheckbox.AutoSize = True
        Me.drawToolbarBorderCheckbox.Location = New System.Drawing.Point(10, 20)
        Me.drawToolbarBorderCheckbox.Name = "drawToolbarBorderCheckbox"
        Me.drawToolbarBorderCheckbox.Size = New System.Drawing.Size(131, 17)
        Me.drawToolbarBorderCheckbox.TabIndex = 0
        Me.drawToolbarBorderCheckbox.Text = "&Draw ToolStrip Borders"
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(412, 349)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.superCoolSettingsGroupBox)
        Me.Controls.Add(Me.rendererStyleGroupBox)
        Me.Name = "Form1"
        Me.Text = "Custom ToolStrip Renderer Demo"
        Me.MenuStrip1.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.rendererStyleGroupBox.ResumeLayout(False)
        Me.rendererStyleGroupBox.PerformLayout()
        Me.superCoolSettingsGroupBox.ResumeLayout(False)
        Me.superCoolSettingsGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ButtonToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents Sep1ToolStripButton As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LabelToolStripButton As System.Windows.Forms.ToolStripLabel
    Friend WithEvents TextBoxToolStripButton As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents rendererStyleGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents normalRendererRadio As System.Windows.Forms.RadioButton
    Friend WithEvents superCoolRendererRadio As System.Windows.Forms.RadioButton
    Friend WithEvents superCoolSettingsGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents SplitButtonToolStripButton As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents SplitButtonSubItemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DropDownButtonToolStripButton As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents drawToolbarBorderCheckbox As System.Windows.Forms.CheckBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ItsatrapStatusStripPanel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents startColorButton As System.Windows.Forms.Button
    Friend WithEvents endColorButton As System.Windows.Forms.Button
    Friend WithEvents endColorDemoPanel As System.Windows.Forms.Panel
    Friend WithEvents startColorDemoPanel As System.Windows.Forms.Panel
    Friend WithEvents chooseColorDialog As System.Windows.Forms.ColorDialog

End Class
