Option Strict Off
Option Explicit On
Friend Class MDIFormWOS
	Inherits System.Windows.Forms.Form
#Region "Windows Form Designer generated code "
	Public Sub New()
		MyBase.New()
		If m_vb6FormDefInstance Is Nothing Then
			m_vb6FormDefInstance = Me
		End If
		'This call is required by the Windows Form Designer.
		InitializeComponent()
	End Sub
	'Form overrides dispose to clean up the component list.
	Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
	Public WithEvents cmdPrint As System.Windows.Forms.Button
	Public WithEvents cmdSearch As System.Windows.Forms.Button
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdFirst As System.Windows.Forms.Button
	Public WithEvents cmdPrevious As System.Windows.Forms.Button
	Public WithEvents cmdNext As System.Windows.Forms.Button
	Public WithEvents cmdLast As System.Windows.Forms.Button
	Public WithEvents cmdAdd As System.Windows.Forms.Button
	Public WithEvents cmdDelete As System.Windows.Forms.Button
	Public WithEvents cmdSave As System.Windows.Forms.Button
	Public WithEvents cmdRefresh As System.Windows.Forms.Button
	Public WithEvents cmdGridView As System.Windows.Forms.Button
	Public WithEvents cmdFormView As System.Windows.Forms.Button
	Public WithEvents cmdWorkOrder As System.Windows.Forms.Button
	Public WithEvents cmdTask As System.Windows.Forms.Button
	Public WithEvents cmdEquipment As System.Windows.Forms.Button
	Public WithEvents Picture1 As System.Windows.Forms.Panel
	Public WithEvents mnuFile As Microsoft.VisualBasic.Compatibility.VB6.MenuItemArray
	Public WithEvents mnuExit As System.Windows.Forms.MenuItem
	Public WithEvents _mnuFile_0 As System.Windows.Forms.MenuItem
	Public WithEvents mnuEquipment As System.Windows.Forms.MenuItem
	Public WithEvents mnuTask As System.Windows.Forms.MenuItem
	Public WithEvents mnuWorkOrder As System.Windows.Forms.MenuItem
	Public WithEvents mnuMeterReading As System.Windows.Forms.MenuItem
	Public WithEvents mnuForms As System.Windows.Forms.MenuItem
	Public WithEvents mnuEquipList As System.Windows.Forms.MenuItem
	Public WithEvents mnuEquipSum As System.Windows.Forms.MenuItem
	Public WithEvents mnuMeterReadingList As System.Windows.Forms.MenuItem
	Public WithEvents mnuReports As System.Windows.Forms.MenuItem
	Public WithEvents mnuNewPlant As System.Windows.Forms.MenuItem
	Public WithEvents mnuUtilities As System.Windows.Forms.MenuItem
	Public WithEvents mnuAbout As System.Windows.Forms.MenuItem
	Public WithEvents mnuHelp As System.Windows.Forms.MenuItem
	Public MainMenu1 As System.Windows.Forms.MainMenu
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(MDIFormWOS))
		Me.IsMDIContainer = True
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ToolTip1.Active = True
		Me.Picture1 = New System.Windows.Forms.Panel
		Me.cmdPrint = New System.Windows.Forms.Button
		Me.cmdSearch = New System.Windows.Forms.Button
		Me.cmdCancel = New System.Windows.Forms.Button
		Me.cmdFirst = New System.Windows.Forms.Button
		Me.cmdPrevious = New System.Windows.Forms.Button
		Me.cmdNext = New System.Windows.Forms.Button
		Me.cmdLast = New System.Windows.Forms.Button
		Me.cmdAdd = New System.Windows.Forms.Button
		Me.cmdDelete = New System.Windows.Forms.Button
		Me.cmdSave = New System.Windows.Forms.Button
		Me.cmdRefresh = New System.Windows.Forms.Button
		Me.cmdGridView = New System.Windows.Forms.Button
		Me.cmdFormView = New System.Windows.Forms.Button
		Me.cmdWorkOrder = New System.Windows.Forms.Button
		Me.cmdTask = New System.Windows.Forms.Button
		Me.cmdEquipment = New System.Windows.Forms.Button
		Me.mnuFile = New Microsoft.VisualBasic.Compatibility.VB6.MenuItemArray(components)
		Me.MainMenu1 = New System.Windows.Forms.MainMenu
		Me._mnuFile_0 = New System.Windows.Forms.MenuItem
		Me.mnuExit = New System.Windows.Forms.MenuItem
		Me.mnuForms = New System.Windows.Forms.MenuItem
		Me.mnuEquipment = New System.Windows.Forms.MenuItem
		Me.mnuTask = New System.Windows.Forms.MenuItem
		Me.mnuWorkOrder = New System.Windows.Forms.MenuItem
		Me.mnuMeterReading = New System.Windows.Forms.MenuItem
		Me.mnuReports = New System.Windows.Forms.MenuItem
		Me.mnuEquipList = New System.Windows.Forms.MenuItem
		Me.mnuEquipSum = New System.Windows.Forms.MenuItem
		Me.mnuMeterReadingList = New System.Windows.Forms.MenuItem
		Me.mnuUtilities = New System.Windows.Forms.MenuItem
		Me.mnuNewPlant = New System.Windows.Forms.MenuItem
		Me.mnuHelp = New System.Windows.Forms.MenuItem
		Me.mnuAbout = New System.Windows.Forms.MenuItem
		CType(Me.mnuFile, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.BackColor = System.Drawing.SystemColors.AppWorkspace
		Me.Text = "WORK ORDER APPLICATION"
		Me.ClientSize = New System.Drawing.Size(646, 487)
		Me.Location = New System.Drawing.Point(4, 29)
		Me.Icon = CType(resources.GetObject("MDIFormWOS.Icon"), System.Drawing.Icon)
		Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
		Me.Enabled = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Name = "MDIFormWOS"
		Me.Picture1.Dock = System.Windows.Forms.DockStyle.Top
		Me.Picture1.BackColor = System.Drawing.SystemColors.Menu
		Me.Picture1.Size = New System.Drawing.Size(646, 33)
		Me.Picture1.Location = New System.Drawing.Point(0, 0)
		Me.Picture1.TabIndex = 0
		Me.Picture1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Picture1.CausesValidation = True
		Me.Picture1.Enabled = True
		Me.Picture1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Picture1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Picture1.TabStop = True
		Me.Picture1.Visible = True
		Me.Picture1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Picture1.Name = "Picture1"
		Me.cmdPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.cmdPrint.Size = New System.Drawing.Size(32, 30)
		Me.cmdPrint.Location = New System.Drawing.Point(528, 0)
		Me.cmdPrint.Image = CType(resources.GetObject("cmdPrint.Image"), System.Drawing.Image)
		Me.cmdPrint.TabIndex = 16
		Me.ToolTip1.SetToolTip(Me.cmdPrint, "Print")
		Me.cmdPrint.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdPrint.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPrint.CausesValidation = True
		Me.cmdPrint.Enabled = True
		Me.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPrint.TabStop = True
		Me.cmdPrint.Name = "cmdPrint"
		Me.cmdSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.cmdSearch.Size = New System.Drawing.Size(32, 30)
		Me.cmdSearch.Location = New System.Drawing.Point(488, 0)
		Me.cmdSearch.Image = CType(resources.GetObject("cmdSearch.Image"), System.Drawing.Image)
		Me.cmdSearch.TabIndex = 15
		Me.ToolTip1.SetToolTip(Me.cmdSearch, "Search")
		Me.cmdSearch.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdSearch.BackColor = System.Drawing.SystemColors.Control
		Me.cmdSearch.CausesValidation = True
		Me.cmdSearch.Enabled = True
		Me.cmdSearch.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdSearch.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdSearch.TabStop = True
		Me.cmdSearch.Name = "cmdSearch"
		Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.cmdCancel.Size = New System.Drawing.Size(32, 30)
		Me.cmdCancel.Location = New System.Drawing.Point(312, 0)
		Me.cmdCancel.Image = CType(resources.GetObject("cmdCancel.Image"), System.Drawing.Image)
		Me.cmdCancel.TabIndex = 14
		Me.ToolTip1.SetToolTip(Me.cmdCancel, "Cancel")
		Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCancel.CausesValidation = True
		Me.cmdCancel.Enabled = True
		Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCancel.TabStop = True
		Me.cmdCancel.Name = "cmdCancel"
		Me.cmdFirst.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.cmdFirst.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdFirst.Size = New System.Drawing.Size(32, 30)
		Me.cmdFirst.Location = New System.Drawing.Point(352, 0)
		Me.cmdFirst.Image = CType(resources.GetObject("cmdFirst.Image"), System.Drawing.Image)
		Me.cmdFirst.TabIndex = 13
		Me.ToolTip1.SetToolTip(Me.cmdFirst, "First")
		Me.cmdFirst.BackColor = System.Drawing.SystemColors.Control
		Me.cmdFirst.CausesValidation = True
		Me.cmdFirst.Enabled = True
		Me.cmdFirst.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdFirst.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdFirst.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdFirst.TabStop = True
		Me.cmdFirst.Name = "cmdFirst"
		Me.cmdPrevious.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.cmdPrevious.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdPrevious.Size = New System.Drawing.Size(32, 30)
		Me.cmdPrevious.Location = New System.Drawing.Point(384, 0)
		Me.cmdPrevious.Image = CType(resources.GetObject("cmdPrevious.Image"), System.Drawing.Image)
		Me.cmdPrevious.TabIndex = 12
		Me.ToolTip1.SetToolTip(Me.cmdPrevious, "Previous")
		Me.cmdPrevious.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPrevious.CausesValidation = True
		Me.cmdPrevious.Enabled = True
		Me.cmdPrevious.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPrevious.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPrevious.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPrevious.TabStop = True
		Me.cmdPrevious.Name = "cmdPrevious"
		Me.cmdNext.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.cmdNext.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdNext.Size = New System.Drawing.Size(32, 30)
		Me.cmdNext.Location = New System.Drawing.Point(416, 0)
		Me.cmdNext.Image = CType(resources.GetObject("cmdNext.Image"), System.Drawing.Image)
		Me.cmdNext.TabIndex = 11
		Me.ToolTip1.SetToolTip(Me.cmdNext, "Next")
		Me.cmdNext.BackColor = System.Drawing.SystemColors.Control
		Me.cmdNext.CausesValidation = True
		Me.cmdNext.Enabled = True
		Me.cmdNext.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdNext.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdNext.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdNext.TabStop = True
		Me.cmdNext.Name = "cmdNext"
		Me.cmdLast.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.cmdLast.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdLast.Size = New System.Drawing.Size(32, 30)
		Me.cmdLast.Location = New System.Drawing.Point(448, 0)
		Me.cmdLast.Image = CType(resources.GetObject("cmdLast.Image"), System.Drawing.Image)
		Me.cmdLast.TabIndex = 10
		Me.ToolTip1.SetToolTip(Me.cmdLast, "Last")
		Me.cmdLast.BackColor = System.Drawing.SystemColors.Control
		Me.cmdLast.CausesValidation = True
		Me.cmdLast.Enabled = True
		Me.cmdLast.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdLast.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdLast.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdLast.TabStop = True
		Me.cmdLast.Name = "cmdLast"
		Me.cmdAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.cmdAdd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdAdd.Size = New System.Drawing.Size(32, 30)
		Me.cmdAdd.Location = New System.Drawing.Point(280, 0)
		Me.cmdAdd.Image = CType(resources.GetObject("cmdAdd.Image"), System.Drawing.Image)
		Me.cmdAdd.TabIndex = 9
		Me.ToolTip1.SetToolTip(Me.cmdAdd, "Add")
		Me.cmdAdd.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAdd.CausesValidation = True
		Me.cmdAdd.Enabled = True
		Me.cmdAdd.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAdd.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAdd.TabStop = True
		Me.cmdAdd.Name = "cmdAdd"
		Me.cmdDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.cmdDelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdDelete.Size = New System.Drawing.Size(32, 30)
		Me.cmdDelete.Location = New System.Drawing.Point(248, 0)
		Me.cmdDelete.Image = CType(resources.GetObject("cmdDelete.Image"), System.Drawing.Image)
		Me.cmdDelete.TabIndex = 8
		Me.ToolTip1.SetToolTip(Me.cmdDelete, "Delete")
		Me.cmdDelete.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDelete.CausesValidation = True
		Me.cmdDelete.Enabled = True
		Me.cmdDelete.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDelete.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDelete.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDelete.TabStop = True
		Me.cmdDelete.Name = "cmdDelete"
		Me.cmdSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.cmdSave.Size = New System.Drawing.Size(32, 30)
		Me.cmdSave.Location = New System.Drawing.Point(216, 0)
		Me.cmdSave.Image = CType(resources.GetObject("cmdSave.Image"), System.Drawing.Image)
		Me.cmdSave.TabIndex = 7
		Me.ToolTip1.SetToolTip(Me.cmdSave, "Save")
		Me.cmdSave.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdSave.BackColor = System.Drawing.SystemColors.Control
		Me.cmdSave.CausesValidation = True
		Me.cmdSave.Enabled = True
		Me.cmdSave.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdSave.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdSave.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdSave.TabStop = True
		Me.cmdSave.Name = "cmdSave"
		Me.cmdRefresh.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.cmdRefresh.Size = New System.Drawing.Size(32, 30)
		Me.cmdRefresh.Location = New System.Drawing.Point(176, 0)
		Me.cmdRefresh.Image = CType(resources.GetObject("cmdRefresh.Image"), System.Drawing.Image)
		Me.cmdRefresh.TabIndex = 6
		Me.ToolTip1.SetToolTip(Me.cmdRefresh, "Refresh")
		Me.cmdRefresh.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdRefresh.BackColor = System.Drawing.SystemColors.Control
		Me.cmdRefresh.CausesValidation = True
		Me.cmdRefresh.Enabled = True
		Me.cmdRefresh.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdRefresh.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdRefresh.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdRefresh.TabStop = True
		Me.cmdRefresh.Name = "cmdRefresh"
		Me.cmdGridView.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.cmdGridView.Size = New System.Drawing.Size(32, 30)
		Me.cmdGridView.Location = New System.Drawing.Point(136, 0)
		Me.cmdGridView.Image = CType(resources.GetObject("cmdGridView.Image"), System.Drawing.Image)
		Me.cmdGridView.TabIndex = 5
		Me.ToolTip1.SetToolTip(Me.cmdGridView, "Grid View")
		Me.cmdGridView.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdGridView.BackColor = System.Drawing.SystemColors.Control
		Me.cmdGridView.CausesValidation = True
		Me.cmdGridView.Enabled = True
		Me.cmdGridView.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdGridView.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdGridView.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdGridView.TabStop = True
		Me.cmdGridView.Name = "cmdGridView"
		Me.cmdFormView.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.cmdFormView.Size = New System.Drawing.Size(32, 30)
		Me.cmdFormView.Location = New System.Drawing.Point(104, 0)
		Me.cmdFormView.Image = CType(resources.GetObject("cmdFormView.Image"), System.Drawing.Image)
		Me.cmdFormView.TabIndex = 4
		Me.ToolTip1.SetToolTip(Me.cmdFormView, "Form View")
		Me.cmdFormView.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdFormView.BackColor = System.Drawing.SystemColors.Control
		Me.cmdFormView.CausesValidation = True
		Me.cmdFormView.Enabled = True
		Me.cmdFormView.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdFormView.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdFormView.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdFormView.TabStop = True
		Me.cmdFormView.Name = "cmdFormView"
		Me.cmdWorkOrder.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.cmdWorkOrder.Size = New System.Drawing.Size(32, 30)
		Me.cmdWorkOrder.Location = New System.Drawing.Point(64, 0)
		Me.cmdWorkOrder.Image = CType(resources.GetObject("cmdWorkOrder.Image"), System.Drawing.Image)
		Me.cmdWorkOrder.TabIndex = 3
		Me.ToolTip1.SetToolTip(Me.cmdWorkOrder, "History")
		Me.cmdWorkOrder.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdWorkOrder.BackColor = System.Drawing.SystemColors.Control
		Me.cmdWorkOrder.CausesValidation = True
		Me.cmdWorkOrder.Enabled = True
		Me.cmdWorkOrder.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdWorkOrder.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdWorkOrder.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdWorkOrder.TabStop = True
		Me.cmdWorkOrder.Name = "cmdWorkOrder"
		Me.cmdTask.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.cmdTask.Size = New System.Drawing.Size(32, 30)
		Me.cmdTask.Location = New System.Drawing.Point(32, 0)
		Me.cmdTask.Image = CType(resources.GetObject("cmdTask.Image"), System.Drawing.Image)
		Me.cmdTask.TabIndex = 2
		Me.ToolTip1.SetToolTip(Me.cmdTask, "Work Order")
		Me.cmdTask.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdTask.BackColor = System.Drawing.SystemColors.Control
		Me.cmdTask.CausesValidation = True
		Me.cmdTask.Enabled = True
		Me.cmdTask.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdTask.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdTask.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdTask.TabStop = True
		Me.cmdTask.Name = "cmdTask"
		Me.cmdEquipment.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.cmdEquipment.Size = New System.Drawing.Size(32, 30)
		Me.cmdEquipment.Location = New System.Drawing.Point(0, 0)
		Me.cmdEquipment.Image = CType(resources.GetObject("cmdEquipment.Image"), System.Drawing.Image)
		Me.cmdEquipment.TabIndex = 1
		Me.ToolTip1.SetToolTip(Me.cmdEquipment, "Equipment")
		Me.cmdEquipment.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdEquipment.BackColor = System.Drawing.SystemColors.Control
		Me.cmdEquipment.CausesValidation = True
		Me.cmdEquipment.Enabled = True
		Me.cmdEquipment.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdEquipment.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdEquipment.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdEquipment.TabStop = True
		Me.cmdEquipment.Name = "cmdEquipment"
		Me._mnuFile_0.Text = "&File"
		Me._mnuFile_0.Checked = False
		Me._mnuFile_0.Enabled = True
		Me._mnuFile_0.Visible = True
		Me._mnuFile_0.MDIList = False
		Me.mnuExit.Text = "&Exit"
		Me.mnuExit.Checked = False
		Me.mnuExit.Enabled = True
		Me.mnuExit.Visible = True
		Me.mnuExit.MDIList = False
		Me.mnuForms.Text = "F&orms"
		Me.mnuForms.Checked = False
		Me.mnuForms.Enabled = True
		Me.mnuForms.Visible = True
		Me.mnuForms.MDIList = False
		Me.mnuEquipment.Text = "&Equipment"
		Me.mnuEquipment.Checked = False
		Me.mnuEquipment.Enabled = True
		Me.mnuEquipment.Visible = True
		Me.mnuEquipment.MDIList = False
		Me.mnuTask.Text = "&Work Order"
		Me.mnuTask.Checked = False
		Me.mnuTask.Enabled = True
		Me.mnuTask.Visible = True
		Me.mnuTask.MDIList = False
		Me.mnuWorkOrder.Text = "&History"
		Me.mnuWorkOrder.Checked = False
		Me.mnuWorkOrder.Enabled = True
		Me.mnuWorkOrder.Visible = True
		Me.mnuWorkOrder.MDIList = False
		Me.mnuMeterReading.Text = "&Meter Reading"
		Me.mnuMeterReading.Checked = False
		Me.mnuMeterReading.Enabled = True
		Me.mnuMeterReading.Visible = True
		Me.mnuMeterReading.MDIList = False
		Me.mnuReports.Text = "&Reports"
		Me.mnuReports.Checked = False
		Me.mnuReports.Enabled = True
		Me.mnuReports.Visible = True
		Me.mnuReports.MDIList = False
		Me.mnuEquipList.Text = "&Equipment Detail"
		Me.mnuEquipList.Checked = False
		Me.mnuEquipList.Enabled = True
		Me.mnuEquipList.Visible = True
		Me.mnuEquipList.MDIList = False
		Me.mnuEquipSum.Text = "Equipment &Summary"
		Me.mnuEquipSum.Checked = False
		Me.mnuEquipSum.Enabled = True
		Me.mnuEquipSum.Visible = True
		Me.mnuEquipSum.MDIList = False
		Me.mnuMeterReadingList.Text = "&Meter Reading List"
		Me.mnuMeterReadingList.Checked = False
		Me.mnuMeterReadingList.Enabled = True
		Me.mnuMeterReadingList.Visible = True
		Me.mnuMeterReadingList.MDIList = False
		Me.mnuUtilities.Text = "&Utilities"
		Me.mnuUtilities.Checked = False
		Me.mnuUtilities.Enabled = True
		Me.mnuUtilities.Visible = True
		Me.mnuUtilities.MDIList = False
		Me.mnuNewPlant.Text = "Create New Plant"
		Me.mnuNewPlant.Checked = False
		Me.mnuNewPlant.Enabled = True
		Me.mnuNewPlant.Visible = True
		Me.mnuNewPlant.MDIList = False
		Me.mnuHelp.Text = "&Help"
		Me.mnuHelp.Visible = False
		Me.mnuHelp.Checked = False
		Me.mnuHelp.Enabled = True
		Me.mnuHelp.MDIList = False
		Me.mnuAbout.Text = "&About"
		Me.mnuAbout.Checked = False
		Me.mnuAbout.Enabled = True
		Me.mnuAbout.Visible = True
		Me.mnuAbout.MDIList = False
		Me.Controls.Add(Picture1)
		Me.Picture1.Controls.Add(cmdPrint)
		Me.Picture1.Controls.Add(cmdSearch)
		Me.Picture1.Controls.Add(cmdCancel)
		Me.Picture1.Controls.Add(cmdFirst)
		Me.Picture1.Controls.Add(cmdPrevious)
		Me.Picture1.Controls.Add(cmdNext)
		Me.Picture1.Controls.Add(cmdLast)
		Me.Picture1.Controls.Add(cmdAdd)
		Me.Picture1.Controls.Add(cmdDelete)
		Me.Picture1.Controls.Add(cmdSave)
		Me.Picture1.Controls.Add(cmdRefresh)
		Me.Picture1.Controls.Add(cmdGridView)
		Me.Picture1.Controls.Add(cmdFormView)
		Me.Picture1.Controls.Add(cmdWorkOrder)
		Me.Picture1.Controls.Add(cmdTask)
		Me.Picture1.Controls.Add(cmdEquipment)
		Me.mnuFile.SetIndex(_mnuFile_0, CType(0, Short))
		CType(Me.mnuFile, System.ComponentModel.ISupportInitialize).EndInit()
		Me._mnuFile_0.Index = 0
		Me._mnuFile_0.MergeType = System.Windows.Forms.MenuMerge.Remove
		Me.mnuForms.Index = 1
		Me.mnuForms.MergeType = System.Windows.Forms.MenuMerge.Remove
		Me.mnuReports.Index = 2
		Me.mnuReports.MergeType = System.Windows.Forms.MenuMerge.Remove
		Me.mnuUtilities.Index = 3
		Me.mnuUtilities.MergeType = System.Windows.Forms.MenuMerge.Remove
		Me.mnuHelp.Index = 4
		Me.mnuHelp.MergeType = System.Windows.Forms.MenuMerge.Remove
		MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem(){Me._mnuFile_0, Me.mnuForms, Me.mnuReports, Me.mnuUtilities, Me.mnuHelp})
		Me.mnuExit.Index = 0
		Me.mnuExit.MergeType = System.Windows.Forms.MenuMerge.Remove
		_mnuFile_0.MenuItems.AddRange(New System.Windows.Forms.MenuItem(){Me.mnuExit})
		Me._mnuFile_0.MergeType = System.Windows.Forms.MenuMerge.Remove
		Me.mnuEquipment.Index = 0
		Me.mnuEquipment.MergeType = System.Windows.Forms.MenuMerge.Remove
		Me.mnuTask.Index = 1
		Me.mnuTask.MergeType = System.Windows.Forms.MenuMerge.Remove
		Me.mnuWorkOrder.Index = 2
		Me.mnuWorkOrder.MergeType = System.Windows.Forms.MenuMerge.Remove
		Me.mnuMeterReading.Index = 3
		Me.mnuMeterReading.MergeType = System.Windows.Forms.MenuMerge.Remove
		mnuForms.MenuItems.AddRange(New System.Windows.Forms.MenuItem(){Me.mnuEquipment, Me.mnuTask, Me.mnuWorkOrder, Me.mnuMeterReading})
		Me.mnuForms.MergeType = System.Windows.Forms.MenuMerge.Remove
		Me.mnuEquipList.Index = 0
		Me.mnuEquipList.MergeType = System.Windows.Forms.MenuMerge.Remove
		Me.mnuEquipSum.Index = 1
		Me.mnuEquipSum.MergeType = System.Windows.Forms.MenuMerge.Remove
		Me.mnuMeterReadingList.Index = 2
		Me.mnuMeterReadingList.MergeType = System.Windows.Forms.MenuMerge.Remove
		mnuReports.MenuItems.AddRange(New System.Windows.Forms.MenuItem(){Me.mnuEquipList, Me.mnuEquipSum, Me.mnuMeterReadingList})
		Me.mnuReports.MergeType = System.Windows.Forms.MenuMerge.Remove
		Me.mnuNewPlant.Index = 0
		Me.mnuNewPlant.MergeType = System.Windows.Forms.MenuMerge.Remove
		mnuUtilities.MenuItems.AddRange(New System.Windows.Forms.MenuItem(){Me.mnuNewPlant})
		Me.mnuUtilities.MergeType = System.Windows.Forms.MenuMerge.Remove
		Me.mnuAbout.Index = 0
		Me.mnuAbout.MergeType = System.Windows.Forms.MenuMerge.Remove
		mnuHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem(){Me.mnuAbout})
		Me.mnuHelp.MergeType = System.Windows.Forms.MenuMerge.Remove
		Me.Menu = MainMenu1
	End Sub
#End Region 
#Region "Upgrade Support "
	Private Shared m_vb6FormDefInstance As MDIFormWOS
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As MDIFormWOS
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New MDIFormWOS()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
	
	Dim ans As Short
	Dim bolCreatePlantClicked As Boolean
	
	
	Private Sub cmdAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAdd.Click
		'UPGRADE_ISSUE: Control Add could not be resolved because it was within the generic namespace ActiveMDIChild. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup2072"'
		ActiveMDIChild.Add()
	End Sub
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		'SaveActive
		'UPGRADE_ISSUE: Control Cancel could not be resolved because it was within the generic namespace ActiveMDIChild. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup2072"'
		ActiveMDIChild.Cancel()
	End Sub
	
	Private Sub cmdDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDelete.Click
		'UPGRADE_ISSUE: Control Delete could not be resolved because it was within the generic namespace ActiveMDIChild. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup2072"'
		ActiveMDIChild.Delete()
	End Sub
	
	Private Sub cmdEquipment_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdEquipment.Click
		SaveActive()
		frmPlant.DefInstance.CheckAll("equip")
	End Sub
	
	Private Sub cmdFirst_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFirst.Click
		'UPGRADE_ISSUE: Control FirstRec could not be resolved because it was within the generic namespace ActiveMDIChild. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup2072"'
		ActiveMDIChild.FirstRec()
	End Sub
	
	Private Sub cmdFormView_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFormView.Click
		'UPGRADE_ISSUE: Control FormView could not be resolved because it was within the generic namespace ActiveMDIChild. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup2072"'
		ActiveMDIChild.FormView()
	End Sub
	
	Private Sub cmdGridView_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdGridView.Click
		'UPGRADE_ISSUE: Control GridView could not be resolved because it was within the generic namespace ActiveMDIChild. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup2072"'
		ActiveMDIChild.GridView()
	End Sub
	
	Private Sub cmdLast_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdLast.Click
		'UPGRADE_ISSUE: Control LastRec could not be resolved because it was within the generic namespace ActiveMDIChild. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup2072"'
		ActiveMDIChild.LastRec()
	End Sub
	
	Private Sub cmdNext_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNext.Click
		'UPGRADE_ISSUE: Control NextRec could not be resolved because it was within the generic namespace ActiveMDIChild. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup2072"'
		ActiveMDIChild.NextRec()
	End Sub
	
	Private Sub cmdPrevious_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPrevious.Click
		'UPGRADE_ISSUE: Control PrevRec could not be resolved because it was within the generic namespace ActiveMDIChild. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup2072"'
		ActiveMDIChild.PrevRec()
	End Sub
	
	
	Private Sub cmdPrint_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPrint.Click
		'UPGRADE_ISSUE: Control PrintReports could not be resolved because it was within the generic namespace ActiveMDIChild. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup2072"'
		ActiveMDIChild.PrintReports()
	End Sub
	
	Private Sub cmdRefresh_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRefresh.Click
		SaveActive()
		'UPGRADE_ISSUE: Control RefreshRec could not be resolved because it was within the generic namespace ActiveMDIChild. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup2072"'
		ActiveMDIChild.RefreshRec()
	End Sub
	
	Private Sub cmdSave_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSave.Click
		'UPGRADE_ISSUE: Control Save could not be resolved because it was within the generic namespace ActiveMDIChild. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup2072"'
		ActiveMDIChild.Save()
	End Sub
	
	Private Sub cmdSearch_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSearch.Click
		'UPGRADE_ISSUE: Control SearchRec could not be resolved because it was within the generic namespace ActiveMDIChild. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup2072"'
		ActiveMDIChild.SearchRec()
	End Sub
	
	Private Sub cmdTask_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdTask.Click
		SaveActive()
		frmPlant.DefInstance.CheckAll("task")
	End Sub
	
	Private Sub cmdWorkOrder_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdWorkOrder.Click
		SaveActive()
		frmPlant.DefInstance.CheckAll("wo")
	End Sub
	
	Public Sub SaveActive()
		' This procedure will save the changes in active form
		' by calling function under specific form
		Dim strFormName As String
		
		On Error GoTo errorhandler
		strFormName = ""
		'UPGRADE_ISSUE: Forms collection was not upgraded. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup2068"'
		'UPGRADE_WARNING: Couldn't resolve default property of object Forms.count. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		If Forms.count > 1 Then
			strFormName = ActiveMDIChild.Name
			If (strFormName = "frmTask" Or strFormName = "frmWorkOrder" Or strFormName = "frmEquipment") Then
				'UPGRADE_ISSUE: Control CheckChange could not be resolved because it was within the generic namespace ActiveMDIChild. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup2072"'
				ActiveMDIChild.CheckChange()
			End If
			'MsgBox "Active form is " & strFormName
			'Else
			'MsgBox "MDI is the only form"
		End If
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: MDI - SaveActive: Description - " & Err.Description)
	End Sub
	
	Public Sub FindActive(ByRef bolAllClosed As Boolean)
		
		On Error GoTo errorhandler
		
		If bolAllClosed = True Then
			cmdFormView.Enabled = False
			cmdGridView.Enabled = False
			cmdRefresh.Enabled = False
			cmdSave.Enabled = False
			cmdDelete.Enabled = False
			cmdAdd.Enabled = False
			cmdCancel.Enabled = False
			cmdFirst.Enabled = False
			cmdPrevious.Enabled = False
			cmdNext.Enabled = False
			cmdLast.Enabled = False
			cmdSearch.Enabled = False
			cmdPrint.Enabled = False
		Else
			strActiveFormName = ""
			strActiveFormName = ActiveMDIChild.Name
			Select Case strActiveFormName
				Case "frmMeterReading"
					cmdFormView.Enabled = False
					cmdGridView.Enabled = False
					cmdRefresh.Enabled = True
					cmdSave.Enabled = False
					cmdDelete.Enabled = False
					cmdAdd.Enabled = False
					cmdCancel.Enabled = False
					cmdFirst.Enabled = False
					cmdPrevious.Enabled = False
					cmdNext.Enabled = False
					cmdLast.Enabled = False
					cmdSearch.Enabled = False
					cmdPrint.Enabled = False
				Case "frmEquipment"
					cmdFormView.Enabled = True
					cmdGridView.Enabled = True
					cmdRefresh.Enabled = True
					cmdSave.Enabled = True
					cmdDelete.Enabled = False
					cmdAdd.Enabled = True
					cmdCancel.Enabled = True
					cmdFirst.Enabled = True
					cmdPrevious.Enabled = True
					cmdNext.Enabled = True
					cmdLast.Enabled = True
					cmdSearch.Enabled = False
					cmdPrint.Enabled = False
				Case "frmTask"
					cmdFormView.Enabled = True
					cmdGridView.Enabled = True
					cmdRefresh.Enabled = True
					cmdSave.Enabled = True
					cmdDelete.Enabled = False
					cmdAdd.Enabled = True
					cmdCancel.Enabled = True
					cmdFirst.Enabled = True
					cmdPrevious.Enabled = True
					cmdNext.Enabled = True
					cmdLast.Enabled = True
					cmdSearch.Enabled = True
					cmdPrint.Enabled = True
				Case "frmWorkOrder"
					cmdFormView.Enabled = True
					cmdGridView.Enabled = True
					cmdRefresh.Enabled = True
					cmdSave.Enabled = True
					cmdDelete.Enabled = True
					cmdAdd.Enabled = True
					cmdCancel.Enabled = True
					cmdFirst.Enabled = True
					cmdPrevious.Enabled = True
					cmdNext.Enabled = True
					cmdLast.Enabled = True
					cmdSearch.Enabled = True
					cmdPrint.Enabled = True
			End Select
		End If
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: MDI - FindActive: Description - " & Err.Description)
	End Sub
	
	Public Sub AddMode()
		
		On Error GoTo errorhandler
		
		cmdFormView.Enabled = False
		cmdGridView.Enabled = False
		cmdRefresh.Enabled = False
		cmdSave.Enabled = True
		cmdDelete.Enabled = False
		cmdAdd.Enabled = False
		cmdCancel.Enabled = True
		cmdFirst.Enabled = False
		cmdPrevious.Enabled = False
		cmdNext.Enabled = False
		cmdLast.Enabled = False
		cmdSearch.Enabled = False
		cmdPrint.Enabled = False
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: MDI - AddMode: Description - " & Err.Description)
	End Sub
	
	Private Sub MDIFormWOS_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		bolCreatePlantClicked = False
	End Sub
	
	'UPGRADE_WARNING: Form event MDIFormWOS.Unload has a new behavior. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup2065"'
	Private Sub MDIFormWOS_Closed(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Closed
		If Not bolCreatePlantClicked Then
			End
		End If
	End Sub
	
	Public Sub mnuEquipList_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuEquipList.Popup
		mnuEquipList_Click(eventSender, eventArgs)
	End Sub
	Public Sub mnuEquipList_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuEquipList.Click
		Dim DRptEquipList As Object
		
		On Error GoTo errorhandler
		
		intReport = 0
		intReport = 1
		DEnvWos.conWOS.Open()
		DEnvWos.comEquipList(intPlantPass)
		'UPGRADE_WARNING: Couldn't resolve default property of object DRptEquipList.Show. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		DRptEquipList.Show(1)
		'UPGRADE_WARNING: Couldn't resolve default property of object DRptEquipList.Top. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		DRptEquipList.Top = 1100
		'UPGRADE_WARNING: Couldn't resolve default property of object DRptEquipList.Left. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		DRptEquipList.Left = 1
		'UPGRADE_WARNING: Couldn't resolve default property of object DRptEquipList.Height. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		DRptEquipList.Height = 6400
		'UPGRADE_WARNING: Couldn't resolve default property of object DRptEquipList.Width. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		DRptEquipList.Width = 9300
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: MDI - mnuEquipList_Click: Description - " & Err.Description)
	End Sub
	
	Public Sub mnuEquipment_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuEquipment.Popup
		mnuEquipment_Click(eventSender, eventArgs)
	End Sub
	Public Sub mnuEquipment_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuEquipment.Click
		SaveActive()
		frmPlant.DefInstance.CheckAll("equip")
	End Sub
	
	Public Sub mnuEquipSum_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuEquipSum.Popup
		mnuEquipSum_Click(eventSender, eventArgs)
	End Sub
	Public Sub mnuEquipSum_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuEquipSum.Click
		Dim DRptEquipSum As Object
		
		On Error GoTo errorhandler
		
		intReport = 0
		intReport = 5
		DEnvWos.conWOS.Open()
		DEnvWos.comEquipList(intPlantPass)
		'UPGRADE_WARNING: Couldn't resolve default property of object DRptEquipSum.Show. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		DRptEquipSum.Show(1)
		'UPGRADE_WARNING: Couldn't resolve default property of object DRptEquipSum.Top. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		DRptEquipSum.Top = 1100
		'UPGRADE_WARNING: Couldn't resolve default property of object DRptEquipSum.Left. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		DRptEquipSum.Left = 1
		'UPGRADE_WARNING: Couldn't resolve default property of object DRptEquipSum.Height. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		DRptEquipSum.Height = 6400
		'UPGRADE_WARNING: Couldn't resolve default property of object DRptEquipSum.Width. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		DRptEquipSum.Width = 9300
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: MDI - mnuEquipSum_Click: Description - " & Err.Description)
	End Sub
	
	Public Sub mnuExit_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuExit.Popup
		mnuExit_Click(eventSender, eventArgs)
	End Sub
	Public Sub mnuExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuExit.Click
		SaveActive()
		End
	End Sub
	
	Public Sub mnuMeterReading_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuMeterReading.Popup
		mnuMeterReading_Click(eventSender, eventArgs)
	End Sub
	Public Sub mnuMeterReading_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuMeterReading.Click
		
		On Error GoTo errorhandler
		'UPGRADE_ISSUE: Forms collection was not upgraded. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup2068"'
		'UPGRADE_WARNING: Couldn't resolve default property of object Forms.count. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		If Forms.count > 1 Then
			If ActiveMDIChild.Name = "frmEquipment" Then
				frmEquipment.DefInstance.Close()
			End If
		End If
		If frmEquipment.DefInstance.CheckRecordset = 2 Then
			MsgBox("Can not open the Meter Reading Screen because there are no records to update.")
		Else
			frmMeterReading.DefInstance.Show()
			frmMeterReading.DefInstance.Activate()
		End If
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: MDI - mnuMeterReading_Click: Description - " & Err.Description)
	End Sub
	
	Public Sub mnuMeterReadingList_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuMeterReadingList.Popup
		mnuMeterReadingList_Click(eventSender, eventArgs)
	End Sub
	Public Sub mnuMeterReadingList_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuMeterReadingList.Click
		Dim DRptMeterReading As Object
		
		On Error GoTo errorhandler
		
		intReport = 0
		intReport = 5
		DEnvWos.conWOS.Open()
		DEnvWos.comMeterReading(intPlantPass)
		'UPGRADE_WARNING: Couldn't resolve default property of object DRptMeterReading.Show. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		DRptMeterReading.Show(1)
		'UPGRADE_WARNING: Couldn't resolve default property of object DRptMeterReading.Top. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		DRptMeterReading.Top = 1100
		'UPGRADE_WARNING: Couldn't resolve default property of object DRptMeterReading.Left. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		DRptMeterReading.Left = 1
		'UPGRADE_WARNING: Couldn't resolve default property of object DRptMeterReading.Height. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		DRptMeterReading.Height = 6400
		'UPGRADE_WARNING: Couldn't resolve default property of object DRptMeterReading.Width. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		DRptMeterReading.Width = 9300
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: MDI - mnuMeterReadingList_Click: Description - " & Err.Description)
	End Sub
	
	Public Sub mnuNewPlant_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuNewPlant.Popup
		mnuNewPlant_Click(eventSender, eventArgs)
	End Sub
	Public Sub mnuNewPlant_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuNewPlant.Click
		
		On Error GoTo errorhandler
		SaveActive()
		bolCreatePlantClicked = True
		MDIFormWOS.DefInstance.Close()
		frmPlant.DefInstance.Show()
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: MDI - cboEquipID_KeyUp: Description - " & Err.Description)
	End Sub
	
	Public Sub mnuTask_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuTask.Popup
		mnuTask_Click(eventSender, eventArgs)
	End Sub
	Public Sub mnuTask_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuTask.Click
		SaveActive()
		frmPlant.DefInstance.CheckAll("task")
	End Sub
	
	Public Sub mnuWorkOrder_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuWorkOrder.Popup
		mnuWorkOrder_Click(eventSender, eventArgs)
	End Sub
	Public Sub mnuWorkOrder_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuWorkOrder.Click
		SaveActive()
		frmPlant.DefInstance.CheckAll("wo")
	End Sub
End Class