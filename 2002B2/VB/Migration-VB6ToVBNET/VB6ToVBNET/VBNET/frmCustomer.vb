Option Strict Off
Option Explicit On
Namespace LangDemo
	Public  Class frmCustomer
        Inherits System.Windows.Forms.Form
		Private Shared  m_vb6FormDefInstance As frmCustomer
		Public Shared  Property DefInstance() As frmCustomer
			Get
				If m_vb6FormDefInstance Is Nothing Then
					m_vb6FormDefInstance = New frmCustomer()
				End If
				DefInstance = m_vb6FormDefInstance
			End Get
			Set
				m_vb6FormDefInstance = Value
			End Set
		End Property
		' Required by the Win Form Designer
		Private  components As System.ComponentModel.Container
        Public ToolTip1 As System.Windows.Forms.ToolTip
        Private WithEvents Form As frmCustomer
        Public WithEvents Command1 As System.Windows.Forms.Button
        Public WithEvents Text1 As System.Windows.Forms.TextBox
		Public Sub New()
			MyBase.New()
			Me.Form = Me
			' This call is required by the Win Form Designer
			If m_vb6FormDefInstance Is Nothing Then
				m_vb6FormDefInstance = Me
			End If
			InitializeComponent()
		End Sub
		' Form overrides dispose to clean up the component list.
		Public Overrides Sub Dispose()
			MyBase.Dispose()
			components.Dispose()
		End Sub
		' The main entry point for the application
		Shared Sub Main()
            System.Windows.Forms.Application.Run(New frmCustomer())
		End Sub
		' NOTE: The following procedure is required by the Win Form Designer
		' It can be modified using the Win Form Designer.
		' Do not modify it using the code editor.

		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
            Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
            ToolTip1.Active = True
			' @design ToolTip1.SetLocation(New System.Drawing.Point(7,7))
			' @design Tag1.SetLocation(New System.Drawing.Point(90,7))
            Me.Command1 = New System.Windows.Forms.Button()
            Me.Text1 = New System.Windows.Forms.TextBox()
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
			Me.Visible = True
			Me.HelpButton = False
            Me.WindowState = System.Windows.Forms.FormWindowState.Normal
			Me.Text = "Form1"
			Me.Location = New System.Drawing.Point(60, 345)
			Me.Size = New System.Drawing.Size(317, 229)
            Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
			Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25, CType(0, System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 5)
            Command1.FlatStyle = System.Windows.Forms.FlatStyle.Standard
			Command1.BackColor = System.Drawing.SystemColors.Control
			Command1.CausesValidation = True
			Command1.Enabled = True
            Command1.Cursor = System.Windows.Forms.Cursors.Default
            Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
			Command1.TabStop = True
			Command1.Text = "Set Name"
			Command1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.5, CType(0, System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
			Command1.Size = New System.Drawing.Size(102, 43)
			Command1.Location = New System.Drawing.Point(188, 91)
			Command1.TabIndex = 1
            Text1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
			Text1.BackColor = System.Drawing.SystemColors.Window
			Text1.CausesValidation = True
			Text1.Enabled = True
			Text1.ForeColor = System.Drawing.SystemColors.WindowText
			Text1.HideSelection = True
			Text1.ReadOnly = False
			'UPGRADE_WARNING: It is possible programmatically to set the Text property to a length greater than MaxLength, but not in VB6.
			Text1.Maxlength = 0
            Text1.Cursor = System.Windows.Forms.Cursors.Default
			Text1.MultiLine = False
            Text1.PasswordChar = ChrW(0)
            Text1.RightToLeft = System.Windows.Forms.RightToLeft.No
            Text1.ScrollBars = System.Windows.Forms.ScrollBars.None
			Text1.TabStop = True
			Text1.Visible = True
			Text1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.5, CType(0, System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
			Text1.Size = New System.Drawing.Size(168, 37)
			Text1.Location = New System.Drawing.Point(8, 95)
			Text1.TabIndex = 0
			Text1.Text = "John Doe"
            Text1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
			Me.Controls.Add(Command1)
			Me.Controls.Add(Text1)
		End Sub
		'  
		'  
		
        Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.click
            Dim x As clsCustomer = New clsCustomer()
            x.CustomerName = Me.Text1.Text
            MsgBox(x.CustomerName)
        End Sub
    End Class
End NameSpace