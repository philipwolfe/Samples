Option Strict Off
Option Explicit On
Friend Class frmSearchTask
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
	Public WithEvents txtEquipID As System.Windows.Forms.TextBox
	Public WithEvents txtTaskID As System.Windows.Forms.TextBox
	Public WithEvents txtMiscComments As System.Windows.Forms.TextBox
	Public WithEvents cmdFind As System.Windows.Forms.Button
	Public WithEvents txtDueDate As System.Windows.Forms.TextBox
	Public WithEvents txtEquipKey As System.Windows.Forms.TextBox
	Public WithEvents optUnschedule As System.Windows.Forms.RadioButton
	Public WithEvents OptDueDate As System.Windows.Forms.RadioButton
	Public WithEvents OptDueMeter As System.Windows.Forms.RadioButton
	Public WithEvents OptAll As System.Windows.Forms.RadioButton
	Public WithEvents framTaskType As System.Windows.Forms.GroupBox
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSearchTask))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ToolTip1.Active = True
		Me.txtEquipID = New System.Windows.Forms.TextBox
		Me.txtTaskID = New System.Windows.Forms.TextBox
		Me.txtMiscComments = New System.Windows.Forms.TextBox
		Me.cmdFind = New System.Windows.Forms.Button
		Me.txtDueDate = New System.Windows.Forms.TextBox
		Me.txtEquipKey = New System.Windows.Forms.TextBox
		Me.framTaskType = New System.Windows.Forms.GroupBox
		Me.optUnschedule = New System.Windows.Forms.RadioButton
		Me.OptDueDate = New System.Windows.Forms.RadioButton
		Me.OptDueMeter = New System.Windows.Forms.RadioButton
		Me.OptAll = New System.Windows.Forms.RadioButton
		Me.Label5 = New System.Windows.Forms.Label
		Me.Label4 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.Text = "Search Work Order"
		Me.ClientSize = New System.Drawing.Size(356, 256)
		Me.Location = New System.Drawing.Point(4, 23)
		Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
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
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmSearchTask"
		Me.txtEquipID.AutoSize = False
		Me.txtEquipID.Size = New System.Drawing.Size(65, 19)
		Me.txtEquipID.Location = New System.Drawing.Point(232, 112)
		Me.txtEquipID.TabIndex = 6
		Me.txtEquipID.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtEquipID.AcceptsReturn = True
		Me.txtEquipID.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtEquipID.BackColor = System.Drawing.SystemColors.Window
		Me.txtEquipID.CausesValidation = True
		Me.txtEquipID.Enabled = True
		Me.txtEquipID.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtEquipID.HideSelection = True
		Me.txtEquipID.ReadOnly = False
		Me.txtEquipID.Maxlength = 0
		Me.txtEquipID.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtEquipID.MultiLine = False
		Me.txtEquipID.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtEquipID.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtEquipID.TabStop = True
		Me.txtEquipID.Visible = True
		Me.txtEquipID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtEquipID.Name = "txtEquipID"
		Me.txtTaskID.AutoSize = False
		Me.txtTaskID.Size = New System.Drawing.Size(65, 19)
		Me.txtTaskID.Location = New System.Drawing.Point(232, 136)
		Me.txtTaskID.TabIndex = 7
		Me.txtTaskID.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtTaskID.AcceptsReturn = True
		Me.txtTaskID.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtTaskID.BackColor = System.Drawing.SystemColors.Window
		Me.txtTaskID.CausesValidation = True
		Me.txtTaskID.Enabled = True
		Me.txtTaskID.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtTaskID.HideSelection = True
		Me.txtTaskID.ReadOnly = False
		Me.txtTaskID.Maxlength = 0
		Me.txtTaskID.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtTaskID.MultiLine = False
		Me.txtTaskID.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtTaskID.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtTaskID.TabStop = True
		Me.txtTaskID.Visible = True
		Me.txtTaskID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtTaskID.Name = "txtTaskID"
		Me.txtMiscComments.AutoSize = False
		Me.txtMiscComments.Size = New System.Drawing.Size(97, 19)
		Me.txtMiscComments.Location = New System.Drawing.Point(232, 184)
		Me.txtMiscComments.TabIndex = 9
		Me.txtMiscComments.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtMiscComments.AcceptsReturn = True
		Me.txtMiscComments.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtMiscComments.BackColor = System.Drawing.SystemColors.Window
		Me.txtMiscComments.CausesValidation = True
		Me.txtMiscComments.Enabled = True
		Me.txtMiscComments.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtMiscComments.HideSelection = True
		Me.txtMiscComments.ReadOnly = False
		Me.txtMiscComments.Maxlength = 0
		Me.txtMiscComments.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtMiscComments.MultiLine = False
		Me.txtMiscComments.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtMiscComments.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtMiscComments.TabStop = True
		Me.txtMiscComments.Visible = True
		Me.txtMiscComments.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtMiscComments.Name = "txtMiscComments"
		Me.cmdFind.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdFind.Text = "Find >>"
		Me.cmdFind.Size = New System.Drawing.Size(81, 33)
		Me.cmdFind.Location = New System.Drawing.Point(248, 216)
		Me.cmdFind.TabIndex = 10
		Me.cmdFind.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdFind.BackColor = System.Drawing.SystemColors.Control
		Me.cmdFind.CausesValidation = True
		Me.cmdFind.Enabled = True
		Me.cmdFind.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdFind.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdFind.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdFind.TabStop = True
		Me.cmdFind.Name = "cmdFind"
		Me.txtDueDate.AutoSize = False
		Me.txtDueDate.Size = New System.Drawing.Size(97, 19)
		Me.txtDueDate.Location = New System.Drawing.Point(232, 160)
		Me.txtDueDate.TabIndex = 8
		Me.txtDueDate.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtDueDate.AcceptsReturn = True
		Me.txtDueDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtDueDate.BackColor = System.Drawing.SystemColors.Window
		Me.txtDueDate.CausesValidation = True
		Me.txtDueDate.Enabled = True
		Me.txtDueDate.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtDueDate.HideSelection = True
		Me.txtDueDate.ReadOnly = False
		Me.txtDueDate.Maxlength = 0
		Me.txtDueDate.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtDueDate.MultiLine = False
		Me.txtDueDate.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtDueDate.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtDueDate.TabStop = True
		Me.txtDueDate.Visible = True
		Me.txtDueDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtDueDate.Name = "txtDueDate"
		Me.txtEquipKey.AutoSize = False
		Me.txtEquipKey.Size = New System.Drawing.Size(97, 19)
		Me.txtEquipKey.Location = New System.Drawing.Point(232, 88)
		Me.txtEquipKey.TabIndex = 5
		Me.txtEquipKey.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtEquipKey.AcceptsReturn = True
		Me.txtEquipKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtEquipKey.BackColor = System.Drawing.SystemColors.Window
		Me.txtEquipKey.CausesValidation = True
		Me.txtEquipKey.Enabled = True
		Me.txtEquipKey.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtEquipKey.HideSelection = True
		Me.txtEquipKey.ReadOnly = False
		Me.txtEquipKey.Maxlength = 0
		Me.txtEquipKey.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtEquipKey.MultiLine = False
		Me.txtEquipKey.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtEquipKey.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtEquipKey.TabStop = True
		Me.txtEquipKey.Visible = True
		Me.txtEquipKey.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtEquipKey.Name = "txtEquipKey"
		Me.framTaskType.Text = "Work Order Type"
		Me.framTaskType.Size = New System.Drawing.Size(241, 73)
		Me.framTaskType.Location = New System.Drawing.Point(88, 8)
		Me.framTaskType.TabIndex = 0
		Me.framTaskType.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.framTaskType.BackColor = System.Drawing.SystemColors.Control
		Me.framTaskType.Enabled = True
		Me.framTaskType.ForeColor = System.Drawing.SystemColors.ControlText
		Me.framTaskType.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.framTaskType.Visible = True
		Me.framTaskType.Name = "framTaskType"
		Me.optUnschedule.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optUnschedule.Text = "Unsheduled"
		Me.optUnschedule.Size = New System.Drawing.Size(81, 25)
		Me.optUnschedule.Location = New System.Drawing.Point(8, 40)
		Me.optUnschedule.TabIndex = 3
		Me.optUnschedule.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.optUnschedule.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optUnschedule.BackColor = System.Drawing.SystemColors.Control
		Me.optUnschedule.CausesValidation = True
		Me.optUnschedule.Enabled = True
		Me.optUnschedule.ForeColor = System.Drawing.SystemColors.ControlText
		Me.optUnschedule.Cursor = System.Windows.Forms.Cursors.Default
		Me.optUnschedule.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.optUnschedule.Appearance = System.Windows.Forms.Appearance.Normal
		Me.optUnschedule.TabStop = True
		Me.optUnschedule.Checked = False
		Me.optUnschedule.Visible = True
		Me.optUnschedule.Name = "optUnschedule"
		Me.OptDueDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.OptDueDate.Text = "Due by Date"
		Me.OptDueDate.Size = New System.Drawing.Size(81, 25)
		Me.OptDueDate.Location = New System.Drawing.Point(8, 16)
		Me.OptDueDate.TabIndex = 1
		Me.OptDueDate.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.OptDueDate.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.OptDueDate.BackColor = System.Drawing.SystemColors.Control
		Me.OptDueDate.CausesValidation = True
		Me.OptDueDate.Enabled = True
		Me.OptDueDate.ForeColor = System.Drawing.SystemColors.ControlText
		Me.OptDueDate.Cursor = System.Windows.Forms.Cursors.Default
		Me.OptDueDate.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.OptDueDate.Appearance = System.Windows.Forms.Appearance.Normal
		Me.OptDueDate.TabStop = True
		Me.OptDueDate.Checked = False
		Me.OptDueDate.Visible = True
		Me.OptDueDate.Name = "OptDueDate"
		Me.OptDueMeter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.OptDueMeter.Text = "Due by Meter"
		Me.OptDueMeter.Size = New System.Drawing.Size(97, 25)
		Me.OptDueMeter.Location = New System.Drawing.Point(136, 16)
		Me.OptDueMeter.TabIndex = 2
		Me.OptDueMeter.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.OptDueMeter.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.OptDueMeter.BackColor = System.Drawing.SystemColors.Control
		Me.OptDueMeter.CausesValidation = True
		Me.OptDueMeter.Enabled = True
		Me.OptDueMeter.ForeColor = System.Drawing.SystemColors.ControlText
		Me.OptDueMeter.Cursor = System.Windows.Forms.Cursors.Default
		Me.OptDueMeter.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.OptDueMeter.Appearance = System.Windows.Forms.Appearance.Normal
		Me.OptDueMeter.TabStop = True
		Me.OptDueMeter.Checked = False
		Me.OptDueMeter.Visible = True
		Me.OptDueMeter.Name = "OptDueMeter"
		Me.OptAll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.OptAll.Text = "All"
		Me.OptAll.Size = New System.Drawing.Size(81, 25)
		Me.OptAll.Location = New System.Drawing.Point(136, 40)
		Me.OptAll.TabIndex = 4
		Me.OptAll.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.OptAll.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.OptAll.BackColor = System.Drawing.SystemColors.Control
		Me.OptAll.CausesValidation = True
		Me.OptAll.Enabled = True
		Me.OptAll.ForeColor = System.Drawing.SystemColors.ControlText
		Me.OptAll.Cursor = System.Windows.Forms.Cursors.Default
		Me.OptAll.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.OptAll.Appearance = System.Windows.Forms.Appearance.Normal
		Me.OptAll.TabStop = True
		Me.OptAll.Checked = False
		Me.OptAll.Visible = True
		Me.OptAll.Name = "OptAll"
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label5.Text = "Work Order ID (Optional):"
		Me.Label5.Size = New System.Drawing.Size(121, 17)
		Me.Label5.Location = New System.Drawing.Point(104, 136)
		Me.Label5.TabIndex = 15
		Me.Label5.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label4.Text = "Equip ID (Optional):"
		Me.Label4.Size = New System.Drawing.Size(121, 17)
		Me.Label4.Location = New System.Drawing.Point(104, 112)
		Me.Label4.TabIndex = 14
		Me.Label4.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label3.Text = "Word from Work Order Comments (Optional):"
		Me.Label3.Size = New System.Drawing.Size(225, 17)
		Me.Label3.Location = New System.Drawing.Point(0, 184)
		Me.Label3.TabIndex = 13
		Me.Label3.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label2.Text = "Due Date (if ""Due by Date"" selected) "
		Me.Label2.Size = New System.Drawing.Size(193, 17)
		Me.Label2.Location = New System.Drawing.Point(32, 160)
		Me.Label2.TabIndex = 12
		Me.Label2.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label1.Text = "Equip Key (Optional):"
		Me.Label1.Size = New System.Drawing.Size(121, 17)
		Me.Label1.Location = New System.Drawing.Point(104, 88)
		Me.Label1.TabIndex = 11
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
		Me.Controls.Add(txtEquipID)
		Me.Controls.Add(txtTaskID)
		Me.Controls.Add(txtMiscComments)
		Me.Controls.Add(cmdFind)
		Me.Controls.Add(txtDueDate)
		Me.Controls.Add(txtEquipKey)
		Me.Controls.Add(framTaskType)
		Me.Controls.Add(Label5)
		Me.Controls.Add(Label4)
		Me.Controls.Add(Label3)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label1)
		Me.framTaskType.Controls.Add(optUnschedule)
		Me.framTaskType.Controls.Add(OptDueDate)
		Me.framTaskType.Controls.Add(OptDueMeter)
		Me.framTaskType.Controls.Add(OptAll)
	End Sub
#End Region 
#Region "Upgrade Support "
	Private Shared m_vb6FormDefInstance As frmSearchTask
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmSearchTask
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmSearchTask()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
	Private Sub cmdFind_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFind.Click
		
		'
		' Evaluates what has been selected or typed for search and
		' uses the values to find if there are records based on criteria.
		' FindRecords function from frmTask is used with all the criteria
		' and value of 1 for checking. If it finds records then it
		' calls same function and brings back to the Work Order(task) view with new records
		' otherwise tells user to change the search criteria
		'
		
		Dim strEquipID, strOpt, strDate As Object
		Dim strMiscComments As String
		Dim intResult As Short
		
		On Error GoTo errorhandler
		
		If OptDueDate.Checked = True And txtDueDate.Text = "" Then
			MsgBox("Due Date is required if the Option is selected.")
		ElseIf OptDueDate.Checked = False And txtDueDate.Text <> "" Then 
			MsgBox("Due date can not be entered for other options.")
			txtDueDate.Text = ""
		Else
			If OptDueDate.Checked = True Then
				'UPGRADE_WARNING: Couldn't resolve default property of object strOpt. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				strOpt = "DueDate"
			ElseIf OptDueMeter.Checked = True Then 
				'UPGRADE_WARNING: Couldn't resolve default property of object strOpt. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				strOpt = "DueMeter"
			ElseIf optUnschedule.Checked = True Then 
				'UPGRADE_WARNING: Couldn't resolve default property of object strOpt. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				strOpt = "Unscheduled"
			Else
				'UPGRADE_WARNING: Couldn't resolve default property of object strOpt. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				strOpt = "All"
			End If
			
			'UPGRADE_WARNING: Couldn't resolve default property of object strOpt. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
			intResult = frmTask.DefInstance.FindRecords(strOpt, txtEquipKey.Text, txtEquipID.Text, txtTaskID.Text, txtDueDate.Text, txtMiscComments.Text, 1)
			If intResult = 1 Then
				'UPGRADE_WARNING: Couldn't resolve default property of object strOpt. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
				intResult = frmTask.DefInstance.FindRecords(strOpt, txtEquipKey.Text, txtEquipID.Text, txtTaskID.Text, txtDueDate.Text, txtMiscComments.Text, 2)
				Me.Close()
			Else
				MsgBox("No records with search criteria.")
			End If
		End If
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: SearchTask - cmdFind_Click: Description - " & Err.Description)
	End Sub
	
	Private Sub frmSearchTask_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
		'
		' Starts with option of - All records with Days Cycle
		'
		
		OptDueDate.Checked = True
	End Sub
	
	Private Sub txtDueDate_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtDueDate.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'
		' If there is a value for date field and format is incorrect it
		' clears the field and requests for re-entry
		'
		
		On Error GoTo errorhandler
		
		If IsDate(txtDueDate.Text) = False And txtDueDate.Text <> "" Then
			MsgBox("Incorrect Format. Please Re-enter.")
			txtDueDate.Text = ""
		End If
		
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: SearchTask - txtDueDate_Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
End Class