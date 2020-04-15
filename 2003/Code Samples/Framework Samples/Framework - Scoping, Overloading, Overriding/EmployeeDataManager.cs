//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).
// The EmployeeDataManager class has methods for transferring employee
// data to and from the database. By being declared with the Friend
// keyword, its members are available to all code within the assembly
// it's a part of, but not to other assemblies.
//
// if it had been defined a protected Friend, it would be visible to
// all code inside the containing assembly and to derived classes in
// other assemblies.
//
// This class is a sealed class. The NotInheritable keyword means that
// no other class may inherit from it.


sealed class EmployeeDataManager
{
    // The WriteEmployeeData function is overloaded, with three
    // different signatures, accepting a FullTimeEmployee object, a
    // PartTimeEmployee object, or a TempEmployee object.
    //
    // It is also a static function, which means that you don't
    // necessarily have to create an instance of this class to use it.
    // You can call this shared procedure either by qualifying it with
    // the class name (EmployeeDataManager.WriteEmployeeData), or with
    // the variable name of a specific instance of the class
    // (edmManager.WriteEmployeeData).

    public static string WriteEmployeeData(FullTimeEmployee Employee) 
	{
        // Code to write to database
        return "Full-Time Employee data written to database.";
    }

    public static string WriteEmployeeData(PartTimeEmployee Employee) 
	{
        // Code to write to database
        return "Part-Time Employee data written to database.";
    }

    public static string WriteEmployeeData(TempEmployee Employee) 
	{
        // Code to write to database
        return "Temporary Employee data written to database.";
    }

    // Like the WriteEmployeeData function, the ReadEmployeeData
    // function has three overloads, one for each type of employee.
    public static string ReadEmployeeData(FullTimeEmployee Employee) 
	{
        // Code to read from database
        return "Full-Time Employee data read from database.";
    }

    public static string ReadEmployeeData(PartTimeEmployee Employee) 
	{
        // Code to read from database
        return "Part-Time Employee data read from database.";
    }

    public static string ReadEmployeeData(TempEmployee Employee) 
	{
        // Code to read from database
        return "Temporary Employee data read from database.";
    }
}

