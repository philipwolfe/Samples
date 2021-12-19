'
'  This program get's all the types from a system assembly and this assembly.
'


Imports System
Imports System.Reflection

Public Class GetTypes

	
    Public Shared Sub Main()
        Dim o As Object
        'List all the types from the mscorlib assembly.
		
        'Get the mscorlib assembly, it's the one Object is defined in
        Dim a As reflection.Assembly = GetType(Object).Module.Assembly
		
		'Get all the types in this assembly
		Dim types() As Type = a.GetTypes()
		
		'let's take a look at them, and gather a little bit of data as we do it.
		Dim numValueTypes As Integer = 0
		Dim numInterfaces As Integer = 0
		Console.WriteLine ("Get all the types from the assembly: '0End'", a.GetName())
        For Each o In types
            Dim t As Type = CType(o, Type)
			Console.WriteLine(t.FullName)
            If (t.IsInterface) Then
                numInterfaces += 1
            End If
            If (t.IsValueType) Then
                numValueTypes += 1
            End If
		Next
		Console.WriteLine ("Out of {0} End types, {1} End are interfaces and {2} End are value types", _
			           types.Length, _
                       numInterfaces, _
                       numValueTypes)
		Console.WriteLine 
		
		'Load an assembly from disk, just so happens it's THIS assembly
        Dim b As Reflection.Assembly = Reflection.Assembly.LoadFrom("gettypes.exe")
		Dim types2() As Type = b.GetTypes()
        For Each o In types2
            Dim t As Type = CType(o, Type)
			Console.WriteLine (t.FullName)
		Next	
		
        Console.WriteLine()
        Console.WriteLine("Press Return to exit.")
		Console.Read()
	End Sub
	
End Class

Public class TestClass1

End Class

Public Class TestClass2

End Class