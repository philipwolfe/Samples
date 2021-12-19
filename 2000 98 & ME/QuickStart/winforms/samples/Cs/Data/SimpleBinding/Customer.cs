//------------------------------------------------------------------------------
/// <copyright from='1997' to='2001' company='Microsoft Corporation'>           
///    Copyright (c) Microsoft Corporation. All Rights Reserved.                
///       
///    This source code is intended only as a supplement to Microsoft
///    Development Tools and/or on-line documentation.  See these other
///    materials for detailed information regarding Microsoft code samples.
///
/// </copyright>                                                                
///   
/// <summary>
///    <para>
///   
///    This file contains 2 classes - Customer and CustomerList
///   
///    Customer represents a single customer   
///    CustomerList represents a collection of customers 
///
///    CustomerList is a strongly typed List - that is it implements IList
///    and has accessors which are of type Customer
///   
///    In order to enable design time support CustomerList also implements
///    IComponent - the implementation is delegated to an instance of Component   
///
///    This strongly typed list was generated using the CodeDom example in 
///    the HowTo section of the QuickStart
///   
///    </para>
/// </summary>
//------------------------------------------------------------------------------
namespace Microsoft.Samples.WinForms.Cs.SimpleBinding.Data {
    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Collections;
    using System.Collections.Bases;

    //Strongly typed list of Customers 
    //Implements IComponent so that we can use in the designer
    public class CustomerList : TypedCollectionBase, IComponent {

        private Component compImpl = new Component();

        public static CustomerList GetCustomers() {
            CustomerList cl = new CustomerList();
            cl.Add(Customer.ReadCustomer1());
            cl.Add(Customer.ReadCustomer2());
            cl.Add(Customer.ReadCustomer3());
            cl.Add(Customer.ReadCustomer4());
            cl.Add(Customer.ReadCustomer5());
            return cl;
        }

        //Component implemenmtation so that we can design this puppy
        public virtual void Dispose() {
            compImpl.Dispose();
        }

        [Browsable(false), Persistable(PersistableSupport.None)]
        public ISite Site  {
            get { return compImpl.Site;}
            set { compImpl.Site = value;}
        }

        public Customer this[int index] {
            get {return (Customer)(List[index]);}
            set {List[index] = value;}
        }
        
        public int Add(Customer value) {
            return List.Add(value);
        }
        
        public void Insert(int index, Customer value) {
            List.Insert(index, value);
        }
        
        public int IndexOf(Customer value) {
            return List.IndexOf(value);
        }
        
        public bool Contains(Customer value) {
            return List.Contains(value);
        }
        
        public void Remove(Customer value) {
            List.Remove(value);
        }
        
        public void CopyTo(Customer[] array, int index) {
            List.CopyTo(array, index);
        }
    }


    public class Customer : Component {

        private string id ;
        private string title ;
        private string firstName ;
        private string lastName ;
        private string address ;
        private DateTime dateOfBirth;

        internal static Customer ReadCustomer1() {
            Customer cust = new Customer("536-45-1245");
            cust.Title = "Mr.";
            cust.FirstName = "Otis";
            cust.LastName = "Redding";
            cust.DateOfBirth = DateTime.FromString("9/9/1941");
            cust.Address = "1 Dock Street,\r\nThe Bay,\r\nGeorgia,\r\nUSA";
            return cust;
        }

        internal static Customer ReadCustomer2() {
            Customer cust = new Customer("246-12-5645");
            cust.Title = "Mr.";
            cust.FirstName = "James";
            cust.LastName = "Brown";
            cust.DateOfBirth = DateTime.FromString("5/3/1933");
            cust.Address = "45 New Bag Street,\r\nBarnwell,\r\nSouth Carolina,\r\nUSA";
            return cust;
        }

        internal static Customer ReadCustomer3() {
            Customer cust = new Customer("651-27-8117");
            cust.Title = "Mz.";
            cust.FirstName = "Aretha";
            cust.LastName = "Franklin";
            cust.DateOfBirth = DateTime.FromString("3/25/1942");
            cust.Address = "21 Chain Ave.,\r\nMemphis,\r\nTennessee,\r\nUSA";
            return cust;
        }

        internal static Customer ReadCustomer4() {
            Customer cust = new Customer("786-34-2114");
            cust.Title = "Mr.";
            cust.FirstName = "Louis";
            cust.LastName = "Armstrong";
            cust.DateOfBirth = DateTime.FromString("8/4/1901");
            cust.Address = "The West End,\r\nNew Orleans,\r\nLousiana,\r\nUSA";
            return cust;
        }

        internal static Customer ReadCustomer5() {
            Customer cust = new Customer("445-34-4332");
            cust.Title = "Mz.";
            cust.FirstName = "Billie";
            cust.LastName = "Holiday";
            cust.DateOfBirth = DateTime.FromString("4/17/1915");
            cust.Address = "Southern Breeze Ave.,\r\nBaltimore,\r\nMaryland,\r\nUSA";
            return cust;
        }

        internal Customer(string ID): base() {
            this.id = ID ;    
        }

        public string ID { 
            get  { 
                return id ;
            }
        }

        public string FirstName { 
            get  { 
                return firstName ;
            }
            set {
                firstName = value ;
            }
        }

        public string Title { 
            get  { 
                return title ;
            }
            set {
                title = value ;
            }
        }

        public string LastName { 
            get  { 
                return lastName ;
            }
            set {
                lastName = value ;
            }
        }

        public string Address { 
            get  { 
                return address ;
            }
            set {
                address = value ;
            }
        }

        public DateTime DateOfBirth { 
            get  { 
                return dateOfBirth ;
            }
            set {
                dateOfBirth = value ;
            }
        }

        public override string ToString() {
            StringWriter sb = new StringWriter() ;
            sb.WriteLine("Customer: \n");
            sb.WriteLine(this.ID);
            sb.Write(this.Title);
            sb.Write(this.FirstName);
            sb.WriteLine(this.LastName);
            sb.WriteLine(this.DateOfBirth.ToString());
            sb.WriteLine(this.Address);
            return sb.ToString();
        }


    }
}
