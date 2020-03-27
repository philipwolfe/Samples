'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Imports System.IO

Public Class ExplorerStyleViewer
    Inherits System.Windows.Forms.Form

    ' Declare variables to hold instances of each of the custom classes
    Private dtvwDirectory As DirectoryTreeView
    Private flvFiles As FileListView
    Private mivChecked As MenuItemView

#Region " Windows Form Designer generated code. NOTE: Sub New() altered for the How To."

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        ' End default How To code. Begin code added for this particular How To...

        ' Create a flvFilesView instance.
        flvFiles = New FileListView()
        flvFiles.Parent = Me
        flvFiles.Dock = DockStyle.Fill

        ' Create a Splitter instance.
        Dim split As New Splitter()
        split.Parent = Me
        split.Dock = DockStyle.Left
        split.BackColor = SystemColors.Control

        ' Create a DirectoryTreeView instance and add an OnAfterSelect event handler.
        dtvwDirectory = New DirectoryTreeView()
        dtvwDirectory.Parent = Me
        dtvwDirectory.Dock = DockStyle.Left
        ' Dynamically add an AfterSelect event handler.
        AddHandler dtvwDirectory.AfterSelect, _
            AddressOf DirectoryTreeViewOnAfterSelect

        ' Add a View menu command to the existing main menu.
        Dim mnuView As New MenuItem("&View")
        mnuView.Index = 1
        Me.mnuMain.MenuItems.Add(mnuView)

        ' Add four menu items to the new View menu. Start by creating arrays to set
        ' properties of each menu item.
        Dim astrView As String() = {"Lar&ge Icons", "S&mall Icons", "&List", "&Details"}
        Dim aview As View() = {View.LargeIcon, View.SmallIcon, View.List, View.Details}
        ' Create an event handler for the menu items.
        Dim eh As New EventHandler(AddressOf MenuOnViewSelect)

        Dim i As Integer
        For i = 0 To 3
            ' Use a custom class MenuItemView, which extends MenuItem to support a 
            ' View property.
            Dim miv As New MenuItemView()
            miv.Text = astrView(i)
            miv.View = aview(i)
            miv.RadioCheck = True
            ' Associate the handler created earlier with the Click event.
            AddHandler miv.Click, eh

            ' Set the Default view to Details.
            If i = 3 Then
                mivChecked = miv
                mivChecked.Checked = True
                flvFiles.View = mivChecked.View
            End If
            ' Add the new menu item to the View menu.
            mnuView.MenuItems.Add(miv)
        Next i

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
    Friend WithEvents mnuMain As System.Windows.Forms.MainMenu
    Friend WithEvents mnuFile As System.Windows.Forms.MenuItem
    Friend WithEvents mnuExit As System.Windows.Forms.MenuItem
    Friend WithEvents lblDevNote As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ExplorerStyleViewer))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.lblDevNote = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'mnuMain
        '
        Me.mnuMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile})
        Me.mnuMain.RightToLeft = CType(resources.GetObject("mnuMain.RightToLeft"), System.Windows.Forms.RightToLeft)
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
        'lblDevNote
        '
        Me.lblDevNote.AccessibleDescription = CType(resources.GetObject("lblDevNote.AccessibleDescription"), String)
        Me.lblDevNote.AccessibleName = CType(resources.GetObject("lblDevNote.AccessibleName"), String)
        Me.lblDevNote.Anchor = CType(resources.GetObject("lblDevNote.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblDevNote.AutoSize = CType(resources.GetObject("lblDevNote.AutoSize"), Boolean)
        Me.lblDevNote.Dock = CType(resources.GetObject("lblDevNote.Dock"), System.Windows.Forms.DockStyle)
        Me.lblDevNote.Enabled = CType(resources.GetObject("lblDevNote.Enabled"), Boolean)
        Me.lblDevNote.Font = CType(resources.GetObject("lblDevNote.Font"), System.Drawing.Font)
        Me.lblDevNote.Image = CType(resources.GetObject("lblDevNote.Image"), System.Drawing.Image)
        Me.lblDevNote.ImageAlign = CType(resources.GetObject("lblDevNote.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblDevNote.ImageIndex = CType(resources.GetObject("lblDevNote.ImageIndex"), Integer)
        Me.lblDevNote.ImeMode = CType(resources.GetObject("lblDevNote.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblDevNote.Location = CType(resources.GetObject("lblDevNote.Location"), System.Drawing.Point)
        Me.lblDevNote.Name = "lblDevNote"
        Me.lblDevNote.RightToLeft = CType(resources.GetObject("lblDevNote.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblDevNote.Size = CType(resources.GetObject("lblDevNote.Size"), System.Drawing.Size)
        Me.lblDevNote.TabIndex = CType(resources.GetObject("lblDevNote.TabIndex"), Integer)
        Me.lblDevNote.Text = resources.GetString("lblDevNote.Text")
        Me.lblDevNote.TextAlign = CType(resources.GetObject("lblDevNote.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblDevNote.Visible = CType(resources.GetObject("lblDevNote.Visible"), Boolean)
        '
        'ExplorerStyleViewer
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
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblDevNote})
        Me.Dock = CType(resources.GetObject("$this.Dock"), System.Windows.Forms.DockStyle)
        Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
        Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Location = CType(resources.GetObject("$this.Location"), System.Drawing.Point)
        Me.MaximumSize = CType(resources.GetObject("$this.MaximumSize"), System.Drawing.Size)
        Me.Menu = Me.mnuMain
        Me.MinimumSize = CType(resources.GetObject("$this.MinimumSize"), System.Drawing.Size)
        Me.Name = "ExplorerStyleViewer"
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

    ' Handles the AfterSelect event for the DirectoryTreeView, which causes the
    ' FileListView object to display the contents of the selected directory.
    Sub DirectoryTreeViewOnAfterSelect(ByVal obj As Object, ByVal tvea As TreeViewEventArgs)
        flvFiles.ShowFiles(tvea.Node.FullPath)
    End Sub

    ' This subroutine handles the Form Load event.
    Private Sub ExplorerStyleViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Turn off the developer note that is only for when viewing the Form in 
        ' Design View.
        lblDevNote.Visible = False
    End Sub

    ' Handles the OnViewSelect event for the View menu items.
    Sub MenuOnViewSelect(ByVal obj As Object, ByVal ea As EventArgs)
        ' Uncheck the currently checked item.
        mivChecked.Checked = False
        ' Cast the event sender and check it.
        mivChecked = CType(obj, MenuItemView)
        mivChecked.Checked = True
        ' Change how the files are viewed in the FileListView control.
        flvFiles.View = mivChecked.View
    End Sub

End Class
