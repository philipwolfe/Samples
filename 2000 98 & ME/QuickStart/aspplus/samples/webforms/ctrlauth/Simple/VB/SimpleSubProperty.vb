Imports System
Imports System.Web
Imports System.Web.UI

Namespace SimpleControlSamples

    Public Class FormatterVB
        Public Size As Integer
        Public Color As String

        Public Sub New(Size As Integer, Color As String)
           MyBase.New
           Me.Size = Size
           Me.Color = Color
        End Sub
    End Class

    Public Class SimpleSubPropertyVB : Inherits Control

       Private _format  As FormatterVB= new FormatterVB(3, "black")
       Private _message As String = Nothing

       Public Property Message As String
           Get
              Return _message
           End Get
           Set
              _message = Value
           End Set
       End Property

       Public ReadOnly Property Format As FormatterVB
           Get
              Return _format
           End Get
       End Property

       Protected Overrides Sub Render(Output As HtmlTextWriter)

           Output.Write("<font size=" & Format.Size & " color=" & Format.Color & ">")
           Output.Write(_message)
           Output.Write("</font>")
       End Sub

    End Class

End Namespace
