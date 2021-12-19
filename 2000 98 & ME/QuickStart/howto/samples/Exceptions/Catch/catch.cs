using System;

class ExceptionTest{

    public static void Main(String []args)
    {
        //This code shows how to catch an exception
        try 
        {
            Console.WriteLine("We're going to divide 10 by 0 and see what happens...");
            Console.WriteLine();
            int i = 10;
            int j = 0;
            int k = i/j;
            
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
