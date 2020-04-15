//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).
// The FullTimeEmployee class inherits from the Employee class and
// therefore has all the properties, methods and events that Employee
// has. FullTimeEmployee also extends the Employee class by adding the
// ComputeAnnualLeave method and overriding the ComputeBonus method.

using System;

public class FullTimeEmployee: Employee
{
    // This constructor simply calls the default constructor in the base
    // class.
    public FullTimeEmployee() 
	{
    }

    // This constructor calls the parameterized constructor in the base
    // class, passing it the employee name.
    public FullTimeEmployee(string Name): base(Name)
	{
    }

    // The AnnualLeave property is measured in days, and is unique to the
    // FullTimeEmployee class.
    public int AnnualLeave
	{
        get {
            return ComputeAnnualLeave();
        }
    }

    // This Salary property procedure provides the implementation
    // for the Salary property that was declared but not
    // implemented in the base class.
    public new decimal Salary
	{
        get 
		{
            return c_Salary;
        }
        set
		{
			if ((value < Convert.ToDecimal(30000.0)) || (value > Convert.ToDecimal(500000.0)))
			{
				throw new ArgumentOutOfRangeException("Salary",
					"Full-time employee salary must be between " +
					"$30,000 and $500,000");
			}
			else 
			{
				c_Salary = value;
			}
        }
    }

    // By implementing the ComputeAnnualLeave method, this class is
    // extending the base class, Employee. The method does not appear in
    // the base class, nor in the PartTimeEmployee class, which is also
    // derived from Employee.
    //
    // The method computes how long the employee has been with the
    // company and gives him 4 days leave for each quarter of service.
    public int ComputeAnnualLeave() 
	{
        // Code to compute annual leave.
        // We're feeling generous in this How-To, so we're giving everyone
        // six weeks.
        return 42;
    }

    // : the ComputeBonus method for full-time employees.
    public override decimal ComputeBonus() 
	{
        // Full-time employees get an annual bonus of 1% of their
        // salary.
        //
        // Because the compiler interprets 0.01 a Long, you convert
        // it to Decimal with the CType function. That way, your math
        // calculation will meet the rules of Option Strict.
        //
        //  prevents you from accidentally narrowing a
        // data type (coercing a long into a Short, for example). You
        // can set  at the top of each file, or at the
        // project level.
        return c_Salary * Convert.ToDecimal(0.01);
    }
}

