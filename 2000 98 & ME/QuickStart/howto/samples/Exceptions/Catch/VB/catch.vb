Imports System

Public Class ExceptionTest

	Public Shared Sub Main()
	
		'This code shows how to catch an exception
		Try 
		
			Console.WriteLine("We're going to divide 10 by 0 and see what happens...")
			Console.WriteLine()
			Dim i as Integer 
			i = 10
			Dim j As Integer 
			j = 0
			Dim k As Double 
			k = i\j
		
		Catch e As Exception
		
			Console.WriteLine("The following error occured:")
			Console.WriteLine(e.ToString())
		
		Finally 
		
			Console.WriteLine()
			Console.WriteLine("Now we can continue")
		End Try

		Console.WriteLine()
		Console.WriteLine ("Press Return to exit.")
		Console.Read()
	End Sub ' end Main


End Class 'end class ExceptionTest
