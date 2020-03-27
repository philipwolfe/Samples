'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text

Public Class frmMain
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        ' So that we only need to set the title of the application once,
        ' we use the AssemblyInfo class (defined in the AssemblyInfo.vb file)
        ' to read the AssemblyTitle attribute.
        Dim ainfo As New AssemblyInfo()

        Me.Text = ainfo.Title
        Me.mnuAbout.Text = String.Format("&About {0} ...", ainfo.Title)

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
    Friend WithEvents mnuMain As System.Windows.Forms.MainMenu
    Friend WithEvents mnuFile As System.Windows.Forms.MenuItem
    Friend WithEvents mnuExit As System.Windows.Forms.MenuItem
    Friend WithEvents mnuHelp As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAbout As System.Windows.Forms.MenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents optWink As System.Windows.Forms.RadioButton
    Friend WithEvents optBall As System.Windows.Forms.RadioButton
    Friend WithEvents tmrAnimation As System.Windows.Forms.Timer
    Friend WithEvents optText As System.Windows.Forms.RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.tmrAnimation = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.optWink = New System.Windows.Forms.RadioButton()
        Me.optBall = New System.Windows.Forms.RadioButton()
        Me.optText = New System.Windows.Forms.RadioButton()
        Me.SuspendLayout()
        '
        'mnuMain
        '
        Me.mnuMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.mnuHelp})
        Me.mnuMain.RightToLeft = CType(resources.GetObject("mnuMain.RightToLeft"), System.Windows.Forms.RightToLeft)
        '
        'mnuFile
        '
        Me.mnuFile.Enabled = CType(resources.GetObject("mnuFile.Enabled"), Boolean)
        Me.mnuFile.Index = 0
        Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuExit})
        Me.mnuFile.Shortcut = CType(resources.GetObject("mnuFile.Shortcut"), System.Windows.Forms.Shortcut)
        Me.mnuFile.ShowShortcut = CType(resources.GetObject("mnuFile.ShowShortcut"), Boolean)
        Me.mnuFile.Text = resources.GetString("mnuFile.Text")
        Me.mnuFile.Visible = CType(resources.GetObject("mnuFile.Visible"), Boolean)
        '
        'mnuExit
        '
        Me.mnuExit.Enabled = CType(resources.GetObject("mnuExit.Enabled"), Boolean)
        Me.mnuExit.Index = 0
        Me.mnuExit.Shortcut = CType(resources.GetObject("mnuExit.Shortcut"), System.Windows.Forms.Shortcut)
        Me.mnuExit.ShowShortcut = CType(resources.GetObject("mnuExit.ShowShortcut"), Boolean)
        Me.mnuExit.Text = resources.GetString("mnuExit.Text")
        Me.mnuExit.Visible = CType(resources.GetObject("mnuExit.Visible"), Boolean)
        '
        'mnuHelp
        '
        Me.mnuHelp.Enabled = CType(resources.GetObject("mnuHelp.Enabled"), Boolean)
        Me.mnuHelp.Index = 1
        Me.mnuHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAbout})
        Me.mnuHelp.Shortcut = CType(resources.GetObject("mnuHelp.Shortcut"), System.Windows.Forms.Shortcut)
        Me.mnuHelp.ShowShortcut = CType(resources.GetObject("mnuHelp.ShowShortcut"), Boolean)
        Me.mnuHelp.Text = resources.GetString("mnuHelp.Text")
        Me.mnuHelp.Visible = CType(resources.GetObject("mnuHelp.Visible"), Boolean)
        '
        'mnuAbout
        '
        Me.mnuAbout.Enabled = CType(resources.GetObject("mnuAbout.Enabled"), Boolean)
        Me.mnuAbout.Index = 0
        Me.mnuAbout.Shortcut = CType(resources.GetObject("mnuAbout.Shortcut"), System.Windows.Forms.Shortcut)
        Me.mnuAbout.ShowShortcut = CType(resources.GetObject("mnuAbout.ShowShortcut"), Boolean)
        Me.mnuAbout.Text = resources.GetString("mnuAbout.Text")
        Me.mnuAbout.Visible = CType(resources.GetObject("mnuAbout.Visible"), Boolean)
        '
        'tmrAnimation
        '
        Me.tmrAnimation.Enabled = True
        '
        'Label1
        '
        Me.Label1.AccessibleDescription = CType(resources.GetObject("Label1.AccessibleDescription"), String)
        Me.Label1.AccessibleName = CType(resources.GetObject("Label1.AccessibleName"), String)
        Me.Label1.Anchor = CType(resources.GetObject("Label1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = CType(resources.GetObject("Label1.AutoSize"), Boolean)
        Me.Label1.Dock = CType(resources.GetObject("Label1.Dock"), System.Windows.Forms.DockStyle)
        Me.Label1.Enabled = CType(resources.GetObject("Label1.Enabled"), Boolean)
        Me.Label1.Font = CType(resources.GetObject("Label1.Font"), System.Drawing.Font)
        Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
        Me.Label1.ImageAlign = CType(resources.GetObject("Label1.ImageAlign"), System.Drawing.ContentAlignment)
        Me.Label1.ImageIndex = CType(resources.GetObject("Label1.ImageIndex"), Integer)
        Me.Label1.ImeMode = CType(resources.GetObject("Label1.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Label1.Location = CType(resources.GetObject("Label1.Location"), System.Drawing.Point)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = CType(resources.GetObject("Label1.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Label1.Size = CType(resources.GetObject("Label1.Size"), System.Drawing.Size)
        Me.Label1.TabIndex = CType(resources.GetObject("Label1.TabIndex"), Integer)
        Me.Label1.Text = resources.GetString("Label1.Text")
        Me.Label1.TextAlign = CType(resources.GetObject("Label1.TextAlign"), System.Drawing.ContentAlignment)
        Me.Label1.Visible = CType(resources.GetObject("Label1.Visible"), Boolean)
        '
        'optWink
        '
        Me.optWink.AccessibleDescription = resources.GetString("optWink.AccessibleDescription")
        Me.optWink.AccessibleName = resources.GetString("optWink.AccessibleName")
        Me.optWink.Anchor = CType(resources.GetObject("optWink.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.optWink.Appearance = CType(resources.GetObject("optWink.Appearance"), System.Windows.Forms.Appearance)
        Me.optWink.BackgroundImage = CType(resources.GetObject("optWink.BackgroundImage"), System.Drawing.Image)
        Me.optWink.CheckAlign = CType(resources.GetObject("optWink.CheckAlign"), System.Drawing.ContentAlignment)
        Me.optWink.Checked = True
        Me.optWink.Dock = CType(resources.GetObject("optWink.Dock"), System.Windows.Forms.DockStyle)
        Me.optWink.Enabled = CType(resources.GetObject("optWink.Enabled"), Boolean)
        Me.optWink.FlatStyle = CType(resources.GetObject("optWink.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.optWink.Font = CType(resources.GetObject("optWink.Font"), System.Drawing.Font)
        Me.optWink.Image = CType(resources.GetObject("optWink.Image"), System.Drawing.Image)
        Me.optWink.ImageAlign = CType(resources.GetObject("optWink.ImageAlign"), System.Drawing.ContentAlignment)
        Me.optWink.ImageIndex = CType(resources.GetObject("optWink.ImageIndex"), Integer)
        Me.optWink.ImeMode = CType(resources.GetObject("optWink.ImeMode"), System.Windows.Forms.ImeMode)
        Me.optWink.Location = CType(resources.GetObject("optWink.Location"), System.Drawing.Point)
        Me.optWink.Name = "optWink"
        Me.optWink.RightToLeft = CType(resources.GetObject("optWink.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.optWink.Size = CType(resources.GetObject("optWink.Size"), System.Drawing.Size)
        Me.optWink.TabIndex = CType(resources.GetObject("optWink.TabIndex"), Integer)
        Me.optWink.TabStop = True
        Me.optWink.Text = resources.GetString("optWink.Text")
        Me.optWink.TextAlign = CType(resources.GetObject("optWink.TextAlign"), System.Drawing.ContentAlignment)
        Me.optWink.Visible = CType(resources.GetObject("optWink.Visible"), Boolean)
        '
        'optBall
        '
        Me.optBall.AccessibleDescription = resources.GetString("optBall.AccessibleDescription")
        Me.optBall.AccessibleName = resources.GetString("optBall.AccessibleName")
        Me.optBall.Anchor = CType(resources.GetObject("optBall.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.optBall.Appearance = CType(resources.GetObject("optBall.Appearance"), System.Windows.Forms.Appearance)
        Me.optBall.BackgroundImage = CType(resources.GetObject("optBall.BackgroundImage"), System.Drawing.Image)
        Me.optBall.CheckAlign = CType(resources.GetObject("optBall.CheckAlign"), System.Drawing.ContentAlignment)
        Me.optBall.Dock = CType(resources.GetObject("optBall.Dock"), System.Windows.Forms.DockStyle)
        Me.optBall.Enabled = CType(resources.GetObject("optBall.Enabled"), Boolean)
        Me.optBall.FlatStyle = CType(resources.GetObject("optBall.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.optBall.Font = CType(resources.GetObject("optBall.Font"), System.Drawing.Font)
        Me.optBall.Image = CType(resources.GetObject("optBall.Image"), System.Drawing.Image)
        Me.optBall.ImageAlign = CType(resources.GetObject("optBall.ImageAlign"), System.Drawing.ContentAlignment)
        Me.optBall.ImageIndex = CType(resources.GetObject("optBall.ImageIndex"), Integer)
        Me.optBall.ImeMode = CType(resources.GetObject("optBall.ImeMode"), System.Windows.Forms.ImeMode)
        Me.optBall.Location = CType(resources.GetObject("optBall.Location"), System.Drawing.Point)
        Me.optBall.Name = "optBall"
        Me.optBall.RightToLeft = CType(resources.GetObject("optBall.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.optBall.Size = CType(resources.GetObject("optBall.Size"), System.Drawing.Size)
        Me.optBall.TabIndex = CType(resources.GetObject("optBall.TabIndex"), Integer)
        Me.optBall.Text = resources.GetString("optBall.Text")
        Me.optBall.TextAlign = CType(resources.GetObject("optBall.TextAlign"), System.Drawing.ContentAlignment)
        Me.optBall.Visible = CType(resources.GetObject("optBall.Visible"), Boolean)
        '
        'optText
        '
        Me.optText.AccessibleDescription = resources.GetString("optText.AccessibleDescription")
        Me.optText.AccessibleName = resources.GetString("optText.AccessibleName")
        Me.optText.Anchor = CType(resources.GetObject("optText.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.optText.Appearance = CType(resources.GetObject("optText.Appearance"), System.Windows.Forms.Appearance)
        Me.optText.BackgroundImage = CType(resources.GetObject("optText.BackgroundImage"), System.Drawing.Image)
        Me.optText.CheckAlign = CType(resources.GetObject("optText.CheckAlign"), System.Drawing.ContentAlignment)
        Me.optText.Dock = CType(resources.GetObject("optText.Dock"), System.Windows.Forms.DockStyle)
        Me.optText.Enabled = CType(resources.GetObject("optText.Enabled"), Boolean)
        Me.optText.FlatStyle = CType(resources.GetObject("optText.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.optText.Font = CType(resources.GetObject("optText.Font"), System.Drawing.Font)
        Me.optText.Image = CType(resources.GetObject("optText.Image"), System.Drawing.Image)
        Me.optText.ImageAlign = CType(resources.GetObject("optText.ImageAlign"), System.Drawing.ContentAlignment)
        Me.optText.ImageIndex = CType(resources.GetObject("optText.ImageIndex"), Integer)
        Me.optText.ImeMode = CType(resources.GetObject("optText.ImeMode"), System.Windows.Forms.ImeMode)
        Me.optText.Location = CType(resources.GetObject("optText.Location"), System.Drawing.Point)
        Me.optText.Name = "optText"
        Me.optText.RightToLeft = CType(resources.GetObject("optText.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.optText.Size = CType(resources.GetObject("optText.Size"), System.Drawing.Size)
        Me.optText.TabIndex = CType(resources.GetObject("optText.TabIndex"), Integer)
        Me.optText.Text = resources.GetString("optText.Text")
        Me.optText.TextAlign = CType(resources.GetObject("optText.TextAlign"), System.Drawing.ContentAlignment)
        Me.optText.Visible = CType(resources.GetObject("optText.Visible"), Boolean)
        '
        'frmMain
        '
        Me.AccessibleDescription = CType(resources.GetObject("$this.AccessibleDescription"), String)
        Me.AccessibleName = CType(resources.GetObject("$this.AccessibleName"), String)
        Me.Anchor = CType(resources.GetObject("$this.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.AutoScaleBaseSize = CType(resources.GetObject("$this.AutoScaleBaseSize"), System.Drawing.Size)
        Me.AutoScroll = CType(resources.GetObject("$this.AutoScroll"), Boolean)
        Me.AutoScrollMargin = CType(resources.GetObject("$this.AutoScrollMargin"), System.Drawing.Size)
        Me.AutoScrollMinSize = CType(resources.GetObject("$this.AutoScrollMinSize"), System.Drawing.Size)
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = CType(resources.GetObject("$this.ClientSize"), System.Drawing.Size)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.optText, Me.optBall, Me.optWink, Me.Label1})
        Me.Dock = CType(resources.GetObject("$this.Dock"), System.Windows.Forms.DockStyle)
        Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
        Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Location = CType(resources.GetObject("$this.Location"), System.Drawing.Point)
        Me.MaximizeBox = False
        Me.MaximumSize = CType(resources.GetObject("$this.MaximumSize"), System.Drawing.Size)
        Me.Menu = Me.mnuMain
        Me.MinimumSize = CType(resources.GetObject("$this.MinimumSize"), System.Drawing.Size)
        Me.Name = "frmMain"
        Me.RightToLeft = CType(resources.GetObject("$this.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.StartPosition = CType(resources.GetObject("$this.StartPosition"), System.Windows.Forms.FormStartPosition)
        Me.Text = resources.GetString("$this.Text")
        Me.Visible = CType(resources.GetObject("$this.Visible"), Boolean)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Standard Menu Code "
    ' <System.Diagnostics.DebuggerStepThrough()> has been added to some procedures since they are
    ' not the focus of the demo. Remove them if you wish to debug the procedures.
    ' This code simply shows the About form.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub mnuAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAbout.Click
        ' Open the About form in Dialog Mode
        Dim frm As New frmAbout()
        frm.ShowDialog(Me)
        frm.Dispose()
    End Sub

    ' This code will close the form.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
        ' Close the current form
        Me.Close()
    End Sub
#End Region

    Const WINK_TIMER_INTERVAL As Integer = 150 ' In milliseconds
    Protected arrImages(4) As Image
    Protected intCurrentImage As Integer = 0
    Protected j As Integer = 1

    Const BALL_TIMER_INTERVAL As Integer = 25 ' In milliseconds
    Private intBallSize As Integer = 16 ' As fraction of client area
    Private intMoveSize As Integer = 4 ' As fraction of ball size
    Private bitmap As bitmap
    Private intBallPositionX, intBallPositionY As Integer
    Private intBallRadiusX, intBallRadiusY, intBallMoveX, intBallMoveY, _
        intBallBitmapWidth, intBallBitmapHeight As Integer
    Private intBitmapWidthMargin, intBitmapHeightMargin As Integer

    Const TEXT_TIMER_INTERVAL As Integer = 15 ' In milliseconds
    Protected intCurrentGradientShift As Integer = 10
    Protected intGradiantStep As Integer = 5

    ' This subroutine handles the Load event for the Form.
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Fills the image array for the Winking Eye example.
        Dim i As Integer
        For i = 0 To 3
            arrImages(i) = New bitmap("..\Eye" & (i + 1).ToString & ".png")
        Next i
    End Sub

    ' This subroutine handles the CheckChanged event for the radio buttons.
    Private Sub RadioButtons_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles optWink.CheckedChanged, optBall.CheckedChanged
        If optWink.Checked Then
            tmrAnimation.Interval = WINK_TIMER_INTERVAL
        ElseIf optBall.Checked Then
            tmrAnimation.Interval = BALL_TIMER_INTERVAL
        ElseIf optText.Checked Then
            tmrAnimation.Interval = TEXT_TIMER_INTERVAL
        End If

        OnResize(EventArgs.Empty)
    End Sub

    ' This subroutine handles the Tick event for the Timer. 
    ' This is where the animation takes place.
    Protected Overridable Sub TimerOnTick(ByVal obj As Object, ByVal ea As EventArgs) Handles tmrAnimation.Tick

        If optWink.Checked Then

            ' Obtain the Graphics object exposed by the Form.
            Dim grfx As Graphics = CreateGraphics()

            ' Call DrawImage, using Overload #8, which takes the current image to be
            ' displayed, the X and Y coordinates (which, in this case centers the 
            ' image in the client area), and the image's width and height.
            grfx.DrawImage(arrImages(intCurrentImage), _
                CInt((ClientSize.Width - arrImages(intCurrentImage).Width) / 2), _
                CInt((ClientSize.Height - arrImages(intCurrentImage).Height) / 2), _
                arrImages(intCurrentImage).Width, _
                arrImages(intCurrentImage).Height)
            ' It is always a good idea to call Dispose for objects that expose this
            ' method instead of waiting for the Garbage Collector to do it for you.
            ' This almost always increases the application's performance.
            grfx.Dispose()

            ' Loop through the images.
            intCurrentImage += j
            If intCurrentImage = 3 Then
                ' This is the last image of the four, so reverse the animation
                ' order so that the eye closes.
                j = -1
            ElseIf intCurrentImage = 0 Then
                ' This is the first image of the four, so reverse the animation
                ' order so that the eye opens again.
                j = 1
            End If

        ElseIf optBall.Checked Then

            ' Obtain the Graphics object exposed by the Form.
            Dim grfx As Graphics = CreateGraphics()
            ' Draw the bitmap containing the ball on the Form.
            grfx.DrawImage(bitmap, _
                CInt(intBallPositionX - intBallBitmapWidth / 2), _
                CInt(intBallPositionY - intBallBitmapHeight / 2), _
                intBallBitmapWidth, intBallBitmapHeight)
            
            grfx.Dispose()

            ' Increment the ball position by the distance it has
            ' moved in both X and Y after being redrawn.
            intBallPositionX += intBallMoveX
            intBallPositionY += intBallMoveY

            ' Reverse the ball's direction when it hits a boundary.
            If intBallPositionX + intBallRadiusX >= ClientSize.Width _
                Or intBallPositionX - intBallRadiusX <= 0 Then
                intBallMoveX = -intBallMoveX
                Beep()
            End If
            ' Set the Y boundary at 40 instead of 0 so the ball does not bounce
            ' into controls on the Form.
            If intBallPositionY + intBallRadiusY >= ClientSize.Height _
                Or intBallPositionY - intBallRadiusY <= 40 Then
                intBallMoveY = -intBallMoveY
                Beep()
            End If

        ElseIf optText.Checked Then

            ' Obtain the Graphics object exposed by the Form.
            Dim grfx As Graphics = CreateGraphics()

            ' Set the font type, text, and determine its size.
            Dim font As New font("Microsoft Sans Serif", 96, _
                FontStyle.Bold, GraphicsUnit.Point)
            Dim strText As String = "GDI+!"
            Dim sizfText As New SizeF(grfx.MeasureString(strText, font))

            ' Set the point at which the text will be drawn: centered
            ' in the client area.
            Dim ptfTextStart As New PointF( _
                CSng(ClientSize.Width - sizfText.Width) / 2, _
                CSng(ClientSize.Height - sizfText.Height) / 2)

            ' Set the gradient start and end point, the latter being adjusted
            ' by a changing value to give the animation affect.
            Dim ptfGradientStart As New PointF(0, 0)
            Dim ptfGradientEnd As New PointF(intCurrentGradientShift, 200)

            ' Instantiate the brush used for drawing the text.
            Dim grBrush As New LinearGradientBrush(ptfGradientStart, _
                ptfGradientEnd, Color.Blue, BackColor)

            ' Draw the text centered on the client area.
            grfx.DrawString(strText, font, grBrush, ptfTextStart)

            grfx.Dispose()

            ' Shift the gradient, reversing it when it gets to a certain value.
            intCurrentGradientShift += intGradiantStep
            If intCurrentGradientShift = 500 Then
                intGradiantStep = -5
            ElseIf intCurrentGradientShift = -50 Then
                intGradiantStep = 5
            End If
        End If
    End Sub

    ' This method overrides the OnResize method in the base Control class. OnResize 
    ' raises the Resize event, which occurs when the control (in this case, the 
    ' Form) is resized.
    Protected Overrides Sub OnResize(ByVal ea As EventArgs)
        If optWink.Checked Then

            ' Obtain the Graphics object exposed by the Form and erase any drawings.
            Dim grfx As Graphics = CreateGraphics()
            ' You could also call grfx.Clear(BackColor) or Me.Invalidate() to clear
            ' off the screen.
            Me.Refresh()
            grfx.Dispose()

        ElseIf optBall.Checked Then

            ' Obtain the Graphics object exposed by the Form and erase any drawings.
            Dim grfx As Graphics = CreateGraphics()
            grfx.Clear(BackColor)

            ' Set the radius of the ball to a fraction of the width or height
            ' of the client area, whichever is less.
            Dim dblRadius As Double = Math.Min(ClientSize.Width / grfx.DpiX, _
                ClientSize.Height / grfx.DpiY) / intBallSize

            ' Set the width and height of the ball as in most cases the DPI is
            ' identical in the X and Y axes.
            intBallRadiusX = CInt(dblRadius * grfx.DpiX)
            intBallRadiusY = CInt(dblRadius * grfx.DpiY)

            grfx.Dispose()

            ' Set the distance the ball moves to 1 pixel or a fraction of the
            ' ball's size, whichever is greater. This means that the distance the 
            ' ball moves each time it is drawn is proportional to its size, which 
            ' is, in turn, proportional to the size of the client area. Thus, when 
            ' the client area is shrunk the ball slows down, and when it is 
            ' increased, the ball speeds up. 
            intBallMoveX = CInt(Math.Max(1, intBallRadiusX / intMoveSize))
            intBallMoveY = CInt(Math.Max(1, intBallRadiusY / intMoveSize))

            ' Notice that the value of the ball's movement also serves as the
            ' margin around the ball, which determines the size of the actual 
            ' bitmap on which the ball is drawn. Thus, the distance the ball moves 
            ' is exactly equal to the size of the bitmap, which permits the previous 
            ' image of the ball to be erased before the next image is drawn, all 
            ' without an inordinate amount of flickering.
            intBitmapWidthMargin = intBallMoveX
            intBitmapHeightMargin = intBallMoveY

            ' Determine the actual size of the Bitmap on which the ball is drawn by
            ' adding the margins to the ball's dimensions.
            intBallBitmapWidth = 2 * (intBallRadiusX + intBitmapWidthMargin)
            intBallBitmapHeight = 2 * (intBallRadiusY + intBitmapHeightMargin)

            ' Create a new bitmap, passing in the width and height
            bitmap = New bitmap(intBallBitmapWidth, intBallBitmapHeight)

            ' Obtain the Graphics object exposed by the Bitmap, clear the existing 
            ' ball, and draw the new ball.
            grfx = Graphics.FromImage(bitmap)
            With grfx
                .Clear(BackColor)
                .FillEllipse(Brushes.Red, New Rectangle(intBallMoveX, _
                    intBallMoveY, 2 * intBallRadiusX, 2 * intBallRadiusY))
                .Dispose()
            End With

            ' Reset the ball's position to the center of the client area.
            intBallPositionX = CInt(ClientSize.Width / 2)
            intBallPositionY = CInt(ClientSize.Height / 2)

        ElseIf optText.Checked Then
            ' Obtain the Graphics object exposed by the Form and erase any drawings.
            Dim grfx As Graphics = CreateGraphics()
            grfx.Clear(BackColor)
        End If
    End Sub
End Class