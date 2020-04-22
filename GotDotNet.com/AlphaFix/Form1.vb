Imports System.Runtime.InteropServices
Imports System.Drawing.Imaging

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Location = New System.Drawing.Point(8, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 32)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "DotNet Standard"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label2.Location = New System.Drawing.Point(8, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(168, 32)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Alpha Channel Restored"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(184, 94)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alpha Fix"
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Shell Icon API "

    <DllImport("shell32.dll", EntryPoint:="ExtractIconEx", CallingConvention:=CallingConvention.Cdecl)> _    Private Shared Function ExtractSmallIconEx _            (ByVal lpszFile As String, _            ByVal nIconIndex As Integer, _            ByVal phiconLarge As IntPtr, _            ByVal phiconSmall As IntPtr(), _            ByVal nIcons As Integer) As Boolean
    End Function
    <DllImport("user32", CallingConvention:=CallingConvention.Cdecl)> _    Private Shared Function DestroyIcon _            (ByVal hIcon As IntPtr) As Boolean
    End Function    Private Structure ICONINFO
        Dim fIcon As Boolean
        Dim xHotspot As Integer
        Dim yHotspot As Integer
        Dim hbmMask As IntPtr
        Dim hbmColor As IntPtr    End Structure
    <DllImport("user32", CallingConvention:=CallingConvention.Cdecl)> _    Private Shared Function GetIconInfo( _
            ByVal hIcon As IntPtr, _
            ByRef piconinfo As ICONINFO) As Boolean
    End Function#End Region

    Private Function ShellIcon(ByVal StartIndex As Integer, ByVal FixAlpha As Boolean) As Bitmap

        Dim hIco() As IntPtr = {New IntPtr}
        ReDim hIco(0)

        Call ExtractSmallIconEx("shell32.dll", StartIndex, IntPtr.Zero, hIco, 1)

        'WindowsXP icons have an Alpha Channel. A new Bitmap object
        'created from image or icon has a PixelFormat of 32bppRgb which
        'does not cater for the Alpha Channel. Although the bitmap
        'object does not support Alpha, the data is still there, so
        'we can simply copy the BitMapData to a 32bppArgb bitmap object.
        'This is done in FixAlphaBitmap.
        If Environment.OSVersion.Version.Major >= 5 AndAlso _
           Environment.OSVersion.Version.Minor >= 1 AndAlso _
           Me.ColorDepth = 32 AndAlso FixAlpha = True Then

            Dim ii As New ICONINFO
            GetIconInfo(hIco(0), ii)

            Dim hBitmap As IntPtr = ii.hbmColor
            Dim bmp As Bitmap = Bitmap.FromHbitmap(hBitmap)

            DestroyIcon(hBitmap)
            DestroyIcon(hIco(0))

            Return FixAlphaBitmap(bmp)

        Else

            Return Bitmap.FromHicon(hIco(0))

        End If

    End Function

    Private Function FixAlphaBitmap(ByVal bmSource As Bitmap) As Bitmap

        'WARNING! This function will fail if the passed bitmap is not of
        'the correct Pixelformat.
        Dim bmData(1) As Imaging.BitmapData
        Dim bmBounds As New Rectangle(0, 0, bmSource.Width, bmSource.Height)
        Dim bmArray(bmSource.Width * bmSource.Height) As Integer
        Dim dstArray(bmSource.Width * bmSource.Height) As Integer

        bmData(0) = bmSource.LockBits(bmBounds, ImageLockMode.ReadOnly, bmSource.PixelFormat)
        Dim dstBitmap As New Bitmap(bmSource.Width, bmSource.Height, bmData(0).Stride, PixelFormat.Format32bppArgb, bmData(0).Scan0)
        bmData(1) = dstBitmap.LockBits(bmBounds, ImageLockMode.WriteOnly, dstBitmap.PixelFormat)

        Marshal.Copy(bmData(0).Scan0, bmArray, 0, bmSource.Width * bmSource.Height)
        Marshal.Copy(bmData(1).Scan0, dstArray, 0, bmSource.Width * bmSource.Height)

        Dim x, y As Integer

        For y = 0 To bmSource.Height - 1
            For x = 0 To bmSource.Width - 1
                dstArray(y * bmSource.Width + x) = bmArray(y * bmSource.Width + x)
            Next
        Next

        Marshal.Copy(bmArray, 0, bmData(0).Scan0, bmSource.Width * bmSource.Height)
        Marshal.Copy(dstArray, 0, bmData(1).Scan0, bmSource.Width * bmSource.Height)

        bmSource.UnlockBits(bmData(0))
        dstBitmap.UnlockBits(bmData(1))

        Return dstBitmap

    End Function

#Region " GetDeviceCaps "
    'What happened to SystemInformation.DisplaySettings()?

    <DllImport("Gdi32", CallingConvention:=CallingConvention.Cdecl)> _
    Public Shared Function GetDeviceCaps _
            (ByVal hDC As IntPtr, _
            ByVal nIndex As Integer) As Integer
    End Function

    <DllImport("Gdi32", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.Cdecl)> _
    Private Shared Function CreateDC _
            (ByVal lpszDriver As String, _
            ByVal lpszDeviceName As String, _
            ByVal lpszOutput As String, _
            ByVal devMode As IntPtr) As IntPtr
    End Function

    <DllImport("Gdi32", CallingConvention:=CallingConvention.Cdecl)> _
    Private Shared Function DeleteDC _
            (ByVal hDC As IntPtr) As Boolean
    End Function

    Public Const BITSPIXEL As Integer = 12
    Public Const PLANES As Integer = 14

    Public ReadOnly Property ColorDepth() As Integer
        Get
            Dim screenDC As IntPtr = CreateDC("DISPLAY", Nothing, Nothing, IntPtr.Zero)
            Dim bitDepth As Integer = GetDeviceCaps(screenDC, BITSPIXEL)
            bitDepth *= GetDeviceCaps(screenDC, PLANES)
            DeleteDC(screenDC)
            Return bitDepth
        End Get
    End Property

#End Region

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Image = ShellIcon(24, False)
        Label2.Image = ShellIcon(24, True)
    End Sub

End Class
