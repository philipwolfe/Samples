using System;
using System.Collections;

class listSample
{
    
    public static void Main(String[] args)
    {
        ArrayList fruit = new ArrayList();
        fruit.Add("Apple");
        fruit.Add("Pear");
        fruit.Add("Orange");
        fruit.Add("Banana");
        foreach (String item in fruit)
        {
            Console.WriteLine(item);
        }
        
		Console.WriteLine ("\r\nPress Return to exit.");
		Console.Read();
    }
}
