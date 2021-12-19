Imports System.Runtime.InteropServices

Public Class API
    ' Declare the external Win32 API function
    <DllImport("user32.dll")> Public Shared Function MessageBox(ByVal Hwnd As Integer, _
                                                                ByVal [text] As String, _
                                                                ByVal Caption As String, _
                                                                ByVal Type As Integer) As Integer

    End Function
End Class
