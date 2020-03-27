Imports System.data
Imports System.data.SqlClient
Imports System.ComponentModel

Public Class Form1
    Private EmployeesBindingSource As BindingSource
    Private BindingNavigatorStandard As BindingNavigator
    Private BindingNavigatorCustom As BindingNavigator

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Create a BindingSource for all the BindingNavigators to use
        EmployeesBindingSource = New BindingSource()
        EmployeesBindingSource.AllowNew = False

        ' The first BindingNavigator (Toolbox) was generated at design time
        ' by dragging the control from the Toolbox
        SetupTab2()
        SetupTab3()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim ds As DataSet = RetrieveDataSet()

        If ds IsNot Nothing Then

            ' Associate the DataSet with the BindingSource.
            Me.EmployeesBindingSource.DataMember = "Employee"
            Me.EmployeesBindingSource.DataSource = ds

            ' Associate the BindingNavigators with the BindingSource
            Me.EmployeesBindingNavigator.BindingSource = Me.EmployeesBindingSource
            Me.BindingNavigatorStandard.BindingSource = Me.EmployeesBindingSource
            Me.BindingNavigatorCustom.BindingSource = Me.EmployeesBindingSource

            ' Bind the form controls
            Me.employeeIDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmployeesBindingSource, "EmployeeID", True))
            Me.titleTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmployeesBindingSource, "Title", True))
            Me.birthDateDateTimePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.EmployeesBindingSource, "BirthDate", True))
            Me.maritalStatusTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmployeesBindingSource, "MaritalStatus", True))
            Me.genderTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmployeesBindingSource, "Gender", True))
            Me.hireDateDateTimePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.EmployeesBindingSource, "HireDate", True))
            Me.salariedFlagCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.EmployeesBindingSource, "SalariedFlag", True))
            Me.vacationHoursTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmployeesBindingSource, "VacationHours", True))
            Me.sickLeaveHoursTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmployeesBindingSource, "SickLeaveHours", True))
            Me.currentFlagCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.EmployeesBindingSource, "CurrentFlag", True))
        End If
    End Sub

    Public Sub SetupTab2()

        ' Generate the second BindingNavigator (Standard UI)
        ' Constructor parameter addStandardItems = true,
        ' meaning give the control the "standard" VCR type UI
        Me.BindingNavigatorStandard = New BindingNavigator(True)

        ' Place navigator on 2nd tab
        Me.tabPageStandard.Controls.Add(Me.BindingNavigatorStandard)
        Me.BindingNavigatorStandard.Dock = DockStyle.Fill

    End Sub

    Public Sub SetupTab3()

        ' Generate the third BindingNavigator (Custom UI)
        ' Constructor parameter addStandardItems = false,
        ' for constructing a custom UI
        Me.BindingNavigatorCustom = New BindingNavigator(False)

        ' Build the custom UI
        ' Generate buttons
        Dim firstButton As New ToolStripButton("|<")
        Dim prevButton As New ToolStripButton("<<")
        Dim nextButton As New ToolStripButton(">>")
        Dim lastButton As New ToolStripButton(">|")
        Dim separator1 As New System.Windows.Forms.ToolStripSeparator()
        Dim positionItem As New System.Windows.Forms.ToolStripTextBox()
        Dim countItem As New System.Windows.Forms.ToolStripLabel()
        Dim separator2 As New System.Windows.Forms.ToolStripSeparator()
        Dim addNewItem As New System.Windows.Forms.ToolStripButton("Add")
        Dim deleteItem As New System.Windows.Forms.ToolStripButton("Delete")

        positionItem.Text = "0"
        positionItem.ToolTipText = "Current Index"

        ' Add buttons to the BindingNavigatorCustom, which is a toolstrip
        ' The order in which the buttons are added is 
        ' the order in which buttons are displayed.
        Me.BindingNavigatorCustom.Items.AddRange(New ToolStripItem() _
            {firstButton, prevButton, nextButton, lastButton, _
            separator1, positionItem, countItem, _
            separator2, addNewItem, deleteItem})

        ' Hook up controls to navigator functionality
        Me.BindingNavigatorCustom.MoveFirstItem = firstButton
        Me.BindingNavigatorCustom.MoveLastItem = lastButton
        Me.BindingNavigatorCustom.MoveNextItem = nextButton
        Me.BindingNavigatorCustom.MovePreviousItem = prevButton
        Me.BindingNavigatorCustom.PositionItem = positionItem
        Me.BindingNavigatorCustom.CountItem = countItem
        Me.BindingNavigatorCustom.CountItemFormat = "of {0}"
        Me.BindingNavigatorCustom.AddNewItem = addNewItem
        Me.BindingNavigatorCustom.DeleteItem = deleteItem

        ' Place navigator on 3rd tab
        Me.tabPageCustom.Controls.Add(Me.BindingNavigatorCustom)
        Me.BindingNavigatorCustom.Dock = DockStyle.Fill

    End Sub

    Public Function RetrieveDataSet() As DataSet

        Try

            ' Retrieve Employee data from database into a DataSet
            ' Build a connnection string to the database
            Dim connectStringBuilder As New SqlConnectionStringBuilder()
            connectStringBuilder.DataSource = ".\SQLEXPRESS"
            connectStringBuilder.AttachDBFilename = "C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\Data\AdventureWorks_Data.mdf"
            connectStringBuilder.IntegratedSecurity = True
            connectStringBuilder.UserInstance = True

            ' Prepare a DataSet to receive the Employee data
            Dim ds As New DataSet("Employees")

            ' Open connection to the AdventureWorks database
            Using connection As New SqlConnection(connectStringBuilder.ConnectionString)

                connection.Open()

                ' Retrieve Employee data
                Dim command As New SqlCommand( _
                  "SELECT TOP 100 * FROM [HumanResources].[Employee]", connection)

                Using drEmployees As SqlDataReader = command.ExecuteReader()

                    ds.Load( _
                     drEmployees, _
                     LoadOption.OverwriteChanges, _
                     New String() {"Employee"})
                End Using

                ' Close the connection to the database
                connection.Close()
            End Using


            Return ds
        Catch err As SqlException

            MessageBox.Show(Err.Message, "SQL Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

    Private Sub employeeIDTextBox_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles employeeIDTextBox.Validating
        Me.HandleValidation(sender, e, Me.employeeIDTextBox.Text.Trim(), True)
    End Sub

    Private Sub titleTextBox_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles titleTextBox.Validating
        Me.HandleValidation(sender, e, Me.titleTextBox.Text.Trim(), False)
    End Sub

    Private Sub maritalStatusTextBox_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles maritalStatusTextBox.Validating
        Me.HandleValidation(sender, e, Me.maritalStatusTextBox.Text.Trim(), False)
    End Sub

    Private Sub genderTextBox_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles genderTextBox.Validating
        Me.HandleValidation(sender, e, Me.genderTextBox.Text.Trim(), False)
    End Sub

    Private Sub vacationHoursTextBox_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles vacationHoursTextBox.Validating
        Me.HandleValidation(sender, e, Me.vacationHoursTextBox.Text.Trim(), True)
    End Sub

    Private Sub sickLeaveHoursTextBox_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles sickLeaveHoursTextBox.Validating
        Me.HandleValidation(sender, e, Me.sickLeaveHoursTextBox.Text.Trim(), True)
    End Sub

    Private Sub HandleValidation(ByVal sender As Object, ByVal e As CancelEventArgs, ByVal text As String, ByVal requiresNumeric As Boolean)
        Dim err As String = Nothing
        Dim numericFailed As Boolean = False
        If requiresNumeric Then
            Dim output As Integer
            Dim isNumeric As Boolean = Integer.TryParse(text, output)
            numericFailed = Not isNumeric
        End If
        If ((text.Length = 0) OrElse numericFailed) Then
            err = IIf(requiresNumeric, "Required Numeric Field", "Required Field")
            ErrorProvider1.SetError(CType(sender, Control), err)
            e.Cancel = True
        Else
            ErrorProvider1.Clear()
        End If
    End Sub
End Class
