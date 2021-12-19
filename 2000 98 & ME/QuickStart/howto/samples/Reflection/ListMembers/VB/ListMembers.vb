'
'  This program lists all the members of the String Type.
'
option  Strict off

Imports System
Imports System.Reflection

Public Class ListMembers

	public Shared Sub Main()
	
		Dim t as Type 
		t = GetType (String)
		Console.WriteLine ("Listing all the members (public and non public) of the {0} type", t)
		
		'Static Fields fist
		Dim fi () as FieldInfo 
		fi = t.GetFields (BindingFlags.Static BitOr BindingFlags.NonPublic BitOr BindingFlags.Public)
		Console.WriteLine ("//Static Fields")
		PrintMembers (fi)
		
		'Static Properites 
		Dim pi() as PropertyInfo
		pi = t.GetProperties (BindingFlags.Static BitOr BindingFlags.NonPublic BitOr BindingFlags.Public)
		Console.WriteLine ("//Static Properites")
		PrintMembers (pi)
		
		'Static Events 
		Dim ei()  as EventInfo
		ei = t.GetEvents (BindingFlags.Static BitOr BindingFlags.NonPublic BitOr BindingFlags.Public)
		Console.WriteLine ("//Static Events")
		PrintMembers (ei)
		
		'Static Methods 
		Dim mi () as MethodInfo
		mi = t.GetMethods (BindingFlags.Static BitOr BindingFlags.NonPublic BitOr BindingFlags.Public)
		Console.WriteLine ("//Static Methods")
		PrintMembers (mi)
		
		'Constructors 
		Dim ci() as ConstructorInfo
		ci = t.GetConstructors (BindingFlags.Instance BitOr BindingFlags.NonPublic BitOr BindingFlags.Public)
		Console.WriteLine ("//Constructors")
		PrintMembers (ci)
		
		'Instance Fields 
		fi = t.GetFields (BindingFlags.Instance BitOr BindingFlags.NonPublic BitOr BindingFlags.Public)
		Console.WriteLine ("//Instance Fields")
		PrintMembers (fi)
		
		'Instance Properites 
		pi = t.GetProperties (BindingFlags.Instance BitOr BindingFlags.NonPublic BitOr BindingFlags.Public)
		Console.WriteLine ("//Instance Properites")
		PrintMembers (pi)
		
		'Instance Events 
		ei = t.GetEvents (BindingFlags.Instance BitOr BindingFlags.NonPublic BitOr BindingFlags.Public)
		Console.WriteLine ("//Instance Events")
		PrintMembers (ei)
		
		'Instance Methods 
		mi = t.GetMethods (BindingFlags.Instance BitOr BindingFlags.NonPublic BitOr BindingFlags.Public)
		Console.WriteLine ("//Instance Methods")
		PrintMembers (mi)
		
		Console.WriteLine ()
		Console.WriteLine ("Press Return to exit.")
		Console.Read()
	End Sub
	
	public Shared Sub PrintMembers (ms () as MemberInfo)
	
		Dim m as object 
		for each  m in ms
			Console.WriteLine ("{0}{1}", "     ", m)
		Next 
		Console.WriteLine()
	End Sub
End Class