'	This sample demonstrats how to use Type.InvokeMember to invoke a member of a type that 
'	 is not known until runtime.
'
'

Imports System
Imports System.Reflection

Public Class Invoke

	Public Shared Sub Main ()
	
		'Call a static method
		Dim t As Type 
		t = GetType (TestClass)
		t.InvokeMember ("SayHello", BindingFlags.Default BitOr BindingFlags.InvokeMethod BitOr BindingFlags.Static, nothing, nothing, new object () {})
		
		'Call an instance method
		Dim c as TestClass 
		c = new TestClass ()
		c.GetType().InvokeMember ("AddUp", BindingFlags.Default BitOr BindingFlags.InvokeMethod, nothing, c, new object () {})
		c.GetType().InvokeMember ("AddUp", BindingFlags.Default BitOr BindingFlags.InvokeMethod, nothing, c, new object () {})
		
		'Call a method with args
		Dim args as object () 
		args = new object () {100.09, 184.45}
		Dim result As object 
		result = t.InvokeMember ("ComputeSum", BindingFlags.Default BitOr BindingFlags.InvokeMethod BitOr BindingFlags.Static, nothing, nothing, args)
		Console.WriteLine ("{0} + {1} = {2}", args(0), args(1), result)
		
		'Get a field value
		result = t.InvokeMember ("Name", BindingFlags.Default BitOr BindingFlags.GetField, nothing, c, new object () {})
		Console.WriteLine ("Name == {0}", result)
		
		'Set a field
		t.InvokeMember ("Name", BindingFlags.Default BitOr BindingFlags.SetField, nothing, c, new object () {"NewName"})
		result = t.InvokeMember ("Name", BindingFlags.Default BitOr BindingFlags.GetField, nothing, c, new object () {})
		Console.WriteLine ("Name == {0}", result)
		
		'Get an indexed property value
		Dim  index As Int32
		index = 3
		result = t.InvokeMember ("Item", BindingFlags.Default BitOr BindingFlags.GetProperty , nothing, c, new object () {index})
		Console.WriteLine ("Item[{0}] == {1}", index, result)
		
		'Set an indexed property value
		index = 3
		t.InvokeMember ("Item", BindingFlags.Default BitOr BindingFlags.SetProperty, nothing, c, new object () {index, "NewValue"})
		result = t.InvokeMember ("Item", BindingFlags.Default BitOr BindingFlags.GetProperty , nothing, c, new object () {index})
		Console.WriteLine ("Item[{0}] == {1}", index, result)
		
		'Get a field or property
		result = t.InvokeMember ("Name", BindingFlags.Default BitOr BindingFlags.GetField BitOr BindingFlags.GetProperty, nothing, c, new object () {})
		Console.WriteLine ("Name == {0}", result)
		result = t.InvokeMember ("Value", BindingFlags.Default BitOr BindingFlags.GetField BitOr BindingFlags.GetProperty, nothing, c, new object () {})
		Console.WriteLine ("Value == {0}", result)
		
		'Call a method using default arguments
		 Dim t2 as Type 
		 t2 = Type.GetType ("TestClass2")
		t2.InvokeMember ("PrintValues",BindingFlags.Default BitOr BindingFlags.InvokeMethod  BitOr BindingFlags.DefaultValueBinding, nothing, Activator.CreateInstance(t2), new object () {100, 101})
		
		'Call a method using named arguments
		dim argValues as object() 
		argValues = new object () {"Mouse", "Micky"}
		dim argNames as String () 
		argNames = new String () {"lastName", "firstName"}
		t.InvokeMember ("PrintName", BindingFlags.Default BitOr BindingFlags.InvokeMethod, nothing, nothing, argValues, nothing, nothing, argNames)
		
		'Call the default member of a type
		Dim t3 As Type 
		t3 = GetType (TestClass2)
		t3.InvokeMember ("", BindingFlags.Default  BitOr BindingFlags.InvokeMethod, nothing, new TestClass2(), new object () {})
		
		'Invoking a ByRef member
		Dim m as MethodInfo 
		m = t.GetMethod("Swap")
		args = new object() {CObj(1), CObj(2)}
		
		m.Invoke(new TestClass(),args)
		Console.WriteLine ("{0}, {1}", args(0), args(1))
		
		Console.WriteLine ()
		Console.WriteLine ("Press Return to exit.")
		Console.Read()
	End Sub
End Class


public class TestClass

	public Name As String 
	private values () As Object  = new Object () {0, 1,2,3,4,5,6,7,8,9}

	public Property Item (index As Int32) As Object
		Get 
			return values(index)
		End Get
		Set 
			values(index) = value
		End Set
		
	End Property

	public ReadOnly Property  Value as Object  
		Get 
		
			return "the value"
		End Get
	End Property
	
	Public Sub New()
		MyBase.New()
		Name = "initalName"
	End Sub
	
	Shared methodCalled as Int32 = 0

	Public Shared Sub SayHello ()
	
		Console.WriteLine ("Hello")
	End Sub
	
	Public Shared Sub AddUp ()
		methodCalled = methodCalled + 1
		Console.WriteLine ("AddUp Called {0} times", methodCalled)
	End Sub
	
	Public Shared Function  ComputeSum (d1 as double , d2 as double) as Double
	
		return d1 + d2
	End Function

	public Shared Sub PrintName (firstName as String , lastName as String )
	
		Console.WriteLine ("{0},{1}", lastName,firstName)
	End Sub

	public Shared Sub PrintTime ()
	
		Console.WriteLine (DateTime.Now)
	End Sub

	public Shared Sub Swap(ByRef a As Int32 , ByRef b as Int32)
	
		Dim x as Int32
		x = a
		a = b
		b = x
	End Sub
End Class

public  class <DefaultMemberAttribute ("PrintTime")> TestClass2

	public Sub PrintTime ()
		Console.WriteLine (DateTime.Now)
	End Sub
	
	Public Sub PrintValues (optional a as int32= 99, optional b as int32 = 99, optional c as int32 = 99)
	   Console.WriteLine ("a = {0}, b = {1}, c = {2}", a,b,c)
	End Sub
End Class


