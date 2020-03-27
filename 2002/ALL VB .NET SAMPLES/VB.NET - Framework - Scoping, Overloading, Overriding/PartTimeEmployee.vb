'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

' The PartTimeEmployee class derives from the Employee class. It
' implements the Salary property that was declared in Employee,
' and implements its own version of the ComputeBonus method.
Public Class PartTimeEmployee
    Inherits Employee

    ' The variable c_MinHoursPerWeek is private, visible only to this
    ' class. It cannot be seen by any other class, including classes
    ' that derive from PartTimeEmployee.
    Private c_MinHoursPerWeek As Double

    ' This constructor simply calls the default constructor in the base
    ' class.
    Public Sub New()
        MyBase.New()
    End Sub

    ' This constructor calls the parameterized constructor in the base
    ' class, passing it the employee name.
    Public Sub New(ByVal Name As String)
        MyBase.New(Name)
    End Sub

    ' This property represente the minimum hours per week a part-time
    ' employee will be allowed to work.
    Public Property MinHoursPerWeek() As Double
        Get
            Return c_MinHoursPerWeek
        End Get
        Set(ByVal Value As Double)
            c_MinHoursPerWeek = Value
        End Set
    End Property

    Public Overrides Property Salary() As Decimal
        Get
            Return c_Salary
        End Get
        Set(ByVal Value As Decimal)
            If Value < 10000.0 Or Value > 30000.0 Then
                Throw New ArgumentOutOfRangeException( _
                     "Salary", "Part-time employee salary must " & _
                     "be between $10,000 and $30,000")
            Else
                c_Salary = Value
            End If
        End Set
    End Property

    ' Implements the ComputeBonus method for part time employees.
    Public Overrides Function ComputeBonus() As Decimal
        ' Part-time employees get an annual bonus of 0.5% of their
        ' salary.
        Return c_Salary * CType(0.005, Decimal)
    End Function

    ' This version of the Hire method overloads the Hire method in the
    ' Employee base class, adding a minimum-hours-per-week argument.
    '
    ' There are now four versions of the Hire method available in the
    ' PartTimeEmployee class. Because it is an override, this version
    ' will show up first on the Intellisense list.
    Public Overloads Sub Hire(ByVal Name As String, ByVal HireDate As DateTime, ByVal StartingSalary As Decimal, ByVal MinHoursPerWeek As Double)
        c_Name = Name
        c_HireDate = HireDate
        c_Salary = StartingSalary
        c_MinHoursPerWeek = MinHoursPerWeek
    End Sub
End Class
