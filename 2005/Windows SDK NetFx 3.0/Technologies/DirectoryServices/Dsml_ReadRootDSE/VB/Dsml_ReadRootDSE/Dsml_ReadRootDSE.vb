' ===================================
'   File:      ReadRootDSE.vb
'  
'   Summary:   Reads the RootDSE Object and prints its attributes
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
' ===================================*/


 
' To compile: vbc.exe /out:App.exe /r:System.DirectoryServices.Protocols.dll 
'                                                           ReadRootDSE.vb
' To run: App.exe <dsmlServer>
'     Eg: App.exe http://myDC1.testDom.fabrikam.com/dsml/adssoap.dsmlx

Option Strict On
Option Explicit On

Imports System
Imports System.Net
Imports System.Security.Permissions
Imports SDS = System.DirectoryServices

Imports System.DirectoryServices.Protocols

<Assembly: System.Reflection.AssemblyVersion("1.0.0.0")>
<Assembly: SecurityPermission(SecurityAction.RequestMinimum,Execution := true)>
<Assembly: SDS.DirectoryServicesPermission(SecurityAction.RequestMinimum)>

Namespace Microsoft.Samples.DirectoryServices



Public NotInheritable Class App
   ' static variables used throughout the sample code
   Private Shared dsmlConnection As DsmlSoapHttpConnection

   ' this DSML server's VDIR should be configured to accept 
   ' anonymous connections for this sample to work
   Private Shared dsmlServer As String

   Private Sub New()
   End Sub
   
   Public Shared Sub Main(args() As String)
      Try
         if Not GetParameters(args) Then
            Return
         End If
         
         CreateConnection()
         ReadRootDSE()         
         Console.WriteLine(vbCrLf + "Application Finished Successfully!!!")
      Catch e As Exception
         Console.WriteLine(vbCrLf + "Unexpected exception occured:" + _
                           vbCrLf + vbTab + e.GetType().Name + ":" + e.Message)
      End Try
   End Sub 'Main
   
   
   
   
   Shared Function GetParameters(args() As String) As Boolean
      If args.Length <> 1 Then
         Console.WriteLine("Usage: App.exe <dsmlServer>")
         Return false
      End If
      
      ' initialize variables
      dsmlServer = args(0)
      Return true
   End Function 'GetParameters
   
   
   
   
   Shared Sub CreateConnection()
      dsmlConnection = New DsmlSoapHttpConnection(New Uri(dsmlServer))
      Console.WriteLine("DsmlSoapHttpConnection is created successfully.")
   End Sub 'CreateConnection
   
   
   
   
   Shared Sub ReadRootDSE()
      Dim baseDN As String = Nothing ' specify base as null for RootDSE search
      Dim ldapSearchFilter As String = "(objectClass=*)"

      ' return ALL attributes that have some value
      Dim attributesToReturn As String() = Nothing
      
      ' create a search request: specify baseDn, ldap search filter, 
      ' attributes to return and scope of the search
      ' SearchScope should be Base for a RootDSE search
      Dim searchRequest As New SearchRequest(baseDN, _
                                             ldapSearchFilter, _
                                             SearchScope.Base, _
                                             attributesToReturn)
      
      
      ' send the request through the connection
      Dim searchResponse As SearchResponse = _
                              CType(dsmlConnection.SendRequest(searchRequest), _
                                    SearchResponse)
      
      ' print the returned entries & their attributes
      Console.WriteLine(vbCrLf + "Search matched " + _
                          searchResponse.Entries.Count.ToString() + " entries:")

      Dim entry As SearchResultEntry
      For Each entry In  searchResponse.Entries
         ' retrieve a specific attribute
         Dim attribute As DirectoryAttribute = _
                                        entry.Attributes("schemaNamingContext")

         ' get the first value since "schemaNamingContext" 
         ' is a single valued attribute
         Console.WriteLine(attribute.Name + "=" + attribute(0).ToString()) 

         ' retrieve all attributes
         Dim attr As DirectoryAttribute
         For Each attr In  entry.Attributes.Values
            Console.Write(attr.Name + "=")
            
            ' retrieve all values for the attribute
            ' the type of the value can be one of string,byte[] or Uri
            Dim value As Object
            For Each value In  attr
               Console.Write(value.ToString() + "  ")
            Next value
            Console.WriteLine()
         Next attr
      Next entry
      
      Console.WriteLine("RootDSE Search is completed successfully." + vbCrLf)
   End Sub 'ReadRootDSE
End Class 'App


End Namespace
