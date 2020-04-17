' ===================================
'   File:      PagedSearch.vb
'  
'   Summary:   Demonstrates doing a paged search Imports Ldap controls.
'  
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
'                                                               PagedSearch.vb
'
' To run: App.exe <ldapServer> <user> <pwd> <domain> <targetOU>
'     Eg: App.exe myDC1.testDom.fabrikam.com  user1  secret@~1 
'                   testDom OU=samples,DC=testDom,DC=fabrikam,DC=com

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
   Private Shared ldapConnection As LdapConnection
   Private Shared ldapServer As String
   Private Shared credential As NetworkCredential
   Private Shared targetOU As String 'dn of an OU. eg: "OU=sample,DC=fabrikam,DC=com"

   ' change the below numbers to try for 
   ' different page sizes and number of pages

   ' the max number of entries we want in each SearchResponse
   Private Shared pageSize As Integer = 5 
   Private Shared numberOfPages As Integer = 8
   
   Private Sub New()
   End Sub   
   
   Public Shared Sub Main(args() As String)
      Try
         if Not GetParameters(args) Then
            Return
         End If

         CreateConnection()
         CreateObjectsToSearch()
         DoPagedSearch()
         DeleteObjectsToSearch()
         
         Console.WriteLine(vbCrLf + "Application Finished Successfully!!!")
      Catch e As Exception
         Console.WriteLine(vbCrLf + "Unexpected exception occured:" + _
                           vbCrLf + vbTab + e.GetType().Name + ":" + e.Message)
      End Try
   End Sub 'Main
   
   
   
   
   Shared Function GetParameters(args() As String) As Boolean
      If args.Length <> 5 Then
         Console.WriteLine("Usage: App.exe <ldapServer> <user> <pwd> " + _
                                                        "<domain> <targetOU>")
         Return false
      End If
      
      ' initialize variables
      ldapServer = args(0)
      credential = New NetworkCredential(args(1), args(2), args(3))
      targetOU = args(4)

      Return true
   End Function 'GetParameters
   
   
   
   
   Shared Sub CreateConnection()
      ldapConnection = New LdapConnection(ldapServer)
      ldapConnection.Credential = credential
      Console.WriteLine("LdapConnection is created successfully.")
   End Sub 'CreateConnection
   
   
   
   Shared Sub CreateObjectsToSearch()
      Dim i As Integer
      For i = 1 To numberOfPages * pageSize
         Dim dn As String = "OU=object" + i.ToString() + "," + targetOU
         ldapConnection.SendRequest(New AddRequest(dn, "organizationalUnit"))
         Console.WriteLine("OU=object" + i.ToString()+ " created successfully.")
      Next i
   End Sub 'CreateObjectsToSearch
   
   
   
   
   Shared Sub DoPagedSearch()
      Console.WriteLine(vbCrLf + "Doing a paged search ...")
      
      Dim ldapSearchFilter As String = _
                               "(&(objectClass=organizationalUnit)(ou=object*))"

      ' return only these attributes
      Dim attributesToReturn() As String = {"description", "ou", "objectClass"} 
      Dim pageRequestControl As New PageResultRequestControl(pageSize)

      ' used to retrieve the cookie to send for the subsequent request      
      Dim pageResponseControl As PageResultResponseControl 
      Dim searchResponse As SearchResponse
      
      ' create a search request: specify baseDn, ldap search filter, 
      ' attributes to return and scope of the search
      Dim searchRequest As New SearchRequest(targetOU, _
                                             ldapSearchFilter, _
                                             SearchScope.Subtree, _
                                             attributesToReturn)
      
      ' attach a page request control to retrieve the results in small chunks
      searchRequest.Controls.Add(pageRequestControl)
      
      
      Dim pageCount As Integer = 0
      Dim count As Integer
      
      ' search in a loop untill there is no more page to retrieve
      While True
         pageCount += 1
         
         searchResponse = CType(ldapConnection.SendRequest(searchRequest), _
                                                                SearchResponse)
         Console.WriteLine(vbCrLf + "Page" + pageCount.ToString() + ": " + _
                                    searchResponse.Entries.Count.ToString() + _
                                    " entries:")
         
         ' print the entries in this page
         count = 0
         Dim entry As SearchResultEntry
         For Each entry In  searchResponse.Entries
	      count = count + 1
            Console.WriteLine(count.ToString() + ":" + entry.DistinguishedName)
         Next entry
         
         
         ' retrieve the cookie 
         If searchResponse.Controls.Length <> 1 Or _
            Not TypeOf searchResponse.Controls(0) Is PageResultResponseControl _
            Then
            Console.WriteLine("The server did not return a " + _
                                    "PageResultResponseControl as expected.")
            Return
         End If
         
         pageResponseControl = CType(searchResponse.Controls(0), _
                                                PageResultResponseControl)
         
         ' if responseControl.Cookie.Length is 0 then there 
         ' is no more page to retrieve so break the loop
         If pageResponseControl.Cookie.Length = 0 Then
            Exit While
         End If 
         ' set the cookie from the response control to retrieve the next page
         pageRequestControl.Cookie = pageResponseControl.Cookie
      End While
      
      Console.WriteLine(vbCrLf + "Paged search is completed successfully." _
                                                                     + vbCrLf)
   End Sub 'DoPagedSearch
   
   
   
   
   
   Shared Sub DeleteObjectsToSearch()
      Dim i As Integer
      For i = 1 To numberOfPages * pageSize
         Dim dn As String = "OU=object" + i.ToString() + "," + targetOU
         ldapConnection.SendRequest(New DeleteRequest(dn))
         Console.WriteLine("OU=object" + i.ToString() + _
                                                      " deleted successfully.")
      Next i
   End Sub 'DeleteObjectsToSearch
End Class 'App 
' end class App

End Namespace
