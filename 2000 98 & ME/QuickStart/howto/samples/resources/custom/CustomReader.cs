/** CustomReader: Implement the interface IResourceReader.
CustomManager: Sub-class ResourceManager and create
ResourceSets using the CustomReader class.
*/

using System;
using System.Collections;
using System.Globalization;
using System.Resources;


class CustomReader : IResourceReader 
{
	
    public void Close() 
    {
		// Close any open files, DB connections, etc here.
    }
	
    IEnumerator IEnumerable.GetEnumerator()
    {
		return GetEnumerator();
    }
	
    public IDictionaryEnumerator GetEnumerator() 
    {
		Dictionary dict = new Dictionary();
		
		dict["key1"] = "value 1";
		dict["key2"] = "value 2";
		dict["key3"] = "value 3";
		
		return dict.GetEnumerator();
    } 
    
}


public class CustomManager : ResourceManager 
{
    override protected ResourceSet InternalGetResourceSet( CultureInfo culture,
		bool createIfNotExists,
		bool tryParents ) 
    {
		return new ResourceSet( new CustomReader() );
    }
	
	
    public static void Main(string[] args)
    {
		ResourceManager resourceManager = new CustomManager();
		Console.WriteLine( "Lookup for key1 yields: "
			+ resourceManager.GetString("key1") );
		
		Console.WriteLine ("\r\nPress Return to exit.");
		Console.Read();
    }
	
}

