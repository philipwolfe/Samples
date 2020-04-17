'-----------------------------------------------------------------------
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
'-----------------------------------------------------------------------

Imports System.Collections.Specialized
Imports System.Configuration
Imports System.Net

' This class shows the implementation of a SettingsProvider-derived class that 
' plugs settings feature.  We combine this with the sample XML Web
' Service included with this sample to store the settings on the server.

Public Class WebServiceSettingsProvider
    Inherits SettingsProvider

    Private appName As String = Application.ProductName

    Public Sub New()

        MyBase.New()

    End Sub

    Public Overrides Sub Initialize(ByVal name As String, _
                                    ByVal config As NameValueCollection)

        MyBase.Initialize(appName, config)

    End Sub ' Initialize

    ' Application name used by Web service to distinguish settings for different applications 
    ' retrieving settings from the same service.

    Public Overrides Property ApplicationName() As String

        Get
            Return Me.appName
        End Get

        Set(ByVal value As String)
            Me.appName = value
        End Set

    End Property ' ApplicationName

    ' The main "getter" accessor for the provider. The application's settings class
    ' internally calls this method to fetch the settings, and for this provider, that means contacting
    ' the Web service (through the localhost.WebSettingsService proxy) and requesting the values there.
    ' The SettingsPropertyCollection is populated with SettingsProperty instances when the 
    ' ApplicationSettingsBase base class for the settings wrapper reflects over the settings 
    ' wrapper and uses the various attributes to determine the settings exposed.

    Public Overrides Function GetPropertyValues( _
                                      ByVal context As SettingsContext, _
                                      ByVal settingProps As SettingsPropertyCollection) _
                                      As SettingsPropertyValueCollection

        Dim values As SettingsPropertyValueCollection
        Dim value As SettingsPropertyValue
        Dim svc As localhost.WebSettingsService

        ' First, create a place to put all the properties and their values.
        values = New SettingsPropertyValueCollection

        ' Create an instance of our web service class.
        svc = New localhost.WebSettingsService

        ' NOTE: the Web service included in this sample uses ASP.NET Profiles 
        ' to store the users's settings. By default, ASP.NET will use the user's 
        ' credentials to determine who the user is, and therefore this provider
        ' needs to determine a secure way of providing those credentials. 
        ' The following line of code will allow you to test this sample, but 
        ' should not be considered secure out of the box.



        ' ################# NOTE! #################
        ' 1. Uncomment before running this sample or you will get a 401: access denied exception
        ' 2. Disallow 'Anonymous access' and 'Allow Integrated Windows Authentication' the Web Service VDIR.
        'svc.Credentials = CredentialCache.DefaultCredentials



        ' Now, for each of the properties they're asking for, go and try
        ' to fetch it from the server.
        '
        ' Exercise for the reader: bundle requests so that there is only one request, 
        ' instead of one per property. For a non-trivial group of settings, the following
        ' would not perform as well as batching property requests.
        For Each setting As SettingsProperty In settingProps

            value = New SettingsPropertyValue(setting)
            value.SerializedValue = svc.GetAppConfigProperty(appName, setting.Name) ' 401 error? See above.
            value.IsDirty = False
            values.Add(value)

        Next

        Return values

    End Function

    ' The corresponding "setter" accessor for properties - calls to this method are triggered 
    ' by calling Save() on the application's settings class.
    Public Overrides Sub SetPropertyValues( _
                                ByVal context As SettingsContext, _
                                ByVal ppvc As SettingsPropertyValueCollection)

        ' Create an instance of our WebService class so we can set properties
        Dim svc As localhost.WebSettingsService
        svc = New localhost.WebSettingsService

        ' NOTE: the Web service included in this sample uses ASP.NET Profiles 
        ' to store the users's settings. By default, ASP.NET will use the user's 
        ' credentials to determine who the user is, and therefore this provider
        ' needs to determine a secure way of providing those credentials. 
        ' The following line of code will allow you to test this sample, but 
        ' should not be considered secure out of the box.



        ' ################# NOTE! #################
        ' 1. Uncomment before running this sample or you will get a 401: access denied exception
        ' 2. Disallow 'Anonymous access' and 'Allow Integrated Windows Authentication' the Web Service VDIR.
        'svc.Credentials = CredentialCache.DefaultCredentials



        ' Now, for each property we're given, if it's dirty, go and set the
        ' property via the XML Web Service
        For Each value As SettingsPropertyValue In ppvc
            If value.IsDirty Then
                svc.SetAppConfigProperty(appName, value.Name, value.SerializedValue) ' 401 error? See above.
            End If
        Next

    End Sub

End Class
