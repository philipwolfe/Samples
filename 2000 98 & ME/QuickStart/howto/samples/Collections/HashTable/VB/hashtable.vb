Option Strict Off
Imports System
Imports System.Collections

Public Class HashTableSample 
	
	Public Shared Sub main()
  	  'Here we'll create a hash table of employee numbers and employee names
		Dim table As New Hashtable 
		table.Add("0123","Jay")
		table.Add("0569","Brad")
		table.Add("1254","Brian")
		table.Add("6839","Seth")
		table.Add("3948","Rajesh")
		table.Add("1930","Lakshan")
		table.Add("9341","Kristian")
		
		'now we'll look to see if an employee is in the table
		Console.Write("What's the name of the Employee ==-> ")
		Dim input As String 
		input = Console.ReadLine()
		If (table.ContainsValue(input))
			Console.WriteLine("Found {0} in the list.",input)
		Else
			Console.WriteLine("Employee {0} not found.",input)
		End If 
		Console.WriteLine ("Now we will print out the entire list of employees.  <press return to start>")
		Console.ReadLine ()
		Console.WriteLine ("ID		Name")
		Console.WriteLine ("--		----")
		Dim d as Object
		Dim d1 As DictionaryEntry
		For Each  d in table
		    d1 = CType (d, DictionaryEntry)
			Console.WriteLine ("{0,-15}{1}", d.Key, d.Value)
		Next
		

		Console.WriteLine ()
		Console.WriteLine ("Press Return to exit.")
		Console.Read()
	End Sub
End Class
