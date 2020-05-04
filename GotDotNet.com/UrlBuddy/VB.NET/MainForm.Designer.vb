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
        Me.timer = New System.Windows.Forms.Timer(Me.components)
        Me.notifyIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.contextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.showLastUrlMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.recentUrlsMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.exitMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.contextMenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'timer
        '
        Me.timer.Interval = 5000
        '
        'notifyIcon
        '
        Me.notifyIcon.ContextMenuStrip = Me.contextMenuStrip
        Me.notifyIcon.Icon = CType(resources.GetObject("notifyIcon.Icon"), System.Drawing.Icon)
        Me.notifyIcon.Visible = True
        '
        'contextMenuStrip
        '
        Me.contextMenuStrip.Enabled = True
        Me.contextMenuStrip.GripMargin = New System.Windows.Forms.Padding(2)
        Me.contextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.showLastUrlMenuItem, Me.recentUrlsMenuItem, Me.exitMenuItem})
        Me.contextMenuStrip.Location = New System.Drawing.Point(22, 37)
        Me.contextMenuStrip.Name = "contextMenuStrip"
        Me.contextMenuStrip.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.contextMenuStrip.Size = New System.Drawing.Size(146, 70)
        '
        'showLastUrlMenuItem
        '
        Me.showLastUrlMenuItem.Enabled = False
        Me.showLastUrlMenuItem.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.showLastUrlMenuItem.Name = "showLastUrlMenuItem"
        Me.showLastUrlMenuItem.Text = "Show Last URL"
        '
        'recentUrlsMenuItem
        '
        Me.recentUrlsMenuItem.Enabled = False
        Me.recentUrlsMenuItem.Name = "recentUrlsMenuItem"
        Me.recentUrlsMenuItem.Text = "Recent URLs"
        '
        'exitMenuItem
        '
        Me.exitMenuItem.Name = "exitMenuItem"
        Me.exitMenuItem.Text = "E&xit"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(300, 52)
        Me.ControlBox = False
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "MainForm"
        Me.ShowInTaskbar = False
        Me.TopMost = True
        Me.contextMenuStrip.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents timer As System.Windows.Forms.Timer
    Friend WithEvents notifyIcon As System.Windows.Forms.NotifyIcon
    Friend Shadows WithEvents contextMenuStrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents exitMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents showLastUrlMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents recentUrlsMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
