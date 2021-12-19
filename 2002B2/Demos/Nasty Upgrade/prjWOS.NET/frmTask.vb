Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmTask
	Inherits System.Windows.Forms.Form
#Region "Windows Form Designer generated code "
	Public Sub New()
		MyBase.New()
		If m_vb6FormDefInstance Is Nothing Then
			If m_InitializingDefInstance Then
				m_vb6FormDefInstance = Me
			Else
				Try 
					'For the start-up form, the first instance created is the default instance.
					If System.Reflection.Assembly.GetExecutingAssembly.EntryPoint.DeclaringType Is Me.GetType Then
						m_vb6FormDefInstance = Me
					End If
				Catch
				End Try
			End If
		End If
		'This call is required by the Windows Form Designer.
		InitializeComponent()
		'This form is an MDI child.
		'This code simulates the VB6 
		' functionality of automatically
		' loading and showing an MDI
		' child's parent.
		Me.MDIParent = prjWOS.MDIFormWOS.DefInstance.DefInstance
		prjWOS.MDIFormWOS.DefInstance.DefInstance.Show
		'The MDI form in the VB6 project had its
		'AutoShowChildren property set to True
		'To simulate the VB6 behavior, we need to
		'automatically Show the form whenever it
		'is loaded.  If you do not want this behavior
		'then delete the following line of code
		'UPGRADE_NOTE: Remove the next line of code to stop form from automatically showing. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup2018"'
		Me.Show
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
	Public WithEvents cmdPrintForm As System.Windows.Forms.Button
	Public WithEvents txtCreatedby As System.Windows.Forms.TextBox
	Public WithEvents txtWorkDueWhenMeterReads As System.Windows.Forms.TextBox
	Public WithEvents txtTaskDesc As System.Windows.Forms.TextBox
	Public WithEvents txtIntervalDays As System.Windows.Forms.TextBox
	Public WithEvents txtIntervalMeter As System.Windows.Forms.TextBox
	Public WithEvents txtToolsRequired As System.Windows.Forms.TextBox
	Public WithEvents txtLastWorkedMeterReading As System.Windows.Forms.TextBox
	Public WithEvents txtMiscComments As System.Windows.Forms.TextBox
	Public WithEvents txtLoTo As System.Windows.Forms.TextBox
	Public WithEvents cboPriority As System.Windows.Forms.ComboBox
	Public WithEvents cboCycleType As System.Windows.Forms.ComboBox
	Public WithEvents cboEquipID As System.Windows.Forms.ComboBox
	Public WithEvents txtCount As System.Windows.Forms.TextBox
	Public WithEvents txtLastWorkedDate As AxMSMask.AxMaskEdBox
	Public WithEvents txtWorkDueDate As AxMSMask.AxMaskEdBox
	Public WithEvents lblCreatedby As System.Windows.Forms.Label
	Public WithEvents lblWorkDueWhenMeterReads As System.Windows.Forms.Label
	Public WithEvents lblWorkDueDate As System.Windows.Forms.Label
	Public WithEvents lblPlantName As System.Windows.Forms.Label
	Public WithEvents lblMiscComments As System.Windows.Forms.Label
	Public WithEvents lblLoTo As System.Windows.Forms.Label
	Public WithEvents lblLastWorkedDate As System.Windows.Forms.Label
	Public WithEvents lblLastWorkedMeterReading As System.Windows.Forms.Label
	Public WithEvents lblToolsRequired As System.Windows.Forms.Label
	Public WithEvents lblIntervalMeter As System.Windows.Forms.Label
	Public WithEvents lblIntervalDays As System.Windows.Forms.Label
	Public WithEvents lblCycleType As System.Windows.Forms.Label
	Public WithEvents lblPriority As System.Windows.Forms.Label
	Public WithEvents lblTaskDesc As System.Windows.Forms.Label
	Public WithEvents lblEquip As System.Windows.Forms.Label
	Public WithEvents FramForm As System.Windows.Forms.GroupBox
	Public WithEvents DGridTask As AxMSDataGridLib.AxDataGrid
	Public WithEvents lblPlantNameG As System.Windows.Forms.Label
	Public WithEvents FramGrid As System.Windows.Forms.GroupBox
	Public WithEvents Label12 As System.Windows.Forms.Label
	Public WithEvents Label11 As System.Windows.Forms.Label
	Public WithEvents Label10 As System.Windows.Forms.Label
	Public WithEvents Label9 As System.Windows.Forms.Label
	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTask))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ToolTip1.Active = True
		Me.cmdPrintForm = New System.Windows.Forms.Button
		Me.FramForm = New System.Windows.Forms.GroupBox
		Me.txtCreatedby = New System.Windows.Forms.TextBox
		Me.txtWorkDueWhenMeterReads = New System.Windows.Forms.TextBox
		Me.txtTaskDesc = New System.Windows.Forms.TextBox
		Me.txtIntervalDays = New System.Windows.Forms.TextBox
		Me.txtIntervalMeter = New System.Windows.Forms.TextBox
		Me.txtToolsRequired = New System.Windows.Forms.TextBox
		Me.txtLastWorkedMeterReading = New System.Windows.Forms.TextBox
		Me.txtMiscComments = New System.Windows.Forms.TextBox
		Me.txtLoTo = New System.Windows.Forms.TextBox
		Me.cboPriority = New System.Windows.Forms.ComboBox
		Me.cboCycleType = New System.Windows.Forms.ComboBox
		Me.cboEquipID = New System.Windows.Forms.ComboBox
		Me.txtCount = New System.Windows.Forms.TextBox
		Me.txtLastWorkedDate = New AxMSMask.AxMaskEdBox
		Me.txtWorkDueDate = New AxMSMask.AxMaskEdBox
		Me.lblCreatedby = New System.Windows.Forms.Label
		Me.lblWorkDueWhenMeterReads = New System.Windows.Forms.Label
		Me.lblWorkDueDate = New System.Windows.Forms.Label
		Me.lblPlantName = New System.Windows.Forms.Label
		Me.lblMiscComments = New System.Windows.Forms.Label
		Me.lblLoTo = New System.Windows.Forms.Label
		Me.lblLastWorkedDate = New System.Windows.Forms.Label
		Me.lblLastWorkedMeterReading = New System.Windows.Forms.Label
		Me.lblToolsRequired = New System.Windows.Forms.Label
		Me.lblIntervalMeter = New System.Windows.Forms.Label
		Me.lblIntervalDays = New System.Windows.Forms.Label
		Me.lblCycleType = New System.Windows.Forms.Label
		Me.lblPriority = New System.Windows.Forms.Label
		Me.lblTaskDesc = New System.Windows.Forms.Label
		Me.lblEquip = New System.Windows.Forms.Label
		Me.FramGrid = New System.Windows.Forms.GroupBox
		Me.DGridTask = New AxMSDataGridLib.AxDataGrid
		Me.lblPlantNameG = New System.Windows.Forms.Label
		Me.Label12 = New System.Windows.Forms.Label
		Me.Label11 = New System.Windows.Forms.Label
		Me.Label10 = New System.Windows.Forms.Label
		Me.Label9 = New System.Windows.Forms.Label
		Me.Label8 = New System.Windows.Forms.Label
		Me.Label7 = New System.Windows.Forms.Label
		Me.Label6 = New System.Windows.Forms.Label
		Me.Label5 = New System.Windows.Forms.Label
		Me.Label4 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		CType(Me.txtLastWorkedDate, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txtWorkDueDate, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.DGridTask, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Text = "Work Order"
		Me.ClientSize = New System.Drawing.Size(748, 463)
		Me.Location = New System.Drawing.Point(4, 23)
		Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds
		Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
		Me.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.MaximizeBox = True
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.Name = "frmTask"
		Me.cmdPrintForm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPrintForm.Text = "Print Work Order"
		Me.cmdPrintForm.Size = New System.Drawing.Size(89, 25)
		Me.cmdPrintForm.Location = New System.Drawing.Point(496, 400)
		Me.cmdPrintForm.TabIndex = 46
		Me.cmdPrintForm.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdPrintForm.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPrintForm.CausesValidation = True
		Me.cmdPrintForm.Enabled = True
		Me.cmdPrintForm.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPrintForm.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPrintForm.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPrintForm.TabStop = True
		Me.cmdPrintForm.Name = "cmdPrintForm"
		Me.FramForm.Size = New System.Drawing.Size(561, 393)
		Me.FramForm.Location = New System.Drawing.Point(24, 0)
		Me.FramForm.TabIndex = 3
		Me.FramForm.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.FramForm.BackColor = System.Drawing.SystemColors.Control
		Me.FramForm.Enabled = True
		Me.FramForm.ForeColor = System.Drawing.SystemColors.ControlText
		Me.FramForm.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.FramForm.Visible = True
		Me.FramForm.Name = "FramForm"
		Me.txtCreatedby.AutoSize = False
		Me.txtCreatedby.Size = New System.Drawing.Size(177, 19)
		Me.txtCreatedby.Location = New System.Drawing.Point(168, 296)
		Me.txtCreatedby.Maxlength = 50
		Me.txtCreatedby.TabIndex = 12
		Me.txtCreatedby.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtCreatedby.AcceptsReturn = True
		Me.txtCreatedby.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtCreatedby.BackColor = System.Drawing.SystemColors.Window
		Me.txtCreatedby.CausesValidation = True
		Me.txtCreatedby.Enabled = True
		Me.txtCreatedby.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtCreatedby.HideSelection = True
		Me.txtCreatedby.ReadOnly = False
		Me.txtCreatedby.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtCreatedby.MultiLine = False
		Me.txtCreatedby.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtCreatedby.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtCreatedby.TabStop = True
		Me.txtCreatedby.Visible = True
		Me.txtCreatedby.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtCreatedby.Name = "txtCreatedby"
		Me.txtWorkDueWhenMeterReads.AutoSize = False
		Me.txtWorkDueWhenMeterReads.Enabled = False
		Me.txtWorkDueWhenMeterReads.Size = New System.Drawing.Size(81, 19)
		Me.txtWorkDueWhenMeterReads.Location = New System.Drawing.Point(168, 328)
		Me.txtWorkDueWhenMeterReads.ReadOnly = True
		Me.txtWorkDueWhenMeterReads.TabIndex = 43
		Me.txtWorkDueWhenMeterReads.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtWorkDueWhenMeterReads.AcceptsReturn = True
		Me.txtWorkDueWhenMeterReads.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtWorkDueWhenMeterReads.BackColor = System.Drawing.SystemColors.Window
		Me.txtWorkDueWhenMeterReads.CausesValidation = True
		Me.txtWorkDueWhenMeterReads.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtWorkDueWhenMeterReads.HideSelection = True
		Me.txtWorkDueWhenMeterReads.Maxlength = 0
		Me.txtWorkDueWhenMeterReads.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtWorkDueWhenMeterReads.MultiLine = False
		Me.txtWorkDueWhenMeterReads.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtWorkDueWhenMeterReads.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtWorkDueWhenMeterReads.TabStop = True
		Me.txtWorkDueWhenMeterReads.Visible = True
		Me.txtWorkDueWhenMeterReads.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtWorkDueWhenMeterReads.Name = "txtWorkDueWhenMeterReads"
		Me.txtTaskDesc.AutoSize = False
		Me.txtTaskDesc.Size = New System.Drawing.Size(313, 19)
		Me.txtTaskDesc.Location = New System.Drawing.Point(168, 56)
		Me.txtTaskDesc.Maxlength = 50
		Me.txtTaskDesc.TabIndex = 1
		Me.txtTaskDesc.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtTaskDesc.AcceptsReturn = True
		Me.txtTaskDesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtTaskDesc.BackColor = System.Drawing.SystemColors.Window
		Me.txtTaskDesc.CausesValidation = True
		Me.txtTaskDesc.Enabled = True
		Me.txtTaskDesc.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtTaskDesc.HideSelection = True
		Me.txtTaskDesc.ReadOnly = False
		Me.txtTaskDesc.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtTaskDesc.MultiLine = False
		Me.txtTaskDesc.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtTaskDesc.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtTaskDesc.TabStop = True
		Me.txtTaskDesc.Visible = True
		Me.txtTaskDesc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtTaskDesc.Name = "txtTaskDesc"
		Me.txtIntervalDays.AutoSize = False
		Me.txtIntervalDays.Size = New System.Drawing.Size(81, 19)
		Me.txtIntervalDays.Location = New System.Drawing.Point(168, 80)
		Me.txtIntervalDays.TabIndex = 2
		Me.txtIntervalDays.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtIntervalDays.AcceptsReturn = True
		Me.txtIntervalDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtIntervalDays.BackColor = System.Drawing.SystemColors.Window
		Me.txtIntervalDays.CausesValidation = True
		Me.txtIntervalDays.Enabled = True
		Me.txtIntervalDays.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtIntervalDays.HideSelection = True
		Me.txtIntervalDays.ReadOnly = False
		Me.txtIntervalDays.Maxlength = 0
		Me.txtIntervalDays.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtIntervalDays.MultiLine = False
		Me.txtIntervalDays.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtIntervalDays.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtIntervalDays.TabStop = True
		Me.txtIntervalDays.Visible = True
		Me.txtIntervalDays.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtIntervalDays.Name = "txtIntervalDays"
		Me.txtIntervalMeter.AutoSize = False
		Me.txtIntervalMeter.Size = New System.Drawing.Size(81, 19)
		Me.txtIntervalMeter.Location = New System.Drawing.Point(168, 104)
		Me.txtIntervalMeter.TabIndex = 5
		Me.txtIntervalMeter.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtIntervalMeter.AcceptsReturn = True
		Me.txtIntervalMeter.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtIntervalMeter.BackColor = System.Drawing.SystemColors.Window
		Me.txtIntervalMeter.CausesValidation = True
		Me.txtIntervalMeter.Enabled = True
		Me.txtIntervalMeter.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtIntervalMeter.HideSelection = True
		Me.txtIntervalMeter.ReadOnly = False
		Me.txtIntervalMeter.Maxlength = 0
		Me.txtIntervalMeter.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtIntervalMeter.MultiLine = False
		Me.txtIntervalMeter.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtIntervalMeter.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtIntervalMeter.TabStop = True
		Me.txtIntervalMeter.Visible = True
		Me.txtIntervalMeter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtIntervalMeter.Name = "txtIntervalMeter"
		Me.txtToolsRequired.AutoSize = False
		Me.txtToolsRequired.Size = New System.Drawing.Size(313, 19)
		Me.txtToolsRequired.Location = New System.Drawing.Point(168, 152)
		Me.txtToolsRequired.Maxlength = 50
		Me.txtToolsRequired.TabIndex = 9
		Me.txtToolsRequired.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtToolsRequired.AcceptsReturn = True
		Me.txtToolsRequired.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtToolsRequired.BackColor = System.Drawing.SystemColors.Window
		Me.txtToolsRequired.CausesValidation = True
		Me.txtToolsRequired.Enabled = True
		Me.txtToolsRequired.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtToolsRequired.HideSelection = True
		Me.txtToolsRequired.ReadOnly = False
		Me.txtToolsRequired.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtToolsRequired.MultiLine = False
		Me.txtToolsRequired.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtToolsRequired.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtToolsRequired.TabStop = True
		Me.txtToolsRequired.Visible = True
		Me.txtToolsRequired.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtToolsRequired.Name = "txtToolsRequired"
		Me.txtLastWorkedMeterReading.AutoSize = False
		Me.txtLastWorkedMeterReading.Size = New System.Drawing.Size(81, 19)
		Me.txtLastWorkedMeterReading.Location = New System.Drawing.Point(400, 104)
		Me.txtLastWorkedMeterReading.TabIndex = 6
		Me.txtLastWorkedMeterReading.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtLastWorkedMeterReading.AcceptsReturn = True
		Me.txtLastWorkedMeterReading.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtLastWorkedMeterReading.BackColor = System.Drawing.SystemColors.Window
		Me.txtLastWorkedMeterReading.CausesValidation = True
		Me.txtLastWorkedMeterReading.Enabled = True
		Me.txtLastWorkedMeterReading.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtLastWorkedMeterReading.HideSelection = True
		Me.txtLastWorkedMeterReading.ReadOnly = False
		Me.txtLastWorkedMeterReading.Maxlength = 0
		Me.txtLastWorkedMeterReading.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtLastWorkedMeterReading.MultiLine = False
		Me.txtLastWorkedMeterReading.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtLastWorkedMeterReading.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtLastWorkedMeterReading.TabStop = True
		Me.txtLastWorkedMeterReading.Visible = True
		Me.txtLastWorkedMeterReading.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtLastWorkedMeterReading.Name = "txtLastWorkedMeterReading"
		Me.txtMiscComments.AutoSize = False
		Me.txtMiscComments.Size = New System.Drawing.Size(313, 83)
		Me.txtMiscComments.Location = New System.Drawing.Point(168, 200)
		Me.txtMiscComments.Maxlength = 255
		Me.txtMiscComments.MultiLine = True
		Me.txtMiscComments.TabIndex = 11
		Me.txtMiscComments.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtMiscComments.AcceptsReturn = True
		Me.txtMiscComments.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtMiscComments.BackColor = System.Drawing.SystemColors.Window
		Me.txtMiscComments.CausesValidation = True
		Me.txtMiscComments.Enabled = True
		Me.txtMiscComments.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtMiscComments.HideSelection = True
		Me.txtMiscComments.ReadOnly = False
		Me.txtMiscComments.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtMiscComments.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtMiscComments.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtMiscComments.TabStop = True
		Me.txtMiscComments.Visible = True
		Me.txtMiscComments.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtMiscComments.Name = "txtMiscComments"
		Me.txtLoTo.AutoSize = False
		Me.txtLoTo.Size = New System.Drawing.Size(81, 19)
		Me.txtLoTo.Location = New System.Drawing.Point(168, 176)
		Me.txtLoTo.Maxlength = 10
		Me.txtLoTo.TabIndex = 10
		Me.txtLoTo.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtLoTo.AcceptsReturn = True
		Me.txtLoTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtLoTo.BackColor = System.Drawing.SystemColors.Window
		Me.txtLoTo.CausesValidation = True
		Me.txtLoTo.Enabled = True
		Me.txtLoTo.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtLoTo.HideSelection = True
		Me.txtLoTo.ReadOnly = False
		Me.txtLoTo.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtLoTo.MultiLine = False
		Me.txtLoTo.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtLoTo.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtLoTo.TabStop = True
		Me.txtLoTo.Visible = True
		Me.txtLoTo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtLoTo.Name = "txtLoTo"
		Me.cboPriority.Size = New System.Drawing.Size(113, 21)
		Me.cboPriority.Location = New System.Drawing.Point(368, 128)
		Me.cboPriority.Items.AddRange(New Object(){"High", "Medium", "Low"})
		Me.cboPriority.TabIndex = 8
		Me.cboPriority.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cboPriority.BackColor = System.Drawing.SystemColors.Window
		Me.cboPriority.CausesValidation = True
		Me.cboPriority.Enabled = True
		Me.cboPriority.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cboPriority.IntegralHeight = True
		Me.cboPriority.Cursor = System.Windows.Forms.Cursors.Default
		Me.cboPriority.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cboPriority.Sorted = False
		Me.cboPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cboPriority.TabStop = True
		Me.cboPriority.Visible = True
		Me.cboPriority.Name = "cboPriority"
		Me.cboCycleType.Size = New System.Drawing.Size(137, 21)
		Me.cboCycleType.Location = New System.Drawing.Point(168, 128)
		Me.cboCycleType.Items.AddRange(New Object(){"Meter Cycle", "Days Cycle", "Unschedule"})
		Me.cboCycleType.TabIndex = 7
		Me.cboCycleType.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cboCycleType.BackColor = System.Drawing.SystemColors.Window
		Me.cboCycleType.CausesValidation = True
		Me.cboCycleType.Enabled = True
		Me.cboCycleType.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cboCycleType.IntegralHeight = True
		Me.cboCycleType.Cursor = System.Windows.Forms.Cursors.Default
		Me.cboCycleType.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cboCycleType.Sorted = False
		Me.cboCycleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cboCycleType.TabStop = True
		Me.cboCycleType.Visible = True
		Me.cboCycleType.Name = "cboCycleType"
		Me.cboEquipID.Size = New System.Drawing.Size(313, 21)
		Me.cboEquipID.Location = New System.Drawing.Point(168, 32)
		Me.cboEquipID.TabIndex = 0
		Me.cboEquipID.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cboEquipID.BackColor = System.Drawing.SystemColors.Window
		Me.cboEquipID.CausesValidation = True
		Me.cboEquipID.Enabled = True
		Me.cboEquipID.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cboEquipID.IntegralHeight = True
		Me.cboEquipID.Cursor = System.Windows.Forms.Cursors.Default
		Me.cboEquipID.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cboEquipID.Sorted = False
		Me.cboEquipID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cboEquipID.TabStop = True
		Me.cboEquipID.Visible = True
		Me.cboEquipID.Name = "cboEquipID"
		Me.txtCount.AutoSize = False
		Me.txtCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		Me.txtCount.Enabled = False
		Me.txtCount.ForeColor = System.Drawing.Color.Blue
		Me.txtCount.Size = New System.Drawing.Size(193, 19)
		Me.txtCount.Location = New System.Drawing.Point(176, 0)
		Me.txtCount.ReadOnly = True
		Me.txtCount.TabIndex = 37
		Me.txtCount.TabStop = False
		Me.txtCount.Text = "1"
		Me.txtCount.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtCount.AcceptsReturn = True
		Me.txtCount.BackColor = System.Drawing.SystemColors.Window
		Me.txtCount.CausesValidation = True
		Me.txtCount.HideSelection = True
		Me.txtCount.Maxlength = 0
		Me.txtCount.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtCount.MultiLine = False
		Me.txtCount.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtCount.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtCount.Visible = True
		Me.txtCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtCount.Name = "txtCount"
		txtLastWorkedDate.OcxState = CType(resources.GetObject("txtLastWorkedDate.OcxState"), System.Windows.Forms.AxHost.State)
		Me.txtLastWorkedDate.Size = New System.Drawing.Size(81, 17)
		Me.txtLastWorkedDate.Location = New System.Drawing.Point(400, 80)
		Me.txtLastWorkedDate.TabIndex = 4
		Me.txtLastWorkedDate.Name = "txtLastWorkedDate"
		txtWorkDueDate.OcxState = CType(resources.GetObject("txtWorkDueDate.OcxState"), System.Windows.Forms.AxHost.State)
		Me.txtWorkDueDate.Size = New System.Drawing.Size(81, 17)
		Me.txtWorkDueDate.Location = New System.Drawing.Point(400, 328)
		Me.txtWorkDueDate.TabIndex = 44
		Me.txtWorkDueDate.Name = "txtWorkDueDate"
		Me.lblCreatedby.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblCreatedby.Text = "Created by:"
		Me.lblCreatedby.Size = New System.Drawing.Size(73, 17)
		Me.lblCreatedby.Location = New System.Drawing.Point(88, 296)
		Me.lblCreatedby.TabIndex = 45
		Me.lblCreatedby.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblCreatedby.BackColor = System.Drawing.SystemColors.Control
		Me.lblCreatedby.Enabled = True
		Me.lblCreatedby.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblCreatedby.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblCreatedby.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblCreatedby.UseMnemonic = True
		Me.lblCreatedby.Visible = True
		Me.lblCreatedby.AutoSize = False
		Me.lblCreatedby.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblCreatedby.Name = "lblCreatedby"
		Me.lblWorkDueWhenMeterReads.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblWorkDueWhenMeterReads.Text = "Work Due When Meter Reads:"
		Me.lblWorkDueWhenMeterReads.Size = New System.Drawing.Size(161, 17)
		Me.lblWorkDueWhenMeterReads.Location = New System.Drawing.Point(8, 328)
		Me.lblWorkDueWhenMeterReads.TabIndex = 42
		Me.lblWorkDueWhenMeterReads.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblWorkDueWhenMeterReads.BackColor = System.Drawing.SystemColors.Control
		Me.lblWorkDueWhenMeterReads.Enabled = True
		Me.lblWorkDueWhenMeterReads.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblWorkDueWhenMeterReads.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblWorkDueWhenMeterReads.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblWorkDueWhenMeterReads.UseMnemonic = True
		Me.lblWorkDueWhenMeterReads.Visible = True
		Me.lblWorkDueWhenMeterReads.AutoSize = False
		Me.lblWorkDueWhenMeterReads.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblWorkDueWhenMeterReads.Name = "lblWorkDueWhenMeterReads"
		Me.lblWorkDueDate.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblWorkDueDate.Text = "Work Due Date:"
		Me.lblWorkDueDate.Size = New System.Drawing.Size(81, 17)
		Me.lblWorkDueDate.Location = New System.Drawing.Point(312, 328)
		Me.lblWorkDueDate.TabIndex = 41
		Me.lblWorkDueDate.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblWorkDueDate.BackColor = System.Drawing.SystemColors.Control
		Me.lblWorkDueDate.Enabled = True
		Me.lblWorkDueDate.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblWorkDueDate.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblWorkDueDate.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblWorkDueDate.UseMnemonic = True
		Me.lblWorkDueDate.Visible = True
		Me.lblWorkDueDate.AutoSize = False
		Me.lblWorkDueDate.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblWorkDueDate.Name = "lblWorkDueDate"
		Me.lblPlantName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblPlantName.Size = New System.Drawing.Size(161, 17)
		Me.lblPlantName.Location = New System.Drawing.Point(0, 0)
		Me.lblPlantName.TabIndex = 39
		Me.lblPlantName.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblPlantName.BackColor = System.Drawing.SystemColors.Control
		Me.lblPlantName.Enabled = True
		Me.lblPlantName.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblPlantName.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblPlantName.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblPlantName.UseMnemonic = True
		Me.lblPlantName.Visible = True
		Me.lblPlantName.AutoSize = False
		Me.lblPlantName.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblPlantName.Name = "lblPlantName"
		Me.lblMiscComments.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblMiscComments.Text = "Comments:"
		Me.lblMiscComments.Size = New System.Drawing.Size(81, 17)
		Me.lblMiscComments.Location = New System.Drawing.Point(80, 200)
		Me.lblMiscComments.TabIndex = 35
		Me.lblMiscComments.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMiscComments.BackColor = System.Drawing.SystemColors.Control
		Me.lblMiscComments.Enabled = True
		Me.lblMiscComments.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMiscComments.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMiscComments.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMiscComments.UseMnemonic = True
		Me.lblMiscComments.Visible = True
		Me.lblMiscComments.AutoSize = False
		Me.lblMiscComments.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMiscComments.Name = "lblMiscComments"
		Me.lblLoTo.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblLoTo.Text = "Lockout/Tagout:"
		Me.lblLoTo.Size = New System.Drawing.Size(81, 17)
		Me.lblLoTo.Location = New System.Drawing.Point(88, 176)
		Me.lblLoTo.TabIndex = 34
		Me.lblLoTo.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblLoTo.BackColor = System.Drawing.SystemColors.Control
		Me.lblLoTo.Enabled = True
		Me.lblLoTo.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblLoTo.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblLoTo.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblLoTo.UseMnemonic = True
		Me.lblLoTo.Visible = True
		Me.lblLoTo.AutoSize = False
		Me.lblLoTo.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblLoTo.Name = "lblLoTo"
		Me.lblLastWorkedDate.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblLastWorkedDate.Text = "Last Worked Date:"
		Me.lblLastWorkedDate.Size = New System.Drawing.Size(97, 17)
		Me.lblLastWorkedDate.Location = New System.Drawing.Point(296, 80)
		Me.lblLastWorkedDate.TabIndex = 33
		Me.lblLastWorkedDate.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblLastWorkedDate.BackColor = System.Drawing.SystemColors.Control
		Me.lblLastWorkedDate.Enabled = True
		Me.lblLastWorkedDate.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblLastWorkedDate.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblLastWorkedDate.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblLastWorkedDate.UseMnemonic = True
		Me.lblLastWorkedDate.Visible = True
		Me.lblLastWorkedDate.AutoSize = False
		Me.lblLastWorkedDate.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblLastWorkedDate.Name = "lblLastWorkedDate"
		Me.lblLastWorkedMeterReading.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblLastWorkedMeterReading.Text = "Last Worked Meter Reading:"
		Me.lblLastWorkedMeterReading.Size = New System.Drawing.Size(137, 17)
		Me.lblLastWorkedMeterReading.Location = New System.Drawing.Point(256, 104)
		Me.lblLastWorkedMeterReading.TabIndex = 32
		Me.lblLastWorkedMeterReading.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblLastWorkedMeterReading.BackColor = System.Drawing.SystemColors.Control
		Me.lblLastWorkedMeterReading.Enabled = True
		Me.lblLastWorkedMeterReading.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblLastWorkedMeterReading.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblLastWorkedMeterReading.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblLastWorkedMeterReading.UseMnemonic = True
		Me.lblLastWorkedMeterReading.Visible = True
		Me.lblLastWorkedMeterReading.AutoSize = False
		Me.lblLastWorkedMeterReading.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblLastWorkedMeterReading.Name = "lblLastWorkedMeterReading"
		Me.lblToolsRequired.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblToolsRequired.Text = "Tools Required:"
		Me.lblToolsRequired.Size = New System.Drawing.Size(81, 17)
		Me.lblToolsRequired.Location = New System.Drawing.Point(80, 152)
		Me.lblToolsRequired.TabIndex = 31
		Me.lblToolsRequired.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblToolsRequired.BackColor = System.Drawing.SystemColors.Control
		Me.lblToolsRequired.Enabled = True
		Me.lblToolsRequired.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblToolsRequired.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblToolsRequired.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblToolsRequired.UseMnemonic = True
		Me.lblToolsRequired.Visible = True
		Me.lblToolsRequired.AutoSize = False
		Me.lblToolsRequired.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblToolsRequired.Name = "lblToolsRequired"
		Me.lblIntervalMeter.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblIntervalMeter.Text = "Interval Meter:"
		Me.lblIntervalMeter.Size = New System.Drawing.Size(73, 17)
		Me.lblIntervalMeter.Location = New System.Drawing.Point(88, 104)
		Me.lblIntervalMeter.TabIndex = 30
		Me.lblIntervalMeter.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblIntervalMeter.BackColor = System.Drawing.SystemColors.Control
		Me.lblIntervalMeter.Enabled = True
		Me.lblIntervalMeter.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblIntervalMeter.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblIntervalMeter.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblIntervalMeter.UseMnemonic = True
		Me.lblIntervalMeter.Visible = True
		Me.lblIntervalMeter.AutoSize = False
		Me.lblIntervalMeter.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblIntervalMeter.Name = "lblIntervalMeter"
		Me.lblIntervalDays.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblIntervalDays.Text = "Interval Days:"
		Me.lblIntervalDays.Size = New System.Drawing.Size(65, 17)
		Me.lblIntervalDays.Location = New System.Drawing.Point(96, 80)
		Me.lblIntervalDays.TabIndex = 29
		Me.lblIntervalDays.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblIntervalDays.BackColor = System.Drawing.SystemColors.Control
		Me.lblIntervalDays.Enabled = True
		Me.lblIntervalDays.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblIntervalDays.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblIntervalDays.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblIntervalDays.UseMnemonic = True
		Me.lblIntervalDays.Visible = True
		Me.lblIntervalDays.AutoSize = False
		Me.lblIntervalDays.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblIntervalDays.Name = "lblIntervalDays"
		Me.lblCycleType.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblCycleType.Text = "Cycle Type:"
		Me.lblCycleType.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblCycleType.Size = New System.Drawing.Size(89, 17)
		Me.lblCycleType.Location = New System.Drawing.Point(72, 128)
		Me.lblCycleType.TabIndex = 28
		Me.lblCycleType.BackColor = System.Drawing.SystemColors.Control
		Me.lblCycleType.Enabled = True
		Me.lblCycleType.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblCycleType.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblCycleType.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblCycleType.UseMnemonic = True
		Me.lblCycleType.Visible = True
		Me.lblCycleType.AutoSize = False
		Me.lblCycleType.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblCycleType.Name = "lblCycleType"
		Me.lblPriority.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblPriority.Text = "Priority:"
		Me.lblPriority.Size = New System.Drawing.Size(41, 17)
		Me.lblPriority.Location = New System.Drawing.Point(320, 128)
		Me.lblPriority.TabIndex = 27
		Me.lblPriority.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblPriority.BackColor = System.Drawing.SystemColors.Control
		Me.lblPriority.Enabled = True
		Me.lblPriority.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblPriority.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblPriority.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblPriority.UseMnemonic = True
		Me.lblPriority.Visible = True
		Me.lblPriority.AutoSize = False
		Me.lblPriority.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblPriority.Name = "lblPriority"
		Me.lblTaskDesc.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblTaskDesc.Text = "Work Order Description:"
		Me.lblTaskDesc.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTaskDesc.Size = New System.Drawing.Size(153, 17)
		Me.lblTaskDesc.Location = New System.Drawing.Point(8, 56)
		Me.lblTaskDesc.TabIndex = 26
		Me.lblTaskDesc.BackColor = System.Drawing.SystemColors.Control
		Me.lblTaskDesc.Enabled = True
		Me.lblTaskDesc.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblTaskDesc.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblTaskDesc.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblTaskDesc.UseMnemonic = True
		Me.lblTaskDesc.Visible = True
		Me.lblTaskDesc.AutoSize = False
		Me.lblTaskDesc.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblTaskDesc.Name = "lblTaskDesc"
		Me.lblEquip.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblEquip.Text = "Equipment:"
		Me.lblEquip.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblEquip.Size = New System.Drawing.Size(81, 17)
		Me.lblEquip.Location = New System.Drawing.Point(80, 32)
		Me.lblEquip.TabIndex = 25
		Me.lblEquip.BackColor = System.Drawing.SystemColors.Control
		Me.lblEquip.Enabled = True
		Me.lblEquip.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblEquip.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblEquip.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblEquip.UseMnemonic = True
		Me.lblEquip.Visible = True
		Me.lblEquip.AutoSize = False
		Me.lblEquip.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblEquip.Name = "lblEquip"
		Me.FramGrid.Size = New System.Drawing.Size(705, 393)
		Me.FramGrid.Location = New System.Drawing.Point(32, 0)
		Me.FramGrid.TabIndex = 36
		Me.FramGrid.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.FramGrid.BackColor = System.Drawing.SystemColors.Control
		Me.FramGrid.Enabled = True
		Me.FramGrid.ForeColor = System.Drawing.SystemColors.ControlText
		Me.FramGrid.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.FramGrid.Visible = True
		Me.FramGrid.Name = "FramGrid"
		DGridTask.OcxState = CType(resources.GetObject("DGridTask.OcxState"), System.Windows.Forms.AxHost.State)
		Me.DGridTask.Size = New System.Drawing.Size(689, 369)
		Me.DGridTask.Location = New System.Drawing.Point(8, 16)
		Me.DGridTask.TabIndex = 38
		Me.DGridTask.Name = "DGridTask"
		Me.lblPlantNameG.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblPlantNameG.Size = New System.Drawing.Size(113, 17)
		Me.lblPlantNameG.Location = New System.Drawing.Point(0, 0)
		Me.lblPlantNameG.TabIndex = 40
		Me.lblPlantNameG.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblPlantNameG.BackColor = System.Drawing.SystemColors.Control
		Me.lblPlantNameG.Enabled = True
		Me.lblPlantNameG.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblPlantNameG.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblPlantNameG.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblPlantNameG.UseMnemonic = True
		Me.lblPlantNameG.Visible = True
		Me.lblPlantNameG.AutoSize = False
		Me.lblPlantNameG.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblPlantNameG.Name = "lblPlantNameG"
		Me.Label12.Text = "Label12"
		Me.Label12.Size = New System.Drawing.Size(81, 33)
		Me.Label12.Location = New System.Drawing.Point(312, 216)
		Me.Label12.TabIndex = 24
		Me.Label12.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label12.BackColor = System.Drawing.SystemColors.Control
		Me.Label12.Enabled = True
		Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label12.UseMnemonic = True
		Me.Label12.Visible = True
		Me.Label12.AutoSize = False
		Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label12.Name = "Label12"
		Me.Label11.Text = "Label11"
		Me.Label11.Size = New System.Drawing.Size(81, 33)
		Me.Label11.Location = New System.Drawing.Point(312, 216)
		Me.Label11.TabIndex = 23
		Me.Label11.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label11.BackColor = System.Drawing.SystemColors.Control
		Me.Label11.Enabled = True
		Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label11.UseMnemonic = True
		Me.Label11.Visible = True
		Me.Label11.AutoSize = False
		Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label11.Name = "Label11"
		Me.Label10.Text = "Label10"
		Me.Label10.Size = New System.Drawing.Size(81, 33)
		Me.Label10.Location = New System.Drawing.Point(312, 216)
		Me.Label10.TabIndex = 22
		Me.Label10.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label10.BackColor = System.Drawing.SystemColors.Control
		Me.Label10.Enabled = True
		Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label10.UseMnemonic = True
		Me.Label10.Visible = True
		Me.Label10.AutoSize = False
		Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label10.Name = "Label10"
		Me.Label9.Text = "Label9"
		Me.Label9.Size = New System.Drawing.Size(81, 33)
		Me.Label9.Location = New System.Drawing.Point(312, 216)
		Me.Label9.TabIndex = 21
		Me.Label9.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label9.BackColor = System.Drawing.SystemColors.Control
		Me.Label9.Enabled = True
		Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label9.UseMnemonic = True
		Me.Label9.Visible = True
		Me.Label9.AutoSize = False
		Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label9.Name = "Label9"
		Me.Label8.Text = "Label8"
		Me.Label8.Size = New System.Drawing.Size(81, 33)
		Me.Label8.Location = New System.Drawing.Point(312, 216)
		Me.Label8.TabIndex = 20
		Me.Label8.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label8.BackColor = System.Drawing.SystemColors.Control
		Me.Label8.Enabled = True
		Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label8.UseMnemonic = True
		Me.Label8.Visible = True
		Me.Label8.AutoSize = False
		Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label8.Name = "Label8"
		Me.Label7.Text = "Label7"
		Me.Label7.Size = New System.Drawing.Size(81, 33)
		Me.Label7.Location = New System.Drawing.Point(312, 216)
		Me.Label7.TabIndex = 19
		Me.Label7.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label7.BackColor = System.Drawing.SystemColors.Control
		Me.Label7.Enabled = True
		Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label7.UseMnemonic = True
		Me.Label7.Visible = True
		Me.Label7.AutoSize = False
		Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label7.Name = "Label7"
		Me.Label6.Text = "Label6"
		Me.Label6.Size = New System.Drawing.Size(81, 33)
		Me.Label6.Location = New System.Drawing.Point(312, 216)
		Me.Label6.TabIndex = 18
		Me.Label6.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label6.BackColor = System.Drawing.SystemColors.Control
		Me.Label6.Enabled = True
		Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label6.UseMnemonic = True
		Me.Label6.Visible = True
		Me.Label6.AutoSize = False
		Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label6.Name = "Label6"
		Me.Label5.Text = "Label5"
		Me.Label5.Size = New System.Drawing.Size(81, 33)
		Me.Label5.Location = New System.Drawing.Point(312, 216)
		Me.Label5.TabIndex = 17
		Me.Label5.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label5.BackColor = System.Drawing.SystemColors.Control
		Me.Label5.Enabled = True
		Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label5.UseMnemonic = True
		Me.Label5.Visible = True
		Me.Label5.AutoSize = False
		Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label5.Name = "Label5"
		Me.Label4.Text = "Label4"
		Me.Label4.Size = New System.Drawing.Size(81, 33)
		Me.Label4.Location = New System.Drawing.Point(312, 216)
		Me.Label4.TabIndex = 16
		Me.Label4.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label4.BackColor = System.Drawing.SystemColors.Control
		Me.Label4.Enabled = True
		Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label4.UseMnemonic = True
		Me.Label4.Visible = True
		Me.Label4.AutoSize = False
		Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label4.Name = "Label4"
		Me.Label3.Text = "Label3"
		Me.Label3.Size = New System.Drawing.Size(81, 33)
		Me.Label3.Location = New System.Drawing.Point(312, 216)
		Me.Label3.TabIndex = 15
		Me.Label3.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label3.BackColor = System.Drawing.SystemColors.Control
		Me.Label3.Enabled = True
		Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label3.UseMnemonic = True
		Me.Label3.Visible = True
		Me.Label3.AutoSize = False
		Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label3.Name = "Label3"
		Me.Label2.Text = "Label2"
		Me.Label2.Size = New System.Drawing.Size(81, 33)
		Me.Label2.Location = New System.Drawing.Point(312, 216)
		Me.Label2.TabIndex = 14
		Me.Label2.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label2.BackColor = System.Drawing.SystemColors.Control
		Me.Label2.Enabled = True
		Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.Visible = True
		Me.Label2.AutoSize = False
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me.Label1.Text = "Label1"
		Me.Label1.Size = New System.Drawing.Size(81, 33)
		Me.Label1.Location = New System.Drawing.Point(312, 216)
		Me.Label1.TabIndex = 13
		Me.Label1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.BackColor = System.Drawing.SystemColors.Control
		Me.Label1.Enabled = True
		Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.Controls.Add(cmdPrintForm)
		Me.Controls.Add(FramForm)
		Me.Controls.Add(FramGrid)
		Me.Controls.Add(Label12)
		Me.Controls.Add(Label11)
		Me.Controls.Add(Label10)
		Me.Controls.Add(Label9)
		Me.Controls.Add(Label8)
		Me.Controls.Add(Label7)
		Me.Controls.Add(Label6)
		Me.Controls.Add(Label5)
		Me.Controls.Add(Label4)
		Me.Controls.Add(Label3)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label1)
		Me.FramForm.Controls.Add(txtCreatedby)
		Me.FramForm.Controls.Add(txtWorkDueWhenMeterReads)
		Me.FramForm.Controls.Add(txtTaskDesc)
		Me.FramForm.Controls.Add(txtIntervalDays)
		Me.FramForm.Controls.Add(txtIntervalMeter)
		Me.FramForm.Controls.Add(txtToolsRequired)
		Me.FramForm.Controls.Add(txtLastWorkedMeterReading)
		Me.FramForm.Controls.Add(txtMiscComments)
		Me.FramForm.Controls.Add(txtLoTo)
		Me.FramForm.Controls.Add(cboPriority)
		Me.FramForm.Controls.Add(cboCycleType)
		Me.FramForm.Controls.Add(cboEquipID)
		Me.FramForm.Controls.Add(txtCount)
		Me.FramForm.Controls.Add(txtLastWorkedDate)
		Me.FramForm.Controls.Add(txtWorkDueDate)
		Me.FramForm.Controls.Add(lblCreatedby)
		Me.FramForm.Controls.Add(lblWorkDueWhenMeterReads)
		Me.FramForm.Controls.Add(lblWorkDueDate)
		Me.FramForm.Controls.Add(lblPlantName)
		Me.FramForm.Controls.Add(lblMiscComments)
		Me.FramForm.Controls.Add(lblLoTo)
		Me.FramForm.Controls.Add(lblLastWorkedDate)
		Me.FramForm.Controls.Add(lblLastWorkedMeterReading)
		Me.FramForm.Controls.Add(lblToolsRequired)
		Me.FramForm.Controls.Add(lblIntervalMeter)
		Me.FramForm.Controls.Add(lblIntervalDays)
		Me.FramForm.Controls.Add(lblCycleType)
		Me.FramForm.Controls.Add(lblPriority)
		Me.FramForm.Controls.Add(lblTaskDesc)
		Me.FramForm.Controls.Add(lblEquip)
		Me.FramGrid.Controls.Add(DGridTask)
		Me.FramGrid.Controls.Add(lblPlantNameG)
		CType(Me.DGridTask, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.txtWorkDueDate, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.txtLastWorkedDate, System.ComponentModel.ISupportInitialize).EndInit()
	End Sub
#End Region 
#Region "Upgrade Support "
	Private Shared m_vb6FormDefInstance As frmTask
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmTask
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmTask()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
	
	Dim rsTaskRetrieve As ADODB.Recordset
	Dim rsListEquip As ADODB.Recordset
	Dim intStatus As Short ' 2 - add, 1 - update
	Dim ans As Short
	Dim strCycleTypeStore, strEquipIDStore As Object
	Dim strPriorityStore As String
	Dim intEquipIDStore As Short
	Dim intUpdateEquipID As Short
	
	Dim strPrintDate, strPrintOpt, strPrintEquipKey As Object
	Dim strPrintMiscComments As String
	Dim intPrintEquip, intPrintTask As Object
	
	
	Private intUpdate As Short ' used to update History if equipment changed in Work Order(Task) screen
	
	Public Sub CheckChange()
		' This will check if value on any field has been changed before
		' moving to new window
		If intStatus = 2 Then
			ans = MsgBox("Do you want to save the new record?", MsgBoxStyle.YesNo)
			If ans = 6 Then
				Save()
			End If
			ans = 0
		Else
			ChangedData()
		End If
		
	End Sub
	
	Public Sub PrintReports()
		Dim DRptTaskSum As Object
		Dim DRptTaskList As Object
		
		'
		' Opens the DataEnvironment's connection object
		' Asks detail or summary report and opens report,
		' which can then be printed
		'
		
		Dim intReportAns As Short
		'UPGRADE_WARNING: Couldn't resolve default property of object intPrintTask. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		intPrintTask = 0
		'UPGRADE_WARNING: Couldn't resolve default property of object intPrintEquip. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		intPrintEquip = 0
		
		On Error GoTo errorhandler
		
		DEnvWos.conWOS.Open()
		DEnvWos.comTaskList(intPrintEquip, intPrintTask, intPlantPass, strPrintOpt, strPrintDate, strPrintEquipKey, strPrintMiscComments)
		intReportAns = MsgBox("Please click YES for detail report, and NO for summarized.", MsgBoxStyle.YesNo)
		If intReportAns = 6 Then
			'UPGRADE_WARNING: Couldn't resolve default property of object DRptTaskList.Show. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			DRptTaskList.Show(1)
			'UPGRADE_WARNING: Couldn't resolve default property of object DRptTaskList.Top. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			DRptTaskList.Top = 1100
			'UPGRADE_WARNING: Couldn't resolve default property of object DRptTaskList.Left. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			DRptTaskList.Left = 1
			'UPGRADE_WARNING: Couldn't resolve default property of object DRptTaskList.Height. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			DRptTaskList.Height = 6400
			'UPGRADE_WARNING: Couldn't resolve default property of object DRptTaskList.Width. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			DRptTaskList.Width = 9300
		Else
			'UPGRADE_WARNING: Couldn't resolve default property of object DRptTaskSum.Show. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			DRptTaskSum.Show(1)
			'UPGRADE_WARNING: Couldn't resolve default property of object DRptTaskSum.Top. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			DRptTaskSum.Top = 1100
			'UPGRADE_WARNING: Couldn't resolve default property of object DRptTaskSum.Left. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			DRptTaskSum.Left = 1
			'UPGRADE_WARNING: Couldn't resolve default property of object DRptTaskSum.Height. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			DRptTaskSum.Height = 6400
			'UPGRADE_WARNING: Couldn't resolve default property of object DRptTaskSum.Width. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			DRptTaskSum.Width = 9300
		End If
		
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Task - PrintReports: Description - " & Err.Description)
	End Sub
	
	Public Sub SearchRec()
		
		'
		' frmSearchTask is opened for entering criteria
		'
		
		On Error GoTo errorhandler
		
		VB6.ShowForm(frmSearchTask.DefInstance, (1))
		Exit Sub
		
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Task - SearchRec: Description - " & Err.Description)
	End Sub
	
	Public Function FindRecords(ByVal strOption As String, ByVal strEquipKey As String, ByVal strEquipID As String, ByVal strTaskID As String, ByVal strDate As String, ByVal strMiscComments As String, ByVal intRetrievalType As Short) As Short
		
		' Takes all the search criteria from search form
		' last argument - 1 for checking and 2- for retrieving
		'
		' Returns 1 - if successful and 0 - if not
		'
		' This is the function called twice from search form -
		' Once to chekc if there are records and then to create sql for new recordset and
		' also to store values if user decides to print the retrived recordset
		'
		Dim strInitialString, strSQL As Object
		Dim strEquipment As String
		Dim rsCheck As ADODB.Recordset
		
		On Error GoTo errorhandler
		' intRetrievalType is used to know if it is just a check or we need to refresh the window
		'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		strInitialString = ""
		If strEquipKey <> "" Then
			'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			strInitialString = " equip_key = '" & Trim(strEquipKey) & "' "
		End If
		If strEquipID <> "" Then
			'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			If strInitialString <> "" Then
				'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				strInitialString = strInitialString & " and task.equip_id = " & Trim(strEquipID)
			Else
				'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				strInitialString = " task.equip_id = " & Trim(strEquipID)
			End If
		End If
		If strTaskID <> "" Then
			'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			If strInitialString <> "" Then
				'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				strInitialString = strInitialString & " and task.task_id = " & Trim(strTaskID)
			Else
				'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				strInitialString = " task.task_id = " & Trim(strTaskID)
			End If
		End If
		If strDate <> "" Then
			'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			If strInitialString <> "" Then
				'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				strInitialString = strInitialString & " and work_due_date <= datevalue('" & Trim(strDate) & "') "
			Else
				'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				strInitialString = " work_due_date <= datevalue('" & Trim(strDate) & "') "
			End If
		End If
		If strMiscComments <> "" Then
			'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			If strInitialString <> "" Then
				'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				strInitialString = strInitialString & " and misc_comments like '%" & Trim(strMiscComments) & "%' "
			Else
				'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				strInitialString = " misc_comments like '%" & Trim(strMiscComments) & "%' "
			End If
		End If
		
		Select Case strOption
			Case "DueDate"
				If intRetrievalType = 2 Then
					'UPGRADE_WARNING: Couldn't resolve default property of object strPrintOpt. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
					strPrintOpt = "DueDate"
					'UPGRADE_WARNING: Couldn't resolve default property of object strPrintDate. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
					strPrintDate = strDate
					If strEquipKey <> "" Then
						'UPGRADE_WARNING: Couldn't resolve default property of object strPrintEquipKey. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
						strPrintEquipKey = strEquipKey
					Else
						'UPGRADE_WARNING: Couldn't resolve default property of object strPrintEquipKey. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
						strPrintEquipKey = "XXXXXXXXXXX"
					End If
					If strEquipID <> "" Then
						'UPGRADE_WARNING: Couldn't resolve default property of object intPrintEquip. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
						intPrintEquip = CShort(strEquipID)
					Else
						'UPGRADE_WARNING: Couldn't resolve default property of object intPrintEquip. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
						intPrintEquip = 0
					End If
					If strTaskID <> "" Then
						'UPGRADE_WARNING: Couldn't resolve default property of object intPrintTask. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
						intPrintTask = CShort(strTaskID)
					Else
						'UPGRADE_WARNING: Couldn't resolve default property of object intPrintTask. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
						intPrintTask = 0
					End If
					If strMiscComments <> "" Then
						strPrintMiscComments = strMiscComments
					Else
						strPrintMiscComments = "XXXXXXXXXXX"
					End If
				End If
				If intPlantPass <> 0 Then
					'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
					'UPGRADE_WARNING: Couldn't resolve default property of object strSQL. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
					strSQL = "SELECT task.*, equipment.equip_key from equipment inner join task on task.equip_id = equipment.equip_id where task.plant_fk = " & intPlantPass & " and " & strInitialString
				Else
					'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
					'UPGRADE_WARNING: Couldn't resolve default property of object strSQL. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
					strSQL = "SELECT task.*, equipment.equip_key from equipment inner join task on task.equip_id = equipment.equip_id where " & strInitialString
				End If
			Case "DueMeter"
				If intRetrievalType = 2 Then
					'UPGRADE_WARNING: Couldn't resolve default property of object strPrintOpt. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
					strPrintOpt = "DueMeter"
					'UPGRADE_WARNING: Couldn't resolve default property of object strPrintDate. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
					strPrintDate = "01/01/1955"
					If strEquipKey <> "" Then
						'UPGRADE_WARNING: Couldn't resolve default property of object strPrintEquipKey. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
						strPrintEquipKey = strEquipKey
					Else
						'UPGRADE_WARNING: Couldn't resolve default property of object strPrintEquipKey. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
						strPrintEquipKey = "XXXXXXXXXXX"
					End If
					If strEquipID <> "" Then
						'UPGRADE_WARNING: Couldn't resolve default property of object intPrintEquip. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
						intPrintEquip = CShort(strEquipID)
					Else
						'UPGRADE_WARNING: Couldn't resolve default property of object intPrintEquip. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
						intPrintEquip = 0
					End If
					If strTaskID <> "" Then
						'UPGRADE_WARNING: Couldn't resolve default property of object intPrintTask. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
						intPrintTask = CShort(strTaskID)
					Else
						'UPGRADE_WARNING: Couldn't resolve default property of object intPrintTask. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
						intPrintTask = 0
					End If
					If strMiscComments <> "" Then
						strPrintMiscComments = strMiscComments
					Else
						strPrintMiscComments = "XXXXXXXXXXX"
					End If
				End If
				If intPlantPass <> 0 Then
					'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
					If strInitialString <> "" Then
						'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
						'UPGRADE_WARNING: Couldn't resolve default property of object strSQL. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
						strSQL = "SELECT task.*, equipment.last_meter_reading, equipment.last_meter_reading_date from equipment inner join task on task.equip_id = equipment.equip_id where work_due_when_meter_reads < last_meter_reading and task.plant_fk = " & intPlantPass & " and " & strInitialString
					Else
						'UPGRADE_WARNING: Couldn't resolve default property of object strSQL. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
						strSQL = "SELECT task.*, equipment.last_meter_reading, equipment.last_meter_reading_date from equipment inner join task on task.equip_id = equipment.equip_id where work_due_when_meter_reads < last_meter_reading and task.plant_fk = " & intPlantPass
					End If
				Else
					'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
					If strInitialString <> "" Then
						'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
						'UPGRADE_WARNING: Couldn't resolve default property of object strSQL. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
						strSQL = "SELECT task.*, equipment.last_meter_reading, equipment.last_meter_reading_date from equipment inner join task on task.equip_id = equipment.equip_id where work_due_when_meter_reads < last_meter_reading and " & strInitialString
					Else
						'UPGRADE_WARNING: Couldn't resolve default property of object strSQL. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
						strSQL = "SELECT task.*, equipment.last_meter_reading, equipment.last_meter_reading_date from equipment inner join task on task.equip_id = equipment.equip_id where work_due_when_meter_reads < last_meter_reading "
					End If
				End If
			Case "Unscheduled"
				If intRetrievalType = 2 Then
					'UPGRADE_WARNING: Couldn't resolve default property of object strPrintOpt. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
					strPrintOpt = "Unschedule"
					'UPGRADE_WARNING: Couldn't resolve default property of object strPrintDate. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
					strPrintDate = "01/01/1955"
					If strEquipKey <> "" Then
						'UPGRADE_WARNING: Couldn't resolve default property of object strPrintEquipKey. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
						strPrintEquipKey = strEquipKey
					Else
						'UPGRADE_WARNING: Couldn't resolve default property of object strPrintEquipKey. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
						strPrintEquipKey = "XXXXXXXXXXX"
					End If
					If strEquipID <> "" Then
						'UPGRADE_WARNING: Couldn't resolve default property of object intPrintEquip. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
						intPrintEquip = CShort(strEquipID)
					Else
						'UPGRADE_WARNING: Couldn't resolve default property of object intPrintEquip. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
						intPrintEquip = 0
					End If
					If strTaskID <> "" Then
						'UPGRADE_WARNING: Couldn't resolve default property of object intPrintTask. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
						intPrintTask = CShort(strTaskID)
					Else
						'UPGRADE_WARNING: Couldn't resolve default property of object intPrintTask. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
						intPrintTask = 0
					End If
					If strMiscComments <> "" Then
						strPrintMiscComments = strMiscComments
					Else
						strPrintMiscComments = "XXXXXXXXXXX"
					End If
				End If
				If intPlantPass <> 0 Then
					'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
					If strInitialString <> "" Then
						'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
						'UPGRADE_WARNING: Couldn't resolve default property of object strSQL. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
						strSQL = "SELECT task.* from equipment inner join task on task.equip_id = equipment.equip_id where cycle_type = 'Unschedule' and task.plant_fk = " & intPlantPass & " and " & strInitialString
					Else
						'UPGRADE_WARNING: Couldn't resolve default property of object strSQL. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
						strSQL = "SELECT task.* from equipment inner join task on task.equip_id = equipment.equip_id where cycle_type = 'Unschedule' and task.plant_fk = " & intPlantPass
					End If
				Else
					'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
					If strInitialString <> "" Then
						'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
						'UPGRADE_WARNING: Couldn't resolve default property of object strSQL. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
						strSQL = "SELECT task.* from equipment inner join task on task.equip_id = equipment.equip_id where cycle_type = 'Unschedule' and " & strInitialString
					Else
						'UPGRADE_WARNING: Couldn't resolve default property of object strSQL. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
						strSQL = "SELECT task.* from equipment inner join task on task.equip_id = equipment.equip_id where cycle_type = 'Unschedule' "
					End If
				End If
			Case "All"
				If intRetrievalType = 2 Then
					'UPGRADE_WARNING: Couldn't resolve default property of object strPrintOpt. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
					strPrintOpt = "All"
					'UPGRADE_WARNING: Couldn't resolve default property of object strPrintDate. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
					strPrintDate = "01/01/1955"
					If strEquipKey <> "" Then
						'UPGRADE_WARNING: Couldn't resolve default property of object strPrintEquipKey. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
						strPrintEquipKey = strEquipKey
					Else
						'UPGRADE_WARNING: Couldn't resolve default property of object strPrintEquipKey. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
						strPrintEquipKey = "XXXXXXXXXXX"
					End If
					If strEquipID <> "" Then
						'UPGRADE_WARNING: Couldn't resolve default property of object intPrintEquip. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
						intPrintEquip = CShort(strEquipID)
					Else
						'UPGRADE_WARNING: Couldn't resolve default property of object intPrintEquip. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
						intPrintEquip = 0
					End If
					If strTaskID <> "" Then
						'UPGRADE_WARNING: Couldn't resolve default property of object intPrintTask. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
						intPrintTask = CShort(strTaskID)
					Else
						'UPGRADE_WARNING: Couldn't resolve default property of object intPrintTask. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
						intPrintTask = 0
					End If
					If strMiscComments <> "" Then
						strPrintMiscComments = strMiscComments
					Else
						strPrintMiscComments = "XXXXXXXXXXX"
					End If
				End If
				'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				If strInitialString <> "" Then
					If intPlantPass <> 0 Then
						'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
						'UPGRADE_WARNING: Couldn't resolve default property of object strSQL. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
						strSQL = "SELECT task.* from equipment inner join task on task.equip_id = equipment.equip_id where task.plant_fk = " & intPlantPass & " and " & strInitialString
					Else
						'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
						'UPGRADE_WARNING: Couldn't resolve default property of object strSQL. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
						strSQL = "SELECT task.* from equipment inner join task on task.equip_id = equipment.equip_id where " & strInitialString
					End If
				Else
					If intPlantPass <> 0 Then
						'UPGRADE_WARNING: Couldn't resolve default property of object strSQL. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
						strSQL = "SELECT * from task where task.plant_fk = " & intPlantPass
					Else
						'UPGRADE_WARNING: Couldn't resolve default property of object strSQL. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
						strSQL = "SELECT * from task where plant_fk <> 0"
					End If
				End If
		End Select
		If intRetrievalType = 1 Then
			' Just checking if there are records
			'UPGRADE_WARNING: Couldn't resolve default property of object strSQL. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			rsCheck = RecordsetTask(strSQL)
			If rsCheck.EOF = True Or rsCheck.BOF = True Then
				FindRecords = 0
				'UPGRADE_NOTE: Object rsCheck may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1029"'
				rsCheck = Nothing
				Exit Function
			Else
				rsCheck.MoveFirst()
				rsCheck.MoveLast()
				If rsCheck.RecordCount > 0 Then
					FindRecords = 1
					'UPGRADE_NOTE: Object rsCheck may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1029"'
					rsCheck = Nothing
					Exit Function
				End If
			End If
		Else
			' retrieving records
			' first setting the existing recordset to nothing
			'UPGRADE_NOTE: Object rsTaskRetrieve may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1029"'
			rsTaskRetrieve = Nothing
			'UPGRADE_NOTE: Object rsListEquip may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1029"'
			rsListEquip = Nothing
			'UPGRADE_WARNING: Couldn't resolve default property of object strSQL. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			rsTaskRetrieve = RecordsetTask(strSQL)
			rsTaskRetrieve.MoveLast()
			rsTaskRetrieve.MoveFirst()
			If intPlantPass = 0 Then
				strEquipment = "select plant_fk, equip_id, equip_desc, last_meter_reading, last_meter_reading_date from equipment where equip_id <> 0"
			Else
				strEquipment = "select plant_fk, equip_id, equip_desc, last_meter_reading, last_meter_reading_date from equipment where plant_fk = " & intPlantPass
			End If
			rsListEquip = EquipList(strEquipment)
			cboEquipID.Items.Clear()
			Do While Not rsListEquip.EOF
				cboEquipID.Items.Add(rsListEquip.Fields("equip_id").Value & " - " & rsListEquip.Fields("equip_desc").Value)
				rsListEquip.MoveNext()
			Loop 
			rsListEquip.MoveFirst()
			
			FillFields()
			
			SetGrid()
		End If
		Exit Function
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Task - FindRecords: Description - " & Err.Description)
	End Function
	
	Public Function CheckRecordset() As Short
		
		'
		' this function is used only to find out
		' if there is recordset to work on before
		' opening the form
		'
		Dim strSQL As String
		
		On Error GoTo errorhandler
		
		If strPlantPass = "All Plants" Then
			strSQL = "select * from task where task_id <> 0"
		Else
			strSQL = "select * from task where plant_fk = " & intPlantPass
		End If
		
		rsTaskRetrieve = RecordsetTask(strSQL)
		
		If rsTaskRetrieve.EOF = True Or rsTaskRetrieve.BOF = True Then
			CheckRecordset = 2
			Exit Function
		Else
			CheckRecordset = 1
		End If
		'UPGRADE_NOTE: Object rsTaskRetrieve may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1029"'
		rsTaskRetrieve = Nothing
		Exit Function
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Task - CheckRecordset: Description - " & Err.Description)
	End Function
	
	Public Sub FormView()
		
		On Error GoTo errorhandler
		
		FramGrid.Visible = False
		FramForm.Visible = True
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Task - FormView: Description - " & Err.Description)
	End Sub
	
	Public Sub GridView()
		
		On Error GoTo errorhandler
		
		FramForm.Visible = False
		FramGrid.Visible = True
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Task - GridView: Description - " & Err.Description)
	End Sub
	
	'UPGRADE_NOTE: Add was upgraded to Add_Renamed. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1061"'
	Public Sub Add_Renamed()
		
		'
		' intStatus  = 2 is set so that in AddUpdateTask function
		' this variable is used to find out if the record is a add
		' or update
		'
		
		On Error GoTo errorhandler
		
		Clear()
		intStatus = 2
		txtCount.Text = "New Record"
		FormView()
		MDIFormWOS.DefInstance.AddMode()
		If intTypeTask <> 1 Then
			intTypeTask = 2
			Me.cboEquipID.Focus()
		End If
		Me.lblPlantName.Text = intPlantPass & " - " & strPlantPass
		Me.lblPlantNameG.Text = intPlantPass & " - " & strPlantPass
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Task - Add: Description - " & Err.Description)
	End Sub
	
	Public Sub Cancel()
		
		On Error GoTo errorhandler
		
		'
		' Unload and reload
		'
		Me.Close()
		frmPlant.DefInstance.CheckAll("task")
		'frmTask.Show
		'If CheckRecordset = 2 Then
		'    MDIFormWOS.AddMode
		'End If
		'frmTask.SetFocus
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Task - Cancel: Description - " & Err.Description)
	End Sub
	
	Public Sub Clear()
		
		'
		' Check if any field has been modified and if changed then save
		' otherwise clear all the fields on the form
		'
		
		On Error GoTo errorhandler
		
		If intTypeTask <> 1 Then
			ChangedData()
		End If
		cboEquipID.Text = ""
		txtTaskDesc.Text = ""
		cboPriority.Text = ""
		cboCycleType.Text = ""
		txtIntervalDays.Text = ""
		txtLastWorkedDate.CtlText = ""
		txtIntervalMeter.Text = ""
		txtLastWorkedMeterReading.Text = ""
		txtToolsRequired.Text = ""
		txtCreatedby.Text = ""
		txtMiscComments.Text = ""
		txtLoTo.Text = ""
		txtWorkDueWhenMeterReads.Text = ""
		txtWorkDueDate.CtlText = ""
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Task - Clear: Description - " & Err.Description)
	End Sub
	
	'Public Sub Delete()
	'    ans = 0
	'    FormView
	'    ans = MsgBox("Are you sure that you want to delete this record?", vbYesNo, "WOS")
	'    If ans = 6 Then
	'        rsTaskRetrieve.Delete
	'        rsTaskRetrieve.MoveNext
	'        If rsTaskRetrieve.EOF Then
	'            rsTaskRetrieve.MovePrevious
	'        End If
	'        FillFields
	'    End If
	'End Sub
	
	Public Sub RefreshRec()
		
		'
		' Unload and reload
		'
		
		On Error GoTo errorhandler
		
		Me.Close()
		frmPlant.DefInstance.CheckAll("task")
		'frmTask.Show
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Task - RefreshRec: Description - " & Err.Description)
	End Sub
	
	Public Sub Save()
		
		' when one clicks add only the fields are cleared
		' but there may not be a recordset to add to
		' so if there is no recordset then new recordset is created
		' Once there is a recordset then AddUpdateTask is called to add the record
		'
		
		Dim strSQL As String
		Dim strAdd As String
		Dim rsUpdate As ADODB.Recordset
		
		Dim intResult As Short
		
		On Error GoTo errorhandler
		
		FormView()
		intResult = ValidateTask
		Dim intPlant As Short
		If intResult = 0 Then
			If intTypeTask = 1 Then
				strAdd = "SELECT * from task where plant_fk <> 0"
				rsTaskRetrieve = RecordsetTask(strAdd)
				rsTaskRetrieve.AddNew()
				intTypeTask = 0
			ElseIf intTypeTask = 2 Then 
				rsTaskRetrieve.AddNew()
				intTypeTask = 0
			End If
			AddUpdateTask()
			If intUpdate = 1 Then
				rsListEquip.MoveFirst()
				rsListEquip.Find(("equip_id = " & intUpdateEquipID))
				intPlant = rsListEquip.Fields("plant_fk").Value
				strSQL = "Update work_order set plant_fk = " & Str(intPlant) & " and equip_id = " & Str(intUpdateEquipID) & " where task_id = " & rsTaskRetrieve.Fields("task_id").Value
				rsUpdate = RecordsetTask(strSQL)
				'UPGRADE_NOTE: Object rsUpdate may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1029"'
				rsUpdate = Nothing
			End If
			If intStatus = 2 Then
				Cancel()
			End If
			intStatus = 0
			'MDIFormWOS.cmdAdd.Enabled = True
		End If
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Task - Save: Description - " & Err.Description)
	End Sub
	
	Public Sub AddUpdateTask()
		Dim intPos As Short
		Dim strNum As String
		Dim intNum As Short
		Dim intLen As Short
		Dim strEquipID As String
		
		Dim intPlant As Short
		
		Dim dtLastWorked As Object
		Dim dtDueDate As Date
		Dim strDueDate As String
		Dim intIntervalDays As Short
		
		On Error GoTo errorhandler
		
		If intStatus = 2 Then
			'rsTaskRetrieve.AddNew
		Else
			rsTaskRetrieve.Update()
		End If
		
		strEquipID = cboEquipID.Text
		strEquipID = Trim(strEquipID)
		intLen = Len(strEquipID)
		intPos = InStr(strEquipID, " - ")
		
		If intPos = 0 Then
			strNum = strEquipID
		Else
			strNum = VB.Left(strEquipID, intPos - 1)
		End If
		
		'intNum = CInt(strNum)
		
		
		rsTaskRetrieve.Fields("equip_id").Value = strNum
		
		rsListEquip.Find(("equip_id = " & rsTaskRetrieve.Fields("equip_id").Value))
		intPlant = rsListEquip.Fields("plant_fk").Value
		rsTaskRetrieve.Fields("plant_fk").Value = intPlant
		
		rsTaskRetrieve.Fields("task_desc").Value = txtTaskDesc.Text
		rsTaskRetrieve.Fields("priority").Value = cboPriority.Text
		rsTaskRetrieve.Fields("cycle_type").Value = cboCycleType.Text
		If txtIntervalDays.Text <> "" Then
			rsTaskRetrieve.Fields("interval_days").Value = txtIntervalDays.Text
		Else
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			rsTaskRetrieve.Fields("interval_days").Value = System.DBNull.Value
		End If
		If txtLastWorkedDate.CtlText <> "" Then
			rsTaskRetrieve.Fields("last_worked_date").Value = txtLastWorkedDate.CtlText
		Else
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			rsTaskRetrieve.Fields("last_worked_date").Value = System.DBNull.Value
		End If
		If txtIntervalMeter.Text <> "" Then
			rsTaskRetrieve.Fields("interval_meter").Value = txtIntervalMeter.Text
		Else
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			rsTaskRetrieve.Fields("interval_meter").Value = System.DBNull.Value
		End If
		If txtLastWorkedMeterReading.Text <> "" Then
			rsTaskRetrieve.Fields("last_worked_meter_reading").Value = txtLastWorkedMeterReading.Text
		Else
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			rsTaskRetrieve.Fields("last_worked_meter_reading").Value = System.DBNull.Value
		End If
		rsTaskRetrieve.Fields("tools_required").Value = txtToolsRequired.Text
		If txtLastWorkedMeterReading.Text <> "" Then
			rsTaskRetrieve.Fields("last_worked_meter_reading").Value = txtLastWorkedMeterReading.Text
		Else
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			rsTaskRetrieve.Fields("last_worked_meter_reading").Value = System.DBNull.Value
		End If
		If txtLastWorkedDate.CtlText <> "" Then
			rsTaskRetrieve.Fields("last_worked_date").Value = txtLastWorkedDate.CtlText
		Else
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			rsTaskRetrieve.Fields("last_worked_date").Value = System.DBNull.Value
		End If
		rsTaskRetrieve.Fields("misc_comments").Value = txtMiscComments.Text
		rsTaskRetrieve.Fields("lo_to").Value = txtLoTo.Text
		rsTaskRetrieve.Fields("created_by").Value = txtCreatedby.Text
		
		Select Case cboCycleType.Text
			Case "Days Cycle"
				'UPGRADE_WARNING: Couldn't resolve default property of object dtLastWorked. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				dtLastWorked = VB6.Format(txtLastWorkedDate.CtlText, "mm/dd/yy")
				intIntervalDays = CShort(txtIntervalDays.Text)
				'UPGRADE_WARNING: Couldn't resolve default property of object dtLastWorked. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				dtDueDate = DateAdd(Microsoft.VisualBasic.DateInterval.Day, intIntervalDays, dtLastWorked)
				txtWorkDueDate.CtlText = dtDueDate
			Case "Meter Cycle"
				txtWorkDueWhenMeterReads.Text = CStr(CInt(txtIntervalMeter.Text) + CInt(txtLastWorkedMeterReading.Text))
			Case "Unschedule"
				Me.txtWorkDueDate.CtlText = ""
				Me.txtWorkDueWhenMeterReads.Text = ""
		End Select
		
		If txtWorkDueWhenMeterReads.Text <> "" Then
			rsTaskRetrieve.Fields("work_due_when_meter_reads").Value = Me.txtWorkDueWhenMeterReads.Text
		Else
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			rsTaskRetrieve.Fields("work_due_when_meter_reads").Value = System.DBNull.Value
		End If
		If txtWorkDueDate.CtlText <> "" Then
			rsTaskRetrieve.Fields("work_due_date").Value = Me.txtWorkDueDate.defaultText
		Else
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			rsTaskRetrieve.Fields("work_due_date").Value = System.DBNull.Value
		End If
		
		
		rsTaskRetrieve.MoveNext()
		rsTaskRetrieve.MovePrevious()
		
		If intStatus = 2 Then
			ans = MsgBox("New Work Order: " & txtTaskDesc.Text & " has been added.", MsgBoxStyle.OKOnly, "WOS")
		Else
			ans = MsgBox("The record has been updated.", MsgBoxStyle.OKOnly, "WOS")
		End If
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Task - AddUpdateTask: Description - " & Err.Description)
	End Sub
	
	Private Sub cboCycleType_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboCycleType.Enter
		
		On Error GoTo errorhandler
		
		'UPGRADE_WARNING: Couldn't resolve default property of object strCycleTypeStore. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		strCycleTypeStore = ""
		'UPGRADE_WARNING: Couldn't resolve default property of object strCycleTypeStore. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		strCycleTypeStore = cboCycleType.Text
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Task - cboCycleType_GotFocus: Description - " & Err.Description)
	End Sub
	
	Private Sub cboCycleType_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles cboCycleType.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim ans As Short
		
		On Error GoTo errorhandler
		
		ans = 0
		ans = MsgBox("Can not edit. Have to select from the list provided.")
		'UPGRADE_WARNING: Couldn't resolve default property of object strCycleTypeStore. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		cboCycleType.Text = strCycleTypeStore
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Task - cboCycleType_KeyDown: Description - " & Err.Description)
	End Sub
	
	Private Sub cboCycleType_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboCycleType.Leave
		
		On Error GoTo errorhandler
		
		'UPGRADE_WARNING: Couldn't resolve default property of object strCycleTypeStore. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		strCycleTypeStore = ""
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Task - cboCycleType_LostFocus: Description - " & Err.Description)
	End Sub
	
	Private Sub cboCycleType_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles cboCycleType.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		Dim intLen As Short
		Dim ans As Short
		
		Dim dtLastWorkedDate As Object
		Dim dtDueDate As Date
		Dim intIntervalDays As Integer 'Integer
		
		On Error GoTo errorhandler
		
		intLen = Len(cboCycleType.Text)
		If intLen = 0 Then
			Beep()
			ans = MsgBox("The CYCLE TYPE field is a required field.", MsgBoxStyle.OKOnly, "WOS")
			Cancel = True
		End If
		
		'UPGRADE_WARNING: Couldn't resolve default property of object strCycleTypeStore. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		If strCycleTypeStore <> cboCycleType.Text Then
			Select Case Trim(cboCycleType.Text)
				Case "Unschedule"
					ans = MsgBox("If you create an unsheduled Work Order, it will not be cycled. Are you sure you want to unschedule this Work Order?", MsgBoxStyle.YesNo)
					If ans = 6 Then
						' continue with the change
					Else
						'UPGRADE_WARNING: Couldn't resolve default property of object strCycleTypeStore. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
						If strCycleTypeStore <> "" Then
							'UPGRADE_WARNING: Couldn't resolve default property of object strCycleTypeStore. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
							cboCycleType.Text = strCycleTypeStore
						Else
							cboCycleType.Text = ""
						End If
						Cancel = True
					End If
				Case "Meter Cycle"
					If (Len(txtIntervalMeter.Text) = 0) Or (Len(txtLastWorkedMeterReading.Text) = 0) Then
						ans = MsgBox("Can not change to METER CYCLE before entering INTERVAL METER and LAST WORKED METER READING.")
						'UPGRADE_WARNING: Couldn't resolve default property of object strCycleTypeStore. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
						cboCycleType.Text = strCycleTypeStore
						Cancel = False
					Else
						'Dim intNum, intLen2, intPos As Integer
						'Dim strNum As String
						'strNum = cboEquipID.Text
						'strNum = Trim(strNum)
						'intPos = InStr(strNum, " - ")
						'If intPos > 0 Then
						'    strNum = Left(strNum, intPos - 1)
						'End If
						'intNum = CInt(strNum)
						
						'rsListEquip.MoveFirst
						'rsListEquip.Find ("equip_id = " & intNum)
						'If rsListEquip!last_meter_reading < 1 Then
						'    MsgBox "Can not create meter cycle for this equipment because there is no current meter for the equipment. Please enter met"
						' ******** Do we let them create meter cycle for the equipment with no meter reading ????
						txtWorkDueWhenMeterReads.Text = CStr(CInt(txtLastWorkedMeterReading.Text) + CInt(txtIntervalMeter.Text))
					End If
				Case "Days Cycle"
					If (Len(txtIntervalDays.Text) = 0) Or (Len(txtLastWorkedDate.CtlText) = 0) Then
						ans = MsgBox("Can not change to DAYS CYCLE before entering INTERVAL DAYS and LAST WORKED DATE.")
						'UPGRADE_WARNING: Couldn't resolve default property of object strCycleTypeStore. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
						cboCycleType.Text = strCycleTypeStore
						Cancel = False
					Else
						
						' get the due date
						' txtworkduedate.Text = txt
						'UPGRADE_WARNING: Couldn't resolve default property of object dtLastWorkedDate. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
						dtLastWorkedDate = txtLastWorkedDate.CtlText
						intIntervalDays = CInt(txtIntervalDays.Text)
						'UPGRADE_WARNING: Couldn't resolve default property of object dtLastWorkedDate. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
						dtDueDate = DateAdd(Microsoft.VisualBasic.DateInterval.Day, intIntervalDays, dtLastWorkedDate)
						Me.txtWorkDueDate.CtlText = VB6.Format(dtDueDate, "mm/dd/yy")
					End If
			End Select
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Task - cboCycleType_Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	'Private Sub cboEquipID_GotFocus()
	'    Dim intLen, intPos As Integer
	'
	'    intEquipIDStore = 0
	'    strEquipIDStore = ""
	'    strEquipIDStore = cboEquipID.Text
	'    If strEquipIDStore <> "" Then
	'        strEquipIDStore = Trim(strEquipIDStore)
	'        intLen = Len(strEquipIDStore)
	'        intPos = InStr(strEquipIDStore, " - ")
	'        If intPos > 0 Then
	'            strEquipIDStore = Left(strEquipIDStore, intPos - 1)
	'        End If
	'        intEquipIDStore = CInt(strEquipIDStore)
	'    End If
	'End Sub
	
	Private Sub cboEquipID_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles cboEquipID.KeyUp
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim intKey As Short
		Dim intValue As Short
		
		On Error GoTo errorhandler
		
		intKey = KeyCode
		If intKey < 48 Or intKey > 57 Then
			MsgBox("This field can only have numbers")
			If intEquipIDStore <> 0 Then
				Me.cboEquipID.Text = CStr(intEquipIDStore)
			End If
		End If
		If intStatus <> 2 Then
			MsgBox("Value can not be changed after a Work Order is created and saved")
			If intEquipIDStore <> 0 Then
				Me.cboEquipID.Text = CStr(intEquipIDStore)
			End If
		End If
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Task - cboEquipID_KeyUp: Description - " & Err.Description)
	End Sub
	
	Private Sub cboEquipID_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboEquipID.Leave
		
		On Error GoTo errorhandler
		
		'UPGRADE_WARNING: Couldn't resolve default property of object strEquipIDStore. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		strEquipIDStore = ""
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Task - cboEquipID_LostFocus: Description - " & Err.Description)
	End Sub
	
	Private Sub cboEquipID_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles cboEquipID.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		Dim intLen2 As Object
		Dim intPos As Short
		Dim intEquipID As Short
		Dim strEquipID As String
		Dim intLen As Short
		Dim ans As Short
		
		On Error GoTo errorhandler
		
		intLen = Len(cboEquipID.Text)
		If intLen = 0 Then
			Beep()
			ans = MsgBox("The EQUIPMENT field is a required field.", MsgBoxStyle.OKOnly, "WOS")
			Cancel = True
		Else
			strEquipID = cboEquipID.Text
			strEquipID = Trim(strEquipID)
			'UPGRADE_WARNING: Couldn't resolve default property of object intLen2. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			intLen2 = Len(strEquipID)
			intPos = InStr(strEquipID, " - ")
			If intPos > 0 Then
				strEquipID = VB.Left(strEquipID, intPos - 1)
			End If
			intEquipID = CShort(strEquipID)
			rsListEquip.MoveFirst()
			rsListEquip.Find(("equip_id = " & intEquipID))
			If rsListEquip.EOF = True Or rsListEquip.BOF = True Then
				MsgBox("The equipment you entered was not found in the dropdown.")
				Cancel = True
				'UPGRADE_WARNING: Couldn't resolve default property of object strEquipIDStore. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				If strEquipIDStore <> "" Then
					'UPGRADE_WARNING: Couldn't resolve default property of object strEquipIDStore. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
					Me.cboEquipID.Text = strEquipIDStore
				Else
					Me.cboEquipID.Text = ""
				End If
			Else
				If intEquipID <> intEquipIDStore And intEquipIDStore <> 0 Then
					If intStatus <> 2 Then
						MsgBox("Value can not be changed after a Work Order is created and saved")
						Me.cboEquipID.Text = CStr(intEquipIDStore)
					End If
					'ans = MsgBox("Are you sure that you want to change equipment. If there are history records for this Work Order, then those recordss will have new equipment assigned.", vbYesNo)
					'If ans = 6 Then
					'    intUpdate = 1
					'    intUpdateEquipID = intEquipID
					'Else
					' do not change the value and go to next control
					'    cboEquipID.Text = strEquipIDStore
					'End If
				End If
			End If
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Task - cboEquipID_Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub cboPriority_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboPriority.Enter
		
		On Error GoTo errorhandler
		
		strPriorityStore = ""
		strPriorityStore = cboPriority.Text
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Task - cboPriority_GotFocus: Description - " & Err.Description)
	End Sub
	
	Private Sub cboPriority_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles cboPriority.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim ans As Short
		
		On Error GoTo errorhandler
		
		ans = 0
		ans = MsgBox("Can not edit. Have to select from the list provided.")
		cboPriority.Text = strPriorityStore
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Task - cboPriority_KeyDown: Description - " & Err.Description)
	End Sub
	
	Private Sub cboPriority_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboPriority.Leave
		strPriorityStore = ""
	End Sub
	
	Private Sub cmdPrintForm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPrintForm.Click
		
		On Error GoTo errorhandler
		'UPGRADE_ISSUE: Form method frmTask.PrintForm was not upgraded. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup2064"'
		PrintForm()
		Exit Sub
errorhandler: 
		MsgBox("Unable to print to this default printer. Please check that you have a default printer set up correctly.", MsgBoxStyle.Exclamation, "Print Form Error")
	End Sub
	
	Private Sub DGridTask_RowColChange(ByVal eventSender As System.Object, ByVal eventArgs As AxMSDataGridLib.DDataGridEvents_RowColChangeEvent) Handles DGridTask.RowColChange
		
		On Error GoTo errorhandler
		
		If FramGrid.Visible = True Then
			FillFields()
		End If
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Task - DGridTask_RowColChange: Description - " & Err.Description)
	End Sub
	
	'UPGRADE_WARNING: Form event frmTask.Activate has a new behavior. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup2065"'
	Private Sub frmTask_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		
		On Error GoTo errorhandler
		'If CheckRecordset = 1 Then
		MDIFormWOS.DefInstance.FindActive((False))
		If intTypeTask = 1 Then
			MDIFormWOS.DefInstance.cmdSearch.Enabled = False
			MDIFormWOS.DefInstance.cmdPrint.Enabled = False
		Else
			MDIFormWOS.DefInstance.cmdSearch.Enabled = True
			MDIFormWOS.DefInstance.cmdPrint.Enabled = True
		End If
		'End If
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Task - Form_Activate: Description - " & Err.Description)
	End Sub
	
	Private Sub frmTask_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Click
		' Do nothing
	End Sub
	
	Public Sub FirstRec()
		
		On Error GoTo errorhandler
		
		ChangedData()
		rsTaskRetrieve.MoveFirst()
		FillFields()
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Task - FirstRec: Description - " & Err.Description)
	End Sub
	
	Public Sub LastRec()
		
		On Error GoTo errorhandler
		
		ChangedData()
		rsTaskRetrieve.MoveLast()
		FillFields()
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Task - LastRec: Description - " & Err.Description)
	End Sub
	
	Public Sub NextRec()
		
		On Error GoTo errorhandler
		
		ChangedData()
		rsTaskRetrieve.MoveNext()
		If rsTaskRetrieve.EOF Then
			rsTaskRetrieve.MovePrevious()
			ans = MsgBox("Already at the end of the list. Can not move any further.")
		End If
		FillFields()
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Task - NextRec: Description - " & Err.Description)
	End Sub
	
	Public Sub PrevRec()
		
		On Error GoTo errorhandler
		
		ChangedData()
		rsTaskRetrieve.MovePrevious()
		If rsTaskRetrieve.BOF Then
			rsTaskRetrieve.MoveNext()
			ans = MsgBox("Already at the beginning of the list. Can not move back any more.")
		End If
		FillFields()
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Task - PrevRec: Description - " & Err.Description)
	End Sub
	
	Public Function FormLoadType() As Object
		
		Dim ans As Short
		Dim strSQL As Object
		Dim strEquip As String
		Dim strCurType As String
		
		On Error GoTo errorhandler
		
		FormView()
		If CheckRecordset = 2 Then
			intTypeTask = 1
			Add_Renamed()
			If strPlantPass = "All Plants" Then
				strEquip = "select plant_fk,equip_id, equip_desc, last_meter_reading, last_meter_reading_date from equipment where equip_id <> 0"
			Else
				strEquip = "select plant_fk,equip_id, equip_desc, last_meter_reading, last_meter_reading_date from equipment where plant_fk = " & intPlantPass
			End If
			
			rsListEquip = EquipList(strEquip)
			cboEquipID.Items.Clear()
			Do While Not rsListEquip.EOF
				cboEquipID.Items.Add(rsListEquip.Fields("equip_id").Value & " - " & rsListEquip.Fields("equip_desc").Value)
				rsListEquip.MoveNext()
			Loop 
			rsListEquip.MoveFirst()
		Else
			If strPlantPass = "All Plants" Then
				'UPGRADE_WARNING: Couldn't resolve default property of object strSQL. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				strSQL = "select DISTINCT t.task_id, t.plant_fk, t.equip_id, e.equip_desc, t.task_desc, t.priority, t.cycle_type, t.interval_days, t.interval_meter, t.tools_required,t.lo_to,t.last_worked_meter_reading,t.last_worked_date, t.created_by, t.misc_comments, t.work_due_when_meter_reads, t.work_due_date, p.*" & " FROM (plant AS p INNER JOIN task AS t ON p.plant_id=t.plant_fk) INNER JOIN equipment AS e ON p.plant_id=e.plant_fk" & " WHERE e.equip_id=t.equip_id And t.plant_fk <> 0"
				'strSQL = "select distinct t.*, p.* from plant p inner join task t on p.plant_id = t.plant_fk where t.plant_fk <> 0"
				strEquip = "select plant_fk, equip_id, equip_desc, last_meter_reading, last_meter_reading_date from equipment where equip_id <> 0"
			Else
				'UPGRADE_WARNING: Couldn't resolve default property of object strSQL. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				strSQL = "select DISTINCT t.task_id, t.plant_fk, t.equip_id, e.equip_desc, t.task_desc, t.priority, t.cycle_type, t.interval_days, t.interval_meter, t.tools_required,t.lo_to,t.last_worked_meter_reading,t.last_worked_date, t.created_by, t.misc_comments, t.work_due_when_meter_reads, t.work_due_date, p.*" & " FROM (plant AS p INNER JOIN task AS t ON p.plant_id=t.plant_fk) INNER JOIN equipment AS e ON p.plant_id=e.plant_fk" & " WHERE e.equip_id=t.equip_id And t.plant_fk = " & intPlantPass
				'strSQL = "select distinct t.*, p.* from plant p inner join task t on p.plant_id = t.plant_fk where t.plant_fk = " & intPlantPass
				strEquip = "select plant_fk, equip_id, equip_desc, last_meter_reading, last_meter_reading_date from equipment where plant_fk = " & intPlantPass
			End If
			
			'UPGRADE_WARNING: Couldn't resolve default property of object strSQL. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			rsTaskRetrieve = RecordsetTask(strSQL)
			rsListEquip = EquipList(strEquip)
			cboEquipID.Items.Clear()
			Do While Not rsListEquip.EOF
				cboEquipID.Items.Add(rsListEquip.Fields("equip_id").Value & " - " & rsListEquip.Fields("equip_desc").Value)
				rsListEquip.MoveNext()
			Loop 
			rsListEquip.MoveFirst()
			rsTaskRetrieve.MoveLast()
			rsTaskRetrieve.MoveFirst()
			
			FillFields()
			
			SetGrid()
			
			' Following are the values,
			' which will return all the records in the taks table
			'UPGRADE_WARNING: Couldn't resolve default property of object strPrintOpt. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			strPrintOpt = "All"
			'UPGRADE_WARNING: Couldn't resolve default property of object strPrintDate. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			strPrintDate = "01/01/1955"
			'UPGRADE_WARNING: Couldn't resolve default property of object strPrintEquipKey. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			strPrintEquipKey = "XXXXXXXXXXX"
			strPrintMiscComments = "XXXXXXXXXXX"
		End If
		Exit Function
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Task - FromLoadType: Description - " & Err.Description)
	End Function
	
	Private Sub frmTask_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim intKeyValue As Short
		
		On Error GoTo errorhandler
		
		intKeyValue = KeyCode
		
		' F8(value 119) save and move to previous record
		' F9(value 120) save and move to next record
		' F10(value 121) can be used to save then move to the next(new) record
		
		If intKeyValue = 121 Then
			Save()
			intTypeTask = 2
			Add_Renamed()
			intEquipIDStore = 0
			MDIFormWOS.DefInstance.Activate()
			frmTask.DefInstance.Activate()
			frmTask.DefInstance.cboEquipID.Focus()
			MDIFormWOS.DefInstance.AddMode()
		ElseIf intKeyValue = 120 Then 
			Save()
			If intStatus = 2 Then
				intStatus = 1
			End If
			If MDIFormWOS.DefInstance.cmdFirst.Enabled = False Then
				Cancel()
			End If
			If MDIFormWOS.DefInstance.cmdAdd.Enabled = True Then
				NextRec()
			End If
			MDIFormWOS.DefInstance.Activate()
			frmTask.DefInstance.Activate()
			frmTask.DefInstance.cboEquipID.Focus()
			'MDIFormWOS.FindActive (False)
			
		ElseIf intKeyValue = 119 Then 
			Save()
			If intStatus = 2 Then
				intStatus = 1
			End If
			If MDIFormWOS.DefInstance.cmdFirst.Enabled = False Then
				Cancel()
			End If
			If MDIFormWOS.DefInstance.cmdAdd.Enabled = True Then
				PrevRec()
			End If
			MDIFormWOS.DefInstance.Activate()
			frmTask.DefInstance.Activate()
			frmTask.DefInstance.cboEquipID.Focus()
			'MDIFormWOS.FindActive (False)
		End If
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Task - Form_KeyUp: Description - " & Err.Description)
	End Sub
	
	Private Sub frmTask_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
		On Error GoTo errorhandler
		intStatus = 0
		Me.Height = VB6.TwipsToPixelsY(7000)
		Me.Width = VB6.TwipsToPixelsX(9300)
		Me.Left = 0
		Me.Top = 0
		FormLoadType()
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Task - Form_Load: Description - " & Err.Description)
	End Sub
	
	Public Sub SetGrid()
		Dim intGridWidth As Short
		Dim col4, col2, col1, col3, col5 As Object
		Dim col6 As MSDataGridLib.Column
		
		On Error GoTo errorhandler
		
		DGridTask.DataSource = rsTaskRetrieve
		
		col1 = DGridTask.Columns(0)
		col2 = DGridTask.Columns(1)
		col3 = DGridTask.Columns(2)
		col4 = DGridTask.Columns(3)
		col5 = DGridTask.Columns(4)
		col6 = DGridTask.Columns(5)
		
		'UPGRADE_WARNING: Couldn't resolve default property of object col1.Caption. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		col1.Caption = "ID"
		'UPGRADE_WARNING: Couldn't resolve default property of object col2.Caption. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		col2.Caption = "PLANT"
		'UPGRADE_WARNING: Couldn't resolve default property of object col3.Caption. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		col3.Caption = "EQUIP"
		'UPGRADE_WARNING: Couldn't resolve default property of object col4.Caption. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		col4.Caption = "EQUIP DESC"
		'UPGRADE_WARNING: Couldn't resolve default property of object col5.Caption. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		col5.Caption = "WORK ORDER DESC"
		col6.Caption = "PRIORITY"
		
		intGridWidth = VB6.PixelsToTwipsX(DGridTask.Width)
		
		'UPGRADE_WARNING: Couldn't resolve default property of object col1.Width. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		col1.Width = (5 / 81) * intGridWidth
		'UPGRADE_WARNING: Couldn't resolve default property of object col2.Width. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		col2.Width = (5 / 81) * intGridWidth
		'UPGRADE_WARNING: Couldn't resolve default property of object col3.Width. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		col3.Width = (5 / 81) * intGridWidth
		'UPGRADE_WARNING: Couldn't resolve default property of object col4.Width. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		col4.Width = (28 / 81) * intGridWidth
		'UPGRADE_WARNING: Couldn't resolve default property of object col5.Width. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		col5.Width = (28 / 81) * intGridWidth
		col6.Width = VB6.TwipsToPixelsX((8 / 81) * intGridWidth)
		'col1.Locked = True
		'col2.Locked = True
		'col3.Locked = True
		'col4.Locked = True
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Task - SetGrid: Description - " & Err.Description)
	End Sub
	
	Private Sub KeepCount()
		
		On Error GoTo errorhandler
		
		Me.txtCount.Text = "Record No. " & rsTaskRetrieve.AbsolutePosition & " of " & rsTaskRetrieve.RecordCount & " Records"
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Task - KeepCount: Description - " & Err.Description)
	End Sub
	
	Private Sub FillFields()
		Dim intCount As Short
		
		On Error GoTo errorhandler
		
		If rsTaskRetrieve.EOF = True Or rsTaskRetrieve.BOF = True Then
			intCount = rsTaskRetrieve.RecordCount
			If intCount = 0 Then
				MsgBox("There are no more Work Order for this plant in the database.")
				Me.Close()
			End If
		Else
			Me.lblPlantName.Text = intPlantPass & " - " & strPlantPass
			Me.lblPlantNameG.Text = intPlantPass & " - " & strPlantPass
			
			cboEquipID.Text = rsTaskRetrieve.Fields("equip_id").Value
			intEquipIDStore = rsTaskRetrieve.Fields("equip_id").Value
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsTaskRetrieve.Fields("task_desc").Value) Then
				txtTaskDesc.Text = ""
			Else
				txtTaskDesc.Text = rsTaskRetrieve.Fields("task_desc").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsTaskRetrieve.Fields("priority").Value) Then
				cboPriority.Text = ""
			Else
				cboPriority.Text = rsTaskRetrieve.Fields("priority").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsTaskRetrieve.Fields("cycle_type").Value) Then
				cboCycleType.Text = ""
			Else
				cboCycleType.Text = rsTaskRetrieve.Fields("cycle_type").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsTaskRetrieve.Fields("interval_days").Value) Then
				txtIntervalDays.Text = ""
			Else
				txtIntervalDays.Text = rsTaskRetrieve.Fields("interval_days").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsTaskRetrieve.Fields("last_worked_date").Value) Then
				txtLastWorkedDate.CtlText = ""
			Else
				txtLastWorkedDate.CtlText = rsTaskRetrieve.Fields("last_worked_date").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsTaskRetrieve.Fields("interval_meter").Value) Then
				txtIntervalMeter.Text = ""
			Else
				txtIntervalMeter.Text = rsTaskRetrieve.Fields("interval_meter").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsTaskRetrieve.Fields("last_worked_meter_reading").Value) Then
				txtLastWorkedMeterReading.Text = ""
			Else
				txtLastWorkedMeterReading.Text = rsTaskRetrieve.Fields("last_worked_meter_reading").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsTaskRetrieve.Fields("tools_required").Value) Then
				txtToolsRequired.Text = ""
			Else
				txtToolsRequired.Text = rsTaskRetrieve.Fields("tools_required").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsTaskRetrieve.Fields("created_by").Value) Then
				txtCreatedby.Text = ""
			Else
				txtCreatedby.Text = rsTaskRetrieve.Fields("created_by").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsTaskRetrieve.Fields("misc_comments").Value) Then
				txtMiscComments.Text = ""
			Else
				txtMiscComments.Text = rsTaskRetrieve.Fields("misc_comments").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsTaskRetrieve.Fields("lo_to").Value) Then
				txtLoTo.Text = ""
			Else
				txtLoTo.Text = rsTaskRetrieve.Fields("lo_to").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsTaskRetrieve.Fields("work_due_when_meter_reads").Value) Then
				txtWorkDueWhenMeterReads.Text = ""
			Else
				txtWorkDueWhenMeterReads.Text = rsTaskRetrieve.Fields("work_due_when_meter_reads").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsTaskRetrieve.Fields("work_due_date").Value) Then
				txtWorkDueDate.CtlText = ""
			Else
				txtWorkDueDate.CtlText = rsTaskRetrieve.Fields("work_due_date").Value
			End If
			KeepCount()
		End If
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Task - FillFields: Description - " & Err.Description)
	End Sub
	
	Public Sub ChangedData()
		Dim intChangedCount As Short
		Dim strEquipID As Object
		Dim strNum As String
		Dim intLen As Short
		Dim intPos As Short
		
		On Error GoTo errorhandler
		
		intChangedCount = 0
		ans = 0
		
		'UPGRADE_WARNING: Couldn't resolve default property of object strEquipID. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		strEquipID = cboEquipID.Text
		'UPGRADE_WARNING: Couldn't resolve default property of object strEquipID. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		strEquipID = Trim(strEquipID)
		intLen = Len(strEquipID)
		'UPGRADE_WARNING: Couldn't resolve default property of object strEquipID. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		intPos = InStr(strEquipID, " - ")
		
		If intPos = 0 Then
			'UPGRADE_WARNING: Couldn't resolve default property of object strEquipID. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			strNum = strEquipID
		Else
			'UPGRADE_WARNING: Couldn't resolve default property of object strEquipID. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			strNum = VB.Left(strEquipID, intPos - 1)
		End If
		
		If rsTaskRetrieve.Fields("equip_id").Value <> CInt(strNum) Then
			intChangedCount = intChangedCount + 1
		End If
		If rsTaskRetrieve.Fields("task_desc").Value <> Me.txtTaskDesc.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsTaskRetrieve.Fields("priority").Value <> Me.cboPriority.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsTaskRetrieve.Fields("cycle_type").Value <> Me.cboCycleType.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsTaskRetrieve.Fields("interval_days").Value <> Me.txtIntervalDays.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsTaskRetrieve.Fields("interval_meter").Value <> Me.txtIntervalMeter.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsTaskRetrieve.Fields("tools_required").Value <> Me.txtToolsRequired.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsTaskRetrieve.Fields("last_worked_meter_reading").Value <> Me.txtLastWorkedMeterReading.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsTaskRetrieve.Fields("last_worked_date").Value <> Me.txtLastWorkedDate.CtlText Then
			intChangedCount = intChangedCount + 1
		End If
		If rsTaskRetrieve.Fields("lo_to").Value <> Me.txtLoTo.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsTaskRetrieve.Fields("misc_comments").Value <> Me.txtMiscComments.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsTaskRetrieve.Fields("created_by").Value <> Me.txtCreatedby.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsTaskRetrieve.Fields("work_due_when_meter_reads").Value <> Me.txtWorkDueWhenMeterReads.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsTaskRetrieve.Fields("work_due_date").Value <> Me.txtWorkDueDate.CtlText Then
			intChangedCount = intChangedCount + 1
		End If
		If intChangedCount > 0 Then
			ans = MsgBox("Do you want to save the changed data?", MsgBoxStyle.YesNo, "WOS")
			If ans = 6 Then
				Save()
			End If
		End If
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Task - ChangedData: Description - " & Err.Description)
	End Sub
	
	'UPGRADE_WARNING: Form event frmTask.Unload has a new behavior. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup2065"'
	Private Sub frmTask_Closed(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Closed
		
		On Error GoTo errorhandler
		
		'UPGRADE_NOTE: Object rsTaskRetrieve may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1029"'
		rsTaskRetrieve = Nothing
		'UPGRADE_NOTE: Object rsListEquip may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1029"'
		rsListEquip = Nothing
		intTypeTask = 0
		MDIFormWOS.DefInstance.FindActive((True))
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Task - Form_Unload: Description - " & Err.Description)
	End Sub
	
	Private Sub txtIntervalDays_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtIntervalDays.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		On Error GoTo errorhandler
		
		If IsNumeric(txtIntervalDays.Text) = False And txtIntervalDays.Text <> "" Then
			MsgBox("Incorrect Format. Please Re-enter.")
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Task - txtIntervalDays_Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub txtIntervalMeter_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtIntervalMeter.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		On Error GoTo errorhandler
		
		If IsNumeric(txtIntervalMeter.Text) = False And txtIntervalMeter.Text <> "" Then
			MsgBox("Incorrect Format. Please Re-enter.")
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Task - txtIntervalMeter_Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub txtLastWorkedDate_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtLastWorkedDate.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		On Error GoTo errorhandler
		
		If IsDate(txtLastWorkedDate.CtlText) = False And txtLastWorkedDate.CtlText <> "" Then
			MsgBox("Incorrect Format. Please Re-enter.")
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Task - txtLastWorkedDate_Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub txtLastWorkedMeterReading_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtLastWorkedMeterReading.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		On Error GoTo errorhandler
		
		If IsNumeric(txtLastWorkedMeterReading.Text) = False And txtLastWorkedMeterReading.Text <> "" Then
			MsgBox("Incorrect Format. Please Re-enter.")
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Task - txtLastWorkedMeterReading_Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub txtTaskDesc_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtTaskDesc.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		Dim intLen As Short
		Dim ans As Short
		
		On Error GoTo errorhandler
		
		intLen = Len(txtTaskDesc.Text)
		If intLen = 0 Then
			Beep()
			ans = MsgBox("The WORK ORDER DESCRIPTION field is a required field.", MsgBoxStyle.OKOnly, "WOS")
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Task - txtTaskDesc_Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
End Class