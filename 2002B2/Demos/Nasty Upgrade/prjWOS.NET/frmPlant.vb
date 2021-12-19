Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmPlant
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
	Public WithEvents cmdCreate As System.Windows.Forms.Button
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdOK As System.Windows.Forms.Button
	Public WithEvents cboPlant As System.Windows.Forms.ComboBox
	Public WithEvents lblRequest As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmPlant))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ToolTip1.Active = True
		Me.cmdCreate = New System.Windows.Forms.Button
		Me.cmdCancel = New System.Windows.Forms.Button
		Me.cmdOK = New System.Windows.Forms.Button
		Me.cboPlant = New System.Windows.Forms.ComboBox
		Me.lblRequest = New System.Windows.Forms.Label
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "WOS"
		Me.ClientSize = New System.Drawing.Size(286, 213)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
		Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmPlant"
		Me.cmdCreate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCreate.Text = "C&reate"
		Me.cmdCreate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdCreate.Size = New System.Drawing.Size(73, 33)
		Me.cmdCreate.Location = New System.Drawing.Point(16, 152)
		Me.cmdCreate.TabIndex = 4
		Me.cmdCreate.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCreate.CausesValidation = True
		Me.cmdCreate.Enabled = True
		Me.cmdCreate.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCreate.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCreate.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCreate.TabStop = True
		Me.cmdCreate.Name = "cmdCreate"
		Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCancel.Text = "&Cancel"
		Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdCancel.Size = New System.Drawing.Size(73, 33)
		Me.cmdCancel.Location = New System.Drawing.Point(192, 152)
		Me.cmdCancel.TabIndex = 3
		Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCancel.CausesValidation = True
		Me.cmdCancel.Enabled = True
		Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCancel.TabStop = True
		Me.cmdCancel.Name = "cmdCancel"
		Me.cmdOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdOK.Text = "&OK"
		Me.cmdOK.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdOK.Size = New System.Drawing.Size(73, 33)
		Me.cmdOK.Location = New System.Drawing.Point(104, 152)
		Me.cmdOK.TabIndex = 2
		Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
		Me.cmdOK.CausesValidation = True
		Me.cmdOK.Enabled = True
		Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdOK.TabStop = True
		Me.cmdOK.Name = "cmdOK"
		Me.cboPlant.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cboPlant.Size = New System.Drawing.Size(129, 21)
		Me.cboPlant.Location = New System.Drawing.Point(72, 104)
		Me.cboPlant.TabIndex = 0
		Me.cboPlant.BackColor = System.Drawing.SystemColors.Window
		Me.cboPlant.CausesValidation = True
		Me.cboPlant.Enabled = True
		Me.cboPlant.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cboPlant.IntegralHeight = True
		Me.cboPlant.Cursor = System.Windows.Forms.Cursors.Default
		Me.cboPlant.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cboPlant.Sorted = False
		Me.cboPlant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cboPlant.TabStop = True
		Me.cboPlant.Visible = True
		Me.cboPlant.Name = "cboPlant"
		Me.lblRequest.Text = "Please Select a plant from the following list and click OK."
		Me.lblRequest.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblRequest.Size = New System.Drawing.Size(241, 49)
		Me.lblRequest.Location = New System.Drawing.Point(24, 32)
		Me.lblRequest.TabIndex = 1
		Me.lblRequest.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblRequest.BackColor = System.Drawing.SystemColors.Control
		Me.lblRequest.Enabled = True
		Me.lblRequest.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblRequest.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblRequest.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblRequest.UseMnemonic = True
		Me.lblRequest.Visible = True
		Me.lblRequest.AutoSize = False
		Me.lblRequest.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblRequest.Name = "lblRequest"
		Me.Controls.Add(cmdCreate)
		Me.Controls.Add(cmdCancel)
		Me.Controls.Add(cmdOK)
		Me.Controls.Add(cboPlant)
		Me.Controls.Add(lblRequest)
	End Sub
#End Region 
#Region "Upgrade Support "
	Private Shared m_vb6FormDefInstance As frmPlant
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmPlant
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmPlant()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
	
	Private Sub cboPlant_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles cboPlant.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
		'
		' Not allowed to type in have to pick from the list
		'
		
		Dim ans As Short
		
		On Error GoTo errorhandler
		ans = 0
		ans = MsgBox("Can not edit. Have to select from the list provided.")
		cboPlant.Text = ""
		
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Plant - cboPlant_KeyDown: Description - " & Err.Description)
	End Sub
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		
		'
		' Exits the application
		'
		
		End
	End Sub
	
	Private Sub cmdCreate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCreate.Click
		
		'
		' Opens Modal form to add plant
		'
		
		On Error GoTo errorhandler
		
		VB6.ShowForm(frmAddPlant.DefInstance, (1))
		
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Plant - cmdCreate_Click: Description - " & Err.Description)
		
	End Sub
	
	Public Function CheckAll(ByRef strFrom As String) As Short
		
		'
		' This is a very important function
		' This is used to check if there are any records starting from equipment
		' to Work Order to History for selected plant. Based on all the information
		' If there are no equipment records for the selected plant then it will
		' open Equipment form to add new records. If "all" plant option has been
		' selected then it will warn that equipment can not be added until a plant
		' has been selected.
		' If there are no Work Order records but there are equipment records then it will
		' open Work Order form in add mode.
		' If there are Work Orders as well as equipment records but no History records
		' then it will open History form in add mode.
		' If there are all the records for all three types then it will open
		' History in update mode or we can call it view mode if user does not
		' change any record.
		'
		' Note: This function can be written with select case rather than if else
		' but since this is an important function and is working this way
		' it recommended to keep it this way unless it becomes hard to maintain
		'
		
		' returns 1 if going in
		' returns 2 if called from inside
		' argument - "outside" or "equip" or "task" or "wo"
		Dim intAns As Short
		
		On Error GoTo errorhandler
		
		If frmWorkOrder.DefInstance.CheckRecordset = 2 Then
			' no history records
			If frmEquipment.DefInstance.CheckRecordset = 2 Then
				' no equipment records
				If intPlantPass <> 0 Then
					' if a plant has been selected
					' open the equipment in add mode
					
					MDIFormWOS.DefInstance.Show()
					frmEquipment.DefInstance.Show()
					intTypeEquip = 1
					frmEquipment.DefInstance.Add_Renamed()
					frmEquipment.DefInstance.Activate()
					frmEquipment.DefInstance.txtEquipKey.Focus()
					MsgBox("Please add equipment for the plant you have selected.")
					CheckAll = 1
				Else
					' if "All Plants" has been selected
					' force user to select a plant for which to add equipment
					MsgBox("Please select a plant to start entering equipment and other information.")
					If strFrom <> "outside" Then
						MDIFormWOS.DefInstance.Close()
						Exit Function
					End If
				End If
			Else
				' if there are equipment records atleast we can open MDI form
				MDIFormWOS.DefInstance.Show()
				If frmTask.DefInstance.CheckRecordset = 2 Then
					' if there are no Work Order(Task) records
					If strFrom <> "outside" Then
						' if it is coming from inside
						If strFrom = "equip" Then
							' if equipment was clicked
							'**********
							frmEquipment.DefInstance.Close()
							frmEquipment.DefInstance.Show()
							frmEquipment.DefInstance.Activate()
							frmEquipment.DefInstance.txtEquipKey.Focus()
							CheckAll = 1
						Else
							' if Work Order(Task) button was clicked and there are no records
							' for Work Order open Work Order form in add mode
							'**********
							frmTask.DefInstance.Close()
							frmTask.DefInstance.Show()
							intTypeTask = 1
							frmTask.DefInstance.Add_Renamed()
							frmTask.DefInstance.Activate()
							frmTask.DefInstance.cboEquipID.Focus()
							CheckAll = 1
						End If
					Else
						' if it was from outside
						' obviously there are no records so ask user if
						' he/she wants to start adding records
						intAns = MsgBox("Do you want me to open Work Order window to add new Work Orders?", MsgBoxStyle.YesNo)
						If intAns = 6 Then
							' open the Work Order(task) in add mode
							frmTask.DefInstance.Show()
							intTypeTask = 1
							frmTask.DefInstance.Add_Renamed()
							frmTask.DefInstance.Activate()
							frmTask.DefInstance.cboEquipID.Focus()
							MsgBox("Please add Work Order for the plant you have selected.")
							CheckAll = 1
						Else
							' If they are not ready to add open equipment
							' window in update/view mode
							'*************
							frmEquipment.DefInstance.Close()
							frmEquipment.DefInstance.Show()
							frmEquipment.DefInstance.Activate()
							frmEquipment.DefInstance.txtEquipKey.Focus()
							CheckAll = 1
						End If
					End If
				Else
					' if there are Work Order(Task) records for the plant selected
					If strFrom <> "outside" Then
						' if it is being called from inside
						Select Case strFrom
							Case "equip"
								' if equipment button was clicked
								'**********
								frmEquipment.DefInstance.Close()
								frmEquipment.DefInstance.Show()
								CheckAll = 1
								frmEquipment.DefInstance.Activate()
								frmEquipment.DefInstance.txtEquipKey.Focus()
							Case "task"
								' if Work Order(task) button was clicked
								'***********
								frmTask.DefInstance.Close()
								frmTask.DefInstance.Show()
								frmTask.DefInstance.Activate()
								frmTask.DefInstance.cboEquipID.Focus()
								CheckAll = 1
							Case "wo"
								' if History button was clicked
								' We already know from the first branch of the
								' if statement that there are no History records
								' so open History form in add mode
								'***************
								frmWorkOrder.DefInstance.Close()
								frmWorkOrder.DefInstance.Show()
								intTypeWO = 1
								frmWorkOrder.DefInstance.Add_Renamed()
								frmWorkOrder.DefInstance.Activate() ' Added 4-10
								frmWorkOrder.DefInstance.cboEquipID.Focus() 'Added 4-10
								MDIFormWOS.DefInstance.AddMode()
								CheckAll = 1
						End Select
					Else
						' if this was called from outside
						' We know there are no History records so ask user
						' if he/she wants to start adding
						
						intAns = MsgBox("Do you want me to open History Screen to complete Work Orders?", MsgBoxStyle.YesNo)
						If intAns = 6 Then
							' open the History in add mode
							frmWorkOrder.DefInstance.Show()
							intTypeWO = 1
							frmWorkOrder.DefInstance.Add_Renamed()
							frmWorkOrder.DefInstance.Activate() 'Added 4-10
							frmWorkOrder.DefInstance.cboEquipID.Focus() ' Added 4-10
							MDIFormWOS.DefInstance.AddMode()
							CheckAll = 1
						Else
							' Show the Work Order(task) form in update/view mode
							'*************
							frmTask.DefInstance.Close()
							frmTask.DefInstance.Show()
							frmTask.DefInstance.Activate()
							frmTask.DefInstance.cboEquipID.Focus()
							CheckAll = 1
						End If
					End If
				End If
			End If
		Else
			' if there were History records
			MDIFormWOS.DefInstance.Show()
			Select Case strFrom
				Case "outside"
					' if called from outside open History form in update/view mode
					frmWorkOrder.DefInstance.Show()
					frmWorkOrder.DefInstance.Activate()
					frmWorkOrder.DefInstance.cboEquipID.Focus()
					CheckAll = 1
				Case "equip"
					' if equipment was clicked from inside then
					' open equipment form in update/view mode
					'***********
					frmEquipment.DefInstance.Close()
					frmEquipment.DefInstance.Show()
					frmEquipment.DefInstance.Activate()
					frmEquipment.DefInstance.txtEquipKey.Focus()
					CheckAll = 1
				Case "task"
					' if Work Order(task) was clicked from inside then
					' open Work Order(task) form in update/view mode
					'*************
					frmTask.DefInstance.Close()
					frmTask.DefInstance.Show()
					frmTask.DefInstance.Activate()
					frmTask.DefInstance.cboEquipID.Focus()
					CheckAll = 1
				Case "wo"
					' if History was clicked from inside then
					' open History form in update/view mode
					'**************
					frmWorkOrder.DefInstance.Close()
					frmWorkOrder.DefInstance.Show()
					frmWorkOrder.DefInstance.Activate()
					frmWorkOrder.DefInstance.cboEquipID.Focus()
					CheckAll = 1
			End Select
		End If
		
		Exit Function
		
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Plant - CheckAll: Description - " & Err.Description)
		
	End Function
	
	Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
		
		'
		' Gets the values selected from the combo box and enters the application
		' with the value
		'
		
		Dim ans As Short
		Dim intPos As Short
		Dim strNum As String
		Dim intLen As Short
		
		On Error GoTo errorhandler
		
		If cboPlant.Text = "" Then
			ans = MsgBox("Please select a plant from the dropdown or create a new plant.", MsgBoxStyle.OKOnly, "WOS")
		Else
			strPlantPass = cboPlant.Text
			strPlantPass = Trim(strPlantPass)
			intLen = Len(strPlantPass)
			intPos = InStr(strPlantPass, " - ")
			strNum = VB.Left(strPlantPass, intPos - 1)
			' Stored in Global variables
			intPlantPass = CShort(strNum)
			strPlantPass = VB.Right(strPlantPass, intLen - 4)
			If CheckAll("outside") = 1 Then
				Me.Close()
			End If
		End If
		
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WO: Plant - cmdOK_Click: Description - " & Err.Description)
		
	End Sub
	
	Private Sub frmPlant_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
		'
		' There is at least "All Plants" Option to start with
		' which means nothing until a plant is added to the database
		'
		
		On Error GoTo errorhandler
		
		Me.Height = VB6.TwipsToPixelsY(3600)
		Me.Width = VB6.TwipsToPixelsX(4410)
		RetrievePlant()
		cboPlant.Items.Add("0 - All Plants")
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Plant - Form_Load: Description - " & Err.Description)
		
	End Sub
	
	Public Sub RetrievePlant()
		
		'
		' Retrieves all the plants from the database and adds them to the combo
		' item list
		'
		
		Dim rsPlantRetrieve As ADODB.Recordset
		Dim I As Short
		Dim count As Short
		Dim strSQL As String
		Dim strCurType As String
		
		On Error GoTo errorhandler
		
		strSQL = "SELECT * from plant where plant_id <> 0 order by plant_name asc"
		strCurType = "Retrieve"
		
		rsPlantRetrieve = RecordsetPlant(strSQL, strCurType)
		
		cboPlant.Items.Clear()
		
		If rsPlantRetrieve.EOF = True Or rsPlantRetrieve.BOF = True Then
			MsgBox("There are no plants in the database. Please enter a new plant name.")
			VB6.ShowForm(frmAddPlant.DefInstance, (1))
		Else
			rsPlantRetrieve.MoveLast()
			count = rsPlantRetrieve.RecordCount
			rsPlantRetrieve.MoveFirst()
			
			For I = 1 To count
				cboPlant.Items.Add(rsPlantRetrieve.Fields("plant_id").Value & " - " & rsPlantRetrieve.Fields("plant_name").Value)
				rsPlantRetrieve.MoveNext()
			Next 
		End If
		'UPGRADE_NOTE: Object rsPlantRetrieve may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1029"'
		rsPlantRetrieve = Nothing
		'Set cnWos = Nothing
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: Plant - RetrievePlant: Description - " & Err.Description)
	End Sub
End Class