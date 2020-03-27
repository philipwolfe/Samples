
Public Class ThisDocument

    Dim uc As ProductLookupUserControl
    Dim b2 As Button


    Private Sub ThisDocument_Startup(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Startup
        ' Create a new instance of the user control
        uc = New ProductLookupUserControl

        ' Create a test button
        Dim b1 As Button
        b1 = New Button
        b1.Text = "Button 1"
        AddHandler b1.Click, AddressOf Me.b1_Click

        ' Create another test button
        b2 = New Button
        b2.Text = "Button 2"
        AddHandler b2.Click, AddressOf Me.b2_Click

        ' Add all three controls to the ActionsPane, show it, then
        ' add an event handler to fire if the orientation of the
        ' ActionsPane changes.
        Me.ActionsPane.Controls.AddRange(New Control() {uc, b1, b2})
        Me.ActionsPane.Show()
        AddHandler ActionsPane.OrientationChanged, AddressOf Me.ActionsPane_OrientationChanged
    End Sub

    Private Sub b1_Click(ByVal sender As Object, ByVal e As EventArgs)
        MessageBox.Show("You clicked button 1")
    End Sub

    Private Sub b2_Click(ByVal sender As Object, ByVal e As EventArgs)
        MessageBox.Show("You clicked button 2")
    End Sub


    Private Sub ActionsPane_OrientationChanged(ByVal sender As Object, ByVal e As EventArgs)
        If (Me.ActionsPane.Orientation = Orientation.Vertical) Then
            Me.ActionsPane.StackOrder = Microsoft.Office.Tools.StackStyle.FromTop
        Else
            Me.ActionsPane.StackOrder = Microsoft.Office.Tools.StackStyle.FromLeft
        End If
    End Sub

    Private Sub ThisDocument_Shutdown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shutdown

    End Sub

End Class
