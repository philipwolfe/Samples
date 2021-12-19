Option Strict Off
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Resources



Public Class frmSnake
    Inherits System.Windows.Forms.Form
	Private mbGameOn As Boolean = False
	Private mbGameInit As Boolean = False
	Private mcSnake As clsSnake
	Const MOVE_INTERVAL = 300
	Const GRID_WIDTH = 12
	Const GRID_HEIGHT = 12
	Const START_SNAKE_LENGTH = 6
	Private crlf As String = CStr(strings.chr(10) & strings.chr(13))
	Public Sub New()
		MyBase.New()
		
		frmSnake = Me
		
		'This call is required by the Win Form Designer.
		InitializeComponent()
		
		'TODO: Add any initialization after the InitializeComponent() call
		Me.picMain.BackColor = Color.FromARGB(255, 255, 225)
		Me.picFly.BackColor = Color.FromARGB(255, 255, 225)
		
		
	End Sub
	
	'Form overrides dispose to clean up the component list.
	Public Overrides Sub Dispose()
		MyBase.Dispose()
		components.Dispose()
	End Sub
	
#Region " Windows Form Designer generated code "
	
	'Required by the Windows Form Designer
	Private components As System.ComponentModel.Container
    Private WithEvents picFly As System.Windows.Forms.PictureBox
    Private WithEvents cmdNewGame As System.Windows.Forms.Button
    Private WithEvents lblScoreCaption As System.Windows.Forms.Label
    Private WithEvents lblScore As System.Windows.Forms.Label
    Private WithEvents tmrSnake As System.Windows.Forms.Timer
    Private WithEvents picMain As System.Windows.Forms.PictureBox
    Dim WithEvents frmSnake As System.Windows.Forms.Form
	
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSnake))
		
		Me.components = New System.ComponentModel.Container()
        Me.lblScore = New System.Windows.Forms.Label()
        Me.tmrSnake = New System.Windows.Forms.Timer(components)
        Me.picFly = New System.Windows.Forms.PictureBox()
        Me.picMain = New System.Windows.Forms.PictureBox()
        Me.cmdNewGame = New System.Windows.Forms.Button()
        Me.lblScoreCaption = New System.Windows.Forms.Label()
		
		'@design Me.TrayHeight = 90
		'@design Me.TrayLargeIcon = False
		'@design Me.TrayAutoArrange = True
		lblScore.Location = New System.Drawing.Point(56, 4)
		lblScore.Text = "0"
		lblScore.Size = New System.Drawing.Size(36, 20)
        lblScore.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		lblScore.ForeColor = System.Drawing.SystemColors.HighlightText
		lblScore.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Bold)
		lblScore.TabIndex = 4
		lblScore.BackColor = System.Drawing.SystemColors.Highlight
        lblScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		
		'@design tmrSnake.SetLocation(New System.Drawing.Point(7, 7))
		
        picFly.Visible = False
        picFly.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		picFly.Location = New System.Drawing.Point(336, -8)
		picFly.Size = New System.Drawing.Size(42, 42)
		picFly.TabIndex = 7
        picFly.TabStop = False
        Dim bug = New Bitmap(Environment.CurrentDirectory + "\bitmap1.bmp")
        picFly.Image = CType(bug, System.Drawing.Image)

        picMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		picMain.BackColor = System.Drawing.SystemColors.Control
		picMain.Location = New System.Drawing.Point(4, 24)
		picMain.Size = New System.Drawing.Size(324, 360)
		picMain.TabIndex = 0
		picMain.TabStop = False
		
		cmdNewGame.Location = New System.Drawing.Point(96, 0)
		cmdNewGame.Size = New System.Drawing.Size(84, 24)
		cmdNewGame.TabIndex = 6
		cmdNewGame.Text = "New Game"
		
		lblScoreCaption.Location = New System.Drawing.Point(4, 8)
		lblScoreCaption.Text = "Score:"
		lblScoreCaption.Size = New System.Drawing.Size(51, 16)
		lblScoreCaption.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Bold)
		lblScoreCaption.TabIndex = 5
		Me.Text = "Visual Basic Snake Game"
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.KeyPreview = True
		Me.ClientSize = New System.Drawing.Size(448, 469)
		
		Me.Controls.Add(picFly)
		Me.Controls.Add(cmdNewGame)
		Me.Controls.Add(lblScoreCaption)
		Me.Controls.Add(lblScore)
		Me.Controls.Add(picMain)
	End Sub
	
#End Region
	
	
    Protected Sub cmdNewGame_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdNewGame.click
        Me.lblScore.Text = "0"
        Dim sCRLF As String = Chr(13) & Chr(10)
        Dim sMsg As String
        sMsg = "The goal is to eat as many flys as you can without crashing into yourself or the wall." & sCRLF
        sMsg = sMsg & "Each time you eat a fly, your tail will grow by one square." & sCRLF
        sMsg = sMsg & "Your direction can be changed using the number pad numbers 8,4,6, and 2." & sCRLF
        sMsg = sMsg & "After this box closes hit one of the number keys to begin.  You can hit the 5 key to pause."
        MsgBox(sMsg, , Me.Text)
        mcSnake = New clsSnake(GRID_WIDTH, GRID_HEIGHT, START_SNAKE_LENGTH, Me.picMain, Me.picFly)


        mbGameOn = True
        mcSnake.PaintSnake()
        Me.tmrSnake.Enabled = True

    End Sub


    Protected Sub frmSnake_Resize(ByVal sender As Object, ByVal e As System.EventArgs)


        Me.picMain.Top = Me.lblScore.Height + Me.lblScore.Top + 4
        Me.picMain.Left = 4
        Me.picMain.Width = Me.ClientRectangle.Width - Me.picMain.Left * 2
        Me.picMain.Height = Me.ClientRectangle.Height - Me.picMain.Top - 4
    End Sub

    Protected Sub tmrSnake_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrSnake.tick
        Try

            If mbGameInit = False Then Exit Sub
            mcSnake.applyNextMove()
            Me.lblScore.Text = mcSnake.Score
            If mcSnake.GameOver Then
                tmrSnake.Enabled = False
                MsgBox("Game Over")
            End If
        Catch oErr As Exception
            ' Do nothing			
            MessageBox.Show(oErr.Message.ToString())
        End Try
    End Sub

    Protected Sub frmSnake_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles frmSnake.KeyPress
        Dim bGotMove As Boolean
        If mbGameOn = False Then Exit Sub


        Select Case CStr(e.KeyChar)
            Case "8"
                mcSnake.addMove(deltaY:=-1)
                bGotMove = True
            Case "2"
                mcSnake.addMove(deltaY:=+1)
                bGotMove = True
            Case "4"
                mcSnake.addMove(deltaX:=-1)
                bGotMove = True
            Case "6"
                mcSnake.addMove(deltaX:=+1)
                bGotMove = True
            Case "5", "32"
                ' Freeze the game
                mbGameInit = False
        End Select
        If bGotMove = True Then
            If mbGameInit = False And CStr(e.KeyChar) <> "5" And CStr(e.KeyChar) <> "32" Then
                mbGameInit = True
                tmrSnake.Interval = MOVE_INTERVAL
                tmrSnake.Enabled = True
            End If
        End If
    End Sub

End Class


