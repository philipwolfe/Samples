using System;
using System.Collections;

class HashTableSample
{
	
	public static void Main(String[] args)
	{
		//Here we'll create a hash table of employee numbers and employee names
		Hashtable table = new Hashtable();
		table.Add("0123","Jay");
		table.Add("0569","Brad");
		table.Add("1254","Brian");
		table.Add("6839","Seth");
		table.Add("3948","Rajesh");
		table.Add("1930","Lakshan");
		table.Add("9341","Kristian");
		
		//now we'll look to see if an employee is in the table
		Console.Write("What's the name of the Employee ==-> ");
		String input = Console.ReadLine();
		if (table.ContainsValue(input))
		{
			Console.WriteLine("Found {0} in the list.",input);
		}
		else
		{
			Console.WriteLine("Employee {0} not found.",input);
		}
		Console.WriteLine ("Now we will print out the entire list of employees.  <press return to start>");
		Console.ReadLine ();
		Console.WriteLine ("ID\tName");
		Console.WriteLine ("--\t----");
		foreach (DictionaryEntry d in table)
		{
			Console.WriteLine ("{0}\t{1}", d.Key, d.Value);
		}

		Console.WriteLine ("\r\nPress Return to exit.");
		Console.Read();
	}
}
