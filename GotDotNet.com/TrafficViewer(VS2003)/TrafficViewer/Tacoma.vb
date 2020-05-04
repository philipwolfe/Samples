Public Class Tacoma
    Inherits System.Windows.Forms.Form
    Private Client As New Net.WebClient
    Private MapColorPen As New Pen(Color.FromArgb(255, 251, 240))
    Private LinePts As Point() = {New Point(1, 4), New Point(1, 3), New Point(2, 3), New Point(2, 2), New Point(5, 2)}


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
    Friend WithEvents Link As System.Windows.Forms.LinkLabel
    Friend WithEvents TacomaMap As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Tacoma))
        Me.TacomaMap = New System.Windows.Forms.Label
        Me.Link = New System.Windows.Forms.LinkLabel
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'TacomaMap
        '
        Me.TacomaMap.BackColor = System.Drawing.SystemColors.Control
        Me.TacomaMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TacomaMap.Image = CType(resources.GetObject("TacomaMap.Image"), System.Drawing.Image)
        Me.TacomaMap.Location = New System.Drawing.Point(2, 37)
        Me.TacomaMap.Name = "TacomaMap"
        Me.TacomaMap.Size = New System.Drawing.Size(358, 374)
        Me.TacomaMap.TabIndex = 1
        '
        'Link
        '
        Me.Link.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Link.Location = New System.Drawing.Point(62, 8)
        Me.Link.Name = "Link"
        Me.Link.Size = New System.Drawing.Size(240, 24)
        Me.Link.TabIndex = 3
        Me.Link.TabStop = True
        Me.Link.Text = "WSDOT Traffic Website (Tacoma)"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(96, 376)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 8)
        Me.Label1.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(48, 176)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(16, 8)
        Me.Label2.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(8, 152)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(16, 8)
        Me.Label3.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(5, 373)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(16, 8)
        Me.Label4.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(304, 344)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(16, 8)
        Me.Label5.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(336, 344)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(16, 8)
        Me.Label6.TabIndex = 10
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(160, 176)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(16, 8)
        Me.Label7.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(336, 360)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(16, 8)
        Me.Label8.TabIndex = 8
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(232, 344)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(16, 8)
        Me.Label9.TabIndex = 15
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(272, 344)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(16, 8)
        Me.Label10.TabIndex = 14
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(184, 296)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(16, 8)
        Me.Label11.TabIndex = 13
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(296, 224)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(16, 8)
        Me.Label12.TabIndex = 12
        '
        'Tacoma
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(360, 411)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Link)
        Me.Controls.Add(Me.TacomaMap)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Tacoma"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Tacoma"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Tacoma_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim c As System.Drawing.Color 'ColorPicker.Color 
        Dim path As New Drawing2D.GraphicsPath

        path.AddPolygon(New Point() {New Point(0, 2), New Point(1, 2), New Point(1, 1), New Point(8, 1), New Point(8, 3), _
        New Point(9, 2), New Point(10, 0), New Point(12, 2), New Point(12, 5), New Point(11, 6), New Point(10, 7), New Point(9, 5), _
        New Point(8, 5), New Point(8, 4), New Point(8, 7), New Point(0, 7), New Point(0, 2)})
        Label4.Region = New Region(path)


        LoadTacomaFlowMap()
    End Sub

    Private Function TacomaDefaultMap() As Image
        Return Image.FromStream(MainViewerForm.MainForm.ThisExe.GetManifestResourceStream(MainViewerForm.MainForm.ThisExeName & ".TacomaMap.JPG"))
    End Function

    Private Sub LoadTacomaFlowMap()
        Try
            TacomaMap.Image = Image.FromStream(New IO.MemoryStream(Client.DownloadData("http://images.wsdot.wa.gov/orflow/cam_map_tacoma.gif")))
        Catch ex As ArgumentException 'can happen if downloaded image is corrupt or image was not completely finished being uploaded
            TacomaMap.Image = TacomaDefaultMap()
        Catch ex As Net.WebException
            TacomaMap.Image = TacomaDefaultMap()
        End Try
    End Sub

    Private Sub Label1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Label1.Paint, Label4.Paint
        'draw the 2 small "shiny reflection" lines on each camera label
        e.Graphics.DrawLines(MapColorPen, LinePts)
        e.Graphics.DrawLine(MapColorPen, 10, 4, 10, 3)
    End Sub


End Class
