Imports System.data
Imports System.Data.SqlClient

Public Class Form1
    ' A DataSet of Employee records from the AdventureWorks database
    Dim dataSetAdventureWorks As DataSet
    Dim dataGridView1 As DataGridView
    Dim bindingSourceEmployee As BindingSource

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Set up a dataset for binding purposes
        dataSetAdventureWorks = LoadDBData()
        If dataSetAdventureWorks IsNot Nothing Then
            bindingSourceEmployee = New BindingSource(dataSetAdventureWorks, "Employee")
            SetupGrid()
        End If
    End Sub

    Private Sub SetupGrid()

        ' For the second grid, columns are generated manually
        dataGridView1 = New DataGridView()
        dataGridView1.Name = "dataGridView1"
        dataGridView1.AllowUserToOrderColumns = True
        dataGridView1.AllowUserToDeleteRows = False
        dataGridView1.AllowUserToAddRows = False
        ' Render alternating rows with a different background color
        dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.InactiveCaptionText
        dataGridView1.AutoGenerateColumns = False
        dataGridView1.DataSource = bindingSourceEmployee
        ' Only one selection is supported at a time
        dataGridView1.MultiSelect = False
        ' Configure the grid to use cell selection
        dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect
        ' Because this grid will contain unbound columns
        ' VirtualMode must be On.
        dataGridView1.VirtualMode = True

        ' There are five kinds of Column UI elements
        ' 1. Text Box
        ' 2. Combo Box
        ' 3. Button
        ' 4. Link
        ' 5. Image
        ' In addition, cell templates can be defined for customizing cell UI

        '
        ' Column: Employee ID, text box
        '
        Dim colEmployeeId As New DataGridViewTextBoxColumn()
        colEmployeeId.DataPropertyName = "EmployeeID"
        colEmployeeId.HeaderText = "Employee ID"
        colEmployeeId.Name = "EmployeeID"
        colEmployeeId.ReadOnly = True
        ' Do not display this system internal number to the user.
        colEmployeeId.Visible = False
        dataGridView1.Columns.Add(colEmployeeId)

        '
        ' Column: Last name, text box
        '
        Dim colLastName As New DataGridViewTextBoxColumn()
        ' Size the column width so it is wide enough to display the widest visible cell, including the header
        colLastName.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        colLastName.DataPropertyName = "LastName"
        colLastName.HeaderText = "Surname"
        colLastName.Name = "LastName"
        colLastName.ReadOnly = False
        dataGridView1.Columns.Add(colLastName)

        '
        ' Column: First name, text box
        '
        Dim colFirstName As New DataGridViewTextBoxColumn()
        ' Size the column width so it is wide enough to display the widest visible cell, including the header
        colFirstName.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        colFirstName.DataPropertyName = "FirstName"
        colFirstName.HeaderText = "Given Name"
        colFirstName.Name = "FirstName"
        colFirstName.ReadOnly = False
        dataGridView1.Columns.Add(colFirstName)

        '
        ' Column: Hire Date, text box with custom formatting
        '
        Dim colHireDate As New DataGridViewTextBoxColumn()
        ' Size the column width so it is wide enough to display the widest visible cell, including the header
        colHireDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        colHireDate.DataPropertyName = "HireDate"
        ' Format date as Month, yyyy
        colHireDate.DefaultCellStyle.Format = "y"
        colHireDate.HeaderText = "Date of Hire"
        colHireDate.Name = "HireDate"
        colHireDate.ReadOnly = True
        dataGridView1.Columns.Add(colHireDate)

        '
        ' Column: Age, unbound calculated column
        '
        Dim colAge As New DataGridViewTextBoxColumn()
        ' Size the column width to display the header
        colAge.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        colAge.HeaderText = "Age"
        colAge.Name = "Age"
        ' Mark column as read-only.  Data edits would occur through a BirthDate column.
        ' If not read-only, then a CellValuePush event handler is required to write the 
        ' entered data into the datasource.
        colAge.ReadOnly = True
        ' Unbound columns fetch data via the CellValueNeeded event
        AddHandler dataGridView1.CellValueNeeded, AddressOf colAge_CellValueNeeded
        dataGridView1.Columns.Add(colAge)

        '
        ' Column: Gender, combo box
        '
        ' For this column, combo box contents are specified programmatically
        Dim colGender As New DataGridViewComboBoxColumn()
        ' Size the column width so it is wide enough to display the header
        colGender.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        colGender.DataPropertyName = "Gender"
        ' Specifiy the list of choices in the combo box
        colGender.Items.AddRange(New String() {"M", "F"})
        ' Sort the combo box contents alphabetically
        colGender.Sorted = True
        ' Disable sorting for the column
        colGender.SortMode = DataGridViewColumnSortMode.NotSortable
        colGender.HeaderText = "Gender"
        colGender.Name = "Gender"
        colGender.ReadOnly = False
        dataGridView1.Columns.Add(colGender)

        '
        ' Column: Marital status, combo box
        '
        ' For this column, combo box contents are retrieved from the database
        Dim colMaritalStatus As New DataGridViewComboBoxColumn()
        ' Size the column width so it is wide enough to display the header
        colMaritalStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        colMaritalStatus.DataPropertyName = "MaritalStatus"
        ' Retrieve the list of choices from the database
        colMaritalStatus.DataSource = dataSetAdventureWorks.Tables("MaritalStatusChoices")
        ' Identify the column in the Employee table that is used to select the combo box item
        colMaritalStatus.ValueMember = "MaritalStatus"
        ' If the column value is not human friendly, e.g., a foreign key identity off to a related table,
        ' the DisplayMember property is used to identify the column used for display purposes
        colMaritalStatus.DisplayMember = "MaritalStatus"
        colMaritalStatus.HeaderText = "Marital Status"
        colMaritalStatus.Name = "MaritalStatus"
        colMaritalStatus.ReadOnly = False
        dataGridView1.Columns.Add(colMaritalStatus)

        '
        ' Column: SalariedFlag, check box
        '
        Dim colSalariedFlag As New DataGridViewCheckBoxColumn()
        ' Size the column width so it is wide enough to display the header
        colSalariedFlag.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        ' Because this is a nullable column, support 3 values for a boolean:
        ' true, false, unknown}
        colSalariedFlag.ThreeState = True
        colSalariedFlag.TrueValue = 1
        colSalariedFlag.FalseValue = 0
        colSalariedFlag.IndeterminateValue = System.DBNull.Value
        colSalariedFlag.DataPropertyName = "SalariedFlag"
        colSalariedFlag.HeaderText = "Salaried"
        colSalariedFlag.Name = "SalariedFlag"
        colSalariedFlag.ReadOnly = True
        dataGridView1.Columns.Add(colSalariedFlag)


        '
        ' Column: Direct Reports, button
        '
        ' This column is not bound to a database table column.
        ' Display a list of employees who report directly to this employee
        Dim colDirectReports As New DataGridViewButtonColumn()
        colDirectReports.HeaderText = "Direct Reports"
        colDirectReports.Name = "DirectReports"
        colDirectReports.Text = "Subordinates"
        ' Use the .Text value for the Button caption
        colDirectReports.UseColumnTextForButtonValue = True
        ' Make the column as wide as required by the column header
        colDirectReports.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        colDirectReports.ToolTipText = "Click to display a list of employees who report directly to this person."
        dataGridView1.Columns.Add(colDirectReports)

        ' Handle the button click. 
        ' Because there is no event specific to button columns or cells,
        ' use the DataGridView.CellContentClick event
        AddHandler dataGridView1.CellContentClick, AddressOf colDirectReports_CellContentClick

        '
        ' Column: Manager, link
        '
        ' Links to the manager's entry, by seeking it in the dataset, and then setting the selected row
        Dim colManager As New DataGridViewLinkColumn()
        ' Size the column width so it is fills out the rest of the grid
        colManager.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        ' But give it a minimum size
        colManager.MinimumWidth = 100
        colManager.DataPropertyName = "ManagerName"
        colManager.HeaderText = "Manager"
        colManager.LinkBehavior = LinkBehavior.AlwaysUnderline
        colManager.LinkBehavior = LinkBehavior.SystemDefault
        colManager.LinkColor = Color.Blue
        colManager.Name = "Manager"
        colManager.SortMode = DataGridViewColumnSortMode.Automatic
        dataGridView1.Columns.Add(colManager)

        ' Handle the link click
        ' The DataGridViewLinkColumn behaves like the DataGridViewButtonColumn
        ' but with a different UI.
        AddHandler dataGridView1.CellContentClick, AddressOf colManager_CellContentClick

        ' Freeze the grid at the FirstName column, so it and columns to its left
        ' stay on screen throughout horizontal scrolling
        colFirstName.Frozen = True

        dataGridView1.Dock = DockStyle.Fill
        Me.Controls.Add(dataGridView1)

        AddHandler dataGridView1.Click, AddressOf dataGridView1_Click

    End Sub


    ' Retrieve all the data required from the database at once into a dataset
    Private Function LoadDBData() As DataSet

        Try

            ' Retrieve Employee data from database into a DataSet
            ' Build a connnection string to the database
            Dim connectStringBuilder As New SqlConnectionStringBuilder()
            connectStringBuilder.DataSource = ".\SQLEXPRESS"
            connectStringBuilder.AttachDBFilename = "C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\Data\AdventureWorks_Data.mdf"
            connectStringBuilder.IntegratedSecurity = True
            connectStringBuilder.UserInstance = True

            Dim ds As New DataSet()

            ' Open connection to the AdventureWorks database
            Using connection As New SqlConnection(connectStringBuilder.ConnectionString)

                connection.Open()

                ' Retrieve Employee data
                Dim command As New SqlCommand( _
                  "SELECT TOP 50" _
                   + "  Employee.*" _
                   + ", EmployeeContact.*" _
                   + ", ManagerContact.LastName + ', ' + ManagerContact.FirstName AS ManagerName" _
                   + " FROM [HumanResources].[Employee] AS Employee" _
                   + " INNER JOIN [Person].[Contact] AS EmployeeContact ON (EmployeeContact.ContactID = Employee.ContactID)" _
                   + " INNER JOIN [HumanResources].[Employee] AS Manager ON (Manager.EmployeeID = Employee.ManagerID)" _
                   + " INNER JOIN [Person].[Contact] AS ManagerContact ON (ManagerContact.ContactID = Manager.ContactID)", _
                  connection)

                Using dataReaderEmployees As SqlDataReader = command.ExecuteReader()

                    ' Load the result set into the dataset.
                    ds.Load( _
                     dataReaderEmployees, _
                     LoadOption.OverwriteChanges, _
                     New String() {"Employee"})

                    ' Retrieve Marital Status choices
                    command.CommandText = "SELECT DISTINCT MaritalStatus FROM [HumanResources].[Employee]"
                    Using dataReaderMaritalChoices As SqlDataReader = command.ExecuteReader()

                        ' Load the result set into the dataset.
                        ds.Load( _
                         dataReaderMaritalChoices, _
                         LoadOption.OverwriteChanges, _
                         New String() {"MaritalStatusChoices"})
                    End Using

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

    ' Handler for clicks on the DirectReports button
    ' Display a listbox at the mouse pointer location with the list of employees 
    ' who report directly.
    Private Sub colDirectReports_CellContentClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs)
        Dim grid As DataGridView = CType(sender, DataGridView)

        ' Filter out clicks not in the DirectReports column
        If e.RowIndex >= 0 And e.ColumnIndex = grid.Columns("DirectReports").Index Then
            ' Filter for direct reports
            Dim Employees As DataTable = dataSetAdventureWorks.Tables("Employee")
            Dim employeeId As Integer = CInt(CType(grid.Rows(e.RowIndex).DataBoundItem, DataRowView).Row("EmployeeID"))
            Dim directReports As DataRow() = Employees.Select("ManagerID = " + employeeId.ToString(), "LastName ASC")

            listBoxDirectReports.Items.Clear()
            For i As Integer = directReports.GetLowerBound(0) To directReports.GetUpperBound(0)
                Dim entry As String = ""
                entry = entry + directReports(i)("LastName")
                listBoxDirectReports.Items.Add(entry)
            Next

            If listBoxDirectReports.Items.Count = 0 Then
                listBoxDirectReports.Items.Add("None")
            End If

            ' Add listbox to form, on top, positioned at mouse pointer
            Me.Controls.Add(listBoxDirectReports)
            listBoxDirectReports.Location = Me.PointToClient(MousePosition)

            ' Display listbox
            listBoxDirectReports.Visible = True
            listBoxDirectReports.BringToFront()
            listBoxDirectReports.Focus()
        End If
    End Sub


    Private Sub listBoxDirectReports_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listBoxDirectReports.Leave
        listBoxDirectReports.Visible = False
    End Sub

    ' Handler for clicks on the Manager link
    ' Seeks to the manager's row in the grid
    Private Sub colManager_CellContentClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs)
        Dim grid As DataGridView = CType(sender, DataGridView)

        ' Filter out clicks not in the DirectReports column.
        If e.RowIndex >= 0 And e.ColumnIndex = grid.Columns("Manager").Index Then
            ' Seek to the manager's entry in the grid
            ' Pull the data from the DataRow behind the GridRow
            ' You should not use e.RowIndex as the index into the Employees table,
            ' because e.RowIndex is not invariant through sort operations
            'Dim managerId As Integer = CInt(dataSetAdventureWorks.Tables("Employee").DefaultView(e.RowIndex)("ManagerID"))
            Dim managerId As Integer = CInt(CType(grid.Rows(e.RowIndex).DataBoundItem, DataRowView).Row("ManagerID"))
            Dim boolFound As Boolean = False
            For Each row As DataGridViewRow In grid.Rows
                ' IsNewRow indicates the grid entry row at the bottom of the grid
                ' Because EmployeeID data is contained in the grid,
                ' you can either retrieve the EmployeeID from the grid...
                'If Not row.IsNewRow And CInt(row.Cells("EmployeeID").Value) = managerId Then
                ' ...or from the underlying datasource.
                If Not row.IsNewRow And CInt(CType(row.DataBoundItem, DataRowView).Row("EmployeeID")) = managerId Then
                    boolFound = True
                    ' The DataGridView is in cell selection mode.
                    ' If row selection were used, use row.Selected = true
                    row.Cells("LastName").Selected = True
                    Exit For
                End If
            Next
            ' Notify user if manager record is not present
            ' This will occur in this sample sometimes because 
            ' not all employee records were retrieved.
            If Not boolFound Then
                MessageBox.Show("No manager data available.")
            End If
        End If
    End Sub

    ' Handle the request for data for unbound columns
    Private Sub colAge_CellValueNeeded(ByVal sender As Object, ByVal e As DataGridViewCellValueEventArgs)
        If e.ColumnIndex = CType(sender, DataGridView).Columns("Age").Index Then
            Dim age As Integer
            Dim Employees As DataTable = dataSetAdventureWorks.Tables("Employee")
            Dim birthDate As DateTime = CType(Employees.DefaultView(e.RowIndex)("BirthDate"), DateTime)
            age = DateTime.Today.Year - birthDate.Year

            ' Adjust down if hasn't had this year's birthday yet.
            If (DateTime.Today.DayOfYear < birthDate.DayOfYear) Then
                age -= 1
            End If
            e.Value = age
        End If
    End Sub

    Private Sub listBoxDirectReports_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listBoxDirectReports.SelectedIndexChanged
        If Not CType(sender, ListBox).SelectedItem = Nothing Then

            For Each row As DataGridViewRow In dataGridView1.Rows
                If Not row.IsNewRow And _
                    CType(row.DataBoundItem, DataRowView).Row("LastName").ToString() = _
                    CType(sender, ListBox).SelectedItem.ToString() Then

                    row.Cells("LastName").Selected = True
                    listBoxDirectReports.Visible = False
                    Exit For
                End If
            Next

        Else
            listBoxDirectReports.Visible = False
        End If
    End Sub

    Private Sub dataGridView1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.HideDirectReports()
    End Sub

    Private Sub Form1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Click
        Me.HideDirectReports()
    End Sub

    Private Sub HideDirectReports()
        If Me.listBoxDirectReports.Visible Then
            Me.listBoxDirectReports.Visible = False
            Me.listBoxDirectReports.SendToBack()
        End If
    End Sub
End Class
