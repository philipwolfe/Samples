Imports System
Imports System.Runtime.InteropServices

Namespace ClassLibrary1
    Public Class Foo
         Shared  Function <DllImport("user32.dll")> MessageBoxA  (ByVal h As Integer, ByVal m As String, ByVal c As String, ByVal type As Integer) As Integer
         End Function

        Public Shared Sub Main()
            MessageBoxA(0, "Hello World2!", "Caption", 0)
        End Sub
    End Class
End Namespace

