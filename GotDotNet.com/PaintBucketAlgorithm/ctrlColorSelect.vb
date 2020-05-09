'Custom Control for brush select form,
Public Class ctrlColorSelect
	Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

	Public Sub New()
		MyBase.New()

		'This call is required by the Windows Form Designer.
		InitializeComponent()

		'Add any initialization after the InitializeComponent() call

	End Sub

	'UserControl overrides dispose to clean up the component list.
	Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing Then
			If Not (components Is Nothing) Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(disposing)
	End Sub

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	Friend WithEvents pctsample As System.Windows.Forms.PictureBox
	Friend WithEvents txtname As System.Windows.Forms.TextBox
	Friend WithEvents lbl As System.Windows.Forms.Label
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.pctsample = New System.Windows.Forms.PictureBox
		Me.txtname = New System.Windows.Forms.TextBox
		Me.lbl = New System.Windows.Forms.Label
		Me.SuspendLayout()
		'
		'pctsample
		'
		Me.pctsample.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.pctsample.BackColor = System.Drawing.Color.White
		Me.pctsample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.pctsample.Location = New System.Drawing.Point(192, 3)
		Me.pctsample.Name = "pctsample"
		Me.pctsample.Size = New System.Drawing.Size(20, 20)
		Me.pctsample.TabIndex = 5
		Me.pctsample.TabStop = False
		'
		'txtname
		'
		Me.txtname.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
		   Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.txtname.Location = New System.Drawing.Point(36, 3)
		Me.txtname.Name = "txtname"
		Me.txtname.ReadOnly = True
		Me.txtname.Size = New System.Drawing.Size(152, 20)
		Me.txtname.TabIndex = 4
		Me.txtname.Text = ""
		'
		'lbl
		'
		Me.lbl.AutoSize = True
		Me.lbl.Location = New System.Drawing.Point(3, 6)
		Me.lbl.Name = "lbl"
		Me.lbl.Size = New System.Drawing.Size(34, 16)
		Me.lbl.TabIndex = 3
		Me.lbl.Text = "Color:"
		'
		'ctrlColorSelect
		'
		Me.Controls.Add(Me.pctsample)
		Me.Controls.Add(Me.txtname)
		Me.Controls.Add(Me.lbl)
		Me.Name = "ctrlColorSelect"
		Me.Size = New System.Drawing.Size(216, 28)
		Me.ResumeLayout(False)

	End Sub

#End Region

	Public Property ColorLabel() As String
		Get
			Return lbl.Text
		End Get
		Set(ByVal Value As String)
			lbl.Text = Value
			lbl.Refresh()
			txtname.Left = lbl.Left + lbl.Width
			txtname.Width = Me.Width - lbl.Width - 30

			txtname.Refresh()
		End Set
	End Property

	Public Property SelectedColor() As Color
		Get
			Return pctsample.BackColor
		End Get
		Set(ByVal Value As Color)
			pctsample.BackColor = Value
			If Value.IsNamedColor Then txtname.Text = Value.Name Else txtname.Text = "#" & Strings.Right(Value.Name, 6).ToUpper
			RaiseEvent ColorChanged()
		End Set
	End Property

	Public Sub ShowDialog()
		Dim clrdlg As New ColorDialog
		clrdlg.AllowFullOpen = True
		clrdlg.AnyColor = True
		clrdlg.FullOpen = True
		clrdlg.Color = SelectedColor
		clrdlg.ShowDialog(Me)
		SelectedColor = clrdlg.Color
	End Sub

	Private Sub ctrlColorSelect_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
		Me.Height = 28
	End Sub

	Private Sub ctrlColorSelect_ControlAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.ControlEventArgs) Handles MyBase.ControlAdded
		SelectedColor = Color.Red
	End Sub

	Private Sub pctsample_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pctsample.DoubleClick
		ShowDialog()
	End Sub

	Event ColorChanged()
End Class
