Option Strict Off
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports microsoft.VisualBasic.Compatibility.VB6

Public Class clsSnake
	Private mcGridSize As clsGridPoint
	Private mcPic As PictureBox
	Private mcQueuedMoves As New Collections.ArrayList()
	Private mcSnakeBody As New Collections.ArrayList()
	Private mNextMove As clsGridPoint
	Private miCellWidthPx As Integer
	Private miCellHeightPx As Integer
	Private mcNextMove As clsGridPoint
	Private mcHeadCell As clsGridPoint
	Private mlSnakeLength As Integer
	Private mCellColor As Color
	Private mcFlyCell As clsGridPoint
	Private mcFlyPic As PictureBox
	
	Private mbGameOver As Boolean = False
	Private mlScore As Integer = 0
	
	Sub New(ByVal lBoardWidth As Integer, ByVal lBoardHeight As Integer, ByVal lInitSnakeLength As Integer, ByVal oPic As Picturebox, ByVal oPicFly As PictureBox)
		mCellColor = Color.FromARGB(58, 110, 165)
		mcGridSize = New clsGridPoint()
		mcGridSize.gridX = lBoardWidth
		mcGridSize.gridY = lBoardHeight
		mcFlyPic = oPicFly
		mcPic = oPic
		Dim oGC As Graphics
		oGC = mcPic.CreateGraphics
		oGC.Clear(mcPic.BackColor)
		oGC.Dispose()
		
		mlSnakeLength = lInitSnakeLength
		
		miCellWidthPx = CInt(mcPic.ClientRectangle.Width / lBoardWidth)
		miCellHeightPx = CInt(mcPic.ClientRectangle.Height / lBoardHeight)
		
		mcHeadCell = New clsGridPoint()
		mcHeadCell.gridX = CInt(mcGridSize.gridX / 2)
		mcHeadCell.gridY = CInt(mcGridSize.gridY / 2)
		
		AddToSnakeBody(mcHeadCell.clone)
		
		createFly()
	End Sub
	Public Function Score() As Integer
		Score = mlScore
	End Function
	Public Function GameOver() As Boolean
		GameOver = mbGameOver
	End Function
	Private Function createFly()
		mcFlyCell = New clsGridPoint()
		Do
			mcFlyCell.gridX = (Rnd * mcGridSize.gridX) + 1
			mcFlyCell.gridY = (Rnd * mcGridSize.gridY) + 1
		Loop Until IsNotOccupied(mcFlyCell) And isinbounds(mcflycell)
		
		PaintSnakeCell(mcFlyCell, color.white, True)
	End Function
	Private Function IsInBounds(ByVal oPt As clsGridPoint) As Boolean
		Dim bRet As Boolean
		bRet = True
		If oPt.gridX < 1 Then
			bRet = False
		End If
		If oPt.gridY < 1 Then
			bRet = False
		End If
		If oPt.gridX > mcGridSize.gridX Then
			bRet = False
		End If
		If oPt.gridY > mcGridSize.gridY Then
			bRet = False
		End If
		IsInBounds = bRet
	End Function
	Private Function IsNotOccupied(ByVal oPt As clsGridPoint) As Boolean
		Dim cCell As clsGridPoint
		Dim bRet As Boolean
		bRet = True
		For Each cCell In mcSnakeBody
			If cCell.isEqualTo(oPt) Then
				bRet = False
			End If
		Next
		IsNotOccupied = bRet
	End Function
	Public Sub applyNextMove()
		Dim cMovePt As Point
		If mcQueuedMoves.Count Then
			mcNextMove = CType(mcQueuedMoves(0), clsGridPoint)
			mcQueuedMoves.RemoveAt(0)
		End If
		mcHeadCell.offsetBy(mcNextMove)
		If IsInBounds(mcHeadCell) = False Then
			mbGameOver = True
		End If
		If IsNotOccupied(mcHeadCell) = False Then
			mbGameOver = True
		End If
		If mbGameOver = False Then
			AddToSnakeBody(mcHeadCell.clone())
			
			' Clear end of snake
			Dim oPt As clsGridPoint
			Do Until mcSnakeBody.Count <= mlSnakeLength
				oPt = mcSnakeBody(0)
				PaintSnakeCell(oPt, mcpic.BackColor, False)
				mcSnakeBody.RemoveAt(0)
			Loop
			
			Dim i As Integer
			Dim oThisColor As Color
			Dim iRed, iGreen, iBlue, iAlpha As Integer
			iRed = mCellCOlor.r
			iGreen = mCellCOlor.g
			iBlue = mCellCOlor.b
			For i = mcSnakeBody.Count - 1 To 0 Step -1
				oThisCOlor = oThisColor.FromARGB(iRed, iGreen, iBlue)
				PaintSnakeCell(mcSnakeBody(i), oThisCOlor, False)
				iBlue = iBlue * 0.95
				iGreen = iGreen * 0.95
				iRed = iRed * 0.95
			Next i
			
			If mcFlyCell.isEqualTo(mcHeadCell) Then
				mlScore = mlScore + 1
				createFly()
				mlSnakeLength = mlSnakeLength + 2
				Beep()
			End If
		End If
	End Sub
	Public Sub PaintSnake()
		Dim i As Integer
		Dim oPt As clsGridPoint
		Dim oThisColor As Color = mCellColor
		For i = 0 To mcSnakeBody.Count - 1
			oPt = CType(mcSnakeBody.Item(i), clsGridPoint)
			PaintSnakeCell(oPt, oThisCOlor, False)
		Next
	End Sub
	
	Public Function SnakeBodyDump() As String
		Dim i As Integer
		Dim oPt As clsGridPoint
		Dim sOut As String
		For i = 0 To mcSnakeBody.Count - 1
			oPt = mcSnakeBody(i)
			sOut = sOut & oPt.DebugText
		Next
		SnakeBodyDump = sOut
	End Function
	Public Function QueuedMovesDump() As String
		Dim i As Integer
		Dim oPt As clsGridPoint
		Dim sOut As String
		For i = 0 To mcQueuedMoves.Count - 1
			oPt = mcQueuedMoves(i)
			sOut = sOut & oPt.DebugText
		Next
		QueuedMovesDump = sOut
	End Function
	Public Sub addMove(Optional ByVal deltaX As Integer = 0, Optional ByVal deltaY As Integer = 0)
		Dim oPt As New clsGridPoint()
		oPt.GridX = deltaX
		oPt.GridY = deltaY
		mcQueuedMoves.Add(oPt)
	End Sub
	Private Sub AddToSnakeBody(ByVal oPt As clsGridPoint)
		mcSnakeBody.Add(oPt)
	End Sub
	Private Sub PaintSnakeCell(ByVal oGridPt As clsGridPoint, ByVal oColor As color, ByVal bAsFly As Boolean)
		Dim oGC As Graphics
		oGC = mcPic.CreateGraphics()
		
		Dim oPen As New Pen(oColor)
		Dim oRect As Rectangle
		oRect.x = (oGridPt.gridX - 1) * miCellWidthPx
		oRect.y = (oGridPt.gridY - 1) * miCellHeightPx
		oRect.Height = miCellHeightPx
		oRect.Width = miCellWidthPx
		oGC.FillRectangle(oPen.Brush, oRect)
		If bAsFly Then
            Dim oFly As Image = Me.mcFlyPic.Image.Clone()
            oGC.DrawImage(oFly, oRect)
		End If
		oPen.Dispose()
		oGC.Dispose()
	End Sub
End Class
Public Class clsGridPoint
    Private miGridX As Integer
    Private miGridY As Integer

    Public Property gridX() As Integer
        Get
            gridX = miGridX
        End Get
        Set(ByVal Value As Integer)
            miGridX = Value
        End Set
    End Property

    Public Property gridY() As Integer
        Get
            gridY = miGridY
        End Get
        Set(ByVal Value As Integer)
            miGridY = Value
        End Set
    End Property

    Public Function isEqualTo(ByVal cPt As clsGridPoint) As Boolean
        If Me.gridX = cPt.gridX And Me.gridY = cPt.gridY Then
            isEqualTo = True
        End If
    End Function

    Public Sub offsetBy(ByVal cPt As clsGridPoint)
        miGridX = miGridX + cPt.gridX
        miGridY = miGridY + cPt.gridY
    End Sub

    Public Function clone() As clsGridPoint
        Dim cRet As New clsGridPoint()
        cRet.gridX = miGridX
        cRet.gridY = miGridY
        clone = cRet
    End Function

    Public Function debugText() As String
        debugText = "(" & CStr(Me.gridX) & "," & CStr(Me.gridY) & ")"
    End Function


End Class
