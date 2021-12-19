Option Strict Off

Imports System
Imports System.Web
Imports System.Web.UI

Namespace SimpleControlSamples

    Public Class SimpleInnerContentVB : Inherits Control

       Protected Overrides Sub Render(Output As HtmlTextWriter)

           If HasControls() And TypeOf Controls(0) Is LiteralControl
              Dim Ctrl As LiteralControl = Controls(0)
              Output.Write("<H2>Your Message: " & Ctrl.Text & "</H2>")
           End If

       End Sub

    End Class

End Namespace