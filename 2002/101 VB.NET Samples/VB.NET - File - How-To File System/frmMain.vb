'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Imports System.IO

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
	Friend WithEvents tvwRoot As System.Windows.Forms.TreeView
	Friend WithEvents lblLength As System.Windows.Forms.Label
	Friend WithEvents lblRoot As System.Windows.Forms.Label
	Friend WithEvents lblParent As System.Windows.Forms.Label
	Friend WithEvents lblName As System.Windows.Forms.Label
	Friend WithEvents lblFullName As System.Windows.Forms.Label
	Friend WithEvents lblExtension As System.Windows.Forms.Label
	Friend WithEvents lblLastWriteTime As System.Windows.Forms.Label
	Friend WithEvents lblLastAccessTime As System.Windows.Forms.Label
	Friend WithEvents lblCreationTime As System.Windows.Forms.Label
	Friend WithEvents lblLengthLabel As System.Windows.Forms.Label
	Friend WithEvents lblRootLabel As System.Windows.Forms.Label
	Friend WithEvents lblParentLabel As System.Windows.Forms.Label
	Friend WithEvents Label7 As System.Windows.Forms.Label
	Friend WithEvents Label6 As System.Windows.Forms.Label
	Friend WithEvents Label5 As System.Windows.Forms.Label
	Friend WithEvents Label4 As System.Windows.Forms.Label
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents lblAttributes As System.Windows.Forms.Label
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents mnuRefresh As System.Windows.Forms.MenuItem
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
		Me.mnuMain = New System.Windows.Forms.MainMenu()
		Me.mnuFile = New System.Windows.Forms.MenuItem()
		Me.mnuRefresh = New System.Windows.Forms.MenuItem()
		Me.mnuExit = New System.Windows.Forms.MenuItem()
		Me.mnuHelp = New System.Windows.Forms.MenuItem()
		Me.mnuAbout = New System.Windows.Forms.MenuItem()
		Me.tvwRoot = New System.Windows.Forms.TreeView()
		Me.lblLength = New System.Windows.Forms.Label()
		Me.lblRoot = New System.Windows.Forms.Label()
		Me.lblParent = New System.Windows.Forms.Label()
		Me.lblName = New System.Windows.Forms.Label()
		Me.lblFullName = New System.Windows.Forms.Label()
		Me.lblExtension = New System.Windows.Forms.Label()
		Me.lblLastWriteTime = New System.Windows.Forms.Label()
		Me.lblLastAccessTime = New System.Windows.Forms.Label()
		Me.lblCreationTime = New System.Windows.Forms.Label()
		Me.lblLengthLabel = New System.Windows.Forms.Label()
		Me.lblRootLabel = New System.Windows.Forms.Label()
		Me.lblParentLabel = New System.Windows.Forms.Label()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.lblAttributes = New System.Windows.Forms.Label()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.SuspendLayout()
		'
		'mnuMain
		'
		Me.mnuMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.mnuHelp})
		'
		'mnuFile
		'
		Me.mnuFile.Index = 0
		Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuRefresh, Me.mnuExit})
		Me.mnuFile.Text = "&File"
		'
		'mnuRefresh
		'
		Me.mnuRefresh.Index = 0
		Me.mnuRefresh.Shortcut = System.Windows.Forms.Shortcut.F5
		Me.mnuRefresh.Text = "&Refresh"
		'
		'mnuExit
		'
		Me.mnuExit.Index = 1
		Me.mnuExit.Text = "E&xit"
		'
		'mnuHelp
		'
		Me.mnuHelp.Index = 1
		Me.mnuHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAbout})
		Me.mnuHelp.Text = "&Help"
		'
		'mnuAbout
		'
		Me.mnuAbout.Index = 0
		Me.mnuAbout.Text = "Text Comes from AssemblyInfo"
		'
		'tvwRoot
		'
		Me.tvwRoot.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
		 Or System.Windows.Forms.AnchorStyles.Left) _
		 Or System.Windows.Forms.AnchorStyles.Right)
		Me.tvwRoot.ImageIndex = -1
		Me.tvwRoot.Indent = 19
		Me.tvwRoot.ItemHeight = 16
		Me.tvwRoot.Location = New System.Drawing.Point(8, 8)
		Me.tvwRoot.Name = "tvwRoot"
		Me.tvwRoot.SelectedImageIndex = -1
		Me.tvwRoot.Size = New System.Drawing.Size(392, 195)
		Me.tvwRoot.TabIndex = 0
		'
		'lblLength
		'
		Me.lblLength.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
		 Or System.Windows.Forms.AnchorStyles.Right)
		Me.lblLength.BackColor = System.Drawing.Color.Transparent
		Me.lblLength.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblLength.ForeColor = System.Drawing.Color.Black
		Me.lblLength.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.lblLength.Location = New System.Drawing.Point(120, 435)
		Me.lblLength.Name = "lblLength"
		Me.lblLength.Size = New System.Drawing.Size(280, 20)
		Me.lblLength.TabIndex = 66
		Me.lblLength.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblRoot
		'
		Me.lblRoot.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
		 Or System.Windows.Forms.AnchorStyles.Right)
		Me.lblRoot.BackColor = System.Drawing.Color.Transparent
		Me.lblRoot.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblRoot.ForeColor = System.Drawing.Color.Black
		Me.lblRoot.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.lblRoot.Location = New System.Drawing.Point(120, 411)
		Me.lblRoot.Name = "lblRoot"
		Me.lblRoot.Size = New System.Drawing.Size(280, 20)
		Me.lblRoot.TabIndex = 65
		Me.lblRoot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblParent
		'
		Me.lblParent.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
		 Or System.Windows.Forms.AnchorStyles.Right)
		Me.lblParent.BackColor = System.Drawing.Color.Transparent
		Me.lblParent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblParent.ForeColor = System.Drawing.Color.Black
		Me.lblParent.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.lblParent.Location = New System.Drawing.Point(120, 387)
		Me.lblParent.Name = "lblParent"
		Me.lblParent.Size = New System.Drawing.Size(280, 20)
		Me.lblParent.TabIndex = 64
		Me.lblParent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblName
		'
		Me.lblName.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
		 Or System.Windows.Forms.AnchorStyles.Right)
		Me.lblName.BackColor = System.Drawing.Color.Transparent
		Me.lblName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblName.ForeColor = System.Drawing.Color.Black
		Me.lblName.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.lblName.Location = New System.Drawing.Point(120, 363)
		Me.lblName.Name = "lblName"
		Me.lblName.Size = New System.Drawing.Size(280, 20)
		Me.lblName.TabIndex = 63
		Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblFullName
		'
		Me.lblFullName.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
		 Or System.Windows.Forms.AnchorStyles.Right)
		Me.lblFullName.BackColor = System.Drawing.Color.Transparent
		Me.lblFullName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblFullName.ForeColor = System.Drawing.Color.Black
		Me.lblFullName.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.lblFullName.Location = New System.Drawing.Point(120, 339)
		Me.lblFullName.Name = "lblFullName"
		Me.lblFullName.Size = New System.Drawing.Size(280, 20)
		Me.lblFullName.TabIndex = 62
		Me.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblExtension
		'
		Me.lblExtension.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
		 Or System.Windows.Forms.AnchorStyles.Right)
		Me.lblExtension.BackColor = System.Drawing.Color.Transparent
		Me.lblExtension.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblExtension.ForeColor = System.Drawing.Color.Black
		Me.lblExtension.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.lblExtension.Location = New System.Drawing.Point(120, 315)
		Me.lblExtension.Name = "lblExtension"
		Me.lblExtension.Size = New System.Drawing.Size(280, 20)
		Me.lblExtension.TabIndex = 61
		Me.lblExtension.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblLastWriteTime
		'
		Me.lblLastWriteTime.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
		 Or System.Windows.Forms.AnchorStyles.Right)
		Me.lblLastWriteTime.BackColor = System.Drawing.Color.Transparent
		Me.lblLastWriteTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblLastWriteTime.ForeColor = System.Drawing.Color.Black
		Me.lblLastWriteTime.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.lblLastWriteTime.Location = New System.Drawing.Point(120, 283)
		Me.lblLastWriteTime.Name = "lblLastWriteTime"
		Me.lblLastWriteTime.Size = New System.Drawing.Size(280, 20)
		Me.lblLastWriteTime.TabIndex = 60
		Me.lblLastWriteTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblLastAccessTime
		'
		Me.lblLastAccessTime.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
		 Or System.Windows.Forms.AnchorStyles.Right)
		Me.lblLastAccessTime.BackColor = System.Drawing.Color.Transparent
		Me.lblLastAccessTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblLastAccessTime.ForeColor = System.Drawing.Color.Black
		Me.lblLastAccessTime.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.lblLastAccessTime.Location = New System.Drawing.Point(120, 259)
		Me.lblLastAccessTime.Name = "lblLastAccessTime"
		Me.lblLastAccessTime.Size = New System.Drawing.Size(280, 20)
		Me.lblLastAccessTime.TabIndex = 59
		Me.lblLastAccessTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblCreationTime
		'
		Me.lblCreationTime.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
		 Or System.Windows.Forms.AnchorStyles.Right)
		Me.lblCreationTime.BackColor = System.Drawing.Color.Transparent
		Me.lblCreationTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblCreationTime.ForeColor = System.Drawing.Color.Black
		Me.lblCreationTime.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.lblCreationTime.Location = New System.Drawing.Point(120, 235)
		Me.lblCreationTime.Name = "lblCreationTime"
		Me.lblCreationTime.Size = New System.Drawing.Size(280, 20)
		Me.lblCreationTime.TabIndex = 58
		Me.lblCreationTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblLengthLabel
		'
		Me.lblLengthLabel.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
		Me.lblLengthLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.lblLengthLabel.Location = New System.Drawing.Point(8, 434)
		Me.lblLengthLabel.Name = "lblLengthLabel"
		Me.lblLengthLabel.Size = New System.Drawing.Size(104, 23)
		Me.lblLengthLabel.TabIndex = 57
		Me.lblLengthLabel.Text = "Length"
		Me.lblLengthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'lblRootLabel
		'
		Me.lblRootLabel.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
		Me.lblRootLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.lblRootLabel.Location = New System.Drawing.Point(8, 410)
		Me.lblRootLabel.Name = "lblRootLabel"
		Me.lblRootLabel.Size = New System.Drawing.Size(104, 23)
		Me.lblRootLabel.TabIndex = 56
		Me.lblRootLabel.Text = "Root"
		Me.lblRootLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'lblParentLabel
		'
		Me.lblParentLabel.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
		Me.lblParentLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.lblParentLabel.Location = New System.Drawing.Point(8, 386)
		Me.lblParentLabel.Name = "lblParentLabel"
		Me.lblParentLabel.Size = New System.Drawing.Size(104, 23)
		Me.lblParentLabel.TabIndex = 55
		Me.lblParentLabel.Text = "Parent"
		Me.lblParentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label7
		'
		Me.Label7.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
		Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.Label7.Location = New System.Drawing.Point(8, 362)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(104, 23)
		Me.Label7.TabIndex = 54
		Me.Label7.Text = "Name"
		Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label6
		'
		Me.Label6.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
		Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.Label6.Location = New System.Drawing.Point(8, 338)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(104, 23)
		Me.Label6.TabIndex = 53
		Me.Label6.Text = "Full Name"
		Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label5
		'
		Me.Label5.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
		Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.Label5.Location = New System.Drawing.Point(8, 314)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(104, 23)
		Me.Label5.TabIndex = 52
		Me.Label5.Text = "Extension"
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label4
		'
		Me.Label4.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
		Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.Label4.Location = New System.Drawing.Point(8, 282)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(104, 23)
		Me.Label4.TabIndex = 51
		Me.Label4.Text = "Last Write Time"
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label3
		'
		Me.Label3.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
		Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.Label3.Location = New System.Drawing.Point(8, 258)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(104, 23)
		Me.Label3.TabIndex = 50
		Me.Label3.Text = "Last Access Time"
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label2
		'
		Me.Label2.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
		Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.Label2.Location = New System.Drawing.Point(8, 234)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(104, 23)
		Me.Label2.TabIndex = 49
		Me.Label2.Text = "Creation Time"
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'lblAttributes
		'
		Me.lblAttributes.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
		 Or System.Windows.Forms.AnchorStyles.Right)
		Me.lblAttributes.BackColor = System.Drawing.Color.Transparent
		Me.lblAttributes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblAttributes.ForeColor = System.Drawing.Color.Black
		Me.lblAttributes.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.lblAttributes.Location = New System.Drawing.Point(120, 211)
		Me.lblAttributes.Name = "lblAttributes"
		Me.lblAttributes.Size = New System.Drawing.Size(280, 20)
		Me.lblAttributes.TabIndex = 48
		Me.lblAttributes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Label1
		'
		Me.Label1.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
		Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.Label1.Location = New System.Drawing.Point(8, 210)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(104, 23)
		Me.Label1.TabIndex = 47
		Me.Label1.Text = "Attributes"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'frmMain
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(408, 458)
		Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblLength, Me.lblRoot, Me.lblParent, Me.lblName, Me.lblFullName, Me.lblExtension, Me.lblLastWriteTime, Me.lblLastAccessTime, Me.lblCreationTime, Me.lblLengthLabel, Me.lblRootLabel, Me.lblParentLabel, Me.Label7, Me.Label6, Me.Label5, Me.Label4, Me.Label3, Me.Label2, Me.lblAttributes, Me.Label1, Me.tvwRoot})
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Menu = Me.mnuMain
		Me.MinimumSize = New System.Drawing.Size(416, 472)
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

		LoadTreeView()
	End Sub
#End Region

	' Use this text for each "dummy" node in the
	' TreeView. See comments below for more information.
	Private Const DUMMY As String = "DUMMY"

	' Keep track of whether a particular
	' item in the TreeView control is a file 
	' or a folder.
	Private Enum ItemType
		Directory = 1
		File = 2
	End Enum

	Private Sub mnuRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRefresh.Click
		LoadTreeView()
	End Sub

	Private Sub tvwRoot_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvwRoot.AfterSelect
		Try
			With e.Node
				Select Case .Tag
					Case ItemType.File
						' FileInfo objects don't supply 
						' Parent or Root properties:
						lblParent.Text = String.Empty
						lblRoot.Text = String.Empty

						' Disable/Enable labels.
						lblParentLabel.Enabled = False
						lblRootLabel.Enabled = False
						lblLengthLabel.Enabled = True

						' Get a FileInfo object corresponding to 
						' the selected file, then display its 
						' properties.
						Dim fi As New FileInfo(.FullPath)
						lblLength.Text = fi.Length.ToString
						DisplayFSIProperties(fi)

					Case ItemType.Directory
						' DirectoryInfo objects don't provide
						' a Length property:
						lblLength.Text = String.Empty

						' Disable/Enable labels.
						lblLengthLabel.Enabled = False
						lblParentLabel.Enabled = True
						lblRootLabel.Enabled = True

						' Get a DirectoryInfo object corresponding
						' to the selected directory, then display
						' its properties.
						Dim di As New DirectoryInfo(.FullPath)
						lblParent.Text = di.Parent.Name
						lblRoot.Text = di.Root.Name
						DisplayFSIProperties(di)
					Case Else
						' Clear out the labels.
						ClearProperties()
				End Select
			End With
		Catch exp As Exception
			MessageBox.Show(exp.Message, Me.Text)
		End Try
	End Sub

	Private Sub tvwRoot_BeforeExpand(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles tvwRoot.BeforeExpand

		' Before expanding a node, remove existing child nodes. 
		' This emulates Windows Explorer's behavior -- if
		' there are directories and/or files within the drive, the
		' TreeView will display them. If not, the + sign simply 
		' disappears when you attempt to expand the node.

		Try
			e.Node.Nodes.Clear()

			' Go out and get the folder and file names.
			AddFolders(e.Node)
			AddFiles(e.Node)

		Catch exp As IOException
			' Perhaps the drive isn't ready. In that
			' case, simply disregard the error.
		Catch exp As Exception
			' If any other error occurs, display an alert.
			MessageBox.Show(exp.ToString, Me.Text)
		End Try
	End Sub

	Private Sub AddFiles(ByVal nod As TreeNode)
		Dim strPath As String = nod.FullPath
		Dim strFile As String

		With nod
			For Each strFile In Directory.GetFiles(strPath)
				With nod.Nodes.Add(Path.GetFileName(strFile))
					.Tag = ItemType.File
				End With
			Next
		End With
	End Sub

	Private Sub AddFolders(ByVal nod As TreeNode)
		Dim strPath As String = nod.FullPath
		Dim strDir As String

		With nod
			For Each strDir In Directory.GetDirectories(strPath)
				' Path.GetFileName returns just the file name portion
				' of the full path returned from the GetDirectories
				' method.
				With nod.Nodes.Add(Path.GetFileName(strDir))
					' Keep track that this item 
					' is, in fact, a directory. We'll need
					' that info later. 
					.Tag = ItemType.Directory

					' Add the DUMMY node, so the + sign appears.
					.Nodes.Add(DUMMY)
				End With
			Next
		End With
	End Sub

	Private Sub ClearProperties()
		lblParent.Text = String.Empty
		lblRoot.Text = String.Empty
		lblLength.Text = String.Empty
		lblAttributes.Text = String.Empty
		lblCreationTime.Text = String.Empty
		lblLastAccessTime.Text = String.Empty
		lblLastWriteTime.Text = String.Empty
		lblExtension.Text = String.Empty
		lblFullName.Text = String.Empty
		lblName.Text = String.Empty
	End Sub

	Private Sub DisplayFSIProperties(ByVal fsi As FileSystemInfo)

		' Display properties common to both DirectoryInfo
		' and FileInfo objects. Note that this works 
		' because both objects inherit from FileSystemInfo.
		lblAttributes.Text = fsi.Attributes.ToString
		lblCreationTime.Text = fsi.CreationTime.ToString
		lblLastAccessTime.Text = fsi.LastAccessTime.ToString
		lblLastWriteTime.Text = fsi.LastWriteTime.ToString
		lblExtension.Text = fsi.Extension
		lblFullName.Text = fsi.FullName
		lblName.Text = fsi.Name
	End Sub

	Private Sub LoadTreeView()
		Dim strDrive As String

		' Loop through all the drives installed on the 
		' computer, adding a node for each. In addition,
		' add a DUMMY node under each existing node,
		' so that the plus sign will appear.

		' Directory.GetLogicalDrives returns an array
		' of strings, each representing one of the
		' installed drives. The .NET Framework doesn't
		' supply methods for determining information about
		' drives -- use the COM-based FileSystemInfo class
		' instead.

		tvwRoot.Nodes.Clear()
		For Each strDrive In Directory.GetLogicalDrives()
			With tvwRoot.Nodes.Add(strDrive)
				.Nodes.Add(DUMMY)
			End With
		Next
	End Sub

End Class