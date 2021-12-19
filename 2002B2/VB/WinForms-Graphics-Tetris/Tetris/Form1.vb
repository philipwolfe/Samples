Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms


Public Class Form1
    
    Inherits System.Windows.Forms.Form
    
    Private CurrentBlock As Block
    Private InternalPlayArea(10, 17) As Integer
    Private JustLocked As Boolean = False
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtLines As System.Windows.Forms.Label
    Private intScore As Integer = 0
    Friend WithEvents cmdPause As System.Windows.Forms.Button
    Private intLines As Integer = 0
    Friend WithEvents txtPaused As System.Windows.Forms.Label
    Private bPaused As Boolean = False
    Private intLevel As Integer = 0

    Public Sub New()
        MyBase.New()

        Form1 = Me

        'This call is required by the Win Form Designer.
        InitializeComponent()

        ' Game Initialisation
        InitGame()

        'Disable pause button
        cmdPause.Enabled = False
    End Sub

    'Form overrides dispose to clean up the component list.
    Public Overrides Sub Dispose()
        MyBase.Dispose()
        components.Dispose()
    End Sub
    Private components As System.ComponentModel.IContainer
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents txtScore As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GameOver As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents cmdStart As System.Windows.Forms.Button
    Friend WithEvents PlayArea As System.Windows.Forms.PictureBox

#Region " Windows Form Designer generated code "

    'Required by the Windows Form Designer










    Dim WithEvents Form1 As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.PlayArea = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtScore = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtLines = New System.Windows.Forms.Label()
        Me.txtPaused = New System.Windows.Forms.Label()
        Me.GameOver = New System.Windows.Forms.Label()
        Me.cmdStart = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.cmdPause = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PlayArea
        '
        Me.PlayArea.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.PlayArea.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.PlayArea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PlayArea.Location = New System.Drawing.Point(104, 8)
        Me.PlayArea.Name = "PlayArea"
        Me.PlayArea.Size = New System.Drawing.Size(210, 352)
        Me.PlayArea.TabIndex = 0
        Me.PlayArea.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtScore})
        Me.GroupBox1.Location = New System.Drawing.Point(4, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(96, 40)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Score"
        '
        'txtScore
        '
        Me.txtScore.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Bold)
        Me.txtScore.Location = New System.Drawing.Point(8, 16)
        Me.txtScore.Name = "txtScore"
        Me.txtScore.Size = New System.Drawing.Size(80, 16)
        Me.txtScore.TabIndex = 0
        Me.txtScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtLines})
        Me.GroupBox2.Location = New System.Drawing.Point(4, 64)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(96, 40)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Lines"
        '
        'txtLines
        '
        Me.txtLines.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtLines.Location = New System.Drawing.Point(8, 16)
        Me.txtLines.Name = "txtLines"
        Me.txtLines.Size = New System.Drawing.Size(80, 16)
        Me.txtLines.TabIndex = 0
        Me.txtLines.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtPaused
        '
        Me.txtPaused.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.txtPaused.ForeColor = System.Drawing.Color.Red
        Me.txtPaused.Location = New System.Drawing.Point(8, 144)
        Me.txtPaused.Name = "txtPaused"
        Me.txtPaused.Size = New System.Drawing.Size(88, 32)
        Me.txtPaused.TabIndex = 10
        Me.txtPaused.Text = "Paused"
        Me.txtPaused.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.txtPaused.Visible = False
        '
        'GameOver
        '
        Me.GameOver.Font = New System.Drawing.Font("Microsoft Sans Serif", 20!)
        Me.GameOver.ForeColor = System.Drawing.Color.Red
        Me.GameOver.Location = New System.Drawing.Point(8, 216)
        Me.GameOver.Name = "GameOver"
        Me.GameOver.Size = New System.Drawing.Size(88, 64)
        Me.GameOver.TabIndex = 2
        Me.GameOver.Text = "Game Over"
        Me.GameOver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.GameOver.Visible = False
        '
        'cmdStart
        '
        Me.cmdStart.Location = New System.Drawing.Point(8, 304)
        Me.cmdStart.Name = "cmdStart"
        Me.cmdStart.TabIndex = 1
        Me.cmdStart.Text = "&Start"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(144, 80)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = "TextBox1"
        '
        'cmdPause
        '
        Me.cmdPause.Location = New System.Drawing.Point(8, 336)
        Me.cmdPause.Name = "cmdPause"
        Me.cmdPause.TabIndex = 4
        Me.cmdPause.Text = "&Pause"
        '
        'Timer1
        '
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(320, 365)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtPaused, Me.GroupBox2, Me.GroupBox1, Me.cmdPause, Me.GameOver, Me.cmdStart, Me.PlayArea, Me.TextBox1})
        Me.KeyPreview = True
        Me.Name = "Form1"
        Me.Text = "Tetris.NET"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    ' Graphical Routines (Draw / Clear )

    Public Sub subClearBox(ByVal intX As Integer, ByVal intY As Integer)

        Dim G As Graphics
        G = PlayArea.CreateGraphics()

        Dim B As SolidBrush
        B = New SolidBrush(Color.White)

        Dim R As Rectangle
        R.X = 4 + intX * 20
        R.Y = 4 + intY * 20
        R.Height = 19
        R.Width = 19

        G.FillRectangle(B, R)

    End Sub

    Public Sub subDrawBox(ByVal intX As Integer, ByVal intY As Integer, ByVal intColor As Color)

        Dim G As Graphics
        G = PlayArea.CreateGraphics()

        Dim P As Pen
        P = New Pen(Color.Black)

        Dim B As SolidBrush
        B = New SolidBrush(intColor)

        Dim R As Rectangle
        R.X = 4 + intX * 20
        R.Y = 4 + intY * 20
        R.Height = 18
        R.Width = 18

        G.FillRectangle(B, R)
        G.DrawRectangle(P, R)

    End Sub


    ' Block Manipulation Routines

    Public Sub DrawBlock(ByVal theBlock As Block, ByVal Directive As String)

        Dim WorkArray(,) As Integer = New Integer(3, 1) {}
        Dim i As Integer

        Dim WorkArray2(), WorkArray3() As String
        WorkArray2 = Split(theBlock.ReturnBlock, "#")
        For i = 0 To 3
            WorkArray3 = Split(WorkArray2(i), ",")
            WorkArray(i, 0) = Convert.ToInt16(WorkArray3(0))
            WorkArray(i, 1) = Convert.ToInt16(WorkArray3(1))
        Next

        For i = 0 To 3
            Select Case Directive
                Case "Clear"
                    subClearBox(WorkArray(i, 0), WorkArray(i, 1))
                    InternalPlayArea(WorkArray(i, 0), WorkArray(i, 1)) = 0
                Case "Draw"
                    subDrawBox(WorkArray(i, 0), WorkArray(i, 1), theBlock.BlockCol)
                    InternalPlayArea(WorkArray(i, 0), WorkArray(i, 1)) = theBlock.BlockCol.ToArgb
                Case "Lock"
                    subDrawBox(WorkArray(i, 0), WorkArray(i, 1), theBlock.BlockCol)
                    InternalPlayArea(WorkArray(i, 0), WorkArray(i, 1)) = theBlock.BlockCol.ToArgb - 1
            End Select

        Next i

    End Sub

    Private Function CanMove(ByVal theblock As Block, ByVal intXdir As Integer, ByVal intYdir As Integer) As Boolean

        Dim WorkArray(,) As Integer = New Integer(3, 1) {}
        Dim i As Integer

        ' Push coordinated to proposed ones
        Dim WorkArray2(), WorkArray3() As String
        WorkArray2 = Split(theblock.ReturnBlock, "#")
        For i = 0 To 3
            WorkArray3 = Split(WorkArray2(i), ",")
            WorkArray(i, 0) = Convert.ToInt16(WorkArray3(0))
            WorkArray(i, 1) = Convert.ToInt16(WorkArray3(1))
        Next

        For i = 0 To 3
            WorkArray(i, 0) = WorkArray(i, 0) + intXdir
            WorkArray(i, 1) = WorkArray(i, 1) + intYdir
        Next

        ' Perform Checks
        CanMove = True

        ' First check screen left/right boundaries
        If CanMove Then
            For i = 0 To 3
                If WorkArray(i, 0) < 0 Or WorkArray(i, 0) > 9 Then
                    CanMove = False
                End If
            Next
        End If

        ' Next check screen up/down boundaries
        If CanMove Then
            For i = 0 To 3
                If WorkArray(i, 1) < 0 Or WorkArray(i, 1) > 16 Then
                    CanMove = False
                End If
            Next
        End If

        ' Finally check if we trying to occupy a space which is already full
        If CanMove Then
            For i = 0 To 3
                If InternalPlayArea(WorkArray(i, 0), WorkArray(i, 1)) <> 0 And InternalPlayArea(WorkArray(i, 0), WorkArray(i, 1)) <> theblock.BlockCol.ToArgb Then
                    CanMove = False
                End If
            Next
        End If

    End Function


    Private Sub CheckForLine()

        ' Check lines by working from bottom up
        Dim i, j, k, BoxCount, LineCount As Integer
        Dim NewColor As Color
        i = 16
        LineCount = 0

        While i > 0

            BoxCount = 0
            For j = 0 To 9
                If InternalPlayArea(j, i) <> 0 Then BoxCount = BoxCount + 1
            Next

            If BoxCount = 10 Then
                LineCount = LineCount + 1
                ' Clear Line
                For k = i To 1 Step -1
                    For j = 0 To 9
                        InternalPlayArea(j, k) = InternalPlayArea(j, k - 1)
                        If InternalPlayArea(j, k) = 0 Then
                            subClearBox(j, k)
                        Else
                            NewColor.FromArgb(InternalPlayArea(j, k))
                            subDrawBox(j, k, NewColor)
                        End If

                    Next
                Next
            Else
                i = i - 1
            End If

        End While

        Select Case LineCount
            Case 1
                intScore = intScore + 10
            Case 2
                intScore = intScore + 50
            Case 3
                intScore = intScore + 250
            Case 4
                intScore = intScore + 400
        End Select

        intLines = intLines + LineCount

        'Increase the speed every ten lines, down to 100ms
        If (intLines > 0) And (Timer1.Interval > 100) Then
            If intLines >= ((intLevel * 10) + 10) Then
                intLevel = intLevel + 1
                Timer1.Interval = Timer1.Interval - 50
            End If
        End If

        txtScore.Text = Format(intScore, "#,##0")
        txtLines.Text = Format(intLines, "#,##0")

    End Sub


    ' Code


    Private Sub InitGame()
        GameOver.Visible = False
        Timer1.Enabled = False
        Dim i, j As Integer
        For i = 0 To 9
            For j = 0 To 16
                InternalPlayArea(i, j) = 0
            Next
        Next
        PlayArea.CreateGraphics.Clear(Color.White)

        intScore = 0
        intLines = 0
        txtScore.Text = 0.ToString
        txtLines.Text = 0.ToString

        Form1.KeyPreview = True

    End Sub

    Private Sub CreateNewBlock()
        CurrentBlock = New Block()
        CurrentBlock.Create()
        CurrentBlock.CurX = 4
        CurrentBlock.CurY = 0
        DrawBlock(CurrentBlock, "Draw")
    End Sub


    Public Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Form1.KeyDown

        Select Case e.KeyCode
            Case Keys.Left
                If CanMove(CurrentBlock, -1, 0) Then
                    DrawBlock(CurrentBlock, "Clear")
                    CurrentBlock.MoveLeft()
                    DrawBlock(CurrentBlock, "Draw")
                End If

            Case Keys.Right
                If CanMove(CurrentBlock, 1, 0) Then
                    DrawBlock(CurrentBlock, "Clear")
                    CurrentBlock.MoveRight()
                    DrawBlock(CurrentBlock, "Draw")
                End If


            Case Keys.Up
                DrawBlock(CurrentBlock, "Clear")
                CurrentBlock.Rotate()
                If CanMove(CurrentBlock, 0, 0) Then
                    DrawBlock(CurrentBlock, "Draw")
                Else
                    CurrentBlock.Unrotate()
                    DrawBlock(CurrentBlock, "Draw")
                End If

            Case Keys.Down
                Dim i As Integer
                For i = CurrentBlock.CurY To 16
                    If CanMove(CurrentBlock, 0, 1) Then
                        DrawBlock(CurrentBlock, "Clear")
                        CurrentBlock.MoveDown()
                        DrawBlock(CurrentBlock, "Draw")
                    End If
                Next

                JustLocked = False   ' Override JustLocked

        End Select

    End Sub

    Private Sub cmdPause_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPause.Click
        If bPaused = False Then
            bPaused = True
            Timer1.Stop()
            txtPaused.Visible = True
        Else
            Timer1.Start()
            bPaused = False
            txtPaused.Visible = False
        End If
    End Sub

    Private Sub cmdStart_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStart.Click

        InitGame()

        CreateNewBlock()
        Timer1.Interval = 800
        Timer1.Enabled = True
        cmdStart.Enabled = False
        cmdPause.Enabled = True

    End Sub

    Private Sub Timer1_Tick_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        ' Check if we can go down - else create new block
        If CanMove(CurrentBlock, 0, 1) Then
            DrawBlock(CurrentBlock, "Clear")
            CurrentBlock.MoveDown()
            DrawBlock(CurrentBlock, "Draw")
            JustLocked = False
        Else
            If JustLocked Then
                ' Game Over
                GameOver.Visible = True
                Timer1.Enabled = False
                cmdStart.Enabled = True
                cmdPause.Enabled = False

            Else
                DrawBlock(CurrentBlock, "Lock")
                CheckForLine()
                CreateNewBlock()
                JustLocked = True
            End If
        End If

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
