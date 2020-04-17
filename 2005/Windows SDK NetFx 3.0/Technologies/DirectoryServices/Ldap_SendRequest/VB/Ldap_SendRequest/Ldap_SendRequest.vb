' ===================================
'   File:      SendRequest.vb
'  
'   Summary:   Demonstrates the use of the LdapConnection class to do 
'                     various directory operations.
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
'                                                                SendRequest.vb
' To run: App.exe <ldapServer> <user> <pwd> <domain> <targetOU>
'       Eg: App.exe myDC1.testDom.fabrikam.com  user1  secret@~1 testDom 
'                               OU=samples,DC=testDom,DC=fabrikam,DC=com

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
   Private Shared ldapConnection As LdapConnection
   Private Shared ldapServer As String
   Private Shared credential As NetworkCredential
   Private Shared targetOU As String 'dn of an OU. eg: "OU=sample,DC=fabrikam,DC=com"

   ' object DNs that are created in the sample
   Private Shared ou1, ou2, ou3 As String
   
   Private Sub New()
   End Sub   
   
   Public Shared Sub Main(args() As String)
      Try
         if Not GetParameters(args) Then
            Return
         End If

         CreateConnection()
         Add()
         Modify()
         Rename()
         Move()
         Compare()
         Search()
         DeleteLeafObject()
         DeleteTree()
         
         
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
   
   
   
   
   Shared Sub Add()
      ' create new OUs under the specified OU
      ou1 = "OU=sampleOU1," + targetOU
      ou2 = "OU=sampleOU2," + targetOU
      ou3 = "OU=sampleOU3," + targetOU
      Dim objectClass As String = "organizationalUnit"
      
      
      ' create a request to add the new object
      Dim addRequest As New AddRequest(ou1, objectClass)
      
      ' send the request through the connection
      ldapConnection.SendRequest(addRequest)
      
      ' create a request to add the new object
      addRequest = New AddRequest(ou2, objectClass)
      
      ' send the request through the connection
      ldapConnection.SendRequest(addRequest)
      
      ' create a request to add the new object
      addRequest = New AddRequest(ou3, objectClass)
      
      ' send the request through the connection
      ldapConnection.SendRequest(addRequest)
      
      Console.WriteLine("Objects are created successfully.")
   End Sub 'Add
   
   
   
   
   
   
   Shared Sub Modify()
      Dim attributeName As String = "description"
      Dim newValue() As String = {"This is a sample OU"}
      
      ' create a request to modify the object
      Dim modifyRequest As New ModifyRequest( _
                                          ou1, _
                                          DirectoryAttributeOperation.Replace, _
                                          attributeName, _
                                          newValue)
      
      ' send the request through the connection
      ldapConnection.SendRequest(modifyRequest)
      
      Console.WriteLine("Object is modified successfully.")
   End Sub 'Modify
   
   
   
   
   
   Shared Sub Rename()
      ' keep the parent container same to do just rename without moving
      Dim newParent As String = targetOU 
      Dim newName As String = "OU=sampleOUNew"
      
      ' create a request to rename the object
      Dim modDnRequest As New ModifyDNRequest(ou1, newParent, newName)
      
      ' send the request through the connection
      ldapConnection.SendRequest(modDnRequest)

      ' this is the new path of the object after rename operation
      ou1 = "OU=sampleOUNew," + targetOU 
      Console.WriteLine("Object has been renamed successfully.")
   End Sub 'Rename
   
   
   
   
   Shared Sub Move()
      ' move sampleOU3 under sampleOU2
      Dim newParent As String = ou2

      ' keep the name same to just move without renaming
      Dim newName As String = "OU=sampleOU3" 
      ' create a request to move the object
      Dim modDnRequest As New ModifyDNRequest(ou3, newParent, newName)
      
      ' send the request through the connection
      ldapConnection.SendRequest(modDnRequest)
      
      Console.WriteLine("Object is moved successfully.")
   End Sub 'Move
   
   
   
   
   Shared Sub Compare()
      Dim attributeName As String = "description"
      Dim valueToCompareAgainst As String = "This is a sample OU"
      
      ' create a request to do compare on the object
      Dim compareRequest As New CompareRequest(ou1, _
                                               attributeName, _
                                               valueToCompareAgainst)
      
      ' send the request through the connection
      Dim compareResponse As CompareResponse = _
                            CType(ldapConnection.SendRequest(compareRequest), _
                                                    CompareResponse)
      
      Console.WriteLine("The result of the comparison is:" + _
                                    compareResponse.ResultCode.ToString())
   End Sub 'Compare
   
   
   
   
   Shared Sub Search()
      Dim ldapSearchFilter As String = _
                              "(&(objectClass=organizationalUnit)(ou=sample*))"

      ' return ALL attributes that have some value
      Dim attributesToReturn As String() = Nothing
      
      ' create a search request: specify baseDn, ldap search filter, 
      ' attributes to return and scope of the search
      Dim searchRequest As New SearchRequest( _
                                             targetOU, _
                                             ldapSearchFilter, _
                                             SearchScope.Subtree, _
                                             attributesToReturn)
      
      
      ' send the request through the connection
      Dim searchResponse As SearchResponse = _
                CType(ldapConnection.SendRequest(searchRequest), SearchResponse)
      
      ' print the returned entries & their attributes
      PrintSearchResponse(searchResponse)
      
      Console.WriteLine("Search is completed successfully." + vbCrLf)
   End Sub 'Search
   
    Shared  Sub PrintSearchResponse(ByRef searchResponse As SearchResponse)
        Dim utf8 As UTF8Encoding = New UTF8Encoding(false, true)
        
        ' print the returned entries & their attributes
        Console.WriteLine(vbCrLf + "Search matched " + _
                          searchResponse.Entries.Count.ToString() + " entries:")
        
        Dim i as Int32=0
        Dim entry As SearchResultEntry
        For Each entry In searchResponse.Entries
            i += 1
        	Console.WriteLine(vbCrLf + i.ToString() + "- "  _
        	                                        + entry.DistinguishedName)
            ' retrieve all attributes
            Dim attr As DirectoryAttribute
            For Each attr in entry.Attributes.Values
                Console.Write(attr.Name + "=" )

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
                        Console.Write(ByteArrayToHexString(value) + "  ")
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
             
   
   
   
   Shared Sub DeleteLeafObject()
      ' create a request to delete the object (ou1 is a leaf object)
      Dim deleteRequest As New DeleteRequest(ou1)
      
      ' send the request through the connection
      ldapConnection.SendRequest(deleteRequest)
      
      Console.WriteLine("Leaf object is deleted successfully.")
   End Sub 'DeleteLeafObject
   
   
   
   
   Shared Sub DeleteTree()
      ' create a request to delete the object 
      ' (ou2 is not a leaf object since it has child objects)
      Dim deleteRequest As New DeleteRequest(ou2)
      
      ' add a tree-delete control to the request
      deleteRequest.Controls.Add(New TreeDeleteControl())
      
      ' send the request through the connection
      ldapConnection.SendRequest(deleteRequest)
      
      Console.WriteLine("Object tree is deleted successfully.")
   End Sub 'DeleteTree
End Class 'App

End Namespace
