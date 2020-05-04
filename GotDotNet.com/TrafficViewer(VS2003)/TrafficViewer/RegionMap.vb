Option Strict On
Public Class RegionMap
    Inherits System.Windows.Forms.Form
    Private MousePosX, MousePosY As Integer
    Friend MapPrefix As String = "Wa"

    Private Reader As IO.StreamReader, DataStream As IO.Stream
    Private ThisExe As Reflection.Assembly = Reflection.Assembly.GetExecutingAssembly
    Private ThisExeName As String = ThisExe.GetName.Name
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
    Friend WithEvents Map As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Map = New System.Windows.Forms.PictureBox
        Me.SuspendLayout()
        '
        'Map
        '
        Me.Map.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Map.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Map.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Map.Location = New System.Drawing.Point(0, 0)
        Me.Map.Name = "Map"
        Me.Map.Size = New System.Drawing.Size(419, 294)
        Me.Map.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Map.TabIndex = 1
        Me.Map.TabStop = False
        '
        'RegionMap
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(419, 294)
        Me.Controls.Add(Me.Map)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "RegionMap"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Map_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Map.MouseDown
        If e.Button = MouseButtons.Left Then
            MousePosX = Me.MousePosition.X - Me.Location.X
            MousePosY = Me.MousePosition.Y - Me.Location.Y
        End If
    End Sub

    Private Sub Map_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Map.MouseMove
        If e.Button = MouseButtons.Left Then
            Me.Location = New Point(Me.MousePosition.X - MousePosX, Me.MousePosition.Y - MousePosY)
        End If
    End Sub

    Private Sub RegionMap_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMap()
    End Sub

    Friend Sub LoadMap()
        DataStream = ThisExe.GetManifestResourceStream(ThisExeName & "." & MapPrefix & "Map.bmp")
        Map.Image = Image.FromStream(DataStream)
        DataStream.Close()
    End Sub

    Private Sub Map_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Map.Click
        Select Case True
            Case Me.MousePosition.X > Me.Left + CInt(Me.Width / 2) AndAlso Me.MousePosition.Y > Me.Top + CInt(Me.Height / 2)
                MainViewerForm.MainForm.MapRegion = "SE"
            Case Me.MousePosition.X <= Me.Left + CInt(Me.Width / 2) AndAlso Me.MousePosition.Y > Me.Top + CInt(Me.Height / 2)
                MainViewerForm.MainForm.MapRegion = "SW"
            Case Me.MousePosition.X > Me.Left + CInt(Me.Width / 2) AndAlso Me.MousePosition.Y <= Me.Top + CInt(Me.Height / 2)
                MainViewerForm.MainForm.MapRegion = "NE"
            Case Me.MousePosition.X <= Me.Left + CInt(Me.Width / 2) AndAlso Me.MousePosition.Y <= Me.Top + CInt(Me.Height / 2)
                MainViewerForm.MainForm.MapRegion = "NW"
            Case Else
                MainViewerForm.MainForm.MapRegion = "NW"
        End Select
        Me.Hide()
    End Sub

    Private Sub RegionMap_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Hide()
        e.Cancel = True
    End Sub
End Class
