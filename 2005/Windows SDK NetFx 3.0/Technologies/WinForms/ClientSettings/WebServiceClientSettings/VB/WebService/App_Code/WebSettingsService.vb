'---------------------------------------------------------------------
'  This file is part of the Microsoft .NET Framework SDK Code Samples.
' 
'  Copyright (C) Microsoft Corporation.  All rights reserved.
' 
'This source code is intended only as a supplement to Microsoft
'Development Tools and/or on-line documentation.  See these other
'materials for detailed information regarding Microsoft code samples.
' 
'THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
'KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
'IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
'PARTICULAR PURPOSE.
'---------------------------------------------------------------------

Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols

' NOTE: This Web service uses ASP.NET Profiles to store its data. 
' The user's credentials are used to determine which user's settings are fetched.
' See the Client WebServiceSettingsProvider.vb for some ways of providing the proper credentials.
' See the ASP.NET Profiles documentation for more details.

' NOTE: The simple API implemented in this Web service allows the caller to specify 
' which application's settings to fetch for that authenticated user. This is NOT a 
' completely secure way of proceeding in a production app - applications may be able
' to spoof other applications also running on that user's machine by getting the provider 
' to pass in a different application name. Less likely, a direct call to the Web service 
' outside of the context of the app may be able to spoof as another application, though 
' again, if the credentials were established properly, the user would still only be able 
' to get to their own settings.

<WebService(Namespace := "http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1, EmitConformanceClaims:=True)> _
Public Class WebSettingsService
     Inherits System.Web.Services.WebService

    ' The following method needed for the Web Service proxy
    <WebMethod()> _
    Public Function GetServerTime() As String

        Return System.DateTime.Now.ToString()

    End Function

    <WebMethod()> _
    Public Function GetAppConfigProperty(ByVal appName As String, ByVal propName As String) _
                                         As Object

        Dim profile As ProfileGroupBase

        ' Note: the following code assumes that both appName and propName are valid names and match
        ' entries in the <profile> section of web.config. A mismatch will cause an error. Additional 
        ' checking could be performed here to make it more robust.
        profile = Me.Context.Profile.GetProfileGroup(appName)

        Return profile.GetPropertyValue(propName)

    End Function

    <WebMethod()> _
    Public Sub SetAppConfigProperty(ByVal appName As String, _
                                    ByVal propName As String, _
                                    ByVal newvalue As String)


        Dim profile As ProfileGroupBase

        ' Note: the following code assumes that both appName and propName are valid names and match
        ' entries in the <profile> section of web.config. A mismatch will cause an error. Additional 
        ' checking could be performed here to make it more robust.
        profile = Me.Context.Profile.GetProfileGroup(appName)
        profile.SetPropertyValue(propName, newvalue)

    End Sub

End Class
