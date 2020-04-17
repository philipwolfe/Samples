' ===================================
'   File:      BatchRequest.vb
'  
'   Summary:   Demonstrates the use of the DsmlSoapHttpConnection & 
'              DsmlRequestDocument class to do various directory 
'              operations in batch.
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
'                                                               BatchRequest.vb
'
' To run: App.exe <dsmlServer> <user> <pwd> <domain> <targetOU>
'     Eg: App.exe http://myDC1.testDom.fabrikam.com/dsml/adssoap.dsmlx  user1  
'                   secret@~1 testDom OU=samples,DC=testDom,DC=fabrikam,DC=com
'

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
         SendBatchRequest()         
         Console.WriteLine(vbCrLf + "Application Finished Successfully!!!")
      Catch e As Exception
         Console.WriteLine(vbCrLf + "Unexpected exception occured:" + _
                           vbCrLf + vbTab + e.GetType().Name + ":" + e.Message)
      End Try
   End Sub 'Main
   
   
   
   
   Shared Function GetParameters(args() As String) As Boolean
      If args.Length <> 5 Then
         Console.WriteLine("Usage: App.exe <dsmlServer> <user> <pwd> " + _
                                                   "<domain> <targetOU>")
         Return false
      End If
      
      ' initialize variables
      dsmlServer = args(0)
      credential = New NetworkCredential(args(1), args(2), args(3))
      targetOU = args(4)

      Return true
   End Function 'GetParameters
   
   
   
   
   Shared Sub CreateConnection()
      dsmlConnection = New DsmlSoapHttpConnection(New Uri(dsmlServer))
      dsmlConnection.Credential = credential
      Console.WriteLine("DsmlSoapHttpConnection is created successfully.")
   End Sub 'CreateConnection
   
   
   
   
   Shared Sub SendBatchRequest()
      Dim batchRequest As New DsmlRequestDocument()
      Dim addRequest As AddRequest
      Dim modifyRequest As ModifyRequest
      Dim compareRequest As CompareRequest
      Dim deleteRequest As DeleteRequest
      
      ' create new OUs under the specified OU
      ou1 = "OU=sampleOU1," + targetOU
      ou2 = "OU=sampleOU2," + targetOU
      ou3 = "OU=sampleOU3," + targetOU
      Dim objectClass As String = "organizationalUnit"
      
      
      ' add multiple requests (make sure )
      addRequest = New AddRequest(ou1, objectClass)
      addRequest.RequestId = "Add1"
      batchRequest.Add(addRequest)
      
      addRequest = New AddRequest(ou2, objectClass)
      addRequest.RequestId = "Add2"
      batchRequest.Add(addRequest)
      
      addRequest = New AddRequest(ou3, objectClass)
      addRequest.RequestId = "Add3"
      batchRequest.Add(addRequest)
      
      
      compareRequest = New CompareRequest(ou1, "distinguishedName", ou1)
      compareRequest.RequestId = "Compare1"
      batchRequest.Add(compareRequest)
      
      deleteRequest = New DeleteRequest(ou1)
      deleteRequest.RequestId = "Delete1"
      batchRequest.Add(deleteRequest)
      
      compareRequest = New CompareRequest(ou2, "distinguishedName", ou2)
      compareRequest.RequestId = "Compare2"
      batchRequest.Add(compareRequest)
      
      modifyRequest = New ModifyRequest(ou2, _
                                        DirectoryAttributeOperation.Replace, _
                                        "description", _
                                        "Testing BatchRequest")

      modifyRequest.RequestId = "Modify1"
      batchRequest.Add(modifyRequest)
      
      deleteRequest = New DeleteRequest(ou2)
      deleteRequest.RequestId = "Delete2"
      batchRequest.Add(deleteRequest)
      
      deleteRequest = New DeleteRequest(ou3)
      deleteRequest.RequestId = "Delete3"
      batchRequest.Add(deleteRequest)
      
      Dim batchResponse As DsmlResponseDocument = _
                                    dsmlConnection.SendRequest(batchRequest)
      
      Dim response As DirectoryResponse
      For Each response In  batchResponse
         Console.WriteLine(response.GetType().Name + ": " + vbTab + _
                           "Id=" + response.RequestId + "," + vbTab + _
                           "ResultCode=" + response.ResultCode.ToString())
      Next response
      
      Console.WriteLine("Batch request has been processed successfully.")
   End Sub 'SendBatchRequest
End Class 'App 




End Namespace
