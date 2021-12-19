Imports System
Imports System.Resources
Imports Microsoft.VisualBasic


Public Class ReadResourceDemo

' The resource manager for accessing the resources.
Dim _resourceManager as ResourceManager 

Public Sub New()
  MyBase.New

  ' Create a resource manager and store it.
  _resourceManager = new ResourceManager( "Errors", System.Reflection.Assembly.GetExecutingAssembly(), Nothing, false)
End Sub


Public Function Divide(op1 As Integer, op2 As Integer) As Object
  Dim result As Double
  
  If (op2 = 0) Then
    ' Create exception with string from resource.
    ' Now application can be localized without altering source code.
    Dim exc As Exception
    exc = New Exception(_resourceManager.GetString("DivisionByZero"))
    Throw(exc)
  Else  
    result = op1 / op2
  End If
  
  Divide = result
End Function


' Public Shared Sub Main(args() As String)
Public Shared Sub Main()
  
  Dim demo As ReadResourceDemo
  demo = new ReadResourceDemo()
  
  Console.WriteLine("4 divided by 2 is {0}", demo.Divide(4, 2) )
  
  ' Provoke an error to see exception.
  Console.WriteLine("4 divided by 0 is {0}", demo.Divide(4, 0) )
  
  Console.WriteLine(ControlChars.CrLf + "Press Return to exit.")
  Console.Read()
End Sub
  
  
End Class

