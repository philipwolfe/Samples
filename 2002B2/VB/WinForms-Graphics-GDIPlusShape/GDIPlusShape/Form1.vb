Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D


Public Class Form1
    Inherits System.Windows.Forms.Form
    
    
    Private ShowDotNet As Boolean = True
    
    Public Sub New()
        MyBase.New

        Form1 = Me

        'This call is required by the Win Form Designer.
        InitializeComponent

        'TODO: Add any initialization after the InitializeComponent() call
    End Sub
    
    Private Sub ApplyInitialRegion()
        Dim myGraphicsPath As GraphicsPath = New GraphicsPath()
        Dim stringText As String = ".net"
        Dim family As FontFamily = New FontFamily("Arial")
        Dim style As Integer = CInt(FontStyle.Bold)
        Dim emSize As Integer = 300
        Dim origin As PointF = New PointF(97, 50)
        Dim format As StringFormat = StringFormat.GenericDefault
        myGraphicsPath.AddString(stringText, family, style, emSize, origin, format)
        myGraphicsPath.AddEllipse(New Rectangle(0, 0, 200, 450))
        Me.Region = New [Region](myGraphicsPath)
    End Sub
    
    
    Private Sub ApplyDotNetRegion()
        Dim myGraphicsPath As GraphicsPath = New GraphicsPath()
        Dim stringText As String = ".net"
        Dim family As FontFamily = New FontFamily("Arial")
        Dim style As Integer = CInt(FontStyle.Bold)
        Dim emSize As Integer = 300
        Dim origin As PointF = New PointF(90, 50)
        Dim format As StringFormat = StringFormat.GenericDefault
        myGraphicsPath.AddString(stringText, family, style, emSize, origin, format)
        myGraphicsPath.AddEllipse(New Rectangle(0, 0, 150, 150))
        Me.Region = New [Region](myGraphicsPath)
    End Sub
    
    Private Sub ApplyRocksRegion()
        Dim myGraphicsPath As GraphicsPath = New GraphicsPath()
        Dim stringText As String = "Rocks!"
        Dim family As FontFamily = New FontFamily("Arial")
        Dim style As Integer = CInt(FontStyle.Bold Or FontStyle.Italic)
        Dim emSize As Integer = 250
        Dim origin As PointF = New PointF(120, 250)
        Dim format As StringFormat = StringFormat.GenericDefault
        myGraphicsPath.AddString(stringText, family, style, emSize, origin, format)
        myGraphicsPath.AddEllipse(New Rectangle(0, 0, 150, 150))
        Me.Region = New [Region](myGraphicsPath)
    End Sub
    
    
    
    
    'Form overrides dispose to clean up the component list.
    Public Overloads Overrides Sub Dispose()
        MyBase.Dispose()
        components.Dispose()
    End Sub

#Region " Windows Form Designer generated code "

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container
    Private WithEvents ButtonVisibility As System.Windows.Forms.Button
    Private WithEvents ButtonShape As System.Windows.Forms.Button
    Private WithEvents ButtonStop As System.Windows.Forms.Button
    Private WithEvents Timer1 As System.Windows.Forms.Timer
    Private WithEvents ButtonStart As System.Windows.Forms.Button

    Dim WithEvents Form1 As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))

        Me.components = New System.ComponentModel.Container()
        Me.ButtonVisibility = New System.Windows.Forms.Button()
        Me.ButtonStart = New System.Windows.Forms.Button()
        Me.ButtonShape = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(components)
        Me.ButtonStop = New System.Windows.Forms.Button()

        '@design Me.TrayHeight = 90
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        ButtonVisibility.Location = New System.Drawing.Point(16, 136)
        ButtonVisibility.ForeColor = System.Drawing.Color.RosyBrown
        ButtonVisibility.BackColor = System.Drawing.SystemColors.ActiveCaption
        ButtonVisibility.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        ButtonVisibility.Size = New System.Drawing.Size(144, 104)
        ButtonVisibility.TabIndex = 3
        ButtonVisibility.Font = New System.Drawing.Font("Tahoma", 14!, System.Drawing.FontStyle.Bold)
        ButtonVisibility.Text = "Thin Me!"

        ButtonStart.Location = New System.Drawing.Point(16, 256)
        ButtonStart.ForeColor = System.Drawing.Color.RosyBrown
        ButtonStart.BackColor = System.Drawing.SystemColors.ActiveCaption
        ButtonStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        ButtonStart.Size = New System.Drawing.Size(144, 104)
        ButtonStart.TabIndex = 0
        ButtonStart.Font = New System.Drawing.Font("Tahoma", 14!, System.Drawing.FontStyle.Bold)
        ButtonStart.Text = "Start Me!"

        ButtonShape.Location = New System.Drawing.Point(184, 8)
        ButtonShape.ForeColor = System.Drawing.Color.RosyBrown
        ButtonShape.BackColor = System.Drawing.SystemColors.ActiveCaption
        ButtonShape.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        ButtonShape.Size = New System.Drawing.Size(144, 104)
        ButtonShape.TabIndex = 2
        ButtonShape.Font = New System.Drawing.Font("Tahoma", 14!, System.Drawing.FontStyle.Bold)
        ButtonShape.Text = "Shape Me!"

        '@design Timer1.SetLocation(New System.Drawing.Point(7, 7))
        Timer1.Interval = 500

        ButtonStop.Location = New System.Drawing.Point(16, 8)
        ButtonStop.ForeColor = System.Drawing.Color.RosyBrown
        ButtonStop.BackColor = System.Drawing.SystemColors.ActiveCaption
        ButtonStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        ButtonStop.Size = New System.Drawing.Size(144, 104)
        ButtonStop.TabIndex = 1
        ButtonStop.Font = New System.Drawing.Font("Tahoma", 14!, System.Drawing.FontStyle.Bold)
        ButtonStop.Text = "Stop Me!"

        Me.Text = "Shaped Form"
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Orange
        Me.ClientSize = New System.Drawing.Size(856, 517)

        Me.Controls.Add(ButtonVisibility)
        Me.Controls.Add(ButtonShape)
        Me.Controls.Add(ButtonStop)
        Me.Controls.Add(ButtonStart)
    End Sub

#End Region

    Protected Sub buttonVisibility_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonVisibility.Click
        Me.Opacity = 0.4
    End Sub

    Protected Sub buttonShape_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonShape.Click
        ApplyInitialRegion()
    End Sub

    Protected Sub buttonStop_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonStop.Click
        Application.Exit()
    End Sub

    Protected Sub timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If (ShowDotNet) Then
            Me.ApplyDotNetRegion()
            ShowDotNet = False
        Else
            Me.ApplyRocksRegion()
            ShowDotNet = True
        End If
    End Sub

    Protected Sub buttonStart_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonStart.Click
        Me.Hide()
        Me.Opacity = 1
        Me.Region = Nothing
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.Show()
        Me.WindowState = FormWindowState.Maximized
        Timer1.Start()
    End Sub



End Class
