using System;
using System.Globalization;




class StringFormat 
{
    
    public static void Main(String[] args)
    {
               
        //Formatting a table
        Console.WriteLine("Formatting in a table");	
        string [] names = {"Mary-Beth", "Aunt Alma", "Sue", "My Really Long Name", "Matt"};
        for (int k = 0; k < 5; k++)
        {
            Console.WriteLine ("{0,-5}{1,-20}", k, names[k]);
            
        }
        Console.WriteLine();
        
        
        //Enum formatting
        Console.WriteLine("Enum Formatting");
        Console.WriteLine ("Name: {0}, Value: {1}", Color.Red.Format(), Color.Red.Format ("D", null));
        Console.WriteLine();
                
        
        //DateTime built in formats
        
        
        Console.WriteLine("DateTime Formatting:  Predefined formats");	
        Console.WriteLine();
        Console.WriteLine ("{0}\t{1}" ,"Code", "Format");
        Console.WriteLine ("{0}\t{1}" ,"----", "------");
        DateTime d = DateTime.Now;
        PrintFormat (DateTime.Now, "d");
        PrintFormat (DateTime.Now, "D");
        PrintFormat (DateTime.Now, "f");
        PrintFormat (DateTime.Now, "F");
        PrintFormat (DateTime.Now, "g");
        PrintFormat (DateTime.Now, "G");
        PrintFormat (DateTime.Now, "m");
        PrintFormat (DateTime.Now, "r");
        PrintFormat (DateTime.Now, "s");
        PrintFormat (DateTime.Now, "t");
        PrintFormat (DateTime.Now, "T");
        PrintFormat (DateTime.Now, "u");
        PrintFormat (DateTime.Now, "U");
        Console.WriteLine();
        
        //DateTime picture  formats
        
        Console.WriteLine("DateTime Formatting:  Picture formats");	
        Console.WriteLine ("{0}\t{1}" ,"Code", "Format");
        Console.WriteLine ("{0}\t{1}" ,"----", "------");
        PrintFormat (DateTime.Now, "ddd");
        PrintFormat (DateTime.Now, "MMMM dd, yyyy");
        
        
        //Number standard formats
        double num = 12.9625;
        Console.WriteLine();
        Console.WriteLine("Numeric Formatting:  Predefined formats");	
        Console.WriteLine ("{0}\t{1}" ,"Code", "Format");
        Console.WriteLine ("{0}\t{1}" ,"----", "------");
        PrintFormat (num, "c");
        PrintFormat (103, "d");
        PrintFormat (num, "e");
        PrintFormat (num, "f");
        PrintFormat (num, "g");
        PrintFormat (num, "n");
        PrintFormat (1102, "x");
        Console.WriteLine ();
        
        
        //Number custom formats
        int i = 25;
        
        Console.WriteLine("Numeric Formatting:  Picture formats");	
        Console.WriteLine ("{0}\t{1}" ,"Code", "Format");
        Console.WriteLine ("{0}\t{1}" ,"----", "------");
        PrintFormat (i, "#");
        PrintFormat (i, "###");
        PrintFormat (i, "#.00");
        PrintFormat (i/100.0, "%#");
        PrintFormat (i, "D4");
        Console.WriteLine ();
        
        //User defined types can specify their own formatting that works in exactly the same way.
        //See the definition of MyType below
        
        Console.WriteLine ("Formatting Custom Types");	
        Console.WriteLine ("{0}\t{1}" ,"Code", "Format");
        Console.WriteLine ("{0}\t{1}" ,"----", "------");
        MyType t = new MyType (43);
        PrintFormat (t, "b");
        
        
        //It is also possible to add new formatting codes to existing types (such as Int32 in this example).
        //See the definition for BaseFormatter below
        int j = 100;
        Console.WriteLine (String.Format ("{0} in the custom B8 format is {1:B8}", new object [] {j,j}, new BaseFormatter ()));
        Console.WriteLine (String.Format ("{0} in the custom B16 format is {1:B16}", new object [] {j,j}, new BaseFormatter ()));
        
		Console.WriteLine ();
        Console.WriteLine ("Press Return to exit.");
		Console.Read();

    } // end Main
    public static void PrintFormat (IFormattable value, string formatString)
    {
        Console.WriteLine ("{0}\t{1}", formatString, value.Format (formatString, null));
    }
} // End class formatExample


//This is my own custom type that implements IFormattable and respects the "b" format for binary 
//as well as all the formatting codes for Int32.
//Console.WriteLine, String.Format, etc will call the Format method to get the string form of an 
//instance of this type
public class MyType : IFormattable
{
    
    private int _value;//to store the value internal
    public MyType (int value)
    {
        _value = value;
    }
    //This is the formatting method called by String.Format.  In it, we look for the "b" format
    //which we respect  and then fall through to Int32's format for anything else we don't know about.
    public string Format (string format, IServiceObjectProvider sop) 
    {
        if (format.Equals ("b"))
            return Convert.ToString (_value, 2);
        else return _value.Format (format, sop);
    }
}


public enum Color
{
    Red,
        Blue,
        Green
}


//This class provides a new formatting code: Bn where n is any number between 2 and 64. This 
//Formatting code allows numbers to be printed out in any base.   
//To get access to the formatting code, a user needs to pass BaseFormatter to String.Format()

public class BaseFormatter : IServiceObjectProvider, ICustomFormatter
{
    
    //String.Format calls this method to get an instance of a ICustomFormatter to handle the formatting.
    //In our case, we just return the same instance (this), but it would be possible return an instance 
    //of a different type.
    public object GetServiceObject (Type service)
    {
        if (service == typeof (ICustomFormatter)) return this;
        else return null;
    }
    
    //Once String.Format gets the ICustomFormatter it calls this format method on each argument. 
    
    public string Format (string format, object arg, IServiceObjectProvider sop)  
    {
        if (format == null) return  String.Format ("{0}", arg);
        
        int i = format.Length;
        
        
        if (!format.StartsWith("B"))  //if it's not one of our codes
        {
            String temp = "{0:" + format +"}";
            return String.Format (temp, arg); //fall through to the system support
        }
        //otherwise, get the base out of the format string and use it to form the output string
        format = format.Trim (new char [] {'B'});
        int b = Convert.ToInt32 (format);
        return Convert.ToString ((int)arg, b);
    }
    
    
    
    
}
