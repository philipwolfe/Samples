//
//  This program lists all the members of the String Type.
//


using System;
using System.Reflection;

class ListMembers
{
	
	public static void Main(String[] args)
	{
		Type t = typeof (String);
		Console.WriteLine ("Listing all the members (public and non public) of the {0} type", t);
		
		//Static Fields first
		FieldInfo [] fi = t.GetFields (BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
		Console.WriteLine ("//Static Fields");
		PrintMembers (fi);
		
		//Static Properites 
		PropertyInfo  [] pi = t.GetProperties (BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
		Console.WriteLine ("//Static Properites");
		PrintMembers (pi);
		
		//Static Events 
		EventInfo  [] ei = t.GetEvents (BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
		Console.WriteLine ("//Static Events");
		PrintMembers (ei);
		
		//Static Methods 
		MethodInfo [] mi = t.GetMethods (BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
		Console.WriteLine ("//Static Methods");
		PrintMembers (mi);
		
		//Constructors 
		ConstructorInfo [] ci = t.GetConstructors (BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
		Console.WriteLine ("//Constructors");
		PrintMembers (ci);
		
		//Instance Fields 
		fi = t.GetFields (BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
		Console.WriteLine ("//Instance Fields");
		PrintMembers (fi);
		
		//Instance Properites 
		pi = t.GetProperties (BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
		Console.WriteLine ("//Instance Properites");
		PrintMembers (pi);
		
		//Instance Events 
		ei = t.GetEvents (BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
		Console.WriteLine ("//Instance Events");
		PrintMembers (ei);
		
		//Instance Methods 
		mi = t.GetMethods (BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
		Console.WriteLine ("//Instance Methods");
		PrintMembers (mi);
		
		Console.WriteLine ("\r\nPress Return to exit.");
		Console.Read();
	}
	
	public static void PrintMembers (MemberInfo [] ms)
	{
		foreach (MemberInfo m in ms)
		{
			Console.WriteLine ("{0}{1}", "     ", m);
		}
		Console.WriteLine();
	}
}