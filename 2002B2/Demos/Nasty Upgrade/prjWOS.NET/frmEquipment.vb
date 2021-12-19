Option Strict Off
Option Explicit On
Friend Class frmEquipment
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
	Public WithEvents txtCount As System.Windows.Forms.TextBox
	Public WithEvents txtEquipKey As System.Windows.Forms.TextBox
	Public WithEvents txtEquipDesc As System.Windows.Forms.TextBox
	Public WithEvents txtMeterReading As System.Windows.Forms.TextBox
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
	Public WithEvents txtMechTdh As System.Windows.Forms.TextBox
	Public WithEvents txtMechSize As System.Windows.Forms.TextBox
	Public WithEvents txtMechCap As System.Windows.Forms.TextBox
	Public WithEvents txtMechRpm As System.Windows.Forms.TextBox
	Public WithEvents txtMechHp As System.Windows.Forms.TextBox
	Public WithEvents txtMechImpSz As System.Windows.Forms.TextBox
	Public WithEvents txtMechModel As System.Windows.Forms.TextBox
	Public WithEvents txtMechFrame As System.Windows.Forms.TextBox
	Public WithEvents txtMechID As System.Windows.Forms.TextBox
	Public WithEvents txtMechSerial As System.Windows.Forms.TextBox
	Public WithEvents txtMechCfm As System.Windows.Forms.TextBox
	Public WithEvents txtMechMinRpm As System.Windows.Forms.TextBox
	Public WithEvents txtMechMaxRpm As System.Windows.Forms.TextBox
	Public WithEvents txtMechCatNo As System.Windows.Forms.TextBox
	Public WithEvents txtMechRecomSpareParts As System.Windows.Forms.TextBox
	Public WithEvents txtMechMiscNPData As System.Windows.Forms.TextBox
	Public WithEvents txtMechNoOfValvesTypes As System.Windows.Forms.TextBox
	Public WithEvents txtMechPipeType As System.Windows.Forms.TextBox
	Public WithEvents txtMechPipeSize As System.Windows.Forms.TextBox
	Public WithEvents txtMechOil As System.Windows.Forms.TextBox
	Public WithEvents txtMechOilFilter As System.Windows.Forms.TextBox
	Public WithEvents txtMechAirFilter As System.Windows.Forms.TextBox
	Public WithEvents txtMechBelt1 As System.Windows.Forms.TextBox
	Public WithEvents txtMechBelt2 As System.Windows.Forms.TextBox
	Public WithEvents _SSTab1_TabPage0 As System.Windows.Forms.TabPage
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
	Public WithEvents txtElecSerial As System.Windows.Forms.TextBox
	Public WithEvents txtElecID As System.Windows.Forms.TextBox
	Public WithEvents txtElecModel As System.Windows.Forms.TextBox
	Public WithEvents txtElecSf As System.Windows.Forms.TextBox
	Public WithEvents txtElecPhs As System.Windows.Forms.TextBox
	Public WithEvents txtElecRpm As System.Windows.Forms.TextBox
	Public WithEvents txtElecHp As System.Windows.Forms.TextBox
	Public WithEvents txtElecCatNo As System.Windows.Forms.TextBox
	Public WithEvents txtElecFrame As System.Windows.Forms.TextBox
	Public WithEvents txtElecDesign As System.Windows.Forms.TextBox
	Public WithEvents txtElecInslCl As System.Windows.Forms.TextBox
	Public WithEvents txtElecDuty As System.Windows.Forms.TextBox
	Public WithEvents txtElecAmp As System.Windows.Forms.TextBox
	Public WithEvents txtElecV As System.Windows.Forms.TextBox
	Public WithEvents txtElecOppEndBrg As System.Windows.Forms.TextBox
	Public WithEvents txtElecShaftEndBrg As System.Windows.Forms.TextBox
	Public WithEvents txtElecMiscNpData As System.Windows.Forms.TextBox
	Public WithEvents txtElecRecomSpareParts As System.Windows.Forms.TextBox
	Public WithEvents txtElecHz As System.Windows.Forms.TextBox
	Public WithEvents _SSTab1_TabPage1 As System.Windows.Forms.TabPage
	Public WithEvents SSTab1 As System.Windows.Forms.TabControl
	Public WithEvents txtMeterReadingDate As AxMSMask.AxMaskEdBox
	Public WithEvents lblPlantName As System.Windows.Forms.Label
	Public WithEvents lblEquipKey As System.Windows.Forms.Label
	Public WithEvents lblEquipDesc As System.Windows.Forms.Label
	Public WithEvents lblLastMeterReadingDate As System.Windows.Forms.Label
	Public WithEvents lblLastMeterReading As System.Windows.Forms.Label
	Public WithEvents Framform As System.Windows.Forms.GroupBox
	Public WithEvents DGridEquipment As AxMSDataGridLib.AxDataGrid
	Public WithEvents lblPlantNameG As System.Windows.Forms.Label
	Public WithEvents FramGrid As System.Windows.Forms.GroupBox
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmEquipment))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ToolTip1.Active = True
		Me.cmdPrintForm = New System.Windows.Forms.Button
		Me.Framform = New System.Windows.Forms.GroupBox
		Me.txtCount = New System.Windows.Forms.TextBox
		Me.txtEquipKey = New System.Windows.Forms.TextBox
		Me.txtEquipDesc = New System.Windows.Forms.TextBox
		Me.txtMeterReading = New System.Windows.Forms.TextBox
		Me.SSTab1 = New System.Windows.Forms.TabControl
		Me._SSTab1_TabPage0 = New System.Windows.Forms.TabPage
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
		Me.txtMechTdh = New System.Windows.Forms.TextBox
		Me.txtMechSize = New System.Windows.Forms.TextBox
		Me.txtMechCap = New System.Windows.Forms.TextBox
		Me.txtMechRpm = New System.Windows.Forms.TextBox
		Me.txtMechHp = New System.Windows.Forms.TextBox
		Me.txtMechImpSz = New System.Windows.Forms.TextBox
		Me.txtMechModel = New System.Windows.Forms.TextBox
		Me.txtMechFrame = New System.Windows.Forms.TextBox
		Me.txtMechID = New System.Windows.Forms.TextBox
		Me.txtMechSerial = New System.Windows.Forms.TextBox
		Me.txtMechCfm = New System.Windows.Forms.TextBox
		Me.txtMechMinRpm = New System.Windows.Forms.TextBox
		Me.txtMechMaxRpm = New System.Windows.Forms.TextBox
		Me.txtMechCatNo = New System.Windows.Forms.TextBox
		Me.txtMechRecomSpareParts = New System.Windows.Forms.TextBox
		Me.txtMechMiscNPData = New System.Windows.Forms.TextBox
		Me.txtMechNoOfValvesTypes = New System.Windows.Forms.TextBox
		Me.txtMechPipeType = New System.Windows.Forms.TextBox
		Me.txtMechPipeSize = New System.Windows.Forms.TextBox
		Me.txtMechOil = New System.Windows.Forms.TextBox
		Me.txtMechOilFilter = New System.Windows.Forms.TextBox
		Me.txtMechAirFilter = New System.Windows.Forms.TextBox
		Me.txtMechBelt1 = New System.Windows.Forms.TextBox
		Me.txtMechBelt2 = New System.Windows.Forms.TextBox
		Me._SSTab1_TabPage1 = New System.Windows.Forms.TabPage
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
		Me.txtElecSerial = New System.Windows.Forms.TextBox
		Me.txtElecID = New System.Windows.Forms.TextBox
		Me.txtElecModel = New System.Windows.Forms.TextBox
		Me.txtElecSf = New System.Windows.Forms.TextBox
		Me.txtElecPhs = New System.Windows.Forms.TextBox
		Me.txtElecRpm = New System.Windows.Forms.TextBox
		Me.txtElecHp = New System.Windows.Forms.TextBox
		Me.txtElecCatNo = New System.Windows.Forms.TextBox
		Me.txtElecFrame = New System.Windows.Forms.TextBox
		Me.txtElecDesign = New System.Windows.Forms.TextBox
		Me.txtElecInslCl = New System.Windows.Forms.TextBox
		Me.txtElecDuty = New System.Windows.Forms.TextBox
		Me.txtElecAmp = New System.Windows.Forms.TextBox
		Me.txtElecV = New System.Windows.Forms.TextBox
		Me.txtElecOppEndBrg = New System.Windows.Forms.TextBox
		Me.txtElecShaftEndBrg = New System.Windows.Forms.TextBox
		Me.txtElecMiscNpData = New System.Windows.Forms.TextBox
		Me.txtElecRecomSpareParts = New System.Windows.Forms.TextBox
		Me.txtElecHz = New System.Windows.Forms.TextBox
		Me.txtMeterReadingDate = New AxMSMask.AxMaskEdBox
		Me.lblPlantName = New System.Windows.Forms.Label
		Me.lblEquipKey = New System.Windows.Forms.Label
		Me.lblEquipDesc = New System.Windows.Forms.Label
		Me.lblLastMeterReadingDate = New System.Windows.Forms.Label
		Me.lblLastMeterReading = New System.Windows.Forms.Label
		Me.FramGrid = New System.Windows.Forms.GroupBox
		Me.DGridEquipment = New AxMSDataGridLib.AxDataGrid
		Me.lblPlantNameG = New System.Windows.Forms.Label
		CType(Me.txtMeterReadingDate, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.DGridEquipment, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Text = "Equipment"
		Me.ClientSize = New System.Drawing.Size(706, 467)
		Me.Location = New System.Drawing.Point(4, 23)
		Me.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds
		Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
		Me.AutoScaleBaseSize = New System.Drawing.Size(8, 19)
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
		Me.Name = "frmEquipment"
		Me.cmdPrintForm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPrintForm.Text = "Print Equipment"
		Me.cmdPrintForm.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdPrintForm.Size = New System.Drawing.Size(89, 25)
		Me.cmdPrintForm.Location = New System.Drawing.Point(512, 440)
		Me.cmdPrintForm.TabIndex = 101
		Me.cmdPrintForm.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPrintForm.CausesValidation = True
		Me.cmdPrintForm.Enabled = True
		Me.cmdPrintForm.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPrintForm.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPrintForm.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPrintForm.TabStop = True
		Me.cmdPrintForm.Name = "cmdPrintForm"
		Me.Framform.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Framform.Size = New System.Drawing.Size(593, 433)
		Me.Framform.Location = New System.Drawing.Point(8, 0)
		Me.Framform.TabIndex = 0
		Me.Framform.BackColor = System.Drawing.SystemColors.Control
		Me.Framform.Enabled = True
		Me.Framform.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Framform.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Framform.Visible = True
		Me.Framform.Name = "Framform"
		Me.txtCount.AutoSize = False
		Me.txtCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		Me.txtCount.Enabled = False
		Me.txtCount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtCount.ForeColor = System.Drawing.Color.Blue
		Me.txtCount.Size = New System.Drawing.Size(177, 19)
		Me.txtCount.Location = New System.Drawing.Point(192, 0)
		Me.txtCount.ReadOnly = True
		Me.txtCount.TabIndex = 96
		Me.txtCount.TabStop = False
		Me.txtCount.Text = "1"
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
		Me.txtEquipKey.AutoSize = False
		Me.txtEquipKey.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtEquipKey.Size = New System.Drawing.Size(81, 19)
		Me.txtEquipKey.Location = New System.Drawing.Point(104, 32)
		Me.txtEquipKey.Maxlength = 10
		Me.txtEquipKey.TabIndex = 1
		Me.txtEquipKey.AcceptsReturn = True
		Me.txtEquipKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtEquipKey.BackColor = System.Drawing.SystemColors.Window
		Me.txtEquipKey.CausesValidation = True
		Me.txtEquipKey.Enabled = True
		Me.txtEquipKey.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtEquipKey.HideSelection = True
		Me.txtEquipKey.ReadOnly = False
		Me.txtEquipKey.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtEquipKey.MultiLine = False
		Me.txtEquipKey.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtEquipKey.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtEquipKey.TabStop = True
		Me.txtEquipKey.Visible = True
		Me.txtEquipKey.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtEquipKey.Name = "txtEquipKey"
		Me.txtEquipDesc.AutoSize = False
		Me.txtEquipDesc.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtEquipDesc.Size = New System.Drawing.Size(449, 43)
		Me.txtEquipDesc.Location = New System.Drawing.Point(104, 56)
		Me.txtEquipDesc.Maxlength = 100
		Me.txtEquipDesc.MultiLine = True
		Me.txtEquipDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.txtEquipDesc.TabIndex = 4
		Me.txtEquipDesc.AcceptsReturn = True
		Me.txtEquipDesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtEquipDesc.BackColor = System.Drawing.SystemColors.Window
		Me.txtEquipDesc.CausesValidation = True
		Me.txtEquipDesc.Enabled = True
		Me.txtEquipDesc.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtEquipDesc.HideSelection = True
		Me.txtEquipDesc.ReadOnly = False
		Me.txtEquipDesc.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtEquipDesc.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtEquipDesc.TabStop = True
		Me.txtEquipDesc.Visible = True
		Me.txtEquipDesc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtEquipDesc.Name = "txtEquipDesc"
		Me.txtMeterReading.AutoSize = False
		Me.txtMeterReading.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtMeterReading.Size = New System.Drawing.Size(65, 19)
		Me.txtMeterReading.Location = New System.Drawing.Point(280, 32)
		Me.txtMeterReading.TabIndex = 2
		Me.txtMeterReading.AcceptsReturn = True
		Me.txtMeterReading.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtMeterReading.BackColor = System.Drawing.SystemColors.Window
		Me.txtMeterReading.CausesValidation = True
		Me.txtMeterReading.Enabled = True
		Me.txtMeterReading.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtMeterReading.HideSelection = True
		Me.txtMeterReading.ReadOnly = False
		Me.txtMeterReading.Maxlength = 0
		Me.txtMeterReading.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtMeterReading.MultiLine = False
		Me.txtMeterReading.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtMeterReading.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtMeterReading.TabStop = True
		Me.txtMeterReading.Visible = True
		Me.txtMeterReading.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtMeterReading.Name = "txtMeterReading"
		Me.SSTab1.Size = New System.Drawing.Size(545, 321)
		Me.SSTab1.Location = New System.Drawing.Point(24, 104)
		Me.SSTab1.TabIndex = 48
		Me.SSTab1.SelectedIndex = 1
		Me.SSTab1.ItemSize = New System.Drawing.Size(42, 18)
		Me.SSTab1.ForeColor = System.Drawing.Color.FromARGB(0, 0, 255)
		Me.SSTab1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.SSTab1.Name = "SSTab1"
		Me._SSTab1_TabPage0.Text = "Mechanical NP Data"
		Me.lblMechRecomSpareParts.Text = "Recommended Spare Parts"
		Me.lblMechRecomSpareParts.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechRecomSpareParts.Size = New System.Drawing.Size(137, 17)
		Me.lblMechRecomSpareParts.Location = New System.Drawing.Point(32, 296)
		Me.lblMechRecomSpareParts.TabIndex = 49
		Me.lblMechRecomSpareParts.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
		Me.lblMechMiscNPData.Text = "Misc. NP Data"
		Me.lblMechMiscNPData.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechMiscNPData.Size = New System.Drawing.Size(73, 17)
		Me.lblMechMiscNPData.Location = New System.Drawing.Point(88, 248)
		Me.lblMechMiscNPData.TabIndex = 50
		Me.lblMechMiscNPData.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
		Me.lblMechNoValvesTypes.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechNoValvesTypes.Size = New System.Drawing.Size(113, 17)
		Me.lblMechNoValvesTypes.Location = New System.Drawing.Point(56, 224)
		Me.lblMechNoValvesTypes.TabIndex = 51
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
		Me.lblMechPipeType.Text = "Pipe Type"
		Me.lblMechPipeType.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechPipeType.Size = New System.Drawing.Size(49, 17)
		Me.lblMechPipeType.Location = New System.Drawing.Point(112, 200)
		Me.lblMechPipeType.TabIndex = 52
		Me.lblMechPipeType.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
		Me.lblMechPipeSize.Text = "Pipe Size(s)"
		Me.lblMechPipeSize.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechPipeSize.Size = New System.Drawing.Size(65, 17)
		Me.lblMechPipeSize.Location = New System.Drawing.Point(104, 176)
		Me.lblMechPipeSize.TabIndex = 53
		Me.lblMechPipeSize.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
		Me.lblMechcfm.Text = "cfm"
		Me.lblMechcfm.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechcfm.Size = New System.Drawing.Size(25, 17)
		Me.lblMechcfm.Location = New System.Drawing.Point(152, 104)
		Me.lblMechcfm.TabIndex = 54
		Me.lblMechcfm.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
		Me.lblMechMaxRpm.Text = "max rpm"
		Me.lblMechMaxRpm.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechMaxRpm.Size = New System.Drawing.Size(41, 17)
		Me.lblMechMaxRpm.Location = New System.Drawing.Point(432, 80)
		Me.lblMechMaxRpm.TabIndex = 55
		Me.lblMechMaxRpm.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
		Me.lblMechMinRpm.Text = "min rpm"
		Me.lblMechMinRpm.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechMinRpm.Size = New System.Drawing.Size(41, 17)
		Me.lblMechMinRpm.Location = New System.Drawing.Point(16, 104)
		Me.lblMechMinRpm.TabIndex = 56
		Me.lblMechMinRpm.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
		Me.lblMechCatNo.Text = "cat no"
		Me.lblMechCatNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechCatNo.Size = New System.Drawing.Size(33, 17)
		Me.lblMechCatNo.Location = New System.Drawing.Point(256, 80)
		Me.lblMechCatNo.TabIndex = 57
		Me.lblMechCatNo.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
		Me.lblMechSize.Text = "size"
		Me.lblMechSize.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechSize.Size = New System.Drawing.Size(25, 17)
		Me.lblMechSize.Location = New System.Drawing.Point(32, 80)
		Me.lblMechSize.TabIndex = 58
		Me.lblMechSize.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
		Me.lblMechtdh.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechtdh.Size = New System.Drawing.Size(17, 17)
		Me.lblMechtdh.Location = New System.Drawing.Point(152, 80)
		Me.lblMechtdh.TabIndex = 59
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
		Me.lblMechCap.Text = "cap"
		Me.lblMechCap.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechCap.Size = New System.Drawing.Size(25, 17)
		Me.lblMechCap.Location = New System.Drawing.Point(448, 56)
		Me.lblMechCap.TabIndex = 60
		Me.lblMechCap.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
		Me.lblMechRpm.Text = "rpm"
		Me.lblMechRpm.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechRpm.Size = New System.Drawing.Size(25, 17)
		Me.lblMechRpm.Location = New System.Drawing.Point(360, 56)
		Me.lblMechRpm.TabIndex = 61
		Me.lblMechRpm.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
		Me.lblMechHp.Text = "hp"
		Me.lblMechHp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechHp.Size = New System.Drawing.Size(17, 17)
		Me.lblMechHp.Location = New System.Drawing.Point(280, 56)
		Me.lblMechHp.TabIndex = 62
		Me.lblMechHp.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
		Me.lblMechImpSz.Text = "imp sz"
		Me.lblMechImpSz.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechImpSz.Size = New System.Drawing.Size(33, 17)
		Me.lblMechImpSz.Location = New System.Drawing.Point(144, 56)
		Me.lblMechImpSz.TabIndex = 63
		Me.lblMechImpSz.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
		Me.lblMechFrame.Text = "frame"
		Me.lblMechFrame.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechFrame.Size = New System.Drawing.Size(33, 17)
		Me.lblMechFrame.Location = New System.Drawing.Point(24, 56)
		Me.lblMechFrame.TabIndex = 64
		Me.lblMechFrame.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
		Me.lblMechModel.Text = "model"
		Me.lblMechModel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechModel.Size = New System.Drawing.Size(33, 17)
		Me.lblMechModel.Location = New System.Drawing.Point(368, 32)
		Me.lblMechModel.TabIndex = 65
		Me.lblMechModel.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
		Me.lblMechID.Text = "id"
		Me.lblMechID.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechID.Size = New System.Drawing.Size(17, 17)
		Me.lblMechID.Location = New System.Drawing.Point(208, 32)
		Me.lblMechID.TabIndex = 66
		Me.lblMechID.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
		Me.lblMechSerial.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.lblMechSerial.Text = "serial"
		Me.lblMechSerial.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechSerial.Size = New System.Drawing.Size(33, 17)
		Me.lblMechSerial.Location = New System.Drawing.Point(24, 32)
		Me.lblMechSerial.TabIndex = 67
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
		Me.lblMechOil.Text = "Oil"
		Me.lblMechOil.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechOil.Size = New System.Drawing.Size(17, 17)
		Me.lblMechOil.Location = New System.Drawing.Point(280, 104)
		Me.lblMechOil.TabIndex = 87
		Me.lblMechOil.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
		Me.lblMechOilFilter.Text = "Oil Filter"
		Me.lblMechOilFilter.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechOilFilter.Size = New System.Drawing.Size(41, 17)
		Me.lblMechOilFilter.Location = New System.Drawing.Point(16, 128)
		Me.lblMechOilFilter.TabIndex = 88
		Me.lblMechOilFilter.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
		Me.lblMechAirFilter.Text = "Air Filter"
		Me.lblMechAirFilter.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechAirFilter.Size = New System.Drawing.Size(41, 17)
		Me.lblMechAirFilter.Location = New System.Drawing.Point(256, 128)
		Me.lblMechAirFilter.TabIndex = 89
		Me.lblMechAirFilter.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
		Me.lblMechBelt1.Text = "Belt1"
		Me.lblMechBelt1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechBelt1.Size = New System.Drawing.Size(25, 17)
		Me.lblMechBelt1.Location = New System.Drawing.Point(24, 152)
		Me.lblMechBelt1.TabIndex = 90
		Me.lblMechBelt1.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
		Me.lblMechBelt2.Text = "Belt2"
		Me.lblMechBelt2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMechBelt2.Size = New System.Drawing.Size(25, 17)
		Me.lblMechBelt2.Location = New System.Drawing.Point(264, 152)
		Me.lblMechBelt2.TabIndex = 91
		Me.lblMechBelt2.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
		Me.txtMechTdh.AutoSize = False
		Me.txtMechTdh.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtMechTdh.Size = New System.Drawing.Size(49, 19)
		Me.txtMechTdh.Location = New System.Drawing.Point(176, 80)
		Me.txtMechTdh.Maxlength = 5
		Me.txtMechTdh.TabIndex = 14
		Me.txtMechTdh.AcceptsReturn = True
		Me.txtMechTdh.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtMechTdh.BackColor = System.Drawing.SystemColors.Window
		Me.txtMechTdh.CausesValidation = True
		Me.txtMechTdh.Enabled = True
		Me.txtMechTdh.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtMechTdh.HideSelection = True
		Me.txtMechTdh.ReadOnly = False
		Me.txtMechTdh.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtMechTdh.MultiLine = False
		Me.txtMechTdh.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtMechTdh.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtMechTdh.TabStop = True
		Me.txtMechTdh.Visible = True
		Me.txtMechTdh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtMechTdh.Name = "txtMechTdh"
		Me.txtMechSize.AutoSize = False
		Me.txtMechSize.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtMechSize.Size = New System.Drawing.Size(73, 19)
		Me.txtMechSize.Location = New System.Drawing.Point(56, 80)
		Me.txtMechSize.Maxlength = 8
		Me.txtMechSize.TabIndex = 13
		Me.txtMechSize.AcceptsReturn = True
		Me.txtMechSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtMechSize.BackColor = System.Drawing.SystemColors.Window
		Me.txtMechSize.CausesValidation = True
		Me.txtMechSize.Enabled = True
		Me.txtMechSize.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtMechSize.HideSelection = True
		Me.txtMechSize.ReadOnly = False
		Me.txtMechSize.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtMechSize.MultiLine = False
		Me.txtMechSize.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtMechSize.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtMechSize.TabStop = True
		Me.txtMechSize.Visible = True
		Me.txtMechSize.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtMechSize.Name = "txtMechSize"
		Me.txtMechCap.AutoSize = False
		Me.txtMechCap.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtMechCap.Size = New System.Drawing.Size(57, 19)
		Me.txtMechCap.Location = New System.Drawing.Point(472, 56)
		Me.txtMechCap.Maxlength = 6
		Me.txtMechCap.TabIndex = 12
		Me.txtMechCap.AcceptsReturn = True
		Me.txtMechCap.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtMechCap.BackColor = System.Drawing.SystemColors.Window
		Me.txtMechCap.CausesValidation = True
		Me.txtMechCap.Enabled = True
		Me.txtMechCap.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtMechCap.HideSelection = True
		Me.txtMechCap.ReadOnly = False
		Me.txtMechCap.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtMechCap.MultiLine = False
		Me.txtMechCap.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtMechCap.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtMechCap.TabStop = True
		Me.txtMechCap.Visible = True
		Me.txtMechCap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtMechCap.Name = "txtMechCap"
		Me.txtMechRpm.AutoSize = False
		Me.txtMechRpm.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtMechRpm.Size = New System.Drawing.Size(57, 19)
		Me.txtMechRpm.Location = New System.Drawing.Point(384, 56)
		Me.txtMechRpm.Maxlength = 6
		Me.txtMechRpm.TabIndex = 11
		Me.txtMechRpm.AcceptsReturn = True
		Me.txtMechRpm.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtMechRpm.BackColor = System.Drawing.SystemColors.Window
		Me.txtMechRpm.CausesValidation = True
		Me.txtMechRpm.Enabled = True
		Me.txtMechRpm.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtMechRpm.HideSelection = True
		Me.txtMechRpm.ReadOnly = False
		Me.txtMechRpm.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtMechRpm.MultiLine = False
		Me.txtMechRpm.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtMechRpm.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtMechRpm.TabStop = True
		Me.txtMechRpm.Visible = True
		Me.txtMechRpm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtMechRpm.Name = "txtMechRpm"
		Me.txtMechHp.AutoSize = False
		Me.txtMechHp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtMechHp.Size = New System.Drawing.Size(49, 19)
		Me.txtMechHp.Location = New System.Drawing.Point(296, 56)
		Me.txtMechHp.Maxlength = 5
		Me.txtMechHp.TabIndex = 10
		Me.txtMechHp.AcceptsReturn = True
		Me.txtMechHp.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtMechHp.BackColor = System.Drawing.SystemColors.Window
		Me.txtMechHp.CausesValidation = True
		Me.txtMechHp.Enabled = True
		Me.txtMechHp.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtMechHp.HideSelection = True
		Me.txtMechHp.ReadOnly = False
		Me.txtMechHp.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtMechHp.MultiLine = False
		Me.txtMechHp.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtMechHp.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtMechHp.TabStop = True
		Me.txtMechHp.Visible = True
		Me.txtMechHp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtMechHp.Name = "txtMechHp"
		Me.txtMechImpSz.AutoSize = False
		Me.txtMechImpSz.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtMechImpSz.Size = New System.Drawing.Size(57, 19)
		Me.txtMechImpSz.Location = New System.Drawing.Point(176, 56)
		Me.txtMechImpSz.Maxlength = 6
		Me.txtMechImpSz.TabIndex = 9
		Me.txtMechImpSz.AcceptsReturn = True
		Me.txtMechImpSz.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtMechImpSz.BackColor = System.Drawing.SystemColors.Window
		Me.txtMechImpSz.CausesValidation = True
		Me.txtMechImpSz.Enabled = True
		Me.txtMechImpSz.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtMechImpSz.HideSelection = True
		Me.txtMechImpSz.ReadOnly = False
		Me.txtMechImpSz.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtMechImpSz.MultiLine = False
		Me.txtMechImpSz.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtMechImpSz.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtMechImpSz.TabStop = True
		Me.txtMechImpSz.Visible = True
		Me.txtMechImpSz.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtMechImpSz.Name = "txtMechImpSz"
		Me.txtMechModel.AutoSize = False
		Me.txtMechModel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtMechModel.Size = New System.Drawing.Size(129, 19)
		Me.txtMechModel.Location = New System.Drawing.Point(400, 32)
		Me.txtMechModel.Maxlength = 15
		Me.txtMechModel.TabIndex = 7
		Me.txtMechModel.AcceptsReturn = True
		Me.txtMechModel.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtMechModel.BackColor = System.Drawing.SystemColors.Window
		Me.txtMechModel.CausesValidation = True
		Me.txtMechModel.Enabled = True
		Me.txtMechModel.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtMechModel.HideSelection = True
		Me.txtMechModel.ReadOnly = False
		Me.txtMechModel.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtMechModel.MultiLine = False
		Me.txtMechModel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtMechModel.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtMechModel.TabStop = True
		Me.txtMechModel.Visible = True
		Me.txtMechModel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtMechModel.Name = "txtMechModel"
		Me.txtMechFrame.AutoSize = False
		Me.txtMechFrame.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtMechFrame.Size = New System.Drawing.Size(73, 19)
		Me.txtMechFrame.Location = New System.Drawing.Point(56, 56)
		Me.txtMechFrame.Maxlength = 7
		Me.txtMechFrame.TabIndex = 8
		Me.txtMechFrame.AcceptsReturn = True
		Me.txtMechFrame.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtMechFrame.BackColor = System.Drawing.SystemColors.Window
		Me.txtMechFrame.CausesValidation = True
		Me.txtMechFrame.Enabled = True
		Me.txtMechFrame.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtMechFrame.HideSelection = True
		Me.txtMechFrame.ReadOnly = False
		Me.txtMechFrame.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtMechFrame.MultiLine = False
		Me.txtMechFrame.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtMechFrame.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtMechFrame.TabStop = True
		Me.txtMechFrame.Visible = True
		Me.txtMechFrame.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtMechFrame.Name = "txtMechFrame"
		Me.txtMechID.AutoSize = False
		Me.txtMechID.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtMechID.Size = New System.Drawing.Size(129, 19)
		Me.txtMechID.Location = New System.Drawing.Point(224, 32)
		Me.txtMechID.Maxlength = 13
		Me.txtMechID.TabIndex = 6
		Me.txtMechID.AcceptsReturn = True
		Me.txtMechID.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtMechID.BackColor = System.Drawing.SystemColors.Window
		Me.txtMechID.CausesValidation = True
		Me.txtMechID.Enabled = True
		Me.txtMechID.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtMechID.HideSelection = True
		Me.txtMechID.ReadOnly = False
		Me.txtMechID.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtMechID.MultiLine = False
		Me.txtMechID.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtMechID.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtMechID.TabStop = True
		Me.txtMechID.Visible = True
		Me.txtMechID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtMechID.Name = "txtMechID"
		Me.txtMechSerial.AutoSize = False
		Me.txtMechSerial.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtMechSerial.Size = New System.Drawing.Size(129, 19)
		Me.txtMechSerial.Location = New System.Drawing.Point(56, 32)
		Me.txtMechSerial.Maxlength = 13
		Me.txtMechSerial.TabIndex = 5
		Me.txtMechSerial.AcceptsReturn = True
		Me.txtMechSerial.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtMechSerial.BackColor = System.Drawing.SystemColors.Window
		Me.txtMechSerial.CausesValidation = True
		Me.txtMechSerial.Enabled = True
		Me.txtMechSerial.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtMechSerial.HideSelection = True
		Me.txtMechSerial.ReadOnly = False
		Me.txtMechSerial.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtMechSerial.MultiLine = False
		Me.txtMechSerial.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtMechSerial.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtMechSerial.TabStop = True
		Me.txtMechSerial.Visible = True
		Me.txtMechSerial.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtMechSerial.Name = "txtMechSerial"
		Me.txtMechCfm.AutoSize = False
		Me.txtMechCfm.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtMechCfm.Size = New System.Drawing.Size(49, 19)
		Me.txtMechCfm.Location = New System.Drawing.Point(176, 104)
		Me.txtMechCfm.Maxlength = 5
		Me.txtMechCfm.TabIndex = 18
		Me.txtMechCfm.AcceptsReturn = True
		Me.txtMechCfm.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtMechCfm.BackColor = System.Drawing.SystemColors.Window
		Me.txtMechCfm.CausesValidation = True
		Me.txtMechCfm.Enabled = True
		Me.txtMechCfm.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtMechCfm.HideSelection = True
		Me.txtMechCfm.ReadOnly = False
		Me.txtMechCfm.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtMechCfm.MultiLine = False
		Me.txtMechCfm.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtMechCfm.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtMechCfm.TabStop = True
		Me.txtMechCfm.Visible = True
		Me.txtMechCfm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtMechCfm.Name = "txtMechCfm"
		Me.txtMechMinRpm.AutoSize = False
		Me.txtMechMinRpm.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtMechMinRpm.Size = New System.Drawing.Size(49, 19)
		Me.txtMechMinRpm.Location = New System.Drawing.Point(56, 104)
		Me.txtMechMinRpm.Maxlength = 5
		Me.txtMechMinRpm.TabIndex = 17
		Me.txtMechMinRpm.AcceptsReturn = True
		Me.txtMechMinRpm.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtMechMinRpm.BackColor = System.Drawing.SystemColors.Window
		Me.txtMechMinRpm.CausesValidation = True
		Me.txtMechMinRpm.Enabled = True
		Me.txtMechMinRpm.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtMechMinRpm.HideSelection = True
		Me.txtMechMinRpm.ReadOnly = False
		Me.txtMechMinRpm.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtMechMinRpm.MultiLine = False
		Me.txtMechMinRpm.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtMechMinRpm.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtMechMinRpm.TabStop = True
		Me.txtMechMinRpm.Visible = True
		Me.txtMechMinRpm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtMechMinRpm.Name = "txtMechMinRpm"
		Me.txtMechMaxRpm.AutoSize = False
		Me.txtMechMaxRpm.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtMechMaxRpm.Size = New System.Drawing.Size(49, 19)
		Me.txtMechMaxRpm.Location = New System.Drawing.Point(472, 80)
		Me.txtMechMaxRpm.Maxlength = 5
		Me.txtMechMaxRpm.TabIndex = 16
		Me.txtMechMaxRpm.AcceptsReturn = True
		Me.txtMechMaxRpm.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtMechMaxRpm.BackColor = System.Drawing.SystemColors.Window
		Me.txtMechMaxRpm.CausesValidation = True
		Me.txtMechMaxRpm.Enabled = True
		Me.txtMechMaxRpm.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtMechMaxRpm.HideSelection = True
		Me.txtMechMaxRpm.ReadOnly = False
		Me.txtMechMaxRpm.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtMechMaxRpm.MultiLine = False
		Me.txtMechMaxRpm.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtMechMaxRpm.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtMechMaxRpm.TabStop = True
		Me.txtMechMaxRpm.Visible = True
		Me.txtMechMaxRpm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtMechMaxRpm.Name = "txtMechMaxRpm"
		Me.txtMechCatNo.AutoSize = False
		Me.txtMechCatNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtMechCatNo.Size = New System.Drawing.Size(121, 19)
		Me.txtMechCatNo.Location = New System.Drawing.Point(296, 80)
		Me.txtMechCatNo.Maxlength = 13
		Me.txtMechCatNo.TabIndex = 15
		Me.txtMechCatNo.AcceptsReturn = True
		Me.txtMechCatNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtMechCatNo.BackColor = System.Drawing.SystemColors.Window
		Me.txtMechCatNo.CausesValidation = True
		Me.txtMechCatNo.Enabled = True
		Me.txtMechCatNo.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtMechCatNo.HideSelection = True
		Me.txtMechCatNo.ReadOnly = False
		Me.txtMechCatNo.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtMechCatNo.MultiLine = False
		Me.txtMechCatNo.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtMechCatNo.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtMechCatNo.TabStop = True
		Me.txtMechCatNo.Visible = True
		Me.txtMechCatNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtMechCatNo.Name = "txtMechCatNo"
		Me.txtMechRecomSpareParts.AutoSize = False
		Me.txtMechRecomSpareParts.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtMechRecomSpareParts.Size = New System.Drawing.Size(209, 19)
		Me.txtMechRecomSpareParts.Location = New System.Drawing.Point(168, 296)
		Me.txtMechRecomSpareParts.Maxlength = 30
		Me.txtMechRecomSpareParts.TabIndex = 28
		Me.txtMechRecomSpareParts.AcceptsReturn = True
		Me.txtMechRecomSpareParts.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtMechRecomSpareParts.BackColor = System.Drawing.SystemColors.Window
		Me.txtMechRecomSpareParts.CausesValidation = True
		Me.txtMechRecomSpareParts.Enabled = True
		Me.txtMechRecomSpareParts.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtMechRecomSpareParts.HideSelection = True
		Me.txtMechRecomSpareParts.ReadOnly = False
		Me.txtMechRecomSpareParts.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtMechRecomSpareParts.MultiLine = False
		Me.txtMechRecomSpareParts.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtMechRecomSpareParts.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtMechRecomSpareParts.TabStop = True
		Me.txtMechRecomSpareParts.Visible = True
		Me.txtMechRecomSpareParts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtMechRecomSpareParts.Name = "txtMechRecomSpareParts"
		Me.txtMechMiscNPData.AutoSize = False
		Me.txtMechMiscNPData.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtMechMiscNPData.Size = New System.Drawing.Size(369, 43)
		Me.txtMechMiscNPData.Location = New System.Drawing.Point(168, 248)
		Me.txtMechMiscNPData.Maxlength = 65
		Me.txtMechMiscNPData.MultiLine = True
		Me.txtMechMiscNPData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.txtMechMiscNPData.TabIndex = 27
		Me.txtMechMiscNPData.AcceptsReturn = True
		Me.txtMechMiscNPData.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtMechMiscNPData.BackColor = System.Drawing.SystemColors.Window
		Me.txtMechMiscNPData.CausesValidation = True
		Me.txtMechMiscNPData.Enabled = True
		Me.txtMechMiscNPData.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtMechMiscNPData.HideSelection = True
		Me.txtMechMiscNPData.ReadOnly = False
		Me.txtMechMiscNPData.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtMechMiscNPData.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtMechMiscNPData.TabStop = True
		Me.txtMechMiscNPData.Visible = True
		Me.txtMechMiscNPData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtMechMiscNPData.Name = "txtMechMiscNPData"
		Me.txtMechNoOfValvesTypes.AutoSize = False
		Me.txtMechNoOfValvesTypes.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtMechNoOfValvesTypes.Size = New System.Drawing.Size(289, 19)
		Me.txtMechNoOfValvesTypes.Location = New System.Drawing.Point(168, 224)
		Me.txtMechNoOfValvesTypes.Maxlength = 30
		Me.txtMechNoOfValvesTypes.TabIndex = 26
		Me.txtMechNoOfValvesTypes.AcceptsReturn = True
		Me.txtMechNoOfValvesTypes.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtMechNoOfValvesTypes.BackColor = System.Drawing.SystemColors.Window
		Me.txtMechNoOfValvesTypes.CausesValidation = True
		Me.txtMechNoOfValvesTypes.Enabled = True
		Me.txtMechNoOfValvesTypes.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtMechNoOfValvesTypes.HideSelection = True
		Me.txtMechNoOfValvesTypes.ReadOnly = False
		Me.txtMechNoOfValvesTypes.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtMechNoOfValvesTypes.MultiLine = False
		Me.txtMechNoOfValvesTypes.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtMechNoOfValvesTypes.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtMechNoOfValvesTypes.TabStop = True
		Me.txtMechNoOfValvesTypes.Visible = True
		Me.txtMechNoOfValvesTypes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtMechNoOfValvesTypes.Name = "txtMechNoOfValvesTypes"
		Me.txtMechPipeType.AutoSize = False
		Me.txtMechPipeType.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtMechPipeType.Size = New System.Drawing.Size(177, 19)
		Me.txtMechPipeType.Location = New System.Drawing.Point(168, 200)
		Me.txtMechPipeType.Maxlength = 20
		Me.txtMechPipeType.TabIndex = 25
		Me.txtMechPipeType.AcceptsReturn = True
		Me.txtMechPipeType.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtMechPipeType.BackColor = System.Drawing.SystemColors.Window
		Me.txtMechPipeType.CausesValidation = True
		Me.txtMechPipeType.Enabled = True
		Me.txtMechPipeType.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtMechPipeType.HideSelection = True
		Me.txtMechPipeType.ReadOnly = False
		Me.txtMechPipeType.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtMechPipeType.MultiLine = False
		Me.txtMechPipeType.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtMechPipeType.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtMechPipeType.TabStop = True
		Me.txtMechPipeType.Visible = True
		Me.txtMechPipeType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtMechPipeType.Name = "txtMechPipeType"
		Me.txtMechPipeSize.AutoSize = False
		Me.txtMechPipeSize.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtMechPipeSize.Size = New System.Drawing.Size(265, 19)
		Me.txtMechPipeSize.Location = New System.Drawing.Point(168, 176)
		Me.txtMechPipeSize.Maxlength = 30
		Me.txtMechPipeSize.TabIndex = 24
		Me.txtMechPipeSize.AcceptsReturn = True
		Me.txtMechPipeSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtMechPipeSize.BackColor = System.Drawing.SystemColors.Window
		Me.txtMechPipeSize.CausesValidation = True
		Me.txtMechPipeSize.Enabled = True
		Me.txtMechPipeSize.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtMechPipeSize.HideSelection = True
		Me.txtMechPipeSize.ReadOnly = False
		Me.txtMechPipeSize.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtMechPipeSize.MultiLine = False
		Me.txtMechPipeSize.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtMechPipeSize.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtMechPipeSize.TabStop = True
		Me.txtMechPipeSize.Visible = True
		Me.txtMechPipeSize.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtMechPipeSize.Name = "txtMechPipeSize"
		Me.txtMechOil.AutoSize = False
		Me.txtMechOil.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtMechOil.Size = New System.Drawing.Size(177, 19)
		Me.txtMechOil.Location = New System.Drawing.Point(296, 104)
		Me.txtMechOil.Maxlength = 20
		Me.txtMechOil.TabIndex = 19
		Me.txtMechOil.AcceptsReturn = True
		Me.txtMechOil.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtMechOil.BackColor = System.Drawing.SystemColors.Window
		Me.txtMechOil.CausesValidation = True
		Me.txtMechOil.Enabled = True
		Me.txtMechOil.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtMechOil.HideSelection = True
		Me.txtMechOil.ReadOnly = False
		Me.txtMechOil.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtMechOil.MultiLine = False
		Me.txtMechOil.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtMechOil.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtMechOil.TabStop = True
		Me.txtMechOil.Visible = True
		Me.txtMechOil.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtMechOil.Name = "txtMechOil"
		Me.txtMechOilFilter.AutoSize = False
		Me.txtMechOilFilter.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtMechOilFilter.Size = New System.Drawing.Size(177, 19)
		Me.txtMechOilFilter.Location = New System.Drawing.Point(56, 128)
		Me.txtMechOilFilter.Maxlength = 20
		Me.txtMechOilFilter.TabIndex = 20
		Me.txtMechOilFilter.AcceptsReturn = True
		Me.txtMechOilFilter.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtMechOilFilter.BackColor = System.Drawing.SystemColors.Window
		Me.txtMechOilFilter.CausesValidation = True
		Me.txtMechOilFilter.Enabled = True
		Me.txtMechOilFilter.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtMechOilFilter.HideSelection = True
		Me.txtMechOilFilter.ReadOnly = False
		Me.txtMechOilFilter.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtMechOilFilter.MultiLine = False
		Me.txtMechOilFilter.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtMechOilFilter.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtMechOilFilter.TabStop = True
		Me.txtMechOilFilter.Visible = True
		Me.txtMechOilFilter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtMechOilFilter.Name = "txtMechOilFilter"
		Me.txtMechAirFilter.AutoSize = False
		Me.txtMechAirFilter.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtMechAirFilter.Size = New System.Drawing.Size(177, 19)
		Me.txtMechAirFilter.Location = New System.Drawing.Point(296, 128)
		Me.txtMechAirFilter.Maxlength = 20
		Me.txtMechAirFilter.TabIndex = 21
		Me.txtMechAirFilter.AcceptsReturn = True
		Me.txtMechAirFilter.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtMechAirFilter.BackColor = System.Drawing.SystemColors.Window
		Me.txtMechAirFilter.CausesValidation = True
		Me.txtMechAirFilter.Enabled = True
		Me.txtMechAirFilter.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtMechAirFilter.HideSelection = True
		Me.txtMechAirFilter.ReadOnly = False
		Me.txtMechAirFilter.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtMechAirFilter.MultiLine = False
		Me.txtMechAirFilter.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtMechAirFilter.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtMechAirFilter.TabStop = True
		Me.txtMechAirFilter.Visible = True
		Me.txtMechAirFilter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtMechAirFilter.Name = "txtMechAirFilter"
		Me.txtMechBelt1.AutoSize = False
		Me.txtMechBelt1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtMechBelt1.Size = New System.Drawing.Size(177, 19)
		Me.txtMechBelt1.Location = New System.Drawing.Point(56, 152)
		Me.txtMechBelt1.Maxlength = 20
		Me.txtMechBelt1.TabIndex = 22
		Me.txtMechBelt1.AcceptsReturn = True
		Me.txtMechBelt1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtMechBelt1.BackColor = System.Drawing.SystemColors.Window
		Me.txtMechBelt1.CausesValidation = True
		Me.txtMechBelt1.Enabled = True
		Me.txtMechBelt1.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtMechBelt1.HideSelection = True
		Me.txtMechBelt1.ReadOnly = False
		Me.txtMechBelt1.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtMechBelt1.MultiLine = False
		Me.txtMechBelt1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtMechBelt1.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtMechBelt1.TabStop = True
		Me.txtMechBelt1.Visible = True
		Me.txtMechBelt1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtMechBelt1.Name = "txtMechBelt1"
		Me.txtMechBelt2.AutoSize = False
		Me.txtMechBelt2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtMechBelt2.Size = New System.Drawing.Size(177, 19)
		Me.txtMechBelt2.Location = New System.Drawing.Point(296, 152)
		Me.txtMechBelt2.Maxlength = 20
		Me.txtMechBelt2.TabIndex = 23
		Me.txtMechBelt2.AcceptsReturn = True
		Me.txtMechBelt2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtMechBelt2.BackColor = System.Drawing.SystemColors.Window
		Me.txtMechBelt2.CausesValidation = True
		Me.txtMechBelt2.Enabled = True
		Me.txtMechBelt2.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtMechBelt2.HideSelection = True
		Me.txtMechBelt2.ReadOnly = False
		Me.txtMechBelt2.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtMechBelt2.MultiLine = False
		Me.txtMechBelt2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtMechBelt2.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtMechBelt2.TabStop = True
		Me.txtMechBelt2.Visible = True
		Me.txtMechBelt2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtMechBelt2.Name = "txtMechBelt2"
		Me._SSTab1_TabPage1.Text = "Electrical NP Data"
		Me.lblElecRecomSpareParts.Text = "Recommended Spare Parts"
		Me.lblElecRecomSpareParts.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecRecomSpareParts.Size = New System.Drawing.Size(137, 17)
		Me.lblElecRecomSpareParts.Location = New System.Drawing.Point(80, 264)
		Me.lblElecRecomSpareParts.TabIndex = 68
		Me.lblElecRecomSpareParts.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
		Me.lblElecMiscNPData.Text = "Misc. NP Data"
		Me.lblElecMiscNPData.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecMiscNPData.Size = New System.Drawing.Size(73, 17)
		Me.lblElecMiscNPData.Location = New System.Drawing.Point(144, 208)
		Me.lblElecMiscNPData.TabIndex = 69
		Me.lblElecMiscNPData.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
		Me.lblElecOppEndBrg.Text = "opp. end brg"
		Me.lblElecOppEndBrg.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecOppEndBrg.Size = New System.Drawing.Size(65, 17)
		Me.lblElecOppEndBrg.Location = New System.Drawing.Point(152, 184)
		Me.lblElecOppEndBrg.TabIndex = 70
		Me.lblElecOppEndBrg.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
		Me.lblElecShaftEndBrg.Text = "shaft end brg"
		Me.lblElecShaftEndBrg.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecShaftEndBrg.Size = New System.Drawing.Size(65, 17)
		Me.lblElecShaftEndBrg.Location = New System.Drawing.Point(152, 160)
		Me.lblElecShaftEndBrg.TabIndex = 71
		Me.lblElecShaftEndBrg.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
		Me.lblElecDesign.Text = "design"
		Me.lblElecDesign.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecDesign.Size = New System.Drawing.Size(33, 17)
		Me.lblElecDesign.Location = New System.Drawing.Point(440, 104)
		Me.lblElecDesign.TabIndex = 72
		Me.lblElecDesign.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
		Me.lblElecInslCl.Text = "insl cl"
		Me.lblElecInslCl.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecInslCl.Size = New System.Drawing.Size(33, 17)
		Me.lblElecInslCl.Location = New System.Drawing.Point(368, 104)
		Me.lblElecInslCl.TabIndex = 73
		Me.lblElecInslCl.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
		Me.lblElecDuty.Text = "duty"
		Me.lblElecDuty.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecDuty.Size = New System.Drawing.Size(25, 17)
		Me.lblElecDuty.Location = New System.Drawing.Point(192, 104)
		Me.lblElecDuty.TabIndex = 74
		Me.lblElecDuty.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
		Me.lblElecAmp.Text = "amp"
		Me.lblElecAmp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecAmp.Size = New System.Drawing.Size(25, 17)
		Me.lblElecAmp.Location = New System.Drawing.Point(32, 104)
		Me.lblElecAmp.TabIndex = 75
		Me.lblElecAmp.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
		Me.lblElecV.Text = "v"
		Me.lblElecV.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecV.Size = New System.Drawing.Size(9, 17)
		Me.lblElecV.Location = New System.Drawing.Point(384, 80)
		Me.lblElecV.TabIndex = 76
		Me.lblElecV.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
		Me.lblElecSf.Text = "sf"
		Me.lblElecSf.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecSf.Size = New System.Drawing.Size(17, 17)
		Me.lblElecSf.Location = New System.Drawing.Point(264, 80)
		Me.lblElecSf.TabIndex = 77
		Me.lblElecSf.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
		Me.lblElecPhs.Text = "phs"
		Me.lblElecPhs.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecPhs.Size = New System.Drawing.Size(25, 17)
		Me.lblElecPhs.Location = New System.Drawing.Point(184, 80)
		Me.lblElecPhs.TabIndex = 78
		Me.lblElecPhs.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
		Me.lblElecHz.Text = "hz"
		Me.lblElecHz.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecHz.Size = New System.Drawing.Size(17, 17)
		Me.lblElecHz.Location = New System.Drawing.Point(40, 80)
		Me.lblElecHz.TabIndex = 79
		Me.lblElecHz.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
		Me.lblElecRpm.Text = "rpm"
		Me.lblElecRpm.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecRpm.Size = New System.Drawing.Size(25, 17)
		Me.lblElecRpm.Location = New System.Drawing.Point(456, 56)
		Me.lblElecRpm.TabIndex = 80
		Me.lblElecRpm.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
		Me.lblElecHp.Text = "hp"
		Me.lblElecHp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecHp.Size = New System.Drawing.Size(17, 17)
		Me.lblElecHp.Location = New System.Drawing.Point(384, 56)
		Me.lblElecHp.TabIndex = 81
		Me.lblElecHp.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
		Me.lblElecCatNo.Text = "cat no"
		Me.lblElecCatNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecCatNo.Size = New System.Drawing.Size(33, 17)
		Me.lblElecCatNo.Location = New System.Drawing.Point(184, 56)
		Me.lblElecCatNo.TabIndex = 82
		Me.lblElecCatNo.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
		Me.lblElecSerial.Text = "serial"
		Me.lblElecSerial.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecSerial.Size = New System.Drawing.Size(33, 17)
		Me.lblElecSerial.Location = New System.Drawing.Point(24, 32)
		Me.lblElecSerial.TabIndex = 83
		Me.lblElecSerial.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
		Me.lblElecID.Text = "id"
		Me.lblElecID.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecID.Size = New System.Drawing.Size(17, 17)
		Me.lblElecID.Location = New System.Drawing.Point(200, 32)
		Me.lblElecID.TabIndex = 84
		Me.lblElecID.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
		Me.lblElecModel.Text = "model"
		Me.lblElecModel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecModel.Size = New System.Drawing.Size(33, 17)
		Me.lblElecModel.Location = New System.Drawing.Point(368, 32)
		Me.lblElecModel.TabIndex = 85
		Me.lblElecModel.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
		Me.lblElecFrame.Text = "frame"
		Me.lblElecFrame.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblElecFrame.Size = New System.Drawing.Size(33, 17)
		Me.lblElecFrame.Location = New System.Drawing.Point(24, 56)
		Me.lblElecFrame.TabIndex = 86
		Me.lblElecFrame.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
		Me.txtElecSerial.AutoSize = False
		Me.txtElecSerial.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtElecSerial.Size = New System.Drawing.Size(129, 19)
		Me.txtElecSerial.Location = New System.Drawing.Point(56, 32)
		Me.txtElecSerial.Maxlength = 13
		Me.txtElecSerial.TabIndex = 29
		Me.txtElecSerial.AcceptsReturn = True
		Me.txtElecSerial.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtElecSerial.BackColor = System.Drawing.SystemColors.Window
		Me.txtElecSerial.CausesValidation = True
		Me.txtElecSerial.Enabled = True
		Me.txtElecSerial.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtElecSerial.HideSelection = True
		Me.txtElecSerial.ReadOnly = False
		Me.txtElecSerial.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtElecSerial.MultiLine = False
		Me.txtElecSerial.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtElecSerial.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtElecSerial.TabStop = True
		Me.txtElecSerial.Visible = True
		Me.txtElecSerial.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtElecSerial.Name = "txtElecSerial"
		Me.txtElecID.AutoSize = False
		Me.txtElecID.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtElecID.Size = New System.Drawing.Size(129, 19)
		Me.txtElecID.Location = New System.Drawing.Point(216, 32)
		Me.txtElecID.Maxlength = 13
		Me.txtElecID.TabIndex = 30
		Me.txtElecID.AcceptsReturn = True
		Me.txtElecID.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtElecID.BackColor = System.Drawing.SystemColors.Window
		Me.txtElecID.CausesValidation = True
		Me.txtElecID.Enabled = True
		Me.txtElecID.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtElecID.HideSelection = True
		Me.txtElecID.ReadOnly = False
		Me.txtElecID.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtElecID.MultiLine = False
		Me.txtElecID.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtElecID.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtElecID.TabStop = True
		Me.txtElecID.Visible = True
		Me.txtElecID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtElecID.Name = "txtElecID"
		Me.txtElecModel.AutoSize = False
		Me.txtElecModel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtElecModel.Size = New System.Drawing.Size(129, 19)
		Me.txtElecModel.Location = New System.Drawing.Point(400, 32)
		Me.txtElecModel.Maxlength = 15
		Me.txtElecModel.TabIndex = 31
		Me.txtElecModel.AcceptsReturn = True
		Me.txtElecModel.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtElecModel.BackColor = System.Drawing.SystemColors.Window
		Me.txtElecModel.CausesValidation = True
		Me.txtElecModel.Enabled = True
		Me.txtElecModel.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtElecModel.HideSelection = True
		Me.txtElecModel.ReadOnly = False
		Me.txtElecModel.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtElecModel.MultiLine = False
		Me.txtElecModel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtElecModel.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtElecModel.TabStop = True
		Me.txtElecModel.Visible = True
		Me.txtElecModel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtElecModel.Name = "txtElecModel"
		Me.txtElecSf.AutoSize = False
		Me.txtElecSf.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtElecSf.Size = New System.Drawing.Size(41, 19)
		Me.txtElecSf.Location = New System.Drawing.Point(280, 80)
		Me.txtElecSf.Maxlength = 4
		Me.txtElecSf.TabIndex = 38
		Me.txtElecSf.AcceptsReturn = True
		Me.txtElecSf.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtElecSf.BackColor = System.Drawing.SystemColors.Window
		Me.txtElecSf.CausesValidation = True
		Me.txtElecSf.Enabled = True
		Me.txtElecSf.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtElecSf.HideSelection = True
		Me.txtElecSf.ReadOnly = False
		Me.txtElecSf.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtElecSf.MultiLine = False
		Me.txtElecSf.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtElecSf.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtElecSf.TabStop = True
		Me.txtElecSf.Visible = True
		Me.txtElecSf.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtElecSf.Name = "txtElecSf"
		Me.txtElecPhs.AutoSize = False
		Me.txtElecPhs.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtElecPhs.Size = New System.Drawing.Size(25, 19)
		Me.txtElecPhs.Location = New System.Drawing.Point(216, 80)
		Me.txtElecPhs.Maxlength = 2
		Me.txtElecPhs.TabIndex = 37
		Me.txtElecPhs.AcceptsReturn = True
		Me.txtElecPhs.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtElecPhs.BackColor = System.Drawing.SystemColors.Window
		Me.txtElecPhs.CausesValidation = True
		Me.txtElecPhs.Enabled = True
		Me.txtElecPhs.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtElecPhs.HideSelection = True
		Me.txtElecPhs.ReadOnly = False
		Me.txtElecPhs.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtElecPhs.MultiLine = False
		Me.txtElecPhs.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtElecPhs.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtElecPhs.TabStop = True
		Me.txtElecPhs.Visible = True
		Me.txtElecPhs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtElecPhs.Name = "txtElecPhs"
		Me.txtElecRpm.AutoSize = False
		Me.txtElecRpm.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtElecRpm.Size = New System.Drawing.Size(57, 19)
		Me.txtElecRpm.Location = New System.Drawing.Point(480, 56)
		Me.txtElecRpm.Maxlength = 6
		Me.txtElecRpm.TabIndex = 35
		Me.txtElecRpm.AcceptsReturn = True
		Me.txtElecRpm.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtElecRpm.BackColor = System.Drawing.SystemColors.Window
		Me.txtElecRpm.CausesValidation = True
		Me.txtElecRpm.Enabled = True
		Me.txtElecRpm.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtElecRpm.HideSelection = True
		Me.txtElecRpm.ReadOnly = False
		Me.txtElecRpm.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtElecRpm.MultiLine = False
		Me.txtElecRpm.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtElecRpm.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtElecRpm.TabStop = True
		Me.txtElecRpm.Visible = True
		Me.txtElecRpm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtElecRpm.Name = "txtElecRpm"
		Me.txtElecHp.AutoSize = False
		Me.txtElecHp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtElecHp.Size = New System.Drawing.Size(49, 19)
		Me.txtElecHp.Location = New System.Drawing.Point(400, 56)
		Me.txtElecHp.Maxlength = 5
		Me.txtElecHp.TabIndex = 34
		Me.txtElecHp.AcceptsReturn = True
		Me.txtElecHp.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtElecHp.BackColor = System.Drawing.SystemColors.Window
		Me.txtElecHp.CausesValidation = True
		Me.txtElecHp.Enabled = True
		Me.txtElecHp.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtElecHp.HideSelection = True
		Me.txtElecHp.ReadOnly = False
		Me.txtElecHp.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtElecHp.MultiLine = False
		Me.txtElecHp.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtElecHp.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtElecHp.TabStop = True
		Me.txtElecHp.Visible = True
		Me.txtElecHp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtElecHp.Name = "txtElecHp"
		Me.txtElecCatNo.AutoSize = False
		Me.txtElecCatNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtElecCatNo.Size = New System.Drawing.Size(73, 19)
		Me.txtElecCatNo.Location = New System.Drawing.Point(216, 56)
		Me.txtElecCatNo.Maxlength = 10
		Me.txtElecCatNo.TabIndex = 33
		Me.txtElecCatNo.AcceptsReturn = True
		Me.txtElecCatNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtElecCatNo.BackColor = System.Drawing.SystemColors.Window
		Me.txtElecCatNo.CausesValidation = True
		Me.txtElecCatNo.Enabled = True
		Me.txtElecCatNo.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtElecCatNo.HideSelection = True
		Me.txtElecCatNo.ReadOnly = False
		Me.txtElecCatNo.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtElecCatNo.MultiLine = False
		Me.txtElecCatNo.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtElecCatNo.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtElecCatNo.TabStop = True
		Me.txtElecCatNo.Visible = True
		Me.txtElecCatNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtElecCatNo.Name = "txtElecCatNo"
		Me.txtElecFrame.AutoSize = False
		Me.txtElecFrame.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtElecFrame.Size = New System.Drawing.Size(73, 19)
		Me.txtElecFrame.Location = New System.Drawing.Point(56, 56)
		Me.txtElecFrame.Maxlength = 7
		Me.txtElecFrame.TabIndex = 32
		Me.txtElecFrame.AcceptsReturn = True
		Me.txtElecFrame.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtElecFrame.BackColor = System.Drawing.SystemColors.Window
		Me.txtElecFrame.CausesValidation = True
		Me.txtElecFrame.Enabled = True
		Me.txtElecFrame.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtElecFrame.HideSelection = True
		Me.txtElecFrame.ReadOnly = False
		Me.txtElecFrame.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtElecFrame.MultiLine = False
		Me.txtElecFrame.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtElecFrame.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtElecFrame.TabStop = True
		Me.txtElecFrame.Visible = True
		Me.txtElecFrame.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtElecFrame.Name = "txtElecFrame"
		Me.txtElecDesign.AutoSize = False
		Me.txtElecDesign.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtElecDesign.Size = New System.Drawing.Size(33, 19)
		Me.txtElecDesign.Location = New System.Drawing.Point(480, 104)
		Me.txtElecDesign.Maxlength = 3
		Me.txtElecDesign.TabIndex = 43
		Me.txtElecDesign.AcceptsReturn = True
		Me.txtElecDesign.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtElecDesign.BackColor = System.Drawing.SystemColors.Window
		Me.txtElecDesign.CausesValidation = True
		Me.txtElecDesign.Enabled = True
		Me.txtElecDesign.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtElecDesign.HideSelection = True
		Me.txtElecDesign.ReadOnly = False
		Me.txtElecDesign.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtElecDesign.MultiLine = False
		Me.txtElecDesign.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtElecDesign.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtElecDesign.TabStop = True
		Me.txtElecDesign.Visible = True
		Me.txtElecDesign.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtElecDesign.Name = "txtElecDesign"
		Me.txtElecInslCl.AutoSize = False
		Me.txtElecInslCl.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtElecInslCl.Size = New System.Drawing.Size(33, 19)
		Me.txtElecInslCl.Location = New System.Drawing.Point(400, 104)
		Me.txtElecInslCl.Maxlength = 3
		Me.txtElecInslCl.TabIndex = 42
		Me.txtElecInslCl.AcceptsReturn = True
		Me.txtElecInslCl.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtElecInslCl.BackColor = System.Drawing.SystemColors.Window
		Me.txtElecInslCl.CausesValidation = True
		Me.txtElecInslCl.Enabled = True
		Me.txtElecInslCl.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtElecInslCl.HideSelection = True
		Me.txtElecInslCl.ReadOnly = False
		Me.txtElecInslCl.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtElecInslCl.MultiLine = False
		Me.txtElecInslCl.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtElecInslCl.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtElecInslCl.TabStop = True
		Me.txtElecInslCl.Visible = True
		Me.txtElecInslCl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtElecInslCl.Name = "txtElecInslCl"
		Me.txtElecDuty.AutoSize = False
		Me.txtElecDuty.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtElecDuty.Size = New System.Drawing.Size(49, 19)
		Me.txtElecDuty.Location = New System.Drawing.Point(216, 104)
		Me.txtElecDuty.Maxlength = 5
		Me.txtElecDuty.TabIndex = 41
		Me.txtElecDuty.AcceptsReturn = True
		Me.txtElecDuty.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtElecDuty.BackColor = System.Drawing.SystemColors.Window
		Me.txtElecDuty.CausesValidation = True
		Me.txtElecDuty.Enabled = True
		Me.txtElecDuty.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtElecDuty.HideSelection = True
		Me.txtElecDuty.ReadOnly = False
		Me.txtElecDuty.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtElecDuty.MultiLine = False
		Me.txtElecDuty.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtElecDuty.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtElecDuty.TabStop = True
		Me.txtElecDuty.Visible = True
		Me.txtElecDuty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtElecDuty.Name = "txtElecDuty"
		Me.txtElecAmp.AutoSize = False
		Me.txtElecAmp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtElecAmp.Size = New System.Drawing.Size(121, 19)
		Me.txtElecAmp.Location = New System.Drawing.Point(56, 104)
		Me.txtElecAmp.Maxlength = 12
		Me.txtElecAmp.TabIndex = 40
		Me.txtElecAmp.AcceptsReturn = True
		Me.txtElecAmp.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtElecAmp.BackColor = System.Drawing.SystemColors.Window
		Me.txtElecAmp.CausesValidation = True
		Me.txtElecAmp.Enabled = True
		Me.txtElecAmp.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtElecAmp.HideSelection = True
		Me.txtElecAmp.ReadOnly = False
		Me.txtElecAmp.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtElecAmp.MultiLine = False
		Me.txtElecAmp.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtElecAmp.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtElecAmp.TabStop = True
		Me.txtElecAmp.Visible = True
		Me.txtElecAmp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtElecAmp.Name = "txtElecAmp"
		Me.txtElecV.AutoSize = False
		Me.txtElecV.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtElecV.Size = New System.Drawing.Size(121, 19)
		Me.txtElecV.Location = New System.Drawing.Point(400, 80)
		Me.txtElecV.Maxlength = 12
		Me.txtElecV.TabIndex = 39
		Me.txtElecV.AcceptsReturn = True
		Me.txtElecV.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtElecV.BackColor = System.Drawing.SystemColors.Window
		Me.txtElecV.CausesValidation = True
		Me.txtElecV.Enabled = True
		Me.txtElecV.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtElecV.HideSelection = True
		Me.txtElecV.ReadOnly = False
		Me.txtElecV.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtElecV.MultiLine = False
		Me.txtElecV.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtElecV.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtElecV.TabStop = True
		Me.txtElecV.Visible = True
		Me.txtElecV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtElecV.Name = "txtElecV"
		Me.txtElecOppEndBrg.AutoSize = False
		Me.txtElecOppEndBrg.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtElecOppEndBrg.Size = New System.Drawing.Size(129, 19)
		Me.txtElecOppEndBrg.Location = New System.Drawing.Point(216, 184)
		Me.txtElecOppEndBrg.Maxlength = 13
		Me.txtElecOppEndBrg.TabIndex = 45
		Me.txtElecOppEndBrg.AcceptsReturn = True
		Me.txtElecOppEndBrg.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtElecOppEndBrg.BackColor = System.Drawing.SystemColors.Window
		Me.txtElecOppEndBrg.CausesValidation = True
		Me.txtElecOppEndBrg.Enabled = True
		Me.txtElecOppEndBrg.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtElecOppEndBrg.HideSelection = True
		Me.txtElecOppEndBrg.ReadOnly = False
		Me.txtElecOppEndBrg.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtElecOppEndBrg.MultiLine = False
		Me.txtElecOppEndBrg.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtElecOppEndBrg.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtElecOppEndBrg.TabStop = True
		Me.txtElecOppEndBrg.Visible = True
		Me.txtElecOppEndBrg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtElecOppEndBrg.Name = "txtElecOppEndBrg"
		Me.txtElecShaftEndBrg.AutoSize = False
		Me.txtElecShaftEndBrg.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtElecShaftEndBrg.Size = New System.Drawing.Size(129, 19)
		Me.txtElecShaftEndBrg.Location = New System.Drawing.Point(216, 160)
		Me.txtElecShaftEndBrg.Maxlength = 13
		Me.txtElecShaftEndBrg.TabIndex = 44
		Me.txtElecShaftEndBrg.AcceptsReturn = True
		Me.txtElecShaftEndBrg.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtElecShaftEndBrg.BackColor = System.Drawing.SystemColors.Window
		Me.txtElecShaftEndBrg.CausesValidation = True
		Me.txtElecShaftEndBrg.Enabled = True
		Me.txtElecShaftEndBrg.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtElecShaftEndBrg.HideSelection = True
		Me.txtElecShaftEndBrg.ReadOnly = False
		Me.txtElecShaftEndBrg.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtElecShaftEndBrg.MultiLine = False
		Me.txtElecShaftEndBrg.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtElecShaftEndBrg.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtElecShaftEndBrg.TabStop = True
		Me.txtElecShaftEndBrg.Visible = True
		Me.txtElecShaftEndBrg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtElecShaftEndBrg.Name = "txtElecShaftEndBrg"
		Me.txtElecMiscNpData.AutoSize = False
		Me.txtElecMiscNpData.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtElecMiscNpData.Size = New System.Drawing.Size(313, 51)
		Me.txtElecMiscNpData.Location = New System.Drawing.Point(216, 208)
		Me.txtElecMiscNpData.Maxlength = 65
		Me.txtElecMiscNpData.MultiLine = True
		Me.txtElecMiscNpData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.txtElecMiscNpData.TabIndex = 46
		Me.txtElecMiscNpData.AcceptsReturn = True
		Me.txtElecMiscNpData.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtElecMiscNpData.BackColor = System.Drawing.SystemColors.Window
		Me.txtElecMiscNpData.CausesValidation = True
		Me.txtElecMiscNpData.Enabled = True
		Me.txtElecMiscNpData.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtElecMiscNpData.HideSelection = True
		Me.txtElecMiscNpData.ReadOnly = False
		Me.txtElecMiscNpData.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtElecMiscNpData.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtElecMiscNpData.TabStop = True
		Me.txtElecMiscNpData.Visible = True
		Me.txtElecMiscNpData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtElecMiscNpData.Name = "txtElecMiscNpData"
		Me.txtElecRecomSpareParts.AutoSize = False
		Me.txtElecRecomSpareParts.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtElecRecomSpareParts.Size = New System.Drawing.Size(177, 19)
		Me.txtElecRecomSpareParts.Location = New System.Drawing.Point(216, 264)
		Me.txtElecRecomSpareParts.Maxlength = 30
		Me.txtElecRecomSpareParts.TabIndex = 47
		Me.txtElecRecomSpareParts.AcceptsReturn = True
		Me.txtElecRecomSpareParts.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtElecRecomSpareParts.BackColor = System.Drawing.SystemColors.Window
		Me.txtElecRecomSpareParts.CausesValidation = True
		Me.txtElecRecomSpareParts.Enabled = True
		Me.txtElecRecomSpareParts.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtElecRecomSpareParts.HideSelection = True
		Me.txtElecRecomSpareParts.ReadOnly = False
		Me.txtElecRecomSpareParts.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtElecRecomSpareParts.MultiLine = False
		Me.txtElecRecomSpareParts.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtElecRecomSpareParts.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtElecRecomSpareParts.TabStop = True
		Me.txtElecRecomSpareParts.Visible = True
		Me.txtElecRecomSpareParts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtElecRecomSpareParts.Name = "txtElecRecomSpareParts"
		Me.txtElecHz.AutoSize = False
		Me.txtElecHz.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtElecHz.Size = New System.Drawing.Size(33, 19)
		Me.txtElecHz.Location = New System.Drawing.Point(56, 80)
		Me.txtElecHz.Maxlength = 3
		Me.txtElecHz.TabIndex = 36
		Me.txtElecHz.AcceptsReturn = True
		Me.txtElecHz.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtElecHz.BackColor = System.Drawing.SystemColors.Window
		Me.txtElecHz.CausesValidation = True
		Me.txtElecHz.Enabled = True
		Me.txtElecHz.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtElecHz.HideSelection = True
		Me.txtElecHz.ReadOnly = False
		Me.txtElecHz.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtElecHz.MultiLine = False
		Me.txtElecHz.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtElecHz.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtElecHz.TabStop = True
		Me.txtElecHz.Visible = True
		Me.txtElecHz.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtElecHz.Name = "txtElecHz"
		txtMeterReadingDate.OcxState = CType(resources.GetObject("txtMeterReadingDate.OcxState"), System.Windows.Forms.AxHost.State)
		Me.txtMeterReadingDate.Size = New System.Drawing.Size(73, 17)
		Me.txtMeterReadingDate.Location = New System.Drawing.Point(464, 32)
		Me.txtMeterReadingDate.TabIndex = 3
		Me.txtMeterReadingDate.Name = "txtMeterReadingDate"
		Me.lblPlantName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblPlantName.Size = New System.Drawing.Size(177, 17)
		Me.lblPlantName.Location = New System.Drawing.Point(0, 0)
		Me.lblPlantName.TabIndex = 99
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
		Me.lblEquipKey.Text = "Equipment Key:"
		Me.lblEquipKey.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblEquipKey.Size = New System.Drawing.Size(89, 17)
		Me.lblEquipKey.Location = New System.Drawing.Point(16, 32)
		Me.lblEquipKey.TabIndex = 95
		Me.lblEquipKey.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblEquipKey.BackColor = System.Drawing.SystemColors.Control
		Me.lblEquipKey.Enabled = True
		Me.lblEquipKey.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblEquipKey.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblEquipKey.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblEquipKey.UseMnemonic = True
		Me.lblEquipKey.Visible = True
		Me.lblEquipKey.AutoSize = False
		Me.lblEquipKey.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblEquipKey.Name = "lblEquipKey"
		Me.lblEquipDesc.Text = "Equipment Desc:"
		Me.lblEquipDesc.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblEquipDesc.Size = New System.Drawing.Size(97, 17)
		Me.lblEquipDesc.Location = New System.Drawing.Point(8, 56)
		Me.lblEquipDesc.TabIndex = 94
		Me.lblEquipDesc.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblEquipDesc.BackColor = System.Drawing.SystemColors.Control
		Me.lblEquipDesc.Enabled = True
		Me.lblEquipDesc.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblEquipDesc.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblEquipDesc.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblEquipDesc.UseMnemonic = True
		Me.lblEquipDesc.Visible = True
		Me.lblEquipDesc.AutoSize = False
		Me.lblEquipDesc.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblEquipDesc.Name = "lblEquipDesc"
		Me.lblLastMeterReadingDate.Text = "Meter Reading Date:"
		Me.lblLastMeterReadingDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblLastMeterReadingDate.Size = New System.Drawing.Size(105, 17)
		Me.lblLastMeterReadingDate.Location = New System.Drawing.Point(360, 32)
		Me.lblLastMeterReadingDate.TabIndex = 93
		Me.lblLastMeterReadingDate.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblLastMeterReadingDate.BackColor = System.Drawing.SystemColors.Control
		Me.lblLastMeterReadingDate.Enabled = True
		Me.lblLastMeterReadingDate.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblLastMeterReadingDate.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblLastMeterReadingDate.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblLastMeterReadingDate.UseMnemonic = True
		Me.lblLastMeterReadingDate.Visible = True
		Me.lblLastMeterReadingDate.AutoSize = False
		Me.lblLastMeterReadingDate.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblLastMeterReadingDate.Name = "lblLastMeterReadingDate"
		Me.lblLastMeterReading.Text = "Meter Reading:"
		Me.lblLastMeterReading.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblLastMeterReading.Size = New System.Drawing.Size(81, 17)
		Me.lblLastMeterReading.Location = New System.Drawing.Point(200, 32)
		Me.lblLastMeterReading.TabIndex = 92
		Me.lblLastMeterReading.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblLastMeterReading.BackColor = System.Drawing.SystemColors.Control
		Me.lblLastMeterReading.Enabled = True
		Me.lblLastMeterReading.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblLastMeterReading.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblLastMeterReading.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblLastMeterReading.UseMnemonic = True
		Me.lblLastMeterReading.Visible = True
		Me.lblLastMeterReading.AutoSize = False
		Me.lblLastMeterReading.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblLastMeterReading.Name = "lblLastMeterReading"
		Me.FramGrid.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.FramGrid.Size = New System.Drawing.Size(545, 393)
		Me.FramGrid.Location = New System.Drawing.Point(16, 0)
		Me.FramGrid.TabIndex = 97
		Me.FramGrid.BackColor = System.Drawing.SystemColors.Control
		Me.FramGrid.Enabled = True
		Me.FramGrid.ForeColor = System.Drawing.SystemColors.ControlText
		Me.FramGrid.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.FramGrid.Visible = True
		Me.FramGrid.Name = "FramGrid"
		DGridEquipment.OcxState = CType(resources.GetObject("DGridEquipment.OcxState"), System.Windows.Forms.AxHost.State)
		Me.DGridEquipment.Size = New System.Drawing.Size(529, 369)
		Me.DGridEquipment.Location = New System.Drawing.Point(8, 16)
		Me.DGridEquipment.TabIndex = 98
		Me.DGridEquipment.Name = "DGridEquipment"
		Me.lblPlantNameG.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblPlantNameG.Size = New System.Drawing.Size(97, 17)
		Me.lblPlantNameG.Location = New System.Drawing.Point(0, 0)
		Me.lblPlantNameG.TabIndex = 100
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
		Me.Controls.Add(cmdPrintForm)
		Me.Controls.Add(Framform)
		Me.Controls.Add(FramGrid)
		Me.Framform.Controls.Add(txtCount)
		Me.Framform.Controls.Add(txtEquipKey)
		Me.Framform.Controls.Add(txtEquipDesc)
		Me.Framform.Controls.Add(txtMeterReading)
		Me.Framform.Controls.Add(SSTab1)
		Me.Framform.Controls.Add(txtMeterReadingDate)
		Me.Framform.Controls.Add(lblPlantName)
		Me.Framform.Controls.Add(lblEquipKey)
		Me.Framform.Controls.Add(lblEquipDesc)
		Me.Framform.Controls.Add(lblLastMeterReadingDate)
		Me.Framform.Controls.Add(lblLastMeterReading)
		Me.SSTab1.Controls.Add(_SSTab1_TabPage0)
		Me.SSTab1.Controls.Add(_SSTab1_TabPage1)
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
		Me._SSTab1_TabPage0.Controls.Add(txtMechTdh)
		Me._SSTab1_TabPage0.Controls.Add(txtMechSize)
		Me._SSTab1_TabPage0.Controls.Add(txtMechCap)
		Me._SSTab1_TabPage0.Controls.Add(txtMechRpm)
		Me._SSTab1_TabPage0.Controls.Add(txtMechHp)
		Me._SSTab1_TabPage0.Controls.Add(txtMechImpSz)
		Me._SSTab1_TabPage0.Controls.Add(txtMechModel)
		Me._SSTab1_TabPage0.Controls.Add(txtMechFrame)
		Me._SSTab1_TabPage0.Controls.Add(txtMechID)
		Me._SSTab1_TabPage0.Controls.Add(txtMechSerial)
		Me._SSTab1_TabPage0.Controls.Add(txtMechCfm)
		Me._SSTab1_TabPage0.Controls.Add(txtMechMinRpm)
		Me._SSTab1_TabPage0.Controls.Add(txtMechMaxRpm)
		Me._SSTab1_TabPage0.Controls.Add(txtMechCatNo)
		Me._SSTab1_TabPage0.Controls.Add(txtMechRecomSpareParts)
		Me._SSTab1_TabPage0.Controls.Add(txtMechMiscNPData)
		Me._SSTab1_TabPage0.Controls.Add(txtMechNoOfValvesTypes)
		Me._SSTab1_TabPage0.Controls.Add(txtMechPipeType)
		Me._SSTab1_TabPage0.Controls.Add(txtMechPipeSize)
		Me._SSTab1_TabPage0.Controls.Add(txtMechOil)
		Me._SSTab1_TabPage0.Controls.Add(txtMechOilFilter)
		Me._SSTab1_TabPage0.Controls.Add(txtMechAirFilter)
		Me._SSTab1_TabPage0.Controls.Add(txtMechBelt1)
		Me._SSTab1_TabPage0.Controls.Add(txtMechBelt2)
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
		Me._SSTab1_TabPage1.Controls.Add(txtElecSerial)
		Me._SSTab1_TabPage1.Controls.Add(txtElecID)
		Me._SSTab1_TabPage1.Controls.Add(txtElecModel)
		Me._SSTab1_TabPage1.Controls.Add(txtElecSf)
		Me._SSTab1_TabPage1.Controls.Add(txtElecPhs)
		Me._SSTab1_TabPage1.Controls.Add(txtElecRpm)
		Me._SSTab1_TabPage1.Controls.Add(txtElecHp)
		Me._SSTab1_TabPage1.Controls.Add(txtElecCatNo)
		Me._SSTab1_TabPage1.Controls.Add(txtElecFrame)
		Me._SSTab1_TabPage1.Controls.Add(txtElecDesign)
		Me._SSTab1_TabPage1.Controls.Add(txtElecInslCl)
		Me._SSTab1_TabPage1.Controls.Add(txtElecDuty)
		Me._SSTab1_TabPage1.Controls.Add(txtElecAmp)
		Me._SSTab1_TabPage1.Controls.Add(txtElecV)
		Me._SSTab1_TabPage1.Controls.Add(txtElecOppEndBrg)
		Me._SSTab1_TabPage1.Controls.Add(txtElecShaftEndBrg)
		Me._SSTab1_TabPage1.Controls.Add(txtElecMiscNpData)
		Me._SSTab1_TabPage1.Controls.Add(txtElecRecomSpareParts)
		Me._SSTab1_TabPage1.Controls.Add(txtElecHz)
		Me.FramGrid.Controls.Add(DGridEquipment)
		Me.FramGrid.Controls.Add(lblPlantNameG)
		CType(Me.DGridEquipment, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.txtMeterReadingDate, System.ComponentModel.ISupportInitialize).EndInit()
	End Sub
#End Region 
#Region "Upgrade Support "
	Private Shared m_vb6FormDefInstance As frmEquipment
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmEquipment
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmEquipment()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
	'Option Explicit
	
	Dim ans As Short
	Dim intStatus As Short ' 1 - Update, 2 - Add
	Dim rsEquipRetrieve As ADODB.Recordset
	Dim lngMeterReading As Integer
	
	'
	' All the functions for Equipment are in this form module with
	' the exception of validation and returning recordset
	
	Public Sub SearchRec()
		' Not supported for equipment
	End Sub
	
	Public Sub CheckChange()
		' This will check if value on any field has been changed before
		' moving to new window
		If intStatus = 2 Then
			ans = MsgBox("Do you want to save new record?", MsgBoxStyle.YesNo)
			If ans = 6 Then
				Save()
			End If
			ans = 0
		Else
			ChangedData()
		End If
		
	End Sub
	
	Public Function CheckRecordset() As Short
		
		'
		' this function is used only to find out
		' if there is recordset to work on
		'
		
		Dim strSQL As String
		
		On Error GoTo errorhandler
		
		If intPlantPass = 0 Then
			strSQL = "select distinct e.*, p.* from plant p inner join equipment e on p.plant_id = e.plant_fk where e.plant_fk <> 0"
		Else
			strSQL = "select distinct e.*, p.* from plant p inner join equipment e on p.plant_id = e.plant_fk where e.plant_fk = " & intPlantPass
		End If
		
		rsEquipRetrieve = RecordsetEquip(strSQL)
		
		If rsEquipRetrieve.EOF = True Or rsEquipRetrieve.BOF = True Then
			CheckRecordset = 2
			Exit Function
		Else
			CheckRecordset = 1
		End If
		'UPGRADE_NOTE: Object rsEquipRetrieve may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1029"'
		rsEquipRetrieve = Nothing
		Exit Function
errorhandler: 
		
		MsgBox("Error Number - " & Err.Number & ": WOS : Equipment - CheckRecordset: Description - " & Err.Description)
	End Function
	
	Public Sub FormView()
		'
		' User can switch between two views
		'
		
		On Error GoTo errorhandler
		
		FramGrid.Visible = False
		FramForm.Visible = True
		
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS : Equipment - Form View: Description - " & Err.Description)
	End Sub
	
	Public Sub GridView()
		'
		' User can switch between two views
		'
		
		On Error GoTo errorhandler
		
		FramForm.Visible = False
		FramGrid.Visible = True
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS : Equipment - Grid View: Description - " & Err.Description)
	End Sub
	
	'UPGRADE_NOTE: Add was upgraded to Add_Renamed. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1061"'
	Public Sub Add_Renamed()
		
		'
		' Used basically to clear the fields in the form
		' User is not allowed to add unless a plant has been selected
		'
		
		On Error GoTo errorhandler
		' if intTypeEquip = 1 then it is in add mode coming from outside or any other
		' way except by clicking "Add"
		' intTypeEquip = 2 if in AddMode by clicking "Add"
		' else equipment key is not used
		'
		' intStatus = 2 is used to know that it is a add and not update
		'
		If intTypeEquip <> 1 Then
			If intPlantPass = 0 Then
				ans = MsgBox("Can not add equipment unless a specific plant is selected. Please exit the application to reselect a plant.")
			Else
				Clear()
				lngMeterReading = 0
				intTypeEquip = 2
				intStatus = 2
				txtCount.Text = "New Record"
				FormView()
				MDIFormWOS.DefInstance.AddMode()
			End If
			Me.txtEquipKey.Focus()
		Else
			Clear()
			lngMeterReading = 0
			intStatus = 2
			txtCount.Text = "New Record"
			FormView()
			MDIFormWOS.DefInstance.AddMode()
		End If
		Me.lblPlantName.Text = intPlantPass & " - " & strPlantPass
		Me.lblPlantNameG.Text = intPlantPass & " - " & strPlantPass
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - Add: Description - " & Err.Description)
		
	End Sub
	
	Public Sub Cancel()
		
		'
		' Unloads and reloads the form
		'
		
		On Error GoTo errorhandler
		
		Me.Close()
		frmPlant.DefInstance.CheckAll("equip")
		
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - Cancel: Description - " & Err.Description)
	End Sub
	
	Public Sub Clear()
		
		'
		' It will first check if data has been changed. It will ask user if he/she
		' wants to save the record if changed and then clears the fields on the form
		'
		
		On Error GoTo errorhandler
		If intTypeEquip <> 1 Then
			ChangedData()
			'Else
			'    intTypeEquip = 2
		End If
		
		Me.txtEquipKey.Text = ""
		Me.txtEquipDesc.Text = ""
		Me.txtMeterReading.Text = ""
		Me.txtMeterReadingDate.CtlText = ""
		Me.txtMechSerial.Text = ""
		Me.txtMechID.Text = ""
		Me.txtMechModel.Text = ""
		Me.txtMechFrame.Text = ""
		Me.txtMechImpSz.Text = ""
		Me.txtMechHp.Text = ""
		Me.txtMechRpm.Text = ""
		Me.txtMechCap.Text = ""
		Me.txtMechSize.Text = ""
		Me.txtMechTdh.Text = ""
		Me.txtMechCatNo.Text = ""
		Me.txtMechMaxRpm.Text = ""
		Me.txtMechMinRpm.Text = ""
		Me.txtMechCfm.Text = ""
		Me.txtMechOil.Text = ""
		Me.txtMechOilFilter.Text = ""
		Me.txtMechAirFilter.Text = ""
		Me.txtMechBelt1.Text = ""
		Me.txtMechBelt2.Text = ""
		Me.txtMechPipeSize.Text = ""
		Me.txtMechPipeType.Text = ""
		Me.txtMechNoOfValvesTypes.Text = ""
		Me.txtMechMiscNPData.Text = ""
		Me.txtMechRecomSpareParts.Text = ""
		Me.txtElecSerial.Text = ""
		Me.txtElecID.Text = ""
		Me.txtElecModel.Text = ""
		Me.txtElecFrame.Text = ""
		Me.txtElecCatNo.Text = ""
		Me.txtElecHp.Text = ""
		Me.txtElecRpm.Text = ""
		Me.txtElecV.Text = ""
		Me.txtElecAmp.Text = ""
		Me.txtElecHz.Text = ""
		Me.txtElecPhs.Text = ""
		Me.txtElecSf.Text = ""
		Me.txtElecDuty.Text = ""
		Me.txtElecInslCl.Text = ""
		Me.txtElecDesign.Text = ""
		Me.txtElecShaftEndBrg.Text = ""
		Me.txtElecOppEndBrg.Text = ""
		Me.txtElecMiscNpData.Text = ""
		Me.txtElecRecomSpareParts.Text = ""
		
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - Clear: Description - " & Err.Description)
	End Sub
	
	Public Sub Delete()
		
		'
		' Deletes the record on display and moves to next record
		' if there is no next record then moves to previuos
		'
		
		On Error GoTo errorhandler
		
		ans = 0
		FormView()
		ans = MsgBox("Are you sure that you want to delete this record?", MsgBoxStyle.YesNo, "WOS")
		If ans = 6 Then
			rsEquipRetrieve.Delete()
			rsEquipRetrieve.MoveNext()
			If rsEquipRetrieve.EOF Then
				rsEquipRetrieve.MovePrevious()
			End If
			FillFields()
		End If
		
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - Delete: Description - " & Err.Description)
	End Sub
	
	Public Sub RefreshRec()
		
		'
		'
		'
		
		On Error GoTo errorhandler
		
		Me.Close()
		frmPlant.DefInstance.CheckAll("equip")
		'frmEquipment.Show
		
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - Refresh: Description - " & Err.Description)
	End Sub
	
	Public Sub Save()
		
		Dim strSQL As String
		
		'
		' Calls AddUpdateEquip to add or update records
		' If there is no existing recordset it creates an empty recordset
		'
		
		Dim intResult As Short
		
		On Error GoTo errorhandler
		
		
		FormView()
		intResult = ValidateEquipment
		If intResult = 0 Then
			If intTypeEquip = 1 Then
				' do not check if some thing is changed
				strSQL = "Select * from equipment where plant_fk <> 0"
				rsEquipRetrieve = RecordsetEquip(strSQL)
				rsEquipRetrieve.AddNew()
				intTypeEquip = 0
			ElseIf intTypeEquip = 2 Then 
				'AddUpdateEquip
				rsEquipRetrieve.AddNew()
				intTypeEquip = 0
			End If
			
			AddUpdateEquip()
			If intStatus = 2 Then
				Cancel()
			End If
			intStatus = 0
			'MDIFormWOS.cmdAdd.Enabled = True
		End If
		
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - Save: Description - " & Err.Description)
	End Sub
	
	Public Sub AddUpdateEquip()
		
		'
		' If intSatus is 1 then it updates the existing recordset otherwise
		' adds a new one
		'
		
		On Error GoTo errorhandler
		
		If intStatus = 2 Then
			' rsEquipRetrieve.AddNew
			' this has been done when save sub-procedure is called
		Else
			rsEquipRetrieve.Update()
		End If
		rsEquipRetrieve.Fields("equip_key").Value = Me.txtEquipKey.Text
		rsEquipRetrieve.Fields("equip_desc").Value = Me.txtEquipDesc.Text
		If txtMeterReading.Text <> "" Then
			rsEquipRetrieve.Fields("last_meter_reading").Value = Me.txtMeterReading.Text
		Else
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			rsEquipRetrieve.Fields("last_meter_reading").Value = System.DBNull.Value
		End If
		If txtMeterReadingDate.CtlText <> "" Then
			rsEquipRetrieve.Fields("last_meter_reading_date").Value = Me.txtMeterReadingDate.CtlText
		Else
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			rsEquipRetrieve.Fields("last_meter_reading_date").Value = System.DBNull.Value
		End If
		If intPlantPass <> 0 Then
			rsEquipRetrieve.Fields("plant_fk").Value = intPlantPass
		End If
		rsEquipRetrieve.Fields("mech_serial").Value = Me.txtMechSerial.Text
		rsEquipRetrieve.Fields("mech_id").Value = Me.txtMechID.Text
		rsEquipRetrieve.Fields("mech_model").Value = Me.txtMechModel.Text
		rsEquipRetrieve.Fields("mech_frame").Value = Me.txtMechFrame.Text
		rsEquipRetrieve.Fields("mech_imp_sz").Value = Me.txtMechImpSz.Text
		rsEquipRetrieve.Fields("mech_hp").Value = Me.txtMechHp.Text
		rsEquipRetrieve.Fields("mech_rpm").Value = Me.txtMechRpm.Text
		rsEquipRetrieve.Fields("mech_cap").Value = Me.txtMechCap.Text
		rsEquipRetrieve.Fields("mech_size").Value = Me.txtMechSize.Text
		rsEquipRetrieve.Fields("mech_tdh").Value = Me.txtMechTdh.Text
		rsEquipRetrieve.Fields("mech_cat_no").Value = Me.txtMechCatNo.Text
		rsEquipRetrieve.Fields("mech_max_rpm").Value = Me.txtMechMaxRpm.Text
		rsEquipRetrieve.Fields("mech_min_rpm").Value = Me.txtMechMinRpm.Text
		rsEquipRetrieve.Fields("mech_cfm").Value = Me.txtMechCfm.Text
		rsEquipRetrieve.Fields("mech_oil").Value = Me.txtMechOil.Text
		rsEquipRetrieve.Fields("mech_oil_filter").Value = Me.txtMechOilFilter.Text
		rsEquipRetrieve.Fields("mech_air_filter").Value = Me.txtMechAirFilter.Text
		rsEquipRetrieve.Fields("mech_belt1").Value = Me.txtMechBelt1.Text
		rsEquipRetrieve.Fields("mech_belt2").Value = Me.txtMechBelt2.Text
		rsEquipRetrieve.Fields("mech_pipe_size").Value = Me.txtMechPipeSize.Text
		rsEquipRetrieve.Fields("mech_pipe_type").Value = Me.txtMechPipeType.Text
		rsEquipRetrieve.Fields("mech_no_valves_types").Value = Me.txtMechNoOfValvesTypes.Text
		rsEquipRetrieve.Fields("mech_misc_nameplate_data").Value = Me.txtMechMiscNPData.Text
		rsEquipRetrieve.Fields("mech_recommended_spare_parts").Value = Me.txtMechRecomSpareParts.Text
		rsEquipRetrieve.Fields("elec_serial").Value = Me.txtElecSerial.Text
		rsEquipRetrieve.Fields("elec_id").Value = Me.txtElecID.Text
		rsEquipRetrieve.Fields("elec_model").Value = Me.txtElecModel.Text
		rsEquipRetrieve.Fields("elec_frame").Value = Me.txtElecFrame.Text
		rsEquipRetrieve.Fields("elec_cat_no").Value = Me.txtElecCatNo.Text
		rsEquipRetrieve.Fields("elec_hp").Value = Me.txtElecHp.Text
		rsEquipRetrieve.Fields("elec_rpm").Value = Me.txtElecRpm.Text
		rsEquipRetrieve.Fields("elec_v").Value = Me.txtElecV.Text
		rsEquipRetrieve.Fields("elec_amp").Value = Me.txtElecAmp.Text
		rsEquipRetrieve.Fields("elec_hz").Value = Me.txtElecHz.Text
		rsEquipRetrieve.Fields("elec_phs").Value = Me.txtElecPhs.Text
		rsEquipRetrieve.Fields("elec_sf").Value = Me.txtElecSf.Text
		rsEquipRetrieve.Fields("elec_duty").Value = Me.txtElecDuty.Text
		rsEquipRetrieve.Fields("elec_insl_cl").Value = Me.txtElecInslCl.Text
		rsEquipRetrieve.Fields("elec_design").Value = Me.txtElecDesign.Text
		rsEquipRetrieve.Fields("elec_shaft_end_brg").Value = Me.txtElecShaftEndBrg.Text
		rsEquipRetrieve.Fields("elec_opp_end_brg").Value = Me.txtElecOppEndBrg.Text
		rsEquipRetrieve.Fields("elec_misc_nameplate_data").Value = Me.txtElecMiscNpData.Text
		rsEquipRetrieve.Fields("elec_recommended_spare_parts").Value = Me.txtElecRecomSpareParts.Text
		
		rsEquipRetrieve.MoveNext()
		rsEquipRetrieve.MovePrevious()
		
		If intStatus = 2 Then
			ans = MsgBox("New Equipment: " & txtEquipKey.Text & " has been added.", MsgBoxStyle.OKOnly, "WOS")
		Else
			ans = MsgBox("The record has been updated.", MsgBoxStyle.OKOnly, "WOS")
		End If
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - AddUpdateEquip: Description - " & Err.Description)
	End Sub
	
	Private Sub cmdPrintForm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPrintForm.Click
		
		On Error GoTo errorhandler
		'UPGRADE_ISSUE: Form method frmEquipment.PrintForm was not upgraded. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup2064"'
		PrintForm()
		Exit Sub
errorhandler: 
		MsgBox("Unable to print to this default printer. Please check that you have a default printer set up correctly.", MsgBoxStyle.Exclamation, "Print Form Error")
	End Sub
	
	Private Sub DGridEquipment_RowColChange(ByVal eventSender As System.Object, ByVal eventArgs As AxMSDataGridLib.DDataGridEvents_RowColChangeEvent) Handles DGridEquipment.RowColChange
		
		'
		' if Row or col changed in the grid values of the new record
		' are placed in the fields of the invisible framform
		'
		
		On Error GoTo errorhandler
		If FramGrid.Visible = True Then
			FillFields()
		End If
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - DGridEquipment RowColChange: Description - " & Err.Description)
	End Sub
	
	Public Sub FirstRec()
		
		'
		' Move the recordset to the first record and fill appropriate fields
		'
		
		On Error GoTo errorhandler
		
		ChangedData()
		rsEquipRetrieve.MoveFirst()
		FillFields()
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - FirstRec: Description - " & Err.Description)
	End Sub
	
	Public Sub PrintScreen()
		' do nothing
	End Sub
	
	Public Sub LastRec()
		
		'
		' Move the recordset to the last record and fill appropriate fields
		'
		
		On Error GoTo errorhandler
		
		ChangedData()
		rsEquipRetrieve.MoveLast()
		FillFields()
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - LastRec: Description - " & Err.Description)
	End Sub
	
	Public Sub NextRec()
		
		'
		' Move the recordset to the next record and fill appropriate fields
		'
		
		On Error GoTo errorhandler
		
		ChangedData()
		rsEquipRetrieve.MoveNext()
		If rsEquipRetrieve.EOF Then
			rsEquipRetrieve.MovePrevious()
			ans = MsgBox("Already at the end of the list. Can not move any further.")
		End If
		FillFields()
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - NextRec: Description - " & Err.Description)
	End Sub
	
	Public Sub PrevRec()
		
		'
		' Move the recordset to the previous records and fill appropriate fields
		'
		
		On Error GoTo errorhandler
		
		ChangedData()
		rsEquipRetrieve.MovePrevious()
		If rsEquipRetrieve.BOF Then
			rsEquipRetrieve.MoveNext()
			ans = MsgBox("Already at the beginning of the list. Can not move back any more.")
		End If
		FillFields()
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - PrevRec: Description - " & Err.Description)
	End Sub
	
	Public Sub SetGrid()
		
		'
		' When user clicks on GridView button all the column headings are
		' set neatly
		'
		
		Dim intGridWidth As Short
		Dim col2, col1, col3 As Object
		Dim col4 As MSDataGridLib.Column
		
		On Error GoTo errorhandler
		
		DGridEquipment.DataSource = rsEquipRetrieve
		
		col1 = DGridEquipment.Columns(0)
		col2 = DGridEquipment.Columns(1)
		col3 = DGridEquipment.Columns(2)
		col4 = DGridEquipment.Columns(3)
		
		'UPGRADE_WARNING: Couldn't resolve default property of object col1.Caption. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		col1.Caption = "ID"
		'UPGRADE_WARNING: Couldn't resolve default property of object col2.Caption. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		col2.Caption = "PLANT"
		'UPGRADE_WARNING: Couldn't resolve default property of object col3.Caption. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		col3.Caption = "EQUIP KEY"
		col4.Caption = "EQUIP DESC"
		
		intGridWidth = VB6.PixelsToTwipsX(DGridEquipment.Width)
		
		'UPGRADE_WARNING: Couldn't resolve default property of object col1.Width. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		col1.Width = (6 / 81) * intGridWidth
		'UPGRADE_WARNING: Couldn't resolve default property of object col2.Width. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		col2.Width = (12 / 81) * intGridWidth
		'UPGRADE_WARNING: Couldn't resolve default property of object col3.Width. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		col3.Width = (18 / 81) * intGridWidth
		col4.Width = VB6.TwipsToPixelsX((45 / 81) * intGridWidth)
		
		'col1.Locked = True
		'col2.Locked = True
		'col3.Locked = True
		'col4.Locked = True
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - SetGrid: Description - " & Err.Description)
	End Sub
	
	'UPGRADE_WARNING: Form event frmEquipment.Activate has a new behavior. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup2065"'
	Private Sub frmEquipment_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		
		'
		' This event is used to call FindActive function from MDI form
		' so as to enable or disable different buttons based on which form
		' is active
		'
		
		On Error GoTo errorhandler
		'If CheckRecordset = 1 Then
		MDIFormWOS.DefInstance.FindActive((False))
		If intTypeEquip = 1 Then
			MDIFormWOS.DefInstance.AddMode()
		End If
		'End If
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - Form_Activate: Description - " & Err.Description)
	End Sub
	
	Public Function FormLoadType() As Object
		
		'
		' Initially sql is passed to find out if there is recordset then only
		' form is opened if there are records. If there is no records then it is set to add mode
		'
		
		Dim strSQL As String
		
		On Error GoTo errorhandler
		
		FormView()
		
		If CheckRecordset = 2 Then
			intTypeEquip = 1
			Add_Renamed()
		Else
			If intPlantPass = 0 Then
				strSQL = "select distinct e.*, p.* from plant p inner join equipment e on p.plant_id = e.plant_fk where e.plant_fk <> 0"
			Else
				strSQL = "select distinct e.*, p.* from plant p inner join equipment e on p.plant_id = e.plant_fk where e.plant_fk = " & intPlantPass
			End If
			
			rsEquipRetrieve = RecordsetEquip(strSQL)
			rsEquipRetrieve.MoveLast()
			rsEquipRetrieve.MoveFirst()
			
			FillFields()
			
			SetGrid()
		End If
		Exit Function
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - FormLoadType: Description - " & Err.Description)
	End Function
	
	Private Sub frmEquipment_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
		'
		' This procedure can be used for hotkey functionality, which is
		' currently working only for History screen
		'
		
		Dim intKeyValue As Short
		
		On Error GoTo errorhandler
		
		intKeyValue = KeyCode
		
		' F8(value 119) save then move to previous record
		' F9(value 120) save then move to next record
		' F10(value 121) can be used to save then move to the next(new) record
		
		If intKeyValue = 121 Then
			Save()
			intTypeEquip = 2
			Add_Renamed()
			MDIFormWOS.DefInstance.Activate()
			frmEquipment.DefInstance.Activate()
			frmEquipment.DefInstance.txtEquipKey.Focus()
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
			frmEquipment.DefInstance.Activate()
			frmEquipment.DefInstance.txtEquipKey.Focus()
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
			frmEquipment.DefInstance.Activate()
			frmEquipment.DefInstance.txtEquipKey.Focus()
			'MDIFormWOS.FindActive (False)
		End If
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - Form_Keyup: Description - " & Err.Description)
	End Sub
	
	Private Sub frmEquipment_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
		'
		' Setting the size and position of the form and
		' calling FormLoadType open in AddMode or Update or View Mode
		'
		
		On Error GoTo errorhandler
		intStatus = 0
		Me.Height = VB6.TwipsToPixelsY(7000)
		Me.Width = VB6.TwipsToPixelsX(9300)
		Me.Left = 0
		Me.Top = 0
		FormLoadType()
		'"select e.equip_id, e.equip_key, " & _
		'"e.equip_desc, e.mech_serial, " & _
		'"e.mech_id, e.mech_model, " & _
		'"e.mech_frame, e.mech_imp_sz, " & _
		'"e.mech_hp, e.mech_rpm, e.mech_cap, " & _
		'"e.mech_size, e.mech_tdh, e.mech_cat_no, " & _
		'"e.mech_max_rpm, e.mech_min_rpm, " & _
		'"e.mech_cfm, e.mech_pipe_size, " & _
		'"e.mech_pipe_type, e.mech_no_valves_types, " & _
		'"e.mech_misc_nameplate_data, e.mech_recommended_spare_parts, " & _
		'"e.elec_serial, e.elec_id, e.elec_model, e.elec_frame, " & _
		'"e.elec_cat_no, e.elec_hp, e.elec_rpm, e.elec_v, " & _
		'"e.elec_amp, e.elec_hz, e.elec_phs, e.elec_sf, " & _
		'"e.elec_duty, e.elec_insl_cl, e.elec_design, " & _
		'"e.elec_shaft_end_brg, e.elec_opp_end_brg, " & _
		'"e.elec_misc_nameplate_data, e.elec_recommended_spare_parts, " & _
		'"e.last_meter_reading, e.last_meter_reading_date " & _
		'"from equipment e, plant p where e.plant_fk = p.plant_id and p.plant_name = '" & (strPlantPass) & "'"
		
		'AdodcMaintenance.Refresh
		
		'If AdodcMaintenance.Recordset.EOF = True Or AdodcMaintenance.Recordset.BOF = True Then
		'    Ans = MsgBox("There are no records for plant " & strPlantPass)
		'    End
		'Else
		'    AdodcMaintenance.Recordset.MoveLast
		'    intRecordCount = AdodcMaintenance.Recordset.RecordCount
		'    If intRecordCount = 0 Then
		'        Ans = MsgBox("There are not records for plant " & strPlantPass & ". Please enter new equipment for it. ")
		'        Me.Hide
		'        frmAddEquip.Show
		'    End If
		
		'    AdodcMaintenance.Recordset.MoveFirst
		'End If
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - Form_Load: Description - " & Err.Description)
	End Sub
	
	Private Sub KeepCount()
		
		'
		' Updates the counter positioned at the top of the formview frame
		'
		
		On Error GoTo errorhandler
		
		Me.txtCount.Text = "Record No. " & rsEquipRetrieve.AbsolutePosition & " of " & rsEquipRetrieve.RecordCount & " Records"
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - KeepCount: Description - " & Err.Description)
	End Sub
	
	Public Sub ChangedData()
		
		'
		' Checks if any of the fields has changed since it was retrieved and
		' shown on the fields
		'
		
		Dim intChangedCount As Short
		
		'On Error GoTo errorhandler
		
		intChangedCount = 0
		ans = 0
		If rsEquipRetrieve.Fields("equip_key").Value <> Me.txtEquipKey.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsEquipRetrieve.Fields("equip_desc").Value <> Me.txtEquipDesc.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsEquipRetrieve.Fields("last_meter_reading").Value <> Me.txtMeterReading.Text Then
			intChangedCount = intChangedCount + 1
		End If
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
		If rsEquipRetrieve.Fields("last_meter_reading_date").Value <> Me.txtMeterReadingDate.CtlText Or (IsDbNull(rsEquipRetrieve.Fields("last_meter_reading_date").Value) And (Me.txtMeterReadingDate.CtlText <> "")) Then
			intChangedCount = intChangedCount + 1
		End If
		If rsEquipRetrieve.Fields("mech_serial").Value <> Me.txtMechSerial.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsEquipRetrieve.Fields("mech_id").Value <> Me.txtMechID.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsEquipRetrieve.Fields("mech_model").Value <> Me.txtMechModel.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsEquipRetrieve.Fields("mech_frame").Value <> Me.txtMechFrame.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsEquipRetrieve.Fields("mech_imp_sz").Value <> Me.txtMechImpSz.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsEquipRetrieve.Fields("mech_hp").Value <> Me.txtMechHp.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsEquipRetrieve.Fields("mech_rpm").Value <> Me.txtMechRpm.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsEquipRetrieve.Fields("mech_cap").Value <> Me.txtMechCap.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsEquipRetrieve.Fields("mech_size").Value <> Me.txtMechSize.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsEquipRetrieve.Fields("mech_tdh").Value <> Me.txtMechTdh.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsEquipRetrieve.Fields("mech_cat_no").Value <> Me.txtMechCatNo.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsEquipRetrieve.Fields("mech_max_rpm").Value <> Me.txtMechMaxRpm.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsEquipRetrieve.Fields("mech_min_rpm").Value <> Me.txtMechMinRpm.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsEquipRetrieve.Fields("mech_cfm").Value <> Me.txtMechCfm.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsEquipRetrieve.Fields("mech_oil").Value <> Me.txtMechOil.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsEquipRetrieve.Fields("mech_oil_filter").Value <> Me.txtMechOilFilter.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsEquipRetrieve.Fields("mech_air_filter").Value <> Me.txtMechAirFilter.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsEquipRetrieve.Fields("mech_belt1").Value <> Me.txtMechBelt1.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsEquipRetrieve.Fields("mech_belt2").Value <> Me.txtMechBelt2.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsEquipRetrieve.Fields("mech_pipe_size").Value <> Me.txtMechPipeSize.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsEquipRetrieve.Fields("mech_pipe_type").Value <> Me.txtMechPipeType.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsEquipRetrieve.Fields("mech_no_valves_types").Value <> Me.txtMechNoOfValvesTypes.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsEquipRetrieve.Fields("mech_misc_nameplate_data").Value <> Me.txtMechMiscNPData.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsEquipRetrieve.Fields("mech_recommended_spare_parts").Value <> Me.txtMechRecomSpareParts.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsEquipRetrieve.Fields("elec_serial").Value <> Me.txtElecSerial.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsEquipRetrieve.Fields("elec_id").Value <> Me.txtElecID.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsEquipRetrieve.Fields("elec_model").Value <> Me.txtElecModel.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsEquipRetrieve.Fields("elec_frame").Value <> Me.txtElecFrame.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsEquipRetrieve.Fields("elec_cat_no").Value <> Me.txtElecCatNo.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsEquipRetrieve.Fields("elec_hp").Value <> Me.txtElecHp.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsEquipRetrieve.Fields("elec_rpm").Value <> Me.txtElecRpm.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsEquipRetrieve.Fields("elec_v").Value <> Me.txtElecV.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsEquipRetrieve.Fields("elec_amp").Value <> Me.txtElecAmp.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsEquipRetrieve.Fields("elec_hz").Value <> Me.txtElecHz.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsEquipRetrieve.Fields("elec_phs").Value <> Me.txtElecPhs.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsEquipRetrieve.Fields("elec_sf").Value <> Me.txtElecSf.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsEquipRetrieve.Fields("elec_duty").Value <> Me.txtElecDuty.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsEquipRetrieve.Fields("elec_insl_cl").Value <> Me.txtElecInslCl.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsEquipRetrieve.Fields("elec_design").Value <> Me.txtElecDesign.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsEquipRetrieve.Fields("elec_shaft_end_brg").Value <> Me.txtElecShaftEndBrg.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsEquipRetrieve.Fields("elec_opp_end_brg").Value <> Me.txtElecOppEndBrg.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsEquipRetrieve.Fields("elec_misc_nameplate_data").Value <> Me.txtElecMiscNpData.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If rsEquipRetrieve.Fields("elec_recommended_spare_parts").Value <> Me.txtElecRecomSpareParts.Text Then
			intChangedCount = intChangedCount + 1
		End If
		If intChangedCount > 0 Then
			ans = MsgBox("Do you want to save the changed data?", MsgBoxStyle.YesNo, "WOS")
			If ans = 6 Then
				Save()
			End If
		End If
		'Exit Sub
		'errorhandler:
		'MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - ChangedData: Description - " & Err.Description
	End Sub
	
	Private Sub FillFields()
		
		'
		' Fills all the fields for the current recordset
		'
		
		Dim intCount As Short
		
		On Error GoTo errorhandler
		
		If rsEquipRetrieve.EOF = True Or rsEquipRetrieve.BOF = True Then
			intCount = rsEquipRetrieve.RecordCount
			If intCount = 0 Then
				MsgBox("There are no more equipment for this plant in the database")
				Me.Close()
				frmPlant.DefInstance.CheckAll("equip")
			End If
		Else
			Me.lblPlantName.Text = intPlantPass & " - " & strPlantPass
			Me.lblPlantNameG.Text = intPlantPass & " - " & strPlantPass
			'If IsNull(rsEquipRetrieve!plant_id) Then
			'    Me.lblPlantName.Caption = ""
			'    Me.lblPlantNameG.Caption = ""
			'Else
			'    Me.lblPlantName.Caption = rsEquipRetrieve!plant_id & " - " & rsEquipRetrieve!plant_name
			'    Me.lblPlantNameG.Caption = rsEquipRetrieve!plant_id & " - " & rsEquipRetrieve!plant_name
			'End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipRetrieve.Fields("equip_key").Value) Then
				Me.txtEquipKey.Text = ""
			Else
				Me.txtEquipKey.Text = rsEquipRetrieve.Fields("equip_key").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipRetrieve.Fields("equip_desc").Value) Then
				Me.txtEquipDesc.Text = ""
			Else
				Me.txtEquipDesc.Text = rsEquipRetrieve.Fields("equip_desc").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipRetrieve.Fields("last_meter_reading").Value) Then
				Me.txtMeterReading.Text = ""
			Else
				Me.txtMeterReading.Text = rsEquipRetrieve.Fields("last_meter_reading").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipRetrieve.Fields("last_meter_reading_date").Value) Then
				Me.txtMeterReadingDate.CtlText = ""
			Else
				Me.txtMeterReadingDate.CtlText = rsEquipRetrieve.Fields("last_meter_reading_date").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipRetrieve.Fields("mech_serial").Value) Then
				Me.txtMechSerial.Text = ""
			Else
				Me.txtMechSerial.Text = rsEquipRetrieve.Fields("mech_serial").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipRetrieve.Fields("mech_id").Value) Then
				Me.txtMechID.Text = ""
			Else
				Me.txtMechID.Text = rsEquipRetrieve.Fields("mech_id").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipRetrieve.Fields("mech_model").Value) Then
				Me.txtMechModel.Text = ""
			Else
				Me.txtMechModel.Text = rsEquipRetrieve.Fields("mech_model").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipRetrieve.Fields("mech_frame").Value) Then
				Me.txtMechFrame.Text = ""
			Else
				Me.txtMechFrame.Text = rsEquipRetrieve.Fields("mech_frame").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipRetrieve.Fields("mech_imp_sz").Value) Then
				Me.txtMechImpSz.Text = ""
			Else
				Me.txtMechImpSz.Text = rsEquipRetrieve.Fields("mech_imp_sz").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipRetrieve.Fields("mech_hp").Value) Then
				Me.txtMechHp.Text = ""
			Else
				Me.txtMechHp.Text = rsEquipRetrieve.Fields("mech_hp").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipRetrieve.Fields("mech_rpm").Value) Then
				Me.txtMechRpm.Text = ""
			Else
				Me.txtMechRpm.Text = rsEquipRetrieve.Fields("mech_rpm").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipRetrieve.Fields("mech_cap").Value) Then
				Me.txtMechCap.Text = ""
			Else
				Me.txtMechCap.Text = rsEquipRetrieve.Fields("mech_cap").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipRetrieve.Fields("mech_size").Value) Then
				Me.txtMechSize.Text = ""
			Else
				Me.txtMechSize.Text = rsEquipRetrieve.Fields("mech_size").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipRetrieve.Fields("mech_tdh").Value) Then
				Me.txtMechTdh.Text = ""
			Else
				Me.txtMechTdh.Text = rsEquipRetrieve.Fields("mech_tdh").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipRetrieve.Fields("mech_cat_no").Value) Then
				Me.txtMechCatNo.Text = ""
			Else
				Me.txtMechCatNo.Text = rsEquipRetrieve.Fields("mech_cat_no").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipRetrieve.Fields("mech_max_rpm").Value) Then
				Me.txtMechMaxRpm.Text = ""
			Else
				Me.txtMechMaxRpm.Text = rsEquipRetrieve.Fields("mech_max_rpm").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipRetrieve.Fields("mech_min_rpm").Value) Then
				Me.txtMechMinRpm.Text = ""
			Else
				Me.txtMechMinRpm.Text = rsEquipRetrieve.Fields("mech_min_rpm").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipRetrieve.Fields("mech_cfm").Value) Then
				Me.txtMechCfm.Text = ""
			Else
				Me.txtMechCfm.Text = rsEquipRetrieve.Fields("mech_cfm").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipRetrieve.Fields("mech_oil").Value) Then
				Me.txtMechOil.Text = ""
			Else
				Me.txtMechOil.Text = rsEquipRetrieve.Fields("mech_oil").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipRetrieve.Fields("mech_oil_filter").Value) Then
				Me.txtMechOilFilter.Text = ""
			Else
				Me.txtMechOilFilter.Text = rsEquipRetrieve.Fields("mech_oil_filter").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipRetrieve.Fields("mech_air_filter").Value) Then
				Me.txtMechAirFilter.Text = ""
			Else
				Me.txtMechAirFilter.Text = rsEquipRetrieve.Fields("mech_air_filter").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipRetrieve.Fields("mech_belt1").Value) Then
				Me.txtMechBelt1.Text = ""
			Else
				Me.txtMechBelt1.Text = rsEquipRetrieve.Fields("mech_belt1").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipRetrieve.Fields("mech_belt2").Value) Then
				Me.txtMechBelt2.Text = ""
			Else
				Me.txtMechBelt2.Text = rsEquipRetrieve.Fields("mech_belt2").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipRetrieve.Fields("mech_pipe_size").Value) Then
				Me.txtMechPipeSize.Text = ""
			Else
				Me.txtMechPipeSize.Text = rsEquipRetrieve.Fields("mech_pipe_size").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipRetrieve.Fields("mech_pipe_type").Value) Then
				Me.txtMechPipeType.Text = ""
			Else
				Me.txtMechPipeType.Text = rsEquipRetrieve.Fields("mech_pipe_type").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipRetrieve.Fields("mech_no_valves_types").Value) Then
				Me.txtMechNoOfValvesTypes.Text = ""
			Else
				Me.txtMechNoOfValvesTypes.Text = rsEquipRetrieve.Fields("mech_no_valves_types").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipRetrieve.Fields("mech_misc_nameplate_data").Value) Then
				Me.txtMechMiscNPData.Text = ""
			Else
				Me.txtMechMiscNPData.Text = rsEquipRetrieve.Fields("mech_misc_nameplate_data").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipRetrieve.Fields("mech_recommended_spare_parts").Value) Then
				Me.txtMechRecomSpareParts.Text = ""
			Else
				Me.txtMechRecomSpareParts.Text = rsEquipRetrieve.Fields("mech_recommended_spare_parts").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipRetrieve.Fields("elec_serial").Value) Then
				Me.txtElecSerial.Text = ""
			Else
				Me.txtElecSerial.Text = rsEquipRetrieve.Fields("elec_serial").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipRetrieve.Fields("elec_id").Value) Then
				Me.txtElecID.Text = ""
			Else
				Me.txtElecID.Text = rsEquipRetrieve.Fields("elec_id").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipRetrieve.Fields("elec_model").Value) Then
				Me.txtElecModel.Text = ""
			Else
				Me.txtElecModel.Text = rsEquipRetrieve.Fields("elec_model").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipRetrieve.Fields("elec_frame").Value) Then
				Me.txtElecFrame.Text = ""
			Else
				Me.txtElecFrame.Text = rsEquipRetrieve.Fields("elec_frame").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipRetrieve.Fields("elec_cat_no").Value) Then
				Me.txtElecCatNo.Text = ""
			Else
				Me.txtElecCatNo.Text = rsEquipRetrieve.Fields("elec_cat_no").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipRetrieve.Fields("elec_hp").Value) Then
				Me.txtElecHp.Text = ""
			Else
				Me.txtElecHp.Text = rsEquipRetrieve.Fields("elec_hp").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipRetrieve.Fields("elec_rpm").Value) Then
				Me.txtElecRpm.Text = ""
			Else
				Me.txtElecRpm.Text = rsEquipRetrieve.Fields("elec_rpm").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipRetrieve.Fields("elec_v").Value) Then
				Me.txtElecV.Text = ""
			Else
				Me.txtElecV.Text = rsEquipRetrieve.Fields("elec_v").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipRetrieve.Fields("elec_amp").Value) Then
				Me.txtElecAmp.Text = ""
			Else
				Me.txtElecAmp.Text = rsEquipRetrieve.Fields("elec_amp").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipRetrieve.Fields("elec_hz").Value) Then
				Me.txtElecHz.Text = ""
			Else
				Me.txtElecHz.Text = rsEquipRetrieve.Fields("elec_hz").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipRetrieve.Fields("elec_phs").Value) Then
				Me.txtElecPhs.Text = ""
			Else
				Me.txtElecPhs.Text = rsEquipRetrieve.Fields("elec_phs").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipRetrieve.Fields("elec_sf").Value) Then
				Me.txtElecSf.Text = ""
			Else
				Me.txtElecSf.Text = rsEquipRetrieve.Fields("elec_sf").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipRetrieve.Fields("elec_duty").Value) Then
				Me.txtElecDuty.Text = ""
			Else
				Me.txtElecDuty.Text = rsEquipRetrieve.Fields("elec_duty").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipRetrieve.Fields("elec_insl_cl").Value) Then
				Me.txtElecInslCl.Text = ""
			Else
				Me.txtElecInslCl.Text = rsEquipRetrieve.Fields("elec_insl_cl").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipRetrieve.Fields("elec_design").Value) Then
				Me.txtElecDesign.Text = ""
			Else
				Me.txtElecDesign.Text = rsEquipRetrieve.Fields("elec_design").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipRetrieve.Fields("elec_shaft_end_brg").Value) Then
				Me.txtElecShaftEndBrg.Text = ""
			Else
				Me.txtElecShaftEndBrg.Text = rsEquipRetrieve.Fields("elec_shaft_end_brg").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipRetrieve.Fields("elec_opp_end_brg").Value) Then
				Me.txtElecOppEndBrg.Text = ""
			Else
				Me.txtElecOppEndBrg.Text = rsEquipRetrieve.Fields("elec_opp_end_brg").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipRetrieve.Fields("elec_misc_nameplate_data").Value) Then
				Me.txtElecMiscNpData.Text = ""
			Else
				Me.txtElecMiscNpData.Text = rsEquipRetrieve.Fields("elec_misc_nameplate_data").Value
			End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
			If IsDbNull(rsEquipRetrieve.Fields("elec_recommended_spare_parts").Value) Then
				Me.txtElecRecomSpareParts.Text = ""
			Else
				Me.txtElecRecomSpareParts.Text = rsEquipRetrieve.Fields("elec_recommended_spare_parts").Value
			End If
			KeepCount()
		End If
		
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - FillFields: Description - " & Err.Description)
	End Sub
	
	'UPGRADE_WARNING: Form event frmEquipment.Unload has a new behavior. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup2065"'
	Private Sub frmEquipment_Closed(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Closed
		
		'
		' Sets the recordset to nothing and sets other form level variables to zero or
		' empty string
		'
		
		On Error GoTo errorhandler
		
		'UPGRADE_NOTE: Object rsEquipRetrieve may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1029"'
		rsEquipRetrieve = Nothing
		intTypeEquip = 0
		MDIFormWOS.DefInstance.FindActive((True))
		'Set cnWos = Nothing
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - Form_Unload: Description - " & Err.Description)
	End Sub
	
	
	
	Private Sub txtElecAmp_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtElecAmp.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'
		'
		'
		
		Dim intLen As Short
		Dim ans As Short
		
		On Error GoTo errorhandler
		
		intLen = Len(txtElecAmp.Text)
		If intLen > 12 Then
			Beep()
			ans = MsgBox("The APM field can not have more than 12 characters.", MsgBoxStyle.OKOnly, "WOS")
			txtElecAmp.Text = ""
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - txtElecAmp Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub txtElecCatNo_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtElecCatNo.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'
		'
		'
		
		
		Dim intLen As Short
		Dim ans As Short
		On Error GoTo errorhandler
		
		intLen = Len(txtElecCatNo.Text)
		If intLen > 10 Then
			Beep()
			ans = MsgBox("The CAT NO field can not have more than 10 characters.", MsgBoxStyle.OKOnly, "WOS")
			txtElecCatNo.Text = ""
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - txtElecCatNo Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub txtElecDesign_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtElecDesign.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'
		'
		'
		
		
		Dim intLen As Short
		Dim ans As Short
		On Error GoTo errorhandler
		
		intLen = Len(txtElecDesign.Text)
		If intLen > 3 Then
			Beep()
			ans = MsgBox("The DESIGN field can not have more than 3 characters.", MsgBoxStyle.OKOnly, "WOS")
			txtElecDesign.Text = ""
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - txtElecDesign Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub txtElecDuty_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtElecDuty.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'
		'
		'
		
		
		Dim intLen As Short
		Dim ans As Short
		On Error GoTo errorhandler
		
		intLen = Len(txtElecDuty.Text)
		If intLen > 5 Then
			Beep()
			ans = MsgBox("The DUTY field can not have more than 5 characters.", MsgBoxStyle.OKOnly, "WOS")
			txtElecDuty.Text = ""
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - txtElecDuty Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub txtElecFrame_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtElecFrame.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'
		'
		'
		
		
		Dim intLen As Short
		Dim ans As Short
		On Error GoTo errorhandler
		
		intLen = Len(txtElecFrame.Text)
		If intLen > 7 Then
			Beep()
			ans = MsgBox("The FRAME field can not have more than 7 characters.", MsgBoxStyle.OKOnly, "WOS")
			txtElecFrame.Text = ""
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - txtElecFrame Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub txtElecHp_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtElecHp.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'
		'
		'
		
		
		Dim intLen As Short
		Dim ans As Short
		On Error GoTo errorhandler
		
		intLen = Len(txtElecHp.Text)
		If intLen > 5 Then
			Beep()
			ans = MsgBox("The HP field can not have more than 5 characters.", MsgBoxStyle.OKOnly, "WOS")
			txtElecHp.Text = ""
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - txtElecHp Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub txtElecHz_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtElecHz.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'
		'
		'
		
		
		Dim intLen As Short
		Dim ans As Short
		On Error GoTo errorhandler
		
		intLen = Len(txtElecHz.Text)
		If intLen > 3 Then
			Beep()
			ans = MsgBox("The HZ field can not have more than 3 characters.", MsgBoxStyle.OKOnly, "WOS")
			txtElecHz.Text = ""
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - txtElecHz Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub txtElecID_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtElecID.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'
		'
		'
		
		
		Dim intLen As Short
		Dim ans As Short
		On Error GoTo errorhandler
		
		intLen = Len(txtElecID.Text)
		If intLen > 13 Then
			Beep()
			ans = MsgBox("The ID field can not have more than 13 characters.", MsgBoxStyle.OKOnly, "WOS")
			txtElecID.Text = ""
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - txtElecID Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub txtElecInslCl_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtElecInslCl.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'
		'
		'
		
		
		Dim intLen As Short
		Dim ans As Short
		On Error GoTo errorhandler
		
		intLen = Len(txtElecInslCl.Text)
		If intLen > 3 Then
			Beep()
			ans = MsgBox("The INSL CL field can not have more than 3 characters.", MsgBoxStyle.OKOnly, "WOS")
			txtElecInslCl.Text = ""
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - txtElecInslCl Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub txtElecMiscNpData_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtElecMiscNpData.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'
		'
		'
		
		
		Dim intLen As Short
		Dim ans As Short
		On Error GoTo errorhandler
		
		intLen = Len(txtElecMiscNpData.Text)
		If intLen > 65 Then
			Beep()
			ans = MsgBox("The MISC NAMEPLATE DATA field can not have more than 65 characters.", MsgBoxStyle.OKOnly, "WOS")
			txtElecMiscNpData.Text = ""
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - txtElecMiscNPData Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub txtElecModel_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtElecModel.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'
		'
		'
		
		
		Dim intLen As Short
		Dim ans As Short
		On Error GoTo errorhandler
		
		intLen = Len(txtElecModel.Text)
		If intLen > 15 Then
			Beep()
			ans = MsgBox("The MODEL field can not have more than 15 characters.", MsgBoxStyle.OKOnly, "WOS")
			txtElecModel.Text = ""
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - txtElecModel Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub txtElecOppEndBrg_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtElecOppEndBrg.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'
		'
		'
		
		
		Dim intLen As Short
		Dim ans As Short
		On Error GoTo errorhandler
		
		intLen = Len(txtElecOppEndBrg.Text)
		If intLen > 13 Then
			Beep()
			ans = MsgBox("The OPP END BRG field can not have more than 13 characters.", MsgBoxStyle.OKOnly, "WOS")
			txtElecOppEndBrg.Text = ""
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - txtElecOppEndBrg Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub txtElecPhs_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtElecPhs.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'
		'
		'
		
		
		Dim intLen As Short
		Dim ans As Short
		On Error GoTo errorhandler
		
		intLen = Len(txtElecPhs.Text)
		If intLen > 2 Then
			Beep()
			ans = MsgBox("The PHS field can not have more than 2 characters.", MsgBoxStyle.OKOnly, "WOS")
			txtElecPhs.Text = ""
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - txtElecPhs Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub txtElecRecomSpareParts_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtElecRecomSpareParts.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'
		'
		'
		
		Dim intLen As Short
		Dim ans As Short
		
		On Error GoTo errorhandler
		
		intLen = Len(txtElecRecomSpareParts.Text)
		If intLen > 30 Then
			Beep()
			ans = MsgBox("The RECOMMENDED SPARE PARTS field can not have more than 30 characters.", MsgBoxStyle.OKOnly, "WOS")
			txtElecRecomSpareParts.Text = ""
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - txtElecRecomSpareParts Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub txtElecRpm_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtElecRpm.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'
		'
		'
		
		
		Dim intLen As Short
		Dim ans As Short
		
		On Error GoTo errorhandler
		
		intLen = Len(txtElecRpm.Text)
		If intLen > 6 Then
			Beep()
			ans = MsgBox("The RPM field can not have more than 6 characters.", MsgBoxStyle.OKOnly, "WOS")
			txtElecRpm.Text = ""
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - txtElecRpm Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub txtElecSerial_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtElecSerial.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'
		'
		'
		
		
		Dim intLen As Short
		Dim ans As Short
		On Error GoTo errorhandler
		
		intLen = Len(txtElecSerial.Text)
		If intLen > 13 Then
			Beep()
			ans = MsgBox("The SERIAL field can not have more than 13 characters.", MsgBoxStyle.OKOnly, "WOS")
			txtElecSerial.Text = ""
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - txtElecSerial Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub txtElecSf_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtElecSf.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'
		'
		'
		
		
		Dim intLen As Short
		Dim ans As Short
		On Error GoTo errorhandler
		
		intLen = Len(txtElecSf.Text)
		If intLen > 4 Then
			Beep()
			ans = MsgBox("The SF field can not have more than 4 characters.", MsgBoxStyle.OKOnly, "WOS")
			txtElecSf.Text = ""
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - txtElecSf Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub txtElecShaftEndBrg_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtElecShaftEndBrg.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'
		'
		'
		
		Dim intLen As Short
		Dim ans As Short
		On Error GoTo errorhandler
		
		intLen = Len(txtElecShaftEndBrg.Text)
		If intLen > 13 Then
			Beep()
			ans = MsgBox("The SHAFT END BRG field can not have more than 13 characters.", MsgBoxStyle.OKOnly, "WOS")
			txtElecShaftEndBrg.Text = ""
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - txtElecShaftEndBrg Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub txtElecV_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtElecV.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'
		'
		'
		
		Dim intLen As Short
		Dim ans As Short
		On Error GoTo errorhandler
		
		intLen = Len(txtElecV.Text)
		If intLen > 12 Then
			Beep()
			ans = MsgBox("The V field can not have more than 12 characters.", MsgBoxStyle.OKOnly, "WOS")
			txtElecV.Text = ""
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - txtElecV Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub txtEquipDesc_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtEquipDesc.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'
		'
		'
		
		Dim intLen As Short
		Dim ans As Short
		On Error GoTo errorhandler
		
		intLen = Len(txtEquipDesc.Text)
		If intLen > 100 Then
			Beep()
			ans = MsgBox("The EQUIPMENT DESCRIPTION field can not have more than 100 characters.", MsgBoxStyle.OKOnly, "WOS")
			txtEquipKey.Text = ""
			Cancel = True
		Else
			If intLen = 0 Then
				Beep()
				ans = MsgBox("The EQUIPMENT DESCRIPTION field is a required field.", MsgBoxStyle.OKOnly, "WOS")
				Cancel = True
			End If
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - txtEquipDesc Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	
	Private Sub txtEquipKey_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtEquipKey.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'
		'
		'
		
		Dim intLen As Short
		Dim ans As Short
		On Error GoTo errorhandler
		
		intLen = Len(txtEquipKey.Text)
		If intLen > 10 Then
			Beep()
			ans = MsgBox("The EQUIPMENT KEY field can not have more than 10 characters.", MsgBoxStyle.OKOnly, "WOS")
			txtEquipKey.Text = ""
			Cancel = True
		Else
			If intLen = 0 Then
				Beep()
				ans = MsgBox("The EQUIPMENT KEY field is a required field.", MsgBoxStyle.OKOnly, "WOS")
				Cancel = True
			End If
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - txtEquipKey Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub txtMechAirFilter_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtMechAirFilter.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'
		'
		'
		
		Dim intLen As Short
		Dim ans As Short
		On Error GoTo errorhandler
		
		intLen = Len(txtMechAirFilter.Text)
		
		If intLen > 20 Then
			Beep()
			ans = MsgBox("The AIR FILTER field can not have more than 20 characters.", MsgBoxStyle.OKOnly, "WOS")
			txtMechAirFilter.Text = ""
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - txtMechAirFilter Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub txtMechBelt1_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtMechBelt1.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'
		'
		'
		
		Dim intLen As Short
		Dim ans As Short
		On Error GoTo errorhandler
		
		intLen = Len(txtMechBelt1.Text)
		
		If intLen > 20 Then
			Beep()
			ans = MsgBox("The BELT1 field can not have more than 20 characters.", MsgBoxStyle.OKOnly, "WOS")
			txtMechBelt1.Text = ""
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - txtMeechBelt1 Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub txtMechBelt2_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtMechBelt2.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'
		'
		'
		
		Dim intLen As Short
		Dim ans As Short
		On Error GoTo errorhandler
		
		intLen = Len(txtMechBelt2.Text)
		
		If intLen > 20 Then
			Beep()
			ans = MsgBox("The BELT2 field can not have more than 20 characters.", MsgBoxStyle.OKOnly, "WOS")
			txtMechBelt2.Text = ""
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - txtMechBelt2 Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub txtMechCap_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtMechCap.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'
		'
		'
		
		Dim intLen As Short
		Dim ans As Short
		On Error GoTo errorhandler
		
		intLen = Len(txtMechCap.Text)
		
		If intLen > 6 Then
			Beep()
			ans = MsgBox("The CAP field can not have more than 6 characters.", MsgBoxStyle.OKOnly, "WOS")
			txtMechCap.Text = ""
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - txtMechCap Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub txtMechCatNo_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtMechCatNo.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'
		'
		'
		
		Dim intLen As Short
		Dim ans As Short
		On Error GoTo errorhandler
		
		intLen = Len(txtMechCatNo.Text)
		
		If intLen > 13 Then
			Beep()
			ans = MsgBox("The CAT NO field can not have more than 13 characters.", MsgBoxStyle.OKOnly, "WOS")
			txtMechCatNo.Text = ""
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - txtMechCatNo Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub txtMechCfm_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtMechCfm.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'
		'
		'
		
		Dim intLen As Short
		Dim ans As Short
		On Error GoTo errorhandler
		
		intLen = Len(txtMechCfm.Text)
		
		If intLen > 5 Then
			Beep()
			ans = MsgBox("The CFM field can not have more than 5 characters.", MsgBoxStyle.OKOnly, "WOS")
			txtMechCfm.Text = ""
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - txtMechCfm Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub txtMechFrame_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtMechFrame.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'
		'
		'
		
		Dim intLen As Short
		Dim ans As Short
		On Error GoTo errorhandler
		
		intLen = Len(txtMechFrame.Text)
		
		If intLen > 7 Then
			Beep()
			ans = MsgBox("The FRAME field can not have more than 7 characters.", MsgBoxStyle.OKOnly, "WOS")
			txtMechFrame.Text = ""
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - txtMechFrame Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub txtMechHp_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtMechHp.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'
		'
		'
		
		Dim intLen As Short
		Dim ans As Short
		On Error GoTo errorhandler
		
		intLen = Len(txtMechHp.Text)
		
		If intLen > 5 Then
			Beep()
			ans = MsgBox("The HP field can not have more than 5 characters.", MsgBoxStyle.OKOnly, "WOS")
			txtMechHp.Text = ""
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - txtMechHp Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub txtMechID_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtMechID.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'
		'
		'
		
		Dim intLen As Short
		Dim ans As Short
		On Error GoTo errorhandler
		
		intLen = Len(txtMechID.Text)
		
		If intLen > 13 Then
			Beep()
			ans = MsgBox("The ID field can not have more than 13 characters.", MsgBoxStyle.OKOnly, "WOS")
			txtMechID.Text = ""
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - txtMechID Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub txtMechImpSz_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtMechImpSz.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'
		'
		'
		
		Dim intLen As Short
		Dim ans As Short
		On Error GoTo errorhandler
		
		intLen = Len(txtMechImpSz.Text)
		
		If intLen > 6 Then
			Beep()
			ans = MsgBox("The IMP SZ field can not have more than 6 characters.", MsgBoxStyle.OKOnly, "WOS")
			txtMechImpSz.Text = ""
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - txtMechImpSz Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub txtMechMaxRpm_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtMechMaxRpm.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'
		'
		'
		
		Dim intLen As Short
		Dim ans As Short
		On Error GoTo errorhandler
		
		intLen = Len(txtMechMaxRpm.Text)
		
		If intLen > 5 Then
			Beep()
			ans = MsgBox("The MAX RPM field can not have more than 5 characters.", MsgBoxStyle.OKOnly, "WOS")
			txtMechMaxRpm.Text = ""
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - txtMechMaxRpm Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub txtMechMinRpm_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtMechMinRpm.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'
		'
		'
		
		Dim intLen As Short
		Dim ans As Short
		On Error GoTo errorhandler
		
		intLen = Len(txtMechMinRpm.Text)
		
		If intLen > 5 Then
			Beep()
			ans = MsgBox("The MIN RPM field can not have more than 5 characters.", MsgBoxStyle.OKOnly, "WOS")
			txtMechMinRpm.Text = ""
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - txtMechMinRpm Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub txtMechMiscNPData_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtMechMiscNPData.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'
		'
		'
		
		Dim intLen As Short
		Dim ans As Short
		On Error GoTo errorhandler
		
		intLen = Len(txtMechMiscNPData.Text)
		
		If intLen > 65 Then
			Beep()
			ans = MsgBox("The MISC NAMEPLATE DATA field can not have more than 65 characters.", MsgBoxStyle.OKOnly, "WOS")
			txtMechMiscNPData.Text = ""
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - txtMechMiscNPData Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub txtMechModel_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtMechModel.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'
		'
		'
		
		Dim intLen As Short
		Dim ans As Short
		On Error GoTo errorhandler
		
		intLen = Len(txtMechModel.Text)
		
		If intLen > 15 Then
			Beep()
			ans = MsgBox("The MODEL field can not have more than 15 characters.", MsgBoxStyle.OKOnly, "WOS")
			txtMechModel.Text = ""
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - txtMechModel Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub txtMechNoOfValvesTypes_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtMechNoOfValvesTypes.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'
		'
		'
		
		Dim intLen As Short
		Dim ans As Short
		On Error GoTo errorhandler
		
		intLen = Len(txtMechNoOfValvesTypes.Text)
		
		If intLen > 30 Then
			Beep()
			ans = MsgBox("The NO OF VALVES & TYPES field can not have more than 30 characters.", MsgBoxStyle.OKOnly, "WOS")
			txtMechNoOfValvesTypes.Text = ""
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - txtMechNoOfValvesTypes Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub txtMechOil_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtMechOil.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'
		'
		'
		
		Dim intLen As Short
		Dim ans As Short
		On Error GoTo errorhandler
		
		intLen = Len(txtMechOil.Text)
		
		If intLen > 20 Then
			Beep()
			ans = MsgBox("The OIL field can not have more than 20 characters.", MsgBoxStyle.OKOnly, "WOS")
			txtMechOil.Text = ""
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - txtMechOil Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub txtMechOilFilter_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtMechOilFilter.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'
		'
		'
		
		Dim intLen As Short
		Dim ans As Short
		On Error GoTo errorhandler
		
		intLen = Len(txtMechOilFilter.Text)
		
		If intLen > 20 Then
			Beep()
			ans = MsgBox("The OIL FILTER field can not have more than 20 characters.", MsgBoxStyle.OKOnly, "WOS")
			txtMechOilFilter.Text = ""
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - txtMechOilFilter Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub txtMechPipeSize_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtMechPipeSize.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'
		'
		'
		
		Dim intLen As Short
		Dim ans As Short
		On Error GoTo errorhandler
		
		intLen = Len(txtMechPipeSize.Text)
		
		If intLen > 30 Then
			Beep()
			ans = MsgBox("The PIPE SIZE field can not have more than 30 characters.", MsgBoxStyle.OKOnly, "WOS")
			txtMechPipeSize.Text = ""
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - txtMechPipeSize Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub txtMechPipeType_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtMechPipeType.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'
		'
		'
		
		Dim intLen As Short
		Dim ans As Short
		On Error GoTo errorhandler
		
		intLen = Len(txtMechPipeType.Text)
		
		If intLen > 20 Then
			Beep()
			ans = MsgBox("The PIPE TYPE field can not have more than 20 characters.", MsgBoxStyle.OKOnly, "WOS")
			txtMechPipeType.Text = ""
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - txtMechPipeType Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub txtMechRecomSpareParts_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtMechRecomSpareParts.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'
		'
		'
		
		Dim intLen As Short
		Dim ans As Short
		On Error GoTo errorhandler
		
		intLen = Len(txtMechRecomSpareParts.Text)
		
		If intLen > 30 Then
			Beep()
			ans = MsgBox("The RECOMMENDED SPARE PARTS field can not have more than 30 characters.", MsgBoxStyle.OKOnly, "WOS")
			txtMechRecomSpareParts.Text = ""
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - txtMechRecomSpareParts Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub txtMechRpm_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtMechRpm.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'
		'
		'
		
		Dim intLen As Short
		Dim ans As Short
		On Error GoTo errorhandler
		
		intLen = Len(txtMechRpm.Text)
		
		If intLen > 6 Then
			Beep()
			ans = MsgBox("The RPM field can not have more than 6 characters.", MsgBoxStyle.OKOnly, "WOS")
			txtMechRpm.Text = ""
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - txtMechRpm Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub txtMechSerial_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtMechSerial.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'
		'
		'
		
		Dim intLen As Short
		Dim ans As Short
		On Error GoTo errorhandler
		
		intLen = Len(txtMechSerial.Text)
		
		If intLen > 13 Then
			Beep()
			ans = MsgBox("The SERIAL field can not have more than 13 characters.", MsgBoxStyle.OKOnly, "WOS")
			txtMechSerial.Text = ""
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - txtMechSerial Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub txtMechSize_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtMechSize.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'
		'
		'
		
		Dim intLen As Short
		Dim ans As Short
		On Error GoTo errorhandler
		
		intLen = Len(txtMechSize.Text)
		
		If intLen > 8 Then
			Beep()
			ans = MsgBox("The SIZE field can not have more than 8 characters.", MsgBoxStyle.OKOnly, "WOS")
			txtMechSize.Text = ""
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - txtMechSize Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub txtMechTdh_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtMechTdh.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'
		'
		'
		
		Dim intLen As Short
		Dim ans As Short
		On Error GoTo errorhandler
		
		intLen = Len(txtMechTdh.Text)
		
		If intLen > 5 Then
			Beep()
			ans = MsgBox("The TDH field can not have more than 5 characters.", MsgBoxStyle.OKOnly, "WOS")
			txtMechTdh.Text = ""
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - txtMechTdh Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub txtMeterReading_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtMeterReading.Enter
		
		'
		'
		'
		
		On Error GoTo errorhandler
		
		If txtMeterReading.Text <> "" Then
			lngMeterReading = 0
			lngMeterReading = CInt(txtMeterReading.Text)
		End If
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - txtMeterReading GotFocus: Description - " & Err.Description)
	End Sub
	
	Private Sub txtMeterReading_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtMeterReading.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'
		'
		'
		Dim lngNewMeter As Integer
		On Error GoTo errorhandler
		
		ans = 0
		lngNewMeter = 0
		If IsNumeric(txtMeterReading.Text) = False And txtMeterReading.Text <> "" Then
			MsgBox("Incorrect Format. Please Re-enter.")
			txtMeterReading.Text = ""
			Cancel = True
		Else
			If lngMeterReading > 0 Then
				If txtMeterReading.Text = "" Then
					lngNewMeter = 0
				Else
					lngNewMeter = CInt(txtMeterReading.Text)
				End If
				If lngNewMeter < lngMeterReading Then
					ans = MsgBox("It is not recommended to have new meter reading to be smaller than the old one. ", MsgBoxStyle.OKOnly)
					'If ans = 6 Then
					'    If IsNull(lngNewMeter) Then
					'        txtMeterReading.Text = ""
					'    Else
					'        txtMeterReading.Text = lngNewMeter
					'    End If
					'Else
					'    If IsNull(lngMeterReading) Then
					'        txtMeterReading.Text = ""
					'    Else
					'        txtMeterReading.Text = lngMeterReading
					'    End If
					'End If
				End If
			End If
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - txtMeterReading Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub TxtMeterReadingDate_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles TxtMeterReadingDate.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'
		'
		'
		
		On Error GoTo errorhandler
		
		If IsDate(txtMeterReadingDate.CtlText) = False And txtMeterReadingDate.defaultText <> "" Then
			MsgBox("Incorrect Format. Please Re-enter.")
			txtMeterReadingDate.CtlText = ""
			Cancel = True
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Equipment - txtMeterReadingDate Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
End Class