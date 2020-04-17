' ===================================
'   File:      BerEncoding.vb
'  
'   Summary:   Demonstrates BerConverter class usage to do ber encoding/decoding.
'  
' ---------------------------------------------------------------------
'   This file is part of the Microsoft .NET SDK Code Samples.
'  
'   Copyright (C) Microsoft Corporation.  All rights reserved.
'  
' This source code is intended only as a supplement to Microsoft
' Development Tools and/or on-line documentation.  See these other
' materials for detailed information regarding Microsoft code samples.
'  
' THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
' KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
' IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
' PARTICULAR PURPOSE.
' ===================================


 
' To compile: vbc.exe /out:App.exe /r:System.DirectoryServices.Protocols.dll 
'                                                             BerEncoding.vb
' To run: App.exe

Option Strict On
Option Explicit On

Imports System
Imports System.Security.Permissions

Imports System.DirectoryServices.Protocols

<Assembly: System.Reflection.AssemblyVersion("1.0.0.0")>
<Assembly: SecurityPermission(SecurityAction.RequestMinimum,Execution := true)>

Namespace Microsoft.Samples.DirectoryServices

Public NotInheritable Class App

    Private Sub New()        
    End Sub
   
   Public Shared Sub Main()
      Try
         DoBerEncoding()         
         Console.WriteLine(vbCrLf + "Application Finished Successfully!!!")
      Catch e As Exception
         Console.WriteLine(vbCrLf + "Unexpected exception occured:" + _
                           vbCrLf + vbTab + e.GetType().Name + ":" + e.Message)
      End Try
      
   End Sub 'Main
   
   
   Shared Sub DoBerEncoding()
      Try
         Dim boolValue As Boolean = True
         Dim intValue As Integer = 5
         Dim binaryValue() As Byte = {&H0, &H1, &H2, &H3}
         Dim strValue As String = "abcdef"
         Dim strValues As String() =  {"abc", "def", "xyzw"}
         Dim binaryValues()() As Byte = {New Byte() {&H0, &H1, &H2, &H3}, _
                                         New Byte() {&H4, &H5, &H6, &H7}, _
                                         New Byte() {&H8, &H9, &HA}, _
                                         New Byte() {&HB, &HC}}
         
         Console.WriteLine(vbCrLf + "Ber encoding objects...")
         Dim berEncodedValue As Byte() = _
                                    BerConverter.Encode("{bios{v}{V}}", _
                                                         New Object(){ _
                                                                boolValue, _
                                                                intValue, _
                                                                binaryValue, _
                                                                strValue, _
                                                                strValues, _
                                                                binaryValues _
                                                                })
         
         Console.WriteLine(vbCrLf + "Ber decoding the byte array...")
         Dim decodedObjects As Object() = BerConverter.Decode("{biOavV}", _
                                                              berEncodedValue)

         Console.WriteLine(vbCrLf + "The decoded objects are:")
         Dim o As Object
         For Each o In  decodedObjects
            Console.WriteLine(o.ToString())
         Next o
      Catch e As BerConversionException
         Console.WriteLine("BerConversionException:" + e.Message)
      Catch e As ArgumentException
         Console.WriteLine("ArgumentException:" + e.Message)
      End Try
   End Sub 'DoBerEncoding
End Class 'App


End Namespace
