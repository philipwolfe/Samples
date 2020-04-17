' ===================================
'   File:      Referral.vb
'  
'   Summary:   Demonstrates sending a request that will generate a referral.
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
'                                                                   Referral.vb
' To run: App.exe <ldapServer> <user> <pwd> <domain>
'       Eg: App.exe myDC1.testDom.fabrikam.com  user1  secret@~1 testDom

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

   Private Sub New()
   End Sub
   
   Public Shared Sub Main(args() As String)
      Try
         if Not GetParameters(args) Then
            Return
         End If

         CreateConnection()
         ReferralTest()         
         Console.WriteLine(vbCrLf+ "Application Finished Successfully!!!")
      Catch e As Exception
         Console.WriteLine(vbCrLf + "Unexpected exception occured:" + _
                           vbCrLf + vbTab + e.GetType().Name + ":" + e.Message)
      End Try
   End Sub 'Main
   
   
   
   
   Shared Function GetParameters(args() As String) As Boolean
      If args.Length <> 4 Then
         Console.WriteLine("Usage: App.exe <ldapServer> <user> <pwd> <domain>")
         Return false
      End If
      
      ' initialize variables
      ldapServer = args(0)
      credential = New NetworkCredential(args(1), args(2), args(3))

      Return true
   End Function 'GetParameters
   
   
   
   
   Shared Sub CreateConnection()
      ldapConnection = New LdapConnection(ldapServer)
      ldapConnection.Credential = credential
      Console.WriteLine("LdapConnection is created successfully.")
   End Sub 'CreateConnection
   
   
   
   
   Shared Sub ReferralTest()
      Console.WriteLine("Sending a request that will generate a referral")
      Dim searchRequest As New SearchRequest()
      searchRequest.DistinguishedName = _
                                  "OU=Users,DC=non-existing,DC=fabrikam,DC=com"
      
      ' send the request through the connection
      Dim response As DirectoryResponse = _
                                      ldapConnection.SendRequest(searchRequest)
      
      Console.WriteLine("ResultCode:" + response.ResultCode.ToString())
      Dim referral As Uri
      For Each referral In  response.Referral
         Console.WriteLine("Referral:" + referral.ToString())
      Next referral
      
      Console.WriteLine("Referral is received successfully.")
   End Sub 'ReferralTest
End Class 'App 

End Namespace
