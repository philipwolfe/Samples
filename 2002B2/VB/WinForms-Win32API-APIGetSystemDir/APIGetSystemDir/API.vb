Imports System.Runtime.InteropServices
Imports System.Text

Public Class API
    'Declare the external Win32 API Call
    <DllImport("kernel32")> Public Shared Function GetSystemDirectory(ByVal Buffer As StringBuilder, _
                                                                      ByVal Size As Integer) As Integer

    End Function

End Class
