' Demonstrates new interop abilities such as the ability to wrap native function pointers 
' into delegates and the ability to marshal fixed-size arrays of structures inside structures.
Option Strict On

Imports System.Runtime.InteropServices

Public Class Form1

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Init some values for the bottom right point
        BottomRightXUpDown.Value = 5
        BottomRightYUpDown.Value = 5
    End Sub

    ' This is the CallBack Method.  The DLL will call this method with the area
    ' calculated within the dll
    Public Shared Sub ShowArea(ByVal area As Integer)
        MessageBox.Show("Calculated Area From CallBack = " & area.ToString())
    End Sub

    ' Validate that the points are indeed topLeft and bottomRight
    Private Function ValidatePoints(ByVal tlPoint As MyPoint, ByVal brPoint As MyPoint) As Boolean
        If tlPoint.x < brPoint.x And tlPoint.y < brPoint.y Then
            Return True
        Else : Return False
        End If
    End Function

    ' Create and populate the Rectangle structure based on the UpDown Controls
    Private Function GetRectangle() As MyRectangle
        Dim tlPoint, brPoint As MyPoint

        ' Create points based on UpDown controls
        tlPoint = New MyPoint(CInt(TopLeftXUpDown.Value), CInt(TopLeftYUpDown.Value))
        brPoint = New MyPoint(CInt(BottomRightXUpDown.Value), CInt(BottomRightYUpDown.Value))

        ' Make sure that points are indeed topLeft and bottomRight
        If ValidatePoints(tlPoint, brPoint) = False Then
            Throw New Exception("Error: Points are not top left and bottom right")
        End If

        Return New MyRectangle(tlPoint, brPoint)
    End Function

    Private Sub CalcAreaButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalcAreaButton.Click
        Try
            ' Get Rectangle based on UI
            Dim rect As MyRectangle = GetRectangle()

            ' Marshal Rectangle (array of struct inside a struct) to unmanaged DLL and
            ' return calculated area
            Dim area As Integer = LibWrapper.GetRectangleArea(rect)
            AreaLabel.Text = area.ToString()
            CalcAreaLabel.Text = area.ToString()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CalcAreaCallBackButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalcAreaCallBackButton.Click
        Try
            ' Get Rectangle based on UI
            Dim rect As MyRectangle = GetRectangle()

            ' Marshal address of callback function and 
            ' marshal Rectangle (array of struct inside a struct) to unmanaged DLL and
            ' return calculated area via callback function
            Dim callback As FPtr
            callback = AddressOf Form1.ShowArea
            LibWrapper.GetRectangleAreaCallBack(callback, rect)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class

