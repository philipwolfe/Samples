Imports System
Imports System.Web
Imports System.Web.UI

Namespace ViewStateControlSamples

    Public Class LabelVB : Inherits Control

       Public Property [Text] As String
          Get
              Return CStr(State("Text"))
          End Get
          Set
              State("Text") = Value
          End Set
       End Property

       Public Property FontSize As Integer
          Get
              Return CInt(State("FontSize"))
          End Get
          Set 
              State("FontSize") = Value
          End Set 
       End Property

       Protected Overrides Sub Render(Output As HtmlTextWriter)
           Output.Write("<font size=" & Me.FontSize & ">" & Me.Text & "</font>")
       End Sub

    End Class

End Namespace