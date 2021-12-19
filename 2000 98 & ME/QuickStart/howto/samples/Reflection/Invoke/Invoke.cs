/*	This sample demonstrates how to use Type.InvokeMember to invoke a member of a type that 
*	 is not known until runtime.
*
*/

using System;
using System.Reflection;

public class Invoke
{
	public static void Main (String [] cmdargs)
	{
		//Call a static method
		Type t = typeof (TestClass);
		t.InvokeMember ("SayHello", BindingFlags.Default | BindingFlags.InvokeMethod | BindingFlags.Static, null, null, new object [] {});
		
		//Call an instance method
		TestClass c = new TestClass ();
		c.GetType().InvokeMember ("AddUp", BindingFlags.Default | BindingFlags.InvokeMethod, null, c, new object [] {});
		c.GetType().InvokeMember ("AddUp", BindingFlags.Default | BindingFlags.InvokeMethod, null, c, new object [] {});
		
		//Call a method with args
		object [] args = new object [] {100.09, 184.45};
		object result;
		result = t.InvokeMember ("ComputeSum", BindingFlags.Default | BindingFlags.InvokeMethod | BindingFlags.Static, null, null, args);
		Console.WriteLine ("{0} + {1} = {2}", args[0], args[1], result);
		
		//Get a field value
		result = t.InvokeMember ("Name", BindingFlags.Default | BindingFlags.GetField, null, c, new object [] {});
		Console.WriteLine ("Name == {0}", result);
		
		//Set a field
		t.InvokeMember ("Name", BindingFlags.Default |BindingFlags.SetField, null, c, new object [] {"NewName"});
		result = t.InvokeMember ("Name", BindingFlags.Default |BindingFlags.GetField, null, c, new object [] {});
		Console.WriteLine ("Name == {0}", result);
		
		//Get an indexed property value
		int  index = 3;
		result = t.InvokeMember ("Item", BindingFlags.Default |BindingFlags.GetProperty , null, c, new object [] {index});
		Console.WriteLine ("Item[{0}] == {1}", index, result);
		
		//Set an indexed property value
		index = 3;
		t.InvokeMember ("Item", BindingFlags.Default |BindingFlags.SetProperty, null, c, new object [] {index, "NewValue"});
		result = t.InvokeMember ("Item", BindingFlags.Default |BindingFlags.GetProperty , null, c, new object [] {index});
		Console.WriteLine ("Item[{0}] == {1}", index, result);
		
		//Get a field or property
		result = t.InvokeMember ("Name", BindingFlags.Default |BindingFlags.GetField | BindingFlags.GetProperty, null, c, new object [] {});
		Console.WriteLine ("Name == {0}", result);
		result = t.InvokeMember ("Value", BindingFlags.Default |BindingFlags.GetField | BindingFlags.GetProperty, null, c, new object [] {});
		Console.WriteLine ("Value == {0}", result);
		
		//Call a method using named arguments
		object[] argValues = new object [] {"Mouse", "Micky"};
		String [] argNames = new String [] {"lastName", "firstName"};
		t.InvokeMember ("PrintName", BindingFlags.Default |BindingFlags.InvokeMethod, null, null, argValues, null, null, argNames);
		
		//Call the default member of a type
		Type t3 = typeof (TestClass2);
		t3.InvokeMember ("", BindingFlags.Default |BindingFlags.InvokeMethod, null, new TestClass2(), new object [] {});
		
		//Invoking a ByRef member
		MethodInfo m = t.GetMethod("Swap");
		args = new object[2];
		args[0] = 1;
		args[1] = 2;
		m.Invoke(new TestClass(),args);
		Console.WriteLine ("{0}, {1}", args[0], args[1]);
		
		Console.WriteLine ("\r\nPress Return to exit.");
		Console.Read();
	}
}

public class TestClass
{
	public String Name;
	private Object [] values = new Object [] {0, 1,2,3,4,5,6,7,8,9};

	public Object this [int index]
	{
		get {
			return values[index];
		}
		set {
			values[index] = value;
		}
	}

	public Object Value {
		get 
		{
			return "the value";
		}
	}
	
	public TestClass ()
	{
		Name = "initalName";
	}

	int methodCalled = 0;

	public static void SayHello ()
	{
		Console.WriteLine ("Hello");
	}
	
	public void AddUp ()
	{
		methodCalled++;
		Console.WriteLine ("AddUp Called {0} times", methodCalled);
	}
	
	public static double ComputeSum (double d1, double d2)
	{
		return d1 + d2;
	}

	public static void PrintName (String firstName, String lastName)
	{
		Console.WriteLine ("{0},{1}", lastName,firstName);
	}

	public void PrintTime ()
	{
		Console.WriteLine (DateTime.Now);
	}

	public void Swap(ref int a, ref int b)
	{
		int x = a;
		a = b;
		b = x;
	}
}

[DefaultMemberAttribute ("PrintTime")]
public class TestClass2
{
	public void PrintTime ()
	{
		Console.WriteLine (DateTime.Now);
	}
}