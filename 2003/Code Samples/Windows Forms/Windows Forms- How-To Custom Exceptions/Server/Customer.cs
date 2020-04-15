//Copyright (C) 2002 Microsoft Corporation

//All rights reserved.

//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 

//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 

//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).


using System;

public class Customer
{

	// In real life we'd use property procedures.

	public int Id;
	public string FirstName;
	public string LastName;

	public static Customer EditCustomer(int Id)
	{
		// Pretend we look for the customer in our database
		// We can't find it, so we notify our caller in a way in 
		// which they can't ignore us.
		string strMsg;
		strMsg = string.Format("The customer you requested by Id {0} could not be found.", Id);
		// Create the exception.
		CustomerNotFoundException exp = new CustomerNotFoundException(strMsg);
		// throw it to our caller
		throw exp;

	}

	public static void DeleteCustomer(int Id)
	{
		// Pretend we find the customer in the database
		// but realize we shouldn't delete them, maybe for
		// security reasons.
		Customer c = new Customer();
		c.Id = Id;
		c.FirstName = "Joe";
		c.LastName = "Smith";

		// This could fail if we don't have rights.

		string strUser;
		try 
		{
			strUser = System.Environment.UserDomainName + @"\" + System.Environment.UserName;
		}
		catch
		{
			strUser = "Unavailable";
		}

		string strMsg;
		strMsg = string.Format("The customer you requested {0} {1} could not be deleted. Your account '{2}' does not have permission.", c.FirstName, c.LastName, strUser);
		CustomerNotDeletedException exp = new CustomerNotDeletedException(strMsg, c, strUser);
		exp.LogError();
		throw exp;
	}

}

// This exception provides the base for
// our CRM system. In large projects
// it would be defined in its own assembly for
// ease of versioning and enhancement.

public class CRMSystemException: System.ApplicationException
{
	private string m_AppSource;

	public CRMSystemException(string message):base(message)
	{
		this.m_AppSource = "SomeCompany CRM System";
	}

	// We only want this method exposed to code
	// in the same assembly. However, we might need to 
	// change the scope if this class were in another
	// assembly.

	internal void LogError()
	{
		System.Diagnostics.EventLog e;
		e = new System.Diagnostics.EventLog("Application");
		e.Source = this.AppSource;
		e.WriteEntry(this.Message, System.Diagnostics.EventLogEntryType.Error);
		e.Dispose();
	}

	// We're exposing a generic 'company' source
	// that children can override if they want.

	public string AppSource		   {
		get {
			return m_AppSource;
		}
	}

}

// Base exception for our Customer module.
// All Customer exceptions will expose a Customer
// reference via the read only property CustomerInfo.
// Note however in some cases it will be null.

public class CustomerException: CRMSystemException
{

	private string m_AppSource;
	private Customer m_Customer;

	public CustomerException(string message, Customer ReqCustomer):base(message)
	{
		this.m_Customer = ReqCustomer;
		this.m_AppSource = "SomeCompany CRM Customer Module";
	}

	public Customer CustomerInfo
	{
		get {
			return this.m_Customer;
		}
	}

	// We wan't exceptions at this level to use
	// our AppSource, not our parents which becomes
	// important when someone calls LogError.

	public string AppSource
	{
		get {
			return this.m_AppSource;
		}
	}
}

// Simple exception

public class CustomerNotFoundException: CustomerException
{

	public CustomerNotFoundException(string Message):base(Message, null)
	{
		// We pass null for the Customer
		// since we couldn't find them.
	}
}

// This exception exposes a custom user id property
// that is initialized at construction.

public class CustomerNotDeletedException: CustomerException
{

	private string m_UserId;

	public CustomerNotDeletedException(string Message, Customer ReqCustomer,string UserId):base(Message, ReqCustomer)
	{
		this.m_UserId = UserId;
	}

	public string UserId
	{
		get {
			return this.m_UserId;
		}
	}

}

// Custom exceptions don't need to be complicated.
// Note this exeption might be defined in another assembly.

public class EmployeeException: CRMSystemException
{
	public EmployeeException(string message):base(message)
	{
	}
}

