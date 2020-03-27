/// <summary>
/// Holds Math Utility Methods
/// </summary>
public class MathUtil
{	
    public static int GCD(int lhs, int rhs)
    {
        // Swap if required
        if ( lhs < rhs )
        {
            int t = lhs;
            lhs = rhs;
            rhs = t;
        }
        
        int remainder = lhs % rhs;
        
        if ( remainder == 0 )
        {
            return rhs;
        }
        else
        {
            return GCD( rhs, remainder);
        }
    } 
}