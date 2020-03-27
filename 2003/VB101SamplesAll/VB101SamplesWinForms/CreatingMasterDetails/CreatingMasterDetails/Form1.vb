Imports System.data
Imports System.Data.SqlClient

Public Class Form1
    Private hrDataSet As DataSet
    Private departmentBindingSource As BindingSource
    Private employeeBindingSource As BindingSource
    Private departmentemployeeBindingSource As BindingSource

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' The first two lines of code were added by Visual Studio 2005 during the design time
        ' work on the Tab 1.
        ' TODO: This line of code loads data into the 'adventureWorks_DataDataSet.Employee' table. You can move, or remove it, as needed.
        Me.employeeTableAdapter.Fill(Me.adventureWorks_DataDataSet.Employee)
        ' TODO: This line of code loads data into the 'adventureWorks_DataDataSet.Department' table. You can move, or remove it, as needed.
        Me.departmentTableAdapter.Fill(Me.adventureWorks_DataDataSet.Department)

        ' Tabs 2 and 3 use the same BindingSource for Department data
        ' Department data draws from the Department table in the DataSet
        hrDataSet = LoadDBData()
        departmentBindingSource = New BindingSource(hrDataSet, "Department")

        ' Employee data draws from the Employee table in the DataSet
        employeeBindingSource = New BindingSource(hrDataSet, "Employee")

        ' Employee data uses the Department->Employee relation in the Department table
        departmentEmployeeBindingSource = New BindingSource(departmentBindingSource, "Department_Employee")

        ' Make binding resources ReadOnly. You can easily change this, but you'll need to add validation and
        '  error handling routines to avoid errors/issues.
        departmentBindingSource.AllowNew = False
        departmentemployeeBindingSource.AllowNew = False
        employeeBindingSource.AllowNew = False

        ' departmentBindingSource1.AllowNew = False ' change in the designer.

        SetupTab2()
        SetupTab3()
    End Sub

    Private Sub SetupTab2()

        ' Create a BindingNavigator for navigating through the Department data
        Dim tab2BindingNavigator As New BindingNavigator(departmentBindingSource)
        tabControl1.TabPages(1).Controls.Add(tab2BindingNavigator)
        tab2BindingNavigator.Dock = DockStyle.Top

        ' Bind the Department form
        Me.departmentIDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", departmentBindingSource, "DepartmentID", True))
        Me.nameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", departmentBindingSource, "Name", True))
        Me.groupNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", departmentBindingSource, "GroupName", True))

        ' Bind the Employee DataGridView
        employeeDataGridView.DataSource = departmentEmployeeBindingSource
    End Sub

    Private Sub SetupTab3()

        ' Create a BindingNavigator for navigating through the Department data
        Dim tab3BindingNavigator As New BindingNavigator(departmentBindingSource)
        tabControl1.TabPages(2).Controls.Add(tab3BindingNavigator)
        tab3BindingNavigator.Dock = DockStyle.Top

        ' Bind the Department form
        Me.departmentIDTextBox2.DataBindings.Add(New System.Windows.Forms.Binding("Text", departmentBindingSource, "DepartmentID", True))
        Me.nameTextBox2.DataBindings.Add(New System.Windows.Forms.Binding("Text", departmentBindingSource, "Name", True))
        Me.groupNameTextBox2.DataBindings.Add(New System.Windows.Forms.Binding("Text", departmentBindingSource, "GroupName", True))

        ' Bind the Employee DataGridView
        employeeDataGridView2.DataSource = employeeBindingSource

        ' Add event handler to refresh Employee grid on the current Department
        AddHandler departmentBindingSource.PositionChanged, AddressOf departmentBindingSource_PositionChanged
    End Sub

    Private Sub departmentBindingSource_PositionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        refreshEmployeeGrid2()
    End Sub

    ' Refresh the Employees grid based upon the current Department
    Private Sub refreshEmployeeGrid2()

        ' Filter the BindingSource based upon the current Department
        ' DepartmentID is a SQL smallint, which is an Int16.
        Dim departmentId As Integer
        departmentId = CInt(CType(departmentBindingSource.Current, DataRowView)("DepartmentID"))
        employeeBindingSource.Filter = "DepartmentID = " & departmentId.ToString()
    End Sub

    ' Retrieve all the data required from the database at once into a dataset
    Private Function LoadDBData() As DataSet

        Try
            'employeeTableAdapter1.Fill(adventureWorks_DataDataSet.Employee)

            ' Retrieve Employee data from database into a DataSet
            ' Build a connnection string to the database
            Dim connectStringBuilder As New SqlConnectionStringBuilder()
            connectStringBuilder.DataSource = ".\SQLEXPRESS"
            connectStringBuilder.AttachDBFilename = "C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\Data\AdventureWorks_Data.mdf"
            connectStringBuilder.IntegratedSecurity = True
            connectStringBuilder.UserInstance = True

            ' Prepare a DataSet to receive the Employee data
            Dim ds As New DataSet()

            ' Open connection to the AdventureWorks database
            Using connection As New SqlConnection(connectStringBuilder.ConnectionString)

                connection.Open()

                ' Retrieve Employee data
                Dim empCommand As New SqlCommand( _
                    "SELECT " _
                    + "	Employee.EmployeeID, EmployeeContact.LastName, EmployeeContact.FirstName," _
                    + "	Employee.Title, Employee.SalariedFlag, Employee.ManagerID, Department.DepartmentID, " _
                    + "	ManagerContact.LastName + ', ' + ManagerContact.FirstName AS ManagerName" _
                    + " FROM [HumanResources].[Employee] AS Employee" _
                    + " INNER JOIN ( SELECT EmployeeID, DepartmentID" _
                    + " 	FROM HumanResources.EmployeeDepartmentHistory h1" _
                    + " 	WHERE EXISTS ( SELECT NULL FROM HumanResources.EmployeeDepartmentHistory h2" _
                    + " 	WHERE h1.EmployeeID = h2.EmployeeID GROUP BY h2.EmployeeID" _
                    + " 	HAVING h1.ModifiedDate = MAX(h2.ModifiedDate))" _
                    + " ) Department ON Department.EmployeeID = Employee.EmployeeID" _
                    + " INNER JOIN [Person].[Contact] AS EmployeeContact ON (EmployeeContact.ContactID = Employee.ContactID)" _
                    + " INNER JOIN [HumanResources].[Employee] AS Manager ON (Manager.EmployeeID = Employee.ManagerID)" _
                    + " INNER JOIN [Person].[Contact] AS ManagerContact ON (ManagerContact.ContactID = Manager.ContactID)", _
                    connection)

                Using dataReaderEmployees As SqlDataReader = empCommand.ExecuteReader()

                    ' Load the result set into the dataset.
                    ds.Load( _
                        dataReaderEmployees, _
                        LoadOption.OverwriteChanges, _
                        New String() {"Employee"})

                    ' Retrieve Department data
                    Dim deptCommand As New SqlCommand( _
                        "SELECT * FROM [HumanResources].[Department]", _
                        connection)

                    Using dataReaderDepartment As SqlDataReader = deptCommand.ExecuteReader()

                        ' Load the result set into the dataset.
                        ds.Load( _
                         dataReaderDepartment, _
                         LoadOption.OverwriteChanges, _
                         New String() {"Department"})
                    End Using

                    ' Setup a relationship between employees and departments
                    ds.Relations.Add("Department_Employee", _
                         ds.Tables("Department").Columns("DepartmentID"), _
                         ds.Tables("Employee").Columns("DepartmentID"))

                    ' Close the connection to the database
                    connection.Close()
                End Using
            End Using

            Return ds
        Catch err As SqlException
            MessageBox.Show(err.Message, "SQL Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

End Class
