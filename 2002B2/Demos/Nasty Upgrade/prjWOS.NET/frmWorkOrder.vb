Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmWorkOrder
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
	Public WithEvents txtComments As System.Windows.Forms.TextBox
	Public WithEvents txtMaterialsCost As System.Windows.Forms.TextBox
	Public WithEvents cboTaskID As System.Windows.Forms.ComboBox
	Public WithEvents cboEquipID As System.Windows.Forms.ComboBox
	Public WithEvents txtCount As System.Windows.Forms.TextBox
	Public WithEvents txtLabor As System.Windows.Forms.TextBox
	Public WithEvents txtCompletedBy As System.Windows.Forms.TextBox
	Public WithEvents txtMeterReadingAtCompletion As System.Windows.Forms.TextBox
	Public WithEvents txtDateCompleted As AxMSMask.AxMaskEdBox
	Public WithEvents lblMechIDD As System.Windows.Forms.Label
	Public WithEvents lblMechModelD As System.Windows.Forms.Label
	Public WithEvents lblMechFrameD As System.Windows.Forms.Label
	Public WithEvents lblMechRecomSparePartsD As System.Windows.Forms.Label
	Public WithEvents lblMechMiscNPDataD As System.Windows.Forms.Label
	Public WithEvents lblMechNoValvesTypesD As System.Windows.Forms.Label
	Public WithEvents lblMechPipeTypeD As System.Windows.Forms.Label
	Public WithEvents lblMechPipeSizeD As System.Windows.Forms.Label
	Public WithEvents lblMechBelt2D As System.Windows.Forms.Label
	Public WithEvents lblMechBelt1D As System.Windows.Forms.Label
	Public WithEvents lblMechAirFilterD As System.Windows.Forms.Label
	Public WithEvents lblMechOilFilterD As System.Windows.Forms.Label
	Public WithEvents lblMechOilD As System.Windows.Forms.Label
	Public WithEvents lblMechCfmD As System.Windows.Forms.Label
	Public WithEvents lblMechMinRpmD As System.Windows.Forms.Label
	Public WithEvents lblMechMaxRpmD As System.Windows.Forms.Label
	Public WithEvents lblMechCatNoD As System.Windows.Forms.Label
	Public WithEvents lblMechTdhD As System.Windows.Forms.Label
	Public WithEvents lblMechSizeD As System.Windows.Forms.Label
	Public WithEvents lblMechCapD As System.Windows.Forms.Label
	Public WithEvents lblMechRpmD As System.Windows.Forms.Label
	Public WithEvents lblMechImpSzD As System.Windows.Forms.Label
	Public WithEvents lblMechSerialD As System.Windows.Forms.Label
	Public WithEvents lblMechRecomSpareParts As System.Windows.Forms.Label
	Public WithEvents lblMechMiscNPData As System.Windows.Forms.Label
	Public WithEvents lblMechNoValvesTypes As System.Windows.Forms.Label
	Public WithEvents lblMechPipeType As System.Windows.Forms.Label
	Public WithEvents lblMechPipeSize As System.Windows.Forms.Label
	Public WithEvents lblMechcfm As System.Windows.Forms.Label
	Public WithEvents lblMechMaxRpm As System.Windows.Forms.Label
	Public WithEvents lblMechMinRpm As System.Windows.Forms.Label
	Public WithEvents lblMechCatNo As System.Windows.Forms.Label
	Public WithEvents lblMechSize As System.Windows.Forms.Label
	Public WithEvents lblMechtdh As System.Windows.Forms.Label
	Public WithEvents lblMechCap As System.Windows.Forms.Label
	Public WithEvents lblMechRpm As System.Windows.Forms.Label
	Public WithEvents lblMechHp As System.Windows.Forms.Label
	Public WithEvents lblMechImpSz As System.Windows.Forms.Label
	Public WithEvents lblMechFrame As System.Windows.Forms.Label
	Public WithEvents lblMechModel As System.Windows.Forms.Label
	Public WithEvents lblMechID As System.Windows.Forms.Label
	Public WithEvents lblMechSerial As System.Windows.Forms.Label
	Public WithEvents lblMechOil As System.Windows.Forms.Label
	Public WithEvents lblMechOilFilter As System.Windows.Forms.Label
	Public WithEvents lblMechAirFilter As System.Windows.Forms.Label
	Public WithEvents lblMechBelt1 As System.Windows.Forms.Label
	Public WithEvents lblMechBelt2 As System.Windows.Forms.Label
	Public WithEvents lblMechHpD As System.Windows.Forms.Label
	Public WithEvents _SSTab1_TabPage0 As System.Windows.Forms.TabPage
	Public WithEvents lblElecMiscNPDataD As System.Windows.Forms.Label
	Public WithEvents lblElecRecomSparePartsD As System.Windows.Forms.Label
	Public WithEvents lblElecOppEndBrgD As System.Windows.Forms.Label
	Public WithEvents lblElecShaftEndBrgD As System.Windows.Forms.Label
	Public WithEvents lblElecDesignD As System.Windows.Forms.Label
	Public WithEvents lblElecInslClD As System.Windows.Forms.Label
	Public WithEvents lblElecAmpD As System.Windows.Forms.Label
	Public WithEvents lblElecVD As System.Windows.Forms.Label
	Public WithEvents lblElecDutyD As System.Windows.Forms.Label
	Public WithEvents lblElecSfD As System.Windows.Forms.Label
	Public WithEvents lblElecPhsD As System.Windows.Forms.Label
	Public WithEvents lblElecHzD As System.Windows.Forms.Label
	Public WithEvents lblElecRpmD As System.Windows.Forms.Label
	Public WithEvents lblElecHpD As System.Windows.Forms.Label
	Public WithEvents lblElecCatNoD As System.Windows.Forms.Label
	Public WithEvents lblElecFrameD As System.Windows.Forms.Label
	Public WithEvents lblElecSerialD As System.Windows.Forms.Label
	Public WithEvents lblElecModelD As System.Windows.Forms.Label
	Public WithEvents lblElecIDD As System.Windows.Forms.Label
	Public WithEvents lblElecRecomSpareParts As System.Windows.Forms.Label
	Public WithEvents lblElecMiscNPData As System.Windows.Forms.Label
	Public WithEvents lblElecOppEndBrg As System.Windows.Forms.Label
	Public WithEvents lblElecShaftEndBrg As System.Windows.Forms.Label
	Public WithEvents lblElecDesign As System.Windows.Forms.Label
	Public WithEvents lblElecInslCl As System.Windows.Forms.Label
	Public WithEvents lblElecDuty As System.Windows.Forms.Label
	Public WithEvents lblElecAmp As System.Windows.Forms.Label
	Public WithEvents lblElecV As System.Windows.Forms.Label
	Public WithEvents lblElecSf As System.Windows.Forms.Label
	Public WithEvents lblElecPhs As System.Windows.Forms.Label
	Public WithEvents lblElecHz As System.Windows.Forms.Label
	Public WithEvents lblElecRpm As System.Windows.Forms.Label
	Public WithEvents lblElecHp As System.Windows.Forms.Label
	Public WithEvents lblElecCatNo As System.Windows.Forms.Label
	Public WithEvents lblElecSerial As System.Windows.Forms.Label
	Public WithEvents lblElecID As System.Windows.Forms.Label
	Public WithEvents lblElecModel As System.Windows.Forms.Label
	Public WithEvents lblElecFrame As System.Windows.Forms.Label
	Public WithEvents _SSTab1_TabPage1 As System.Windows.Forms.TabPage
	Public WithEvents txtTaskMiscCommentsD As System.Windows.Forms.TextBox
	Public WithEvents lblWorkDueDateD As System.Windows.Forms.Label
	Public WithEvents lblWorkDueWhenMeterReadsD As System.Windows.Forms.Label
	Public WithEvents lblWorkDueDate As System.Windows.Forms.Label
	Public WithEvents lblWorkDueWhenMeterReads As System.Windows.Forms.Label
	Public WithEvents lblCreatedbyD As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents lblTaskToolsRequiredD As System.Windows.Forms.Label
	Public WithEvents lblTaskLoToD As System.Windows.Forms.Label
	Public WithEvents lblTaskLastWorkedMeterD As System.Windows.Forms.Label
	Public WithEvents lblTaskLastWorkedDateD As System.Windows.Forms.Label
	Public WithEvents lblTaskIntervalDaysD As System.Windows.Forms.Label
	Public WithEvents lblTaskIntervalMeterD As System.Windows.Forms.Label
	Public WithEvents lblTaskPriorityD As System.Windows.Forms.Label
	Public WithEvents lblTaskCycleTypeD As System.Windows.Forms.Label
	Public WithEvents lblTaskTaskDescD As System.Windows.Forms.Label
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
	Public WithEvents _SSTab1_TabPage2 As System.Windows.Forms.TabPage
	Public WithEvents SSTab1 As System.Windows.Forms.TabControl
	Public WithEvents lblPlantName As System.Windows.Forms.Label
	Public WithEvents lblComments As System.Windows.Forms.Label
	Public WithEvents lblMaterialsCost As System.Windows.Forms.Label
	Public WithEvents lblLaborCost As System.Windows.Forms.Label
	Public WithEvents lblCompletedBy As System.Windows.Forms.Label
	Public WithEvents lblDateCompleted As System.Windows.Forms.Label
	Public WithEvents lblMeterReadingatWorkCompletion As System.Windows.Forms.Label
	Public WithEvents lblTaskID As System.Windows.Forms.Label
	Public WithEvents lblEquipID As System.Windows.Forms.Label
	Public WithEvents FramForm As System.Windows.Forms.GroupBox
	Public WithEvents DGridWO As AxMSDataGridLib.AxDataGrid
	Public WithEvents lblPlantNameG As System.Windows.Forms.Label
	Public WithEvents FramGrid As System.Windows.Forms.GroupBox
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmWorkOrder))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ToolTip1.Active = True
		Me.FramForm = New System.Windows.Forms.GroupBox
		Me.txtComments = New System.Windows.Forms.TextBox
		Me.txtMaterialsCost = New System.Windows.Forms.TextBox
		Me.cboTaskID = New System.Windows.Forms.ComboBox
		Me.cboEquipID = New System.Windows.Forms.ComboBox
		Me.txtCount = New System.Windows.Forms.TextBox
		Me.txtLabor = New System.Windows.Forms.TextBox
		Me.txtCompletedBy = New System.Windows.Forms.TextBox
		Me.txtMeterReadingAtCompletion = New System.Windows.Forms.TextBox
		Me.txtDateCompleted = New AxMSMask.AxMaskEdBox
		Me.SSTab1 = New System.Windows.Forms.TabControl
		Me._SSTab1_TabPage0 = New System.Windows.Forms.TabPage
		Me.lblMechIDD = New System.Windows.Forms.Label
		Me.lblMechModelD = New System.Windows.Forms.Label
		Me.lblMechFrameD = New System.Windows.Forms.Label
		Me.lblMechRecomSparePartsD = New System.Windows.Forms.Label
		Me.lblMechMiscNPDataD = New System.Windows.Forms.Label
		Me.lblMechNoValvesTypesD = New System.Windows.Forms.Label
		Me.lblMechPipeTypeD = New System.Windows.Forms.Label
		Me.lblMechPipeSizeD = New System.Windows.Forms.Label
		Me.lblMechBelt2D = New System.Windows.Forms.Label
		Me.lblMechBelt1D = New System.Windows.Forms.Label
		Me.lblMechAirFilterD = New System.Windows.Forms.Label
		Me.lblMechOilFilterD = New System.Windows.Forms.Label
		Me.lblMechOilD = New System.Windows.Forms.Label
		Me.lblMechCfmD = New System.Windows.Forms.Label
		Me.lblMechMinRpmD = New System.Windows.Forms.Label
		Me.lblMechMaxRpmD = New System.Windows.Forms.Label
		Me.lblMechCatNoD = New System.Windows.Forms.Label
		Me.lblMechTdhD = New System.Windows.Forms.Label
		Me.lblMechSizeD = New System.Windows.Forms.Label
		Me.lblMechCapD = New System.Windows.Forms.Label
		Me.lblMechRpmD = New System.Windows.Forms.Label
		Me.lblMechImpSzD = New System.Windows.Forms.Label
		Me.lblMechSerialD = New System.Windows.Forms.Label
		Me.lblMechRecomSpareParts = New System.Windows.Forms.Label
		Me.lblMechMiscNPData = New System.Windows.Forms.Label
		Me.lblMechNoValvesTypes = New System.Windows.Forms.Label
		Me.lblMechPipeType = New System.Windows.Forms.Label
		Me.lblMechPipeSize = New System.Windows.Forms.Label
		Me.lblMechcfm = New System.Windows.Forms.Label
		Me.lblMechMaxRpm = New System.Windows.Forms.Label
		Me.lblMechMinRpm = New System.Windows.Forms.Label
		Me.lblMechCatNo = New System.Windows.Forms.Label
		Me.lblMechSize = New System.Windows.Forms.Label
		Me.lblMechtdh = New System.Windows.Forms.Label
		Me.lblMechCap = New System.Windows.Forms.Label
		Me.lblMechRpm = New System.Windows.Forms.Label
		Me.lblMechHp = New System.Windows.Forms.Label
		Me.lblMechImpSz = New System.Windows.Forms.Label
		Me.lblMechFrame = New System.Windows.Forms.Label
		Me.lblMechModel = New System.Windows.Forms.Label
		Me.lblMechID = New System.Windows.Forms.Label
		Me.lblMechSerial = New System.Windows.Forms.Label
		Me.lblMechOil = New System.Windows.Forms.Label
		Me.lblMechOilFilter = New System.Windows.Forms.Label
		Me.lblMechAirFilter = New System.Windows.Forms.Label
		Me.lblMechBelt1 = New System.Windows.Forms.Label
		Me.lblMechBelt2 = New System.Windows.Forms.Label
		Me.lblMechHpD = New System.Windows.Forms.Label
		Me._SSTab1_TabPage1 = New System.Windows.Forms.TabPage
		Me.lblElecMiscNPDataD = New System.Windows.Forms.Label
		Me.lblElecRecomSparePartsD = New System.Windows.Forms.Label
		Me.lblElecOppEndBrgD = New System.Windows.Forms.Label
		Me.lblElecShaftEndBrgD = New System.Windows.Forms.Label
		Me.lblElecDesignD = New System.Windows.Forms.Label
		Me.lblElecInslClD = New System.Windows.Forms.Label
		Me.lblElecAmpD = New System.Windows.Forms.Label
		Me.lblElecVD = New System.Windows.Forms.Label
		Me.lblElecDutyD = New System.Windows.Forms.Label
		Me.lblElecSfD = New System.Windows.Forms.Label
		Me.lblElecPhsD = New System.Windows.Forms.Label
		Me.lblElecHzD = New System.Windows.Forms.Label
		Me.lblElecRpmD = New System.Windows.Forms.Label
		Me.lblElecHpD = New System.Windows.Forms.Label
		Me.lblElecCatNoD = New System.Windows.Forms.Label
		Me.lblElecFrameD = New System.Windows.Forms.Label
		Me.lblElecSerialD = New System.Windows.Forms.Label
		Me.lblElecModelD = New System.Windows.Forms.Label
		Me.lblElecIDD = New System.Windows.Forms.Label
		Me.lblElecRecomSpareParts = New System.Windows.Forms.Label
		Me.lblElecMiscNPData = New System.Windows.Forms.Label
		Me.lblElecOppEndBrg = New System.Windows.Forms.Label
		Me.lblElecShaftEndBrg = New System.Windows.Forms.Label
		Me.lblElecDesign = New System.Windows.Forms.Label
		Me.lblElecInslCl = New System.Windows.Forms.Label
		Me.lblElecDuty = New System.Windows.Forms.Label
		Me.lblElecAmp = New System.Windows.Forms.Label
		Me.lblElecV = New System.Windows.Forms.Label
		Me.lblElecSf = New System.Windows.Forms.Label
		Me.lblElecPhs = New System.Windows.Forms.Label
		Me.lblElecHz = New System.Windows.Forms.Label
		Me.lblElecRpm = New System.Windows.Forms.Label
		Me.lblElecHp = New System.Windows.Forms.Label
		Me.lblElecCatNo = New System.Windows.Forms.Label
		Me.lblElecSerial = New System.Windows.Forms.Label
		Me.lblElecID = New System.Windows.Forms.Label
		Me.lblElecModel = New System.Windows.Forms.Label
		Me.lblElecFrame = New System.Windows.Forms.Label
		Me._SSTab1_TabPage2 = New System.Windows.Forms.TabPage
		Me.txtTaskMiscCommentsD = New System.Windows.Forms.TextBox
		Me.lblWorkDueDateD = New System.Windows.Forms.Label
		Me.lblWorkDueWhenMeterReadsD = New System.Windows.Forms.Label
		Me.lblWorkDueDate = New System.Windows.Forms.Label
		Me.lblWorkDueWhenMeterReads = New System.Windows.Forms.Label
		Me.lblCreatedbyD = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.lblTaskToolsRequiredD = New System.Windows.Forms.Label
		Me.lblTaskLoToD = New System.Windows.Forms.Label
		Me.lblTaskLastWorkedMeterD = New System.Windows.Forms.Label
		Me.lblTaskLastWorkedDateD = New System.Windows.Forms.Label
		Me.lblTaskIntervalDaysD = New System.Windows.Forms.Label
		Me.lblTaskIntervalMeterD = New System.Windows.Forms.Label
		Me.lblTaskPriorityD = New System.Windows.Forms.Label
		Me.lblTaskCycleTypeD = New System.Windows.Forms.Label
		Me.lblTaskTaskDescD = New System.Windows.Forms.Label
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
		Me.lblPlantName = New System.Windows.Forms.Label
		Me.lblComments = New System.Windows.Forms.Label
		Me.lblMaterialsCost = New System.Windows.Forms.Label
		Me.lblLaborCost = New System.Windows.Forms.Label
		Me.lblCompletedBy = New System.Windows.Forms.Label
		Me.lblDateCompleted = New System.Windows.Forms.Label
		Me.lblMeterReadingatWorkCompletion = New System.Windows.Forms.Label
		Me.lblTaskID = New System.Windows.Forms.Label
		Me.lblEquipID = New System.Windows.Forms.Label
		Me.FramGrid = New System.Windows.Forms.GroupBox
		Me.DGridWO = New AxMSDataGridLib.AxDataGrid
		Me.lblPlantNameG = New System.Windows.Forms.Label
		CType(Me.txtDateCompleted, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.DGridWO, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Text = "History"
		Me.ClientSize = New System.Drawing.Size(706, 566)
		Me.Location = New System.Drawing.Point(4, 23)
		Me.KeyPreview = True
		Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds
		Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
		Me.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
		Me.ControlBox = True
		Me.Enabled = True
		Me.MaximizeBox = True
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.Name = "frmWorkOrder"
		Me.FramForm.Size = New System.Drawing.Size(577, 417)
		Me.FramForm.Location = New System.Drawing.Point(15, 0)
		Me.FramForm.TabIndex = 1
		Me.FramForm.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.FramForm.BackColor = System.Drawing.SystemColors.Control
		Me.FramForm.Enabled = True
		Me.FramForm.ForeColor = System.Drawing.SystemColors.ControlText
		Me.FramForm.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.FramForm.Visible = True
		Me.FramForm.Name = "FramForm"
		Me.txtComments.AutoSize = False
		Me.txtComments.Size = New System.Drawing.Size(441, 51)
		Me.txtComments.Location = New System.Drawing.Point(104, 128)
		Me.txtComments.MultiLine = True
		Me.txtComments.TabIndex = 8
		Me.txtComments.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtComments.AcceptsReturn = True
		Me.txtComments.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtComments.BackColor = System.Drawing.SystemColors.Window
		Me.txtComments.CausesValidation = True
		Me.txtComments.Enabled = True
		Me.txtComments.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtComments.HideSelection = True
		Me.txtComments.ReadOnly = False
		Me.txtComments.Maxlength = 0
		Me.txtComments.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtComments.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtComments.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtComments.TabStop = True
		Me.txtComments.Visible = True
		Me.txtComments.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtComments.Name = "txtComments"
		Me.txtMaterialsCost.AutoSize = False
		Me.txtMaterialsCost.Size = New System.Drawing.Size(57, 19)
		Me.txtMaterialsCost.Location = New System.Drawing.Point(488, 104)
		Me.txtMaterialsCost.TabIndex = 7
		Me.txtMaterialsCost.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtMaterialsCost.AcceptsReturn = True
		Me.txtMaterialsCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtMaterialsCost.BackColor = System.Drawing.SystemColors.Window
		Me.txtMaterialsCost.CausesValidation = True
		Me.txtMaterialsCost.Enabled = True
		Me.txtMaterialsCost.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtMaterialsCost.HideSelection = True
		Me.txtMaterialsCost.ReadOnly = False
		Me.txtMaterialsCost.Maxlength = 0
		Me.txtMaterialsCost.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtMaterialsCost.MultiLine = False
		Me.txtMaterialsCost.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtMaterialsCost.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtMaterialsCost.TabStop = True
		Me.txtMaterialsCost.Visible = True
		Me.txtMaterialsCost.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtMaterialsCost.Name = "txtMaterialsCost"
		Me.cboTaskID.Size = New System.Drawing.Size(441, 21)
		Me.cboTaskID.Location = New System.Drawing.Point(104, 56)
		Me.cboTaskID.TabIndex = 2
		Me.cboTaskID.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cboTaskID.BackColor = System.Drawing.SystemColors.Window
		Me.cboTaskID.CausesValidation = True
		Me.cboTaskID.Enabled = True
		Me.cboTaskID.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cboTaskID.IntegralHeight = True
		Me.cboTaskID.Cursor = System.Windows.Forms.Cursors.Default
		Me.cboTaskID.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cboTaskID.Sorted = False
		Me.cboTaskID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cboTaskID.TabStop = True
		Me.cboTaskID.Visible = True
		Me.cboTaskID.Name = "cboTaskID"
		Me.cboEquipID.Size = New System.Drawing.Size(441, 21)
		Me.cboEquipID.Location = New System.Drawing.Point(104, 32)
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
		Me.txtCount.Size = New System.Drawing.Size(177, 19)
		Me.txtCount.Location = New System.Drawing.Point(192, 0)
		Me.txtCount.ReadOnly = True
		Me.txtCount.TabIndex = 17
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
		Me.txtLabor.AutoSize = False
		Me.txtLabor.Size = New System.Drawing.Size(49, 19)
		Me.txtLabor.Location = New System.Drawing.Point(350, 104)
		Me.txtLabor.TabIndex = 6
		Me.txtLabor.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtLabor.AcceptsReturn = True
		Me.txtLabor.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtLabor.BackColor = System.Drawing.SystemColors.Window
		Me.txtLabor.CausesValidation = True
		Me.txtLabor.Enabled = True
		Me.txtLabor.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtLabor.HideSelection = True
		Me.txtLabor.ReadOnly = False
		Me.txtLabor.Maxlength = 0
		Me.txtLabor.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtLabor.MultiLine = False
		Me.txtLabor.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtLabor.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtLabor.TabStop = True
		Me.txtLabor.Visible = True
		Me.txtLabor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtLabor.Name = "txtLabor"
		Me.txtCompletedBy.AutoSize = False
		Me.txtCompletedBy.Size = New System.Drawing.Size(201, 19)
		Me.txtCompletedBy.Location = New System.Drawing.Point(104, 104)
		Me.txtCompletedBy.TabIndex = 5
		Me.txtCompletedBy.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtCompletedBy.AcceptsReturn = True
		Me.txtCompletedBy.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtCompletedBy.BackColor = System.Drawing.SystemColors.Window
		Me.txtCompletedBy.CausesValidation = True
		Me.txtCompletedBy.Enabled = True
		Me.txtCompletedBy.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtCompletedBy.HideSelection = True
		Me.txtCompletedBy.ReadOnly = False
		Me.txtCompletedBy.Maxlength = 0
		Me.txtCompletedBy.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtCompletedBy.MultiLine = False
		Me.txtCompletedBy.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtCompletedBy.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtCompletedBy.TabStop = True
		Me.txtCompletedBy.Visible = True
		Me.txtCompletedBy.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtCompletedBy.Name = "txtCompletedBy"
		Me.txtMeterReadingAtCompletion.AutoSize = False
		Me.txtMeterReadingAtCompletion.Size = New System.Drawing.Size(73, 19)
		Me.txtMeterReadingAtCompletion.Location = New System.Drawing.Point(472, 80)
		Me.txtMeterReadingAtCompletion.TabIndex = 4
		Me.txtMeterReadingAtCompletion.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtMeterReadingAtCompletion.AcceptsReturn = True
		Me.txtMeterReadingAtCompletion.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtMeterReadingAtCompletion.BackColor = System.Drawing.SystemColors.Window
		Me.txtMeterReadingAtCompletion.CausesValidation = True
		Me.txtMeterReadingAtCompletion.Enabled = True
		Me.txtMeterReadingAtCompletion.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtMeterReadingAtCompletion.HideSelection = True
		Me.txtMeterReadingAtCompletion.ReadOnly = False
		Me.txtMeterReadingAtCompletion.Maxlength = 0
		Me.txtMeterReadingAtCompletion.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtMeterReadingAtCompletion.MultiLine = False
		Me.txtMeterReadingAtCompletion.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtMeterReadingAtCompletion.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtMeterReadingAtCompletion.TabStop = True
		Me.txtMeterReadingAtCompletion.Visible = True
		Me.txtMeterReadingAtCompletion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtMeterReadingAtCompletion.Name = "txtMeterReadingAtCompletion"
		txtDateCompleted.OcxState = CType(resources.GetObject("txtDateCompleted.OcxState"), System.Windows.Forms.AxHost.State)
		Me.txtDateCompleted.Size = New System.Drawing.Size(81, 17)
		Me.txtDateCompleted.Location = New System.Drawing.Point(104, 80)
		Me.txtDateCompleted.TabIndex = 3
		Me.txtDateCompleted.Name = "txtDateCompleted"
		Me.SSTab1.Size = New System.Drawing.Size(547, 209)
		Me.SSTab1.Location = New System.Drawing.Point(16, 192)
		Me.SSTab1.TabIndex = 20
		Me.SSTab1.TabStop = False
		Me.SSTab1.ItemSize = New System.Drawing.Size(42, 18)
		Me.SSTab1.ForeColor = System.Drawing.Color.FromARGB(0, 0, 255)
		Me.SSTab1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.SSTab1.Name = "SSTab1"
		Me._SSTab1_TabPage0.Text = "Mechanical"
		Me.lblMechIDD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechIDD.Size = New System.Drawing.Size(113, 17)
		Me.lblMechIDD.Location = New System.Drawing.Point(216, 24)
		Me.lblMechIDD.TabIndex = 69
		Me.lblMechIDD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblMechIDD.BackColor = System.Drawing.SystemColors.Control
		Me.lblMechIDD.Enabled = True
		Me.lblMechIDD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMechIDD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMechIDD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMechIDD.UseMnemonic = True
		Me.lblMechIDD.Visible = True
		Me.lblMechIDD.AutoSize = False
		Me.lblMechIDD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMechIDD.Name = "lblMechIDD"
		Me.lblMechModelD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechModelD.Size = New System.Drawing.Size(129, 17)
		Me.lblMechModelD.Location = New System.Drawing.Point(384, 24)
		Me.lblMechModelD.TabIndex = 70
		Me.lblMechModelD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblMechModelD.BackColor = System.Drawing.SystemColors.Control
		Me.lblMechModelD.Enabled = True
		Me.lblMechModelD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMechModelD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMechModelD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMechModelD.UseMnemonic = True
		Me.lblMechModelD.Visible = True
		Me.lblMechModelD.AutoSize = False
		Me.lblMechModelD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMechModelD.Name = "lblMechModelD"
		Me.lblMechFrameD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechFrameD.Size = New System.Drawing.Size(65, 17)
		Me.lblMechFrameD.Location = New System.Drawing.Point(72, 40)
		Me.lblMechFrameD.TabIndex = 71
		Me.lblMechFrameD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblMechFrameD.BackColor = System.Drawing.SystemColors.Control
		Me.lblMechFrameD.Enabled = True
		Me.lblMechFrameD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMechFrameD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMechFrameD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMechFrameD.UseMnemonic = True
		Me.lblMechFrameD.Visible = True
		Me.lblMechFrameD.AutoSize = False
		Me.lblMechFrameD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMechFrameD.Name = "lblMechFrameD"
		Me.lblMechRecomSparePartsD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechRecomSparePartsD.Size = New System.Drawing.Size(257, 17)
		Me.lblMechRecomSparePartsD.Location = New System.Drawing.Point(72, 136)
		Me.lblMechRecomSparePartsD.TabIndex = 72
		Me.lblMechRecomSparePartsD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblMechRecomSparePartsD.BackColor = System.Drawing.SystemColors.Control
		Me.lblMechRecomSparePartsD.Enabled = True
		Me.lblMechRecomSparePartsD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMechRecomSparePartsD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMechRecomSparePartsD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMechRecomSparePartsD.UseMnemonic = True
		Me.lblMechRecomSparePartsD.Visible = True
		Me.lblMechRecomSparePartsD.AutoSize = False
		Me.lblMechRecomSparePartsD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMechRecomSparePartsD.Name = "lblMechRecomSparePartsD"
		Me.lblMechMiscNPDataD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechMiscNPDataD.Size = New System.Drawing.Size(465, 33)
		Me.lblMechMiscNPDataD.Location = New System.Drawing.Point(72, 152)
		Me.lblMechMiscNPDataD.TabIndex = 73
		Me.lblMechMiscNPDataD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblMechMiscNPDataD.BackColor = System.Drawing.SystemColors.Control
		Me.lblMechMiscNPDataD.Enabled = True
		Me.lblMechMiscNPDataD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMechMiscNPDataD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMechMiscNPDataD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMechMiscNPDataD.UseMnemonic = True
		Me.lblMechMiscNPDataD.Visible = True
		Me.lblMechMiscNPDataD.AutoSize = False
		Me.lblMechMiscNPDataD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMechMiscNPDataD.Name = "lblMechMiscNPDataD"
		Me.lblMechNoValvesTypesD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechNoValvesTypesD.Size = New System.Drawing.Size(257, 17)
		Me.lblMechNoValvesTypesD.Location = New System.Drawing.Point(128, 184)
		Me.lblMechNoValvesTypesD.TabIndex = 74
		Me.lblMechNoValvesTypesD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblMechNoValvesTypesD.BackColor = System.Drawing.SystemColors.Control
		Me.lblMechNoValvesTypesD.Enabled = True
		Me.lblMechNoValvesTypesD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMechNoValvesTypesD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMechNoValvesTypesD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMechNoValvesTypesD.UseMnemonic = True
		Me.lblMechNoValvesTypesD.Visible = True
		Me.lblMechNoValvesTypesD.AutoSize = False
		Me.lblMechNoValvesTypesD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMechNoValvesTypesD.Name = "lblMechNoValvesTypesD"
		Me.lblMechPipeTypeD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechPipeTypeD.Size = New System.Drawing.Size(176, 17)
		Me.lblMechPipeTypeD.Location = New System.Drawing.Point(368, 120)
		Me.lblMechPipeTypeD.TabIndex = 75
		Me.lblMechPipeTypeD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblMechPipeTypeD.BackColor = System.Drawing.SystemColors.Control
		Me.lblMechPipeTypeD.Enabled = True
		Me.lblMechPipeTypeD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMechPipeTypeD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMechPipeTypeD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMechPipeTypeD.UseMnemonic = True
		Me.lblMechPipeTypeD.Visible = True
		Me.lblMechPipeTypeD.AutoSize = False
		Me.lblMechPipeTypeD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMechPipeTypeD.Name = "lblMechPipeTypeD"
		Me.lblMechPipeSizeD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechPipeSizeD.Size = New System.Drawing.Size(257, 17)
		Me.lblMechPipeSizeD.Location = New System.Drawing.Point(72, 120)
		Me.lblMechPipeSizeD.TabIndex = 76
		Me.lblMechPipeSizeD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblMechPipeSizeD.BackColor = System.Drawing.SystemColors.Control
		Me.lblMechPipeSizeD.Enabled = True
		Me.lblMechPipeSizeD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMechPipeSizeD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMechPipeSizeD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMechPipeSizeD.UseMnemonic = True
		Me.lblMechPipeSizeD.Visible = True
		Me.lblMechPipeSizeD.AutoSize = False
		Me.lblMechPipeSizeD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMechPipeSizeD.Name = "lblMechPipeSizeD"
		Me.lblMechBelt2D.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechBelt2D.Size = New System.Drawing.Size(177, 17)
		Me.lblMechBelt2D.Location = New System.Drawing.Point(288, 104)
		Me.lblMechBelt2D.TabIndex = 77
		Me.lblMechBelt2D.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblMechBelt2D.BackColor = System.Drawing.SystemColors.Control
		Me.lblMechBelt2D.Enabled = True
		Me.lblMechBelt2D.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMechBelt2D.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMechBelt2D.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMechBelt2D.UseMnemonic = True
		Me.lblMechBelt2D.Visible = True
		Me.lblMechBelt2D.AutoSize = False
		Me.lblMechBelt2D.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMechBelt2D.Name = "lblMechBelt2D"
		Me.lblMechBelt1D.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechBelt1D.Size = New System.Drawing.Size(177, 17)
		Me.lblMechBelt1D.Location = New System.Drawing.Point(72, 104)
		Me.lblMechBelt1D.TabIndex = 78
		Me.lblMechBelt1D.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblMechBelt1D.BackColor = System.Drawing.SystemColors.Control
		Me.lblMechBelt1D.Enabled = True
		Me.lblMechBelt1D.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMechBelt1D.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMechBelt1D.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMechBelt1D.UseMnemonic = True
		Me.lblMechBelt1D.Visible = True
		Me.lblMechBelt1D.AutoSize = False
		Me.lblMechBelt1D.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMechBelt1D.Name = "lblMechBelt1D"
		Me.lblMechAirFilterD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechAirFilterD.Size = New System.Drawing.Size(177, 17)
		Me.lblMechAirFilterD.Location = New System.Drawing.Point(288, 88)
		Me.lblMechAirFilterD.TabIndex = 79
		Me.lblMechAirFilterD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblMechAirFilterD.BackColor = System.Drawing.SystemColors.Control
		Me.lblMechAirFilterD.Enabled = True
		Me.lblMechAirFilterD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMechAirFilterD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMechAirFilterD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMechAirFilterD.UseMnemonic = True
		Me.lblMechAirFilterD.Visible = True
		Me.lblMechAirFilterD.AutoSize = False
		Me.lblMechAirFilterD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMechAirFilterD.Name = "lblMechAirFilterD"
		Me.lblMechOilFilterD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechOilFilterD.Size = New System.Drawing.Size(177, 17)
		Me.lblMechOilFilterD.Location = New System.Drawing.Point(72, 88)
		Me.lblMechOilFilterD.TabIndex = 80
		Me.lblMechOilFilterD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblMechOilFilterD.BackColor = System.Drawing.SystemColors.Control
		Me.lblMechOilFilterD.Enabled = True
		Me.lblMechOilFilterD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMechOilFilterD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMechOilFilterD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMechOilFilterD.UseMnemonic = True
		Me.lblMechOilFilterD.Visible = True
		Me.lblMechOilFilterD.AutoSize = False
		Me.lblMechOilFilterD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMechOilFilterD.Name = "lblMechOilFilterD"
		Me.lblMechOilD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechOilD.Size = New System.Drawing.Size(177, 17)
		Me.lblMechOilD.Location = New System.Drawing.Point(288, 72)
		Me.lblMechOilD.TabIndex = 81
		Me.lblMechOilD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblMechOilD.BackColor = System.Drawing.SystemColors.Control
		Me.lblMechOilD.Enabled = True
		Me.lblMechOilD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMechOilD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMechOilD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMechOilD.UseMnemonic = True
		Me.lblMechOilD.Visible = True
		Me.lblMechOilD.AutoSize = False
		Me.lblMechOilD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMechOilD.Name = "lblMechOilD"
		Me.lblMechCfmD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechCfmD.Size = New System.Drawing.Size(57, 17)
		Me.lblMechCfmD.Location = New System.Drawing.Point(176, 72)
		Me.lblMechCfmD.TabIndex = 82
		Me.lblMechCfmD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblMechCfmD.BackColor = System.Drawing.SystemColors.Control
		Me.lblMechCfmD.Enabled = True
		Me.lblMechCfmD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMechCfmD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMechCfmD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMechCfmD.UseMnemonic = True
		Me.lblMechCfmD.Visible = True
		Me.lblMechCfmD.AutoSize = False
		Me.lblMechCfmD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMechCfmD.Name = "lblMechCfmD"
		Me.lblMechMinRpmD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechMinRpmD.Size = New System.Drawing.Size(49, 17)
		Me.lblMechMinRpmD.Location = New System.Drawing.Point(72, 72)
		Me.lblMechMinRpmD.TabIndex = 83
		Me.lblMechMinRpmD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblMechMinRpmD.BackColor = System.Drawing.SystemColors.Control
		Me.lblMechMinRpmD.Enabled = True
		Me.lblMechMinRpmD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMechMinRpmD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMechMinRpmD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMechMinRpmD.UseMnemonic = True
		Me.lblMechMinRpmD.Visible = True
		Me.lblMechMinRpmD.AutoSize = False
		Me.lblMechMinRpmD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMechMinRpmD.Name = "lblMechMinRpmD"
		Me.lblMechMaxRpmD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechMaxRpmD.Size = New System.Drawing.Size(49, 17)
		Me.lblMechMaxRpmD.Location = New System.Drawing.Point(472, 56)
		Me.lblMechMaxRpmD.TabIndex = 84
		Me.lblMechMaxRpmD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblMechMaxRpmD.BackColor = System.Drawing.SystemColors.Control
		Me.lblMechMaxRpmD.Enabled = True
		Me.lblMechMaxRpmD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMechMaxRpmD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMechMaxRpmD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMechMaxRpmD.UseMnemonic = True
		Me.lblMechMaxRpmD.Visible = True
		Me.lblMechMaxRpmD.AutoSize = False
		Me.lblMechMaxRpmD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMechMaxRpmD.Name = "lblMechMaxRpmD"
		Me.lblMechCatNoD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechCatNoD.Size = New System.Drawing.Size(113, 17)
		Me.lblMechCatNoD.Location = New System.Drawing.Point(288, 56)
		Me.lblMechCatNoD.TabIndex = 85
		Me.lblMechCatNoD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblMechCatNoD.BackColor = System.Drawing.SystemColors.Control
		Me.lblMechCatNoD.Enabled = True
		Me.lblMechCatNoD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMechCatNoD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMechCatNoD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMechCatNoD.UseMnemonic = True
		Me.lblMechCatNoD.Visible = True
		Me.lblMechCatNoD.AutoSize = False
		Me.lblMechCatNoD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMechCatNoD.Name = "lblMechCatNoD"
		Me.lblMechTdhD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechTdhD.Size = New System.Drawing.Size(57, 17)
		Me.lblMechTdhD.Location = New System.Drawing.Point(176, 56)
		Me.lblMechTdhD.TabIndex = 86
		Me.lblMechTdhD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblMechTdhD.BackColor = System.Drawing.SystemColors.Control
		Me.lblMechTdhD.Enabled = True
		Me.lblMechTdhD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMechTdhD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMechTdhD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMechTdhD.UseMnemonic = True
		Me.lblMechTdhD.Visible = True
		Me.lblMechTdhD.AutoSize = False
		Me.lblMechTdhD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMechTdhD.Name = "lblMechTdhD"
		Me.lblMechSizeD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechSizeD.Size = New System.Drawing.Size(73, 17)
		Me.lblMechSizeD.Location = New System.Drawing.Point(72, 56)
		Me.lblMechSizeD.TabIndex = 87
		Me.lblMechSizeD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblMechSizeD.BackColor = System.Drawing.SystemColors.Control
		Me.lblMechSizeD.Enabled = True
		Me.lblMechSizeD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMechSizeD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMechSizeD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMechSizeD.UseMnemonic = True
		Me.lblMechSizeD.Visible = True
		Me.lblMechSizeD.AutoSize = False
		Me.lblMechSizeD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMechSizeD.Name = "lblMechSizeD"
		Me.lblMechCapD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechCapD.Size = New System.Drawing.Size(57, 17)
		Me.lblMechCapD.Location = New System.Drawing.Point(472, 40)
		Me.lblMechCapD.TabIndex = 88
		Me.lblMechCapD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblMechCapD.BackColor = System.Drawing.SystemColors.Control
		Me.lblMechCapD.Enabled = True
		Me.lblMechCapD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMechCapD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMechCapD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMechCapD.UseMnemonic = True
		Me.lblMechCapD.Visible = True
		Me.lblMechCapD.AutoSize = False
		Me.lblMechCapD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMechCapD.Name = "lblMechCapD"
		Me.lblMechRpmD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechRpmD.Size = New System.Drawing.Size(49, 17)
		Me.lblMechRpmD.Location = New System.Drawing.Point(384, 40)
		Me.lblMechRpmD.TabIndex = 89
		Me.lblMechRpmD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblMechRpmD.BackColor = System.Drawing.SystemColors.Control
		Me.lblMechRpmD.Enabled = True
		Me.lblMechRpmD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMechRpmD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMechRpmD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMechRpmD.UseMnemonic = True
		Me.lblMechRpmD.Visible = True
		Me.lblMechRpmD.AutoSize = False
		Me.lblMechRpmD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMechRpmD.Name = "lblMechRpmD"
		Me.lblMechImpSzD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechImpSzD.Size = New System.Drawing.Size(81, 17)
		Me.lblMechImpSzD.Location = New System.Drawing.Point(176, 40)
		Me.lblMechImpSzD.TabIndex = 90
		Me.lblMechImpSzD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblMechImpSzD.BackColor = System.Drawing.SystemColors.Control
		Me.lblMechImpSzD.Enabled = True
		Me.lblMechImpSzD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMechImpSzD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMechImpSzD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMechImpSzD.UseMnemonic = True
		Me.lblMechImpSzD.Visible = True
		Me.lblMechImpSzD.AutoSize = False
		Me.lblMechImpSzD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMechImpSzD.Name = "lblMechImpSzD"
		Me.lblMechSerialD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechSerialD.Size = New System.Drawing.Size(113, 17)
		Me.lblMechSerialD.Location = New System.Drawing.Point(72, 24)
		Me.lblMechSerialD.TabIndex = 91
		Me.lblMechSerialD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblMechSerialD.BackColor = System.Drawing.SystemColors.Control
		Me.lblMechSerialD.Enabled = True
		Me.lblMechSerialD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMechSerialD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMechSerialD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMechSerialD.UseMnemonic = True
		Me.lblMechSerialD.Visible = True
		Me.lblMechSerialD.AutoSize = False
		Me.lblMechSerialD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMechSerialD.Name = "lblMechSerialD"
		Me.lblMechRecomSpareParts.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblMechRecomSpareParts.Text = "Rec. Parts"
		Me.lblMechRecomSpareParts.Size = New System.Drawing.Size(57, 17)
		Me.lblMechRecomSpareParts.Location = New System.Drawing.Point(8, 136)
		Me.lblMechRecomSpareParts.TabIndex = 92
		Me.lblMechRecomSpareParts.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechRecomSpareParts.BackColor = System.Drawing.SystemColors.Control
		Me.lblMechRecomSpareParts.Enabled = True
		Me.lblMechRecomSpareParts.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMechRecomSpareParts.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMechRecomSpareParts.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMechRecomSpareParts.UseMnemonic = True
		Me.lblMechRecomSpareParts.Visible = True
		Me.lblMechRecomSpareParts.AutoSize = False
		Me.lblMechRecomSpareParts.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMechRecomSpareParts.Name = "lblMechRecomSpareParts"
		Me.lblMechMiscNPData.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblMechMiscNPData.Text = "NP Data"
		Me.lblMechMiscNPData.Size = New System.Drawing.Size(41, 17)
		Me.lblMechMiscNPData.Location = New System.Drawing.Point(24, 152)
		Me.lblMechMiscNPData.TabIndex = 93
		Me.lblMechMiscNPData.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechMiscNPData.BackColor = System.Drawing.SystemColors.Control
		Me.lblMechMiscNPData.Enabled = True
		Me.lblMechMiscNPData.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMechMiscNPData.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMechMiscNPData.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMechMiscNPData.UseMnemonic = True
		Me.lblMechMiscNPData.Visible = True
		Me.lblMechMiscNPData.AutoSize = False
		Me.lblMechMiscNPData.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMechMiscNPData.Name = "lblMechMiscNPData"
		Me.lblMechNoValvesTypes.Text = "No. Valves and Types"
		Me.lblMechNoValvesTypes.Size = New System.Drawing.Size(113, 17)
		Me.lblMechNoValvesTypes.Location = New System.Drawing.Point(16, 184)
		Me.lblMechNoValvesTypes.TabIndex = 94
		Me.lblMechNoValvesTypes.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechNoValvesTypes.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblMechNoValvesTypes.BackColor = System.Drawing.SystemColors.Control
		Me.lblMechNoValvesTypes.Enabled = True
		Me.lblMechNoValvesTypes.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMechNoValvesTypes.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMechNoValvesTypes.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMechNoValvesTypes.UseMnemonic = True
		Me.lblMechNoValvesTypes.Visible = True
		Me.lblMechNoValvesTypes.AutoSize = False
		Me.lblMechNoValvesTypes.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMechNoValvesTypes.Name = "lblMechNoValvesTypes"
		Me.lblMechPipeType.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblMechPipeType.Text = "Type"
		Me.lblMechPipeType.Size = New System.Drawing.Size(25, 17)
		Me.lblMechPipeType.Location = New System.Drawing.Point(336, 120)
		Me.lblMechPipeType.TabIndex = 95
		Me.lblMechPipeType.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechPipeType.BackColor = System.Drawing.SystemColors.Control
		Me.lblMechPipeType.Enabled = True
		Me.lblMechPipeType.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMechPipeType.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMechPipeType.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMechPipeType.UseMnemonic = True
		Me.lblMechPipeType.Visible = True
		Me.lblMechPipeType.AutoSize = False
		Me.lblMechPipeType.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMechPipeType.Name = "lblMechPipeType"
		Me.lblMechPipeSize.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblMechPipeSize.Text = "Pipe Size(s)"
		Me.lblMechPipeSize.Size = New System.Drawing.Size(57, 17)
		Me.lblMechPipeSize.Location = New System.Drawing.Point(8, 120)
		Me.lblMechPipeSize.TabIndex = 96
		Me.lblMechPipeSize.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechPipeSize.BackColor = System.Drawing.SystemColors.Control
		Me.lblMechPipeSize.Enabled = True
		Me.lblMechPipeSize.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMechPipeSize.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMechPipeSize.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMechPipeSize.UseMnemonic = True
		Me.lblMechPipeSize.Visible = True
		Me.lblMechPipeSize.AutoSize = False
		Me.lblMechPipeSize.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMechPipeSize.Name = "lblMechPipeSize"
		Me.lblMechcfm.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblMechcfm.Text = "cfm"
		Me.lblMechcfm.Size = New System.Drawing.Size(25, 17)
		Me.lblMechcfm.Location = New System.Drawing.Point(144, 72)
		Me.lblMechcfm.TabIndex = 97
		Me.lblMechcfm.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechcfm.BackColor = System.Drawing.SystemColors.Control
		Me.lblMechcfm.Enabled = True
		Me.lblMechcfm.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMechcfm.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMechcfm.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMechcfm.UseMnemonic = True
		Me.lblMechcfm.Visible = True
		Me.lblMechcfm.AutoSize = False
		Me.lblMechcfm.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMechcfm.Name = "lblMechcfm"
		Me.lblMechMaxRpm.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblMechMaxRpm.Text = "max rpm"
		Me.lblMechMaxRpm.Size = New System.Drawing.Size(41, 17)
		Me.lblMechMaxRpm.Location = New System.Drawing.Point(424, 56)
		Me.lblMechMaxRpm.TabIndex = 98
		Me.lblMechMaxRpm.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechMaxRpm.BackColor = System.Drawing.SystemColors.Control
		Me.lblMechMaxRpm.Enabled = True
		Me.lblMechMaxRpm.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMechMaxRpm.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMechMaxRpm.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMechMaxRpm.UseMnemonic = True
		Me.lblMechMaxRpm.Visible = True
		Me.lblMechMaxRpm.AutoSize = False
		Me.lblMechMaxRpm.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMechMaxRpm.Name = "lblMechMaxRpm"
		Me.lblMechMinRpm.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblMechMinRpm.Text = "min rpm"
		Me.lblMechMinRpm.Size = New System.Drawing.Size(41, 17)
		Me.lblMechMinRpm.Location = New System.Drawing.Point(24, 72)
		Me.lblMechMinRpm.TabIndex = 99
		Me.lblMechMinRpm.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechMinRpm.BackColor = System.Drawing.SystemColors.Control
		Me.lblMechMinRpm.Enabled = True
		Me.lblMechMinRpm.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMechMinRpm.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMechMinRpm.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMechMinRpm.UseMnemonic = True
		Me.lblMechMinRpm.Visible = True
		Me.lblMechMinRpm.AutoSize = False
		Me.lblMechMinRpm.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMechMinRpm.Name = "lblMechMinRpm"
		Me.lblMechCatNo.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblMechCatNo.Text = "cat no"
		Me.lblMechCatNo.Size = New System.Drawing.Size(33, 17)
		Me.lblMechCatNo.Location = New System.Drawing.Point(248, 56)
		Me.lblMechCatNo.TabIndex = 100
		Me.lblMechCatNo.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechCatNo.BackColor = System.Drawing.SystemColors.Control
		Me.lblMechCatNo.Enabled = True
		Me.lblMechCatNo.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMechCatNo.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMechCatNo.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMechCatNo.UseMnemonic = True
		Me.lblMechCatNo.Visible = True
		Me.lblMechCatNo.AutoSize = False
		Me.lblMechCatNo.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMechCatNo.Name = "lblMechCatNo"
		Me.lblMechSize.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblMechSize.Text = "size"
		Me.lblMechSize.Size = New System.Drawing.Size(25, 17)
		Me.lblMechSize.Location = New System.Drawing.Point(40, 56)
		Me.lblMechSize.TabIndex = 101
		Me.lblMechSize.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechSize.BackColor = System.Drawing.SystemColors.Control
		Me.lblMechSize.Enabled = True
		Me.lblMechSize.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMechSize.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMechSize.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMechSize.UseMnemonic = True
		Me.lblMechSize.Visible = True
		Me.lblMechSize.AutoSize = False
		Me.lblMechSize.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMechSize.Name = "lblMechSize"
		Me.lblMechtdh.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblMechtdh.Text = "tdh"
		Me.lblMechtdh.Size = New System.Drawing.Size(17, 17)
		Me.lblMechtdh.Location = New System.Drawing.Point(152, 56)
		Me.lblMechtdh.TabIndex = 102
		Me.lblMechtdh.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechtdh.BackColor = System.Drawing.SystemColors.Control
		Me.lblMechtdh.Enabled = True
		Me.lblMechtdh.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMechtdh.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMechtdh.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMechtdh.UseMnemonic = True
		Me.lblMechtdh.Visible = True
		Me.lblMechtdh.AutoSize = False
		Me.lblMechtdh.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMechtdh.Name = "lblMechtdh"
		Me.lblMechCap.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblMechCap.Text = "cap"
		Me.lblMechCap.Size = New System.Drawing.Size(25, 17)
		Me.lblMechCap.Location = New System.Drawing.Point(440, 40)
		Me.lblMechCap.TabIndex = 103
		Me.lblMechCap.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechCap.BackColor = System.Drawing.SystemColors.Control
		Me.lblMechCap.Enabled = True
		Me.lblMechCap.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMechCap.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMechCap.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMechCap.UseMnemonic = True
		Me.lblMechCap.Visible = True
		Me.lblMechCap.AutoSize = False
		Me.lblMechCap.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMechCap.Name = "lblMechCap"
		Me.lblMechRpm.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblMechRpm.Text = "rpm"
		Me.lblMechRpm.Size = New System.Drawing.Size(25, 17)
		Me.lblMechRpm.Location = New System.Drawing.Point(352, 40)
		Me.lblMechRpm.TabIndex = 104
		Me.lblMechRpm.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechRpm.BackColor = System.Drawing.SystemColors.Control
		Me.lblMechRpm.Enabled = True
		Me.lblMechRpm.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMechRpm.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMechRpm.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMechRpm.UseMnemonic = True
		Me.lblMechRpm.Visible = True
		Me.lblMechRpm.AutoSize = False
		Me.lblMechRpm.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMechRpm.Name = "lblMechRpm"
		Me.lblMechHp.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblMechHp.Text = "hp"
		Me.lblMechHp.Size = New System.Drawing.Size(17, 17)
		Me.lblMechHp.Location = New System.Drawing.Point(264, 40)
		Me.lblMechHp.TabIndex = 105
		Me.lblMechHp.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechHp.BackColor = System.Drawing.SystemColors.Control
		Me.lblMechHp.Enabled = True
		Me.lblMechHp.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMechHp.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMechHp.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMechHp.UseMnemonic = True
		Me.lblMechHp.Visible = True
		Me.lblMechHp.AutoSize = False
		Me.lblMechHp.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMechHp.Name = "lblMechHp"
		Me.lblMechImpSz.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblMechImpSz.Text = "imp sz"
		Me.lblMechImpSz.Size = New System.Drawing.Size(33, 17)
		Me.lblMechImpSz.Location = New System.Drawing.Point(136, 40)
		Me.lblMechImpSz.TabIndex = 106
		Me.lblMechImpSz.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechImpSz.BackColor = System.Drawing.SystemColors.Control
		Me.lblMechImpSz.Enabled = True
		Me.lblMechImpSz.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMechImpSz.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMechImpSz.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMechImpSz.UseMnemonic = True
		Me.lblMechImpSz.Visible = True
		Me.lblMechImpSz.AutoSize = False
		Me.lblMechImpSz.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMechImpSz.Name = "lblMechImpSz"
		Me.lblMechFrame.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblMechFrame.Text = "frame"
		Me.lblMechFrame.Size = New System.Drawing.Size(33, 17)
		Me.lblMechFrame.Location = New System.Drawing.Point(32, 40)
		Me.lblMechFrame.TabIndex = 107
		Me.lblMechFrame.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechFrame.BackColor = System.Drawing.SystemColors.Control
		Me.lblMechFrame.Enabled = True
		Me.lblMechFrame.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMechFrame.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMechFrame.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMechFrame.UseMnemonic = True
		Me.lblMechFrame.Visible = True
		Me.lblMechFrame.AutoSize = False
		Me.lblMechFrame.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMechFrame.Name = "lblMechFrame"
		Me.lblMechModel.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblMechModel.Text = "model"
		Me.lblMechModel.Size = New System.Drawing.Size(33, 17)
		Me.lblMechModel.Location = New System.Drawing.Point(344, 24)
		Me.lblMechModel.TabIndex = 108
		Me.lblMechModel.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechModel.BackColor = System.Drawing.SystemColors.Control
		Me.lblMechModel.Enabled = True
		Me.lblMechModel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMechModel.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMechModel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMechModel.UseMnemonic = True
		Me.lblMechModel.Visible = True
		Me.lblMechModel.AutoSize = False
		Me.lblMechModel.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMechModel.Name = "lblMechModel"
		Me.lblMechID.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblMechID.Text = "id"
		Me.lblMechID.Size = New System.Drawing.Size(17, 17)
		Me.lblMechID.Location = New System.Drawing.Point(192, 24)
		Me.lblMechID.TabIndex = 109
		Me.lblMechID.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechID.BackColor = System.Drawing.SystemColors.Control
		Me.lblMechID.Enabled = True
		Me.lblMechID.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMechID.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMechID.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMechID.UseMnemonic = True
		Me.lblMechID.Visible = True
		Me.lblMechID.AutoSize = False
		Me.lblMechID.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMechID.Name = "lblMechID"
		Me.lblMechSerial.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblMechSerial.Text = "serial"
		Me.lblMechSerial.Size = New System.Drawing.Size(33, 17)
		Me.lblMechSerial.Location = New System.Drawing.Point(32, 24)
		Me.lblMechSerial.TabIndex = 110
		Me.lblMechSerial.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechSerial.BackColor = System.Drawing.SystemColors.Control
		Me.lblMechSerial.Enabled = True
		Me.lblMechSerial.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMechSerial.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMechSerial.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMechSerial.UseMnemonic = True
		Me.lblMechSerial.Visible = True
		Me.lblMechSerial.AutoSize = False
		Me.lblMechSerial.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMechSerial.Name = "lblMechSerial"
		Me.lblMechOil.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblMechOil.Text = "Oil"
		Me.lblMechOil.Size = New System.Drawing.Size(17, 17)
		Me.lblMechOil.Location = New System.Drawing.Point(264, 72)
		Me.lblMechOil.TabIndex = 111
		Me.lblMechOil.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechOil.BackColor = System.Drawing.SystemColors.Control
		Me.lblMechOil.Enabled = True
		Me.lblMechOil.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMechOil.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMechOil.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMechOil.UseMnemonic = True
		Me.lblMechOil.Visible = True
		Me.lblMechOil.AutoSize = False
		Me.lblMechOil.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMechOil.Name = "lblMechOil"
		Me.lblMechOilFilter.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblMechOilFilter.Text = "Oil Filt"
		Me.lblMechOilFilter.Size = New System.Drawing.Size(33, 17)
		Me.lblMechOilFilter.Location = New System.Drawing.Point(32, 88)
		Me.lblMechOilFilter.TabIndex = 112
		Me.lblMechOilFilter.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechOilFilter.BackColor = System.Drawing.SystemColors.Control
		Me.lblMechOilFilter.Enabled = True
		Me.lblMechOilFilter.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMechOilFilter.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMechOilFilter.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMechOilFilter.UseMnemonic = True
		Me.lblMechOilFilter.Visible = True
		Me.lblMechOilFilter.AutoSize = False
		Me.lblMechOilFilter.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMechOilFilter.Name = "lblMechOilFilter"
		Me.lblMechAirFilter.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblMechAirFilter.Text = "Air Filt"
		Me.lblMechAirFilter.Size = New System.Drawing.Size(33, 17)
		Me.lblMechAirFilter.Location = New System.Drawing.Point(248, 88)
		Me.lblMechAirFilter.TabIndex = 113
		Me.lblMechAirFilter.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechAirFilter.BackColor = System.Drawing.SystemColors.Control
		Me.lblMechAirFilter.Enabled = True
		Me.lblMechAirFilter.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMechAirFilter.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMechAirFilter.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMechAirFilter.UseMnemonic = True
		Me.lblMechAirFilter.Visible = True
		Me.lblMechAirFilter.AutoSize = False
		Me.lblMechAirFilter.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMechAirFilter.Name = "lblMechAirFilter"
		Me.lblMechBelt1.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblMechBelt1.Text = "Belt1"
		Me.lblMechBelt1.Size = New System.Drawing.Size(25, 17)
		Me.lblMechBelt1.Location = New System.Drawing.Point(40, 104)
		Me.lblMechBelt1.TabIndex = 114
		Me.lblMechBelt1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechBelt1.BackColor = System.Drawing.SystemColors.Control
		Me.lblMechBelt1.Enabled = True
		Me.lblMechBelt1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMechBelt1.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMechBelt1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMechBelt1.UseMnemonic = True
		Me.lblMechBelt1.Visible = True
		Me.lblMechBelt1.AutoSize = False
		Me.lblMechBelt1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMechBelt1.Name = "lblMechBelt1"
		Me.lblMechBelt2.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblMechBelt2.Text = "Belt2"
		Me.lblMechBelt2.Size = New System.Drawing.Size(25, 17)
		Me.lblMechBelt2.Location = New System.Drawing.Point(256, 104)
		Me.lblMechBelt2.TabIndex = 115
		Me.lblMechBelt2.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechBelt2.BackColor = System.Drawing.SystemColors.Control
		Me.lblMechBelt2.Enabled = True
		Me.lblMechBelt2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMechBelt2.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMechBelt2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMechBelt2.UseMnemonic = True
		Me.lblMechBelt2.Visible = True
		Me.lblMechBelt2.AutoSize = False
		Me.lblMechBelt2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMechBelt2.Name = "lblMechBelt2"
		Me.lblMechHpD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechHpD.Size = New System.Drawing.Size(49, 17)
		Me.lblMechHpD.Location = New System.Drawing.Point(288, 40)
		Me.lblMechHpD.TabIndex = 126
		Me.lblMechHpD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblMechHpD.BackColor = System.Drawing.SystemColors.Control
		Me.lblMechHpD.Enabled = True
		Me.lblMechHpD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMechHpD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMechHpD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMechHpD.UseMnemonic = True
		Me.lblMechHpD.Visible = True
		Me.lblMechHpD.AutoSize = False
		Me.lblMechHpD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMechHpD.Name = "lblMechHpD"
		Me._SSTab1_TabPage1.Text = "Electrical"
		Me.lblElecMiscNPDataD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecMiscNPDataD.Size = New System.Drawing.Size(369, 33)
		Me.lblElecMiscNPDataD.Location = New System.Drawing.Point(152, 104)
		Me.lblElecMiscNPDataD.TabIndex = 31
		Me.lblElecMiscNPDataD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblElecMiscNPDataD.BackColor = System.Drawing.SystemColors.Control
		Me.lblElecMiscNPDataD.Enabled = True
		Me.lblElecMiscNPDataD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblElecMiscNPDataD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblElecMiscNPDataD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblElecMiscNPDataD.UseMnemonic = True
		Me.lblElecMiscNPDataD.Visible = True
		Me.lblElecMiscNPDataD.AutoSize = False
		Me.lblElecMiscNPDataD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblElecMiscNPDataD.Name = "lblElecMiscNPDataD"
		Me.lblElecRecomSparePartsD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecRecomSparePartsD.Size = New System.Drawing.Size(257, 17)
		Me.lblElecRecomSparePartsD.Location = New System.Drawing.Point(152, 144)
		Me.lblElecRecomSparePartsD.TabIndex = 32
		Me.lblElecRecomSparePartsD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblElecRecomSparePartsD.BackColor = System.Drawing.SystemColors.Control
		Me.lblElecRecomSparePartsD.Enabled = True
		Me.lblElecRecomSparePartsD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblElecRecomSparePartsD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblElecRecomSparePartsD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblElecRecomSparePartsD.UseMnemonic = True
		Me.lblElecRecomSparePartsD.Visible = True
		Me.lblElecRecomSparePartsD.AutoSize = False
		Me.lblElecRecomSparePartsD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblElecRecomSparePartsD.Name = "lblElecRecomSparePartsD"
		Me.lblElecOppEndBrgD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecOppEndBrgD.Size = New System.Drawing.Size(113, 17)
		Me.lblElecOppEndBrgD.Location = New System.Drawing.Point(384, 88)
		Me.lblElecOppEndBrgD.TabIndex = 33
		Me.lblElecOppEndBrgD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblElecOppEndBrgD.BackColor = System.Drawing.SystemColors.Control
		Me.lblElecOppEndBrgD.Enabled = True
		Me.lblElecOppEndBrgD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblElecOppEndBrgD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblElecOppEndBrgD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblElecOppEndBrgD.UseMnemonic = True
		Me.lblElecOppEndBrgD.Visible = True
		Me.lblElecOppEndBrgD.AutoSize = False
		Me.lblElecOppEndBrgD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblElecOppEndBrgD.Name = "lblElecOppEndBrgD"
		Me.lblElecShaftEndBrgD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecShaftEndBrgD.Size = New System.Drawing.Size(113, 17)
		Me.lblElecShaftEndBrgD.Location = New System.Drawing.Point(152, 88)
		Me.lblElecShaftEndBrgD.TabIndex = 34
		Me.lblElecShaftEndBrgD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblElecShaftEndBrgD.BackColor = System.Drawing.SystemColors.Control
		Me.lblElecShaftEndBrgD.Enabled = True
		Me.lblElecShaftEndBrgD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblElecShaftEndBrgD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblElecShaftEndBrgD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblElecShaftEndBrgD.UseMnemonic = True
		Me.lblElecShaftEndBrgD.Visible = True
		Me.lblElecShaftEndBrgD.AutoSize = False
		Me.lblElecShaftEndBrgD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblElecShaftEndBrgD.Name = "lblElecShaftEndBrgD"
		Me.lblElecDesignD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecDesignD.Size = New System.Drawing.Size(33, 17)
		Me.lblElecDesignD.Location = New System.Drawing.Point(480, 72)
		Me.lblElecDesignD.TabIndex = 35
		Me.lblElecDesignD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblElecDesignD.BackColor = System.Drawing.SystemColors.Control
		Me.lblElecDesignD.Enabled = True
		Me.lblElecDesignD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblElecDesignD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblElecDesignD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblElecDesignD.UseMnemonic = True
		Me.lblElecDesignD.Visible = True
		Me.lblElecDesignD.AutoSize = False
		Me.lblElecDesignD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblElecDesignD.Name = "lblElecDesignD"
		Me.lblElecInslClD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecInslClD.Size = New System.Drawing.Size(33, 17)
		Me.lblElecInslClD.Location = New System.Drawing.Point(384, 72)
		Me.lblElecInslClD.TabIndex = 36
		Me.lblElecInslClD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblElecInslClD.BackColor = System.Drawing.SystemColors.Control
		Me.lblElecInslClD.Enabled = True
		Me.lblElecInslClD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblElecInslClD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblElecInslClD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblElecInslClD.UseMnemonic = True
		Me.lblElecInslClD.Visible = True
		Me.lblElecInslClD.AutoSize = False
		Me.lblElecInslClD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblElecInslClD.Name = "lblElecInslClD"
		Me.lblElecAmpD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecAmpD.Size = New System.Drawing.Size(105, 17)
		Me.lblElecAmpD.Location = New System.Drawing.Point(56, 72)
		Me.lblElecAmpD.TabIndex = 37
		Me.lblElecAmpD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblElecAmpD.BackColor = System.Drawing.SystemColors.Control
		Me.lblElecAmpD.Enabled = True
		Me.lblElecAmpD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblElecAmpD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblElecAmpD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblElecAmpD.UseMnemonic = True
		Me.lblElecAmpD.Visible = True
		Me.lblElecAmpD.AutoSize = False
		Me.lblElecAmpD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblElecAmpD.Name = "lblElecAmpD"
		Me.lblElecVD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecVD.Size = New System.Drawing.Size(105, 17)
		Me.lblElecVD.Location = New System.Drawing.Point(384, 56)
		Me.lblElecVD.TabIndex = 38
		Me.lblElecVD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblElecVD.BackColor = System.Drawing.SystemColors.Control
		Me.lblElecVD.Enabled = True
		Me.lblElecVD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblElecVD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblElecVD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblElecVD.UseMnemonic = True
		Me.lblElecVD.Visible = True
		Me.lblElecVD.AutoSize = False
		Me.lblElecVD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblElecVD.Name = "lblElecVD"
		Me.lblElecDutyD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecDutyD.Size = New System.Drawing.Size(49, 17)
		Me.lblElecDutyD.Location = New System.Drawing.Point(200, 72)
		Me.lblElecDutyD.TabIndex = 39
		Me.lblElecDutyD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblElecDutyD.BackColor = System.Drawing.SystemColors.Control
		Me.lblElecDutyD.Enabled = True
		Me.lblElecDutyD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblElecDutyD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblElecDutyD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblElecDutyD.UseMnemonic = True
		Me.lblElecDutyD.Visible = True
		Me.lblElecDutyD.AutoSize = False
		Me.lblElecDutyD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblElecDutyD.Name = "lblElecDutyD"
		Me.lblElecSfD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecSfD.Size = New System.Drawing.Size(41, 17)
		Me.lblElecSfD.Location = New System.Drawing.Point(264, 56)
		Me.lblElecSfD.TabIndex = 40
		Me.lblElecSfD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblElecSfD.BackColor = System.Drawing.SystemColors.Control
		Me.lblElecSfD.Enabled = True
		Me.lblElecSfD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblElecSfD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblElecSfD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblElecSfD.UseMnemonic = True
		Me.lblElecSfD.Visible = True
		Me.lblElecSfD.AutoSize = False
		Me.lblElecSfD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblElecSfD.Name = "lblElecSfD"
		Me.lblElecPhsD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecPhsD.Size = New System.Drawing.Size(25, 17)
		Me.lblElecPhsD.Location = New System.Drawing.Point(200, 56)
		Me.lblElecPhsD.TabIndex = 41
		Me.lblElecPhsD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblElecPhsD.BackColor = System.Drawing.SystemColors.Control
		Me.lblElecPhsD.Enabled = True
		Me.lblElecPhsD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblElecPhsD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblElecPhsD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblElecPhsD.UseMnemonic = True
		Me.lblElecPhsD.Visible = True
		Me.lblElecPhsD.AutoSize = False
		Me.lblElecPhsD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblElecPhsD.Name = "lblElecPhsD"
		Me.lblElecHzD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecHzD.Size = New System.Drawing.Size(33, 17)
		Me.lblElecHzD.Location = New System.Drawing.Point(56, 56)
		Me.lblElecHzD.TabIndex = 42
		Me.lblElecHzD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblElecHzD.BackColor = System.Drawing.SystemColors.Control
		Me.lblElecHzD.Enabled = True
		Me.lblElecHzD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblElecHzD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblElecHzD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblElecHzD.UseMnemonic = True
		Me.lblElecHzD.Visible = True
		Me.lblElecHzD.AutoSize = False
		Me.lblElecHzD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblElecHzD.Name = "lblElecHzD"
		Me.lblElecRpmD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecRpmD.Size = New System.Drawing.Size(57, 17)
		Me.lblElecRpmD.Location = New System.Drawing.Point(472, 40)
		Me.lblElecRpmD.TabIndex = 43
		Me.lblElecRpmD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblElecRpmD.BackColor = System.Drawing.SystemColors.Control
		Me.lblElecRpmD.Enabled = True
		Me.lblElecRpmD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblElecRpmD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblElecRpmD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblElecRpmD.UseMnemonic = True
		Me.lblElecRpmD.Visible = True
		Me.lblElecRpmD.AutoSize = False
		Me.lblElecRpmD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblElecRpmD.Name = "lblElecRpmD"
		Me.lblElecHpD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecHpD.Size = New System.Drawing.Size(49, 17)
		Me.lblElecHpD.Location = New System.Drawing.Point(384, 40)
		Me.lblElecHpD.TabIndex = 44
		Me.lblElecHpD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblElecHpD.BackColor = System.Drawing.SystemColors.Control
		Me.lblElecHpD.Enabled = True
		Me.lblElecHpD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblElecHpD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblElecHpD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblElecHpD.UseMnemonic = True
		Me.lblElecHpD.Visible = True
		Me.lblElecHpD.AutoSize = False
		Me.lblElecHpD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblElecHpD.Name = "lblElecHpD"
		Me.lblElecCatNoD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecCatNoD.Size = New System.Drawing.Size(97, 17)
		Me.lblElecCatNoD.Location = New System.Drawing.Point(200, 40)
		Me.lblElecCatNoD.TabIndex = 45
		Me.lblElecCatNoD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblElecCatNoD.BackColor = System.Drawing.SystemColors.Control
		Me.lblElecCatNoD.Enabled = True
		Me.lblElecCatNoD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblElecCatNoD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblElecCatNoD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblElecCatNoD.UseMnemonic = True
		Me.lblElecCatNoD.Visible = True
		Me.lblElecCatNoD.AutoSize = False
		Me.lblElecCatNoD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblElecCatNoD.Name = "lblElecCatNoD"
		Me.lblElecFrameD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecFrameD.Size = New System.Drawing.Size(65, 17)
		Me.lblElecFrameD.Location = New System.Drawing.Point(56, 40)
		Me.lblElecFrameD.TabIndex = 46
		Me.lblElecFrameD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblElecFrameD.BackColor = System.Drawing.SystemColors.Control
		Me.lblElecFrameD.Enabled = True
		Me.lblElecFrameD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblElecFrameD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblElecFrameD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblElecFrameD.UseMnemonic = True
		Me.lblElecFrameD.Visible = True
		Me.lblElecFrameD.AutoSize = False
		Me.lblElecFrameD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblElecFrameD.Name = "lblElecFrameD"
		Me.lblElecSerialD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecSerialD.Size = New System.Drawing.Size(113, 17)
		Me.lblElecSerialD.Location = New System.Drawing.Point(56, 24)
		Me.lblElecSerialD.TabIndex = 47
		Me.lblElecSerialD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblElecSerialD.BackColor = System.Drawing.SystemColors.Control
		Me.lblElecSerialD.Enabled = True
		Me.lblElecSerialD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblElecSerialD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblElecSerialD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblElecSerialD.UseMnemonic = True
		Me.lblElecSerialD.Visible = True
		Me.lblElecSerialD.AutoSize = False
		Me.lblElecSerialD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblElecSerialD.Name = "lblElecSerialD"
		Me.lblElecModelD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecModelD.Size = New System.Drawing.Size(129, 17)
		Me.lblElecModelD.Location = New System.Drawing.Point(384, 24)
		Me.lblElecModelD.TabIndex = 48
		Me.lblElecModelD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblElecModelD.BackColor = System.Drawing.SystemColors.Control
		Me.lblElecModelD.Enabled = True
		Me.lblElecModelD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblElecModelD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblElecModelD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblElecModelD.UseMnemonic = True
		Me.lblElecModelD.Visible = True
		Me.lblElecModelD.AutoSize = False
		Me.lblElecModelD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblElecModelD.Name = "lblElecModelD"
		Me.lblElecIDD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecIDD.Size = New System.Drawing.Size(113, 17)
		Me.lblElecIDD.Location = New System.Drawing.Point(200, 24)
		Me.lblElecIDD.TabIndex = 49
		Me.lblElecIDD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblElecIDD.BackColor = System.Drawing.SystemColors.Control
		Me.lblElecIDD.Enabled = True
		Me.lblElecIDD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblElecIDD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblElecIDD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblElecIDD.UseMnemonic = True
		Me.lblElecIDD.Visible = True
		Me.lblElecIDD.AutoSize = False
		Me.lblElecIDD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblElecIDD.Name = "lblElecIDD"
		Me.lblElecRecomSpareParts.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblElecRecomSpareParts.Text = "Recommended Spare Parts"
		Me.lblElecRecomSpareParts.Size = New System.Drawing.Size(137, 17)
		Me.lblElecRecomSpareParts.Location = New System.Drawing.Point(8, 144)
		Me.lblElecRecomSpareParts.TabIndex = 50
		Me.lblElecRecomSpareParts.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecRecomSpareParts.BackColor = System.Drawing.SystemColors.Control
		Me.lblElecRecomSpareParts.Enabled = True
		Me.lblElecRecomSpareParts.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblElecRecomSpareParts.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblElecRecomSpareParts.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblElecRecomSpareParts.UseMnemonic = True
		Me.lblElecRecomSpareParts.Visible = True
		Me.lblElecRecomSpareParts.AutoSize = False
		Me.lblElecRecomSpareParts.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblElecRecomSpareParts.Name = "lblElecRecomSpareParts"
		Me.lblElecMiscNPData.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblElecMiscNPData.Text = "Misc. NP Data"
		Me.lblElecMiscNPData.Size = New System.Drawing.Size(73, 17)
		Me.lblElecMiscNPData.Location = New System.Drawing.Point(72, 104)
		Me.lblElecMiscNPData.TabIndex = 51
		Me.lblElecMiscNPData.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecMiscNPData.BackColor = System.Drawing.SystemColors.Control
		Me.lblElecMiscNPData.Enabled = True
		Me.lblElecMiscNPData.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblElecMiscNPData.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblElecMiscNPData.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblElecMiscNPData.UseMnemonic = True
		Me.lblElecMiscNPData.Visible = True
		Me.lblElecMiscNPData.AutoSize = False
		Me.lblElecMiscNPData.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblElecMiscNPData.Name = "lblElecMiscNPData"
		Me.lblElecOppEndBrg.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblElecOppEndBrg.Text = "opp. end brg"
		Me.lblElecOppEndBrg.Size = New System.Drawing.Size(65, 17)
		Me.lblElecOppEndBrg.Location = New System.Drawing.Point(312, 88)
		Me.lblElecOppEndBrg.TabIndex = 52
		Me.lblElecOppEndBrg.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecOppEndBrg.BackColor = System.Drawing.SystemColors.Control
		Me.lblElecOppEndBrg.Enabled = True
		Me.lblElecOppEndBrg.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblElecOppEndBrg.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblElecOppEndBrg.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblElecOppEndBrg.UseMnemonic = True
		Me.lblElecOppEndBrg.Visible = True
		Me.lblElecOppEndBrg.AutoSize = False
		Me.lblElecOppEndBrg.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblElecOppEndBrg.Name = "lblElecOppEndBrg"
		Me.lblElecShaftEndBrg.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblElecShaftEndBrg.Text = "shaft end brg"
		Me.lblElecShaftEndBrg.Size = New System.Drawing.Size(65, 17)
		Me.lblElecShaftEndBrg.Location = New System.Drawing.Point(80, 88)
		Me.lblElecShaftEndBrg.TabIndex = 53
		Me.lblElecShaftEndBrg.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecShaftEndBrg.BackColor = System.Drawing.SystemColors.Control
		Me.lblElecShaftEndBrg.Enabled = True
		Me.lblElecShaftEndBrg.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblElecShaftEndBrg.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblElecShaftEndBrg.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblElecShaftEndBrg.UseMnemonic = True
		Me.lblElecShaftEndBrg.Visible = True
		Me.lblElecShaftEndBrg.AutoSize = False
		Me.lblElecShaftEndBrg.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblElecShaftEndBrg.Name = "lblElecShaftEndBrg"
		Me.lblElecDesign.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblElecDesign.Text = "design"
		Me.lblElecDesign.Size = New System.Drawing.Size(33, 17)
		Me.lblElecDesign.Location = New System.Drawing.Point(440, 72)
		Me.lblElecDesign.TabIndex = 54
		Me.lblElecDesign.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecDesign.BackColor = System.Drawing.SystemColors.Control
		Me.lblElecDesign.Enabled = True
		Me.lblElecDesign.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblElecDesign.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblElecDesign.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblElecDesign.UseMnemonic = True
		Me.lblElecDesign.Visible = True
		Me.lblElecDesign.AutoSize = False
		Me.lblElecDesign.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblElecDesign.Name = "lblElecDesign"
		Me.lblElecInslCl.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblElecInslCl.Text = "insl cl"
		Me.lblElecInslCl.Size = New System.Drawing.Size(33, 17)
		Me.lblElecInslCl.Location = New System.Drawing.Point(344, 72)
		Me.lblElecInslCl.TabIndex = 55
		Me.lblElecInslCl.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecInslCl.BackColor = System.Drawing.SystemColors.Control
		Me.lblElecInslCl.Enabled = True
		Me.lblElecInslCl.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblElecInslCl.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblElecInslCl.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblElecInslCl.UseMnemonic = True
		Me.lblElecInslCl.Visible = True
		Me.lblElecInslCl.AutoSize = False
		Me.lblElecInslCl.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblElecInslCl.Name = "lblElecInslCl"
		Me.lblElecDuty.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblElecDuty.Text = "duty"
		Me.lblElecDuty.Size = New System.Drawing.Size(25, 17)
		Me.lblElecDuty.Location = New System.Drawing.Point(168, 72)
		Me.lblElecDuty.TabIndex = 56
		Me.lblElecDuty.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecDuty.BackColor = System.Drawing.SystemColors.Control
		Me.lblElecDuty.Enabled = True
		Me.lblElecDuty.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblElecDuty.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblElecDuty.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblElecDuty.UseMnemonic = True
		Me.lblElecDuty.Visible = True
		Me.lblElecDuty.AutoSize = False
		Me.lblElecDuty.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblElecDuty.Name = "lblElecDuty"
		Me.lblElecAmp.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblElecAmp.Text = "amp"
		Me.lblElecAmp.Size = New System.Drawing.Size(25, 17)
		Me.lblElecAmp.Location = New System.Drawing.Point(24, 72)
		Me.lblElecAmp.TabIndex = 57
		Me.lblElecAmp.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecAmp.BackColor = System.Drawing.SystemColors.Control
		Me.lblElecAmp.Enabled = True
		Me.lblElecAmp.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblElecAmp.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblElecAmp.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblElecAmp.UseMnemonic = True
		Me.lblElecAmp.Visible = True
		Me.lblElecAmp.AutoSize = False
		Me.lblElecAmp.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblElecAmp.Name = "lblElecAmp"
		Me.lblElecV.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblElecV.Text = "v"
		Me.lblElecV.Size = New System.Drawing.Size(9, 17)
		Me.lblElecV.Location = New System.Drawing.Point(360, 56)
		Me.lblElecV.TabIndex = 58
		Me.lblElecV.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecV.BackColor = System.Drawing.SystemColors.Control
		Me.lblElecV.Enabled = True
		Me.lblElecV.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblElecV.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblElecV.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblElecV.UseMnemonic = True
		Me.lblElecV.Visible = True
		Me.lblElecV.AutoSize = False
		Me.lblElecV.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblElecV.Name = "lblElecV"
		Me.lblElecSf.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblElecSf.Text = "sf"
		Me.lblElecSf.Size = New System.Drawing.Size(17, 17)
		Me.lblElecSf.Location = New System.Drawing.Point(240, 56)
		Me.lblElecSf.TabIndex = 59
		Me.lblElecSf.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecSf.BackColor = System.Drawing.SystemColors.Control
		Me.lblElecSf.Enabled = True
		Me.lblElecSf.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblElecSf.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblElecSf.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblElecSf.UseMnemonic = True
		Me.lblElecSf.Visible = True
		Me.lblElecSf.AutoSize = False
		Me.lblElecSf.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblElecSf.Name = "lblElecSf"
		Me.lblElecPhs.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblElecPhs.Text = "phs"
		Me.lblElecPhs.Size = New System.Drawing.Size(25, 17)
		Me.lblElecPhs.Location = New System.Drawing.Point(168, 56)
		Me.lblElecPhs.TabIndex = 60
		Me.lblElecPhs.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecPhs.BackColor = System.Drawing.SystemColors.Control
		Me.lblElecPhs.Enabled = True
		Me.lblElecPhs.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblElecPhs.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblElecPhs.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblElecPhs.UseMnemonic = True
		Me.lblElecPhs.Visible = True
		Me.lblElecPhs.AutoSize = False
		Me.lblElecPhs.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblElecPhs.Name = "lblElecPhs"
		Me.lblElecHz.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblElecHz.Text = "hz"
		Me.lblElecHz.Size = New System.Drawing.Size(17, 17)
		Me.lblElecHz.Location = New System.Drawing.Point(32, 56)
		Me.lblElecHz.TabIndex = 61
		Me.lblElecHz.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecHz.BackColor = System.Drawing.SystemColors.Control
		Me.lblElecHz.Enabled = True
		Me.lblElecHz.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblElecHz.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblElecHz.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblElecHz.UseMnemonic = True
		Me.lblElecHz.Visible = True
		Me.lblElecHz.AutoSize = False
		Me.lblElecHz.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblElecHz.Name = "lblElecHz"
		Me.lblElecRpm.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblElecRpm.Text = "rpm"
		Me.lblElecRpm.Size = New System.Drawing.Size(25, 17)
		Me.lblElecRpm.Location = New System.Drawing.Point(440, 40)
		Me.lblElecRpm.TabIndex = 62
		Me.lblElecRpm.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecRpm.BackColor = System.Drawing.SystemColors.Control
		Me.lblElecRpm.Enabled = True
		Me.lblElecRpm.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblElecRpm.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblElecRpm.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblElecRpm.UseMnemonic = True
		Me.lblElecRpm.Visible = True
		Me.lblElecRpm.AutoSize = False
		Me.lblElecRpm.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblElecRpm.Name = "lblElecRpm"
		Me.lblElecHp.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblElecHp.Text = "hp"
		Me.lblElecHp.Size = New System.Drawing.Size(17, 17)
		Me.lblElecHp.Location = New System.Drawing.Point(360, 40)
		Me.lblElecHp.TabIndex = 63
		Me.lblElecHp.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecHp.BackColor = System.Drawing.SystemColors.Control
		Me.lblElecHp.Enabled = True
		Me.lblElecHp.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblElecHp.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblElecHp.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblElecHp.UseMnemonic = True
		Me.lblElecHp.Visible = True
		Me.lblElecHp.AutoSize = False
		Me.lblElecHp.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblElecHp.Name = "lblElecHp"
		Me.lblElecCatNo.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblElecCatNo.Text = "cat no"
		Me.lblElecCatNo.Size = New System.Drawing.Size(33, 17)
		Me.lblElecCatNo.Location = New System.Drawing.Point(160, 40)
		Me.lblElecCatNo.TabIndex = 64
		Me.lblElecCatNo.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecCatNo.BackColor = System.Drawing.SystemColors.Control
		Me.lblElecCatNo.Enabled = True
		Me.lblElecCatNo.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblElecCatNo.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblElecCatNo.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblElecCatNo.UseMnemonic = True
		Me.lblElecCatNo.Visible = True
		Me.lblElecCatNo.AutoSize = False
		Me.lblElecCatNo.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblElecCatNo.Name = "lblElecCatNo"
		Me.lblElecSerial.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblElecSerial.Text = "serial"
		Me.lblElecSerial.Size = New System.Drawing.Size(33, 17)
		Me.lblElecSerial.Location = New System.Drawing.Point(16, 24)
		Me.lblElecSerial.TabIndex = 65
		Me.lblElecSerial.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecSerial.BackColor = System.Drawing.SystemColors.Control
		Me.lblElecSerial.Enabled = True
		Me.lblElecSerial.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblElecSerial.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblElecSerial.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblElecSerial.UseMnemonic = True
		Me.lblElecSerial.Visible = True
		Me.lblElecSerial.AutoSize = False
		Me.lblElecSerial.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblElecSerial.Name = "lblElecSerial"
		Me.lblElecID.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblElecID.Text = "id"
		Me.lblElecID.Size = New System.Drawing.Size(17, 17)
		Me.lblElecID.Location = New System.Drawing.Point(176, 24)
		Me.lblElecID.TabIndex = 66
		Me.lblElecID.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecID.BackColor = System.Drawing.SystemColors.Control
		Me.lblElecID.Enabled = True
		Me.lblElecID.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblElecID.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblElecID.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblElecID.UseMnemonic = True
		Me.lblElecID.Visible = True
		Me.lblElecID.AutoSize = False
		Me.lblElecID.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblElecID.Name = "lblElecID"
		Me.lblElecModel.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblElecModel.Text = "model"
		Me.lblElecModel.Size = New System.Drawing.Size(33, 17)
		Me.lblElecModel.Location = New System.Drawing.Point(344, 24)
		Me.lblElecModel.TabIndex = 67
		Me.lblElecModel.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecModel.BackColor = System.Drawing.SystemColors.Control
		Me.lblElecModel.Enabled = True
		Me.lblElecModel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblElecModel.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblElecModel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblElecModel.UseMnemonic = True
		Me.lblElecModel.Visible = True
		Me.lblElecModel.AutoSize = False
		Me.lblElecModel.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblElecModel.Name = "lblElecModel"
		Me.lblElecFrame.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblElecFrame.Text = "frame"
		Me.lblElecFrame.Size = New System.Drawing.Size(33, 17)
		Me.lblElecFrame.Location = New System.Drawing.Point(16, 40)
		Me.lblElecFrame.TabIndex = 68
		Me.lblElecFrame.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecFrame.BackColor = System.Drawing.SystemColors.Control
		Me.lblElecFrame.Enabled = True
		Me.lblElecFrame.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblElecFrame.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblElecFrame.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblElecFrame.UseMnemonic = True
		Me.lblElecFrame.Visible = True
		Me.lblElecFrame.AutoSize = False
		Me.lblElecFrame.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblElecFrame.Name = "lblElecFrame"
		Me._SSTab1_TabPage2.Text = "Work Order"
		Me.txtTaskMiscCommentsD.AutoSize = False
		Me.txtTaskMiscCommentsD.Size = New System.Drawing.Size(433, 51)
		Me.txtTaskMiscCommentsD.Location = New System.Drawing.Point(96, 136)
		Me.txtTaskMiscCommentsD.ReadOnly = True
		Me.txtTaskMiscCommentsD.MultiLine = True
		Me.txtTaskMiscCommentsD.TabIndex = 10
		Me.txtTaskMiscCommentsD.TabStop = False
		Me.txtTaskMiscCommentsD.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtTaskMiscCommentsD.AcceptsReturn = True
		Me.txtTaskMiscCommentsD.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtTaskMiscCommentsD.BackColor = System.Drawing.SystemColors.Window
		Me.txtTaskMiscCommentsD.CausesValidation = True
		Me.txtTaskMiscCommentsD.Enabled = True
		Me.txtTaskMiscCommentsD.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtTaskMiscCommentsD.HideSelection = True
		Me.txtTaskMiscCommentsD.Maxlength = 0
		Me.txtTaskMiscCommentsD.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtTaskMiscCommentsD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtTaskMiscCommentsD.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtTaskMiscCommentsD.Visible = True
		Me.txtTaskMiscCommentsD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtTaskMiscCommentsD.Name = "txtTaskMiscCommentsD"
		Me.lblWorkDueDateD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblWorkDueDateD.Size = New System.Drawing.Size(89, 17)
		Me.lblWorkDueDateD.Location = New System.Drawing.Point(104, 104)
		Me.lblWorkDueDateD.TabIndex = 134
		Me.lblWorkDueDateD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblWorkDueDateD.BackColor = System.Drawing.SystemColors.Control
		Me.lblWorkDueDateD.Enabled = True
		Me.lblWorkDueDateD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblWorkDueDateD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblWorkDueDateD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblWorkDueDateD.UseMnemonic = True
		Me.lblWorkDueDateD.Visible = True
		Me.lblWorkDueDateD.AutoSize = False
		Me.lblWorkDueDateD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblWorkDueDateD.Name = "lblWorkDueDateD"
		Me.lblWorkDueWhenMeterReadsD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblWorkDueWhenMeterReadsD.Size = New System.Drawing.Size(89, 17)
		Me.lblWorkDueWhenMeterReadsD.Location = New System.Drawing.Point(408, 88)
		Me.lblWorkDueWhenMeterReadsD.TabIndex = 133
		Me.lblWorkDueWhenMeterReadsD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblWorkDueWhenMeterReadsD.BackColor = System.Drawing.SystemColors.Control
		Me.lblWorkDueWhenMeterReadsD.Enabled = True
		Me.lblWorkDueWhenMeterReadsD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblWorkDueWhenMeterReadsD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblWorkDueWhenMeterReadsD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblWorkDueWhenMeterReadsD.UseMnemonic = True
		Me.lblWorkDueWhenMeterReadsD.Visible = True
		Me.lblWorkDueWhenMeterReadsD.AutoSize = False
		Me.lblWorkDueWhenMeterReadsD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblWorkDueWhenMeterReadsD.Name = "lblWorkDueWhenMeterReadsD"
		Me.lblWorkDueDate.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblWorkDueDate.Text = "Work Due Date"
		Me.lblWorkDueDate.Size = New System.Drawing.Size(81, 17)
		Me.lblWorkDueDate.Location = New System.Drawing.Point(16, 104)
		Me.lblWorkDueDate.TabIndex = 132
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
		Me.lblWorkDueWhenMeterReads.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblWorkDueWhenMeterReads.Text = "Work Due When Meter Reads"
		Me.lblWorkDueWhenMeterReads.Size = New System.Drawing.Size(153, 17)
		Me.lblWorkDueWhenMeterReads.Location = New System.Drawing.Point(248, 88)
		Me.lblWorkDueWhenMeterReads.TabIndex = 131
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
		Me.lblCreatedbyD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblCreatedbyD.Size = New System.Drawing.Size(89, 17)
		Me.lblCreatedbyD.Location = New System.Drawing.Point(104, 88)
		Me.lblCreatedbyD.TabIndex = 128
		Me.lblCreatedbyD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblCreatedbyD.BackColor = System.Drawing.SystemColors.Control
		Me.lblCreatedbyD.Enabled = True
		Me.lblCreatedbyD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblCreatedbyD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblCreatedbyD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblCreatedbyD.UseMnemonic = True
		Me.lblCreatedbyD.Visible = True
		Me.lblCreatedbyD.AutoSize = False
		Me.lblCreatedbyD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblCreatedbyD.Name = "lblCreatedbyD"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label1.Text = "Created by"
		Me.Label1.Size = New System.Drawing.Size(81, 17)
		Me.Label1.Location = New System.Drawing.Point(16, 88)
		Me.Label1.TabIndex = 127
		Me.Label1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
		Me.lblTaskToolsRequiredD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTaskToolsRequiredD.Size = New System.Drawing.Size(425, 17)
		Me.lblTaskToolsRequiredD.Location = New System.Drawing.Point(104, 120)
		Me.lblTaskToolsRequiredD.TabIndex = 124
		Me.lblTaskToolsRequiredD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblTaskToolsRequiredD.BackColor = System.Drawing.SystemColors.Control
		Me.lblTaskToolsRequiredD.Enabled = True
		Me.lblTaskToolsRequiredD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblTaskToolsRequiredD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblTaskToolsRequiredD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblTaskToolsRequiredD.UseMnemonic = True
		Me.lblTaskToolsRequiredD.Visible = True
		Me.lblTaskToolsRequiredD.AutoSize = False
		Me.lblTaskToolsRequiredD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblTaskToolsRequiredD.Name = "lblTaskToolsRequiredD"
		Me.lblTaskLoToD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTaskLoToD.Size = New System.Drawing.Size(105, 17)
		Me.lblTaskLoToD.Location = New System.Drawing.Point(408, 56)
		Me.lblTaskLoToD.TabIndex = 123
		Me.lblTaskLoToD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblTaskLoToD.BackColor = System.Drawing.SystemColors.Control
		Me.lblTaskLoToD.Enabled = True
		Me.lblTaskLoToD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblTaskLoToD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblTaskLoToD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblTaskLoToD.UseMnemonic = True
		Me.lblTaskLoToD.Visible = True
		Me.lblTaskLoToD.AutoSize = False
		Me.lblTaskLoToD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblTaskLoToD.Name = "lblTaskLoToD"
		Me.lblTaskLastWorkedMeterD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTaskLastWorkedMeterD.Size = New System.Drawing.Size(81, 17)
		Me.lblTaskLastWorkedMeterD.Location = New System.Drawing.Point(408, 72)
		Me.lblTaskLastWorkedMeterD.TabIndex = 122
		Me.lblTaskLastWorkedMeterD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblTaskLastWorkedMeterD.BackColor = System.Drawing.SystemColors.Control
		Me.lblTaskLastWorkedMeterD.Enabled = True
		Me.lblTaskLastWorkedMeterD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblTaskLastWorkedMeterD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblTaskLastWorkedMeterD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblTaskLastWorkedMeterD.UseMnemonic = True
		Me.lblTaskLastWorkedMeterD.Visible = True
		Me.lblTaskLastWorkedMeterD.AutoSize = False
		Me.lblTaskLastWorkedMeterD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblTaskLastWorkedMeterD.Name = "lblTaskLastWorkedMeterD"
		Me.lblTaskLastWorkedDateD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTaskLastWorkedDateD.Size = New System.Drawing.Size(89, 17)
		Me.lblTaskLastWorkedDateD.Location = New System.Drawing.Point(104, 72)
		Me.lblTaskLastWorkedDateD.TabIndex = 121
		Me.lblTaskLastWorkedDateD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblTaskLastWorkedDateD.BackColor = System.Drawing.SystemColors.Control
		Me.lblTaskLastWorkedDateD.Enabled = True
		Me.lblTaskLastWorkedDateD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblTaskLastWorkedDateD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblTaskLastWorkedDateD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblTaskLastWorkedDateD.UseMnemonic = True
		Me.lblTaskLastWorkedDateD.Visible = True
		Me.lblTaskLastWorkedDateD.AutoSize = False
		Me.lblTaskLastWorkedDateD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblTaskLastWorkedDateD.Name = "lblTaskLastWorkedDateD"
		Me.lblTaskIntervalDaysD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTaskIntervalDaysD.Size = New System.Drawing.Size(81, 17)
		Me.lblTaskIntervalDaysD.Location = New System.Drawing.Point(408, 40)
		Me.lblTaskIntervalDaysD.TabIndex = 120
		Me.lblTaskIntervalDaysD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblTaskIntervalDaysD.BackColor = System.Drawing.SystemColors.Control
		Me.lblTaskIntervalDaysD.Enabled = True
		Me.lblTaskIntervalDaysD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblTaskIntervalDaysD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblTaskIntervalDaysD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblTaskIntervalDaysD.UseMnemonic = True
		Me.lblTaskIntervalDaysD.Visible = True
		Me.lblTaskIntervalDaysD.AutoSize = False
		Me.lblTaskIntervalDaysD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblTaskIntervalDaysD.Name = "lblTaskIntervalDaysD"
		Me.lblTaskIntervalMeterD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTaskIntervalMeterD.Size = New System.Drawing.Size(81, 17)
		Me.lblTaskIntervalMeterD.Location = New System.Drawing.Point(104, 56)
		Me.lblTaskIntervalMeterD.TabIndex = 119
		Me.lblTaskIntervalMeterD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblTaskIntervalMeterD.BackColor = System.Drawing.SystemColors.Control
		Me.lblTaskIntervalMeterD.Enabled = True
		Me.lblTaskIntervalMeterD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblTaskIntervalMeterD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblTaskIntervalMeterD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblTaskIntervalMeterD.UseMnemonic = True
		Me.lblTaskIntervalMeterD.Visible = True
		Me.lblTaskIntervalMeterD.AutoSize = False
		Me.lblTaskIntervalMeterD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblTaskIntervalMeterD.Name = "lblTaskIntervalMeterD"
		Me.lblTaskPriorityD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTaskPriorityD.Size = New System.Drawing.Size(81, 17)
		Me.lblTaskPriorityD.Location = New System.Drawing.Point(256, 40)
		Me.lblTaskPriorityD.TabIndex = 118
		Me.lblTaskPriorityD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblTaskPriorityD.BackColor = System.Drawing.SystemColors.Control
		Me.lblTaskPriorityD.Enabled = True
		Me.lblTaskPriorityD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblTaskPriorityD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblTaskPriorityD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblTaskPriorityD.UseMnemonic = True
		Me.lblTaskPriorityD.Visible = True
		Me.lblTaskPriorityD.AutoSize = False
		Me.lblTaskPriorityD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblTaskPriorityD.Name = "lblTaskPriorityD"
		Me.lblTaskCycleTypeD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTaskCycleTypeD.Size = New System.Drawing.Size(97, 17)
		Me.lblTaskCycleTypeD.Location = New System.Drawing.Point(104, 40)
		Me.lblTaskCycleTypeD.TabIndex = 117
		Me.lblTaskCycleTypeD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblTaskCycleTypeD.BackColor = System.Drawing.SystemColors.Control
		Me.lblTaskCycleTypeD.Enabled = True
		Me.lblTaskCycleTypeD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblTaskCycleTypeD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblTaskCycleTypeD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblTaskCycleTypeD.UseMnemonic = True
		Me.lblTaskCycleTypeD.Visible = True
		Me.lblTaskCycleTypeD.AutoSize = False
		Me.lblTaskCycleTypeD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblTaskCycleTypeD.Name = "lblTaskCycleTypeD"
		Me.lblTaskTaskDescD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTaskTaskDescD.Size = New System.Drawing.Size(417, 17)
		Me.lblTaskTaskDescD.Location = New System.Drawing.Point(104, 24)
		Me.lblTaskTaskDescD.TabIndex = 116
		Me.lblTaskTaskDescD.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblTaskTaskDescD.BackColor = System.Drawing.SystemColors.Control
		Me.lblTaskTaskDescD.Enabled = True
		Me.lblTaskTaskDescD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblTaskTaskDescD.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblTaskTaskDescD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblTaskTaskDescD.UseMnemonic = True
		Me.lblTaskTaskDescD.Visible = True
		Me.lblTaskTaskDescD.AutoSize = False
		Me.lblTaskTaskDescD.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblTaskTaskDescD.Name = "lblTaskTaskDescD"
		Me.lblMiscComments.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblMiscComments.Text = "Comments"
		Me.lblMiscComments.Size = New System.Drawing.Size(81, 17)
		Me.lblMiscComments.Location = New System.Drawing.Point(8, 136)
		Me.lblMiscComments.TabIndex = 30
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
		Me.lblLoTo.Text = "Lockout/Tagout"
		Me.lblLoTo.Size = New System.Drawing.Size(81, 17)
		Me.lblLoTo.Location = New System.Drawing.Point(320, 56)
		Me.lblLoTo.TabIndex = 29
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
		Me.lblLastWorkedDate.Text = "Last Worked Date"
		Me.lblLastWorkedDate.Size = New System.Drawing.Size(89, 17)
		Me.lblLastWorkedDate.Location = New System.Drawing.Point(8, 72)
		Me.lblLastWorkedDate.TabIndex = 28
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
		Me.lblLastWorkedMeterReading.Text = "Last Worked Meter Reading"
		Me.lblLastWorkedMeterReading.Size = New System.Drawing.Size(137, 17)
		Me.lblLastWorkedMeterReading.Location = New System.Drawing.Point(264, 72)
		Me.lblLastWorkedMeterReading.TabIndex = 27
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
		Me.lblToolsRequired.Text = "Tools Required"
		Me.lblToolsRequired.Size = New System.Drawing.Size(81, 17)
		Me.lblToolsRequired.Location = New System.Drawing.Point(16, 120)
		Me.lblToolsRequired.TabIndex = 26
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
		Me.lblIntervalMeter.Text = "Interval Meter"
		Me.lblIntervalMeter.Size = New System.Drawing.Size(73, 17)
		Me.lblIntervalMeter.Location = New System.Drawing.Point(24, 56)
		Me.lblIntervalMeter.TabIndex = 25
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
		Me.lblIntervalDays.Text = "Interval Days"
		Me.lblIntervalDays.Size = New System.Drawing.Size(65, 17)
		Me.lblIntervalDays.Location = New System.Drawing.Point(336, 40)
		Me.lblIntervalDays.TabIndex = 24
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
		Me.lblCycleType.Text = "Cycle Type"
		Me.lblCycleType.Size = New System.Drawing.Size(81, 17)
		Me.lblCycleType.Location = New System.Drawing.Point(16, 40)
		Me.lblCycleType.TabIndex = 23
		Me.lblCycleType.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
		Me.lblPriority.Text = "Priority"
		Me.lblPriority.Size = New System.Drawing.Size(41, 17)
		Me.lblPriority.Location = New System.Drawing.Point(208, 40)
		Me.lblPriority.TabIndex = 22
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
		Me.lblTaskDesc.Text = "WO Description"
		Me.lblTaskDesc.Size = New System.Drawing.Size(81, 17)
		Me.lblTaskDesc.Location = New System.Drawing.Point(16, 24)
		Me.lblTaskDesc.TabIndex = 21
		Me.lblTaskDesc.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
		Me.lblPlantName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblPlantName.Size = New System.Drawing.Size(185, 17)
		Me.lblPlantName.Location = New System.Drawing.Point(0, 0)
		Me.lblPlantName.TabIndex = 130
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
		Me.lblComments.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblComments.Text = "Comments:"
		Me.lblComments.Size = New System.Drawing.Size(65, 17)
		Me.lblComments.Location = New System.Drawing.Point(38, 128)
		Me.lblComments.TabIndex = 19
		Me.lblComments.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblComments.BackColor = System.Drawing.SystemColors.Control
		Me.lblComments.Enabled = True
		Me.lblComments.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblComments.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblComments.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblComments.UseMnemonic = True
		Me.lblComments.Visible = True
		Me.lblComments.AutoSize = False
		Me.lblComments.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblComments.Name = "lblComments"
		Me.lblMaterialsCost.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblMaterialsCost.Text = "Materials Cost $:"
		Me.lblMaterialsCost.Size = New System.Drawing.Size(81, 17)
		Me.lblMaterialsCost.Location = New System.Drawing.Point(404, 104)
		Me.lblMaterialsCost.TabIndex = 18
		Me.lblMaterialsCost.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMaterialsCost.BackColor = System.Drawing.SystemColors.Control
		Me.lblMaterialsCost.Enabled = True
		Me.lblMaterialsCost.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMaterialsCost.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMaterialsCost.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMaterialsCost.UseMnemonic = True
		Me.lblMaterialsCost.Visible = True
		Me.lblMaterialsCost.AutoSize = False
		Me.lblMaterialsCost.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMaterialsCost.Name = "lblMaterialsCost"
		Me.lblLaborCost.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblLaborCost.Text = "Labor:"
		Me.lblLaborCost.Size = New System.Drawing.Size(33, 17)
		Me.lblLaborCost.Location = New System.Drawing.Point(312, 104)
		Me.lblLaborCost.TabIndex = 16
		Me.lblLaborCost.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblLaborCost.BackColor = System.Drawing.SystemColors.Control
		Me.lblLaborCost.Enabled = True
		Me.lblLaborCost.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblLaborCost.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblLaborCost.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblLaborCost.UseMnemonic = True
		Me.lblLaborCost.Visible = True
		Me.lblLaborCost.AutoSize = False
		Me.lblLaborCost.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblLaborCost.Name = "lblLaborCost"
		Me.lblCompletedBy.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblCompletedBy.Text = "Completed by:"
		Me.lblCompletedBy.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblCompletedBy.Size = New System.Drawing.Size(81, 17)
		Me.lblCompletedBy.Location = New System.Drawing.Point(22, 104)
		Me.lblCompletedBy.TabIndex = 15
		Me.lblCompletedBy.BackColor = System.Drawing.SystemColors.Control
		Me.lblCompletedBy.Enabled = True
		Me.lblCompletedBy.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblCompletedBy.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblCompletedBy.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblCompletedBy.UseMnemonic = True
		Me.lblCompletedBy.Visible = True
		Me.lblCompletedBy.AutoSize = False
		Me.lblCompletedBy.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblCompletedBy.Name = "lblCompletedBy"
		Me.lblDateCompleted.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblDateCompleted.Text = "Date Completed:"
		Me.lblDateCompleted.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblDateCompleted.Size = New System.Drawing.Size(97, 17)
		Me.lblDateCompleted.Location = New System.Drawing.Point(6, 80)
		Me.lblDateCompleted.TabIndex = 14
		Me.lblDateCompleted.BackColor = System.Drawing.SystemColors.Control
		Me.lblDateCompleted.Enabled = True
		Me.lblDateCompleted.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblDateCompleted.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDateCompleted.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDateCompleted.UseMnemonic = True
		Me.lblDateCompleted.Visible = True
		Me.lblDateCompleted.AutoSize = False
		Me.lblDateCompleted.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblDateCompleted.Name = "lblDateCompleted"
		Me.lblMeterReadingatWorkCompletion.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblMeterReadingatWorkCompletion.Text = "Meter Read at Completion:"
		Me.lblMeterReadingatWorkCompletion.Size = New System.Drawing.Size(129, 17)
		Me.lblMeterReadingatWorkCompletion.Location = New System.Drawing.Point(336, 80)
		Me.lblMeterReadingatWorkCompletion.TabIndex = 13
		Me.lblMeterReadingatWorkCompletion.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMeterReadingatWorkCompletion.BackColor = System.Drawing.SystemColors.Control
		Me.lblMeterReadingatWorkCompletion.Enabled = True
		Me.lblMeterReadingatWorkCompletion.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMeterReadingatWorkCompletion.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMeterReadingatWorkCompletion.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMeterReadingatWorkCompletion.UseMnemonic = True
		Me.lblMeterReadingatWorkCompletion.Visible = True
		Me.lblMeterReadingatWorkCompletion.AutoSize = False
		Me.lblMeterReadingatWorkCompletion.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMeterReadingatWorkCompletion.Name = "lblMeterReadingatWorkCompletion"
		Me.lblTaskID.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblTaskID.Text = "Work Order:"
		Me.lblTaskID.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTaskID.Size = New System.Drawing.Size(81, 17)
		Me.lblTaskID.Location = New System.Drawing.Point(22, 56)
		Me.lblTaskID.TabIndex = 12
		Me.lblTaskID.BackColor = System.Drawing.SystemColors.Control
		Me.lblTaskID.Enabled = True
		Me.lblTaskID.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblTaskID.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblTaskID.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblTaskID.UseMnemonic = True
		Me.lblTaskID.Visible = True
		Me.lblTaskID.AutoSize = False
		Me.lblTaskID.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblTaskID.Name = "lblTaskID"
		Me.lblEquipID.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblEquipID.Text = "Equipment:"
		Me.lblEquipID.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblEquipID.Size = New System.Drawing.Size(73, 17)
		Me.lblEquipID.Location = New System.Drawing.Point(30, 32)
		Me.lblEquipID.TabIndex = 11
		Me.lblEquipID.BackColor = System.Drawing.SystemColors.Control
		Me.lblEquipID.Enabled = True
		Me.lblEquipID.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblEquipID.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblEquipID.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblEquipID.UseMnemonic = True
		Me.lblEquipID.Visible = True
		Me.lblEquipID.AutoSize = False
		Me.lblEquipID.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblEquipID.Name = "lblEquipID"
		Me.FramGrid.Size = New System.Drawing.Size(561, 393)
		Me.FramGrid.Location = New System.Drawing.Point(16, 0)
		Me.FramGrid.TabIndex = 9
		Me.FramGrid.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.FramGrid.BackColor = System.Drawing.SystemColors.Control
		Me.FramGrid.Enabled = True
		Me.FramGrid.ForeColor = System.Drawing.SystemColors.ControlText
		Me.FramGrid.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.FramGrid.Visible = True
		Me.FramGrid.Name = "FramGrid"
		DGridWO.OcxState = CType(resources.GetObject("DGridWO.OcxState"), System.Windows.Forms.AxHost.State)
		Me.DGridWO.Size = New System.Drawing.Size(545, 369)
		Me.DGridWO.Location = New System.Drawing.Point(8, 16)
		Me.DGridWO.TabIndex = 125
		Me.DGridWO.Name = "DGridWO"
		Me.lblPlantNameG.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblPlantNameG.Size = New System.Drawing.Size(121, 17)
		Me.lblPlantNameG.Location = New System.Drawing.Point(0, 0)
		Me.lblPlantNameG.TabIndex = 129
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
		Me.Controls.Add(FramForm)
		Me.Controls.Add(FramGrid)
		Me.FramForm.Controls.Add(txtComments)
		Me.FramForm.Controls.Add(txtMaterialsCost)
		Me.FramForm.Controls.Add(cboTaskID)
		Me.FramForm.Controls.Add(cboEquipID)
		Me.FramForm.Controls.Add(txtCount)
		Me.FramForm.Controls.Add(txtLabor)
		Me.FramForm.Controls.Add(txtCompletedBy)
		Me.FramForm.Controls.Add(txtMeterReadingAtCompletion)
		Me.FramForm.Controls.Add(txtDateCompleted)
		Me.FramForm.Controls.Add(SSTab1)
		Me.FramForm.Controls.Add(lblPlantName)
		Me.FramForm.Controls.Add(lblComments)
		Me.FramForm.Controls.Add(lblMaterialsCost)
		Me.FramForm.Controls.Add(lblLaborCost)
		Me.FramForm.Controls.Add(lblCompletedBy)
		Me.FramForm.Controls.Add(lblDateCompleted)
		Me.FramForm.Controls.Add(lblMeterReadingatWorkCompletion)
		Me.FramForm.Controls.Add(lblTaskID)
		Me.FramForm.Controls.Add(lblEquipID)
		Me.SSTab1.Controls.Add(_SSTab1_TabPage0)
		Me.SSTab1.Controls.Add(_SSTab1_TabPage1)
		Me.SSTab1.Controls.Add(_SSTab1_TabPage2)
		Me._SSTab1_TabPage0.Controls.Add(lblMechIDD)
		Me._SSTab1_TabPage0.Controls.Add(lblMechModelD)
		Me._SSTab1_TabPage0.Controls.Add(lblMechFrameD)
		Me._SSTab1_TabPage0.Controls.Add(lblMechRecomSparePartsD)
		Me._SSTab1_TabPage0.Controls.Add(lblMechMiscNPDataD)
		Me._SSTab1_TabPage0.Controls.Add(lblMechNoValvesTypesD)
		Me._SSTab1_TabPage0.Controls.Add(lblMechPipeTypeD)
		Me._SSTab1_TabPage0.Controls.Add(lblMechPipeSizeD)
		Me._SSTab1_TabPage0.Controls.Add(lblMechBelt2D)
		Me._SSTab1_TabPage0.Controls.Add(lblMechBelt1D)
		Me._SSTab1_TabPage0.Controls.Add(lblMechAirFilterD)
		Me._SSTab1_TabPage0.Controls.Add(lblMechOilFilterD)
		Me._SSTab1_TabPage0.Controls.Add(lblMechOilD)
		Me._SSTab1_TabPage0.Controls.Add(lblMechCfmD)
		Me._SSTab1_TabPage0.Controls.Add(lblMechMinRpmD)
		Me._SSTab1_TabPage0.Controls.Add(lblMechMaxRpmD)
		Me._SSTab1_TabPage0.Controls.Add(lblMechCatNoD)
		Me._SSTab1_TabPage0.Controls.Add(lblMechTdhD)
		Me._SSTab1_TabPage0.Controls.Add(lblMechSizeD)
		Me._SSTab1_TabPage0.Controls.Add(lblMechCapD)
		Me._SSTab1_TabPage0.Controls.Add(lblMechRpmD)
		Me._SSTab1_TabPage0.Controls.Add(lblMechImpSzD)
		Me._SSTab1_TabPage0.Controls.Add(lblMechSerialD)
		Me._SSTab1_TabPage0.Controls.Add(lblMechRecomSpareParts)
		Me._SSTab1_TabPage0.Controls.Add(lblMechMiscNPData)
		Me._SSTab1_TabPage0.Controls.Add(lblMechNoValvesTypes)
		Me._SSTab1_TabPage0.Controls.Add(lblMechPipeType)
		Me._SSTab1_TabPage0.Controls.Add(lblMechPipeSize)
		Me._SSTab1_TabPage0.Controls.Add(lblMechcfm)
		Me._SSTab1_TabPage0.Controls.Add(lblMechMaxRpm)
		Me._SSTab1_TabPage0.Controls.Add(lblMechMinRpm)
		Me._SSTab1_TabPage0.Controls.Add(lblMechCatNo)
		Me._SSTab1_TabPage0.Controls.Add(lblMechSize)
		Me._SSTab1_TabPage0.Controls.Add(lblMechtdh)
		Me._SSTab1_TabPage0.Controls.Add(lblMechCap)
		Me._SSTab1_TabPage0.Controls.Add(lblMechRpm)
		Me._SSTab1_TabPage0.Controls.Add(lblMechHp)
		Me._SSTab1_TabPage0.Controls.Add(lblMechImpSz)
		Me._SSTab1_TabPage0.Controls.Add(lblMechFrame)
		Me._SSTab1_TabPage0.Controls.Add(lblMechModel)
		Me._SSTab1_TabPage0.Controls.Add(lblMechID)
		Me._SSTab1_TabPage0.Controls.Add(lblMechSerial)
		Me._SSTab1_TabPage0.Controls.Add(lblMechOil)
		Me._SSTab1_TabPage0.Controls.Add(lblMechOilFilter)
		Me._SSTab1_TabPage0.Controls.Add(lblMechAirFilter)
		Me._SSTab1_TabPage0.Controls.Add(lblMechBelt1)
		Me._SSTab1_TabPage0.Controls.Add(lblMechBelt2)
		Me._SSTab1_TabPage0.Controls.Add(lblMechHpD)
		Me._SSTab1_TabPage1.Controls.Add(lblElecMiscNPDataD)
		Me._SSTab1_TabPage1.Controls.Add(lblElecRecomSparePartsD)
		Me._SSTab1_TabPage1.Controls.Add(lblElecOppEndBrgD)
		Me._SSTab1_TabPage1.Controls.Add(lblElecShaftEndBrgD)
		Me._SSTab1_TabPage1.Controls.Add(lblElecDesignD)
		Me._SSTab1_TabPage1.Controls.Add(lblElecInslClD)
		Me._SSTab1_TabPage1.Controls.Add(lblElecAmpD)
		Me._SSTab1_TabPage1.Controls.Add(lblElecVD)
		Me._SSTab1_TabPage1.Controls.Add(lblElecDutyD)
		Me._SSTab1_TabPage1.Controls.Add(lblElecSfD)
		Me._SSTab1_TabPage1.Controls.Add(lblElecPhsD)
		Me._SSTab1_TabPage1.Controls.Add(lblElecHzD)
		Me._SSTab1_TabPage1.Controls.Add(lblElecRpmD)
		Me._SSTab1_TabPage1.Controls.Add(lblElecHpD)
		Me._SSTab1_TabPage1.Controls.Add(lblElecCatNoD)
		Me._SSTab1_TabPage1.Controls.Add(lblElecFrameD)
		Me._SSTab1_TabPage1.Controls.Add(lblElecSerialD)
		Me._SSTab1_TabPage1.Controls.Add(lblElecModelD)
		Me._SSTab1_TabPage1.Controls.Add(lblElecIDD)
		Me._SSTab1_TabPage1.Controls.Add(lblElecRecomSpareParts)
		Me._SSTab1_TabPage1.Controls.Add(lblElecMiscNPData)
		Me._SSTab1_TabPage1.Controls.Add(lblElecOppEndBrg)
		Me._SSTab1_TabPage1.Controls.Add(lblElecShaftEndBrg)
		Me._SSTab1_TabPage1.Controls.Add(lblElecDesign)
		Me._SSTab1_TabPage1.Controls.Add(lblElecInslCl)
		Me._SSTab1_TabPage1.Controls.Add(lblElecDuty)
		Me._SSTab1_TabPage1.Controls.Add(lblElecAmp)
		Me._SSTab1_TabPage1.Controls.Add(lblElecV)
		Me._SSTab1_TabPage1.Controls.Add(lblElecSf)
		Me._SSTab1_TabPage1.Controls.Add(lblElecPhs)
		Me._SSTab1_TabPage1.Controls.Add(lblElecHz)
		Me._SSTab1_TabPage1.Controls.Add(lblElecRpm)
		Me._SSTab1_TabPage1.Controls.Add(lblElecHp)
		Me._SSTab1_TabPage1.Controls.Add(lblElecCatNo)
		Me._SSTab1_TabPage1.Controls.Add(lblElecSerial)
		Me._SSTab1_TabPage1.Controls.Add(lblElecID)
		Me._SSTab1_TabPage1.Controls.Add(lblElecModel)
		Me._SSTab1_TabPage1.Controls.Add(lblElecFrame)
		Me._SSTab1_TabPage2.Controls.Add(txtTaskMiscCommentsD)
		Me._SSTab1_TabPage2.Controls.Add(lblWorkDueDateD)
		Me._SSTab1_TabPage2.Controls.Add(lblWorkDueWhenMeterReadsD)
		Me._SSTab1_TabPage2.Controls.Add(lblWorkDueDate)
		Me._SSTab1_TabPage2.Controls.Add(lblWorkDueWhenMeterReads)
		Me._SSTab1_TabPage2.Controls.Add(lblCreatedbyD)
		Me._SSTab1_TabPage2.Controls.Add(Label1)
		Me._SSTab1_TabPage2.Controls.Add(lblTaskToolsRequiredD)
		Me._SSTab1_TabPage2.Controls.Add(lblTaskLoToD)
		Me._SSTab1_TabPage2.Controls.Add(lblTaskLastWorkedMeterD)
		Me._SSTab1_TabPage2.Controls.Add(lblTaskLastWorkedDateD)
		Me._SSTab1_TabPage2.Controls.Add(lblTaskIntervalDaysD)
		Me._SSTab1_TabPage2.Controls.Add(lblTaskIntervalMeterD)
		Me._SSTab1_TabPage2.Controls.Add(lblTaskPriorityD)
		Me._SSTab1_TabPage2.Controls.Add(lblTaskCycleTypeD)
		Me._SSTab1_TabPage2.Controls.Add(lblTaskTaskDescD)
		Me._SSTab1_TabPage2.Controls.Add(lblMiscComments)
		Me._SSTab1_TabPage2.Controls.Add(lblLoTo)
		Me._SSTab1_TabPage2.Controls.Add(lblLastWorkedDate)
		Me._SSTab1_TabPage2.Controls.Add(lblLastWorkedMeterReading)
		Me._SSTab1_TabPage2.Controls.Add(lblToolsRequired)
		Me._SSTab1_TabPage2.Controls.Add(lblIntervalMeter)
		Me._SSTab1_TabPage2.Controls.Add(lblIntervalDays)
		Me._SSTab1_TabPage2.Controls.Add(lblCycleType)
		Me._SSTab1_TabPage2.Controls.Add(lblPriority)
		Me._SSTab1_TabPage2.Controls.Add(lblTaskDesc)
		Me.FramGrid.Controls.Add(DGridWO)
		Me.FramGrid.Controls.Add(lblPlantNameG)
		CType(Me.DGridWO, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.txtDateCompleted, System.ComponentModel.ISupportInitialize).EndInit()
	End Sub
#End Region 
#Region "Upgrade Support "
	Private Shared m_vb6FormDefInstance As frmWorkOrder
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmWorkOrder
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmWorkOrder()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
	
	Dim rsWORetrieve As ADODB.Recordset
	Public rsEquipWO As ADODB.Recordset
	Public rsTaskWO As ADODB.Recordset
	Dim ans As Short
	Dim intStatus As Short ' 2 - add, 1 - update
	'Dim intTypeWO As Integer ' 1 - new, 2 - existing recordset
	Dim intEquipIDStore As Object
	Dim intTaskIDStore As Short
	Dim strEquipIDStore As Object
	Dim strTaskIDStore As String
	
	' ***************************************
	' Used for searching WOs
	' ***************************************
	Dim strSearchEquipKey As Object
	Dim strSearchEquipDesc As String
	Dim strSearchTaskDesc, strSearchMiscComments As Object
	Dim strSearchComments As String
	Dim strSearchInitial, strSearchDate1 As Object
	Dim strSearchDate2 As String
	Dim strState As Object
	Dim strSearchOpt As String
	
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
	
	Private Sub cboEquipID_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles cboEquipID.KeyUp
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim intKey As Short
		Dim intValue As Short
		
		On Error GoTo errorhandler
		
		intKey = KeyCode
		If (intKey < 48 Or intKey > 57) And intKey <> 119 And intKey <> 121 And intKey <> 120 And intKey <> 122 And intKey <> 13 Then
			MsgBox("Equipment field can only have numbers")
			'UPGRADE_WARNING: Couldn't resolve default property of object intEquipIDStore. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			If intEquipIDStore <> 0 Then
				'UPGRADE_WARNING: Couldn't resolve default property of object intEquipIDStore. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				Me.cboEquipID.Text = intEquipIDStore
			End If
		End If
		If intStatus <> 2 Then
			MsgBox("Value can not be changed after History is created and saved")
			'UPGRADE_WARNING: Couldn't resolve default property of object intEquipIDStore. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			If intEquipIDStore <> 0 Then
				'UPGRADE_WARNING: Couldn't resolve default property of object intEquipIDStore. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				Me.cboEquipID.Text = intEquipIDStore
			End If
		End If
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: WO - cboEquipID_KeyUp: Description - " & Err.Description)
	End Sub
	
	Private Sub cboEquipID_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles cboEquipID.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		Dim ans As Short
		Dim intPos As Short
		Dim strNum As String
		Dim intLen As Short
		Dim strEquipID As String
		Dim intEquipID As Short
		
		On Error GoTo errorhandler
		
		
		If cboEquipID.Text = "" Then
			Beep()
			ans = MsgBox("Please select an equipment from the dropdown.", MsgBoxStyle.OKOnly, "WOS")
			Cancel = True
		Else
			strEquipID = cboEquipID.Text
			strEquipID = Trim(strEquipID)
			intLen = Len(strEquipID)
			intPos = InStr(strEquipID, " - ")
			If intPos = 0 Then
				strNum = strEquipID
			Else
				strNum = VB.Left(strEquipID, intPos - 1)
			End If
			intEquipID = CShort(strNum)
			rsEquipWO.MoveFirst()
			rsEquipWO.Find(("equip_id = " & intEquipID))
			If rsEquipWO.EOF = True Or rsEquipWO.BOF = True Then
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
				'UPGRADE_WARNING: Couldn't resolve default property of object intEquipIDStore. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				If intEquipID <> intEquipIDStore And intEquipIDStore <> 0 Then
					If intStatus <> 2 Then
						MsgBox("Value can not be changed after a History is created and saved")
						'UPGRADE_WARNING: Couldn't resolve default property of object intEquipIDStore. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
						Me.cboEquipID.Text = intEquipIDStore
					End If
					'ans = MsgBox("Are you sure that you want to change equipment? Every thing has to be reset if you continue.", vbYesNo)
					'If ans = 6 Then
					'    Clear
					'    rsEquipWO.Find ("equip_id = " & intEquipID)
					'    FillLabelsEquip
					'    PopTaskList intEquipID
					'    ClearTask
					'Else
					'    rsEquipWO.MoveFirst
					'    rsEquipWO.Find ("equip_id = " & intEquipIDStore)
					'    cboEquipID.Text = rsEquipWO!equip_id
					'FillLabelsEquip
					'ClearTask
					'    Cancel = True
					'End If
					'UPGRADE_WARNING: Couldn't resolve default property of object intEquipIDStore. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				ElseIf intEquipIDStore = 0 Then 
					rsEquipWO.Find(("equip_id = " & intEquipID))
					FillLabelsEquip()
					PopTaskList(intEquipID)
					ClearTask()
				End If
			End If
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: WO - cboEquipID_Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	'UPGRADE_NOTE: Add was upgraded to Add_Renamed. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1061"'
	Public Function Add_Renamed() As Object
		
		Dim intEquipL As Short
		
		On Error GoTo errorhandler
		
		Clear()
		txtCount.Text = "New Record"
		FormView()
		MDIFormWOS.DefInstance.AddMode()
		If intTypeWO <> 1 Then
			intTypeWO = 2
			Me.cboEquipID.Focus()
		Else
			intEquipL = PopEquipList(0)
		End If
		' intStatus will be 2 for add
		intStatus = 2
		Me.lblPlantName.Text = intPlantPass & " - " & strPlantPass
		Me.lblPlantNameG.Text = intPlantPass & " - " & strPlantPass
		Exit Function
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: WO - Add: Description - " & Err.Description)
	End Function
	
	Public Function UpdateTaskWO(ByVal strmeter As String, ByVal strDate As String) As Short
		'with the update of the History we need to save the information for
		' Work Order(task) so that it can be used in the future to calculate the due date
		' or the due meter reading
		Dim strSQL, strFind As Object
		Dim strCycle As String
		Dim rsupdateTsk As ADODB.Recordset
		Dim rsFindValues As ADODB.Recordset
		Dim intGO As Short ' if 1 - do it , if 2 - don't do it
		Dim intIntervalMeter As Object
		Dim intIntervalDays As Integer 'integer
		Dim strDueMeter As String
		Dim dtDateComp As Object
		Dim dtDateDue As Date
		
		On Error GoTo errorhandler
		
		
		'UPGRADE_WARNING: Couldn't resolve default property of object strFind. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		strFind = "SELECT interval_days, interval_meter, cycle_type from task where task_id = " & rsWORetrieve.Fields("task_id").Value
		'UPGRADE_WARNING: Couldn't resolve default property of object strFind. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		rsFindValues = RecordsetTask(strFind)
		strCycle = rsFindValues.Fields("cycle_type").Value
		Select Case strCycle
			Case "Meter Cycle"
				'UPGRADE_WARNING: Couldn't resolve default property of object intIntervalMeter. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				intIntervalMeter = rsFindValues.Fields("interval_meter").Value
				'UPGRADE_NOTE: Object rsFindValues may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1029"'
				rsFindValues = Nothing
				'UPGRADE_WARNING: Couldn't resolve default property of object intIntervalMeter. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				strDueMeter = Str(CInt(strmeter) + intIntervalMeter)
				If strmeter <> "X" And strDate = "X" Then
					'UPGRADE_WARNING: Couldn't resolve default property of object strSQL. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
					strSQL = "UPDATE task set last_worked_meter_reading = " & strmeter & ", work_due_when_meter_reads = " & strDueMeter & " where task_id = " & rsWORetrieve.Fields("task_id").Value
					intGO = 1
				ElseIf strmeter = "X" And strDate = "X" Then 
					intGO = 2
				Else
					'UPGRADE_WARNING: Couldn't resolve default property of object strSQL. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
					strSQL = "UPDATE task set last_worked_date = '" & strDate & "' , last_worked_meter_reading = " & strmeter & ", work_due_when_meter_reads = " & strDueMeter & " where task_id = " & rsWORetrieve.Fields("task_id").Value
					intGO = 1
				End If
				
			Case "Days Cycle"
				intIntervalDays = rsFindValues.Fields("interval_days").Value
				'UPGRADE_NOTE: Object rsFindValues may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1029"'
				rsFindValues = Nothing
				'UPGRADE_WARNING: Couldn't resolve default property of object dtDateComp. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				dtDateComp = VB6.Format(strDate, "mm/dd/yy")
				
				'UPGRADE_WARNING: Couldn't resolve default property of object dtDateComp. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				dtDateDue = DateAdd(Microsoft.VisualBasic.DateInterval.Day, intIntervalDays, dtDateComp)
				If strmeter = "X" And strDate <> "X" Then
					'UPGRADE_WARNING: Couldn't resolve default property of object strSQL. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
					strSQL = "UPDATE task set last_worked_date = '" & strDate & "', work_due_date = '" & dtDateDue & "' where task_id = " & rsWORetrieve.Fields("task_id").Value
					intGO = 1
				ElseIf strmeter = "X" And strDate = "X" Then 
					intGO = 2
				Else
					'UPGRADE_WARNING: Couldn't resolve default property of object strSQL. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
					strSQL = "UPDATE task set last_worked_date = '" & strDate & "' , last_worked_meter_reading = " & strmeter & ", work_due_date = '" & dtDateDue & "' where task_id = " & rsWORetrieve.Fields("task_id").Value
					intGO = 1
				End If
			Case Else
				'UPGRADE_NOTE: Object rsFindValues may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1029"'
				rsFindValues = Nothing
				If strmeter = "X" And strDate <> "X" Then
					'UPGRADE_WARNING: Couldn't resolve default property of object strSQL. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
					strSQL = "UPDATE task set last_worked_date = '" & strDate & "' where task_id = " & rsWORetrieve.Fields("task_id").Value
					intGO = 1
				ElseIf strmeter <> "X" And strDate = "X" Then 
					'UPGRADE_WARNING: Couldn't resolve default property of object strSQL. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
					strSQL = "UPDATE task set last_worked_meter_reading = " & strmeter & " where task_id = " & rsWORetrieve.Fields("task_id").Value
					intGO = 1
				ElseIf strmeter = "X" And strDate = "X" Then 
					intGO = 2
				Else
					'UPGRADE_WARNING: Couldn't resolve default property of object strSQL. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
					strSQL = "UPDATE task set last_worked_date = '" & strDate & "' , last_worked_meter_reading = " & strmeter & " where task_id = " & rsWORetrieve.Fields("task_id").Value
					intGO = 1
				End If
		End Select
		If intGO = 1 Then
			'UPGRADE_WARNING: Couldn't resolve default property of object strSQL. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			rsupdateTsk = RecordsetTask(strSQL)
			'UPGRADE_NOTE: Object rsupdateTsk may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1029"'
			rsupdateTsk = Nothing
		End If
		UpdateTaskWO = 1
		Exit Function
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: WO - UpdateTaskWO: Description - " & Err.Description)
	End Function
	
	Public Sub Clear()
		
		On Error GoTo errorhandler
		
		If intTypeWO <> 1 Then
			ChangedData()
			intTypeWO = 0 ' Added 4-10
		End If
		
		ClearTask()
		ClearEquip()
		'Me.cboEquipID.SetFocus
		cboEquipID.Text = ""
		cboTaskID.Text = ""
		txtMeterReadingAtCompletion.Text = ""
		txtDateCompleted.defaultText = ""
		txtCompletedBy.Text = ""
		txtLabor.Text = ""
		txtMaterialsCost.Text = ""
		txtComments.Text = ""
		
		'UPGRADE_WARNING: Couldn't resolve default property of object intEquipIDStore. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		intEquipIDStore = 0
		'UPGRADE_WARNING: Couldn't resolve default property of object strEquipIDStore. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		strEquipIDStore = ""
		intTaskIDStore = 0
		strTaskIDStore = ""
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: WO - Clear: Description - " & Err.Description)
	End Sub
	
	Public Sub Delete()
		
		On Error GoTo errorhandler
		
		ans = 0
		FormView()
		ans = MsgBox("Are you sure that you want to delete this record?", MsgBoxStyle.YesNo, "WOS")
		If ans = 6 Then
			rsWORetrieve.Delete()
			rsWORetrieve.MoveNext()
			If rsWORetrieve.RecordCount < 1 Then
				intTypeWO = 1
				Add_Renamed()
			Else
				If rsWORetrieve.EOF Then
					rsWORetrieve.MovePrevious()
				End If
				FillFields()
				'CalculateFields rsWORetrieve!task_id
				rsEquipWO.MoveFirst()
				rsEquipWO.Find(("equip_id = " & rsWORetrieve.Fields("equip_id").Value))
				FillLabelsEquip()
				rsTaskWO.MoveFirst()
				rsTaskWO.Find(("task_id = " & rsWORetrieve.Fields("task_id").Value))
				FillLabelsTask()
			End If
		End If
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: WO - Delete: Description - " & Err.Description)
	End Sub
	
	Public Sub RefreshRec()
		
		On Error GoTo errorhandler
		
		Me.Close()
		intTypeWO = 0
		frmPlant.DefInstance.CheckAll("wo")
		'frmWorkOrder.Show
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: WO - RefreshRec: Description - " & Err.Description)
	End Sub
	
	Public Sub Save()
		Dim intResult As Short
		Dim strSQL As String
		
		On Error GoTo errorhandler
		FormView()
		intResult = ValidateWO
		
		If intResult = 0 Then
			If intTypeWO = 1 Then
				' do not check if some thing is changed
				strSQL = "Select * from work_order where plant_fk <> 0"
				rsWORetrieve = RecordsetWO(strSQL)
				rsWORetrieve.AddNew()
				intTypeWO = 0
			ElseIf intTypeWO = 2 Then 
				rsWORetrieve.AddNew()
				intTypeWO = 0
			End If
			AddUpdateWO()
			If intStatus = 2 Then
				Cancel()
			End If
			intStatus = 0
			'MDIFormWOS.cmdAdd.Enabled = True
		End If
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: WO - Save: Description - " & Err.Description)
	End Sub
	
	Public Sub AddUpdateWO()
		Dim strEquipNum, strEquipID, strTaskID As Object
		Dim strTaskNum As String
		Dim intLenEquip As Object
		Dim intLenTask As Short
		Dim intPosEquip As Object
		Dim intPosTask As Short
		
		On Error GoTo errorhandler
		
		ans = 0
		
		If intStatus = 2 Then
			'rsWORetrieve.AddNew
		Else
			rsWORetrieve.Update()
		End If
		
		' getting equipment_id value
		'UPGRADE_WARNING: Couldn't resolve default property of object strEquipID. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		strEquipID = cboEquipID.Text
		'UPGRADE_WARNING: Couldn't resolve default property of object strEquipID. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		strEquipID = Trim(strEquipID)
		'UPGRADE_WARNING: Couldn't resolve default property of object intLenEquip. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		intLenEquip = Len(strEquipID)
		'UPGRADE_WARNING: Couldn't resolve default property of object strEquipID. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		'UPGRADE_WARNING: Couldn't resolve default property of object intPosEquip. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		intPosEquip = InStr(strEquipID, " - ")
		
		'UPGRADE_WARNING: Couldn't resolve default property of object intPosEquip. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		If intPosEquip = 0 Then
			'UPGRADE_WARNING: Couldn't resolve default property of object strEquipID. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			'UPGRADE_WARNING: Couldn't resolve default property of object strEquipNum. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			strEquipNum = strEquipID
		Else
			'UPGRADE_WARNING: Couldn't resolve default property of object intPosEquip. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			'UPGRADE_WARNING: Couldn't resolve default property of object strEquipID. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			'UPGRADE_WARNING: Couldn't resolve default property of object strEquipNum. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			strEquipNum = VB.Left(strEquipID, intPosEquip - 1)
		End If
		
		'UPGRADE_WARNING: Couldn't resolve default property of object strEquipNum. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		rsWORetrieve.Fields("equip_id").Value = strEquipNum
		
		' getting task_id value
		'UPGRADE_WARNING: Couldn't resolve default property of object strTaskID. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		strTaskID = cboTaskID.Text
		'UPGRADE_WARNING: Couldn't resolve default property of object strTaskID. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		strTaskID = Trim(strTaskID)
		intLenTask = Len(strTaskID)
		'UPGRADE_WARNING: Couldn't resolve default property of object strTaskID. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		intPosTask = InStr(strTaskID, " - ")
		
		If intPosTask = 0 Then
			'UPGRADE_WARNING: Couldn't resolve default property of object strTaskID. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			strTaskNum = strTaskID
		Else
			'UPGRADE_WARNING: Couldn't resolve default property of object strTaskID. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			strTaskNum = VB.Left(strTaskID, intPosTask - 1)
		End If
		
		
		rsWORetrieve.Fields("task_id").Value = strTaskNum
		
		Dim intPlant As Short
		rsTaskWO.Find(("task_id = " & rsWORetrieve.Fields("task_id").Value))
		intPlant = rsTaskWO.Fields("plant_fk").Value
		rsWORetrieve.Fields("plant_fk").Value = intPlant
		If txtMeterReadingAtCompletion.Text <> "" Then
			rsWORetrieve.Fields("meter_reading_at_work_completion").Value = txtMeterReadingAtCompletion.Text
		Else
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			rsWORetrieve.Fields("meter_reading_at_work_completion").Value = System.DBNull.Value
		End If
		If txtDateCompleted.CtlText <> "" Then
			' does it work if I place "" around the text from txtdatecompleted?
			rsWORetrieve.Fields("date_work_completed").Value = txtDateCompleted.CtlText
		Else
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			rsWORetrieve.Fields("date_work_completed").Value = System.DBNull.Value
		End If
		rsWORetrieve.Fields("completed_by").Value = txtCompletedBy.Text
		If txtLabor.Text <> "" Then
			rsWORetrieve.Fields("labor").Value = txtLabor.Text
		Else
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			rsWORetrieve.Fields("labor").Value = System.DBNull.Value
		End If
		If txtMaterialsCost.Text <> "" Then
			rsWORetrieve.Fields("materials_cost").Value = txtMaterialsCost.Text
		Else
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			rsWORetrieve.Fields("materials_cost").Value = System.DBNull.Value
		End If
		rsWORetrieve.Fields("Comments").Value = txtComments.Text
		
		rsWORetrieve.MoveNext()
		rsWORetrieve.MovePrevious()
		
		Dim strDateCompleted As Object
		Dim strMeterReading As String
		If txtMeterReadingAtCompletion.Text <> "" Then
			strMeterReading = txtMeterReadingAtCompletion.Text
		Else
			strMeterReading = "X"
		End If
		If txtDateCompleted.CtlText <> "" Then
			'UPGRADE_WARNING: Couldn't resolve default property of object strDateCompleted. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			strDateCompleted = txtDateCompleted.CtlText
		Else
			'UPGRADE_WARNING: Couldn't resolve default property of object strDateCompleted. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			strDateCompleted = "X"
		End If
		Dim intupdatetsk As Short
		'UPGRADE_WARNING: Couldn't resolve default property of object strDateCompleted. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		intupdatetsk = UpdateTaskWO(strMeterReading, strDateCompleted)
		
		If intStatus = 2 Then
			ans = MsgBox("A record has been added.", MsgBoxStyle.OKOnly, "WOS")
		Else
			ans = MsgBox("The record has been updated.", MsgBoxStyle.OKOnly, "WOS")
		End If
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: WO - AddUpdateWO: Description - " & Err.Description)
	End Sub
	
	Public Sub FirstRec()
		
		On Error GoTo errorhandler
		
		ChangedData()
		rsWORetrieve.MoveFirst()
		PopTaskList(rsWORetrieve.Fields("equip_id").Value)
		ClearTask()
		FillFields()
		'CalculateFields rsWORetrieve!task_id
		rsEquipWO.MoveFirst()
		rsEquipWO.Find(("equip_id = " & rsWORetrieve.Fields("equip_id").Value))
		FillLabelsEquip()
		rsTaskWO.MoveFirst()
		rsTaskWO.Find(("task_id = " & rsWORetrieve.Fields("task_id").Value))
		FillLabelsTask()
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: WO - FirstRec: Description - " & Err.Description)
	End Sub
	
	Public Sub LastRec()
		
		On Error GoTo errorhandler
		
		ChangedData()
		rsWORetrieve.MoveLast()
		PopTaskList(rsWORetrieve.Fields("equip_id").Value)
		ClearTask()
		FillFields()
		'CalculateFields rsWORetrieve!task_id
		rsEquipWO.MoveFirst()
		rsEquipWO.Find(("equip_id = " & rsWORetrieve.Fields("equip_id").Value))
		FillLabelsEquip()
		rsTaskWO.MoveFirst()
		rsTaskWO.Find(("task_id = " & rsWORetrieve.Fields("task_id").Value))
		FillLabelsTask()
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: WO - LastRec: Description - " & Err.Description)
	End Sub
	
	Public Sub NextRec()
		
		On Error GoTo errorhandler
		
		ChangedData()
		rsWORetrieve.MoveNext()
		If rsWORetrieve.EOF Then
			rsWORetrieve.MovePrevious()
			ans = MsgBox("Already at the end of the list. Can not move any further.")
		End If
		PopTaskList(rsWORetrieve.Fields("equip_id").Value)
		ClearTask()
		FillFields()
		'CalculateFields rsWORetrieve!task_id
		rsEquipWO.MoveFirst()
		rsEquipWO.Find(("equip_id = " & rsWORetrieve.Fields("equip_id").Value))
		FillLabelsEquip()
		rsTaskWO.MoveFirst()
		rsTaskWO.Find(("task_id = " & rsWORetrieve.Fields("task_id").Value))
		FillLabelsTask()
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: WO - NextRec: Description - " & Err.Description)
	End Sub
	
	Public Sub PrevRec()
		
		On Error GoTo errorhandler
		
		ChangedData()
		rsWORetrieve.MovePrevious()
		If rsWORetrieve.BOF Then
			rsWORetrieve.MoveNext()
			ans = MsgBox("Already at the beginning of the list. Can not move back any more.")
		End If
		PopTaskList(rsWORetrieve.Fields("equip_id").Value)
		ClearTask()
		FillFields()
		'CalculateFields rsWORetrieve!task_id
		rsEquipWO.MoveFirst()
		rsEquipWO.Find(("equip_id = " & rsWORetrieve.Fields("equip_id").Value))
		FillLabelsEquip()
		rsTaskWO.MoveFirst()
		rsTaskWO.Find(("task_id = " & rsWORetrieve.Fields("task_id").Value))
		FillLabelsTask()
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: WO - PrevRec: Description - " & Err.Description)
	End Sub
	
	'Private Sub cboTaskID_GotFocus()
	'    Dim intLen, intPos As Integer
	'
	'    intTaskIDStore = 0
	'    strTaskIDStore = ""
	'    strTaskIDStore = cboTaskID.Text
	'    If strTaskIDStore <> "" Then
	'        strTaskIDStore = Trim(strTaskIDStore)
	'        intLen = Len(strTaskIDStore)
	'        intPos = InStr(strTaskIDStore, " - ")
	'        If intPos > 0 Then
	'            strTaskIDStore = Left(strTaskIDStore, intPos - 1)
	'        End If
	'        intTaskIDStore = CInt(strTaskIDStore)
	'    End If
	'End Sub
	
	Private Sub cboTaskID_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles cboTaskID.KeyUp
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim intKey As Short
		Dim intValue As Short
		
		On Error GoTo errorhandler
		
		intKey = KeyCode
		If (intKey < 48 Or intKey > 57) And intKey <> 119 And intKey <> 121 And intKey <> 120 And intKey <> 13 Then
			MsgBox("This field can only have numbers")
			If intTaskIDStore <> 0 Then
				Me.cboTaskID.Text = CStr(intTaskIDStore)
			End If
		End If
		If intStatus <> 2 Then
			MsgBox("Value can not be changed after a History is created and saved")
			If intTaskIDStore <> 0 Then
				Me.cboTaskID.Text = CStr(intTaskIDStore)
			End If
		End If
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: WO - cboTaskID_KeyUp: Description - " & Err.Description)
	End Sub
	
	Private Sub cboTaskID_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles cboTaskID.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		Dim ans As Short
		Dim intPos As Short
		Dim strNum As String
		Dim intLen As Short
		Dim strTaskID As String
		Dim intTaskID As Short
		
		On Error GoTo errorhandler
		
		If cboTaskID.Text = "" Then
			Beep()
			ans = MsgBox("Please select a Work Order from the dropdown.", MsgBoxStyle.OKOnly, "WOS")
			Cancel = True
		Else
			strTaskID = cboTaskID.Text
			strTaskID = Trim(strTaskID)
			intLen = Len(strTaskID)
			intPos = InStr(strTaskID, " - ")
			If intPos = 0 Then
				strNum = strTaskID
			Else
				strNum = VB.Left(strTaskID, intPos - 1)
			End If
			intTaskID = CShort(strNum)
			rsTaskWO.MoveFirst()
			rsTaskWO.Find(("task_id = " & intTaskID))
			If rsTaskWO.EOF = True Or rsTaskWO.BOF = True Then
				MsgBox("The Work Order you entered is not found in the dropdown.")
				Cancel = True
			Else
				'CalculateFields intTaskID
				FillLabelsTask()
				If intTaskID <> intTaskIDStore And intTaskIDStore <> 0 Then
					If intStatus <> 2 Then
						MsgBox("Value can not be changed after a History is created and saved")
						If intTaskIDStore <> 0 Then
							Me.cboTaskID.Text = CStr(intTaskIDStore)
						End If
					End If
					'ans = MsgBox("Are you sure you want to change Work Order? All the fields has to be reset except equipment info.", vbYesNo)
					'If ans = 6 Then
					'    rsTaskWO.MoveFirst
					'    rsTaskWO.Find ("task_id = " & intTaskID)
					'CalculateFields (intTaskID)
					'    FillLabelsTask
					'Else
					'    cboTaskID.Text = strNum
					'End If
				End If
			End If
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: WO - cboTaskID_Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub DGridWO_RowColChange(ByVal eventSender As System.Object, ByVal eventArgs As AxMSDataGridLib.DDataGridEvents_RowColChangeEvent) Handles DGridWO.RowColChange
		
		On Error GoTo errorhandler
		
		If FramGrid.Visible = True Then
			PopTaskList(rsWORetrieve.Fields("equip_id").Value)
			ClearTask()
			FillFields()
			'CalculateFields rsWORetrieve!task_id
			rsEquipWO.MoveFirst()
			rsEquipWO.Find(("equip_id = " & rsWORetrieve.Fields("equip_id").Value))
			FillLabelsEquip()
			rsTaskWO.MoveFirst()
			rsTaskWO.Find(("task_id = " & rsWORetrieve.Fields("task_id").Value))
			FillLabelsTask()
		End If
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: WO - Dgrid_RowColChange: Description - " & Err.Description)
	End Sub
	
	'UPGRADE_WARNING: Form event frmWorkOrder.Activate has a new behavior. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup2065"'
	Private Sub frmWorkOrder_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		
		On Error GoTo errorhandler
		'If CheckRecordset = 1 Then
		MDIFormWOS.DefInstance.FindActive((False))
		'End If
		If intTypeWO = 1 Then
			MDIFormWOS.DefInstance.cmdSearch.Enabled = False
			MDIFormWOS.DefInstance.cmdPrint.Enabled = False
			MDIFormWOS.DefInstance.AddMode()
		Else
			MDIFormWOS.DefInstance.cmdSearch.Enabled = True
			MDIFormWOS.DefInstance.cmdPrint.Enabled = True
		End If
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: WO - Form_Activate: Description - " & Err.Description)
	End Sub
	
	' This has to be modified to allow add as well as update
	Private Sub frmWorkOrder_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim intKeyValue As Short
		
		On Error GoTo errorhandler
		
		intKeyValue = KeyCode
		' F8 (value 119) - move previous
		' F9 (value 120) - move next
		' F10 (value 121) - new record
		' F11 (value 122) - save
		Select Case intKeyValue
			Case 122
				If MDIFormWOS.DefInstance.cmdSave.Enabled = True Then
					Save()
				End If
			Case 121
				If MDIFormWOS.DefInstance.cmdAdd.Enabled = True Then
					Add_Renamed()
					'intTypeWO = 2
					'UPGRADE_WARNING: Couldn't resolve default property of object intEquipIDStore. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
					intEquipIDStore = 0
					intTaskIDStore = 0
					'UPGRADE_WARNING: Couldn't resolve default property of object strEquipIDStore. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
					strEquipIDStore = ""
					strTaskIDStore = ""
					
					'MDIFormWOS.SetFocus
					frmWorkOrder.DefInstance.Activate()
					frmWorkOrder.DefInstance.cboEquipID.Focus()
				Else
					MsgBox("Data has to be saved before entering another record.")
				End If
			Case 120
				If MDIFormWOS.DefInstance.cmdNext.Enabled = True Then
					NextRec()
					MDIFormWOS.DefInstance.Activate()
					frmWorkOrder.DefInstance.Activate()
					frmWorkOrder.DefInstance.cboEquipID.Focus()
				Else
					Cancel()
				End If
				If intStatus = 2 Then
					intStatus = 1
				End If
				
			Case 119
				
				If MDIFormWOS.DefInstance.cmdPrevious.Enabled = True Then
					PrevRec()
					MDIFormWOS.DefInstance.Activate()
					frmWorkOrder.DefInstance.Activate()
					frmWorkOrder.DefInstance.cboEquipID.Focus()
				Else
					Cancel()
				End If
				If intStatus = 2 Then
					intStatus = 1
				End If
		End Select
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: WO - Form_KeyUp: Description - " & Err.Description)
	End Sub
	
	Private Sub frmWorkOrder_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Dim intResult As Short
		
		On Error GoTo errorhandler
		intStatus = 0
		Me.Height = VB6.TwipsToPixelsY(7000)
		Me.Width = VB6.TwipsToPixelsX(9300)
		Me.Left = 0
		Me.Top = 0
		FormView()
		'UPGRADE_WARNING: Couldn't resolve default property of object strSearchEquipKey. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		strSearchEquipKey = "XXXXXXXXXXX"
		strSearchEquipDesc = "XXXXXXXXXXX"
		'UPGRADE_WARNING: Couldn't resolve default property of object strSearchTaskDesc. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		strSearchTaskDesc = "XXXXXXXXXXX"
		'UPGRADE_WARNING: Couldn't resolve default property of object strSearchMiscComments. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		strSearchMiscComments = "XXXXXXXXXXX"
		strSearchComments = "XXXXXXXXXXX"
		'UPGRADE_WARNING: Couldn't resolve default property of object strSearchInitial. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		strSearchInitial = "XXXXXXXXXXX"
		'UPGRADE_WARNING: Couldn't resolve default property of object strSearchDate1. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		strSearchDate1 = "01/01/1955"
		strSearchDate2 = "01/01/2999"
		strSearchOpt = "All"
		
		'UPGRADE_WARNING: Couldn't resolve default property of object strState. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		strState = "Load"
		
		'UPGRADE_WARNING: Couldn't resolve default property of object strState. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		intResult = RetrieveWO(strState, "")
		If intResult = 0 Then
		Else
			FillFields()
			SetGrid()
			PopEquipList(rsWORetrieve.Fields("equip_id").Value)
			FillLabelsEquip()
			PopTaskList(rsWORetrieve.Fields("equip_id").Value)
			FillLabelsTask()
			cboTaskID.Text = rsWORetrieve.Fields("task_id").Value
			'CalculateFields rsWORetrieve!task_id
		End If
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: WO - Form_Load: Description - " & Err.Description)
	End Sub
	
	
	Public Sub Populate()
		
		On Error GoTo errorhandler
		
		FillFields()
		SetGrid()
		rsEquipWO.MoveFirst()
		rsEquipWO.Find(("equip_id = " & rsWORetrieve.Fields("equip_id").Value))
		FillLabelsEquip()
		PopTaskList(rsWORetrieve.Fields("equip_id").Value)
		rsTaskWO.MoveFirst()
		rsTaskWO.Find(("task_id = " & rsWORetrieve.Fields("task_id").Value))
		FillLabelsTask()
		'CalculateFields rsWORetrieve!task_id
		cboTaskID.Text = rsWORetrieve.Fields("task_id").Value
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: WO - Populate: Description - " & Err.Description)
	End Sub
	
	Public Sub PrintScreen()
		' Need to print the History record being
		' looked at or print a report based on the record on the screen
	End Sub
	
	Public Sub SetGrid()
		Dim intGridWidth As Short
		Dim col4, col2, col1, col3, col5 As Object
		Dim col6 As MSDataGridLib.Column
		
		On Error GoTo errorhandler
		
		DGridWO.DataSource = rsWORetrieve
		
		col1 = DGridWO.Columns(0)
		col2 = DGridWO.Columns(1)
		col3 = DGridWO.Columns(2)
		col4 = DGridWO.Columns(3)
		col5 = DGridWO.Columns(4)
		col6 = DGridWO.Columns(5)
		
		'UPGRADE_WARNING: Couldn't resolve default property of object col1.Caption. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		col1.Caption = "ID"
		'UPGRADE_WARNING: Couldn't resolve default property of object col2.Caption. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		col2.Caption = "PLANT"
		'UPGRADE_WARNING: Couldn't resolve default property of object col3.Caption. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		col3.Caption = "EQUIP"
		'UPGRADE_WARNING: Couldn't resolve default property of object col4.Caption. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		col4.Caption = "WORK ORDER"
		'UPGRADE_WARNING: Couldn't resolve default property of object col5.Caption. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		col5.Caption = "METER READING"
		col6.Caption = "DATE COMPLETED"
		
		intGridWidth = VB6.PixelsToTwipsX(DGridWO.Width)
		
		'UPGRADE_WARNING: Couldn't resolve default property of object col1.Width. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		col1.Width = (6 / 81) * intGridWidth
		'UPGRADE_WARNING: Couldn't resolve default property of object col2.Width. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		col2.Width = (7 / 81) * intGridWidth
		'UPGRADE_WARNING: Couldn't resolve default property of object col3.Width. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		col3.Width = (7 / 81) * intGridWidth
		'UPGRADE_WARNING: Couldn't resolve default property of object col4.Width. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		col4.Width = (7 / 81) * intGridWidth
		'UPGRADE_WARNING: Couldn't resolve default property of object col5.Width. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		col5.Width = (24 / 81) * intGridWidth
		col6.Width = VB6.TwipsToPixelsX((30 / 81) * intGridWidth)
		
		'col1.Locked = True
		'col2.Locked = True
		'col3.Locked = True
		'col4.Locked = True
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: WO - SetGrid: Description - " & Err.Description)
	End Sub
	
	Public Sub ChangedData()
		Dim intChangedCount As Short
		Dim strEquipNum, strEquipID, strTaskID As Object
		Dim strTaskNum As String
		Dim intLenEquip As Object
		Dim intLenTask As Short
		Dim intPosEquip As Object
		Dim intPosTask As Short
		
		On Error GoTo errorhandler
		
		intChangedCount = 0
		ans = 0
		
		' Evaluating equipment_id change
		'UPGRADE_WARNING: Couldn't resolve default property of object strEquipID. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		strEquipID = cboEquipID.Text
		'UPGRADE_WARNING: Couldn't resolve default property of object strEquipID. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		strEquipID = Trim(strEquipID)
		'UPGRADE_WARNING: Couldn't resolve default property of object intLenEquip. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		intLenEquip = Len(strEquipID)
		'UPGRADE_WARNING: Couldn't resolve default property of object strEquipID. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		'UPGRADE_WARNING: Couldn't resolve default property of object intPosEquip. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		intPosEquip = InStr(strEquipID, " - ")
		
		'UPGRADE_WARNING: Couldn't resolve default property of object intPosEquip. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		If intPosEquip = 0 Then
			'UPGRADE_WARNING: Couldn't resolve default property of object strEquipID. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			'UPGRADE_WARNING: Couldn't resolve default property of object strEquipNum. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			strEquipNum = strEquipID
		Else
			'UPGRADE_WARNING: Couldn't resolve default property of object intPosEquip. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			'UPGRADE_WARNING: Couldn't resolve default property of object strEquipID. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			'UPGRADE_WARNING: Couldn't resolve default property of object strEquipNum. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			strEquipNum = VB.Left(strEquipID, intPosEquip - 1)
		End If
		
		'UPGRADE_WARNING: Couldn't resolve default property of object strEquipNum. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		If rsWORetrieve.Fields("equip_id").Value <> CInt(strEquipNum) Then
			intChangedCount = intChangedCount + 1
		End If
		
		' Evaluating task_id change
		'UPGRADE_WARNING: Couldn't resolve default property of object strTaskID. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		strTaskID = cboTaskID.Text
		'UPGRADE_WARNING: Couldn't resolve default property of object strTaskID. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		strTaskID = Trim(strTaskID)
		intLenTask = Len(strTaskID)
		'UPGRADE_WARNING: Couldn't resolve default property of object strTaskID. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		intPosTask = InStr(strTaskID, " - ")
		
		If intPosTask = 0 Then
			'UPGRADE_WARNING: Couldn't resolve default property of object strTaskID. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			strTaskNum = strTaskID
		Else
			'UPGRADE_WARNING: Couldn't resolve default property of object strTaskID. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			strTaskNum = VB.Left(strTaskID, intPosTask - 1)
		End If
		
		If rsWORetrieve.Fields("task_id").Value <> CInt(strTaskNum) Then
			intChangedCount = intChangedCount + 1
		End If
		
		' Evaluating rest of the fields
		
		If txtMeterReadingAtCompletion.Text <> rsWORetrieve.Fields("meter_reading_at_work_completion").Value Then
			intChangedCount = intChangedCount + 1
		End If
		If txtDateCompleted.CtlText <> "" Then
			If CDate(txtDateCompleted.CtlText) <> rsWORetrieve.Fields("date_work_completed").Value Then
				intChangedCount = intChangedCount + 1
			End If
		Else
			If txtDateCompleted.CtlText <> rsWORetrieve.Fields("date_work_completed").Value Then
				intChangedCount = intChangedCount + 1
			End If
		End If
		If txtCompletedBy.Text <> rsWORetrieve.Fields("completed_by").Value Then
			intChangedCount = intChangedCount + 1
		End If
		If txtLabor.Text <> rsWORetrieve.Fields("labor").Value Then
			intChangedCount = intChangedCount + 1
		End If
		If txtMaterialsCost.Text <> rsWORetrieve.Fields("materials_cost").Value Then
			intChangedCount = intChangedCount + 1
		End If
		If txtComments.Text <> rsWORetrieve.Fields("Comments").Value Then
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
		MsgBox("Error Number - " & Err.Number & ": WOS: WO - ChangedData: Description - " & Err.Description)
	End Sub
	
	Private Sub KeepCount()
		
		On Error GoTo errorhandler
		
		Me.txtCount.Text = "Record No. " & rsWORetrieve.AbsolutePosition & " of " & rsWORetrieve.RecordCount & " Records"
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: WO - KeepCount: Description - " & Err.Description)
	End Sub
	
	Private Sub FillLabelsEquip()
		Dim intCount As Object
		Dim I As Short
		'Dim strEq As String
		
		On Error GoTo errorhandler
		
		If rsEquipWO.EOF = True Or rsEquipWO.BOF = True Then
			'intCount = rsEquipWO.RecordCount
			'rsEquipWO.MoveFirst
			'For I = 0 To intCount
			'    strEq = rsEquipWO!equip_id
			'    rsEquipWO.MoveNext
			'Next
			'If intCount = 0 Then
			'    MsgBox "There are no more equipment for this plant in the database"
			'    Unload Me
			'End If
		Else
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipWO.Fields("mech_serial").Value) Then
				Me.lblMechSerialD.Text = ""
			Else
				Me.lblMechSerialD.Text = rsEquipWO.Fields("mech_serial").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipWO.Fields("mech_id").Value) Then
				Me.lblMechIDD.Text = ""
			Else
				Me.lblMechIDD.Text = rsEquipWO.Fields("mech_id").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipWO.Fields("mech_model").Value) Then
				Me.lblMechModelD.Text = ""
			Else
				Me.lblMechModelD.Text = rsEquipWO.Fields("mech_model").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipWO.Fields("mech_frame").Value) Then
				Me.lblMechFrameD.Text = ""
			Else
				Me.lblMechFrameD.Text = rsEquipWO.Fields("mech_frame").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipWO.Fields("mech_imp_sz").Value) Then
				Me.lblMechImpSzD.Text = ""
			Else
				Me.lblMechImpSzD.Text = rsEquipWO.Fields("mech_imp_sz").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipWO.Fields("mech_hp").Value) Then
				Me.lblMechHpD.Text = ""
			Else
				Me.lblMechHpD.Text = rsEquipWO.Fields("mech_hp").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipWO.Fields("mech_rpm").Value) Then
				Me.lblMechRpmD.Text = ""
			Else
				Me.lblMechRpmD.Text = rsEquipWO.Fields("mech_rpm").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipWO.Fields("mech_cap").Value) Then
				Me.lblMechCapD.Text = ""
			Else
				Me.lblMechCapD.Text = rsEquipWO.Fields("mech_cap").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipWO.Fields("mech_size").Value) Then
				Me.lblMechSizeD.Text = ""
			Else
				Me.lblMechSizeD.Text = rsEquipWO.Fields("mech_size").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipWO.Fields("mech_tdh").Value) Then
				Me.lblMechTdhD.Text = ""
			Else
				Me.lblMechTdhD.Text = rsEquipWO.Fields("mech_tdh").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipWO.Fields("mech_cat_no").Value) Then
				Me.lblMechCatNoD.Text = ""
			Else
				Me.lblMechCatNoD.Text = rsEquipWO.Fields("mech_cat_no").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipWO.Fields("mech_max_rpm").Value) Then
				Me.lblMechMaxRpmD.Text = ""
			Else
				Me.lblMechMaxRpmD.Text = rsEquipWO.Fields("mech_max_rpm").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipWO.Fields("mech_min_rpm").Value) Then
				Me.lblMechMinRpmD.Text = ""
			Else
				Me.lblMechMinRpmD.Text = rsEquipWO.Fields("mech_min_rpm").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipWO.Fields("mech_cfm").Value) Then
				Me.lblMechCfmD.Text = ""
			Else
				Me.lblMechCfmD.Text = rsEquipWO.Fields("mech_cfm").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipWO.Fields("mech_oil").Value) Then
				Me.lblMechOilD.Text = ""
			Else
				Me.lblMechOilD.Text = rsEquipWO.Fields("mech_oil").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipWO.Fields("mech_oil_filter").Value) Then
				Me.lblMechOilFilterD.Text = ""
			Else
				Me.lblMechOilFilterD.Text = rsEquipWO.Fields("mech_oil_filter").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipWO.Fields("mech_air_filter").Value) Then
				Me.lblMechAirFilterD.Text = ""
			Else
				Me.lblMechAirFilterD.Text = rsEquipWO.Fields("mech_air_filter").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipWO.Fields("mech_belt1").Value) Then
				Me.lblMechBelt1D.Text = ""
			Else
				Me.lblMechBelt1D.Text = rsEquipWO.Fields("mech_belt1").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipWO.Fields("mech_belt2").Value) Then
				Me.lblMechBelt2D.Text = ""
			Else
				Me.lblMechBelt2D.Text = rsEquipWO.Fields("mech_belt2").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipWO.Fields("mech_pipe_size").Value) Then
				Me.lblMechPipeSizeD.Text = ""
			Else
				Me.lblMechPipeSizeD.Text = rsEquipWO.Fields("mech_pipe_size").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipWO.Fields("mech_pipe_type").Value) Then
				Me.lblMechPipeTypeD.Text = ""
			Else
				Me.lblMechPipeTypeD.Text = rsEquipWO.Fields("mech_pipe_type").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipWO.Fields("mech_no_valves_types").Value) Then
				Me.lblMechNoValvesTypesD.Text = ""
			Else
				Me.lblMechNoValvesTypesD.Text = rsEquipWO.Fields("mech_no_valves_types").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipWO.Fields("mech_misc_nameplate_data").Value) Then
				Me.lblMechMiscNPDataD.Text = ""
			Else
				Me.lblMechMiscNPDataD.Text = rsEquipWO.Fields("mech_misc_nameplate_data").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipWO.Fields("mech_recommended_spare_parts").Value) Then
				Me.lblMechRecomSparePartsD.Text = ""
			Else
				Me.lblMechRecomSparePartsD.Text = rsEquipWO.Fields("mech_recommended_spare_parts").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipWO.Fields("elec_serial").Value) Then
				Me.lblElecSerialD.Text = ""
			Else
				Me.lblElecSerialD.Text = rsEquipWO.Fields("elec_serial").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipWO.Fields("elec_id").Value) Then
				Me.lblElecIDD.Text = ""
			Else
				Me.lblElecIDD.Text = rsEquipWO.Fields("elec_id").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipWO.Fields("elec_model").Value) Then
				Me.lblElecModelD.Text = ""
			Else
				Me.lblElecModelD.Text = rsEquipWO.Fields("elec_model").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipWO.Fields("elec_frame").Value) Then
				Me.lblElecFrameD.Text = ""
			Else
				Me.lblElecFrameD.Text = rsEquipWO.Fields("elec_frame").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipWO.Fields("elec_cat_no").Value) Then
				Me.lblElecCatNoD.Text = ""
			Else
				Me.lblElecCatNoD.Text = rsEquipWO.Fields("elec_cat_no").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipWO.Fields("elec_hp").Value) Then
				Me.lblElecHpD.Text = ""
			Else
				Me.lblElecHpD.Text = rsEquipWO.Fields("elec_hp").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipWO.Fields("elec_rpm").Value) Then
				Me.lblElecRpmD.Text = ""
			Else
				Me.lblElecRpmD.Text = rsEquipWO.Fields("elec_rpm").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipWO.Fields("elec_v").Value) Then
				Me.lblElecVD.Text = ""
			Else
				Me.lblElecVD.Text = rsEquipWO.Fields("elec_v").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipWO.Fields("elec_amp").Value) Then
				Me.lblElecAmpD.Text = ""
			Else
				Me.lblElecAmpD.Text = rsEquipWO.Fields("elec_amp").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipWO.Fields("elec_hz").Value) Then
				Me.lblElecHzD.Text = ""
			Else
				Me.lblElecHzD.Text = rsEquipWO.Fields("elec_hz").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipWO.Fields("elec_phs").Value) Then
				Me.lblElecPhsD.Text = ""
			Else
				Me.lblElecPhsD.Text = rsEquipWO.Fields("elec_phs").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipWO.Fields("elec_sf").Value) Then
				Me.lblElecSfD.Text = ""
			Else
				Me.lblElecSfD.Text = rsEquipWO.Fields("elec_sf").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipWO.Fields("elec_duty").Value) Then
				Me.lblElecDutyD.Text = ""
			Else
				Me.lblElecDutyD.Text = rsEquipWO.Fields("elec_duty").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipWO.Fields("elec_insl_cl").Value) Then
				Me.lblElecInslClD.Text = ""
			Else
				Me.lblElecInslClD.Text = rsEquipWO.Fields("elec_insl_cl").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipWO.Fields("elec_design").Value) Then
				Me.lblElecDesignD.Text = ""
			Else
				Me.lblElecDesignD.Text = rsEquipWO.Fields("elec_design").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipWO.Fields("elec_shaft_end_brg").Value) Then
				Me.lblElecShaftEndBrgD.Text = ""
			Else
				Me.lblElecShaftEndBrgD.Text = rsEquipWO.Fields("elec_shaft_end_brg").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipWO.Fields("elec_opp_end_brg").Value) Then
				Me.lblElecOppEndBrgD.Text = ""
			Else
				Me.lblElecOppEndBrgD.Text = rsEquipWO.Fields("elec_opp_end_brg").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipWO.Fields("elec_misc_nameplate_data").Value) Then
				Me.lblElecMiscNPDataD.Text = ""
			Else
				Me.lblElecMiscNPDataD.Text = rsEquipWO.Fields("elec_misc_nameplate_data").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipWO.Fields("elec_recommended_spare_parts").Value) Then
				Me.lblElecRecomSparePartsD.Text = ""
			Else
				Me.lblElecRecomSparePartsD.Text = rsEquipWO.Fields("elec_recommended_spare_parts").Value
			End If
		End If
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: WO - FillLabelsEquip: Description - " & Err.Description)
	End Sub
	
	Private Sub FillLabelsTask()
		Dim intCount As Short
		
		On Error GoTo errorhandler
		
		If rsTaskWO.EOF = True Or rsTaskWO.BOF = True Then
			'intCount = rsTaskRetrieve.RecordCount
			'If intCount = 0 Then
			'    MsgBox "There are no more Work Order for this plant in the database"
			'    Unload Me
			'End If
		Else
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsTaskWO.Fields("task_desc").Value) Then
				lblTaskTaskDescD.Text = ""
			Else
				lblTaskTaskDescD.Text = rsTaskWO.Fields("task_desc").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsTaskWO.Fields("priority").Value) Then
				lblTaskPriorityD.Text = ""
			Else
				lblTaskPriorityD.Text = rsTaskWO.Fields("priority").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsTaskWO.Fields("cycle_type").Value) Then
				lblTaskCycleTypeD.Text = ""
			Else
				lblTaskCycleTypeD.Text = rsTaskWO.Fields("cycle_type").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsTaskWO.Fields("interval_days").Value) Then
				lblTaskIntervalDaysD.Text = ""
			Else
				lblTaskIntervalDaysD.Text = rsTaskWO.Fields("interval_days").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsTaskWO.Fields("interval_meter").Value) Then
				lblTaskIntervalMeterD.Text = ""
			Else
				lblTaskIntervalMeterD.Text = rsTaskWO.Fields("interval_meter").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsTaskWO.Fields("tools_required").Value) Then
				lblTaskToolsRequiredD.Text = ""
			Else
				lblTaskToolsRequiredD.Text = rsTaskWO.Fields("tools_required").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsTaskWO.Fields("last_worked_meter_reading").Value) Then
				lblTaskLastWorkedMeterD.Text = ""
			Else
				lblTaskLastWorkedMeterD.Text = rsTaskWO.Fields("last_worked_meter_reading").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsTaskWO.Fields("last_worked_date").Value) Then
				lblTaskLastWorkedDateD.Text = ""
			Else
				lblTaskLastWorkedDateD.Text = rsTaskWO.Fields("last_worked_date").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsTaskWO.Fields("misc_comments").Value) Then
				txtTaskMiscCommentsD.Text = ""
			Else
				txtTaskMiscCommentsD.Text = rsTaskWO.Fields("misc_comments").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsTaskWO.Fields("lo_to").Value) Then
				lblTaskLoToD.Text = ""
			Else
				lblTaskLoToD.Text = rsTaskWO.Fields("lo_to").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsTaskWO.Fields("created_by").Value) Then
				lblCreatedbyD.Text = ""
			Else
				lblCreatedbyD.Text = rsTaskWO.Fields("created_by").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsTaskWO.Fields("work_due_when_meter_reads").Value) Then
				Me.lblWorkDueWhenMeterReadsD.Text = ""
			Else
				Me.lblWorkDueWhenMeterReadsD.Text = rsTaskWO.Fields("work_due_when_meter_reads").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsTaskWO.Fields("work_due_date").Value) Then
				Me.lblWorkDueDateD.Text = ""
			Else
				Me.lblWorkDueDateD.Text = rsTaskWO.Fields("work_due_date").Value
			End If
		End If
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: WO - FillLabelsTask: Description - " & Err.Description)
	End Sub
	
	Private Sub FillFields()
		Dim intCount As Short
		
		On Error GoTo errorhandler
		
		If rsWORetrieve.EOF = True Or rsWORetrieve.BOF = True Then
			intCount = rsWORetrieve.RecordCount
			If intCount = 0 Then
				MsgBox("There are no more History record for this plant in the database")
				Me.Close()
			End If
		Else
			
			Me.lblPlantName.Text = intPlantPass & " - " & strPlantPass
			Me.lblPlantNameG.Text = intPlantPass & " - " & strPlantPass
			
			cboEquipID.Text = rsWORetrieve.Fields("equip_id").Value
			
			'UPGRADE_WARNING: Couldn't resolve default property of object intEquipIDStore. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			intEquipIDStore = rsWORetrieve.Fields("equip_id").Value
			
			cboTaskID.Text = rsWORetrieve.Fields("task_id").Value
			
			intTaskIDStore = rsWORetrieve.Fields("task_id").Value
			
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsWORetrieve.Fields("meter_reading_at_work_completion").Value) Then
				txtMeterReadingAtCompletion.Text = ""
			Else
				txtMeterReadingAtCompletion.Text = rsWORetrieve.Fields("meter_reading_at_work_completion").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsWORetrieve.Fields("date_work_completed").Value) Then
				txtDateCompleted.CtlText = ""
			Else
				txtDateCompleted.CtlText = rsWORetrieve.Fields("date_work_completed").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsWORetrieve.Fields("completed_by").Value) Then
				txtCompletedBy.Text = ""
			Else
				txtCompletedBy.Text = rsWORetrieve.Fields("completed_by").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsWORetrieve.Fields("labor").Value) Then
				txtLabor.Text = ""
			Else
				txtLabor.Text = rsWORetrieve.Fields("labor").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsWORetrieve.Fields("materials_cost").Value) Then
				txtMaterialsCost.Text = ""
			Else
				txtMaterialsCost.Text = rsWORetrieve.Fields("materials_cost").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsWORetrieve.Fields("Comments").Value) Then
				txtComments.Text = ""
			Else
				txtComments.Text = rsWORetrieve.Fields("Comments").Value
			End If
			KeepCount()
		End If
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: WO - FillFields: Description - " & Err.Description)
	End Sub
	
	Public Function RetrieveWO(ByVal strState As String, ByRef strSqlA As String) As Short
		' returns 1 or 0
		' 1 - records
		' 0 - no records
		
		Dim ans As Short
		Dim strSQL As Object
		Dim strWO As String
		Dim strSearchString As String
		'Dim dtDate1, dtDate2 As Date
		
		On Error GoTo errorhandler
		
		If strState = "Load" Then
			If strPlantPass = "All Plants" Then
				'UPGRADE_WARNING: Couldn't resolve default property of object strSQL. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				strSQL = "select * from work_order where work_order_id <> 0"
			Else
				'UPGRADE_WARNING: Couldn't resolve default property of object strSQL. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				strSQL = "select * from work_order where plant_fk = " & intPlantPass
			End If
		Else
			'UPGRADE_WARNING: Couldn't resolve default property of object strSQL. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			strSQL = strSqlA
		End If
		'UPGRADE_WARNING: Couldn't resolve default property of object strSQL. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		rsWORetrieve = RecordsetWO(strSQL)
		If rsWORetrieve.EOF = True Or rsWORetrieve.BOF = True Then
			RetrieveWO = 0
		Else
			rsWORetrieve.MoveLast()
			rsWORetrieve.MoveFirst()
			RetrieveWO = 1
		End If
		Exit Function
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: WO - RetrieveWO: Description - " & Err.Description)
	End Function
	
	'UPGRADE_WARNING: Form event frmWorkOrder.Unload has a new behavior. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup2065"'
	Private Sub frmWorkOrder_Closed(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Closed
		
		On Error GoTo errorhandler
		
		'UPGRADE_NOTE: Object rsWORetrieve may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1029"'
		rsWORetrieve = Nothing
		intTypeWO = 0
		' All the variable used in search
		'UPGRADE_WARNING: Couldn't resolve default property of object strSearchEquipKey. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		strSearchEquipKey = ""
		strSearchEquipDesc = ""
		'UPGRADE_WARNING: Couldn't resolve default property of object strSearchTaskDesc. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		strSearchTaskDesc = ""
		'UPGRADE_WARNING: Couldn't resolve default property of object strSearchMiscComments. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		strSearchMiscComments = ""
		strSearchComments = ""
		'UPGRADE_WARNING: Couldn't resolve default property of object strSearchDate1. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		strSearchDate1 = ""
		strSearchDate2 = ""
		strSearchOpt = ""
		
		'UPGRADE_WARNING: Couldn't resolve default property of object strState. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		strState = ""
		
		MDIFormWOS.DefInstance.FindActive((True))
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: WO - Form_Unload: Description - " & Err.Description)
	End Sub
	
	Public Function PopEquipList(ByRef intEquip As Short) As Short
		' value passed either -1 for record existing
		'               or    0 for all list of equipments
		'               or    precise equip_id
		' Returns 1 for success, 2 for failure
		Dim I As Object
		Dim count As Short
		Dim strSQL As String
		
		On Error GoTo errorhandler
		
		If strPlantPass = "All Plants" Then
			strSQL = "select * from equipment where equip_id <> 0"
		Else
			strSQL = "select * from equipment where plant_fk = " & intPlantPass
		End If
		
		rsEquipWO = RecordsetWO(strSQL)
		
		If rsEquipWO.EOF = True Or rsEquipWO.BOF = True Then
			If strPlantPass <> "All Plants" Then
				MsgBox("There are no equipments under the selected plant. Please add new equipment. ")
				Me.Close()
				frmEquipment.DefInstance.CheckRecordset()
				PopEquipList = 2
			Else
				MsgBox("New equipment could not be added until you select a specific plant.")
				MDIFormWOS.DefInstance.Close()
				frmPlant.DefInstance.Show()
				PopEquipList = 2
			End If
			'Do not try to populate the dropdown
		Else
			cboEquipID.Items.Clear()
			rsEquipWO.MoveLast()
			count = rsEquipWO.RecordCount
			rsEquipWO.MoveFirst()
			For I = 1 To count
				cboEquipID.Items.Add(rsEquipWO.Fields("equip_id").Value & " - " & rsEquipWO.Fields("equip_desc").Value)
				rsEquipWO.MoveNext()
			Next 
			
			rsEquipWO.MoveFirst()
			If intEquip <> 0 Then
				If intEquip = -1 Then
					rsEquipWO.Find(("equip_id = " & rsWORetrieve.Fields("equip_id").Value))
				Else
					rsEquipWO.Find(("equip_id = " & intEquip))
				End If
				cboEquipID.Text = Str(intEquip)
			End If
			PopEquipList = 1
			
		End If
		Exit Function
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: WO - PopEquipList: Description - " & Err.Description)
	End Function
	
	Public Function PopTaskList(ByRef intEquipID As Short) As Object
		Dim I As Object
		Dim count As Short
		Dim strSQL As String
		
		On Error GoTo errorhandler
		
		If strPlantPass = "All Plants" Then
			strSQL = "select * from task where task_id <> 0 and equip_id = " & intEquipID
		Else
			strSQL = "select * from task where plant_fk = " & intPlantPass & " and equip_id = " & intEquipID
		End If
		
		rsTaskWO = RecordsetWO(strSQL)
		
		If rsTaskWO.EOF = True Or rsTaskWO.BOF = True Then
			MsgBox("There are no Work Orders under the selected equipment. Please select another equipment or create Work Order for the equipment.")
			cboTaskID.Items.Clear()
			cboEquipID.Focus()
		Else
			rsTaskWO.MoveLast()
			count = rsTaskWO.RecordCount
			rsTaskWO.MoveFirst()
			cboTaskID.Items.Clear()
			For I = 1 To count
				cboTaskID.Items.Add(rsTaskWO.Fields("task_id").Value & " - " & rsTaskWO.Fields("task_desc").Value)
				rsTaskWO.MoveNext()
			Next 
			rsTaskWO.MoveFirst()
		End If
		Exit Function
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: WO - PopTaskList: Description - " & Err.Description)
	End Function
	
	Private Sub txtDateCompleted_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtDateCompleted.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		On Error GoTo errorhandler
		
		If IsDate(txtDateCompleted.CtlText) = False And txtDateCompleted.CtlText <> "" Then
			MsgBox("Incorrect Format. Please Re-enter.")
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: WO - txtDateCompleted_Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub txtLabor_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtLabor.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		On Error GoTo errorhandler
		
		If IsNumeric(txtLabor.Text) = False And txtLabor.Text <> "" Then
			MsgBox("Incorrect Format. Please Re-enter.")
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: WO - txtLabor_Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub txtMaterialsCost_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtMaterialsCost.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		On Error GoTo errorhandler
		
		If IsNumeric(txtMaterialsCost.Text) = False And txtMaterialsCost.Text <> "" Then
			MsgBox("Incorrect Format. Please Re-enter.")
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: WO - txtMaterialsCost_Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub txtMeterReadingAtCompletion_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtMeterReadingAtCompletion.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		On Error GoTo errorhandler
		
		If IsNumeric(txtMeterReadingAtCompletion.Text) = False And txtMeterReadingAtCompletion.Text <> "" Then
			MsgBox("Incorrect Format. Please Re-enter.")
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: WO - txtMeterReadingAtCompletion_Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	
	'Public Sub CalculateFields(intTaskID As Integer)
	' get the datelastcompleted, meterreadingwhenlastcompleted, intervaldays, intervalmeter
	'    Dim intIntervalDays, intIntervalMeter, intDueMeter, intLastWorkedMeter As Integer
	'    Dim dtLastWorkedDate, dtDueDate As Date
	' it would otherwise tell me that it already is at the eof or bof
	'    rsTaskWO.MoveFirst
	'    rsTaskWO.Find ("task_id = " & intTaskID)
	'    Select Case rsTaskWO!cycle_type
	'    Case "unscheduled"
	' do nothing because the values are not supposed to be calculated
	'        txtWorkDueWhenMeterReads.Text = ""
	'        txtWorkDueDate.Text = ""
	'    Case "Days Cycle"
	'        dtLastWorkedDate = rsTaskWO!last_worked_date
	'        If IsNull(dtLastWorkedDate) Then
	' ask Bob if he agrees this rule
	'            dtLastWorkedDate = rsTaskWO!date_task_created
	'        End If
	'       intIntervalDays = rsTaskWO!interval_days
	'       dtDueDate = dtLastWorkedDate + intIntervalDays
	'       txtWorkDueDate.Text = Format(dtDueDate, "mm/dd/yy")
	'   Case "Meter Cycle"
	'       If IsNull(rsTaskWO!last_worked_meter_reading) Then
	'           intLastWorkedMeter = 0
	'       Else
	'           intLastWorkedMeter = rsTaskWO!last_worked_meter_reading
	'       End If
	'       If IsNull(rsTaskWO!interval_meter) Then
	'           intIntervalMeter = 0
	'       Else
	'           intIntervalMeter = rsTaskWO!interval_meter
	'       End If
	'       intDueMeter = intLastWorkedMeter + intIntervalDays
	'       txtWorkDueWhenMeterReads.Text = intDueMeter
	'   End Select
	'End Sub
	
	'Private Sub cboEquipID_GotFocus()
	'    Dim intLen, intPos As Integer
	'
	'    intEquipIDStore = 0
	'    strEquipIDStore = ""
	'    If cboEquipID.Text <> "" Then
	'        strEquipIDStore = cboEquipID.Text
	'    End If
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
	Public Sub PrintReports()
		Dim DRptWOSum As Object
		Dim DRptWOList As Object
		
		On Error GoTo errorhandler
		
		DEnvWos.conWOS.Open()
		'DEnvWos.ComWOList intPlantPass, strSearchOpt, strSearchEquipKey, strSearchEquipDesc, strSearchTaskDesc, strSearchMiscComments, strSearchComments, strSearchInitial, strSearchDate1, strSearchDate2, intPlantPass, strSearchOpt, strSearchEquipKey, strSearchEquipDesc, strSearchTaskDesc, strSearchMiscComments, strSearchComments, strSearchInitial, strSearchDate1, strSearchDate2
		
		Dim cn As ADODB.Connection
		Dim rs As ADODB.Recordset
		Dim strSQL As String
		
		cn = New ADODB.Connection
		rs = New ADODB.Recordset
		
		cn.Open("Provider=MSDataShape;Data Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Program Files\WORK ORDER\WOS.mdb;")
		
		'UPGRADE_WARNING: Couldn't resolve default property of object strSearchDate1. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		'UPGRADE_WARNING: Couldn't resolve default property of object strSearchInitial. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		'UPGRADE_WARNING: Couldn't resolve default property of object strSearchMiscComments. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		'UPGRADE_WARNING: Couldn't resolve default property of object strSearchTaskDesc. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		'UPGRADE_WARNING: Couldn't resolve default property of object strSearchEquipKey. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		strSQL = "SHAPE {SELECT DISTINCT equipment.equip_key, equipment.equip_id, equipment.equip_desc FROM " & "(plant INNER JOIN (equipment INNER JOIN task ON equipment.equip_id = task.equip_id) ON " & "plant.plant_id = equipment.plant_fk) INNER JOIN work_order ON task.task_id = work_order.task_id " & "WHERE ((work_order.plant_fk = " & CStr(intPlantPass) & " AND " & CStr(intPlantPass) & " <> 0) OR (work_order.plant_fk <> 0 AND " & CStr(intPlantPass) & " = 0)) AND " & "(('" & strSearchOpt & "' = 'ALL') OR ('" & strSearchOpt & "' = 'Unschedule' AND task.cycle_type = 'Unschedule') OR " & "('" & strSearchOpt & "' = 'DueDate' AND task.cycle_type = 'Days Cycle') OR ('" & strSearchOpt & "' = 'DueMeter' AND " & "task.cycle_type = 'Meter Cycle')) AND " & "(('" & strSearchEquipKey & "' = 'XXXXXXXXXXX') OR ('" & strSearchEquipKey & "' <> 'XXXXXXXXXXX' AND " & "equipment.equip_key = '" & strSearchEquipKey & "')) AND " & "(('" & strSearchEquipDesc & "' = 'XXXXXXXXXXX') OR ('" & strSearchEquipDesc & "' <> 'XXXXXXXXXXX' AND equipment.equip_desc " & "LIKE '%" & strSearchEquipDesc & "%')) AND (('" & strSearchTaskDesc & "' = 'XXXXXXXXXXX') OR " & "('" & strSearchTaskDesc & "' <> 'XXXXXXXXXXX' AND " & "task.task_desc LIKE '%" & strSearchTaskDesc & "%')) AND (('" & strSearchMiscComments & "' = 'XXXXXXXXXXX') OR " & "('" & strSearchMiscComments & "' <> 'XXXXXXXXXXX' AND task.misc_comments LIKE '%" & strSearchMiscComments & "%')) AND " & "(('" & strSearchComments & "' = 'XXXXXXXXXXX') OR ('" & strSearchComments & "' <> 'XXXXXXXXXXX' AND work_order.comments " & "LIKE '%" & strSearchComments & "%')) AND (('" & strSearchInitial & "' = 'XXXXXXXXXXX') OR ('" & strSearchInitial & "' <> 'XXXXXXXXXXX' AND " & "work_order.completed_by LIKE '%" & strSearchInitial & "%')) AND (('" & strSearchDate1 & "' = '01/01/1955') OR " & "('" & strSearchDate1 & "' <> '01/01/1955' AND work_order.date_work_completed >= datevalue('" & strSearchDate1 & "'))) AND " & "(('" & strSearchDate2 & "' = '01/01/2999') OR ('" & strSearchDate2 & "' <> '01/01/2999' AND " & "work_order.date_work_completed <= datevalue('" & strSearchDate2 & "'))) " & "ORDER BY equipment.equip_key;} AS ComWOList APPEND "
		
		'UPGRADE_WARNING: Couldn't resolve default property of object strSearchDate1. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		'UPGRADE_WARNING: Couldn't resolve default property of object strSearchInitial. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		'UPGRADE_WARNING: Couldn't resolve default property of object strSearchMiscComments. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		'UPGRADE_WARNING: Couldn't resolve default property of object strSearchTaskDesc. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		'UPGRADE_WARNING: Couldn't resolve default property of object strSearchEquipKey. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		strSQL = strSQL & "({SELECT work_order.*, task.*, equipment.*, plant.* FROM (plant INNER JOIN (equipment INNER JOIN task ON " & "equipment.equip_id = task.equip_id) ON plant.plant_id = equipment.plant_fk) INNER JOIN work_order ON " & "task.task_id = work_order.task_id " & "WHERE ((work_order.plant_fk = " & CStr(intPlantPass) & " AND " & CStr(intPlantPass) & " <> 0) OR (work_order.plant_fk <> 0 AND " & CStr(intPlantPass) & " = 0)) AND " & "(('" & strSearchOpt & "' = 'ALL') OR ('" & strSearchOpt & "' = 'Unschedule' AND task.cycle_type = 'Unschedule') OR " & "('" & strSearchOpt & "' = 'DueDate' AND task.cycle_type = 'Days Cycle') OR ('" & strSearchOpt & "' = 'DueMeter' AND " & "task.cycle_type = 'Meter Cycle')) AND " & "(('" & strSearchEquipKey & "' = 'XXXXXXXXXXX') OR ('" & strSearchEquipKey & "' <> 'XXXXXXXXXXX' AND " & "equipment.equip_key = '" & strSearchEquipKey & "')) AND " & "(('" & strSearchEquipDesc & "' = 'XXXXXXXXXXX') OR ('" & strSearchEquipDesc & "' <> 'XXXXXXXXXXX' AND equipment.equip_desc " & "LIKE '%" & strSearchEquipDesc & "%')) AND (('" & strSearchTaskDesc & "' = 'XXXXXXXXXXX') OR " & "('" & strSearchTaskDesc & "' <> 'XXXXXXXXXXX' AND " & "task.task_desc LIKE '%" & strSearchTaskDesc & "%')) AND (('" & strSearchMiscComments & "' = 'XXXXXXXXXXX') OR " & "('" & strSearchMiscComments & "' <> 'XXXXXXXXXXX' AND task.misc_comments LIKE '%" & strSearchMiscComments & "%')) AND " & "(('" & strSearchComments & "' = 'XXXXXXXXXXX') OR ('" & strSearchComments & "' <> 'XXXXXXXXXXX' AND work_order.comments " & "LIKE '%" & strSearchComments & "%')) AND (('" & strSearchInitial & "' = 'XXXXXXXXXXX') OR ('" & strSearchInitial & "' <> 'XXXXXXXXXXX' AND " & "work_order.completed_by LIKE '%" & strSearchInitial & "%')) AND (('" & strSearchDate1 & "' = '01/01/1955') OR " & "('" & strSearchDate1 & "' <> '01/01/1955' AND work_order.date_work_completed >= datevalue('" & strSearchDate1 & "'))) AND " & "(('" & strSearchDate2 & "' = '01/01/2999') OR ('" & strSearchDate2 & "' <> '01/01/2999' AND " & "work_order.date_work_completed <= datevalue('" & strSearchDate2 & "'))) " & "ORDER BY equipment.equip_key ASC, work_order.date_work_completed ASC;} " & "AS ComWOList2 RELATE 'equip_id' TO 'work_order.equip_id') AS ComWOList2"
		
		rs.Open(strSQL, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText)
		
		DEnvWos.rsComWOList.DataSource = rs
		
		rs.Close()
		cn.Close()
		
		'UPGRADE_NOTE: Object rs may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1029"'
		rs = Nothing
		'UPGRADE_NOTE: Object cn may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1029"'
		cn = Nothing
		
		ans = MsgBox("Please, click YES to get detail report, and NO to get summarized report.", MsgBoxStyle.YesNo)
		If ans = 6 Then
			'open wo detail report
			'UPGRADE_WARNING: Couldn't resolve default property of object DRptWOList.Show. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			DRptWOList.Show(1)
			'UPGRADE_WARNING: Couldn't resolve default property of object DRptWOList.Top. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			DRptWOList.Top = 1100
			'UPGRADE_WARNING: Couldn't resolve default property of object DRptWOList.Left. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			DRptWOList.Left = 1
			'UPGRADE_WARNING: Couldn't resolve default property of object DRptWOList.Height. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			DRptWOList.Height = 6400
			'UPGRADE_WARNING: Couldn't resolve default property of object DRptWOList.Width. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			DRptWOList.Width = 9300
			
		Else
			' open wo summary report
			'UPGRADE_WARNING: Couldn't resolve default property of object DRptWOSum.Show. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			DRptWOSum.Show(1)
			'UPGRADE_WARNING: Couldn't resolve default property of object DRptWOSum.Top. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			DRptWOSum.Top = 1100
			'UPGRADE_WARNING: Couldn't resolve default property of object DRptWOSum.Left. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			DRptWOSum.Left = 1
			'UPGRADE_WARNING: Couldn't resolve default property of object DRptWOSum.Height. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			DRptWOSum.Height = 6400
			'UPGRADE_WARNING: Couldn't resolve default property of object DRptWOSum.Width. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			DRptWOSum.Width = 9300
		End If
		
		Exit Sub
errorhandler: 
		'UPGRADE_NOTE: Object rs may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1029"'
		rs = Nothing
		'UPGRADE_NOTE: Object cn may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1029"'
		cn = Nothing
		
		MsgBox("Error Number - " & Err.Number & ": WOS: WO - PrintReports: Description - " & Err.Description)
	End Sub
	
	Public Function FindRecords(ByVal strOption As String, ByVal strEquipKey As String, ByVal strEquipDesc As String, ByVal strTaskDesc As String, ByVal strTaskMiscComments As String, ByVal strWOComments As String, ByVal strInitial As String, ByVal strDate1 As String, ByVal strDate2 As String, ByVal intRetrievalType As Short) As Short
		Dim intResult As Short
		Dim strInitialString As Object
		Dim strSQL As String
		Dim rsCheck As ADODB.Recordset
		
		On Error GoTo errorhandler
		
		' intRetrievalType is used to know if it is just a check or we need to refresh the window
		'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		strInitialString = ""
		Select Case strOption
			Case "DueDate"
				'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				strInitialString = " task.cycle_type = 'Days Cycle' "
			Case "DueMeter"
				'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				strInitialString = " task.cycle_type = 'Meter Cycle' "
			Case "Unschedule"
				'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				strInitialString = " task.cycle_type = 'Unschedule' "
		End Select
		If strEquipKey <> "" Then
			'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			If strInitialString <> "" Then
				'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				strInitialString = strInitialString & " and equip_key = '" & Trim(strEquipKey) & "' "
			Else
				'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				strInitialString = " equip_key = '" & Trim(strEquipKey) & "' "
			End If
		End If
		If strEquipDesc <> "" Then
			'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			If strInitialString <> "" Then
				'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				strInitialString = strInitialString & " and equip_desc like '%" & Trim(strEquipDesc) & "%' "
			Else
				'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				strInitialString = " equip_desc like '%" & Trim(strEquipDesc) & "%' "
			End If
		End If
		If strTaskDesc <> "" Then
			'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			If strInitialString <> "" Then
				'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				strInitialString = strInitialString & " and task_desc like '%" & Trim(strTaskDesc) & "%' "
			Else
				'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				strInitialString = " task_desc like '%" & Trim(strTaskDesc) & "%' "
			End If
		End If
		If strTaskMiscComments <> "" Then
			'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			If strInitialString <> "" Then
				'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				strInitialString = strInitialString & " and misc_comments like '%" & Trim(strTaskMiscComments) & "%'"
			Else
				'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				strInitialString = " misc_comments like '%" & Trim(strTaskMiscComments) & "%'"
			End If
		End If
		If strWOComments <> "" Then
			'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			If strInitialString <> "" Then
				'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				strInitialString = strInitialString & " and comments like '%" & Trim(strWOComments) & "%' "
			Else
				'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				strInitialString = " comments like '%" & Trim(strWOComments) & "%' "
			End If
		End If
		If strInitial <> "" Then
			'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			If strInitialString <> "" Then
				'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				strInitialString = strInitialString & " and completed_by like '%" & Trim(strInitial) & "%' "
			Else
				'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				strInitialString = " completed_by like '%" & Trim(strInitial) & "%' "
			End If
		End If
		If strDate1 <> "" Then
			'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			If strInitialString <> "" Then
				'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				strInitialString = strInitialString & " and date_work_completed >= datevalue('" & strDate1 & "') "
			Else
				'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				strInitialString = " date_work_completed >= datevalue('" & strDate1 & "') "
			End If
		End If
		If strDate2 <> "" Then
			'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			If strInitialString <> "" Then
				'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				strInitialString = strInitialString & " and date_work_completed <= datevalue('" & strDate2 & "') "
			Else
				'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				strInitialString = " date_work_completed <= datevalue('" & strDate2 & "') "
			End If
		End If
		If intPlantPass <> 0 Then
			'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			If strInitialString <> "" Then
				'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				strSQL = "SELECT work_order.*,work_order.plant_fk as plant_fk, work_order.equip_id as equip_id, work_order.task_id as task_id,task.*, equipment.*,plant.* FROM (plant INNER JOIN (equipment INNER JOIN task ON [equipment].[equip_id]=[task].[equip_id]) ON [plant].[plant_id]=[equipment].[plant_fk]) INNER JOIN work_order ON [task].[task_id]=[work_order].[task_id] where " & strInitialString & " and work_order.plant_fk = " & intPlantPass & ";"
			Else
				strSQL = "SELECT work_order.*,work_order.plant_fk as plant_fk, work_order.equip_id as equip_id, work_order.task_id as task_id, task.*, equipment.*,plant.* FROM (plant INNER JOIN (equipment INNER JOIN task ON [equipment].[equip_id]=[task].[equip_id]) ON [plant].[plant_id]=[equipment].[plant_fk]) INNER JOIN work_order ON [task].[task_id]=[work_order].[task_id] where work_order.plant_fk = " & intPlantPass & ";"
			End If
		Else
			'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			If strInitialString <> "" Then
				'UPGRADE_WARNING: Couldn't resolve default property of object strInitialString. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				strSQL = "SELECT work_order.*, work_order.plant_fk as plant_fk, work_order.equip_id as equip_id, work_order.task_id as task_id, task.*, equipment.*,plant.* FROM (plant INNER JOIN (equipment INNER JOIN task ON [equipment].[equip_id]=[task].[equip_id]) ON [plant].[plant_id]=[equipment].[plant_fk]) INNER JOIN work_order ON [task].[task_id]=[work_order].[task_id] where " & strInitialString & ";"
			Else
				strSQL = "SELECT work_order.*, work_order.plant_fk as plant_fk, work_order.equip_id as equip_id, work_order.task_id as task_id, task.*, equipment.*,plant.* FROM (plant INNER JOIN (equipment INNER JOIN task ON [equipment].[equip_id]=[task].[equip_id]) ON [plant].[plant_id]=[equipment].[plant_fk]) INNER JOIN work_order ON [task].[task_id]=[work_order].[task_id] where work_order.plant_fk <> 0; "
			End If
		End If
		If intRetrievalType = 2 Then
			Select Case strOption
				Case "DueDate"
					strSearchOpt = "DueDate"
				Case "DueMeter"
					strSearchOpt = "DueMeter"
				Case "Unschedule"
					strSearchOpt = "Unschedule"
				Case "All"
					strSearchOpt = "All"
			End Select
			
			If strEquipKey <> "" Then
				'UPGRADE_WARNING: Couldn't resolve default property of object strSearchEquipKey. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				strSearchEquipKey = strEquipKey
			Else
				'UPGRADE_WARNING: Couldn't resolve default property of object strSearchEquipKey. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				strSearchEquipKey = "XXXXXXXXXXX"
			End If
			If strEquipDesc <> "" Then
				strSearchEquipDesc = strEquipDesc
			Else
				strSearchEquipDesc = "XXXXXXXXXXX"
			End If
			If strTaskDesc <> "" Then
				'UPGRADE_WARNING: Couldn't resolve default property of object strSearchTaskDesc. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				strSearchTaskDesc = strTaskDesc
			Else
				'UPGRADE_WARNING: Couldn't resolve default property of object strSearchTaskDesc. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				strSearchTaskDesc = "XXXXXXXXXXX"
			End If
			If strTaskMiscComments <> "" Then
				'UPGRADE_WARNING: Couldn't resolve default property of object strSearchMiscComments. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				strSearchMiscComments = strTaskMiscComments
			Else
				'UPGRADE_WARNING: Couldn't resolve default property of object strSearchMiscComments. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				strSearchMiscComments = "XXXXXXXXXXX"
			End If
			If strWOComments <> "" Then
				strSearchComments = strWOComments
			Else
				strSearchComments = "XXXXXXXXXXX"
			End If
			If strInitial <> "" Then
				'UPGRADE_WARNING: Couldn't resolve default property of object strSearchInitial. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				strSearchInitial = strInitial
			Else
				'UPGRADE_WARNING: Couldn't resolve default property of object strSearchInitial. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				strSearchInitial = "XXXXXXXXXXX"
			End If
			If strDate1 <> "" Then
				'UPGRADE_WARNING: Couldn't resolve default property of object strSearchDate1. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				strSearchDate1 = strDate1
			Else
				'UPGRADE_WARNING: Couldn't resolve default property of object strSearchDate1. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				strSearchDate1 = "01/01/1955"
			End If
			If strDate2 <> "" Then
				strSearchDate2 = strDate2
			Else
				strSearchDate2 = "01/01/2999"
			End If
			'UPGRADE_WARNING: Couldn't resolve default property of object strState. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			strState = "Search"
			'UPGRADE_WARNING: Couldn't resolve default property of object strState. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			intResult = RetrieveWO(strState, strSQL)
			If intResult <> 0 Then
				FindRecords = 1
				FillFields()
				SetGrid()
				PopEquipList(rsWORetrieve.Fields("equip_id").Value)
				FillLabelsEquip()
				PopTaskList(rsWORetrieve.Fields("equip_id").Value)
				FillLabelsTask()
				cboTaskID.Text = rsWORetrieve.Fields("task_id").Value
				'CalculateFields rsWORetrieve!task_id
				Exit Function
			End If
		Else
			rsCheck = RecordsetWO(strSQL)
			If rsCheck.BOF = True Or rsCheck.EOF = True Then
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
		End If
		Exit Function
errorhandler: 
		'UPGRADE_NOTE: Object rsCheck may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1029"'
		rsCheck = Nothing
		MsgBox("Error Number - " & Err.Number & ": WOS: WO - FindRecords: Description - " & Err.Description)
	End Function
	
	Public Function CheckRecordset() As Short
		' this function is used only to find out
		' if there is recordset to work on
		Dim intResult As Short
		
		On Error GoTo errorhandler
		
		intResult = RetrieveWO("Load", "")
		
		If rsWORetrieve.EOF = True Or rsWORetrieve.BOF = True Then
			CheckRecordset = 2
			Exit Function
		Else
			CheckRecordset = 1
		End If
		'Set rsWORetrieve = Nothing
		Exit Function
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: WO - CheckRecordset: Description - " & Err.Description)
	End Function
	
	Public Sub SearchRec()
		
		On Error GoTo errorhandler
		
		VB6.ShowForm(frmSearchWO.DefInstance, (1))
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: WO - SearchRec: Description - " & Err.Description)
	End Sub
	
	Public Sub FormView()
		
		On Error GoTo errorhandler
		
		FramGrid.Visible = False
		FramForm.Visible = True
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: WO - FormView: Description - " & Err.Description)
	End Sub
	
	Public Sub GridView()
		
		On Error GoTo errorhandler
		
		FramForm.Visible = False
		FramGrid.Visible = True
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: WO - GridView: Description - " & Err.Description)
	End Sub
	
	Public Sub Cancel()
		
		On Error GoTo errorhandler
		
		Me.Close()
		frmPlant.DefInstance.CheckAll("wo")
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: WO - Cancel: Description - " & Err.Description)
	End Sub
	
	Public Sub ClearTask()
		
		On Error GoTo errorhandler
		lblTaskTaskDescD.Text = ""
		lblTaskPriorityD.Text = ""
		lblTaskCycleTypeD.Text = ""
		lblTaskIntervalDaysD.Text = ""
		lblTaskIntervalMeterD.Text = ""
		lblTaskToolsRequiredD.Text = ""
		lblTaskLastWorkedMeterD.Text = ""
		lblTaskLastWorkedDateD.Text = ""
		txtTaskMiscCommentsD.Text = ""
		lblTaskLoToD.Text = ""
		lblCreatedbyD.Text = ""
		lblWorkDueWhenMeterReadsD.Text = ""
		lblWorkDueDateD.Text = ""
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: WO - ClearTask: Description - " & Err.Description)
	End Sub
	
	Public Sub ClearEquip()
		
		On Error GoTo errorhandler
		
		Me.lblMechSerialD.Text = ""
		Me.lblMechIDD.Text = ""
		Me.lblMechModelD.Text = ""
		Me.lblMechFrameD.Text = ""
		Me.lblMechImpSzD.Text = ""
		Me.lblMechHpD.Text = ""
		Me.lblMechRpmD.Text = ""
		Me.lblMechCapD.Text = ""
		Me.lblMechSizeD.Text = ""
		Me.lblMechTdhD.Text = ""
		Me.lblMechCatNoD.Text = ""
		Me.lblMechMaxRpmD.Text = ""
		Me.lblMechMinRpmD.Text = ""
		Me.lblMechCfmD.Text = ""
		Me.lblMechOilD.Text = ""
		Me.lblMechOilFilterD.Text = ""
		Me.lblMechAirFilterD.Text = ""
		Me.lblMechBelt1D.Text = ""
		Me.lblMechBelt2D.Text = ""
		Me.lblMechPipeSizeD.Text = ""
		Me.lblMechPipeTypeD.Text = ""
		Me.lblMechNoValvesTypesD.Text = ""
		Me.lblMechMiscNPDataD.Text = ""
		Me.lblMechRecomSparePartsD.Text = ""
		Me.lblElecSerialD.Text = ""
		Me.lblElecIDD.Text = ""
		Me.lblElecModelD.Text = ""
		Me.lblElecFrameD.Text = ""
		Me.lblElecCatNoD.Text = ""
		Me.lblElecHpD.Text = ""
		Me.lblElecRpmD.Text = ""
		Me.lblElecVD.Text = ""
		Me.lblElecAmpD.Text = ""
		Me.lblElecHzD.Text = ""
		Me.lblElecPhsD.Text = ""
		Me.lblElecSfD.Text = ""
		Me.lblElecDutyD.Text = ""
		Me.lblElecInslClD.Text = ""
		Me.lblElecDesignD.Text = ""
		Me.lblElecShaftEndBrgD.Text = ""
		Me.lblElecOppEndBrgD.Text = ""
		Me.lblElecMiscNPDataD.Text = ""
		Me.lblElecRecomSparePartsD.Text = ""
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: WO - ClearEquip: Description - " & Err.Description)
	End Sub
End Class