using System;
using System.Globalization;

class parseExample 
{
    
    public static void Main(String[] args)
    {
        // This variable forces the data parsing to succeed.  If you'd like
        // to see the parsing work in your own locale, you can remove this
        // call and then replace all dates with ones that are formatted in
        // your locale specific manner.
        System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

        //Simple DateTime parsing 
        Console.WriteLine();
        String date = "03/17/77";
        Console.WriteLine("Parsing {0}.",date);	
        DateTime d = DateTime.Parse(date);
        Console.WriteLine("The date parsed as {0}",d);
        
        //DateTime parsing using ParseExact 
        Console.WriteLine();
        String date2 = "Thursday, March 17, 1977";
        Console.WriteLine("Parsing {0}.",date2);	
        DateTime d2 = DateTime.ParseExact(date2,"D", null);
        Console.WriteLine("The date parsed as {0}",d2);
        
        //Simple numeric parsing
        String toBeParsed = "123456";
        Console.WriteLine();
        Console.WriteLine("Parsing the string {0}.",toBeParsed);
        int i = Int32.Parse(toBeParsed);
        Console.WriteLine("The string parsed to {0}.",i);
        
        //Parsing using NumberStyles
        Console.WriteLine();
        String toBeParsed2 = "  (123456)";
        Console.WriteLine();
        Console.WriteLine("Parsing the string {0} which contains leading white space and parens.",toBeParsed);
        int j = Int32.Parse(toBeParsed2, NumberStyles.AllowParentheses|NumberStyles.AllowLeadingWhite);
        Console.WriteLine("The string parsed to {0}.",i);
        
		Console.WriteLine ("\r\nPress Return to exit.");
		Console.Read();
        
    } // end Main
} // End class formatExample
