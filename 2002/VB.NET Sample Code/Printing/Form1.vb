Option Strict Off

Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing

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
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PageSetupDialog1 As System.Windows.Forms.PageSetupDialog
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents fileMenu As System.Windows.Forms.MenuItem
    Friend WithEvents filePrintPreviewMenuItem As System.Windows.Forms.MenuItem
    Friend WithEvents printPreviewButton As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog()
        Me.MainMenu1 = New System.Windows.Forms.MainMenu()
        Me.fileMenu = New System.Windows.Forms.MenuItem()
        Me.filePrintPreviewMenuItem = New System.Windows.Forms.MenuItem()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.printPreviewButton = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Location = New System.Drawing.Point(398, 17)
        Me.PrintPreviewDialog1.MaximumSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Opacity = 1
        Me.PrintPreviewDialog1.TransparencyKey = System.Drawing.Color.Empty
        Me.PrintPreviewDialog1.Visible = False
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.fileMenu})
        '
        'fileMenu
        '
        Me.fileMenu.Index = 0
        Me.fileMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.filePrintPreviewMenuItem})
        Me.fileMenu.Text = "File"
        '
        'filePrintPreviewMenuItem
        '
        Me.filePrintPreviewMenuItem.Index = 0
        Me.filePrintPreviewMenuItem.Text = "Print Pre&view"
        '
        'PrintDocument1
        '
        '
        'printPreviewButton
        '
        Me.printPreviewButton.Location = New System.Drawing.Point(24, 24)
        Me.printPreviewButton.Name = "printPreviewButton"
        Me.printPreviewButton.Size = New System.Drawing.Size(240, 24)
        Me.printPreviewButton.TabIndex = 36
        Me.printPreviewButton.Text = "Print Preview"
        '
        'CheckBox1
        '
        Me.CheckBox1.Location = New System.Drawing.Point(24, 64)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(160, 24)
        Me.CheckBox1.TabIndex = 37
        Me.CheckBox1.Text = "Draw Gradient Text"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(312, 97)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.CheckBox1, Me.printPreviewButton})
        Me.Menu = Me.MainMenu1
        Me.Name = "Form1"
        Me.Text = "Some Fun with Graphics"
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private Sub printPreviewButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles printPreviewButton.Click, filePrintPreviewMenuItem.Click
        PrintPreviewControl()

    End Sub

    Private Sub PrintPreviewControl()
        Dim ppdlg As New PrintPreviewDialog()
        With ppdlg
            .Document = PrintDocument1
            .WindowState = FormWindowState.Maximized
            .ShowDialog()
            .Dispose()
        End With

    End Sub

    Private Sub MyPrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim topMargin = e.MarginBounds.Top
        Dim leftMargin = e.MarginBounds.Left
        Dim rightMargin = e.MarginBounds.Right
        Dim bottomMargin = e.MarginBounds.Bottom
        Dim pageWidth = e.MarginBounds.Width
        Dim pageHeight = e.MarginBounds.Height
        Dim vPos As Single = topMargin
        Dim hPos As Single = leftMargin
        Dim textLine As String = "Some Cool Text"
        Dim textWidth As Single = 0
        Dim textHeight As Single = 0

        ' create pens
        Dim penWideRed As Pen = New Pen(Color.Red, 10)
        Dim penDashedBlack As Pen = New Pen(Color.Black, 6)
        penDashedBlack.DashStyle = DashStyle.Dash
        penDashedBlack.DashCap = DashCap.Round

        ' create some brushes for the text and filled shapes
        Dim lgRectangle As Rectangle
        lgRectangle = New Rectangle( _
                            CInt(e.PageBounds.Width / 2), _
                            CInt(e.PageBounds.Height / 6), _
                            CInt(e.PageBounds.Width / 3), _
                            CInt(e.PageBounds.Height / 10))

        Dim myLGBrush As New LinearGradientBrush( _
            lgRectangle, _
            Color.Purple, _
            Color.LightBlue, _
            LinearGradientMode.Horizontal)

        ' create brushes
        Dim brushBlue As Brush = New SolidBrush(Color.Blue)
        Dim brushBlack As Brush = Brushes.Black

        ' create some fonts for use on the print document
        Dim fontSmall As Font = New Font("Verdana", 5, GraphicsUnit.Millimeter)
        Dim fontExtraLarge As Font = New Font("Verdana", 25, GraphicsUnit.Millimeter)

        ' create fonts
        Dim fontMedium As Font = New Font("Verdana", 14)
        Dim fontLargeBold As Font
        fontLargeBold = New Font("Verdana", 36, FontStyle.Bold)


        Dim hPos1 As Integer = e.MarginBounds.Left
        Dim hPos2 As Integer = e.MarginBounds.Width / 2
        Dim vPos1 As Integer = e.MarginBounds.Top
        Dim vPos2 As Integer = e.MarginBounds.Height / 2
        Dim rectWidth As Integer = hPos2 - hPos1
        Dim rectHeight As Integer = vPos2 - vPos1

        ' draw outline shapes
        e.Graphics.DrawLine(penWideRed, hPos1, vPos1, hPos2, vPos2)
        e.Graphics.DrawRectangle(penDashedBlack, _
                                hPos1, _
                                vPos1, _
                                rectWidth, _
                                rectHeight)

        ' draw an elipse filled with a linear gradient brush
        e.Graphics.FillEllipse(myLGBrush, lgRectangle)

        ' draw filled blue rectangle
        Dim fillRectangle As Rectangle
        fillRectangle = New Rectangle( _
                            lgRectangle.Left, _
                            lgRectangle.Bottom, _
                            lgRectangle.Width, _
                            lgRectangle.Height)
        e.Graphics.FillRectangle(brushBlue, fillRectangle)

        ' draw the text using the large font
        e.Graphics.DrawString("testing fontLargeBold", fontLargeBold, brushBlue, hPos, vPos)

        Dim centeredText As String = "Centering Text is a breeze!"
        Dim rectText As Rectangle = New Rectangle( _
                                                e.PageBounds.Width * 0.5, _
                                                e.PageBounds.Height * 0.45, _
                                                e.PageBounds.Width * 0.4, _
                                                e.PageBounds.Height * 0.1)
        ' draw centered text
        textWidth = e.Graphics.MeasureString(centeredText, _
                                            fontMedium).Width
        textHeight = fontMedium.GetHeight(e.Graphics)
        hPos = rectText.Left + (rectText.Width - textWidth) / 2
        vPos = rectText.Top + (rectText.Height - textHeight) / 2
        e.Graphics.DrawRectangle(Pens.Black, rectText)
        e.Graphics.DrawString(centeredText, fontMedium, brushBlack, hPos, vPos)


        If Me.CheckBox1.Checked = True Then
            ' draw text filled with a linear gradient brush
            e.Graphics.DrawString(textLine, _
                                    New Font("Verdana", 24, FontStyle.Bold), _
                                    New LinearGradientBrush(New Rectangle(e.MarginBounds.Left, CInt(e.PageBounds.Height / 2), e.Graphics.MeasureString(textLine, New Font("Verdana", 24)).Width, e.Graphics.MeasureString(textLine, New Font("Verdana", 24)).Height), Color.Red, Color.Blue, LinearGradientMode.Horizontal), _
                                    e.MarginBounds.Left, _
                                    CInt(e.PageBounds.Height / 2))

        End If

        ' print a graphic
        e.Graphics.DrawImage(Image.FromFile(Application.StartupPath & "\..\franklins_sm.jpg"), e.MarginBounds.Left, CInt(e.PageBounds.Height - e.PageBounds.Height / 5))

    End Sub


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
