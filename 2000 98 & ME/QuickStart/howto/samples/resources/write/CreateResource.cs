/** CreateResources writes a .resources file containing
one name/value pair.

  Resource should be merged into an assembly, but
  can also be used as standalone files, as demonstrated
  below.
*/

using System;
using System.Resources;

public class MakeResources
{
	public static void Main(string[] args)
	{
		ResourceWriter resourceWriter;
		
		// Create a .resources file and add one string.
		resourceWriter = new ResourceWriter("Greeting.resources");
		resourceWriter.AddResource("Greeting", "Welcome to Microsoft .Net Framework !");
		resourceWriter.Write();
		resourceWriter.Close();
		
		// Testing the resource file.
		ResourceManager rm = new ResourceManager( "Greeting",     // Name of the resource.
			".",            // Use current directory.
			null);
		
		// Query resource for object.
		Console.WriteLine("-->{0}<--", rm.GetString("Greeting"));
		
		Console.WriteLine ("\r\nPress Return to exit.");
		Console.Read();
	}
}
