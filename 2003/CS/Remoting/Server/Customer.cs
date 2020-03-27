//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;

namespace RemotingSample
{
	public class Customer : MarshalByRefObject
	{
		//private fields for storage of property values of customer

		private byte m_Age = 0;
		private string m_Name = "<<Uninitialized>>";
		// private field to store time object instance was created.
		private readonly DateTime mdteCreationTime = DateTime.Now;

		//Default no argument constructor
		public Customer() 
		{
		}
		//Parameterized Constructor called only by Client Activated Objects
		public Customer(string newName, byte newAge)
		{
			this.Name = newName;
			this.Age = newAge;
		}

		//implementation for Age
		public byte Age 
		{
			get 
			{
				return m_Age;
			}
			set
			{
				if (value > 0) 
				{
					m_Age = value;
				}
				else 
				{
					m_Age = 0;
				}
			}
		}

		//implementation for Name

		public string Name 
		{
			get 
			{
				return m_Name;
			}
			set 
			{
				m_Name = value;
			}
		}

		//return Customer Name and Age a string
		public string GetCustomerInfo()
		{
			return string.Format("Customer Name is {0}. Customer Age is {1}", this.Name, this.Age);
		}

		// Accept changes to the Name + Age and return the values a string
		public string UpdateCustomerInfo(string newName, byte newAge) 
		{
			// Update local properties
			this.Name = newName;
			this.Age = newAge;
			// Do some work here like update a database (an exercise for the reader).
			return string.Format("Customer Name is {0}. Customer Age is {1}", this.Name, this.Age);
		}

		// The following properties are for getting information about the component
		// for testing purposes only. Some information is retrieved using the
		// AssemblyInfo class (defined in the AssemblyInfo.cs file).
		// All the members are decorated with the Debug keyword to designate their
		// testing status and to make them easy to find in IntelliSense.
		// The CodeBase will return the physical path from which the 
		// component is running.
		public string DebugCodeBase
		{
			get 
			{
				AssemblyInfo ainfo = new AssemblyInfo();
				return ainfo.CodeBase;
			}
		}

		// Returns the assembly's fully qualified name
		public string DebugFQName
		{
			get 
			{
				AssemblyInfo ainfo = new AssemblyInfo();
				return ainfo.AsmFQName;
			}
		}

		// Returns the date + time the current object instance was created.
		public DateTime DebugCreationTime
		{
			get 
			{
				return mdteCreationTime;
			}
		}

		// Returns the name of the machine that the object is running on.
		public string DebugHostName
		{
			get 
			{
				return System.Environment.MachineName;
			}
		}
	}
}

