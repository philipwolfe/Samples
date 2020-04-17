' ===================================
'   File:      PrintDomain.vb
'  
'   Summary:   Demonstrates how to connect to the currently logged-in domain.
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
'                                                               PrintDomain.vb
' To run: App.exe

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

   Private Sub New()
   End Sub
   
   Public Shared Sub Main()
      Try
         Console.WriteLine("Creating LdapConnection to " + _
                                            "currently logged-in domain.")

         Dim ldapConnection As New LdapConnection(CStr(Nothing))
         
         Console.WriteLine("Sending a RootDSE search to discover " + _
                                            "the fully qualified domain name.")

         Dim search As New SearchRequest()
         search.Scope = SearchScope.Base ' should be Base for doing a RootDSE search
         Dim response As SearchResponse = _
                                CType(ldapConnection.SendRequest(search), _
                                      SearchResponse)
         
         ' dnsHostName is in the form dcName.domainName.xyz.abc.com
         ' so we need to get the substring after the 1st '.' character
         Dim dnsHostName As String = _
                          CStr(response.Entries(0).Attributes("dnsHostName")(0))

         Console.WriteLine(vbCrLf + "Your domain is:" + _
                          dnsHostName.Substring(dnsHostName.IndexOf("."c) + 1))
         
         Console.WriteLine(vbCrLf + "Application Finished Successfully!!!")
         
      Catch e As Exception
         Console.WriteLine(vbCrLf + "Unexpected exception occured:" + _
                           vbCrLf + vbTab + e.GetType().Name + ":" + e.Message)
      End Try
   End Sub 'Main
End Class 'App 

End Namespace
