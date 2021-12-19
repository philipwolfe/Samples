using System;
using System.IO;
using System.Collections;

class Anagrams 
{
    
    public static void Main(String[] args)
    {
        StreamReader din = File.OpenText ("words.txt");
        String str;
        StringTable st = new StringTable(); 
        
        Console.WriteLine("Reading data and insterting into a StringTable.");
        while ((str=din.ReadLine()) != null) {
            st.Add(str);
        }
        Console.WriteLine("Printing out the StringTable.");
        foreach (string s in st)
        {
            Console.WriteLine (s);
        }
        
		Console.WriteLine ("\r\nPress Return to exit.");
		Console.Read();
    }
}
