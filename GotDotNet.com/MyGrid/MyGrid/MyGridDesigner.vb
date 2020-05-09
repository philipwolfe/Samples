Imports System.ComponentModel
Imports System.ComponentModel.Design
Public Class MyGridDesigner
    Inherits System.ComponentModel.Design.ComponentDesigner

    Public Sub New()
        'Dim clickVerb As New DesignerVerb("Property Builder", _
        'New EventHandler(AddressOf OnVerbClicked))
        'Dim dvc As New DesignerVerbCollection()
        'dvc.Add(clickVerb)
    End Sub
 
    Public Overrides ReadOnly Property Verbs() As DesignerVerbCollection
        Get
            Dim clickVerb As New DesignerVerb("Property Builder", New EventHandler(AddressOf OnVerbClicked))
            Return New DesignerVerbCollection(New DesignerVerb() {clickVerb})
        End Get
    End Property

    Private Sub OnVerbClicked(ByVal sender As Object, ByVal e As EventArgs)
        Dim fProp As New fProperties()
        fProp.ShowDialog()
    End Sub

End Class

