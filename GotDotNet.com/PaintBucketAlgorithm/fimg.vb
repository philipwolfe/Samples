'form that picture is drawn on
Public Class fimg
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
	Friend WithEvents pct As System.Windows.Forms.PictureBox
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.pct = New System.Windows.Forms.PictureBox
		Me.SuspendLayout()
		'
		'pct
		'
		Me.pct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.pct.Cursor = System.Windows.Forms.Cursors.No
		Me.pct.Dock = System.Windows.Forms.DockStyle.Fill
		Me.pct.Location = New System.Drawing.Point(5, 5)
		Me.pct.Name = "pct"
		Me.pct.Size = New System.Drawing.Size(282, 256)
		Me.pct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
		Me.pct.TabIndex = 0
		Me.pct.TabStop = False
		'
		'fimg
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(292, 266)
		Me.Controls.Add(Me.pct)
		Me.DockPadding.All = 5
		Me.Name = "fimg"
		Me.Text = "fimg"
		Me.ResumeLayout(False)

	End Sub

#End Region

	Dim frm As fmain
	Dim WithEvents pbucket As clsPaintBucket

	Public tickst As Long = 0
	Public _undo As New ArrayList
	Public _redo As New ArrayList
	Public _format As Imaging.ImageCodecInfo

	Private Sub fimg_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
		If Not pct.Cursor Is Windows.Forms.Cursors.WaitCursor Then
			If frm.frmtoolbox.chkpbucket.Checked = True Then
				pct.Cursor = New Windows.Forms.Cursor(Application.StartupPath & "\bucket.cur")
			Else
				pct.Cursor = Windows.Forms.Cursors.No
				ChangeStatusText("Ready", "", "")
			End If
		Else
			ChangeStatusText("Please wait algorithm in progress", "", "")
		End If
	End Sub

	Private Sub fimg_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
		frm = Me.MdiParent
	End Sub

	Private Sub pct_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pct.MouseDown
		If (frm.frmtoolbox.chkpbucket.Checked = True) And (Not pct.Cursor Is Windows.Forms.Cursors.WaitCursor) And (Not pct.Cursor Is Windows.Forms.Cursors.No) Then
			Dim newpoint As Point = CalculatedCoordinates(New Point(e.X, e.Y))

			If (newpoint.X <= pct.Image.Width - 1) And (newpoint.X >= 0) And (newpoint.Y <= pct.Image.Height - 1) And (newpoint.Y >= 0) Then
				tickst = Now.Ticks / 10000

				frm.stbarp00.Text = "Please wait algorithm in progress"
				pct.Cursor = Windows.Forms.Cursors.WaitCursor

				UndoAdd(pct.Image)
				_redo.Clear()

				pbucket = New clsPaintBucket(pct.Image, 100 - frm.frmtoolbox.trktolarance.Value)
				pbucket.PaintBucketAsyc(newpoint, frm.frmbrush.SelectedBrush)
			Else
				Beep()
			End If
		Else
			Beep()
		End If
	End Sub

	Private Function CalculatedCoordinates(ByVal inp As Point) As Point
		Dim x As Integer = (pct.Width - pct.Image.Width - 2) / 2
		Dim y As Integer = (pct.Height - pct.Image.Height - 2) / 2

		Return New Point(inp.X - x, inp.Y - y)
	End Function

	Private Sub pct_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pct.MouseMove
		If Not pct.Cursor Is Windows.Forms.Cursors.WaitCursor Then
			If frm.frmtoolbox.chkpbucket.Checked = True Then

				Dim newpoint As Point = CalculatedCoordinates(New Point(e.X, e.Y))

				If (newpoint.X <= pct.Image.Width - 1) And (newpoint.X >= 0) And (newpoint.Y <= pct.Image.Height - 1) And (newpoint.Y >= 0) Then
					ChangeStatusText("Click on the image for starting the algorithm", newpoint.X, newpoint.Y)
				Else
					ChangeStatusText("Out of Area", "", "")
				End If
			End If
		Else
			ChangeStatusText("Please wait algorithm in progress", "", "")
		End If
	End Sub

	Private Sub pct_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pct.MouseLeave
		ChangeStatusText("Ready", "", "")
	End Sub

	Private Sub pbucket_PaintBucketAsycEnd() Handles pbucket.PaintBucketAsycEnd
		pct.Image = pbucket.Output.Clone

		pbucket.Dispose()
		pbucket = Nothing

		frm.stbarp03.Text = Fix((Now.Ticks / 10000) - tickst) & " msec"

		If frm.frmtoolbox.chkpbucket.Checked = True Then
			pct.Cursor = New Windows.Forms.Cursor(Application.StartupPath & "\bucket.cur")
		Else
			pct.Cursor = Windows.Forms.Cursors.No
			ChangeStatusText("Ready", "", "")
		End If

		Beep()
	End Sub

	Private Sub ChangeStatusText(ByVal txt As String, ByVal x As String, ByVal y As String)
		frm.stbarp00.Text = txt
		frm.stbarp01.Text = x
		frm.stbarp02.Text = y
	End Sub

	Private Sub UndoAdd(ByVal img As Image)
		If _undo.Count = 5 Then
			_undo.RemoveAt(4)
		End If
		Dim str As IO.MemoryStream = SaveImg(img)
		_undo.Insert(0, str)
	End Sub

	Private Function SaveImg(ByVal inp As Image) As IO.Stream
		Dim tmp As New IO.MemoryStream
		Dim img As Image = New Bitmap(inp.Width, inp.Height)
		Dim grp As Graphics = Graphics.FromImage(img)
		grp.DrawImage(inp, 0, 0, img.Width, img.Height)
		img.Save(tmp, Imaging.ImageFormat.Png)
		img.Dispose()
		grp.Dispose()
		img = Nothing
		grp = Nothing
		Return tmp
	End Function

	Private Sub RedoAdd(ByVal img As Image)
		If _redo.Count = 5 Then
			_redo.RemoveAt(4)
		End If
		Dim str As IO.MemoryStream = SaveImg(img)
		_redo.Insert(0, str)
	End Sub

	Sub UndoAction()
		RedoAdd(pct.Image)
		Dim str As IO.MemoryStream = _undo(0)
		Dim tmp As Image = Image.FromStream(str)
		pct.Image = tmp.Clone
		_undo.RemoveAt(0)
		tmp.Dispose()
	End Sub

	Sub RedoAction()
		UndoAdd(pct.Image)
		Dim str As IO.MemoryStream = _redo(0)
		Dim tmp As Image = Image.FromStream(str)
		pct.Image = tmp.Clone
		_redo.RemoveAt(0)
		tmp.Dispose()
	End Sub

	Private Sub fimg_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Disposed
		_undo.Clear()
		_redo.Clear()
		frm = Nothing
		pbucket = Nothing
	End Sub

	Private Sub fimg_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
		e.Cancel = True
		frm.mnufile_close_Click(sender, Nothing)
	End Sub
End Class