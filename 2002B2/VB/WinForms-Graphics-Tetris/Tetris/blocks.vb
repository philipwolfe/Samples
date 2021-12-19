Imports System.Drawing

Public Class Block
    
    ' Block defined as offsets from start (lart character back from start)
    ' 0 - Left
    ' 1 - Down
    ' 2 - Right
    ' 3 - Up
    
    Public BlockCol As Color
    Public CurX As Integer
    Public CurY As Integer
    Private BlockMatrix(,) As Integer = {{0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}}
    
    Public Sub Create()
        
        Dim randomNumber As New System.Random()
        
        Dim intBlockType As Integer
        intBlockType = randomNumber.Next() Mod 7
        
        Select Case intBlockType
            
            Case 0
                BlockCol = Color.Blue
                BlockMatrix(1, 0) = 1
                BlockMatrix(1, 1) = 1
                BlockMatrix(1, 2) = 1
                BlockMatrix(1, 3) = 1
                
            Case 1
                BlockCol = Color.Red
                BlockMatrix(2, 1) = 1
                BlockMatrix(1, 1) = 1
                BlockMatrix(1, 2) = 1
                BlockMatrix(2, 2) = 1
                
            Case 2
                BlockCol = Color.Green
                BlockMatrix(1, 0) = 1
                BlockMatrix(1, 1) = 1
                BlockMatrix(1, 2) = 1
                BlockMatrix(2, 0) = 1
                
            Case 3
                BlockCol = Color.Yellow
                BlockMatrix(1, 0) = 1
                BlockMatrix(1, 1) = 1
                BlockMatrix(1, 2) = 1
                BlockMatrix(2, 2) = 1
                
            Case 4
                BlockCol = Color.Purple
                BlockMatrix(1, 0) = 1
                BlockMatrix(1, 1) = 1
                BlockMatrix(2, 1) = 1
                BlockMatrix(2, 2) = 1
                
            Case 5
                BlockCol = Color.DarkSalmon
                BlockMatrix(1, 1) = 1
                BlockMatrix(1, 2) = 1
                BlockMatrix(2, 1) = 1
                BlockMatrix(2, 0) = 1
                
            Case 6
                BlockCol = Color.YellowGreen
                BlockMatrix(1, 1) = 1
                BlockMatrix(1, 2) = 1
                BlockMatrix(1, 0) = 1
                BlockMatrix(2, 1) = 1
                
        End Select
        
    End Sub
    
    Public Sub Rotate()
              
        Dim TempMatrix(,) As Integer = {{0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}}
        
        Dim q, w As Integer
        For q = 0 To 3
            For w = 0 To 3
                TempMatrix(q, w) = BlockMatrix(w, 3 - q)
            Next
        Next
        BlockMatrix = TempMatrix
        
    End Sub
    
    Public Sub Unrotate()
        
        Dim q As Integer
        For q = 1 To 3
            Rotate()
        Next
        
    End Sub
    
    Public Function ReturnBlock() As String
        
        ' Return String with block coordinates delimited by '#'
        Dim q, w As Integer
        Dim ReturnString As String = ""
        
        For q = 0 To 3
            For w = 0 To 3
                If BlockMatrix(q, w) = 1 Then
                    
                    If ReturnString <> "" Then
                        ReturnString = ReturnString & "#"
                    End If
                    
                    ReturnString = ReturnString & (q + CurX).ToString & "," & (w + CurY).ToString
                    
                End If
            Next
        Next
        ReturnBlock = ReturnString
        
    End Function
    
    Sub MoveLeft()
        CurX = CurX - 1
    End Sub
    
    Sub MoveRight()
        CurX = CurX + 1
    End Sub
    
    Sub MoveDown()
        CurY = CurY + 1
    End Sub
    
End Class
