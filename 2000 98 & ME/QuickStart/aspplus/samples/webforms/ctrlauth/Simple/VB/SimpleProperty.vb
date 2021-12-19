Imports System
Imports System.Web
Imports System.Web.UI

Namespace SimpleControlSamples

    Public Enum MsgSize

        Small = 0
        Medium = 1
        Large = 2

     End Enum    

    Public Class SimplePropertyVB : Inherits Control

       Private _message As String
       Private _messageSize As MsgSize
       Private _iterations As Integer = 1

       Public Property Message As String
           Get
              Return _message
           End Get
           Set
              _message = Value
           End Set
       End Property

       Public Property MessageSize As MsgSize
           Get
              Return _messageSize
           End Get
           Set
              _messageSize = Value
           End Set
       End Property

       Public Property Iterations As Integer
           Get
              Return _iterations
           End Get
           Set
              _iterations = Value
           End Set
       End Property

       Protected Overrides Sub Render(Output As HtmlTextWriter)

           Dim HtmlSize As String

           If _messageSize = MsgSize.Small
              HtmlSize="H5"
           Else if _messageSize = MsgSize.Medium
              HtmlSize="H3"
           Else
              HtmlSize="H1"
           End If

           Dim I As Integer
           For I = 0 To _iterations - 1
              Output.Write("<" & htmlSize & ">" & _message & "</" & htmlSize & ">")
           Next
       End Sub

    End Class

End Namespace
