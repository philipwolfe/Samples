'/*=====================================================================
'  File:      ValueEnum.vb

'  Summary:   Demonstrates things you can do with ValueType/Enum types.

'---------------------------------------------------------------------
'  This file is part of the Microsoft COM+ 2.0 SDK Code Samples.

'  Copyright (C) 2000 Microsoft Corporation.  All rights reserved.

'This source code is intended only as a supplement to Microsoft
'Development Tools and/or on-line documentation.  See these other
'materials for detailed information regarding Microsoft code samples.

'THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
'KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
'IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
'PARTICULAR PURPOSE.
'=====================================================================*/

' Add the classes in the following namespaces to our namespace
Imports System
Imports System.ValueType
Imports System.Enum
Imports System.Object

Public Module modMain
    'This is a value type because of "structure"
    Structure Point
        Dim x, y As Integer
                
        Sub New(ByVal x As Integer, ByVal y As Integer)
            MyBase.New()
            Me.x = x
            Me.y = y
        End Sub

        'TODO : Implement this function once the bug is resolved
        '       Currently we cannot override any of the Value Class Methods
        'Overrides Public Function ToString() As String  
        '  ToString = "(" & x & "," & y & ")"
        'End Function
        
    End Structure

    Private Sub DemoValueTypes()
        Console.WriteLine("Demo start: Demo of value types.")

        Dim p1 = New Point(5, 10)
        Dim p2 = New Point(5, 10)
        Dim p3 = New Point(3, 4)

        ' What type is this valuetype & what is it derived from
        Console.WriteLine("   The " & (p1.GetType().ToString) & " type is derived from " & (p1.GetType().BaseType.ToString))

        ' Value types compare for equality by comparing the fields
        Console.WriteLine("   Does p1 equal p1: " & p1.Equals(p1)) ' True
        Console.WriteLine("   Does p1 equal p2: " & p1.Equals(p2)) ' True
        Console.WriteLine("   Does p1 equal p3: " & p1.Equals(p3)) ' False

        'this line is not working because ToString is not getting the values
        Console.WriteLine("   p1=" & p1.ToString() & ", p3=" & p3.ToString())

        Console.WriteLine("Demo stop: Demo of value types.")

    End Sub

    ' This is an enumerated type because of 'enum'
    Enum Color
        Red = 111
        Green = 222
        Blue = 333
    End Enum

    Private Sub DemoEnums()
        
        Console.WriteLine()
        Console.Writeline()
        Console.WriteLine("Demo start: Demo of enumerated types.")
        Dim c = CType(Color.Red, Color)

        ' What type is this enum & what is it derived from
        Console.WriteLine("   The " + c.GetType().ToString + " type is derived from " + c.GetType().BaseType.ToString)

        ' What is the underlying type used for the Enum's value
        Console.WriteLine("   Underlying type: " + GetUnderlyingType(c.GetType()).ToString)

        ' Display the set of legal enum values
        Dim o() = GetValues(c.GetType())
        Console.WriteLine()
        Console.WriteLine("   Number of valid enum values: " & o.length)
        
        Dim x As Integer
        For x = 0 To (o.Length - 1)
            Dim cc = CType(o(x), Color)
            Console.WriteLine("   " & x & ": Name=" & chr(9) & Format(GetType(Color), cc, "g") & Chr(9) & "     Number=" & cc.ToString())
        Next
       
        ' Check if a value is legal for this enum
        Console.WriteLine()
        Console.WriteLine("   111 is a valid enum value: " & IsDefined(c.GetType(), 111)) ' True
        Console.WriteLine("   112 is a valid enum value: " & IsDefined(c.GetType(), 112)) ' False

        ' Check if two enums are equal
        console.WriteLine()
        Console.WriteLine("   Is c equal to Red: " & (c.Equals(Color.Red))) ' True
        Console.WriteLine("   Is c equal to Blue: " & (c.Equals(Color.Blue))) ' False

        ' Display the enum's value as a string
        console.WriteLine()
        Console.WriteLine("   c's value as a string: " & Format(GetType(Color), c, "g")) ' Red
        Console.WriteLine("   c's value as a number: " & c.ToString()) ' 111

        ' Convert a string to an enum's value
        c = CType(FromString(GetType(Color), "Blue"), color)
        Try
            c = CType(FromString(GetType(Color), "NotAColor"), Color) ' Not valid, raises exception        
        Catch 
            Console.WriteLine("   'NotAColor' is not a valid value for this enum.")
        End Try

        ' Display the enum's value as a string
        console.WriteLine()
        Console.WriteLine("   c's value as a string: " + Format(GetType(Color), c, "g")) ' Blue
        Console.WriteLine("   c's value as a number: " + c.ToString()) ' 333

        Console.WriteLine("Demo stop: Demo of enumerated types.")
    End Sub

    
    Enum <Flags()> ActionAttributes
        Read = 1
        Write = 2
        Delete = 4
        Query = 8
        Sync = 16
    End Enum

    Private Sub DemoFlags()
        Console.WriteLine()
        Console.WriteLine()
        Console.WriteLine("Demo start: Demo of enumerated flags types.")
        
        Dim aa = CType((ActionAttributes.Read BitOr ActionAttributes.Write BitOr ActionAttributes.Query), ActionAttributes)
       
        ' What type is this enum & what is it derived from
        Console.WriteLine("   The " & aa.GetType.ToString & " type is derived from " & aa.GetType.BaseType.ToString)

        ' What is the underlying type used for the Enum's value
        Console.WriteLine("   Underlying type: " & GetUnderlyingType(aa.GetType()).ToString)

        ' Display the set of legal enum values
        Dim o() = GetValues(aa.GetType())
        Console.WriteLine()
        Console.WriteLine("   Number of valid enum values: " & o.Length)

        Dim x As Integer
        For x = 0 To (o.Length - 1)
            Dim aax = CType(o(x), ActionAttributes)
            Console.WriteLine("   " & x & ": Name=" & Chr(9) & Format(GetType(ActionAttributes), aax, "g") & chr(9) & chr(9) & "Number=" & aax.ToString)
        Next

        ' Check if a value is legal for this enum
        Console.WriteLine()
        Console.WriteLine("   8 is a valid enum value: " & IsDefined(aa.GetType(), 8)) ' True
        Console.WriteLine("   6 is a valid enum value: " & IsDefined(aa.GetType(), 6)) ' False

        ' Display the enum's value as a string
        Console.WriteLine()
        Console.WriteLine("   aa's value as a string: " & Format(GetType(ActionAttributes), aa, "g")) ' Read|Write|Query
        Console.WriteLine("   aa's value as a number: " & aa.ToString()) ' 11

        ' Convert a string to an enum's value
        aa = CType(FromString(GetType(ActionAttributes), "Write"), ActionAttributes)
        aa = aa BitOr CType(FromString(GetType(ActionAttributes), "Sync"), ActionAttributes)
        console.WriteLine()
        Console.WriteLine("   aa's value as a string: " & Format(GetType(ActionAttributes), aa, "g")) ' Write|Sync
        Console.WriteLine("   aa's value as a number: " & aa.ToString()) ' 18

        Console.WriteLine("Demo stop: Demo of enumerated flags types.")
    End Sub

    Class Rectangle
        Dim x, y, width, height As Integer

        Sub New(ByRef x As Integer, ByRef y As Integer, ByRef width As Integer, ByRef height As Integer)
            MyBase.New()
            Me.x = x
            Me.y = y
            Me.width = width
            Me.height = height
        End Sub

        Overrides Public Function ToString() As String
            ToString = "(" & x & "," & y & ")x(" & width & "," & height & ")"
        End Function

        Overrides Public Function Equals(ByVal o As Object) As Boolean
            ' Change the symantics of this reference type so that it is
            ' equal to the same type of object if the fields are equal.
            Console.WriteLine("   In Rectangle.Equals method")
            Dim r As Rectangle = CType(o, Rectangle)
            
            If (r.x = x And r.y = y And r.width = width And r.height = height) Then
                Equals = True
            Else
                Equals = False
            End If

        End Function

    End Class

    Private Sub DemoReferenceTypes()
        
        console.WriteLine()
        console.WriteLine()
        Console.WriteLine("Demo start: Demo of reference types.")
        Dim r = New Rectangle(1, 2, 3, 4)
  
        ' What type is this reference type & what is it derived from
        Console.WriteLine("   The " & r.GetType().ToString & " type is derived from " & r.GetType().BaseType.ToString)
        Console.WriteLine("   " & r.ToString)
        
        ' Reference types are equal if they refer to the same object
        Console.WriteLine("   Is r equal to (1, 2, 3, 4): " & (r Is New Rectangle(1, 2, 3, 4))) ' False
        Console.WriteLine("   Is r equal to (1, 2, 3, 4): " & (r.Equals(New Rectangle(1, 2, 3, 4)))) ' True
        Console.WriteLine("   Is r equal to (1, 1, 1, 1): " & (r Is New Rectangle(1, 1, 1, 1))) ' False
        Console.WriteLine("   Is r equal to (1, 1, 1, 1): " & (r.Equals(New Rectangle(1, 1, 1, 1)))) ' False

        Console.WriteLine("Demo stop: Demo of reference types.")
    End Sub

    ' "Main" is application's entry point
    Sub Main()
        DemoValueTypes()
        DemoEnums()
        DemoFlags()
        DemoReferenceTypes()
    End Sub
End Module

'End of File