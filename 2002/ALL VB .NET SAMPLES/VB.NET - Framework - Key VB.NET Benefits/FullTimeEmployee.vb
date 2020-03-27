'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

' The FullTimeEmployee class inherits from the Employee class and
' therefore has all the properties, methods and events that Employee
' has. FullTimeEmployee also extends the Employee class by adding the
' ComputeAnnualLeave method and overriding the ComputeBonus method.
Public Class FullTimeEmployee
    Inherits Employee

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

    ' The AnnualLeave property is measured in days, and is unique to the
    ' FullTimeEmployee class.
    Public ReadOnly Property AnnualLeave() As Integer
        Get
            Return ComputeAnnualLeave()
        End Get
    End Property

    ' This Salary property procedure provides the implementation
    ' for the Salary property that was declared but not
    ' implemented in the base class.
    Public Overrides Property Salary() As Decimal
        Get
            Return c_Salary
        End Get
        Set(ByVal Value As Decimal)
            If Value < 30000.0 Or Value > 500000.0 Then
                Throw New ArgumentOutOfRangeException( _
                     "Salary", _
                     "Full-time employee salary must be between " & _
                     "$30,000 and $500,000")
            Else
                c_Salary = Value
            End If
        End Set
    End Property

    ' By implementing the ComputeAnnualLeave method, this class is
    ' extending the base class, Employee. The method does not appear in
    ' the base class, nor in the PartTimeEmployee class, which is also
    ' derived from Employee.
    '
    ' The method computes how long the employee has been with the
    ' company and gives him 4 days leave for each quarter of service.
    Public Function ComputeAnnualLeave() As Integer
        ' Code to compute annual leave.
        ' We're feeling generous in this demo, so we're giving everyone
        ' six weeks.
        Return 42
    End Function

    ' Implements the ComputeBonus method for full-time employees.
    Public Overrides Function ComputeBonus() As Decimal
        ' Full-time employees get an annual bonus of 1% of their
        ' salary.
        '
        ' Because the compiler interprets 0.01 as a Long, you convert
        ' it to Decimal with the CType function. That way, your math
        ' calculation will meet the rules of Option Strict.
        '
        ' Option Strict On prevents you from accidentally narrowing a
        ' data type (coercing a Long into a Short, for example). You
        ' can set Option Strict On at the top of each file, or at the
        ' project level.
        Return c_Salary * CType(0.01, Decimal)
    End Function
End Class
