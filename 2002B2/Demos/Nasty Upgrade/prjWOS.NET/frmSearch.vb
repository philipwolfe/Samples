Option Strict Off
Option Explicit On
Friend Class frmSearchWO
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
	Public WithEvents optAll As System.Windows.Forms.RadioButton
	Public WithEvents optUnschedule As System.Windows.Forms.RadioButton
	Public WithEvents OptDueMeter As System.Windows.Forms.RadioButton
	Public WithEvents OptDueDate As System.Windows.Forms.RadioButton
	Public WithEvents framWOTypes As System.Windows.Forms.GroupBox
	Public WithEvents txtInitial As System.Windows.Forms.TextBox
	Public WithEvents cmdFind As System.Windows.Forms.Button
	Public WithEvents txtEquipDesc As System.Windows.Forms.TextBox
	Public WithEvents txtTaskDesc As System.Windows.Forms.TextBox
	Public WithEvents txtTaskMiscComments As System.Windows.Forms.TextBox
	Public WithEvents txtComments As System.Windows.Forms.TextBox
	Public WithEvents txtEquipKey As System.Windows.Forms.TextBox
	Public WithEvents TxtDateCompleted1 As AxMSMask.AxMaskEdBox
	Public WithEvents TxtDateCompleted2 As AxMSMask.AxMaskEdBox
	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents lblInfo As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSearchWO))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ToolTip1.Active = True
		Me.framWOTypes = New System.Windows.Forms.GroupBox
		Me.optAll = New System.Windows.Forms.RadioButton
		Me.optUnschedule = New System.Windows.Forms.RadioButton
		Me.OptDueMeter = New System.Windows.Forms.RadioButton
		Me.OptDueDate = New System.Windows.Forms.RadioButton
		Me.txtInitial = New System.Windows.Forms.TextBox
		Me.cmdFind = New System.Windows.Forms.Button
		Me.txtEquipDesc = New System.Windows.Forms.TextBox
		Me.txtTaskDesc = New System.Windows.Forms.TextBox
		Me.txtTaskMiscComments = New System.Windows.Forms.TextBox
		Me.txtComments = New System.Windows.Forms.TextBox
		Me.txtEquipKey = New System.Windows.Forms.TextBox
		Me.TxtDateCompleted1 = New AxMSMask.AxMaskEdBox
		Me.TxtDateCompleted2 = New AxMSMask.AxMaskEdBox
		Me.Label8 = New System.Windows.Forms.Label
		Me.Label7 = New System.Windows.Forms.Label
		Me.Label6 = New System.Windows.Forms.Label
		Me.Label5 = New System.Windows.Forms.Label
		Me.Label4 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.lblInfo = New System.Windows.Forms.Label
		CType(Me.TxtDateCompleted1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.TxtDateCompleted2, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Search History"
		Me.ClientSize = New System.Drawing.Size(436, 336)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
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
		Me.Name = "frmSearchWO"
		Me.framWOTypes.Text = "Work Order Types"
		Me.framWOTypes.Size = New System.Drawing.Size(385, 65)
		Me.framWOTypes.Location = New System.Drawing.Point(24, 56)
		Me.framWOTypes.TabIndex = 18
		Me.framWOTypes.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.framWOTypes.BackColor = System.Drawing.SystemColors.Control
		Me.framWOTypes.Enabled = True
		Me.framWOTypes.ForeColor = System.Drawing.SystemColors.ControlText
		Me.framWOTypes.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.framWOTypes.Visible = True
		Me.framWOTypes.Name = "framWOTypes"
		Me.optAll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optAll.Text = "All"
		Me.optAll.Size = New System.Drawing.Size(65, 25)
		Me.optAll.Location = New System.Drawing.Point(304, 24)
		Me.optAll.TabIndex = 22
		Me.optAll.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.optAll.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optAll.BackColor = System.Drawing.SystemColors.Control
		Me.optAll.CausesValidation = True
		Me.optAll.Enabled = True
		Me.optAll.ForeColor = System.Drawing.SystemColors.ControlText
		Me.optAll.Cursor = System.Windows.Forms.Cursors.Default
		Me.optAll.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.optAll.Appearance = System.Windows.Forms.Appearance.Normal
		Me.optAll.TabStop = True
		Me.optAll.Checked = False
		Me.optAll.Visible = True
		Me.optAll.Name = "optAll"
		Me.optUnschedule.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optUnschedule.Text = "Unschedule"
		Me.optUnschedule.Size = New System.Drawing.Size(81, 25)
		Me.optUnschedule.Location = New System.Drawing.Point(208, 24)
		Me.optUnschedule.TabIndex = 21
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
		Me.OptDueMeter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.OptDueMeter.Text = "Due by Meter"
		Me.OptDueMeter.Size = New System.Drawing.Size(89, 25)
		Me.OptDueMeter.Location = New System.Drawing.Point(112, 24)
		Me.OptDueMeter.TabIndex = 20
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
		Me.OptDueDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.OptDueDate.Text = "Due by Date"
		Me.OptDueDate.Size = New System.Drawing.Size(81, 25)
		Me.OptDueDate.Location = New System.Drawing.Point(16, 24)
		Me.OptDueDate.TabIndex = 19
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
		Me.txtInitial.AutoSize = False
		Me.txtInitial.Size = New System.Drawing.Size(81, 19)
		Me.txtInitial.Location = New System.Drawing.Point(216, 248)
		Me.txtInitial.TabIndex = 6
		Me.txtInitial.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtInitial.AcceptsReturn = True
		Me.txtInitial.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtInitial.BackColor = System.Drawing.SystemColors.Window
		Me.txtInitial.CausesValidation = True
		Me.txtInitial.Enabled = True
		Me.txtInitial.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtInitial.HideSelection = True
		Me.txtInitial.ReadOnly = False
		Me.txtInitial.Maxlength = 0
		Me.txtInitial.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtInitial.MultiLine = False
		Me.txtInitial.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtInitial.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtInitial.TabStop = True
		Me.txtInitial.Visible = True
		Me.txtInitial.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtInitial.Name = "txtInitial"
		Me.cmdFind.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdFind.Text = "Find >>"
		Me.cmdFind.Size = New System.Drawing.Size(65, 33)
		Me.cmdFind.Location = New System.Drawing.Point(320, 296)
		Me.cmdFind.TabIndex = 9
		Me.cmdFind.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdFind.BackColor = System.Drawing.SystemColors.Control
		Me.cmdFind.CausesValidation = True
		Me.cmdFind.Enabled = True
		Me.cmdFind.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdFind.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdFind.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdFind.TabStop = True
		Me.cmdFind.Name = "cmdFind"
		Me.txtEquipDesc.AutoSize = False
		Me.txtEquipDesc.Size = New System.Drawing.Size(81, 19)
		Me.txtEquipDesc.Location = New System.Drawing.Point(216, 152)
		Me.txtEquipDesc.TabIndex = 1
		Me.txtEquipDesc.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtEquipDesc.AcceptsReturn = True
		Me.txtEquipDesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtEquipDesc.BackColor = System.Drawing.SystemColors.Window
		Me.txtEquipDesc.CausesValidation = True
		Me.txtEquipDesc.Enabled = True
		Me.txtEquipDesc.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtEquipDesc.HideSelection = True
		Me.txtEquipDesc.ReadOnly = False
		Me.txtEquipDesc.Maxlength = 0
		Me.txtEquipDesc.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtEquipDesc.MultiLine = False
		Me.txtEquipDesc.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtEquipDesc.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtEquipDesc.TabStop = True
		Me.txtEquipDesc.Visible = True
		Me.txtEquipDesc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtEquipDesc.Name = "txtEquipDesc"
		Me.txtTaskDesc.AutoSize = False
		Me.txtTaskDesc.Size = New System.Drawing.Size(81, 19)
		Me.txtTaskDesc.Location = New System.Drawing.Point(216, 176)
		Me.txtTaskDesc.TabIndex = 2
		Me.txtTaskDesc.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtTaskDesc.AcceptsReturn = True
		Me.txtTaskDesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtTaskDesc.BackColor = System.Drawing.SystemColors.Window
		Me.txtTaskDesc.CausesValidation = True
		Me.txtTaskDesc.Enabled = True
		Me.txtTaskDesc.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtTaskDesc.HideSelection = True
		Me.txtTaskDesc.ReadOnly = False
		Me.txtTaskDesc.Maxlength = 0
		Me.txtTaskDesc.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtTaskDesc.MultiLine = False
		Me.txtTaskDesc.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtTaskDesc.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtTaskDesc.TabStop = True
		Me.txtTaskDesc.Visible = True
		Me.txtTaskDesc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtTaskDesc.Name = "txtTaskDesc"
		Me.txtTaskMiscComments.AutoSize = False
		Me.txtTaskMiscComments.Size = New System.Drawing.Size(81, 19)
		Me.txtTaskMiscComments.Location = New System.Drawing.Point(216, 200)
		Me.txtTaskMiscComments.TabIndex = 4
		Me.txtTaskMiscComments.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtTaskMiscComments.AcceptsReturn = True
		Me.txtTaskMiscComments.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtTaskMiscComments.BackColor = System.Drawing.SystemColors.Window
		Me.txtTaskMiscComments.CausesValidation = True
		Me.txtTaskMiscComments.Enabled = True
		Me.txtTaskMiscComments.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtTaskMiscComments.HideSelection = True
		Me.txtTaskMiscComments.ReadOnly = False
		Me.txtTaskMiscComments.Maxlength = 0
		Me.txtTaskMiscComments.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtTaskMiscComments.MultiLine = False
		Me.txtTaskMiscComments.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtTaskMiscComments.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtTaskMiscComments.TabStop = True
		Me.txtTaskMiscComments.Visible = True
		Me.txtTaskMiscComments.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtTaskMiscComments.Name = "txtTaskMiscComments"
		Me.txtComments.AutoSize = False
		Me.txtComments.Size = New System.Drawing.Size(81, 19)
		Me.txtComments.Location = New System.Drawing.Point(216, 224)
		Me.txtComments.TabIndex = 5
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
		Me.txtComments.MultiLine = False
		Me.txtComments.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtComments.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtComments.TabStop = True
		Me.txtComments.Visible = True
		Me.txtComments.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtComments.Name = "txtComments"
		Me.txtEquipKey.AutoSize = False
		Me.txtEquipKey.Size = New System.Drawing.Size(81, 19)
		Me.txtEquipKey.Location = New System.Drawing.Point(216, 128)
		Me.txtEquipKey.Maxlength = 10
		Me.txtEquipKey.TabIndex = 0
		Me.txtEquipKey.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
		TxtDateCompleted1.OcxState = CType(resources.GetObject("TxtDateCompleted1.OcxState"), System.Windows.Forms.AxHost.State)
		Me.TxtDateCompleted1.Size = New System.Drawing.Size(81, 17)
		Me.TxtDateCompleted1.Location = New System.Drawing.Point(216, 272)
		Me.TxtDateCompleted1.TabIndex = 7
		Me.TxtDateCompleted1.Name = "TxtDateCompleted1"
		TxtDateCompleted2.OcxState = CType(resources.GetObject("TxtDateCompleted2.OcxState"), System.Windows.Forms.AxHost.State)
		Me.TxtDateCompleted2.Size = New System.Drawing.Size(81, 17)
		Me.TxtDateCompleted2.Location = New System.Drawing.Point(320, 272)
		Me.TxtDateCompleted2.TabIndex = 8
		Me.TxtDateCompleted2.Name = "TxtDateCompleted2"
		Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label8.Text = "Initials:"
		Me.Label8.Size = New System.Drawing.Size(33, 17)
		Me.Label8.Location = New System.Drawing.Point(176, 248)
		Me.Label8.TabIndex = 17
		Me.Label8.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
		Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label7.Text = "Equip Key needs to be exact:"
		Me.Label7.Size = New System.Drawing.Size(145, 17)
		Me.Label7.Location = New System.Drawing.Point(64, 128)
		Me.Label7.TabIndex = 16
		Me.Label7.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
		Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label6.Text = "Word(s) from Equip Desc:"
		Me.Label6.Size = New System.Drawing.Size(145, 17)
		Me.Label6.Location = New System.Drawing.Point(64, 152)
		Me.Label6.TabIndex = 15
		Me.Label6.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label5.Text = "Word(s) from Work Order Desc:"
		Me.Label5.Size = New System.Drawing.Size(169, 17)
		Me.Label5.Location = New System.Drawing.Point(40, 176)
		Me.Label5.TabIndex = 14
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
		Me.Label4.Text = "Word(s) from Work Order Comments:"
		Me.Label4.Size = New System.Drawing.Size(185, 17)
		Me.Label4.Location = New System.Drawing.Point(24, 200)
		Me.Label4.TabIndex = 13
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
		Me.Label3.Text = "Word(s) from History Comments:"
		Me.Label3.Size = New System.Drawing.Size(185, 17)
		Me.Label3.Location = New System.Drawing.Point(24, 224)
		Me.Label3.TabIndex = 12
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
		Me.Label2.Text = "Completed Dates between:"
		Me.Label2.Size = New System.Drawing.Size(145, 17)
		Me.Label2.Location = New System.Drawing.Point(64, 272)
		Me.Label2.TabIndex = 11
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
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.Label1.Text = "and"
		Me.Label1.Size = New System.Drawing.Size(25, 17)
		Me.Label1.Location = New System.Drawing.Point(296, 272)
		Me.Label1.TabIndex = 10
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
		Me.lblInfo.Text = "Please, make sure that if you enter info in more than one field it will try to find History records matching all the criteria. Only date ranges are the required fields. Also the strings you are entering has to match letter by letter (including spaces)."
		Me.lblInfo.Size = New System.Drawing.Size(377, 41)
		Me.lblInfo.Location = New System.Drawing.Point(16, 8)
		Me.lblInfo.TabIndex = 3
		Me.lblInfo.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblInfo.BackColor = System.Drawing.SystemColors.Control
		Me.lblInfo.Enabled = True
		Me.lblInfo.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblInfo.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblInfo.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblInfo.UseMnemonic = True
		Me.lblInfo.Visible = True
		Me.lblInfo.AutoSize = False
		Me.lblInfo.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblInfo.Name = "lblInfo"
		Me.Controls.Add(framWOTypes)
		Me.Controls.Add(txtInitial)
		Me.Controls.Add(cmdFind)
		Me.Controls.Add(txtEquipDesc)
		Me.Controls.Add(txtTaskDesc)
		Me.Controls.Add(txtTaskMiscComments)
		Me.Controls.Add(txtComments)
		Me.Controls.Add(txtEquipKey)
		Me.Controls.Add(TxtDateCompleted1)
		Me.Controls.Add(TxtDateCompleted2)
		Me.Controls.Add(Label8)
		Me.Controls.Add(Label7)
		Me.Controls.Add(Label6)
		Me.Controls.Add(Label5)
		Me.Controls.Add(Label4)
		Me.Controls.Add(Label3)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label1)
		Me.Controls.Add(lblInfo)
		Me.framWOTypes.Controls.Add(optAll)
		Me.framWOTypes.Controls.Add(optUnschedule)
		Me.framWOTypes.Controls.Add(OptDueMeter)
		Me.framWOTypes.Controls.Add(OptDueDate)
		CType(Me.TxtDateCompleted2, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.TxtDateCompleted1, System.ComponentModel.ISupportInitialize).EndInit()
	End Sub
#End Region 
#Region "Upgrade Support "
	Private Shared m_vb6FormDefInstance As frmSearchWO
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmSearchWO
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmSearchWO()
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
		' FindRecords function from frmWorkOrder is used with all the criteria
		' and value of 1 for checking. If it finds records then it
		' calls same function and brings back to the History view with new records
		' otherwise tells user to change the search criteria
		'
		
		
		Dim intResult As Short
		Dim strOpt As String
		
		On Error GoTo errorhandler
		
		
		If OptDueDate.Checked = True Then
			strOpt = "DueDate"
		ElseIf OptDueMeter.Checked = True Then 
			strOpt = "DueMeter"
		ElseIf optUnschedule.Checked = True Then 
			strOpt = "Unschedule"
		Else
			strOpt = "All"
		End If
		intResult = frmWorkOrder.DefInstance.FindRecords(strOpt, txtEquipKey.Text, txtEquipDesc.Text, txtTaskDesc.Text, txtTaskMiscComments.Text, txtComments.Text, txtInitial.Text, TxtDateCompleted1.CtlText, TxtDateCompleted2.CtlText, 1)
		If intResult = 1 Then
			intResult = frmWorkOrder.DefInstance.FindRecords(strOpt, txtEquipKey.Text, txtEquipDesc.Text, txtTaskDesc.Text, txtTaskMiscComments.Text, txtComments.Text, txtInitial.Text, TxtDateCompleted1.CtlText, TxtDateCompleted2.CtlText, 2)
			frmWorkOrder.DefInstance.Populate()
			Me.Close()
		Else
			MsgBox("Records not found for the entered search criteria.")
		End If
		Exit Sub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: SearchWO - cmdFind_Click: Description - " & Err.Description)
	End Sub
	
	Private Sub frmSearchWO_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
		'
		' Starts with - All records with Days Cycle
		'
		
		OptDueDate.Checked = True
	End Sub
	
	Private Sub TxtDateCompleted1_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles TxtDateCompleted1.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'
		' If there is a value for date field and format is incorrect it
		' clears the field and requests for re-entry
		'
		
		On Error GoTo errorhandler
		
		If TxtDateCompleted1.CtlText <> "" Then
			If IsDate(TxtDateCompleted1.CtlText) = False Then
				MsgBox("Incorrect Format. Please Re-enter.")
				Cancel = True
			End If
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: SearchWO - txtDateCompleted1_Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub TxtDateCompleted2_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles TxtDateCompleted2.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'
		' If there is a value for date field and format is incorrect it
		' clears the field and requests for re-entry
		'
		
		On Error GoTo errorhandler
		
		If TxtDateCompleted2.CtlText <> "" Then
			If IsDate(TxtDateCompleted2.CtlText) = False Then
				MsgBox("Incorrect Format. Please Re-enter.")
				Cancel = True
			End If
		End If
		GoTo EventExitSub
errorhandler: 
		MsgBox("Error Number - " & Err.Number & ": WOS: SearchWO - txtDateCompleted2_Validate: Description - " & Err.Description)
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
End Class