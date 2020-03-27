
Public Class Sheet1

    Dim r As New Random()
    Dim form As SimpleForm

    Private Sub Sheet1_Startup(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Startup
        form = New SimpleForm()
    End Sub

    Private Sub Sheet1_Shutdown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shutdown

    End Sub

    Private Sub doubleClickNamedRange_BeforeDoubleClick(ByVal Target As Microsoft.Office.Interop.Excel.Range, ByRef Cancel As System.Boolean) Handles doubleClickNamedRange.BeforeDoubleClick
        MessageBox.Show("You double-clicked the cell.")
        Cancel = True
    End Sub

    Private Sub rightClickNamedRange_BeforeRightClick(ByVal Target As Microsoft.Office.Interop.Excel.Range, ByRef Cancel As System.Boolean) Handles rightClickNamedRange.BeforeRightClick
        Form.Show()

        Cancel = True
    End Sub

    Private Sub addRowButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addRowButton.Click
        Dim row As Excel.ListRow = Globals.Sheet1.dynamicListObject.ListRows.Add()

        row.Range.Value2 = r.Next()
    End Sub

    Private Sub selectNamedRange_Selected(ByVal Target As Microsoft.Office.Interop.Excel.Range) Handles selectNamedRange.Selected
        helpCalendar.Visible = True
    End Sub

    Private Sub selectNamedRange_Deselected(ByVal Target As Microsoft.Office.Interop.Excel.Range) Handles selectNamedRange.Deselected
        helpCalendar.Visible = False
    End Sub

    Private Sub helpCalendar_DateSelected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles helpCalendar.DateSelected
        selectNamedRange.Value = helpCalendar.SelectionStart.ToShortDateString()
        selectNamedRange.Select()
    End Sub
End Class
