Option Strict Off

Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace CompositionSampleControls

    Public Class Composition1VB : Inherits Control : Implements INamingContainer

        Public Property Value As Integer
           Get
               Dim Ctrl As TextBox = Controls(1)
               Return Int32.Parse(Ctrl.Text)
           End Get
           Set 
               Dim Ctrl As TextBox = Controls(1)
               Ctrl.Text = Value.ToString()
           End Set
        End Property

        Protected Overrides Sub CreateChildControls()

            Me.Controls.Add(New LiteralControl("<h3>Value: "))

            Dim Box As New TextBox
            Box.Text = "0"
            Me.Controls.Add(box)

            Me.Controls.Add(New LiteralControl("</h3>"))
        End Sub

    End Class

End Namespace