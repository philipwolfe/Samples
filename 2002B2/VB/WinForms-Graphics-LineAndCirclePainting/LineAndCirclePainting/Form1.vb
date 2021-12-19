Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D

Public Class Form1
    Inherits System.Windows.Forms.Form
    
    Private BackingBmp As Bitmap
    
    Public Sub New()
        MyBase.New

        Form1 = Me

        'This call is required by the Win Form Designer.
        InitializeComponent

        'TODO: Add any initialization after the InitializeComponent() call
        BackingBmp = New Bitmap(200, 200)
        PictureBox1.Image = BackingBmp
        
    End Sub

    'Form overrides dispose to clean up the component list.
    Public Overloads Overrides Sub Dispose()
        MyBase.Dispose()
        components.Dispose()
    End Sub

#Region " Windows Form Designer generated code "

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container
    Private WithEvents Button1 As System.Windows.Forms.Button
    Private WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Private WithEvents Panel1 As System.Windows.Forms.Panel

    Dim WithEvents Form1 As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()

        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        Button1.Location = New System.Drawing.Point(8, 192)
        Button1.Size = New System.Drawing.Size(88, 32)
        Button1.TabIndex = 2
        Button1.Text = "Paint"

        Panel1.Location = New System.Drawing.Point(216, 24)
        Panel1.Size = New System.Drawing.Size(152, 128)
        Panel1.TabIndex = 0

        PictureBox1.Location = New System.Drawing.Point(152, 176)
        PictureBox1.Size = New System.Drawing.Size(224, 80)
        PictureBox1.TabIndex = 1
        PictureBox1.TabStop = False
        Me.Text = "Form1"
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(408, 273)

        Me.Controls.Add(Button1)
        Me.Controls.Add(PictureBox1)
        Me.Controls.Add(Panel1)
    End Sub

#End Region

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.click
        Dim g As Graphics
        Dim p As Pen

        Try
            'Draw to the bitmap in the PictureBox
            g = Graphics.FromImage(BackingBmp)
            p = New Pen(Color.Red, 5)
            p.DashStyle = DashStyle.Dot
            g.FillRectangle(Brushes.BlueViolet, Me.ClientRectangle)
            g.DrawString("Hello", Me.Font, Brushes.BlanchedAlmond, 10, 10)
            g.DrawLine(p, 30, 10, 50, 50)
            p.Color = Color.Blue
            p.DashStyle = DashStyle.Solid
            g.DrawEllipse(p, 50, 30, 60, 30)
            g.FillEllipse(Brushes.CornflowerBlue, 150, 10, 30, 50)

            'Tell PictureBox to redraw
            PictureBox1.Refresh()
        Finally
            If Not (g Is Nothing) Then
                g.Dispose()
            End If
            If Not (p Is Nothing) Then
                p.Dispose()
            End If
        End Try

    End Sub

    Public Sub Form1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Form1.Paint
        'When the form paints, draw a red line
        e.Graphics.DrawLine(Pens.Red, 10, 10, 100, 100)
    End Sub

    Public Sub Panel1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        'When the panel paints, draw a rectangle
        e.Graphics.FillRectangle(Brushes.Yellow, Panel1.ClientRectangle)
        'Place the word Hello in the rectangle
        e.Graphics.DrawString("Hello", Me.Font, Brushes.BlueViolet, 10, 10)
    End Sub



End Class
