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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(192, 24)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(292, 260)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button1})
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private DownX, DownY As Integer
    Private LastRect As Rectangle
    Private NonClientWidth As Integer = Me.Width - (Me.ClientSize.Width + 2)
    Private NonClientHeight As Integer = Me.Height - (Me.ClientSize.Height + 2)
    Private FormRect As Rectangle
    Private ButtonCount As Int32 = 1

    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        DownX = CInt(e.X)
        DownY = CInt(e.Y)
        Me.Cursor = Cursors.Cross
        Dim pt As New System.Drawing.Point(Me.Left + NonClientWidth, Me.Top + NonClientHeight)
        FormRect = New Rectangle(pt, Me.ClientSize)
    End Sub

    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        If DownX > 0 Then
            Dim ThisX As Int32 = Me.Left + NonClientWidth + DownX
            Dim ThisY As Int32 = Me.Top + NonClientHeight + DownY
            Dim ThisRect As New Rectangle(ThisX, ThisY, e.X - DownX, e.Y - DownY)

            If ThisRect.Bottom > FormRect.Bottom Then
                ThisRect.Height = (FormRect.Bottom - ThisY) - 2
            ElseIf ThisRect.Bottom < FormRect.Top Then
                ThisRect.Height = (FormRect.Top - ThisY) - 2
            End If

            If ThisRect.Right > FormRect.Right Then
                ThisRect.Width = (FormRect.Right - ThisX) - 2
            ElseIf ThisRect.Right < FormRect.Left Then
                ThisRect.Width = (FormRect.Left - ThisX) - 2
            End If

            Console.WriteLine(ThisRect.Height)
            If LastRect.X <> 0 Then
                ControlPaint.DrawReversibleFrame(LastRect, System.Drawing.Color.Black, FrameStyle.Dashed)
            End If
            ControlPaint.DrawReversibleFrame(ThisRect, System.Drawing.Color.Black, FrameStyle.Dashed)
            LastRect = ThisRect
        End If
    End Sub

    Private Sub Form1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp
        ControlPaint.DrawReversibleFrame(LastRect, System.Drawing.Color.Black, FrameStyle.Dashed)
        Dim b As New Button()
        b.SuspendLayout()
        Me.Controls.Add(b)

        b.Left = LastRect.Left - (Me.Left + NonClientWidth)
        b.Top = LastRect.Top - (Me.Top + NonClientHeight)
        b.Width = LastRect.Width
        b.Height = LastRect.Height
        ButtonCount += 1
        b.Name = "Button" & ButtonCount.ToString
        b.Text = b.Name
        b.ResumeLayout()

        DownX = 0
        DownY = 0
        Cursor = Cursors.Default
        LastRect.X = 0
    End Sub

End Class
