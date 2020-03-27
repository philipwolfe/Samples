<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class MainForm
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.seventyfivePercent = New System.Windows.Forms.ToolStripMenuItem
        Me.fiftyPercent = New System.Windows.Forms.ToolStripMenuItem
        Me.formatToolStrip = New System.Windows.Forms.ToolStrip
        Me.formatToolStripLabel = New System.Windows.Forms.ToolStripLabel
        Me.formatToolStripBoldButton = New System.Windows.Forms.ToolStripButton
        Me.formatToolStripItalicsButton = New System.Windows.Forms.ToolStripButton
        Me.formatToolStripUnderlineButton = New System.Windows.Forms.ToolStripButton
        Me.OnehundredPercent = New System.Windows.Forms.ToolStripMenuItem
        Me.TwentyfivePercent = New System.Windows.Forms.ToolStripMenuItem
        Me.optionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.testProgressBarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.changeOpacityToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.underlineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.openToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.newToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.saveFileDialog = New System.Windows.Forms.SaveFileDialog
        Me.saveToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.fileToolStrip = New System.Windows.Forms.ToolStrip
        Me.italicsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EntryArea = New System.Windows.Forms.RichTextBox
        Me.docContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.formatContextMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.formatBoldContextMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.formatItalicsContextMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.formatUnderlineContextMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.openFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.toolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.statusStrip = New System.Windows.Forms.StatusStrip
        Me.toolStripProgressBar = New System.Windows.Forms.ToolStripProgressBar
        Me.exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.saveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.boldToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.formatToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.openToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.mainMenuControlStrip = New System.Windows.Forms.MenuStrip
        Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.newToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.formatToolStrip.SuspendLayout()
        Me.fileToolStrip.SuspendLayout()
        Me.docContextMenuStrip.SuspendLayout()
        Me.statusStrip.SuspendLayout()
        Me.mainMenuControlStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'seventyfivePercent
        '
        Me.seventyfivePercent.CheckOnClick = True
        Me.seventyfivePercent.Name = "seventyfivePercent"
        Me.seventyfivePercent.Tag = ".75"
        Me.seventyfivePercent.Text = "&75%"
        '
        'fiftyPercent
        '
        Me.fiftyPercent.CheckOnClick = True
        Me.fiftyPercent.Name = "fiftyPercent"
        Me.fiftyPercent.Tag = ".50"
        Me.fiftyPercent.Text = "&50%"
        '
        'formatToolStrip
        '
        Me.formatToolStrip.Dock = System.Windows.Forms.DockStyle.None
        Me.formatToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.formatToolStripLabel, Me.formatToolStripBoldButton, Me.formatToolStripItalicsButton, Me.formatToolStripUnderlineButton})
        Me.formatToolStrip.Location = New System.Drawing.Point(80, 25)
        Me.formatToolStrip.Name = "formatToolStrip"
        Me.formatToolStrip.Size = New System.Drawing.Size(148, 25)
        Me.formatToolStrip.TabIndex = 7
        Me.formatToolStrip.Text = "toolStrip1"
        '
        'formatToolStripLabel
        '
        Me.formatToolStripLabel.Name = "formatToolStripLabel"
        Me.formatToolStripLabel.Text = "Format"
        '
        'formatToolStripBoldButton
        '
        Me.formatToolStripBoldButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.formatToolStripBoldButton.Image = UsingMenusStatusStripsToolStrips.My.Resources.Resources.Bold
        Me.formatToolStripBoldButton.Name = "formatToolStripBoldButton"
        Me.formatToolStripBoldButton.Text = "&Bold"
        '
        'formatToolStripItalicsButton
        '
        Me.formatToolStripItalicsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.formatToolStripItalicsButton.Image = UsingMenusStatusStripsToolStrips.My.Resources.Resources.Italics
        Me.formatToolStripItalicsButton.Name = "formatToolStripItalicsButton"
        Me.formatToolStripItalicsButton.Text = "&Italics"
        '
        'formatToolStripUnderlineButton
        '
        Me.formatToolStripUnderlineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.formatToolStripUnderlineButton.Image = UsingMenusStatusStripsToolStrips.My.Resources.Resources.Underline
        Me.formatToolStripUnderlineButton.Name = "formatToolStripUnderlineButton"
        Me.formatToolStripUnderlineButton.Text = "&Underline"
        '
        'OnehundredPercent
        '
        Me.OnehundredPercent.CheckOnClick = True
        Me.OnehundredPercent.Name = "OnehundredPercent"
        Me.OnehundredPercent.Tag = "1"
        Me.OnehundredPercent.Text = "&100%"
        '
        'TwentyfivePercent
        '
        Me.TwentyfivePercent.CheckOnClick = True
        Me.TwentyfivePercent.Name = "TwentyfivePercent"
        Me.TwentyfivePercent.Tag = ".25"
        Me.TwentyfivePercent.Text = "&25%"
        '
        'optionsToolStripMenuItem
        '
        Me.optionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.testProgressBarToolStripMenuItem, Me.changeOpacityToolStripMenuItem})
        Me.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem"
        Me.optionsToolStripMenuItem.Text = "O&ptions"
        '
        'testProgressBarToolStripMenuItem
        '
        Me.testProgressBarToolStripMenuItem.Name = "testProgressBarToolStripMenuItem"
        Me.testProgressBarToolStripMenuItem.Text = "&Test Progress Bar"
        '
        'changeOpacityToolStripMenuItem
        '
        Me.changeOpacityToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TwentyfivePercent, Me.fiftyPercent, Me.seventyfivePercent, Me.OnehundredPercent})
        Me.changeOpacityToolStripMenuItem.Name = "changeOpacityToolStripMenuItem"
        Me.changeOpacityToolStripMenuItem.Text = "&Change Opacity"
        '
        'underlineToolStripMenuItem
        '
        Me.underlineToolStripMenuItem.CheckOnClick = True
        Me.underlineToolStripMenuItem.Image = UsingMenusStatusStripsToolStrips.My.Resources.Resources.Underline
        Me.underlineToolStripMenuItem.Name = "underlineToolStripMenuItem"
        Me.underlineToolStripMenuItem.Text = "&Underline"
        '
        'openToolStripButton
        '
        Me.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.openToolStripButton.Image = CType(resources.GetObject("openToolStripButton.Image"), System.Drawing.Image)
        Me.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.openToolStripButton.Name = "openToolStripButton"
        Me.openToolStripButton.Text = "&Open"
        '
        'newToolStripButton
        '
        Me.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.newToolStripButton.Image = CType(resources.GetObject("newToolStripButton.Image"), System.Drawing.Image)
        Me.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.newToolStripButton.Name = "newToolStripButton"
        Me.newToolStripButton.Text = "&New"
        '
        'saveToolStripButton
        '
        Me.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.saveToolStripButton.Image = CType(resources.GetObject("saveToolStripButton.Image"), System.Drawing.Image)
        Me.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.saveToolStripButton.Name = "saveToolStripButton"
        Me.saveToolStripButton.Text = "&Save"
        '
        'fileToolStrip
        '
        Me.fileToolStrip.Dock = System.Windows.Forms.DockStyle.None
        Me.fileToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.newToolStripButton, Me.openToolStripButton, Me.saveToolStripButton})
        Me.fileToolStrip.Location = New System.Drawing.Point(0, 25)
        Me.fileToolStrip.Name = "fileToolStrip"
        Me.fileToolStrip.Size = New System.Drawing.Size(111, 25)
        Me.fileToolStrip.TabIndex = 10
        Me.fileToolStrip.Text = "toolStrip1"
        '
        'italicsToolStripMenuItem
        '
        Me.italicsToolStripMenuItem.CheckOnClick = True
        Me.italicsToolStripMenuItem.Image = UsingMenusStatusStripsToolStrips.My.Resources.Resources.Italics
        Me.italicsToolStripMenuItem.Name = "italicsToolStripMenuItem"
        Me.italicsToolStripMenuItem.Text = "&Italics"
        '
        'EntryArea
        '
        Me.EntryArea.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EntryArea.ContextMenuStrip = Me.docContextMenuStrip
        Me.EntryArea.Location = New System.Drawing.Point(0, 53)
        Me.EntryArea.Name = "EntryArea"
        Me.EntryArea.Size = New System.Drawing.Size(543, 336)
        Me.EntryArea.TabIndex = 8
        Me.EntryArea.Text = ""
        '
        'docContextMenuStrip
        '
        Me.docContextMenuStrip.Enabled = True
        Me.docContextMenuStrip.GripMargin = New System.Windows.Forms.Padding(2)
        Me.docContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.formatContextMenuItem})
        Me.docContextMenuStrip.Location = New System.Drawing.Point(25, 66)
        Me.docContextMenuStrip.Name = "docContextMenuStrip"
        Me.docContextMenuStrip.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.docContextMenuStrip.Size = New System.Drawing.Size(98, 26)
        '
        'formatContextMenuItem
        '
        Me.formatContextMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.formatBoldContextMenuItem, Me.formatItalicsContextMenuItem, Me.formatUnderlineContextMenuItem})
        Me.formatContextMenuItem.Name = "formatContextMenuItem"
        Me.formatContextMenuItem.Text = "Format"
        '
        'formatBoldContextMenuItem
        '
        Me.formatBoldContextMenuItem.Name = "formatBoldContextMenuItem"
        Me.formatBoldContextMenuItem.Text = "&Bold"
        '
        'formatItalicsContextMenuItem
        '
        Me.formatItalicsContextMenuItem.Name = "formatItalicsContextMenuItem"
        Me.formatItalicsContextMenuItem.Text = "&Italics"
        '
        'formatUnderlineContextMenuItem
        '
        Me.formatUnderlineContextMenuItem.Name = "formatUnderlineContextMenuItem"
        Me.formatUnderlineContextMenuItem.Text = "&Underline"
        '
        'openFileDialog
        '
        Me.openFileDialog.FileName = "openFileDialog1"
        '
        'toolStripStatusLabel
        '
        Me.toolStripStatusLabel.Name = "toolStripStatusLabel"
        Me.toolStripStatusLabel.Text = "Status"
        '
        'statusStrip
        '
        Me.statusStrip.AutoSize = False
        Me.statusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripStatusLabel, Me.toolStripProgressBar})
        Me.statusStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table
        Me.statusStrip.Location = New System.Drawing.Point(0, 392)
        Me.statusStrip.Name = "statusStrip"
        Me.statusStrip.Size = New System.Drawing.Size(542, 24)
        Me.statusStrip.TabIndex = 9
        Me.statusStrip.Text = "statusStrip1"
        '
        'toolStripProgressBar
        '
        Me.toolStripProgressBar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
        Me.toolStripProgressBar.Name = "toolStripProgressBar"
        Me.toolStripProgressBar.Size = New System.Drawing.Size(100, 17)
        Me.toolStripProgressBar.Text = "toolStripProgressBar1"
        '
        'exitToolStripMenuItem
        '
        Me.exitToolStripMenuItem.Name = "exitToolStripMenuItem"
        Me.exitToolStripMenuItem.Text = "&Exit"
        '
        'saveToolStripMenuItem
        '
        Me.saveToolStripMenuItem.Name = "saveToolStripMenuItem"
        Me.saveToolStripMenuItem.Text = "&Save"
        '
        'boldToolStripMenuItem
        '
        Me.boldToolStripMenuItem.CheckOnClick = True
        Me.boldToolStripMenuItem.Image = UsingMenusStatusStripsToolStrips.My.Resources.Resources.Bold
        Me.boldToolStripMenuItem.Name = "boldToolStripMenuItem"
        Me.boldToolStripMenuItem.Text = "&Bold"
        '
        'formatToolStripMenuItem
        '
        Me.formatToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.boldToolStripMenuItem, Me.italicsToolStripMenuItem, Me.underlineToolStripMenuItem})
        Me.formatToolStripMenuItem.Name = "formatToolStripMenuItem"
        Me.formatToolStripMenuItem.Text = "Fo&rmat"
        '
        'openToolStripMenuItem
        '
        Me.openToolStripMenuItem.Name = "openToolStripMenuItem"
        Me.openToolStripMenuItem.Text = "&Open"
        '
        'mainMenuControlStrip
        '
        Me.mainMenuControlStrip.BackColor = System.Drawing.SystemColors.MenuBar
        Me.mainMenuControlStrip.Dock = System.Windows.Forms.DockStyle.None
        Me.mainMenuControlStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileToolStripMenuItem, Me.formatToolStripMenuItem, Me.optionsToolStripMenuItem})
        Me.mainMenuControlStrip.Location = New System.Drawing.Point(0, 0)
        Me.mainMenuControlStrip.Name = "mainMenuControlStrip"
        Me.mainMenuControlStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.mainMenuControlStrip.Size = New System.Drawing.Size(232, 24)
        Me.mainMenuControlStrip.TabIndex = 6
        Me.mainMenuControlStrip.Text = "menuStrip1"
        '
        'fileToolStripMenuItem
        '
        Me.fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.newToolStripMenuItem, Me.openToolStripMenuItem, Me.saveToolStripMenuItem, Me.exitToolStripMenuItem})
        Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
        Me.fileToolStripMenuItem.Text = "&File"
        '
        'newToolStripMenuItem
        '
        Me.newToolStripMenuItem.Name = "newToolStripMenuItem"
        Me.newToolStripMenuItem.Text = "&New"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(542, 416)
        Me.Controls.Add(Me.fileToolStrip)
        Me.Controls.Add(Me.EntryArea)
        Me.Controls.Add(Me.statusStrip)
        Me.Controls.Add(Me.mainMenuControlStrip)
        Me.Controls.Add(Me.formatToolStrip)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Using Menus, StatusStrips, ToolStrips"
        Me.formatToolStrip.ResumeLayout(False)
        Me.fileToolStrip.ResumeLayout(False)
        Me.docContextMenuStrip.ResumeLayout(False)
        Me.statusStrip.ResumeLayout(False)
        Me.mainMenuControlStrip.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents seventyfivePercent As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents fiftyPercent As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents formatToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents formatToolStripLabel As System.Windows.Forms.ToolStripLabel
    Friend WithEvents formatToolStripBoldButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents formatToolStripItalicsButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents formatToolStripUnderlineButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents OnehundredPercent As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TwentyfivePercent As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents optionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents testProgressBarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents changeOpacityToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents underlineToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents openToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents newToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents saveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents saveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents fileToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents italicsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EntryArea As System.Windows.Forms.RichTextBox
    Friend WithEvents docContextMenuStrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents formatContextMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents formatBoldContextMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents formatItalicsContextMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents formatUnderlineContextMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents openFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents toolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents statusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents toolStripProgressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents exitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents saveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents boldToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents formatToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents openToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mainMenuControlStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents newToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
