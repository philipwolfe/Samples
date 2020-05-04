Imports System
Imports System.IO
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.Design
Imports System.Web.UI.WebControls


'@ <summary>
'@ The designer for the dialog opener controls.
'@ </summary>
Public Class MenuLinkDesigner
    Inherits System.Web.UI.Design.ControlDesigner

    '@ <summary>
    '@ Overrides <see cref="System.Web.UI.Design.ControlDesigner.GetDesignTimeHtml"/>.
    '@ </summary>
    Public Overrides Function GetDesignTimeHtml() As String
        Dim link As ContextMenuLink = CType(Component, ContextMenuLink)

        If link.Text.Length > 0 Then
            Dim sw As New StringWriter
            Dim tw As New HtmlTextWriter(sw)

            Dim placeholderLink As New HyperLink

            ' Put simple.Text into the link's Text.
            placeholderLink.Text = link.Text
            placeholderLink.NavigateUrl = link.Text
            placeholderLink.RenderControl(tw)

            Return sw.ToString()
        Else
            Return GetEmptyDesignTimeHtml()
        End If
    End Function

End Class