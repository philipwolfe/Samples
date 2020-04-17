' ===================================
'   File:      Exceptions.vb
'  
'   Summary:   Demonstrates DSML exceptions.
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
'                                                           Exceptions.vb
'
' To run: App.exe <dsmlServer> <user> <pwd> <domain>
'     Eg: App.exe http://myDC1.testDom.fabrikam.com/dsml/adssoap.dsmlx  
'                                                     user1  secret@~1 testDom

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
   Private Shared dsmlServer As String
   Private Shared credential As NetworkCredential
   
    Private Sub New()
    End Sub
   
   Public Shared Sub Main(args() As String)
      Try
         if Not GetParameters(args) Then
            Return
         End If
         
         CreateConnection()
         HandleErrorResponseException()
         HandleWebException()
         
         Console.WriteLine(vbCrLf + "Application Finished Successfully!!!")
      Catch e As Exception
         Console.WriteLine(vbCrLf + "Unexpected exception occured:" + _
                           vbCrLf + vbTab + e.GetType().Name + ":" + e.Message)
      End Try
   End Sub 'Main
   
   
   
   
   Shared Function  GetParameters(args() As String) As Boolean
      If args.Length <> 4 Then
         Console.WriteLine("Usage: App.exe <dsmlServer> <user> <pwd> <domain>")
         Return false
      End If
      
      ' initialize variables
      dsmlServer = args(0)
      credential = New NetworkCredential(args(1), args(2), args(3))

      Return true
   End Function 'GetParameters
   
   
   
   
   Shared Sub CreateConnection()
      dsmlConnection = New DsmlSoapHttpConnection(New Uri(dsmlServer))
      dsmlConnection.Credential = credential
      Console.WriteLine("DsmlSoapHttpConnection is created successfully.")
   End Sub 'CreateConnection
   
   
   Shared Sub HandleErrorResponseException()
      Try
         Console.WriteLine(vbCrLf + "Sending a compare request with " + _
                                                  "an invalid attribute name..")

         ' the request will generate an ErrorResponseException
         ' because the attribute name is not valid 
         ' according to the dsmlv2 schema 
         ' (eg.: $ is not allowed in attribute names)
         dsmlConnection.SendRequest(New CompareRequest( _
                                               "CN=myUser,DC=fabrikam,DC=com", _
                                               "$description", _
                                               "attrVal"))
      Catch e As ErrorResponseException
         Dim errResponse As DsmlErrorResponse = e.Response
         Console.WriteLine(e.GetType().Name + ": Message:" + e.Message)
         Console.WriteLine(errResponse.GetType().Name + ":" + vbCrLf + _
                           "Type:" + errResponse.Type.ToString() + vbCrLf + _
                           "Message:" + errResponse.Message)
      End Try
   End Sub 'HandleErrorResponseException
   
   
   Shared Sub HandleWebException()
      Try
         Console.WriteLine(vbCrLf + "Trying to authenticate " + _
                                                   "with bogus credentials...")

         dsmlConnection.Credential = New NetworkCredential("bogusUser", _
                                                           "bogusPwd", _
                                                           "bogusDom")

         ' send an empty batch request which is a valid DSML request
         dsmlConnection.SendRequest(New DsmlRequestDocument())
      Catch e As WebException
         Console.WriteLine(e.GetType().Name + ": Message:" + e.Message)
         
         ' revert back to original credentials supplied
         dsmlConnection.Credential = credential
      End Try
   End Sub 'HandleWebException
End Class 'App 
' end class App


End Namespace
