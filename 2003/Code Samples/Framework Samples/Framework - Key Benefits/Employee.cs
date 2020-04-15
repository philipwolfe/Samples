//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).
// This class is declared with the MustInherit keyword. This means no
// instances of this class can be created. Instead, it serves a
// blueprint for other classes which inherit from it.

using System;

public abstract class Employee
{
	// Because the following variables are declared using the Protected
	// keyword, they're accessible only from within the Employee class
	// and classes derived from Employee, like FullTimeEmployee and
	// PartTimeEmployee. The private keyword would have made them
	// accessible only within Employee.
	//
	// You can use protected only at the class level, outside of any
	// procedures. You can! declare protected variables at the module,
	// namespace, or file level.

	protected DateTime c_HireDate;
	protected string c_Name;
	protected decimal c_Salary;
	protected string c_SocialServicesID;

	// This is the class's default constructor. This procedure runs when
	// an Employee object is instantiated with no parameters. You can
	// use it to set up default values for certain properties, to
	// establish database connections, or any other initialization
	// activities.
	//
	// In this example, the default Hire Date is set to today.

	public Employee()
	{
		c_HireDate = DateTime.Now.Date;
	}

	// This is an overloaded, parameterized constructor (see the Hire
	// method below for more on Overloaded methods).
	//
	// This procedure runs when an Employee object is instantiated with
	// a string parameter. Parameterized constructors allow data to be
	// passed to the object at the same time it is instantiated. This
	// requires fewer accesses to the object, less code, and better
	// performance.

	public Employee(string Name)
	{
		c_Name = Name;
		c_HireDate = DateTime.Now.Date;
	}

	public bool IsNumeric(string s) 
	{
		try 
		{
			Convert.ToInt64(s);
			return true;
		}
		catch(FormatException e) 
		{
			return false;
		}
	}

	public decimal Bonus
	{
		get 
		{
			return ComputeBonus();
		}
	}

	public DateTime HireDate
	{
		get 
		{
			return c_HireDate;
		}
		set
		{
			if (value <= DateTime.Now.Date) 
			{
				c_HireDate = value;
			}
			else 
			{
				throw new ArgumentException("Hire Date can! be later than today", "HireDate");
			}
		}
	}

	public string Name
	{
		get 
		{
			return c_Name;
		}
		set 
		{
			c_Name = value;
		}
	}

	// if you want to allow derived classes to implement completely
	// different means of assigning wages/salary depending on the kind
	// of employee they represent, you declare a property like
	// Salary with the MustOverride keyword, which requires the
	// derived class to override it and to provide its own
	// implementation code.
	//
	// Note that there is no } statement, nor any
	// implementation statements.

	public decimal Salary;
	
	// Because your company may have branches in other countries, you're
	// using the generic term SocialServicesID to represent Social
	// Security numbers in the USA, well other Social Service type
	// IDs in other countries.
	//
	// Unlike Salary, you include implementation statements to
	// handle your most common type of employee, one in the USA. Derived
	// classes are free to implement the property they choose to, but
	// they are not required to do so, they are with Salary.

	public string SocialServicesID
	{
		get 
		{
			return c_SocialServicesID;
		}
		set 
		{
            // You might want to use more complex validation, such as
            // using a regular expression, perhaps allowing for the
            // presence of hyphens.
			if((IsNumeric(value) == true) && (value.Length == 11))
			{
					c_SocialServicesID = value;
			}
			else 
			{
				throw new ArgumentException( "Social Security Number must be 11 numeric " + 
					"characters", "SocialServicesID");
			}
		}
	}

    // ComputeBonus is marked with the MustOverride keyword, requiring
    // derived classes to implement their own bonus calculation code.
    public abstract decimal ComputeBonus();
	
    // Hire is an overloaded method. When someone calls the Hire method,
    // they must provide the name of the new employee, at least. But
    // because the two other versions of this method allow the user to
    // optionally provide the employee's hire date and salary well.
    //
    // The argument list in each version of the method must be different
    // from all the others, either in the number of arguments, their
    // data types, or both. This allows the compiler to distinguish
    // which version of the method to use.
    //
    // Derived classes may also have their own overloaded versions of
    // this method, which must also be unique in their argument lists.

    public void Hire(string Name)
	{
        c_Name = Name;
    }

    public void Hire(string Name, DateTime HireDate)
	{
        c_Name = Name;
        c_HireDate = HireDate;
    }

    public void Hire(string Name, DateTime HireDate, decimal StartingSalary)
	{
        c_Name = Name;
        c_HireDate = HireDate;
        c_Salary = StartingSalary;
    }
}

