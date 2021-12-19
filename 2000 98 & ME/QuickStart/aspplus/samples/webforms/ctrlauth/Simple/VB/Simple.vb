Imports System
Imports System.Web
Imports System.Web.UI

Namespace SimpleControlSamples

    Public Class SimpleVB : Inherits Control

       Protected Overrides Sub Render(Output As HtmlTextWriter)
           Output.Write("<H2>Welcome to Control Development!</H2>")
       End Sub
    End Class
End Namespace