Imports System.Data

Public Class Employee
    ' Property variables       
    Private employeeIdValue As Integer
    Private firstNameValue As String
    Private lastNameValue As String
    Private titleValue As String
    Private birthDateValue As DateTime
    Private hireDateValue As DateTime
    Private maritalStatusValue As String

    ' Property accessors
    Public ReadOnly Property EmployeeId() As Integer
        Get
            Return employeeIdValue
        End Get
    End Property

    Public Property FirstName() As String
        Get
            Return firstNameValue
        End Get
        Set(ByVal value As String)
            firstNameValue = value
        End Set
    End Property

    Public Property LastName() As String
        Get
            Return lastNameValue
        End Get
        Set(ByVal value As String)
            lastNameValue = value
        End Set
    End Property

    Public Property Title() As String
        Get
            Return titleValue
        End Get
        Set(ByVal value As String)
            titleValue = value
        End Set
    End Property

    Public Property BirthDate() As DateTime
        Get
            Return birthDateValue
        End Get
        Set(ByVal value As DateTime)
            birthDateValue = value
        End Set
    End Property

    Public Property HireDate() As DateTime
        Get
            Return hireDateValue
        End Get
        Set(ByVal value As DateTime)
            hireDateValue = value
        End Set
    End Property

    Public Property MaritalStatus() As String
        Get
            Return maritalStatusValue
        End Get
        Set(ByVal value As String)
            maritalStatusValue = value
        End Set
    End Property

    Public Sub New()

        ' Provide default values
        employeeIdValue = 0
        FirstName = "Enter first name."
        LastName = "Enter last name."
        Title = "Enter title."
        BirthDate = DateTime.Today
        HireDate = DateTime.Today
        MaritalStatus = ""
    End Sub

    Public Sub New(ByVal employeeData As DataRow)

        employeeIdValue = CInt(employeeData("EmployeeId"))
        FirstName = CStr(employeeData("FirstName"))
        LastName = CStr(employeeData("LastName"))
        Title = CStr(employeeData("Title"))
        BirthDate = CDate(employeeData("BirthDate"))
        HireDate = CDate(employeeData("HireDate"))
        MaritalStatus = CStr(employeeData("MaritalStatus"))
    End Sub

    Public Shared Function LoadEmployees(ByVal employeesData As DataTable) As System.Collections.Generic.List(Of Employee)

        Dim employees As New List(Of Employee)()
        For i As Integer = 0 To employeesData.Rows.Count - 1
            Dim employeeData As DataRow = employeesData.Rows(i)
            Dim newEmployee As New Employee(employeeData)
            employees.Add(newEmployee)
        Next

        Return employees
    End Function


End Class
