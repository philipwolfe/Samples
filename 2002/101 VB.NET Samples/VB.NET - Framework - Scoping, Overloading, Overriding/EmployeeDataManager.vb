'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

' The EmployeeDataManager class has methods for transferring employee
' data to and from the database. By being declared with the Friend
' keyword, its members are available to all code within the assembly
' it's a part of, but not to other assemblies.
'
' If it had been defined as a Protected Friend, it would be visible to
' all code inside the containing assembly and to derived classes in
' other assemblies.
'
' This class is a sealed class. The NotInheritable keyword means that
' no other class may inherit from it.
Friend NotInheritable Class EmployeeDataManager

    ' The WriteEmployeeData function is overloaded, with three
    ' different signatures, accepting a FullTimeEmployee object, a
    ' PartTimeEmployee object, or a TempEmployee object.
    '
    ' It is also a Shared function, which means that you don't
    ' necessarily have to create an instance of this class to use it.
    ' You can call this shared procedure either by qualifying it with
    ' the class name (EmployeeDataManager.WriteEmployeeData), or with
    ' the variable name of a specific instance of the class
    ' (edmManager.WriteEmployeeData).
    Public Shared Function WriteEmployeeData(ByVal Employee As FullTimeEmployee) As String
        ' Code to write to database
        Return "Full-Time Employee data written to database."
    End Function

    Public Shared Function WriteEmployeeData(ByVal Employee As PartTimeEmployee) As String
        ' Code to write to database
        Return "Part-Time Employee data written to database."
    End Function

    Public Shared Function WriteEmployeeData(ByVal Employee As TempEmployee) As String
        ' Code to write to database
        Return "Temporary Employee data written to database."
    End Function

    ' Like the WriteEmployeeData function, the ReadEmployeeData
    ' function has three overloads, one for each type of employee.
    Public Shared Function ReadEmployeeData(ByVal Employee As FullTimeEmployee) As String
        ' Code to read from database
        Return "Full-Time Employee data read from database."
    End Function

    Public Shared Function ReadEmployeeData(ByVal Employee As PartTimeEmployee) As String
        ' Code to read from database
        Return "Part-Time Employee data read from database."
    End Function

    Public Shared Function ReadEmployeeData(ByVal Employee As TempEmployee) As String
        ' Code to read from database
        Return "Temporary Employee data read from database."
    End Function
End Class
