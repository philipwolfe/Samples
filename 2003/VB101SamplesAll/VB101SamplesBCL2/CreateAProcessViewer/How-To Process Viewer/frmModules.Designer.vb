<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModules
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmModules))
        Me.chItem = New System.Windows.Forms.ColumnHeader
        Me.mnuClose = New System.Windows.Forms.MenuItem
        Me.splVert = New System.Windows.Forms.Splitter
        Me.lvModDetail = New System.Windows.Forms.ListView
        Me.chValue = New System.Windows.Forms.ColumnHeader
        Me.lvModules = New System.Windows.Forms.ListView
        Me.chModName = New System.Windows.Forms.ColumnHeader
        Me.sbInfo = New System.Windows.Forms.StatusBar
        Me.mnuFile = New System.Windows.Forms.MenuItem
        Me.mnuMain = New System.Windows.Forms.MainMenu(Me.components)
        Me.SuspendLayout()
        '
        'chItem
        '
        Me.chItem.Text = "Item"
        Me.chItem.Width = 150
        '
        'mnuClose
        '
        Me.mnuClose.Index = 0
        Me.mnuClose.Text = "&Close"
        '
        'splVert
        '
        Me.splVert.Location = New System.Drawing.Point(184, 0)
        Me.splVert.Name = "splVert"
        Me.splVert.Size = New System.Drawing.Size(3, 284)
        Me.splVert.TabIndex = 7
        Me.splVert.TabStop = False
        '
        'lvModDetail
        '
        Me.lvModDetail.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chItem, Me.chValue})
        Me.lvModDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvModDetail.FullRowSelect = True
        Me.lvModDetail.Location = New System.Drawing.Point(184, 0)
        Me.lvModDetail.MultiSelect = False
        Me.lvModDetail.Name = "lvModDetail"
        Me.lvModDetail.Size = New System.Drawing.Size(485, 284)
        Me.lvModDetail.TabIndex = 6
        Me.lvModDetail.UseCompatibleStateImageBehavior = False
        Me.lvModDetail.View = System.Windows.Forms.View.Details
        '
        'chValue
        '
        Me.chValue.Text = "Value"
        Me.chValue.Width = 570
        '
        'lvModules
        '
        Me.lvModules.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chModName})
        Me.lvModules.Dock = System.Windows.Forms.DockStyle.Left
        Me.lvModules.FullRowSelect = True
        Me.lvModules.Location = New System.Drawing.Point(0, 0)
        Me.lvModules.MultiSelect = False
        Me.lvModules.Name = "lvModules"
        Me.lvModules.Size = New System.Drawing.Size(184, 284)
        Me.lvModules.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvModules.TabIndex = 5
        Me.lvModules.UseCompatibleStateImageBehavior = False
        Me.lvModules.View = System.Windows.Forms.View.Details
        '
        'chModName
        '
        Me.chModName.Text = "Module Name"
        Me.chModName.Width = 150
        '
        'sbInfo
        '
        Me.sbInfo.Location = New System.Drawing.Point(0, 284)
        Me.sbInfo.Name = "sbInfo"
        Me.sbInfo.Size = New System.Drawing.Size(669, 22)
        Me.sbInfo.TabIndex = 4
        Me.sbInfo.Text = "Ready"
        '
        'mnuFile
        '
        Me.mnuFile.Index = 0
        Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuClose})
        Me.mnuFile.Text = "&File"
        '
        'mnuMain
        '
        Me.mnuMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile})
        '
        'frmModules
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(669, 306)
        Me.Controls.Add(Me.splVert)
        Me.Controls.Add(Me.lvModDetail)
        Me.Controls.Add(Me.lvModules)
        Me.Controls.Add(Me.sbInfo)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Menu = Me.mnuMain
        Me.Name = "frmModules"
        Me.Text = "Module Detail"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents chItem As System.Windows.Forms.ColumnHeader
    Friend WithEvents mnuClose As System.Windows.Forms.MenuItem
    Friend WithEvents splVert As System.Windows.Forms.Splitter
    Friend WithEvents lvModDetail As System.Windows.Forms.ListView
    Friend WithEvents chValue As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvModules As System.Windows.Forms.ListView
    Friend WithEvents chModName As System.Windows.Forms.ColumnHeader
    Friend WithEvents sbInfo As System.Windows.Forms.StatusBar
    Friend WithEvents mnuFile As System.Windows.Forms.MenuItem
    Friend WithEvents mnuMain As System.Windows.Forms.MainMenu
End Class
