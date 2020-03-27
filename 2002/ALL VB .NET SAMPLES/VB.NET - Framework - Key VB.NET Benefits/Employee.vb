'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

' This class is declared with the MustInherit keyword. This means no
' instances of this class can be created. Instead, it serves as a
' blueprint for other classes which inherit from it.
Public MustInherit Class Employee
    ' Because the following variables are declared using the Protected
    ' keyword, they're accessible only from within the Employee class
    ' and classes derived from Employee, like FullTimeEmployee and
    ' PartTimeEmployee. The Private keyword would have made them
    ' accessible only within Employee.
    '
    ' You can use Protected only at the class level, outside of any
    ' procedures. You cannot declare protected variables at the module,
    ' namespace, or file level.
    Protected c_HireDate As DateTime
    Protected c_Name As String
    Protected c_Salary As Decimal
    Protected c_SocialServicesID As String

    ' This is the class's default constructor. This procedure runs when
    ' an Employee object is instantiated with no parameters. You can
    ' use it to set up default values for certain properties, to
    ' establish database connections, or any other initialization
    ' activities.
    '
    ' In this example, the default Hire Date is set to today.
    Public Sub New()
        c_HireDate = DateTime.Now.Date
    End Sub

    ' This is an overloaded, parameterized constructor (see the Hire
    ' method below for more on Overloaded methods).
    '
    ' This procedure runs when an Employee object is instantiated with
    ' a String parameter. Parameterized constructors allow data to be
    ' passed to the object at the same time as it is instantiated. This
    ' requires fewer accesses to the object, less code, and better
    ' performance.
    Public Sub New(ByVal Name As String)
        c_Name = Name
        c_HireDate = DateTime.Now.Date
    End Sub

    Public ReadOnly Property Bonus() As Decimal
        Get
            Return ComputeBonus()
        End Get
    End Property

    Public Property HireDate() As Date
        Get
            Return c_HireDate
        End Get
        Set(ByVal Value As Date)
            If Value <= DateTime.Now.Date Then
                c_HireDate = Value
            Else
                Throw New ArgumentException( _
                    "Hire Date cannot be later than today", "HireDate")
            End If
        End Set
    End Property

    Public Property Name() As String
        Get
            Return c_Name
        End Get
        Set(ByVal Value As String)
            c_Name = Value
        End Set
    End Property

    ' If you want to allow derived classes to implement completely
    ' different means of assigning wages/salary depending on the kind
    ' of employee they represent, you declare a property like
    ' Salary with the MustOverride keyword, which requires the
    ' derived class to override it and to provide its own
    ' implementation code.
    '
    ' Note that there is no End Property statement, nor any
    ' implementation statements.
    Public MustOverride Property Salary() As Decimal

    ' Because your company may have branches in other countries, you're
    ' using the generic term SocialServicesID to represent Social
    ' Security numbers in the USA, as well as other Social Service type
    ' IDs in other countries.
    '
    ' Unlike Salary, you include implementation statements to
    ' handle your most common type of employee, one in the USA. Derived
    ' classes are free to implement the property as they choose to, but
    ' they are not required to do so, as they are with Salary.
    Public Overridable Property SocialServicesID() As String
        Get
            Return c_SocialServicesID
        End Get

        Set(ByVal Value As String)
            ' You might want to use more complex validation, such as
            ' using a regular expression, perhaps allowing for the
            ' presence of hyphens.
            If IsNumeric(Value) And Len(Value) = 11 Then
                c_SocialServicesID = Value
            Else
                Throw New ArgumentException( _
                    "Social Security Number must be 11 numeric " & _
                    "characters", "SocialServicesID")
            End If
        End Set
    End Property

    ' ComputeBonus is marked with the MustOverride keyword, requiring
    ' derived classes to implement their own bonus calculation code.
    Public MustOverride Function ComputeBonus() As Decimal

    ' Hire is an overloaded method. When someone calls the Hire method,
    ' they must provide the name of the new employee, at least. But
    ' because the two other versions of this method allow the user to
    ' optionally provide the employee's hire date and salary as well.
    '
    ' The argument list in each version of the method must be different
    ' from all the others, either in the number of arguments, their
    ' data types, or both. This allows the compiler to distinguish
    ' which version of the method to use.
    '
    ' Derived classes may also have their own overloaded versions of
    ' this method, which must also be unique in their argument lists.
    Public Sub Hire(ByVal Name As String)
        c_Name = Name
    End Sub

    Public Sub Hire(ByVal Name As String, ByVal HireDate As DateTime)
        c_Name = Name
        c_HireDate = HireDate
    End Sub

    Public Sub Hire(ByVal Name As String, ByVal HireDate As DateTime, ByVal StartingSalary As Decimal)
        c_Name = Name
        c_HireDate = HireDate
        c_Salary = StartingSalary
    End Sub
End Class
