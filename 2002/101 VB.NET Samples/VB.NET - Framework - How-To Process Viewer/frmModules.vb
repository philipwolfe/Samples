Public Class frmModules
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
	Friend WithEvents sbInfo As System.Windows.Forms.StatusBar
	Friend WithEvents lvModules As System.Windows.Forms.ListView
	Friend WithEvents chModName As System.Windows.Forms.ColumnHeader
	Friend WithEvents mnuMain As System.Windows.Forms.MainMenu
	Friend WithEvents mnuFile As System.Windows.Forms.MenuItem
	Friend WithEvents mnuClose As System.Windows.Forms.MenuItem
	Friend WithEvents lvModDetail As System.Windows.Forms.ListView
	Friend WithEvents chItem As System.Windows.Forms.ColumnHeader
	Friend WithEvents chValue As System.Windows.Forms.ColumnHeader
	Friend WithEvents splVert As System.Windows.Forms.Splitter
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmModules))
		Me.sbInfo = New System.Windows.Forms.StatusBar()
		Me.lvModules = New System.Windows.Forms.ListView()
		Me.chModName = New System.Windows.Forms.ColumnHeader()
		Me.mnuMain = New System.Windows.Forms.MainMenu()
		Me.mnuFile = New System.Windows.Forms.MenuItem()
		Me.mnuClose = New System.Windows.Forms.MenuItem()
		Me.lvModDetail = New System.Windows.Forms.ListView()
		Me.chItem = New System.Windows.Forms.ColumnHeader()
		Me.chValue = New System.Windows.Forms.ColumnHeader()
		Me.splVert = New System.Windows.Forms.Splitter()
		Me.SuspendLayout()
		'
		'sbInfo
		'
		Me.sbInfo.Location = New System.Drawing.Point(0, 195)
		Me.sbInfo.Name = "sbInfo"
		Me.sbInfo.Size = New System.Drawing.Size(927, 22)
		Me.sbInfo.TabIndex = 0
		Me.sbInfo.Text = "Ready"
		'
		'lvModules
		'
		Me.lvModules.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chModName})
		Me.lvModules.Dock = System.Windows.Forms.DockStyle.Left
		Me.lvModules.FullRowSelect = True
		Me.lvModules.MultiSelect = False
		Me.lvModules.Name = "lvModules"
		Me.lvModules.Size = New System.Drawing.Size(184, 195)
		Me.lvModules.Sorting = System.Windows.Forms.SortOrder.Ascending
		Me.lvModules.TabIndex = 1
		Me.lvModules.View = System.Windows.Forms.View.Details
		'
		'chModName
		'
		Me.chModName.Text = "Module Name"
		Me.chModName.Width = 150
		'
		'mnuMain
		'
		Me.mnuMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile})
		'
		'mnuFile
		'
		Me.mnuFile.Index = 0
		Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuClose})
		Me.mnuFile.Text = "&File"
		'
		'mnuClose
		'
		Me.mnuClose.Index = 0
		Me.mnuClose.Text = "&Close"
		'
		'lvModDetail
		'
		Me.lvModDetail.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chItem, Me.chValue})
		Me.lvModDetail.Dock = System.Windows.Forms.DockStyle.Fill
		Me.lvModDetail.FullRowSelect = True
		Me.lvModDetail.Location = New System.Drawing.Point(184, 0)
		Me.lvModDetail.MultiSelect = False
		Me.lvModDetail.Name = "lvModDetail"
		Me.lvModDetail.Size = New System.Drawing.Size(743, 195)
		Me.lvModDetail.TabIndex = 2
		Me.lvModDetail.View = System.Windows.Forms.View.Details
		'
		'chItem
		'
		Me.chItem.Text = "Item"
		Me.chItem.Width = 150
		'
		'chValue
		'
		Me.chValue.Text = "Value"
		Me.chValue.Width = 570
		'
		'splVert
		'
		Me.splVert.Location = New System.Drawing.Point(184, 0)
		Me.splVert.Name = "splVert"
		Me.splVert.Size = New System.Drawing.Size(3, 195)
		Me.splVert.TabIndex = 3
		Me.splVert.TabStop = False
		'
		'frmModules
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(927, 217)
		Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.splVert, Me.lvModDetail, Me.lvModules, Me.sbInfo})
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Menu = Me.mnuMain
		Me.Name = "frmModules"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Module Detail"
		Me.ResumeLayout(False)

	End Sub

#End Region

	Private m_ParentProcess As Process

	Private mits As ListView.ListViewItemCollection
	Private mcolModules As New Collection()

	Friend Property ParentProcess() As Process
		Get
			Return ParentProcess
		End Get
		Set(ByVal Value As Process)
			m_ParentProcess = Value
			If m_ParentProcess Is Nothing Then
				mcolModules = Nothing
			End If
		End Set
	End Property

	Private Sub EnumModules()
		Try
			Me.lvModules.Items.Clear()
			Dim mf As ProcessModule
			If Not mcolModules Is Nothing Then
				mcolModules = New Collection()
			End If
			Dim m As ProcessModule
			For Each m In m_ParentProcess.Modules
				Me.lvModules.Items.Add(m.ModuleName)

				Try
					mcolModules.Add(m, m.ModuleName)
				Catch exp As ArgumentException
					' This means the item was duplicated.
					' Eat error and continue.
				Catch exp As Exception
					MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
				End Try

			Next
		Catch exp As Exception
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub

	Friend Sub RefreshModules()
		Me.sbInfo.Text = "Process = " & m_ParentProcess.ProcessName
		Me.lvModDetail.Items.Clear()
		EnumModules()
	End Sub

	Private Sub mnuClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClose.Click
		Me.Hide()
	End Sub

	Private Sub EnumModule(ByVal m As ProcessModule)

		Me.lvModDetail.Items.Clear()

		mits = Me.lvModDetail.Items

		Try
			AddNameValuePair("Base Address", Hex(m.BaseAddress.ToInt32).ToLower())
			AddNameValuePair("Entry Point Address", Hex(m.EntryPointAddress.ToInt32).ToLower())
			AddNameValuePair("File Name", m.FileName)
			AddNameValuePair("File Version", m.FileVersionInfo.FileVersion.ToString())
			AddNameValuePair("File Description", m.FileVersionInfo.FileDescription)
			AddNameValuePair("Memory Size", m.ModuleMemorySize.ToString("N0"))

		Catch exp As Exception
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub

	Private Sub AddNameValuePair(ByVal Item As String, ByVal SubItem As String)
		With mits.Add(Item)
			.SubItems.Add(SubItem)
		End With
	End Sub

	Private Sub lvModules_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvModules.SelectedIndexChanged
		Try
			Dim lv As ListView = CType(sender, ListView)

			If lv.SelectedItems.Count = 1 Then
				Dim strMod As String = lv.SelectedItems(0).Text

				Dim m As ProcessModule = CType(mcolModules.Item(strMod), ProcessModule)
				EnumModule(m)
			End If
		Catch exp As Exception
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub
End Class
