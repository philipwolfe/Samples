'==========================================================================
'  File:      Factorial.vb
'
'  Summary:   Computes the factorial of a number (the Value method should be
'             the entry point).  This class is present to provide a class
'             to test with the Reflector sample.
' 
'  Classes:   Factorial
'
'  Functions: Value, calc
'
'----------------------------------------------------------------------------
'  This file is part of the Microsoft COM+ 2.0 SDK Samples
'
'  Copyright (C) 1998-1999 Microsoft Corporation.  All rights reserved.
'==========================================================================+*/

Imports System
Option Explicit

Class Factorial

'*****************************************************************************
' Function :    Value
'
' Abstract:     Computes the Factorial of the input (printing information to 
'               standard output.
'			
' Input Parameters: i (the number to compute the factorial of)
'
' Returns: int
'******************************************************************************/
	Public Function Value(i As Integer) As Integer
		Console.Write("Factorial::Value:")
		Console.WriteLine(i)
		Dim ret As Integer = calc(i)
		Console.Write("Factorial::Value returning:")
		Console.WriteLine(ret)
		Value = ret
	End Function

'*****************************************************************************
' Function :    calc
'
' Abstract:     Computes the Factorial of the input.
'			
' Input Parameters: i (the number to compute the factorial of)
'
' Returns: int
'******************************************************************************/
	Public Function calc(i As Integer) As Integer
		If i <= 1 Then 
			calc = 1
		Else
			calc = i * calc(i-1)
		End If
	End Function
End Class

