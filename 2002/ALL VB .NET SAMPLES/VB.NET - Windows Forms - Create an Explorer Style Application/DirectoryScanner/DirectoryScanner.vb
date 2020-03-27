'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Imports System.IO

Public Class DirectoryScanner
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents mnuMain As System.Windows.Forms.MainMenu
    Friend WithEvents mnuExit As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFile As System.Windows.Forms.MenuItem
    Friend WithEvents tvwDirectories As System.Windows.Forms.TreeView
    Friend WithEvents sbrScan As System.Windows.Forms.StatusBar
    Friend WithEvents lvwDirectories As System.Windows.Forms.ListView
    Friend WithEvents mnuScan As System.Windows.Forms.MenuItem
    Friend WithEvents mnuScanAll As System.Windows.Forms.MenuItem
    Friend WithEvents mnuScanFromOne As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(DirectoryScanner))
        Me.lvwDirectories = New System.Windows.Forms.ListView()
        Me.sbrScan = New System.Windows.Forms.StatusBar()
        Me.tvwDirectories = New System.Windows.Forms.TreeView()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuScanAll = New System.Windows.Forms.MenuItem()
        Me.mnuScanFromOne = New System.Windows.Forms.MenuItem()
        Me.mnuScan = New System.Windows.Forms.MenuItem()
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.SuspendLayout()
        '
        'lvwDirectories
        '
        Me.lvwDirectories.AccessibleDescription = resources.GetString("lvwDirectories.AccessibleDescription")
        Me.lvwDirectories.AccessibleName = resources.GetString("lvwDirectories.AccessibleName")
        Me.lvwDirectories.Alignment = CType(resources.GetObject("lvwDirectories.Alignment"), System.Windows.Forms.ListViewAlignment)
        Me.lvwDirectories.Anchor = CType(resources.GetObject("lvwDirectories.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lvwDirectories.BackgroundImage = CType(resources.GetObject("lvwDirectories.BackgroundImage"), System.Drawing.Image)
        Me.lvwDirectories.Dock = CType(resources.GetObject("lvwDirectories.Dock"), System.Windows.Forms.DockStyle)
        Me.lvwDirectories.Enabled = CType(resources.GetObject("lvwDirectories.Enabled"), Boolean)
        Me.lvwDirectories.Font = CType(resources.GetObject("lvwDirectories.Font"), System.Drawing.Font)
        Me.lvwDirectories.FullRowSelect = True
        Me.lvwDirectories.ImeMode = CType(resources.GetObject("lvwDirectories.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lvwDirectories.LabelWrap = CType(resources.GetObject("lvwDirectories.LabelWrap"), Boolean)
        Me.lvwDirectories.Location = CType(resources.GetObject("lvwDirectories.Location"), System.Drawing.Point)
        Me.lvwDirectories.MultiSelect = False
        Me.lvwDirectories.Name = "lvwDirectories"
        Me.lvwDirectories.RightToLeft = CType(resources.GetObject("lvwDirectories.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lvwDirectories.Size = CType(resources.GetObject("lvwDirectories.Size"), System.Drawing.Size)
        Me.lvwDirectories.TabIndex = CType(resources.GetObject("lvwDirectories.TabIndex"), Integer)
        Me.lvwDirectories.Text = resources.GetString("lvwDirectories.Text")
        Me.lvwDirectories.View = System.Windows.Forms.View.Details
        Me.lvwDirectories.Visible = CType(resources.GetObject("lvwDirectories.Visible"), Boolean)
        '
        'sbrScan
        '
        Me.sbrScan.AccessibleDescription = resources.GetString("sbrScan.AccessibleDescription")
        Me.sbrScan.AccessibleName = resources.GetString("sbrScan.AccessibleName")
        Me.sbrScan.Anchor = CType(resources.GetObject("sbrScan.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.sbrScan.BackgroundImage = CType(resources.GetObject("sbrScan.BackgroundImage"), System.Drawing.Image)
        Me.sbrScan.Dock = CType(resources.GetObject("sbrScan.Dock"), System.Windows.Forms.DockStyle)
        Me.sbrScan.Enabled = CType(resources.GetObject("sbrScan.Enabled"), Boolean)
        Me.sbrScan.Font = CType(resources.GetObject("sbrScan.Font"), System.Drawing.Font)
        Me.sbrScan.ImeMode = CType(resources.GetObject("sbrScan.ImeMode"), System.Windows.Forms.ImeMode)
        Me.sbrScan.Location = CType(resources.GetObject("sbrScan.Location"), System.Drawing.Point)
        Me.sbrScan.Name = "sbrScan"
        Me.sbrScan.RightToLeft = CType(resources.GetObject("sbrScan.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.sbrScan.Size = CType(resources.GetObject("sbrScan.Size"), System.Drawing.Size)
        Me.sbrScan.TabIndex = CType(resources.GetObject("sbrScan.TabIndex"), Integer)
        Me.sbrScan.Text = resources.GetString("sbrScan.Text")
        Me.sbrScan.Visible = CType(resources.GetObject("sbrScan.Visible"), Boolean)
        '
        'tvwDirectories
        '
        Me.tvwDirectories.AccessibleDescription = resources.GetString("tvwDirectories.AccessibleDescription")
        Me.tvwDirectories.AccessibleName = resources.GetString("tvwDirectories.AccessibleName")
        Me.tvwDirectories.Anchor = CType(resources.GetObject("tvwDirectories.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.tvwDirectories.BackgroundImage = CType(resources.GetObject("tvwDirectories.BackgroundImage"), System.Drawing.Image)
        Me.tvwDirectories.Dock = CType(resources.GetObject("tvwDirectories.Dock"), System.Windows.Forms.DockStyle)
        Me.tvwDirectories.Enabled = CType(resources.GetObject("tvwDirectories.Enabled"), Boolean)
        Me.tvwDirectories.Font = CType(resources.GetObject("tvwDirectories.Font"), System.Drawing.Font)
        Me.tvwDirectories.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tvwDirectories.ImageIndex = CType(resources.GetObject("tvwDirectories.ImageIndex"), Integer)
        Me.tvwDirectories.ImeMode = CType(resources.GetObject("tvwDirectories.ImeMode"), System.Windows.Forms.ImeMode)
        Me.tvwDirectories.Indent = CType(resources.GetObject("tvwDirectories.Indent"), Integer)
        Me.tvwDirectories.ItemHeight = CType(resources.GetObject("tvwDirectories.ItemHeight"), Integer)
        Me.tvwDirectories.Location = CType(resources.GetObject("tvwDirectories.Location"), System.Drawing.Point)
        Me.tvwDirectories.Name = "tvwDirectories"
        Me.tvwDirectories.RightToLeft = CType(resources.GetObject("tvwDirectories.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.tvwDirectories.SelectedImageIndex = CType(resources.GetObject("tvwDirectories.SelectedImageIndex"), Integer)
        Me.tvwDirectories.Size = CType(resources.GetObject("tvwDirectories.Size"), System.Drawing.Size)
        Me.tvwDirectories.TabIndex = CType(resources.GetObject("tvwDirectories.TabIndex"), Integer)
        Me.tvwDirectories.Text = resources.GetString("tvwDirectories.Text")
        Me.tvwDirectories.Visible = CType(resources.GetObject("tvwDirectories.Visible"), Boolean)
        '
        'Splitter1
        '
        Me.Splitter1.AccessibleDescription = resources.GetString("Splitter1.AccessibleDescription")
        Me.Splitter1.AccessibleName = resources.GetString("Splitter1.AccessibleName")
        Me.Splitter1.Anchor = CType(resources.GetObject("Splitter1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Splitter1.BackgroundImage = CType(resources.GetObject("Splitter1.BackgroundImage"), System.Drawing.Image)
        Me.Splitter1.Dock = CType(resources.GetObject("Splitter1.Dock"), System.Windows.Forms.DockStyle)
        Me.Splitter1.Enabled = CType(resources.GetObject("Splitter1.Enabled"), Boolean)
        Me.Splitter1.Font = CType(resources.GetObject("Splitter1.Font"), System.Drawing.Font)
        Me.Splitter1.ImeMode = CType(resources.GetObject("Splitter1.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Splitter1.Location = CType(resources.GetObject("Splitter1.Location"), System.Drawing.Point)
        Me.Splitter1.MinExtra = CType(resources.GetObject("Splitter1.MinExtra"), Integer)
        Me.Splitter1.MinSize = CType(resources.GetObject("Splitter1.MinSize"), Integer)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.RightToLeft = CType(resources.GetObject("Splitter1.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Splitter1.Size = CType(resources.GetObject("Splitter1.Size"), System.Drawing.Size)
        Me.Splitter1.TabIndex = CType(resources.GetObject("Splitter1.TabIndex"), Integer)
        Me.Splitter1.TabStop = False
        Me.Splitter1.Visible = CType(resources.GetObject("Splitter1.Visible"), Boolean)
        '
        'mnuFile
        '
        Me.mnuFile.Enabled = CType(resources.GetObject("mnuFile.Enabled"), Boolean)
        Me.mnuFile.Index = 0
        Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuExit})
        Me.mnuFile.Shortcut = CType(resources.GetObject("mnuFile.Shortcut"), System.Windows.Forms.Shortcut)
        Me.mnuFile.ShowShortcut = CType(resources.GetObject("mnuFile.ShowShortcut"), Boolean)
        Me.mnuFile.Text = resources.GetString("mnuFile.Text")
        Me.mnuFile.Visible = CType(resources.GetObject("mnuFile.Visible"), Boolean)
        '
        'mnuExit
        '
        Me.mnuExit.Enabled = CType(resources.GetObject("mnuExit.Enabled"), Boolean)
        Me.mnuExit.Index = 0
        Me.mnuExit.Shortcut = CType(resources.GetObject("mnuExit.Shortcut"), System.Windows.Forms.Shortcut)
        Me.mnuExit.ShowShortcut = CType(resources.GetObject("mnuExit.ShowShortcut"), Boolean)
        Me.mnuExit.Text = resources.GetString("mnuExit.Text")
        Me.mnuExit.Visible = CType(resources.GetObject("mnuExit.Visible"), Boolean)
        '
        'mnuScanAll
        '
        Me.mnuScanAll.Enabled = CType(resources.GetObject("mnuScanAll.Enabled"), Boolean)
        Me.mnuScanAll.Index = 0
        Me.mnuScanAll.Shortcut = CType(resources.GetObject("mnuScanAll.Shortcut"), System.Windows.Forms.Shortcut)
        Me.mnuScanAll.ShowShortcut = CType(resources.GetObject("mnuScanAll.ShowShortcut"), Boolean)
        Me.mnuScanAll.Text = resources.GetString("mnuScanAll.Text")
        Me.mnuScanAll.Visible = CType(resources.GetObject("mnuScanAll.Visible"), Boolean)
        '
        'mnuScanFromOne
        '
        Me.mnuScanFromOne.Enabled = CType(resources.GetObject("mnuScanFromOne.Enabled"), Boolean)
        Me.mnuScanFromOne.Index = 1
        Me.mnuScanFromOne.Shortcut = CType(resources.GetObject("mnuScanFromOne.Shortcut"), System.Windows.Forms.Shortcut)
        Me.mnuScanFromOne.ShowShortcut = CType(resources.GetObject("mnuScanFromOne.ShowShortcut"), Boolean)
        Me.mnuScanFromOne.Text = resources.GetString("mnuScanFromOne.Text")
        Me.mnuScanFromOne.Visible = CType(resources.GetObject("mnuScanFromOne.Visible"), Boolean)
        '
        'mnuScan
        '
        Me.mnuScan.Enabled = CType(resources.GetObject("mnuScan.Enabled"), Boolean)
        Me.mnuScan.Index = 1
        Me.mnuScan.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuScanAll, Me.mnuScanFromOne})
        Me.mnuScan.Shortcut = CType(resources.GetObject("mnuScan.Shortcut"), System.Windows.Forms.Shortcut)
        Me.mnuScan.ShowShortcut = CType(resources.GetObject("mnuScan.ShowShortcut"), Boolean)
        Me.mnuScan.Text = resources.GetString("mnuScan.Text")
        Me.mnuScan.Visible = CType(resources.GetObject("mnuScan.Visible"), Boolean)
        '
        'mnuMain
        '
        Me.mnuMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.mnuScan})
        Me.mnuMain.RightToLeft = CType(resources.GetObject("mnuMain.RightToLeft"), System.Windows.Forms.RightToLeft)
        '
        'DirectoryScanner
        '
        Me.AccessibleDescription = resources.GetString("$this.AccessibleDescription")
        Me.AccessibleName = resources.GetString("$this.AccessibleName")
        Me.Anchor = CType(resources.GetObject("$this.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.AutoScaleBaseSize = CType(resources.GetObject("$this.AutoScaleBaseSize"), System.Drawing.Size)
        Me.AutoScroll = CType(resources.GetObject("$this.AutoScroll"), Boolean)
        Me.AutoScrollMargin = CType(resources.GetObject("$this.AutoScrollMargin"), System.Drawing.Size)
        Me.AutoScrollMinSize = CType(resources.GetObject("$this.AutoScrollMinSize"), System.Drawing.Size)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = CType(resources.GetObject("$this.ClientSize"), System.Drawing.Size)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lvwDirectories, Me.Splitter1, Me.tvwDirectories, Me.sbrScan})
        Me.Dock = CType(resources.GetObject("$this.Dock"), System.Windows.Forms.DockStyle)
        Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
        Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Location = CType(resources.GetObject("$this.Location"), System.Drawing.Point)
        Me.MaximumSize = CType(resources.GetObject("$this.MaximumSize"), System.Drawing.Size)
        Me.Menu = Me.mnuMain
        Me.MinimumSize = CType(resources.GetObject("$this.MinimumSize"), System.Drawing.Size)
        Me.Name = "DirectoryScanner"
        Me.RightToLeft = CType(resources.GetObject("$this.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.StartPosition = CType(resources.GetObject("$this.StartPosition"), System.Windows.Forms.FormStartPosition)
        Me.Text = resources.GetString("$this.Text")
        Me.Visible = CType(resources.GetObject("$this.Visible"), Boolean)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Standard Menu Code "
    ' <System.Diagnostics.DebuggerStepThrough()> has been added to some procedures since they are
    ' not the focus of the demo. Remove them if you wish to debug the procedures.
    ' This code simply shows the About form.
    <System.Diagnostics.DebuggerStepThroughAttribute()> Private Sub mnuAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Open the About form in Dialog Mode
        Dim frm As New frmAbout()
        frm.ShowDialog(Me)
        frm.Dispose()
    End Sub

    ' This code will close the form.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
        ' Close the current form
        Me.Close()
    End Sub
#End Region

    Const MB As Long = 1024 * 1024

    ' Handles the Click event for the "Scan | All Directories" menu item.
    Private Sub mnuScanAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuScanAll.Click
        ' Get an array of all logical drives.
        Dim Drives As String() = Directory.GetLogicalDrives()
        Dim drive As String

        tvwDirectories.Nodes.Clear()
        lvwDirectories.Items.Clear()

        For Each drive In Drives
            Dim dnDrive As DirectoryNode

            Try
                ' Create a DirectoryNode that represents each logical drive and add
                ' it to the TreeView.
                dnDrive = New DirectoryNode()
                dnDrive.Text = drive.Remove(Len(drive) - 1, 1)
                tvwDirectories.Nodes.Add(dnDrive)

                ' Calculate the size of the drive by adding up the size of all its
                ' sub-directories.
                dnDrive.Size += GetDirectorySize(drive, dnDrive)
            Catch exc As Exception
                ' Do nothing. Simply skip any directories that can't be read. Control
                ' passes to the first line after End Try.
            End Try
        Next
    End Sub

    ' Handles the Click event for the "Scan | From One Directory" menu item.
    Private Sub mnuScanFromOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuScanFromOne.Click

        ' Show the FolderBrowser dialog and set the initial directory to the 
        ' user's selection.
        Dim strSelectedDirectory As String = FolderBrowser.ShowDialog()
        Dim dnSelectedDirectory As DirectoryNode

        tvwDirectories.Nodes.Clear()
        lvwDirectories.Items.Clear()

        Try
            ' Add the DirectoryNode that represents the selected directory to the
            ' TreeView.
            dnSelectedDirectory = New DirectoryNode()
            dnSelectedDirectory.Text = strSelectedDirectory
            tvwDirectories.Nodes.Add(dnSelectedDirectory)

            ' Calculate the size of the selected directory by adding up the size of 
            ' all its sub-directories.
            dnSelectedDirectory.Size += GetDirectorySize(strSelectedDirectory, _
                dnSelectedDirectory)

        Catch exc As Exception
            ' Do nothing. Simply skip any directories that can't be read. Control
            ' passes to the first line after End Try.
        End Try

    End Sub

    ' Handles the Load event for the DirectoryScanner.
    Private Sub DirectoryScanner_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set up the initial ListView columns
        lvwDirectories.Columns.Add("Size", 90, HorizontalAlignment.Left)
        lvwDirectories.Columns.Add("Folder Name", 400, HorizontalAlignment.Left)
    End Sub

    ' Handles the AfterExpand event for the TreeView, which does not occur after 
    ' the TreeView is selected, but after the application decides that the user's 
    ' attempt to expand the node should be allowed. The corresponding BeforeExpand 
    ' event handler is used for this decision making, if desired. All Before______
    ' events pass a TreeViewCancelEventArgs object that contains a Cancel property.
    ' This property can be used for vetoing the user's action. Thus, the "AfterExpand"
    ' event could rightly be named "AfterExpandApproval".
    Private Sub TreeView_AfterExpand(ByVal sender As Object, ByVal e As TreeViewEventArgs) Handles tvwDirectories.AfterExpand
        e.Node.Expand()
        ShowSubDirectories(CType(e.Node, DirectoryNode))
    End Sub

    ' Handles the AfterSelect event for the TreeView, which does not occur after 
    ' the TreeView is selected, but after the application decides that the user's 
    ' attempt to select the node should be allowed. The corresponding BeforeSelect 
    ' event handler is used for this decision making, if desired. All Before______
    ' events pass a TreeViewCancelEventArgs object that contains a Cancel property.
    ' This property can be used for vetoing the user's action. Thus, the "AfterSelect"
    ' event could rightly be named "AfterSelectApproval".
    Private Sub TreeView_AfterSelect(ByVal sender As Object, ByVal e As TreeViewEventArgs) Handles tvwDirectories.AfterSelect
        Dim strSubDirectory As DirectoryNode = CType(e.Node, DirectoryNode)

        lvwDirectories.Items.Clear()

        AddToListView(Format(strSubDirectory.Size / (1024 * 1024), "F") + "MB", _
            strSubDirectory.Text)
    End Sub

    ' This subroutine adds the strSubDirectory that the user selects on the TreeView 
    ' to the ListView, and sets the text, size, and color.
    Private Sub AddToListView(ByVal strSize As String, ByVal strFolderName As String)
        Dim lvi As New ListViewItem()
        Dim lvsi As ListViewItem.ListViewSubItem

        lvi.Text = strSize
        lvi.ForeColor = GetSizeColor(strSize)

        lvsi = New ListViewItem.ListViewSubItem()
        lvsi.Text = strFolderName

        lvi.SubItems.Add(lvsi)
        lvwDirectories.Items.Add(lvi)
    End Sub

    ' This subroutine returns a Color based on the combined size of the directory 
    ' and all its subdirectories. This is one of two overloads.
    Private Function GetSizeColor(ByVal strSize As String) As System.Drawing.Color
        Return GetSizeColor(CLng(CDbl(strSize.Substring(0, _
            strSize.LastIndexOf("M") - 1)) * MB))
    End Function

    ' This function returns a Color based on the combined size of the directory 
    ' and all its subdirectories. This is the second of two overloads.
    Private Function GetSizeColor(ByVal intSize As Long) As System.Drawing.Color
        Select Case intSize
            Case 200 * MB To 500 * MB
                Return System.Drawing.Color.Gold
            Case Is > 500 * MB
                Return System.Drawing.Color.Red
            Case Else
                Return System.Drawing.Color.Green
        End Select
    End Function

    ' This function returns the size of a directory, and all its sub-directories.
    Public Function GetDirectorySize(ByVal strDirPath As String, _
        ByVal dnDriveOrDirectory As DirectoryNode) As Long

        ' Show the current scan directory in the status bar.
        sbrScan.Text = "Scanning : " + strDirPath

        Try
            Dim astrSubDirectories As String() = Directory.GetDirectories(strDirPath)
            Dim strSubDirectory As String

            ' The size of the current directory is dependent on the size 
            ' of the sub-directories in the array astrSubDirectories. So iterate
            ' through the array and use recursion to end up with the total
            ' size of the current directory and all its sub-directories.
            For Each strSubDirectory In astrSubDirectories
                Dim dnSubDirectoryNode As DirectoryNode
                dnSubDirectoryNode = New DirectoryNode()

                ' Set the node text = to only the last part of the full path.
                dnSubDirectoryNode.Text = _
                    strSubDirectory.Remove(0, strSubDirectory.LastIndexOf("\") + 1)

                ' Note that the following line is recursive.
                dnDriveOrDirectory.Size += _
                    GetDirectorySize(strSubDirectory, dnSubDirectoryNode)
                dnDriveOrDirectory.Nodes.Add(dnSubDirectoryNode)
            Next

            ' Add to the size calcutate above all of the files in the current 
            ' directory.
            Dim astrFiles As String() = Directory.GetFiles(strDirPath)
            Dim strFileName As String
            Dim Size As Long = 0

            For Each strFileName In astrFiles
                dnDriveOrDirectory.Size += New FileInfo(strFileName).Length
            Next

            ' Set the color of the TreeNode based on the total calculated size.
            dnDriveOrDirectory.ForeColor = _
                GetSizeColor(dnDriveOrDirectory.Size)

        Catch exc As Exception
            ' Do nothing. Simply skip any directories that can't be read. Control
            ' passes to the first line after End Try.
        End Try

        ' Reset the StatusBar and Return the total size for this directory.
        sbrScan.Text = ""
        Return dnDriveOrDirectory.Size

    End Function

    ' When a directory node is expanded, add its subdirectories to the ListView.
    Public Sub ShowSubDirectories(ByVal dnDrive As DirectoryNode)
        Dim strSubDirectory As DirectoryNode

        lvwDirectories.Items.Clear()

        For Each strSubDirectory In dnDrive.Nodes
            AddToListView(Format(strSubDirectory.Size / MB, "F") + "MB", _
                strSubDirectory.Text)
        Next
    End Sub

End Class
