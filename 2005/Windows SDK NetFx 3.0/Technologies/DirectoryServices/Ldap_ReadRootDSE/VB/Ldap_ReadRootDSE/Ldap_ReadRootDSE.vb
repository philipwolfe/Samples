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
' ===================================

' To compile: vbc.exe /out:App.exe /r:System.DirectoryServices.Protocols.dll 
'                                                               ReadRootDSE.vb
'
' To run: App.exe <ldapServer>
'       Eg: App.exe myDC1.testDom.fabrikam.com

Option Strict On
Option Explicit On

Imports System
Imports System.Text
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
    Shared ldapConnection As LdapConnection
    Shared ldapServer As String

    Private Sub New()
    End Sub
 
    Public Shared  Sub Main(ByVal args() As String)
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
    End Sub
 
 
 
   Shared Function GetParameters(args() As String) As Boolean
        If args.Length <> 1 Then
            Console.WriteLine("Usage: App.exe <ldapServer>")
            Return false
        End If
 
        ' initialize variables
        ldapServer = args(0)

        Return true
   End Function 'GetParameters
 
 
 
    Shared  Sub CreateConnection()
        ldapConnection = New LdapConnection(ldapServer)
        ldapConnection.AutoBind = False
        Console.WriteLine("LdapConnection is created successfully.")
    End Sub
 
 
 
    Shared  Sub ReadRootDSE()
        Dim baseDN As String =  Nothing  ' specify base as null for RootDSE search
        Dim ldapSearchFilter As String =  "(objectClass=*)" 

        ' return ALL attributes that have some value
        Dim attributesToReturn() As String =  Nothing 
 
        ' create a search request: specify baseDn, ldap search filter, 
        ' attributes to return and scope of the search
        
        ' SearchScope should be Base for a RootDSE search
        Dim searchRequest As SearchRequest = New SearchRequest( _
                                                            baseDN, _
                                                            ldapSearchFilter, _
                                                            SearchScope.Base, _
                                                            attributesToReturn) 
 
 
        ' send the request through the connection
        Dim searchResponse As SearchResponse = _
                              CType(ldapConnection.SendRequest(searchRequest), _
                                                                SearchResponse)
 
        ' print the returned entries & their attributes
		PrintSearchResponse(searchResponse)
 
        Console.WriteLine("RootDSE Search is completed successfully." + vbCrLf)
    End Sub


    Shared  Sub PrintSearchResponse(ByRef searchResponse As SearchResponse)
        Dim utf8 As UTF8Encoding = New UTF8Encoding(false, true)

        ' print the returned entries & their attributes
        Console.WriteLine(vbCrLf + "Search matched " + _
                          searchResponse.Entries.Count.ToString() + " entries:")

        Dim i as Int32=0
        Dim entry As SearchResultEntry

        For Each entry In searchResponse.Entries
        	Console.WriteLine((++i) & "- "  & entry.DistinguishedName)
            ' retrieve all attributes
            Dim attr As DirectoryAttribute
            For Each attr in entry.Attributes.Values
                Console.Write(attr.Name & "=" )

                ' retrieve all values for the attribute
                ' LdapConnection returns everything as 
                ' byte[] just as in LDAP C API
                Dim value As byte()
                For Each value in attr                
                    ' first check to see if it is a valid UTF8 string
                    Try
                        Console.Write(utf8.GetString(value) + "  ")
                    ' it is not a valid UTF8 string, 
                    ' just print raw bytes as hex
                    Catch e As ArgumentException 
                        Console.Write(ByteArrayToHexString(value) & "  ")
                    End Try
                Next
                Console.WriteLine()
            Next
        Next
    
    End Sub

    Shared  Function ByteArrayToHexString(ByVal bytes as byte()) As String
        If bytes is Nothing Then 
        	ByteArrayToHexString = ""
        	Exit Function
        End If
        
        Dim s As StringBuilder = New StringBuilder(CType(bytes.Length/2,Int32))
        s.Append("0x")
        Dim b As byte
        For Each b in bytes
            s.Append(String.Format("{0:X2}",b))
		Next
        ByteArrayToHexString = s.ToString()
    End Function
          
 
End Class
' end class App

End Namespace
