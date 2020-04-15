//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).
// The PartTimeEmployee class derives from the Employee class. It
// implements the Salary property that was declared in Employee,
// and implements its own version of the ComputeBonus method.

using System;

public class PartTimeEmployee : Employee
{
    // The variable c_MinHoursPerWeek is private, visible only to this
    // class. It can! be seen by any other class, including classes
    // that derive from PartTimeEmployee.
    private double c_MinHoursPerWeek;
    // This constructor simply calls the default constructor in the base
    // class.
    public PartTimeEmployee() 
	{
    }
    // This constructor calls the parameterized constructor in the base
    // class, passing it the employee name.
    public PartTimeEmployee(string Name): base(Name)
	{
    }
    // This property represente the minimum hours per week a part-time
    // employee will be allowed to work.

    public double MinHoursPerWeek
	{
        get {
            return c_MinHoursPerWeek;
        }
        set
		{
            c_MinHoursPerWeek = value;
        }
    }

    public new decimal Salary
	{
        get {
            return c_Salary;
        }
        set
		{
			if ((value < Convert.ToDecimal(10000.0)) || (value > Convert.ToDecimal(30000.0)))
			{
				throw new ArgumentOutOfRangeException("Salary", "Part-time employee salary must " +
					"be between $10,000 and $30,000");
			}
			else 
			{
				c_Salary = value;
			}
        }
    }

    // : the ComputeBonus method for part time employees.
    public override decimal ComputeBonus() 
	{
        // Part-time employees get an annual bonus of 0.5% of their
        // salary.
        return c_Salary * (Decimal) 0.005;
    }

    // This version of the Hire method overloads the Hire method in the
    // Employee base class, adding a minimum-hours-per-week argument.
    //
    // There are now four versions of the Hire method available in the
    // PartTimeEmployee class. Because it is an override, this version
    // will show up first on the Intellisense list.
    public void Hire(string Name, DateTime HireDate, decimal StartingSalary, double MinHoursPerWeek)
{
        c_Name = Name;
        c_HireDate = HireDate;
        c_Salary = StartingSalary;
        c_MinHoursPerWeek = MinHoursPerWeek;
    }
}

