Option Strict Off
Option Explicit On
Friend Class frmAddPlant
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
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdSave As System.Windows.Forms.Button
	Public WithEvents txtPlantName As System.Windows.Forms.TextBox
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAddPlant))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ToolTip1.Active = True
		Me.cmdCancel = New System.Windows.Forms.Button
		Me.cmdSave = New System.Windows.Forms.Button
		Me.txtPlantName = New System.Windows.Forms.TextBox
		Me.Label1 = New System.Windows.Forms.Label
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Plant Add"
		Me.ClientSize = New System.Drawing.Size(312, 157)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmAddPlant"
		Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCancel.Text = "&Cancel"
		Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdCancel.Size = New System.Drawing.Size(67, 33)
		Me.cmdCancel.Location = New System.Drawing.Point(176, 104)
		Me.cmdCancel.TabIndex = 2
		Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCancel.CausesValidation = True
		Me.cmdCancel.Enabled = True
		Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCancel.TabStop = True
		Me.cmdCancel.Name = "cmdCancel"
		Me.cmdSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdSave.Text = "&Save"
		Me.cmdSave.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdSave.Size = New System.Drawing.Size(67, 33)
		Me.cmdSave.Location = New System.Drawing.Point(64, 104)
		Me.cmdSave.TabIndex = 1
		Me.cmdSave.BackColor = System.Drawing.SystemColors.Control
		Me.cmdSave.CausesValidation = True
		Me.cmdSave.Enabled = True
		Me.cmdSave.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdSave.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdSave.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdSave.TabStop = True
		Me.cmdSave.Name = "cmdSave"
		Me.txtPlantName.AutoSize = False
		Me.txtPlantName.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtPlantName.Size = New System.Drawing.Size(177, 25)
		Me.txtPlantName.Location = New System.Drawing.Point(64, 56)
		Me.txtPlantName.TabIndex = 0
		Me.txtPlantName.AcceptsReturn = True
		Me.txtPlantName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtPlantName.BackColor = System.Drawing.SystemColors.Window
		Me.txtPlantName.CausesValidation = True
		Me.txtPlantName.Enabled = True
		Me.txtPlantName.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtPlantName.HideSelection = True
		Me.txtPlantName.ReadOnly = False
		Me.txtPlantName.Maxlength = 0
		Me.txtPlantName.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtPlantName.MultiLine = False
		Me.txtPlantName.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtPlantName.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtPlantName.TabStop = True
		Me.txtPlantName.Visible = True
		Me.txtPlantName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtPlantName.Name = "txtPlantName"
		Me.Label1.Text = "Please enter a new plant name."
		Me.Label1.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.Size = New System.Drawing.Size(257, 25)
		Me.Label1.Location = New System.Drawing.Point(32, 16)
		Me.Label1.TabIndex = 3
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
		Me.Controls.Add(cmdCancel)
		Me.Controls.Add(cmdSave)
		Me.Controls.Add(txtPlantName)
		Me.Controls.Add(Label1)
	End Sub
#End Region 
#Region "Upgrade Support "
	Private Shared m_vb6FormDefInstance As frmAddPlant
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmAddPlant
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmAddPlant()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
	
	
	'
	' This form is uded to add new plant
	' Plant can not be deleted, which is also true for
	' Equipment as well as Work Order(Task)
	'
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		
		'
		' If user selects not to add new plant to the list of plants.
		'
		
		On Error GoTo errorhandler
		
		Me.Hide()
		Exit Sub
		
errorhandler: 
		
		MsgBox("Error Number - " & Err.Number & ": WOS : Add Plant - Cancel: Description - " & Err.Description)
	End Sub
	
	Private Sub cmdSave_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSave.Click
		
		'
		' Used to save plant once a value is entered
		' It will be saved only after validating
		' Code for validation can be found in modPlant module
		'
		
		On Error GoTo errorhandler
		
		ValidatePlant()
		Exit Sub
errorhandler: 
		
		MsgBox("Error Number - " & Err.Number & ": WOS : Add Plant - Validate Plant: Description - " & Err.Description)
	End Sub
	
	Public Sub AddPlant()
		
		'
		'  Once the validation is done the data is saved and
		'  user is informed of the addition
		'
		
		Dim rsPlantAdd As ADODB.Recordset
		Dim ans As Short
		Dim strSQL As String
		Dim strCurType As String
		
		On Error GoTo errorhandler
		Me.Height = VB6.TwipsToPixelsY(3600)
		Me.Width = VB6.TwipsToPixelsX(4410)
		
		strSQL = "SELECT * from plant where plant_id = 0"
		strCurType = "Add"
		
		rsPlantAdd = RecordsetPlant(strSQL, strCurType)
		
		rsPlantAdd.AddNew()
		rsPlantAdd.Fields("plant_name").Value = Me.txtPlantName.Text
		rsPlantAdd.MoveNext()
		
		'UPGRADE_NOTE: Object rsPlantAdd may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1029"'
		rsPlantAdd = Nothing
		'Set cnWos = Nothing
		
		ans = MsgBox("New plant: " & txtPlantName.Text & " has been added.", MsgBoxStyle.OKOnly, "WOS")
		Me.Hide()
		frmPlant.DefInstance.RetrievePlant()
		frmPlant.DefInstance.cboPlant.Items.Add("0 - All Plants")
		Exit Sub
errorhandler: 
		
		MsgBox("Error Number - " & Err.Number & ": WOS : Add Plant - Add Plant: Description - " & Err.Description)
	End Sub
End Class