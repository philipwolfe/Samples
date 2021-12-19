Imports System

Public Class Throws

	Public Shared Function  SeeIfIntIsOne(i as Integer) As String
	
		Dim s As String 
		s = "You passed in 1"
		If i = 1
		   return s
		
		Else Throw New ArgumentException("Your integer was not 1")
		' it should be noted that this exception does not utilize the Runtime's resource
		' system which would make the text of the exception easily localizable.
		' For examples of using resources, see the Resources section of Quickstart.
		End If
	End Function

	Public Shared Sub Main ()
	
		'this code shows how to catch an exception
		Try 
		
			Console.WriteLine("We're going to call our mehod with two args, one valid and one invalid")
			Console.WriteLine()
			Console.WriteLine("Trying to call the method wih an argument of 1")
			Console.WriteLine(SeeIfIntIsOne(1))
			Console.WriteLine()
			Console.WriteLine("Trying to call the method with an argument of 2")
			Console.WriteLine(SeeIfIntIsOne(2))	
		
		Catch e As Exception 
		
			Console.WriteLine("The following error occured:")
			Console.WriteLine(e.ToString())
		
		Finally 
		
			Console.WriteLine()
			Console.WriteLine("Now we can Continue")
		End Try

		Console.WriteLine ()
		Console.WriteLine ("Press Return to exit.")
		Console.Read()
	End Sub ' end Main

End Class 'Throws
