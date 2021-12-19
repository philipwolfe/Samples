Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Net

Public Class GDIPlusForm
    Inherits System.Windows.Forms.Form
    Private myFillBackground As Boolean = False
    Private myAddWhiteWash As Boolean = False
    Private myAddWebLogo As Boolean = False
    Private myAddGradientFill As Boolean = False
    Private myAddShadowedText As Boolean = False
    Private myAddJapaneseText As Boolean = False
    Private myAddPathFill As Boolean = False

    Private backgroundBrush As Brush
    Private sampleImage As Image
    Private webLogo As Image

    Private titleFont As Font
    Private titleShadowBrush As Brush
    Private titleBrush As Brush

    Private japaneseFont As Font
    Private doJapaneseSample As Boolean = False
    Private japaneseBrush As Brush

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        'Load the image to be used for the background from the exe's resource fork
        Dim backgroundImage As Image = LabelColorBars.Image

        'Load sample
        sampleImage = LabelSample.Image

        'Now create the brush we are going to use to paint the background
        backgroundBrush = New TextureBrush(backgroundImage)

        'Load an image from the web and display that - if it fails load one from a local resource
        Try
            Dim request As WebRequest = WebRequest.Create("http://localhost/msnet.bmp")
            request.Credentials = CredentialCache.DefaultCredentials

            Dim source As Stream = request.GetResponse().GetResponseStream()
            Dim ms As MemoryStream = New MemoryStream()

            Dim data(256) As Byte
            Dim c As Integer = source.Read(data, 0, data.Length)

            While c > 0
                ms.Write(data, 0, c)
                c = source.Read(data, 0, data.Length)
            End While

            source.Close()
            ms.Position = 0
            webLogo = New Bitmap(ms)

        Catch ex As Exception
            webLogo = sampleImage
        End Try

        'Set up shadowed text
        titleFont = New Font("Arial", 60)
        titleShadowBrush = New SolidBrush(Color.FromArgb(70, Color.Black))

        Dim textImage As Image = LabelMarble.Image
        titleBrush = New TextureBrush(textImage)

        'Set up Japanese text
        Try
            japaneseFont = New Font("MS Mincho", 60)
            japaneseBrush = New LinearGradientBrush(New Point(0, 0), New Point(0, 45), Color.Blue, Color.Red)
            doJapaneseSample = True
        Catch ex As Exception
            doJapaneseSample = False
            Button7.Enabled = False
            Button7.Visible = False
        End Try

    End Sub

#Region " Windows Form Designer generated code "


    'Form overrides dispose to clean up the component list.
    Public Overloads Overrides Sub Dispose()
        MyBase.Dispose()
        If Not (components Is Nothing) Then
            components.Dispose()
        End If
    End Sub

    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents LabelColorBars As System.Windows.Forms.Label
    Friend WithEvents LabelSample As System.Windows.Forms.Label
    Friend WithEvents LabelMarble As System.Windows.Forms.Label

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThroughAttribute()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(GDIPlusForm))
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LabelMarble = New System.Windows.Forms.Label()
        Me.LabelSample = New System.Windows.Forms.Label()
        Me.LabelColorBars = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button4
        '
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.Button4.Location = New System.Drawing.Point(8, 128)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(128, 32)
        Me.Button4.TabIndex = 3
        Me.Button4.Text = "Gradient Fill"
        '
        'Button5
        '
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.Button5.Location = New System.Drawing.Point(8, 168)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(128, 32)
        Me.Button5.TabIndex = 4
        Me.Button5.Text = "Shadow Text"
        '
        'Button6
        '
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.Button6.Location = New System.Drawing.Point(8, 208)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(128, 32)
        Me.Button6.TabIndex = 5
        Me.Button6.Text = "Path Fill"
        '
        'Button7
        '
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button7.Font = New System.Drawing.Font("Microsoft Sans Serif", 14!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.Button7.Location = New System.Drawing.Point(8, 248)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(128, 32)
        Me.Button7.TabIndex = 6
        Me.Button7.Text = "Japanese Text"
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.Button1.Location = New System.Drawing.Point(8, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(128, 32)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Background"
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.Button2.Location = New System.Drawing.Point(8, 48)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(128, 32)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "White Wash"
        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.Button3.Location = New System.Drawing.Point(8, 88)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(128, 32)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Web Image"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(536, 648)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Text = "PictureBox1"
        '
        'Panel1
        '
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.LabelMarble, Me.LabelSample, Me.LabelColorBars, Me.Button7, Me.Button6, Me.Button5, Me.Button4, Me.Button3, Me.Button2, Me.Button1})
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(544, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(144, 650)
        Me.Panel1.TabIndex = 0
        Me.Panel1.Text = "Panel1"
        '
        'LabelMarble
        '
        Me.LabelMarble.Enabled = False
        Me.LabelMarble.Image = CType(resources.GetObject("LabelMarble.Image"), System.Drawing.Bitmap)
        Me.LabelMarble.Location = New System.Drawing.Point(32, 368)
        Me.LabelMarble.Name = "LabelMarble"
        Me.LabelMarble.Size = New System.Drawing.Size(80, 32)
        Me.LabelMarble.TabIndex = 6
        Me.LabelMarble.Text = "Label1"
        Me.LabelMarble.Visible = False
        '
        'LabelSample
        '
        Me.LabelSample.Enabled = False
        Me.LabelSample.Image = CType(resources.GetObject("LabelSample.Image"), System.Drawing.Bitmap)
        Me.LabelSample.Location = New System.Drawing.Point(32, 336)
        Me.LabelSample.Name = "LabelSample"
        Me.LabelSample.Size = New System.Drawing.Size(64, 23)
        Me.LabelSample.TabIndex = 5
        Me.LabelSample.Text = "Label1"
        Me.LabelSample.Visible = False
        '
        'LabelColorBars
        '
        Me.LabelColorBars.Enabled = False
        Me.LabelColorBars.Image = CType(resources.GetObject("LabelColorBars.Image"), System.Drawing.Bitmap)
        Me.LabelColorBars.Location = New System.Drawing.Point(32, 296)
        Me.LabelColorBars.Name = "LabelColorBars"
        Me.LabelColorBars.Size = New System.Drawing.Size(80, 24)
        Me.LabelColorBars.TabIndex = 4
        Me.LabelColorBars.Text = "Label1"
        Me.LabelColorBars.Visible = False
        '
        'GDIPlusForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(688, 650)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel1, Me.PictureBox1})
        Me.Name = "GDIPlusForm"
        Me.Text = "GDI+ Sample"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim codes As New StringWriter()

        codes.WriteLine("japaneseFont = New Font(""MS Mincho"", 60)")
        codes.WriteLine("japaneseBrush = New LinearGradientBrush(New Point(0, 0), New Point(0, 45), Color.Blue, Color.Red)")
        codes.WriteLine("")
        codes.WriteLine("Dim japaneseText As String = New String(New Char() {ChrW(31169), ChrW(12398), ChrW(21517), ChrW(21069), ChrW(12399), ChrW(12463), ChrW(12522), ChrW(12473), ChrW(12391), ChrW(12377), ChrW(12290)})")
        codes.WriteLine("")
        codes.WriteLine("ev.Graphics.RotateTransform(-30)")
        codes.WriteLine("ev.Graphics.TranslateTransform(-180, 300)")
        codes.WriteLine("ev.Graphics.DrawString(japaneseText, japaneseFont, japaneseBrush, 20, 140)")
        codes.WriteLine("ev.Graphics.ResetTransform()")

        Dim f As New CodeForm(codes.ToString())
        f.ShowDialog()
        f.Dispose()

        myAddJapaneseText = True
        PictureBox1.Invalidate()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim codes As New StringWriter()
        codes.WriteLine("Dim backgroundImage As Image = New Bitmap(""e:\pdcdemos\images\colorbars.jpg"")")
        codes.WriteLine("backgroundBrush = New TextureBrush(backgroundImage)")
        codes.WriteLine("ev.Graphics.FillRectangle(backgroundBrush, ClientRectangle)")

        Dim f As New CodeForm(codes.ToString())
        f.ShowDialog()
        f.Dispose()

        myFillBackground = True
        PictureBox1.Invalidate()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim codes As New StringWriter()
        codes.WriteLine("ev.Graphics.FillRectangle(New SolidBrush(Color.FromARGB(180, Color.White)), ClientRectangle)")

        Dim f As New CodeForm(codes.ToString())
        f.ShowDialog()
        f.Dispose()

        myAddWhiteWash = True
        PictureBox1.Invalidate()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim codes As New StringWriter()
        codes.WriteLine("Dim request As WebRequest = _ ")
        codes.WriteLine("WebRequest.Create(""http://localhost/msnet.bmp"")")
        codes.WriteLine("")
        codes.WriteLine("request.Credentials = CredentialCache.DefaultCredentials")
        codes.WriteLine("")
        codes.WriteLine("Dim source As Stream = request.GetResponse().GetResponseStream()")
        codes.WriteLine("Dim ms As MemoryStream = New MemoryStream")
        codes.WriteLine("")
        codes.WriteLine("Dim data(256) As Byte")
        codes.WriteLine("Dim c As Integer = source.Read(data, 0, data.Length)")
        codes.WriteLine("")
        codes.WriteLine("While c > 0")
        codes.WriteLine("    ms.Write(data, 0, c)")
        codes.WriteLine("    c = source.Read(data, 0, data.Length)")
        codes.WriteLine("End While")
        codes.WriteLine("")
        codes.WriteLine("source.Close()")
        codes.WriteLine("ms.Position = 0")
        codes.WriteLine("webLogo = New Bitmap(ms)")
        codes.WriteLine("")
        codes.WriteLine("ev.Graphics.RotateTransform(-30)")
        codes.WriteLine("ev.Graphics.DrawImage(webLogo, 75, 170)")
        codes.WriteLine("ev.Graphics.ResetTransform()")

        Dim f As New CodeForm(codes.ToString())
        f.ShowDialog()
        f.Dispose()

        myAddWebLogo = True
        PictureBox1.Invalidate()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim codes As New StringWriter()
        codes.WriteLine("Dim r As Rectangle = New Rectangle(275, 350, 250, 150)")
        codes.WriteLine("Dim lb As LinearGradientBrush = _")
        codes.WriteLine("    New LinearGradientBrush(r, Color.Red, Color.Yellow, LinearGradientMode.BackwardDiagonal)")
        codes.WriteLine("ev.Graphics.FillRectangle(lb, r)")


        Dim f As New CodeForm(codes.ToString())
        f.ShowDialog()
        f.Dispose()

        myAddGradientFill = True
        PictureBox1.Invalidate()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim codes As New StringWriter()
        codes.WriteLine("Dim titleText As String = ""Graphics Samples""")
        codes.WriteLine("Dim textImage As Image = New Bitmap(""e:\pdcdemos\images\marble.jpg"")")
        codes.WriteLine("titleBrush = New TextureBrush(textImage)")
        codes.WriteLine("titleFont = New Font(""Lucida Sans Unicode"", 60)")
        codes.WriteLine("titleShadowBrush = New SolidBrush(Color.FromARGB(70, Color.Black))")
        codes.WriteLine("")
        codes.WriteLine("ev.Graphics.DrawString(titleText, titleFont, titleShadowBrush, 15, 145)")
        codes.WriteLine("ev.Graphics.DrawString(titleText, titleFont, titleBrush, 10, 140)")

        Dim f As New CodeForm(codes.ToString())
        f.ShowDialog()

        myAddShadowedText = True
        PictureBox1.Invalidate()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim codes As New StringWriter()

        codes.WriteLine("Dim points() As Point = {New Point(100, 0), New Point(200, 200), New Point(0, 200)}")
        codes.WriteLine("")
        codes.WriteLine("Dim colorBlend1 As ColorBlend = New ColorBlend()")
        codes.WriteLine("colorBlend1.Colors = New Color() {Color.Green, Color.Aqua, Color.Blue}")
        codes.WriteLine("colorBlend1.Positions = New Single() {0F, 0.4F, 1F}")
        codes.WriteLine("")
        codes.WriteLine("Dim pgb As PathGradientBrush = New PathGradientBrush(points)")
        codes.WriteLine("pgb.InterpolationColors = colorBlend1")
        codes.WriteLine("pgb.FocusScales = New PointF(0.1F, 0.1F)")
        codes.WriteLine("")
        codes.WriteLine("ev.Graphics.FillRectangle(pgb, 0, 0, 200, 200)")

        Dim f As New CodeForm(codes.ToString())
        f.ShowDialog()
        f.Dispose()

        myAddPathFill = True
        PictureBox1.Invalidate()

    End Sub

    Private Sub PictureBox1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PictureBox1.Paint
        Dim g As Graphics = e.Graphics

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        FillBackground(g, CType(sender, Control))

        PaintWebLogo(g, CType(sender, Control))

        PaintGradientFill(g, CType(sender, Control))

        PaintShadowedText(g, CType(sender, Control))

        PaintJapaneseText(g, CType(sender, Control))

        PaintPathFill(g, CType(sender, Control))

    End Sub

    Friend Sub FillBackground(ByVal g As Graphics, ByVal c As Control)
        If (myFillBackground) Then
            g.FillRectangle(backgroundBrush, c.ClientRectangle)
        End If

        If (myAddWhiteWash) Then
            g.FillRectangle(New SolidBrush(Color.FromArgb(180, Color.White)), c.ClientRectangle)
        End If
    End Sub

    Friend Sub PaintWebLogo(ByVal g As Graphics, ByVal c As Control)
        If (myAddWebLogo) Then
            g.RotateTransform(30)
            g.DrawImage(webLogo, 375, -130)
            g.ResetTransform()
        End If
    End Sub

    Friend Sub PaintGradientFill(ByVal g As Graphics, ByVal c As Control)
        If (myAddGradientFill) Then
            Dim r As Rectangle = New Rectangle(275, 350, 250, 150)
            Dim lb As LinearGradientBrush = New LinearGradientBrush(r, Color.Red, Color.Yellow, LinearGradientMode.BackwardDiagonal)
            g.FillRectangle(lb, r)
        End If
    End Sub

    Friend Sub PaintShadowedText(ByVal g As Graphics, ByVal c As Control)
        If (myAddShadowedText) Then
            Dim titleText As String = "Graphics Samples"
            g.DrawString(titleText, titleFont, titleShadowBrush, 15, 495)
            g.DrawString(titleText, titleFont, titleBrush, 10, 490)
        End If
    End Sub

    Friend Sub PaintJapaneseText(ByVal g As Graphics, ByVal c As Control)
        If (myAddJapaneseText And doJapaneseSample) Then
            Dim japaneseText As String = New String(New Char() {ChrW(31169), ChrW(12398), ChrW(21517), ChrW(21069), ChrW(12399), ChrW(12463), ChrW(12522), ChrW(12473), ChrW(12391), ChrW(12377), ChrW(12290)})
            g.RotateTransform(-30)
            g.TranslateTransform(-180, 300)
            g.DrawString(japaneseText, japaneseFont, japaneseBrush, 20, 140)
            g.ResetTransform()
        End If
    End Sub

    Friend Sub PaintPathFill(ByVal g As Graphics, ByVal c As Control)
        If (myAddPathFill) Then
            
            Dim points() As Point = {New Point(100, 0), New Point(200, 200), New Point(0, 200)}

            Dim colorBlend1 As ColorBlend = New ColorBlend()
            colorBlend1.Colors = New Color() {Color.Green, Color.Aqua, Color.Blue}
            colorBlend1.Positions = New Single() {0F, 0.4F, 1F}

            Dim pgb As PathGradientBrush = New PathGradientBrush(points)
            pgb.InterpolationColors = colorBlend1

            pgb.FocusScales = New PointF(0.1F, 0.1F)

            g.FillRectangle(pgb, 0, 0, 200, 200)

        End If
    End Sub


End Class

