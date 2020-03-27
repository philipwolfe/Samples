<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
        Me.chkAutoRefresh = New System.Windows.Forms.CheckBox
        Me.cmdResume = New System.Windows.Forms.Button
        Me.cmdPause = New System.Windows.Forms.Button
        Me.cmdStop = New System.Windows.Forms.Button
        Me.cmdStart = New System.Windows.Forms.Button
        Me.chSvcType = New System.Windows.Forms.ColumnHeader
        Me.tmrStatus = New System.Windows.Forms.Timer(Me.components)
        Me.chStatus = New System.Windows.Forms.ColumnHeader
        Me.lvServices = New System.Windows.Forms.ListView
        Me.chName = New System.Windows.Forms.ColumnHeader
        Me.pnlCommands = New System.Windows.Forms.Panel
        Me.mnuTools = New System.Windows.Forms.MenuItem
        Me.mnuRelist = New System.Windows.Forms.MenuItem
        Me.MenuItem3 = New System.Windows.Forms.MenuItem
        Me.mnuRefresh = New System.Windows.Forms.MenuItem
        Me.mnuExit = New System.Windows.Forms.MenuItem
        Me.mnuMain = New System.Windows.Forms.MainMenu(Me.components)
        Me.mnuFile = New System.Windows.Forms.MenuItem
        Me.mnuHelp = New System.Windows.Forms.MenuItem
        Me.mnuAbout = New System.Windows.Forms.MenuItem
        Me.sbInfo = New System.Windows.Forms.StatusBar
        Me.pnlCommands.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkAutoRefresh
        '
        Me.chkAutoRefresh.Checked = True
        Me.chkAutoRefresh.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAutoRefresh.Location = New System.Drawing.Point(336, 8)
        Me.chkAutoRefresh.Name = "chkAutoRefresh"
        Me.chkAutoRefresh.Size = New System.Drawing.Size(104, 24)
        Me.chkAutoRefresh.TabIndex = 4
        Me.chkAutoRefresh.Text = "&Auto Refresh"
        '
        'cmdResume
        '
        Me.cmdResume.Location = New System.Drawing.Point(248, 8)
        Me.cmdResume.Name = "cmdResume"
        Me.cmdResume.Size = New System.Drawing.Size(75, 23)
        Me.cmdResume.TabIndex = 3
        Me.cmdResume.Text = "&Resume"
        '
        'cmdPause
        '
        Me.cmdPause.Location = New System.Drawing.Point(168, 8)
        Me.cmdPause.Name = "cmdPause"
        Me.cmdPause.Size = New System.Drawing.Size(75, 23)
        Me.cmdPause.TabIndex = 2
        Me.cmdPause.Text = "&Pause"
        '
        'cmdStop
        '
        Me.cmdStop.Location = New System.Drawing.Point(88, 8)
        Me.cmdStop.Name = "cmdStop"
        Me.cmdStop.Size = New System.Drawing.Size(75, 23)
        Me.cmdStop.TabIndex = 1
        Me.cmdStop.Text = "S&top"
        '
        'cmdStart
        '
        Me.cmdStart.Location = New System.Drawing.Point(8, 8)
        Me.cmdStart.Name = "cmdStart"
        Me.cmdStart.Size = New System.Drawing.Size(75, 23)
        Me.cmdStart.TabIndex = 0
        Me.cmdStart.Text = "&Start"
        '
        'chSvcType
        '
        Me.chSvcType.Text = "Service Type"
        Me.chSvcType.Width = 225
        '
        'tmrStatus
        '
        Me.tmrStatus.Enabled = True
        Me.tmrStatus.Interval = 5000
        '
        'chStatus
        '
        Me.chStatus.Text = "Status"
        Me.chStatus.Width = 100
        '
        'lvServices
        '
        Me.lvServices.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chName, Me.chStatus, Me.chSvcType})
        Me.lvServices.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvServices.FullRowSelect = True
        Me.lvServices.HideSelection = False
        Me.lvServices.Location = New System.Drawing.Point(0, 0)
        Me.lvServices.MultiSelect = False
        Me.lvServices.Name = "lvServices"
        Me.lvServices.Size = New System.Drawing.Size(559, 208)
        Me.lvServices.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvServices.TabIndex = 3
        Me.lvServices.UseCompatibleStateImageBehavior = False
        Me.lvServices.View = System.Windows.Forms.View.Details
        '
        'chName
        '
        Me.chName.Text = "Name"
        Me.chName.Width = 200
        '
        'pnlCommands
        '
        Me.pnlCommands.Controls.Add(Me.chkAutoRefresh)
        Me.pnlCommands.Controls.Add(Me.cmdResume)
        Me.pnlCommands.Controls.Add(Me.cmdPause)
        Me.pnlCommands.Controls.Add(Me.cmdStop)
        Me.pnlCommands.Controls.Add(Me.cmdStart)
        Me.pnlCommands.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlCommands.Location = New System.Drawing.Point(0, 208)
        Me.pnlCommands.Name = "pnlCommands"
        Me.pnlCommands.Size = New System.Drawing.Size(559, 40)
        Me.pnlCommands.TabIndex = 4
        '
        'mnuTools
        '
        Me.mnuTools.Index = 1
        Me.mnuTools.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuRelist, Me.MenuItem3, Me.mnuRefresh})
        Me.mnuTools.Text = "&Tools"
        '
        'mnuRelist
        '
        Me.mnuRelist.Index = 0
        Me.mnuRelist.Text = "Relist &All Services"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 1
        Me.MenuItem3.Text = "-"
        '
        'mnuRefresh
        '
        Me.mnuRefresh.Index = 2
        Me.mnuRefresh.Shortcut = System.Windows.Forms.Shortcut.F5
        Me.mnuRefresh.Text = "&Refresh"
        '
        'mnuExit
        '
        Me.mnuExit.Index = 0
        Me.mnuExit.Text = "E&xit"
        '
        'mnuMain
        '
        Me.mnuMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.mnuTools, Me.mnuHelp})
        '
        'mnuFile
        '
        Me.mnuFile.Index = 0
        Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuExit})
        Me.mnuFile.Text = "&File"
        '
        'mnuHelp
        '
        Me.mnuHelp.Index = 2
        Me.mnuHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAbout})
        Me.mnuHelp.Text = "&Help"
        '
        'mnuAbout
        '
        Me.mnuAbout.Index = 0
        Me.mnuAbout.Text = "Text Comes from AssemblyInfo"
        '
        'sbInfo
        '
        Me.sbInfo.Location = New System.Drawing.Point(0, 248)
        Me.sbInfo.Name = "sbInfo"
        Me.sbInfo.Size = New System.Drawing.Size(559, 22)
        Me.sbInfo.TabIndex = 5
        Me.sbInfo.Text = "Ready"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(559, 270)
        Me.Controls.Add(Me.lvServices)
        Me.Controls.Add(Me.pnlCommands)
        Me.Controls.Add(Me.sbInfo)
        Me.MaximizeBox = False
        Me.Menu = Me.mnuMain
        Me.Name = "frmMain"
        Me.Text = "Title Comes from Assembly Info"
        Me.pnlCommands.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents chkAutoRefresh As System.Windows.Forms.CheckBox
    Friend WithEvents cmdResume As System.Windows.Forms.Button
    Friend WithEvents cmdPause As System.Windows.Forms.Button
    Friend WithEvents cmdStop As System.Windows.Forms.Button
    Friend WithEvents cmdStart As System.Windows.Forms.Button
    Friend WithEvents chSvcType As System.Windows.Forms.ColumnHeader
    Friend WithEvents tmrStatus As System.Windows.Forms.Timer
    Friend WithEvents chStatus As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvServices As System.Windows.Forms.ListView
    Friend WithEvents chName As System.Windows.Forms.ColumnHeader
    Friend WithEvents pnlCommands As System.Windows.Forms.Panel
    Friend WithEvents mnuTools As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRelist As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRefresh As System.Windows.Forms.MenuItem
    Friend WithEvents mnuExit As System.Windows.Forms.MenuItem
    Friend WithEvents mnuMain As System.Windows.Forms.MainMenu
    Friend WithEvents mnuFile As System.Windows.Forms.MenuItem
    Friend WithEvents mnuHelp As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAbout As System.Windows.Forms.MenuItem
    Friend WithEvents sbInfo As System.Windows.Forms.StatusBar

End Class
