Imports System
Imports System.Text
Imports Microsoft.VisualBasic

Namespace HelloWorld

  Public Class HelloObjVB 
  
    Private _name As String

    Public Sub New()

        MyBase.New()
        _name = ""
    End Sub

    Public Property FirstName As String

      Get 
        return _name
      End Get

      Set
        _name = Value
      End Set
    End Property

    Public Function SayHello() As String

      Dim SB As StringBuilder
      SB = New StringBuilder("Hello ")

      If Not (_name = "")
         SB.Append(_name)
      Else
         SB.Append("World")
      End If

      SB.Append("!")
      Return SB.ToString()
    End Function

  End Class

End Namespace