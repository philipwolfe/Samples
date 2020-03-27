'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Imports System.Configuration
Imports System.Collections
Imports System.Xml

Public Class frmMain
	Inherits System.Windows.Forms.Form

	' Sortes the name of our configuration file.
	Private mstrCFGFile As String
	' From the System.Collections Namespace.
	' Note the version returned by 
	' ConfigurationSettings.AppSettings is
	' read-only even though instances of
	' Specialized.NameValueCollection can be 
	' read-write.
	Dim mAppSet As Specialized.NameValueCollection

	' Custom class to work with app settings
	Private mcustAppSettings As AppSettings
	' Individual setting
	Private mcustAppSet As AppSetting
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
	Friend WithEvents tabOptions As System.Windows.Forms.TabControl
	Friend WithEvents pgeAS As System.Windows.Forms.TabPage
	Friend WithEvents pgeCustom As System.Windows.Forms.TabPage
	Friend WithEvents lblValue As System.Windows.Forms.Label
	Friend WithEvents txtKey As System.Windows.Forms.TextBox
	Friend WithEvents cmdReadValue As System.Windows.Forms.Button
	Friend WithEvents cmdListByIndex As System.Windows.Forms.Button
	Friend WithEvents cmdListByKey As System.Windows.Forms.Button
	Friend WithEvents lstSettings As System.Windows.Forms.ListBox
	Friend WithEvents cmdLoadAS As System.Windows.Forms.Button
	Friend WithEvents cmdLoadCfg As System.Windows.Forms.Button
	Friend WithEvents chkAutoSave As System.Windows.Forms.CheckBox
	Friend WithEvents cmdListAllSettings As System.Windows.Forms.Button
	Friend WithEvents lvSettings As System.Windows.Forms.ListView
	Friend WithEvents chKey As System.Windows.Forms.ColumnHeader
	Friend WithEvents chValue As System.Windows.Forms.ColumnHeader
	Friend WithEvents txtSettingKey As System.Windows.Forms.TextBox
	Friend WithEvents lblSettingKey As System.Windows.Forms.Label
	Friend WithEvents lblSettingValue As System.Windows.Forms.Label
	Friend WithEvents txtSettingValue As System.Windows.Forms.TextBox
	Friend WithEvents cmdAddNew As System.Windows.Forms.Button
	Friend WithEvents cmdUpdate As System.Windows.Forms.Button
	Friend WithEvents cmdSave As System.Windows.Forms.Button
	Friend WithEvents cmdUnload As System.Windows.Forms.Button
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
		Me.mnuMain = New System.Windows.Forms.MainMenu()
		Me.mnuFile = New System.Windows.Forms.MenuItem()
		Me.mnuExit = New System.Windows.Forms.MenuItem()
		Me.mnuHelp = New System.Windows.Forms.MenuItem()
		Me.mnuAbout = New System.Windows.Forms.MenuItem()
		Me.tabOptions = New System.Windows.Forms.TabControl()
		Me.pgeAS = New System.Windows.Forms.TabPage()
		Me.lblValue = New System.Windows.Forms.Label()
		Me.txtKey = New System.Windows.Forms.TextBox()
		Me.cmdReadValue = New System.Windows.Forms.Button()
		Me.cmdListByIndex = New System.Windows.Forms.Button()
		Me.cmdListByKey = New System.Windows.Forms.Button()
		Me.lstSettings = New System.Windows.Forms.ListBox()
		Me.cmdLoadAS = New System.Windows.Forms.Button()
		Me.pgeCustom = New System.Windows.Forms.TabPage()
		Me.cmdUnload = New System.Windows.Forms.Button()
		Me.cmdSave = New System.Windows.Forms.Button()
		Me.cmdUpdate = New System.Windows.Forms.Button()
		Me.cmdAddNew = New System.Windows.Forms.Button()
		Me.lblSettingValue = New System.Windows.Forms.Label()
		Me.txtSettingValue = New System.Windows.Forms.TextBox()
		Me.lblSettingKey = New System.Windows.Forms.Label()
		Me.txtSettingKey = New System.Windows.Forms.TextBox()
		Me.lvSettings = New System.Windows.Forms.ListView()
		Me.chKey = New System.Windows.Forms.ColumnHeader()
		Me.chValue = New System.Windows.Forms.ColumnHeader()
		Me.cmdListAllSettings = New System.Windows.Forms.Button()
		Me.chkAutoSave = New System.Windows.Forms.CheckBox()
		Me.cmdLoadCfg = New System.Windows.Forms.Button()
		Me.tabOptions.SuspendLayout()
		Me.pgeAS.SuspendLayout()
		Me.pgeCustom.SuspendLayout()
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
		'tabOptions
		'
		Me.tabOptions.Controls.AddRange(New System.Windows.Forms.Control() {Me.pgeAS, Me.pgeCustom})
		Me.tabOptions.Location = New System.Drawing.Point(8, 8)
		Me.tabOptions.Name = "tabOptions"
		Me.tabOptions.SelectedIndex = 0
		Me.tabOptions.Size = New System.Drawing.Size(456, 256)
		Me.tabOptions.TabIndex = 0
		'
		'pgeAS
		'
		Me.pgeAS.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblValue, Me.txtKey, Me.cmdReadValue, Me.cmdListByIndex, Me.cmdListByKey, Me.lstSettings, Me.cmdLoadAS})
		Me.pgeAS.Location = New System.Drawing.Point(4, 22)
		Me.pgeAS.Name = "pgeAS"
		Me.pgeAS.Size = New System.Drawing.Size(448, 230)
		Me.pgeAS.TabIndex = 0
		Me.pgeAS.Text = "AppSettings"
		'
		'lblValue
		'
		Me.lblValue.Location = New System.Drawing.Point(8, 169)
		Me.lblValue.Name = "lblValue"
		Me.lblValue.Size = New System.Drawing.Size(120, 48)
		Me.lblValue.TabIndex = 6
		Me.lblValue.Text = CType(configurationAppSettings.GetValue("lblValue.Text", GetType(System.String)), String)
		'
		'txtKey
		'
		Me.txtKey.Location = New System.Drawing.Point(8, 137)
		Me.txtKey.Name = "txtKey"
		Me.txtKey.Size = New System.Drawing.Size(120, 20)
		Me.txtKey.TabIndex = 5
		Me.txtKey.Text = ""
		'
		'cmdReadValue
		'
		Me.cmdReadValue.Enabled = False
		Me.cmdReadValue.Location = New System.Drawing.Point(8, 105)
		Me.cmdReadValue.Name = "cmdReadValue"
		Me.cmdReadValue.Size = New System.Drawing.Size(120, 23)
		Me.cmdReadValue.TabIndex = 4
		Me.cmdReadValue.Text = "&Read Value"
		'
		'cmdListByIndex
		'
		Me.cmdListByIndex.Enabled = False
		Me.cmdListByIndex.Location = New System.Drawing.Point(8, 73)
		Me.cmdListByIndex.Name = "cmdListByIndex"
		Me.cmdListByIndex.Size = New System.Drawing.Size(120, 23)
		Me.cmdListByIndex.TabIndex = 3
		Me.cmdListByIndex.Text = "List By &Index"
		'
		'cmdListByKey
		'
		Me.cmdListByKey.Enabled = False
		Me.cmdListByKey.Location = New System.Drawing.Point(8, 41)
		Me.cmdListByKey.Name = "cmdListByKey"
		Me.cmdListByKey.Size = New System.Drawing.Size(120, 23)
		Me.cmdListByKey.TabIndex = 2
		Me.cmdListByKey.Text = "List By &Key"
		'
		'lstSettings
		'
		Me.lstSettings.Location = New System.Drawing.Point(136, 9)
		Me.lstSettings.Name = "lstSettings"
		Me.lstSettings.Size = New System.Drawing.Size(304, 212)
		Me.lstSettings.TabIndex = 0
		'
		'cmdLoadAS
		'
		Me.cmdLoadAS.Location = New System.Drawing.Point(8, 9)
		Me.cmdLoadAS.Name = "cmdLoadAS"
		Me.cmdLoadAS.Size = New System.Drawing.Size(120, 23)
		Me.cmdLoadAS.TabIndex = 1
		Me.cmdLoadAS.Text = "&Load AppSettings"
		'
		'pgeCustom
		'
		Me.pgeCustom.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdUnload, Me.cmdSave, Me.cmdUpdate, Me.cmdAddNew, Me.lblSettingValue, Me.txtSettingValue, Me.lblSettingKey, Me.txtSettingKey, Me.lvSettings, Me.cmdListAllSettings, Me.chkAutoSave, Me.cmdLoadCfg})
		Me.pgeCustom.Location = New System.Drawing.Point(4, 22)
		Me.pgeCustom.Name = "pgeCustom"
		Me.pgeCustom.Size = New System.Drawing.Size(448, 230)
		Me.pgeCustom.TabIndex = 1
		Me.pgeCustom.Text = "Custom"
		'
		'cmdUnload
		'
		Me.cmdUnload.Enabled = False
		Me.cmdUnload.Location = New System.Drawing.Point(8, 200)
		Me.cmdUnload.Name = "cmdUnload"
		Me.cmdUnload.Size = New System.Drawing.Size(140, 23)
		Me.cmdUnload.TabIndex = 11
		Me.cmdUnload.Text = "&Unload"
		'
		'cmdSave
		'
		Me.cmdSave.Enabled = False
		Me.cmdSave.Location = New System.Drawing.Point(8, 168)
		Me.cmdSave.Name = "cmdSave"
		Me.cmdSave.Size = New System.Drawing.Size(140, 23)
		Me.cmdSave.TabIndex = 5
		Me.cmdSave.Text = "&Save"
		'
		'cmdUpdate
		'
		Me.cmdUpdate.Enabled = False
		Me.cmdUpdate.Location = New System.Drawing.Point(8, 136)
		Me.cmdUpdate.Name = "cmdUpdate"
		Me.cmdUpdate.Size = New System.Drawing.Size(140, 23)
		Me.cmdUpdate.TabIndex = 4
		Me.cmdUpdate.Text = "&Update"
		'
		'cmdAddNew
		'
		Me.cmdAddNew.Enabled = False
		Me.cmdAddNew.Location = New System.Drawing.Point(8, 104)
		Me.cmdAddNew.Name = "cmdAddNew"
		Me.cmdAddNew.Size = New System.Drawing.Size(140, 23)
		Me.cmdAddNew.TabIndex = 3
		Me.cmdAddNew.Text = "&Add New Pair"
		'
		'lblSettingValue
		'
		Me.lblSettingValue.Location = New System.Drawing.Point(152, 200)
		Me.lblSettingValue.Name = "lblSettingValue"
		Me.lblSettingValue.Size = New System.Drawing.Size(50, 23)
		Me.lblSettingValue.TabIndex = 9
		Me.lblSettingValue.Text = "&Value"
		'
		'txtSettingValue
		'
		Me.txtSettingValue.Location = New System.Drawing.Point(208, 200)
		Me.txtSettingValue.Name = "txtSettingValue"
		Me.txtSettingValue.Size = New System.Drawing.Size(232, 20)
		Me.txtSettingValue.TabIndex = 10
		Me.txtSettingValue.Text = ""
		'
		'lblSettingKey
		'
		Me.lblSettingKey.Location = New System.Drawing.Point(152, 176)
		Me.lblSettingKey.Name = "lblSettingKey"
		Me.lblSettingKey.Size = New System.Drawing.Size(50, 23)
		Me.lblSettingKey.TabIndex = 7
		Me.lblSettingKey.Text = "&Key"
		'
		'txtSettingKey
		'
		Me.txtSettingKey.Location = New System.Drawing.Point(208, 176)
		Me.txtSettingKey.Name = "txtSettingKey"
		Me.txtSettingKey.Size = New System.Drawing.Size(232, 20)
		Me.txtSettingKey.TabIndex = 8
		Me.txtSettingKey.Text = ""
		'
		'lvSettings
		'
		Me.lvSettings.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chKey, Me.chValue})
		Me.lvSettings.FullRowSelect = True
		Me.lvSettings.Location = New System.Drawing.Point(152, 8)
		Me.lvSettings.MultiSelect = False
		Me.lvSettings.Name = "lvSettings"
		Me.lvSettings.Size = New System.Drawing.Size(288, 160)
		Me.lvSettings.Sorting = System.Windows.Forms.SortOrder.Ascending
		Me.lvSettings.TabIndex = 6
		Me.lvSettings.View = System.Windows.Forms.View.Details
		'
		'chKey
		'
		Me.chKey.Text = "Key"
		Me.chKey.Width = 100
		'
		'chValue
		'
		Me.chValue.Text = "Value"
		Me.chValue.Width = 175
		'
		'cmdListAllSettings
		'
		Me.cmdListAllSettings.Enabled = False
		Me.cmdListAllSettings.Location = New System.Drawing.Point(8, 72)
		Me.cmdListAllSettings.Name = "cmdListAllSettings"
		Me.cmdListAllSettings.Size = New System.Drawing.Size(140, 23)
		Me.cmdListAllSettings.TabIndex = 2
		Me.cmdListAllSettings.Text = "&List All Settings"
		'
		'chkAutoSave
		'
		Me.chkAutoSave.Location = New System.Drawing.Point(8, 40)
		Me.chkAutoSave.Name = "chkAutoSave"
		Me.chkAutoSave.Size = New System.Drawing.Size(140, 23)
		Me.chkAutoSave.TabIndex = 1
		Me.chkAutoSave.Text = "&Enable AutoSave?"
		'
		'cmdLoadCfg
		'
		Me.cmdLoadCfg.Location = New System.Drawing.Point(8, 8)
		Me.cmdLoadCfg.Name = "cmdLoadCfg"
		Me.cmdLoadCfg.Size = New System.Drawing.Size(140, 23)
		Me.cmdLoadCfg.TabIndex = 0
		Me.cmdLoadCfg.Text = "Load &Config"
		'
		'frmMain
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(474, 275)
		Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.tabOptions})
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.Menu = Me.mnuMain
		Me.Name = "frmMain"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Title Comes from Assembly Info"
		Me.tabOptions.ResumeLayout(False)
		Me.pgeAS.ResumeLayout(False)
		Me.pgeCustom.ResumeLayout(False)
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

	Private Sub cmdLoadAS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoadAS.Click
		' Access the application settings that were
		' loaded at start time.
		mAppSet = ConfigurationSettings.AppSettings

		MessageBox.Show("Applicaton Settings have been loaded.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

		Me.cmdListByIndex.Enabled = True
		Me.cmdListByKey.Enabled = True
		Me.cmdReadValue.Enabled = True

		' The settings are loaded once per app domain.
		' So, there's no point in trying again.
		Me.cmdLoadAS.Enabled = False
	End Sub

	Private Sub cmdListByKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdListByKey.Click
		' This routine lists the items by getting
		' a list of keys and then accessing the items
		' by key.
		If Not mAppSet Is Nothing Then
			Me.lstSettings.Items.Clear()
			Dim keys() As String
			keys = mAppSet.AllKeys

			Dim key As String
			For Each key In keys
				Me.lstSettings.Items.Add(key & ": " & mAppSet.Item(key))
			Next
		End If
	End Sub

	Private Sub cmdListByIndex_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdListByIndex.Click
		' This routine lists the items using
		' an index number.
		' The collection is 0-based so
		' go from 0 to Count - 1
		If Not mAppSet Is Nothing Then
			Me.lstSettings.Items.Clear()
			Dim i As Integer
			For i = 0 To mAppSet.Count - 1
				Me.lstSettings.Items.Add(mAppSet.GetKey(i) & ": " & mAppSet.Item(i))
			Next
		End If
	End Sub

	Private Sub cmdReadValue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReadValue.Click
		Me.lblValue.Text = mAppSet.Item(Me.txtKey.Text)
	End Sub

	Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
		' Each application domain in a process can have
		' a configuration file.
		' Windows Forms applications by default have
		' one appdomain and one configuration file.
		Dim ad As AppDomain = AppDomain.CurrentDomain
		Me.mstrCFGFile = ad.SetupInformation.ConfigurationFile
	End Sub

	Private Sub cmdLoadCfg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoadCfg.Click
		' This function uses a custom AppSettings instance to load
		' the configuration file settings.
		Try
			Dim blnAutoSave As Boolean
			If Me.chkAutoSave.CheckState = CheckState.Checked Then
				blnAutoSave = True
			Else
				blnAutoSave = False
			End If

			If Not mcustAppSettings Is Nothing Then
				mcustAppSettings.Dispose()
				mcustAppSettings = Nothing
			End If

			mcustAppSettings = New AppSettings(Me.mstrCFGFile, blnAutoSave)

			If Me.lvSettings.Items.Count > 0 Then
				Me.lvSettings.Items.Clear()
			End If

			Me.cmdAddNew.Enabled = True
			Me.cmdListAllSettings.Enabled = True
			Me.cmdUpdate.Enabled = True
			Me.cmdSave.Enabled = True
			Me.cmdUnload.Enabled = True

		Catch exp As Exception
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)

		End Try
	End Sub

	Private Sub cmdListAllSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdListAllSettings.Click
		Me.ListCustomSettings()
	End Sub

	Private Sub lvSettings_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvSettings.SelectedIndexChanged
		' Put the current selected key/value pair's values
		' into the appropriate text boxes.
		Dim strKey As String
		Dim strValue As String
		If Me.lvSettings.SelectedItems.Count = 1 Then
			Me.txtSettingKey.Text = Me.lvSettings.SelectedItems(0).SubItems(0).Text
			Me.txtSettingValue.Text = Me.lvSettings.SelectedItems(0).SubItems(1).Text
		End If
	End Sub

	Private Sub cmdAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddNew.Click
		' Add a new item to the collection
		Try
			If Me.txtSettingKey.Text = String.Empty Then
				MessageBox.Show("You must enter a value for the key.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtSettingKey.Select()
				Exit Sub
			End If
			If Me.txtSettingValue.Text = String.Empty Then
				MessageBox.Show("You must enter a value for the value field.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtSettingValue.Select()
				Exit Sub
			End If
			mcustAppSet = New AppSetting(Me.txtSettingKey.Text, Me.txtSettingValue.Text)

			mcustAppSettings.Add(mcustAppSet)

			Me.ListCustomSettings()

			MessageBox.Show("New setting added.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
		Catch exp As Exception
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try

	End Sub

	Private Sub ListCustomSettings()
		' list all the settings and put them
		' in the list view control
		If Not mcustAppSettings Is Nothing Then
			Try
				Me.lvSettings.Items.Clear()
				For Each mcustAppSet In mcustAppSettings
					With Me.lvSettings.Items.Add(mcustAppSet.Key)
						.SubItems.Add(mcustAppSet.Value)
					End With
				Next
			Catch exp As Exception
				MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try

		End If
	End Sub

	Private Sub frmMain_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
		Me.UnloadConfigSettings(True)
	End Sub

	Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
		' Update an existing item.
		Try
			If Me.txtSettingKey.Text = String.Empty Then
				MessageBox.Show("You must enter a value for the key.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtSettingKey.Select()
				Exit Sub
			End If
			If Me.txtSettingValue.Text = String.Empty Then
				MessageBox.Show("You must enter a value for the value field.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtSettingValue.Select()
				Exit Sub
			End If

			mcustAppSet = New AppSetting(Me.txtSettingKey.Text, Me.txtSettingValue.Text)
			mcustAppSettings.Update(mcustAppSet)

			Me.ListCustomSettings()

			MessageBox.Show("Existing setting updated.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

		Catch exp As Exception
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try

	End Sub

	Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
		' Save any changes.
		If Not mcustAppSettings Is Nothing Then
			Try
				mcustAppSettings.Save()
				MessageBox.Show("Configuration file saved..", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)


			Catch exp As Exception
				MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		End If
	End Sub

	Private Sub cmdUnload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUnload.Click
		Me.UnloadConfigSettings(False)
	End Sub

	Private Sub UnloadConfigSettings(ByVal FormClosing As Boolean)
		' Correctly unload the configuration file
		' by calling its Dispose method and releasing the 
		' object reference.
		Try
			If Not mcustAppSettings Is Nothing Then
				mcustAppSettings.Dispose()
				mcustAppSettings = Nothing

				If Not FormClosing Then
					Me.lvSettings.Items.Clear()

					Me.txtSettingKey.Text = String.Empty
					Me.txtSettingValue.Text = String.Empty

					Me.cmdListAllSettings.Enabled = False
					Me.cmdAddNew.Enabled = False
					Me.cmdUpdate.Enabled = False
					Me.cmdSave.Enabled = False
					Me.cmdLoadCfg.Select()
					Me.cmdUnload.Enabled = False
				End If
			End If

		Catch exp As Exception
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try

	End Sub
End Class

Public Class AppSetting
	' This class maps the name/value pairs

	' the parent setting will be set
	' if the user ask for an AppSetting 
	' via the AppSettings instance.
	' This allows us to update the
	' configuration file if changes are made.
	Private mParent As AppSettings
	Private mstrKey As String
	Private mstrValue As String

	Public Property Key() As String
		Get
			Return mstrKey
		End Get
		Set(ByVal Value As String)
			Me.UpdateParent()
			Value = mstrKey
		End Set
	End Property

	Public Property Value() As String
		Get
			Return mstrValue
		End Get
		Set(ByVal Value As String)
			Me.UpdateParent()
			mstrValue = Value
		End Set
	End Property

	Private Sub UpdateParent()
		If Not Me.mParent Is Nothing Then
			Me.mParent.Update(Me)
		End If
	End Sub

	Public Sub New()
		Me.New(String.Empty, String.Empty)
	End Sub

	Public Sub New(ByVal Key As String, ByVal Value As String)
		Me.New(Key, Value, Nothing)
	End Sub

	Friend Sub New(ByVal Key As String, ByVal Value As String, ByVal Parent As AppSettings)
		MyBase.New()
		Me.mstrKey = Key
		Me.mstrValue = Value
		Me.mParent = Parent
	End Sub
End Class

Public Class AppSettings
	Implements IEnumerable, IDisposable

	' This classes wraps access to the configuration//appSettings
	' section of the config file specified when an instance is created.
	' XPath expressions are used to find values when requested.
	' In addition, the class supports enumeration by implementing
	' IEnumerable and providing a private Iterator which implements
	' IEnumerator.

	Private cfg As New XmlDocument()
	Private xAS As XmlNode
	Private mstrFileName As String
	Private mblnAutoSave As Boolean
	Private mblnDirty As Boolean
	Private maItems() As AppSetting
	Private mblnDisposing As Boolean
	Private mblnDisposed As Boolean

	Private Const APPSETTINGS_ELEMENT As String = "configuration//appSettings"
	Private Const NEWELEMENT As String = "add"
	Private Const XPATH_KEY_ADD As String = "//add"
	Private Const XPATH_KEY_ADD_KEY As String = "//add[@key='{0}']"

	Public Sub New(ByVal ConfigFile As String)
		Me.New(ConfigFile, False)
	End Sub

	Public Sub New(ByVal ConfigFile As String, ByVal AutoSave As Boolean)
		MyBase.New()
		If ConfigFile.Length = 0 Then
			Throw New ArgumentNullException("You must pass in a valid file name.")
		Else
			If System.IO.File.Exists(ConfigFile) Then
				Try
					cfg.Load(ConfigFile)

				Catch exp As Exception
					Throw New System.IO.FileLoadException("The file name specified could not be loaded. Please see InnerException for more information", exp)
				End Try
				' Get the main appSettings element
				' so we can add new settings
				xAS = cfg.SelectSingleNode(APPSETTINGS_ELEMENT)

				If xAS Is Nothing Then
					Throw New ConfigurationException("The file specified, while a valid XML document, is not a valid configuration file.")
				End If

				' If we get this far we need to
				' store the file name for any changes
				mstrFileName = ConfigFile

				Me.AutoSave = AutoSave


			Else
				Throw New System.IO.FileNotFoundException(String.Format("The file name specified {0} does not exist.", ConfigFile))
			End If
		End If

	End Sub

	Public Sub Dispose() Implements System.IDisposable.Dispose
		Me.mblnDisposing = True
		If Me.Dirty Then
			Me.Save()
		End If
		Me.mblnDisposed = True
		Me.mblnDisposing = False
		GC.SuppressFinalize(Me)
	End Sub

	Protected Overrides Sub Finalize()
		MyBase.Finalize()
		If Me.Dirty Then
			If Not Me.mblnDisposed Then
				If Not Me.mblnDisposing Then
					Me.Dispose()
				End If
			End If
		End If
	End Sub

	Public Property AutoSave() As Boolean
		Get
			Return Me.mblnAutoSave
		End Get
		Set(ByVal Value As Boolean)
			Me.mblnAutoSave = Value
		End Set
	End Property

	Public ReadOnly Property Dirty() As Boolean
		Get
			Return Me.mblnDirty
		End Get
	End Property

	Public Sub Add(ByVal NewSetting As AppSetting)
		Dim newElem As XmlElement
		Dim newAttr As XmlAttribute

		newElem = cfg.CreateElement(NEWELEMENT)

		newAttr = cfg.CreateAttribute("key")
		newAttr.Value = NewSetting.Key
		newElem.Attributes.Append(newAttr)

		newAttr = cfg.CreateAttribute("value")
		newAttr.Value = NewSetting.Value
		newElem.Attributes.Append(newAttr)

		xAS.AppendChild(newElem)

		Me.mblnDirty = True
		If Me.AutoSave Then
			Me.Save()
		End If
	End Sub

	Public Function Add(ByVal Key As String, ByVal Value As String) As AppSetting
		Dim NewSetting As New AppSetting(Key, Value, Me)
		Me.Add(NewSetting)
		Return NewSetting
	End Function

	Public Function Item(ByVal Key As String) As AppSetting
		Dim xNode As XmlNode
		Dim strSearch As String = XPATH_KEY_ADD_KEY

		xNode = xAS.SelectSingleNode(String.Format(strSearch, Key))

		If xNode Is Nothing Then
			Throw New ArgumentOutOfRangeException("Key", Key, "The item you wanted to update does not exists.")
		Else
			Dim las As New AppSetting()
			las.Key = Key
			las.Value = xNode.Attributes.Item(1).Value

			Return las
		End If
	End Function

	Public Sub RemoveByKey(ByVal Setting As AppSetting)
		Dim xNode As XmlNode
		Dim strSearch As String = XPATH_KEY_ADD_KEY

		xNode = xAS.SelectSingleNode(String.Format(strSearch, Setting.Key))

		If Not xNode Is Nothing Then

		End If
		Me.mblnDirty = True
		If Me.AutoSave Then
			Me.Save()
		End If

	End Sub

	Public Sub RemoveByKey(ByVal Key As String)

	End Sub

	Public Function Update(ByVal Key As String, ByVal Value As String) As AppSetting
		Dim NewSetting As New AppSetting(Key, Value, Me)
		Me.Update(NewSetting)
		Return NewSetting
	End Function

	Public Sub Update(ByVal NewSetting As AppSetting)
		Dim xNode As XmlNode
		Dim strSearch As String = XPATH_KEY_ADD_KEY

		xNode = xAS.SelectSingleNode(String.Format(strSearch, NewSetting.Key))

		If xNode Is Nothing Then
			Throw New ArgumentOutOfRangeException("Key", NewSetting.Key, "The item you wanted to update does not exists.")
		Else
			xNode.Attributes.Item(1).Value = NewSetting.Value
		End If

		Me.mblnDirty = True

		If Me.AutoSave Then
			Me.Save()
		End If
	End Sub

	Public Sub Save()
		' We don't have a try catch here so
		' that if we fail, it will bounce up
		' to our caller.
		cfg.Save(Me.mstrFileName)
		Me.mblnDirty = False
	End Sub

	Private Function GetAllItems() As AppSetting()
		Dim xNode As XmlNode
		Dim xNodeList As XmlNodeList
		Dim atts As XmlAttributeCollection

		xNodeList = xAS.SelectNodes(XPATH_KEY_ADD)

		Dim xa As XmlAttribute
		Dim asa(xNodeList.Count - 1) As AppSetting
		Dim asi As AppSetting
		Dim i As Integer = -1

		For Each xNode In xNodeList
			i += 1
			atts = xNode.Attributes

			With atts
				asi = New AppSetting(.Item(0).Value, .Item(1).Value, Me)
			End With
			asa(i) = asi
		Next

		Return asa
	End Function

	Private Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
		Me.maItems = Me.GetAllItems()
		Return New Iterator(Me.maItems)
	End Function

	Private Class Iterator
		Implements IEnumerator

		' This private class exposes the necessary
		' functions so that For..Each will work.
		Private mData() As AppSetting
		Private Index As Integer = -1

		Public Sub New(ByVal Keys() As AppSetting)
			mData = Keys
		End Sub
		Private ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
			Get
				Return mData(Index)
			End Get
		End Property
		Private Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
			Index += 1
			If (Index <= (mData.Length - 1)) Then
				Return True
			End If
		End Function
		Private Sub Reset() Implements System.Collections.IEnumerator.Reset
			Index = -1
		End Sub
	End Class

End Class
