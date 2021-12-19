using System;
using System.Collections;



class sortExample 
{
        
    public static void Main(String[] args)
    {
        //Array.Sort works on any object that implements IComparable such as ints, doubles and strings
        
        int []intArray={1,3,5,6,2,4};
        Console.Write("The unsorted int array: ");
        PrintArray(intArray);
        //Sort and print the array
        Array.Sort(intArray);
        Console.Write("The sorted array: ");
        PrintArray(intArray);
        Console.WriteLine();

        double []doubleArray={1.5,4.3,2.5,6.9,2.01,0.04};
        Console.Write("The unsorted double array: ");
        PrintArray(doubleArray);
        //Sort and print the array
        Array.Sort(doubleArray);
        Console.Write("The sorted array: ");
        PrintArray(doubleArray);

        Console.WriteLine();
        string []stringArray={"red", "yellow", "green", "blue"};
        Console.Write("The unsorted string array: ");
        PrintArray(stringArray);
        //Sort and print the array
        Array.Sort(stringArray);
        Console.Write("The sorted array: ");
        PrintArray(stringArray);

        //And even your own objects, such as MyType

        Console.WriteLine();
        MyType[]myTypeArray =new MyType [] {new MyType (1),new MyType (3),new MyType (5),new MyType (6),
            new MyType (2),new MyType (4)};
        Console.Write("The unsorted myType array: ");
        PrintArray(myTypeArray);
        //Sort and print the array
        Array.Sort(myTypeArray);
        Console.Write("The sorted array: ");
        PrintArray(myTypeArray);

        //You can even compare objects that don't implement IComparable (or ones you want to custom compare).
        Console.WriteLine();
        Guid[]guidArray =new Guid[] {Guid.NewGuid(),Guid.NewGuid(),Guid.NewGuid(),Guid.NewGuid(),
                Guid.NewGuid(),Guid.NewGuid(),Guid.NewGuid()};
        Console.Write("The unsorted guidArray array: ");
        PrintArray(guidArray);
        //Sort the array using guidComparer
        Array.Sort(guidArray, new GuidComparer());
        Console.Write("The sorted array: ");
        PrintArray(guidArray);


        Console.WriteLine();
		Console.WriteLine ("Press Return to exit.");
		Console.Read();
        
    } // end Main
    public static void PrintArray(Array arr)
    {
        Console.WriteLine ();
        Console.Write ("{");
        foreach (object o in arr)
            Console.Write(" {0},", o);
        Console.WriteLine ("}");
        
    }
} // End class sortExample


class MyType : IComparable
{
    private int _value;
    public MyType (int value)
    {
        _value = value;
    }
    public int CompareTo (object o)
    {
        if (!(o is MyType)) throw new ArgumentException ("o must be of type 'MyType'");
        MyType v = (MyType) o;
        return _value - v._value;
    }
    override public string ToString ()
    {
        return String.Format ("MyType({0})", _value);
    }
}

class GuidComparer: IComparer
{
    public int Compare (object x, object y) 
    {
        Guid g1 = (Guid) x;
        Guid g2 = (Guid) y;
        
        return g1.ToString().CompareTo (g2.ToString ());
    }

}