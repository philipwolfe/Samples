using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace UsingBindingSource
{
    class Employee
    {
        // Property variables       
        private int employeeId;
        private string firstName;
        private string lastName;
        private string title;
        private DateTime birthDate;
        private DateTime hireDate;
        private string maritalStatus;

        // Property accessors
        public int EmployeeId
        {
            get { return employeeId; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public DateTime BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }

        public DateTime HireDate
        {
            get { return hireDate; }
            set { hireDate = value; }
        }

        public string  MaritalStatus
        {
            get { return maritalStatus; }
            set { maritalStatus = value; }
        }
        
        public Employee()
        {
            // Provide default values
            employeeId = 0;
            firstName = "Enter first name.";
            lastName = "Enter last name.";
            title = "Enter title.";
            birthDate = DateTime.Today;
            hireDate = DateTime.Today;
            maritalStatus = "";
        }

        public Employee(DataRow employeeData)
        {
            employeeId = (int)employeeData["EmployeeId"];
            firstName = (string)employeeData["FirstName"];
            lastName= (string)employeeData["LastName"];
            title = (string)employeeData["Title"];
            birthDate = (DateTime)employeeData["BirthDate"];
            hireDate = (DateTime)employeeData["HireDate"];
            maritalStatus = (string)employeeData["MaritalStatus"];
        }

        static public System.Collections.Generic.List<Employee> LoadEmployees(DataTable employeesData)
        {
            System.Collections.Generic.List<Employee> employees = new List<Employee>();
            for (int i = 0; i < employeesData.Rows.Count; i++)
            {
                DataRow employeeData = employeesData.Rows[i];
                Employee employee = new Employee(employeeData);
                employees.Add(employee);
            }

            return employees;
        }

    }
}
