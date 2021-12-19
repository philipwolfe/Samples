Option Strict Off
Option Explicit On
Friend Class frmMeterReading
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
	Public WithEvents dgridMeterReading As AxMSDataGridLib.AxDataGrid
	Public WithEvents lblPlantName As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMeterReading))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ToolTip1.Active = True
		Me.dgridMeterReading = New AxMSDataGridLib.AxDataGrid
		Me.lblPlantName = New System.Windows.Forms.Label
		CType(Me.dgridMeterReading, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Text = "Meter Reading"
		Me.ClientSize = New System.Drawing.Size(612, 400)
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
		Me.Name = "frmMeterReading"
		dgridMeterReading.OcxState = CType(resources.GetObject("dgridMeterReading.OcxState"), System.Windows.Forms.AxHost.State)
		Me.dgridMeterReading.Size = New System.Drawing.Size(545, 369)
		Me.dgridMeterReading.Location = New System.Drawing.Point(8, 16)
		Me.dgridMeterReading.TabIndex = 0
		Me.dgridMeterReading.Name = "dgridMeterReading"
		Me.lblPlantName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblPlantName.Size = New System.Drawing.Size(185, 17)
		Me.lblPlantName.Location = New System.Drawing.Point(8, 0)
		Me.lblPlantName.TabIndex = 1
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
		Me.Controls.Add(dgridMeterReading)
		Me.Controls.Add(lblPlantName)
		CType(Me.dgridMeterReading, System.ComponentModel.ISupportInitialize).EndInit()
	End Sub
#End Region 
#Region "Upgrade Support "
	Private Shared m_vb6FormDefInstance As frmMeterReading
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmMeterReading
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmMeterReading()
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
	Dim lngMeterReading As Integer
	Dim rsUpdateMeter As ADODB.Recordset
	
	Private Sub DGridMeterReading_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles DGridMeterReading.Enter
		
		'
		' When a cell gets focus it gets the value from it so that it can be used
		' for validation
		'
		
		On Error GoTo errorhandler
		
		lngMeterReading = 0
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
		If IsDbNull(rsUpdateMeter.Fields("last_meter_reading").Value) Then
			lngMeterReading = 0
		Else
			lngMeterReading = rsUpdateMeter.Fields("last_meter_reading").Value
		End If
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: MeterReading - dgridMeterReading GotFocus: Description - " & Err.Description)
	End Sub
	
	Private Sub DGridMeterReading_RowColChange(ByVal eventSender As System.Object, ByVal eventArgs As AxMSDataGridLib.DDataGridEvents_RowColChangeEvent) Handles DGridMeterReading.RowColChange
		
		'
		' If the col or row is changed thenit gets value for the new cell so
		' that it can be used for validation
		'
		
		On Error GoTo errorhandler
		
		
		lngMeterReading = 0
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
		If IsDbNull(rsUpdateMeter.Fields("last_meter_reading").Value) Then
			lngMeterReading = 0
		Else
			lngMeterReading = rsUpdateMeter.Fields("last_meter_reading").Value
		End If
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: MeterReading - dgridMeterReading RowColChange: Description - " & Err.Description)
	End Sub
	
	Private Sub DGridMeterReading_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles DGridMeterReading.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'
		' Validates the field before leaving
		'
		Dim lngNewMeter As Integer
		Dim strequip_key As String
		
		On Error GoTo errorhandler
		
		ans = 0
		lngNewMeter = 0
		
		strequip_key = rsUpdateMeter.Fields("equip_key").Value
		
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
		If IsDbNull(dgridMeterReading.Columns(2).Text) Or dgridMeterReading.Columns(2).Text = "" Then
			If lngMeterReading > 0 Then
				ans = MsgBox("It is not suggested to have new meter reading smaller than the old one. Do you want to continue?", MsgBoxStyle.YesNo)
				If ans = 6 Then
					
				Else
					dgridMeterReading.Columns(2).Value = lngMeterReading
				End If
			End If
		Else 'If dgridMeterReading.Columns(2).Value <> "" Then
			If IsNumeric(dgridMeterReading.Columns(2).Value) = False And dgridMeterReading.Columns(2).Value <> "" Then
				MsgBox("Incorrect Format. Please Re-enter.")
				Cancel = True
			ElseIf IsDate(dgridMeterReading.Columns(3).Value) = False And dgridMeterReading.Columns(2).Value <> "" Then 
				MsgBox("Incorrect Format. Please Re-enter.")
				Cancel = True
			Else
				lngNewMeter = CInt(dgridMeterReading.Columns(2).Value)
				
				If lngNewMeter < lngMeterReading Then
					ans = MsgBox("It is not suggested to have new meter reading smaller than the old one. Do you want to continue?", MsgBoxStyle.YesNo)
					If ans = 6 Then
						'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
						If IsDbNull(lngNewMeter) Then
							dgridMeterReading.Columns(2).Value = ""
						Else
							dgridMeterReading.Columns(2).Value = lngNewMeter
						End If
					Else
						'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1049"'
						If IsDbNull(lngMeterReading) Then
							dgridMeterReading.Columns(2).Value = ""
						Else
							dgridMeterReading.Columns(2).Value = lngMeterReading
						End If
					End If
				End If
			End If
		End If
		
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: MeterReading - dgridMeterReading Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Public Sub RefreshRec()
		
		'
		' Basically unloads and reloads the form
		'
		
		On Error GoTo errorhandler
		
		Me.Close()
		frmMeterReading.DefInstance.Show()
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: MeterReading - RefreshRec: Description - " & Err.Description)
	End Sub
	
	'UPGRADE_WARNING: Form event frmMeterReading.Activate has a new behavior. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup2065"'
	Private Sub frmMeterReading_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		
		'
		' Used to know which form is active to enbale or disable buttons which are on MDI form
		'
		
		On Error GoTo errorhandler
		
		MDIFormWOS.DefInstance.FindActive((False))
		
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: MeterReading - Form_Activate: Description - " & Err.Description)
	End Sub
	
	Private Sub frmMeterReading_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
		'
		' Sets size and position of the form and retrieves all the records
		'
		
		On Error GoTo errorhandler
		
		Me.Height = VB6.TwipsToPixelsY(6400)
		Me.Width = VB6.TwipsToPixelsX(9300)
		Me.Left = 0
		Me.Top = 0
		UpdateMeterReading()
		
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: MeterReading - Form_Load: Description - " & Err.Description)
	End Sub
	
	Private Sub UpdateMeterReading()
		
		'
		' Procedure used to retrieve records and set to the grid
		'
		
		Dim intGridWidth As Short
		
		On Error GoTo errorhandler
		
		
		Dim I As Short
		Dim count As Short
		Dim strSQL As String
		
		If intPlantPass = 0 Then
			strSQL = "SELECT equip_key, equip_desc, last_meter_reading, last_meter_reading_date from equipment where plant_fk <> 0"
		Else
			strSQL = "SELECT equip_key, equip_desc, last_meter_reading, last_meter_reading_date from equipment where plant_fk = " & intPlantPass
		End If
		
		rsUpdateMeter = RecordsetEquip(strSQL)
		
		dgridMeterReading.DataSource = rsUpdateMeter
		dgridMeterReading.Columns(0).Caption = "EQUIP KEY (LOCKED)"
		dgridMeterReading.Columns(1).Caption = "EQUIP DESC (LOCKED)"
		dgridMeterReading.Columns(2).Caption = "METER READING"
		dgridMeterReading.Columns(3).Caption = "DATE READ"
		intGridWidth = VB6.PixelsToTwipsX(dgridMeterReading.Width)
		
		dgridMeterReading.Columns(0).Width = VB6.TwipsToPixelsX((16 / 81) * intGridWidth)
		dgridMeterReading.Columns(1).Width = VB6.TwipsToPixelsX((35 / 81) * intGridWidth)
		dgridMeterReading.Columns(2).Width = VB6.TwipsToPixelsX((15 / 81) * intGridWidth)
		dgridMeterReading.Columns(3).Width = VB6.TwipsToPixelsX((11.5 / 81) * intGridWidth)
		
		dgridMeterReading.Columns(0).Locked = True
		dgridMeterReading.Columns(1).Locked = True
		
		Me.lblPlantName.Text = intPlantPass & " - " & strPlantPass
		
		'Set rsUpdateMeter = Nothing
		'Set cnWOS = Nothing
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: MeterReading - UpdateMeterReading: Description - " & Err.Description)
	End Sub
	
	Public Sub Cancel()
		
		'
		' Unloads and reloads the form
		'
		
		On Error GoTo errorhandler
		
		Me.Close()
		frmMeterReading.DefInstance.Show()
		
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: MeterReading - Cancel: Description - " & Err.Description)
	End Sub
	
	'UPGRADE_WARNING: Form event frmMeterReading.Unload has a new behavior. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup2065"'
	Private Sub frmMeterReading_Closed(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Closed
		
		'
		' Unloads the form
		' sets the recordset to nothing
		' and calls FindActive procedure from MDI form to disable all
		' the buttons except equipment, Work Order(Task) and History until one
		' form is active
		'
		
		On Error GoTo errorhandler
		
		'UPGRADE_NOTE: Object rsUpdateMeter may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1029"'
		rsUpdateMeter = Nothing
		MDIFormWOS.DefInstance.FindActive((True))
		
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: MeterReading - Form_Unload: Description - " & Err.Description)
	End Sub
End Class