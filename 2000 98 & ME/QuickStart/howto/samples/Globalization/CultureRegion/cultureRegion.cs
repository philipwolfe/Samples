using System;
using System.Globalization;
 
class CultureAndRegion
{
 
 public static void Main(String[] args) 
 {
    CultureInfo c = new CultureInfo("en-us");
    Console.WriteLine ("The CultureInfo is set to: {0}", c.DisplayName);
    Console.WriteLine ("The parent culture is: {0}", c.Parent.DisplayName);
    Console.WriteLine ("The three leter ISO language name is: {0}", c.ThreeLetterISOLanguageName);
    Console.WriteLine ("The default calendar for this culture is: {0}\n\n", c.Calendar.ToString());

    RegionInfo r = new RegionInfo("us");
    Console.WriteLine ("The name of this region is: {0}", r.Name);
    Console.WriteLine ("The currency symbol for the region is: {0}", r.CurrencySymbol);
    Console.WriteLine ("Is this region metric : {0} \n\n", r.IsMetric);
    
    CultureInfo c2 = new CultureInfo("de-ch");
    Console.WriteLine ("The CultureInfo is set to: {0}", c2.DisplayName);
    Console.WriteLine ("The parent culture is: {0}", c2.Parent.DisplayName);
    Console.WriteLine ("The three leter ISO language name is: {0}", c2.ThreeLetterISOLanguageName);
    Console.WriteLine ("The default calendar for this culture is: {0}\n\n", c2.Calendar.ToString());

    RegionInfo r2 = new RegionInfo("de");
    Console.WriteLine ("The name of this region is: {0}", r2.Name);
    Console.WriteLine ("The currency symbol for the region is: {0}", r2.CurrencySymbol);
    Console.WriteLine ("Is this region metric : {0}", r2.IsMetric);
 }
}
 
