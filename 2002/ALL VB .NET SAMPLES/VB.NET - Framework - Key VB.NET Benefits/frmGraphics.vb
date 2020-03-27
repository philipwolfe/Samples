Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class frmGraphics
    Inherits System.Windows.Forms.Form
    Private drawX As Integer
    Private drawY As Integer

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
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents miDrawLine As System.Windows.Forms.MenuItem
    Friend WithEvents miDrawCircle As System.Windows.Forms.MenuItem
    Friend WithEvents miDrawRectangle As System.Windows.Forms.MenuItem
    Friend WithEvents miDrawText As System.Windows.Forms.MenuItem
    Friend WithEvents miDrawFancyText As System.Windows.Forms.MenuItem
    Friend WithEvents picDrawing As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.MainMenu1 = New System.Windows.Forms.MainMenu()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.miDrawLine = New System.Windows.Forms.MenuItem()
        Me.miDrawCircle = New System.Windows.Forms.MenuItem()
        Me.miDrawRectangle = New System.Windows.Forms.MenuItem()
        Me.miDrawText = New System.Windows.Forms.MenuItem()
        Me.miDrawFancyText = New System.Windows.Forms.MenuItem()
        Me.picDrawing = New System.Windows.Forms.PictureBox()
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miDrawLine, Me.miDrawCircle, Me.miDrawRectangle, Me.miDrawText, Me.miDrawFancyText})
        Me.MenuItem1.Text = "Action"
        '
        'miDrawLine
        '
        Me.miDrawLine.Index = 0
        Me.miDrawLine.Text = "Draw Line"
        '
        'miDrawCircle
        '
        Me.miDrawCircle.Index = 1
        Me.miDrawCircle.Text = "Draw Circle"
        '
        'miDrawRectangle
        '
        Me.miDrawRectangle.Index = 2
        Me.miDrawRectangle.Text = "Draw Rectangle"
        '
        'miDrawText
        '
        Me.miDrawText.Index = 3
        Me.miDrawText.Text = "Draw Text"
        '
        'miDrawFancyText
        '
        Me.miDrawFancyText.Index = 4
        Me.miDrawFancyText.Text = "Draw Fancy Text"
        '
        'picDrawing
        '
        Me.picDrawing.Location = New System.Drawing.Point(104, 24)
        Me.picDrawing.Name = "picDrawing"
        Me.picDrawing.Size = New System.Drawing.Size(424, 312)
        Me.picDrawing.TabIndex = 0
        Me.picDrawing.TabStop = False
        '
        'frmGraphics
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(554, 360)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.picDrawing})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Menu = Me.MainMenu1
        Me.Name = "frmGraphics"
        Me.Text = "Graphics Support"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub miDrawLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miDrawLine.Click
        picDrawing.CreateGraphics().Clear(Me.BackColor)
        Dim g As Graphics = picDrawing.CreateGraphics()
        Dim p As New Pen(Color.Blue, 6)
        g.DrawLine(p, 100, 100, 50, 150)
        g.Dispose()
    End Sub

    Private Sub frmGraphics_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        drawX = CInt((ClientSize.Width / 2) + 50)
        drawY = CInt((ClientSize.Height / 2) + 50)
    End Sub

    Private Sub miDrawCircle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miDrawCircle.Click
        picDrawing.CreateGraphics().Clear(Me.BackColor)
        Dim g As Graphics = picDrawing.CreateGraphics()
        Dim p As New Pen(Color.Red, 3)
        g.DrawEllipse(p, 120, 120, 100, 100)
        g.Dispose()
    End Sub

    Private Sub miDrawRectangle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miDrawRectangle.Click
        picDrawing.CreateGraphics().Clear(Me.BackColor)
        Dim g As Graphics = picDrawing.CreateGraphics()
        Dim p As New Pen(Color.Green, 3)
        g.DrawRectangle(p, 150, 150, 100, 100)
        g.Dispose()
    End Sub

    Private Sub miDrawText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miDrawText.Click
        picDrawing.CreateGraphics().Clear(Me.BackColor)
        Dim g As Graphics = picDrawing.CreateGraphics()
        g.DrawString("VB.NET", New Font("Arial", 20), Brushes.Blue, 135, 135)
        g.Dispose()
    End Sub

    Private Sub miDrawFancyText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miDrawFancyText.Click
        picDrawing.CreateGraphics().Clear(Me.BackColor)
        Dim g As Graphics = picDrawing.CreateGraphics()
        Dim b1 As New SolidBrush(Color.FromArgb(80, 10, 255, 100))
        g.DrawString("VB.NET", New Font("Arial", 30), b1, 135, 135)
        Dim b2 As New SolidBrush(Color.FromArgb(80, 100, 255, 100))
        g.DrawString("VB.NET", New Font("Arial", 20), b2, 150, 150)
        Dim b3 As New SolidBrush(Color.FromArgb(80, 10, 255, 100))
        g.DrawString("VB.NET", New Font("Arial", 10), b3, 170, 170)
        g.Dispose()
    End Sub
End Class
