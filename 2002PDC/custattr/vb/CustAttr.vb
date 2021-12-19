'=====================================================================
'  File:      CustAttr.vb
'
'  Summary:   Demonstrates how to create and use custom attributes.
'
'---------------------------------------------------------------------
'  This file is part of the Microsoft COM+ 2.0 SDK Code Samples.
'
'  Copyright (C) 2000 Microsoft Corporation.  All rights reserved.
'
'This source code is intended only as a supplement to Microsoft
'Development Tools and/or on-line documentation.  See these other
'materials for detailed information regarding Microsoft code samples.
'
'THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
'KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
'IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
'PARTICULAR PURPOSE.
'=====================================================================*/


Imports System
Imports System.Reflection


Namespace Microsoft.Sample.CustAttr.VB

    'VB Defines call attributes in the the class declaration statement.
    'It is the statement enclosed in <>
    Public Class <AttributeUsageAttribute(AttributeTargets.Class BitOr AttributeTargets.ClassMembers)> MyAttribute
        Inherits System.Attribute

        Public y As Integer 'This is a public attribute
        Public s As String 'This is a public attribute
        Public x As Integer 'This is a public attribute

        Public Sub New(ByVal s As String, ByVal x As Integer, Optional ByVal y As Integer = 111)
            MyBase.New()

            Me.s = s
            Me.x = x
        End Sub
            
        Shared Sub DisplayAttrInfo(ByVal n As Integer, ByVal a As Attribute)

            If TypeOf (a) Is MyAttribute Then
                ' Refer to the one of the custom attributes
                Dim myAttribute As MyAttribute = CType(a, MyAttribute)

                Console.WriteLine("{0}-""{1}"": {2}", n, a, "X: " + myAttribute.x.ToString() + ", Y: " + myAttribute.y.ToString() + ", S: " + myAttribute.s)
            Else
                Console.WriteLine("{0}-""{1}""", n, a)

            End If
        End Sub
    End Class

    Class <MyAttribute("AttribOnType", 111, 333), Obsolete("Ignore this warning -- just testing the Obsolete attribute ")> SampAttrApp
        ' Apply our attribute to the constructor. the optional parameter is NOT used.
        ' NOTE: For convenience, URT allows "Attribute" to be omitted from "MyAttribute"
        Sub  <My("AttribOnMethod", 333)> New()
            MyBase.New()

            Console.WriteLine("In Application constructor")
        End Sub

        Shared Sub Main()

            ' Get the set of custom attributes associated with the type
            Dim TypeAttrs() As Object = GetType(SampAttrApp).GetCustomAttributes()

            Console.WriteLine("Number of custom attributes on Application type: " & TypeAttrs.Length)
            Dim n As Integer
        
            For n = 0 To TypeAttrs.Length - 1
                MyAttribute.DisplayAttrInfo(n, CType(TypeAttrs(n), Attribute))
            Next n

            Console.WriteLine()

            ' Get the set of methods associated with the type
            Dim mi() As MemberInfo = GetType(SampAttrApp).FindMembers(MemberTypes.Constructor BitOr MemberTypes.Method, BindingFlags.LookupAll BitOr BindingFlags.DeclaredOnly, Type.FilterName, "*")
            Console.WriteLine("Number of methods (including constructors): " & mi.Length)

            Dim x As Integer
            For x = 0 To mi.Length - 1
                ' Get the set of custom attributes associated with this method
                Dim MethodAttrs() As Object = mi(x).GetCustomAttributes()

                Console.WriteLine("Method name: " & mi(x).Name & Chr$(9) & "(" & MethodAttrs.Length & " attributes)")

                For n = 0 To MethodAttrs.Length - 1
                    Console.Write("   ")
                    MyAttribute.DisplayAttrInfo(n, CType(MethodAttrs(n), Attribute))
                Next n

            Next x
        End Sub

    End Class


End Namespace

