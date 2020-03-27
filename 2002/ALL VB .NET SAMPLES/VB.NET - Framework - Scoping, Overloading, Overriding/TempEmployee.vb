'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

' The TempEmployee class derives from the Employee class. It
' implements the Salary property that was declared in Employee,
' and implements its own version of the ComputeBonus and Hire methods.
'
' It shadows the Hire method, which means that not only will its
' version of Hire take precedence. but the hire methods in the base
' class are not accessible at all to a TempEmployee object.
Public Class TempEmployee
    Inherits Employee

    ' Temporary employees have an expected termination date, which is
    ' entered as an argument to the Hire method (see below). This
    ' Public variable holds that date. It is a Field, a public property
    ' that can be written and read without a property procedure.
    '
    ' Of course, you give up the validation and control over the
    ' that property procedures offer. Try setting this to a date in
    ' last year, for example, and it will be accepted.
    Public ExpectedTermDate As DateTime

    Public Overrides Property Salary() As Decimal
        Get
            Return c_Salary
        End Get
        Set(ByVal Value As Decimal)
            If Value < 10000.0 Or Value > 20000.0 Then
                Throw New ArgumentOutOfRangeException( _
                     "Salary", "Temporary employee salary must " & _
                     "be between $10,000 and $20,000")
            Else
                c_Salary = Value
            End If
        End Set
    End Property

    ' Implements the ComputeBonus method for temporary employees.
    ' It would be nice to shadow this function (see the Hire method
    ' below) but you cannot shadow a function declared as MustOverride.
    Public Overrides Function ComputeBonus() As Decimal
        ' Temporary employees get no bonus.
        Return 0
    End Function

    ' This Hire method shadows the Hire method in Employee, which means
    ' that, not only will this version of Hire take precedence, but the
    ' Hire methods in the base class are not accessible at all to this
    ' class.
    Public Shadows Sub Hire(ByVal Name As String, ByVal HireDate As DateTime, ByVal StartingSalary As Decimal, ByVal EmploymentEndDate As DateTime)
        c_Name = Name
        c_HireDate = HireDate
        c_Salary = StartingSalary
        ExpectedTermDate = EmploymentEndDate
    End Sub
End Class
