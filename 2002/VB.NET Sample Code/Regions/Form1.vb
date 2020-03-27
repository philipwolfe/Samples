'-- REGION BUILDER - by Carl Franklin (carl@franklins.net)
'   This program lets you design windows graphically using regions
'   Run the program, draw a shape, and release the mouse.
'   A new window will be created with a Close button somewhere in the middle.
'   Press the Code button on the main form to display VB code that
'   you can use to re-create the form in any VB.NET Windows application.
'   Carl will get you up to speed on Visual Basic.NET in 5 days.
'   Details: http://www.franklins.net/vbnetmc.asp 
Public Class Form1
    Inherits System.Windows.Forms.Form
    Private Points(10000) As System.Drawing.Point
    Private NumPoints As Int32
    Private Drawing As Boolean
    Private Box As Rectangle

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
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnSave As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.MainMenu1 = New System.Windows.Forms.MainMenu()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.MenuItem3 = New System.Windows.Forms.MenuItem()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(10, 0)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(96, 28)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Code"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PictureBox1.Location = New System.Drawing.Point(0, 35)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(768, 375)
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem2, Me.MenuItem3})
        Me.MenuItem1.Text = "&File"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 0
        Me.MenuItem2.Text = "&Edit"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 1
        Me.MenuItem3.Text = "E&xit"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(768, 410)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnSave, Me.PictureBox1})
        Me.Menu = Me.MainMenu1
        Me.Name = "Form1"
        Me.Text = "Window Builder"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PictureBox1.BackColor = System.Drawing.Color.Blue
    End Sub

    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Dim Y As Single
        Y = Me.ClientSize.Height - btnSave.Size.Height
        PictureBox1.Size = New System.Drawing.Size(PictureBox1.Size.Width, Y)
    End Sub

    Private Sub PictureBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        '-- Initialize the drawing
        Drawing = True
        NumPoints = 0
        ReDim Points(10000)
        'Console.WriteLine("Drawing")
    End Sub

    Private Sub PictureBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        Me.Text = "(" & e.X.ToString & "," & e.Y.ToString & ")"
        If Drawing Then
            If NumPoints > 10000 Then
                Drawing = False
                MsgBox("Buffer Full")
            Else
                '-- Add this point to the array
                Points(NumPoints).X = e.X
                Points(NumPoints).Y = e.Y

                '-- Adjust the Box rectangle to the bounds of this drawing
                If NumPoints > 0 Then
                    If e.X < Box.X Then
                        Box.X = e.X
                    End If
                    If e.Y < Box.Y Then
                        Box.Y = e.Y
                    End If
                    If e.X > Box.X + Box.Width Then
                        Box.Width = e.X - Box.X
                    End If
                    If e.Y > Box.Y + Box.Height Then
                        Box.Height = e.Y - Box.Y
                    End If
                    With PictureBox1
                        .CreateGraphics.DrawLine(Pens.White, Points(NumPoints - 1), Points(NumPoints))
                    End With
                    'Console.WriteLine(e.X.ToString & " " & e.Y.ToString)
                Else
                    '-- First point, reset the box
                    Box.X = e.X
                    Box.Y = e.Y
                    Box.Width = 0
                    Box.Height = 0
                End If
                '-- Bump up the point counter
                NumPoints = NumPoints + 1
            End If
        End If
    End Sub

    Private Sub PictureBox1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp
        Dim i As Int32
        If NumPoints < 1 Then
            Drawing = False
            Exit Sub
        End If
        If Drawing = True Then
            '-- Remove the last point (0,0)
            NumPoints = NumPoints - 1
            Drawing = False '-- Reset drawing flag

            '-- Create a new form
            Dim frm As New Form2()

            '-- Make sure the last point is the same as the first point (to 
            '   avoid strange points to the north-west.
            If Points(0).ToString <> Points(NumPoints).ToString Then
                NumPoints = NumPoints + 1
                Points(NumPoints).X = Points(0).X
                Points(NumPoints).Y = Points(0).Y
            End If

            '-- Resize the Points array
            ReDim Preserve Points(NumPoints)

            '-- Scale points to fit inside the box
            For i = 0 To NumPoints
                Points(i).X = Points(i).X - Box.X
                Points(i).Y = Points(i).Y - Box.Y
            Next

            '-- Reset the rectangle's X and Y to 0
            Box.X = 0
            Box.Y = 0

            '-- Define an array of bytes containing the type of the path points
            Dim Types(NumPoints) As Byte
            For i = 0 To NumPoints
                Types(i) = System.Drawing.Drawing2D.PathPointType.Line
            Next

            '-- Create a GraphPath 
            Dim GP As New System.Drawing.Drawing2D.GraphicsPath(Points, Types)

            '-- Resize the new form to the box
            frm.Size = New Drawing.Size(Box.Width, Box.Height + (2 * (Me.Size.Height - Me.ClientSize.Height)))
            '-- Set the region
            frm.Region = New Region(GP)
            '-- Move the button to somewhere in the middle
            frm.btnClose.Location = New Point(Box.X + (Box.Width \ 2) - (frm.btnClose.Size.Width \ 2), Box.Y + (Box.Height \ 2) - (frm.btnClose.Size.Height \ 2))
            frm.Show() '-- Show the form

            '-- Clear the picture control 
            PictureBox1.CreateGraphics.Clear(System.Drawing.Color.Blue)
            'Console.WriteLine(Box.X.ToString & "," & Box.Y.ToString & "," & Box.Width.ToString & "," & Box.Height.ToString)
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim Output As String
        Dim i As Int32
        '-- Generate code and put it in a rich text box 
        Output = "'-- Add this code to the Form_Load of your application" & vbCrLf & _
            "Dim GP As New System.Drawing.Drawing2D.GraphicsPath(Drawing.Drawing2D.FillMode.Alternate)" & vbCrLf
        For i = 1 To NumPoints
            Output = Output & "GP.AddLine(" & Points(i - 1).X.ToString & ", " & Points(i - 1).Y.ToString & ", " & Points(i).X.ToString & ", " & Points(i).Y.ToString & ")" & vbCrLf
        Next
        Output = Output & "Me.Region = New Region(GP)" & vbCrLf
        Dim frm As New Form3()
        frm.RichTextBox1.Text = Output
        frm.Show()

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub
End Class
