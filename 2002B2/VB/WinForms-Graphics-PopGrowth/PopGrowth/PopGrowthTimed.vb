
Imports System.Drawing
Imports System.Windows.Forms


Imports System.ComponentModel


Public Class PopGrowthTimed
    
    Inherits System.Windows.Forms.Form
    
    Private Const Generations As Byte = 100
    Private Const Margin As Integer = 3
    
    Public Sub New()
        MyBase.New()
        
        PopGrowth = Me
        
        'This call is required by the Win Form Designer.
        InitializeComponent()
        
        chkAuto.Checked = True
    End Sub
    
    'Form overrides dispose to clean up the component list.
    Public Overloads Overrides Sub Dispose()
        MyBase.Dispose()
        components.Dispose()
    End Sub
    Private components As System.ComponentModel.IContainer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFormula As System.Windows.Forms.TextBox
    Friend WithEvents lblFormula As System.Windows.Forms.Label
    Friend WithEvents lblK As System.Windows.Forms.Label
    Friend WithEvents txtK As System.Windows.Forms.TextBox
    Friend WithEvents Timer As System.Windows.Forms.Timer
    Friend WithEvents optPoint As System.Windows.Forms.RadioButton
    Friend WithEvents optLine As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkRun As System.Windows.Forms.CheckBox
    Friend WithEvents chkPause As System.Windows.Forms.CheckBox
    Friend WithEvents cmdStop As System.Windows.Forms.Button
    Friend WithEvents updnSpeed As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkAuto As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents pnlControl As System.Windows.Forms.Panel
    Friend WithEvents pic As System.Windows.Forms.PictureBox
    Friend WithEvents TrackBar As System.Windows.Forms.TrackBar
    Friend WithEvents pnlDisplay As System.Windows.Forms.Panel
    Friend WithEvents pnlEmpty As System.Windows.Forms.Panel

#Region " Windows Form Designer generated code "

    'Required by the Windows Form Designer














































































    Dim WithEvents PopGrowth As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.pnlDisplay = New System.Windows.Forms.Panel()
        Me.pic = New System.Windows.Forms.PictureBox()
        Me.TrackBar = New System.Windows.Forms.TrackBar()
        Me.lblFormula = New System.Windows.Forms.Label()
        Me.chkAuto = New System.Windows.Forms.CheckBox()
        Me.txtFormula = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.optLine = New System.Windows.Forms.RadioButton()
        Me.optPoint = New System.Windows.Forms.RadioButton()
        Me.pnlControl = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.updnSpeed = New System.Windows.Forms.NumericUpDown()
        Me.cmdStop = New System.Windows.Forms.Button()
        Me.chkPause = New System.Windows.Forms.CheckBox()
        Me.chkRun = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtK = New System.Windows.Forms.TextBox()
        Me.lblK = New System.Windows.Forms.Label()
        Me.pnlEmpty = New System.Windows.Forms.Panel()
        Me.Timer = New System.Windows.Forms.Timer(Me.components)
        Me.pnlDisplay.SuspendLayout()
        CType(Me.TrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.pnlControl.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.updnSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.updnSpeed.SuspendLayout()
        Me.pnlEmpty.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlDisplay
        '
        Me.pnlDisplay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlDisplay.Controls.AddRange(New System.Windows.Forms.Control() {Me.pic, Me.TrackBar})
        Me.pnlDisplay.Location = New System.Drawing.Point(16, 7)
        Me.pnlDisplay.Name = "pnlDisplay"
        Me.pnlDisplay.Size = New System.Drawing.Size(392, 222)
        Me.pnlDisplay.TabIndex = 24
        '
        'pic
        '
        Me.pic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pic.Dock = System.Windows.Forms.DockStyle.Top
        Me.pic.Name = "pic"
        Me.pic.Size = New System.Drawing.Size(388, 162)
        Me.pic.TabIndex = 1
        Me.pic.TabStop = False
        '
        'TrackBar
        '
        Me.TrackBar.AutoSize = False
        Me.TrackBar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TrackBar.Location = New System.Drawing.Point(0, 173)
        Me.TrackBar.Maximum = 4000
        Me.TrackBar.Name = "TrackBar"
        Me.TrackBar.Size = New System.Drawing.Size(388, 45)
        Me.TrackBar.SmallChange = 100
        Me.TrackBar.TabIndex = 0
        Me.TrackBar.TickFrequency = 100
        '
        'lblFormula
        '
        Me.lblFormula.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblFormula.Location = New System.Drawing.Point(5, 257)
        Me.lblFormula.Name = "lblFormula"
        Me.lblFormula.Size = New System.Drawing.Size(93, 22)
        Me.lblFormula.TabIndex = 2
        Me.lblFormula.Text = "Formula"
        '
        'chkAuto
        '
        Me.chkAuto.Location = New System.Drawing.Point(7, 44)
        Me.chkAuto.Name = "chkAuto"
        Me.chkAuto.Size = New System.Drawing.Size(86, 22)
        Me.chkAuto.TabIndex = 1
        Me.chkAuto.Text = "Automatic"
        '
        'txtFormula
        '
        Me.txtFormula.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtFormula.Location = New System.Drawing.Point(5, 234)
        Me.txtFormula.Name = "txtFormula"
        Me.txtFormula.Size = New System.Drawing.Size(93, 23)
        Me.txtFormula.TabIndex = 3
        Me.txtFormula.Text = "x2 = Kx(1-x)"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.optLine, Me.optPoint})
        Me.GroupBox2.Location = New System.Drawing.Point(7, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(93, 66)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Graph"
        '
        'optLine
        '
        Me.optLine.Location = New System.Drawing.Point(13, 37)
        Me.optLine.Name = "optLine"
        Me.optLine.Size = New System.Drawing.Size(53, 15)
        Me.optLine.TabIndex = 1
        Me.optLine.Text = "Line"
        '
        'optPoint
        '
        Me.optPoint.Checked = True
        Me.optPoint.Location = New System.Drawing.Point(13, 18)
        Me.optPoint.Name = "optPoint"
        Me.optPoint.Size = New System.Drawing.Size(60, 15)
        Me.optPoint.TabIndex = 0
        Me.optPoint.TabStop = True
        Me.optPoint.Text = "Points"
        '
        'pnlControl
        '
        Me.pnlControl.BackColor = System.Drawing.Color.Transparent
        Me.pnlControl.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox1, Me.cmdStop, Me.chkPause, Me.chkRun, Me.GroupBox2})
        Me.pnlControl.Location = New System.Drawing.Point(16, 243)
        Me.pnlControl.Name = "pnlControl"
        Me.pnlControl.Size = New System.Drawing.Size(385, 74)
        Me.pnlControl.TabIndex = 23
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkAuto, Me.updnSpeed})
        Me.GroupBox1.Location = New System.Drawing.Point(288, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(93, 66)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Speed"
        '
        'updnSpeed
        '
        Me.updnSpeed.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.updnSpeed.Location = New System.Drawing.Point(7, 18)
        Me.updnSpeed.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.updnSpeed.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.updnSpeed.Name = "updnSpeed"
        Me.updnSpeed.Size = New System.Drawing.Size(79, 23)
        Me.updnSpeed.TabIndex = 0
        Me.updnSpeed.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'cmdStop
        '
        Me.cmdStop.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdStop.BackColor = System.Drawing.SystemColors.Control
        Me.cmdStop.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdStop.Location = New System.Drawing.Point(222, 22)
        Me.cmdStop.Name = "cmdStop"
        Me.cmdStop.Size = New System.Drawing.Size(59, 37)
        Me.cmdStop.TabIndex = 18
        Me.cmdStop.Text = "Stop"
        Me.cmdStop.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'chkPause
        '
        Me.chkPause.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.chkPause.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkPause.BackColor = System.Drawing.SystemColors.Control
        Me.chkPause.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.chkPause.Location = New System.Drawing.Point(164, 22)
        Me.chkPause.Name = "chkPause"
        Me.chkPause.Size = New System.Drawing.Size(58, 37)
        Me.chkPause.TabIndex = 19
        Me.chkPause.Text = "Pause"
        Me.chkPause.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'chkRun
        '
        Me.chkRun.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.chkRun.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkRun.BackColor = System.Drawing.SystemColors.Control
        Me.chkRun.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.chkRun.Location = New System.Drawing.Point(106, 22)
        Me.chkRun.Name = "chkRun"
        Me.chkRun.Size = New System.Drawing.Size(58, 37)
        Me.chkRun.TabIndex = 20
        Me.chkRun.Text = "Run"
        Me.chkRun.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!)
        Me.Label2.Location = New System.Drawing.Point(5, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 229)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "where x2, the population at the next generation, is equal to the population in th" & _
        "is generation times a constant times the difference between this generations pop" & _
        "ulation and one"
        '
        'txtK
        '
        Me.txtK.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtK.Location = New System.Drawing.Point(5, 305)
        Me.txtK.Name = "txtK"
        Me.txtK.Size = New System.Drawing.Size(93, 23)
        Me.txtK.TabIndex = 0
        Me.txtK.Text = ""
        '
        'lblK
        '
        Me.lblK.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblK.Location = New System.Drawing.Point(5, 328)
        Me.lblK.Name = "lblK"
        Me.lblK.Size = New System.Drawing.Size(93, 22)
        Me.lblK.TabIndex = 1
        Me.lblK.Text = "K Value"
        '
        'pnlEmpty
        '
        Me.pnlEmpty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlEmpty.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblFormula, Me.txtFormula, Me.txtK, Me.lblK, Me.Label2})
        Me.pnlEmpty.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlEmpty.DockPadding.All = 5
        Me.pnlEmpty.Location = New System.Drawing.Point(411, 4)
        Me.pnlEmpty.Name = "pnlEmpty"
        Me.pnlEmpty.Size = New System.Drawing.Size(107, 359)
        Me.pnlEmpty.TabIndex = 22
        '
        'Timer
        '
        '
        'PopGrowthTimed
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 16)
        Me.ClientSize = New System.Drawing.Size(522, 367)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlControl, Me.pnlDisplay, Me.pnlEmpty})
        Me.DockPadding.All = 4
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.Name = "PopGrowthTimed"
        Me.Text = "PopGrowth"
        Me.pnlDisplay.ResumeLayout(False)
        CType(Me.TrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.pnlControl.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.updnSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.updnSpeed.ResumeLayout(False)
        Me.pnlEmpty.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Protected Sub chkAuto_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAuto.CheckedChanged
        updnSpeed.Enabled = Not chkAuto.Checked
    End Sub

    Private Sub SingleCycle()
        Dim Gen As Integer
        Dim PopSize As Single
        Dim Graphic As Graphics
        Dim DrawingPen As System.Drawing.Pen = New System.Drawing.Pen(Color.Black, 20)
        Dim X As Single
        Dim Y As Single
        Dim XLast As Single
        Dim YLast As Single
        Dim K As Single
        Dim Height As Single
        Dim Width As Single
        Dim Lines As Boolean

        PopSize = 0.02 ' starting population

        With pic
            .Refresh()
            Graphic = .CreateGraphics
            DrawingPen = System.Drawing.Pens.Black
        End With

        Lines = optLine.Checked

        K = CSng(TrackBar.Value / 1000)
        Height = (Graphic.VisibleClipBounds.Height) - 10
        Width = (Graphic.VisibleClipBounds.Width)
        YLast = Height

        For Gen = 1 To Generations
            PopSize = (K * PopSize) * (1 - PopSize)
            X = Gen * Width / Generations
            Y = Height - (PopSize * Height) + 5
            If Lines Then
                Graphic.DrawLine(DrawingPen, XLast, YLast, X, Y)
                YLast = Y
                XLast = X
            Else
                Graphic.DrawRectangle(DrawingPen, X, Y, 2, 2)
            End If
        Next

        Graphic.Dispose()
    End Sub

    Private Sub EnableButtons(ByVal bStart As Boolean)
        chkPause.Enabled = bStart
        chkRun.Enabled = Not bStart
        chkRun.Checked = False
    End Sub

    Public Sub TrackBar_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar.ValueChanged
        Dim NewValue As Double

        NewValue = TrackBar.Value / 1000
        txtK.Text = NewValue.ToString("0.0000")
        SingleCycle()
    End Sub

    Public Sub cmdStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStop.Click
        StopNow()
    End Sub

    Public Sub chkRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRun.Click
        If chkRun.Checked Then
            ' user just checked the buton - start the demo
            EnableButtons(True)
            TrackBar.Value = 0
            Timer.Enabled = True
        End If
    End Sub

    Public Sub chkPause_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPause.Click
        Timer.Enabled = Not chkPause.Checked
    End Sub

    Public Sub PopGrowth_Layout(ByVal sender As Object, ByVal e As System.Windows.Forms.LayoutEventArgs) Handles PopGrowth.Layout
        Dim Left As Integer

        pnlDisplay.SetBounds(Left, _
                             Me.DisplayRectangle.Top, _
                             Me.DisplayRectangle.Width - Left - pnlEmpty.Width - 1 * Margin, _
                             Me.ClientRectangle.Height - pnlControl.Height - 2 * Margin)
        pic.SetBounds(pnlDisplay.Left, pnlDisplay.Top, pnlDisplay.Width, pnlDisplay.Height - TrackBar.Height)
        pnlControl.SetBounds(Left, _
                             pnlDisplay.Top + pnlDisplay.Height + Margin, _
                             pnlDisplay.Width, _
                             pnlControl.Height)
    End Sub

    Public Sub Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer.Tick
        Dim Interval As Integer
        Dim Multiplier As Integer
        Dim Value As Integer

        If chkAuto.Checked Then
            If TrackBar.Value < 1000 Then
                Multiplier = 1000
            ElseIf TrackBar.Value < 3400 Then
                Multiplier = 100
            ElseIf TrackBar.Value < 3700 Then
                Multiplier = 10
            Else
                Multiplier = 1
            End If
        Else
            Multiplier = CInt(updnSpeed.Value * 10)
        End If
        Interval = Multiplier

        Value = TrackBar.Value + Interval
        If Value < TrackBar.Maximum Then
            TrackBar.Value = Value
        Else
            StopNow()
        End If
    End Sub

    Private Sub StopNow()
        TrackBar.Value = 0
        Timer.Enabled = False
        EnableButtons(False)
    End Sub

End Class
