using System;

class ExceptionTest{

	public static String SeeIfIntIsOne(int i)
	{
		String s = "You passed in 1";
		if (i == 1) 
			{
				return s;
			}
		else throw new ArgumentException("Your integer was not 1");
		// it should be noted that this exception does not utilize the runtime's resource
		// system which would make the text of the exception easily localizable.
		// For examples of using resources, see the Resources section of Quickstart.
	}

	public static void Main(String []args)
	{
		//This code shows how to catch an exception
		try 
		{
			Console.WriteLine("We're going to call our method with two args, one valid and one invalid");
			Console.WriteLine();
			Console.WriteLine("Trying to call the method with an argument of 1");
			Console.WriteLine(SeeIfIntIsOne(1));
			Console.WriteLine();
			Console.WriteLine("Trying to call the method with an argument of 2");
			Console.WriteLine(SeeIfIntIsOne(2));	
		}
		catch (Exception e)
		{
			Console.WriteLine("The following error occured:");
			Console.WriteLine(e.ToString());
		}
		finally 
		{
			Console.WriteLine();
			Console.WriteLine("Now we can continue");
		}

		Console.WriteLine ("\r\nPress Return to exit.");
		Console.Read();
	} // end Main

} // end class ExceptionTest
