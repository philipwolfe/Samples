'form for brush selection, 
Imports System.Drawing.Drawing2D
Imports System.Reflection
Public Class fbrush
	Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

	Public Sub New()
		MyBase.New()

		'This call is required by the Windows Form Designer.
		InitializeComponent()

		'Add any initialization after the InitializeComponent() call

	End Sub

	'Form overrides dispose to clean up the component list.
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
	Friend WithEvents tbctrl As System.Windows.Forms.TabControl
	Friend WithEvents tbpg02 As System.Windows.Forms.TabPage
	Friend WithEvents tbpg03 As System.Windows.Forms.TabPage
	Friend WithEvents tbpg01 As System.Windows.Forms.TabPage
	Friend WithEvents pctsample As System.Windows.Forms.PictureBox
	Friend WithEvents lbl02 As System.Windows.Forms.Label
	Friend WithEvents CtrlColorSelectSolid As PaintBucketAlgorithm.ctrlColorSelect
	Friend WithEvents CtrlColorSelectHFore As PaintBucketAlgorithm.ctrlColorSelect
	Friend WithEvents CtrlColorSelectHBack As PaintBucketAlgorithm.ctrlColorSelect
	Friend WithEvents cmbhatchstyle As System.Windows.Forms.ComboBox
	Friend WithEvents lbl01 As System.Windows.Forms.Label
	Friend WithEvents txttexture As System.Windows.Forms.TextBox
	Friend WithEvents btntexturebrowse As System.Windows.Forms.Button
	Friend WithEvents lbl04 As System.Windows.Forms.Label
	Friend WithEvents cmbtexturestyle As System.Windows.Forms.ComboBox
	Friend WithEvents lbl03 As System.Windows.Forms.Label
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.tbctrl = New System.Windows.Forms.TabControl
		Me.tbpg01 = New System.Windows.Forms.TabPage
		Me.CtrlColorSelectSolid = New PaintBucketAlgorithm.ctrlColorSelect
		Me.lbl02 = New System.Windows.Forms.Label
		Me.tbpg02 = New System.Windows.Forms.TabPage
		Me.btntexturebrowse = New System.Windows.Forms.Button
		Me.txttexture = New System.Windows.Forms.TextBox
		Me.lbl04 = New System.Windows.Forms.Label
		Me.cmbtexturestyle = New System.Windows.Forms.ComboBox
		Me.lbl03 = New System.Windows.Forms.Label
		Me.tbpg03 = New System.Windows.Forms.TabPage
		Me.lbl01 = New System.Windows.Forms.Label
		Me.cmbhatchstyle = New System.Windows.Forms.ComboBox
		Me.CtrlColorSelectHBack = New PaintBucketAlgorithm.ctrlColorSelect
		Me.CtrlColorSelectHFore = New PaintBucketAlgorithm.ctrlColorSelect
		Me.pctsample = New System.Windows.Forms.PictureBox
		Me.tbctrl.SuspendLayout()
		Me.tbpg01.SuspendLayout()
		Me.tbpg02.SuspendLayout()
		Me.tbpg03.SuspendLayout()
		Me.SuspendLayout()
		'
		'tbctrl
		'
		Me.tbctrl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
		Me.tbctrl.Controls.Add(Me.tbpg01)
		Me.tbctrl.Controls.Add(Me.tbpg02)
		Me.tbctrl.Controls.Add(Me.tbpg03)
		Me.tbctrl.Location = New System.Drawing.Point(124, 4)
		Me.tbctrl.Name = "tbctrl"
		Me.tbctrl.SelectedIndex = 0
		Me.tbctrl.Size = New System.Drawing.Size(256, 120)
		Me.tbctrl.TabIndex = 0
		'
		'tbpg01
		'
		Me.tbpg01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.tbpg01.Controls.Add(Me.CtrlColorSelectSolid)
		Me.tbpg01.Controls.Add(Me.lbl02)
		Me.tbpg01.Location = New System.Drawing.Point(4, 25)
		Me.tbpg01.Name = "tbpg01"
		Me.tbpg01.Size = New System.Drawing.Size(248, 91)
		Me.tbpg01.TabIndex = 0
		Me.tbpg01.Text = "Solid Brush"
		'
		'CtrlColorSelectSolid
		'
		Me.CtrlColorSelectSolid.ColorLabel = "Color:"
		Me.CtrlColorSelectSolid.Location = New System.Drawing.Point(4, 4)
		Me.CtrlColorSelectSolid.Name = "CtrlColorSelectSolid"
		Me.CtrlColorSelectSolid.SelectedColor = System.Drawing.Color.Red
		Me.CtrlColorSelectSolid.Size = New System.Drawing.Size(240, 28)
		Me.CtrlColorSelectSolid.TabIndex = 1
		'
		'lbl02
		'
		Me.lbl02.AutoSize = True
		Me.lbl02.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
		Me.lbl02.Location = New System.Drawing.Point(60, 36)
		Me.lbl02.Name = "lbl02"
		Me.lbl02.Size = New System.Drawing.Size(183, 14)
		Me.lbl02.TabIndex = 0
		Me.lbl02.Text = "Doubleclick on color for select a new color"
		'
		'tbpg02
		'
		Me.tbpg02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.tbpg02.Controls.Add(Me.btntexturebrowse)
		Me.tbpg02.Controls.Add(Me.txttexture)
		Me.tbpg02.Controls.Add(Me.lbl04)
		Me.tbpg02.Controls.Add(Me.cmbtexturestyle)
		Me.tbpg02.Controls.Add(Me.lbl03)
		Me.tbpg02.Location = New System.Drawing.Point(4, 25)
		Me.tbpg02.Name = "tbpg02"
		Me.tbpg02.Size = New System.Drawing.Size(248, 91)
		Me.tbpg02.TabIndex = 1
		Me.tbpg02.Text = "Texture Brush"
		'
		'btntexturebrowse
		'
		Me.btntexturebrowse.Location = New System.Drawing.Point(168, 8)
		Me.btntexturebrowse.Name = "btntexturebrowse"
		Me.btntexturebrowse.Size = New System.Drawing.Size(68, 23)
		Me.btntexturebrowse.TabIndex = 3
		Me.btntexturebrowse.Text = "Browse"
		'
		'txttexture
		'
		Me.txttexture.Location = New System.Drawing.Point(56, 8)
		Me.txttexture.Name = "txttexture"
		Me.txttexture.ReadOnly = True
		Me.txttexture.Size = New System.Drawing.Size(108, 20)
		Me.txttexture.TabIndex = 2
		Me.txttexture.Text = ""
		'
		'lbl04
		'
		Me.lbl04.AutoSize = True
		Me.lbl04.Location = New System.Drawing.Point(8, 40)
		Me.lbl04.Name = "lbl04"
		Me.lbl04.Size = New System.Drawing.Size(33, 16)
		Me.lbl04.TabIndex = 6
		Me.lbl04.Text = "Style:"
		'
		'cmbtexturestyle
		'
		Me.cmbtexturestyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbtexturestyle.Items.AddRange(New Object() {"Tile", "TileFlipX", "TileFlipXY", "TileFlipY", "Clamp"})
		Me.cmbtexturestyle.Location = New System.Drawing.Point(44, 36)
		Me.cmbtexturestyle.Name = "cmbtexturestyle"
		Me.cmbtexturestyle.Size = New System.Drawing.Size(188, 21)
		Me.cmbtexturestyle.TabIndex = 4
		'
		'lbl03
		'
		Me.lbl03.AutoSize = True
		Me.lbl03.Location = New System.Drawing.Point(8, 12)
		Me.lbl03.Name = "lbl03"
		Me.lbl03.Size = New System.Drawing.Size(46, 16)
		Me.lbl03.TabIndex = 6
		Me.lbl03.Text = "Texture:"
		'
		'tbpg03
		'
		Me.tbpg03.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.tbpg03.Controls.Add(Me.lbl01)
		Me.tbpg03.Controls.Add(Me.cmbhatchstyle)
		Me.tbpg03.Controls.Add(Me.CtrlColorSelectHBack)
		Me.tbpg03.Controls.Add(Me.CtrlColorSelectHFore)
		Me.tbpg03.Location = New System.Drawing.Point(4, 25)
		Me.tbpg03.Name = "tbpg03"
		Me.tbpg03.Size = New System.Drawing.Size(248, 91)
		Me.tbpg03.TabIndex = 2
		Me.tbpg03.Text = "Hatch Brush"
		'
		'lbl01
		'
		Me.lbl01.AutoSize = True
		Me.lbl01.Location = New System.Drawing.Point(8, 64)
		Me.lbl01.Name = "lbl01"
		Me.lbl01.Size = New System.Drawing.Size(33, 16)
		Me.lbl01.TabIndex = 4
		Me.lbl01.Text = "Style:"
		'
		'cmbhatchstyle
		'
		Me.cmbhatchstyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbhatchstyle.Location = New System.Drawing.Point(48, 60)
		Me.cmbhatchstyle.Name = "cmbhatchstyle"
		Me.cmbhatchstyle.Size = New System.Drawing.Size(188, 21)
		Me.cmbhatchstyle.TabIndex = 7
		'
		'CtrlColorSelectHBack
		'
		Me.CtrlColorSelectHBack.ColorLabel = "Backcolor:"
		Me.CtrlColorSelectHBack.Location = New System.Drawing.Point(4, 32)
		Me.CtrlColorSelectHBack.Name = "CtrlColorSelectHBack"
		Me.CtrlColorSelectHBack.SelectedColor = System.Drawing.Color.White
		Me.CtrlColorSelectHBack.Size = New System.Drawing.Size(236, 28)
		Me.CtrlColorSelectHBack.TabIndex = 6
		'
		'CtrlColorSelectHFore
		'
		Me.CtrlColorSelectHFore.ColorLabel = "Forecolor:"
		Me.CtrlColorSelectHFore.Location = New System.Drawing.Point(4, 4)
		Me.CtrlColorSelectHFore.Name = "CtrlColorSelectHFore"
		Me.CtrlColorSelectHFore.SelectedColor = System.Drawing.Color.Red
		Me.CtrlColorSelectHFore.Size = New System.Drawing.Size(236, 28)
		Me.CtrlColorSelectHFore.TabIndex = 5
		'
		'pctsample
		'
		Me.pctsample.BackColor = System.Drawing.Color.White
		Me.pctsample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.pctsample.Location = New System.Drawing.Point(8, 8)
		Me.pctsample.Name = "pctsample"
		Me.pctsample.Size = New System.Drawing.Size(108, 112)
		Me.pctsample.TabIndex = 1
		Me.pctsample.TabStop = False
		'
		'fbrush
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(382, 128)
		Me.ControlBox = False
		Me.Controls.Add(Me.pctsample)
		Me.Controls.Add(Me.tbctrl)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "fbrush"
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Brush Type"
		Me.tbctrl.ResumeLayout(False)
		Me.tbpg01.ResumeLayout(False)
		Me.tbpg02.ResumeLayout(False)
		Me.tbpg03.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub

#End Region

	Private HatchStyleValues As New ArrayList

	Public ReadOnly Property SelectedBrush()
		Get
			Dim _brsh As Brush
			Select Case tbctrl.SelectedTab.Name
				Case "tbpg01"
					_brsh = New SolidBrush(CtrlColorSelectSolid.SelectedColor)
				Case "tbpg02"
					_brsh = New TextureBrush(Image.FromFile(txttexture.Text), cmbtexturestyle.SelectedIndex)
				Case "tbpg03"
					_brsh = New HatchBrush(HatchStyleValues(cmbhatchstyle.SelectedIndex), CtrlColorSelectHFore.SelectedColor, CtrlColorSelectHBack.SelectedColor)
				Case Else
					_brsh = Nothing
			End Select
			Return _brsh
		End Get
	End Property

	Private Sub CtrlColorSelectSolid_ColorChanged() Handles CtrlColorSelectSolid.ColorChanged
		ReDrawSample()
	End Sub

	Sub ReDrawSample()
		Dim _brsh As Brush
		Select Case tbctrl.SelectedTab.Name
			Case "tbpg01"
				_brsh = New SolidBrush(CtrlColorSelectSolid.SelectedColor)
			Case "tbpg02"
				_brsh = New TextureBrush(Image.FromFile(txttexture.Text), cmbtexturestyle.SelectedIndex)
			Case "tbpg03"
				_brsh = New HatchBrush(HatchStyleValues(cmbhatchstyle.SelectedIndex), CtrlColorSelectHFore.SelectedColor, CtrlColorSelectHBack.SelectedColor)
			Case Else
				Exit Sub
		End Select

		Dim _bmp As New Bitmap(pctsample.Width, pctsample.Height)
		Dim _grp As Graphics = Graphics.FromImage(_bmp)

		_grp.FillRectangle(_brsh, 0, 0, pctsample.Width, pctsample.Height)
		pctsample.Image = _bmp.Clone

		_bmp.Dispose()
		_grp.Dispose()
		_brsh.Dispose()
	End Sub

	Private Sub fbrush_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
		LoadHatchStyles()
		cmbtexturestyle.SelectedIndex = 0
		txttexture.Text = Application.StartupPath & "\sampletexture.jpg"
		ReDrawSample()
	End Sub

	Private Sub cmbhatchstyle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbhatchstyle.SelectedIndexChanged
		ReDrawSample()
	End Sub

	Private Sub LoadHatchStyles()
		cmbhatchstyle.Items.Clear()

		Dim finfo As FieldInfo
		Dim finfos() As FieldInfo = GetType(HatchStyle).GetFields

		For Each finfo In finfos
			If finfo.IsLiteral Then
				cmbhatchstyle.Items.Add(finfo.Name)
				Dim hatch_style As HatchStyle = DirectCast(finfo.GetValue(Me), HatchStyle)
				HatchStyleValues.Add(hatch_style)
			End If
		Next
		cmbhatchstyle.SelectedIndex = 0
	End Sub

	Private Sub CtrlColorSelectHFore_ColorChanged() Handles CtrlColorSelectHFore.ColorChanged
		ReDrawSample()
	End Sub

	Private Sub CtrlColorSelectHBack_ColorChanged() Handles CtrlColorSelectHBack.ColorChanged
		ReDrawSample()
	End Sub

	Private Sub btntexturebrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btntexturebrowse.Click
		Dim opendlg As New OpenFileDialog
		Dim frm As fmain = Me.MdiParent
		opendlg.CheckFileExists = True
		opendlg.CheckPathExists = True
		opendlg.Filter = frm.GetFormats(True)
		opendlg.InitialDirectory = ""
		opendlg.Multiselect = False
		opendlg.ShowReadOnly = False
		opendlg.ValidateNames = True


		If opendlg.ShowDialog(Me) = DialogResult.OK Then
			txttexture.Text = opendlg.FileName
			ReDrawSample()
		End If
	End Sub

	Private Sub cmbtexturestyle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtexturestyle.SelectedIndexChanged
		ReDrawSample()
	End Sub

	Private Sub tbctrl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbctrl.SelectedIndexChanged
		ReDrawSample()
	End Sub
End Class
