using System;
using System.Text;

/// <summary>
/// A simple Rational type example for the PDC.
/// </summary>
public struct Rational : System.IFormattable
{ 
    private int numerator;
    private int denominator;
    
	/// <summary>
	/// Constructor for the Rational Type
	/// </summary>
	/// <param name="n"> The numerator   </param>
	/// <param name="d"> The denominator </param>
    public Rational (int n, int d) 
    { 
        numerator   = n; 
        denominator = d; 
    } 
        
	/// <summary>
	/// Return the numerator for the Rational number
	/// </summary>
    public int Numerator
    {
        get { return numerator;  }
    }
    
	/// <summary>
	/// Return the denominator for the Rational number
	/// </summary>
    public int Denominator
    {
        get { return denominator; }
    }
    
	/// <summary>
	/// Returns the string representation of the Rational number.
	/// </summary>
    public override string ToString()
    {
        StringBuilder b = new StringBuilder();
        
        b.Append( Numerator );
        b.Append( '/' );
        b.Append( Denominator );        
        
        return b.ToString();
    }
    
	/// <summary>
	/// Explicit conversion from Rational to double.
	/// </summary>
	/// <param name="r"> The rational number to convert </param>
    public static explicit operator double(Rational r)
    {
        return (double) r.Numerator / r.Denominator;
    }   
    
	/// <summary>
	/// Implicit conversion from int to Rational.
	/// </summary>
	/// <param name="i"> The integer value to create a Rational from</param>
    public static implicit operator Rational(int i)
    {
        return new Rational(i, 1);
    }
    
	/// <summary>
	/// Add Operator
	/// </summary>
	/// <param name="lhs">The left-hand side of the add operation</param>
	/// <param name="rhs">The right-hand side of the add operation </param>
    public static Rational operator+ ( Rational lhs, Rational rhs ) 
    {
        return new Rational( lhs.Denominator * rhs.Numerator + lhs.Numerator * rhs.Denominator,
                              lhs.Denominator * rhs.Denominator );
    }    
    
	/// <summary>
	/// Return a reduced version of the Rational number passed.
	/// </summary>
	/// <param name="r"> The Rational number to reduce</param>
    public static Rational Reduced(Rational r)
    {
        int cd = MathUtil.GCD(r.Numerator, r.Denominator);
        
        return new Rational( r.Numerator / cd, r.Denominator / cd ); 
    }    
    
	/// <summary cref="Equals">
	/// The basic == operator.
	/// </summary>
	/// <param name="lhs">The left-hand side of the operator</param>
	/// <param name="rhs">The right-hand side of the operator</param>
    public static bool operator==( Rational lhs, Rational rhs ) 
    {                            
		return lhs.Equals(rhs);
    }

	/// <summary cref="Equals">
	/// The basic != operator
	/// </summary>
	/// <param name="lhs">The left-hand side of the operator</param>
	/// <param name="rhs">The right-hand side of the operator</param>
    public static bool operator!=( Rational lhs, Rational rhs ) 
    {                        
        return !lhs.Equals(rhs);
    }
   
	/// <summary>
	/// Return true if the object passed is the same value
	/// </summary>
	/// <param name="o">The object to compare to</param>
    public override bool Equals(object o)
    {
        bool eq = false;
                        
        if ( o is Rational )
        {
            Rational r = (Rational) o;

			Rational r1 = Reduced(this);
			Rational r2 = Reduced(r);
            
            eq = (r1.Numerator == r2.Numerator && 
				  r1.Denominator == r2.Denominator);
        }
        
        return eq;
    }
        
	/// <summary>
	/// Provides support for placeholder formatting
	/// </summary>
	/// <param name="formatStr">The placeholder format string</param>
	/// <param name="isop"> Context information for the formatting</param>
    public string Format(string formatStr, IServiceObjectProvider isop)
    {
        string s = this.ToString();
        
        if ( formatStr == "reduced" )
        {
            Rational r = Reduced(this);
            s = r.ToString();
        }
        
        return s;   
    }
}

/// <summary>
/// Basic Test Harness class for the Rationla Type
/// </summary>
public class Test
{   
    public static void Main()
    {
        // Create using the constructor
        Rational r1 = new Rational(1,4);        
        Rational r2 = new Rational(1,2);        
        
        // Do some addition 
        Rational r3 = r1 + r2;
        Console.WriteLine("{0} + {1} = {2}", r1, r2, r3);        
        
        // Note the use again of the implicit conversion from int.
        Rational r4 = r3 + 1;
        Console.WriteLine("{0} + {1} = {2}", r3, 1, r4);   

        // Create using the constructor - note that the values are the same 
        Rational r5 = new Rational(2,4);        
        Rational r6 = new Rational(1,2);        
        
		// Call the Equals operator
        if ( r5.Equals(r6) )
            Console.WriteLine("{0} .Equals {1}", r5, r6 );        
        else
            Console.WriteLine("{0} .Equals {1} returned false (WRONG!)", r5, r6 );        
        
		// Now use the short-hand for the Equals operator 
        if ( r5 == r6 )
            Console.WriteLine("{0} == {1}", r5, r6 );        
        else
            Console.WriteLine("{0} == {1} returned false (WRONG!)", r5, r6 );        
        
		// Create two more rationals
        Rational r7 = new Rational(1,2);        
        Rational r8 = new Rational(2,3);
        
		// Test the not equals operator 
        if ( r7 != r8 )
            Console.WriteLine("{0} != {1}", r7, r8 );        
        else
            Console.WriteLine("{0} == {1} (WRONG!)", r7, r8 );

		// Now lets call the Placeholder formatting support
        Rational r9 = new Rational(2,4);        
        
        Console.WriteLine("No Format      = {0}", r9);
        Console.WriteLine("Reduced Format = {0:reduced}", r9);
    }
}