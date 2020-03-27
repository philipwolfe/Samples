Option Strict On

Imports System.Reflection

' Embedded Resources
' Resources such as bitmaps can be 'Embedded' and compiled into the assembly.  Simply
' addd the desired resource, in this case a .bmp file to the project and then set the
' Build Action property of the file to 'Embedded Resource'

Public Class Form1

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Load Images into the thumbnail size PictureBoxes
        GetThumbImages()

        ' Set Form to close instead of minimize
        MinimizeBox = False
    End Sub

    ' Load the 4 embedded images from the assembly into the thumbnail picture boxes
    Private Sub GetThumbImages()
        Dim stream As System.IO.Stream
        Dim bmp As Bitmap

        ' Get Assembly
        Dim asm As Assembly = Assembly.GetExecutingAssembly()

        ' Get images as a stream from the Assembly
        ' Thumb1
        stream = asm.GetManifestResourceStream("EmbeddedResources.Gone Fishing.bmp")
        bmp = New Bitmap(stream)
        Thumb1PictureBox.Image = bmp

        ' Thumb2
        stream = asm.GetManifestResourceStream("EmbeddedResources.Coffee Bean.bmp")
        bmp = New Bitmap(stream)
        Thumb2PictureBox.Image = bmp

        ' Thumb3
        stream = asm.GetManifestResourceStream("EmbeddedResources.River Sumida.bmp")
        bmp = New Bitmap(stream)
        Thumb3PictureBox.Image = bmp

        ' Thumb4
        stream = asm.GetManifestResourceStream("EmbeddedResources.Santa Fe Stucco.bmp")
        bmp = New Bitmap(stream)
        Thumb4PictureBox.Image = bmp
    End Sub


    ' Get image compiled as an embedded resource for the form background.
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        ' Get Assembly
        Dim asm As Assembly = Assembly.GetExecutingAssembly()

        ' Get image as a stream from the Assembly
        Dim stream As System.IO.Stream = asm.GetManifestResourceStream("EmbeddedResources.Greenstone.bmp")

        ' Save Stream to a bitmap
        Dim backGroundImage As New Bitmap(stream)

        ' Set the drawing rectangle
        Dim rect As New Rectangle(0, 0, backGroundImage.Width, backGroundImage.Height)

        ' Draw the Imagee
        e.Graphics.DrawImage(backGroundImage, Me.ClientRectangle, rect, GraphicsUnit.Pixel)
    End Sub

    Private Sub Thumb1PictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Thumb1PictureBox.Click
        ' Set the MainPicture Image to the clicked Thumb Image
        MainPictureBox.Image = Thumb1PictureBox.Image
    End Sub

    Private Sub Thumb2PictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Thumb2PictureBox.Click
        ' Set the MainPicture Image to the clicked Thumb Image
        MainPictureBox.Image = Thumb2PictureBox.Image
    End Sub

    Private Sub Thumb3PictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Thumb3PictureBox.Click
        ' Set the MainPicture Image to the clicked Thumb Image
        MainPictureBox.Image = Thumb3PictureBox.Image
    End Sub

    Private Sub Thumb4PictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Thumb4PictureBox.Click
        ' Set the MainPicture Image to the clicked Thumb Image
        MainPictureBox.Image = Thumb4PictureBox.Image
    End Sub
End Class
