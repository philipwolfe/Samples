Imports ExcelTools = Microsoft.Office.Tools.Excel

Public Class Sheet1

    Private c4NamedRange As ExcelTools.NamedRange
    Private Sub Sheet1_Startup(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Startup
        CreateNamedRange()
    End Sub

    ''' <summary>
    ''' Create a named range programmatically, then set the inner value
    ''' </summary>
    Private Sub CreateNamedRange()
        ' First obtain the intrinsic range for the given cell(s)
        ' The second argument can be supplied for a multi-cell range
        Dim c4Range As Excel.Range = Me.Range("C4")

        ' Now create the named range by providing the intrinsic range
        ' and a reference name
        c4NamedRange = Me.Controls.AddNamedRange(c4Range, "MyNamedRange")

        ' Now set the value of the named range, this is, what will be
        ' displayed in the worksheet.
        c4NamedRange.Value2 = "Runtime named range created"
    End Sub

    Private Sub salaryNamedRange_Change(ByVal Target As Microsoft.Office.Interop.Excel.Range) Handles salaryNamedRange.Change
        UpdateRiskLevel()
    End Sub

    Private Sub debtNamedRange_Change(ByVal Target As Microsoft.Office.Interop.Excel.Range) Handles debtNamedRange.Change
        UpdateRiskLevel()
    End Sub

    ''' <summary>
    ''' A shared method to handle obtaining credit risk information
    ''' and displaying it.
    ''' </summary>
    Private Sub UpdateRiskLevel()
        ' Verify that both fields are set
        If ((Not (salaryNamedRange.Value2) Is Nothing) _
                    AndAlso (Not (debtNamedRange.Value2) Is Nothing)) Then

            ' Convert the values to floats
            Dim salary As Single = Single.Parse(salaryNamedRange.Value2.ToString)
            Dim debt As Single = Single.Parse(debtNamedRange.Value2.ToString)

            ' Calculate the risk level and display it
            riskNamedRange.Value2 = LookupRiskLevel(salary, debt)
        End If
    End Sub

    ''' <summary>
    ''' A simple comparison to assign a text-based risk level based on 
    ''' a given debt ratio.
    ''' </summary>
    ''' <param name="salary">The salary of the person being evaluated</param>
    ''' <param name="debt">The total debt load for this person</param>
    ''' <returns></returns>
    Private Function LookupRiskLevel(ByVal salary As Single, ByVal debt As Single) As String
        Dim ratio As Single = (debt / salary)
        Select Case ratio
            Case Is < 0.25
                Return "LOW"
            Case Is < 0.5
                Return "AVERAGE"
            Case Is < 0.7
                Return "HIGH"
            Case Else
                Return "EXTREME"
        End Select
    End Function

    Private Sub Sheet1_Shutdown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shutdown

    End Sub

End Class
