using System;
using System.IO;

namespace ListBoxItemData
{
	/// <summary>
	/// Summary description for Customer.
	/// </summary>
	public class Customer
	{
		private string strID;
		private string strTitle;
		private string strFirstName;
		private string strLastName;
		private string strAddress;
		private DateTime dtDateOfBirth;

		public Customer(string ID)
		{
			this.strID = ID;
			//
			// TODO: Add constructor logic here
			//
		}

		public static Customer[] LoadCustomers()
		{
			Customer[] Customers = new Customer[5];
			Customers[0] = ReadCustomer1();
			Customers[1] = ReadCustomer2();
			Customers[2] = ReadCustomer3();
			Customers[3] = ReadCustomer4();
			Customers[4] = ReadCustomer5();

			return Customers;

		}

		internal static Customer ReadCustomer1()
		{
			Customer cust = new Customer("536-45-1245");
			cust.Title = "Mr.";
			cust.FirstName = "Otis";
			cust.LastName = "Redding";
			cust.DateOfBirth = DateTime.Parse("9/9/1941");
			cust.Address = "1 Dock Street," + "\r\n" + "The Bay," + "\r\n" + "Georgia," + "\r\n" + "USA";
			return cust;
		}

		internal static Customer ReadCustomer2()
		{
			Customer cust = new Customer("246-12-5645");
			cust.Title = "Mr.";
			cust.FirstName = "James";
			cust.LastName = "Brown";
			cust.DateOfBirth = DateTime.Parse("5/3/1933");
			cust.Address = "45 New Bag Street," + "\r\n" + "Barnwell," + "\r\n" + "South Carolina," + "\r\n" + "USA";
			return cust;
		}

		internal static Customer ReadCustomer3()
		{
			Customer cust = new Customer("651-27-8117");
			cust.Title = "Mz.";
			cust.FirstName = "Aretha";
			cust.LastName = "Franklin";
			cust.DateOfBirth = DateTime.Parse("3/25/1942");
			cust.Address = "21 Chain Ave.," + "\r\n" + "Memphis," + "\r\n" + "Tennessee," + "\r\n" + "USA";
			return cust;
		}

		private static Customer ReadCustomer4()
		{
			Customer cust = new Customer("786-34-2114");
			cust.Title = "Mr.";
			cust.FirstName = "Louis";
			cust.LastName = "Armstrong";
			cust.DateOfBirth = DateTime.Parse("8/4/1901");
			cust.Address = "The West End," + "\r\n" + "New Orleans," + "\r\n" + "Lousiana," + "\r\n" + "USA";
			return cust;
		}

		private static Customer ReadCustomer5()
		{
			Customer cust = new Customer("445-34-4332");
			cust.Title = "Mz.";
			cust.FirstName = "Billie";
			cust.LastName = "Holiday";
			cust.DateOfBirth = DateTime.Parse("4/17/1915");
			cust.Address = "Southern Breeze Ave.," + "\r\n" + "\r\n" + "Baltimore," + "\r\n" + "Maryland," + "\r\n" + "USA";
			return cust;
		}

		public string ID
		//public readonly string ID
		{
			get
			{
				return strID;
			}
		}

		public string FirstName
		{
			get
			{
				return strFirstName;
			}
			set
			{
				strFirstName = value;
			}
		}

		public string Title
		{
			get
			{
				return strTitle;
			}
			set
			{
				strTitle = value;
			}
		}

		public string LastName
		{
			get
			{
				return strLastName;
			}
			set
			{
				strLastName = value;
			}
		}

		public string Address
		{
			get
			{
				return strAddress;
			}
			set
			{
				strAddress = value;
			}
		}

		public DateTime DateOfBirth
		{
			get
			{
				return dtDateOfBirth;
			}
			set
			{
				dtDateOfBirth = value;
			}
		}

		public override string ToString()
		{
			StringWriter sb = new StringWriter();
			sb.Write(this.Title);
			sb.Write(" ");
			sb.Write(this.FirstName);
			sb.Write(" ");
			sb.Write(this.LastName);
			return sb.ToString();
		}
	}
}
