Option Strict On

Imports Microsoft.WindowsCE.Forms

Public Class Form1

    ' Keeps track of what next screen angle should be
    Private CurrentAngle As ScreenOrientation = ScreenOrientation.Angle0
    Private HardButton1 As HardwareButton
    Private HardButton2 As HardwareButton
    Private HardButton3 As HardwareButton
    Private HardButton4 As HardwareButton
    Private HardButton5 As HardwareButton
    Private HardButton6 As HardwareButton

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load, MyBase.Load
        ' Display the OK button for closing the application.
        MinimizeBox = False

        ' Anchor / Dock Controls
        Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        InstructionsLabel.Dock = DockStyle.Top

        ' Init instructions
        InstructionsLabel.Text = "Click the buttons to rotate the screen orientation." & ControlChars.CrLf & ControlChars.CrLf & _
            "Click the Left or Right Hardware rocker buttons to rotate the screen orientation." & ControlChars.CrLf & ControlChars.CrLf & _
            "Click the other Hardware buttons and view the status bar to see which hardware buttons your device supports."

        ' Init ScreenOrientation to default Angle0 (standard portrait view)
        SetOrientation(CurrentAngle)

        ' Set KeyPreview to true so that the form sees the events first
        Me.KeyPreview = True

        ' Init the hardware buttons
        HardButton1 = New HardwareButton()
        HardButton2 = New HardwareButton()
        HardButton3 = New HardwareButton()
        HardButton4 = New HardwareButton()
        HardButton5 = New HardwareButton()
        HardButton6 = New HardwareButton()

        Try
            ' Set the AssociatedControl property to the form
            HardButton1.AssociatedControl = Me
            HardButton2.AssociatedControl = Me
            HardButton3.AssociatedControl = Me
            HardButton4.AssociatedControl = Me
            HardButton5.AssociatedControl = Me
            HardButton6.AssociatedControl = Me
            ' Init HardwareKey value to the appropriate enum value
            HardButton1.HardwareKey = HardwareKeys.ApplicationKey1
            HardButton2.HardwareKey = HardwareKeys.ApplicationKey2
            HardButton3.HardwareKey = HardwareKeys.ApplicationKey3
            HardButton4.HardwareKey = HardwareKeys.ApplicationKey4
            HardButton5.HardwareKey = HardwareKeys.ApplicationKey5
            HardButton6.HardwareKey = HardwareKeys.ApplicationKey6
        Catch ex As Exception
            MessageBox.Show(ex.Message + " Hardware button not physically available on this device.")
        End Try
    End Sub

    ' Set the orientation and update status bar with the current angle.
    Private Sub SetOrientation(ByVal orientation As ScreenOrientation)
        SystemSettings.ScreenOrientation = orientation
        StatusBar1.Text = SystemSettings.ScreenOrientation.ToString()
    End Sub

    Private Sub RotateClockwise()
        ' init next angle value for next click
        Select Case CurrentAngle
            Case ScreenOrientation.Angle90 : CurrentAngle = ScreenOrientation.Angle180
            Case ScreenOrientation.Angle180 : CurrentAngle = ScreenOrientation.Angle270
            Case ScreenOrientation.Angle270 : CurrentAngle = ScreenOrientation.Angle0
            Case Else : CurrentAngle = ScreenOrientation.Angle90
        End Select
        SetOrientation(CurrentAngle)
    End Sub

    Private Sub RotateCounterClockwise()
        ' init next angle value for next click
        Select Case CurrentAngle
            Case ScreenOrientation.Angle90 : CurrentAngle = ScreenOrientation.Angle0
            Case ScreenOrientation.Angle180 : CurrentAngle = ScreenOrientation.Angle90
            Case ScreenOrientation.Angle270 : CurrentAngle = ScreenOrientation.Angle180
            Case Else : CurrentAngle = ScreenOrientation.Angle270
        End Select
        SetOrientation(CurrentAngle)
    End Sub

    ' Each click moves the screen orientation clockwise 90 degrees
    Private Sub ClockwiseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClockwiseButton.Click
        RotateClockwise()
    End Sub

    ' Each click moves the screen orientation counter clockwise 90 degrees
    Private Sub CounterClockwiseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CounterClockwiseButton.Click
        RotateCounterClockwise()
    End Sub

    Private Sub Form1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        ' Determine which hardware key was pressed.  Note that not all application keys are supported
        ' on every emulator or device, yet all are implemented here to assist in determining what your
        ' emulator or device supports.
        Select Case CType(e.KeyCode, HardwareKeys)
            Case HardwareKeys.ApplicationKey1
                StatusBar1.Text = "ApplicationKey1"
            Case HardwareKeys.ApplicationKey2
                StatusBar1.Text = "ApplicationKey2"
            Case HardwareKeys.ApplicationKey3
                StatusBar1.Text = "ApplicationKey3"
            Case HardwareKeys.ApplicationKey4
                StatusBar1.Text = "ApplicationKey4"
            Case HardwareKeys.ApplicationKey5
                StatusBar1.Text = "ApplicationKey5"
            Case HardwareKeys.ApplicationKey6
                StatusBar1.Text = "ApplicationKey6"
        End Select

        ' Process the left and right arrow keys
        If (e.KeyCode = System.Windows.Forms.Keys.Left) Then
            RotateCounterClockwise()
        ElseIf (e.KeyCode = System.Windows.Forms.Keys.Right) Then
            RotateClockwise()
        End If
        e.Handled = True ' mark event as handled here
    End Sub

End Class
