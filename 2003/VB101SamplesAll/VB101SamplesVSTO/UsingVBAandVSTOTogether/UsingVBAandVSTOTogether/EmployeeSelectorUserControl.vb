Public Class EmployeeSelectorUserControl

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        Me.vEmployeeTableAdapter.Fill(Me.adventureWorks_DataDataSet.vEmployee)

    End Sub
    Private Sub selectButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles selectButton.Click
        Dim employeeRow As AdventureWorks_DataDataSet.vEmployeeRow = _
            CType( _
            CType(Me.vEmployeeBindingSource.Current, DataRowView).Row(), _
            AdventureWorks_DataDataSet.vEmployeeRow)

        Globals.Sheet1.emailAddressNamedRange.Value = _
            employeeRow.EmailAddress.Split("@")(0)
        Globals.Sheet1.employeeNameNamedRange.Value = _
            employeeRow.LastName & ", " & employeeRow.FirstName
        Globals.Sheet1.employeeNumberNamedRange.Value = employeeRow.EmployeeID
        Globals.Sheet1.employeePhoneNamedRange.Value = employeeRow.Phone
        Globals.Sheet1.employeeTitleNamedRange.Value = employeeRow.JobTitle
        Globals.Sheet1.locationNamedRange.Value = _
            employeeRow.City & ", " & employeeRow.StateProvinceName

    End Sub
End Class
