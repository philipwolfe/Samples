Option Strict On

Imports Microsoft.WindowsCE.Forms

Public Class Form1

    ' Keeps track of what next screen angle should be
    Private CurrentAngle As ScreenOrientation = ScreenOrientation.Angle0

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load, MyBase.Load
        ' Display the OK button for closing the application.
        MinimizeBox = False

        ' Init ScreenOrientation to default Angle0 (standard portrait view)
        ' by setting the index to 0
        OrientationComboBox.SelectedIndex = 0
    End Sub

    Private Sub ChangeOrientation(ByVal orientation As ScreenOrientation)
        ' Set Orientation
        SystemSettings.ScreenOrientation = orientation

        ' Calculate the height of TextBox2 based on the ClientRectangle and the 2 panels
        ' so that the Textbox uses all available space.
        TextBox2.Height = Me.ClientRectangle.Height - Panel1.Height - Panel2.Height
    End Sub


    Private Sub OrientationComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrientationComboBox.SelectedIndexChanged
        If OrientationComboBox.SelectedIndex = 1 Then
            ' Landscape
            ChangeOrientation(ScreenOrientation.Angle90)
        Else
            ' Portrait (default anything other than value of 1 to portrait)
            ChangeOrientation(ScreenOrientation.Angle0)
        End If
    End Sub
End Class
