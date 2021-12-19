Imports System.Drawing.Drawing2D

Public Class Form1
    Inherits System.Windows.Forms.Form

    Private ShowDotNet As Boolean = True

    Private Sub ApplyInitialRegion()
        Dim myGraphicsPath As GraphicsPath = New GraphicsPath()
        Dim stringText As String = ".net"
        Dim family As FontFamily = New FontFamily("Arial")
        Dim fontStyle As FontStyle = fontStyle.Bold
        Dim emSize As Integer = 300
        Dim origin As PointF = New PointF(97, 50)
        Dim format As StringFormat = StringFormat.GenericDefault
        myGraphicsPath.AddString(stringText, family, fontStyle, emSize, origin, format)
        myGraphicsPath.AddEllipse(New Rectangle(0, 0, 200, 450))
        Me.Region = New Region(myGraphicsPath)
    End Sub

    Private Sub ApplyDotNetRegion()
        Dim myGraphicsPath As GraphicsPath = New GraphicsPath()
        Dim stringText As String = ".net"
        Dim family As FontFamily = New FontFamily("Arial")
        Dim fontStyle As FontStyle = fontStyle.Bold
        Dim emSize As Integer = 400
        Dim origin As PointF = New PointF(90, 50)
        Dim format As StringFormat = StringFormat.GenericDefault
        myGraphicsPath.AddString(stringText, family, fontStyle, emSize, origin, format)
        myGraphicsPath.AddEllipse(New Rectangle(0, 0, 150, 150))
        Me.Region = New Region(myGraphicsPath)
    End Sub

    Private Sub ApplyRocksRegion()
        Dim myGraphicsPath As GraphicsPath = New GraphicsPath()
        Dim stringText As String = "Rocks!"
        Dim family As FontFamily = New FontFamily("Arial")
        Dim fontStyle As FontStyle = fontStyle.Bold Or fontStyle.Italic
        Dim emSize As Integer = 250
        Dim origin As PointF = New PointF(120, 250)
        Dim format As StringFormat = StringFormat.GenericDefault
        myGraphicsPath.AddString(stringText, family, fontStyle, emSize, origin, format)
        myGraphicsPath.AddEllipse(New Rectangle(0, 0, 150, 150))
        Me.Region = New Region(myGraphicsPath)
    End Sub

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'Me call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Public Overloads Overrides Sub Dispose()
        MyBase.Dispose()
        If Not (components Is Nothing) Then
            components.Dispose()
        End If
    End Sub
    Friend WithEvents ButtonVisibility As System.Windows.Forms.Button
    Friend WithEvents ButtonShape As System.Windows.Forms.Button
    Friend WithEvents ButtonStop As System.Windows.Forms.Button
    Friend WithEvents ButtonStart As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents LabelBitmapHolder As System.Windows.Forms.Label
    Private components As System.ComponentModel.IContainer

    'Required by the Windows Form Designer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThroughAttribute()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ButtonStop = New System.Windows.Forms.Button()
        Me.LabelBitmapHolder = New System.Windows.Forms.Label()
        Me.ButtonStart = New System.Windows.Forms.Button()
        Me.ButtonShape = New System.Windows.Forms.Button()
        Me.ButtonVisibility = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'ButtonStop
        '
        Me.ButtonStop.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ButtonStop.Font = New System.Drawing.Font("Tahoma", 14!, System.Drawing.FontStyle.Bold)
        Me.ButtonStop.ForeColor = System.Drawing.Color.RosyBrown
        Me.ButtonStop.Location = New System.Drawing.Point(24, 16)
        Me.ButtonStop.Name = "ButtonStop"
        Me.ButtonStop.Size = New System.Drawing.Size(144, 104)
        Me.ButtonStop.TabIndex = 1
        Me.ButtonStop.Text = "Stop Me!"
        '
        'LabelBitmapHolder
        '
        Me.LabelBitmapHolder.Enabled = False
        Me.LabelBitmapHolder.Image = CType(resources.GetObject("LabelBitmapHolder.Image"), System.Drawing.Bitmap)
        Me.LabelBitmapHolder.Location = New System.Drawing.Point(368, 152)
        Me.LabelBitmapHolder.Name = "LabelBitmapHolder"
        Me.LabelBitmapHolder.Size = New System.Drawing.Size(88, 48)
        Me.LabelBitmapHolder.TabIndex = 4
        Me.LabelBitmapHolder.Text = "Label1"
        Me.LabelBitmapHolder.Visible = False
        '
        'ButtonStart
        '
        Me.ButtonStart.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ButtonStart.Font = New System.Drawing.Font("Tahoma", 14!, System.Drawing.FontStyle.Bold)
        Me.ButtonStart.ForeColor = System.Drawing.Color.RosyBrown
        Me.ButtonStart.Location = New System.Drawing.Point(24, 144)
        Me.ButtonStart.Name = "ButtonStart"
        Me.ButtonStart.Size = New System.Drawing.Size(144, 104)
        Me.ButtonStart.TabIndex = 2
        Me.ButtonStart.Text = "Start Me!"
        '
        'ButtonShape
        '
        Me.ButtonShape.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ButtonShape.Font = New System.Drawing.Font("Tahoma", 14!, System.Drawing.FontStyle.Bold)
        Me.ButtonShape.ForeColor = System.Drawing.Color.RosyBrown
        Me.ButtonShape.Location = New System.Drawing.Point(184, 16)
        Me.ButtonShape.Name = "ButtonShape"
        Me.ButtonShape.Size = New System.Drawing.Size(144, 104)
        Me.ButtonShape.TabIndex = 3
        Me.ButtonShape.Text = "Shape Me!"
        '
        'ButtonVisibility
        '
        Me.ButtonVisibility.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ButtonVisibility.Font = New System.Drawing.Font("Tahoma", 14!, System.Drawing.FontStyle.Bold)
        Me.ButtonVisibility.ForeColor = System.Drawing.Color.RosyBrown
        Me.ButtonVisibility.Location = New System.Drawing.Point(24, 272)
        Me.ButtonVisibility.Name = "ButtonVisibility"
        Me.ButtonVisibility.Size = New System.Drawing.Size(144, 104)
        Me.ButtonVisibility.TabIndex = 0
        Me.ButtonVisibility.Text = "Thin Me!"
        '
        'Form1
        '
        Me.AcceptButton = Me.ButtonShape
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Orange
        Me.ClientSize = New System.Drawing.Size(848, 490)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.LabelBitmapHolder, Me.ButtonStart, Me.ButtonStop, Me.ButtonShape, Me.ButtonVisibility})
        Me.Name = "Form1"
        Me.Text = "Shaped Window"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub ButtonVisibility_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonVisibility.Click
        Me.Opacity = 0.4
    End Sub

    Private Sub ButtonShape_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonShape.Click
        ApplyInitialRegion()
    End Sub

    Private Sub ButtonStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonStop.Click
        Application.Exit()
    End Sub

    Private Sub ButtonStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonStart.Click
        Me.Hide()
        Me.Opacity = 1
        Me.Region = Nothing
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
        Me.BackgroundImage = CType(resources.GetObject("LabelBitmapHolder.Image"), System.Drawing.Bitmap)
        Me.Show()
        Application.DoEvents()
        Me.WindowState = FormWindowState.Maximized
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If (ShowDotNet) Then
            ApplyDotNetRegion()
            ShowDotNet = False
        Else
            ApplyRocksRegion()
            ShowDotNet = True
        End If

    End Sub



End Class
