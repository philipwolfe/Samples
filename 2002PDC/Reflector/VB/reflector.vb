'==========================================================================
'  File:      reflector.vb
'
'  Summary:   The purpose of this demo is to introduce COM+ reflection. 
'             Reflection is a feature in COM+ that allow object inspection 
'             and dynamic invocation. The reflector program uses the COM+ 
'             reflection to inspect the methods and properties of the class 
'             named on the command line at runtime. You can also invoke the 
'             classes methods at runtime by using the command line switches.
' 
'  Classes:   Reflector
'
'  Functions: Run, DumpClass, DumpMethods, Usage, main
'
'----------------------------------------------------------------------------
'  This file is part of the Microsoft COM+ 2.0 SDK Samples
'
'  Copyright (C) 1998-1999 Microsoft Corporation.  All rights reserved.
'==========================================================================+*/
Imports System
Imports System.Reflection
Imports System.Text

Imports Microsoft.VisualBasic.ControlChars

Option Explicit
Option Strict Off

Module ModMain

Class Reflector

	Public Shared strLoc As String = "000oo"

	Public methods, verbose, implOnly, invoke As Boolean
	Public className, methName, callArgs As String


'*****************************************************************************
' Function :    Run
'
' Abstract:     Dumps the class name and its methods stored in "className".
'			
' Input Parameters: None
'
' Returns: int (1==error, 0==OK)
'******************************************************************************/
	Public Function Run As Integer
		if className = Nothing Then
			Run = 1
			Exit Function
		End If

		Try 
			DumpClass
		
		Catch e As Exception
			Console.WriteLine("Exception: ({0})" & CrLf & " {1}" & CrLf,strLoc, e.StackTrace)
			Run = 1
			Exit Function
		End try

		Run = 0
	End Function

'*****************************************************************************
' Function :    DumpClass
'
' Abstract:     Dumps the class "className" and its methods.
'			
' Input Parameters: None
'
' Returns: Void
'******************************************************************************/
	Public Sub DumpClass
		Dim t As Type = Type.GetType(className & "," & className & ".Dll")
		if (t = Nothing) Then
			Console.WriteLine("ERROR: Class '{0}' not found" & CrLf, className)
			Exit Sub
		End If
		Console.WriteLine("Class: {0}" & CrLf,t.FullName)
		if (methods) Then DumpMethods(t)
	End Sub

'*****************************************************************************
' Function :    DumpMethods
'
' Abstract:     Dumps the class "className" and its methods.  If the bool 
'               invoke is true, then the method name "methName" is invoked
'               with the arguments "callArgs".
'			
' Input Parameters: c (Microsoft::Runtime::Class in which to dump methods)
'
' Returns: Void
'******************************************************************************/
	Public Sub DumpMethods(t As Type)
		' int in4a = -2
		strLoc = "DM_23n"
		Dim memi2() As MemberInfo = Nothing
		
		If (methName = Nothing) Then
			' t.GetMethods() returns MethodInfo()
			memi2 = t.GetMethods
		Else
			memi2 = t.FindMembers(MemberTypes.Method ,  BindingFlags.NonPublic, _ 
					Type.FilterName, methName) ' returns MemberInfo()
		End If
	
		Console.WriteLine("Methods ({0})" & CrLf,memi2.Length)

		strLoc = "DM_66n"

		If (verbose) Then
			Dim i As Integer
			For i=0 To memi2.Length-1
				Console.WriteLine(Tab & "{0}" & CrLf,memi2(i))
			Next
		End If

		strLoc = "DM_57x"

		If (invoke AND (memi2.Length = 1)) Then

			Dim o As Object = Activator.CreateInstance(t)
			Console.WriteLine("Invoking method '{0}' on class '{1}'" & CrLf, _
					memi2(0).Name, t.FullName)

			Dim varRet As Object = Nothing
			Dim var2() As Object = Nothing
			
			If (callArgs <> Nothing) Then
				'Dim str() As String = callArgs.Split( new char() {' '} )
				Dim str() As String = callArgs.Split( " " )
				'var2 = new Object(str.Length)
				var2 = new Object
				ReDim var2(str.Length)

				Dim a As String = ""
				if (str.Length <> 1) Then a = "s"

				Console.WriteLine("With {0} argument{1}:" & CrLf,str.Length,a)

				Dim ii As Integer
				For ii = 0  To str.Length-1
					Console.WriteLine(Tab & "Argument {0}: '{1}'" & CrLf,(ii+1),str(ii))

					var2(ii) = Convert.ToInt32(str(ii))
				Next					
			Else 
				Console.WriteLine("With no arguments" & CrLf)
			End If
				
			strLoc = "DM_08u"

			Try	
				Dim tmpMethodInfo As MethodInfo = memi2(0)
				varRet = tmpMethodInfo.Invoke(o,var2)
			
			Catch e As Exception
				Console.WriteLine("Invoke Exception: ({0}) {1}" & CrLf, strLoc, e)
			End Try

			strLoc = "DM_48k"
			Dim vt As Type = varRet.GetType
			Console.WriteLine("Invocation Results: ({0}) ", vt.FullName)

			strLoc = "DM_92c"
			Console.WriteLine("{0}" & CrLf,varRet.ToString())

			strLoc = "DM_61a"
		End If
	End Sub


'*****************************************************************************
' Function :    Usage
'
' Abstract:     Prints usage for reflector application.
'			
' Input Parameters: None
'
' Returns: Void
'******************************************************************************/
Public Sub Usage
	Console.WriteLine("Usage: Reflector [options] class" & CrLf & CrLf)
	Console.WriteLine("Options:" & CrLf)
	Console.WriteLine("   -V" & Tab & "Verbose" & CrLf)
	Console.WriteLine("   -M<opt>" & Tab & "Methods <=name>" & CrLf)
	Console.WriteLine("   -I<opt>" & Tab & "Invoke <='args'>" & CrLf)
	Console.WriteLine("   -?" & Tab & "Help" & CrLf)
End Sub

End Class


'*****************************************************************************
' Function :    main
'
' Abstract:     Entry point to the application.  Parses command line options
'               and instantiates the Reflector class and calls Run().
'			
' Input Parameters: argc (number of arguments, including the program name)
'                   argv (array of ansi strings containing the arguments)
'
' Returns: Void
'******************************************************************************/
Public Shared Sub Main
	Dim r As new Reflector
	Dim do_usage As Boolean = false
	Dim args() As String = Environment.GetCommandLineArgs()	

	Try	
		If (args.Length < 2) Then
			r.Usage
			Environment.ExitCode = 1
			Exit Sub
		End If

		Dim i As Integer
		For i=1 to args.Length - 1
			Dim len As Integer = args(i).Length
			If ( args(i).StartsWith("/") OR args(i).StartsWith("-") ) Then

				Select Case args(i).SubString(1,1).ToUpper
				case "?"
					do_usage = true
				case "M"
					r.methods = true
					if (len > 2) Then r.methName = args(i).SubString(2)
				case "I"
					r.invoke = true
					if (len > 2) Then r.callArgs = args(i).SubString(2)
				case "V"
					r.verbose = true
				case Else 
					Console.WriteLine("Invalid Option" & CrLf & CrLf)
					do_usage = true
				End Select
			Else
				r.className = args(i)
			End If
			
			if (do_usage) Then Exit For
		Next

		if (do_usage OR r.className = Nothing) Then
			r.Usage()
			Environment.ExitCode = 1
			Exit Sub
		End If

		Environment.ExitCode = r.Run
		Exit Sub

	Catch exc_main As Exception

		Console.WriteLine("Error Err_012ab, exc caught in main, " & _
						  "strLoc=={0}, exc_main=={1}" & CrLf,Reflector.strLoc,exc_main)
	End Try
	Environment.ExitCode = 1
End Sub

End Module
