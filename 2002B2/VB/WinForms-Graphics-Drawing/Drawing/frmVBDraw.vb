Option Strict Off
Option Explicit On 

Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Public Class frmVBDraw
    Inherits System.Windows.Forms.Form
   
   Public Sub New()
      MyBase.New()
      
      frmVBDraw = Me
      
      'This call is required by the Win Form Designer.
      InitializeComponent()
      
      'TODO: Add any initialization after the InitializeComponent() call
      ' Fill Lines Color List
      Dim sColor As String
      For Each sColor In Me.GetColorList()
         Me.cboColor.Items.Add(sColor)
      Next
      Me.cboColor.SelectedItem = "Green"
      
      ' fill Circle color list
      For Each sColor In Me.GetColorList()
         Me.cboCircleColor.Items.Add(sColor)
      Next
      Me.cboCircleColor.SelectedItem = "Blue"
      
   End Sub
   
   'Form overrides dispose to clean up the component list.
    Public Overloads Overrides Sub Dispose()
        MyBase.Dispose()
        components.Dispose()
    End Sub

#Region " Windows Form Designer generated code "

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container
    Private WithEvents chkAutoredraw As System.Windows.Forms.CheckBox

    Private WithEvents cmdDrawArc As System.Windows.Forms.Button
    Private WithEvents cmdFillCircle As System.Windows.Forms.Button
    Private WithEvents Label9 As System.Windows.Forms.Label
    Private WithEvents cmdDrawCircle As System.Windows.Forms.Button
    Private WithEvents txtRadius As System.Windows.Forms.TextBox
    Private WithEvents Label8 As System.Windows.Forms.Label
    Private WithEvents cboCircleColor As System.Windows.Forms.ComboBox
    Private WithEvents Label7 As System.Windows.Forms.Label
    Private WithEvents txtCircleY As System.Windows.Forms.TextBox
    Private WithEvents Label6 As System.Windows.Forms.Label
    Private WithEvents txtCircleX As System.Windows.Forms.TextBox
    Private WithEvents cmdFillRect As System.Windows.Forms.Button
    Private WithEvents cmdDrawRect As System.Windows.Forms.Button
    Private WithEvents cmdDrawLine As System.Windows.Forms.Button
    Private WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents cboColor As System.Windows.Forms.ComboBox
    Private WithEvents txtX1 As System.Windows.Forms.TextBox
    Private WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents txtY1 As System.Windows.Forms.TextBox
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents txtX2 As System.Windows.Forms.TextBox
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents txtY2 As System.Windows.Forms.TextBox
    Private WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents Panel1 As System.Windows.Forms.Panel
    Private WithEvents tabRect As System.Windows.Forms.TabPage
    Private WithEvents tabCircle As System.Windows.Forms.TabPage
    Private WithEvents TabControl1 As System.Windows.Forms.TabControl
    Private WithEvents picCanvas As System.Windows.Forms.PictureBox
    Dim WithEvents frmVBDraw As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.txtCircleY = New System.Windows.Forms.TextBox()
        Me.txtX2 = New System.Windows.Forms.TextBox()
        Me.cmdFillCircle = New System.Windows.Forms.Button()
        Me.txtCircleX = New System.Windows.Forms.TextBox()
        Me.txtX1 = New System.Windows.Forms.TextBox()
        Me.txtY1 = New System.Windows.Forms.TextBox()
        Me.tabCircle = New System.Windows.Forms.TabPage()
        Me.cmdFillRect = New System.Windows.Forms.Button()
        Me.cboCircleColor = New System.Windows.Forms.ComboBox()
        Me.cmdDrawCircle = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabRect = New System.Windows.Forms.TabPage()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkAutoredraw = New System.Windows.Forms.CheckBox()
        Me.cmdDrawArc = New System.Windows.Forms.Button()
        Me.cmdDrawLine = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtY2 = New System.Windows.Forms.TextBox()
        Me.cmdDrawRect = New System.Windows.Forms.Button()
        Me.txtRadius = New System.Windows.Forms.TextBox()
        Me.cboColor = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.picCanvas = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()

        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        txtCircleY.Location = New System.Drawing.Point(116, 8)
        txtCircleY.Text = "60"
        txtCircleY.TabIndex = 2
        txtCircleY.Size = New System.Drawing.Size(26, 20)

        txtX2.Location = New System.Drawing.Point(32, 36)
        txtX2.Text = "50"
        txtX2.TabIndex = 2
        txtX2.Size = New System.Drawing.Size(26, 20)

        cmdFillCircle.Location = New System.Drawing.Point(220, 40)
        cmdFillCircle.Size = New System.Drawing.Size(104, 24)
        cmdFillCircle.TabIndex = 9
        cmdFillCircle.Text = "Fill Circle"

        txtCircleX.Location = New System.Drawing.Point(64, 8)
        txtCircleX.Text = "60"
        txtCircleX.TabIndex = 0
        txtCircleX.Size = New System.Drawing.Size(26, 20)

        txtX1.Location = New System.Drawing.Point(32, 8)
        txtX1.Text = "10"
        txtX1.TabIndex = 0
        txtX1.Size = New System.Drawing.Size(26, 20)

        txtY1.Location = New System.Drawing.Point(84, 8)
        txtY1.Text = "10"
        txtY1.TabIndex = 1
        txtY1.Size = New System.Drawing.Size(26, 20)

        tabCircle.Text = "Circles"
        tabCircle.Size = New System.Drawing.Size(456, 70)
        tabCircle.TabIndex = 1

        cmdFillRect.Location = New System.Drawing.Point(312, 40)
        cmdFillRect.Size = New System.Drawing.Size(108, 24)
        cmdFillRect.TabIndex = 8
        cmdFillRect.Text = "Fill Rectangle"

        cboCircleColor.Location = New System.Drawing.Point(200, 8)
        cboCircleColor.Size = New System.Drawing.Size(104, 21)
        cboCircleColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        cboCircleColor.TabIndex = 4

        cmdDrawCircle.Location = New System.Drawing.Point(128, 40)
        cmdDrawCircle.Size = New System.Drawing.Size(88, 24)
        cmdDrawCircle.TabIndex = 7
        cmdDrawCircle.Text = "Draw Circle"

        TabControl1.Location = New System.Drawing.Point(8, 8)
        TabControl1.Size = New System.Drawing.Size(464, 96)
        TabControl1.SelectedIndex = 0
        TabControl1.TabIndex = 2

        tabRect.Text = "Lines and Rectangles"
        tabRect.Size = New System.Drawing.Size(456, 70)
        tabRect.TabIndex = 2

        Label3.Location = New System.Drawing.Point(60, 40)
        Label3.Text = "Y2:"
        Label3.Size = New System.Drawing.Size(24, 16)
        Label3.TabIndex = 0

        chkAutoredraw.Checked = True
        chkAutoredraw.Location = New System.Drawing.Point(8, 108)
        chkAutoredraw.Text = "Use Autoredraw"
        chkAutoredraw.Size = New System.Drawing.Size(172, 16)
        chkAutoredraw.CheckState = System.Windows.Forms.CheckState.Checked
        chkAutoredraw.TabIndex = 3

        cmdDrawArc.Location = New System.Drawing.Point(328, 40)
        cmdDrawArc.Size = New System.Drawing.Size(108, 24)
        cmdDrawArc.TabIndex = 10
        cmdDrawArc.Text = "Draw Arc"

        cmdDrawLine.Location = New System.Drawing.Point(128, 40)
        cmdDrawLine.Size = New System.Drawing.Size(72, 24)
        cmdDrawLine.TabIndex = 6
        cmdDrawLine.Text = "Draw Line"

        Label8.Location = New System.Drawing.Point(160, 12)
        Label8.Text = "Color:"
        Label8.Size = New System.Drawing.Size(40, 16)
        Label8.TabIndex = 5

        Label9.Location = New System.Drawing.Point(16, 36)
        Label9.Text = "Radius:"
        Label9.Size = New System.Drawing.Size(44, 16)
        Label9.TabIndex = 8

        txtY2.Location = New System.Drawing.Point(84, 36)
        txtY2.Text = "50"
        txtY2.TabIndex = 1
        txtY2.Size = New System.Drawing.Size(26, 20)

        cmdDrawRect.Location = New System.Drawing.Point(204, 40)
        cmdDrawRect.Size = New System.Drawing.Size(104, 24)
        cmdDrawRect.TabIndex = 7
        cmdDrawRect.Text = "Draw Rectangle"

        txtRadius.Location = New System.Drawing.Point(64, 32)
        txtRadius.Text = "35"
        txtRadius.TabIndex = 6
        txtRadius.Size = New System.Drawing.Size(26, 20)

        cboColor.Location = New System.Drawing.Point(168, 8)
        cboColor.Size = New System.Drawing.Size(104, 21)
        cboColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        cboColor.TabIndex = 4

        Label4.Location = New System.Drawing.Point(8, 12)
        Label4.Text = "X1:"
        Label4.Size = New System.Drawing.Size(24, 16)
        Label4.TabIndex = 6

        Label1.Location = New System.Drawing.Point(60, 12)
        Label1.Text = "Y1:"
        Label1.Size = New System.Drawing.Size(24, 16)
        Label1.TabIndex = 0

        Label2.Location = New System.Drawing.Point(8, 40)
        Label2.Text = "X2:"
        Label2.Size = New System.Drawing.Size(24, 16)
        Label2.TabIndex = 2

        picCanvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        picCanvas.BackColor = System.Drawing.Color.White
        picCanvas.Location = New System.Drawing.Point(8, 124)
        picCanvas.Size = New System.Drawing.Size(464, 200)
        picCanvas.TabIndex = 1
        picCanvas.TabStop = False

        Panel1.Size = New System.Drawing.Size(120, 64)
        Panel1.TabIndex = 0

        Label5.Location = New System.Drawing.Point(128, 12)
        Label5.Text = "Color:"
        Label5.Size = New System.Drawing.Size(40, 16)
        Label5.TabIndex = 5

        Label6.Location = New System.Drawing.Point(8, 12)
        Label6.Text = "Center  X:"
        Label6.Size = New System.Drawing.Size(56, 16)
        Label6.TabIndex = 1

        Label7.Location = New System.Drawing.Point(96, 12)
        Label7.Text = "Y:"
        Label7.Size = New System.Drawing.Size(16, 16)
        Label7.TabIndex = 3
        Me.Text = "Drawing in VB.Net"
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(476, 325)

        Me.Controls.Add(chkAutoredraw)
        Me.Controls.Add(TabControl1)
        Me.Controls.Add(picCanvas)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(txtY2)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(txtX2)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(txtY1)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(txtX1)
        tabCircle.Controls.Add(cmdDrawArc)
        tabCircle.Controls.Add(cmdFillCircle)
        tabCircle.Controls.Add(Label9)
        tabCircle.Controls.Add(cmdDrawCircle)
        tabCircle.Controls.Add(txtRadius)
        tabCircle.Controls.Add(Label8)
        tabCircle.Controls.Add(cboCircleColor)
        tabCircle.Controls.Add(Label7)
        tabCircle.Controls.Add(txtCircleY)
        tabCircle.Controls.Add(Label6)
        tabCircle.Controls.Add(txtCircleX)
        tabRect.Controls.Add(cmdFillRect)
        tabRect.Controls.Add(cmdDrawRect)
        tabRect.Controls.Add(cmdDrawLine)
        tabRect.Controls.Add(Label5)
        tabRect.Controls.Add(cboColor)
        tabRect.Controls.Add(Panel1)
        TabControl1.Controls.Add(tabRect)
        TabControl1.Controls.Add(tabCircle)
    End Sub

#End Region

    Protected Sub cmdDrawArc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDrawArc.Click
        Me.DemoCircleDrawing("DrawArc")
    End Sub

    Protected Sub cmdFillCircle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFillCircle.Click
        Me.DemoCircleDrawing("FillCircle")
    End Sub

    Protected Sub cmdDrawCircle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDrawCircle.Click
        Me.DemoCircleDrawing("DrawCircle")
    End Sub

    Protected Sub cmdFillRect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFillRect.Click
        Me.DemoRectBasedDrawing("FillRectangle")

    End Sub
    Protected Sub cmdDrawRect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDrawRect.Click
        Me.DemoRectBasedDrawing("DrawRectangle")
    End Sub

    Protected Sub cmdDrawLine_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDrawLine.Click
        Me.DemoRectBasedDrawing("DrawLine")
    End Sub

    Public Sub DemoRectBasedDrawing(ByVal sDrawItemType As String)
        ' Take the setting in the form under the rectangle tab
        ' and draws the requested shape
        Dim x1, y1, x2, y2 As Single
        x1 = Val(Me.txtX1.Text)
        y1 = Val(Me.txtY1.Text)
        x2 = Val(Me.txtX2.Text)
        y2 = Val(Me.txtY2.Text)

        ' Extrace color from name      
        Dim oColor As Color
        Dim sColorName As String
        sColorName = Me.cboColor.SelectedItem
        oColor = Color.FromName(sColorName)

        ' Create pen from color and set width to 2px
        Dim hPen As Pen = New Pen(oColor, 2)
        Dim oGraphics As Graphics
        If Me.chkAutoredraw.Checked = True Then
            oGraphics = Me.CreateAutoRedrawGraphics(Me.picCanvas)
        Else
            oGraphics = Me.picCanvas.CreateGraphics()
        End If

        Select Case sDrawItemType
            Case "DrawLine"
                ' Draw Line
                oGraphics.DrawLine(hPen, x1, y1, x2, y2)
            Case "DrawRectangle"
                ' Draw Line
                oGraphics.DrawRectangle(hPen, x1, y1, x2, y2)
            Case "FillRectangle"
                ' Draw Line
                oGraphics.FillRectangle(hPen.Brush, x1, y1, x2, y2)
            Case Else
                ' Double check to make sure I didn't misspell anything
                MsgBox("DrawItemType:'" & sDrawItemType & "' was not found.")
        End Select
        oGraphics.Dispose()
    End Sub

    Public Function CreateAutoRedrawGraphics(ByVal oPic As PictureBox) As Graphics
        ' Autoredraw will keep your drawing changes if your form is repainted.
        ' When you use the normal createGraphics function off a picture box, 
        ' your drawing commands run directly against the screen.  If your form 
        ' is covered and the uncovered, your changes will need to be redrawn.  
        ' With autoredraw you are drawing against a memory based image
        ' which is then drawn automatically when your form is repainted.

        ' If a background image if one does not exist one will be created
        ' Check to see if our pic has an image
        If oPic.Image Is Nothing Then
            ' Create the image as a bitmap (to be painted in the background)
            oPic.Image = New Bitmap(oPic.ClientRectangle.Width, oPic.ClientRectangle.Height)
        End If
        CreateAutoRedrawGraphics = Graphics.FromImage(oPic.Image)
        oPic.Invalidate()
    End Function

    Public Sub DemoCircleDrawing(ByVal sDrawItemType As String)
        Dim circleTop, circleLeft, circleRadius, circleWidth, circleHeight As Single

        ' Drawing circles and ovals requires a bounding rectangle
        ' This is a quick conversion from focus/radius to a bouding rectangle
        circleRadius = Val(Me.txtRadius.Text)
        circleTop = Val(Me.txtCircleX.Text) - circleRadius
        circleLeft = Val(Me.txtCircleY.Text) - circleRadius
        circleWidth = circleRadius * 2
        circleHeight = circleRadius * 2

        ' Default angles for drawing arc
        Dim angleFrom As Integer
        Dim angleTo As Integer
        angleFrom = 90
        angleTo = 90

        ' Extract color from name      
        Dim oColor As Color
        Dim sColorName As String
        sColorName = Me.cboCircleColor.SelectedItem
        oColor = Color.FromName(sColorName)

        ' Create pen from color and set width to 2px
        Dim hPen As Pen = New Pen(oColor, 2)
        Dim oGraphics As Graphics

        If Me.chkAutoredraw.Checked = True Then
            oGraphics = Me.CreateAutoRedrawGraphics(Me.picCanvas)
        Else
            oGraphics = Me.picCanvas.CreateGraphics()
        End If

        Select Case sDrawItemType
            Case "DrawCircle"
                ' Draw Circle
                oGraphics.DrawEllipse(hPen, circleLeft, circleTop, circleWidth, circleHeight)
            Case "FillCircle"
                ' Fill Circle
                oGraphics.FillEllipse(hPen.Brush, circleLeft, circleTop, circleWidth, circleHeight)
            Case "DrawArc"
                ' Draw Arc
                oGraphics.DrawArc(hPen, circleLeft, circleTop, circleWidth, circleHeight, angleFrom, angleTo)
            Case Else
                ' Double check to make sure I didn't misspell anything
                MsgBox("DrawItemType:'" & sDrawItemType & "' was not found.")
        End Select
        oGraphics.Dispose()

    End Sub
    Private Function GetColorList() As Collections.ArrayList
        ' returns an arraylist of the colors in the drawing.knownColor enumerator
        Dim oRet As New Collections.ArrayList()
        With oRet
            .Add("AliceBlue")
            .Add("AntiqueWhite")
            .Add("Aqua")
            .Add("Aquamarine")
            .Add("Azure")
            .Add("Beige")
            .Add("Bisque")
            .Add("Black")
            .Add("BlanchedAlmond")
            .Add("Blue")
            .Add("BlueViolet")
            .Add("Brown")
            .Add("BurlyWood")
            .Add("CadetBlue")
            .Add("Chartreuse")
            .Add("Chocolate")
            .Add("Coral")
            .Add("Cornflower")
            .Add("Cornsilk")
            .Add("Crimson")
            .Add("Cyan")
            .Add("DarkBlue")
            .Add("DarkCyan")
            .Add("DarkGoldenrod")
            .Add("DarkGray")
            .Add("DarkGreen")
            .Add("DarkKhaki")
            .Add("DarkMagenta")
            .Add("DarkOliveGreen")
            .Add("DarkOrange")
            .Add("DarkOrchid")
            .Add("DarkRed")
            .Add("DarkSalmon")
            .Add("DarkSeaGreen")
            .Add("DarkSlateBlue")
            .Add("DarkSlateGray")
            .Add("DarkTurquoise")
            .Add("DarkViolet")
            .Add("DeepPink")
            .Add("DeepSkyBlue")
            .Add("DimGray")
            .Add("DodgerBlue")
            .Add("Firebrick")
            .Add("FloralWhite")
            .Add("ForestGreen")
            .Add("Fuchsia")
            .Add("Gainsboro")
            .Add("GhostWhite")
            .Add("Gold")
            .Add("Goldenrod")
            .Add("Gray")
            .Add("Green")
            .Add("GreenYellow")
            .Add("Honeydew")
            .Add("HotPink")
            .Add("IndianRed")
            .Add("Indigo")
            .Add("Ivory")
            .Add("Khaki")
            .Add("Lavender")
            .Add("LavenderBlush")
            .Add("LawnGreen")
            .Add("LemonChiffon")
            .Add("LightBlue")
            .Add("LightCoral")
            .Add("LightCyan")
            .Add("LightGoldenrodYellow")
            .Add("LightGray")
            .Add("LightGreen")
            .Add("LightPink")
            .Add("LightSalmon")
            .Add("LightSeaGreen")
            .Add("LightSkyBlue")
            .Add("LightSlateGray")
            .Add("LightSteelBlue")
            .Add("LightYellow")
            .Add("Lime")
            .Add("LimeGreen")
            .Add("Linen")
            .Add("Magenta")
            .Add("Maroon")
            .Add("MediumAquamarine")
            .Add("MediumBlue")
            .Add("MediumOrchid")
            .Add("MediumPurple")
            .Add("MediumSeaGreen")
            .Add("MediumSlateBlue")
            .Add("MediumSpringGreen")
            .Add("MediumTurquoise")
            .Add("MediumVioletRed")
            .Add("MidnightBlue")
            .Add("MintCream")
            .Add("MistyRose")
            .Add("Moccasin")
            .Add("NavajoWhite")
            .Add("Navy")
            .Add("OldLace")
            .Add("Olive")
            .Add("OliveDrab")
            .Add("Orange")
            .Add("OrangeRed")
            .Add("Orchid")
            .Add("PaleGoldenrod")
            .Add("PaleGreen")
            .Add("PaleTurquoise")
            .Add("PaleVioletRed")
            .Add("PapayaWhip")
            .Add("PeachPuff")
            .Add("Peru")
            .Add("Pink")
            .Add("Plum")
            .Add("PowderBlue")
            .Add("Purple")
            .Add("Red")
            .Add("RosyBrown")
            .Add("RoyalBlue")
            .Add("SaddleBrown")
            .Add("Salmon")
            .Add("SandyBrown")
            .Add("SeaGreen")
            .Add("SeaShell")
            .Add("Sienna")
            .Add("Silver")
            .Add("SkyBlue")
            .Add("SlateBlue")
            .Add("SlateGray")
            .Add("Snow")
            .Add("SpringGreen")
            .Add("SteelBlue")
            .Add("Tan")
            .Add("Teal")
            .Add("Thistle")
            .Add("Tomato")
            .Add("Transparent")
            .Add("Turquoise")
            .Add("Violet")
            .Add("Wheat")
            .Add("White")
            .Add("WhiteSmoke")
            .Add("Yellow")
            .Add("YellowGreen")
        End With
        GetColorList = oRet
    End Function

End Class
