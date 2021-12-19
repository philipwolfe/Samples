Option Strict Off

Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace CompositionSampleControls

    Public Class Composition2VB : Inherits Control : Implements INamingContainer

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

           ' Add Literal Control

           Me.Controls.Add(New LiteralControl("<h3>Value: "))

           ' Add Textbox

           Dim Box As New TextBox
           Box.Text = "0"
           Me.Controls.Add(Box)

           ' Add Literal Control

           Me.Controls.Add(New LiteralControl("</h3>"))

           ' Add "Add" Button

           Dim AddButton As New Button
           AddButton.Text = "Add"
           AddHandler AddButton.Click, AddressOf AddBtn_Click
           Me.Controls.Add(AddButton)

           ' Add Literal Control

           Me.Controls.Add(New LiteralControl(" | "))

           ' Add "Subtract" Button

           Dim SubtractButton As New Button
           SubtractButton.Text = "Subtract"
           AddHandler SubtractButton.Click, AddressOf SubtractBtn_Click
           Me.Controls.Add(SubtractButton)

        End Sub

        Private Sub AddBtn_Click(Sender As Object, E As EventArgs)
           Me.Value = Me.Value + 1
        End Sub

        Private Sub SubtractBtn_Click(Sender As Object, E As EventArgs)
           Me.Value = Me.Value - 1
        End Sub

    End Class

End Namespace