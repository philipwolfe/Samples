' ------------------------------------------------------------------------------
'  <copyright from='1997' to='2001' company='Microsoft Corporation'>		   
'	  Copyright (c) Microsoft Corporation. All Rights Reserved. 			   
'		 
'	  This source code is intended only as a supplement to Microsoft
'	  Development Tools and/or on-line documentation.  See these other
'	  materials for detailed information regarding Microsoft code samples.
' 
'  </copyright> 															   
'	 
'  <summary>
'	  <para>
'	 
'	  This file contains 2 classes - Customer and CustomerList
'	 
'	  Customer represents a single customer   
'	  CustomerList represents a collection of customers 
' 
'	  CustomerList is a strongly typed List - that is it implements IList
'	  and has accessors which are of type Customer
'	 
'	  In order to enable design time support CustomerList also implements
'	  IComponent - the implementation is delegated to an instance of Component	 
' 
'	  This strongly typed list was generated using the CodeDom example in 
'	  the HowTo section of the QuickStart
'	 
'	  </para>
'  </summary>
' ------------------------------------------------------------------------------
Imports System
Imports System.ComponentModel
Imports System.IO
Imports System.Collections
Imports System.Collections.Bases
Imports Microsoft.VisualBasic

namespace Microsoft.Samples.WinForms.VB.SimpleBinding.Data 

	' Strongly typed list of Customers 
	' Implements IComponent so that we can use in the designer
	public class CustomerList 
		Inherits TypedCollectionBase

		private compImpl As Component = new Component()

		public shared Function GetCustomersArray() As Customer()
			Dim custList(5) As Customer
			custList(0) =Customer.ReadCustomer1()
			custList(1) = Customer.ReadCustomer2()
			custList(2)=Customer.ReadCustomer3()
			custList(3)=Customer.ReadCustomer4()
			custList(4)=Customer.ReadCustomer5()
			return custList
		End Function

		public shared Function GetCustomers() As CustomerList
			Dim custList As CustomerList = New CustomerList()
			custList.Add(Customer.ReadCustomer1())
			custList.Add(Customer.ReadCustomer2())
			custList.Add(Customer.ReadCustomer3())
			custList.Add(Customer.ReadCustomer4())
			custList.Add(Customer.ReadCustomer5())
			return custList
		End Function

		' Component implementation so that we can design this puppy
		public overridable Sub Dispose()
			compImpl.Dispose()
		End Sub

		public Property Site As ISite
			Get
				return compImpl.Site
			end Get
			Set
				compImpl.Site = value
			end Set
		End Property

		Public Property this(ByVal index As Integer) As Customer
			Get
				return CType(List(index),Customer)
			End Get
			Set
				List(index) = value
			End Set
		End Property
		
		public Function Add(ByVal value As Customer) As Integer
			Add = List.Add(value)
		End Function
		
		public Sub Insert(ByVal index As Integer, ByVal value As Customer)
			List.Insert(index, value)
		End Sub
		
		public Function IndexOf(ByVal value As Customer) As Integer
			return List.IndexOf(value)
		End Function
		
		public Function Contains(ByVal value As Customer) As Boolean
			return List.Contains(value)
		End Function
		
		public Sub Remove(ByVal value As Customer)
			List.Remove(value)
		End Sub
		
		public Sub CopyTo(ByVal array() As Customer, ByVal index As Integer)
			List.CopyTo(array, index)
		End Sub
	End Class


	public class Customer
	Inherits Component

		private strID as string 
		private strTitle as string 
		private strFirstname as string 
		private strLastName As string 
		private strAddress As string 
		private dtDateOfBirth As DateTime

		friend shared Function ReadCustomer1() As Customer 
			Dim cust As Customer = new Customer("536-45-1245")
			cust.Title = "Mr."
			cust.FirstName = "Otis"
			cust.LastName = "Redding"
			cust.DateOfBirth = DateTime.FromString("9/9/1941")
			cust.Address = "1 Dock Street," + Strings.Chr(13) + Strings.Chr(10) + "The Bay," + Strings.Chr(13) + Strings.Chr(10) + "Georgia," + Strings.Chr(13) + Strings.Chr(10) + "USA"
			return cust
		End Function

		friend shared Function ReadCustomer2() As Customer 
			Dim cust As Customer = new Customer("246-12-5645")
			cust.Title = "Mr."
			cust.FirstName = "James"
			cust.LastName = "Brown"
			cust.DateOfBirth = DateTime.FromString("5/3/1933")
			cust.Address = "45 New Bag Street," + Strings.Chr(13) + Strings.Chr(10) + "Barnwell," + Strings.Chr(13) + Strings.Chr(10) + "South Carolina," + Strings.Chr(13) + Strings.Chr(10) + "USA"
			return cust
		End Function

		friend shared Function ReadCustomer3() As Customer 
			Dim cust As Customer = new Customer("651-27-8117")
			cust.Title = "Mz."
			cust.FirstName = "Aretha"
			cust.LastName = "Franklin"
			cust.DateOfBirth = DateTime.FromString("3/25/1942")
			cust.Address = "21 Chain Ave.," + Strings.Chr(13) + Strings.Chr(10) + "Memphis," + Strings.Chr(13) + Strings.Chr(10) + "Tennessee," + Strings.Chr(13) + Strings.Chr(10) + "USA"
			return cust
		End Function

		friend shared Function ReadCustomer4() As Customer 
			Dim cust As Customer = new Customer("786-34-2114")
			cust.Title = "Mr."
			cust.FirstName = "Louis"
			cust.LastName = "Armstrong"
			cust.DateOfBirth = DateTime.FromString("8/4/1901")
			cust.Address = "The West End," + Strings.Chr(13) + Strings.Chr(10) + "New Orleans," + Strings.Chr(13) + Strings.Chr(10) + "Lousiana," + Strings.Chr(13) + Strings.Chr(10) + "USA"
			return cust
		End Function

		friend shared Function ReadCustomer5() As Customer 
			Dim cust As Customer = new Customer("445-34-4332")
			cust.Title = "Mz."
			cust.FirstName = "Billie"
			cust.LastName = "Holiday"
			cust.DateOfBirth = DateTime.FromString("4/17/1915")
			cust.Address = "Southern Breeze Ave.," + Strings.Chr(13) + Strings.Chr(10) + "Baltimore," + Strings.Chr(13) + Strings.Chr(10) + "Maryland," + Strings.Chr(13) + Strings.Chr(10) + "USA"
			return cust
		End Function

		friend Sub New(ByVal ID As String)
		MyBase.New()
			Me.strID = ID
		End Sub

		public ReadOnly Property ID As String
			Get
				return strID
			End Get
		End Property

		public Property FirstName As String
			Get
				return strFirstName
			End Get
			Set
				strFirstName = value
			End Set
		End Property

		public Property Title As String
			Get
				return strTitle
			End Get
			Set
				strTitle = value
			End Set
		End Property

		public Property LastName As String
			Get
				return strLastName
			End Get
			Set
				strLastName = value
			End Set
		End Property

		public Property Address As String
			Get
				return strAddress
			End Get
			Set
				strAddress = value
			End Set
		End Property

		public Property DateOfBirth As DateTime
			Get
				return dtDateOfBirth
			End Get
			Set
				dtDateOfBirth = value
			End Set
		End Property

		public overrides Function ToString() As String
			Dim sb As StringWriter = new StringWriter()
			sb.WriteLine("Customer: \n")
			sb.WriteLine(me.ID)
			sb.Write(me.Title)
			sb.Write(me.FirstName)
			sb.WriteLine(me.LastName)
			sb.WriteLine(me.DateOfBirth.ToString())
			sb.WriteLine(me.Address)
			return sb.ToString()
		End Function
	
	End Class

End Namespace

