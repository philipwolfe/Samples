Imports System.IO

Public Class Customer
    
    Private mCustID As String
    Private mTitle As String
    Private mFirstname As String
    Private mLastName As String
    Private mAddress As String
    Private mDateOfBirth As DateTime
    
    Public Shared Function LoadCustomers() As Customer()
        
        Dim Customers(4) As Customer
        Customers(0) = ReadCustomer1()
        Customers(1) = ReadCustomer2()
        Customers(2) = ReadCustomer3()
        Customers(3) = ReadCustomer4()
        Customers(4) = ReadCustomer5()
        
        Return Customers
        
    End Function
    
    Friend Shared Function ReadCustomer1() As Customer
        Dim Cust As Customer = New Customer("536-45-1245")
        Cust.Title = "Mr."
        Cust.FirstName = "Otis"
        Cust.LastName = "Redding"
        Cust.DateOfBirth = DateTime.Parse("9/9/1941")
        Cust.Address = "1 Dock Street," + Strings.Chr(13) + Strings.Chr(10) + "The Bay," + Strings.Chr(13) + Strings.Chr(10) + "Georgia," + Strings.Chr(13) + Strings.Chr(10) + "USA"
        Return Cust
    End Function
    
    Friend Shared Function ReadCustomer2() As Customer
        Dim Cust As Customer = New Customer("246-12-5645")
        Cust.Title = "Mr."
        Cust.FirstName = "James"
        Cust.LastName = "Brown"
        Cust.DateOfBirth = DateTime.Parse("5/3/1933")
        Cust.Address = "45 New Bag Street," + Strings.Chr(13) + Strings.Chr(10) + "Barnwell," + Strings.Chr(13) + Strings.Chr(10) + "South Carolina," + Strings.Chr(13) + Strings.Chr(10) + "USA"
        Return Cust
    End Function
    
    Friend Shared Function ReadCustomer3() As Customer
        Dim Cust As Customer = New Customer("651-27-8117")
        Cust.Title = "Mz."
        Cust.FirstName = "Aretha"
        Cust.LastName = "Franklin"
        Cust.DateOfBirth = DateTime.Parse("3/25/1942")
        Cust.Address = "21 Chain Ave.," + Strings.Chr(13) + Strings.Chr(10) + "Memphis," + Strings.Chr(13) + Strings.Chr(10) + "Tennessee," + Strings.Chr(13) + Strings.Chr(10) + "USA"
        Return Cust
    End Function
    
    Private Shared Function ReadCustomer4() As Customer
        Dim Cust As Customer = New Customer("786-34-2114")
        Cust.Title = "Mr."
        Cust.FirstName = "Louis"
        Cust.LastName = "Armstrong"
        Cust.DateOfBirth = DateTime.Parse("8/4/1901")
        Cust.Address = "The West End," + Strings.Chr(13) + Strings.Chr(10) + "New Orleans," + Strings.Chr(13) + Strings.Chr(10) + "Lousiana," + Strings.Chr(13) + Strings.Chr(10) + "USA"
        Return Cust
    End Function
    
    Private Shared Function ReadCustomer5() As Customer
        Dim Cust As Customer = New Customer("445-34-4332")
        Cust.Title = "Mz."
        Cust.FirstName = "Billie"
        Cust.LastName = "Holiday"
        Cust.DateOfBirth = DateTime.Parse("4/17/1915")
        Cust.Address = "Southern Breeze Ave.," + Strings.Chr(13) + Strings.Chr(10) + "Baltimore," + Strings.Chr(13) + Strings.Chr(10) + "Maryland," + Strings.Chr(13) + Strings.Chr(10) + "USA"
        Return Cust
    End Function
    
    Public Sub New(ByVal ID As String)
        MyBase.New()
        mCustID = ID
    End Sub
    
    Public ReadOnly Property ID() As String
        Get
            Return mCustID
        End Get
    End Property
    
    Public Property FirstName() As String
        Get
            Return mFirstName
        End Get
        Set
            mFirstName = Value
        End Set
    End Property
    
    Public Property Title() As String
        Get
            Return mTitle
        End Get
        Set
            mTitle = Value
        End Set
    End Property
    
    Public Property LastName() As String
        Get
            Return mLastName
        End Get
        Set
            mLastName = Value
        End Set
    End Property
    
    Public Property Address() As String
        Get
            Return mAddress
        End Get
        Set
            mAddress = Value
        End Set
    End Property
    
    Public Property DateOfBirth() As DateTime
        Get
            Return mDateOfBirth
        End Get
        Set(ByVal Value As DateTime)
            mDateOfBirth = Value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Dim sb As StringWriter = New StringWriter()
        sb.Write(Me.Title)
        sb.Write(" ")
        sb.Write(Me.FirstName)
        sb.Write(" ")
        sb.Write(Me.LastName)
        Return sb.ToString()
    End Function


End Class
