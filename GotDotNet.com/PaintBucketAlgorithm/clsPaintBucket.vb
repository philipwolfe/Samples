'Class for paint bucket algorithm
Imports PaintBucketAlgorithm.ColorSimilarity
Public Class clsPaintBucket
	Implements IDisposable

	'Private variable declares
	Private _cnvs(,) As Byte
	Private _grp As Graphics
	Private _bmp As Bitmap
	Private _tol As Byte
	Private _postponeds As New ArrayList
	Private _rects As New ArrayList

	'AsynCall declarations
	Private PaintBucketDelegate As _PaintBucket
	Private PaintBucketCallBack As AsyncCallback
	Event PaintBucketAsycEnd()
	Private Delegate Function _PaintBucket(ByVal startpoint As Point, ByVal newBrush As Brush) As Image

	'New creation construct
	Sub New(ByVal baseimg As Image, ByVal tolarence As Byte)
		_bmp = baseimg
		_grp = Graphics.FromImage(_bmp)
		_tol = tolarence
		ReDim _cnvs(_bmp.Width, _bmp.Height)
	End Sub

	'End routine for AsycCall
	Private Sub PaintBucketEnd(ByVal ar As IAsyncResult)
		PaintBucketDelegate.EndInvoke(ar)
		RaiseEvent PaintBucketAsycEnd()
	End Sub

	'AsycCall creation basec on SyncCall
	Sub PaintBucketAsyc(ByVal startpoint As Point, ByVal newBrush As Brush)
		PaintBucketDelegate = New _PaintBucket(AddressOf PaintBucket)
		PaintBucketCallBack = New AsyncCallback(AddressOf PaintBucketEnd)
		PaintBucketDelegate.BeginInvoke(startpoint, newBrush, PaintBucketCallBack, Nothing)
	End Sub

	'Main Routine of algoritm
	Function PaintBucket(ByVal startpoint As Point, ByVal newBrush As Brush) As Image
		_rects.Add(New Rectangle(startpoint, New Size(1, 1)))

		Dim basecolor As Color = _bmp.GetPixel(startpoint.X, startpoint.Y)
		ReDim _cnvs(_bmp.Width, _bmp.Height)

		Do
			SearchPoints(startpoint, basecolor)
			If _postponeds.Count = 0 Then
				Exit Do
			Else
				startpoint = _postponeds(0)
				_postponeds.RemoveAt(0)
			End If
		Loop
		Application.DoEvents()
		Dim rectsarr() As Rectangle
		rectsarr = _rects.ToArray(GetType(Rectangle))
		_grp.FillRectangles(newBrush, rectsarr)
		Return _bmp.Clone
	End Function

	'Property for output of algorithm
	ReadOnly Property Output() As Image
		Get
			Return _bmp.Clone
		End Get
	End Property

	'Sub routine of main routine, it searches the similarity on connected points
	Private Sub SearchPoints(ByVal basepoint As Point, ByVal basecolor As Color)
		Dim points() As Point = GetPoints(basepoint)
		If points Is Nothing Then Exit Sub

		For i As Byte = points.GetLowerBound(0) To points.GetUpperBound(0)
			If _cnvs(points(i).X, points(i).Y) <> 0 Then GoTo skippoint

			If GetNearRGBVectorial(basecolor, _bmp.GetPixel(points(i).X, points(i).Y)) > _tol Then
				_cnvs(points(i).X, points(i).Y) = 2
				_rects.Add(New Rectangle(points(i), New Size(1, 1)))
				_postponeds.Add(points(i))
			Else
				_cnvs(points(i).X, points(i).Y) = 1
			End If

			Application.DoEvents()
skippoint:
		Next
	End Sub

	'Sub routine of searchpoints routine, it returns the connected points of basepoint
	Private Function GetPoints(ByVal basepoint As Point) As Point()
		Dim points As New ArrayList
		Dim x, y, _x, _y As Int16

		x = -1
		y = 2
		Do
			_x = basepoint.X + (x Mod 2)
			_y = basepoint.Y + (y Mod 2)

			If (_x >= 0) And (_x < _bmp.Width) And (_y >= 0) And (_y < _bmp.Height) Then
				If _cnvs(_x, _y) = 0 Then
					points.Add(New Point(_x, _y))
				End If
			End If

			If x = 2 Then Exit Do
			x += 1
			y -= 1
		Loop

		If points.Count = 0 Then
			Return Nothing
		Else
			GetPoints = points.ToArray(GetType(Point))
			points = Nothing
		End If
	End Function

	'Disposing the variables and objects
	Protected Overrides Sub Finalize()
		Dispose()
		MyBase.Finalize()
	End Sub

	'Routine for clearing the objects and variables from memory
	Public Sub Dispose() Implements System.IDisposable.Dispose
		_bmp.Dispose()
		_grp.Dispose()
		_cnvs = Nothing
		_rects = Nothing
		_postponeds = Nothing
	End Sub
End Class