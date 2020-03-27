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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.lvThreads = New System.Windows.Forms.ListView
        Me.chThreads = New System.Windows.Forms.ColumnHeader
        Me.chBasePri = New System.Windows.Forms.ColumnHeader
        Me.chCurrentPri = New System.Windows.Forms.ColumnHeader
        Me.chPriBoostEnabled = New System.Windows.Forms.ColumnHeader
        Me.chPriLevel = New System.Windows.Forms.ColumnHeader
        Me.chPrivProcTime = New System.Windows.Forms.ColumnHeader
        Me.chStartAddress = New System.Windows.Forms.ColumnHeader
        Me.chStartTime = New System.Windows.Forms.ColumnHeader
        Me.chTotalProcTime = New System.Windows.Forms.ColumnHeader
        Me.chUserProcTime = New System.Windows.Forms.ColumnHeader
        Me.chValue = New System.Windows.Forms.ColumnHeader
        Me.chItem = New System.Windows.Forms.ColumnHeader
        Me.splVert = New System.Windows.Forms.Splitter
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.ctxRefresh = New System.Windows.Forms.MenuItem
        Me.lvProcessDetail = New System.Windows.Forms.ListView
        Me.splHor = New System.Windows.Forms.Splitter
        Me.pnlThreads = New System.Windows.Forms.Panel
        Me.mnuRefresh = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.mnuAbout = New System.Windows.Forms.MenuItem
        Me.mnuHelp = New System.Windows.Forms.MenuItem
        Me.mnuModules = New System.Windows.Forms.MenuItem
        Me.mnuFile = New System.Windows.Forms.MenuItem
        Me.mnuExit = New System.Windows.Forms.MenuItem
        Me.mnuMain = New System.Windows.Forms.MainMenu(Me.components)
        Me.mnuView = New System.Windows.Forms.MenuItem
        Me.sbInfo = New System.Windows.Forms.StatusBar
        Me.chUser = New System.Windows.Forms.ColumnHeader
        Me.chPriv = New System.Windows.Forms.ColumnHeader
        Me.ctxViewMods = New System.Windows.Forms.MenuItem
        Me.ctxView = New System.Windows.Forms.ContextMenu
        Me.chProcessorTime = New System.Windows.Forms.ColumnHeader
        Me.lvProcesses = New System.Windows.Forms.ListView
        Me.chProcessName = New System.Windows.Forms.ColumnHeader
        Me.chPID = New System.Windows.Forms.ColumnHeader
        Me.pnlProcess = New System.Windows.Forms.Panel
        Me.pnlThreads.SuspendLayout()
        Me.pnlProcess.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvThreads
        '
        Me.lvThreads.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chThreads, Me.chBasePri, Me.chCurrentPri, Me.chPriBoostEnabled, Me.chPriLevel, Me.chPrivProcTime, Me.chStartAddress, Me.chStartTime, Me.chTotalProcTime, Me.chUserProcTime})
        Me.lvThreads.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvThreads.FullRowSelect = True
        Me.lvThreads.Location = New System.Drawing.Point(0, 0)
        Me.lvThreads.MultiSelect = False
        Me.lvThreads.Name = "lvThreads"
        Me.lvThreads.Size = New System.Drawing.Size(775, 134)
        Me.lvThreads.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvThreads.TabIndex = 14
        Me.lvThreads.UseCompatibleStateImageBehavior = False
        Me.lvThreads.View = System.Windows.Forms.View.Details
        '
        'chThreads
        '
        Me.chThreads.Text = "Thread(s)"
        '
        'chBasePri
        '
        Me.chBasePri.Text = "Base Priority"
        Me.chBasePri.Width = 75
        '
        'chCurrentPri
        '
        Me.chCurrentPri.Text = "Current Priority"
        Me.chCurrentPri.Width = 85
        '
        'chPriBoostEnabled
        '
        Me.chPriBoostEnabled.Text = "Priority Boost Enabled"
        Me.chPriBoostEnabled.Width = 115
        '
        'chPriLevel
        '
        Me.chPriLevel.Text = "Priority Level"
        Me.chPriLevel.Width = 75
        '
        'chPrivProcTime
        '
        Me.chPrivProcTime.Text = "Privileged"
        '
        'chStartAddress
        '
        Me.chStartAddress.Text = "Start Address"
        Me.chStartAddress.Width = 80
        '
        'chStartTime
        '
        Me.chStartTime.Text = "Start Time"
        Me.chStartTime.Width = 120
        '
        'chTotalProcTime
        '
        Me.chTotalProcTime.Text = "Processor Time"
        Me.chTotalProcTime.Width = 120
        '
        'chUserProcTime
        '
        Me.chUserProcTime.Text = "User"
        '
        'chValue
        '
        Me.chValue.Text = "Value"
        Me.chValue.Width = 206
        '
        'chItem
        '
        Me.chItem.Text = "Item"
        Me.chItem.Width = 165
        '
        'splVert
        '
        Me.splVert.Dock = System.Windows.Forms.DockStyle.Right
        Me.splVert.Location = New System.Drawing.Point(388, 0)
        Me.splVert.Name = "splVert"
        Me.splVert.Size = New System.Drawing.Size(3, 368)
        Me.splVert.TabIndex = 14
        Me.splVert.TabStop = False
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 1
        Me.MenuItem1.Text = "-"
        '
        'ctxRefresh
        '
        Me.ctxRefresh.Index = 2
        Me.ctxRefresh.Shortcut = System.Windows.Forms.Shortcut.F5
        Me.ctxRefresh.Text = "&Refresh"
        '
        'lvProcessDetail
        '
        Me.lvProcessDetail.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chItem, Me.chValue})
        Me.lvProcessDetail.Dock = System.Windows.Forms.DockStyle.Right
        Me.lvProcessDetail.Location = New System.Drawing.Point(391, 0)
        Me.lvProcessDetail.MultiSelect = False
        Me.lvProcessDetail.Name = "lvProcessDetail"
        Me.lvProcessDetail.Size = New System.Drawing.Size(384, 368)
        Me.lvProcessDetail.TabIndex = 13
        Me.lvProcessDetail.UseCompatibleStateImageBehavior = False
        Me.lvProcessDetail.View = System.Windows.Forms.View.Details
        '
        'splHor
        '
        Me.splHor.Dock = System.Windows.Forms.DockStyle.Top
        Me.splHor.Location = New System.Drawing.Point(0, 368)
        Me.splHor.Name = "splHor"
        Me.splHor.Size = New System.Drawing.Size(775, 3)
        Me.splHor.TabIndex = 20
        Me.splHor.TabStop = False
        '
        'pnlThreads
        '
        Me.pnlThreads.Controls.Add(Me.lvThreads)
        Me.pnlThreads.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlThreads.Location = New System.Drawing.Point(0, 368)
        Me.pnlThreads.Name = "pnlThreads"
        Me.pnlThreads.Size = New System.Drawing.Size(775, 134)
        Me.pnlThreads.TabIndex = 19
        '
        'mnuRefresh
        '
        Me.mnuRefresh.Index = 2
        Me.mnuRefresh.Shortcut = System.Windows.Forms.Shortcut.F5
        Me.mnuRefresh.Text = "&Refresh"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 1
        Me.MenuItem2.Text = "-"
        '
        'mnuAbout
        '
        Me.mnuAbout.Index = 0
        Me.mnuAbout.Text = "Text Comes from AssemblyInfo"
        '
        'mnuHelp
        '
        Me.mnuHelp.Index = 2
        Me.mnuHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAbout})
        Me.mnuHelp.Text = "&Help"
        '
        'mnuModules
        '
        Me.mnuModules.Index = 0
        Me.mnuModules.Shortcut = System.Windows.Forms.Shortcut.CtrlV
        Me.mnuModules.Text = "&Modules"
        '
        'mnuFile
        '
        Me.mnuFile.Index = 0
        Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuExit})
        Me.mnuFile.Text = "&File"
        '
        'mnuExit
        '
        Me.mnuExit.Index = 0
        Me.mnuExit.Text = "E&xit"
        '
        'mnuMain
        '
        Me.mnuMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.mnuView, Me.mnuHelp})
        '
        'mnuView
        '
        Me.mnuView.Index = 1
        Me.mnuView.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuModules, Me.MenuItem2, Me.mnuRefresh})
        Me.mnuView.Text = "&View"
        '
        'sbInfo
        '
        Me.sbInfo.Location = New System.Drawing.Point(0, 502)
        Me.sbInfo.Name = "sbInfo"
        Me.sbInfo.Size = New System.Drawing.Size(775, 22)
        Me.sbInfo.TabIndex = 17
        Me.sbInfo.Text = "Ready"
        '
        'chUser
        '
        Me.chUser.Text = "User"
        Me.chUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.chUser.Width = 80
        '
        'chPriv
        '
        Me.chPriv.Text = "Priviledged"
        Me.chPriv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.chPriv.Width = 80
        '
        'ctxViewMods
        '
        Me.ctxViewMods.Index = 0
        Me.ctxViewMods.Shortcut = System.Windows.Forms.Shortcut.CtrlV
        Me.ctxViewMods.Text = "View &Modules"
        '
        'ctxView
        '
        Me.ctxView.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.ctxViewMods, Me.MenuItem1, Me.ctxRefresh})
        '
        'chProcessorTime
        '
        Me.chProcessorTime.Text = "Processor Time"
        Me.chProcessorTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.chProcessorTime.Width = 150
        '
        'lvProcesses
        '
        Me.lvProcesses.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chProcessName, Me.chPID, Me.chProcessorTime, Me.chPriv, Me.chUser})
        Me.lvProcesses.ContextMenu = Me.ctxView
        Me.lvProcesses.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvProcesses.FullRowSelect = True
        Me.lvProcesses.Location = New System.Drawing.Point(0, 0)
        Me.lvProcesses.MultiSelect = False
        Me.lvProcesses.Name = "lvProcesses"
        Me.lvProcesses.Size = New System.Drawing.Size(388, 368)
        Me.lvProcesses.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvProcesses.TabIndex = 15
        Me.lvProcesses.UseCompatibleStateImageBehavior = False
        Me.lvProcesses.View = System.Windows.Forms.View.Details
        '
        'chProcessName
        '
        Me.chProcessName.Text = "Process Name"
        Me.chProcessName.Width = 150
        '
        'chPID
        '
        Me.chPID.Text = "PID"
        '
        'pnlProcess
        '
        Me.pnlProcess.Controls.Add(Me.lvProcesses)
        Me.pnlProcess.Controls.Add(Me.splVert)
        Me.pnlProcess.Controls.Add(Me.lvProcessDetail)
        Me.pnlProcess.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlProcess.Location = New System.Drawing.Point(0, 0)
        Me.pnlProcess.Name = "pnlProcess"
        Me.pnlProcess.Size = New System.Drawing.Size(775, 368)
        Me.pnlProcess.TabIndex = 18
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(775, 524)
        Me.Controls.Add(Me.splHor)
        Me.Controls.Add(Me.pnlThreads)
        Me.Controls.Add(Me.sbInfo)
        Me.Controls.Add(Me.pnlProcess)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Menu = Me.mnuMain
        Me.Name = "frmMain"
        Me.Text = "Title Comes from Assembly Info"
        Me.pnlThreads.ResumeLayout(False)
        Me.pnlProcess.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lvThreads As System.Windows.Forms.ListView
    Friend WithEvents chThreads As System.Windows.Forms.ColumnHeader
    Friend WithEvents chBasePri As System.Windows.Forms.ColumnHeader
    Friend WithEvents chCurrentPri As System.Windows.Forms.ColumnHeader
    Friend WithEvents chPriBoostEnabled As System.Windows.Forms.ColumnHeader
    Friend WithEvents chPriLevel As System.Windows.Forms.ColumnHeader
    Friend WithEvents chPrivProcTime As System.Windows.Forms.ColumnHeader
    Friend WithEvents chStartAddress As System.Windows.Forms.ColumnHeader
    Friend WithEvents chStartTime As System.Windows.Forms.ColumnHeader
    Friend WithEvents chTotalProcTime As System.Windows.Forms.ColumnHeader
    Friend WithEvents chUserProcTime As System.Windows.Forms.ColumnHeader
    Friend WithEvents chValue As System.Windows.Forms.ColumnHeader
    Friend WithEvents chItem As System.Windows.Forms.ColumnHeader
    Friend WithEvents splVert As System.Windows.Forms.Splitter
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents ctxRefresh As System.Windows.Forms.MenuItem
    Friend WithEvents lvProcessDetail As System.Windows.Forms.ListView
    Friend WithEvents splHor As System.Windows.Forms.Splitter
    Friend WithEvents pnlThreads As System.Windows.Forms.Panel
    Friend WithEvents mnuRefresh As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAbout As System.Windows.Forms.MenuItem
    Friend WithEvents mnuHelp As System.Windows.Forms.MenuItem
    Friend WithEvents mnuModules As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFile As System.Windows.Forms.MenuItem
    Friend WithEvents mnuExit As System.Windows.Forms.MenuItem
    Friend WithEvents mnuMain As System.Windows.Forms.MainMenu
    Friend WithEvents mnuView As System.Windows.Forms.MenuItem
    Friend WithEvents sbInfo As System.Windows.Forms.StatusBar
    Friend WithEvents chUser As System.Windows.Forms.ColumnHeader
    Friend WithEvents chPriv As System.Windows.Forms.ColumnHeader
    Friend WithEvents ctxViewMods As System.Windows.Forms.MenuItem
    Friend WithEvents ctxView As System.Windows.Forms.ContextMenu
    Friend WithEvents chProcessorTime As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvProcesses As System.Windows.Forms.ListView
    Friend WithEvents chProcessName As System.Windows.Forms.ColumnHeader
    Friend WithEvents chPID As System.Windows.Forms.ColumnHeader
    Friend WithEvents pnlProcess As System.Windows.Forms.Panel
End Class
