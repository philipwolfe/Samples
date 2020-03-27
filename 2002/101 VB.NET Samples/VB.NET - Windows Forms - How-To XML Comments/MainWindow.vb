'*****************************************************************************
' Copyright (C) 1999-2002, Microsoft Corporation.  All Rights Reserved.
'*****************************************************************************

Option Explicit On 
Option Compare Text

Imports Microsoft.VisualBasic
Imports System
Imports System.Reflection
Imports System.Diagnostics
Imports System.Collections
Imports System.Drawing
Imports System.Windows.Forms

Public Class MainWindow : Inherits Form
    ' The main user interface window.

    Public Const WINDOW_TITLE As String = "XML Documentation Tool"
    Public Const SAVE_MESSAGE As String = "Do you want to save changes to the current XML Documentation file?"

    ' these constants are used to look up data in the registry
    Public Const APPNAME As String = WINDOW_TITLE           ' the application name
    Public Const HISTORYFILES As String = "History Files"   ' the registry group for history files

    Private m_Doc As MainDoc                        'The core engine instance.
    Private m_AsmFileName As String                 'The filename of the assembly.
    Private m_XMLFileName As String                 'The filename of the XML Documentation file.
    Private m_CopyNode As MemberNode                'Store the node copied

    Private WithEvents m_FindDialog As FindDialog   'The Find dialog instance.


#Region " Windows Form Designer generated code"

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
        If Not (components Is Nothing) Then
            components.Dispose()
        End If
    End Sub

    Public WithEvents MdiClient As System.Windows.Forms.MdiClient
    Public WithEvents TreeView As XMLDocumentationTool.AssemblyTreeView
    Public WithEvents ErrorWindow As XMLDocumentationTool.ErrorWindow
    Private WithEvents StatusPanelErrorInformation As System.Windows.Forms.StatusBarPanel
    Private WithEvents MenuEdit As System.Windows.Forms.MenuItem
    Private WithEvents MenuEditCut As System.Windows.Forms.MenuItem
    Private WithEvents MenuEditCopy As System.Windows.Forms.MenuItem
    Private WithEvents MenuEditPaste As System.Windows.Forms.MenuItem
    Private WithEvents MenuEditSplitter1 As System.Windows.Forms.MenuItem
    Private WithEvents MenuEditSplitter2 As System.Windows.Forms.MenuItem
    Private WithEvents MenuEditFind As System.Windows.Forms.MenuItem
    Private WithEvents MenuFileSaveAs As System.Windows.Forms.MenuItem
    Private WithEvents MenuFileExit As System.Windows.Forms.MenuItem
    Private WithEvents MenuFileOpenXML As System.Windows.Forms.MenuItem
    Private WithEvents MenuFileSave As System.Windows.Forms.MenuItem
    Private WithEvents MainSplitter As System.Windows.Forms.Splitter
    Private WithEvents MainMenu As System.Windows.Forms.MainMenu
    Private WithEvents MenuFile As System.Windows.Forms.MenuItem
    Private WithEvents MenuFileSplitter As System.Windows.Forms.MenuItem
    Private WithEvents MenuView As System.Windows.Forms.MenuItem
    Private WithEvents MenuViewExpandAll As System.Windows.Forms.MenuItem
    Private WithEvents MenuViewCollapseAll As System.Windows.Forms.MenuItem
    Private WithEvents MenuViewShowErrorWindow As System.Windows.Forms.MenuItem
    Private WithEvents MenuWindow As System.Windows.Forms.MenuItem
    Private WithEvents MenuWindowCascade As System.Windows.Forms.MenuItem
    Private WithEvents MenuWindowTile As System.Windows.Forms.MenuItem
    Private WithEvents MenuWindowArrangeIcons As System.Windows.Forms.MenuItem
    Private WithEvents MenuWindowCloseAll As System.Windows.Forms.MenuItem
    Private WithEvents MainStatusBar As System.Windows.Forms.StatusBar
    Private WithEvents StatusPanelAction As System.Windows.Forms.StatusBarPanel
    Private WithEvents TreeViewContextMenu As System.Windows.Forms.ContextMenu
    Private WithEvents TreeViewContextMenuOpen As System.Windows.Forms.MenuItem
    Private WithEvents MenuViewSplitter As System.Windows.Forms.MenuItem
    Private WithEvents ErrorPanelSplitter As System.Windows.Forms.Splitter
    Private WithEvents ImageList As System.Windows.Forms.ImageList
    Private WithEvents ErrorPanel As System.Windows.Forms.Panel
    Private WithEvents ErrorWindowTitle As System.Windows.Forms.Label
    Private WithEvents MenuEditDeleteAllXMLNodes As System.Windows.Forms.MenuItem
    Private WithEvents MenuViewVersionInfo As System.Windows.Forms.MenuItem
    Private WithEvents MenuFileOpen As System.Windows.Forms.MenuItem

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents MenuEditDeleteError As System.Windows.Forms.MenuItem
    Private WithEvents MenuEditClearNode As System.Windows.Forms.MenuItem
    Private WithEvents TreeViewContextMenuClear As System.Windows.Forms.MenuItem
    Private WithEvents MenuHelpMenu As System.Windows.Forms.MenuItem
    Friend WithEvents MenuHelp As System.Windows.Forms.MenuItem
    Friend WithEvents MenuHelpAbout As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(MainWindow))
        Me.MdiClient = New System.Windows.Forms.MdiClient()
        Me.MainStatusBar = New System.Windows.Forms.StatusBar()
        Me.StatusPanelAction = New System.Windows.Forms.StatusBarPanel()
        Me.StatusPanelErrorInformation = New System.Windows.Forms.StatusBarPanel()
        Me.MenuEdit = New System.Windows.Forms.MenuItem()
        Me.MenuEditCut = New System.Windows.Forms.MenuItem()
        Me.MenuEditCopy = New System.Windows.Forms.MenuItem()
        Me.MenuEditPaste = New System.Windows.Forms.MenuItem()
        Me.MenuEditSplitter1 = New System.Windows.Forms.MenuItem()
        Me.MenuEditClearNode = New System.Windows.Forms.MenuItem()
        Me.MenuEditDeleteAllXMLNodes = New System.Windows.Forms.MenuItem()
        Me.MenuEditDeleteError = New System.Windows.Forms.MenuItem()
        Me.MenuEditSplitter2 = New System.Windows.Forms.MenuItem()
        Me.MenuEditFind = New System.Windows.Forms.MenuItem()
        Me.TreeView = New XMLDocumentationTool.AssemblyTreeView()
        Me.TreeViewContextMenu = New System.Windows.Forms.ContextMenu()
        Me.TreeViewContextMenuOpen = New System.Windows.Forms.MenuItem()
        Me.TreeViewContextMenuClear = New System.Windows.Forms.MenuItem()
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.MenuFileSaveAs = New System.Windows.Forms.MenuItem()
        Me.MenuFileExit = New System.Windows.Forms.MenuItem()
        Me.MenuFileOpenXML = New System.Windows.Forms.MenuItem()
        Me.MenuFileSave = New System.Windows.Forms.MenuItem()
        Me.MainSplitter = New System.Windows.Forms.Splitter()
        Me.MainMenu = New System.Windows.Forms.MainMenu()
        Me.MenuFile = New System.Windows.Forms.MenuItem()
        Me.MenuFileOpen = New System.Windows.Forms.MenuItem()
        Me.MenuFileSplitter = New System.Windows.Forms.MenuItem()
        Me.MenuView = New System.Windows.Forms.MenuItem()
        Me.MenuViewExpandAll = New System.Windows.Forms.MenuItem()
        Me.MenuViewCollapseAll = New System.Windows.Forms.MenuItem()
        Me.MenuViewSplitter = New System.Windows.Forms.MenuItem()
        Me.MenuViewShowErrorWindow = New System.Windows.Forms.MenuItem()
        Me.MenuViewVersionInfo = New System.Windows.Forms.MenuItem()
        Me.MenuWindow = New System.Windows.Forms.MenuItem()
        Me.MenuWindowCascade = New System.Windows.Forms.MenuItem()
        Me.MenuWindowTile = New System.Windows.Forms.MenuItem()
        Me.MenuWindowArrangeIcons = New System.Windows.Forms.MenuItem()
        Me.MenuWindowCloseAll = New System.Windows.Forms.MenuItem()
        Me.MenuHelpMenu = New System.Windows.Forms.MenuItem()
        Me.MenuHelp = New System.Windows.Forms.MenuItem()
        Me.MenuHelpAbout = New System.Windows.Forms.MenuItem()
        Me.ErrorPanel = New System.Windows.Forms.Panel()
        Me.ErrorWindow = New XMLDocumentationTool.ErrorWindow()
        Me.ErrorPanelSplitter = New System.Windows.Forms.Splitter()
        Me.ErrorWindowTitle = New System.Windows.Forms.Label()
        CType(Me.StatusPanelAction, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusPanelErrorInformation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ErrorPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'MdiClient
        '
        Me.MdiClient.AccessibleDescription = CType(resources.GetObject("MdiClient.AccessibleDescription"), String)
        Me.MdiClient.AccessibleName = CType(resources.GetObject("MdiClient.AccessibleName"), String)
        Me.MdiClient.Anchor = CType(resources.GetObject("MdiClient.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.MdiClient.BackgroundImage = CType(resources.GetObject("MdiClient.BackgroundImage"), System.Drawing.Image)
        Me.MdiClient.Dock = CType(resources.GetObject("MdiClient.Dock"), System.Windows.Forms.DockStyle)
        Me.MdiClient.Enabled = CType(resources.GetObject("MdiClient.Enabled"), Boolean)
        Me.MdiClient.Font = CType(resources.GetObject("MdiClient.Font"), System.Drawing.Font)
        Me.MdiClient.ImeMode = CType(resources.GetObject("MdiClient.ImeMode"), System.Windows.Forms.ImeMode)
        Me.MdiClient.Location = CType(resources.GetObject("MdiClient.Location"), System.Drawing.Point)
        Me.MdiClient.Name = "MdiClient"
        Me.MdiClient.RightToLeft = CType(resources.GetObject("MdiClient.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.MdiClient.Size = CType(resources.GetObject("MdiClient.Size"), System.Drawing.Size)
        Me.MdiClient.TabIndex = CType(resources.GetObject("MdiClient.TabIndex"), Integer)
        Me.MdiClient.Text = resources.GetString("MdiClient.Text")
        Me.MdiClient.Visible = CType(resources.GetObject("MdiClient.Visible"), Boolean)
        '
        'MainStatusBar
        '
        Me.MainStatusBar.AccessibleDescription = CType(resources.GetObject("MainStatusBar.AccessibleDescription"), String)
        Me.MainStatusBar.AccessibleName = CType(resources.GetObject("MainStatusBar.AccessibleName"), String)
        Me.MainStatusBar.Anchor = CType(resources.GetObject("MainStatusBar.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.MainStatusBar.BackgroundImage = CType(resources.GetObject("MainStatusBar.BackgroundImage"), System.Drawing.Image)
        Me.MainStatusBar.Dock = CType(resources.GetObject("MainStatusBar.Dock"), System.Windows.Forms.DockStyle)
        Me.MainStatusBar.Enabled = CType(resources.GetObject("MainStatusBar.Enabled"), Boolean)
        Me.MainStatusBar.Font = CType(resources.GetObject("MainStatusBar.Font"), System.Drawing.Font)
        Me.MainStatusBar.ImeMode = CType(resources.GetObject("MainStatusBar.ImeMode"), System.Windows.Forms.ImeMode)
        Me.MainStatusBar.Location = CType(resources.GetObject("MainStatusBar.Location"), System.Drawing.Point)
        Me.MainStatusBar.Name = "MainStatusBar"
        Me.MainStatusBar.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusPanelAction, Me.StatusPanelErrorInformation})
        Me.MainStatusBar.RightToLeft = CType(resources.GetObject("MainStatusBar.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.MainStatusBar.ShowPanels = True
        Me.MainStatusBar.Size = CType(resources.GetObject("MainStatusBar.Size"), System.Drawing.Size)
        Me.MainStatusBar.TabIndex = CType(resources.GetObject("MainStatusBar.TabIndex"), Integer)
        Me.MainStatusBar.Text = resources.GetString("MainStatusBar.Text")
        Me.MainStatusBar.Visible = CType(resources.GetObject("MainStatusBar.Visible"), Boolean)
        '
        'StatusPanelAction
        '
        Me.StatusPanelAction.Alignment = CType(resources.GetObject("StatusPanelAction.Alignment"), System.Windows.Forms.HorizontalAlignment)
        Me.StatusPanelAction.Icon = CType(resources.GetObject("StatusPanelAction.Icon"), System.Drawing.Icon)
        Me.StatusPanelAction.MinWidth = CType(resources.GetObject("StatusPanelAction.MinWidth"), Integer)
        Me.StatusPanelAction.Text = resources.GetString("StatusPanelAction.Text")
        Me.StatusPanelAction.ToolTipText = resources.GetString("StatusPanelAction.ToolTipText")
        Me.StatusPanelAction.Width = CType(resources.GetObject("StatusPanelAction.Width"), Integer)
        '
        'StatusPanelErrorInformation
        '
        Me.StatusPanelErrorInformation.Alignment = CType(resources.GetObject("StatusPanelErrorInformation.Alignment"), System.Windows.Forms.HorizontalAlignment)
        Me.StatusPanelErrorInformation.Icon = CType(resources.GetObject("StatusPanelErrorInformation.Icon"), System.Drawing.Icon)
        Me.StatusPanelErrorInformation.MinWidth = CType(resources.GetObject("StatusPanelErrorInformation.MinWidth"), Integer)
        Me.StatusPanelErrorInformation.Text = resources.GetString("StatusPanelErrorInformation.Text")
        Me.StatusPanelErrorInformation.ToolTipText = resources.GetString("StatusPanelErrorInformation.ToolTipText")
        Me.StatusPanelErrorInformation.Width = CType(resources.GetObject("StatusPanelErrorInformation.Width"), Integer)
        '
        'MenuEdit
        '
        Me.MenuEdit.Enabled = CType(resources.GetObject("MenuEdit.Enabled"), Boolean)
        Me.MenuEdit.Index = 1
        Me.MenuEdit.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuEditCut, Me.MenuEditCopy, Me.MenuEditPaste, Me.MenuEditSplitter1, Me.MenuEditClearNode, Me.MenuEditDeleteAllXMLNodes, Me.MenuEditDeleteError, Me.MenuEditSplitter2, Me.MenuEditFind})
        Me.MenuEdit.Shortcut = CType(resources.GetObject("MenuEdit.Shortcut"), System.Windows.Forms.Shortcut)
        Me.MenuEdit.ShowShortcut = CType(resources.GetObject("MenuEdit.ShowShortcut"), Boolean)
        Me.MenuEdit.Text = resources.GetString("MenuEdit.Text")
        Me.MenuEdit.Visible = CType(resources.GetObject("MenuEdit.Visible"), Boolean)
        '
        'MenuEditCut
        '
        Me.MenuEditCut.Enabled = CType(resources.GetObject("MenuEditCut.Enabled"), Boolean)
        Me.MenuEditCut.Index = 0
        Me.MenuEditCut.Shortcut = CType(resources.GetObject("MenuEditCut.Shortcut"), System.Windows.Forms.Shortcut)
        Me.MenuEditCut.ShowShortcut = CType(resources.GetObject("MenuEditCut.ShowShortcut"), Boolean)
        Me.MenuEditCut.Text = resources.GetString("MenuEditCut.Text")
        Me.MenuEditCut.Visible = CType(resources.GetObject("MenuEditCut.Visible"), Boolean)
        '
        'MenuEditCopy
        '
        Me.MenuEditCopy.Enabled = CType(resources.GetObject("MenuEditCopy.Enabled"), Boolean)
        Me.MenuEditCopy.Index = 1
        Me.MenuEditCopy.Shortcut = CType(resources.GetObject("MenuEditCopy.Shortcut"), System.Windows.Forms.Shortcut)
        Me.MenuEditCopy.ShowShortcut = CType(resources.GetObject("MenuEditCopy.ShowShortcut"), Boolean)
        Me.MenuEditCopy.Text = resources.GetString("MenuEditCopy.Text")
        Me.MenuEditCopy.Visible = CType(resources.GetObject("MenuEditCopy.Visible"), Boolean)
        '
        'MenuEditPaste
        '
        Me.MenuEditPaste.Enabled = CType(resources.GetObject("MenuEditPaste.Enabled"), Boolean)
        Me.MenuEditPaste.Index = 2
        Me.MenuEditPaste.Shortcut = CType(resources.GetObject("MenuEditPaste.Shortcut"), System.Windows.Forms.Shortcut)
        Me.MenuEditPaste.ShowShortcut = CType(resources.GetObject("MenuEditPaste.ShowShortcut"), Boolean)
        Me.MenuEditPaste.Text = resources.GetString("MenuEditPaste.Text")
        Me.MenuEditPaste.Visible = CType(resources.GetObject("MenuEditPaste.Visible"), Boolean)
        '
        'MenuEditSplitter1
        '
        Me.MenuEditSplitter1.Enabled = CType(resources.GetObject("MenuEditSplitter1.Enabled"), Boolean)
        Me.MenuEditSplitter1.Index = 3
        Me.MenuEditSplitter1.Shortcut = CType(resources.GetObject("MenuEditSplitter1.Shortcut"), System.Windows.Forms.Shortcut)
        Me.MenuEditSplitter1.ShowShortcut = CType(resources.GetObject("MenuEditSplitter1.ShowShortcut"), Boolean)
        Me.MenuEditSplitter1.Text = resources.GetString("MenuEditSplitter1.Text")
        Me.MenuEditSplitter1.Visible = CType(resources.GetObject("MenuEditSplitter1.Visible"), Boolean)
        '
        'MenuEditClearNode
        '
        Me.MenuEditClearNode.Enabled = CType(resources.GetObject("MenuEditClearNode.Enabled"), Boolean)
        Me.MenuEditClearNode.Index = 4
        Me.MenuEditClearNode.Shortcut = CType(resources.GetObject("MenuEditClearNode.Shortcut"), System.Windows.Forms.Shortcut)
        Me.MenuEditClearNode.ShowShortcut = CType(resources.GetObject("MenuEditClearNode.ShowShortcut"), Boolean)
        Me.MenuEditClearNode.Text = resources.GetString("MenuEditClearNode.Text")
        Me.MenuEditClearNode.Visible = CType(resources.GetObject("MenuEditClearNode.Visible"), Boolean)
        '
        'MenuEditDeleteAllXMLNodes
        '
        Me.MenuEditDeleteAllXMLNodes.Enabled = CType(resources.GetObject("MenuEditDeleteAllXMLNodes.Enabled"), Boolean)
        Me.MenuEditDeleteAllXMLNodes.Index = 5
        Me.MenuEditDeleteAllXMLNodes.Shortcut = CType(resources.GetObject("MenuEditDeleteAllXMLNodes.Shortcut"), System.Windows.Forms.Shortcut)
        Me.MenuEditDeleteAllXMLNodes.ShowShortcut = CType(resources.GetObject("MenuEditDeleteAllXMLNodes.ShowShortcut"), Boolean)
        Me.MenuEditDeleteAllXMLNodes.Text = resources.GetString("MenuEditDeleteAllXMLNodes.Text")
        Me.MenuEditDeleteAllXMLNodes.Visible = CType(resources.GetObject("MenuEditDeleteAllXMLNodes.Visible"), Boolean)
        '
        'MenuEditDeleteError
        '
        Me.MenuEditDeleteError.Enabled = CType(resources.GetObject("MenuEditDeleteError.Enabled"), Boolean)
        Me.MenuEditDeleteError.Index = 6
        Me.MenuEditDeleteError.Shortcut = CType(resources.GetObject("MenuEditDeleteError.Shortcut"), System.Windows.Forms.Shortcut)
        Me.MenuEditDeleteError.ShowShortcut = CType(resources.GetObject("MenuEditDeleteError.ShowShortcut"), Boolean)
        Me.MenuEditDeleteError.Text = resources.GetString("MenuEditDeleteError.Text")
        Me.MenuEditDeleteError.Visible = CType(resources.GetObject("MenuEditDeleteError.Visible"), Boolean)
        '
        'MenuEditSplitter2
        '
        Me.MenuEditSplitter2.Enabled = CType(resources.GetObject("MenuEditSplitter2.Enabled"), Boolean)
        Me.MenuEditSplitter2.Index = 7
        Me.MenuEditSplitter2.Shortcut = CType(resources.GetObject("MenuEditSplitter2.Shortcut"), System.Windows.Forms.Shortcut)
        Me.MenuEditSplitter2.ShowShortcut = CType(resources.GetObject("MenuEditSplitter2.ShowShortcut"), Boolean)
        Me.MenuEditSplitter2.Text = resources.GetString("MenuEditSplitter2.Text")
        Me.MenuEditSplitter2.Visible = CType(resources.GetObject("MenuEditSplitter2.Visible"), Boolean)
        '
        'MenuEditFind
        '
        Me.MenuEditFind.Enabled = CType(resources.GetObject("MenuEditFind.Enabled"), Boolean)
        Me.MenuEditFind.Index = 8
        Me.MenuEditFind.Shortcut = CType(resources.GetObject("MenuEditFind.Shortcut"), System.Windows.Forms.Shortcut)
        Me.MenuEditFind.ShowShortcut = CType(resources.GetObject("MenuEditFind.ShowShortcut"), Boolean)
        Me.MenuEditFind.Text = resources.GetString("MenuEditFind.Text")
        Me.MenuEditFind.Visible = CType(resources.GetObject("MenuEditFind.Visible"), Boolean)
        '
        'TreeView
        '
        Me.TreeView.AccessibleDescription = CType(resources.GetObject("TreeView.AccessibleDescription"), String)
        Me.TreeView.AccessibleName = CType(resources.GetObject("TreeView.AccessibleName"), String)
        Me.TreeView.AllowDrop = True
        Me.TreeView.Anchor = CType(resources.GetObject("TreeView.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.TreeView.BackgroundImage = CType(resources.GetObject("TreeView.BackgroundImage"), System.Drawing.Image)
        Me.TreeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TreeView.ContextMenu = Me.TreeViewContextMenu
        Me.TreeView.Dock = CType(resources.GetObject("TreeView.Dock"), System.Windows.Forms.DockStyle)
        Me.TreeView.Enabled = CType(resources.GetObject("TreeView.Enabled"), Boolean)
        Me.TreeView.Font = CType(resources.GetObject("TreeView.Font"), System.Drawing.Font)
        Me.TreeView.HideSelection = False
        Me.TreeView.ImageIndex = CType(resources.GetObject("TreeView.ImageIndex"), Integer)
        Me.TreeView.ImageList = Me.ImageList
        Me.TreeView.ImeMode = CType(resources.GetObject("TreeView.ImeMode"), System.Windows.Forms.ImeMode)
        Me.TreeView.Indent = CType(resources.GetObject("TreeView.Indent"), Integer)
        Me.TreeView.ItemHeight = CType(resources.GetObject("TreeView.ItemHeight"), Integer)
        Me.TreeView.Location = CType(resources.GetObject("TreeView.Location"), System.Drawing.Point)
        Me.TreeView.Name = "TreeView"
        Me.TreeView.RightToLeft = CType(resources.GetObject("TreeView.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.TreeView.SelectedImageIndex = CType(resources.GetObject("TreeView.SelectedImageIndex"), Integer)
        Me.TreeView.Size = CType(resources.GetObject("TreeView.Size"), System.Drawing.Size)
        Me.TreeView.Sorted = True
        Me.TreeView.TabIndex = CType(resources.GetObject("TreeView.TabIndex"), Integer)
        Me.TreeView.Text = resources.GetString("TreeView.Text")
        Me.TreeView.Visible = CType(resources.GetObject("TreeView.Visible"), Boolean)
        '
        'TreeViewContextMenu
        '
        Me.TreeViewContextMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.TreeViewContextMenuOpen, Me.TreeViewContextMenuClear})
        Me.TreeViewContextMenu.RightToLeft = CType(resources.GetObject("TreeViewContextMenu.RightToLeft"), System.Windows.Forms.RightToLeft)
        '
        'TreeViewContextMenuOpen
        '
        Me.TreeViewContextMenuOpen.Enabled = CType(resources.GetObject("TreeViewContextMenuOpen.Enabled"), Boolean)
        Me.TreeViewContextMenuOpen.Index = 0
        Me.TreeViewContextMenuOpen.Shortcut = CType(resources.GetObject("TreeViewContextMenuOpen.Shortcut"), System.Windows.Forms.Shortcut)
        Me.TreeViewContextMenuOpen.ShowShortcut = CType(resources.GetObject("TreeViewContextMenuOpen.ShowShortcut"), Boolean)
        Me.TreeViewContextMenuOpen.Text = resources.GetString("TreeViewContextMenuOpen.Text")
        Me.TreeViewContextMenuOpen.Visible = CType(resources.GetObject("TreeViewContextMenuOpen.Visible"), Boolean)
        '
        'TreeViewContextMenuClear
        '
        Me.TreeViewContextMenuClear.Enabled = CType(resources.GetObject("TreeViewContextMenuClear.Enabled"), Boolean)
        Me.TreeViewContextMenuClear.Index = 1
        Me.TreeViewContextMenuClear.Shortcut = CType(resources.GetObject("TreeViewContextMenuClear.Shortcut"), System.Windows.Forms.Shortcut)
        Me.TreeViewContextMenuClear.ShowShortcut = CType(resources.GetObject("TreeViewContextMenuClear.ShowShortcut"), Boolean)
        Me.TreeViewContextMenuClear.Text = resources.GetString("TreeViewContextMenuClear.Text")
        Me.TreeViewContextMenuClear.Visible = CType(resources.GetObject("TreeViewContextMenuClear.Visible"), Boolean)
        '
        'ImageList
        '
        Me.ImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList.ImageSize = CType(resources.GetObject("ImageList.ImageSize"), System.Drawing.Size)
        Me.ImageList.TransparentColor = System.Drawing.Color.Lime
        '
        'MenuFileSaveAs
        '
        Me.MenuFileSaveAs.Enabled = CType(resources.GetObject("MenuFileSaveAs.Enabled"), Boolean)
        Me.MenuFileSaveAs.Index = 3
        Me.MenuFileSaveAs.Shortcut = CType(resources.GetObject("MenuFileSaveAs.Shortcut"), System.Windows.Forms.Shortcut)
        Me.MenuFileSaveAs.ShowShortcut = CType(resources.GetObject("MenuFileSaveAs.ShowShortcut"), Boolean)
        Me.MenuFileSaveAs.Text = resources.GetString("MenuFileSaveAs.Text")
        Me.MenuFileSaveAs.Visible = CType(resources.GetObject("MenuFileSaveAs.Visible"), Boolean)
        '
        'MenuFileExit
        '
        Me.MenuFileExit.Enabled = CType(resources.GetObject("MenuFileExit.Enabled"), Boolean)
        Me.MenuFileExit.Index = 5
        Me.MenuFileExit.Shortcut = CType(resources.GetObject("MenuFileExit.Shortcut"), System.Windows.Forms.Shortcut)
        Me.MenuFileExit.ShowShortcut = CType(resources.GetObject("MenuFileExit.ShowShortcut"), Boolean)
        Me.MenuFileExit.Text = resources.GetString("MenuFileExit.Text")
        Me.MenuFileExit.Visible = CType(resources.GetObject("MenuFileExit.Visible"), Boolean)
        '
        'MenuFileOpenXML
        '
        Me.MenuFileOpenXML.Enabled = CType(resources.GetObject("MenuFileOpenXML.Enabled"), Boolean)
        Me.MenuFileOpenXML.Index = 1
        Me.MenuFileOpenXML.Shortcut = CType(resources.GetObject("MenuFileOpenXML.Shortcut"), System.Windows.Forms.Shortcut)
        Me.MenuFileOpenXML.ShowShortcut = CType(resources.GetObject("MenuFileOpenXML.ShowShortcut"), Boolean)
        Me.MenuFileOpenXML.Text = resources.GetString("MenuFileOpenXML.Text")
        Me.MenuFileOpenXML.Visible = CType(resources.GetObject("MenuFileOpenXML.Visible"), Boolean)
        '
        'MenuFileSave
        '
        Me.MenuFileSave.Enabled = CType(resources.GetObject("MenuFileSave.Enabled"), Boolean)
        Me.MenuFileSave.Index = 2
        Me.MenuFileSave.Shortcut = CType(resources.GetObject("MenuFileSave.Shortcut"), System.Windows.Forms.Shortcut)
        Me.MenuFileSave.ShowShortcut = CType(resources.GetObject("MenuFileSave.ShowShortcut"), Boolean)
        Me.MenuFileSave.Text = resources.GetString("MenuFileSave.Text")
        Me.MenuFileSave.Visible = CType(resources.GetObject("MenuFileSave.Visible"), Boolean)
        '
        'MainSplitter
        '
        Me.MainSplitter.AccessibleDescription = CType(resources.GetObject("MainSplitter.AccessibleDescription"), String)
        Me.MainSplitter.AccessibleName = CType(resources.GetObject("MainSplitter.AccessibleName"), String)
        Me.MainSplitter.Anchor = CType(resources.GetObject("MainSplitter.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.MainSplitter.BackgroundImage = CType(resources.GetObject("MainSplitter.BackgroundImage"), System.Drawing.Image)
        Me.MainSplitter.Dock = CType(resources.GetObject("MainSplitter.Dock"), System.Windows.Forms.DockStyle)
        Me.MainSplitter.Enabled = CType(resources.GetObject("MainSplitter.Enabled"), Boolean)
        Me.MainSplitter.Font = CType(resources.GetObject("MainSplitter.Font"), System.Drawing.Font)
        Me.MainSplitter.ImeMode = CType(resources.GetObject("MainSplitter.ImeMode"), System.Windows.Forms.ImeMode)
        Me.MainSplitter.Location = CType(resources.GetObject("MainSplitter.Location"), System.Drawing.Point)
        Me.MainSplitter.MinExtra = CType(resources.GetObject("MainSplitter.MinExtra"), Integer)
        Me.MainSplitter.MinSize = CType(resources.GetObject("MainSplitter.MinSize"), Integer)
        Me.MainSplitter.Name = "MainSplitter"
        Me.MainSplitter.RightToLeft = CType(resources.GetObject("MainSplitter.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.MainSplitter.Size = CType(resources.GetObject("MainSplitter.Size"), System.Drawing.Size)
        Me.MainSplitter.TabIndex = CType(resources.GetObject("MainSplitter.TabIndex"), Integer)
        Me.MainSplitter.TabStop = False
        Me.MainSplitter.Visible = CType(resources.GetObject("MainSplitter.Visible"), Boolean)
        '
        'MainMenu
        '
        Me.MainMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuFile, Me.MenuEdit, Me.MenuView, Me.MenuWindow, Me.MenuHelpMenu})
        Me.MainMenu.RightToLeft = CType(resources.GetObject("MainMenu.RightToLeft"), System.Windows.Forms.RightToLeft)
        '
        'MenuFile
        '
        Me.MenuFile.Enabled = CType(resources.GetObject("MenuFile.Enabled"), Boolean)
        Me.MenuFile.Index = 0
        Me.MenuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuFileOpen, Me.MenuFileOpenXML, Me.MenuFileSave, Me.MenuFileSaveAs, Me.MenuFileSplitter, Me.MenuFileExit})
        Me.MenuFile.Shortcut = CType(resources.GetObject("MenuFile.Shortcut"), System.Windows.Forms.Shortcut)
        Me.MenuFile.ShowShortcut = CType(resources.GetObject("MenuFile.ShowShortcut"), Boolean)
        Me.MenuFile.Text = resources.GetString("MenuFile.Text")
        Me.MenuFile.Visible = CType(resources.GetObject("MenuFile.Visible"), Boolean)
        '
        'MenuFileOpen
        '
        Me.MenuFileOpen.Enabled = CType(resources.GetObject("MenuFileOpen.Enabled"), Boolean)
        Me.MenuFileOpen.Index = 0
        Me.MenuFileOpen.Shortcut = CType(resources.GetObject("MenuFileOpen.Shortcut"), System.Windows.Forms.Shortcut)
        Me.MenuFileOpen.ShowShortcut = CType(resources.GetObject("MenuFileOpen.ShowShortcut"), Boolean)
        Me.MenuFileOpen.Text = resources.GetString("MenuFileOpen.Text")
        Me.MenuFileOpen.Visible = CType(resources.GetObject("MenuFileOpen.Visible"), Boolean)
        '
        'MenuFileSplitter
        '
        Me.MenuFileSplitter.Enabled = CType(resources.GetObject("MenuFileSplitter.Enabled"), Boolean)
        Me.MenuFileSplitter.Index = 4
        Me.MenuFileSplitter.Shortcut = CType(resources.GetObject("MenuFileSplitter.Shortcut"), System.Windows.Forms.Shortcut)
        Me.MenuFileSplitter.ShowShortcut = CType(resources.GetObject("MenuFileSplitter.ShowShortcut"), Boolean)
        Me.MenuFileSplitter.Text = resources.GetString("MenuFileSplitter.Text")
        Me.MenuFileSplitter.Visible = CType(resources.GetObject("MenuFileSplitter.Visible"), Boolean)
        '
        'MenuView
        '
        Me.MenuView.Enabled = CType(resources.GetObject("MenuView.Enabled"), Boolean)
        Me.MenuView.Index = 2
        Me.MenuView.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuViewExpandAll, Me.MenuViewCollapseAll, Me.MenuViewSplitter, Me.MenuViewShowErrorWindow, Me.MenuViewVersionInfo})
        Me.MenuView.Shortcut = CType(resources.GetObject("MenuView.Shortcut"), System.Windows.Forms.Shortcut)
        Me.MenuView.ShowShortcut = CType(resources.GetObject("MenuView.ShowShortcut"), Boolean)
        Me.MenuView.Text = resources.GetString("MenuView.Text")
        Me.MenuView.Visible = CType(resources.GetObject("MenuView.Visible"), Boolean)
        '
        'MenuViewExpandAll
        '
        Me.MenuViewExpandAll.Enabled = CType(resources.GetObject("MenuViewExpandAll.Enabled"), Boolean)
        Me.MenuViewExpandAll.Index = 0
        Me.MenuViewExpandAll.Shortcut = CType(resources.GetObject("MenuViewExpandAll.Shortcut"), System.Windows.Forms.Shortcut)
        Me.MenuViewExpandAll.ShowShortcut = CType(resources.GetObject("MenuViewExpandAll.ShowShortcut"), Boolean)
        Me.MenuViewExpandAll.Text = resources.GetString("MenuViewExpandAll.Text")
        Me.MenuViewExpandAll.Visible = CType(resources.GetObject("MenuViewExpandAll.Visible"), Boolean)
        '
        'MenuViewCollapseAll
        '
        Me.MenuViewCollapseAll.Enabled = CType(resources.GetObject("MenuViewCollapseAll.Enabled"), Boolean)
        Me.MenuViewCollapseAll.Index = 1
        Me.MenuViewCollapseAll.Shortcut = CType(resources.GetObject("MenuViewCollapseAll.Shortcut"), System.Windows.Forms.Shortcut)
        Me.MenuViewCollapseAll.ShowShortcut = CType(resources.GetObject("MenuViewCollapseAll.ShowShortcut"), Boolean)
        Me.MenuViewCollapseAll.Text = resources.GetString("MenuViewCollapseAll.Text")
        Me.MenuViewCollapseAll.Visible = CType(resources.GetObject("MenuViewCollapseAll.Visible"), Boolean)
        '
        'MenuViewSplitter
        '
        Me.MenuViewSplitter.Enabled = CType(resources.GetObject("MenuViewSplitter.Enabled"), Boolean)
        Me.MenuViewSplitter.Index = 2
        Me.MenuViewSplitter.Shortcut = CType(resources.GetObject("MenuViewSplitter.Shortcut"), System.Windows.Forms.Shortcut)
        Me.MenuViewSplitter.ShowShortcut = CType(resources.GetObject("MenuViewSplitter.ShowShortcut"), Boolean)
        Me.MenuViewSplitter.Text = resources.GetString("MenuViewSplitter.Text")
        Me.MenuViewSplitter.Visible = CType(resources.GetObject("MenuViewSplitter.Visible"), Boolean)
        '
        'MenuViewShowErrorWindow
        '
        Me.MenuViewShowErrorWindow.Enabled = CType(resources.GetObject("MenuViewShowErrorWindow.Enabled"), Boolean)
        Me.MenuViewShowErrorWindow.Index = 3
        Me.MenuViewShowErrorWindow.Shortcut = CType(resources.GetObject("MenuViewShowErrorWindow.Shortcut"), System.Windows.Forms.Shortcut)
        Me.MenuViewShowErrorWindow.ShowShortcut = CType(resources.GetObject("MenuViewShowErrorWindow.ShowShortcut"), Boolean)
        Me.MenuViewShowErrorWindow.Text = resources.GetString("MenuViewShowErrorWindow.Text")
        Me.MenuViewShowErrorWindow.Visible = CType(resources.GetObject("MenuViewShowErrorWindow.Visible"), Boolean)
        '
        'MenuViewVersionInfo
        '
        Me.MenuViewVersionInfo.Enabled = CType(resources.GetObject("MenuViewVersionInfo.Enabled"), Boolean)
        Me.MenuViewVersionInfo.Index = 4
        Me.MenuViewVersionInfo.Shortcut = CType(resources.GetObject("MenuViewVersionInfo.Shortcut"), System.Windows.Forms.Shortcut)
        Me.MenuViewVersionInfo.ShowShortcut = CType(resources.GetObject("MenuViewVersionInfo.ShowShortcut"), Boolean)
        Me.MenuViewVersionInfo.Text = resources.GetString("MenuViewVersionInfo.Text")
        Me.MenuViewVersionInfo.Visible = CType(resources.GetObject("MenuViewVersionInfo.Visible"), Boolean)
        '
        'MenuWindow
        '
        Me.MenuWindow.Enabled = CType(resources.GetObject("MenuWindow.Enabled"), Boolean)
        Me.MenuWindow.Index = 3
        Me.MenuWindow.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuWindowCascade, Me.MenuWindowTile, Me.MenuWindowArrangeIcons, Me.MenuWindowCloseAll})
        Me.MenuWindow.Shortcut = CType(resources.GetObject("MenuWindow.Shortcut"), System.Windows.Forms.Shortcut)
        Me.MenuWindow.ShowShortcut = CType(resources.GetObject("MenuWindow.ShowShortcut"), Boolean)
        Me.MenuWindow.Text = resources.GetString("MenuWindow.Text")
        Me.MenuWindow.Visible = CType(resources.GetObject("MenuWindow.Visible"), Boolean)
        '
        'MenuWindowCascade
        '
        Me.MenuWindowCascade.Enabled = CType(resources.GetObject("MenuWindowCascade.Enabled"), Boolean)
        Me.MenuWindowCascade.Index = 0
        Me.MenuWindowCascade.Shortcut = CType(resources.GetObject("MenuWindowCascade.Shortcut"), System.Windows.Forms.Shortcut)
        Me.MenuWindowCascade.ShowShortcut = CType(resources.GetObject("MenuWindowCascade.ShowShortcut"), Boolean)
        Me.MenuWindowCascade.Text = resources.GetString("MenuWindowCascade.Text")
        Me.MenuWindowCascade.Visible = CType(resources.GetObject("MenuWindowCascade.Visible"), Boolean)
        '
        'MenuWindowTile
        '
        Me.MenuWindowTile.Enabled = CType(resources.GetObject("MenuWindowTile.Enabled"), Boolean)
        Me.MenuWindowTile.Index = 1
        Me.MenuWindowTile.Shortcut = CType(resources.GetObject("MenuWindowTile.Shortcut"), System.Windows.Forms.Shortcut)
        Me.MenuWindowTile.ShowShortcut = CType(resources.GetObject("MenuWindowTile.ShowShortcut"), Boolean)
        Me.MenuWindowTile.Text = resources.GetString("MenuWindowTile.Text")
        Me.MenuWindowTile.Visible = CType(resources.GetObject("MenuWindowTile.Visible"), Boolean)
        '
        'MenuWindowArrangeIcons
        '
        Me.MenuWindowArrangeIcons.Enabled = CType(resources.GetObject("MenuWindowArrangeIcons.Enabled"), Boolean)
        Me.MenuWindowArrangeIcons.Index = 2
        Me.MenuWindowArrangeIcons.Shortcut = CType(resources.GetObject("MenuWindowArrangeIcons.Shortcut"), System.Windows.Forms.Shortcut)
        Me.MenuWindowArrangeIcons.ShowShortcut = CType(resources.GetObject("MenuWindowArrangeIcons.ShowShortcut"), Boolean)
        Me.MenuWindowArrangeIcons.Text = resources.GetString("MenuWindowArrangeIcons.Text")
        Me.MenuWindowArrangeIcons.Visible = CType(resources.GetObject("MenuWindowArrangeIcons.Visible"), Boolean)
        '
        'MenuWindowCloseAll
        '
        Me.MenuWindowCloseAll.Enabled = CType(resources.GetObject("MenuWindowCloseAll.Enabled"), Boolean)
        Me.MenuWindowCloseAll.Index = 3
        Me.MenuWindowCloseAll.Shortcut = CType(resources.GetObject("MenuWindowCloseAll.Shortcut"), System.Windows.Forms.Shortcut)
        Me.MenuWindowCloseAll.ShowShortcut = CType(resources.GetObject("MenuWindowCloseAll.ShowShortcut"), Boolean)
        Me.MenuWindowCloseAll.Text = resources.GetString("MenuWindowCloseAll.Text")
        Me.MenuWindowCloseAll.Visible = CType(resources.GetObject("MenuWindowCloseAll.Visible"), Boolean)
        '
        'MenuHelpMenu
        '
        Me.MenuHelpMenu.Enabled = CType(resources.GetObject("MenuHelpMenu.Enabled"), Boolean)
        Me.MenuHelpMenu.Index = 4
        Me.MenuHelpMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuHelp, Me.MenuHelpAbout})
        Me.MenuHelpMenu.Shortcut = CType(resources.GetObject("MenuHelpMenu.Shortcut"), System.Windows.Forms.Shortcut)
        Me.MenuHelpMenu.ShowShortcut = CType(resources.GetObject("MenuHelpMenu.ShowShortcut"), Boolean)
        Me.MenuHelpMenu.Text = resources.GetString("MenuHelpMenu.Text")
        Me.MenuHelpMenu.Visible = CType(resources.GetObject("MenuHelpMenu.Visible"), Boolean)
        '
        'MenuHelp
        '
        Me.MenuHelp.Enabled = CType(resources.GetObject("MenuHelp.Enabled"), Boolean)
        Me.MenuHelp.Index = 0
        Me.MenuHelp.Shortcut = CType(resources.GetObject("MenuHelp.Shortcut"), System.Windows.Forms.Shortcut)
        Me.MenuHelp.ShowShortcut = CType(resources.GetObject("MenuHelp.ShowShortcut"), Boolean)
        Me.MenuHelp.Text = resources.GetString("MenuHelp.Text")
        Me.MenuHelp.Visible = CType(resources.GetObject("MenuHelp.Visible"), Boolean)
        '
        'MenuHelpAbout
        '
        Me.MenuHelpAbout.Enabled = CType(resources.GetObject("MenuHelpAbout.Enabled"), Boolean)
        Me.MenuHelpAbout.Index = 1
        Me.MenuHelpAbout.Shortcut = CType(resources.GetObject("MenuHelpAbout.Shortcut"), System.Windows.Forms.Shortcut)
        Me.MenuHelpAbout.ShowShortcut = CType(resources.GetObject("MenuHelpAbout.ShowShortcut"), Boolean)
        Me.MenuHelpAbout.Text = resources.GetString("MenuHelpAbout.Text")
        Me.MenuHelpAbout.Visible = CType(resources.GetObject("MenuHelpAbout.Visible"), Boolean)
        '
        'ErrorPanel
        '
        Me.ErrorPanel.AccessibleDescription = CType(resources.GetObject("ErrorPanel.AccessibleDescription"), String)
        Me.ErrorPanel.AccessibleName = CType(resources.GetObject("ErrorPanel.AccessibleName"), String)
        Me.ErrorPanel.Anchor = CType(resources.GetObject("ErrorPanel.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.ErrorPanel.AutoScroll = CType(resources.GetObject("ErrorPanel.AutoScroll"), Boolean)
        Me.ErrorPanel.AutoScrollMargin = CType(resources.GetObject("ErrorPanel.AutoScrollMargin"), System.Drawing.Size)
        Me.ErrorPanel.AutoScrollMinSize = CType(resources.GetObject("ErrorPanel.AutoScrollMinSize"), System.Drawing.Size)
        Me.ErrorPanel.BackgroundImage = CType(resources.GetObject("ErrorPanel.BackgroundImage"), System.Drawing.Image)
        Me.ErrorPanel.Controls.AddRange(New System.Windows.Forms.Control() {Me.ErrorWindow})
        Me.ErrorPanel.Dock = CType(resources.GetObject("ErrorPanel.Dock"), System.Windows.Forms.DockStyle)
        Me.ErrorPanel.Enabled = CType(resources.GetObject("ErrorPanel.Enabled"), Boolean)
        Me.ErrorPanel.Font = CType(resources.GetObject("ErrorPanel.Font"), System.Drawing.Font)
        Me.ErrorPanel.ImeMode = CType(resources.GetObject("ErrorPanel.ImeMode"), System.Windows.Forms.ImeMode)
        Me.ErrorPanel.Location = CType(resources.GetObject("ErrorPanel.Location"), System.Drawing.Point)
        Me.ErrorPanel.Name = "ErrorPanel"
        Me.ErrorPanel.RightToLeft = CType(resources.GetObject("ErrorPanel.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.ErrorPanel.Size = CType(resources.GetObject("ErrorPanel.Size"), System.Drawing.Size)
        Me.ErrorPanel.TabIndex = CType(resources.GetObject("ErrorPanel.TabIndex"), Integer)
        Me.ErrorPanel.Text = resources.GetString("ErrorPanel.Text")
        Me.ErrorPanel.Visible = CType(resources.GetObject("ErrorPanel.Visible"), Boolean)
        '
        'ErrorWindow
        '
        Me.ErrorWindow.AccessibleDescription = CType(resources.GetObject("ErrorWindow.AccessibleDescription"), String)
        Me.ErrorWindow.AccessibleName = CType(resources.GetObject("ErrorWindow.AccessibleName"), String)
        Me.ErrorWindow.Anchor = CType(resources.GetObject("ErrorWindow.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.ErrorWindow.AutoScroll = CType(resources.GetObject("ErrorWindow.AutoScroll"), Boolean)
        Me.ErrorWindow.AutoScrollMargin = CType(resources.GetObject("ErrorWindow.AutoScrollMargin"), System.Drawing.Size)
        Me.ErrorWindow.AutoScrollMinSize = CType(resources.GetObject("ErrorWindow.AutoScrollMinSize"), System.Drawing.Size)
        Me.ErrorWindow.BackgroundImage = CType(resources.GetObject("ErrorWindow.BackgroundImage"), System.Drawing.Image)
        Me.ErrorWindow.Dock = CType(resources.GetObject("ErrorWindow.Dock"), System.Windows.Forms.DockStyle)
        Me.ErrorWindow.Enabled = CType(resources.GetObject("ErrorWindow.Enabled"), Boolean)
        Me.ErrorWindow.Font = CType(resources.GetObject("ErrorWindow.Font"), System.Drawing.Font)
        Me.ErrorWindow.ImeMode = CType(resources.GetObject("ErrorWindow.ImeMode"), System.Windows.Forms.ImeMode)
        Me.ErrorWindow.Location = CType(resources.GetObject("ErrorWindow.Location"), System.Drawing.Point)
        Me.ErrorWindow.Name = "ErrorWindow"
        Me.ErrorWindow.RightToLeft = CType(resources.GetObject("ErrorWindow.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.ErrorWindow.Size = CType(resources.GetObject("ErrorWindow.Size"), System.Drawing.Size)
        Me.ErrorWindow.TabIndex = CType(resources.GetObject("ErrorWindow.TabIndex"), Integer)
        Me.ErrorWindow.Visible = CType(resources.GetObject("ErrorWindow.Visible"), Boolean)
        '
        'ErrorPanelSplitter
        '
        Me.ErrorPanelSplitter.AccessibleDescription = CType(resources.GetObject("ErrorPanelSplitter.AccessibleDescription"), String)
        Me.ErrorPanelSplitter.AccessibleName = CType(resources.GetObject("ErrorPanelSplitter.AccessibleName"), String)
        Me.ErrorPanelSplitter.Anchor = CType(resources.GetObject("ErrorPanelSplitter.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.ErrorPanelSplitter.BackgroundImage = CType(resources.GetObject("ErrorPanelSplitter.BackgroundImage"), System.Drawing.Image)
        Me.ErrorPanelSplitter.Dock = CType(resources.GetObject("ErrorPanelSplitter.Dock"), System.Windows.Forms.DockStyle)
        Me.ErrorPanelSplitter.Enabled = CType(resources.GetObject("ErrorPanelSplitter.Enabled"), Boolean)
        Me.ErrorPanelSplitter.Font = CType(resources.GetObject("ErrorPanelSplitter.Font"), System.Drawing.Font)
        Me.ErrorPanelSplitter.ImeMode = CType(resources.GetObject("ErrorPanelSplitter.ImeMode"), System.Windows.Forms.ImeMode)
        Me.ErrorPanelSplitter.Location = CType(resources.GetObject("ErrorPanelSplitter.Location"), System.Drawing.Point)
        Me.ErrorPanelSplitter.MinExtra = CType(resources.GetObject("ErrorPanelSplitter.MinExtra"), Integer)
        Me.ErrorPanelSplitter.MinSize = CType(resources.GetObject("ErrorPanelSplitter.MinSize"), Integer)
        Me.ErrorPanelSplitter.Name = "ErrorPanelSplitter"
        Me.ErrorPanelSplitter.RightToLeft = CType(resources.GetObject("ErrorPanelSplitter.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.ErrorPanelSplitter.Size = CType(resources.GetObject("ErrorPanelSplitter.Size"), System.Drawing.Size)
        Me.ErrorPanelSplitter.TabIndex = CType(resources.GetObject("ErrorPanelSplitter.TabIndex"), Integer)
        Me.ErrorPanelSplitter.TabStop = False
        Me.ErrorPanelSplitter.Visible = CType(resources.GetObject("ErrorPanelSplitter.Visible"), Boolean)
        '
        'ErrorWindowTitle
        '
        Me.ErrorWindowTitle.AccessibleDescription = CType(resources.GetObject("ErrorWindowTitle.AccessibleDescription"), String)
        Me.ErrorWindowTitle.AccessibleName = CType(resources.GetObject("ErrorWindowTitle.AccessibleName"), String)
        Me.ErrorWindowTitle.Anchor = CType(resources.GetObject("ErrorWindowTitle.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.ErrorWindowTitle.AutoSize = CType(resources.GetObject("ErrorWindowTitle.AutoSize"), Boolean)
        Me.ErrorWindowTitle.Dock = CType(resources.GetObject("ErrorWindowTitle.Dock"), System.Windows.Forms.DockStyle)
        Me.ErrorWindowTitle.Enabled = CType(resources.GetObject("ErrorWindowTitle.Enabled"), Boolean)
        Me.ErrorWindowTitle.Font = CType(resources.GetObject("ErrorWindowTitle.Font"), System.Drawing.Font)
        Me.ErrorWindowTitle.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(25, Byte), CType(37, Byte))
        Me.ErrorWindowTitle.Image = CType(resources.GetObject("ErrorWindowTitle.Image"), System.Drawing.Image)
        Me.ErrorWindowTitle.ImageAlign = CType(resources.GetObject("ErrorWindowTitle.ImageAlign"), System.Drawing.ContentAlignment)
        Me.ErrorWindowTitle.ImageIndex = CType(resources.GetObject("ErrorWindowTitle.ImageIndex"), Integer)
        Me.ErrorWindowTitle.ImeMode = CType(resources.GetObject("ErrorWindowTitle.ImeMode"), System.Windows.Forms.ImeMode)
        Me.ErrorWindowTitle.Location = CType(resources.GetObject("ErrorWindowTitle.Location"), System.Drawing.Point)
        Me.ErrorWindowTitle.Name = "ErrorWindowTitle"
        Me.ErrorWindowTitle.RightToLeft = CType(resources.GetObject("ErrorWindowTitle.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.ErrorWindowTitle.Size = CType(resources.GetObject("ErrorWindowTitle.Size"), System.Drawing.Size)
        Me.ErrorWindowTitle.TabIndex = CType(resources.GetObject("ErrorWindowTitle.TabIndex"), Integer)
        Me.ErrorWindowTitle.Text = resources.GetString("ErrorWindowTitle.Text")
        Me.ErrorWindowTitle.TextAlign = CType(resources.GetObject("ErrorWindowTitle.TextAlign"), System.Drawing.ContentAlignment)
        Me.ErrorWindowTitle.Visible = CType(resources.GetObject("ErrorWindowTitle.Visible"), Boolean)
        '
        'MainWindow
        '
        Me.AccessibleDescription = CType(resources.GetObject("$this.AccessibleDescription"), String)
        Me.AccessibleName = CType(resources.GetObject("$this.AccessibleName"), String)
        Me.Anchor = CType(resources.GetObject("$this.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.AutoScaleBaseSize = CType(resources.GetObject("$this.AutoScaleBaseSize"), System.Drawing.Size)
        Me.AutoScroll = CType(resources.GetObject("$this.AutoScroll"), Boolean)
        Me.AutoScrollMargin = CType(resources.GetObject("$this.AutoScrollMargin"), System.Drawing.Size)
        Me.AutoScrollMinSize = CType(resources.GetObject("$this.AutoScrollMinSize"), System.Drawing.Size)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = CType(resources.GetObject("$this.ClientSize"), System.Drawing.Size)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.ErrorPanelSplitter, Me.ErrorPanel, Me.MainSplitter, Me.TreeView, Me.MainStatusBar, Me.MdiClient})
        Me.Dock = CType(resources.GetObject("$this.Dock"), System.Windows.Forms.DockStyle)
        Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
        Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
        Me.IsMdiContainer = True
        Me.Location = CType(resources.GetObject("$this.Location"), System.Drawing.Point)
        Me.MaximumSize = CType(resources.GetObject("$this.MaximumSize"), System.Drawing.Size)
        Me.Menu = Me.MainMenu
        Me.MinimumSize = CType(resources.GetObject("$this.MinimumSize"), System.Drawing.Size)
        Me.Name = "MainWindow"
        Me.RightToLeft = CType(resources.GetObject("$this.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.StartPosition = CType(resources.GetObject("$this.StartPosition"), System.Windows.Forms.FormStartPosition)
        Me.Text = resources.GetString("$this.Text")
        Me.Visible = CType(resources.GetObject("$this.Visible"), Boolean)
        CType(Me.StatusPanelAction, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusPanelErrorInformation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ErrorPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub New()
        MyBase.New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        InitializeSetUp()
    End Sub

    Private Sub InitializeSetUp()

        'The error window is initially hidden.
        HideErrorWindow()

        TreeView.Font = MemberNode.EditedFont

        'Load the image strip from an embedded resource.
        Me.ImageList.Images.AddStrip(Image.FromStream(Reflection.Assembly.GetExecutingAssembly.GetManifestResourceStream("XMLDocumentationTool.imagestrip.bmp")))

        'If we have a list of previously opened files in the registry, add them to the file menu.
        CheckForHistoryFiles()

        If Microsoft.VisualBasic.Command <> "" Then
            OpenNamedAssembly(Microsoft.VisualBasic.Command)
        End If

    End Sub

    Private Sub CheckForHistoryFiles()
        ' Check to see if the registry contains information about recently
        ' opened files, and if so, add them to the file menu.

        Dim strFileName As String

        strFileName = GetSetting(APPNAME, HISTORYFILES, "1")
        If strFileName = "" Then Exit Sub

        ' add a separator bar
        Dim NewItem As MenuItem
        NewItem = New MenuItem("-")
        Me.MenuFile.MenuItems.Add(Me.MenuFile.MenuItems.Count - 1, NewItem)

        ' add the history files
        NewItem = New MenuItem("&1 " & strFileName, New EventHandler(AddressOf OpenHistoryFile))
        Me.MenuFile.MenuItems.Add(Me.MenuFile.MenuItems.Count - 2, NewItem)

        strFileName = GetSetting(APPNAME, HISTORYFILES, "2")
        If strFileName = "" Then Exit Sub
        NewItem = New MenuItem("&2 " & strFileName, New EventHandler(AddressOf OpenHistoryFile))
        Me.MenuFile.MenuItems.Add(Me.MenuFile.MenuItems.Count - 2, NewItem)

        strFileName = GetSetting(APPNAME, HISTORYFILES, "3")
        If strFileName = "" Then Exit Sub
        NewItem = New MenuItem("&3 " & strFileName, New EventHandler(AddressOf OpenHistoryFile))
        Me.MenuFile.MenuItems.Add(Me.MenuFile.MenuItems.Count - 2, NewItem)

        strFileName = GetSetting(APPNAME, HISTORYFILES, "4")
        If strFileName = "" Then Exit Sub
        NewItem = New MenuItem("&4 " & strFileName, New EventHandler(AddressOf OpenHistoryFile))
        Me.MenuFile.MenuItems.Add(Me.MenuFile.MenuItems.Count - 2, NewItem)

    End Sub

    Private Sub ShiftHistoryFiles(ByVal NewestFile As String)
        'Move each file in the history list down one, and add a new entry at the top.  If the
        'new entry appears in the list, remove it from that point in the list and move it to
        'the top.

        Dim strFileName As String

        ' first make sure the file doesn't already appear in our history in at least position 3
        If GetSetting(APPNAME, HISTORYFILES, "1") <> NewestFile Then
            If GetSetting(APPNAME, HISTORYFILES, "2") = NewestFile Then
                strFileName = GetSetting(APPNAME, HISTORYFILES, "1")
                SaveSetting(APPNAME, HISTORYFILES, "2", strFileName)
                SaveSetting(APPNAME, HISTORYFILES, "1", NewestFile)
            ElseIf GetSetting(APPNAME, HISTORYFILES, "3") = NewestFile Then
                strFileName = GetSetting(APPNAME, HISTORYFILES, "2")
                SaveSetting(APPNAME, HISTORYFILES, "3", strFileName)
                strFileName = GetSetting(APPNAME, HISTORYFILES, "1")
                SaveSetting(APPNAME, HISTORYFILES, "2", strFileName)
                SaveSetting(APPNAME, HISTORYFILES, "1", NewestFile)
            Else
                strFileName = GetSetting(APPNAME, HISTORYFILES, "3")
                SaveSetting(APPNAME, HISTORYFILES, "4", strFileName)
                strFileName = GetSetting(APPNAME, HISTORYFILES, "2")
                SaveSetting(APPNAME, HISTORYFILES, "3", strFileName)
                strFileName = GetSetting(APPNAME, HISTORYFILES, "1")
                SaveSetting(APPNAME, HISTORYFILES, "2", strFileName)
                SaveSetting(APPNAME, HISTORYFILES, "1", NewestFile)
            End If
        End If

        ' let's also update the File Menu at this point.  First, we want
        ' to verify that there are old history files to remove from the
        ' menu.
        Dim iBars As Integer = 0
        Dim item As MenuItem
        For Each item In Me.MenuFile.MenuItems
            If item.Text = "-" Then iBars += 1
        Next
        If iBars < 2 Then Exit Sub

        ' then, remove the old ones, and call CheckForHistoryFiles to 
        ' repopulate them.
        iBars = 1
        Do
            iBars += 1
            If Me.MenuFile.MenuItems(iBars).Text = "-" Then Exit Do
        Loop
        Do
            Me.MenuFile.MenuItems.RemoveAt(iBars)
        Loop Until Me.MenuFile.MenuItems(iBars).Text = "-"
        CheckForHistoryFiles()

    End Sub

    Private Sub MenuFileOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuFileOpen.Click
        ' Open an Assembly file and, optionally, an associated XML
        ' Documentation file.

        If Not m_Doc Is Nothing Then
            If FileDirty Then
                'Ask the user to save the current XML Documentation file.
                Select Case MsgBox(SAVE_MESSAGE, MsgBoxStyle.YesNoCancel)
                    Case MsgBoxResult.Yes
                        If SaveXMLDocumentationFile() = FileResult.Failure Then
                            Exit Sub
                        End If

                    Case MsgBoxResult.Cancel
                        Exit Sub
                End Select
            End If
        End If

        Dim fileOpen As OpenFiles = New OpenFiles()
        If fileOpen.ShowDialog = DialogResult.OK Then

            'Import the Assembly.
            OpenNamedAssembly(fileOpen.AssemblyPath, fileOpen.XMLDocumentationPath)
        End If

    End Sub

    Private Sub OpenHistoryFile(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Open an assembly file from the recently opened files

        Dim WhichFile As String

        Try
            WhichFile = Mid(CType(sender, MenuItem).Text, 2, 1)
            If CInt(WhichFile) = 0 Then Exit Sub
        Catch
            Exit Sub
        End Try

        Dim AsmPath As String

        AsmPath = GetSetting(APPNAME, HISTORYFILES, WhichFile)

        'Import the Assembly.
        OpenNamedAssembly(AsmPath)

    End Sub

    Private Function OpenNamedAssembly(ByVal Asmpath As String, Optional ByVal XMLPath As String = "") As FileResult
        'This is a subsidiary function to actually open the assembly once we've worked out
        'what assembly we want to open via one of the different ways available to the user
        'via the UI.

        'If an assembly file has been opened before we need to do some cleanup.
        If Not m_Doc Is Nothing Then
            If FileDirty Then
                'Ask the user to save the current XML Documentation file.
                Select Case MsgBox(SAVE_MESSAGE, MsgBoxStyle.YesNoCancel)
                    Case MsgBoxResult.Yes
                        If SaveXMLDocumentationFile() = FileResult.Failure Then
                            Return FileResult.Failure
                            Exit Function
                        End If

                    Case MsgBoxResult.Cancel
                        Return FileResult.Failure
                        Exit Function
                End Select
            End If

            'Do some clean up before opening a new document.
            TreeView.Nodes.Clear()
            Me.StatusPanelErrorInformation.Text = ""
            m_Doc = Nothing
            m_AsmFileName = Nothing
            m_XMLFileName = Nothing
            ErrorWindow.ClearAllItems()
            Me.ErrorPanel.Hide()
            Me.ErrorPanelSplitter.Hide()
            MenuWindowCloseAll_Click(Nothing, Nothing)
        End If

        'Import the Assembly.
        If OpenAssemblyFile(Asmpath) = FileResult.Success Then
            Me.Text = WINDOW_TITLE & " - " & m_AsmFileName

            If XMLPath = "" Then
                'Attempt to guess the right XML file
                XMLPath = IO.Path.GetDirectoryName(Asmpath) & "\" & IO.Path.GetFileNameWithoutExtension(Asmpath) & ".xml"
            End If

            'Open the XML Documentation file if the user supplied one.
            If IO.File.Exists(XMLPath) Then
                OpenXMLDocumentationFile(XMLPath)
            End If

            'Update the file history
            ShiftHistoryFiles(m_AsmFileName)

            'Reset dirty flag
            FileDirty = False

            Return FileResult.Success
        Else
            Return FileResult.Failure
        End If

    End Function

    Private Sub MenuFileOpenXML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuFileOpenXML.Click
        Dim openDialog As OpenFileDialog = New OpenFileDialog()

        openDialog.FileName = GetXMLFileName()
        openDialog.Filter = XML_FILE_FILTER

        If openDialog.ShowDialog = DialogResult.OK Then
            OpenXMLDocumentationFile(openDialog.FileName)
        End If
    End Sub

    Private Sub MenuFileSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuFileSave.Click
        SaveXMLDocumentationFile()
    End Sub

    Private Sub MenuFileSaveAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuFileSaveAs.Click
        SaveWithNewFileName()
    End Sub

    Private Enum FileResult
        Failure
        Success
    End Enum

    Private Function OpenAssemblyFile(ByVal filename As String) As FileResult
        ' Construct the main document and then import the assembly.

        Try
            StatusMessage("Loading Assembly...")
            Update()  'Fixes some redrawing annoyances.

            m_Doc = New MainDoc(Me, Reflection.Assembly.LoadFrom(filename))
            m_Doc.ImportAssembly()
            ErrorWindow.AdjustColumns()     'To make the error window columns fit any error messages.
            m_AsmFileName = filename
            Return FileResult.Success

        Catch e As Exception
            MsgBox(GetErrorMessage(ErrorID.ErrorDuringLoad3, "the assembly file", filename, e.Message))
            Return FileResult.Failure

        Finally
            StatusMessageReady()
        End Try

    End Function

    Private Function OpenXMLDocumentationFile(ByVal filename As String) As FileResult
        Try
            StatusMessage("Loading XML...")
            ErrorWindow.BeginUpdate()

            m_Doc.OpenXML(filename)
            ErrorWindow.AdjustColumns()     'To make the error window columns fit any error messages.
            m_XMLFileName = filename
            Return FileResult.Success

        Catch e As Exception
            MsgBox(GetErrorMessage(ErrorID.ErrorDuringLoad3, "the XML Documentation file", filename, e.Message))
            Return FileResult.Failure

        Finally
            StatusMessageReady()
            ErrorWindow.EndUpdate()
        End Try

    End Function

    Private Function SaveXMLDocumentationFile() As FileResult
        If m_XMLFileName = "" Then
            Return SaveWithNewFileName()
        Else
            Return SaveWithFileName()
        End If
    End Function

    Private Function SaveWithFileName() As FileResult

        Try
            StatusMessage("Saving...")
            m_Doc.SaveXML(m_XMLFileName)
            FileDirty = False
            Return FileResult.Success

        Catch e As Exception
            MsgBox(GetErrorMessage(ErrorID.ErrorDuringSave3, "the XML Documentation file", m_XMLFileName, e.Message))
            Return FileResult.Failure

        Finally
            StatusMessageReady()
        End Try

    End Function
    Private Function SaveWithNewFileName() As FileResult
        ' Ask the user for a new XML Documentation filename and then save
        ' using that new name.

        Dim saveDialog As SaveFileDialog = New SaveFileDialog()

        saveDialog.FileName = GetXMLFileName()
        saveDialog.Filter = XML_FILE_FILTER

        If DialogResult.OK = saveDialog.ShowDialog Then
            m_XMLFileName = saveDialog.FileName
            Return SaveWithFileName()
        End If

    End Function

    Private Sub MenuFileExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuFileExit.Click
        Me.Close()  'This will fire the Closing event which will take care of notifying the user to save their file.
    End Sub

    Private Sub MenuEditCut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuEditCut.Click
        If Not Me.ActiveMdiChild Is Nothing Then
            Dim Holder As UserControl = CType(Me.ActiveMdiChild.ActiveControl, UserControl)
            If Not Holder.ActiveControl Is Nothing Then
                Dim box As DescriptoBox = CType(Holder.ActiveControl, DescriptoBox)
                If box.SelectionLength > 0 Then
                    box.Cut()
                    FileDirty = True
                End If
            End If
        End If
    End Sub

    Private Sub MenuEditCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuEditCopy.Click
        If Not Me.ActiveMdiChild Is Nothing AndAlso Me.ActiveControl Is Me.ActiveMdiChild Then
            Dim Holder As UserControl = CType(Me.ActiveMdiChild.ActiveControl, UserControl)
            If Not Holder.ActiveControl Is Nothing Then
                Dim box As DescriptoBox = CType(Holder.ActiveControl, DescriptoBox)
                If box.SelectionLength > 0 Then
                    box.Copy()
                End If
            End If
        ElseIf Me.ActiveControl Is TreeView Then
            Dim source As MemberNode = CType(TreeView.SelectedNode, MemberNode)
            m_CopyNode = CType(source.Clone, MemberNode)
        End If
        If Not Me.ActiveControl Is TreeView Then
            m_CopyNode = Nothing
        End If
    End Sub

    Private Sub MenuEditPaste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuEditPaste.Click
        If Not Me.ActiveMdiChild Is Nothing AndAlso Me.ActiveControl Is Me.ActiveMdiChild Then
            Dim Holder As UserControl = CType(Me.ActiveMdiChild.ActiveControl, UserControl)
            If Not Holder.ActiveControl Is Nothing Then
                Dim box As DescriptoBox = CType(Holder.ActiveControl, DescriptoBox)
                box.Paste(DataFormats.GetFormat(DataFormats.Text))
                FileDirty = True
            End If
        ElseIf Me.ActiveControl Is TreeView Then
            Dim target As MemberNode = CType(TreeView.SelectedNode, MemberNode)
            TreeView.CopyNode(m_CopyNode, target)
            FileDirty = True
        End If
    End Sub

    Private Sub MenuEditFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuEditFind.Click
        ' Display the Find dialog.
        ' We need to consider three situations:
        '         Find Dialog is not constructed yet
        '         Find Dialog is hidden
        '         Find Dialog is already visible

        If m_FindDialog Is Nothing Then
            m_FindDialog = New FindDialog(Me)
            m_FindDialog.Show()
        ElseIf m_FindDialog.Visible = False Then
            m_FindDialog.Reset()
            m_FindDialog.Show()
        Else
            m_FindDialog.BringToFront()
        End If
    End Sub

    Private Sub MenuEditClearNode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuEditClearNode.Click, TreeViewContextMenuClear.Click
        ' Delete the selected node, including its children.

        Dim memberNode As MemberNode = CType(TreeView.SelectedNode(), MemberNode)

        If memberNode.GetNodeCount(False) > 0 Then
            If vbNo = MsgBox("This will clear all the children of this node. " & _
                    vbCrLf & "Are you sure you want to continue?", MsgBoxStyle.YesNo) Then
                Return
            End If
        End If

        StatusMessage("Deleting...")

        ClearNode(memberNode, True)
        FileDirty = True

        StatusMessageReady()
    End Sub

    Private Sub MenuEditDeleteAllXMLNodes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuEditDeleteAllXMLNodes.Click
        ' Delete all nodes which appear only in the XML Documentation file.
        ' First we recurse the Assembly tree to build a list of nodes to
        ' delete.  Then given this list, we delete each one.  Since we recurse
        ' depth-first, children are guaranteed to be deleted before their
        ' parents (which keeps the tree from getting garbled as we delete
        ' nodes).

        If vbNo = MsgBox("This will delete all the nodes found only in the XML Documentation file. Continue?", MsgBoxStyle.YesNo) Then
            Return
        End If

        StatusMessage("Deleting...")

        Dim memberNode As MemberNode
        Dim DeletionList As New ArrayList(8)

        For Each memberNode In TreeView.Nodes
            RecursiveCheck(memberNode, DeletionList)
        Next

        For Each memberNode In DeletionList
            DeleteNode(memberNode, False)   'The children are already in the list, so don't do a recursive delete.
        Next

        FileDirty = True

        StatusMessageReady()
    End Sub

    Private Sub RecursiveCheck(ByVal memberNode As MemberNode, ByVal DeletionList As ArrayList)
        ' Builds a deletion list of all nodes which are found only in the
        ' XML Documentation file.  We do a depth-first search to make sure
        ' children appear before their parents in the deletion list.

        Dim childNode As MemberNode
        For Each childNode In memberNode.Nodes
            RecursiveCheck(childNode, DeletionList)
        Next

        If memberNode.Source = NodeSource.XML Then
            DeletionList.Add(memberNode)
        End If
    End Sub

    Private Sub DoDeleteNode(ByVal memberNode As MemberNode, ByVal IncludeChildren As Boolean)
        ' Delete the member node from the XML Documentation tree.  If
        ' necessary, recursively delete the children as well.  Remove the
        ' deleted node's errors from the error list, close its window (if
        ' open), and remove it from consideration in the Find window's state.

        If IncludeChildren Then
            'Delete the children first.
            Dim child As MemberNode
            For Each child In memberNode.Nodes
                DoDeleteNode(child, True)
            Next
        End If

        'Remove all the errors for this node.
        If memberNode.HasErrors Then
            m_Doc.DeleteNodeFromErrorList(memberNode)
        End If

        'If this node has a editor window open, close it.
        Dim form As NodeWindow
        For Each form In MdiClient.MdiChildren
            If form.Text = memberNode.FriendlySignatureWithPathAndModifiers Then
                form.Close()
                Exit For
            End If
        Next

        If Not m_FindDialog Is Nothing AndAlso m_FindDialog.Visible Then
            m_FindDialog.SkipDeletedNode(memberNode)
        End If

    End Sub

    Private Sub ClearNode(ByVal memberNode As MemberNode, ByVal IncludeChildren As Boolean)
        ' Clear the member node from the XML Documentation tree.  If
        ' necessary, recursively delete the children as well.  Remove
        ' any errors and update the document window.

        If IncludeChildren Then
            'Clear the children first.
            Dim child As MemberNode
            For Each child In memberNode.Nodes
                ClearNode(child, True)
            Next
        End If

        'Remove all the errors for this node.
        If memberNode.HasErrors Then
            m_Doc.DeleteNodeFromErrorList(memberNode)
        End If

        'Clear all the stored values
        ClearValues(memberNode.m_Params)
        ClearValues(memberNode.m_PropertyValue)
        ClearValues(memberNode.m_Remarks)
        ClearValues(memberNode.m_ReturnValue)
        ClearValues(memberNode.m_Summary)

        'If this node has an editor window open, refresh the controls.
        Dim form As NodeWindow
        For Each form In MdiClient.MdiChildren
            If form.Text = memberNode.FriendlySignatureWithPathAndModifiers Then
                Dim Holder As UserControl = CType(form.ActiveControl, UserControl)
                Holder.Controls.Clear()
                form.BuildFormMembers()
                Exit For
            End If
        Next

        memberNode.UpdateEditState()

    End Sub

    Private Sub ClearValues(ByVal Values As ArrayList)
        ' Clear valid values from the arraylist.  Delete errors.

        Dim i As Integer
        Dim param As ParameterDescriptor
        Dim content As ContentDescriptor

        For i = 0 To Values.Count - 1
            If Values(i).GetType Is GetType(ParameterDescriptor) Then
                param = CType(Values(i), ParameterDescriptor)
                If param.Errors Is Nothing Then
                    param.Content = ""
                Else
                    Values.Remove(param)
                End If
            ElseIf Values(i).GetType Is GetType(ContentDescriptor) Then
                content = CType(Values(i), ContentDescriptor)
                If content.Errors Is Nothing Then
                    content.Content = ""
                Else
                    Values.Remove(content)
                End If
            End If
        Next
    End Sub

    Private Sub DeleteNode(ByVal memberNode As MemberNode, ByVal IncludeChildren As Boolean)
        DoDeleteNode(memberNode, IncludeChildren)

        'Remove the top-level node from the Assembly tree.  If children are included, they
        'will be removed as well.
        TreeView.Nodes.Remove(memberNode)
    End Sub

    Private Sub MenuViewExpandAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuViewExpandAll.Click
        StatusMessage("Expanding...")

        TreeView.BeginUpdate()
        TreeView.ExpandAll()
        ' Make sure we are on top of the tree
        If TreeView.GetNodeCount(False) > 0 Then
            TreeView.Nodes(0).EnsureVisible()
        End If
        TreeView.EndUpdate()

        StatusMessageReady()
    End Sub

    Private Sub MenuViewCollapseAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuViewCollapseAll.Click
        StatusMessage("Collapsing...")
        TreeView.CollapseAll()
        StatusMessageReady()
    End Sub

    Private Sub MenuViewShowErrorWindow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuViewShowErrorWindow.Click
        Me.MenuViewShowErrorWindow.Checked = Not MenuViewShowErrorWindow.Checked
        If Me.MenuViewShowErrorWindow.Checked Then
            ShowErrorWindow()
        Else
            HideErrorWindow()
        End If
    End Sub

    Private Sub MenuViewVersionInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuViewVersionInfo.Click
        ' Build the version properties objects and display the version info
        ' dialog.

        Dim AsmData As VersionData = New VersionData(m_Doc.m_Asm.GetName)

        Dim versionProperties As VersionProperties

        If Not m_Doc.m_XMLData Is Nothing Then
            versionProperties = New VersionProperties(AsmData, m_Doc.m_XMLData)
        Else
            versionProperties = New VersionProperties(AsmData)
        End If

        Dim verinfo As VersionInfo = New VersionInfo(versionProperties)
        verinfo.ShowDialog()
    End Sub

    Private Sub MenuWindowCascade_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuWindowCascade.Click
        MdiClient.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub MenuWindowTile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuWindowTile.Click
        MdiClient.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub MenuWindowArrangeIcons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuWindowArrangeIcons.Click
        MdiClient.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub MenuWindowCloseAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuWindowCloseAll.Click
        Dim form As NodeWindow
        For Each form In MdiClient.MdiChildren
            form.Close()
        Next
    End Sub

    Private Sub MenuHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuHelp.Click
        Try
            System.Diagnostics.Process.Start("ReadMe.htm")
        Catch ex1 As System.ComponentModel.Win32Exception
            Try
                System.Diagnostics.Process.Start("..\ReadMe.htm")
            Catch ex2 As Exception
                MsgBox("Error loading 'ReadMe.htm': " & ex2.Message)
            End Try
        End Try
    End Sub

    Private Sub MenuFile_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuFile.Popup
        ' Disables SaveAs, Save, and OpenXML if no assembly is open.  OpenXML
        ' is disabled if an XML Documentation file is already open.

        Me.MenuFileSaveAs.Enabled = Not m_Doc Is Nothing
        Me.MenuFileSave.Enabled = Not m_Doc Is Nothing
        Me.MenuFileOpenXML.Enabled = m_XMLFileName = "" AndAlso Not m_Doc Is Nothing
    End Sub

    Private Sub MenuEdit_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuEdit.Popup
        ' Enable Cut, Copy and Paste depending on the current item selected.

        Me.MenuEditCut.Enabled = False
        Me.MenuEditCopy.Enabled = False
        Me.MenuEditPaste.Enabled = False
        Me.MenuEditDeleteError.Enabled = False

        'Cut, Copy and Paste only works for DescriptoBoxes.
        If Not Me.ActiveMdiChild Is Nothing AndAlso Me.ActiveControl Is Me.ActiveMdiChild Then
            Dim Holder As UserControl = CType(Me.ActiveMdiChild.ActiveControl, UserControl)
            If Not Holder.ActiveControl Is Nothing Then
                Dim box As DescriptoBox = CType(Holder.ActiveControl, DescriptoBox)
                If box.SelectionLength > 0 Then
                    MenuEditCut.Enabled = Not box.ReadOnly
                    MenuEditCopy.Enabled = True
                End If
                If TypeOf System.Windows.Forms.Clipboard.GetDataObject.GetData(DataFormats.Text) Is String Then
                    Me.MenuEditPaste.Enabled = Not box.ReadOnly
                End If
                If box.Descriptor.HasErrors Then
                    Me.MenuEditDeleteError.Enabled = True
                End If
            End If
        ElseIf Me.ActiveControl Is TreeView Then
            MenuEditCopy.Enabled = True
            If Not m_CopyNode Is Nothing Then
                MenuEditPaste.Enabled = True
            End If
        End If

        Me.MenuEditFind.Enabled = Not m_Doc Is Nothing
        Me.MenuEditDeleteAllXMLNodes.Enabled = Not m_Doc Is Nothing AndAlso Me.ErrorWindow.ErrorCount > 0
        'Can only delete a node if the treeview is active and has a node selected.
        Me.MenuEditClearNode.Enabled = Not m_Doc Is Nothing AndAlso Me.ActiveControl Is TreeView AndAlso Not TreeView.SelectedNode() Is Nothing
    End Sub

    Private Sub MenuView_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuView.Popup
        Me.MenuViewExpandAll.Enabled = Not m_Doc Is Nothing
        Me.MenuViewCollapseAll.Enabled = Not m_Doc Is Nothing

        If Not m_Doc Is Nothing AndAlso Me.ErrorWindow.ErrorCount > 0 Then
            Me.MenuViewShowErrorWindow.Checked = ErrorWindow.Visible
            Me.MenuViewShowErrorWindow.Enabled = True
        Else
            Me.MenuViewShowErrorWindow.Checked = False
            Me.MenuViewShowErrorWindow.Enabled = False
        End If

        Me.MenuViewVersionInfo.Enabled = Not m_Doc Is Nothing AndAlso Not m_Doc.m_Asm Is Nothing
    End Sub

    Private Sub MenuWindow_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuWindow.Popup
        Me.MenuWindowArrangeIcons.Enabled = MdiClient.HasChildren
        Me.MenuWindowCascade.Enabled = MdiClient.HasChildren
        Me.MenuWindowCloseAll.Enabled = MdiClient.HasChildren
        Me.MenuWindowTile.Enabled = MdiClient.HasChildren
    End Sub

    Private Sub TreeViewContextMenu_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TreeViewContextMenu.Popup
        'A right-click selects the node at the location of the right-click.
        TreeView.SelectedNode = TreeView.GetNodeAt(TreeView.PointToClient(Control.MousePosition))
        Me.TreeViewContextMenuClear.Enabled = Not TreeView Is Nothing AndAlso Not TreeView.SelectedNode Is Nothing
        Me.TreeViewContextMenuOpen.Enabled = Not TreeView Is Nothing AndAlso Not TreeView.SelectedNode Is Nothing
    End Sub

    Private Sub MainStatusBar_PanelClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.StatusBarPanelClickEventArgs) Handles MainStatusBar.PanelClick
        ' Double clicking the Error Status Panel displays all error nodes in
        ' the Assembly tree.

        If e.StatusBarPanel Is Me.StatusPanelErrorInformation AndAlso e.Clicks = 2 AndAlso Not m_Doc Is Nothing AndAlso Me.ErrorWindow.ErrorCount > 0 Then
            ShowAllErrorNode()
        End If
    End Sub

    Public Sub StatusMessage(ByVal message As String)
        ' Displays status messages as tasks are performed.  This function
        ' is used in conjunction with StatusMessageReady to change the mouse
        ' cursor.

        Debug.Assert(message <> READY_STATUS, "Wrong sub called to set the ready status.")

        'The program is doing something, so set the wait cursor.
        Me.Cursor.Current = Cursors.WaitCursor
        Me.MainStatusBar.Panels(0).Text = message
        Me.MainStatusBar.Update()
    End Sub

    Public Const READY_STATUS As String = "Ready"   'The string for the Ready status.

    Public Sub StatusMessageReady()
        ' Set the status back to "Ready".  This function is used in
        ' conjunction with StatusMessage to change the mouse cursor.

        'Set the mouse back to the default pointer.
        Me.Cursor.Current = Cursors.Default
        Me.MainStatusBar.Panels(0).Text = READY_STATUS
        Me.MainStatusBar.Update()
    End Sub

    Public Sub UpdateErrorStatus()
        ' Update the Error Status Panel to display the correct number of
        ' errors.

        Dim errorNumber As Integer = Me.ErrorWindow.ErrorCount

        If errorNumber <> 0 Then
            If errorNumber > 1 Then
                Me.StatusPanelErrorInformation.Text = CStr(errorNumber) & " Errors"
            Else
                Me.StatusPanelErrorInformation.Text = CStr(errorNumber) & " Error"
            End If

            If Me.ErrorWindow.Visible = False Then  'A simple optimization.
                Me.ShowErrorWindow()
                Me.StatusPanelErrorInformation.ToolTipText = "Double click to view all error nodes"
            End If
        Else
            Me.StatusPanelErrorInformation.Text = "No Error"
            Me.HideErrorWindow()
        End If

    End Sub

    Private Sub OpenNodeWindow(ByVal member As MemberNode) Handles ErrorWindow.ErrorListDoubleClick
        ' The window for a member needs to be opened, so first see if it's
        ' already open.  If it is, bring the form to the front.  Otherwise,
        ' constuct a new node window, hookup the cut, copy, paste events, and
        ' show it.

        If member Is Nothing Then
            Exit Sub
        End If

        Dim form As NodeWindow

        For Each form In MdiClient.MdiChildren
            ' We use full signature as the title for each node window so we will search
            ' based on it since it is unique.
            If form.Text = member.FriendlySignatureWithPathAndModifiers Then
                form.BringToFront()
                Return
            End If
        Next

        'At this point, the form is not found in the MdiChildren so build a new one.
        form = New NodeWindow(member, m_Doc, Me)
        AddHandler form.MenuCutClicked, AddressOf MenuEditCut_Click
        AddHandler form.MenuCopyClicked, AddressOf MenuEditCopy_Click
        AddHandler form.MenuPasteClicked, AddressOf MenuEditPaste_Click

        form.MdiParent = Me
        form.Show()

        TreeView.SelectedNode = member
    End Sub

    Private Sub OpenNodeWindow(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TreeView.DoubleClick, TreeViewContextMenuOpen.Click
        ' This overloaded sub maps more events onto OpenNodeWindow.

        OpenNodeWindow(CType(TreeView.SelectedNode, MemberNode))
    End Sub

    Private Sub FindDialog_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles m_FindDialog.Closing
        'Hide the dialog instead of closing it to preserve its state.
        e.Cancel = True
        m_FindDialog.Hide()
    End Sub

    Private Sub UpdateNodeWindow(ByVal destination As MemberNode) Handles TreeView.NodeCopied
        'Update the destination's NodeWindow if it is opened.
        Dim form As NodeWindow
        For Each form In MdiClient.MdiChildren
            If form.Text = destination.FriendlySignatureWithPathAndModifiers Then
                Dim Holder As UserControl = CType(form.ActiveControl, UserControl)
                Holder.Controls.Clear()
                form.BuildFormMembers()
                Exit For
            End If
        Next
    End Sub

    Private Sub ShowAllErrorNode()
        ' Expand the Assembly tree so that all member nodes with errors are
        ' visible.

        StatusMessage("Expanding...")
        TreeView.BeginUpdate()

        'Recursively walk the tree looking for nodes with errors.
        Dim node As MemberNode
        For Each node In TreeView.Nodes
            TraverseTree(node)
        Next

        'After the expansion is complete, seek back to the top of the tree.
        TreeView.SelectedNode = Nothing
        TreeView.Nodes(0).EnsureVisible()

        TreeView.EndUpdate()
        StatusMessageReady()
    End Sub

    Private Sub TraverseTree(ByVal node As MemberNode)
        ' Recursively display all the error nodes.

        If node.HasErrors Then
            'Selecting the node automatically expands the tree to that node.
            TreeView.SelectedNode = node
        End If

        'If the current node has children, look at each of them.
        If node.GetNodeCount(False) > 0 Then
            Dim subnode As MemberNode
            For Each subnode In node.Nodes
                TraverseTree(subnode)
            Next
        End If
    End Sub

    Private Function GetXMLFileName() As String
        ' Return the XML Documentation file's name.  The default name is the
        ' name of the Assembly file with the extension replaced with "xml".

        If m_XMLFileName = "" Then
            Try
                If Microsoft.VisualBasic.Right(m_AsmFileName, 4) = ".exe" Then
                    Return m_AsmFileName.Replace(".exe", ".xml")
                End If
            Catch
            End Try
            Return m_AsmFileName.Replace(".dll", ".xml")
        Else
            Return m_XMLFileName
        End If
    End Function
    Public Sub ShowErrorWindow()
        Me.ErrorPanelSplitter.Show()
        Me.ErrorPanel.Show()
        Me.ErrorWindow.Show()
    End Sub

    Public Sub HideErrorWindow() Handles ErrorWindow.OnCloseButtonClicked
        Me.ErrorPanelSplitter.Hide()
        Me.ErrorPanel.Hide()
        Me.ErrorWindow.Hide()
    End Sub

    Private Sub OnFormClosing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ' If the program is closing and an Assembly file has been opened, then
        ' we need to prompt the user to save.

        If Not m_Doc Is Nothing Then

            If FileDirty Then

                'Ask the user to save.
                Select Case MsgBox(SAVE_MESSAGE, MsgBoxStyle.YesNoCancel)
                    Case MsgBoxResult.Yes
                        If SaveXMLDocumentationFile() = FileResult.Failure Then
                            e.Cancel = True
                        End If

                    Case MsgBoxResult.Cancel
                        e.Cancel = True

                    Case MsgBoxResult.No
                        'Do nothing to shut down.
                End Select

            End If

        End If
    End Sub

    Private Sub MenuEditDeleteError_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuEditDeleteError.Click
        Dim form As NodeWindow = CType(Me.ActiveMdiChild, NodeWindow)
        Dim Holder As UserControl = CType(form.ActiveControl, UserControl)
        Dim box As DescriptoBox = CType(Holder.ActiveControl, DescriptoBox)
        form.RemoveDescriptor(box.Descriptor)
        FileDirty = True
    End Sub

    Private Sub MenuHelpAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuHelpAbout.Click
        ' Open the About form in Dialog Mode
        Dim frm As New frmAbout()
        frm.ShowDialog(Me)
        frm.Dispose()
    End Sub
End Class
