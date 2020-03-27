Public Class Form1
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.Location = New System.Drawing.Point(8, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(320, 296)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(448, 32)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(200, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Draw 10 Random Lines"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(392, 32)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(48, 22)
        Me.TextBox1.TabIndex = 2
        Me.TextBox1.Text = "10"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(656, 312)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TextBox1, Me.Button1, Me.PictureBox1})
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private imgMemoryImage As Image
    Private gImageGraphics As Graphics

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Rnd As New Random()
        Dim R, G, B, X1, Y1, X2, Y2 As Int32
        Dim P As Pen
        Dim C As Color
        Dim i As Int32
        Dim NumLines As Int32 = CInt(TextBox1.Text)
        If NumLines > 0 Then
            gImageGraphics.Clear(PictureBox1.BackColor)
            For i = 1 To NumLines
                Randomize(Now.Ticks)
                R = Rnd.Next(0, 255)
                Randomize(Now.Ticks)
                G = Rnd.Next(0, 255)
                Randomize(Now.Ticks)
                B = Rnd.Next(0, 255)
                Randomize(Now.Ticks)
                X1 = Rnd.Next(0, PictureBox1.Width)
                Randomize(Now.Ticks)
                X2 = Rnd.Next(0, PictureBox1.Width)
                Randomize(Now.Ticks)
                Y1 = Rnd.Next(0, PictureBox1.Height)
                Randomize(Now.Ticks)
                Y2 = Rnd.Next(0, PictureBox1.Height)
                C = Color.FromArgb(R, G, B)
                P = New Pen(C)
                gImageGraphics.DrawLine(P, X1, Y1, X2, Y2)
            Next
            PictureBox1.Refresh()
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        imgMemoryImage = New Bitmap(PictureBox1.Width, PictureBox1.Height)
        PictureBox1.Image = imgMemoryImage
        gImageGraphics = PictureBox1.CreateGraphics.FromImage(imgMemoryImage)
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If Val(TextBox1.Text) > 0 Then
            Button1.Text = "Draw " & TextBox1.Text & " Random Lines"
        End If
    End Sub
End Class
