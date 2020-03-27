'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Public Class frmMain
	Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

	Public Sub New()
		MyBase.New()

		'This call is required by the Windows Form Designer.
		InitializeComponent()

		'Add any initialization after the InitializeComponent() call

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
	Friend WithEvents mnuHelp As System.Windows.Forms.MenuItem
	Friend WithEvents mnuAbout As System.Windows.Forms.MenuItem
    Friend WithEvents mnuWindow As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCascade As System.Windows.Forms.MenuItem
    Friend WithEvents mnuNew As System.Windows.Forms.MenuItem
    Friend WithEvents mnuTileVertical As System.Windows.Forms.MenuItem
    Friend WithEvents mnuTileHorizontal As System.Windows.Forms.MenuItem
    Friend WithEvents sbarEdit As System.Windows.Forms.StatusBar
    Friend WithEvents mnuView As System.Windows.Forms.MenuItem
    Friend WithEvents mnuStatusBar As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuNew = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuView = New System.Windows.Forms.MenuItem()
        Me.mnuStatusBar = New System.Windows.Forms.MenuItem()
        Me.mnuWindow = New System.Windows.Forms.MenuItem()
        Me.mnuCascade = New System.Windows.Forms.MenuItem()
        Me.mnuTileVertical = New System.Windows.Forms.MenuItem()
        Me.mnuTileHorizontal = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.sbarEdit = New System.Windows.Forms.StatusBar()
        Me.SuspendLayout()
        '
        'mnuMain
        '
        Me.mnuMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.mnuView, Me.mnuWindow, Me.mnuHelp})
        '
        'mnuFile
        '
        Me.mnuFile.Index = 0
        Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuNew, Me.mnuExit})
        Me.mnuFile.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mnuFile.Text = "&File"
        '
        'mnuNew
        '
        Me.mnuNew.DefaultItem = True
        Me.mnuNew.Index = 0
        Me.mnuNew.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mnuNew.Text = "&New"
        '
        'mnuExit
        '
        Me.mnuExit.Index = 1
        Me.mnuExit.MergeOrder = 10
        Me.mnuExit.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mnuExit.Text = "E&xit"
        '
        'mnuView
        '
        Me.mnuView.Index = 1
        Me.mnuView.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuStatusBar})
        Me.mnuView.MergeOrder = 10
        Me.mnuView.Text = "&View"
        '
        'mnuStatusBar
        '
        Me.mnuStatusBar.Checked = True
        Me.mnuStatusBar.Index = 0
        Me.mnuStatusBar.Text = "&Status Bar"
        '
        'mnuWindow
        '
        Me.mnuWindow.Index = 2
        Me.mnuWindow.MdiList = True
        Me.mnuWindow.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuCascade, Me.mnuTileVertical, Me.mnuTileHorizontal})
        Me.mnuWindow.MergeOrder = 20
        Me.mnuWindow.Text = "&Window"
        '
        'mnuCascade
        '
        Me.mnuCascade.Index = 0
        Me.mnuCascade.Text = "&Cascade"
        '
        'mnuTileVertical
        '
        Me.mnuTileVertical.Index = 1
        Me.mnuTileVertical.Text = "Tile &Vertical"
        '
        'mnuTileHorizontal
        '
        Me.mnuTileHorizontal.Index = 2
        Me.mnuTileHorizontal.Text = "Tile &Horizontal"
        '
        'mnuHelp
        '
        Me.mnuHelp.Index = 3
        Me.mnuHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAbout})
        Me.mnuHelp.MergeOrder = 30
        Me.mnuHelp.Text = "&Help"
        '
        'mnuAbout
        '
        Me.mnuAbout.Index = 0
        Me.mnuAbout.Text = "Text Comes from AssemblyInfo"
        '
        'sbarEdit
        '
        Me.sbarEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.sbarEdit.Location = New System.Drawing.Point(0, 268)
        Me.sbarEdit.Name = "sbarEdit"
        Me.sbarEdit.Size = New System.Drawing.Size(424, 22)
        Me.sbarEdit.TabIndex = 1
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(424, 290)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.sbarEdit})
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Menu = Me.mnuMain
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Title Comes from Assembly Info"
        Me.ResumeLayout(False)

    End Sub

#End Region


#Region " Standard Menu Code "
	' <System.Diagnostics.DebuggerStepThrough()> has been added to some procedures since they are
	' not the focus of the demo. Remove them if you wish to debug the procedures.
	' This code simply shows the About form.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub mnuAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAbout.Click
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

#Region " Form Load "
	' <System.Diagnostics.DebuggerStepThrough()> has been added to some procedures since they are
	' not the focus of the demo. Remove them if you wish to debug the procedures.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
		' So that we only need to set the title of the application once,
		' we use the AssemblyInfo class (defined in the AssemblyInfo.vb file)
		' to read the AssemblyTitle attribute.
		Dim ainfo As New AssemblyInfo()

		Me.Text = ainfo.Title
		Me.mnuAbout.Text = String.Format("&About {0} ...", ainfo.Title)

    End Sub
#End Region

    Private Sub mnuCascade_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCascade.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub mnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNew.Click
        ' Attempt to create a new child form.
        AddNew()
    End Sub

    Private Sub AddNew()
        Try
            Dim frm As New frmEdit()
            Static intChild As Integer

            intChild += 1
            frm.MdiParent = Me
            frm.Text = "Child " & intChild
            frm.Show()
        Catch exp As Exception
            MessageBox.Show(exp.Message, Me.Text)
        End Try
    End Sub

    Private Sub mnuStatusBar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuStatusBar.Click
        ' Toggle the visibility of the status bar.
        Dim blnShow As Boolean = Not mnuStatusBar.Checked
        mnuStatusBar.Checked = blnShow
        sbarEdit.Visible = blnShow
    End Sub

    Private Sub mnuTileHorizontal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTileHorizontal.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub mnuTileVertical_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTileVertical.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub mnuView_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuView.Popup
        ' Determine how to treat items on the View menu.
        mnuStatusBar.Checked = sbarEdit.Visible
    End Sub

    Private Sub mnuWindow_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuWindow.Popup

        ' Enable/disable child form-handling menu items.
        Dim blnEnable As Boolean = (Me.MdiChildren.Length > 0)
        mnuCascade.Enabled = blnEnable
        mnuTileHorizontal.Enabled = blnEnable
        mnuTileVertical.Enabled = blnEnable
    End Sub

    Private Sub ClearStatus(ByVal sender As Object, ByVal e As System.EventArgs) _
     Handles mnuAbout.Click, mnuCascade.Click, mnuExit.Click, mnuFile.Click, mnuHelp.Click, _
     mnuNew.Click, mnuStatusBar.Click, mnuTileHorizontal.Click, mnuTileVertical.Click, _
     mnuView.Click, mnuWindow.Click
        ' Once you click a menu item, clear the status bar.
        ClearStatusBar()
    End Sub

    Public Sub ClearStatusBar()
        sbarEdit.Text = String.Empty
    End Sub

    Private Sub HandleSelect(ByVal sender As Object, ByVal e As System.EventArgs) _
     Handles mnuStatusBar.Select, mnuAbout.Select, mnuCascade.Select, mnuExit.Select, _
     mnuNew.Select, mnuTileHorizontal.Select, mnuTileVertical.Select, mnuFile.Select, _
     mnuView.Select, mnuWindow.Select, mnuHelp.Select
        Dim strText As String

        If sender Is mnuStatusBar Then
            strText = "Toggle display of the status bar"
        ElseIf sender Is mnuAbout Then
            strText = "Display the About dialog box"
        ElseIf sender Is mnuCascade Then
            strText = "Cascade child windows"
        ElseIf sender Is mnuExit Then
            strText = "Exit demonstration"
        ElseIf sender Is mnuNew Then
            strText = "Create new child window"
        ElseIf sender Is mnuTileHorizontal Then
            strText = "Tile windows horizontally"
        ElseIf sender Is mnuTileVertical Then
            strText = "Tile windows vertically"
        Else
            strText = String.Empty
        End If

        WriteToStatusBar(strText)
    End Sub

    Public Sub WriteToStatusBar(ByVal Text As String)
        ' Make this procedure public so that the child form(s)
        ' can call it, as well.
        sbarEdit.Text = Text
    End Sub

End Class