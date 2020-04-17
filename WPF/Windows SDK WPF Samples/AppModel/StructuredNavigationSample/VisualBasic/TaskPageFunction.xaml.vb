Public Class TaskPageFunction
    Inherits PageFunction(Of String)

    Public Sub New(ByVal initialDataItem1Value As String)
        Me.InitializeComponent()

        ' Set initial value
        Me.dataItem1TextBox.Text = initialDataItem1Value
    End Sub

    Private Sub cancelButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Cancel task
        Me.OnReturn(Nothing)
    End Sub

    Private Sub okButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Accept task when Ok button is clicked
        Me.OnReturn(New ReturnEventArgs(Of String)(Me.dataItem1TextBox.Text))
    End Sub

End Class