'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Imports System.Reflection 'Namespace for Assembly type

Public Class frmMain
	Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

	Public Sub New()
		MyBase.New()

		'This call is required by the Windows Form Designer.
		InitializeComponent()

		'Add any initialization after the InitializeComponent() call

		' So that we only need to set the title of the application once,
		' we use the AssemblyInfo class (defined in the AssemblyInfo.vb file)
		' to read the AssemblyTitle attribute.
		Dim ainfo As New AssemblyInfo()

		Me.Text = ainfo.Title
		Me.mnuAbout.Text = String.Format("&About {0} ...", ainfo.Title)

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
	Friend WithEvents lblCurrentlyLoadedAssemblies As System.Windows.Forms.Label
	Friend WithEvents cmdListLoadedAssemblies As System.Windows.Forms.Button
	Friend WithEvents lstLoadedAssemblies As System.Windows.Forms.ListBox
	Friend WithEvents cmdAssemblyDetail As System.Windows.Forms.Button
	Friend WithEvents txtDisplayName As System.Windows.Forms.TextBox
	Friend WithEvents lblDisplayName As System.Windows.Forms.Label
	Friend WithEvents txtLocation As System.Windows.Forms.TextBox
	Friend WithEvents lblLocation As System.Windows.Forms.Label
	Friend WithEvents grpViewMetadata As System.Windows.Forms.GroupBox
	Friend WithEvents lstTypes As System.Windows.Forms.ListBox
	Friend WithEvents lblTypes As System.Windows.Forms.Label
	Friend WithEvents lblMembers As System.Windows.Forms.Label
	Friend WithEvents lstMembers As System.Windows.Forms.ListBox
	Friend WithEvents sbInfo As System.Windows.Forms.StatusBar
	Friend WithEvents pnlAssemblies As System.Windows.Forms.StatusBarPanel
	Friend WithEvents pnlTypes As System.Windows.Forms.StatusBarPanel
	Friend WithEvents pnlMembers As System.Windows.Forms.StatusBarPanel
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
		Me.mnuMain = New System.Windows.Forms.MainMenu()
		Me.mnuFile = New System.Windows.Forms.MenuItem()
		Me.mnuExit = New System.Windows.Forms.MenuItem()
		Me.mnuHelp = New System.Windows.Forms.MenuItem()
		Me.mnuAbout = New System.Windows.Forms.MenuItem()
		Me.grpViewMetadata = New System.Windows.Forms.GroupBox()
		Me.cmdAssemblyDetail = New System.Windows.Forms.Button()
		Me.cmdListLoadedAssemblies = New System.Windows.Forms.Button()
		Me.lblCurrentlyLoadedAssemblies = New System.Windows.Forms.Label()
		Me.lstLoadedAssemblies = New System.Windows.Forms.ListBox()
		Me.txtDisplayName = New System.Windows.Forms.TextBox()
		Me.lblDisplayName = New System.Windows.Forms.Label()
		Me.txtLocation = New System.Windows.Forms.TextBox()
		Me.lblLocation = New System.Windows.Forms.Label()
		Me.lstTypes = New System.Windows.Forms.ListBox()
		Me.lblTypes = New System.Windows.Forms.Label()
		Me.lblMembers = New System.Windows.Forms.Label()
		Me.lstMembers = New System.Windows.Forms.ListBox()
		Me.sbInfo = New System.Windows.Forms.StatusBar()
		Me.pnlAssemblies = New System.Windows.Forms.StatusBarPanel()
		Me.pnlTypes = New System.Windows.Forms.StatusBarPanel()
		Me.pnlMembers = New System.Windows.Forms.StatusBarPanel()
		Me.grpViewMetadata.SuspendLayout()
		CType(Me.pnlAssemblies, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.pnlTypes, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.pnlMembers, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'mnuMain
		'
		Me.mnuMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.mnuHelp})
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
		'grpViewMetadata
		'
		Me.grpViewMetadata.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdAssemblyDetail, Me.cmdListLoadedAssemblies})
		Me.grpViewMetadata.Location = New System.Drawing.Point(16, 16)
		Me.grpViewMetadata.Name = "grpViewMetadata"
		Me.grpViewMetadata.Size = New System.Drawing.Size(248, 104)
		Me.grpViewMetadata.TabIndex = 0
		Me.grpViewMetadata.TabStop = False
		Me.grpViewMetadata.Text = "&View Metadata"
		'
		'cmdAssemblyDetail
		'
		Me.cmdAssemblyDetail.Enabled = False
		Me.cmdAssemblyDetail.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.cmdAssemblyDetail.Location = New System.Drawing.Point(24, 64)
		Me.cmdAssemblyDetail.Name = "cmdAssemblyDetail"
		Me.cmdAssemblyDetail.Size = New System.Drawing.Size(200, 24)
		Me.cmdAssemblyDetail.TabIndex = 2
		Me.cmdAssemblyDetail.Text = "Show &Detail for Selected Assembly"
		'
		'cmdListLoadedAssemblies
		'
		Me.cmdListLoadedAssemblies.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.cmdListLoadedAssemblies.Location = New System.Drawing.Point(24, 32)
		Me.cmdListLoadedAssemblies.Name = "cmdListLoadedAssemblies"
		Me.cmdListLoadedAssemblies.Size = New System.Drawing.Size(200, 24)
		Me.cmdListLoadedAssemblies.TabIndex = 1
		Me.cmdListLoadedAssemblies.Text = "List &Loaded Assemblies"
		'
		'lblCurrentlyLoadedAssemblies
		'
		Me.lblCurrentlyLoadedAssemblies.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.lblCurrentlyLoadedAssemblies.Location = New System.Drawing.Point(296, 8)
		Me.lblCurrentlyLoadedAssemblies.Name = "lblCurrentlyLoadedAssemblies"
		Me.lblCurrentlyLoadedAssemblies.Size = New System.Drawing.Size(168, 16)
		Me.lblCurrentlyLoadedAssemblies.TabIndex = 3
		Me.lblCurrentlyLoadedAssemblies.Text = "&Currently Loaded Assemblies"
		'
		'lstLoadedAssemblies
		'
		Me.lstLoadedAssemblies.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
		   Or System.Windows.Forms.AnchorStyles.Right)
		Me.lstLoadedAssemblies.Location = New System.Drawing.Point(288, 24)
		Me.lstLoadedAssemblies.Name = "lstLoadedAssemblies"
		Me.lstLoadedAssemblies.Size = New System.Drawing.Size(214, 95)
		Me.lstLoadedAssemblies.Sorted = True
		Me.lstLoadedAssemblies.TabIndex = 4
		'
		'txtDisplayName
		'
		Me.txtDisplayName.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
		   Or System.Windows.Forms.AnchorStyles.Right)
		Me.txtDisplayName.Location = New System.Drawing.Point(16, 152)
		Me.txtDisplayName.Name = "txtDisplayName"
		Me.txtDisplayName.ReadOnly = True
		Me.txtDisplayName.Size = New System.Drawing.Size(486, 20)
		Me.txtDisplayName.TabIndex = 6
		Me.txtDisplayName.Text = ""
		'
		'lblDisplayName
		'
		Me.lblDisplayName.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.lblDisplayName.Location = New System.Drawing.Point(16, 136)
		Me.lblDisplayName.Name = "lblDisplayName"
		Me.lblDisplayName.Size = New System.Drawing.Size(288, 16)
		Me.lblDisplayName.TabIndex = 5
		Me.lblDisplayName.Text = "F&ully qualified name (DisplayName) for Assembly"
		'
		'txtLocation
		'
		Me.txtLocation.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
		   Or System.Windows.Forms.AnchorStyles.Right)
		Me.txtLocation.Location = New System.Drawing.Point(16, 200)
		Me.txtLocation.Name = "txtLocation"
		Me.txtLocation.ReadOnly = True
		Me.txtLocation.Size = New System.Drawing.Size(486, 20)
		Me.txtLocation.TabIndex = 8
		Me.txtLocation.Text = ""
		'
		'lblLocation
		'
		Me.lblLocation.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.lblLocation.Location = New System.Drawing.Point(16, 184)
		Me.lblLocation.Name = "lblLocation"
		Me.lblLocation.Size = New System.Drawing.Size(288, 16)
		Me.lblLocation.TabIndex = 7
		Me.lblLocation.Text = "&Path and File Name of Assembly"
		'
		'lstTypes
		'
		Me.lstTypes.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
		   Or System.Windows.Forms.AnchorStyles.Right)
		Me.lstTypes.Location = New System.Drawing.Point(16, 248)
		Me.lstTypes.Name = "lstTypes"
		Me.lstTypes.Size = New System.Drawing.Size(496, 121)
		Me.lstTypes.Sorted = True
		Me.lstTypes.TabIndex = 10
		'
		'lblTypes
		'
		Me.lblTypes.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.lblTypes.Location = New System.Drawing.Point(16, 232)
		Me.lblTypes.Name = "lblTypes"
		Me.lblTypes.Size = New System.Drawing.Size(152, 16)
		Me.lblTypes.TabIndex = 9
		Me.lblTypes.Text = "&Types in Assembly"
		'
		'lblMembers
		'
		Me.lblMembers.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.lblMembers.Location = New System.Drawing.Point(16, 376)
		Me.lblMembers.Name = "lblMembers"
		Me.lblMembers.Size = New System.Drawing.Size(152, 16)
		Me.lblMembers.TabIndex = 11
		Me.lblMembers.Text = "&Members in Selected Type"
		'
		'lstMembers
		'
		Me.lstMembers.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
		   Or System.Windows.Forms.AnchorStyles.Left) _
		   Or System.Windows.Forms.AnchorStyles.Right)
		Me.lstMembers.Location = New System.Drawing.Point(16, 392)
		Me.lstMembers.Name = "lstMembers"
		Me.lstMembers.Size = New System.Drawing.Size(496, 121)
		Me.lstMembers.Sorted = True
		Me.lstMembers.TabIndex = 12
		'
		'sbInfo
		'
		Me.sbInfo.Location = New System.Drawing.Point(0, 523)
		Me.sbInfo.Name = "sbInfo"
		Me.sbInfo.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.pnlAssemblies, Me.pnlTypes, Me.pnlMembers})
		Me.sbInfo.ShowPanels = True
		Me.sbInfo.Size = New System.Drawing.Size(520, 22)
		Me.sbInfo.TabIndex = 13
		'
		'pnlAssemblies
		'
		Me.pnlAssemblies.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
		Me.pnlAssemblies.Text = "Assemblies: {0}"
		Me.pnlAssemblies.Width = 168
		'
		'pnlTypes
		'
		Me.pnlTypes.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
		Me.pnlTypes.Text = "Types: {0}"
		Me.pnlTypes.Width = 168
		'
		'pnlMembers
		'
		Me.pnlMembers.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
		Me.pnlMembers.Text = "Members: {0}"
		Me.pnlMembers.Width = 168
		'
		'frmMain
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(520, 545)
		Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.sbInfo, Me.lblMembers, Me.lstMembers, Me.lblTypes, Me.lstTypes, Me.lblLocation, Me.txtLocation, Me.lblDisplayName, Me.txtDisplayName, Me.lstLoadedAssemblies, Me.lblCurrentlyLoadedAssemblies, Me.grpViewMetadata})
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.Menu = Me.mnuMain
		Me.Name = "frmMain"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Title Comes from Assembly Info"
		Me.grpViewMetadata.ResumeLayout(False)
		CType(Me.pnlAssemblies, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.pnlTypes, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.pnlMembers, System.ComponentModel.ISupportInitialize).EndInit()
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

	'This will be used to track the current assembly being investigated.
	'The word Assembly is a keyword in VB.NET, so it must be escaped with [].
	Private CurrentAsm As [Assembly]

	Private Sub cmdListLoadedAssemblies_Click(ByVal sender As System.Object, _
											ByVal e As System.EventArgs) _
											Handles cmdListLoadedAssemblies.Click
		'This method will enumerate and list all currently loaded assemblies into 
		'the adjacent list box. Listed assemblies can subsequently be clicked on 
		'to display further details.

		'Assembly is a keyword in VB.Net, so it must be escaped with [].
		Dim asms() As [Assembly]

		'Retrieve the loaded assemblies from the current AppDomain.
		asms = AppDomain.CurrentDomain.GetAssemblies()

		'Clear out any current listbox entries
		lstLoadedAssemblies.Items.Clear()


		'Enumerate and display the assemblies
		Dim asm As [Assembly]
		For Each asm In asms
			lstLoadedAssemblies.Items.Add(asm.GetName.Name)
		Next

		Me.UpdatePanels(Me.lstLoadedAssemblies.Items.Count)

		'If there are assemblies listed, allow viewing of details
		cmdAssemblyDetail.Enabled = (lstLoadedAssemblies.Items.Count > 0)

		'Clear out previous details
		txtDisplayName.Text = vbNullString
		txtLocation.Text = vbNullString
		lstTypes.Items.Clear()
		lstMembers.Items.Clear()
		CurrentAsm = Nothing

	End Sub

	Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		UpdatePanels(0, 0, 0)
	End Sub

	Private Sub lstLoadedAssemblies_SelectedIndexChanged(ByVal sender As System.Object, _
	   ByVal e As System.EventArgs) _
	   Handles lstLoadedAssemblies.SelectedIndexChanged

		'Clear out previous details
		txtDisplayName.Text = vbNullString
		txtLocation.Text = vbNullString
		lstTypes.Items.Clear()
		lstMembers.Items.Clear()

		' Let go of earlier used reference
		CurrentAsm = Nothing
	End Sub

	Private Sub lstTypes_SelectedIndexChanged(ByVal sender As System.Object, _
	   ByVal e As System.EventArgs) _
	   Handles lstTypes.SelectedIndexChanged
		' This method loads the members for the selected type.
		' Turn on hourglass
		Me.Cursor.Current = Cursors.WaitCursor

		' Get a type reference for the selected type
		Dim t As Type = CurrentAsm.GetType(lstTypes.Text)

		' Clear out the old info
		lstMembers.Items.Clear()

		' Load in the new info, displaying the name and kind of member (field, method, etc.)
		Dim mi As MemberInfo
		For Each mi In t.GetMembers()
			lstMembers.Items.Add(mi.Name & " - " & mi.MemberType.ToString)
		Next

		With Me
			.UpdatePanels(.lstLoadedAssemblies.Items.Count, .lstTypes.Items.Count, .lstMembers.Items.Count)
		End With

		' Turn off hourglass
		Me.Cursor.Current = Cursors.Default
	End Sub

	Private Sub ShowAssemblyDetail(ByVal sender As System.Object, _
	  ByVal e As System.EventArgs) _
	  Handles cmdAssemblyDetail.Click, _
	  lstLoadedAssemblies.DoubleClick
		'Display metadata for the selected assembly. Note that this method handles
		'both the assembly detail button's click event and the assemblies list box's
		'double-click event.


		'Make sure an assembly is selected
		If lstLoadedAssemblies.SelectedIndex = -1 Then
			MessageBox.Show("Please select an assembly to view from the list", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
			Exit Sub
		End If

		' Turn on hourglass
		Me.Cursor.Current = Cursors.WaitCursor

		'Assembly is a keyword in VB.Net, so it must be escaped with [].
		Dim asm As [Assembly]

		'Assign asm to the correct assembly from the collection of 
		'currently loaded(assemblies)
		For Each asm In AppDomain.CurrentDomain.GetAssemblies()
			If asm.GetName.Name = lstLoadedAssemblies.Text Then Exit For
		Next

		'Retain a longer-lived reference to the selected assembly
		CurrentAsm = asm

		'Display details
		txtDisplayName.Text = CurrentAsm.FullName
		txtLocation.Text = CurrentAsm.Location()

		'Display list of types in the assembly
		Dim t As Type
		For Each t In CurrentAsm.GetTypes
			lstTypes.Items.Add(t.FullName)
		Next

		Me.UpdatePanels(Me.lstLoadedAssemblies.Items.Count, Me.lstTypes.Items.Count)

		' Turn off hourglass
		Me.Cursor.Current = Cursors.Default
	End Sub

	' The following three overloaded methods (UpdatePanels) update the status bar's three panels text
	' with the count of the loaded assemblies, types, and members respectively.
	Private Sub UpdatePanels(ByVal AsmCount As Integer)
		UpdatePanels(AsmCount, 0)
	End Sub

	Private Sub UpdatePanels(ByVal AsmCount As Integer, ByVal TypeCount As Integer)
		UpdatePanels(AsmCount, TypeCount, 0)
	End Sub

	Private Sub UpdatePanels(ByVal AsmCount As Integer, ByVal TypeCount As Integer, ByVal MethodCount As Integer)
		Dim pAsm As StatusBarPanel = Me.sbInfo.Panels(0)
		Dim pTyp As StatusBarPanel = Me.sbInfo.Panels(1)
		Dim pMbr As StatusBarPanel = Me.sbInfo.Panels(2)

		Const ASM_TEXT As String = "Assemblies: {0}"
		Const TYP_TEXT As String = "Types: {0}"
		Const MBR_TEXT As String = "Members: {0}"

		pAsm.Text = String.Format(ASM_TEXT, AsmCount.ToString)
		pTyp.Text = String.Format(TYP_TEXT, TypeCount.ToString)
		pMbr.Text = String.Format(MBR_TEXT, MethodCount.ToString)
	End Sub
End Class