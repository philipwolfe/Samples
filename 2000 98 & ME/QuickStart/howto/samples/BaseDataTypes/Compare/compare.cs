using System;


class compareExample 
{
    
    public static void Main(String[] args)
    {
        
        //this example will compare some ints
        Console.WriteLine ("Our Max method works on any type that implements IComparable....");
        Console.WriteLine ("ints: Max (5, 10) == {0}", Max (5, 10));
        Console.WriteLine ("doubles: Max (4.3, 2.5) == {0}", Max (4.3, 2.5));
        decimal d1 = 1235698;
        decimal d2 = -234238;
        Console.WriteLine ("decimals: Max ({0}, {1}) == {2}", d1, d2, Max (d1, d2));
        String s1 = "Mathew";
        String s2 = "Mark";
        Console.WriteLine ("strings: Max ({0}, {1}) == {2}", s1, s2, Max (s1, s2));
        Console.WriteLine ("chars: Max ({0}, {1}) == {2}", 't', 'a', Max ('t', 'a'));
        MyType t1 = new MyType (12);
        MyType t2 = new MyType (17);
        Console.WriteLine ("Custom types: Max ({0}, {1}) == {2}", t1, t2, Max (t1,  t2));
		Console.WriteLine ("\r\nPress Return to exit.");
		Console.Read();
        
    } // end Main
    public static IComparable Max (IComparable val1, IComparable val2)
    {
        if (val1.CompareTo(val2) > 0) return val1; //val1 > val2
        if (val1.CompareTo(val2) < 0) return val2; //val1 < val2
        if (val1.CompareTo(val2) == 0) return val1; //val1 == val2, return val1 by definition
        return null;
    }
} // End class 

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
