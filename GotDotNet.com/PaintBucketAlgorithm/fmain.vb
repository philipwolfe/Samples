'Main MDIContainer form of the project
Imports System.Drawing.Imaging
Public Class fmain
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
	Friend WithEvents mnufile As System.Windows.Forms.MenuItem
	Friend WithEvents mnufile_open As System.Windows.Forms.MenuItem
	Friend WithEvents mnufile_save As System.Windows.Forms.MenuItem
	Friend WithEvents mnufile_saveas As System.Windows.Forms.MenuItem
	Friend WithEvents mnufile_close As System.Windows.Forms.MenuItem
	Friend WithEvents mnufile_sep As System.Windows.Forms.MenuItem
	Friend WithEvents mnufile_exit As System.Windows.Forms.MenuItem
	Friend WithEvents mnuvote As System.Windows.Forms.MenuItem
	Friend WithEvents mnuhelp As System.Windows.Forms.MenuItem
	Friend WithEvents mnuhelp_about As System.Windows.Forms.MenuItem
	Friend WithEvents mnu As System.Windows.Forms.MainMenu
	Friend WithEvents stbar As System.Windows.Forms.StatusBar
	Friend WithEvents stbarp01 As System.Windows.Forms.StatusBarPanel
	Friend WithEvents stbarp02 As System.Windows.Forms.StatusBarPanel
	Friend WithEvents stbarp03 As System.Windows.Forms.StatusBarPanel
	Friend WithEvents stbarp00 As System.Windows.Forms.StatusBarPanel
	Friend WithEvents mnuedit As System.Windows.Forms.MenuItem
	Friend WithEvents mnuedit_undo As System.Windows.Forms.MenuItem
	Friend WithEvents mnuedit_redo As System.Windows.Forms.MenuItem
	Friend WithEvents mnuhelp_readme As System.Windows.Forms.MenuItem
	Friend WithEvents mnuhelp_sep As System.Windows.Forms.MenuItem
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.mnu = New System.Windows.Forms.MainMenu
		Me.mnufile = New System.Windows.Forms.MenuItem
		Me.mnufile_open = New System.Windows.Forms.MenuItem
		Me.mnufile_save = New System.Windows.Forms.MenuItem
		Me.mnufile_saveas = New System.Windows.Forms.MenuItem
		Me.mnufile_close = New System.Windows.Forms.MenuItem
		Me.mnufile_sep = New System.Windows.Forms.MenuItem
		Me.mnufile_exit = New System.Windows.Forms.MenuItem
		Me.mnuedit = New System.Windows.Forms.MenuItem
		Me.mnuedit_undo = New System.Windows.Forms.MenuItem
		Me.mnuedit_redo = New System.Windows.Forms.MenuItem
		Me.mnuvote = New System.Windows.Forms.MenuItem
		Me.mnuhelp = New System.Windows.Forms.MenuItem
		Me.mnuhelp_about = New System.Windows.Forms.MenuItem
		Me.stbar = New System.Windows.Forms.StatusBar
		Me.stbarp00 = New System.Windows.Forms.StatusBarPanel
		Me.stbarp01 = New System.Windows.Forms.StatusBarPanel
		Me.stbarp02 = New System.Windows.Forms.StatusBarPanel
		Me.stbarp03 = New System.Windows.Forms.StatusBarPanel
		Me.mnuhelp_readme = New System.Windows.Forms.MenuItem
		Me.mnuhelp_sep = New System.Windows.Forms.MenuItem
		CType(Me.stbarp00, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.stbarp01, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.stbarp02, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.stbarp03, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'mnu
		'
		Me.mnu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnufile, Me.mnuedit, Me.mnuvote, Me.mnuhelp})
		'
		'mnufile
		'
		Me.mnufile.Index = 0
		Me.mnufile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnufile_open, Me.mnufile_save, Me.mnufile_saveas, Me.mnufile_close, Me.mnufile_sep, Me.mnufile_exit})
		Me.mnufile.Text = "File"
		'
		'mnufile_open
		'
		Me.mnufile_open.Index = 0
		Me.mnufile_open.Shortcut = System.Windows.Forms.Shortcut.CtrlO
		Me.mnufile_open.Text = "Open..."
		'
		'mnufile_save
		'
		Me.mnufile_save.Index = 1
		Me.mnufile_save.Shortcut = System.Windows.Forms.Shortcut.CtrlS
		Me.mnufile_save.Text = "Save"
		'
		'mnufile_saveas
		'
		Me.mnufile_saveas.Index = 2
		Me.mnufile_saveas.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftS
		Me.mnufile_saveas.Text = "Save As..."
		'
		'mnufile_close
		'
		Me.mnufile_close.Index = 3
		Me.mnufile_close.Text = "Close"
		'
		'mnufile_sep
		'
		Me.mnufile_sep.Index = 4
		Me.mnufile_sep.Text = "-"
		'
		'mnufile_exit
		'
		Me.mnufile_exit.Index = 5
		Me.mnufile_exit.Text = "Exit"
		'
		'mnuedit
		'
		Me.mnuedit.Index = 1
		Me.mnuedit.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuedit_undo, Me.mnuedit_redo})
		Me.mnuedit.Text = "Edit"
		'
		'mnuedit_undo
		'
		Me.mnuedit_undo.Index = 0
		Me.mnuedit_undo.Text = "Undo"
		'
		'mnuedit_redo
		'
		Me.mnuedit_redo.Index = 1
		Me.mnuedit_redo.Text = "Redo"
		'
		'mnuvote
		'
		Me.mnuvote.Index = 2
		Me.mnuvote.Text = "Vote Now..."
		'
		'mnuhelp
		'
		Me.mnuhelp.Index = 3
		Me.mnuhelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuhelp_readme, Me.mnuhelp_sep, Me.mnuhelp_about})
		Me.mnuhelp.Text = "Help"
		'
		'mnuhelp_about
		'
		Me.mnuhelp_about.Index = 2
		Me.mnuhelp_about.Shortcut = System.Windows.Forms.Shortcut.F1
		Me.mnuhelp_about.Text = "About"
		'
		'stbar
		'
		Me.stbar.Location = New System.Drawing.Point(0, 520)
		Me.stbar.Name = "stbar"
		Me.stbar.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.stbarp00, Me.stbarp01, Me.stbarp02, Me.stbarp03})
		Me.stbar.ShowPanels = True
		Me.stbar.Size = New System.Drawing.Size(760, 22)
		Me.stbar.TabIndex = 1
		Me.stbar.Text = "Ready"
		'
		'stbarp00
		'
		Me.stbarp00.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
		Me.stbarp00.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.None
		Me.stbarp00.Text = "Ready"
		Me.stbarp00.Width = 594
		'
		'stbarp01
		'
		Me.stbarp01.Alignment = System.Windows.Forms.HorizontalAlignment.Center
		Me.stbarp01.Width = 40
		'
		'stbarp02
		'
		Me.stbarp02.Alignment = System.Windows.Forms.HorizontalAlignment.Center
		Me.stbarp02.Width = 40
		'
		'stbarp03
		'
		Me.stbarp03.Alignment = System.Windows.Forms.HorizontalAlignment.Center
		Me.stbarp03.Width = 70
		'
		'mnuhelp_readme
		'
		Me.mnuhelp_readme.Index = 0
		Me.mnuhelp_readme.Text = "Readme File"
		'
		'mnuhelp_sep
		'
		Me.mnuhelp_sep.Index = 1
		Me.mnuhelp_sep.Text = "-"
		'
		'fmain
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(760, 542)
		Me.Controls.Add(Me.stbar)
		Me.IsMdiContainer = True
		Me.Menu = Me.mnu
		Me.Name = "fmain"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.Text = "Paint Bucket Algorithm Test Application"
		Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
		CType(Me.stbarp00, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.stbarp01, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.stbarp02, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.stbarp03, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub

#End Region

	Public frmbrush As fbrush
	Public frmtoolbox As ftoolbox
	Private _encoderInfos As New ArrayList

	Private Sub fmain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		frmbrush = New fbrush
		Me.AddOwnedForm(frmbrush)
		frmbrush.Show()

		frmtoolbox = New ftoolbox
		Me.AddOwnedForm(frmtoolbox)
		frmtoolbox.Show()

		Dim verinfo As Diagnostics.FileVersionInfo = FileVersionInfo.GetVersionInfo(Application.ExecutablePath)
		Me.Text &= "  v" & verinfo.FileMajorPart & "." & verinfo.FileMinorPart & "." & verinfo.FileBuildPart & " Build " & verinfo.FilePrivatePart
	End Sub

	Private Sub mnufile_open_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnufile_open.Click
		Dim opendlg As New OpenFileDialog
		opendlg.CheckFileExists = True
		opendlg.CheckPathExists = True
		opendlg.Filter = GetFormats(True)
		opendlg.InitialDirectory = ""
		opendlg.Multiselect = True
		opendlg.ShowReadOnly = False
		opendlg.ValidateNames = True

		If opendlg.ShowDialog(Me) = DialogResult.OK Then
			Dim tmp As String

			For Each tmp In opendlg.FileNames
				Dim frm As New fimg
				Dim inpstream As IO.Stream = IO.File.Open(tmp, IO.FileMode.Open, IO.FileAccess.Read)
				Dim img As Image = Image.FromStream(inpstream)
				inpstream.Close()

				frm._format = _encoderInfos(opendlg.FilterIndex - 1)
				frm.pct.Image = img.Clone

				Dim fl As New IO.FileInfo(tmp)
				frm.Text = fl.Name & " - " & img.Width & "x" & img.Height
				frm.pct.Tag = fl

				If Not img.Width > Me.Width Then frm.Width = img.Width + 2 + (SystemInformation.FrameBorderSize.Width * 2) + 10
				If Not img.Height > Me.Height Then frm.Height = img.Height + 2 + SystemInformation.CaptionHeight + (SystemInformation.FrameBorderSize.Height * 2) + 10
				img.Dispose()
				img = Nothing
				frm.MdiParent = Me
				frm.Show()
			Next
		End If
	End Sub

	Private Sub mnufile_Select(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnufile.Select
		If Me.ActiveMdiChild Is Nothing Then
			mnufile_close.Enabled = False
			mnufile_save.Enabled = False
			mnufile_saveas.Enabled = False
		Else
			mnufile_close.Enabled = True
			mnufile_save.Enabled = True
			mnufile_saveas.Enabled = True
		End If
	End Sub

	Private Sub mnuedit_Select(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuedit.Select
		If Me.ActiveMdiChild Is Nothing Then
			mnuedit_redo.Enabled = False
			mnuedit_undo.Enabled = False
		Else
			Dim frm As fimg = Me.ActiveMdiChild
			If frm._undo.Count = 0 Then
				mnuedit_undo.Enabled = False
				mnuedit_undo.Text = "No Undo Avaible"
			Else
				mnuedit_undo.Enabled = True
				mnuedit_undo.Text = "Undo (" & frm._undo.Count & ")"
			End If

			If frm._redo.Count = 0 Then
				mnuedit_redo.Enabled = False
				mnuedit_redo.Text = "No Redo Avaible"
			Else
				mnuedit_redo.Enabled = True
				mnuedit_redo.Text = "Redo (" & frm._redo.Count & ")"
			End If
		End If
	End Sub

	Private Sub mnuedit_undo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuedit_undo.Click
		Dim frm As fimg = Me.ActiveMdiChild
		frm.UndoAction()
	End Sub

	Private Sub mnuedit_redo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuedit_redo.Click
		Dim frm As fimg = Me.ActiveMdiChild
		frm.RedoAction()
	End Sub

	Private Sub mnufile_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnufile_save.Click
		Dim frm As fimg = Me.ActiveMdiChild
		Dim fl As IO.FileInfo = frm.pct.Tag
		Dim _encoder As ImageCodecInfo = frm._format
		Dim _codecparamslist As New ArrayList

		Select Case _encoder.MimeType
			Case "image/bmp"
				_codecparamslist.Add(New EncoderParameter(Encoder.ColorDepth, 24))
			Case "image/jpeg", "image/png"
				_codecparamslist.Add(New EncoderParameter(Encoder.Quality, CLng(100)))
				_codecparamslist.Add(New EncoderParameter(Encoder.RenderMethod, EncoderValue.RenderNonProgressive))
			Case "image/gif"
				_codecparamslist.Add(New EncoderParameter(Encoder.ScanMethod, EncoderValue.ScanMethodNonInterlaced))
				_codecparamslist.Add(New EncoderParameter(Encoder.Version, EncoderValue.VersionGif89))
		End Select

		Dim _codecparamarr As New EncoderParameters
		_codecparamarr.Param = _codecparamslist.ToArray(GetType(EncoderParameter))

		SaveImg(frm.pct.Image, fl.FullName, _encoder, _codecparamarr)
		stbarp00.Text = "Image saved (" & fl.FullName & ")"
	End Sub

	Function GetFormats(Optional ByVal allfiles As Boolean = False) As String
		Dim _encoders() As ImageCodecInfo
		Dim _encoder As ImageCodecInfo
		Dim tmp As String
		Dim allexts As String
		_encoders = ImageCodecInfo.GetImageEncoders()

		If Not _encoders Is Nothing Then
			For Each _encoder In _encoders
				If (Strings.Right(_encoder.MimeType, 4) = "/bmp") Or (Strings.Right(_encoder.MimeType, 4) = "jpeg") Or (Strings.Right(_encoder.MimeType, 4) = "/gif") Or (Strings.Right(_encoder.MimeType, 4) = "/png") Then
					tmp &= _encoder.CodecName & " (" & _encoder.FilenameExtension.ToLower & ")|" & _encoder.FilenameExtension & "|"
					_encoderInfos.Add(_encoder)
					If allfiles = True Then allexts &= _encoder.FilenameExtension & ";"
				End If
			Next

			If allfiles = False Then
				Return Strings.Left(tmp, (tmp.Length - 1))
			Else
				allexts = Strings.Left(allexts, allexts.Length - 1).ToLower
				Return "All Image Files (" & allexts & ")|" & allexts & "|" & Strings.Left(tmp, (tmp.Length - 1))
			End If
		Else
			Return ""
		End If
	End Function

	Private Sub mnufile_saveas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnufile_saveas.Click
		Dim savedlg As New SaveFileDialog
		Dim frm As fimg = Me.ActiveMdiChild
		Dim fl As IO.FileInfo = frm.pct.Tag

		savedlg.Filter = GetFormats()
		savedlg.CheckPathExists = True
		savedlg.DefaultExt = ".jpg"
		savedlg.FileName = Strings.Left(fl.Name, fl.Name.Length - fl.Extension.Length)
		savedlg.OverwritePrompt = True
		savedlg.ValidateNames = True
		savedlg.AddExtension = True

		If savedlg.ShowDialog(Me) = DialogResult.OK Then
			Dim _encoder As ImageCodecInfo = _encoderInfos(savedlg.FilterIndex - 1)
			Dim _codecparamslist As New ArrayList
			Select Case _encoder.MimeType
				Case "image/bmp"
					_codecparamslist.Add(New EncoderParameter(Encoder.ColorDepth, 24))
				Case "image/jpeg", "image/png"
					_codecparamslist.Add(New EncoderParameter(Encoder.Quality, CLng(100)))
					_codecparamslist.Add(New EncoderParameter(Encoder.RenderMethod, EncoderValue.RenderNonProgressive))
				Case "image/gif"
					_codecparamslist.Add(New EncoderParameter(Encoder.ScanMethod, EncoderValue.ScanMethodNonInterlaced))
					_codecparamslist.Add(New EncoderParameter(Encoder.Version, EncoderValue.VersionGif89))
			End Select

			Dim _codecparamarr As New EncoderParameters
			_codecparamarr.Param = _codecparamslist.ToArray(GetType(EncoderParameter))

			SaveImg(frm.pct.Image, savedlg.FileName, _encoder, _codecparamarr)
			stbarp00.Text = "Image saved (" & savedlg.FileName & ")"

			frm.tickst = 0
			fl = New IO.FileInfo(savedlg.FileName)
			frm.pct.Tag = fl
			frm.Text = fl.Name & " - " & frm.pct.Image.Width & "x" & frm.pct.Image.Height
		End If
	End Sub

	Private Sub SaveImg(ByVal inp As Image, ByVal path As String, ByVal enc As ImageCodecInfo, ByVal params As EncoderParameters)
		Dim img As Image = New Bitmap(inp.Width, inp.Height)
		Dim grp As Graphics = Graphics.FromImage(img)
		grp.DrawImage(inp, 0, 0, img.Width, img.Height)
		img.Save(path, enc, params)
		img.Dispose()
		grp.Dispose()
		img = Nothing
		grp = Nothing
	End Sub

	Sub mnufile_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnufile_close.Click
		Dim frm As fimg = Me.ActiveMdiChild
		If frm.tickst <> 0 Then
			If Not frm.pct.Cursor Is Windows.Forms.Cursors.WaitCursor Then
				Dim res As MsgBoxResult
				res = MsgBox("Some changes made on image, Do you want to save changes ?", MsgBoxStyle.Question Or MsgBoxStyle.YesNoCancel)

				If res = MsgBoxResult.Yes Then
					mnufile_save_Click(sender, e)
					frm.Dispose()
				ElseIf res = MsgBoxResult.No Then
					frm.Dispose()
				Else
					Exit Sub
				End If
			Else
				MsgBox("Please wait algorithm in progress", MsgBoxStyle.Information)
			End If
		Else
			frm.Dispose()
		End If

	End Sub

	Private Sub mnufile_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnufile_exit.Click
		Dim frm As fimg

		Do
			frm = Me.ActiveMdiChild
			If frm Is Nothing Then Exit Do
			frm.Select()
			mnufile_close_Click(sender, e)
			If frm.Visible = True Then Exit Sub
		Loop
		End
	End Sub

	Private Sub mnuhelp_about_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuhelp_about.Click
		Dim ret As String
		Dim verinfo As Diagnostics.FileVersionInfo = FileVersionInfo.GetVersionInfo(Application.ExecutablePath)

		ret &= "PaintBucket Algorithm" & vbCrLf
		ret &= "v" & verinfo.FileMajorPart & "." & verinfo.FileMinorPart & "." & verinfo.FileBuildPart & " Build " & verinfo.FilePrivatePart & vbCrLf
		ret &= " " & vbCrLf
		ret &= "coded by Sukru Alatas (http://alatas.info)" & vbCrLf
		ret &= " " & vbCrLf
		ret &= "Do you want to vote now?" & vbCrLf

		If MsgBox(ret, MsgBoxStyle.Information Or MsgBoxStyle.YesNo, "About...") = MsgBoxResult.Yes Then
			mnuvote_Click(sender, e)
		End If
	End Sub

	Private Sub mnuvote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuvote.Click
		Dim ieproc As New Process
		Dim stread As IO.StreamReader = IO.File.OpenText(Application.StartupPath & "\VoteNow.url")

		stread.ReadLine()

		Dim buff As String = stread.ReadLine
		buff = Strings.Right(buff, buff.Length - 8)
		stread.Close()

		ieproc.Start("explorer.exe", Chr(34) & buff & Chr(34))
	End Sub

	Private Sub mnuhelp_readme_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuhelp_readme.Click
		Dim ieproc As New Process
		ieproc.Start("explorer.exe", Chr(34) & Application.StartupPath & "\..\Readme.htm" & Chr(34))
	End Sub
End Class
