Imports System
Imports System.Web
Imports System.Web.UI

Namespace CustomParsingControlSamples 

    Public Class ItemVB : Inherits Control

       Private _message As String

       Public Property Message As String
          Get
             Return _message
          End Get
          Set 
             _message = Value
          End Set
       End Property

    End Class

End Namespace