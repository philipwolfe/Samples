//
//  This program get's all the types from a system assembly and this assembly.
//


using System;
using System.Reflection;

class GetTypes
{
	
	public static void Main(String[] args)
	{
		//List all the types from the mscorlib assembly.
		
		//Get the mscorlib assembly, it's the one Object is defined in
		Assembly a = typeof(Object).Module.Assembly;
		
		//Get all the types in this assembly
		Type [] types = a.GetTypes ();
		
		//let's take a look at them, and gather a little bit of data as we do it.
		int numValueTypes = 0;
		int numInterfaces = 0;
		Console.WriteLine ("Get all the types from the assembly: '{0}'", a.GetName());
		foreach (Type t in types)
		{
			Console.WriteLine (t.FullName);
			if (t.IsInterface) numInterfaces++;
			if (t.IsValueType) numValueTypes++;
		}
		Console.WriteLine ("Out of {0} types, {1} are interfaces and {2} are value types",
			types.Length, numInterfaces, numValueTypes);
		
		//Load THIS assembly using its file name
		Assembly b = Assembly.LoadFrom ("GetTypes.exe");
		Type [] types2 = b.GetTypes ();
		foreach (Type t in types2)
		{
			Console.WriteLine (t.FullName);
		}
		
		Console.WriteLine ("\r\nPress Return to exit.");
		Console.Read();
	}
	
}

public class TestClass1
{
}

public class TestClass2
{
}