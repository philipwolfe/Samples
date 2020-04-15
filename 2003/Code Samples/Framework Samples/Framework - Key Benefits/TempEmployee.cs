//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).
// The TempEmployee class derives from the Employee class. It
// implements the Salary property that was declared in Employee,
// and implements its own version of the ComputeBonus and Hire methods.
//
// It shadows the Hire method, which means that not only will its
// version of Hire take precedence. but the hire methods in the base
// class are not accessible at all to a TempEmployee object.

using System;

public class TempEmployee : Employee
{
    // Temporary employees have an expected termination date, which is
    // entered an argument to the Hire method (see below). This
    // public variable holds that date. It is a Field, a public property
    // that can be written and read without a property procedure.
    //
    // Of course, you give up the validation and control over the
    // that property procedures offer. try { setting this to a date in
    // last year, for example, and it will be accepted.
    public DateTime ExpectedTermDate;

    public new decimal Salary
	{
        get {
            return c_Salary;
        }
        set
		{
			if ((value < Convert.ToDecimal(10000.0)) || (value > Convert.ToDecimal(20000.0))) 
			{
				throw new ArgumentOutOfRangeException("Salary", "Temporary employee salary must " + 
				"be between $10,000 and $20,000");
			}
			else 
			{
				c_Salary = value;
			}
        }
    }

    // : the ComputeBonus method for temporary employees.
    // It would be nice to shadow this function (see the Hire method
    // below) but you can! shadow a function declared MustOverride.
    public override decimal ComputeBonus()
	{
        // Temporary employees get no bonus.
        return 0;
    }

    // This Hire method shadows the Hire method in Employee, which means
    // that, not only will this version of Hire take precedence, but the
    // Hire methods in the base class are not accessible at all to this
    // class.

    public void Hire(string Name ,DateTime HireDate ,decimal StartingSalary ,DateTime EmploymentEndDate )
	{
        c_Name = Name;
        c_HireDate = HireDate;
        c_Salary = StartingSalary;
        ExpectedTermDate = EmploymentEndDate;
    }
}

