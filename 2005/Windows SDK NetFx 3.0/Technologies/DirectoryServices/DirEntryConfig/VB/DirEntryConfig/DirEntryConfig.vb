'=====================================================================
'  File:      DirectoryEntryConfigurationSettings.vb
'
'  Summary:   This sample shows how to get and set directory entry
'             configuration settings using DirectoryEntryConfiguration
'             class
'
'---------------------------------------------------------------------
'  This file is part of the Microsoft .NET SDK Code Samples.
'
'  Copyright (C) Microsoft Corporation.  All rights reserved.
'
'This source code is intended only as a supplement to Microsoft
'Development Tools and/or on-line documentation.  See these other
'materials for detailed information regarding Microsoft code samples.
'
'THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
'KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
'IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
'PARTICULAR PURPOSE.
'=====================================================================

Imports System
Imports System.Security.Permissions

Imports System.DirectoryServices


<Assembly: System.Reflection.AssemblyVersion("1.0.0.0")> 
<Assembly: SecurityPermission(SecurityAction.RequestMinimum, Execution:=True)> 
<Assembly: DirectoryServicesPermission(SecurityAction.RequestMinimum)> 


Namespace Microsoft.Samples.DirectoryServices

    Public NotInheritable Class DirectoryEntryConfigurationSettingsSample
        ' Change the value of next constant to bind to a particular domain
        ' Value of null means current domain
        Private Shared domainADsPath As String = Nothing

        Public Overloads Shared Sub Main()
            Try
                DirectoryEntryConfigurationSettings()

                Console.WriteLine()
                Console.WriteLine("Application Finished Successfully!!!")
            Catch e As Exception
                Console.WriteLine()
                Console.WriteLine("Unexpected exception occured:")
                Console.WriteLine(e.GetType().ToString() + ":" + e.Message)
            End Try
        End Sub 'Main

        Private Sub New()
        End Sub

        Shared Sub DirectoryEntryConfigurationSettings()
            ' Bind to current domain
            Dim entry As New DirectoryEntry(domainADsPath)
            Dim entryConfiguration As DirectoryEntryConfiguration = _
                                                            entry.Options

            ' Display directory entry configuration
            ' Notice that options property (entry.Options) is the parameter to 
            '  the function
            DisplayConfigurationEntryConfiguration(entry.Options)

            ' Enable paged search and referral chasing in directory entry 
            '  Configuration()
            ' Clear security masks in directory entry configuration
            ' Notice that the changes are set in the reference object 
            '  (entryConfiguration object)
            entryConfiguration.PageSize = 512
            entryConfiguration.Referral = ReferralChasingOption.Subordinate
            ' Or can be done directly to the property (entry.Options property)
            entry.Options.SecurityMasks = SecurityMasks.None

            ' Display directory entry configuration modified
            ' Notice that options property (entry.Options) is the parameter to
            '  the function
            DisplayConfigurationEntryConfiguration(entry.Options)

            ' Set the defaults again for directory entry configuration
            SetDefaultsForEntryConfiguration(entryConfiguration)

            ' Display directory entry configuration modified to defaults
            DisplayConfigurationEntryConfiguration(entry.Options)
        End Sub 'DirectoryEntryConfigurationSettings

        Shared Sub SetDefaultsForEntryConfiguration(ByVal entryConfiguration _
                                                As DirectoryEntryConfiguration)
            entryConfiguration.PageSize = 512
            entryConfiguration.PasswordEncoding = _
                                    PasswordEncodingMethod.PasswordEncodingSsl
            entryConfiguration.PasswordPort = 636
            entryConfiguration.Referral = ReferralChasingOption.External
            entryConfiguration.SecurityMasks = SecurityMasks.Owner Or _
                                    SecurityMasks.Group Or SecurityMasks.Dacl
        End Sub 'SetDefaultsForEntryConfiguration


        Shared Sub DisplayConfigurationEntryConfiguration( _
                    ByVal entryConfiguration As DirectoryEntryConfiguration)
            Console.WriteLine("DISPLAYING DIRECTORY ENTRY CONFIGURATION")
            Console.WriteLine(("Server: " + _
                                entryConfiguration.GetCurrentServerName()))
            Console.WriteLine(("Page Size: " + _
                                entryConfiguration.PageSize.ToString()))
            Console.WriteLine(("Password Encoding: " + _
                                entryConfiguration.PasswordEncoding.ToString()))
            Console.WriteLine(("Password Port: " + _
                                entryConfiguration.PasswordPort.ToString()))
            Console.WriteLine(("Referral: " + _
                                entryConfiguration.Referral.ToString()))
            Console.WriteLine(("Security Masks: " + _
                                entryConfiguration.SecurityMasks.ToString()))
            Console.WriteLine(("Is Mutually Authenticated: " + _
                            entryConfiguration.IsMutuallyAuthenticated().ToString()))
            Console.WriteLine()
        End Sub 'DisplayConfigurationEntryConfiguration
    End Class 'DirectoryEntryConfigurationSettingsSample
End Namespace 'Microsoft.Samples.DirectoryServices