' ===================================
'   File:      AsyncSend.vb
'  
'   Summary:   Demonstrates Imports LdapConnection to do directory 
'              operations asynchronously.
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
'                                                                 AsyncSend.vb
'
' To run: App.exe <ldapServer> <user> <pwd> <domain> <targetOU>
'     Eg: App.exe myDC1.testDom.fabrikam.com  user1  secret@~1 
'                             testDom OU=samples,DC=testDom,DC=fabrikam,DC=com            

Option Strict On 
Option Explicit On

Imports System
Imports System.Threading
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
    Shared credential As NetworkCredential
    Shared targetOU As String  'dn of an OU. eg: "OU=sample,DC=fabrikam,DC=com"
 
    Shared numberOfObjects As Integer =  10 


    Private Sub New()
    End Sub
 
    Public Shared Sub Main(ByVal args() As String)
        Try
            if Not GetParameters(args) Then
               Return
            End If

            CreateConnection()
            CreateObjectsToSearch()
            DoNotificationSearch()
            DeleteObjectsToSearch()
 
            Console.WriteLine(vbCrLf + "Application Finished Successfully!!!")
        Catch e As Exception
            Console.WriteLine(vbCrLf + "Unexpected exception occured:" + _
                           vbCrLf + vbTab + e.GetType().Name + ":" + e.Message)
        End Try
    End Sub
 
 
 
    Public Shared Function GetParameters(ByVal args() As String) As Boolean
        If args.Length <> 5 Then
            Console.WriteLine("Usage: App.exe <ldapServer> <user> <pwd> " + _
                                                         "<domain> <targetOU>")
            Return False
        End If
 
        ' initialize variables
        ldapServer = args(0)
        credential = New NetworkCredential(args(1), args(2), args(3))
        targetOU = args(4)

        Return true
    End Function
 
 
 
    Public Shared Sub CreateConnection()
        ldapConnection = New LdapConnection(ldapServer)        
        ldapConnection.Credential = credential
        Console.WriteLine("LdapConnection is created successfully.")
    End Sub
 
 
    Public Shared Sub CreateObjectsToSearch()
        Dim asyncResults(numberOfObjects-1) As IAsyncResult
 
        Dim i As Integer
        For  i = 1 To numberOfObjects
            Dim dn As String =  "OU=object" + i.ToString() + "," + targetOU 
 
            asyncResults(i-1) = ldapConnection.BeginSendRequest( _
                                  New AddRequest(dn, "organizationalUnit"), _
                                  PartialResultProcessing.NoPartialResultSupport, _
                                  Nothing, _
                                  Nothing _
                                  )
        Next
 


        For  i = 0 To asyncResults.Length-1
            ldapConnection.EndSendRequest(asyncResults(i))
            Console.WriteLine("OU=object" + (i+1).ToString() + _
                                                      " created successfully.")
        Next
    End Sub
 
 
 
    Public Shared Sub DoNotificationSearch()    
        Console.WriteLine(vbCrLf + "Doing a notification search asynchronously.")
        Dim asyncResult As IAsyncResult
 
        Dim searchRequest As SearchRequest =  New SearchRequest() 
        searchRequest.DistinguishedName = targetOU
        searchRequest.Scope = SearchScope.OneLevel

        ' attach a notification control
        searchRequest.Controls.Add(New DirectoryNotificationControl())
 
 
        Console.WriteLine("Initiating the notification search " + _
                                                      "with AsyncCallback.")
                                                      
        asyncResult = ldapConnection.BeginSendRequest( _
                        searchRequest, _
                        PartialResultProcessing.ReturnPartialResultsAndNotifyCallback, _
                        AddressOf NotificationSearchCallback, _
                        Nothing)
 
 
        Dim notifications As Integer
        For  notifications = 0 To 4
            Console.WriteLine(vbCrLf + "Sending ModifyRequest so that the " + _
                                    "callback is invoked with the new changes")

            ldapConnection.SendRequest( _
                                 New ModifyRequest( _
                                    "OU=object1," + targetOU, _
                                    DirectoryAttributeOperation.Replace, _
                                    "description", _
                                    "newDescription" + notifications.ToString() _
                                   ))
 
            ' make sure the callback is called
            Console.WriteLine("Waiting for callback to be invoked...")
            While Not asyncCallbackFinished  
                Thread.Sleep(10)  
            End while 
            asyncCallbackFinished = False
        Next
 
 
        Console.WriteLine(vbCrLf + "Calling Abort to finish notification search.")
        ldapConnection.Abort(asyncResult)
 
        Console.WriteLine("CompletedSynchronously=" + _
                                 asyncResult.CompletedSynchronously.ToString())
 
        Console.WriteLine(vbCrLf + "Notification search is completed " + _
                                                      "successfully." +vbCrLf )
    End Sub
 
 
    Shared asyncCallbackFinished As Boolean
    Public Shared Sub NotificationSearchCallback(asyncRes As IAsyncResult)
        asyncCallbackFinished = False
 
        Console.WriteLine("AsyncCallback invoked.")        
 
        Console.WriteLine("IAsyncResult.IsCompleted:" + _
                                             asyncRes.IsCompleted.ToString())
 
        Console.WriteLine("Retrieving partial results.")
        Dim partialResults As PartialResultsCollection =  _
                                      ldapConnection.GetPartialResults(asyncRes) 
 
        Dim count As Integer =  0 
        Dim obj As Object
        For Each obj In partialResults
            count  = count + 1
            If TypeOf obj Is SearchResultEntry Then
                Dim entry As SearchResultEntry = CType(obj, SearchResultEntry)
                Console.WriteLine(entry.DistinguishedName + ": Description:" + _
                                  entry.Attributes("description")(0).ToString())

            Else If TypeOf obj Is SearchResultReference Then 
                Dim reference As SearchResultReference = CType(obj, _
                                                          SearchResultReference)

                Console.WriteLine("SearchResultReference:")
                Dim uri As Uri
                For Each uri In reference.Reference
                    Console.WriteLine(uri)
                Next
            End If
        Next
        asyncCallbackFinished = True
    End Sub    
 
 
 
    Public Shared Sub DeleteObjectsToSearch()    
        Dim asyncResults(numberOfObjects-1) As IAsyncResult
 
        Dim i As Integer
        For  i = 1 To numberOfObjects
            Dim dn As String =  "OU=object" + i.ToString() + "," + targetOU 
 
            asyncResults(i-1) = ldapConnection.BeginSendRequest( _
                                 New DeleteRequest(dn), _
                                 PartialResultProcessing.NoPartialResultSupport, _
                                 Nothing, _
                                 Nothing _
                                )
        Next 

        For  i = 0 To asyncResults.Length-1
            ldapConnection.EndSendRequest(asyncResults(i))
            Console.WriteLine("OU=object" + (i+1).ToString() + _
                                                      " deleted successfully.")
        Next
    End Sub    
 
End Class
' end class App

End Namespace
