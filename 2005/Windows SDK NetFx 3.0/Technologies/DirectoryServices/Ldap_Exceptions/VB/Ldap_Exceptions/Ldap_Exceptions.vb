' ===================================
'   File:      Exceptions.vb
'  
'   Summary:   Demonstrates exceptions like LdapException, 
'              DirectoryOperationException etc.
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
'                                                                 Exceptions.vb
'
' To run: App.exe <ldapServer> <user> <pwd> <domain>
'     Eg: App.exe myDC1.testDom.fabrikam.com  user1  secret@~1 testDom

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
    Shared ldapConnection As LdapConnection 
    Shared ldapServer As String  
    Shared credential As NetworkCredential 

    Private Sub New()
    End Sub

    Public Shared  Sub Main(ByVal args() As String)        
        Try
            if Not GetParameters(args) Then
                Return
            End If

            CreateConnection()
            HandleLdapException()
            HandleDirectoryOperationException()
            HandlePlatformNotSupportedException()
            HandleBerConversionException()
            HandleDirectoryArgumentNullException()
            HandleTlsOperationException()
            HandleInvalidOperationException()
 
            Console.WriteLine(vbCrLf + "Application Finished Successfully!!!")
        Catch e As Exception
            Console.WriteLine(vbCrLf + "Unexpected exception occured:" + _
                           vbCrLf + vbTab + e.GetType().Name + ":" + e.Message)
        End Try
    End Sub
 
 
 
    Shared Function GetParameters(args() As String) As Boolean
        If args.Length <> 4 Then
            Console.WriteLine("Usage: App.exe <ldapServer> <user> <pwd> <domain>")
            Return false
        End If
 
        ' initialize variables
        ldapServer = args(0)
        credential = New NetworkCredential(args(1), args(2), args(3))

        Return true
    End Function
 
 
 
    Shared  Sub CreateConnection()
        ldapConnection = New LdapConnection(ldapServer)        
        ldapConnection.Credential = credential
        Console.WriteLine("LdapConnection is created successfully.")
    End Sub
 
    Shared  Sub HandleLdapException()
        Try
            Console.WriteLine(vbCrLf + "Trying to connect to an "+ _
                                                       "unknown Ldap server...")

            Dim conn As LdapConnection  = New LdapConnection("badServer")
            conn.Bind()
        Catch e As LdapException
            Console.WriteLine(e.GetType().Name + _
                              ": ErrorCode:"+ e.ErrorCode.ToString() + _
                              ", Message:" + e.Message)
        End Try
 
 
        Try
            Console.WriteLine(vbCrLf + "Trying to authenticate "+ _
                                                    "with bogus credentials...")
                                                    
            ldapConnection.Credential = New NetworkCredential("bogusUser", _
                                                              "bogusPwd", _
                                                              "bogusDom")
            ldapConnection.Bind()
        Catch e As LdapException
            Console.WriteLine(e.GetType().Name + _
                              ": ErrorCode:"+ e.ErrorCode.ToString() + _
                              ", Message:" + e.Message)
 
            ' revert back to original credentials supplied
            ldapConnection.Credential  = credential
        End Try
    End Sub
 
 
    Shared  Sub HandleDirectoryOperationException()
        Try
            Console.WriteLine(vbCrLf + "Sending a delete request " + _
                                                    "with an invalid dn... ")

            ldapConnection.SendRequest(New DeleteRequest("#thisIsAnInValidDN#"))
        Catch e As DirectoryOperationException
            Dim response As DeleteResponse  = CType(e.Response, DeleteResponse)
            Console.WriteLine(e.GetType().Name + ": Message:" + e.Message)
            Console.WriteLine("Response: ResultCode:" + _
                                    response.ResultCode.ToString() + _
                                    " : ErrorMessage:" + response.ErrorMessage)
        End Try
    End Sub
 
 
    Shared  Sub HandlePlatformNotSupportedException()
        Try
            Dim conn As LdapConnection  = New LdapConnection("someServer")
        Catch e As PlatformNotSupportedException
            Console.WriteLine(e.GetType().Name + ": Message:" + e.Message)
 
            ' The application should handle this exception and 
            ' fail gracefully on an unsupported platform
            Console.WriteLine("The application is not supported on " + _
                                           "this platform and will shutdown...")
        End Try
    End Sub
 
 
    Shared  Sub HandleBerConversionException()
        Try
            Console.WriteLine(vbCrLf + "Trying to decode a binary " + _
                                    "value with an incorrect decode string...")

            BerConverter.Decode("{iiiiiiiii}",New Byte(){&H01,&H02,&H03,&H04, _
                                                         &H05,&H05,&H05,&H05, _
                                                         &H05,&H05,&H05})
        Catch e As BerConversionException
            Console.WriteLine(e.GetType().Name + ": Message:" + e.Message)
        End Try
    End Sub
 
 
    Shared  Sub HandleDirectoryArgumentNullException()
        Try
            Console.WriteLine(vbCrLf + "Trying to create " + _
                                       "DirectoryAttribute with null values...")

            Dim attribute As DirectoryAttribute = New DirectoryAttribute( _
                                                    "attrName", _
                                                    New String(){"val1", _
                                                                 Nothing, _
                                                                 "val2"})

        Catch e As ArgumentNullException
            Console.WriteLine(e.GetType().Name + ": Message:" + e.Message)
        End Try
    End Sub
 
 
    Shared  Sub HandleTlsOperationException()    
        Try
            Console.WriteLine(vbCrLf + "Calling StopTransportLayerSecurity()...")
            ldapConnection.SessionOptions.StopTransportLayerSecurity()
        Catch e As TlsOperationException
            Console.WriteLine(e.GetType().Name + ": Message:" + e.Message)
        End Try
    End Sub
 
 
    Shared  Sub HandleInvalidOperationException()
        Try
            Console.WriteLine(vbCrLf + "Trying anonymous authentication " + _
                                                  "with a non-null credential ")

            ldapConnection.AuthType = AuthType.Anonymous
            ldapConnection.Credential = New NetworkCredential("userName", _
                                                              "pwd", _
                                                              "domain")
            ldapConnection.Bind()
 
        Catch e As InvalidOperationException
            Console.WriteLine(e.GetType().Name + ": Message:" + e.Message)
            ' revert back
            ldapConnection.AuthType = AuthType.Negotiate
            ldapConnection.Credential = credential
        End Try
    End Sub
 
End Class
' end class App

End Namespace
